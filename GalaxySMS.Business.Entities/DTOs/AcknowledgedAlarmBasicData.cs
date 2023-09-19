using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public partial class AcknowledgedAlarmBasicData : ObjectBase
    {
        #region Public Properties
        [DataMember]
        public Guid ActivityEventUid { get; set; }
        [DataMember]
        public Guid DeviceEntityId { get; set; }
        [DataMember]
        public Guid DeviceUid { get; set; }
        [DataMember]
        public Guid AccessPortalAlarmEventAcknowledgmentUid { get; set; }
        [DataMember]
        public Guid GalaxyPanelAlarmEventAcknowledgmentUid { get; set; }
        [DataMember]
        public Guid InputDeviceAlarmEventAcknowledgmentUid { get; set; }

        [DataMember]
        public string Response { get; set; }
        [DataMember]
        public Guid AckedByUserId { get; set; }
        [DataMember]
        public string AckedByUserDisplayName { get; set; }
        [DataMember]
        public DateTimeOffset AckedDateTime { get; set; }
        [DataMember]
        public DateTimeOffset AckedUpdatedDateTime { get; set; }
        #endregion

    }

}
