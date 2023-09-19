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

namespace GalaxySMS.Client.UI
{
    /// <summary>
    /// Interaction logic for EditButtonControlBindable.xaml
    /// </summary>
    public partial class EditButtonControlBindable : ButtonUserControlBase
    {
        public EditButtonControlBindable()
        {
            InitializeComponent();
            this.IsVisible = true;
            this.Text = Properties.Resources.Common_Edit;
            this.ToolTip = Properties.Resources.Common_EditToolTip;
        }
    }
}
