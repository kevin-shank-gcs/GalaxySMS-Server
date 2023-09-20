using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.AssaAbloyDSR.DSRAccessControlService;
using GCS.AssaAbloyDSR.DSRManagementService;
using GCS.Core.Common.Extensions;

namespace GCS.AssaAbloyDSR
{
    public static class AssaAbloyExtensions
    {
        public static string GetAttribute(this AccessPoint p, AccessPointAttribute a)
        {
            var returnValue = (from att in p.accessPointAttributes
                               where att.name == a
                               select att).FirstOrDefault()?.Value;
            if (string.IsNullOrEmpty(returnValue) || string.IsNullOrWhiteSpace(returnValue))
                return string.Empty;
            return returnValue;
        }

        public static TimePeriod FromStartEndTimePeriod(this TimePeriod tp, StartEndTimePeriod o)
        {
            var data = new TimePeriod();
            data.start = data.start.FromDateTime(o.StartTime);
            data.end = data.end.FromDateTime(o.EndTime);
            return data;
        }

        public static TimePeriod FromStartEndDateTime(this TimePeriod tp, DateTime start, DateTime end)
        {
            var data = new TimePeriod();
            data.start = data.start.FromDateTime(start);
            data.end = data.end.FromDateTime(end);
            return data;
        }

        public static LocalTime FromDateTime(this LocalTime lt, DateTime o)
        {
            var data = new LocalTime();
            data.hour = o.Hour;
            data.minute = o.Minute;
            data.second = o.Second;
            data.millisecond = o.Millisecond;
            return data;
        }

        public static LocalDate FromDateTime(this LocalDate ld, DateTime o)
        {
            var data = new LocalDate();
            data.year = o.Year;
            data.month = o.Month;
            data.dayOfMonth = o.Day;
            return data;
        }

        public static LocalDate ToLocalDate(this DateTime dt)
        {
            var data = new LocalDate();
            data.year = dt.Year;
            data.month = dt.Month;
            data.dayOfMonth = dt.Day;
            return data;
        }

        public static LocalTime ToDSRLocalTime(this DateTime dt)
        {
            var data = new LocalTime();
            data.hour = dt.Hour;
            data.minute = dt.Minute;
            data.second = dt.Second;
            data.millisecond = dt.Millisecond;
            return data;
        }

        public static DateTime ToDateTime(this LocalDate ld)
        {
            return new DateTime(ld.year, ld.month, ld.dayOfMonth);
        }

        public static DateTime ToDateTime(this LocalDateTime ldt)
        {
            return new DateTime(ldt.localDate.year, ldt.localDate.month, ldt.localDate.dayOfMonth, ldt.localTime.hour, ldt.localTime.minute, ldt.localTime.second, ldt.localTime.millisecond);
        }

        public static bool IsEqual(this DSRAccessControlService.Entity de, DSRAccessControlService.Entity o)
        {
            if (de == null && o == null)
                return true;
            if (de == null && o != null)
                return false;
            if (de != null && o == null)
                return false;
            if (de == o)
                return true;
            if (de.id != o.id)
                return false;
            return true;
        }
        
        public static bool IsEqual(this DayException de, DayException o)
        {
            if (de == null && o == null)
                return true;
            if (de == null && o != null)
                return false;
            if (de != null && o == null)
                return false;
            if (de == o)
                return true;
            if (de.id != o.id)
                return false;
            if (de.localDate == null && o.localDate != null)
                return false;
            if (de.localDate != null && o.localDate == null)
                return false;

            if (de.localDate.year != o.localDate.year ||
                de.localDate.month != o.localDate.month ||
                de.localDate.dayOfMonth != o.localDate.dayOfMonth)
                return false;

            if (de.timePeriods == null && o.timePeriods != null)
                return false;
            if (de.timePeriods != null && o.timePeriods == null)
                return false;

            if (de.timePeriods.Length != o.timePeriods.Length)
                return false;

            for( int x = 0; x < de.timePeriods.Length; x++)
            {
                var tp = de.timePeriods[x];
                var tp1 = o.timePeriods[x];
                if (tp.start.hour != tp.start.hour ||
                    tp.end.hour != tp.end.hour ||
                    tp.start.minute != tp.start.minute ||
                    tp.end.minute != tp.end.minute ||
                    tp.start.second != tp.start.second ||
                    tp.end.second != tp.end.second ||
                    tp.start.millisecond != tp.start.millisecond ||
                    tp.end.millisecond != tp.end.millisecond)
                    return false;
            }

            return true;
        }

