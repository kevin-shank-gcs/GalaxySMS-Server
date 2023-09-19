////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\EntityPermissionLevelIds.cs
//
// summary:	Implements the entity permission level identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An entity permission level identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class EntityPermissionLevelIds
    {
        /// <summary>   Identifier for the permission level none. </summary>
        public static readonly Guid PermissionLevel_None_Id = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   Identifier for the permission level view only. </summary>
        public static readonly Guid PermissionLevel_ViewOnly_Id = new Guid("00000000-0000-0000-0000-000000000002");
        //public static readonly Guid PermissionLevel_ViewEdit_Id = new Guid("BFF20CB5-9220-4B03-803E-2CC425FDF114");
        //public static readonly Guid PermissionLevel_ViewEditDelete_Id = new Guid("82CA3F23-ACB4-491D-96E1-CFA9DB2F606F");
    }
}
