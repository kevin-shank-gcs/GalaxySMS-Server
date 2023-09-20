////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Models\RequestModels\AccessPortalTimeSchedulePutReq.cs
//
// summary:	Implements the access portal time schedule put request class
///=================================================================================================

using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    /// <summary>   The access portal time schedule put request. </summary>
    public partial class AccessPortalTimeSchedulePutReq : PutRequestBase
    {
        //public System.Guid AccessPortalTimeScheduleUid { get; set; }


        //public System.Guid AccessPortalUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time schedule UID. </summary>
        ///
        /// <value> The time schedule UID. </value>
        ///=================================================================================================
        [RequiredGuid]
        public System.Guid TimeScheduleUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal schedule type UID. </summary>
        /// <remarks>   </remarks>
        /// <value> The access portal schedule type UID. </value>
        ///=================================================================================================
//        [RequiredGuidNotEmptyAttribute]
        [RequiredGuid]
        public System.Guid AccessPortalScheduleTypeUid { get; set; }
    }
}
