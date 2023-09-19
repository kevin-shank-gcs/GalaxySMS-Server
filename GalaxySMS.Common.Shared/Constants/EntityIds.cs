////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\EntityIds.cs
//
// summary:	Implements the entity identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An entity identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class EntityIds
    {
        /// <summary>   Identifier for the galaxy SMS default entity. </summary>
        public static readonly Guid GalaxySMS_DefaultEntity_Id = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   Identifier for the galaxy SMS system entity. </summary>
        public static readonly Guid GalaxySMS_SystemEntity_Id = new Guid("00000000-0000-0000-0000-000000000001");
    }

    public class EntityTypes
    {
        public static readonly string Reserved = "reserved";
        public static readonly string Administrator = "administrator";
        public static readonly string Customer = "customer";
        public static readonly string Location = "location";
        public static readonly string EnterpriseCustomer = "enterprise_customer";
        public static readonly string Dealer = "dealer";
    }
}
