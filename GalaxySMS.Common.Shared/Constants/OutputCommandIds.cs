////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\OutputCommandIds.cs
//
// summary:	Implements the output command identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An output command identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class OutputCommandIds
    {
        /// <summary>   The on. </summary>
        public static readonly Guid On = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The off. </summary>
        public static readonly Guid Off = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The enable. </summary>
        public static readonly Guid Enable = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   The disable. </summary>
        public static readonly Guid Disable = new Guid("00000000-0000-0000-0000-000000000005");
        /// <summary>   The request status. </summary>
        public static readonly Guid RequestStatus = new Guid("00000000-0000-0000-0000-000000000009");
    }
}
