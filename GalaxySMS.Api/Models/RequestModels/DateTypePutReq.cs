////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\DateType.cs
//
// summary:	Implements the date type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class DateTypePutReq : PutRequestBase
    {

        [Required]
        public System.Guid DateTypeUid { get; set; }

        [Required]
        public System.Guid EntityId { get; set; }

        [Required]
        public System.Guid DayTypeUid { get; set; }

        [Required]
        public System.DateTimeOffset Date { get; set; }

        [Required]
        [StringLength(65)]
        public string Title { get; set; }
    }
}
