using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class UnacknowledgedAlarm
    {
        #region Public Variables
        public Guid ActivityEventUid { get; set; }
        public Guid DeviceUid { get; set; }
        public Guid DeviceEntityId { get; set; }
        public Guid CpuUid { get; set; }
        public Guid GalaxyActivityEventTypeUid { get; set; }
        public Guid PersonUid { get; set; }
        public Guid CredentialUid { get; set; }
        public DateTimeOffset ActivityDateTime { get; set; }
        public string EventDescription { get; set; }
        public string DeviceName { get; set; }
        public int AlarmPriority { get; set; }
        public string Instructions { get; set; }
        public string Category { get; set; }
        public string ActivityEventText { get; set; }
        public string CredentialDescription { get; set; }
        #endregion
    }
}
