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
        public static readonly Guid GalaxySMS_DefaultApp_Id = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   Identifier for the galaxy SMS admin. </summary>
        public static readonly Guid GalaxySMS_Admin_Id = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   Identifier for the galaxy SMS facility manager. </summary>
        public static readonly Guid GalaxySMS_FacilityManager_Id = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   Identifier for the galaxy SMS monitoring manager. </summary>
        public static readonly Guid GalaxySMS_MonitoringManager_Id = new Guid("00000000-0000-0000-0000-000000000004");
        ///// <summary>   Identifier for the galaxy SMS web. </summary>
        //public static readonly Guid GalaxySMS_Web_Id = new Guid("7C7A2E36-24F3-420C-A21F-94FCCCE5063D");
        ///// <summary>   Identifier for the galaxy SMS site manager. </summary>
        //public static readonly Guid GalaxySMS_SiteManager_Id = new Guid("ADD42BA3-7239-4C4B-B46B-339826DCA4D6");
        ///// <summary>   Identifier for the galaxy SMS personnel manager. </summary>
        //public static readonly Guid GalaxySMS_PersonnelManager_Id = new Guid("C2044707-BC0A-4199-BCA4-435B40A8585D");
    }

    public class ApplicationNames
    {
        public static readonly string GalaxySMS = "GalaxySMS";
        public static readonly string GalaxySMS_Admin = "GalaxySMS.Admin";
        public static readonly string GalaxySMS_FacilityManager = "GalaxySMS.FacilityManager";
        public static readonly string GalaxySMS_MonitoringManager = "GalaxySMS.MonitoringManager";
    }

    public class ApplicationDescriptions
    {
        public static readonly string GalaxySMS = "Galaxy Security Management System";
        public static readonly string GalaxySMS_Admin = "Administrative application for the GalaxySMS system.";
        public static readonly string GalaxySMS_FacilityManager = "Application to manage Galaxy SMS data";
        public static readonly string GalaxySMS_MonitoringManager = "Application to monitor events and activity.";
    }
}
