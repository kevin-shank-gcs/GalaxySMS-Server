using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
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


        [DataMember] public string CompanyName { get; set; }


        [DataMember] public bool IsLicensePeriodUnlimited { get; set; }


        [DataMember] public bool IsTrialPeriod { get; set; }


        [DataMember] public int LicensedMaxPrinterCount { get; set; }


        [DataMember] public bool SupportsMultiplePrinters { get; set; }


        [DataMember] public string DefaultTimeZone { get; set; }


        [DataMember] public string Email { get; set; }


        [DataMember] public bool IsInactive { get; set; }


        [DataMember] public bool IsReseller { get; set; }


        [DataMember] public string MasterUserName { get; set; }


        [DataMember] public string MasterPassword { get; set; }


        [DataMember] public string ContactFirstName { get; set; }


        [DataMember] public string ContactLastName { get; set; }


        [DataMember] public string ContactMiddleName { get; set; }


        [DataMember] public string Address { get; set; }


        [DataMember] public string City { get; set; }


        [DataMember] public string State { get; set; }


        [DataMember] public string ZipCode { get; set; }


        [DataMember] public string Telephone { get; set; }


        [DataMember] public string CustomerNb { get; set; }


        [DataMember] public string Notes { get; set; }
    }


    [DataContract]
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


        [DataMember] public string MasterUserName { get; set; }


        [DataMember] public string MasterPassword { get; set; }
    }


    [DataContract]
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


        [DataMember] public string CompanyName { get; set; }


        [DataMember] public int LicensedMaxPrinterCount { get; set; }


        [DataMember] public int SupportsMultiplePrinters { get; set; }
    }


    [DataContract]
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


        [DataMember] public Guid EntityId { get; set; }


        [DataMember] public bool IsLicensePeriodUnlimited { get; set; }


        [DataMember] public bool IsTrialPeriod { get; set; }


        [DataMember] public int LicensedMaxPrinterCount { get; set; }


        [DataMember] public bool SupportsMultiplePrinters { get; set; }


        [DataMember] public string DefaultTimeZone { get; set; }


        [DataMember] public string Email { get; set; }


        [DataMember] public bool IsInactive { get; set; }


        [DataMember] public bool IsReseller { get; set; }


        [DataMember] public string MasterUserName { get; set; }


        [DataMember] public string MasterPassword { get; set; }


        [DataMember] public string ContactFirstName { get; set; }


        [DataMember] public string ContactLastName { get; set; }


        [DataMember] public string ContactMiddleName { get; set; }


        [DataMember] public string Address { get; set; }


        [DataMember] public string City { get; set; }


        [DataMember] public string State { get; set; }


        [DataMember] public string ZipCode { get; set; }


        [DataMember] public string Telephone { get; set; }


        [DataMember] public string CustomerNb { get; set; }


        [DataMember] public string Notes { get; set; }


        [DataMember] public bool AlwaysUseRoot { get; set; }
    }


    [DataContract]
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


        [DataMember] public uint SubscriptionId { get; set; }


        [DataMember] public Guid PersonUid { get; set; }
    }

    
    [DataContract]
    public class IdProducerPrintPreviewRequestParameters
    {
        public IdProducerPrintPreviewRequestParameters()
        {
        }

        public IdProducerPrintPreviewRequestParameters(IdProducerPrintRequestParameters o)
        {
            if (o != null)
            {
                PersonCredentialUid = o.PersonCredentialUid;
                Dossier = o.Dossier;
            }
        }
        public IdProducerPrintPreviewRequestParameters(IdProducerPrintPreviewRequestParameters o)
        {
            if (o != null)
            {
                PersonCredentialUid = o.PersonCredentialUid;
                Dossier = o.Dossier;
            }
        }

        [DataMember] public Guid PersonCredentialUid { get; set; }
        [DataMember] public bool Dossier { get; set; }
        [DataMember] public int PrinterId { get; set; }
        [DataMember] public int DispatcherId { get; set; }

    }

    
    [DataContract]
    public class IdProducerPrintRequestParameters
    {
        public IdProducerPrintRequestParameters()
        {
        }

        public IdProducerPrintRequestParameters(IdProducerPrintRequestParameters o) 
        {
            if (o != null)
            {
                PersonCredentialUid = o.PersonCredentialUid;
                Dossier = o.Dossier;
                PrinterId = o.PrinterId;
                DispatcherId = o.DispatcherId;
            }
        }


        [DataMember] public Guid PersonCredentialUid { get; set; }
        [DataMember] public bool Dossier { get; set; }
        [DataMember] public int PrinterId { get; set; }
        [DataMember] public int DispatcherId { get; set; }

    }



    [DataContract]
    public class GetAllSubscriptionsResponse
    {
        [DataMember] public SubscriptionData[] Subscriptions { get; set; }


        [DataMember] public bool IsSuccessful { get; set; }


        [DataMember] public int ErrorCode { get; set; }


        [DataMember] public string ErrorCodeStr { get; set; }


        [DataMember] public string ErrorMessage { get; set; }


        [DataMember] public string UserWhoMadeCall { get; set; }
    }


    [DataContract]
    public class ChildrenSubscription
    {
        [DataMember] public int ID { get; set; }


        [DataMember] public int ParentSubscriptionID { get; set; }


        [DataMember] public string CompanyName { get; set; }


        [DataMember] public string ParentCompanyName { get; set; }


//        [DataMember] public object License { get; set; }
        [DataMember] public string License { get; set; }


        [DataMember] public FriendlyLicenseDetails FriendlyLicenseDetails { get; set; }


        [DataMember] public string ContactFirstName { get; set; }


        [DataMember] public string ContactMiddleName { get; set; }


        [DataMember] public string ContactLastName { get; set; }


        [DataMember] public string Address { get; set; }


        [DataMember] public string City { get; set; }


        [DataMember] public string State { get; set; }


        [DataMember] public string ZipCode { get; set; }


        [DataMember] public string Country { get; set; }


        [DataMember] public string Telephone { get; set; }


        [DataMember] public string Email { get; set; }


        [DataMember] public string CustomerNb { get; set; }


        [DataMember] public string Notes { get; set; }


        [DataMember] public bool IsInactive { get; set; }


 //       [DataMember] public object DefaultTimeZone { get; set; }
        [DataMember] public string DefaultTimeZone { get; set; }


        [DataMember] public ChildrenSubscription[] ChildrenSubscriptions { get; set; }


        [DataMember] public int[] ParentSubscriptionIDs { get; set; }


        [DataMember] public PrintDispatcher[] PrintDispatchers { get; set; }


        [DataMember] public SubscriptionConfig SubscriptionConfig { get; set; }


        [DataMember] public bool MarkedForDeletion { get; set; }
    }


    [DataContract]
    public class SubscriptionData
    {
        public SubscriptionData()
        {
            FriendlyLicenseDetails = new FriendlyLicenseDetails();
            SubscriptionConfig = new SubscriptionConfig();
        }


        [DataMember] public int ID { get; set; }


        [DataMember] public int? ParentSubscriptionID { get; set; }


        [DataMember] public string CompanyName { get; set; }


        [DataMember] public string ParentCompanyName { get; set; }


//        [DataMember] public object License { get; set; }
        [DataMember] public string License { get; set; }


        [DataMember] public FriendlyLicenseDetails FriendlyLicenseDetails { get; set; }


        [DataMember] public string ContactFirstName { get; set; }


        [DataMember] public string ContactMiddleName { get; set; }


        [DataMember] public string ContactLastName { get; set; }


        [DataMember] public string Address { get; set; }


        [DataMember] public string City { get; set; }


        [DataMember] public string State { get; set; }


        [DataMember] public string ZipCode { get; set; }


        [DataMember] public string Country { get; set; }


        [DataMember] public string Telephone { get; set; }


        [DataMember] public string Email { get; set; }


        [DataMember] public string CustomerNb { get; set; }


        [DataMember] public string Notes { get; set; }


        [DataMember] public bool IsInactive { get; set; }


//        [DataMember] public object DefaultTimeZone { get; set; }
        [DataMember] public string DefaultTimeZone { get; set; }


        [DataMember] public ChildrenSubscription[] ChildrenSubscriptions { get; set; }


        [DataMember] public int?[] ParentSubscriptionIDs { get; set; }


        [DataMember] public PrintDispatcher[] PrintDispatchers { get; set; }


        [DataMember] public SubscriptionConfig SubscriptionConfig { get; set; }


        [DataMember] public bool MarkedForDeletion { get; set; }


        [DataMember] public string MasterUserName { get; set; }


        [DataMember] public string MasterPassword { get; set; }
    }


    [DataContract]
    public class FriendlyLicenseDetails
    {
        [DataMember] public int ID { get; set; }
        [DataMember] public int SubscriptionID { get; set; }
 //       public object CompanyName { get; set; }
 [DataMember] public string CompanyName { get; set; }
 [DataMember] public bool IsReseller { get; set; }
 [DataMember] public string OEMLicenseCode { get; set; }
 [DataMember] public string MachineLockCode { get; set; }
 [DataMember] public bool IsProductionServer { get; set; }
 [DataMember] public int LicensedMaxIssuanceCount { get; set; }
 [DataMember] public int LicensedMaxPrinterCount { get; set; }
 [DataMember] public bool IsLicensePeriodUnlimited { get; set; }
 [DataMember] public string LicensePeriodString { get; set; }
 [DataMember] public int LicenseState { get; set; }
 [DataMember] public bool IsTrialPeriod { get; set; }
 [DataMember] public int MaxCustomerCount { get; set; }
 [DataMember] public bool SupportsMultiplePrinters { get; set; }
 [DataMember] public int MaxPrintDispatchersCount { get; set; }
 [DataMember] public int MaxIndividualsCount { get; set; }
 [DataMember] public int MaxTemplatesCount { get; set; }
 [DataMember] public int MaxEnrollmentFormsCount { get; set; }
 [DataMember] public int MaxRemotePrintsCount { get; set; }
 [DataMember] public int MaxCaptureHandlersCount { get; set; }
 [DataMember] public bool SupportsMultipleResellers { get; set; }
 [DataMember] public bool CanResellerCreateResellers { get; set; }
 [DataMember] public bool MarkedForDeletion { get; set; }
    }


    [DataContract]
    public class SubscriptionConfig
    {
        [DataMember] public int ID { get; set; }


        [DataMember] public int? SubscriptionID { get; set; }


        [DataMember] public bool? UseCardReaderForQA { get; set; }


        [DataMember] public int? WaitForPrinterToGetReadySeconds { get; set; }


        [DataMember] public int? WaitForPrintCompletedSeconds { get; set; }


        [DataMember] public int? DispatcherWaitTimeIdle { get; set; }


        [DataMember] public int? PrinterWaitTimeIdle { get; set; }


        [DataMember] public string DisplayDateFormat { get; set; }


        [DataMember] public string DisplayTimeFormat { get; set; }


        [DataMember] public bool? CanCreateOrders { get; set; }


        [DataMember] public bool? PORequiredForOrders { get; set; }


        [DataMember] public bool? CanAddAndDeleteIndividuals { get; set; }


        [DataMember] public bool MarkedForDeletion { get; set; }
    }

    [DataContract]
    public class PreviewData //: ResponseBase
    {
        [DataMember]
        public string FrontPreviewImage { get; set; }

        [DataMember]
        public string BackPreviewImage { get; set; }
    }



    [DataContract]
    public class CreatedPrintRequest
    {
        [DataMember]
        public string Identifier { get; set; }
        [DataMember]
        public int PrintRequestID { get; set; }
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string ErrorCodeStr { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
    }


    [DataContract]
    public class CreatedPrintRequestResponse
    {
        [DataMember]
        public CreatedPrintRequest[] CreatedPrintRequests { get; set; }
        [DataMember]
        public bool IsSuccessful { get; set; }
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string ErrorCodeStr { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string UserWhoMadeCall { get; set; }
    }

    [DataContract]
    public class PrintDispatcher
    {
        [DataMember] public int ID { get; set; }


        [DataMember] public int SubscriptionID { get; set; }


        [DataMember] public string MachineName { get; set; }


        [DataMember] public string FriendlyName { get; set; }


        [DataMember] public bool IsActive { get; set; }


        [DataMember] public bool IsOnline { get; set; }


        [DataMember] public Printer[] Printers { get; set; }


        [DataMember] public bool MarkedForDeletion { get; set; }
    }


    [DataContract]
    public class Printer
    {
        [DataMember] public int ID { get; set; }


        [DataMember] public int SubscriptionID { get; set; }


        [DataMember] public int PrintDispatcherID { get; set; }


        [DataMember] public string LocalPrinterName { get; set; }


        [DataMember] public string PaperSizeName { get; set; }


        [DataMember] public int PrinterProfileID { get; set; }


        [DataMember] public int Resolution { get; set; }


        [DataMember] public int Orientation { get; set; }


        [DataMember] public bool SimulatePrinting { get; set; }


        [DataMember] public bool SavePreviewToFile { get; set; }


        [DataMember] public bool UsePrinterEncoder { get; set; }


        [DataMember] public bool UsePrinterControl { get; set; }


        [DataMember] public int FrontRotate { get; set; }


        [DataMember] public int FrontRenderingMode { get; set; }


        [DataMember] public int FrontNudgeX { get; set; }


        [DataMember] public int FrontNudgeY { get; set; }


        [DataMember] public int BackRotate { get; set; }


        [DataMember] public int BackRenderingMode { get; set; }


        [DataMember] public int BackNudgeX { get; set; }


        [DataMember] public int BackNudgeY { get; set; }


        [DataMember] public int PageFit { get; set; }


        [DataMember] public string FriendlyName { get; set; }


//        [DataMember] public object SmartCardReader { get; set; }
        [DataMember] public string SmartCardReader { get; set; }


        [DataMember] public bool IsQueuedDefault { get; set; }


        [DataMember] public bool IsActive { get; set; }


        [DataMember] public bool IsOnline { get; set; }


        [DataMember] public bool MarkedForDeletion { get; set; }
    }


    [DataContract]
    public class PrinterDispatchersResponse
    {
        [DataMember] public PrintDispatcher[] PrintDispatchers { get; set; }


        [DataMember] public bool IsSuccessful { get; set; }


        [DataMember] public int ErrorCode { get; set; }


        [DataMember] public string ErrorCodeStr { get; set; }


        [DataMember] public string ErrorMessage { get; set; }


        [DataMember] public string UserWhoMadeCall { get; set; }
    }


    [DataContract]
    public class SetMasterLicenseData
    {
        public SetMasterLicenseData()
        {
            FriendlyLicenseDetails = new LicenseDetails();
        }


        [DataContract]
        public class LicenseDetails
        {
            [DataMember] public int SubscriptionID { get; set; }


            [DataMember] public string OEMLicenseCode { get; set; }


            [DataMember] public bool IsLicensePeriodUnlimited { get; set; }


            [DataMember] public bool IsTrialPeriod { get; set; }


            [DataMember] public int LicensedMaxPrinterCount { get; set; }


            [DataMember] public bool SupportsMultiplePrinters { get; set; }
        }


        [DataMember] public int ID { get; set; }


        [DataMember] public string CompanyName { get; set; }


        [DataMember] public string ContactFirstName { get; set; }


        [DataMember] public string ContactLastName { get; set; }


        [DataMember] public string Email { get; set; }


        [DataMember] public bool IsInactive { get; set; }


        [DataMember] public string DefaultTimeZone { get; set; }


        [DataMember] public string ContactMiddleName { get; set; }


        [DataMember] public string Address { get; set; }


        [DataMember] public string City { get; set; }


        [DataMember] public string State { get; set; }


        [DataMember] public string ZipCode { get; set; }


        [DataMember] public string Telephone { get; set; }


        [DataMember] public string CustomerNb { get; set; }


        [DataMember] public string Notes { get; set; }


        [DataMember] public LicenseDetails FriendlyLicenseDetails { get; set; }
    }
}