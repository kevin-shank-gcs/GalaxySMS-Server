////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\UserDefinedPropertyTypeIds.cs
//
// summary:	Implements the user defined property type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user defined property type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UserDefinedPropertyTypeIds
    {
        /// <summary>   The text. </summary>
        public static readonly Guid Text = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   Number of. </summary>
        public static readonly Guid Number = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The boolean. </summary>
        public static readonly Guid Boolean = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The date. </summary>
        public static readonly Guid Date = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   The list. </summary>
        public static readonly Guid List = new Guid("00000000-0000-0000-0000-000000000005");
        /// <summary>   Unique identifier. </summary>
        public static readonly Guid Guid = new Guid("00000000-0000-0000-0000-000000000006");
    }

}
