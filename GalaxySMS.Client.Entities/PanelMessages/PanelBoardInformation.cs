////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\PanelBoardInformation.cs
//
// summary:	Implements the panel board information class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Information about the panel board. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class PanelBoardInformation : ObjectBase
    {
        /// <summary>   The board number. </summary>
        private short _boardNumber;
        /// <summary>   The status. </summary>
        private PanelBoardStatus _status;
        /// <summary>   The flash result. </summary>
        private PanelBoardFlashResult _flashResult;
        /// <summary>   The flash package. </summary>
        private GalaxyInterfaceBoardType _flashPackage;
        /// <summary>   The version. </summary>
        private FirmwareVersion _version;
        /// <summary>   The selected CPU number. </summary>
        private short _selectedCpuNumber;
        /// <summary>   The heartbeat age. </summary>
        private short _HeartbeatAge;
        /// <summary>   The boot version. </summary>
        private FirmwareVersion _bootVersion;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelBoardInformation()
        {
            Version = new FirmwareVersion();
            BootVersion = new FirmwareVersion();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The PanelBoardInformation to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelBoardInformation(PanelBoardInformation p)
        {
            Version = new FirmwareVersion();
            BootVersion = new FirmwareVersion();
            if (p != null)
            {
                BoardNumber = p.BoardNumber;
                Version.Major = p.Version.Major;
                Version.Minor = p.Version.Minor;
                Version.LetterCode = p.Version.LetterCode;

                BootVersion.Major = p.BootVersion.Major;
                BootVersion.Minor = p.BootVersion.Minor;
                BootVersion.LetterCode = p.BootVersion.LetterCode;

                Status = p.Status;
                FlashResult = p.FlashResult;
                FlashPackage = p.FlashPackage;
                SelectedCpuNumber = p.SelectedCpuNumber;
                HeartbeatAge = p.HeartbeatAge;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the board number. </summary>
        ///
        /// <value> The board number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short BoardNumber
        {
            get { return _boardNumber; }
            set
            {
                if (_boardNumber != value)
                {
                    _boardNumber = value;
                    OnPropertyChanged(() => BoardNumber, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the status. </summary>
        ///
        /// <value> The status. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PanelBoardStatus Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(() => Status, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the flash result. </summary>
        ///
        /// <value> The flash result. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PanelBoardFlashResult FlashResult
        {
            get { return _flashResult; }
            set
            {
                if (_flashResult != value)
                {
                    _flashResult = value;
                    OnPropertyChanged(() => FlashResult, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the flash package. </summary>
        ///
        /// <value> The flash package. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public GalaxyInterfaceBoardType FlashPackage
        {
            get { return _flashPackage; }
            set
            {
                if (_flashPackage != value)
                {
                    _flashPackage = value;
                    OnPropertyChanged(() => FlashPackage, true);
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
                    OnPropertyChanged(() => Version, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the selected CPU number. </summary>
        ///
        /// <value> The selected CPU number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short SelectedCpuNumber
        {
            get { return _selectedCpuNumber; }
            set
            {
                if (_selectedCpuNumber != value)
                {
                    _selectedCpuNumber = value;
                    OnPropertyChanged(() => SelectedCpuNumber, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the heartbeat age. </summary>
        ///
        /// <value> The heartbeat age. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short HeartbeatAge
        {
            get { return _HeartbeatAge; }
            set
            {
                if (_HeartbeatAge != value)
                {
                    _HeartbeatAge = value;
                    OnPropertyChanged(() => HeartbeatAge, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the boot version. </summary>
        ///
        /// <value> The boot version. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public FirmwareVersion BootVersion
        {
            get { return _bootVersion; }
            set
            {
                if (_bootVersion != value)
                {
                    _bootVersion = value;
                    OnPropertyChanged(() => BootVersion, true);
                }
            }
        }


    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Collection of panel board informations. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class PanelBoardInformationCollection : PanelMessageBase
    {
        /// <summary>   The boards. </summary>
        private List<PanelBoardInformation> _boards;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelBoardInformationCollection()
        {
            Boards = new List<PanelBoardInformation>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The PanelBoardInformationCollection to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelBoardInformationCollection(PanelBoardInformationCollection o) : base(o)
        {
            Boards = new List<PanelBoardInformation>();
            if (o != null)
                Boards = o.Boards.ToList();
        }

        [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the boards. </summary>
        ///
        /// <value> The boards. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<PanelBoardInformation> Boards
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

    }
}
