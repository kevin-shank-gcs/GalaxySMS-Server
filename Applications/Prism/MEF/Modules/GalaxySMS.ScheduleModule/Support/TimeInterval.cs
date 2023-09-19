using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Schedule.Support
{
    public class TimeInterval
    {
        public enum Resolution : int { Minute = 1, FifteenMinute = 15 }

        private string _toolTip;
//        public DateTimeOffset Time { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan Duration { get; set; }
        public string ToolTip
        {
            get
            {
                if (string.IsNullOrEmpty(_toolTip))
                {
                    var dt = new DateTime(1, 1, 1, Time.Hours, Time.Minutes, 0);
                    if (Duration.TotalMinutes > 1)
                    {
                        return string.Format("{0} - {1}",
                            dt.ToShortTimeString(), (dt + Duration).ToShortTimeString());
                    }
                    else
                    {
                        return string.Format("{0}", dt.ToShortTimeString());
                    }
                }
                return _toolTip;
            }
            set { _toolTip = value; }
        }

        public Resolution IntervalResolution { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            var dt = new DateTime(1, 1, 1, Time.Hours, Time.Minutes, 0);
            switch (IntervalResolution)
            {
                case Resolution.Minute:
                    switch (Time.Minutes)
                    {
                        case 0:
                            return dt.ToString("h tt");
                        case 15:
                        case 30:
                        case 45:
                            return dt.ToString("h:mm");

                        default:
                            if (Time.Minutes % 5 == 0)
                                return dt.ToString("mm");
                                //    return "\u2022";
                            return dt.ToString("    ");
                            break;
                    }
                    break;
                case Resolution.FifteenMinute:
                    if (Time.Minutes == 0)
                        return dt.ToString("h tt");
                    break;
            }
            //if ( Time.Minute == 0)
            //    return Time.ToString("h tt");
            //switch( Time.Minute)
            //{
            //    case 0:
            //        return Time.ToString("h");
            //}
            return "  "; //string.Empty;
        }

        #endregion
    }
}
