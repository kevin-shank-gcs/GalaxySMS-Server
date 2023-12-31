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
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class GalaxyPanelResp 
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

        public ICollection<GalaxyCpuBasic> Cpus { get; set; }

        public ICollection<GalaxyInterfaceBoardBasic> InterfaceBoards { get; set; }

        public ICollection<GalaxyPanelAlertEventBasic> AlertEvents { get; set; }

        public int ClusterNumber { get; set; }
    }
}
