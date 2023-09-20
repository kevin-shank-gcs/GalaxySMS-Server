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
    /// Interaction logic for EditDeleteButtonControl.xaml
    /// </summary>
    public partial class EditDeleteButtonControl : UserControl
    {
        public EditDeleteButtonControl()
        {
            InitializeComponent();
            StackPanelOrientation = Orientation.Horizontal;
        }


        #region StackPanelOrientation
        public static readonly DependencyProperty StackPanelOrientationProperty =
            DependencyProperty.Register(
                "IsVisible",
                typeof(Orientation),
                typeof(UserControl),
                new UIPropertyMetadata(null));
        public Orientation StackPanelOrientation
        {
            get { return (Orientation)GetValue(StackPanelOrientationProperty); }
            set { SetValue(StackPanelOrientationProperty, value); }
        }
        #endregion


    }
}