        public static bool IsEqual(this DayExceptionGroup o, DayExceptionGroup o1)
        {
            if (o1 == null && o == null)
                return true;
            if (o1 == null && o != null)
                return false;
            if (o1 != null && o == null)
                return false;
            if (o1 == o)
                return true;
            if (o1.id != o.id)
                return false;

            if ((o1.dayExceptionIds == null || o1.dayExceptionIds.Length == 0) &&
                (o.dayExceptionIds == null || o.dayExceptionIds.Length == 0))
                return true;

            if (o1.dayExceptionIds.Length != o.dayExceptionIds.Length)
                return false;

            foreach( var id in o1.dayExceptionIds)
            {
                if( !o.dayExceptionIds.Contains(id))
                    return false;
            }

            return true;
        }

        public static bool IsEqual(this DayPeriod dp, DayPeriod o)
        {
            if (dp == null && o == null)
                return true;
            if (dp == null && o != null)
                return false;
            if (dp != null && o == null)
                return false;
            if (dp == o)
                return true;
            if (dp.id != o.id)
                return false;

            if (dp.weekDays.Length != o.weekDays.Length)
                return false;
            foreach( var wd in dp.weekDays)
            {
                if (!dp.weekDays.Contains(wd))
                    return false;
            }

            if (dp.timePeriods == null && o.timePeriods != null)
                return false;
            if (dp.timePeriods != null && o.timePeriods == null)
                return false;

            if (dp.timePeriods.Length != o.timePeriods.Length)
                return false;

            for (int x = 0; x < dp.timePeriods.Length; x++)
            {
                var tp = dp.timePeriods[x];
                var tp1 = o.timePeriods[x];
                if (tp.start.hour != tp.start.hour ||
                    tp.end.hour != tp.end.hour ||
                    tp.start.minute != tp.start.minute ||
                    tp.end.minute != tp.end.minute ||
                    tp.start.second != tp.start.second ||
                    tp.end.second != tp.end.second ||
                    tp.start.millisecond != tp.start.millisecond ||
                    tp.end.millisecond != tp.end.millisecond)
                    return false;
            }

            return true;
        }

        public static bool IsEqual(this Schedule o, Schedule o1)
        {
            if (o1 == null && o == null)
                return true;
            if (o1 == null && o != null)
                return false;
            if (o1 != null && o == null)
                return false;
            if (o1 == o)
                return true;
            if (o1.id != o.id)
                return false;

            if (o1.dayPeriodIds.AreContentsEqual(o.dayPeriodIds) == false)
                return false;

            return o1.dayExceptionGroupIds.AreContentsEqual(o.dayExceptionGroupIds);

        }

        public static bool IsEqual(this Authorization o, Authorization o1)
        {
            if (o1 == null && o == null)
                return true;
            if (o1 == null && o != null)
                return false;
            if (o1 != null && o == null)
                return false;
            if (o1 == o)
                return true;
            if (o1.id != o.id)
                return false;

            if (o1.scheduleId != o.scheduleId)
                return false;

            if (o1.useCount != o.useCount)
                return false;

            if (o1.useCountSpecified != o.useCountSpecified)
                return false;

            if (o1.accessPointId.AreContentsEqual(o.accessPointId) == false)
                return false;
            if (o1.authorizationType.AreContentsEqual(o.authorizationType) == false)
                return false;
            if (o1.userId.AreContentsEqual(o.userId) == false)
                return false;

            return true;

        }

