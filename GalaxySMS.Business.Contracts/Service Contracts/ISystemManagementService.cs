using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using TimeScheduleType = GalaxySMS.Common.Enums.TimeScheduleType;

namespace GalaxySMS.Business.Contracts
{
    [ServiceContract]
    public interface ISystemManagementService
    {
        #region Region Operations
        [OperationContract]
        Region[] GetAllRegions(GetParametersWithPhoto parameters);

        [OperationContract]
        Region[] GetAllRegionsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllRegionsList(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllRegionsListEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Region GetRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Region SaveRegion(SaveParameters<Region> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteRegionByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteRegion(DeleteParameters<Region> parameters);

        [OperationContract]
        bool IsRegionReferenced(Guid uid);

        [OperationContract]
        bool IsRegionUnique(Region data);
        #endregion

        #region Site Operations
        [OperationContract]
        Site[] GetAllSites(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllSitesList(GetParametersWithPhoto parameters);

        [OperationContract]
        Site[] GetAllSitesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        Site[] GetAllSitesForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllSitesForEntityList(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllSitesForRegionList(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Site GetSite(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Site SaveSite(SaveParameters<Site> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteSiteByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteSite(DeleteParameters<Site> parameters);

        [OperationContract]
        bool IsSiteReferenced(Guid uid);

        [OperationContract]
        bool IsSiteUnique(Site data);
        #endregion

        #region TimeZone Operations
        [OperationContract]
        GalaxySMS.Business.Entities.TimeZone[] GetAllTimeZones(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxySMS.Business.Entities.TimeZone GetTimeZone(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxySMS.Business.Entities.TimeZone SaveTimeZone(SaveParameters<GalaxySMS.Business.Entities.TimeZone> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteTimeZoneByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteTimeZone(DeleteParameters<GalaxySMS.Business.Entities.TimeZone> parameters);

        [OperationContract]
        bool IsTimeZoneReferenced(Guid uid);

        [OperationContract]
        bool IsTimeZoneUnique(GalaxySMS.Business.Entities.TimeZone data);
        #endregion

        #region Seed Database
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool SeedDatabase(SaveParameters<SeedDatabaseRequest> parameters);
        #endregion

        #region Brand Operations
        [OperationContract]
        Brand[] GetAllBrands(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Brand GetBrand(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Brand SaveBrand(SaveParameters<Brand> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteBrandByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteBrand(DeleteParameters<Brand> parameters);

        [OperationContract]
        bool IsBrandReferenced(Guid uid);

        [OperationContract]
        bool IsBrandUnique(Brand data);
        #endregion

        #region Credential Reader Data Format Operations
        [OperationContract]
        CredentialReaderDataFormat[] GetAllCredentialReaderDataFormats(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderDataFormat GetCredentialReaderDataFormat(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderDataFormat SaveCredentialReaderDataFormat(SaveParameters<CredentialReaderDataFormat> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderDataFormatByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderDataFormat(DeleteParameters<CredentialReaderDataFormat> parameters);

        [OperationContract]
        bool IsCredentialReaderDataFormatReferenced(Guid uid);

        [OperationContract]
        bool IsCredentialReaderDataFormatUnique(CredentialReaderDataFormat data);
        #endregion

        #region Credential Reader Type Operations
        [OperationContract]
        CredentialReaderType[] GetAllCredentialReaderTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderType GetCredentialReaderType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderType SaveCredentialReaderType(SaveParameters<CredentialReaderType> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderTypeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderType(DeleteParameters<CredentialReaderType> parameters);

        [OperationContract]
        bool IsCredentialReaderTypeReferenced(Guid uid);

        [OperationContract]
        bool IsCredentialReaderTypeUnique(CredentialReaderType data);
        #endregion

        #region Feature Operations
        [OperationContract]
        Feature[] GetAllFeatures(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Feature GetFeature(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Feature SaveFeature(SaveParameters<Feature> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteFeatureByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteFeature(DeleteParameters<Feature> parameters);

        [OperationContract]
        bool IsFeatureReferenced(Guid uid);

        [OperationContract]
        bool IsFeatureUnique(Feature data);
        #endregion

        #region Feature Item Operations
        [OperationContract]
        FeatureItem[] GetAllFeatureItemsForFeature(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        FeatureItem GetFeatureItem(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        FeatureItem SaveFeatureItem(SaveParameters<FeatureItem> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteFeatureItemByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteFeatureItem(DeleteParameters<FeatureItem> parameters);

        [OperationContract]
        bool IsFeatureItemReferenced(Guid uid);

        [OperationContract]
        bool IsFeatureItemUnique(FeatureItem data);
        #endregion

        #region Credential Reader Type Feature Map Operations
        [OperationContract]
        CredentialReaderTypeFeatureMap[] GetAllCredentialReaderTypeFeatureMapForCredentialReaderType(GetParametersWithPhoto parameters);

        [OperationContract]
        CredentialReaderTypeFeatureMap[] GetAllCredentialReaderTypeFeatureMapForFeature(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderTypeFeatureMap GetCredentialReaderTypeFeatureMap(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderTypeFeatureMap SaveCredentialReaderTypeFeatureMap(SaveParameters<CredentialReaderTypeFeatureMap> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderTypeFeatureMapByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderTypeFeatureMap(DeleteParameters<CredentialReaderTypeFeatureMap> parameters);

        [OperationContract]
        bool IsCredentialReaderTypeFeatureMapReferenced(Guid uid);

        [OperationContract]
        bool IsCredentialReaderTypeFeatureMapUnique(CredentialReaderTypeFeatureMap data);
        #endregion

        #region AccessPortalType Operations
        [OperationContract]
        AccessPortalType[] GetAllAccessPortalTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessPortalType GetAccessPortalType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessPortalType SaveAccessPortalType(SaveParameters<AccessPortalType> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessPortalTypeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessPortalType(DeleteParameters<AccessPortalType> parameters);

        [OperationContract]
        bool IsAccessPortalTypeReferenced(Guid uid);

        [OperationContract]
        bool IsAccessPortalTypeUnique(AccessPortalType data);
        #endregion

        #region AccessPortal Operations
        [OperationContract]
        ArrayResponse<AccessPortal> GetAllAccessPortals(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortal> GetAccessPortalsByTextSearch(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortalListItemCommands> GetAccessPortalsListByTextSearch(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortal> GetAllAccessPortalsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortal> GetAllAccessPortalsForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortal> GetAllAccessPortalsForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortal> GetAllAccessPortalsForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortal> GetAllAccessPortalsForGalaxyPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForGalaxyPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessPortalListItem> GetAccessPortalListItemsForGalaxyPanel(GetParameters parameters);

        [OperationContract]
        AccessPortalListItem GetAccessPortalListItem(GetParameters parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessPortal GetAccessPortal(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessPortal SaveAccessPortal(SaveParameters<AccessPortal> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessPortalByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessPortal(DeleteParameters<AccessPortal> parameters);

        [OperationContract]
        bool IsAccessPortalReferenced(Guid uid);

        [OperationContract]
        bool IsAccessPortalUnique(AccessPortal data);

        [OperationContract]
        AccessPortalGalaxyCommonEditingData GetAccessPortalGalaxyCommonEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessPortalGalaxyPanelSpecificEditingData GetAccessPortalGalaxyPanelSpecificEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CommandResponse<AccessPortalCommandAction> ExecuteAccessPortalCommand(CommandParameters<AccessPortalCommandAction> parameters);
        //bool ExecuteAccessPortalCommand(CommandParameters<AccessPortalCommandAction> parameters);
        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetAccessPortalActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);
       
        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateAccessPortal(SaveParameters<AccessPortal> parameters);
        #endregion

        #region InputDevice Operations
        [OperationContract]
        ArrayResponse<InputDevice> GetAllInputDevices(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDevice> GetInputDevicesByTextSearch(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDeviceListItemCommands> GetInputDevicesListByTextSearch(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDevice> GetAllInputDevicesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesListForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDevice> GetAllInputDevicesForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesListForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDevice> GetAllInputDevicesForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesListForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDevice> GetAllInputDevicesForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesListForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDevice> GetAllInputDevicesForGalaxyPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesListForGalaxyPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputDeviceListItem> GetInputDeviceListItemsForGalaxyPanel(GetParameters parameters);

        [OperationContract]
        InputDeviceListItem GetInputDeviceListItem(GetParameters parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        InputDevice GetInputDevice(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        InputDevice SaveInputDevice(SaveParameters<InputDevice> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteInputDeviceByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteInputDevice(DeleteParameters<InputDevice> parameters);

        [OperationContract]
        bool IsInputDeviceReferenced(Guid uid);

        [OperationContract]
        bool IsInputDeviceUnique(InputDevice data);

        [OperationContract]
        InputDeviceGalaxyCommonEditingData GetInputDeviceGalaxyCommonEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        InputDeviceHardwareSpecificEditingData GetInputDeviceHardwareSpecificEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CommandResponse<InputDeviceCommandAction> ExecuteInputDeviceCommand(CommandParameters<InputDeviceCommandAction> parameters);

        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetInputDeviceActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);
        #endregion

        #region OutputDevice Operations
        [OperationContract]
        ArrayResponse<OutputDevice> GetAllOutputDevices(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDevice> GetOutputDevicesByTextSearch(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDeviceListItemCommands> GetOutputDevicesListByTextSearch(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDevice> GetAllOutputDevicesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesListForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDevice> GetAllOutputDevicesForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesListForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDevice> GetAllOutputDevicesForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesListForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDevice> GetAllOutputDevicesForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesListForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDevice> GetAllOutputDevicesForGalaxyPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesListForGalaxyPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<OutputDeviceListItem> GetOutputDeviceListItemsForGalaxyPanel(GetParameters parameters);

        [OperationContract]
        OutputDeviceListItem GetOutputDeviceListItem(GetParameters parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        OutputDevice GetOutputDevice(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        OutputDevice SaveOutputDevice(SaveParameters<OutputDevice> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteOutputDeviceByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteOutputDevice(DeleteParameters<OutputDevice> parameters);

        [OperationContract]
        bool IsOutputDeviceReferenced(Guid uid);

        [OperationContract]
        bool IsOutputDeviceUnique(OutputDevice data);

        [OperationContract]
        OutputDeviceGalaxyCommonEditingData GetOutputDeviceGalaxyCommonEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        OutputDeviceHardwareSpecificEditingData GetOutputDeviceHardwareSpecificEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CommandResponse<OutputDeviceCommandAction> ExecuteOutputDeviceCommand(CommandParameters<OutputDeviceCommandAction> parameters);

        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetOutputDeviceActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);

        #endregion

        #region Time Schedule Operations
        [OperationContract]
        ArrayResponse<TimeSchedule> GetAllTimeSchedules(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<TimeScheduleListItem> GetAllTimeSchedulesList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<TimeSchedule> GetAllTimeSchedulesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<TimeScheduleListItem> GetAllTimeSchedulesForEntityList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<TimeSchedule> GetAllTimeSchedulesForMappedEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<TimeSchedule> GetAllTimeSchedulesForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<TimeScheduleListItem> GetAllTimeSchedulesForClusterList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<TimeSchedule> GetAllTimeSchedulesForAssaAbloyDsr(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<TimeScheduleClusterItem> GetTimeScheduleClusterItems(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        TimeSchedule GetTimeSchedule(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        TimeSchedule SaveTimeSchedule(SaveParameters<TimeSchedule> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteTimeScheduleByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteTimeSchedule(DeleteParameters<TimeSchedule> parameters);

        [OperationContract]
        bool IsTimeScheduleReferenced(Guid uid);

        [OperationContract]
        bool IsTimeScheduleUnique(TimeSchedule data);

        [OperationContract]
        bool IsTimeScheduleActive(Guid timeScheduleUid, GalaxySMS.Common.Enums.TimeScheduleType scheduleType, Guid clusterUid, DateTimeOffset dateTime);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyClusterTimeScheduleMap SetTimeScheduleToClusterMapping(Guid timeScheduleUid, Guid clusterUid, bool isMapped, bool fifteenMinuteFormatUsesHolidays);
   
        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool CanTimeScheduleBeUnmappedFromCluster(Guid timeScheduleUid, Guid clusterUid);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool CanTimeScheduleBeDeleted(Guid timeScheduleUid);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        TimeScheduleUsageData GetTimeScheduleUsageInformation(Guid timeScheduleUid, Guid clusterUid);
        #endregion

        #region Time Period Operations
        [OperationContract]
        TimePeriod[] GetAllTimePeriods(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllTimePeriodsList(GetParametersWithPhoto parameters);

        [OperationContract]
        TimePeriod[] GetAllTimePeriodsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllTimePeriodsForEntityList(GetParametersWithPhoto parameters);


        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        TimePeriod GetTimePeriod(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        TimePeriod FindTimePeriodByTimes(GetParameters<TimePeriod> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        TimePeriod SaveTimePeriod(SaveParameters<TimePeriod> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteTimePeriodByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteTimePeriod(DeleteParameters<TimePeriod> parameters);

        [OperationContract]
        bool IsTimePeriodReferenced(Guid uid);

        [OperationContract]
        bool IsTimePeriodUnique(TimePeriod data);
        #endregion

        #region Galaxy Time Period Operations
        [OperationContract]
        ArrayResponse<GalaxyTimePeriod> GetAllGalaxyTimePeriods(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<GalaxyTimePeriodListItem> GetAllGalaxyTimePeriodsList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<GalaxyTimePeriodListItem> GetAllGalaxyTimePeriodsListForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<GalaxyTimePeriod> GetAllGalaxyTimePeriodsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyTimePeriod GetGalaxyTimePeriod(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyTimePeriod SaveGalaxyTimePeriod(SaveParameters<GalaxyTimePeriod> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyTimePeriodByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyTimePeriod(DeleteParameters<GalaxyTimePeriod> parameters);

        [OperationContract]
        bool IsGalaxyTimePeriodReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyTimePeriodUnique(GalaxyTimePeriod data);
        #endregion

        #region Day Type Operations
        [OperationContract]
        ArrayResponse<DayType> GetAllDayTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayTypeListItem> GetAllDayTypesListForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayType> GetAllDayTypesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayTypeListItem> GetAllDayTypesList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayType> GetAllDayTypesForMappedEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayTypeListItem> GetAllDayTypesListForMappedEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayType> GetAllDayTypesForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayTypeListItem> GetAllDayTypesListForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayType> GetAllDayTypesForAssaAbloyDsr(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayTypeListItem> GetAllDayTypesListForAssaAbloyDsr(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        DayType GetDayType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        DayType SaveDayType(SaveParameters<DayType> parameters);

        [OperationContract]
        DayTypeDateValidationError[] ValidateDatesForDayType(DayType data);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        ArrayResponse<DayType> EnsureDefaultDayTypesExistForEntity(SaveParameters<DayType> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDayTypeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDayType(DeleteParameters<DayType> parameters);

        [OperationContract]
        bool IsDayTypeReferenced(Guid uid);

        [OperationContract]
        bool IsDayTypeUnique(DayType data);
        #endregion

        #region Date Type Operations
        [OperationContract]
        ArrayResponse<DateType> GetAllDateTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DateType> GetAllDateTypesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DateType> GetAllDateTypesForMappedEntity(GetParametersWithPhoto parameters);

        //[OperationContract]
        //DateType[] GetAllDateTypesForCluster(GetParametersWithPhoto parameters);

        //[OperationContract]
        //DateType[] GetAllDateTypesForAssaAbloyDsr(GetParametersWithPhoto parameters);

        //[OperationContract]
        //DateType[] GetAllDateTypesForDayTypeEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DateType> GetAllDateTypesForDayType(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        DateType GetDateType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        DateType SaveDateType(SaveParameters<DateType> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDateTypeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDateType(DeleteParameters<DateType> parameters);

        [OperationContract]
        bool IsDateTypeReferenced(Guid uid);

        [OperationContract]
        bool IsDateTypeUnique(DateType data);
        #endregion

        #region Date Type Default Behavior Operations

        [OperationContract]
        DateTypeDefaultBehavior GetDateTypeDefaultBehaviorForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        DateTypeDefaultBehavior GetDateTypeDefaultBehavior(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        DateTypeDefaultBehavior SaveDateTypeDefaultBehavior(SaveParameters<DateTypeDefaultBehavior> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDateTypeDefaultBehaviorByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDateTypeDefaultBehavior(DeleteParameters<DateTypeDefaultBehavior> parameters);

        [OperationContract]
        bool IsDateTypeDefaultBehaviorReferenced(Guid uid);

        [OperationContract]
        bool IsDateTypeDefaultBehaviorUnique(DateTypeDefaultBehavior data);
        #endregion

        #region AssaDayPeriod Operations
        [OperationContract]
        AssaDayPeriod[] GetAllAssaDayPeriods(GetParametersWithPhoto parameters);

        [OperationContract]
        AssaDayPeriod[] GetAllAssaDayPeriodsForEntity(GetParametersWithPhoto parameters);

        //[OperationContract]
        //AssaDayPeriod[] GetAllAssaDayPeriodsForCluster(GetParametersWithPhoto parameters);

        //[OperationContract]
        //AssaDayPeriod[] GetAllAssaDayPeriodsForAssaAbloyDsr(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaDayPeriod GetAssaDayPeriod(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaDayPeriod SaveAssaDayPeriod(SaveParameters<AssaDayPeriod> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaDayPeriodByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaDayPeriod(DeleteParameters<AssaDayPeriod> parameters);

        [OperationContract]
        bool IsAssaDayPeriodReferenced(Guid uid);

        [OperationContract]
        bool IsAssaDayPeriodUnique(AssaDayPeriod data);
        #endregion

        #region Assa Abloy DSR Operations
        [OperationContract]
        AssaDsr[] GetAllAssaDsrs(GetParametersWithPhoto parameters);

        [OperationContract]
        AssaDsr[] GetAllAssaDsrsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaDsr GetAssaDsr(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaDsr SaveAssaDsr(SaveParameters<AssaDsr> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaDsrByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaDsr(DeleteParameters<AssaDsr> parameters);

        [OperationContract]
        bool IsAssaDsrReferenced(Guid uid);

        [OperationContract]
        bool IsAssaDsrUnique(AssaDsr data);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaDsr ImportAssaAccessPointsFromDsr(GetParametersWithPhoto parameters);

        #endregion

        #region Assa Abloy Access Point Operations

        [OperationContract]
        AssaAccessPoint[] GetAllAssaAccessPointsFromDsr(GetParametersWithPhoto parameters);

        [OperationContract]
        AssaAccessPoint[] GetAllAssaAccessPoints(GetParametersWithPhoto parameters);

        [OperationContract]
        AssaAccessPoint[] GetAllAssaAccessPointsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        AssaAccessPoint[] GetAllAssaAccessPointsForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaAccessPoint GetAssaAccessPoint(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaAccessPoint GetAssaAccessPointByAssaUniqueId(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaAccessPoint GetAssaAccessPointByAssaSerialNumber(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaAccessPoint SaveAssaAccessPoint(SaveParameters<AssaAccessPoint> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaAccessPointByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaAccessPoint(DeleteParameters<AssaAccessPoint> parameters);

        [OperationContract]
        bool IsAssaAccessPointReferenced(Guid uid);

        [OperationContract]
        bool IsAssaAccessPointUnique(AssaAccessPoint data);

        [OperationContract]
        AssaAccessPoint AssaConfirmAccessPoint(SaveParameters<AssaAccessPoint> parameters);
        #endregion

        #region Assa Abloy Access Point Type Operations
        [OperationContract]
        AssaAccessPointType[] GetAllAssaAccessPointTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        AssaAccessPointType GetAssaAccessPointTypeById(GetParametersWithPhoto parameters);

        [OperationContract]
        AssaAccessPointType GetAssaAccessPointType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaAccessPointType SaveAssaAccessPointType(SaveParameters<AssaAccessPointType> parameters);
        #endregion

        #region Galaxy Hardware Operations

        #region ClusterType Operations
        [OperationContract]
        ClusterType[] GetAllClusterTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ClusterType GetClusterType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        ClusterType SaveClusterType(SaveParameters<ClusterType> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteClusterTypeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteClusterType(DeleteParameters<ClusterType> parameters);

        [OperationContract]
        bool IsClusterTypeReferenced(Guid uid);

        [OperationContract]
        bool IsClusterTypeUnique(ClusterType data);
        #endregion 

        #region ClusterCommand Operations
        [OperationContract]
        ClusterCommand[] GetAllClusterCommands(GetParametersWithPhoto parameters);

        [OperationContract]
        ClusterCommand[] GetClusterCommandsByClusterType(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ClusterCommand GetClusterCommand(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        ClusterCommand SaveClusterCommand(SaveParameters<ClusterCommand> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteClusterCommandByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteClusterCommand(DeleteParameters<ClusterCommand> parameters);

        [OperationContract]
        bool IsClusterCommandReferenced(Guid uid);

        [OperationContract]
        bool IsClusterCommandUnique(ClusterCommand data);
        #endregion 

        #region Cluster Operations
        [OperationContract]
        ArrayResponse<Cluster> GetAllClusters(GetParametersWithPhoto parameters);
        [OperationContract]
        ArrayResponse<ClusterListItemCommands> GetAllClustersList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<Cluster> GetAllClustersForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<ClusterListItemCommands> GetAllClustersForEntityList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<ClusterGalaxyPanelMinimal> GetClustersWithGalaxyPanelInfo(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<Cluster> GetAllClustersForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<ClusterListItemCommands> GetAllClustersForSiteList(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Cluster GetCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Cluster GetClusterByHardwareAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateCluster(SaveParameters<Cluster> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Cluster SaveCluster(SaveParameters<Cluster> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteClusterByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCluster(DeleteParameters<Cluster> parameters);

        [OperationContract]
        bool IsClusterReferenced(Guid uid);

        [OperationContract]
        bool IsClusterUnique(Cluster data);

        [OperationContract]
        ClusterEditingData GetClusterEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        //CommandResponse<ClusterDataLoadParameters> SendClusterDataToPanels(CommandParameters<ClusterDataLoadParameters> parameters);
        LoadDataCommandResponse<ClusterDataLoadParameters> SendClusterDataToPanels(CommandParameters<ClusterDataLoadParameters> parameters);
        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        //BackgroundJobInfo<CommandResponse<ClusterDataLoadParameters>> SendClusterDataToPanelsJob(CommandParameters<ClusterDataLoadParameters> parameters);
        BackgroundJobInfo<LoadDataCommandResponse<ClusterDataLoadParameters>> SendClusterDataToPanelsJob(CommandParameters<ClusterDataLoadParameters> parameters);
        #endregion

        #region Galaxy Panel Model Operations
        [OperationContract]
        GalaxyPanelModel[] GetAllGalaxyPanelModels(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanelModel GetGalaxyPanelModel(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanelModel SaveGalaxyPanelModel(SaveParameters<GalaxyPanelModel> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanelModelByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanelModel(DeleteParameters<GalaxyPanelModel> parameters);

        [OperationContract]
        bool IsGalaxyPanelModelReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyPanelModelUnique(GalaxyPanelModel data);
        #endregion

        #region GalaxyPanelCommand Operations
        [OperationContract]
        GalaxyPanelCommand[] GetAllGalaxyPanelCommands(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyPanelCommand[] GetGalaxyPanelCommandsByPanelModel(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanelCommand GetGalaxyPanelCommand(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanelCommand SaveGalaxyPanelCommand(SaveParameters<GalaxyPanelCommand> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanelCommandByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanelCommand(DeleteParameters<GalaxyPanelCommand> parameters);

        [OperationContract]
        bool IsGalaxyPanelCommandReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyPanelCommandUnique(GalaxyPanelCommand data);
        #endregion 

        #region Galaxy Panel Operations
        [OperationContract]
        ArrayResponse<GalaxyPanel> GetAllGalaxyPanels(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<GalaxyPanel> GetAllGalaxyPanelsForCluster(GetParametersWithPhoto parameters);

        //[OperationContract]
        //GalaxyPanel[] GetAllGalaxyPanelsForEntity(GetParametersWithPhoto parameters);

        //[OperationContract]
        //GalaxyPanel[] GetAllGalaxyPanelsForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<GalaxyPanel> GetAllGalaxyPanelsForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanel GetGalaxyPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanel GetGalaxyPanelByHardwareAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanel SaveGalaxyPanel(SaveParameters<GalaxyPanel> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanelByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanel(DeleteParameters<GalaxyPanel> parameters);

        [OperationContract]
        bool IsGalaxyPanelReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyPanelUnique(GalaxyPanel data);

        [OperationContract]
//        GalaxyPanelEditingDataBasic GetGalaxyPanelEditingData(GetParametersWithPhoto parameters);
        GalaxyPanelEditingData GetGalaxyPanelEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetGalaxyPanelActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateGalaxyPanel(SaveParameters<GalaxyPanel> parameters);
        #endregion

        #region Galaxy CPU Model Operations
        [OperationContract]
        GalaxyCpuModel[] GetAllGalaxyCpuModels(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyCpuModel GetGalaxyCpuModel(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyCpuModel SaveGalaxyCpuModel(SaveParameters<GalaxyCpuModel> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyCpuModelByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyCpuModel(DeleteParameters<GalaxyCpuModel> parameters);

        [OperationContract]
        bool IsGalaxyCpuModelReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyCpuModelUnique(GalaxyCpuModel data);
        #endregion 

        #region Galaxy CPU Operations
        [OperationContract]
        GalaxyCpu[] GetAllGalaxyCpus(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyCpu[] GetAllGalaxyCpusForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyCpu[] GetAllGalaxyCpusForPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyCpu GetGalaxyCpu(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]

        GalaxyCpu SaveGalaxyCpu(SaveParameters<GalaxyCpu> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyCpuDatabaseInformation SaveGalaxyCpuConnectionInfo(SaveParameters<CpuConnectionInfo> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyCpuByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyCpu(DeleteParameters<GalaxyCpu> parameters);

        [OperationContract]
        bool IsGalaxyCpuReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyCpuUnique(GalaxyCpu data);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyCpuLoggingControl SaveGalaxyCpuLoggingControl(ISaveParameters<GalaxyCpuLoggingControl> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool ExecuteGalaxyCpuCommand(CommandParameters<GalaxyCpuCommandAction> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CommandResponse<GalaxyCpuCommandAction> ExecuteClusterCommand(CommandParameters<GalaxyCpuCommandAction> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool ExecuteGalaxyLoadFlashCommand(CommandParameters<GalaxyLoadFlashCommandAction> parameters);

        #endregion

        #region Galaxy Interface Board Type Operations
        [OperationContract]
        InterfaceBoardType[] GetAllGalaxyInterfaceBoardTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        InterfaceBoardType GetGalaxyInterfaceBoardType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        InterfaceBoardType SaveGalaxyInterfaceBoardType(SaveParameters<InterfaceBoardType> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardTypeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardType(DeleteParameters<InterfaceBoardType> parameters);

        [OperationContract]
        bool IsGalaxyInterfaceBoardTypeReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyInterfaceBoardTypeUnique(InterfaceBoardType data);
        #endregion

        #region Galaxy Interface Board Section Mode Operations
        [OperationContract]
        InterfaceBoardSectionMode[] GetAllGalaxyInterfaceBoardSectionModes(GetParametersWithPhoto parameters);

        [OperationContract]
        InterfaceBoardSectionMode[] GetAllGalaxyInterfaceBoardSectionModesForType(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        InterfaceBoardSectionMode GetGalaxyInterfaceBoardSectionMode(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        InterfaceBoardSectionMode SaveGalaxyInterfaceBoardSectionMode(SaveParameters<InterfaceBoardSectionMode> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionModeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionMode(DeleteParameters<InterfaceBoardSectionMode> parameters);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionModeReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionModeUnique(InterfaceBoardSectionMode data);
        #endregion 

        #region Galaxy Hardware Module Type Operations
        [OperationContract]
        GalaxyHardwareModuleType[] GetAllGalaxyHardwareModuleTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyHardwareModuleType GetGalaxyHardwareModuleType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyHardwareModuleType SaveGalaxyHardwareModuleType(SaveParameters<GalaxyHardwareModuleType> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyHardwareModuleTypeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyHardwareModuleType(DeleteParameters<GalaxyHardwareModuleType> parameters);

        [OperationContract]
        bool IsGalaxyHardwareModuleTypeReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyHardwareModuleTypeUnique(GalaxyHardwareModuleType data);
        #endregion 

        #region Galaxy Interface Board Operations
        [OperationContract]
        GalaxyInterfaceBoard[] GetAllGalaxyInterfaceBoards(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoard[] GetAllGalaxyInterfaceBoardsForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoard[] GetAllGalaxyInterfaceBoardsForPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoard[] GetAllGalaxyInterfaceBoardsForPanelAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoard GetGalaxyInterfaceBoard(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoard SaveGalaxyInterfaceBoard(SaveParameters<GalaxyInterfaceBoard> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoard(DeleteParameters<GalaxyInterfaceBoard> parameters);

        [OperationContract]
        bool IsGalaxyInterfaceBoardReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyInterfaceBoardUnique(GalaxyInterfaceBoard data);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateGalaxyInterfaceBoard(SaveParameters<GalaxyInterfaceBoard> parameters);

        #endregion

        #region Galaxy Interface Board Section Operations
        [OperationContract]
        GalaxyInterfaceBoardSection[] GetAllGalaxyInterfaceBoardSections(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoardSection[] GetAllGalaxyInterfaceBoardSectionsForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoardSection[] GetAllGalaxyInterfaceBoardSectionsForPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoardSection[] GetAllGalaxyInterfaceBoardSectionsForPanelAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoardSection[] GetAllGalaxyInterfaceBoardSectionsForInterfaceBoard(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoardSection GetGalaxyInterfaceBoardSection(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoardSection SaveGalaxyInterfaceBoardSection(SaveParameters<GalaxyInterfaceBoardSection> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSection(DeleteParameters<GalaxyInterfaceBoardSection> parameters);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionUnique(GalaxyInterfaceBoardSection data);


        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool ExecuteGalaxyInterfaceBoardSectionCommand(CommandParameters<GalaxyInterfaceBoardSectionCommandAction> parameters);

        #endregion

        #region Galaxy Interface Board Section Command Operations
        [OperationContract]
        GalaxyInterfaceBoardSectionCommand[] GetAllGalaxyInterfaceBoardSectionCommands(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoardSectionCommand GetGalaxyInterfaceBoardSectionCommand(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoardSectionCommand SaveGalaxyInterfaceBoardSectionCommand(SaveParameters<GalaxyInterfaceBoardSectionCommand> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionCommandByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionCommand(DeleteParameters<GalaxyInterfaceBoardSectionCommand> parameters);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionCommandReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionCommandUnique(GalaxyInterfaceBoardSectionCommand data);

        #endregion

        #region Galaxy Hardware Module Operations
        [OperationContract]
        GalaxyHardwareModule[] GetAllGalaxyHardwareModules(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyHardwareModule[] GetAllGalaxyHardwareModulesForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyHardwareModule[] GetAllGalaxyHardwareModulesForPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyHardwareModule[] GetAllGalaxyHardwareModulesForPanelAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyHardwareModule[] GetAllGalaxyHardwareModulesForInterfaceBoard(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyHardwareModule[] GetAllGalaxyHardwareModulesForInterfaceBoardSection(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyHardwareModule GetGalaxyHardwareModule(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyHardwareModule SaveGalaxyHardwareModule(SaveParameters<GalaxyHardwareModule> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyHardwareModuleByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyHardwareModule(DeleteParameters<GalaxyHardwareModule> parameters);

        [OperationContract]
        bool IsGalaxyHardwareModuleReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyHardwareModuleUnique(GalaxyHardwareModule data);
        #endregion

        #region Galaxy Interface Board Section Node Operations
        [OperationContract]
        GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodes(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForPanelAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoard(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSection(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModule(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoardSectionNode GetGalaxyInterfaceBoardSectionNode(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoardSectionNode SaveGalaxyInterfaceBoardSectionNode(SaveParameters<GalaxyInterfaceBoardSectionNode> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionNodeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionNode(DeleteParameters<GalaxyInterfaceBoardSectionNode> parameters);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionNodeReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionNodeUnique(GalaxyInterfaceBoardSectionNode data);
        #endregion

        #region Galaxy CPU Flash Operations
        [OperationContract]
        GalaxyFlashImage[] GetAllGalaxyFlashImages(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyFlashImage[] GetAllGalaxyFlashImagesForGalaxyCpuModelTypeCode(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyFlashImage[] GetAllGalaxyFlashImagesForGalaxyCpuModelUid(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyFlashImage GetGalaxyFlashImage(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyFlashImage SaveGalaxyFlashImage(SaveParameters<GalaxyFlashImage> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyFlashImageByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyFlashImage(DeleteParameters<GalaxyFlashImage> parameters);

        [OperationContract]
        bool IsGalaxyFlashImageReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyFlashImageUnique(GalaxyFlashImage data);
        #endregion

        #endregion

        #region Access Profile Operations
        [OperationContract]
        ArrayResponse<AccessProfile> GetAllAccessProfiles(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessProfileListItem> GetAllAccessProfilesList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessProfileListItem> GetAllAccessProfilesListForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessProfile> GetAllAccessProfilesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessProfile> GetAllAccessProfilesForMappedEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessProfile GetAccessProfile(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessProfile SaveAccessProfile(SaveParameters<AccessProfile> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessProfileByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessProfile(DeleteParameters<AccessProfile> parameters);

        [OperationContract]
        bool IsAccessProfileReferenced(Guid uid);

        [OperationContract]
        bool IsAccessProfileUnique(AccessProfile data);

        [OperationContract]
        AccessProfileEditingData GetAccessProfileEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessAndAlarmControlPermissionsEditingData GetAccessProfileClusterPermissionsEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int SyncPersonsWithAccessProfile(SaveParameters<AccessProfile> parameters);

        #endregion

        #region Department Operations
        [OperationContract]
        ArrayResponse<Department> GetAllDepartments(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<Department> GetAllDepartmentsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<ListItemBase> GetAllDepartmentsList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<ListItemBase> GetAllDepartmentsListEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Department GetDepartment(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Department SaveDepartment(SaveParameters<Department> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDepartmentByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDepartment(DeleteParameters<Department> parameters);

        [OperationContract]
        bool IsDepartmentReferenced(Guid uid);

        [OperationContract]
        bool IsDepartmentUnique(Department data);
        #endregion

        #region BadgeTemplate Operations
        [OperationContract]
        BadgeTemplate[] GetAllBadgeTemplates(GetParametersWithPhoto parameters);

        [OperationContract]
        BadgeTemplate[] GetAllBadgeTemplatesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllBadgeTemplatesList(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllBadgeTemplatesListEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        BadgeTemplate GetBadgeTemplate(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        BadgeTemplate SaveBadgeTemplate(SaveParameters<BadgeTemplate> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteBadgeTemplateByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteBadgeTemplate(DeleteParameters<BadgeTemplate> parameters);

        [OperationContract]
        bool IsBadgeTemplateReferenced(Guid uid);

        [OperationContract]
        bool IsBadgeTemplateUnique(BadgeTemplate data);
        #endregion

        #region Galaxy Data Operations

        #region Galaxy Access Group Operations
        [OperationContract]
        ArrayResponse<AccessGroupEx> GetAllAccessGroups(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessGroupEx> GetAllAccessGroupsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessGroupEx> GetAllAccessGroupsForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessGroupEx GetAccessGroup(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessGroupEx SaveAccessGroup(SaveParameters<AccessGroup> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessGroupByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessGroup(DeleteParameters<AccessGroup> parameters);

        [OperationContract]
        bool IsAccessGroupReferenced(Guid uid);

        [OperationContract]
        bool IsAccessGroupUnique(AccessGroup data);

        [OperationContract]
        int GetAvailableAccessGroupNumber(Guid clusterUid, GalaxySMS.Common.Enums.ChooseAvailableAccessGroupNumberRange rangeOption);

        [OperationContract]
        AccessGroupEditingData GetAccessGroupEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessGroupPersonInfo> GetPersonInfoForAccessGroup(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateAccessGroup(SaveParameters<AccessGroup> parameters);
        #endregion

        #region Galaxy Area Operations
        [OperationContract]
        ArrayResponse<Area> GetAllAreas(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<Area> GetAllAreasForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<Area> GetAllAreasForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Area GetArea(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Area SaveArea(SaveParameters<Area> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAreaByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteArea(DeleteParameters<Area> parameters);

        [OperationContract]
        bool IsAreaReferenced(Guid uid);

        [OperationContract]
        bool IsAreaUnique(Area data);

        #endregion

        #region Galaxy Input Output Group Operations
        [OperationContract]
        ArrayResponse<InputOutputGroup> GetAllInputOutputGroups(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputOutputGroup> GetAllInputOutputGroupsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputOutputGroup> GetAllInputOutputGroupsForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<InputOutputGroup> GetAllInputOutputGroupsForClusterAddress(GetParametersWithPhoto parameters);

        [OperationContract]
        InputOutputGroup GetInputOutputGroupForClusterAddressAndInputOutputGroupNumber(GetParametersWithPhoto parameters);

        [OperationContract]
        InputOutputGroupAssignmentSource[] GetInputOutputGroupAssignmentSourcesForInputOutputGroup(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        InputOutputGroup GetInputOutputGroup(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        InputOutputGroup SaveInputOutputGroup(SaveParameters<InputOutputGroup> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteInputOutputGroupByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteInputOutputGroup(DeleteParameters<InputOutputGroup> parameters);

        [OperationContract]
        bool IsInputOutputGroupReferenced(Guid uid);

        [OperationContract]
        bool IsInputOutputGroupUnique(InputOutputGroup data);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool ExecuteInputOutputGroupCommand(CommandParameters<InputOutputGroupCommandAction> parameters);
        #endregion
        #endregion

        #region PersonRecordType Operations
        [OperationContract]
        PersonRecordType[] GetAllPersonRecordTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        PersonRecordType[] GetAllPersonRecordTypesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllPersonRecordTypesList(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllPersonRecordTypesListEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        PersonRecordType GetPersonRecordType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        PersonRecordType SavePersonRecordType(SaveParameters<PersonRecordType> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePersonRecordTypeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePersonRecordType(DeleteParameters<PersonRecordType> parameters);

        [OperationContract]
        bool IsPersonRecordTypeReferenced(Guid uid);

        [OperationContract]
        bool IsPersonRecordTypeUnique(PersonRecordType data);
        #endregion

        #region Person Operations
        //[OperationContract]
        //PersonBasic SearchPersons();

        [OperationContract]
        Person[] GetAllPersons(GetParametersWithPhoto parameters);

        [OperationContract]
        Person[] GetAllPersonsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        PersonSummary[] SearchPersons(PersonSummarySearchParameters parameters);

        [OperationContract]
        ArrayResponse<PersonSummary> SearchPersonsPaged(PersonSummarySearchParameters parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Person GetPerson(GetParametersWithPhoto parameters);


        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Person SavePerson(SaveParameters<Person> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePersonByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePerson(DeleteParameters<Person> parameters);

        [OperationContract]
        bool IsPersonReferenced(Guid uid);

        [OperationContract]
        bool IsPersonUnique(Person data);

        [OperationContract]
        PersonEditingData GetPersonEditingData(GetParametersWithPhoto parameters);

        //[OperationContract]
        //PersonEditingDataWpf GetPersonEditingDataWpf(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessAndAlarmControlPermissionsEditingData GetAccessAndAlarmControlPermissionsEditingData(GetParametersWithPhoto parameters);

        //[OperationContract]
        //AccessAndAlarmControlPermissionsEditingDataWpf GetAccessAndAlarmControlPermissionsEditingDataWpf(GetParametersWithPhoto parameters);
        [OperationContract]
        UserInterfacePageControlData GetPersonUserInterfacePageControlData(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Person SyncPersonWithAccessProfile(GetParametersWithPhoto parameters);


        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        SaveDefaultPhotoResponse SavePersonPhoto(SaveParameters<SavePhotoParameters> parameters);

        [OperationContract]
        PersonInfoWithMissingPhotoUrl[] GetPersonInfoWithNoPhotoPublicUrl(Guid entityId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        PersonSavePhotoResponse[] SendPersonPhotosToCdn(Guid personUid);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePersonPhoto(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Person UpdatePersonProperties(SaveParameters<SavePersonPropertiesParameters> parameters);

        #endregion

        #region User Defined Property Operations
        [OperationContract]
        UserDefinedProperty[] GetAllUserDefinedProperties(GetParametersWithPhoto parameters);

        [OperationContract]
        UserDefinedProperty[] GetAllUserDefinedPropertiesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserDefinedProperty GetUserDefinedProperty(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserDefinedProperty SaveUserDefinedProperty(SaveParameters<UserDefinedProperty> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUserDefinedPropertyByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUserDefinedProperty(DeleteParameters<UserDefinedProperty> parameters);

        [OperationContract]
        bool IsUserDefinedPropertyReferenced(Guid uid);

        [OperationContract]
        bool IsUserDefinedPropertyUnique(UserDefinedProperty data);


        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserInterfacePageControlData SaveUserDefinedProperties(SaveParameters<List<UserDefinedProperty>> parameters);
        #endregion

        #region Credential Operations
        [OperationContract]
        DecodedCredential[] DecodeCredentialNumber(DecodeCredentialNumberParameters parameters);

        [OperationContract]
        Credential_PanelLoadData[] GetCredentialDataChangesToLoadForCpu(GetParametersWithPhoto parameters);

        [OperationContract]
        CredentialToDeleteFromCpu[] GetCredentialDataToDeleteLoadForCpu(GetParametersWithPhoto parameters);

        [OperationContract]
        Credential_PanelLoadData[] GetAllCredentialPanelData(GetParametersWithPhoto parameters);

        [OperationContract]
        CredentialFormat GetCredentialFormat(GetParametersWithPhoto parameters);
        #endregion

        #region Activity Event Data Operations
        [OperationContract]
        Credential_ActivityEventData GetCredentialActivityEventData(byte[] parameters);

        #endregion

        #region GalaxyActivityEventType

        [OperationContract]
        GalaxyActivityEventType[] GetAllGalaxyActivityEventType(GetParametersWithPhoto parameters); 
        
        [OperationContract]
        GalaxyActivityEventTypeBasicGroups GetGalaxyActivityEventTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyActivityEventType[] GetAllGalaxyActivityEventTypeForCulture(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyActivityEventType GetGalaxyActivityEventType(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyActivityEventType GetGalaxyActivityEventTypeByEventType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyActivityEventType SaveGalaxyActivityEventType(SaveParameters<GalaxyActivityEventType> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyActivityEventTypeByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyActivityEventType(DeleteParameters<GalaxyActivityEventType> parameters);

        [OperationContract]
        bool IsGalaxyActivityEventTypeReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyActivityEventTypeUnique(GalaxyActivityEventType data);
        #endregion

        #region Alarm Acknowledgement Operations
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AcknowledgedAlarmBasicData AcknowledgeAlarmEvent(SaveParameters<AcknowledgeAlarmEventParameters> parameters);
        
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int UnacknowledgeAlarmEvent(SaveParameters<UnacknowledgeAlarmEventParameters> parameters);

        [OperationContract]
        PanelActivityLogMessage[] GetUnacknowledgedAlarms(GetParametersWithPhoto parameters);
        #endregion

        #region idPRODUCER Operations

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        SubscriptionData IdProducerEnsureIsLicensed(SaveParameters<IdProducerSaveMasterLicenseParameters> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool IdProducerUpdateRootSubscriptionCompanyName(SaveParameters<IdProducerUpdateRootCustomerNameParameters> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        SubscriptionData IdProducerSyncSubscriptionAndEntity(SaveParameters<IdProducerSyncSubscriptionAndEntityParameters> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        SubscriptionTemplateField[] SyncSubscriptionTemplateFields(SaveParameters<IdProducerRequestParameters> parameters);

        [OperationContract]
        SubscriptionData[] IdProducerGetSubscriptions(GetParametersWithPhoto parameters);

        [OperationContract]
        SubscriptionData IdProducerGetRootSubscription(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CardTemplateLite[] GetAllCardTemplates(bool import, int subscriptionId);

        [OperationContract]
        PrintDispatcher[] GetPrintDispatchers(GetParametersWithPhoto<IdProducerRequestParameters> parameters);

        [OperationContract]
        Printer[] GetPrinters(GetParametersWithPhoto<IdProducerRequestParameters> parameters);

        [OperationContract]
        PreviewData GetPreviewImagesForCredential(GetParametersWithPhoto<IdProducerPrintPreviewRequestParameters> parameters);

        [OperationContract]
        CreatedPrintRequest[] CreatePrintRequestForCredential(GetParametersWithPhoto<IdProducerPrintRequestParameters> parameters);

        [OperationContract]
        ServerVersionNumber GetIdProducerVersion();

        #endregion

        #region Validation Operations
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateByGuid(GuidValidationRequest data);
        #endregion

        #region Event Operations
        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);

        [OperationContract]
        EventFilterData GetEventFilterData(EventFilterDataSelectionParameters parameters);

        [OperationContract]
        EntityDeviceAlertEventSettings GetDeviceAlertEventSettings(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        EntityDeviceAlertEventSettings SaveDeviceAlertEventSettings(SaveParameters<EntityDeviceAlertEventSettings> parameters);

        #endregion
    }
}
