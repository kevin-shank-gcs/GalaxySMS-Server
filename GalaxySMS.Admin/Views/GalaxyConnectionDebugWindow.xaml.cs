using System.Windows;
using GalaxySMS.Admin.ViewModels;
using GCS.Core.Common.Core;
using PDSA.MessageBroker;

namespace GalaxySMS.Admin.Views
{
    /// <summary>
    /// Interaction logic for GalaxyConnectionDebugWindow.xaml
    /// </summary>
    public partial class GalaxyConnectionDebugWindow : Window
    {
        private PDSAMessageBroker _MessageBroker = null;
        public IGalaxyConnectionDebugViewModel ViewModel 
        { 
            get
            {
                return main.DataContext as IGalaxyConnectionDebugViewModel;
            }
        }
        public GalaxyConnectionDebugWindow()
        {
            InitializeComponent();
//            main.DataContext = ObjectBase.Container.GetExportedValue<IGalaxyConnectionDebugViewModel>();
            main.DataContext = StaticObjects.Container.GetExportedValue<IGalaxyConnectionDebugViewModel>();
            DataContext = main.DataContext;
            _MessageBroker = Globals.Instance.MessageBrokerPanelCommunication;
            _MessageBroker.MessageReceived += _MessageBroker_MessageReceived;
        }

        void _MessageBroker_MessageReceived(object sender, PDSAMessageBrokerEventArgs e)
        {
            switch (e.MessageName)
            {
                case MessageNames.CloseAllDebugWindows:
                    this.Close();
                    break;
            }
        }


    }
}
