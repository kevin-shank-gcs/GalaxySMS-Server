using System;
using System.Collections.Generic;
using System.Text;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    public class SaveMasterLicenseParameters
    {
        public int ID { get; set; } = 1000;
        public int ParentSubscriptionId { get; set; }
        public string CompanyName { get; set; } = "Galaxy Auto License";
        public bool IsLicensePeriodUnlimited { get; set; } = true;
        public bool IsTrialPeriod { get; set; } = false;
        public int LicensedMaxPrinterCount { get; set; } = 1;
        public bool SupportsMultiplePrinters { get; set; } = false;
        public string DefaultTimeZone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsInactive { get; set; } = false; 
        public bool IsReseller { get; set; } = false;
        public string MasterUserName { get; set; } = "galaxyApi@idProducer.com";
        public string MasterPassword { get; set; } = "galaxy";
        //public string ContactFirstName { get; set; }
        //public string ContactLastName { get; set; }
        //public string ContactMiddleName { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string ZipCode { get; set; }
        //public string Telephone { get; set; }
        //public string CustomerNb { get; set; }
        //public string Notes { get; set; }
        public int MaxCustomerCount { get; set; } = 1;
    }
}
