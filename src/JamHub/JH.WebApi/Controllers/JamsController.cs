using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JH.WebApi.Controllers
{
    public class JamsController : ApiController
    {
        // GET: api/Jams
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Jams/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Jams
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Jams/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Jams/5
        public void Delete(int id)
        {
        }
    }
}
