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

    public partial class InputOutputGroupCommandAction : ObjectBase
    {
        public InputOutputGroupCommandAction()
        {
            Init();
        }

        public InputOutputGroupCommandAction(InputOutputGroupCommandAction o)
        {
            Init();
            InputOutputGroupUid = o.InputOutputGroupUid;
            CommandAction = o.CommandAction;
            //AccessPortalHardwareInformation = o.AccessPortalHardwareInformation;
            InputOutputGroupNumber = o.InputOutputGroupNumber;
            CommandUid = o.CommandUid;
        }

        public void Init()
        {
            CommandAction = InputOutputGroupCommandActionCode.None;
            InputOutputGroupUid = Guid.Empty;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupCommandActionCode CommandAction { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputOutputGroupUid { get; set; }

        public Byte InputOutputGroupNumber {get; set;}
        //// Server side only. We do not need this to have the DataMember attribute
        //public AccessPortal_GetHardwareInformation AccessPortalHardwareInformation { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CommandUid {get;set;}

    }
}
