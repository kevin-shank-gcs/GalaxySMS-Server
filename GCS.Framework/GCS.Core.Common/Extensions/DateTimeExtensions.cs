////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\DateTimeExtensions.cs
//
// summary:	Implements the date time extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A date time extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class DateTimeExtensions
    {
        /// <summary>   The GC. </summary>
        static GregorianCalendar _gc = new GregorianCalendar();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that minimum SQL date time. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTimeOffset MinSqlDateTime(this DateTimeOffset dt)
        {
            return new DateTimeOffset(1753, 1, 1, 0,0,0,0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that maximum SQL date time. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTimeOffset MaxSqlDateTime(this DateTimeOffset dt)
        {
            return new DateTimeOffset(9999, 12, 31, 23,59,59);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that minimum SQL small date time. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTimeOffset MinSqlSmallDateTime(this DateTimeOffset dt)
        {
            return new DateTimeOffset(1900, 1, 1,0,0,0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that maximum SQL small date time. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTimeOffset MaxSqlSmallDateTime(this DateTimeOffset dt)
        {
            return new DateTimeOffset(2079, 6, 6,23,59,59);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that minimum SQL date time 2. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTimeOffset MinSqlDateTime2(this DateTimeOffset dt)
        {
            return new DateTimeOffset(1, 1, 1, 0, 0, 0, 0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that maximum SQL date time 2. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTimeOffset MaxSqlDateTime2(this DateTimeOffset dt)
        {
            return new DateTimeOffset(9999, 12, 31, 23, 59, 59, 9999999);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that date only. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTimeOffset DateOnly(this DateTimeOffset dt)
        {
            return new DateTimeOffset(dt.Year, dt.Month, dt.Day);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that starts of month. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTimeOffset StartOfMonth(this DateTimeOffset dt)
        {
            return new DateTimeOffset(dt.Year, dt.Month, 1, 0, 0, 0);    
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that ends of month. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DateTimeOffset EndOfMonth(this DateTimeOffset dt)
        {
            return dt.StartOfMonth().AddMonths(1) - new TimeSpan(0, 0, 0, 0, 1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that day of week number. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int DayOfWeekNumber(this DateTimeOffset dt)
        {
            return (int)dt.DayOfWeek;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that gets week of year. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="time"> The time to act on. </param>
        ///
        /// <returns>   The week of year. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static int GetWeekOfYear(this DateTimeOffset time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that week of month. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int WeekOfMonth(this DateTimeOffset dt)
        {
            DateTimeOffset first = new DateTimeOffset(dt.Year, dt.Month, 1);
            return dt.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that days in month. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int DaysInMonth(this DateTimeOffset dt)
        {
            return _gc.GetDaysInMonth(dt.Year, dt.Month);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that query if 'dt' is in the past. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   True if in the past, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsInThePast(this DateTimeOffset dt)
        {
            return dt < DateTimeOffset.Now;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A DateTimeOffset extension method that query if 'dt' is within the next year.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   True if within the next year, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsWithinTheNextYear(this DateTimeOffset dt)
        {
            return dt >= DateTimeOffset.Today && dt < DateTimeOffset.Now.AddYears(1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that query if 'dt' is this month. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   True if this month, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsThisMonth(this DateTimeOffset dt)
        {
            return dt.Month == DateTimeOffset.Now.Month;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that query if 'dt' is today. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   True if today, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsToday(this DateTimeOffset dt)
        {
            return dt.Year == DateTimeOffset.Now.Year && dt.Month == DateTimeOffset.Now.Month && dt.Day == DateTimeOffset.Now.Day;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the first of each month for next years in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the first of each month for next
        /// years in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<DateTimeOffset> GetFirstOfEachMonthForNextYear(this DateTimeOffset dt)
        {
            var now = DateTimeOffset.Now;
            var results = new List<DateTimeOffset>();
            for(int x = 0; x < 12; x++)
            {
                results.Add(now.StartOfMonth());
                now = now.AddMonths(1);
            }
            return results;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all day of week dates in months in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">           The dt to act on. </param>
        /// <param name="dayOfWeek">    The day of week. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process all day of week dates in months in
        /// this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<DateTimeOffset> GetAllDayOfWeekDatesInMonth(this DateTimeOffset dt, DayOfWeek dayOfWeek )
        {
            return Enumerable.Range(1, DateTimeOffset.DaysInMonth(dt.Year, dt.Month))  // Days: 1, 2 ... 31 etc.
                .Select(day => new DateTimeOffset(dt.Year, dt.Month, day)) // Map each day to a date
                .Where(dow => dow.DayOfWeek == dayOfWeek)
                .ToList(); // Load dates into a list
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all dates for ranges in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dt">           The dt to act on. </param>
        /// <param name="endDateTime">  The end date time. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process all dates for ranges in this
        /// collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<DateTimeOffset> GetAllDatesForRange(this DateTimeOffset dt, DateTimeOffset endDateTime)
        {
            return Enumerable.Range(0, 1 + endDateTime.Subtract(dt).Days)
                .Select(offset => dt.AddDays(offset))
                .ToArray();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that unix timestamp from date time. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="date"> The date to act on. </param>
        ///
        /// <returns>   A long. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static long UnixTimestampFromDateTime(this DateTimeOffset date)
        {
            long unixTimestamp = date.Ticks - new DateTimeOffset(1970, 1, 1).Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An int extension method that time from unix timestamp. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="unixTimestamp">    The unixTimestamp to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static DateTimeOffset TimeFromUnixTimestamp(this int unixTimestamp)
        {
            DateTimeOffset unixYear0 = new DateTimeOffset(1970, 1, 1);
            long unixTimeStampInTicks = unixTimestamp * TimeSpan.TicksPerSecond;
            DateTimeOffset dtUnix = new DateTimeOffset(unixYear0.Ticks + unixTimeStampInTicks);
            return dtUnix;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A DateTimeOffset extension method that converts a value to a SQL date time format.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="value">    The value to act on. </param>
        ///
        /// <returns>   Value as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ToSqlDateTimeFormat(this DateTimeOffset value)
        {
            return value.ToString("s");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A DateTimeOffset extension method that converts a value to a SQL date format.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="value">    The value to act on. </param>
        ///
        /// <returns>   Value as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ToSqlDateFormat(this DateTimeOffset value)
        {
            return value.ToString("yyyy-MM-dd");
        }

        public static DateTimeOffset GetCurrentTimeForTimeZoneId(this DateTimeOffset value, string timeZoneId)
        {
            if( string.IsNullOrEmpty(timeZoneId))
                return value;
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, timeZoneId);
        }
    }
}
