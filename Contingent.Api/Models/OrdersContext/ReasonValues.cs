using System.Collections.Generic;

namespace Contingent.Api.Models.OrdersContext
{
    public class ReasonValues
    {
        public int Id { get; set; }
        public Dictionary<string, string> FieldValues { get; set; }
    }
}