using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.ConfigManager.Views
{
    /// <summary>
    /// Interaction logic for MessageBoxView.xaml
    /// </summary>
    public partial class MessageBoxView : UserControlViewBase
    {
        public enum IconType    
        {
            Warning,
            Stop,
            Question,
            Info,
            Success
        }

        public MessageBoxView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Message { get; set; }
        public IconType Icon { get; set; }
    }
}
