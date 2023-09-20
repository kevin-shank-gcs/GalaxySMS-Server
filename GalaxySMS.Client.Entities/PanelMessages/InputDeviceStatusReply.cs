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
    public class InputDeviceStatusReply : PanelMessageBase
    {
        /// <summary>   The access portal UID. </summary>
        private Guid _inputDeviceUid;

        private InputDeviceContactStatus _contactStatus;
        private InputDeviceIoGroupArmedStatus _armedStatus;
        private InputDeviceMonitoringStatus _monitoringStatus;
        private CircuitBoardStatus _boardStatus;
        private bool _IoGroupIsLocal;
        private InputDeviceIoGroupArmedManuallyStatus _armedManuallyStatus;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceStatusReply()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="b">    The PanelMessageBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceStatusReply(PanelMessageBase b)
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

        public InputDeviceStatusReply(InputDeviceStatusReply o)
            : base(o)
        {
            if (o != null)
            {
                InputDeviceUid = o.InputDeviceUid;
                ContactStatus = o.ContactStatus;
                ArmedStatus = o.ArmedStatus;
                MonitoringStatus = o.MonitoringStatus;
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the lock status. </summary>
        ///
        /// <value> The lock status. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public InputDeviceContactStatus ContactStatus
        {
            get => _contactStatus;
            set            
            {
                if (_contactStatus != value)
                {
                    _contactStatus = value;
                    OnPropertyChanged(() => ContactStatus, false);
                }
            }

        }

        [DataMember]
        public InputDeviceIoGroupArmedStatus ArmedStatus
        {
            get => _armedStatus;
            set            
            {
                if (_armedStatus != value)
                {
                    _armedStatus = value;
                    OnPropertyChanged(() => ArmedStatus, false);
                }
            }
        }

        
        [DataMember]
        public InputDeviceIoGroupArmedManuallyStatus ArmedManuallyStatus
        {
            get => _armedManuallyStatus;
            set            
            {
                if (_armedManuallyStatus != value)
                {
                    _armedManuallyStatus = value;
                    OnPropertyChanged(() => ArmedManuallyStatus, false);
                }
            }
        }

        [DataMember]
        public InputDeviceMonitoringStatus MonitoringStatus
        {
            get => _monitoringStatus;
            set            
            {
                if (_monitoringStatus != value)
                {
                    _monitoringStatus = value;
                    OnPropertyChanged(() => MonitoringStatus, false);
                }
            }
        }

        [DataMember]
        public CircuitBoardStatus BoardStatus
        {
            get => _boardStatus;
            set            
            {
                if (_boardStatus != value)
                {
                    _boardStatus = value;
                    OnPropertyChanged(() => BoardStatus, false);
                }
            }
        }


        [DataMember]
        public bool IoGroupIsLocal
        {
            get { return _IoGroupIsLocal; }
            set
            {
                if (_IoGroupIsLocal != value)
                {
                    _IoGroupIsLocal = value;
                    OnPropertyChanged(() => IoGroupIsLocal, false);
                }
            }
        }

    }

}
