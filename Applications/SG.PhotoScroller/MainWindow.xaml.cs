using System;
using System.Collections.Generic;
using System.Linq;
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
using SG.PhotoScroller.Support.Telerik;
using SG.PhotoScroller.ViewModels;
using GCS.Core.Common.Core;
using Telerik.Windows.Controls;

namespace SG.PhotoScroller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _cancelClose = true;
        public MainWindow()
        {
            InitializeComponent();
            main.DataContext = ObjectBase.Container.GetExportedValue<MainViewModel>();
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
    }
}
