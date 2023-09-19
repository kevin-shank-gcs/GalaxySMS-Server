////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AssaAbloyDsr\LogEntry.cs
//
// summary:	Implements the log entry class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities.AssaAbloyDsr
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A log entry. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class LogEntry : DtoObjectBase
    {
        /// <summary>   The origin field. </summary>
        private LogOrigin originField;

        /// <summary>   The family field. </summary>
        private LogFamily familyField;

        /// <summary>   The code field. </summary>
        private LogCode codeField;

        /// <summary>   The time stamp field Date/Time. </summary>
        private System.DateTimeOffset timeStampField;

        /// <summary>   The request identifier field. </summary>
        private DsrUUID requestIdField;

        /// <summary>   The log data field. </summary>
        private LogData[] logDataField;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the origin. </summary>
        ///
        /// <value> The origin. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public LogOrigin origin
        {
            get
            {
                return this.originField;
            }
            set
            {
                this.originField = value;
                OnPropertyChanged(() => origin, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the family. </summary>
        ///
        /// <value> The family. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public LogFamily family
        {
            get
            {
                return this.familyField;
            }
            set
            {
                this.familyField = value;
                OnPropertyChanged(() => family, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the code. </summary>
        ///
        /// <value> The code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public LogCode code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
                OnPropertyChanged(() => code, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time stamp. </summary>
        ///
        /// <value> The time stamp. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.DateTimeOffset timeStamp
        {
            get
            {
                return this.timeStampField;
            }
            set
            {
                this.timeStampField = value;
                OnPropertyChanged(() => timeStamp, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the request. </summary>
        ///
        /// <value> The identifier of the request. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DsrUUID requestId
        {
            get
            {
                return this.requestIdField;
            }
            set
            {
                this.requestIdField = value;
                OnPropertyChanged(() => requestId, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the log. </summary>
        ///
        /// <value> Information describing the log. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public LogData[] logData
        {
            get
            {
                return this.logDataField;
            }
            set
            {
                this.logDataField = value;
                OnPropertyChanged(() => logData, false);
            }
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A log origin. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class LogOrigin : DtoObjectBase
    {

        /// <summary>   The log origin type field. </summary>
        private LogOriginType logOriginTypeField;

        /// <summary>   The origin identifier field. </summary>
        private string originIdField;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the log origin. </summary>
        ///
        /// <value> The type of the log origin. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public LogOriginType logOriginType
        {
            get
            {
                return this.logOriginTypeField;
            }
            set
            {
                this.logOriginTypeField = value;
                OnPropertyChanged(() => logOriginType, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the origin. </summary>
        ///
        /// <value> The identifier of the origin. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string originId
        {
            get
            {
                return this.originIdField;
            }
            set
            {
                this.originIdField = value;
                OnPropertyChanged(() => originId, false);
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent log origin types. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum LogOriginType
    {

        /// <remarks/>
        CONTROLLER,

        /// <remarks/>
        DOOR,

        /// <remarks/>
        EXTENSION,

        /// <remarks/>
        DSR,

        /// <remarks/>
        CYLINDER,

        /// <remarks/>
        KEY,
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent log families. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum LogFamily
    {

        /// <remarks/>
        ACCESS,

        /// <remarks/>
        ALARM,

        /// <remarks/>
        GENERAL,

        /// <remarks/>
        AUDIT,
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent log codes. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum LogCode
    {

        /// <remarks/>
        PROPRIETARY,

        /// <remarks/>
        DOOR_FORCED,

        /// <remarks/>
        DOOR_HELD,

        /// <remarks/>
        DOOR_BOLTTHROWN,

        /// <remarks/>
        DOOR_BOLTRETRACTED,

        /// <remarks/>
        MODE_PROGRAMMING,

        /// <remarks/>
        MODE_LOCKOUT,

        /// <remarks/>
        MODE_LOCKOUT_TIMED,

        /// <remarks/>
        MODE_LOCKOUT_USER,

        /// <remarks/>
        MODE_RELOCK,

        /// <remarks/>
        MODE_EMERGENCY,

        /// <remarks/>
        MODE_PANIC,

        /// <remarks/>
        MODE_RESET,

        /// <remarks/>
        MODE_NORMAL,

        /// <remarks/>
        MODE_PASSAGE,

        /// <remarks/>
        MODE_PASSAGE_TIMED,

        /// <remarks/>
        MODE_PASSAGE_USER,

        /// <remarks/>
        MODE_LOCKED,

        /// <remarks/>
        MODE_LOCKED_TIMED,

        /// <remarks/>
        MODE_LOCKED_USER,

        /// <remarks/>
        MODE_SECURED,

        /// <remarks/>
        MODE_PANIC_END,

        /// <remarks/>
        BATTERY_DEPLETED,

        /// <remarks/>
        BATTERY_REPLACED,

        /// <remarks/>
        BATTERY_CRITICAL,

        /// <remarks/>
        BATTERY_WARN,

        /// <remarks/>
        BATTERY_CHECK_ERROR,

        /// <remarks/>
        USER_MODIFY,

        /// <remarks/>
        USER_REVOKE,

        /// <remarks/>
        USER_ADD,

        /// <remarks/>
        USER_BADTIME,

        /// <remarks/>
        USER_INVALID,

        /// <remarks/>
        USER_OK,

        /// <remarks/>
        ACCESS_DENIED,

        /// <remarks/>
        ACCESS_DENIED_SCHEDULE,

        /// <remarks/>
        ACCESS_DENIED_LOCKOUT,

        /// <remarks/>
        ACCESS_DENIED_BOLTED,

        /// <remarks/>
        ACCESS_DENIED_EXPIRED,

        /// <remarks/>
        ACCESS_DENIED_BUSY,

        /// <remarks/>
        ACCESS_DENIED_SUSPENDED,

        /// <remarks/>
        ACCESS_DENIED_PANIC,

        /// <remarks/>
        ACCESS_DENIED_PASSAGE,

        /// <remarks/>
        ACCESS_GRANTED,

        /// <remarks/>
        ACCESS_GRANTED_REMOTEUNLOCK,

        /// <remarks/>
        ACCESS_GRANTED_ONE_TIME_USER,

        /// <remarks/>
        ACCESS_GRANTED_NOTIFY,

        /// <remarks/>
        ACCESS_GRANTED_DEADBOLT_OVERRIDE,

        /// <remarks/>
        ACCESS_KEYOVERRIDE,

        /// <remarks/>
        ACCESS_INVALIDENTRY,

        /// <remarks/>
        AUTHORIZATION_SUCCESS_COMMUSER,

        /// <remarks/>
        AUTHORIZATION_DENY_COMMUSER,

        /// <remarks/>
        AUTHORIZATION_SUCCESS_MASTER,

        /// <remarks/>
        AUTHORIZATION_FAIL_MASTER,

        /// <remarks/>
        LOG_LOGCLEARED,

        /// <remarks/>
        LOG_LOGWRAPPED,

        /// <remarks/>
        FIRMWARE_UPDATE_ABORT,

        /// <remarks/>
        FIRMWARE_UPDATE_ERROR,

        /// <remarks/>
        FIRMWARE_UPDATE_TIMEOUT,

        /// <remarks/>
        FIRMWARE_UPDATE_SUCCESS,

        /// <remarks/>
        FIRMWARE_UPDATE_FAIL,

        /// <remarks/>
        DB_USERDB_RESET,

        /// <remarks/>
        DB_USERDB_RESET_USER,

        /// <remarks/>
        CLOCK_DATETIMESET,

        /// <remarks/>
        CLOCK_DSTFORWARD,

        /// <remarks/>
        CLOCK_DSTBACK,

        /// <remarks/>
        CLOCK_ERROR,

        /// <remarks/>
        CLOCK_RESET,

        /// <remarks/>
        NVRAM_CLEAR,

        /// <remarks/>
        NVRAM_OK,

        /// <remarks/>
        NVRAM_CLEAR_USER,

        /// <remarks/>
        NVRAM_LAYUT_CHANGED,

        /// <remarks/>
        NVRAM_CHECKSUM,

        /// <remarks/>
        HW_MORTISE_ERROR,

        /// <remarks/>
        HW_POWER_ERROR,

        /// <remarks/>
        HW_DPAC_ERROR,

        /// <remarks/>
        COMMUNICATION_ERROR,

        /// <remarks/>
        COMMUNICATION_TIMEOUT,

        /// <remarks/>
        COMMUNICATION_HW_DISABLED,

        /// <remarks/>
        COMMUNICATION_START,

        /// <remarks/>
        COMMUNICATION_END,

        /// <remarks/>
        RESET_PERFORMED,

        /// <remarks/>
        REMOTE_AUTHORIZATION_REQUEST,

        /// <remarks/>
        RXOVERRUN,

        /// <remarks/>
        ACCESSPOINT_RXHELD,

        /// <remarks/>
        ACCESSPOINT_DELETED,

        /// <remarks/>
        ACCESSPOINT_CREATED,

        /// <remarks/>
        ACCESSPOINT_REPLACED,

        /// <remarks/>
        ACCESSPOINT_CONFIRMED,

        /// <remarks/>
        ACCESSPOINT_UNCONFIRMED,

        /// <remarks/>
        ACCESSPOINT_ONLINE,

        /// <remarks/>
        ACCESSPOINT_OFFLINE,

        /// <remarks/>
        ACCESSPOINT_REQUEST_CLOCK_RESET,

        /// <remarks/>
        INTERNAL_ERROR,

        /// <remarks/>
        LOG_RETRIEVED,

        /// <remarks/>
        FIRMWARE_TAMPERED,

        /// <remarks/>
        LOCK_TAMPERED,

        /// <remarks/>
        AUDIT_LOG,

        /// <remarks/>
        MISSED_CALLBACKS_FROM_DSR,

        /// <remarks/>
        INTEGRITY_CHECK_FAILED,

        /// <remarks/>
        PRESENT_ON_BLACKLIST,

        /// <remarks/>
        BLACKLIST_CLEARED,

        /// <remarks/>
        BLACKLIST_LOADED,
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A dsr uuid. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class DsrUUID : DtoObjectBase
    {

        /// <summary>   The request identifier field. </summary>
        private string requestIdField;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the request. </summary>
        ///
        /// <value> The identifier of the request. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string requestId
        {
            get
            {
                return this.requestIdField;
            }
            set
            {
                this.requestIdField = value;
                OnPropertyChanged(() => requestId, false);
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A log data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class LogData : DtoObjectBase
    {

        /// <summary>   The name field. </summary>
        private string nameField;

        /// <summary>   The value field. </summary>
        private LogDataType valueField;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
                OnPropertyChanged(() => name, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value. </summary>
        ///
        /// <value> The value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public LogDataType value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
                OnPropertyChanged(() => value, false);
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A log data type. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class LogDataType : DtoObjectBase
    {
        /// <summary>   The int value field. </summary>
        private long intValueField;

        /// <summary>   True if int value field specified. </summary>
        private bool intValueFieldSpecified;

        /// <summary>   The string value field. </summary>
        private string stringValueField;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the int value. </summary>
        ///
        /// <value> The int value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public long intValue
        {
            get
            {
                return this.intValueField;
            }
            set
            {
                this.intValueField = value;
                OnPropertyChanged(() => intValue, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the int value specified. </summary>
        ///
        /// <value> True if int value specified, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool intValueSpecified
        {
            get
            {
                return this.intValueFieldSpecified;
            }
            set
            {
                this.intValueFieldSpecified = value;
                OnPropertyChanged(() => intValueSpecified, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string value. </summary>
        ///
        /// <value> The string value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string stringValue
        {
            get
            {
                return this.stringValueField;
            }
            set
            {
                this.stringValueField = value;
                OnPropertyChanged(() => stringValue, false);
            }
        }

    }

}
