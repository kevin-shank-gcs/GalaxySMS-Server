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
using GalaxySMS.Client.Entities;
using Telerik.Windows.Controls;

namespace GalaxySMS.PersonCredential.UserControls
{
    public enum SelectedPrintTargetType { DirectPrint, Dispatcher }
    /// <summary>
    /// Interaction logic for idProducerPrintWindow.xaml
    /// </summary>
    public partial class idProducerPrintWindow : RadWindow
    {
        public idProducerPrintWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                this.IsTopmost = true;
            };
        }
        public PreviewData BadgePreviewData
        {
            get { return printControl.BadgePreviewData; }
            set
            {
                printControl.BadgePreviewData = value;

            }
        }

        public IEnumerable<Printer> Printers
        {
            get { return printControl.Printers; }
            set
            {
                printControl.Printers = value;

            }
        }

        public IEnumerable<PrintDispatcher> Dispatchers
        {
            get { return printControl.Dispatchers; }
            set
            {
                printControl.Dispatchers = value;

            }
        }


        public Printer SelectedPrinter
        {
            get { return printControl.SelectedPrinter; }
            set
            {
                printControl.SelectedPrinter = value;

            }
        }

        public PrintDispatcher SelectedDispatcher
        {
            get { return printControl.SelectedDispatcher; }
            set
            {
                printControl.SelectedDispatcher = value;

            }
        }

        public SelectedPrintTargetType TargetType
        {
            get { return printControl.TargetType; }
            set
            {
                printControl.TargetType = value;

            }
        }
    }
}
