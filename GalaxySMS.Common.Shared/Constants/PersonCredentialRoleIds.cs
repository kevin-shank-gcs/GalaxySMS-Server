////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessProfileIds.cs
//
// summary:	Implements the access profile identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access profile identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PersonCredentialRoleIds
    {

        /// <summary>   The access control role. </summary>
        public static readonly Guid AccessControl = new Guid("00000000-0000-0000-0000-000000000001");

        /// <summary>   The alarm control role. </summary>
        public static readonly Guid AlarmControl = new Guid("00000000-0000-0000-0000-000000000002");
    }




}
