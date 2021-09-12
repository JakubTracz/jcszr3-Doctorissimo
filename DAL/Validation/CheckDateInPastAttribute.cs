using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Validation
{
    public class CheckDateInPastAttribute :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }
    }
}
