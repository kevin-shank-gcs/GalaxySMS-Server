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
using GalaxySMS.Client.UI;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.OutputDevice.UserControls
{
    /// <summary>
    /// Interaction logic for ucInputSourceSettings.xaml
    /// </summary>
    public partial class ucInputSourceSettings : UserControl//UserControlViewBase
    {
        public ucInputSourceSettings()
        {
            InitializeComponent();
        }

        #region InputSource
        public static readonly DependencyProperty InputSourceProperty =
            DependencyProperty.Register(
                "InputSource",
                typeof(GalaxyOutputDeviceInputSource),
                typeof(ucInputSourceSettings),
                new UIPropertyMetadata(null));
        public GalaxyOutputDeviceInputSource InputSource
        {
            get { return (GalaxyOutputDeviceInputSource) GetValue(InputSourceProperty); }
            set { SetValue(InputSourceProperty, value); }
        }
        #endregion
    }
}
