using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

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
    public class AccessPortalAuxiliaryOutputModeEditorData
    {
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid InterfaceBoardSectionModeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardSectionModeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ModeIsAllowed { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public bool DescriptionAllowed { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool TimeScheduleSelectorVisible { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ActivationDelayVisible { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ActivationDurationVisible { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IllegalOpenVisible { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool OpenTooLongVisible { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool InvalidAttemptVisible { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool AccessGrantedVisible { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool DuressVisible { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool PassbackViolationVisible { get; set; }
    }
}
