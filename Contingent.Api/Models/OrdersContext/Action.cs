using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contingent.Api.Models.OrdersContext
{
    public class Action
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public Dictionary<string, object> Fields { get; set; }
    }
}