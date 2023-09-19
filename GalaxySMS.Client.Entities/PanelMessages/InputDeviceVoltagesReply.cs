////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\AccessPortalStatusReply.cs
//
// summary:	Implements the access portal status reply class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal status reply. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class InputDeviceVoltagesReply : PanelMessageBase
    {
        /// <summary>   The access portal UID. </summary>
        private Guid _inputDeviceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceVoltagesReply()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="b">    The PanelMessageBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceVoltagesReply(PanelMessageBase b)
            : base(b)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="o">    The AccessPortalStatusReply to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceVoltagesReply(InputDeviceVoltagesReply o)
            : base(o)
        {
            if (o != null)
            {
                InputDeviceUid = o.InputDeviceUid;
                NormalVoltage = o.NormalVoltage;
                AlternateVoltage = o.AlternateVoltage;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal UID. </summary>
        ///
        /// <value> The access portal UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid InputDeviceUid
        {
            get { return _inputDeviceUid; }
            set
            {
                if (_inputDeviceUid != value)
                {
                    _inputDeviceUid = value;
                    OnPropertyChanged(() => InputDeviceUid, false);
                }
            }
        }


        private ushort _normalVoltage;

        [DataMember]
        public ushort NormalVoltage
        {
            get { return _normalVoltage; }
            set
            {
                if (_normalVoltage != value)
                {
                    _normalVoltage = value;
                    OnPropertyChanged(() => NormalVoltage, true);
                }
            }
        }

        private ushort _alternateVoltage;

        [DataMember]
        public ushort AlternateVoltage
        {
            get { return _alternateVoltage; }
            set
            {
                if (_alternateVoltage != value)
                {
                    _alternateVoltage = value;
                    OnPropertyChanged(() => AlternateVoltage, true);
                }
            }
        }

    }

}
