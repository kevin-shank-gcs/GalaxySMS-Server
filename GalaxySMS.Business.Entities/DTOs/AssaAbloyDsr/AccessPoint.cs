using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Framework.Security;

namespace GalaxySMS.Business.Entities.AssaAbloyDsr
{
    public enum AccessPointSynchronizationStatus
    {

        /// <remarks/>
        SYNCHRONIZED,

        /// <remarks/>
        PENDING,

        /// <remarks/>
        OUT_OF_SYNC,

        /// <remarks/>
        OUT_OF_SYNC_INTERNAL,

        /// <remarks/>
        OUT_OF_SYNC_COMM,

        /// <remarks/>
        ENABLED,

        /// <remarks/>
        DISABLED,

        /// <remarks/>
        CLEARED,

        /// <remarks/>
        UNKNOWN,
    }

    public class AccessPoint: EntityBase
    {
        public string serialNumber
        {
            get;
            set;
        }

        
        public AccessPointType accessPointType
        {
            get;
            set;
        }

        
        public bool online
        {
            get;
            set;
        }

        
        public bool confirmed
        {
            get;
            set;
        }

        
        public AccessPointSynchronizationStatus syncStatus
        {
            get;
            set;
        }

        
        public System.DateTimeOffset lastSeen
        {
            get;
            set;
        }

        
        public System.DateTimeOffset timeOfLastCommunicationError
        {
            get;
            set;
        }

        
        public AccessPointAttributeValue[] accessPointAttributes
        {
            get;
            set;
        }

        
        public LogEntry lastAlarm
        {
            get;
            set;
        }
    }
}
