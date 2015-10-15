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
        public List<ActionValues> Actions { get; set; }

        [Required]
        [NumberOfElements(AtLeast = 1)]
        public List<ReasonValues> Reasons { get; set; }
    }
}