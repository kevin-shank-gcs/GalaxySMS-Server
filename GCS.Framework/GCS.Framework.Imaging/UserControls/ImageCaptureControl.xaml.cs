using System.Windows.Forms;
using System.Windows.Forms.Integration;
using SPECSID.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GCS.Core.Common.UI.Core;
using Telerik.Windows.Controls;
//using UserControl = System.Windows.Controls.UserControl;

namespace GCS.Framework.Imaging
{
    /// <summary>
    /// Interaction logic for ImageCaptureControl.xaml
    /// </summary>
    public partial class ImageCaptureControl : UserControlViewBase// System.Windows.Controls.UserControl
    {
        private ImageCaptureControlViewModel _viewModel;
        private List<ImageCaptureDevice> _ImageCaptureDevices;

        public ImageCaptureControl()
        {
            InitializeComponent();
            _viewModel = new ImageCaptureControlViewModel();
            DataContext = _viewModel;
            AspectRatio = ImageAspectRatio.Square1X1;
            Loaded += UserControl_Loaded;
            DialogResult = false;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            winFormHostImageControl.Child = _viewModel.CaptureControl;
        }

        #region Public Properties
        public ImageCaptureDevice SelectedDevice
        {
            get
            {
                if (_viewModel != null)
                {
                    if (_viewModel.SelectedCaptureDevice != null)
                        return new ImageCaptureDevice(_viewModel.SelectedCaptureDevice.Name);
                }
                return new ImageCaptureDevice(string.Empty);
            }
            set
            {
                if (_viewModel != null)
                {
                    if (_viewModel.SelectedCaptureDevice != null)
                    {
                        foreach (var cd in _viewModel.CaptureDevices)
                        {
                            if (cd.Name == value.Name)
                            {
                                _viewModel.SelectedCaptureDevice = cd;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public ReadOnlyCollection<ImageCaptureDevice> CaptureDevices
        {
            get
            {
                if (_viewModel != null)
                {
                    _ImageCaptureDevices = new List<ImageCaptureDevice>();
                    foreach (CaptureDevice cd in _viewModel.CaptureDevices)
                        _ImageCaptureDevices.Add(new ImageCaptureDevice(cd.Name));
                    return new ReadOnlyCollection<ImageCaptureDevice>(_ImageCaptureDevices);
                }
                return null;
            }
        }

        public bool AutomaticallyScaleDownImage
        {
            get
            {
                if (_viewModel != null)
                    return _viewModel.AutomaticallyScaleDownImage;
                return false;
            }
            set
            {
                if (_viewModel != null)
                    _viewModel.AutomaticallyScaleDownImage = value;
            }
        }

        public UInt16 ScaleToMaximumWidth
        {
            get
            {
                if (_viewModel != null)
                    return _viewModel.ScaleToMaximumWidth;
                return 0;
            }
            set
            {
                if (_viewModel != null)
                    _viewModel.ScaleToMaximumWidth = value;
            }
        }

        public UInt16 ScaleToMaximumHeight
        {
            get
            {
                if (_viewModel != null)
                    return _viewModel.ScaleToMaximumHeight;
                return 0;
            }
            set
            {
                if (_viewModel != null)
                    _viewModel.ScaleToMaximumHeight = value;
            }
        }

        public System.Drawing.Image Image
        {
            get
            {
                if (_viewModel != null)
                    return _viewModel.Image;
                return null;
            }
            set
            {
                if (_viewModel != null)
                    _viewModel.Image = value;
            }
        }

        public System.Drawing.Image ImageCropped
        {
            get
            {
                if (_viewModel != null)
                {
                    return _viewModel.ImageCropped;
                }
                return null;
            }
        }

        public System.Drawing.Image ImageCroppedAndScaled
        {
            get
            {
                if (_viewModel != null)
                {
                    return _viewModel.ImageCroppedAndScaled;
                }
                return null;
            }
        }

        public ImageAspectRatio AspectRatio
        {
            get
            {
                if (_viewModel != null)
                    return _viewModel.SelectedAspectRatio.ImageAspectRatio;
                return ImageAspectRatio.Square1X1;
            }
            set
            {
                if (_viewModel != null)
                    _viewModel.SetAspectRatio(value);
            }
        }

        public AutoCropModes AutoCropMode
        {
            get
            {
                if (_viewModel != null)
                    return _viewModel.AutoCropMode;
                return AutoCropModes.None;
            }
            set
            {
                if (_viewModel != null)
                    _viewModel.AutoCropMode = value;
            }
        }
        #endregion
        public Nullable<bool> DialogResult { get; internal set; }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.UpdateImageCroppedAndScaled();
            }
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
