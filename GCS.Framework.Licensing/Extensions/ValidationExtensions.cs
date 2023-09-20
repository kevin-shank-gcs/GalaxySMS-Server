using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portable.Licensing;
using Portable.Licensing.Prime;
using Portable.Licensing.Prime.Validation;
//using Portable.Licensing.Validation;

namespace GCS.Framework.Licensing.Extensions
{
    public static class ValidationExtensions
    {
        public static IValidationChain IsLicensedTo(this IStartValidationChain validationChain, string name, string email)
        {
            return validationChain.AssertThat(license => CheckCustomer(license, name, email),
                new GeneralValidationFailure()
                {
                    Message = Properties.Resources.ResourceManager.GetString("ValidationExtension_IsLicensedToFailureAction"),
                    HowToResolve = Properties.Resources.ResourceManager.GetString("ValidationExtension_IsLicensedToFailureAction")
                });
        }

        private static bool CheckCustomer(License license, string name, string email)
        {
            if (license.Customer == null)
            {
                return false;
            }

            return license.Customer.Name == name
                && license.Customer.Email == email;
        }
    }
}
