////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\GuidUtilities.cs
//
// summary:	Implements the unique identifier utilities class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A unique identifier utilities. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class GuidUtilities
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Generates a comb. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The comb. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Guid GenerateComb()
        {
            byte[] guidArray = Guid.NewGuid().ToByteArray();

            DateTimeOffset baseDate = new DateTimeOffset(1900, 1, 1);
            DateTimeOffset now = DateTimeOffset.Now;

            // Get the days and milliseconds which will be used to build the byte string 
            TimeSpan days = new TimeSpan(now.Ticks - baseDate.Ticks);
            TimeSpan msecs = now.TimeOfDay;

            // Convert to a byte array 
            // Note that SQL Server is accurate to 1/300th of a millisecond so we divide by 3.333333 
            byte[] daysArray = BitConverter.GetBytes(days.Days);
            byte[] msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));

            // Reverse the bytes to match SQL Servers ordering 
            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            // Copy the bytes into the guid 
            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

            return new Guid(guidArray);
        }
    }
}
