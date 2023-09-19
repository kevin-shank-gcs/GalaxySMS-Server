using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{

    public partial class GalaxyPanel_GetAlertEventAcknowledgeDataResp
    {
        #region Public Properties
        public Guid GalaxyPanelUid { get; set; }
        public Guid GalaxyPanelAlertEventTypeUid { get; set; }
        public string Tag { get; set; }
        public bool CanHaveAudio { get; set; }
        public bool CanHaveInstructions { get; set; }
        public bool CanHaveSchedule { get; set; }
        public Guid AcknowledgeTimeScheduleUid { get; set; }
        public int AcknowledgePriority { get; set; }
        public string ResponseInstructions { get; set; }
        public Guid UserInstructionsNoteUid { get; set; }
        public Guid AudioBinaryResourceUid { get; set; }
        public Guid ClusterUid { get; set; }
        public GalaxySMS.Common.Enums.TimeScheduleType ScheduleTypeCode { get; set; }

        #endregion
    }

}
