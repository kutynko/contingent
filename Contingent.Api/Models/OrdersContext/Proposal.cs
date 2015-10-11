using System.Collections.Generic;

namespace Contingent.Api.Models.OrdersContext
{
    public class Proposal
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public List<Student> Students { get; set; }
        public List<Action> Actions { get; set; }
        public List<Reason> Reasons { get; set; }
    }
}