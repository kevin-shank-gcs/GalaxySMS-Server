using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Imaging
{
    public class AspectRatio
    {
        public AspectRatio(ImageAspectRatio aspectRatio)
        {
            ImageAspectRatio = aspectRatio;
        }

        public ImageAspectRatio ImageAspectRatio { get; set; }
        public override string ToString()
        {
            switch (ImageAspectRatio)
            {
                case ImageAspectRatio.Square1X1:
                    return Properties.Resources.ImageCaptureControl_AspectRatio_Square;
                case ImageAspectRatio.Portrait4X5:
                    return Properties.Resources.ImageCaptureControl_AspectRatio_Portrait_4x5;
                case ImageAspectRatio.Landscape5X4:
                    return Properties.Resources.ImageCaptureControl_AspectRatio_Landscape_5x4;
                case ImageAspectRatio.Landscape4X3:
                    return Properties.Resources.ImageCaptureControl_AspectRatio_Landscape_4x3;
                case ImageAspectRatio.Landscape8X5:
                    return Properties.Resources.ImageCaptureControl_AspectRatio_Landscape_8x5;
                case ImageAspectRatio.Landscape16X9:
                    return Properties.Resources.ImageCaptureControl_AspectRatio_Landscape_16x9;
                default:
                    return ImageAspectRatio.ToString();
            }
        }
    }
}
