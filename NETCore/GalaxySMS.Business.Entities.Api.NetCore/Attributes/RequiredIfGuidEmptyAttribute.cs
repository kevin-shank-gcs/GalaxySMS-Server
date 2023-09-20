using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;


// https://stackoverflow.com/questions/52321148/conditional-validation-in-mvc-net-core-requiredif
// 
namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredIfGuidEmptyAttribute : ValidationAttribute, IClientModelValidator
    {
        private string PropertyName { get; set; }

        public RequiredIfGuidEmptyAttribute(string propertyName)
        {
            PropertyName = propertyName;
            ErrorMessage = "The {0} field is required."; //used if error message is not set on attribute itself
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            object instance = context.ObjectInstance;
            Type type = instance.GetType();

            if (Guid.TryParse(type.GetProperty(PropertyName).GetValue(instance)?.ToString(), out Guid propertyValue))
            {

                if (propertyValue == Guid.Empty && (value == null || string.IsNullOrWhiteSpace(value.ToString())))
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
