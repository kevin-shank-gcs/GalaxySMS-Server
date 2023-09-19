using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.AssaAbloyTestApp
{


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0", ConfigurationName = "CallbackService.DsrCallbackInterface")]
    public interface DsrCallbackInterface
    {

        // CODEGEN: Parameter 'logEntry' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action = "http://xml.assaabloy.com/dsr/2.0/DsrCallbackInterface/newEvent", ReplyAction = "http://xml.assaabloy.com/dsr/2.0/DsrCallbackInterface/newEventResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Entity))]
        newEventResponse newEvent(newEvent request);

        //[System.ServiceModel.OperationContractAttribute(Action = "http://xml.assaabloy.com/dsr/2.0/DsrCallbackInterface/newEvent", ReplyAction = "http://xml.assaabloy.com/dsr/2.0/DsrCallbackInterface/newEventResponse")]
        //System.Threading.Tasks.Task<newEventResponse> newEventAsync(newEvent request);

        // CODEGEN: Parameter 'accessPoint' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action = "http://xml.assaabloy.com/dsr/2.0/DsrCallbackInterface/notifyUpdated", ReplyAction = "http://xml.assaabloy.com/dsr/2.0/DsrCallbackInterface/notifyUpdatedResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Entity))]
        notifyUpdatedResponse notifyUpdated(notifyUpdated request);

        //[System.ServiceModel.OperationContractAttribute(Action = "http://xml.assaabloy.com/dsr/2.0/DsrCallbackInterface/notifyUpdated", ReplyAction = "http://xml.assaabloy.com/dsr/2.0/DsrCallbackInterface/notifyUpdatedResponse")]
        //System.Threading.Tasks.Task<notifyUpdatedResponse> notifyUpdatedAsync(notifyUpdated request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
    public partial class LogEntry : object, System.ComponentModel.INotifyPropertyChanged
    {

        private LogOrigin originField;

        private LogFamily familyField;

        private LogCode codeField;

        private System.DateTimeOffset timeStampField;

        private DsrUUID requestIdField;

        private LogData[] logDataField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public LogOrigin origin
        {
            get
            {
                return this.originField;
            }
            set
            {
                this.originField = value;
                this.RaisePropertyChanged("origin");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public LogFamily family
        {
            get
            {
                return this.familyField;
            }
            set
            {
                this.familyField = value;
                this.RaisePropertyChanged("family");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public LogCode code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
                this.RaisePropertyChanged("code");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public System.DateTimeOffset timeStamp
        {
            get
            {
                return this.timeStampField;
            }
            set
            {
                this.timeStampField = value;
                this.RaisePropertyChanged("timeStamp");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public DsrUUID requestId
        {
            get
            {
                return this.requestIdField;
            }
            set
            {
                this.requestIdField = value;
                this.RaisePropertyChanged("requestId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("logData", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public LogData[] logData
        {
            get
            {
                return this.logDataField;
            }
            set
            {
                this.logDataField = value;
                this.RaisePropertyChanged("logData");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
    public partial class LogOrigin : object, System.ComponentModel.INotifyPropertyChanged
    {

        private LogOriginType logOriginTypeField;

        private string originIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LogOriginType logOriginType
        {
            get
            {
                return this.logOriginTypeField;
            }
            set
            {
                this.logOriginTypeField = value;
                this.RaisePropertyChanged("logOriginType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string originId
        {
            get
            {
                return this.originIdField;
            }
            set
            {
                this.originIdField = value;
                this.RaisePropertyChanged("originId");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
    public partial class AccessPointAttributeValue : object, System.ComponentModel.INotifyPropertyChanged
    {

        private AccessPointAttribute nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public AccessPointAttribute name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
    public enum AccessPointAttribute
    {

        /// <remarks/>
        SERIAL_NUMBER,

        /// <remarks/>
        FIRMWARE_VERSION,

        /// <remarks/>
        FIRMWARE_TAMPERED,

        /// <remarks/>
        TAMPERED,

        /// <remarks/>
        BATTERY_LEVEL,

        /// <remarks/>
        BATTERY_STATUS,

        /// <remarks/>
        DC_VOLTAGE,

        /// <remarks/>
        DESCRIPTION,

        /// <remarks/>
        LOCK_STATE,

        /// <remarks/>
        DOOR_STATE,

        /// <remarks/>
        RADIO_FIRMWARE_VERSION,

        /// <remarks/>
        TLS_CA_CERTIFICATE_VALID_FROM,

        /// <remarks/>
        TLS_CA_CERTIFICATE_VALID_TILL,

        /// <remarks/>
        TLS_CLIENT_CERTIFICATE_VALID_FROM,

        /// <remarks/>
        TLS_CLIENT_CERTIFICATE_VALID_TILL,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
    public partial class AccessPointType : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string idField;

        private string displayNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public string displayName
        {
            get
            {
                return this.displayNameField;
            }
            set
            {
                this.displayNameField = value;
                this.RaisePropertyChanged("displayName");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AccessPoint))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
    public abstract partial class Entity : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
    public partial class AccessPoint : Entity
    {

        private string serialNumberField;

        private AccessPointType accessPointTypeField;

        private bool onlineField;

        private bool confirmedField;

        private AccessPointSynchronizationStatus syncStatusField;

        private System.DateTimeOffset lastSeenField;

        private System.DateTimeOffset timeOfLastCommunicationErrorField;

        private AccessPointAttributeValue[] accessPointAttributesField;

        private LogEntry lastAlarmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string serialNumber
        {
            get
            {
                return this.serialNumberField;
            }
            set
            {
                this.serialNumberField = value;
                this.RaisePropertyChanged("serialNumber");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public AccessPointType accessPointType
        {
            get
            {
                return this.accessPointTypeField;
            }
            set
            {
                this.accessPointTypeField = value;
                this.RaisePropertyChanged("accessPointType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public bool online
        {
            get
            {
                return this.onlineField;
            }
            set
            {
                this.onlineField = value;
                this.RaisePropertyChanged("online");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public bool confirmed
        {
            get
            {
                return this.confirmedField;
            }
            set
            {
                this.confirmedField = value;
                this.RaisePropertyChanged("confirmed");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public AccessPointSynchronizationStatus syncStatus
        {
            get
            {
                return this.syncStatusField;
            }
            set
            {
                this.syncStatusField = value;
                this.RaisePropertyChanged("syncStatus");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        public System.DateTimeOffset lastSeen
        {
            get
            {
                return this.lastSeenField;
            }
            set
            {
                this.lastSeenField = value;
                this.RaisePropertyChanged("lastSeen");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 6)]
        public System.DateTimeOffset timeOfLastCommunicationError
        {
            get
            {
                return this.timeOfLastCommunicationErrorField;
            }
            set
            {
                this.timeOfLastCommunicationErrorField = value;
                this.RaisePropertyChanged("timeOfLastCommunicationError");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("attribute", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public AccessPointAttributeValue[] accessPointAttributes
        {
            get
            {
                return this.accessPointAttributesField;
            }
            set
            {
                this.accessPointAttributesField = value;
                this.RaisePropertyChanged("accessPointAttributes");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 8)]
        public LogEntry lastAlarm
        {
            get
            {
                return this.lastAlarmField;
            }
            set
            {
                this.lastAlarmField = value;
                this.RaisePropertyChanged("lastAlarm");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
    public partial class LogDataType : object, System.ComponentModel.INotifyPropertyChanged
    {

        private long intValueField;

        private bool intValueFieldSpecified;

        private string stringValueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public long intValue
        {
            get
            {
                return this.intValueField;
            }
            set
            {
                this.intValueField = value;
                this.RaisePropertyChanged("intValue");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool intValueSpecified
        {
            get
            {
                return this.intValueFieldSpecified;
            }
            set
            {
                this.intValueFieldSpecified = value;
                this.RaisePropertyChanged("intValueSpecified");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string stringValue
        {
            get
            {
                return this.stringValueField;
            }
            set
            {
                this.stringValueField = value;
                this.RaisePropertyChanged("stringValue");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
    public partial class LogData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string nameField;

        private LogDataType valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public LogDataType value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
                this.RaisePropertyChanged("value");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
    public partial class DsrUUID : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string requestIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string requestId
        {
            get
            {
                return this.requestIdField;
            }
            set
            {
                this.requestIdField = value;
                this.RaisePropertyChanged("requestId");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0")]
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

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "newEvent", WrapperNamespace = "http://xml.assaabloy.com/dsr/2.0", IsWrapped = true)]
    public partial class newEvent
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LogEntry logEntry;

        public newEvent()
        {
        }

        public newEvent(LogEntry logEntry)
        {
            this.logEntry = logEntry;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "newEventResponse", WrapperNamespace = "http://xml.assaabloy.com/dsr/2.0", IsWrapped = true)]
    public partial class newEventResponse
    {

        public newEventResponse()
        {
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "notifyUpdated", WrapperNamespace = "http://xml.assaabloy.com/dsr/2.0", IsWrapped = true)]
    public partial class notifyUpdated
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://xml.assaabloy.com/dsr/2.0", Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AccessPoint accessPoint;

        public notifyUpdated()
        {
        }

        public notifyUpdated(AccessPoint accessPoint)
        {
            this.accessPoint = accessPoint;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "notifyUpdatedResponse", WrapperNamespace = "http://xml.assaabloy.com/dsr/2.0", IsWrapped = true)]
    public partial class notifyUpdatedResponse
    {

        public notifyUpdatedResponse()
        {
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DsrCallbackInterfaceChannel : DsrCallbackInterface, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DsrCallbackInterfaceClient : System.ServiceModel.ClientBase<DsrCallbackInterface>, DsrCallbackInterface
    {

        public DsrCallbackInterfaceClient()
        {
        }

        public DsrCallbackInterfaceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public DsrCallbackInterfaceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public DsrCallbackInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public DsrCallbackInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        newEventResponse DsrCallbackInterface.newEvent(newEvent request)
        {
            return base.Channel.newEvent(request);
        }

        public void newEvent(LogEntry logEntry)
        {
            newEvent inValue = new newEvent();
            inValue.logEntry = logEntry;
            newEventResponse retVal = ((DsrCallbackInterface) (this)).newEvent(inValue);
        }

        //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        //System.Threading.Tasks.Task<newEventResponse> DsrCallbackInterface.newEventAsync(newEvent request)
        //{
        //    return base.Channel.newEventAsync(request);
        //}

        //public System.Threading.Tasks.Task<newEventResponse> newEventAsync(LogEntry logEntry)
        //{
        //    newEvent inValue = new newEvent();
        //    inValue.logEntry = logEntry;
        //    return ((DsrCallbackInterface) (this)).newEventAsync(inValue);
        //}

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        notifyUpdatedResponse DsrCallbackInterface.notifyUpdated(notifyUpdated request)
        {
            return base.Channel.notifyUpdated(request);
        }

        public void notifyUpdated(AccessPoint accessPoint)
        {
            notifyUpdated inValue = new notifyUpdated();
            inValue.accessPoint = accessPoint;
            notifyUpdatedResponse retVal = ((DsrCallbackInterface) (this)).notifyUpdated(inValue);
        }

        //[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        //System.Threading.Tasks.Task<notifyUpdatedResponse> DsrCallbackInterface.notifyUpdatedAsync(notifyUpdated request)
        //{
        //    return base.Channel.notifyUpdatedAsync(request);
        //}

        //public System.Threading.Tasks.Task<notifyUpdatedResponse> notifyUpdatedAsync(AccessPoint accessPoint)
        //{
        //    notifyUpdated inValue = new notifyUpdated();
        //    inValue.accessPoint = accessPoint;
        //    return ((DsrCallbackInterface) (this)).notifyUpdatedAsync(inValue);
        //}
    }
}
