////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\PersonActiveStatusTypeIds.cs
//
// summary:	Implements the person active status type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person active status type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PersonActiveStatusTypeIds
    {
        /// <summary>   The active. </summary>
        public static readonly Guid Active = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The inactive. </summary>
        public static readonly Guid Inactive = new Guid("00000000-0000-0000-0000-000000000002");
        //public static readonly Guid PersonActiveStatusType_Suspended = new Guid("00000000-0000-0000-0000-000000000003");
        //public static readonly Guid PersonActiveStatusType_Leave = new Guid("00000000-0000-0000-0000-000000000003");
    }
}
