using JH.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace JH.WebApi.Controllers
{
    public class JamsController : ApiController
    {
        // GET: api/Jams
        [ResponseType(typeof(Jam))]
        public IHttpActionResult Get()
        {
            try
            {
                var jamRepository = new JamRepository();
                return Ok(jamRepository.Retrieve().AsQueryable());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Jams/5
        [ResponseType(typeof(Jam))]
        [Authorize()]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Jam jam;
                var jamRepository = new JamRepository();

                if (id > 0)
                {
                    var jams = jamRepository.Retrieve();
                    jam = jams.FirstOrDefault(p => p.JamId == id);
                    if (jam == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    jam = jamRepository.Create();
                }
                return Ok(jam);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }





        // POST: api/Jams
        [ResponseType(typeof(Jam))]
        public IHttpActionResult Post([FromBody]Jam jam)
        {
            try
            {
                if (jam == null)
                {
                    return BadRequest("Jam cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var jamRepository = new Models.JamRepository();
                var newJam = jamRepository.Save(jam);
                if (newJam == null)
                {
                    return Conflict();
                }
                return Created<Jam>(Request.RequestUri + newJam.JamId.ToString(),
                    newJam);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Jams/5
        public IHttpActionResult Put(int id, [FromBody]Jam jam)
        {
            try
            {
                if (jam == null)
                {
                    return BadRequest("Jam cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var jamRepository = new Models.JamRepository();
                var updatedJam = jamRepository.Save(id, jam);
                if (updatedJam == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Jams/5
        public void Delete(int id)
        {
        }
    }
}
