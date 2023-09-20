////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AssaAbloyDsr\AccessPoint.cs
//
// summary:	Implements the access point class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities.AssaAbloyDsr
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent access point synchronization status. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access point. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AccessPoint: AssaDsrEntityBase
    {
        /// <summary>   The serial number. </summary>
        private string _serialNumber;

        /// <summary>   The access point type field. </summary>
        private AccessPointType accessPointTypeField;

        /// <summary>   True to online field. </summary>
        private bool onlineField;

        /// <summary>   True to confirmed field. </summary>
        private bool confirmedField;

        /// <summary>   The synchronise status field. </summary>
        private AccessPointSynchronizationStatus syncStatusField;

        /// <summary>   The last seen field Date/Time. </summary>
        private System.DateTimeOffset lastSeenField;

        /// <summary>   The time of last communication error field. </summary>
        private System.DateTimeOffset timeOfLastCommunicationErrorField;

        /// <summary>   The access point attributes field. </summary>
        private AccessPointAttributeValue[] accessPointAttributesField;

        /// <summary>   The last alarm field. </summary>
        private LogEntry lastAlarmField;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the serial number. </summary>
        ///
        /// <value> The serial number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string serialNumber
        {
            get { return _serialNumber; }
            set
            {
                if (_serialNumber != value)
                {
                    _serialNumber = value;
                    OnPropertyChanged(() => serialNumber, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the access point. </summary>
        ///
        /// <value> The type of the access point. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AccessPointType accessPointType
        {
            get
            {
                return this.accessPointTypeField;
            }
            set
            {
                this.accessPointTypeField = value;
                OnPropertyChanged(() => accessPointType, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the online. </summary>
        ///
        /// <value> True if online, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool online
        {
            get
            {
                return this.onlineField;
            }
            set
            {
                this.onlineField = value;
                OnPropertyChanged(() => online, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the confirmed. </summary>
        ///
        /// <value> True if confirmed, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool confirmed
        {
            get
            {
                return this.confirmedField;
            }
            set
            {
                this.confirmedField = value;
                OnPropertyChanged(() => confirmed, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the synchronise status. </summary>
        ///
        /// <value> The synchronise status. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AccessPointSynchronizationStatus syncStatus
        {
            get
            {
                return this.syncStatusField;
            }
            set
            {
                this.syncStatusField = value;
                OnPropertyChanged(() => syncStatus, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the last seen. </summary>
        ///
        /// <value> The last seen. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.DateTimeOffset lastSeen
        {
            get
            {
                return this.lastSeenField;
            }
            set
            {
                this.lastSeenField = value;
                OnPropertyChanged(() => lastSeen, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time of last communication error. </summary>
        ///
        /// <value> The time of last communication error. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.DateTimeOffset timeOfLastCommunicationError
        {
            get
            {
                return this.timeOfLastCommunicationErrorField;
            }
            set
            {
                this.timeOfLastCommunicationErrorField = value;
                OnPropertyChanged(() => timeOfLastCommunicationError, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access point attributes. </summary>
        ///
        /// <value> The access point attributes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AccessPointAttributeValue[] accessPointAttributes
        {
            get
            {
                return this.accessPointAttributesField;
            }
            set
            {
                this.accessPointAttributesField = value;
                OnPropertyChanged(() => accessPointAttributes, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the last alarm. </summary>
        ///
        /// <value> The last alarm. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public LogEntry lastAlarm
        {
            get
            {
                return this.lastAlarmField;
            }
            set
            {
                this.lastAlarmField = value;
                OnPropertyChanged(() => lastAlarm, false);
            }
        }
    }
}
