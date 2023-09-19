////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\FromPanel\GalaxyCpuInformation.cs
//
// summary:	Implements the galaxy CPU information class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about the galaxy cpu. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class GalaxyCpuInformation : PanelMessageBase
    {
        /// <summary>   The panel inquery reply. </summary>
        private PanelInqueryReply _panelInqueryReply;
        /// <summary>   The card count reply. </summary>
        private CredentialCountReply _cardCountReply;
        /// <summary>   The logging status reply. </summary>
        private LoggingStatusReply _loggingStatusReply;
        /// <summary>   Unique identifier for the instance. </summary>
        private string _instanceGuid;
        /// <summary>   The boards. </summary>
        private PanelBoardInformationCollection _boards;
        private FlashProgressMessage _flashProgressMessage;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuInformation()
        {
            InqueryReply = new PanelInqueryReply();
            CardCountReply = new CredentialCountReply();
            LoggingStatusReply = new LoggingStatusReply();
            Boards = new PanelBoardInformationCollection();
            InstanceGuid = string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="b">    The PanelMessageBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuInformation(PanelMessageBase b)
            : base(b)
        {
            InqueryReply = new PanelInqueryReply();
            CardCountReply = new CredentialCountReply();
            LoggingStatusReply = new LoggingStatusReply();
            Boards = new PanelBoardInformationCollection();
            InstanceGuid = string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxyCpuInfo">    Information describing the galaxy CPU. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuInformation(GalaxyCpuInformation galaxyCpuInfo)
            : base(galaxyCpuInfo)
        {
            if (galaxyCpuInfo != null)
            {
                InqueryReply = new PanelInqueryReply(galaxyCpuInfo.InqueryReply);
                CardCountReply = new CredentialCountReply(galaxyCpuInfo.CardCountReply);
                LoggingStatusReply = new LoggingStatusReply(galaxyCpuInfo.LoggingStatusReply);
                Boards = new PanelBoardInformationCollection(galaxyCpuInfo.Boards);
                InstanceGuid = galaxyCpuInfo.InstanceGuid;
            }
            else
            {
                InqueryReply = new PanelInqueryReply();
                CardCountReply = new CredentialCountReply();
                LoggingStatusReply = new LoggingStatusReply();
                Boards = new PanelBoardInformationCollection();
                InstanceGuid = string.Empty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the instance. </summary>
        ///
        /// <value> Unique identifier of the instance. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String InstanceGuid
        {
            get { return _instanceGuid; }
            set
            {
                if (_instanceGuid != value)
                {
                    _instanceGuid = value;
                    OnPropertyChanged(() => InstanceGuid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the inquery reply. </summary>
        ///
        /// <value> The inquery reply. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PanelInqueryReply InqueryReply
        {
            get { return _panelInqueryReply; }
            set
            {
                if (_panelInqueryReply != value)
                {
                    _panelInqueryReply = value;
                    OnPropertyChanged(() => InqueryReply);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the card count reply. </summary>
        ///
        /// <value> The card count reply. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public CredentialCountReply CardCountReply
        {
            get { return _cardCountReply; }
            set
            {
                if (_cardCountReply != value)
                {
                    _cardCountReply = value;
                    OnPropertyChanged(() => CardCountReply);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the logging status reply. </summary>
        ///
        /// <value> The logging status reply. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public LoggingStatusReply LoggingStatusReply
        {
            get { return _loggingStatusReply; }
            set
            {
                if (_loggingStatusReply != value)
                {
                    _loggingStatusReply = value;
                    OnPropertyChanged(() => LoggingStatusReply);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the boards. </summary>
        ///
        /// <value> The boards. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PanelBoardInformationCollection Boards
        {
            get { return _boards; }
            set
            {
                if (_boards != value)
                {
                    _boards = value;
                    OnPropertyChanged(() => Boards, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the flash progress. </summary>
        /// <remarks>   This property is provided for client application to store the latest FlashProgressMessage which is provided by the SignalRClient.</remarks>
        /// <value> A message describing the flash progress. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FlashProgressMessage FlashProgressMessage
        {
            get { return _flashProgressMessage; }
            set
            {
                if (_flashProgressMessage != value)
                {
                    _flashProgressMessage = value;
                    OnPropertyChanged(() => FlashProgressMessage, false);
                }
            }
        }

    }
}
