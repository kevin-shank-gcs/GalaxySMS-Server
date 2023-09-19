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

namespace GalaxySMS.PersonCredential.UserControls.SearchProperties
{
    /// <summary>
    /// Interaction logic for ucCredentialXceedId40BitSearch.xaml
    /// </summary>
    public partial class ucCredentialXceedId40BitSearch : UserControl
    {
        public ucCredentialXceedId40BitSearch()
        {
            InitializeComponent();
        }

        private void ucCredentialXceedId40BitSearch_OnLoaded(object sender, RoutedEventArgs e)
        {
            var o = this.DataContext;
        }
    }
}
