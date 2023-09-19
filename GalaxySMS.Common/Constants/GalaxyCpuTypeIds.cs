﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyCpuTypeIds.cs
//
// summary:	Implements the galaxy CPU type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyCpuTypeIds
    {
        /// <summary>   The galaxy CPU type 600. </summary>
        public static readonly Guid GalaxyCpuType_600 = new Guid("00000000-0000-0000-0000-000000000258");
        /// <summary>   The fifth galaxy CPU type 63. </summary>
        public static readonly Guid GalaxyCpuType_635 = new Guid("00000000-0000-0000-0000-00000000027B");
        /// <summary>   The galaxy CPU type 500. </summary>
        public static readonly Guid GalaxyCpuType_500 = new Guid("00000000-0000-0000-0000-0000000001F4");
    }
}
