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
    public class InitializeBoardSectionSettings : EntityBase
	{
        public InitializeBoardSectionSettings()
        {
            Address = new BoardSectionHardwareAddress();
        }
		[DataMember]
		public BoardSectionHardwareAddress Address { get; set; }

		[DataMember]
		public PanelInterfaceBoardSectionType SectionType { get; set; }

        [DataMember]
        public GalaxySMS.Common.Enums.CredentialReaderDataFormat ReaderDataFormat { get; set; }

        [DataMember]
		public UInt16 RelayCount { get; set; }

        public byte TypeCode
        {
            get
            {
                switch (SectionType)
                {
                    case PanelInterfaceBoardSectionType.DrmSection:
                    case PanelInterfaceBoardSectionType.DsiRs485DoorModule:
                        return (byte)((byte)SectionType | (byte)ReaderDataFormat);

                    case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                    case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                    case PanelInterfaceBoardSectionType.DsiElevatorControlRelays:
                    case PanelInterfaceBoardSectionType.DsiCypressClockDisplay:
                    case PanelInterfaceBoardSectionType.DsiOutputControlRelays:
                    case PanelInterfaceBoardSectionType.DsiIngersolRandPimWiegand:
                    case PanelInterfaceBoardSectionType.DsiIngersolRandPimClockData:
                    case PanelInterfaceBoardSectionType.DsiLcd4x20Display:
                    case PanelInterfaceBoardSectionType.DsiAssaAbloyAperio:
                    case PanelInterfaceBoardSectionType.DsiSalto:
                    case PanelInterfaceBoardSectionType.DsiRs485InputModule:
                    case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                    case PanelInterfaceBoardSectionType.CardTourManagerCpu:
                    case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                    default:
                        return (byte)SectionType;

                }
            }
        }
    }
}
