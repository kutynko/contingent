using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contingent.Api.Validation
{
    public sealed class NumberOfElementsAttribute : ValidationAttribute
    {
        public NumberOfElementsAttribute()
        {
            ErrorMessage = $"Collection must contain at least {AtLeast} element(s)";
        }

        public int AtLeast { get; set; }
    }
}