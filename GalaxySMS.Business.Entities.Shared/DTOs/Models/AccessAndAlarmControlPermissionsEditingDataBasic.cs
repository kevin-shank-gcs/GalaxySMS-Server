using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
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
    public class InputOutputGroupSelectionItemBasic //: EntityBaseSimple
    {
        public InputOutputGroupSelectionItemBasic()
        {

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
    public class AccessGroupSelectionItemBasic //: EntityBaseSimple
    {
        public AccessGroupSelectionItemBasic()
        {

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
    public class AccessPortalSelectionItemBasic //: EntityBaseSimple
    {
        public AccessPortalSelectionItemBasic()
        {

        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalUid {get;set;}

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
        public string Location {get;set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Photo { get; set; }

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
    public class InputDeviceSelectionItemBasic// : EntityBaseSimple
    {
        public InputDeviceSelectionItemBasic()
        {

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
        public byte[] Photo { get; set; }

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
    public class OutputDeviceSelectionItemBasic //: EntityBaseSimple
    {
        public OutputDeviceSelectionItemBasic()
        {

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
        public byte[] Photo { get; set; }

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
    public class TimeScheduleSelectionItemBasic //: EntityBaseSimple
    {
        public TimeScheduleSelectionItemBasic()
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

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class ClusterSelectionItemBasic //: EntityBaseSimple
    {
        public ClusterSelectionItemBasic()
        {
            AccessGroups = new HashSet<AccessGroupSelectionItemBasic>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItemBasic>();
            AccessPortals = new HashSet<AccessPortalSelectionItemBasic>();
            InputDevices = new HashSet<InputDeviceSelectionItemBasic>();
            OutputDevices = new HashSet<OutputDeviceSelectionItemBasic>();
            TimeSchedules = new HashSet<TimeScheduleSelectionItemBasic>();
        }

        public ClusterSelectionItemBasic(Cluster o)
        {
            AccessGroups = new HashSet<AccessGroupSelectionItemBasic>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItemBasic>();
            AccessPortals = new HashSet<AccessPortalSelectionItemBasic>();
            InputDevices = new HashSet<InputDeviceSelectionItemBasic>();
            OutputDevices = new HashSet<OutputDeviceSelectionItemBasic>();
            TimeSchedules = new HashSet<TimeScheduleSelectionItemBasic>();

            ClusterUid = o.ClusterUid;
            SiteUid = o.SiteUid;
            ClusterName = o.ClusterName;
            ClusterNumber = o.ClusterNumber;
            ClusterGroupId = o.ClusterGroupId;
            EntityId = o.EntityId;

            Photo = o.gcsBinaryResource?.BinaryResource;
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
        public ICollection<AccessGroupSelectionItemBasic> AccessGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputOutputGroupSelectionItemBasic> InputOutputGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleSelectionItemBasic> TimeSchedules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalSelectionItemBasic> AccessPortals { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputDeviceSelectionItemBasic> InputDevices { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<OutputDeviceSelectionItemBasic> OutputDevices { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SiteSelectionItemBasic //: EntityBaseSimple
    {
        public SiteSelectionItemBasic()
        {
            Clusters = new HashSet<ClusterSelectionItemBasic>();
        }

        public SiteSelectionItemBasic(Site o)
        {
            Clusters = new HashSet<ClusterSelectionItemBasic>();
            if (o != null)
            {
                SiteUid = o.SiteUid;
                RegionUid = o.RegionUid;
                SiteName = o.SiteName;
                Photo = o.gcsBinaryResource?.BinaryResource;
                SiteId = o.SiteId;
                EntityId = o.EntityId;
            }

        }

        public void UpdateFromSite(Site o)
        {
            if (o != null)
            {
                SiteUid = o.SiteUid;
                RegionUid = o.RegionUid;
                SiteName = o.SiteName;
                Photo = o.gcsBinaryResource?.BinaryResource;
                SiteId = o.SiteId;
                EntityId = o.EntityId;
            }
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
        public byte[] Photo { get; set; }

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
        public ICollection<ClusterSelectionItemBasic> Clusters { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class RegionSelectionItemBasic //: EntityBaseSimple
    {
        public RegionSelectionItemBasic()
        {
            Sites = new HashSet<SiteSelectionItemBasic>();
        }

        public RegionSelectionItemBasic(Region o)
        {
            Sites = new HashSet<SiteSelectionItemBasic>();
            if (o != null)
            {
                RegionUid = o.RegionUid;
                RegionName = o.RegionName;
                Photo = o.gcsBinaryResource?.BinaryResource;
                RegionId = o.RegionId;
                EntityId = o.EntityId;
            }
        }

        public void UpdateFromRegion(Region o)
        {
            if (o != null)
            {
                RegionUid = o.RegionUid;
                RegionName = o.RegionName;
                Photo = o.gcsBinaryResource?.BinaryResource;
                RegionId = o.RegionId;
                EntityId = o.EntityId;
            }

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
        public byte[] Photo { get; set; }

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
        public ICollection<SiteSelectionItemBasic> Sites { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class AccessAndAlarmControlPermissionsEditingDataBasic //: EntityBaseSimple
    {
        public AccessAndAlarmControlPermissionsEditingDataBasic()
        {
            Regions = new HashSet<RegionSelectionItemBasic>();

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<RegionSelectionItemBasic> Regions { get; set; }

    }
}
