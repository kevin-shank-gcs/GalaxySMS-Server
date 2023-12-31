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
    public partial class ClusterReq
    {
        public System.Guid ClusterUid { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the site UID. </summary>
        /// <remarks>   If omitted or '00000000-0000-0000-0000-000000000000' is specified, the system will default to the first created site for the current Entity, or the entity specified by the EntityId parameter.</remarks>
        /// <value> The site UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //[Required]
        public System.Guid SiteUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Specifies the EntityId to add the cluster to. This is ignored if SiteUid is specified and not set to '00000000-0000-0000-0000-000000000000'
        /// </summary>
        ///<remarks>
        /// The server will use the SiteUid to determine the entity IF a valid SiteUid is specified. If a valid SiteUid is not specified, then the system will add the cluster to the oldest site for the specified entity. If EntityId is omitted or '00000000-0000-0000-0000-000000000000' is specified, then the system will use the currentEntityId for the users session to determine which entity and site to use.
        /// </remarks>
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //[Required]

        public System.Guid EntityId { get; set; }

        [Required]
        [Range(0, 65535)]
        public int ClusterNumber { get; set; }

        [Required]
        [StringLength(65)]
        public string ClusterName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public System.Guid ClusterTypeUid { get; set; }

        [Required]
        [EnumDataType(typeof(GalaxySMS.Common.Enums.ClusterType))]
        public GalaxySMS.Common.Enums.ClusterType ClusterType { get; set; }


        [Required]
        public System.Guid CredentialDataLengthUid { get; set; }

        [Required]
        [EnumDataType(typeof(GalaxySMS.Common.Enums.CredentialDataSize))]
        public GalaxySMS.Common.Enums.CredentialDataSize CredentialDataLength { get; set; }

        [Required]
        public System.Guid TimeScheduleTypeUid { get; set; }

        [Required]
        [EnumDataType(typeof(GalaxySMS.Common.Enums.TimeScheduleType))]
        public GalaxySMS.Common.Enums.TimeScheduleType TimeScheduleType { get; set; }


        //[Required]
        //[Range(0, 65535)]
        //public int ClusterGroupId { get; set; }
        //public int ClusterGroupId { get; }

        public bool IsActive { get; set; }

        [Required]
        [Range(1, 59)]
        public short AbaStartDigit { get; set; }

        [Required]
        [Range(2, 60)]
        public short AbaStopDigit { get; set; }

        public bool AbaFoldOption { get; set; }

        public bool AbaClipOption { get; set; }

        [Required]
        [Range(0, 254)]
        public short WiegandStartBit { get; set; }

        [Required]
        [Range(1, 255)]
        public short WiegandStopBit { get; set; }

        [Required]
        [Range(1, 255)]
        public short CardaxStartBit { get; set; }

        [Required]
        [Range(1, 255)]
        public short CardaxStopBit { get; set; }

        [Required]
        [Range(0, 255)]
        public short LockoutAfterInvalidAttempts { get; set; }

        [Required]
        [Range(0, 65535)]
        public int LockoutDurationInCs { get; set; }

        [Required]
        [Range(0, 65535)]
        public int AccessRuleOverrideTimeoutInCs { get; set; }

        [Required]
        [Range(0, 65535)]
        public int UnlimitedCredentialTimeoutInCs { get; set; }

        public string TimeZoneId { get; set; }

        public Nullable<System.Guid> CrisisActivateInputOutputGroupUid { get; set; }

        public Nullable<System.Guid> CrisisResetInputOutputGroupUid { get; set; }

        public System.Guid AccessPortalLockedLedBehaviorModeUid { get; set; }

        [EnumDataType(typeof(GalaxySMS.Common.Enums.ClusterLedBehavior))]
        public GalaxySMS.Common.Enums.ClusterLedBehavior AccessPortalLockedLedBehaviorMode { get; set; }

        public System.Guid AccessPortalUnlockedLedBehaviorModeUid { get; set; }

        [EnumDataType(typeof(GalaxySMS.Common.Enums.ClusterLedBehavior))]
        public GalaxySMS.Common.Enums.ClusterLedBehavior AccessPortalUnlockedLedBehaviorMode { get; set; }

        public Nullable<System.Guid> AccessPortalTypeUid { get; set; }

        //public Nullable<System.Guid> TemplateAccessPortalUid { get; set; }

        public byte[] Image { get; set; }

        //public ICollection<Guid> EntityIds { get; set; }
        public ICollection<Guid> RoleIds { get; set; }

        //public ICollection<EntityIdEntityMapPermissionLevelReq> MappedEntitiesPermissionLevels { get; set; }

        //public ICollection<TimeScheduleSelect> TimeSchedules { get; set; }

        //public ICollection<DayTypeSelect> DayTypes { get; set; }

        //public ClusterType ClusterType { get; set; }

        //public ICollection<InputOutputGroup> InputOutputGroups { get; set; }

        //public ICollection<AccessGroup> AccessGroups { get; set; }

        //public ICollection<Area> Areas { get; set; }

        //public ICollection<ClusterEntityMap> ClusterEntityMaps { get; set; }

        //public ICollection<ClusterInputOutputGroup> ClusterInputOutputGroups { get; set; }

        //public ICollection<GalaxyPanel> GalaxyPanels { get; set; }

        //public ICollection<ClusterCommand> ClusterCommands { get; set; }

        //public ICollection<ClusterCommand> ClusterFlashingCommands { get; set; }

        public ICollection<Guid> ScheduleIds { get; set; }

    }
}
