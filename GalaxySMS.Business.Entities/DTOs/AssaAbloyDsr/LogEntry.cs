using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Framework.Security;

namespace GalaxySMS.Business.Entities.AssaAbloyDsr
{
    
    public partial class LogEntry : EntityBase
    {
        
        public LogOrigin origin
        {
            get;
            set;
        }

        
        public LogFamily family
        {
            get;
            set;
        }

        
        public LogCode code
        {
            get;
            set;
        }

        
        public System.DateTimeOffset timeStamp
        {
            get;
            set;
        }

        
        public DsrUUID requestId
        {
            get;
            set;
        }

        
        public LogData[] logData
        {
            get;
            set;
        }

    }

    
    public partial class LogOrigin : EntityBase
    {
       
        public LogOriginType logOriginType
        {
            get;
            set;
        }

        
        public string originId
        {
            get;
            set;
        }
    }

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

    
    public partial class DsrUUID : EntityBase
    {
       
        public string requestId
        {
            get;
            set;
        }
    }

    
    public partial class LogData : EntityBase
    {
       
        public string name
        {
            get;
            set;
        }

        
        public LogDataType value
        {
            get;
            set;
        }
    }

    
    public partial class LogDataType : EntityBase
    {
        
        public long intValue
        {
            get;
            set;
        }

        
        public bool intValueSpecified
        {
            get;
            set;
        }

        
        public string stringValue
        {
            get;
            set;
        }

    }

}
