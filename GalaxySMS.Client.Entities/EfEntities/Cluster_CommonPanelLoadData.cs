////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\Cluster_CommonPanelLoadData.cs
//
// summary:	Implements the cluster common panel load data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A cluster common panel load data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Cluster_CommonPanelLoadData : DbObjectBase
    {
        #region Private Variables
        /// <summary>   The cluster UID. </summary>
        private Guid _ClusterUid = Guid.NewGuid();
        /// <summary>   The cluster number. </summary>
        private int _ClusterNumber = 0;
        /// <summary>   Name of the cluster. </summary>
        private string _ClusterName = string.Empty;
        /// <summary>   The insert date. </summary>
        private DateTimeOffset _InsertDate = DateTimeOffset.Now;
        /// <summary>   The update Date/Time. </summary>
        private DateTimeOffset _UpdateDate = DateTimeOffset.Now;
        /// <summary>   The account code. </summary>
        private int _clusterGroupId = 0;
        /// <summary>   The is active. </summary>
        private bool? _IsActive = false;
        /// <summary>   The aba start digit. </summary>
        private short _AbaStartDigit = 0;
        /// <summary>   The aba stop digit. </summary>
        private short _AbaStopDigit = 0;
        /// <summary>   The aba fold option. </summary>
        private bool? _AbaFoldOption = false;
        /// <summary>   The aba clip option. </summary>
        private bool? _AbaClipOption = false;
        /// <summary>   The wiegand start bit. </summary>
        private short _WiegandStartBit = 0;
        /// <summary>   The wiegand stop bit. </summary>
        private short _WiegandStopBit = 0;
        /// <summary>   The cardax start bit. </summary>
        private short _CardaxStartBit = 0;
        /// <summary>   The cardax stop bit. </summary>
        private short _CardaxStopBit = 0;
        /// <summary>   The lockout after invalid attempts. </summary>
        private short _LockoutAfterInvalidAttempts = 0;
        /// <summary>   The lockout duration in seconds. </summary>
        private int _LockoutDurationSeconds = 0;
        /// <summary>   The access rule override timeout. </summary>
        private int _AccessRuleOverrideTimeout = 0;
        /// <summary>   The unlimited credential timeout. </summary>
        private int _UnlimitedCredentialTimeout = 0;
        /// <summary>   Identifier for the time zone. </summary>
        private string _TimeZoneId = string.Empty;
        /// <summary>   The activate crisis i/o group number. </summary>
        private int _ActivateCrisisIOGroupNumber = 0;
        /// <summary>   The reset crisis i/o group number. </summary>
        private int _ResetCrisisIOGroupNumber = 0;
        /// <summary>   The locked LED. </summary>
        private short _LockedLED = 0;
        /// <summary>   The unlocked LED. </summary>
        private short _UnlockedLED = 0;
        /// <summary>   The cluster type code. </summary>
        private string _ClusterTypeCode = string.Empty;
        /// <summary>   Length of the credential data. </summary>
        private short _CredentialDataLength = 0;
        /// <summary>   The time schedule type code. </summary>
        private short _TimeScheduleTypeCode = 0;
        /// <summary>   The returnvalue. </summary>
        private int _RETURNVALUE = 0;
        #endregion

        #region Public Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Uid value. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid ClusterUid
        {
            get { return _ClusterUid; }
            set
            {
                if (_ClusterUid != value)
                {
                    _ClusterUid = value;
                    OnPropertyChanged(() => ClusterUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Number value. </summary>
        ///
        /// <value> The cluster number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int ClusterNumber
        {
            get { return _ClusterNumber; }
            set
            {
                if (_ClusterNumber != value)
                {
                    _ClusterNumber = value;
                    OnPropertyChanged(() => ClusterNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Name value. </summary>
        ///
        /// <value> The name of the cluster. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string ClusterName
        {
            get { return _ClusterName; }
            set
            {
                if (_ClusterName != value)
                {
                    _ClusterName = value;
                    OnPropertyChanged(() => ClusterName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Insert Date value. </summary>
        ///
        /// <value> The insert date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public DateTimeOffset InsertDate
        {
            get { return _InsertDate; }
            set
            {
                if (_InsertDate != value)
                {
                    _InsertDate = value;
                    OnPropertyChanged(() => InsertDate);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Update Date value. </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public DateTimeOffset UpdateDate
        {
            get { return _UpdateDate; }
            set
            {
                if (_UpdateDate != value)
                {
                    _UpdateDate = value;
                    OnPropertyChanged(() => UpdateDate);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Account Code value. </summary>
        ///
        /// <value> The account code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int ClusterGroupId
        {
            get { return _clusterGroupId; }
            set
            {
                if (_clusterGroupId != value)
                {
                    _clusterGroupId = value;
                    OnPropertyChanged(() => ClusterGroupId);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Is Active value. </summary>
        ///
        /// <value> The is active. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? IsActive
        {
            get { return _IsActive; }
            set
            {
                if (_IsActive != value)
                {
                    _IsActive = value;
                    OnPropertyChanged(() => IsActive);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Aba Start Digit value. </summary>
        ///
        /// <value> The aba start digit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short AbaStartDigit
        {
            get { return _AbaStartDigit; }
            set
            {
                if (_AbaStartDigit != value)
                {
                    _AbaStartDigit = value;
                    OnPropertyChanged(() => AbaStartDigit);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Aba Stop Digit value. </summary>
        ///
        /// <value> The aba stop digit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short AbaStopDigit
        {
            get { return _AbaStopDigit; }
            set
            {
                if (_AbaStopDigit != value)
                {
                    _AbaStopDigit = value;
                    OnPropertyChanged(() => AbaStopDigit);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Aba Fold Option value. </summary>
        ///
        /// <value> The aba fold option. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? AbaFoldOption
        {
            get { return _AbaFoldOption; }
            set
            {
                if (_AbaFoldOption != value)
                {
                    _AbaFoldOption = value;
                    OnPropertyChanged(() => AbaFoldOption);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Aba Clip Option value. </summary>
        ///
        /// <value> The aba clip option. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool? AbaClipOption
        {
            get { return _AbaClipOption; }
            set
            {
                if (_AbaClipOption != value)
                {
                    _AbaClipOption = value;
                    OnPropertyChanged(() => AbaClipOption);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Wiegand Start Bit value. </summary>
        ///
        /// <value> The wiegand start bit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short WiegandStartBit
        {
            get { return _WiegandStartBit; }
            set
            {
                if (_WiegandStartBit != value)
                {
                    _WiegandStartBit = value;
                    OnPropertyChanged(() => WiegandStartBit);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Wiegand Stop Bit value. </summary>
        ///
        /// <value> The wiegand stop bit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short WiegandStopBit
        {
            get { return _WiegandStopBit; }
            set
            {
                if (_WiegandStopBit != value)
                {
                    _WiegandStopBit = value;
                    OnPropertyChanged(() => WiegandStopBit);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cardax Start Bit value. </summary>
        ///
        /// <value> The cardax start bit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short CardaxStartBit
        {
            get { return _CardaxStartBit; }
            set
            {
                if (_CardaxStartBit != value)
                {
                    _CardaxStartBit = value;
                    OnPropertyChanged(() => CardaxStartBit);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cardax Stop Bit value. </summary>
        ///
        /// <value> The cardax stop bit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short CardaxStopBit
        {
            get { return _CardaxStopBit; }
            set
            {
                if (_CardaxStopBit != value)
                {
                    _CardaxStopBit = value;
                    OnPropertyChanged(() => CardaxStopBit);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Lockout After Invalid Attempts value. </summary>
        ///
        /// <value> The lockout after invalid attempts. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short LockoutAfterInvalidAttempts
        {
            get { return _LockoutAfterInvalidAttempts; }
            set
            {
                if (_LockoutAfterInvalidAttempts != value)
                {
                    _LockoutAfterInvalidAttempts = value;
                    OnPropertyChanged(() => LockoutAfterInvalidAttempts);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Lockout Duration Seconds value. </summary>
        ///
        /// <value> The lockout duration seconds. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int LockoutDurationSeconds
        {
            get { return _LockoutDurationSeconds; }
            set
            {
                if (_LockoutDurationSeconds != value)
                {
                    _LockoutDurationSeconds = value;
                    OnPropertyChanged(() => LockoutDurationSeconds);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Access Rule Override Timeout value. </summary>
        ///
        /// <value> The access rule override timeout. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int AccessRuleOverrideTimeout
        {
            get { return _AccessRuleOverrideTimeout; }
            set
            {
                if (_AccessRuleOverrideTimeout != value)
                {
                    _AccessRuleOverrideTimeout = value;
                    OnPropertyChanged(() => AccessRuleOverrideTimeout);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Unlimited Credential Timeout value. </summary>
        ///
        /// <value> The unlimited credential timeout. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int UnlimitedCredentialTimeout
        {
            get { return _UnlimitedCredentialTimeout; }
            set
            {
                if (_UnlimitedCredentialTimeout != value)
                {
                    _UnlimitedCredentialTimeout = value;
                    OnPropertyChanged(() => UnlimitedCredentialTimeout);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Time Zone Id value. </summary>
        ///
        /// <value> The identifier of the time zone. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string TimeZoneId
        {
            get { return _TimeZoneId; }
            set
            {
                if (_TimeZoneId != value)
                {
                    _TimeZoneId = value;
                    OnPropertyChanged(() => TimeZoneId);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Activate Crisis IO Group Number value. </summary>
        ///
        /// <value> The activate crisis i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int ActivateCrisisIOGroupNumber
        {
            get { return _ActivateCrisisIOGroupNumber; }
            set
            {
                if (_ActivateCrisisIOGroupNumber != value)
                {
                    _ActivateCrisisIOGroupNumber = value;
                    OnPropertyChanged(() => ActivateCrisisIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Reset Crisis IO Group Numbe value. </summary>
        ///
        /// <value> The reset crisis i/o group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int ResetCrisisIOGroupNumber
        {
            get { return _ResetCrisisIOGroupNumber; }
            set
            {
                if (_ResetCrisisIOGroupNumber != value)
                {
                    _ResetCrisisIOGroupNumber = value;
                    OnPropertyChanged(() => ResetCrisisIOGroupNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Locked LED value. </summary>
        ///
        /// <value> The locked LED. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short LockedLED
        {
            get { return _LockedLED; }
            set
            {
                if (_LockedLED != value)
                {
                    _LockedLED = value;
                    OnPropertyChanged(() => LockedLED);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Unlocked LED value. </summary>
        ///
        /// <value> The unlocked LED. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short UnlockedLED
        {
            get { return _UnlockedLED; }
            set
            {
                if (_UnlockedLED != value)
                {
                    _UnlockedLED = value;
                    OnPropertyChanged(() => UnlockedLED);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Cluster Type Code value. </summary>
        ///
        /// <value> The cluster type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string ClusterTypeCode
        {
            get { return _ClusterTypeCode; }
            set
            {
                if (_ClusterTypeCode != value)
                {
                    _ClusterTypeCode = value;
                    OnPropertyChanged(() => ClusterTypeCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Credential Data Length value. </summary>
        ///
        /// <value> The length of the credential data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short CredentialDataLength
        {
            get { return _CredentialDataLength; }
            set
            {
                if (_CredentialDataLength != value)
                {
                    _CredentialDataLength = value;
                    OnPropertyChanged(() => CredentialDataLength);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Time Schedule Type Code value. </summary>
        ///
        /// <value> The time schedule type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public short TimeScheduleTypeCode
        {
            get { return _TimeScheduleTypeCode; }
            set
            {
                if (_TimeScheduleTypeCode != value)
                {
                    _TimeScheduleTypeCode = value;
                    OnPropertyChanged(() => TimeScheduleTypeCode);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the return value value. </summary>
        ///
        /// <value> The returnvalue. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public int RETURNVALUE
        {
            get { return _RETURNVALUE; }
            set
            {
                if (_RETURNVALUE != value)
                {
                    _RETURNVALUE = value;
                    OnPropertyChanged(() => RETURNVALUE);
                }
            }
        }


        #endregion
    }
}
