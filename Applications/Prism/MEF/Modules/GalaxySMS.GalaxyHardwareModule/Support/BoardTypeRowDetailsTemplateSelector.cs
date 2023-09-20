using GalaxySMS.Client.Entities;
using System.Windows;
using System.Windows.Controls;

namespace GalaxySMS.GalaxyHardware
{
    public class BoardTypeRowDetailsTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item is GalaxyInterfaceBoard)
            {
                var board = item as GalaxyInterfaceBoard;
                if (board.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface600)
                    return DualReaderInterface600Template;

                if (board.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualReaderInterface635)
                    return DualReaderInterface635Template;

                if (board.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DigitalInputOutput600)
                    return DigitalInputOutput600Template;

                //if (board.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface600)
                //    return DualSerialInterface600Template;

                if (board.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_DualSerialInterface635)
                    return DualSerialInterface635Template;

                //if (board.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_CardTourManager)
                //    return CardTourManagerTemplate;

                if (board.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_OtisElevatorInterface)
                    return OtisElevatorManagerTemplate;

                if (board.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_KoneElevatorInterface)
                    return KoneElevatorManagerTemplate;

                if (board.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_Cpu)
                    return VeridtCpuTemplate;

                if (board.InterfaceBoardTypeUid == GalaxySMS.Common.Constants.GalaxyInterfaceBoardTypeIds.GalaxyInterfaceBoardType_Veridt_ReaderModule)
                    return VeridtReaderTemplate;
            }
            return null;
        }

        public DataTemplate DualReaderInterface600Template { get; set; }
        public DataTemplate DigitalInputOutput600Template { get; set; }
        public DataTemplate DualSerialInterface600Template { get; set; }
        public DataTemplate DualReaderInterface635Template { get; set; }
        public DataTemplate DualSerialInterface635Template { get; set; }
        //public DataTemplate CardTourManagerTemplate { get; set; }
        public DataTemplate OtisElevatorManagerTemplate { get; set; }
        public DataTemplate KoneElevatorManagerTemplate { get; set; }
        public DataTemplate VeridtCpuTemplate { get; set; }
        public DataTemplate VeridtReaderTemplate { get; set; }
    }
}
