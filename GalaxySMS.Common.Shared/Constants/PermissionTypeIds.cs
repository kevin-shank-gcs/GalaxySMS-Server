////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\PermissionTypeIds.cs
//
// summary:	Implements the permission type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A permission type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PermissionTypeIds
    {
        /// <summary>   Identifier for the execute. </summary>
        public static readonly Guid ExecuteId = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   Identifier for the view. </summary>
        public static readonly Guid ViewId = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   Identifier for the add. </summary>
        public static readonly Guid AddId = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   Identifier for the edit update. </summary>
        public static readonly Guid EditUpdateId = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   Identifier for the delete. </summary>
        public static readonly Guid DeleteId = new Guid("00000000-0000-0000-0000-000000000005");
        /// <summary>   Identifier for the view property. </summary>
        public static readonly Guid ViewPropertyId = new Guid("00000000-0000-0000-0000-000000000006");
        /// <summary>   Identifier for the edit property. </summary>
        public static readonly Guid EditPropertyId = new Guid("00000000-0000-0000-0000-000000000007");
    }
}
