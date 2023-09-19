using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public partial class AccessPortalCommandAction : ObjectBase
    {
        public AccessPortalCommandAction()
        {
            Init();
        }

        public AccessPortalCommandAction(AccessPortalCommandAction o)
        {
            Init();
            AccessPortalUid = o.AccessPortalUid;
            CommandAction = o.CommandAction;
            AccessPortalHardwareInformation = o.AccessPortalHardwareInformation;
            CommandUid = o.CommandUid;
        }

        public void Init()
        {
            CommandAction = AccessPortalCommandActionCode.None;
            AccessPortalUid = Guid.Empty;
        }


        [DataMember]
        public AccessPortalCommandActionCode CommandAction { get; set; }

        [DataMember]
        public Guid AccessPortalUid { get; set; }

        // Server side only. We do not need this to have the DataMember attribute
        public AccessPortal_GetHardwareInformation AccessPortalHardwareInformation { get; set; }
                
        [DataMember]
        public Guid CommandUid {get;set;}

    }
}
