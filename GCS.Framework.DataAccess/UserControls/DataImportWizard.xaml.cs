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
using GCS.Core.Common.UI.Controls;
using GCS.Core.Common.UI.Core;
using GCS.Framework.DataAccess.ViewModels;
using Telerik.Windows.Controls;

namespace GCS.Framework.DataAccess.UserControls
{
    /// <summary>
    /// Interaction logic for DataImportWizard.xaml
    /// </summary>
    public partial class DataImportWizard : UserControlViewBase
    {
        private DataImportWizardViewModel _viewModel;

        public DataImportWizard()
        {
            InitializeComponent();
            DataContext = (DataImportWizardViewModel)this.Resources["viewModel"];
            _viewModel = DataContext as DataImportWizardViewModel;
        }

        private void wizard_Completed(object sender, Telerik.Windows.Controls.Wizard.WizardCompletedEventArgs e)
        {
        }

        public DataImportWizardViewModel ViewModel { get { return _viewModel; } }    

        private void wizard_Help(object sender, NavigationButtonsEventArgs e)
        {
            string documentationUrlWPF = "http://docs.telerik.com/devtools/wpf/introduction.html";
            SqlServerPickerViewModel vm = (SqlServerPickerViewModel)this.DataContext;
            var hyperlinkControl = new HyperlinkControl();

            hyperlinkControl.Text = "Telerik UI for WPF Documentation";
            vm.HelpUrl = documentationUrlWPF;

            hyperlinkControl.Command = vm.NavigateCommand;
            var alertContent = new StackPanel();
            alertContent.Children.Add(new TextBlock() { Text = "You can view our documentation here:" });
            alertContent.Children.Add(hyperlinkControl);
            RadWindow.Alert(new DialogParameters()
            {
                Header = "Help",
                Content = alertContent
            });
        }

        private void wizard_Next(object sender, NavigationButtonsEventArgs e)
        {
            switch (e.SelectedPageIndex)
            {
                case 0:
                    ViewModel.SqlServerDataImportVM.SelectedSqlServer = ViewModel.SqlServerPickerVM.SelectedSqlServer;
                    break;

                case 1:
                    ViewModel.SqlServerDataImportMapperVM.SourceSqlServer =
                        ViewModel.SqlServerDataImportVM.SelectedSqlServer;
                    break;
            }
        }
    }
}
