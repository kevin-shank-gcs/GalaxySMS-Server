using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

    public class LoadDataToPanelSettings// : ObjectBase
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ClusterSharedSettings { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool TimeSchedules { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool AllCardData { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public bool CardChanges { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool InputOutputGroups { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public bool AccessPortals { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool AccessPortalsInputsOutputs { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool AccessRules { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public bool InputOutputDevices { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool PanelAlarms { get; set; }
    }
}
