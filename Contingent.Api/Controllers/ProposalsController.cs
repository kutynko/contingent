﻿using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Contingent.Api.DataAccess;
using Contingent.Api.Models.OrdersContext;

using Action = Contingent.Api.Models.OrdersContext.Action;

namespace Contingent.Api.Controllers
{
    [RoutePrefix("api/proposals")]
    public class ProposalsController : ApiController
    {
        private static ProposalsRepository _db = new ProposalsRepository();

        [Route]
        [ResponseType(typeof(ProposalReadModel[]))]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok((await _db.GetAll()).ToArray());
        }

        [Route("{id:guid}", Name = "Proposal")]
        [ResponseType(typeof(ProposalReadModel))]
        [HttpGet]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var result = await _db.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route]
        [ResponseType(typeof(ProposalReadModel))]
        [HttpPost]
        public async Task<IHttpActionResult> Post(ProposalEditModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = Guid.NewGuid();
            await _db.Insert(id, data);

            return CreatedAtRoute("Proposal", new { id = id }, await _db.GetById(id));
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(ProposalReadModel))]
        [HttpPut]
        public async Task<IHttpActionResult> Put(Guid id, ProposalEditModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recordsUpdated = await _db.Update(id, data);
            
            if (recordsUpdated == 0)
            {
                await _db.Insert(id, data);
                return CreatedAtRoute("Proposal", new { id = id }, await _db.GetById(id));
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var recordsDeleted = await _db.Delete(id);

            if (recordsDeleted == 0)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        #region Lookups

        [Route("students")]
        [ResponseType(typeof(Student[]))]
        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            return Ok(new ProposalsLookups().GetStudents());
        }

        [Route("actions")]
        [ResponseType(typeof(Action[]))]
        public async Task<IHttpActionResult> GetActions()
        {
            return Ok(await new ProposalsLookups().GetActions());
        }

        [Route("reasons")]
        [ResponseType(typeof(Reason[]))]
        public async Task<IHttpActionResult> GetReasons()
        {
            return Ok(await new ProposalsLookups().GetReasons());
        } 

        #endregion
    }
}
