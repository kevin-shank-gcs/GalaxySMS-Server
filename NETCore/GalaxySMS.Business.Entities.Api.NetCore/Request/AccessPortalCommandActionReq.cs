using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;


namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class AccessPortalCommandActionReq
    {
        public AccessPortalCommandActionReq()
        {
            Init();
        }

        public AccessPortalCommandActionReq(AccessPortalCommandActionReq o)
        {
            Init();
            AccessPortalUid = o.AccessPortalUid;
            CommandAction = o.CommandAction;
            //CommandUid = o.CommandUid;
        }

        public void Init()
        {
            CommandAction = AccessPortalCommandActionCode.None;
            AccessPortalUid = Guid.Empty;
        }

        [Required]
        [EnumDataType(typeof(GalaxySMS.Common.Enums.AccessPortalCommandActionCode))]
        public AccessPortalCommandActionCode CommandAction { get; set; }

        [Required]
        public Guid AccessPortalUid { get; set; }

        //public Guid CommandUid {get;set;}

    }
}
