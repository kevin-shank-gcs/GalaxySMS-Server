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
using GalaxySMS.Client.Entities;
using GalaxySMS.PersonCredential.Support;
using Telerik.Windows.Controls;

namespace GalaxySMS.PersonCredential.UserControls
{
    public partial class ucidProducerPrintControl : UserControl
    {
        public ucidProducerPrintControl()
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

                if (!string.IsNullOrEmpty(BadgePreviewData.FrontPreviewImage))
                {
                    var frontPreviewImage = Convert.FromBase64String(BadgePreviewData.FrontPreviewImage);
                    var bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(frontPreviewImage);
                    bi.EndInit();
                    imgPreview.Source = bi;
                    imgPreview.Tag = null;
                }

                if (!string.IsNullOrEmpty(BadgePreviewData.BackPreviewImage))
                {
                    var backPreviewImage = Convert.FromBase64String(BadgePreviewData.BackPreviewImage);
                    var biBack = new BitmapImage();
                    biBack.BeginInit();
                    biBack.StreamSource = new MemoryStream(backPreviewImage);
                    biBack.EndInit();
                    imgPreviewBack.Source = biBack;
                    imgPreviewBack.Tag = null;
                }
            }
            else
            {
                previewPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void btn_SendToPrinter_Click(object sender, RoutedEventArgs e)
        {
            TargetType = SelectedPrintTargetType.DirectPrint;
            var window = this.ParentOfType<RadWindow>();
            window.DialogResult = true;
            window.Close();
        }

        private void btn_SendToDispatcher_Click(object sender, RoutedEventArgs e)
        {
            TargetType = SelectedPrintTargetType.Dispatcher;
            var window = this.ParentOfType<RadWindow>();
            window.DialogResult = true;
            window.Close();
        }
    }
}
