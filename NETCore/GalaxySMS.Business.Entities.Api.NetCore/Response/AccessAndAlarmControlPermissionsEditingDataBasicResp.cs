using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;
using System.Linq;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public class InputOutputGroupSelectionItemBasicResp
    {
        public InputOutputGroupSelectionItemBasicResp()
        {

        }

        public Guid InputOutputGroupUid { get; set; }
        //public Guid ClusterUid { get; set; }
        //public Guid EntityId { get; set; }
        public string InputOutputGroupName { get; set; }
        public string Description { get; set; }
        public int InputOutputGroupNumber { get; set; }

    }
    public class AccessGroupSelectionItemBasicResp
    {
        public AccessGroupSelectionItemBasicResp()
        {

        }

        public Guid AccessGroupUid { get; set; }
        //public Guid ClusterUid { get; set; }
        //public Guid EntityId { get; set; }

        public string AccessGroupName { get; set; }
        public string Description { get; set; }
        public int AccessGroupNumber { get; set; }
        //public bool IsExtendedAccessGroup => AccessGroupNumber > GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess;
        public AccessGroupType AccessGroupType { get
            {
                if (AccessGroupNumber < GalaxySMS.Common.Constants.AccessGroupLimits.MinimumExtendedGroupNumber)
                    return AccessGroupType.Basic;
                if (AccessGroupNumber <= GalaxySMS.Common.Constants.AccessGroupLimits.MaximumNumber)
                    return AccessGroupType.Extended;
                return AccessGroupType.Personal;
            }
        }

    }
    public class AccessPortalSelectionItemBasicResp
    {
        public AccessPortalSelectionItemBasicResp()
        {

        }


        public Guid AccessPortalUid {get;set;}
        //public Guid ClusterUid { get; set; }
        //public Guid EntityId { get; set; }
        public string AccessPortalName { get; set; }
        //public string Location {get;set;}
        //public byte[] Photo { get; set; }
        //public string ClusterTypeCode { get; set; }
        //public string GalaxyPanelTypeCode { get; set; }
        //public string InterfaceBoardModel { get; set; }
        //public short InterfaceBoardSectionModeCode { get; set; }
        //public short InterfaceBoardTypeCode { get; set; }
        //public short ModuleTypeCode { get; set; }

    }
    public class InputDeviceSelectionItemBasicResp
    {
        public InputDeviceSelectionItemBasicResp()
        {

        }
        public Guid InputDeviceUid { get; set; }
        //public Guid ClusterUid { get; set; }
        //public Guid EntityId { get; set; }
        public string InputName { get; set; }
        //public string Location { get; set; }
        //public byte[] Photo { get; set; }
        //public string ClusterTypeCode { get; set; }
        //public string GalaxyPanelTypeCode { get; set; }
        //public string InterfaceBoardModel { get; set; }
        //public short InterfaceBoardSectionModeCode { get; set; }
        //public short InterfaceBoardTypeCode { get; set; }
        //public short ModuleTypeCode { get; set; }

    }
    public class OutputDeviceSelectionItemBasicResp
    {
        public OutputDeviceSelectionItemBasicResp()
        {

        }
        public Guid OutputDeviceUid { get; set; }
        //public Guid ClusterUid { get; set; }
        //public Guid EntityId { get; set; }
        public string OutputName { get; set; }
        //public string Location { get; set; }
        //public byte[] Photo { get; set; }
        //public string ClusterTypeCode { get; set; }
        //public string GalaxyPanelTypeCode { get; set; }
        //public string InterfaceBoardModel { get; set; }
        //public short InterfaceBoardSectionModeCode { get; set; }
        //public short InterfaceBoardTypeCode { get; set; }
        //public short ModuleTypeCode { get; set; }

    }
    public class TimeScheduleSelectionItemBasicResp
    {
        public TimeScheduleSelectionItemBasicResp()
        {

        }
        public Guid TimeScheduleUid { get; set; }
        public string TimeScheduleName { get; set; }
        public string Description { get; set; }
        //public Guid EntityId { get; set; }

    }
    public class ClusterSelectionItemBasicResp
    {
        public ClusterSelectionItemBasicResp()
        {
            AccessGroups = new HashSet<AccessGroupSelectionItemBasicResp>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItemBasicResp>();
            TimeSchedules = new HashSet<TimeScheduleSelectionItemBasicResp>();
            AccessPortals = new HashSet<AccessPortalSelectionItemBasicResp>();
            ////InputDevices = new HashSet<InputDeviceSelectionItemBasicResp>();
            ////OutputDevices = new HashSet<OutputDeviceSelectionItemBasicResp>();
        }
        public Guid ClusterUid { get; set; }
        //public Guid SiteUid { get; set; }

        public string ClusterName { get; set; }

        public int ClusterNumber { get; set; }
        public int ClusterGroupId { get; set; }
        public byte[] Photo { get; set; }
        public Guid EntityId { get; set; }
        //public ICollection<AccessGroupSelectionItemBasicResp> AccessGroupsBasic => AccessGroups.Where(o => o.AccessGroupNumber <= GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess).ToArray();
        //public ICollection<AccessGroupSelectionItemBasicResp> AccessGroupsExtended => AccessGroups.Where(o => o.AccessGroupNumber < GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup).ToArray();
        public ICollection<AccessGroupSelectionItemBasicResp> AccessGroups { get; set; }
        public ICollection<InputOutputGroupSelectionItemBasicResp> InputOutputGroups { get; set; }
        public ICollection<TimeScheduleSelectionItemBasicResp> TimeSchedules { get; set; }
        public ICollection<AccessPortalSelectionItemBasicResp> AccessPortals { get; set; }
        //public ICollection<InputDeviceSelectionItemBasicResp> InputDevices { get; set; }
        //public ICollection<OutputDeviceSelectionItemBasicResp> OutputDevices { get; set; }


    }
    public class SiteSelectionItemBasicResp
    {
        public SiteSelectionItemBasicResp()
        {
            Clusters = new HashSet<ClusterSelectionItemBasicResp>();
        }
        public Guid SiteUid { get; set; }
        //public Guid RegionUid { get; set; }
        public string SiteName { get; set; }
        public byte[] Photo { get; set; }
        //public string SiteId { get; set; }
        public Guid EntityId { get; set; }
        public ICollection<ClusterSelectionItemBasicResp> Clusters { get; set; }

    }
    public class RegionSelectionItemBasicResp
    {
        public RegionSelectionItemBasicResp()
        {
            Sites = new HashSet<SiteSelectionItemBasicResp>();
        }
        public Guid RegionUid { get; set; }
        public string RegionName { get; set; }
        public byte[] Photo { get; set; }
        //public string RegionId { get; set; }
        public Guid EntityId { get; set; }
        public ICollection<SiteSelectionItemBasicResp> Sites { get; set; }

    }
    public class AccessAndAlarmControlPermissionsEditingDataBasicResp
    {
        public AccessAndAlarmControlPermissionsEditingDataBasicResp()
        {
            Regions = new HashSet<RegionSelectionItemBasicResp>();

        }
        public ICollection<RegionSelectionItemBasicResp> Regions { get; set; }

    }
}
