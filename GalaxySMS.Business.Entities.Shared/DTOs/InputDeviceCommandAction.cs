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

    public partial class InputDeviceCommandAction //: ObjectBase
    {
        public InputDeviceCommandAction()
        {
            Init();
        }

        public InputDeviceCommandAction(InputDeviceCommandAction o)
        {
            Init();
            InputDeviceUid = o.InputDeviceUid;
            CommandAction = o.CommandAction;
            InputDeviceHardwareInformation = o.InputDeviceHardwareInformation;
            CommandUid = o.CommandUid;
        }

        public void Init()
        {
            CommandAction = InputDeviceCommandActionCode.None;
            InputDeviceUid = Guid.Empty;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputDeviceCommandActionCode CommandAction { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputDeviceUid { get; set; }

        // Server side only. We do not need this to have the DataMember attribute
        public InputDevice_GetHardwareInformation InputDeviceHardwareInformation { get; set; }
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
