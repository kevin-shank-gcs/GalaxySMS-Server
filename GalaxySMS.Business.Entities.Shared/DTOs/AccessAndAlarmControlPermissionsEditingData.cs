using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
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
    public class InputOutputGroupSelectionItem : EntityBase
    {
        public InputOutputGroupSelectionItem()
        {

        }

        public InputOutputGroupSelectionItem(InputOutputGroupSelectionItemBasic o)
        {
            InputOutputGroupUid = o.InputOutputGroupUid;
            ClusterUid = o.ClusterUid;
            EntityId = o.EntityId;
            InputOutputGroupName = o.InputOutputGroupName;
            Description = o.Description;
            InputOutputGroupNumber = o.InputOutputGroupNumber;

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputOutputGroupUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InputOutputGroupName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputOutputGroupNumber { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class AccessGroupSelectionItem : EntityBase
    {
        public AccessGroupSelectionItem()
        {

        }

        public AccessGroupSelectionItem(AccessGroupSelectionItemBasic o)
        {
            AccessGroupUid = o.AccessGroupUid;
            ClusterUid = o.ClusterUid;
            EntityId = o.EntityId;
            AccessGroupName = o.AccessGroupName;
            Description = o.Description;
            AccessGroupNumber = o.AccessGroupNumber;
            //IsExtendedAccessGroup = o.IsExtendedAccessGroup;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessGroupUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string AccessGroupName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessGroupNumber { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        public bool IsExtendedAccessGroup => AccessGroupNumber > GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess;


}

#if NetCoreApi
#else
[DataContract]
#endif
    public class AccessPortalSelectionItem : EntityBase
    {
        public AccessPortalSelectionItem()
        {

        }

        public AccessPortalSelectionItem(AccessPortalSelectionItemBasic o)
        {
            AccessPortalUid = o.AccessPortalUid;
            ClusterUid = o.ClusterUid;
            EntityId = o.EntityId;
            AccessPortalName = o.AccessPortalName;
            Location = o.Location;
            BinaryResource = o.Photo;
            ClusterTypeCode = o.ClusterTypeCode;
            GalaxyPanelTypeCode = o.GalaxyPanelTypeCode;
            InterfaceBoardModel = o.InterfaceBoardModel;
            InterfaceBoardSectionModeCode = o.InterfaceBoardSectionModeCode;
            InterfaceBoardTypeCode = o.InterfaceBoardTypeCode;
            ModuleTypeCode = o.ModuleTypeCode;

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string AccessPortalName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Location { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] BinaryResource { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string GalaxyPanelTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InterfaceBoardModel { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardSectionModeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short ModuleTypeCode { get; set; }

    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class InputDeviceSelectionItem : EntityBase
    {
        public InputDeviceSelectionItem()
        {

        }

        public InputDeviceSelectionItem(InputDeviceSelectionItemBasic o)
        {
            InputDeviceUid = o.InputDeviceUid;
            ClusterUid = o.ClusterUid;
            EntityId = o.EntityId;
            InputName = o.InputName;
            Location = o.Location;
            BinaryResource = o.Photo;
            ClusterTypeCode = o.ClusterTypeCode;
            GalaxyPanelTypeCode = o.GalaxyPanelTypeCode;
            InterfaceBoardModel = o.InterfaceBoardModel;
            InterfaceBoardSectionModeCode = o.InterfaceBoardSectionModeCode;
            InterfaceBoardTypeCode = o.InterfaceBoardTypeCode;
            ModuleTypeCode = o.ModuleTypeCode;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InputName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Location { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] BinaryResource { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string GalaxyPanelTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InterfaceBoardModel { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardSectionModeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short ModuleTypeCode { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class OutputDeviceSelectionItem : EntityBase
    {
        public OutputDeviceSelectionItem()
        {

        }

        public OutputDeviceSelectionItem(OutputDeviceSelectionItemBasic o)
        {
            OutputDeviceUid = o.OutputDeviceUid;
            ClusterUid = o.ClusterUid;
            EntityId = o.EntityId;
            OutputName = o.OutputName;
            Location = o.Location;
            BinaryResource = o.Photo;
            ClusterTypeCode = o.ClusterTypeCode;
            GalaxyPanelTypeCode = o.GalaxyPanelTypeCode;
            InterfaceBoardModel = o.InterfaceBoardModel;
            InterfaceBoardSectionModeCode = o.InterfaceBoardSectionModeCode;
            InterfaceBoardTypeCode = o.InterfaceBoardTypeCode;
            ModuleTypeCode = o.ModuleTypeCode;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OutputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string OutputName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Location { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] BinaryResource { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string GalaxyPanelTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InterfaceBoardModel { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardSectionModeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short ModuleTypeCode { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class TimeScheduleSelectionItem : EntityBase
    {
        public TimeScheduleSelectionItem()
        {

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid TimeScheduleUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TimeScheduleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PanelScheduleNumber { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class ClusterSelectionItem : EntityBase
    {
        public ClusterSelectionItem()
        {
            AccessGroups = new HashSet<AccessGroupSelectionItem>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItem>();
            AccessPortals = new HashSet<AccessPortalSelectionItem>();
            InputDevices = new HashSet<InputDeviceSelectionItem>();
            OutputDevices = new HashSet<OutputDeviceSelectionItem>();
        }

        public ClusterSelectionItem(ClusterSelectionItemBasic o)
        {
            AccessGroups = new HashSet<AccessGroupSelectionItem>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItem>();
            AccessPortals = new HashSet<AccessPortalSelectionItem>();
            InputDevices = new HashSet<InputDeviceSelectionItem>();
            OutputDevices = new HashSet<OutputDeviceSelectionItem>();

            ClusterUid = o.ClusterUid;
            SiteUid = o.SiteUid;
            ClusterName = o.ClusterName;
            ClusterNumber = o.ClusterNumber;
            ClusterGroupId = o.ClusterGroupId;
            Photo = o.Photo;
            EntityId = o.EntityId;

            foreach (var ag in o.AccessGroups)
            {
                AccessGroups.Add(new AccessGroupSelectionItem(ag));
            }

            foreach (var iog in o.InputOutputGroups)
            {
                InputOutputGroups.Add(new InputOutputGroupSelectionItem(iog));
            }

            foreach (var ap in o.AccessPortals)
            {
                AccessPortals.Add(new AccessPortalSelectionItem(ap));
            }

            foreach (var id in o.InputDevices)
            {
                InputDevices.Add(new InputDeviceSelectionItem(id));
            }

            foreach (var od in o.OutputDevices)
            {
                OutputDevices.Add(new OutputDeviceSelectionItem(od));
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid SiteUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterGroupId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Photo { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessGroupSelectionItem> AccessGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputOutputGroupSelectionItem> InputOutputGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleSelectionItem> TimeSchedules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalSelectionItem> AccessPortals { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputDeviceSelectionItem> InputDevices { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<OutputDeviceSelectionItem> OutputDevices { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SiteSelectionItem : EntityBase
    {
        public SiteSelectionItem()
        {
            Clusters = new HashSet<ClusterSelectionItem>();
        }

        public SiteSelectionItem(SiteSelectionItemBasic o)
        {
            SiteUid = o.SiteUid;
            RegionUid = o.RegionUid;
            SiteName = o.SiteName;
            BinaryResource = o.Photo;
            SiteId = o.SiteId;
            EntityId = o.EntityId;
            Clusters = new HashSet<ClusterSelectionItem>();
            foreach (var c in o.Clusters)
                Clusters.Add(new ClusterSelectionItem(c));
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid SiteUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid RegionUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SiteName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] BinaryResource { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SiteId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterSelectionItem> Clusters { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class RegionSelectionItem : EntityBase
    {
        public RegionSelectionItem()
        {
            Sites = new HashSet<SiteSelectionItem>();
        }
        public RegionSelectionItem(Region o)
        {
            Sites = new HashSet<SiteSelectionItem>();
            RegionUid = o.RegionUid;
            RegionName = o.RegionName;
            BinaryResource = o.gcsBinaryResource?.BinaryResource;
            RegionId = o.RegionId;
            EntityId = o.EntityId;
        }

        public RegionSelectionItem(RegionSelectionItemBasic o)
        {
            Sites = new HashSet<SiteSelectionItem>();
            foreach (var item in o.Sites)
            {
                Sites.Add(new SiteSelectionItem(item));
            }
            RegionUid = o.RegionUid;
            RegionName = o.RegionName;
            BinaryResource = o.Photo;
            RegionId = o.RegionId;
            EntityId = o.EntityId;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid RegionUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RegionName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] BinaryResource { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RegionId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<SiteSelectionItem> Sites { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class AccessAndAlarmControlPermissionsEditingData : EntityBase
    {
        public AccessAndAlarmControlPermissionsEditingData()
        {
            Regions = new HashSet<RegionSelectionItemBasic>();

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<RegionSelectionItemBasic> Regions { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class AccessAndAlarmControlPermissionsEditingDataWpf : EntityBase
    {
        public AccessAndAlarmControlPermissionsEditingDataWpf()
        {
            Regions = new HashSet<RegionSelectionItem>();

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<RegionSelectionItem> Regions { get; set; }

    }
}
