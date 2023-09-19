using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Framework.Security;

namespace GalaxySMS.Business.Entities.AssaAbloyDsr
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

    public partial class AccessPointAttributeValue : EntityBase
    {

        private AccessPointAttribute nameField;

        private string valueField;

        
        public AccessPointAttribute name
        {
            get;
            set;
        }

        
        public string Value
        {
            get;
            set;
        }
    }

}
