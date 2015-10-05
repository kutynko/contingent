using System.Collections.Generic;

namespace Contingent.Api.Models
{
    public class Proposal
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public List<Action> Actions { get; set; }
        public List<Reason> Reasons { get; set; }
    }

    public class Action
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public Dictionary<string, object> Fields { get; set; }
    }

    public class Reason
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public Dictionary<string, object> Fields { get; set; }

    }
}