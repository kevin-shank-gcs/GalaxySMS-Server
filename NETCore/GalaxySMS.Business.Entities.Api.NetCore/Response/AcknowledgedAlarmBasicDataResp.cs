using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class AcknowledgedAlarmBasicData
    {
        #region Public Properties

        public Guid ActivityEventUid { get; set; }

        public Guid DeviceEntityId { get; set; }

        public Guid DeviceUid { get; set; }

        public Guid AlarmEventAcknowledgmentUid { get; set; }

        public PanelActivityEventCategory ActivityEventCategory { get; set; }

        public string Response { get; set; }

        public Guid AckedByUserId { get; set; }

        public string AckedByUserDisplayName { get; set; }

        public DateTimeOffset AckedDateTime { get; set; }

        public DateTimeOffset AckedUpdatedDateTime { get; set; }
        #endregion

    }

}
