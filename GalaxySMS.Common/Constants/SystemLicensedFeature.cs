////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\SystemLicensedFeature.cs
//
// summary:	Implements the system licensed feature class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent license types. </summary>
    ///
    /// <remarks>   Kevin, 6/19/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum LicenseType
    {
        /// <summary>For trial or demo use</summary>
        Trial = 1,
        /// <summary>Standard license</summary>
        Standard = 2,
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent licensed feature keys. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum LicenseFeatureKey
    {
        /// <summary>   An enum constant representing the server thumb print option. </summary>
        ServerThumbPrint,
        /// <summary>   An enum constant representing the server system number option. </summary>
        ServerSystemNumber,
        /// <summary>   An enum constant representing the software license key option. </summary>
        SoftwareLicenseKey,
        /// <summary>   An enum constant representing the product level option. </summary>
        ProductLevel,
        /// <summary>   An enum constant representing the version option. </summary>
        Version,
        /// <summary>   An enum constant representing the maximum clients option. </summary>
        MaximumClients,
        /// <summary>   An enum constant representing the maximum access portals option. </summary>
        MaximumAccessPortals,
        /// <summary>   An enum constant representing the maximum input devices option. </summary>
        MaximumInputDevices,
        /// <summary>   An enum constant representing the maximum dsi access portals option. </summary>
        MaximumDsiAccessPortals,
        /// <summary>   An enum constant representing the can upgrade versions option. </summary>
        CanUpgradeVersions,
        /// <summary>   An enum constant representing the biometric morpho manger option. </summary>
        BiometricMorphoManger,
        /// <summary>   An enum constant representing the biometric invixium ixm web option. </summary>
        BiometricInvixiumIXMWeb,
        /// <summary>  An enum constant representing the badging system Identifier producer option. </summary>
        BadgingSystemIdProducer,
        /// <summary>   An enum constant representing the galaxy vms option. </summary>
        GalaxyVms,
        /// <summary>   An enum constant representing the vms API option. </summary>
        VmsApi,
        /// <summary>   An enum constant representing the vms system limit option. </summary>
        VmsSystemLimit,
        /// <summary>   An enum constant representing the time attendance option. </summary>
        TimeAttendance,
        /// <summary>   An enum constant representing the import export option. </summary>
        ImportExport,
        /// <summary>   An enum constant representing the event log distribution option. </summary>
        EventLogDistribution,
        /// <summary>   An enum constant representing the user status option. </summary>
        UserStatus,
        /// <summary>   An enum constant representing the guard tour option. </summary>
        GuardTour,
        /// <summary>   An enum constant representing the alarm panel integration option. </summary>
        AlarmPanelIntegration,
        /// <summary>   An enum constant representing the passback door groups option. </summary>
        Passback,
        /// <summary>   An enum constant representing the door groups option. </summary>
        DoorGroups,
        /// <summary>   An enum constant representing the graphic device status option. </summary>
        GraphicDeviceStatus,
        /// <summary>   An enum constant representing the unlimited credential capability option. </summary>
        UnlimitedCredentialCapability,
        /// <summary>   An enum constant representing the access rule override option. </summary>
        AccessRuleOverride,
        /// <summary>   An enum constant representing the API access option. </summary>
        ApiAccess,
        /// <summary>   An enum constant representing the API can get person data option. </summary>
        ApiCanGetPersonData,
        /// <summary>   An enum constant representing the API can post person data option. </summary>
        ApiCanPostPersonData,
        /// <summary>   An enum constant representing the API can put person data option. </summary>
        ApiCanPutPersonData,
        /// <summary>   An enum constant representing the API can delete person data option. </summary>
        ApiCanDeletePersonData,
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent licensed attribute keys. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum LicenseAttributeKey
    {
        Attribute1,
        Attribute2,
    }

    public enum EntityLicenseFeatureKey
    {
        BadgingSystemType,
        BiometricSystemType,
    }
    public enum EntityLicenseAttributeKey
    {
        Attribute1,
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent product levels. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum ProductLevel
    {
        /// <summary>   An enum constant representing the professional option. </summary>
        Professional,
        /// <summary>   An enum constant representing the corporate option. </summary>
        Corporate,
        /// <summary>   An enum constant representing the enterprise option. </summary>
        Enterprise
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A default trial license values. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DefaultTrialLicenseValues
    {
        /// <summary>   The valid for in days. </summary>
        public const int ValidForDays = 30;
        /// <summary>   The maximum clients. </summary>
        public const int MaximumClients = 2;
        /// <summary>   The maximum access portals. </summary>
        public const int MaximumAccessPortals = 16;
        /// <summary>   The maximum dsi access portals. </summary>
        public const int MaximumDsiAccessPortals = 16;
        /// <summary>   The maximum input devices. </summary>
        public const int MaximumInputDevices = 32;
        /// <summary>   The vms system limit. </summary>
        public const int VmsSystemLimit = 5;
        /// <summary>   The can upgrade versions. </summary>
        public const bool CanUpgradeVersions = false;
        /// <summary>   The biometric morpho manger. </summary>
        public const bool BiometricMorphoManger = false;
        /// <summary>   The biometric invixium ixm web. </summary>
        public const bool BiometricInvixiumIXMWeb = false;
        /// <summary>   The badging system identifier producer. </summary>
        public const bool BadgingSystemIdProducer = false;
        /// <summary>   The galaxy vms. </summary>
        public const bool GalaxyVms = false;
        /// <summary>   The vms API. </summary>
        public const bool VmsApi = false;
        /// <summary>   The time attendance. </summary>
        public const bool TimeAttendance = false;
        /// <summary>   The import export. </summary>
        public const bool ImportExport = false;
        /// <summary>   The event log distribution. </summary>
        public const bool EventLogDistribution = false;
        /// <summary>   The user status. </summary>
        public const bool UserStatus = false;
        /// <summary>   The guard tour. </summary>
        public const bool GuardTour = false;
        /// <summary>   The alarm panel integration. </summary>
        public const bool AlarmPanelIntegration = false;
        /// <summary>   The passback. </summary>
        public const bool Passback = false;
        /// <summary>   Groups the door belongs to. </summary>
        public const bool DoorGroups = false;
        /// <summary>   The graphic device status. </summary>
        public const bool GraphicDeviceStatus = false;
        /// <summary>   The unlimited credential capability. </summary>
        public const bool UnlimitedCredentialCapability = false;
        /// <summary>   The access rule override. </summary>
        public const bool AccessRuleOverride = false;
        /// <summary>   The API access. </summary>
        public const bool ApiAccess = false;
        /// <summary>   Information describing the API can get person. </summary>
        public const bool ApiCanGetPersonData = false;
        /// <summary>   Information describing the API can post person. </summary>
        public const bool ApiCanPostPersonData = false;
        /// <summary>   Information describing the API can put person. </summary>
        public const bool ApiCanPutPersonData = false;
        /// <summary>   Information describing the API can delete person. </summary>
        public const bool ApiCanDeletePersonData = false;
    }
}
