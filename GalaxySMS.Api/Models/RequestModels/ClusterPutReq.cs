
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using GalaxySMS.Api.Models.RequestModels;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class ClusterPutReq : PutRequestBase
    {
        public System.Guid ClusterUid { get; set; }

        [Required]
        public System.Guid SiteUid { get; set; }

        [Required]
        [Range(1, 65535)]
        public int ClusterNumber { get; set; }

        [Required]
        [StringLength(65)]
        public string ClusterName { get; set; }

        [Required]
        public System.Guid ClusterTypeUid { get; set; }

        //[Required]
        //[EnumDataType(typeof(GalaxySMS.Common.Enums.ClusterType))]
        //public GalaxySMS.Common.Enums.ClusterType ClusterType { get; set; }

        [Required]
        public System.Guid EntityId { get; set; }

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


        [StringLength(16, MinimumLength = 0)]
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
        public int LockoutDurationSeconds { get; set; }

        [Required]
        [Range(0, 65535)]
        public short AccessRuleOverrideTimeout { get; set; }

        [Required]
        [Range(0, 65535)]
        public short UnlimitedCredentialTimeout { get; set; }

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

        public BinaryResourceReq gcsBinaryResource { get; set; }

        public ICollection<Guid> EntityIds { get; set; }

        public ICollection<EntityIdEntityMapPermissionLevelReq> MappedEntitiesPermissionLevels { get; set; }

        //public ICollection<GalaxyClusterTimeScheduleMapPutReq> TimeSchedules { get; set; }

        //public ICollection<GalaxyClusterDayTypeMapPutReq> DayTypes { get; set; }
    }
}
