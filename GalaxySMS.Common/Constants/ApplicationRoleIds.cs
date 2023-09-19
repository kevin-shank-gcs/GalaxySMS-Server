////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\ApplicationRoleIds.cs
//
// summary:	Implements the application role identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An application role identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ApplicationRoleIds
    {
        /// <summary>   Identifier for the galaxy SMS admin administator. </summary>
        public static readonly Guid GalaxySMS_Admin_AdministatorId = new Guid("DF66596A-9582-4099-9B5F-4B57F7B26A6A");
        /// <summary>   Identifier for the galaxy SMS facility manager administator. </summary>
        public static readonly Guid GalaxySMS_FacilityManager_AdministatorId = new Guid("290113AE-C956-462E-A01B-474F536722BB");
        /// <summary>   Identifier for the galaxy SMS site manager administator. </summary>
        public static readonly Guid GalaxySMS_SiteManager_AdministatorId = new Guid("8DC77008-3277-4B59-B369-9EE64909C00D");
        /// <summary>   Identifier for the galaxy SMS personnel manager administrator. </summary>
        public static readonly Guid GalaxySMS_PersonnelManager_AdministratorId = new Guid("7F322692-2943-4549-BC35-A39A7339994E");
    }
}

