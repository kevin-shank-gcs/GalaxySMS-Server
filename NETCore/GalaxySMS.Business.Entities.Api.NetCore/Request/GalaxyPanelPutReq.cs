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
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class GalaxyPanelPutReq : PutRequestBase
    {
        [Required]
        public System.Guid GalaxyPanelUid { get; set; }

        [Required]
        public System.Guid ClusterUid { get; set; }
        public string ClusterName { get; set; }
        [Required]
        [Range(1, 65534)]
        public int PanelNumber { get; set; }

        [Required]
        [StringLength(65)]
        public string PanelName { get; set; }

        [Required]
        [StringLength(65)]
        public string Location { get; set; }

        public Nullable<System.Guid> GalaxyPanelModelUid { get; set; }

        //[Required]
        [EnumDataType(typeof(GalaxySMS.Common.Enums.GalaxyPanelModel))]
        public GalaxySMS.Common.Enums.GalaxyPanelModel GalaxyPanelModel {get;set;}

 //       [Required]
        public ICollection<GalaxyCpuPutReq> Cpus { get; set; }

//        [Required]
        public ICollection<GalaxyInterfaceBoardPutReq> InterfaceBoards { get; set; }

        public ICollection<GalaxyPanelAlertEventPutReq> AlertEvents { get; set; }


        // Not used for put, but are here for response data
        public int InterfaceBoardCount { get; set; }
        public int ActiveCpuCount { get; set; }
        public int AccessPortalCount { get; set; }
        public int InputDeviceCount { get; set; }
        public int OutputDeviceCount { get; set; }
        public int ElevatorOutputCount { get; set; }

    }
}
