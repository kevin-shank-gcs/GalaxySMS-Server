using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;


// https://stackoverflow.com/questions/52321148/conditional-validation-in-mvc-net-core-requiredif
// 
namespace System.ComponentModel.DataAnnotations
{

    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredGuidAttribute : ValidationAttribute
    {
        public RequiredGuidAttribute() => ErrorMessage = "{0} is required and cannot = '00000000-0000-0000-0000-000000000000'";

        public override bool IsValid(object value)
            => value != null && value is Guid && !Guid.Empty.Equals(value);
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredGuidNotEmptyAttribute : ValidationAttribute, IClientModelValidator
    {
        private string PropertyName { get; set; }

        public RequiredGuidNotEmptyAttribute(string propertyName)
        {
            PropertyName = propertyName;
            ErrorMessage = $"The property is required and cannot = {Guid.Empty}."; //used if error message is not set on attribute itself
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            object instance = context.ObjectInstance;
            Type type = instance.GetType();

            if (Guid.TryParse(type.GetProperty(PropertyName).GetValue(instance)?.ToString(), out Guid propertyValue))
            {

                if (value == null || propertyValue == Guid.Empty)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);

        }
        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val-requirediftrue", errorMessage);
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
    }
}
