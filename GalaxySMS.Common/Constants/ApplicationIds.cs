////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\ApplicationIds.cs
//
// summary:	Implements the application identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An application identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ApplicationIds
    {
        /// <summary>   Identifier for the galaxy SMS admin. </summary>
        public static readonly Guid GalaxySMS_Admin_Id = new Guid("FB5E8579-2F9B-4421-89BD-496F1EF93C64");
        /// <summary>   Identifier for the galaxy SMS web. </summary>
        public static readonly Guid GalaxySMS_Web_Id = new Guid("7C7A2E36-24F3-420C-A21F-94FCCCE5063D");
        /// <summary>   Identifier for the galaxy SMS site manager. </summary>
        public static readonly Guid GalaxySMS_SiteManager_Id = new Guid("ADD42BA3-7239-4C4B-B46B-339826DCA4D6");
        /// <summary>   Identifier for the galaxy SMS personnel manager. </summary>
        public static readonly Guid GalaxySMS_PersonnelManager_Id = new Guid("C2044707-BC0A-4199-BCA4-435B40A8585D");
        /// <summary>   Identifier for the galaxy SMS facility manager. </summary>
        public static readonly Guid GalaxySMS_FacilityManager_Id = new Guid("49DAB866-CCEF-40B5-8CA7-AA32BC79B53A");
    }
}
