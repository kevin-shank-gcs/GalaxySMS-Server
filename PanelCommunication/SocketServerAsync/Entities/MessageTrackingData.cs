using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelCommunicationServerAsync.Entities
{
    public class MessageTrackingData
    {
        public MessageTrackingData(object originalData, Type objectType, double timoutSeconds = 30)
        {
            ObjectType = objectType;
            OriginalData = originalData;
            Expiration = DateTimeOffset.Now + TimeSpan.FromSeconds(timoutSeconds);
        }

        //public Guid OperationUid { get; set; }
        //public Guid SessionId { get; set; }
        public object OriginalData { get; internal set; }
        public Type ObjectType { get; internal set; }
        public DateTimeOffset Expiration { get; internal set; }
    }
}
