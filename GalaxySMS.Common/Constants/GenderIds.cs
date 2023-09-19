////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GenderIds.cs
//
// summary:	Implements the gender identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A gender identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GenderIds
    {
        /// <summary>   The male. </summary>
        public static readonly Guid Male = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The female. </summary>
        public static readonly Guid Female = new Guid("00000000-0000-0000-0000-000000000002");
    }
}
