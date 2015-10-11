using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Contingent.Api.Models.OrdersContext;

namespace Contingent.Api.Controllers
{
    [RoutePrefix("api/proposals")]
    public class ProposalsController : ApiController
    {
        private static List<Proposal> _data = new List<Proposal>();

        [Route]
        [ResponseType(typeof(Proposal))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_data.ToArray());
        }

        [Route("{id:int}", Name = "Proposal")]
        [ResponseType(typeof(Proposal))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _data.SingleOrDefault(p => p.Id == id);

            return Ok(result);
        }

        [Route]
        [ResponseType(typeof(Proposal))]
        [HttpPost]
        public IHttpActionResult Post(Proposal data)
        {
            if (data.Actions == null || data.Actions.Count == 0)
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            data.Id = _data.Max(p => p.Id) + 1;
            _data.Add(data);

            return CreatedAtRoute("Proposal", new { id = data.Id }, data);
        }

        [Route("{id:int}")]
        [ResponseType(typeof(Proposal))]
        [HttpPut]
        public IHttpActionResult Put(int id, Proposal data)
        {
            if (data.Actions == null || data.Actions.Count == 0)
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            var target = _data.SingleOrDefault(d => d.Id == data.Id);

            if (target == null)
            {
                data.Id = id;
                _data.Add(data);
                return CreatedAtRoute("Proposal", new { id = id }, data);
            }

            target.Actions = data.Actions;
            target.Reasons = data.Reasons;
            target.Status = data.Status;
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var target = _data.SingleOrDefault(d => d.Id == id);
            if (target == null)
            {
                return NotFound();
            }

            _data.Remove(target);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
