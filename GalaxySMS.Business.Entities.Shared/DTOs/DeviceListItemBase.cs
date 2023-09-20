using GalaxySMS.Common.Constants;
using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

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
    public class DeviceListItemBase : ObjectBase
    {
        public DeviceListItemBase()
        {
            WhenCreated = DateTimeOffset.Now;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid UniqueUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Name { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterGroupId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int PanelNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int BoardNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int SectionNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int ModuleNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int NodeNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PanelName { get; set; }

        public String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.DefaultAccountClusterPanelBoardSectionNode, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber); } }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset WhenCreated { get; set; }
        public TimeSpan Age
        {
            get { return DateTimeOffset.Now - WhenCreated; }
        }
    }
}
