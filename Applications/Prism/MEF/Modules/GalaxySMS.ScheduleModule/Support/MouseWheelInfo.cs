using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Schedule.Support
{
    public class MouseWheelInfo
    {
        public MouseWheelInfo(int delta)
        {
            Delta = delta;
        }

        public int Delta { get; }
    }
}
