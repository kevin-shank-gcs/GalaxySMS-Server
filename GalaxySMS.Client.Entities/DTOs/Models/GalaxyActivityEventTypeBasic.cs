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
    public partial class GalaxyActivityEventTypeBasic
    {
        [DataMember]
        public System.Guid EventTypeUid { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string ForeColorHex { get; set; }

        [DataMember]
        public string DeviceType { get; set; }

    }

    [DataContract]
    public partial class GalaxyActivityEventTypeBasicGroups
    {
        [DataMember]
        public GalaxyActivityEventTypeBasic[] AccessPortalEventTypes { get; set; }

        [DataMember]
        public GalaxyActivityEventTypeBasic[] GalaxyPanelEventTypes { get; set; }

        [DataMember]
        public GalaxyActivityEventTypeBasic[] InputOutputGroupEventTypes { get; set; }

        [DataMember]
        public GalaxyActivityEventTypeBasic[] InputDeviceEventTypes { get; set; }

        [DataMember]
        public GalaxyActivityEventTypeBasic[] OutputDeviceEventTypes { get; set; }

        [DataMember]
        public GalaxyActivityEventTypeBasic[] ElevatorEventTypes { get; set; }
    }

}
