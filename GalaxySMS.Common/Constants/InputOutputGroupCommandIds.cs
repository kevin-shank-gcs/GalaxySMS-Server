////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\InputOutputGroupCommandIds.cs
//
// summary:	Implements the input output group command identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input output group command identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class InputOutputGroupCommandIds
    {
        /// <summary>   The arm. </summary>
        public static readonly Guid Arm = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The disarm. </summary>
        public static readonly Guid Disarm = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The shunt. </summary>
        public static readonly Guid Shunt = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The unshunt. </summary>
        public static readonly Guid Unshunt = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   The unlock access portals. </summary>
        public static readonly Guid UnlockAccessPortals = new Guid("00000000-0000-0000-0000-000000000005");
        /// <summary>   The lock access portals. </summary>
        public static readonly Guid LockAccessPortals = new Guid("00000000-0000-0000-0000-000000000006");
        /// <summary>   The enable access portals. </summary>
        public static readonly Guid EnableAccessPortals = new Guid("00000000-0000-0000-0000-000000000007");
        /// <summary>   The disable access portals. </summary>
        public static readonly Guid DisableAccessPortals = new Guid("00000000-0000-0000-0000-000000000008");
    }

}
