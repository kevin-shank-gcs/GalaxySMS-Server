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
    /// <summary>   The access portal put request. </summary>
    public partial class AccessPortalPutReq : PutRequestBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal UID. </summary>
        ///
        /// <value> The access portal UID. </value>
        ///=================================================================================================

        [Required]
        public System.Guid AccessPortalUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal type UID. </summary>
        ///
        /// <value> The access portal type UID. </value>
        ///=================================================================================================

        [Required]
        public System.Guid AccessPortalTypeUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the site UID. </summary>
        ///
        /// <value> The site UID. </value>
        ///=================================================================================================

        [Required]
        public System.Guid SiteUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ///=================================================================================================

        [Required]
        public System.Guid EntityId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the portal. </summary>
        ///
        /// <value> The name of the portal. </value>
        ///=================================================================================================

        [Required]
        [StringLength(128)]
        public string PortalName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the location. </summary>
        ///
        /// <value> The location. </value>
        ///=================================================================================================

        [StringLength(255)]
        public string Location { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the service comment. </summary>
        ///
        /// <value> The service comment. </value>
        ///=================================================================================================

        [StringLength(1000)]
        public string ServiceComment { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the criticality comment. </summary>
        ///
        /// <value> The criticality comment. </value>
        ///=================================================================================================

        [StringLength(1000)]
        public string CriticalityComment { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the comment. </summary>
        ///
        /// <value> The comment. </value>
        ///=================================================================================================

        [StringLength(1000)]
        public string Comment { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this AccessPortalPutReq is template.
        /// </summary>
        ///
        /// <value> True if this AccessPortalPutReq is template, false if not. </value>
        ///=================================================================================================

        public bool IsTemplate { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs binary resource. </summary>
        ///
        /// <value> The gcs binary resource. </value>
        ///=================================================================================================

        public BinaryResourceReq gcsBinaryResource { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the name. </summary>
        /////
        ///// <value> The name. </value>
        /////=================================================================================================

        //public string Name
        //{
        //    get { return PortalName; }

        //    set { PortalName = value; }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the entities. </summary>
        ///
        /// <value> A list of identifiers of the entities. </value>
        ///=================================================================================================

        public ICollection<Guid> EntityIds { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the mapped entities permission levels. </summary>
        ///
        /// <value> The mapped entities permission levels. </value>
        ///=================================================================================================

        public ICollection<EntityIdEntityMapPermissionLevelReq> MappedEntitiesPermissionLevels { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the properties. </summary>
        ///
        /// <value> The properties. </value>
        ///=================================================================================================

        public AccessPortalPropertiesPutReq Properties { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the areas. </summary>
        ///
        /// <value> The areas. </value>
        ///=================================================================================================

        public ICollection<AccessPortalAreaPutReq> Areas { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the schedules. </summary>
        ///
        /// <value> The schedules. </value>
        ///=================================================================================================

        public ICollection<AccessPortalTimeSchedulePutReq> Schedules { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the alert events. </summary>
        ///
        /// <value> The alert events. </value>
        ///=================================================================================================

        public ICollection<AccessPortalAlertEventPutReq> AlertEvents { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the auxiliary outputs. </summary>
        ///
        /// <value> The auxiliary outputs. </value>
        ///=================================================================================================

        public ICollection<AccessPortalAuxiliaryOutputPutReq> AuxiliaryOutputs { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the notes. </summary>
        ///
        /// <value> The notes. </value>
        ///=================================================================================================

        public ICollection<NotePutReq> Notes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access group access portals. </summary>
        ///
        /// <value> The access group access portals. </value>
        ///=================================================================================================

        public ICollection<AccessGroupAccessPortalApPutReq> AccessGroupAccessPortals { get; set; }

    }
}
