using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class AccessPortalAuxiliaryOutputPutReq : PutRequestBase
    {

        //public System.Guid AccessPortalAuxiliaryOutputUid { get; set; }


        //public System.Guid AccessPortalUid { get; set; }


        public System.Guid AccessPortalAuxiliaryOutputModeUid { get; set; }


        public System.Guid TimeScheduleUid { get; set; }


        public string Description { get; set; }


        public string Tag { get; set; }


        public int ActivationDelay { get; set; }


        public int ActivationDuration { get; set; }


        public bool IllegalOpen { get; set; }


        public bool OpenTooLong { get; set; }


        public bool InvalidAttempt { get; set; }


        public bool AccessGranted { get; set; }


        public bool Duress { get; set; }


        public bool PassbackViolation { get; set; }
    }
}
