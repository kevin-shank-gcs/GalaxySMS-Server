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

        public partial class AccessPortalTimeScheduleReq : RequestBase
    {
        public System.Guid AccessPortalTimeScheduleUid { get; set; }

        public System.Guid AccessPortalUid { get; set; }

        public System.Guid TimeScheduleUid { get; set; }

        public System.Guid AccessPortalScheduleTypeUid { get; set; }

    }
}
