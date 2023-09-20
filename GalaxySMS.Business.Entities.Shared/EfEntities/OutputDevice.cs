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
    public partial class OutputDevice : EntityBase, IIdentifiableEntity, IEquatable<OutputDevice>, ITableEntityBase, IHasBinaryResource, IHasEntityMappingList, IHasRoleMappingList, IHasEntityId
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid OutputDeviceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> BinaryResourceUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid SiteUid { get; set; }

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
        public bool EMailEventsEnabled { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool TransmitEventsEnabled { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool FileOutputEnabled { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsTemplate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public gcsBinaryResource gcsBinaryResource { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyOutputDevice GalaxyOutputDevice { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Name
        {
            get { return OutputName; }

            set { OutputName = value; }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RegionName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SiteName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> EntityIds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> RoleIds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Note> Notes { get; set; }
        
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<OutputCommand> Commands { get; set; }


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
        public short BoardNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short SectionNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short ModuleNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short NodeNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyPanelModelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string GalaxyPanelTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InterfaceBoardTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InterfaceBoardModel { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid InterfaceBoardSectionModeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short InterfaceBoardSectionModeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyHardwareModuleTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short ModuleTypeCode { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsNodeActive { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsBoundToHardware { get; set; }


    }
}
