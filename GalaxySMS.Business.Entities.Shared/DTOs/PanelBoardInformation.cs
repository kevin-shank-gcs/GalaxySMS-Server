using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public class PanelBoardInformation// : EntityBase
    {
        public PanelBoardInformation()
        {
            Version = new FirmwareVersion();
            BootVersion = new FirmwareVersion();
        }

        public PanelBoardInformation(PanelBoardInformation p)// : base(p)
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
#if NetCoreApi
#else
        [DataMember]
#endif
        public short BoardNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelBoardStatus Status { get; set; }

        public string FriendlyStatus => Status.ToString();

#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelBoardFlashResult FlashResult { get; set; }
        public string FriendlyFlashResult => FlashResult.ToString();

#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyInterfaceBoardType FlashPackage { get; set; }

        public string FriendlyFlashPackage => FlashPackage.ToString();

#if NetCoreApi
#else
        [DataMember]
#endif
        public FirmwareVersion Version { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short SelectedCpuNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public short HeartbeatAge { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public FirmwareVersion BootVersion { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif

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
#if NetCoreApi
#else
        [DataMember]
#endif
        public List<PanelBoardInformation> Boards { get; set; }
    }



#if NetCoreApi
#else
    [DataContract]
#endif
    public class PanelBoardInformationCollectionBasic
    {
        public PanelBoardInformationCollectionBasic()
        {
            Boards = new List<PanelBoardInformation>();
        }

        public PanelBoardInformationCollectionBasic(PanelBoardInformationCollection o)
        {
            Boards = new List<PanelBoardInformation>();
            if (o != null)
                Boards = o.Boards.ToList();
        }

        public PanelBoardInformationCollectionBasic(PanelBoardInformationCollectionBasic o)
        {
            Boards = new List<PanelBoardInformation>();
            if (o != null)
                Boards = o.Boards.ToList();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public List<PanelBoardInformation> Boards { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif

    public class PanelBoardInformationCollectionSignalR : PanelMessageBaseSimple
    {
        public PanelBoardInformationCollectionSignalR()
        {
            Boards = new List<PanelBoardInformation>();
        }

        public PanelBoardInformationCollectionSignalR(PanelMessageBaseSimple b) : base(b)
        {
            Boards = new List<PanelBoardInformation>();
        }
        public PanelBoardInformationCollectionSignalR(PanelBoardInformationCollectionSignalR o) : base(o)
        {
            Boards = new List<PanelBoardInformation>();
            if (o != null)
                Boards = o.Boards.ToList();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public List<PanelBoardInformation> Boards { get; set; }
    }

}
