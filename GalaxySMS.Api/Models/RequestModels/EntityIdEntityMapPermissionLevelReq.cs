////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EntityIdEntityMapPermissionLevel.cs
//
// summary:	Implements the entity identifier entity map permission level class
///=================================================================================================

using System;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public class EntityIdEntityMapPermissionLevelReq
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ///=================================================================================================

        [Required]
        public Guid EntityId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity map permission level UID. </summary>
        ///
        /// <value> The entity map permission level UID. </value>
        ///=================================================================================================

        [Required]
        public Guid EntityMapPermissionLevelUid { get; set; }
    }
}
