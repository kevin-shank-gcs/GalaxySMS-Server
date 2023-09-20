using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public partial class AccessPortalCommandAction //: ObjectBase
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalCommandActionCode CommandAction { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalUid { get; set; }

        // Server side only. We do not need this to have the DataMember attribute
        public AccessPortal_GetHardwareInformation AccessPortalHardwareInformation { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CommandUid {get;set;}


#if NetCoreApi
#else
        [DataMember]
#endif
        public string CommandActionCode
        {
            get { return CommandAction.ToString(); }
            set { }
        }
    }
}
