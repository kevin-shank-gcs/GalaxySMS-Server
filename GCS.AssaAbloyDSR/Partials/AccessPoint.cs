using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.AssaAbloyDSR.DSRManagementService
{
    public partial class AccessPoint
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string accessPointName
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.DESCRIPTION);
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string firmwareVersion
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.FIRMWARE_VERSION);
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string batteryLevel
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.BATTERY_LEVEL);
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string batteryStatus
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.BATTERY_STATUS);
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string dcVoltage
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.DC_VOLTAGE);
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string doorState
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.DOOR_STATE);
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string firmwareTampered
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.FIRMWARE_TAMPERED);
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string lockState
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.LOCK_STATE);
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string radioFirmwareVersion
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.RADIO_FIRMWARE_VERSION);
            }
        }

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string tampered
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.TAMPERED);
            }
        }


        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string sn
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.SERIAL_NUMBER);
            }
        }


        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string firmwareVersionInProgress
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.FIRMWARE_VERSION_INPROGRESS);
            }
        }


        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string expectedOnlineTime
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.EXPECTED_ONLINE_TIME);
            }
        }


        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string schedulerType
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.SCHEDULER_TYPE);
            }
        }


        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string snInternal
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.SERIAL_NUMBER_INTERNAL);
            }
        }


        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string tlsCaCertificateValidFrom
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.TLS_CA_CERTIFICATE_VALID_FROM);
            }
        }
       

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string tlsCaCertificateValidUntil
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.TLS_CA_CERTIFICATE_VALID_TILL);
            }
        }
        

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string tlsClientCertificateValidFrom
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.TLS_CLIENT_CERTIFICATE_VALID_FROM);
            }
        }
        

        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string tlsClientCertificateValidUntil
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.TLS_CLIENT_CERTIFICATE_VALID_TILL);
            }
        }


        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string firmwareUploadPercentage
        {
            get
            {
                return this.GetAttribute(AccessPointAttribute.FIRMWARE_UPLOAD_PERCENTAGE);
            }
        }


        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.accessPointName) && !string.IsNullOrEmpty(serialNumber))
                return string.Format("{0} SN:{1}", accessPointName, this.serialNumber);
            if (!string.IsNullOrEmpty(this.accessPointName))
                return accessPointName;
            if (!string.IsNullOrEmpty(this.serialNumber))
                return serialNumber;
            return this.id;
            //return base.ToString();
        }
        //public IEnumerable<AccessPointAlarmSetting> AlarmSettings { get; set; }
    }
}
