using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    public partial class GalaxyPanel_GetAlertEventAcknowledgeData
    {

        #region Public Properties

        [DataMember]

        public Guid GalaxyPanelUid { get; set; }

        [DataMember]

        public Guid GalaxyPanelAlertEventTypeUid { get; set; }

        [DataMember]

        public string Tag { get; set; }

        [DataMember]

        public bool CanHaveAudio { get; set; }

        [DataMember]

        public bool CanHaveInstructions { get; set; }

        [DataMember]

        public bool CanHaveSchedule { get; set; }

        [DataMember]

        public Guid AcknowledgeTimeScheduleUid { get; set; }

        [DataMember]

        public int AcknowledgePriority { get; set; }

        [DataMember]
        public bool ResponseRequired { get; set; }


        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]

        public string ResponseInstructions { get; set; }

        [DataMember]

        public Guid UserInstructionsNoteUid { get; set; }

        [DataMember]

        public Guid AudioBinaryResourceUid { get; set; }

        [DataMember]

        public Guid ClusterUid { get; set; }

        [DataMember]

        public GalaxySMS.Common.Enums.TimeScheduleType ScheduleTypeCode { get; set; }

        #endregion
    }

}
