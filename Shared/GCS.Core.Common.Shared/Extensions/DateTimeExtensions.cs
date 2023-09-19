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
//#if NetCoreApi
//using GCS.Core.Common.Core.Api;
//#endif
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

        public static DateTime MinSqlDateTime(this DateTime dt)
        {
            return new DateTime(1753, 1, 1, 0, 0, 0, 0);
        }

        public static DateTimeOffset MinSqlDateTime(this DateTimeOffset dt)
        {
            return new DateTimeOffset(1753, 1, 1, 0, 0, 0, TimeSpan.Zero);
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

        public static DateTime MaxSqlDateTime(this DateTime dt)
        {
            return new DateTime(9999, 12, 31, 23, 59, 59);
        }
        public static DateTimeOffset MaxSqlDateTime(this DateTimeOffset dt)
        {
            return new DateTimeOffset(DateTime.Now.MaxSqlDateTime());
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

        public static DateTime MinSqlSmallDateTime(this DateTime dt)
        {
            return new DateTime(1900, 1, 1, 0, 0, 0);
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

        public static DateTime MaxSqlSmallDateTime(this DateTime dt)
        {
            return new DateTime(2079, 6, 6, 23, 59, 59);
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

        public static DateTime MinSqlDateTime2(this DateTime dt)
        {
            return new DateTime(1, 1, 1, 0, 0, 0, 0);
        }
        public static DateTimeOffset MinSqlDateTime2(this DateTimeOffset dt)
        {
            return new DateTimeOffset(1, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
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

        public static DateTime MaxSqlDateTime2(this DateTime dt)
        {
            return new DateTime(9999, 12, 31, 23, 59, 59, 9999999);
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

        public static DateTime DateOnly(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day);
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

        public static DateTime StartOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1, 0, 0, 0);
        }

        public static DateTimeOffset StartOfMonth(this DateTimeOffset dt)
        {
            return new DateTimeOffset(dt.Year, dt.Month, 1, 0, 0, 0, TimeSpan.Zero);
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

        public static DateTime EndOfMonth(this DateTime dt)
        {
            return dt.StartOfMonth().AddMonths(1) - new TimeSpan(0, 0, 0, 0, 1);
        }

        public static DateTimeOffset EndOfMonth(this DateTimeOffset dt)
        {
            return dt.StartOfMonth().AddMonths(1) - new TimeSpan(0, 0, 0, 0, 1);
        }


        public static DateTime StartOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1, 0, 0, 0);
        }

        public static DateTimeOffset StartOfYear(this DateTimeOffset dt)
        {
            return new DateTimeOffset(dt.Year, 1, 1, 0, 0, 0, TimeSpan.Zero);
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

        public static DateTime EndOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 12, 31, 23, 59, 59, 999);
        }

        public static DateTimeOffset EndOfYear(this DateTimeOffset dt)
        {
            return new DateTimeOffset(dt.Year, 12, 31, 23, 59, 59, TimeSpan.Zero);
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that returns the start of the day. </summary>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ///=================================================================================================

        public static DateTime StartOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A DateTimeOffset extension method that returns the end of the day. </summary>
        ///
        /// <param name="dt">   The dt to act on. </param>
        ///
        /// <returns>   A DateTimeOffset. </returns>
        ///=================================================================================================

        public static DateTime EndOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
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

        public static int DayOfWeekNumber(this DateTime dt)
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

        static int GetWeekOfYear(this DateTime time)
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

        public static int WeekOfMonth(this DateTime dt)
        {
            DateTime first = new DateTime(dt.Year, dt.Month, 1);
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

        public static bool IsWithinTheNextYear(this DateTime dt)
        {
            return dt >= DateTime.Today && dt < DateTime.Now.AddYears(1);
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

        public static IEnumerable<DateTime> GetFirstOfEachMonthForNextYear(this DateTime dt)
        {
            var now = DateTime.Now;
            var results = new List<DateTime>();
            for (int x = 0; x < 12; x++)
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

        public static IEnumerable<DateTime> GetAllDayOfWeekDatesInMonth(this DateTime dt, DayOfWeek dayOfWeek)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(dt.Year, dt.Month))  // Days: 1, 2 ... 31 etc.
                .Select(day => new DateTime(dt.Year, dt.Month, day)) // Map each day to a date
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

        public static long UnixTimestampFromDateTime(this DateTime date)
        {
            long unixTimestamp = date.Ticks - new DateTime(1970, 1, 1).Ticks;
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

        private static DateTime TimeFromUnixTimestamp(this int unixTimestamp)
        {
            DateTime unixYear0 = new DateTime(1970, 1, 1);
            long unixTimeStampInTicks = unixTimestamp * TimeSpan.TicksPerSecond;
            DateTime dtUnix = new DateTime(unixYear0.Ticks + unixTimeStampInTicks);
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
            if (string.IsNullOrEmpty(timeZoneId))
                return value;
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, timeZoneId);
        }

        public static string ToMonthName(this DateTimeOffset dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public static string ToShortMonthName(this DateTimeOffset dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }

        public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime, string timeZoneId)
        {
            var result = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, timeZoneId);
            return result;
        }

        public static DateTimeOffset ToDateTimeOffset(string sValue)
        {
            var dto = DateTimeOffset.MinValue;
            if ( string.IsNullOrEmpty(sValue))
                return dto;
            if (DateTimeOffset.TryParse(sValue, out dto))
                return dto;
            return dto;
        }

        public static DateTimeOffset ToDateTimeOffset(object o)
        {
            var dto = DateTimeOffset.MinValue;
            if (o == null)
                return dto;
            var sValue = o.ToString();
            if (string.IsNullOrEmpty(sValue))
                return dto;
            if (DateTimeOffset.TryParse(sValue, out dto))
                return dto;
            return dto;
        }

        public static DateTimeOffset Today(this DateTimeOffset dateTime)
        {
            return new DateTimeOffset(DateTime.Now.DateOnly());
        }


        public static bool IsValueNotEquivalentToSqlNull(this DateTimeOffset? o)
        {
            if( o == null )
                return false;
            if (o.Value <= o.Value.MinSqlDateTime())
                return false;
            return true;
        }

        public static bool IsValueNotEquivalentToSqlNull(this DateTimeOffset o)
        {
            if (o <= o.MinSqlDateTime())
                return false;
            return true;
        }


        public static bool IsValueNotEquivalentToSqlNull(this DateTime? o)
        {
            if (o == null)
                return false;
            if (o.Value <= o.Value.MinSqlDateTime())
                return false;
            return true;
        }

        public static bool IsValueNotEquivalentToSqlNull(this DateTime o)
        {
            if (o <= o.MinSqlDateTime())
                return false;
            return true;
        }

    }
}
