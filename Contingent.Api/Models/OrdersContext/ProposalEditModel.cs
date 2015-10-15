using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contingent.Api.Validation;

namespace Contingent.Api.Models.OrdersContext
{
    public class ProposalEditModel
    {
        [Required]
        [NumberOfElements(AtLeast = 1)]
        public List<Guid> Students { get; set; }

        [Required]
        [NumberOfElements(AtLeast = 1)]
        public List<Action> Actions { get; set; }

        [Required]
        [NumberOfElements(AtLeast = 1)]
        public List<Reason> Reasons { get; set; }

        public class Action
        {
            public int Id { get; set; }
            public Dictionary<string, string> FieldValues { get; set; }
        }

        public class Reason
        {
            public int Id { get; set; }
            public Dictionary<string, string> FieldValues { get; set; }
        }
    }
}