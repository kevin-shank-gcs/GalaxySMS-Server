using System.ComponentModel;
using System.Globalization;
using System.Windows;
using GalaxySMS.SiteManager.Support;
using GalaxySMS.SiteManager.ViewModels;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Extensions;
using Telerik.Windows.Controls;

namespace GalaxySMS.SiteManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _cancelClose = true;
        public MainWindow()
        {
            this.SetFlowDirection();
            InitializeComponent();
            //this.DataContext = Globals.Instance;
//            main.DataContext = ObjectBase.Container.GetExportedValue<MainViewModel>();
            main.DataContext = StaticObjects.Container.GetExportedValue<MainViewModel>();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            _cancelClose = true;
            TelerikHelpers.PromptForExit(OnConfirmClosed);
            e.Cancel = _cancelClose;
        }

        private void OnConfirmClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                _cancelClose = false;
            }
        }
    }
}
