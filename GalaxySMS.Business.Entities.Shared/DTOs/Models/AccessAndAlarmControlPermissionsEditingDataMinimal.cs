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
    public class InputOutputGroupSelectionItemMinimal //: EntityBaseSimple
    {
        public InputOutputGroupSelectionItemMinimal()
        {

        }


#if NetCoreApi
#else
        [DataMember]
#endif
        //public Guid InputOutputGroupUid { get; set; }
        public Guid Id { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid ClusterUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        //public string InputOutputGroupName { get; set; }
        public string Name { get; set; }
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
    public class AccessGroupSelectionItemMinimal //: EntityBaseSimple
    {
        public AccessGroupSelectionItemMinimal()
        {

        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessGroupUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid ClusterUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid EntityId { get; set; }


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
    public class AccessPortalSelectionItemMinimal //: EntityBaseSimple
    {
        public AccessPortalSelectionItemMinimal()
        {

        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid Id { get; set; }
        //public Guid AccessPortalUid {get;set;}

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid ClusterUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Name { get; set; }
        //public string AccessPortalName { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string Location {get;set;}

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Photo { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string ClusterTypeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string GalaxyPanelTypeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string InterfaceBoardModel { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public short InterfaceBoardSectionModeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public short InterfaceBoardTypeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public short ModuleTypeCode { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class InputDeviceSelectionItemMinimal// : EntityBaseSimple
    {
        public InputDeviceSelectionItemMinimal()
        {

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        //public Guid InputDeviceUid { get; set; }
        public Guid Id { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid ClusterUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
//        public string InputName { get; set; }
        public string Name { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string Location { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Photo { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string ClusterTypeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string GalaxyPanelTypeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string InterfaceBoardModel { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public short InterfaceBoardSectionModeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public short InterfaceBoardTypeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public short ModuleTypeCode { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class OutputDeviceSelectionItemMinimal //: EntityBaseSimple
    {
        public OutputDeviceSelectionItemMinimal()
        {

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid Id { get; set; }
  //      public Guid OutputDeviceUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid ClusterUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Name { get; set; }
  //      public string OutputName { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string Location { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Photo { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string ClusterTypeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string GalaxyPanelTypeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string InterfaceBoardModel { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public short InterfaceBoardSectionModeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public short InterfaceBoardTypeCode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public short ModuleTypeCode { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class TimeScheduleSelectionItemMinimal //: EntityBaseSimple
    {
        public TimeScheduleSelectionItemMinimal()
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
    public class ClusterSelectionItemMinimal //: EntityBaseSimple
    {
        public ClusterSelectionItemMinimal()
        {
            AccessGroups = new HashSet<AccessGroupSelectionItemMinimal>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItemMinimal>();
            AccessPortals = new HashSet<AccessPortalSelectionItemMinimal>();
            InputDevices = new HashSet<InputDeviceSelectionItemMinimal>();
            OutputDevices = new HashSet<OutputDeviceSelectionItemMinimal>();
            TimeSchedules = new HashSet<TimeScheduleSelectionItemMinimal>();
        }

        public ClusterSelectionItemMinimal(Cluster o)
        {
            AccessGroups = new HashSet<AccessGroupSelectionItemMinimal>();
            InputOutputGroups = new HashSet<InputOutputGroupSelectionItemMinimal>();
            AccessPortals = new HashSet<AccessPortalSelectionItemMinimal>();
            InputDevices = new HashSet<InputDeviceSelectionItemMinimal>();
            OutputDevices = new HashSet<OutputDeviceSelectionItemMinimal>();
            TimeSchedules = new HashSet<TimeScheduleSelectionItemMinimal>();

      //      ClusterUid = o.ClusterUid;
            Id = o.ClusterUid;
            //SiteUid = o.SiteUid;
   //         ClusterName = o.ClusterName;
            Name = o.ClusterName;
            //ClusterNumber = o.ClusterNumber;
            //ClusterGroupId = o.ClusterGroupId;
            //EntityId = o.EntityId;

            Photo = o.gcsBinaryResource?.BinaryResource;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
 //       public Guid ClusterUid { get; set; }

        public Guid Id { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid SiteUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
//        public string ClusterName { get; set; }

        public string Name { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int ClusterNumber { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int ClusterGroupId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Photo { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessGroupSelectionItemMinimal> AccessGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputOutputGroupSelectionItemMinimal> InputOutputGroups { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<TimeScheduleSelectionItemMinimal> TimeSchedules { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalSelectionItemMinimal> AccessPortals { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<InputDeviceSelectionItemMinimal> InputDevices { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<OutputDeviceSelectionItemMinimal> OutputDevices { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SiteSelectionItemMinimal //: EntityBaseSimple
    {
        public SiteSelectionItemMinimal()
        {
            Clusters = new HashSet<ClusterSelectionItemMinimal>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        //public Guid SiteUid { get; set; }

        public Guid Id { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid RegionUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        //public string SiteName { get; set; }

        public string Name { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Photo { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string SiteId { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<ClusterSelectionItemMinimal> Clusters { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class RegionSelectionItemMinimal //: EntityBaseSimple
    {
        public RegionSelectionItemMinimal()
        {
            Sites = new HashSet<SiteSelectionItemMinimal>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
 //       public Guid RegionUid { get; set; }

        public Guid Id { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        //public string RegionName { get; set; }
        public string Name { get; set; }    

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Photo { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string RegionId { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<SiteSelectionItemMinimal> Sites { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class AccessAndAlarmControlPermissionsEditingDataMinimal //: EntityBaseSimple
    {
        public AccessAndAlarmControlPermissionsEditingDataMinimal()
        {
            Regions = new HashSet<RegionSelectionItemMinimal>();

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<RegionSelectionItemMinimal> Regions { get; set; }

    }
}
