using System;
using System.Collections.Generic;
using System.Text;
using static GCS.Framework.Badging.IdProducer.idProducerAPI;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    public class RequestStateChangeData
    {
        public int OriginatorUserID { get; set; }
        public int RequestID { get; set; }
        public int[] RequestIDs { get; set; }
        public string CardID { get; set; }
        public string[] CardIDs { get; set; }
        public RequestStateMapping FromState { get; set; }
        public RequestStateMapping ToState { get; set; }
        public string LastReason { get; set; }
        public int SubscriptionID { get; set; }
        public int DispatcherID { get; set; }
        public int CardStockID { get; set; }
        public bool IsDirectPrint { get; set; }
        public int PrinterID { get; set; }
    }
}
