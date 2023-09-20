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
    public partial class GalaxyPanelBasic : EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid GalaxyPanelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int PanelNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PanelName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Location { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> GalaxyPanelModelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyPanelModelBasic GalaxyPanelModel { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyPanelSiteBasic> GalaxyPanelSites { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyCpuBasic> Cpus { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyInterfaceBoardBasic> InterfaceBoards { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GalaxyPanelAlertEventBasic> AlertEvents { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<GalaxyPanelCommandBasic> GalaxyPanelCommands { get; set; }
        
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> DisabledCommandIds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ClusterNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InterfaceBoardCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ActiveCpuCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessPortalCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputDeviceCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int OutputDeviceCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ElevatorOutputCount { get; set; }
    }
}
