using System;
using System.Collections.Generic;
using System.IO;
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
using GCS.Framework.Badging.IdProducer.Entities;
using Telerik.Windows.Controls;

namespace GCS.Framework.Badging.IdProducer.UI
{
    /// <summary>
    /// Interaction logic for PrintControl.xaml
    /// </summary>
    public partial class PrintControl : UserControl
    {
        public PrintControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public PreviewData BadgePreviewData { get; set; }
        public IEnumerable<Printer> Printers { get; set; }
        public IEnumerable<PrintDispatcher> Dispatchers { get; set; }

        public Printer SelectedPrinter { get; set; }
        public PrintDispatcher SelectedDispatcher { get; set; }
        public SelectedPrintTargetType TargetType { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (BadgePreviewData != null)
            {
                previewPanel.Visibility = Visibility.Visible;

                var frontPreviewImage = Convert.FromBase64String(BadgePreviewData.FrontPreviewImage);
                var bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(frontPreviewImage);
                bi.EndInit();
                imgPreview.Source = bi;
                imgPreview.Tag = null;

                var backPreviewImage = Convert.FromBase64String(BadgePreviewData.BackPreviewImage);
                var biBack = new BitmapImage();
                biBack.BeginInit();
                biBack.StreamSource = new MemoryStream(backPreviewImage);
                biBack.EndInit();
                imgPreviewBack.Source = biBack;
                imgPreviewBack.Tag = null;
            }
            else
            {
                previewPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void btn_SendToPrinter_Click(object sender, RoutedEventArgs e)
        {
            TargetType = SelectedPrintTargetType.DirectPrint;
            RadWindow window = this.ParentOfType<RadWindow>();
            window.DialogResult = true;
            window.Close();
        }

        private void btn_SendToDispatcher_Click(object sender, RoutedEventArgs e)
        {
            TargetType = SelectedPrintTargetType.Dispatcher;
            RadWindow window = this.ParentOfType<RadWindow>();
            window.DialogResult = true;
            window.Close();
        }
    }
}
