using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel.DataAnnotations
{
    public sealed class CompareDatesAttribute : ValidationAttribute//, IClientModelValidator
    {
        private string _dateToCompare;
        private const string _errorMessage = "'{0}' must be greater or equal to '{1}'";

        public CompareDatesAttribute(string dateToCompare)
            : base(_errorMessage)
        {
            _dateToCompare = dateToCompare;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(_errorMessage, name, _dateToCompare);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || _dateToCompare == null)
            {
                return ValidationResult.Success;
            }

            var dateToCompare = validationContext.ObjectType.GetProperty(_dateToCompare);
            var dateToCompareValue = dateToCompare.GetValue(validationContext.ObjectInstance, null);
            if (dateToCompareValue != null && value != null && (DateTimeOffset)value < (DateTimeOffset)dateToCompareValue)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }

    //public void AddValidation(ClientModelValidationContext context)
    //{
    //    throw new NotImplementedException();
    //}
}

    [AttributeUsage(AttributeTargets.Property)]
    public class CompareDateGreaterThanAttribute : ValidationAttribute, IClientModelValidator
    {
        private string PropertyName { get; set; }
        private string _dateToCompare;

        public CompareDateGreaterThanAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            object instance = context.ObjectInstance;
            Type type = instance.GetType();
            if(DateTimeOffset.TryParse(value?.ToString(), out DateTimeOffset compareToPropertyValue))
            if (DateTimeOffset.TryParse(type.GetProperty(PropertyName).GetValue(instance)?.ToString(), out DateTimeOffset propertyValue))
            {
                if ( propertyValue >= compareToPropertyValue)
                {
                    ErrorMessage = $"{context.DisplayName} ({compareToPropertyValue.TimeOfDay}) must be later than {PropertyName} ({propertyValue.TimeOfDay})"; //used if error message is not set on attribute itself

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
