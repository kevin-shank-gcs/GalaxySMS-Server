using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.AssaAbloyDSR.DSRAccessControlService;

namespace GCS.AssaAbloyDSR
{
    public class StartEndTimePeriod
    {
        public StartEndTimePeriod()
        {
            StartTime = DateTime.Today;
            EndTime = StartTime.Add(new TimeSpan(23, 59, 59));
        }

        public StartEndTimePeriod(DateTime start, DateTime end)
        {
            StartTime = start;
            EndTime = end;
        }

        public StartEndTimePeriod(LocalTime start, LocalTime end)
        {
            var today = DateTime.Today;
            StartTime = new DateTime(today.Year, today.Month, today.Day, start.hour, start.minute, start.second);
            EndTime = new DateTime(today.Year, today.Month, today.Day, end.hour, end.minute, end.second);
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", StartTime.ToString("T"), EndTime.ToString("T"));
        }
    }
}
