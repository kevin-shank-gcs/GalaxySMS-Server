using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Schedule
{
    public class DateDayTypeChanged
    {
        public DayTypeListItem DayType { get; set; }
        public List<DateTimeOffset> Dates { get; set; }
    }
}
