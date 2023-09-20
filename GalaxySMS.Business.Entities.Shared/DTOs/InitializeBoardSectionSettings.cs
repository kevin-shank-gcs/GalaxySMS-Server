using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
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
#if NetCoreApi
#else
    [DataContract]
#endif

    public class InitializeBoardSectionSettings : EntityBase
    {
        public InitializeBoardSectionSettings()
        {
            Address = new BoardSectionHardwareAddress();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public BoardSectionHardwareAddress Address { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelInterfaceBoardSectionType SectionType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxySMS.Common.Enums.CredentialReaderDataFormat ReaderDataFormat { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 RelayCount { get; set; }

        public byte TypeCode
        {
            get
            {
                switch (SectionType)
                {
                    case PanelInterfaceBoardSectionType.DrmSection:
                    case PanelInterfaceBoardSectionType.RS485DoorModule:
                        return (byte)((byte)SectionType | (byte)ReaderDataFormat);

                    case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                    case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                    case PanelInterfaceBoardSectionType.ElevatorRelays:
                    case PanelInterfaceBoardSectionType.CypressClockDisplay:
                    case PanelInterfaceBoardSectionType.OutputRelays:
                    case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                    case PanelInterfaceBoardSectionType.AllegionPimAba:
                    case PanelInterfaceBoardSectionType.LCD_4x20Display:
                    case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                    case PanelInterfaceBoardSectionType.SaltoSallis:
                    case PanelInterfaceBoardSectionType.RS485InputModule:
                    case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                    //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
                    case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                    case PanelInterfaceBoardSectionType.VeridtCpu:
                    case PanelInterfaceBoardSectionType.VeridtReader:
                    default:
                        return (byte)SectionType;

                }
            }
        }

        public Guid OperationUid { get; set; }
    }
}
