using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.GalaxyHardware
{
    public class BoardSectionModeRowDetailsTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item is GalaxyInterfaceBoardSection)
            {
                var section = item as GalaxyInterfaceBoardSection;
                //if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.CardTourManagerBoardInterfaceSectionModeIds.CTMSectionMode_CTM)
                //    return CardTourManagerTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.VeridtCpuBoardInterfaceSectionModeIds.VeridtCpuBoardInterfaceSectionMode_Cpu)
                    return VeridtCpuTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.VeridtReaderModuleBoardInterfaceSectionModeIds.VeridtReaderModuleBoardInterfaceSectionMode_Reader)
                    return VeridtReaderTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.KoneElevatorManagerBoardInterfaceSectionModeIds.KoneElevatorManagerSectionMode_KEI)
                    return KoneElevatorManagerTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.OtisElevatorManagerBoardInterfaceSectionModeIds.OtisElevatorManagerSectionMode_OEI)
                    return OtisElevatorManagerTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Inputs)
                    return DigitalInputOutputBoardInputsTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DigitalInputOutputBoardInterfaceSectionModeIds.DIOSectionMode_Outputs)
                    return DigitalInputOutputBoardOutputsTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_Unused ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_Unused)
                    return ReaderInterfaceUnusedTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_AccessPortal ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal )
                    return ReaderInterfaceAccessPortalTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface600ModeIds.ReaderInterfaceMode_CredentialReaderOnly ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_CredentialReaderOnly)
                    return ReaderInterfaceCredentialReaderTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand)
                    return DualSerialInterfaceAllegionPimChannelTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio)
                    return DualSerialInterfaceAssaAbloyAperioChannelTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis)
                    return DualSerialInterfaceSaltoSallisChannelTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_CypressClockDisplay ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_CypressClockDisplay ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_LCD_4x20Display ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_LCD_4x20Display)
                    return DualSerialInterfaceCypressLCDChannelTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_ElevatorRelays ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_ElevatorRelays)
                    return DualSerialInterfaceGalaxyElevatorRelaysChannelTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_OutputRelays ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_OutputRelays)
                    return DualSerialInterfaceGalaxyOutputRelaysChannelTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface600ChannelModeIds.DualSerialChannelMode_VeridtCac ||
                    section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_VeridtCac)
                    return DualSerialInterfaceVeridtCacChannelTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule)
                    return DualSerialInterfaceGalaxyDoorModuleChannelTemplate;

                if (section.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485InputModule)
                    return DualSerialInterfaceGalaxyInputModuleChannelTemplate;
            }
            return null;
        }

        //public DataTemplate CardTourManagerTemplate { get; set; }
        public DataTemplate VeridtCpuTemplate { get; set; }
        public DataTemplate VeridtReaderTemplate { get; set; }
        public DataTemplate OtisElevatorManagerTemplate { get; set; }
        public DataTemplate KoneElevatorManagerTemplate { get; set; }
        public DataTemplate DigitalInputOutputBoardInputsTemplate { get; set; }
        public DataTemplate DigitalInputOutputBoardOutputsTemplate { get; set; }
        public DataTemplate ReaderInterfaceUnusedTemplate { get; set; }
        public DataTemplate ReaderInterfaceAccessPortalTemplate { get; set; }
        public DataTemplate ReaderInterfaceCredentialReaderTemplate { get; set; }
        public DataTemplate DualSerialInterfaceAllegionPimChannelTemplate { get; set; }
        public DataTemplate DualSerialInterfaceAssaAbloyAperioChannelTemplate { get; set; }
        public DataTemplate DualSerialInterfaceSaltoSallisChannelTemplate { get; set; }
        public DataTemplate DualSerialInterfaceCypressLCDChannelTemplate { get; set; }
        public DataTemplate DualSerialInterfaceGalaxyElevatorRelaysChannelTemplate { get; set; }
        public DataTemplate DualSerialInterfaceGalaxyOutputRelaysChannelTemplate { get; set; }
        public DataTemplate DualSerialInterfaceVeridtCacChannelTemplate { get; set; }
        public DataTemplate DualSerialInterfaceShellChannelTemplate { get; set; }
        public DataTemplate DualSerialInterfaceGalaxyDoorModuleChannelTemplate { get; set; }
        public DataTemplate DualSerialInterfaceGalaxyInputModuleChannelTemplate { get; set; }

    }
}
