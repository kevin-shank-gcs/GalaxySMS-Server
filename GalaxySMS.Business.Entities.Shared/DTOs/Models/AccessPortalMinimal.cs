//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
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
    public partial class AccessPortalMinimal 
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid AccessPortalUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.Guid AccessPortalTypeUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Nullable<System.Guid> BinaryResourceUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.Guid SiteUid { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PortalName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Location { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ServiceComment { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CriticalityComment { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Comment { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsEnabled { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public bool IsTemplate { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string InsertName { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public System.DateTimeOffset InsertDate { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string UpdateName { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Nullable<short> ConcurrencyValue { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public gcsBinaryResourceBasic gcsBinaryResource { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public byte[] PhotoImage { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string Name
        //        {
        //            get { return PortalName; }

        //            set { PortalName = value; }
        //        }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public System.Guid RegionUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string RegionName { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string SiteName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int ClusterGroupId { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int ClusterNumber { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int PanelNumber { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public short BoardNumber { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public short SectionNumber { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public short ModuleNumber { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public short NodeNumber { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid ClusterTypeUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string ClusterTypeCode { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid GalaxyPanelModelUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string GalaxyPanelTypeCode { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid InterfaceBoardTypeUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public short InterfaceBoardTypeCode { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string InterfaceBoardModel { get; set; }

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

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid GalaxyHardwareModuleTypeUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public short ModuleTypeCode { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<Guid> EntityIds { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<Guid> RoleIds { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public AccessPortalGalaxyHardwareAddressBasic GalaxyHardwareAddress { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public AccessPortalPropertiesBasic Properties { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<AccessPortalAreaBasic> Areas { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<AccessPortalTimeScheduleBasic> Schedules { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<AccessPortalAlertEventBasic> AlertEvents { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<AccessPortalAuxiliaryOutputBasic> AuxiliaryOutputs { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<NoteBasic> Notes { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<AccessGroupAccessPortalBasic> AccessGroups { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<AccessPortalCommandBasic> Commands { get; set; }
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<Guid> DisabledCommandIds { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int DoorNumber { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid GalaxyInterfaceBoardSectionNodeUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid GalaxyHardwareModuleUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid GalaxyInterfaceBoardSectionUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid GalaxyInterfaceBoardUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PanelName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalLastUsageData LastUsageData { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> DisabledCommandIds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsBoundToHardware { get; set; }
    }
}
