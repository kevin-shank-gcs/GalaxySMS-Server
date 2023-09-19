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
    /// Interaction logic for ucCredential26BitStandardSearch.xaml
    /// </summary>
    public partial class ucCredential26BitStandardSearch : UserControl
    {
        public ucCredential26BitStandardSearch()
        {
            InitializeComponent();
        }

        private void ucCredential26BitStandardSearch_OnLoaded(object sender, RoutedEventArgs e)
        {
            var dc = this.DataContext;
        }
    }
}
