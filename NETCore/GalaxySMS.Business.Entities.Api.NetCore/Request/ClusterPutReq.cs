
using GalaxySMS.Business.Entities.Api.NetCore;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class ClusterPutReq : PutRequestBase
    {
        public System.Guid ClusterUid { get; set; }

        [Required]
        public System.Guid SiteUid { get; set; }

        // This is omitted from PUT because the Entity was determined at creation time by virtue of the site that the cluster is associated with. The entity cannot be changed after creation time.
        //[Required]
        //public System.Guid EntityId { get; set; }

        [Required]
        [Range(1, 65535)]
        public int ClusterNumber { get; set; }

        [Required]
        [StringLength(65)]
        public string ClusterName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public System.Guid ClusterTypeUid { get; set; }

        //[Required]
        //[EnumDataType(typeof(GalaxySMS.Common.Enums.ClusterType))]
        //public GalaxySMS.Common.Enums.ClusterType ClusterType { get; set; }


        [Required]
        public System.Guid CredentialDataLengthUid { get; set; }

        //[Required]
        //[EnumDataType(typeof(GalaxySMS.Common.Enums.CredentialDataSize))]
        //public GalaxySMS.Common.Enums.CredentialDataSize CredentialDataLength { get; set; }

        [Required]
        public System.Guid TimeScheduleTypeUid { get; set; }

        //[Required]
        //[EnumDataType(typeof(GalaxySMS.Common.Enums.TimeScheduleType))]
        //public GalaxySMS.Common.Enums.TimeScheduleType TimeScheduleType { get; set; }


        [Required]
        [Range(0, 65535)]
        [SwaggerSchema(ReadOnly = true)]
        public int ClusterGroupId { get; set; }

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

        //[EnumDataType(typeof(GalaxySMS.Common.Enums.ClusterLedBehavior))]
        //public GalaxySMS.Common.Enums.ClusterLedBehavior AccessPortalLockedLedBehaviorMode { get; set; }

        public System.Guid AccessPortalUnlockedLedBehaviorModeUid { get; set; }

        //[EnumDataType(typeof(GalaxySMS.Common.Enums.ClusterLedBehavior))]
        //public GalaxySMS.Common.Enums.ClusterLedBehavior AccessPortalUnlockedLedBehaviorMode { get; set; }

        public Nullable<System.Guid> AccessPortalTypeUid { get; set; }

        //public Nullable<System.Guid> TemplateAccessPortalUid { get; set; }

        //public BinaryResourceReq gcsBinaryResource { get; set; }

        //public ICollection<Guid> EntityIds { get; set; }
        public ICollection<Guid> RoleIds { get; set; }

        //public ICollection<EntityIdEntityMapPermissionLevelReq> MappedEntitiesPermissionLevels { get; set; }

        //public ICollection<GalaxyClusterTimeScheduleMapPutReq> TimeSchedules { get; set; }

        //public ICollection<GalaxyClusterDayTypeMapPutReq> DayTypes { get; set; }
        public ICollection<Guid> ScheduleIds { get; set; }
        public ICollection<ClusterTimeScheduleItem> MappedSchedules { get; set; }
        public ICollection<Guid> DisabledCommandIds { get; set; }
    }


    public partial class ClusterPutReqMinimalChildren : ClusterPutReq
    {
        public ICollection<GalaxyPanelMinimal> GalaxyPanels { get; set; }
    }
}
