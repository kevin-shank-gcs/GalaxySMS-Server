////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\CredentialUsageCountLimits.cs
//
// summary:	Implements the credential usage count limits class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential usage count limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CredentialUsageCountLimits
    {
        /// <summary>   The minimum. </summary>
        public const short Minimum = 0;
        /// <summary>   The maximum. </summary>
        public const short Maximum = 255;
    }
}
