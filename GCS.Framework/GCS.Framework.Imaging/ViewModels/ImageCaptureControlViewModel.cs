using System.Drawing;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Imaging.Helpers;
using SPECSID.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCS.Core.Common.Extensions;

namespace GCS.Framework.Imaging
{
    public class ImageCaptureControlViewModel : ViewModelBase
    {
        public ImageCaptureControlViewModel()
        {
            ZoomInCommand = new DelegateCommand<object>(OnZoomInCommandExecute, OnZoomInCommandCanExecute);
            ZoomOutCommand = new DelegateCommand<object>(OnZoomOutCommandExecute, OnSaveCommandZoomOutCommandCanExecute);
            CapturePhotoCommand = new DelegateCommand<object>(OnCapturePhotoCommandExecute, OnCapturePhotoCommandCanExecute);
            try
            {
                _aspectRatios = new ObservableCollection<AspectRatio>();
                _aspectRatios.Add(new AspectRatio(ImageAspectRatio.Square1X1));
                _aspectRatios.Add(new AspectRatio(ImageAspectRatio.Portrait4X5));
                _aspectRatios.Add(new AspectRatio(ImageAspectRatio.Landscape16X9));
                _aspectRatios.Add(new AspectRatio(ImageAspectRatio.Landscape4X3));
                _aspectRatios.Add(new AspectRatio(ImageAspectRatio.Landscape5X4));
                _aspectRatios.Add(new AspectRatio(ImageAspectRatio.Landscape8X5));

                CaptureControl.SetActiveGuid("A38C5910-6615-4659-949C-835A0B37AD2E");
                _CaptureControl = new CaptureControl();
                _CaptureControl.DisableProviders("TWAIN,WIA,CanonSDK,CanonEDSDK");

                _CaptureControl.AspectRatio = new System.Drawing.Size(4, 5);
                _CaptureControl.AutoCropMode = SPECSID.Windows.Forms.AutoCropModes.Person;// SPECSID.Windows.Forms.AutoCropModes.None;
                _CaptureControl.FaceDetectParams.ImageAspectRatio = new System.Drawing.Size(4, 5);
                _CaptureControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                _CaptureControl.CropRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
                _CaptureControl.DemoText = "";
                _CaptureControl.ForceDemoMode = false;
                _CaptureControl.Image = null;
                _CaptureControl.Location = new System.Drawing.Point(0, 0);
                _CaptureControl.Name = "captureControl1";
                _CaptureControl.ResetRotationOnCapture = true;
                _CaptureControl.Rotation = 0F;
                _CaptureControl.RotationDelta1 = 1;
                _CaptureControl.RotationDelta2 = 5;
                _CaptureControl.SelectedDevice = null;
                _CaptureControl.Size = new System.Drawing.Size(160, 200);
                _CaptureControl.Visible = true;
                _CaptureControl.ZoomPct = 0;
                _CaptureControl.CropRectangle = new System.Drawing.Rectangle(0, 0, _CaptureControl.Size.Width, _CaptureControl.Size.Height);
                _CaptureControl.ImageChanged += _CaptureControl_ImageChanged;
                CaptureDevices = _CaptureControl.Devices.ToObservableCollection<CaptureDevice>();
                if (_CaptureControl.Devices.Length > 0)
                    SelectedCaptureDevice = _CaptureControl.Devices[0];
            }
            catch (Exception ex)
            {
                CustomErrors.Add(new Core.Common.CustomError(ex));
            }
        }

        void _CaptureControl_ImageChanged(object sender, EventArgs e)
        {
            _CaptureControl.Invalidate();
        }

        public DelegateCommand<object> ZoomInCommand { get; private set; }
        public DelegateCommand<object> ZoomOutCommand { get; private set; }
        public DelegateCommand<object> CapturePhotoCommand { get; private set; }

        CaptureControl _CaptureControl;
        ObservableCollection<CaptureDevice> _CaptureDevices;
        CaptureDevice _SelectedCaptureDevice;
        bool _LivePreview = true;
        private bool _automaticallyScaleDownImage;
        private ushort _scaleToMaximumWidth;
        private ushort _scaleToMaximumHeight;
        private Image _imageCroppedAndScaled;
        private int _uiControlWidth;
        private int _uiControlHeight;
        private ObservableCollection<AspectRatio> _aspectRatios;
        private AspectRatio _selectedAspectRatio;

