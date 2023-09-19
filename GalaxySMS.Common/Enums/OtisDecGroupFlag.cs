////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\OtisDecGroupFlag.cs
//
// summary:	Implements the otis decrement group flag class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A bit-field of flags for specifying otis Decrement group flags. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[Flags]
	public enum OtisDecGroupFlag
	{
        /// <summary>   A binary constant representing the block 0 flag. </summary>
		Block0,
        /// <summary>   A binary constant representing the block 1 flag. </summary>
		Block1,
        /// <summary>   A binary constant representing the block 2 flag. </summary>
		Block2,
        /// <summary>   A binary constant representing the block 3 flag. </summary>
		Block3,
        /// <summary>   A binary constant representing the block 4 flag. </summary>
		Block4,
        /// <summary>   A binary constant representing the block 5 flag. </summary>
		Block5,
        /// <summary>   A binary constant representing the block 6 flag. </summary>
		Block6,
        /// <summary>   A binary constant representing the block 7 flag. </summary>
		Block7,
        /// <summary>   A binary constant representing the block 8 flag. </summary>
		Block8,
        /// <summary>   A binary constant representing the block 9 flag. </summary>
		Block9,
        /// <summary>   A binary constant representing the block 10 flag. </summary>
		Block10,
        /// <summary>   A binary constant representing all flag. </summary>
		All = Block0 | Block1 | Block2 | Block3 | Block4 | Block5 | Block6 | Block7 | Block8 | Block9 | Block10
	}
}
