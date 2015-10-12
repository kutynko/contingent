using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Contingent.Api.Models.OrdersContext;
using Contingent.Api.Scheduler;

namespace Contingent.Api.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private static readonly List<Order> _orders = new List<Order>();
        private static readonly List<Proposal> _proposals = new List<Proposal>();
        private static readonly SchedulerService _scheduler = new SchedulerService();


        [Route]
        [ResponseType(typeof(Order[]))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_orders.ToArray());
        }

        [Route("{id:int}", Name = "Order")]
        [ResponseType(typeof(Order))]
        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            var target = _orders.SingleOrDefault(o => o.Id == id);
            if (target == null)
            {
                return NotFound();
            }

            return Ok(target);
        }

        [Route]
        [ResponseType(typeof(Order))]
        [HttpPost]
        public IHttpActionResult Post(Guid proposalId, string refNumber, string signedBy)
        {
            var proposal = _proposals.Single(p => p.Id == proposalId);
            if (proposal.Status != 1)
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            proposal.Status = 2;
            //_proposals.Save(proposal);

            var result = new Order
            {
                Id = Guid.NewGuid(),
                ProposalId = proposalId,
                RefNumber = refNumber,
                SignedOn = DateTime.UtcNow,
                SignedBy = signedBy
            };

            _scheduler.Process(result.ToString());

            return CreatedAtRoute("Order", new { id = result.Id }, result);
        }

        [Route("{id:guid}")]
        //[RequirePermission(Permissions.UndoOrders)]
        public IHttpActionResult Delete(Guid id)
        {
            var target = _orders.SingleOrDefault(o => o.Id == id);
            if (target == null)
            {
                return NotFound();
            }

            _orders.Remove(target);
            _scheduler.Undo(target.ToString());

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
