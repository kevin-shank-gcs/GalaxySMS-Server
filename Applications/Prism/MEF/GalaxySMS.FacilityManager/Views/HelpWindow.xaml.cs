using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace GalaxySMS.FacilityManager.Views
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : RadWindow
    {
        private static HelpWindow instance;

        public HelpWindow()
        {
            InitializeComponent();
        }
        public static HelpWindow Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HelpWindow();
                }
                return instance;
            }
        }
    }
}
