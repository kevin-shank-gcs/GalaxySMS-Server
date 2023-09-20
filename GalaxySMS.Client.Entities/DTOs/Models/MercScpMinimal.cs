using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class MercScpMinimal : DbObjectBase
    {

        [DataMember]
        public System.Guid MercScpUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public System.Guid ClusterUid { get; set; }


        [DataMember]
        public string ScpName { get; set; }

        [DataMember]
        public string Location { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Nullable<System.Guid> GalaxyPanelModelUid { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public GalaxyPanelModelBasic GalaxyPanelModel { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<GalaxyPanelSiteBasic> GalaxyPanelSites { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<GalaxyCpuBasic> Cpus { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<GalaxyInterfaceBoardBasic> InterfaceBoards { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<GalaxyPanelAlertEventBasic> AlertEvents { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<GalaxyPanelCommandBasic> GalaxyPanelCommands { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public int ClusterNumber { get; set; }


        [DataMember]
        public int InterfaceBoardCount { get; set; }


        [DataMember]
        public int ActiveCpuCount { get; set; }


        [DataMember]
        public int AccessPortalCount { get; set; }


        [DataMember]
        public int InputDeviceCount { get; set; }


        [DataMember]
        public int OutputDeviceCount { get; set; }


        [DataMember]
        public int ElevatorOutputCount { get; set; }


        [DataMember]
        public ICollection<Guid> DisabledCommandIds { get; set; }

    }
}
