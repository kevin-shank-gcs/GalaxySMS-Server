using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{

    public class PanelBoardInformationResp
    {
        public PanelBoardInformationResp()
        {
            Version = new FirmwareVersionResp();
            BootVersion = new FirmwareVersionResp();
        }

        public PanelBoardInformationResp(PanelBoardInformationResp p)
        {
            Version = new FirmwareVersionResp();
            BootVersion = new FirmwareVersionResp();
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
        public short BoardNumber { get; set; }
        public PanelBoardStatus Status { get; set; }
        public string StatusFriendly => Status.ToString();
        public PanelBoardFlashResult FlashResult { get; set; }
        public string FlashResultFriendly => FlashResult.ToString();
        public GalaxyInterfaceBoardType FlashPackage { get; set; }
        public string FlashPackageFriendly => FlashPackage.ToString();
        public FirmwareVersionResp Version { get; set; }
        public short SelectedCpuNumber { get; set; }
        public short HeartbeatAge { get; set; }
        public FirmwareVersionResp BootVersion { get; set; }

    }

    public class PanelBoardInformationCollectionResp : PanelMessageBaseResp
    {
        public PanelBoardInformationCollectionResp()
        {
            Boards = new List<PanelBoardInformationResp>();
        }

        public PanelBoardInformationCollectionResp(PanelMessageBaseResp b) : base(b)
        {
            Boards = new List<PanelBoardInformationResp>();
        }
        public PanelBoardInformationCollectionResp(PanelBoardInformationCollectionResp o) : base(o)
        {
            Boards = new List<PanelBoardInformationResp>();
            if (o != null)
                Boards = o.Boards.ToList();
        }
        public List<PanelBoardInformationResp> Boards { get; set; }
    }

    public class PanelBoardInformationCollectionBasicResp
    {
        public PanelBoardInformationCollectionBasicResp()
        {
            Boards = new List<PanelBoardInformationResp>();
        }

        public PanelBoardInformationCollectionBasicResp(PanelBoardInformationCollectionResp o) 
        {
            Boards = new List<PanelBoardInformationResp>();
            if (o != null)
                Boards = o.Boards.ToList();
        }

        public PanelBoardInformationCollectionBasicResp(PanelBoardInformationCollectionBasicResp o) 
        {
            Boards = new List<PanelBoardInformationResp>();
            if (o != null)
                Boards = o.Boards.ToList();
        }

        public List<PanelBoardInformationResp> Boards { get; set; }
    }


}
