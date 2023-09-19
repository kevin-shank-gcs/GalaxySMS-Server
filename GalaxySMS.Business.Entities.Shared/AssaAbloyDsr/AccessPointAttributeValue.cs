using GCS.Core.Common.Core;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.AssaAbloyDsr
#else
namespace GalaxySMS.Business.Entities.AssaAbloyDsr
#endif
{
    public enum AccessPointAttribute
    {

        /// <remarks/>
        SERIAL_NUMBER,

        /// <remarks/>
        BATTERY_LEVEL,

        /// <remarks/>
        BATTERY_STATUS,

        /// <remarks/>
        FIRMWARE_VERSION,

        /// <remarks/>
        FIRMWARE_TAMPERED,

        /// <remarks/>
        TAMPERED,

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
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class AccessPointAttributeValue : EntityBase
    {

        private AccessPointAttribute nameField;

        private string valueField;



#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPointAttribute name
        {
            get;
            set;
        }



#if NetCoreApi
#else
        [DataMember]
#endif
        public string Value
        {
            get;
            set;
        }
    }

}
