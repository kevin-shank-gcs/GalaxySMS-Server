////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\ClusterCommandAction.cs
//
// summary:	Implements the galaxy CPU command action class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU command action. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class GalaxyLoadFlashCommandAction : GalaxyCpuCommandBase
    {

        /// <summary>   The command action. </summary>
        private GalaxyLoadFlashCommandActionCode _commandAction;
        private Guid _galaxyFlashImageUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyLoadFlashCommandAction()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ///
        /// <param name="o">    The GalaxyCpuCommandAction to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyLoadFlashCommandAction(GalaxyLoadFlashCommandAction o)
        {
            Init();

            if (o == null)
                return;

            this.CommandAction = o.CommandAction;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyCpuCommandAction. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command action. </summary>
        ///
        /// <value> The command action. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public GalaxyLoadFlashCommandActionCode CommandAction
        {
            get { return _commandAction; }
            set
            {
                if (_commandAction != value)
                {
                    _commandAction = value;
                    OnPropertyChanged(() => CommandAction, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy flash image UID. </summary>
        ///
        /// <value> The galaxy flash image UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid GalaxyFlashImageUid
        {
            get { return _galaxyFlashImageUid; }
            set
            {
                if (_galaxyFlashImageUid != value)
                {
                    _galaxyFlashImageUid = value;
                    OnPropertyChanged(() => GalaxyFlashImageUid, true);
                }
            }
        }

        private int _PacketsPerLoadMessage;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the packets per load. </summary>
        ///
        /// <value> A message describing the packets per load. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int PacketsPerLoadMessage
        {
            get { return _PacketsPerLoadMessage; }
            set
            {
                if (_PacketsPerLoadMessage != value)
                {
                    if (value < 1)
                        _PacketsPerLoadMessage = 1;
                    else if (value > 7)
                        _PacketsPerLoadMessage = 7;
                    else
                        _PacketsPerLoadMessage = value;
                    OnPropertyChanged(() => PacketsPerLoadMessage, true);
                }
            }
        }
        private int _sendPacketIntervalMilliseconds;



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the send packet interval milliseconds. </summary>
        ///
        /// <value> The send packet interval milliseconds. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember]

        public int SendPacketIntervalMilliseconds
        {
            get { return _sendPacketIntervalMilliseconds; }
            set
            {
                if (_sendPacketIntervalMilliseconds != value)
                {
                    _sendPacketIntervalMilliseconds = value;
                    OnPropertyChanged(() => SendPacketIntervalMilliseconds, true);
                }
            }
        }

    }
}
