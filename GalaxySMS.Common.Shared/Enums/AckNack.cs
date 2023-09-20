////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AckNack.cs
//
// summary:	Implements the acknowledge nack class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent Acknowledge nacks. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum AckNack
	{
        /// <summary>   An enum constant representing the unknown option. </summary>
		Unknown = 0,
        /// <summary>   An enum constant representing the Acknowledge option. </summary>
		Ack = 3,
        /// <summary>   An enum constant representing the nack option. </summary>
		Nack = 4
	}
}
