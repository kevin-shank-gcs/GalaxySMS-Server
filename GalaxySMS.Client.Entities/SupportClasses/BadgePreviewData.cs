using GCS.Core.Common.Core;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace GalaxySMS.Client.Entities
{
    public class BadgePreviewData : ObjectBase
    {
        public BadgePreviewData()
        {

        }

        public BadgePreviewData(PreviewData previewData)
        {
            if (!string.IsNullOrEmpty(previewData?.FrontPreviewImage))
            {
                var frontPreviewImage = Convert.FromBase64String(previewData.FrontPreviewImage);
                FrontImage = new BitmapImage();
                FrontImage.BeginInit();
                FrontImage.StreamSource = new MemoryStream(frontPreviewImage);
                FrontImage.EndInit();
            }

            if (!string.IsNullOrEmpty(previewData?.BackPreviewImage))
            {
                var backPreviewImage = Convert.FromBase64String(previewData.BackPreviewImage);
                BackImage = new BitmapImage();
                BackImage.BeginInit();
                BackImage.StreamSource = new MemoryStream(backPreviewImage);
                BackImage.EndInit();
            }
        }


        private BitmapImage _frontImage;

        public BitmapImage FrontImage
        {
            get { return _frontImage; }
            set
            {
                if (_frontImage != value)
                {
                    _frontImage = value;
                    OnPropertyChanged(() => FrontImage, false);
                }
            }
        }

        private BitmapImage _backImage;

        public BitmapImage BackImage
        {
            get { return _backImage; }
            set
            {
                if (_backImage != value)
                {
                    _backImage = value;
                    OnPropertyChanged(() => BackImage, false);
                }
            }
        }


    }
}
