using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Imaging
{
    public class ImageCaptureDevice
    {
        public ImageCaptureDevice(string name)
        {
            Name = name;
        }

        public String Name
        {
            get;
            internal set;
        }

    }
}
