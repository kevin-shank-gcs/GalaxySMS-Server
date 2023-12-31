//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Business.Entities
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
    using GCS.Core.Common.Core;
    public partial class GalaxyPanel : EntityBase, IIdentifiableEntity, IEquatable<GalaxyPanel>
    {
        public System.Guid GalaxyPanelUid { get; set; }
        public System.Guid ClusterUid { get; set; }
        public int PanelNumber { get; set; }
        public string PanelName { get; set; }
        public string Location { get; set; }
        public string InsertName { get; set; }
        public System.DateTimeOffset InsertDate { get; set; }
        public string UpdateName { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<short> ConcurrencyValue { get; set; }
        public Nullable<System.Guid> GalaxyPanelModelUid { get; set; }

        public GalaxyPanelModel GalaxyPanelModel { get; set; }
        public ICollection<GalaxyPanelSite> GalaxyPanelSites { get; set; }

        public ICollection<GalaxyCpu> Cpus { get; set; }
        public ICollection<GalaxyInterfaceBoard> InterfaceBoards { get; set; }
        public ICollection<GalaxyPanelAlertEvent> AlertEvents { get; set; }

        public int ClusterNumber { get; set; }
    }
}
