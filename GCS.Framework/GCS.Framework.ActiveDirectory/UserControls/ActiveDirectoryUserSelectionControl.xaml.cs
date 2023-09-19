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
using GCS.Core.Common.UI.Core;

namespace GCS.Framework.ActiveDirectory.UserControls
{
    /// <summary>
    /// Interaction logic for ActiveDirectoryUserSelectionControl.xaml
    /// </summary>
    public partial class ActiveDirectoryUserSelectionControl : UserControlViewBase
    {
        private ActiveDirectoryUserSelectionViewModel _viewModel;

        public ActiveDirectoryUserSelectionControl()
        {
            InitializeComponent();
            _viewModel = new ActiveDirectoryUserSelectionViewModel();
            DataContext = _viewModel;
        }

        public GCSADUser SelectedADUser
        {
            get { return _viewModel.SelectedADUser; }
            set
            {
                _viewModel.SelectedADUser = value;
            }
        }

        public Nullable<bool> DialogResult { get; internal set; }
        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnAccept_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
