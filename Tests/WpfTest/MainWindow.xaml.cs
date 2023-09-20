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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using GCS.Framework.Flash;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ThemeSwitcher.SwitchTheme(null);
        }

        private void btnShowCardExchangePrintWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var printWindow = new GCS.Framework.Badging.CardExchange.UI.PrintWindow();
                printWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnLoadS28File_Click(object sender, RoutedEventArgs e)
        {
            String filename = "E:\\Dev\\Installs\\SG_V11_1_0\\Components\\Program Files\\Flash\\600\\CPU_635_11-0-2_release.s28";
            var flashHelper = new GalaxyFlashImageHelper();
            flashHelper.ReadFlashS28File(filename);

        }
    }
}
