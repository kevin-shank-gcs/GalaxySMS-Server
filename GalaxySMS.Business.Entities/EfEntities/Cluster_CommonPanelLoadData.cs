using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public partial class Cluster_CommonPanelLoadData: ObjectBase
    {
        #region Public Properties
        /// <summary>
        /// Get/Set the Cluster Uid value
        /// </summary>

        public Guid ClusterUid { get; set; }

        /// <summary>
        /// Get/Set the Cluster Number value
        /// </summary>

        public int ClusterNumber { get; set; }

        /// <summary>
        /// Get/Set the Cluster Name value
        /// </summary>

        public string ClusterName { get; set; }

        /// <summary>
        /// Get/Set the Insert Date value
        /// </summary>

        public DateTimeOffset InsertDate { get; set; }

        /// <summary>
        /// Get/Set the Update Date value
        /// </summary>

        public DateTimeOffset UpdateDate { get; set; }

        /// <summary>
        /// Get/Set the Account Code value
        /// </summary>

        public int ClusterGroupId { get; set; }

        /// <summary>
        /// Get/Set the Is Active value
        /// </summary>

        public bool? IsActive { get; set; }

        /// <summary>
        /// Get/Set the Aba Start Digit value
        /// </summary>

        public short AbaStartDigit { get; set; }
    /// <summary>
    /// Get/Set the Aba Stop Digit value
    /// </summary>

        public short AbaStopDigit { get; set; }

        /// <summary>
        /// Get/Set the Aba Fold Option value
        /// </summary>

        public bool? AbaFoldOption { get; set; }

        /// <summary>
        /// Get/Set the Aba Clip Option value
        /// </summary>

        public bool? AbaClipOption { get; set; }

        /// <summary>
        /// Get/Set the Wiegand Start Bit value
        /// </summary>

        public short WiegandStartBit { get; set; }

        /// <summary>
        /// Get/Set the Wiegand Stop Bit value
        /// </summary>

        public short WiegandStopBit { get; set; }

        /// <summary>
        /// Get/Set the Cardax Start Bit value
        /// </summary>

        public short CardaxStartBit { get; set; }

        /// <summary>
        /// Get/Set the Cardax Stop Bit value
        /// </summary>

        public short CardaxStopBit { get; set; }

        /// <summary>
        /// Get/Set the Lockout After Invalid Attempts value
        /// </summary>

        public short LockoutAfterInvalidAttempts { get; set; }

        /// <summary>
        /// Get/Set the Lockout Duration Seconds value
        /// </summary>

        public int LockoutDurationSeconds { get; set; }

        /// <summary>
        /// Get/Set the Access Rule Override Timeout value
        /// </summary>

        public short AccessRuleOverrideTimeout { get; set; }

        /// <summary>
        /// Get/Set the Unlimited Credential Timeout value
        /// </summary>

        public short UnlimitedCredentialTimeout { get; set; }

        /// <summary>
        /// Get/Set the Time Zone Id value
        /// </summary>

        public string TimeZoneId { get; set; }

        /// <summary>
        /// Get/Set the Activate Crisis IO Group Number value
        /// </summary>

        public int ActivateCrisisIOGroupNumber { get; set; }

        /// <summary>
        /// Get/Set the Reset Crisis IO Group Numbe value
        /// </summary>

        public int ResetCrisisIOGroupNumber { get; set; }

        /// <summary>
        /// Get/Set the Locked LED value
        /// </summary>

        public short LockedLED { get; set; }

        /// <summary>
        /// Get/Set the Unlocked LED value
        /// </summary>

        public short UnlockedLED { get; set; }

        /// <summary>
        /// Get/Set the Cluster Type Code value
        /// </summary>

        public string ClusterTypeCode { get; set; }

        /// <summary>
        /// Get/Set the Credential Data Length value
        /// </summary>

        public short CredentialDataLength { get; set; }

        /// <summary>
        /// Get/Set the Time Schedule Type Code value
        /// </summary>

        public short TimeScheduleTypeCode { get; set; }

        /// <summary>
        /// Get/Set the return value value
        /// </summary>

        public int RETURNVALUE { get; set; }


        #endregion
    }
}
