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

    public partial class OutputDeviceCommandAction //: ObjectBase
    {
        public OutputDeviceCommandAction()
        {
            Init();
        }

        public OutputDeviceCommandAction(OutputDeviceCommandAction o)
        {
            Init();
            OutputDeviceUid = o.OutputDeviceUid;
            CommandAction = o.CommandAction;
            OutputDeviceHardwareInformation = o.OutputDeviceHardwareInformation;
            CommandUid = o.CommandUid;
        }

        public void Init()
        {
            CommandAction = OutputDeviceCommandActionCode.None;
            OutputDeviceUid = Guid.Empty;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public OutputDeviceCommandActionCode CommandAction { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OutputDeviceUid { get; set; }

        // Server side only. We do not need this to have the DataMember attribute
        public OutputDevice_GetHardwareInformation OutputDeviceHardwareInformation { get; set; }
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
