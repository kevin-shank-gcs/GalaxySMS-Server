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
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class RegionReq
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique region UID. </summary>
        ///
        /// <value> The region UID. </value>
        ///=================================================================================================

        [Required]
        public System.Guid RegionUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the region. This must be unique relative to the EntityId </summary>
        ///
        /// <value> The name of the region. </value>
        ///=================================================================================================

        [Required]
        [StringLength(100)]
        public string RegionName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique key value of the region. </summary>
        ///
        /// <value> The identifier of the region. </value>
        ///=================================================================================================

        [Required]
        [StringLength(30)]
        public string RegionId { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the identifier of the entity that this Region belongs to. </summary>
        /////
        ///// <value> The identifier of the entity. </value>
        /////=================================================================================================

        //[Required]
        //public System.Guid EntityId { get; set; }

        //public Nullable<System.Guid> BinaryResourceUid { get; set; }

        public byte[] Image { get; set; }
        //public BinaryRes gcsBinaryResource { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the entities that can access this region. </summary>
        ///
        /// <value> A list of identifiers of the entities. </value>
        ///=================================================================================================

        public ICollection<Guid> EntityIds { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the mapped entities permission levels. </summary>
        /////
        ///// <value> The mapped entities permission levels. </value>
        /////=================================================================================================

        //public ICollection<EntityIdEntityMapPermissionLevelReq> MappedEntitiesPermissionLevels { get; set; }


    }
}
