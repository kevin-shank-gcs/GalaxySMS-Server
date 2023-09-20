////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GetOptions.cs
//
// summary:	Implements the get options class
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A get options. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetOptions
    {
        /// <summary>   The build tree structure. </summary>
        public const string BuildTreeStructure = "BuildTreeStructure";

        /// <summary>   The include no selection entry. </summary>
        public const string IncludeNoSelectionEntry = "IncludeNoSelectionEntry";

        /// <summary>   The include active only. </summary>
        public const string IncludeActiveOnly = "IncludeActiveOnly";

        /// <summary>   The enforce permissions. </summary>
        public const string EnforcePermissions = "EnforcePermissions";

        /// <summary>   Name of the include device. </summary>
        public const string IncludeDeviceName = "IncludeDeviceName";

        /// <summary>   The include counts. </summary>
        public const string IncludeCounts = "IncludeCounts";

        /// <summary>   Include region site hierachy. </summary>
        public const string IncludeRegionSiteHierachy = "IncludeRegionSiteHierachy";
    }

    public class GetOptions_AccessGroup
    {
        public const string IncludeSystemAccessGroups = "IncludeSystemAccessGroups";
        public const string IncludePersonLastAccessInfo = "IncludePersonLastAccessInfo";
        public const string IncludeAllAccessPortals = "IncludeAllAccessPortals";
    }

    public class GetOptions_AccessProfile
    {
        public const string OmitNone = "OmitNone";
    }

    public class GetOptions_DayType
    {
        public const string IsActive = "IsActive";
    }

    public class GetOptions_Entity
    {
        public const string IgnoreCurrentEntity = "IgnoreCurrentEntity";
    }

    public class GetOptions_TimeSchedule
    {

        public const string IncludeBlankSchedule = "IncludeBlankSchedule";
    }

    /// <summary>   A get options for access portals. </summary>
    public class GetOptions_AccessPortal
    {

        /// <summary>   The is node active. </summary>
        public const string IsNodeActive = "IsNodeActive";
        public const string SearchIncludesComments = "SearchIncludesComments";
        public const string IncludeLastAccessInfo = "IncludeLastAccessInfo";
    }

    /// <summary>   A get options for input devices. </summary>
    public class GetOptions_InputDevice
    {

        /// <summary>   The is node active. </summary>
        public const string IsNodeActive = "IsNodeActive";
        public const string SearchIncludesComments = "SearchIncludesComments";
    }

    /// <summary>   A get options for input devices. </summary>
    public class GetOptions_OutputDevice
    {

        /// <summary>   The is node active. </summary>
        public const string IsNodeActive = "IsNodeActive";
        public const string SearchIncludesComments = "SearchIncludesComments";
    }

    public class GetOptions_UserEditorData
    {
        public const string ExcludeNotAuthorizedRoles = "ExcludeNotAuthorizedRoles";
        public const string ExcludeNotAuthorizedApplications = "ExcludeNotAuthorizedApplications";
        public const string ApplicationId = "ApplicationId";
    }

    public class GetOptions_ActivityHistoryEvents
    {
        public const string GetFromFlatTables = "GetFromFlatTables";
    }
}
