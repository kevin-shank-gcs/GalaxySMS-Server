using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class IdProducerSaveMasterLicenseParameters
    {
        public IdProducerSaveMasterLicenseParameters()
        {

        }

        public IdProducerSaveMasterLicenseParameters(IdProducerSaveMasterLicenseParameters o)
        {
            CompanyName = o.CompanyName;
            IsLicensePeriodUnlimited = o.IsLicensePeriodUnlimited;
            IsTrialPeriod = o.IsTrialPeriod;
            LicensedMaxPrinterCount = o.LicensedMaxPrinterCount;
            SupportsMultiplePrinters = o.SupportsMultiplePrinters;
            DefaultTimeZone = o.DefaultTimeZone;
            Email = o.Email;
            IsInactive = o.IsInactive;
            IsReseller = o.IsReseller;
            MasterUserName = o.MasterUserName;
            MasterPassword = o.MasterPassword;
            ContactFirstName = o.ContactFirstName;
            ContactLastName = o.ContactLastName;
            ContactMiddleName = o.ContactMiddleName;
            Address = o.Address;
            City = o.City;
            State = o.State;
            ZipCode = o.ZipCode;
            Telephone = o.Telephone;
            CustomerNb = o.CustomerNb;
            Notes = o.Notes;
        }

        public string CompanyName { get; set; }
        public bool IsLicensePeriodUnlimited { get; set; }
        public bool IsTrialPeriod { get; set; }
        public int LicensedMaxPrinterCount { get; set; }
        public bool SupportsMultiplePrinters { get; set; }
        public string DefaultTimeZone { get; set; }
        public string Email { get; set; }
        public bool IsInactive { get; set; }
        public bool IsReseller { get; set; }
        public string MasterUserName { get; set; }
        public string MasterPassword { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactMiddleName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string CustomerNb { get; set; }
        public string Notes { get; set; }
    }

    public class IdProducerEnsureGalaxyApiUserExistsParameters
    {
        public IdProducerEnsureGalaxyApiUserExistsParameters()
        {

        }

        public IdProducerEnsureGalaxyApiUserExistsParameters(IdProducerEnsureGalaxyApiUserExistsParameters o)
        {
            MasterUserName = o.MasterUserName;
            MasterPassword = o.MasterPassword;
        }

        public string MasterUserName { get; set; }
        public string MasterPassword { get; set; }

    }

    public class IdProducerUpdateRootCustomerNameParameters
    {
        public IdProducerUpdateRootCustomerNameParameters()
        {

        }

        public IdProducerUpdateRootCustomerNameParameters(IdProducerUpdateRootCustomerNameParameters o)
        {
            CompanyName = o.CompanyName;
            LicensedMaxPrinterCount = o.LicensedMaxPrinterCount;
            SupportsMultiplePrinters = o.SupportsMultiplePrinters;
        }


        public string CompanyName { get; set; }
        public int LicensedMaxPrinterCount { get; set; }
        public int SupportsMultiplePrinters { get; set; }
    }

    public class IdProducerSyncSubscriptionAndEntityParameters
    {
        public IdProducerSyncSubscriptionAndEntityParameters()
        {
            Init();
        }

        public IdProducerSyncSubscriptionAndEntityParameters(IdProducerSyncSubscriptionAndEntityParameters o)
        {
            Init();
            this.EntityId = o.EntityId;
            this.IsLicensePeriodUnlimited = o.IsLicensePeriodUnlimited;
            this.IsTrialPeriod = o.IsTrialPeriod;
            this.LicensedMaxPrinterCount = o.LicensedMaxPrinterCount;
            this.SupportsMultiplePrinters = o.SupportsMultiplePrinters;
            this.DefaultTimeZone = o.DefaultTimeZone;
            this.Email = o.Email;
            this.IsInactive = o.IsInactive;
            this.IsReseller = o.IsReseller;
            this.MasterUserName = o.MasterUserName;
            this.MasterPassword = o.MasterPassword;
            this.ContactFirstName = o.ContactFirstName;
            this.ContactLastName = o.ContactLastName;
            this.ContactMiddleName = o.ContactMiddleName;
            this.Address = o.Address;
            this.City = o.City;
            this.State = o.State;
            this.ZipCode = o.ZipCode;
            this.Telephone = o.Telephone;
            this.CustomerNb = o.CustomerNb;
            this.Notes = o.Notes;
            this.AlwaysUseRoot = o.AlwaysUseRoot;
        }

        private void Init()
        {
            IsTrialPeriod = false;
            Email = string.Empty;
            IsLicensePeriodUnlimited = true;
            IsReseller = false;
            IsInactive = false;
            MasterUserName = string.Empty;
            MasterPassword = string.Empty;
            DefaultTimeZone = "Eastern Standard Time";
            ContactFirstName = string.Empty;
            ContactLastName = string.Empty;
            ContactMiddleName = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            State = string.Empty;
            ZipCode = string.Empty;
            Telephone = string.Empty;
            CustomerNb = string.Empty;
            Notes = string.Empty;
            AlwaysUseRoot = false;
        }
        public Guid EntityId { get; set; }
        public bool IsLicensePeriodUnlimited { get; set; }
        public bool IsTrialPeriod { get; set; }
        public int LicensedMaxPrinterCount { get; set; }
        public bool SupportsMultiplePrinters { get; set; }
        public string DefaultTimeZone { get; set; }
        public string Email { get; set; }
        public bool IsInactive { get; set; }
        public bool IsReseller { get; set; }
        public string MasterUserName { get; set; }
        public string MasterPassword { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactMiddleName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string CustomerNb { get; set; }
        public string Notes { get; set; }
        public bool AlwaysUseRoot { get; set; }
    }

    public class IdProducerRequestParameters
    {
        public IdProducerRequestParameters()
        {

        }
        public IdProducerRequestParameters(IdProducerRequestParameters o)
        {
            if (o != null)
            {
                SubscriptionId = o.SubscriptionId;
                PersonUid = o.PersonUid;
            }
        }

        public uint SubscriptionId { get; set; }
        public Guid PersonUid { get; set; }
    }

}
