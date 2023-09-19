////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\InputCommandIds.cs
//
// summary:	Implements the input command identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input command identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class InputCommandIds
    {
        /// <summary>   The enable. </summary>
        public static readonly Guid Enable = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The disable. </summary>
        public static readonly Guid Disable = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The shunt. </summary>
        public static readonly Guid Shunt = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The unshunt. </summary>
        public static readonly Guid Unshunt = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   The request status. </summary>
        public static readonly Guid RequestStatus = new Guid("00000000-0000-0000-0000-000000000009");
    }
}
