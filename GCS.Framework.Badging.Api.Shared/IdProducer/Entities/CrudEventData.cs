using System;
using System.Collections.Generic;
using System.Text;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    public class CrudEventData
    {
        public int OriginatorUserID { get; set; }
        public int EventEntity { get; set; }
        public int EntityType { get; set; }
        public string ExternalIDs { get; set; }
        public int RecordID { get; set; }
        public int[] RecordIDs { get; set; }
    }
}
