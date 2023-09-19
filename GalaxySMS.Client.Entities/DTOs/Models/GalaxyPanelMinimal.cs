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
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class GalaxyPanelMinimal
    {

        [DataMember]
        public System.Guid GalaxyPanelUid { get; set; }

        [DataMember]
        public string PanelName { get; set; }
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
