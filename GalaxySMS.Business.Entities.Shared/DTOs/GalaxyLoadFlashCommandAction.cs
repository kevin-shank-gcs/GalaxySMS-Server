////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\GalaxyCpuCommandAction.cs
//
// summary:	Implements the galaxy CPU command action class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using System;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU command action. </summary>
    ///
    /// <remarks>   Kevin, 10/5/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif

    public partial class GalaxyLoadFlashCommandAction : GalaxyCpuCommandBase
    {
        private int _packetsPerLoadMessage;
        private int _sendPacketIntervalMilliseconds;

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
            this.GalaxyFlashImageUid = o.GalaxyFlashImageUid;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this GalaxyCpuCommandAction. </summary>
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyLoadFlashCommandActionCode CommandAction { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy flash image UID. </summary>
        ///
        /// <value> The galaxy flash image UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GalaxyFlashImageUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the packets per load message </summary>
        ///
        /// <value> A message describing the packets per load. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public int PacketsPerLoadMessage
        {
            get { return _packetsPerLoadMessage; }
            set
            {
                if (value < 1)
                    _packetsPerLoadMessage = 1;
                else if (value > 7)
                    _packetsPerLoadMessage = 7;
                else _packetsPerLoadMessage = value;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the send packet interval milliseconds. </summary>
        ///
        /// <value> The send packet interval milliseconds. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public int SendPacketIntervalMilliseconds
        {
            get => _sendPacketIntervalMilliseconds;
            set
            {
                if (value < GalaxyFlashLoadLimits.MinimumFlashPacketInterval)
                    _sendPacketIntervalMilliseconds = GalaxyFlashLoadLimits.DefaultFlashPacketInterval;
                else if (value > GalaxyFlashLoadLimits.MaximumFlashPacketInterval)
                    _sendPacketIntervalMilliseconds = GalaxyFlashLoadLimits.MaximumFlashPacketInterval;
                else _sendPacketIntervalMilliseconds = value;
            }
        }
    }
}
