using GalaxySMS.Common.Constants;
using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class DeviceListItemBase : ObjectBase
    {
        public DeviceListItemBase()
        {
            WhenCreated = DateTimeOffset.Now;
        }
        [DataMember]
        public Guid EntityId { get; set; }
        [DataMember]
        public Guid UniqueUid { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int ClusterGroupId { get; set; }
        [DataMember]
        public int ClusterNumber { get; set; }
        [DataMember]
        public int PanelNumber { get; set; }
        [DataMember]
        public int BoardNumber { get; set; }
        [DataMember]
        public int SectionNumber { get; set; }
        [DataMember]
        public int ModuleNumber { get; set; }
        [DataMember]
        public int NodeNumber { get; set; }

        public String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.DefaultAccountClusterPanelBoardSectionNode, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber); } }
        [DataMember]
        public DateTimeOffset WhenCreated { get; set; }
        public TimeSpan Age
        {
            get { return DateTimeOffset.Now - WhenCreated; }
        }
    }
}
