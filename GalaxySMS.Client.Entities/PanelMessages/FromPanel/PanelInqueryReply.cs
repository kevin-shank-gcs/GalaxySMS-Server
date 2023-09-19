////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\FromPanel\PanelInqueryReply.cs
//
// summary:	Implements the panel inquery reply class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A panel inquery reply. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public class PanelInqueryReply : PanelMessageBase
	{
        /// <summary>   The serial number. </summary>
	    private string _serialNumber;
        /// <summary>   The model number. </summary>
	    private CpuModel _modelNumber;
        /// <summary>   The version. </summary>
	    private FirmwareVersion _version;
        /// <summary>   The last restart cold or warm. </summary>
	    private CpuResetType _lastRestartColdOrWarm;
        /// <summary>   The crisis mode active. </summary>
	    private CrisisModeState _crisisModeActive;
        /// <summary>   Number of unacknowledged activity logs. </summary>
	    private uint _unacknowledgedActivityLogCount;
        /// <summary>   The activity logging enabled. </summary>
	    private ActivityLoggingEnabledState _activityLoggingEnabled;
        /// <summary>   The card code format. </summary>
	    private Common.Enums.CredentialDataSize _cardCodeFormat;
        /// <summary>   The option switches. </summary>
	    private byte _optionSwitches;
        /// <summary>   The link connected. </summary>
	    private byte _zLinkConnected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public PanelInqueryReply()
		{
			Version = new FirmwareVersion();
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="b">    The PanelMessageBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelInqueryReply(PanelMessageBase b) : base(b)
        {
            Version = new FirmwareVersion();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The PanelInqueryReply to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public PanelInqueryReply(PanelInqueryReply p) : base (p)
		{
			Version = new FirmwareVersion();
			if (p != null)
			{
				SerialNumber = p.SerialNumber;
				ModelNumber = p.ModelNumber;
				Version.Major = p.Version.Major;
				Version.Minor = p.Version.Minor;
                Version.LetterCode = p.Version.LetterCode;
				LastRestartColdOrWarm = p.LastRestartColdOrWarm;
				CrisisModeActive = p.CrisisModeActive;
				UnacknowledgedActivityLogCount = p.UnacknowledgedActivityLogCount;
				ActivityLoggingEnabled = p.ActivityLoggingEnabled;
				CardCodeFormat = p.CardCodeFormat;
				OptionSwitches = p.OptionSwitches;
				ZLinkConnected = p.ZLinkConnected;
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the serial number. </summary>
        ///
        /// <value> The serial number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public string SerialNumber
	    {
	        get { return _serialNumber; }
            set
            {
                if (_serialNumber != value)
                {
                    _serialNumber = value;
                    OnPropertyChanged(() => SerialNumber);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the model number. </summary>
        ///
        /// <value> The model number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public CpuModel ModelNumber
	    {
	        get { return _modelNumber; }
            set
            {
                if (_modelNumber != value)
                {
                    _modelNumber = value;
                    OnPropertyChanged(() => ModelNumber);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the version. </summary>
        ///
        /// <value> The version. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public FirmwareVersion Version
	    {
	        get { return _version; }
            set
            {
                if (_version != value)
                {
                    _version = value;
                    OnPropertyChanged(() => Version);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the last restart cold or warm. </summary>
        ///
        /// <value> The last restart cold or warm. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public CpuResetType LastRestartColdOrWarm
	    {
	        get { return _lastRestartColdOrWarm; }
            set
            {
                if (_lastRestartColdOrWarm != value)
                {
                    _lastRestartColdOrWarm = value;
                    OnPropertyChanged(() => LastRestartColdOrWarm);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the crisis mode active. </summary>
        ///
        /// <value> The crisis mode active. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public CrisisModeState CrisisModeActive
	    {
	        get { return _crisisModeActive; }
            set
            {
                if (_crisisModeActive != value)
                {
                    _crisisModeActive = value;
                    OnPropertyChanged(() => CrisisModeActive);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of unacknowledged activity logs. </summary>
        ///
        /// <value> The number of unacknowledged activity logs. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt32 UnacknowledgedActivityLogCount
	    {
	        get { return _unacknowledgedActivityLogCount; }
            set
            {
                if (_unacknowledgedActivityLogCount != value)
                {
                    _unacknowledgedActivityLogCount = value;
                    OnPropertyChanged(() => UnacknowledgedActivityLogCount);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the activity logging enabled. </summary>
        ///
        /// <value> The activity logging enabled. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public ActivityLoggingEnabledState ActivityLoggingEnabled
	    {
	        get { return _activityLoggingEnabled; }
            set
            {
                if (_activityLoggingEnabled != value)
                {
                    _activityLoggingEnabled = value;
                    OnPropertyChanged(() => ActivityLoggingEnabled);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the card code format. </summary>
        ///
        /// <value> The card code format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public CredentialDataSize CardCodeFormat
	    {
	        get { return _cardCodeFormat; }
            set
            {
                if (_cardCodeFormat != value)
                {
                    _cardCodeFormat = value;
                    OnPropertyChanged(() => CardCodeFormat);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the option switches. </summary>
        ///
        /// <value> The option switches. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Byte OptionSwitches
	    {
	        get { return _optionSwitches; }
            set
            {
                if (_optionSwitches != value)
                {
                    _optionSwitches = value;
                    OnPropertyChanged(() => OptionSwitches);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the link connected. </summary>
        ///
        /// <value> The z coordinate link connected. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Byte ZLinkConnected
	    {
	        get { return _zLinkConnected; }
            set
            {
                if (_zLinkConnected != value)
                {
                    _zLinkConnected = value;
                    OnPropertyChanged(() => ZLinkConnected);
                }
            }
	    }
	}
}
