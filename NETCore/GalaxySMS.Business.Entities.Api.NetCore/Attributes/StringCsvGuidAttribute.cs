using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;


// https://stackoverflow.com/questions/52321148/conditional-validation-in-mvc-net-core-requiredif
// 
namespace System.ComponentModel.DataAnnotations
{

    [AttributeUsage(AttributeTargets.Property)]
    public class StringIsCsvGuidAttribute : ValidationAttribute
    {
        public StringIsCsvGuidAttribute() => ErrorMessage = "{0} must be a comma-separated string of Guid values";

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var sValue = value.ToString();
            if (string.IsNullOrEmpty(sValue))
                return true;

            var parts = value.ToString().Split(',');
            foreach (var p in parts)
            {
                var g = Guid.Empty;
                if (!Guid.TryParse(p, out g))
                    return false;
            }
            return true;
        }
    }
}
