using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class AccessPortalAlertEventPutReq : PutRequestBase
    {
        //public System.Guid AccessPortalAlertEventUid { get; set; }


        //public System.Guid AccessPortalUid { get; set; }


        public System.Guid InputOutputGroupUid { get; set; }


        public System.Guid AcknowledgeTimeScheduleUid { get; set; }


        public Nullable<System.Guid> AudioBinaryResourceUid { get; set; }


        public Nullable<System.Guid> ResponseInstructionsUid { get; set; }


        public System.Guid AccessPortalAlertEventTypeUid { get; set; }


        public Nullable<System.Guid> InputOutputGroupAssignmentUid { get; set; }


        public int AcknowledgePriority { get; set; }

        //public BinaryResourceReq gcsBinaryResource { get; set; }

        public NotePutReq Note { get; set; }

    }
}
