using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Managers
{
    public static class MessageBrokerMessageNames
    {
        public const string SendClusterSettingsToHardware = "SendClusterSettingsToHardware";
        public const string SendAccessPortalSettingsToHardware = "SendAccessPortalSettingsToHardware";
        public const string SendInterfaceBoardSectionDataToHardware = "SendInterfaceBoardSectionDataToHardware";
        public const string SendSavedDateTypeDataToHardware = "SendSavedDateTypeDataToHardware";
        public const string SendDateTypeDataToClusters = "SendDateTypeDataToClusters";
        public const string SendAccessGroupSettingsToHardware = "SendAccessGroupSettingsToHardware";
        public const string SendTimeScheduleToHardware = "SendTimeScheduleToHardware";
        public const string SendGalaxyTimePeriodToHardware = "SendGalaxyTimePeriodToHardware";
        public const string SendPersonCredentialDataToHardware = "SendPersonCredentialDataToHardware";
        public const string SendInputOutputGroupToHardware = "SendInputOutputGroupToHardware";
        public const string SendCpuCommandToHardware = "SendCpuCommandToHardware";
        public const string SendClusterCommandToHardware = "SendClusterCommandToHardware";
        public const string SendAccessPortalCommandToHardware = "SendAccessPortalCommandToHardware";
        public const string SendInputDeviceCommandToHardware = "SendInputDeviceCommandToHardware";
        public const string SendInputOutputGroupCommandToHardware = "SendInputOutputGroupCommandToHardware";
        public const string SendGalaxyFlashCommandToHardware = "SendGalaxyFlashCommandToHardware";
        public const string SendPanelAlarmsToHardware = "SendPanelAlarmsToHardware";
        public const string SendAllTimeSchedulesToHardware = "SendAllTimeSchedulesToHardware";
        public const string SendAllCredentialDataToHardware = "SendAllCredentialDataToHardware";
        public const string SendCredentialChangesToHardware = "SendCredentialChangesToHardware";
        public const string SendAllClusterInputOutputGroupsToHardware = "SendAllClusterInputOutputGroupsToHardware";
        public const string SendAccessPortalsToHardware = "SendAccessPortalsToHardware";
        public const string SendInputOutputDevicesToHardware = "SendInputOutputDevicesToHardware";
        public const string SendDeletedCredentialsToHardware = "SendDeletedCredentialsToHardware";
        public const string GalaxyCpuDatabaseInformationSaved = "GalaxyCpuDatabaseInformationSaved";
        public const string SendGalaxyInterfaceBoardSectionCommandToHardware = "SendGalaxyInterfaceBoardSectionCommandToHardware";
        public const string SendInputDeviceSettingsToHardware = "SendInputDeviceSettingsToHardware";
        public const string SendOutputDeviceCommandToHardware = "SendOutputDeviceCommandToHardware";
        public const string SendOutputDeviceSettingsToHardware = "SendOutputDeviceSettingsToHardware";

        public const string SendRefreshGalaxyPanelDataFromDb = "SendRefreshGalaxyPanelDataFromDb";
        public const string ClusterAddressChanged = "ClusterAddressChanged";
        public const string PanelAddressChanged = "PanelAddressChanged";
        public const string ClusterTimeZoneChanged = "ClusterTimeZoneChanged";

        public const string NewClusterSaved = "NewClusterSaved";
        public const string NewPanelSaved = "NewPanelSaved";

        public const string ClusterDeleted = "ClusterDeleted";
        public const string PanelDeleted = "PanelDeleted";

        //public const string SendLoadDataFinished = "SendLoadDataFinished";

    }
}

