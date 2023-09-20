using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Schedule.Support
{
    public class MinutesPerTimeIntervalRow
    {
        public int Minutes { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            if( Minutes < 60)
                return new TimeSpan(0, 0, Minutes, 0).ToString();
            return new TimeSpan(0, 0, Minutes, 0).ToString("HH");
        }

        #endregion
    }
}
