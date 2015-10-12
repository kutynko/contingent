using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contingent.Api.Models.OrdersContext
{
    public class Order
    {
        public Guid Id { get; internal set; }
        public int ProposalId { get; set; }
        public string RefNumber { get; internal set; }
        public string SignedBy { get; internal set; }
        public DateTime SignedOn { get; internal set; }
    }
}