using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;

namespace GalaxySMS.Client.Licensing.Entities
{

    public partial class ActivateSystemLicenseData
    {

    	class ActivateSystemLicenseDataValidator : AbstractValidator<ActivateSystemLicenseData>
    	{

    		public ActivateSystemLicenseDataValidator()
    		{
                RuleFor(obj => obj.ActivatedByPersonName).NotEmpty().MaximumLength(100);
                RuleFor(obj => obj.City).NotEmpty().Length(1, 100);
                RuleFor(obj => obj.CountryIso3).NotEmpty().Length(3, 3);
                RuleFor(obj => obj.CustomerContactPerson).NotEmpty().Length(1, 100);
                RuleFor(obj => obj.CustomerContactPhone).NotEmpty().Length(1, 100);
                RuleFor(obj => obj.CustomerEmailAddress).NotEmpty().EmailAddress();
                RuleFor(obj => obj.CustomerName).NotEmpty().Length(1, 100);
                //RuleFor(obj => obj.CustomerJobNumber).NotEmpty().Length(1, 100);
                //RuleFor(obj => obj.CustomerPurchaseOrder).NotEmpty().Length(1, 100);
                RuleFor(obj => obj.FacilityType).NotEmpty().Length(1, 100);
                RuleFor(obj => obj.LicenseKey).NotEmpty().Matches("^[0-9a-zA-Z]{5}-[0-9a-zA-Z]{5}-[0-9a-zA-Z]{5}-[0-9a-zA-Z]{5}-[0-9a-zA-Z]{4}").Length(1, 100);
                RuleFor(obj => obj.MajorVersion).InclusiveBetween(1, 100);
                RuleFor(obj => obj.ServerSystemNumber).NotEmpty().Length(1, 100);
                RuleFor(obj => obj.LicenseType).IsInEnum();
                RuleFor(obj => obj.StateProvinceCode).NotEmpty().Length(1, 100);
                //RuleFor(obj => obj.StreetAddress).NotEmpty().Length(1, 100);
                RuleFor(obj => obj.SystemThumbprint).NotEmpty().Matches("^[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}");
            }
        }

    	protected override IValidator GetValidator()
    	{
    		return new ActivateSystemLicenseDataValidator();
    	}
    }

}
