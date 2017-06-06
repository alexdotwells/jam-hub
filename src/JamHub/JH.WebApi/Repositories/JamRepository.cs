using JH.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JH.WebApi.Repositories
{
    public class JamRepository : IJamRepository
    {
        private readonly string connectionString;

        public JamRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["JamsConnectionString"].ConnectionString;
        }

        
        public List<Jam> Retrieve()
        {
            const string sql = @"SELECT
                                    J.Id, J.Description, J.Rating, J.JamCode, J.JamName, J.AdddedDate
                                 FROM Jam J
                                 JOIN Title T ON T.Id = J.TitleId
                                 ORDER BY J.AdddedDate DESC";

            var jams = new List<Jam>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                        jams.Add(BuildJam(reader));
                }
            }

            return jams;
        }

        public List<Jam> Retrieve(int id)
        {
            const string sql = @"SELECT
                                   J.Id, J.Description, J.Rating, J.JamCode, J.JamName, J.AdddedDate
                                 FROM Jam J
                                 JOIN Title T ON T.Id = J.TitleId
                                 WHERE T.Id = @Id";

            var jams = new List<Jam>();

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                        jams.Add(BuildJam(reader));
                }
            }

            return jams;
        }

        public Jam Save(Jam jam)
        {
            //TODO
            return new Jam();
        }

        private static Jam BuildJam(IDataRecord reader)
        {
            return new Jam
            {
                JamId = reader.GetInt32(0),
                Description = reader.GetString(1),
                Rating = reader.GetInt32(2),
                JamCode = reader.GetString(3),
                JamName = reader.GetString(4),
                AdddedDate = reader.GetDateTime(5)
            };
        }
    }
}