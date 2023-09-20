using GCS.Core.Common.Core;
using System.Runtime.Serialization;
//using GCS.Framework.Security;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.AssaAbloyDsr
#else
namespace GalaxySMS.Business.Entities.AssaAbloyDsr
#endif
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

#if NetCoreApi
#else
    [DataContract]
#endif
    public class AccessPoint : EntityBase
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public string serialNumber
        {
            get;
            set;
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPointType accessPointType
        {
            get;
            set;
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public bool online
        {
            get;
            set;
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public bool confirmed
        {
            get;
            set;
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPointSynchronizationStatus syncStatus
        {
            get;
            set;
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset lastSeen
        {
            get;
            set;
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset timeOfLastCommunicationError
        {
            get;
            set;
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPointAttributeValue[] accessPointAttributes
        {
            get;
            set;
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public LogEntry lastAlarm
        {
            get;
            set;
        }
    }
}