        public CaptureControl CaptureControl { get { return _CaptureControl; } }
        public ObservableCollection<CaptureDevice> CaptureDevices
        {
            get { return _CaptureDevices; }
            set
            {
                if (_CaptureDevices != value)
                {
                    _CaptureDevices = value;
                    OnPropertyChanged(() => CaptureDevices, false);
                }
            }
        }

        public ObservableCollection<AspectRatio> AspectRatios
        {
            get { return _aspectRatios; }
            set
            {
                if (_aspectRatios != value)
                {
                    _aspectRatios = value;
                    OnPropertyChanged(() => AspectRatios, false);
                }
            }
        }

        public AspectRatio SelectedAspectRatio
        {
            get { return _selectedAspectRatio; }
            set
            {
                if (_selectedAspectRatio != value)
                {
                    _selectedAspectRatio = value;
                    OnPropertyChanged(() => SelectedAspectRatio, false);
                    SetAspectRatio(_selectedAspectRatio.ImageAspectRatio);
                }
            }
        }

        public AutoCropModes AutoCropMode
        {
            get
            {
                switch (_CaptureControl.AutoCropMode)
                {
                    case SPECSID.Windows.Forms.AutoCropModes.None:
                        return AutoCropModes.None;

                    case SPECSID.Windows.Forms.AutoCropModes.Person:
                        return AutoCropModes.Person;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                switch (value)
                {
                    case AutoCropModes.None:
                        _CaptureControl.AutoCropMode = SPECSID.Windows.Forms.AutoCropModes.None;
                       break;
                    case AutoCropModes.Person:
                        _CaptureControl.AutoCropMode = SPECSID.Windows.Forms.AutoCropModes.Person;
                       break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }
        public CaptureDevice SelectedCaptureDevice
        {
            get { return _SelectedCaptureDevice; }
            set
            {
                if (_SelectedCaptureDevice != value)
                {
                    _SelectedCaptureDevice = value;
                    OnPropertyChanged(() => SelectedCaptureDevice, false);

                    if (_CaptureControl != null)
                        _CaptureControl.SelectedDevice = _SelectedCaptureDevice;
                }
            }
        }

        public bool LivePreview
        {
            get { return _LivePreview; }
            set
            {
                if (_LivePreview != value)
                {
                    _LivePreview = value;
                    OnPropertyChanged(() => LivePreview, false);
                }
                if (_CaptureControl != null && _CaptureControl.SelectedDevice != null)
                {
                    if (_LivePreview == true)
                        _CaptureControl.SelectedDevice.Preview = OnOff.On;
                    else
                        _CaptureControl.SelectedDevice.Preview = OnOff.Off;
                }
            }
        }

        public void SetAspectRatio(ImageAspectRatio aspectRatio)
        {
            int x = 1;
            int y = 1;
            switch (aspectRatio)
            {
                case ImageAspectRatio.Square1X1:
                    x = 1;
                    y = 1;
                    UIControlWidth = 250;
                    UIControlHeight = 250;
                    break;

                case ImageAspectRatio.Landscape16X9:
                    x = 16;
                    y = 9;
                    UIControlWidth = 250;
                    UIControlHeight = 141;
                    break;

                case ImageAspectRatio.Landscape4X3:
                    x = 4;
                    y = 3;
                    UIControlWidth = 250;
                    UIControlHeight = 188;
                    break;
                case ImageAspectRatio.Landscape5X4:
                    x = 5;
                    y = 4;
                    UIControlWidth = 250;
                    UIControlHeight = 200;
                    break;
                case ImageAspectRatio.Landscape8X5:
                    x = 8;
                    y = 5;
                    UIControlWidth = 250;
                    UIControlHeight = 156;
                    break;
                case ImageAspectRatio.Portrait4X5:
                    x = 4;
                    y = 5;
                    UIControlWidth = 200;
                    UIControlHeight = 250;
                    break;
            }
            if (_CaptureControl != null)
            {
                _CaptureControl.AspectRatio = new System.Drawing.Size(x, y);
                _CaptureControl.FaceDetectParams.ImageAspectRatio = new System.Drawing.Size(x, y);
                _CaptureControl.Size = new System.Drawing.Size(UIControlWidth, UIControlHeight);
                _CaptureControl.CropRectangle = new System.Drawing.Rectangle(0, 0, _CaptureControl.Size.Width, _CaptureControl.Size.Height);
            }

            foreach (AspectRatio ar  in AspectRatios)
            {
                if (ar.ImageAspectRatio == aspectRatio)
                {
                    _selectedAspectRatio = ar;
                    break;
                }
            }
        }


        public int UIControlWidth
        {
            get { return _uiControlWidth; }
            set
            {
                _uiControlWidth = value;
                OnPropertyChanged(() => UIControlWidth, false);

            }
        }

        public int UIControlHeight
        {
            get { return _uiControlHeight; }
            set
            {
                _uiControlHeight = value;
                OnPropertyChanged(() => UIControlHeight, false);
            }
        }


        public bool AutomaticallyScaleDownImage
        {
            get { return _automaticallyScaleDownImage; }
            set { _automaticallyScaleDownImage = value; }
        }

        public UInt16 ScaleToMaximumWidth
        {
            get { return _scaleToMaximumWidth; }
            set { _scaleToMaximumWidth = value; }
        }

        public UInt16 ScaleToMaximumHeight
        {
            get { return _scaleToMaximumHeight; }
            set { _scaleToMaximumHeight = value; }
        }

        public System.Drawing.Image Image
        {
            get
            {
                if (CaptureControl != null)
                    return CaptureControl.Image;
                return null;
            }
            set
            {
                if (CaptureControl != null)
                    CaptureControl.Image = value;
            }
        }

        public System.Drawing.Image ImageCropped
        {
            get
            {
                if (CaptureControl != null)
                {
                    return CaptureControl.ImageCropped;
                }
                return null;
            }
        }

        public System.Drawing.Image ImageCroppedAndScaled
        {
            get
            {
                return _imageCroppedAndScaled;
            }
        }

        private bool OnCapturePhotoCommandCanExecute(object obj)
        {
            if (_CaptureControl != null && _CaptureControl.SelectedDevice != null)
                return true;
            return false;
        }

        private void OnCapturePhotoCommandExecute(object obj)
        {
            try
            {
                if (_CaptureControl != null && _CaptureControl.SelectedDevice != null)
                {
                    GC.Collect();
                    bool bRet = _CaptureControl.CaptureImage(false);
                    if (bRet == true)
                    {
                        //if (AutomaticallyScaleDownImage == true)
                        //    UpdateImageCroppedAndScaled();
                    }
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                CustomErrors.Add(new Core.Common.CustomError(ex));
            }

        }

        private bool OnSaveCommandZoomOutCommandCanExecute(object obj)
        {
            if (_CaptureControl != null && _CaptureControl.Image != null)
                return true;
            return false;
        }

        public void UpdateImageCroppedAndScaled()
        {
            if (_CaptureControl != null)
            {
                try
                {
                    if (CaptureControl.ImageCropped != null)
                    {
                        var img = CaptureControl.ImageCropped;
                        _imageCroppedAndScaled = ImageUtilities.ResizeImageWithAspectRatio(img, //CaptureControl.ImageCropped,
                            ScaleToMaximumWidth, ScaleToMaximumHeight);
                    }
                }
                catch (Exception e)
                {
                    if (CaptureControl.Image != null)
                    {
                        _imageCroppedAndScaled = ImageUtilities.ResizeImageWithAspectRatio(CaptureControl.Image,
                            ScaleToMaximumWidth, ScaleToMaximumHeight);
                    }

                }
            }
        }
        private void OnZoomOutCommandExecute(object obj)
        {
            try
            {
                if (_CaptureControl != null && _CaptureControl.Image != null)
                {
                    _CaptureControl.ZoomOut(1);
//                    UpdateImageCroppedAndScaled();
                }
            }
            catch (Exception ex)
            {
                CustomErrors.Add(new Core.Common.CustomError(ex));
            }
        }

        private bool OnZoomInCommandCanExecute(object obj)
        {
            if (_CaptureControl != null && _CaptureControl.Image != null)
                return true;
            return false;
        }

        private void OnZoomInCommandExecute(object obj)
        {
            try
            {
                if (_CaptureControl != null && _CaptureControl.Image != null)
                {
                    _CaptureControl.ZoomIn(1);
//                    UpdateImageCroppedAndScaled();
                }
            }
            catch (Exception ex)
            {
                CustomErrors.Add(new Core.Common.CustomError(ex));
            }
        }
    }
}
