using System;
using System.Web.Http;
using Contingent.Api.Models;
using Contingent.Api.Models.OrdersContext;

namespace Contingent.Api.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        [Route]
        public Order[] Get()
        {
            return new Order[0];
        }

        [Route("{id:int}")]
        public Order Get(Guid id)
        {
            return null;
        }

        [Route]
        public Order Post(int proposalId, string refNumber, string signedBy)
        {
            //var proposal = _proposals.Get(proposalId);
            //if (proposal.Status != 1)
            //{
            //    throw new InvalidOperationException("Proposal can not be signed");
            //}

            //proposal.Status = 2;
            //_proposals.Save(proposal);

            var result = new Order
            {
                Id = Guid.NewGuid(),
                //Proposal = proposal,
                RefNumber = refNumber,
                SignedOn = DateTime.UtcNow,
                SignedBy = signedBy
            };

            //_scheduler.Add(result);

            return result;
        }

        [Route("{id:int}")]
        //[RequirePermission(Permissions.UndoOrders)]
        public void Delete(int id)
        {

        }
    }
}
