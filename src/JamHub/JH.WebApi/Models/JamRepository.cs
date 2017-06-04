using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace JH.WebApi.Models
{
    /// <summary>
    /// TEMP: Storing data in a json file during build
    /// </summary>
    public class JamRepository
    {     
        /// <summary>
        /// Creates a new jam with default values
        /// </summary>
        /// <returns></returns>
        internal Jam Create()
        {
            Jam jam = new Jam
            {
                AdddedDate = DateTime.Now
            };
            return jam;
        }

        /// <summary>
        /// Retrieves the list of jams.
        /// </summary>
        /// <returns></returns>
        internal List<Jam> Retrieve()
        {
            var filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/jam.json");

            var json = System.IO.File.ReadAllText(filePath);

            var jams = JsonConvert.DeserializeObject<List<Jam>>(json);

            return jams;
        }

        /// <summary>
        /// Saves a new jam.
        /// </summary>
        /// <param name="jam"></param>
        /// <returns></returns>
        internal Jam Save(Jam jam)
        {
            // Read in the existing jams
            var jams = this.Retrieve();

            // Assign a new Id
            var maxId = jams.Max(p => p.JamId);
            jam.JamId = maxId + 1;
            jams.Add(jam);

            WriteData(jams);
            return jam;
        }

        /// <summary>
        /// Updates an existing jam
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jam"></param>
        /// <returns></returns>
        internal Jam Save(int id, Jam jam)
        {
            // Read in the existing jams
            var jams = this.Retrieve();

            // Locate and replace the item
            var itemIndex = jams.FindIndex(p => p.JamId == jam.JamId);
            if (itemIndex > 0)
            {
                jams[itemIndex] = jam;
            }
            else
            {
                return null;
            }

            WriteData(jams);
            return jam;
        }


        private bool WriteData(List<Jam> jams)
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/jam.json");

            var json = JsonConvert.SerializeObject(jams, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }
    }
}