        public static bool IsEqual(this AccessPointMode o, AccessPointMode o1)
        {
            if (o1 == null && o == null)
                return true;
            if (o1 == null && o != null)
                return false;
            if (o1 != null && o == null)
                return false;
            if (o1 == o)
                return true;
            if (o1.id != o.id)
                return false;

            if (o1.scheduleId != o.scheduleId)
                return false;

            if (o1.accessPointModeType != o.accessPointModeType)
                return false;

            if (o1.accessPointIds.AreContentsEqual(o.accessPointIds) == false)
                return false;

            return true;

        }

        public static bool IsEqual(this LocalDate o, LocalDate o1)
        {
            if (o1 == null && o == null)
                return true;
            if (o1 == null && o != null)
                return false;
            if (o1 != null && o == null)
                return false;
            if (o1 == o)
                return true;
            if (o.dayOfMonth != o1.dayOfMonth ||
                o.month != o1.month ||
                o.year != o1.year)
                return false;
            return true;
        }

        public static bool IsEqual(this LocalTime o, LocalTime o1)
        {
            if (o1 == null && o == null)
                return true;
            if (o1 == null && o != null)
                return false;
            if (o1 != null && o == null)
                return false;
            if (o1 == o)
                return true;
            if (o.millisecond != o1.millisecond ||
                o.second != o1.second ||
                o.minute != o1.minute ||
                o.hour != o1.hour)
                return false;
            return true;
        }

        public static bool IsEqual( this LocalDateTime o, LocalDateTime o1)
        {
            if (o1 == null && o == null)
                return true;
            if (o1 == null && o != null)
                return false;
            if (o1 != null && o == null)
                return false;
            if (o1 == o)
                return true;
            if (!o.localDate.IsEqual(o1.localDate))
                return false;
            if (!o.localTime.IsEqual(o1.localTime))
                return false;
            return true;
        }

        public static bool IsEqual(this DateTimePeriod o, DateTimePeriod o1)
        {
            if (o1 == null && o == null)
                return true;
            if (o1 == null && o != null)
                return false;
            if (o1 != null && o == null)
                return false;
            if (o1 == o)
                return true;
            if (!o.end.IsEqual(o1.end))
                return false;
            if (!o.start.IsEqual(o1.start))
                return false;
            return true;
        }

        public static bool IsEqual(this User o, User o1)
        {
            if (o1 == null && o == null)
                return true;
            if (o1 == null && o != null)
                return false;
            if (o1 != null && o == null)
                return false;
            if (o1 == o)
                return true;
            if (o1.id != o.id)
                return false;

            if (o1.cardholderId != o.cardholderId)
                return false;

            if (o1.userFlags == null && o.userFlags != null ||
                o1.userFlags != null && o.userFlags == null)
                return false;

            if( o1.userFlags != null && o.userFlags != null)
            {
                if (o1.userFlags.AreContentsEqual(o.userFlags) == false)
                return false;
            }

            if (o1.validity == null && o.validity != null ||
                o1.validity != null && o.validity == null)
                return false;

            if (o1.validity != null && o.validity != null)
            {
                if (o1.validity.IsEqual(o.validity) == false)
                    return false;
            }

            if (o1.credentials == null && o.credentials != null ||
                o1.credentials != null && o.credentials == null)
                return false;

            if (o1.credentials != null && o.credentials != null)
            {
                if (o.credentials.Length != o1.credentials.Length)
                    return false;

                if (o.credentials != null)
                {
                    for (int x = 0; x < o.credentials.Length; x++)
                    {
                        var c = o.credentials[x];
                        var c1 = o1.credentials[x];

                        if (c.facilityCode != c1.facilityCode)
                            return false;
                        if (c.format != c1.format)
                            return false;
                        if (c.ordinal != c1.ordinal)
                            return false;
                        if (c.value?.intValue != c1.value?.intValue)
                            return false;
                        if (c.value?.intValueSpecified != c1.value?.intValueSpecified)
                            return false;
                        if (c.value?.stringValue != c1.value?.stringValue)
                            return false;
                    }
                }
            }
            return true;

        }
    }
}
