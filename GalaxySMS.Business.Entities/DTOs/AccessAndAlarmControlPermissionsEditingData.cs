using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{

    public class InputOutputGroupSelectionItem : EntityBase
    {
        public InputOutputGroupSelectionItem()
        {

        }

        public Guid InputOutputGroupUid { get; set; }
        public Guid ClusterUid { get; set; }
        public Guid EntityId { get; set; }
        public string InputOutputGroupName { get; set; }
        public string Description { get; set; }
        public int InputOutputGroupNumber { get; set; }

    }

    public class AccessGroupSelectionItem : EntityBase
    {
        public AccessGroupSelectionItem()
        {

        }

        public Guid AccessGroupUid { get; set; }
        public Guid ClusterUid { get; set; }
        public Guid EntityId { get; set; }

        public string AccessGroupName { get; set; }
        public string Description { get; set; }

        public int AccessGroupNumber { get; set; }

        public bool IsExtendedAccessGroup => AccessGroupNumber > GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess;

    }

    public class AccessPortalSelectionItem : EntityBase
    {
        public AccessPortalSelectionItem()
        {

        }


        public Guid AccessPortalUid {get;set;}
        public Guid ClusterUid { get; set; }
        public Guid EntityId { get; set; }

        public string AccessPortalName { get; set; }
        public string Location {get;set;}

        public byte[] BinaryResource { get; set; }
        public string ClusterTypeCode { get; set; }
        public string GalaxyPanelTypeCode { get; set; }
        public string InterfaceBoardModel { get; set; }
        public short InterfaceBoardSectionModeCode { get; set; }
        public short InterfaceBoardTypeCode { get; set; }
        public short ModuleTypeCode { get; set; }

    }

    public class TimeScheduleSelectionItem : EntityBase
    {
        public TimeScheduleSelectionItem()
        {

        }

        public Guid TimeScheduleUid { get; set; }

        public string TimeScheduleName { get; set; }
        public string Description { get; set; }
        public Guid EntityId { get; set; }

    }

    public class ClusterSelectionItem : EntityBase
    {
        public ClusterSelectionItem()
        {
            AccessGroups = new HashSet<AccessGroupSelectionItem>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItem>();
        }

        public Guid ClusterUid { get; set; }
        public Guid SiteUid { get; set; }

        public string ClusterName { get; set; }

        public int ClusterNumber { get; set; }

        public int ClusterGroupId { get; set; }

        public byte[] BinaryResource { get; set; }

        public Guid EntityId { get; set; }

        public ICollection<AccessGroupSelectionItem> AccessGroups { get; set; }

        public ICollection<InputOutputGroupSelectionItem> InputOutputGroups { get; set; }

        public ICollection<TimeScheduleSelectionItem> TimeSchedules { get; set; }

        public ICollection<AccessPortalSelectionItem> AccessPortals { get; set; }

    }

    public class SiteSelectionItem : EntityBase
    {
        public SiteSelectionItem()
        {
            Clusters = new HashSet<ClusterSelectionItem>();
        }
        public Guid SiteUid { get; set; }
        public Guid RegionUid { get; set; }
        public string SiteName { get; set; }
        public byte[] BinaryResource { get; set; }
        public string SiteId { get; set; }
        public Guid EntityId { get; set; }
        public ICollection<ClusterSelectionItem> Clusters { get; set; }

    }

    public class RegionSelectionItem : EntityBase
    {
        public RegionSelectionItem()
        {
            Sites = new HashSet<SiteSelectionItem>();
        }

        public Guid RegionUid { get; set; }
        public string RegionName { get; set; }
        public byte[] BinaryResource { get; set; }
        public string RegionId { get; set; }
        public Guid EntityId { get; set; }
        public ICollection<SiteSelectionItem> Sites { get; set; }

    }

    public class AccessAndAlarmControlPermissionsEditingData : EntityBase
    {
        public AccessAndAlarmControlPermissionsEditingData()
        {
            Regions = new HashSet<RegionSelectionItem>();

        }
        public ICollection<RegionSelectionItem> Regions { get; set; }

    }
}
