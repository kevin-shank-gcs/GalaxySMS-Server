////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\BadgeSystemTypeIds.cs
//
// summary:	Implements the badge system type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A badge system type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class BadgeSystemTypeIds
    {
        /// <summary>   The none. </summary>
        public static readonly Guid None = Guid.Empty;
        /// <summary>   The identifier producer. </summary>
        public static readonly Guid IdProducer = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The card exchange. </summary>
        public static readonly Guid CardExchange = new Guid("00000000-0000-0000-0000-000000000002");
    }
}
