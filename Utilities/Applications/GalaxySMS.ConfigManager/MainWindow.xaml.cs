using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaxySMS.ConfigManager.Support.Telerik;
using GalaxySMS.ConfigManager.ViewModels;
using GCS.Core.Common.Core;
using Telerik.Windows.Controls;

namespace GalaxySMS.ConfigManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadWindow
    {
        private bool _cancelClose = true;
        public MainWindow()
        {
            InitializeComponent();
            main.DataContext = ObjectBase.Container.GetExportedValue<MainViewModel>();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Image img = new Image();
                //img.Source = Properties.Resources.user_id_save.ToImageSource();
                //this.Icon = img;
                Globals.Instance.MainWindow = this;

            }
            catch (ReflectionTypeLoadException ex)
            {
                foreach (var loaderEx in ex.LoaderExceptions)
                {
                    MessageBox.Show(loaderEx.ToString());
                }
                Application.Current.Shutdown(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Current.Shutdown(0);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
                //Application.Current.Shutdown(0);
            }
        }

        private void RadWindow_PreviewClosed(object sender, WindowPreviewClosedEventArgs e)
        {
            _cancelClose = true;
            TelerikHelpers.PromptForExit(OnConfirmClosed);
            e.Cancel = _cancelClose;

        }
    }
}
