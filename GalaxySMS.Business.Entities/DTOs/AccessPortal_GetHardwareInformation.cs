using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortal_GetHardwareInformation : EntityBase
    {
        #region Public Properties
        public Guid AccessPortalUid { get; set; }
        public Guid AccessPortalTypeUid { get; set; }
        public string PortalName { get; set; }
        public Guid RegionUid { get; set; }
        public string SiteName { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public int PanelNumber { get; set; }
        public short BoardNumber { get; set; }
        public short SectionNumber { get; set; }
        public short ModuleNumber { get; set; }
        public short NodeNumber { get; set; }
        public short DoorNumber { get; set; }
        public Guid ClusterTypeUid { get; set; }
        public string ClusterTypeCode { get; set; }
        public Guid GalaxyPanelModelUid { get; set; }
        public string GalaxyPanelTypeCode { get; set; }
        public Guid InterfaceBoardTypeUid { get; set; }
        public short InterfaceBoardTypeCode { get; set; }
        public string InterfaceBoardModel { get; set; }
        public Guid InterfaceBoardSectionModeUid { get; set; }
        public short InterfaceBoardSectionModeCode { get; set; }
        public Guid GalaxyHardwareModuleTypeUid { get; set; }
        public short ModuleTypeCode { get; set; }
        public Guid ClusterUid { get; set; }
        public Guid GalaxyPanelUid { get; set; }
        public Guid GalaxyInterfaceBoardUid { get; set; }
        public Guid GalaxyInterfaceBoardSectionUid { get; set; }
        public Guid GalaxyHardwareModuleUid { get; set; }
        public Guid GalaxyInterfaceBoardSectionNodeUid { get; set; }
        #endregion

    }
}
