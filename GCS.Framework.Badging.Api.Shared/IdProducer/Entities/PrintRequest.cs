using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    public class PrintRequestsResponse
    {
        public PrintRequest[] PrintRequests { get; set; }
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorCodeStr { get; set; }
        public string ErrorMessage { get; set; }
        public string UserWhoMadeCall { get; set; }
    }

    public class PrintRequest
    {
        public int ID { get; set; }
        public int CustomerSubscriptionID { get; set; }
        public object ResellerSubscriptionID { get; set; }
        public object VirtualLocationID { get; set; }
        public int PrintDispatcherID { get; set; }
        public object PrinterID { get; set; }
        public int CardTemplateID { get; set; }
        public string ExternalUserName { get; set; }
        public string Label { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public object CardID { get; set; }
        public int IndividualID { get; set; }
        public int RequestStateID { get; set; }
        public int ProductionCardStateID { get; set; }
        public object CardSerialNumber { get; set; }
        public object LastReason { get; set; }
        public object IssuanceNumber { get; set; }
        public bool IsDirectPrint { get; set; }
        public ParentIndividual ParentIndividual { get; set; }
        public bool MarkedForDeletion { get; set; }
    }

    public class ParentIndividual
    {
        public int ID { get; set; }
        public int SubscriptionID { get; set; }
        public object FirstName { get; set; }
        public object MiddleName { get; set; }
        public object LastName { get; set; }
        public object BirthDateString { get; set; }
        public string IndividualExtID { get; set; }
        public object[] TemplateFieldValues { get; set; }
        public bool MarkedForDeletion { get; set; }
    }

}
