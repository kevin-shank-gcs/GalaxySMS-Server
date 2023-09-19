////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\StringEncodingFormat.cs
//
// summary:	Implements the string encoding format class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent string encoding formats. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum StringEncodingFormat
	{
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the hexadecimal option. </summary>
		Hexadecimal,
        /// <summary>   An enum constant representing the base 64 string option. </summary>
		Base64String
	}
}
