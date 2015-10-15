using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Contingent.Api.Validation
{
    public sealed class NumberOfElementsAttribute : ValidationAttribute
    {
        private int _atLeast;

        public NumberOfElementsAttribute()
        {
        }

        public int AtLeast
        {
            get { return _atLeast; }
            set
            {
                _atLeast = value;
                ErrorMessage = $"Collection must contain at least {_atLeast} element(s)";
            }
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            return (value is ICollection && ((ICollection)value).Count >= AtLeast) || (value is IEnumerable && Count((IEnumerable)value) >= AtLeast);
        }

        private static int Count(IEnumerable values)
        {
            var result = 0;
            foreach (var item in values) { result++; }
            return result;
        }
    }
}