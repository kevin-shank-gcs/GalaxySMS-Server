////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\SearchType.cs
//
// summary:	Implements the search type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent text search types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum TextSearchType:short
    {
        /// <summary>   An enum constant representing the equals option. </summary>
        Equals = 0,
        /// <summary>   An enum constant representing the starts with option. </summary>
        StartsWith = 1,
        /// <summary>   An enum constant representing the contains option. </summary>
        Contains = 2
    }
}
