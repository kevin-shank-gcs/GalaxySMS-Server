////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AssaAbloyDsr\AccessPointAttributeValue.cs
//
// summary:	Implements the access point attribute value class
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
    /// <summary>   Values that represent access point attributes. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access point attribute value. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class AccessPointAttributeValue : DtoObjectBase
    {

        /// <summary>   The name field. </summary>
        private AccessPointAttribute nameField;

        /// <summary>   The value field. </summary>
        private string valueField;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AccessPointAttribute name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
                OnPropertyChanged(() => name, true);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value. </summary>
        ///
        /// <value> The value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
                OnPropertyChanged(() => Value, true);
            }
        }
    }

}
