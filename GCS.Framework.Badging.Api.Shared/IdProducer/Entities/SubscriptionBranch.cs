using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Badging.IdProducer.Entities
{

    public class SubscriptionBranchData
    {
        public SubscriptionBranch Subscription { get; set; }
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorCodeStr { get; set; }
        public string ErrorMessage { get; set; }
        public string UserWhoMadeCall { get; set; }
    }


    public class SubscriptionBranch
    {
        public int ID { get; set; }
        public int? ParentSubscriptionID { get; set; }
        public string CompanyName { get; set; }
        public object ParentCompanyName { get; set; }
        public object License { get; set; }
        public FriendlyLicenseDetails FriendlyLicenseDetails { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactMiddleName { get; set; }
        public string ContactLastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string CustomerNb { get; set; }
        public string Notes { get; set; }
        public bool IsInactive { get; set; }
        public object DefaultTimeZone { get; set; }
        public ChildrenSubscription[] ChildrenSubscriptions { get; set; }
        public int[] ParentSubscriptionIDs { get; set; }
        public PrintDispatcher[] PrintDispatchers { get; set; }
        public SubscriptionConfig SubscriptionConfig { get; set; }
        public bool MarkedForDeletion { get; set; }
    }

    //public class Friendlylicensedetails
    //{
    //    public int ID { get; set; }
    //    public int SubscriptionID { get; set; }
    //    public object CompanyName { get; set; }
    //    public bool IsReseller { get; set; }
    //    public string OEMLicenseCode { get; set; }
    //    public string MachineLockCode { get; set; }
    //    public bool IsProductionServer { get; set; }
    //    public int LicensedMaxIssuanceCount { get; set; }
    //    public int LicensedMaxPrinterCount { get; set; }
    //    public bool IsLicensePeriodUnlimited { get; set; }
    //    public string LicensePeriodString { get; set; }
    //    public int LicenseState { get; set; }
    //    public bool IsTrialPeriod { get; set; }
    //    public int MaxCustomerCount { get; set; }
    //    public bool SupportsMultiplePrinters { get; set; }
    //    public int MaxPrintDispatchersCount { get; set; }
    //    public int MaxIndividualsCount { get; set; }
    //    public int MaxTemplatesCount { get; set; }
    //    public int MaxEnrollmentFormsCount { get; set; }
    //    public int MaxRemotePrintsCount { get; set; }
    //    public int MaxCaptureHandlersCount { get; set; }
    //    public bool SupportsMultipleResellers { get; set; }
    //    public bool CanResellerCreateResellers { get; set; }
    //    public bool MarkedForDeletion { get; set; }
    //}

    //public class Subscriptionconfig
    //{
    //    public int ID { get; set; }
    //    public int SubscriptionID { get; set; }
    //    public bool UseCardReaderForQA { get; set; }
    //    public int WaitForPrinterToGetReadySeconds { get; set; }
    //    public int WaitForPrintCompletedSeconds { get; set; }
    //    public int DispatcherWaitTimeIdle { get; set; }
    //    public int PrinterWaitTimeIdle { get; set; }
    //    public string DisplayDateFormat { get; set; }
    //    public string DisplayTimeFormat { get; set; }
    //    public bool CanCreateOrders { get; set; }
    //    public bool PORequiredForOrders { get; set; }
    //    public bool MarkedForDeletion { get; set; }
    //}

    //public class Printdispatcher
    //{
    //    public int ID { get; set; }
    //    public int SubscriptionID { get; set; }
    //    public string MachineName { get; set; }
    //    public string FriendlyName { get; set; }
    //    public bool IsActive { get; set; }
    //    public bool IsOnline { get; set; }
    //    public Printer[] Printers { get; set; }
    //    public bool MarkedForDeletion { get; set; }
    //}


}
