using System;
using System.Collections.Generic;

namespace Contingent.Api.Models.OrdersContext
{
    public class ProposalReadModel
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public List<Guid> Students { get; set; }
        public List<ActionValues> Actions { get; set; }
        public List<ReasonValues> Reasons { get; set; }
    }
}