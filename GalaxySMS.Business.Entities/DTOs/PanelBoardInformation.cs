using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class PanelBoardInformation : EntityBase
    {
        public PanelBoardInformation()
        {
            Version = new FirmwareVersion();
            BootVersion = new FirmwareVersion();
        }

        public PanelBoardInformation(PanelBoardInformation p) : base(p)
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

        [DataMember]
        public short BoardNumber { get; set; }

        [DataMember]
        public PanelBoardStatus Status { get; set; }

        [DataMember]
        public PanelBoardFlashResult FlashResult { get; set; }

        [DataMember]
        public GalaxyInterfaceBoardType FlashPackage { get; set; }

        [DataMember]
        public FirmwareVersion Version { get; set; }

        [DataMember]
        public short SelectedCpuNumber { get; set; }

        [DataMember]
        public short HeartbeatAge { get; set; }

        [DataMember]
        public FirmwareVersion BootVersion { get; set; }

    }

    [DataContract]
    public class PanelBoardInformationCollection : PanelMessageBase
    {
        public PanelBoardInformationCollection()
        {
            Boards = new List<PanelBoardInformation>();
        }

        public PanelBoardInformationCollection(PanelMessageBase b) : base(b)
        {
            Boards = new List<PanelBoardInformation>();
        }
        public PanelBoardInformationCollection(PanelBoardInformationCollection o) : base(o)
        {
            Boards = new List<PanelBoardInformation>();
            if (o != null)
                Boards = o.Boards.ToList();
        }

        [DataMember]
        public List<PanelBoardInformation> Boards { get; set; }
    }
}
