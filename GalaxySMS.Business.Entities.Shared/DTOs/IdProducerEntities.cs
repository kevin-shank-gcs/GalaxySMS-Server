using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

#if NetCoreApi
#else
    [DataContract]
#endif
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
            MaxCustomerCount = o.MaxCustomerCount;
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public string CompanyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsLicensePeriodUnlimited { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsTrialPeriod { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int LicensedMaxPrinterCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool SupportsMultiplePrinters { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int MaxCustomerCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DefaultTimeZone { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Email { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsInactive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsReseller { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MasterUserName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MasterPassword { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactFirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactLastName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactMiddleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Address { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string City { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string State { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ZipCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Telephone { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CustomerNb { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Notes { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public string MasterUserName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MasterPassword { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public string CompanyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int LicensedMaxPrinterCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int SupportsMultiplePrinters { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsLicensePeriodUnlimited { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsTrialPeriod { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int LicensedMaxPrinterCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool SupportsMultiplePrinters { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DefaultTimeZone { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Email { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsInactive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsReseller { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MasterUserName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MasterPassword { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactFirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactLastName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactMiddleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Address { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string City { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string State { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ZipCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Telephone { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CustomerNb { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Notes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool AlwaysUseRoot { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public int SubscriptionId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class IdProducerPrintPreviewRequestParameters
    {
        public IdProducerPrintPreviewRequestParameters()
        {

        }
        public IdProducerPrintPreviewRequestParameters(IdProducerPrintPreviewRequestParameters o)
        {
            if (o != null)
            {
                PersonCredentialUid = o.PersonCredentialUid;
                Dossier = o.Dossier;
            }
        }

        public IdProducerPrintPreviewRequestParameters(IdProducerPrintRequestParameters o)
        {
            if (o != null)
            {
                PersonCredentialUid = o.PersonCredentialUid;
                Dossier = o.Dossier;
            }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonCredentialUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool Dossier { get; set; }
    }



#if NetCoreApi
#else
    [DataContract]
#endif
    public class IdProducerPrintRequestParameters
    {
        public IdProducerPrintRequestParameters()
        {

        }


        public IdProducerPrintRequestParameters(IdProducerPrintRequestParameters o)
        {
            if (o != null)
            {
                PrinterId = o.PrinterId;
                DispatcherId = o.DispatcherId;
                PersonCredentialUid = o.PersonCredentialUid;
                Dossier = o.Dossier;
            }
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonCredentialUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool Dossier { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PrinterId { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int DispatcherId { get; set; }

    }



#if NetCoreApi
#else
    [DataContract]
#endif
    public class GetAllSubscriptionsResponse
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public SubscriptionData[] Subscriptions { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsSuccessful { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ErrorCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorCodeStr { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorMessage { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserWhoMadeCall { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class ChildrenSubscription
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ParentSubscriptionID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CompanyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ParentCompanyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        //        public object License { get; set; }
        public string License { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public FriendlyLicenseDetails FriendlyLicenseDetails { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactFirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactMiddleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactLastName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Address { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string City { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string State { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ZipCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Country { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Telephone { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Email { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CustomerNb { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Notes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsInactive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        //        public object DefaultTimeZone { get; set; }
        public string DefaultTimeZone { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ChildrenSubscription[] ChildrenSubscriptions { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int[] ParentSubscriptionIDs { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PrintDispatcher[] PrintDispatchers { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public SubscriptionConfig SubscriptionConfig { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool MarkedForDeletion { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SubscriptionData
    {
        public SubscriptionData()
        {
            FriendlyLicenseDetails = new FriendlyLicenseDetails();
            SubscriptionConfig = new SubscriptionConfig();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int? ParentSubscriptionID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CompanyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ParentCompanyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        //        public object License { get; set; }
        public string License { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public FriendlyLicenseDetails FriendlyLicenseDetails { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactFirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactMiddleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactLastName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Address { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string City { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string State { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ZipCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Country { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Telephone { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Email { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CustomerNb { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Notes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsInactive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        //       public object DefaultTimeZone { get; set; }
        public string DefaultTimeZone { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ChildrenSubscription[] ChildrenSubscriptions { get; set; } = new List<ChildrenSubscription>().ToArray();

#if NetCoreApi
#else
        [DataMember]
#endif
        public int?[] ParentSubscriptionIDs { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PrintDispatcher[] PrintDispatchers { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public SubscriptionConfig SubscriptionConfig { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool MarkedForDeletion { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MasterUserName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MasterPassword { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class FriendlyLicenseDetails
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int SubscriptionID { get; set; }
        //        public object CompanyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CompanyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsReseller { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string OEMLicenseCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MachineLockCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsProductionServer { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int LicensedMaxIssuanceCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int LicensedMaxPrinterCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsLicensePeriodUnlimited { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LicensePeriodString { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int LicenseState { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsTrialPeriod { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int MaxCustomerCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool SupportsMultiplePrinters { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int MaxPrintDispatchersCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int MaxIndividualsCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int MaxTemplatesCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int MaxEnrollmentFormsCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int MaxRemotePrintsCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int MaxCaptureHandlersCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool SupportsMultipleResellers { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool CanResellerCreateResellers { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool MarkedForDeletion { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SubscriptionConfig
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int? SubscriptionID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool? UseCardReaderForQA { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int? WaitForPrinterToGetReadySeconds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int? WaitForPrintCompletedSeconds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int? DispatcherWaitTimeIdle { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int? PrinterWaitTimeIdle { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DisplayDateFormat { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DisplayTimeFormat { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool? CanCreateOrders { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool? PORequiredForOrders { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool? CanAddAndDeleteIndividuals { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool MarkedForDeletion { get; set; }
    }
    
#if NetCoreApi
#else
    [DataContract]
#endif
    public class CreatedPrintRequest
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Identifier { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int PrintRequestID { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ErrorCode { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorCodeStr { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorMessage { get; set; }
    }



#if NetCoreApi
#else
    [DataContract]
#endif
    public class CreatedPrintRequestResponse
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public CreatedPrintRequest[] CreatedPrintRequests { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsSuccessful { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ErrorCode { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorCodeStr { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorMessage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserWhoMadeCall { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class PrintDispatcher
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int SubscriptionID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MachineName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FriendlyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsOnline { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Printer[] Printers { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool MarkedForDeletion { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class Printer
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int SubscriptionID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PrintDispatcherID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LocalPrinterName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PaperSizeName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PrinterProfileID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int Resolution { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int Orientation { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool SimulatePrinting { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool SavePreviewToFile { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool UsePrinterEncoder { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool UsePrinterControl { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int FrontRotate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int FrontRenderingMode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int FrontNudgeX { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int FrontNudgeY { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int BackRotate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int BackRenderingMode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int BackNudgeX { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int BackNudgeY { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PageFit { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FriendlyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        //        public object SmartCardReader { get; set; }
        public string SmartCardReader { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsQueuedDefault { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsOnline { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool MarkedForDeletion { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class PrinterDispatchersResponse
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public PrintDispatcher[] PrintDispatchers { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsSuccessful { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ErrorCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorCodeStr { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorMessage { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserWhoMadeCall { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SetMasterLicenseData
    {
        public SetMasterLicenseData()
        {
            FriendlyLicenseDetails = new LicenseDetails();
        }
#if NetCoreApi
#else
        [DataContract]
#endif
        public class LicenseDetails
        {

#if NetCoreApi
#else
            [DataMember]
#endif
            public int SubscriptionID { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public string OEMLicenseCode { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public bool IsLicensePeriodUnlimited { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public bool IsTrialPeriod { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public int LicensedMaxPrinterCount { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public bool SupportsMultiplePrinters { get; set; }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CompanyName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactFirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactLastName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Email { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsInactive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DefaultTimeZone { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ContactMiddleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Address { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string City { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string State { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ZipCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Telephone { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CustomerNb { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Notes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public LicenseDetails FriendlyLicenseDetails { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SubscriptionTemplateFieldsResponse
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public SubscriptionTemplateField[] SubscriptionTemplateFields { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class SubscriptionTemplateField
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int SubscriptionID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int TemplateFieldTypeID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int? TemplateFieldFormatID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TableName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FieldName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DisplayName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsRequired { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int MaxLength { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int? FormControlTypeID { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsProprietary { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool HideFromTemplateEditor { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsReadOnly { get; set; }
        //        public bool IsMappedToRemoveField {get;set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public object[] TemplateFieldValues { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public object[] TemplateFieldChoices { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public object[] UserSearchFieldValues { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool MarkedForDeletion { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class GetAllCardTemplatesLiteResponse
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public CardTemplateLite[] CardTemplatesLite { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsSuccessful { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ErrorCode { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorCodeStr { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorMessage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserWhoMadeCall { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class CardTemplateLite
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ID { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int SubscriptionID { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Name { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool AutomaticQA { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset LastModified { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int? CardStockID { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsDuplex { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int NbOfColorElementsOnFront { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int NbOfBlackElementsOnfront { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int NbOfColorElementsOnBack { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int NbOfBlackElementsOnBack { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int MagStripeElementLocation { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool PrePrintedBackgroundFront { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool PrePrintedBackgroundBack { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsSmartCard { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string CardStockName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string CardStockSubscriptionCompanyName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public object[] CardTemplateFields { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool MarkedForDeletion { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class GetCardTemplateLiteResponse
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public CardTemplateLite CardTemplateLite { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsSuccessful { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ErrorCode { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorCodeStr { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorMessage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserWhoMadeCall { get; set; }
    }



#if NetCoreApi
#else
    [DataContract]
#endif
    public class PreviewData //: ResponseBase
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public string FrontPreviewImage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string BackPreviewImage { get; set; }
    }



#if NetCoreApi
#else
    [DataContract]
#endif
    public class PreviewDataResponse
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public string[] Base64Images { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsSuccessful { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ErrorCode { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorCodeStr { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ErrorMessage { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class ServerVersionNumber
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Data { get; set; }


        public Version Version
        {
            get
            {
                var result = new Version();
                if (string.IsNullOrEmpty(Data))
                {
                    return result;
                }

                if (Version.TryParse(Data, out result))
                {
                    return result;
                }

                return result;
            }
        }

    }
}
