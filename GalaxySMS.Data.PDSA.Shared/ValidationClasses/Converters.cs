using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Validation;
using PDSA.Validation;

namespace GalaxySMS.Data.PDSA.ValidationClasses
{
    public class Converters
    {
        public static DataValidationException ConvertToDataValidationException(PDSAValidationException pdsaValidationEx)
        {
            DataValidationException ret = new DataValidationException(Properties.Resources.DataValidationExceptionMessage);
            foreach (var validationRule in pdsaValidationEx.BusinessRuleMessages)
            {
                ret.AddValidationRuleMessage(new ValidationRule(validationRule.PropertyName, validationRule.Message));
            }
            return ret;
        }
    }
}
