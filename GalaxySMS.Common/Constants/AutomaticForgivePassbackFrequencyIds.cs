////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AutomaticForgivePassbackFrequencyIds.cs
//
// summary:	Implements the automatic forgive passback frequency identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An automatic forgive passback frequency identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AutomaticForgivePassbackFrequencyIds
    {
        /// <summary>   The never. </summary>
        public static readonly Guid Never = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The once per day. </summary>
        public static readonly Guid OncePerDay = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The twice per day. </summary>
        public static readonly Guid TwicePerDay = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The four times per day. </summary>
        public static readonly Guid FourTimesPerDay = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   The every two in hours. </summary>
        public static readonly Guid EveryTwoHours = new Guid("00000000-0000-0000-0000-000000000005");
        /// <summary>   The every hour. </summary>
        public static readonly Guid EveryHour = new Guid("00000000-0000-0000-0000-000000000006");
        /// <summary>   The every thirty in minutes. </summary>
        public static readonly Guid EveryThirtyMinutes = new Guid("00000000-0000-0000-0000-000000000007");
    }
}

