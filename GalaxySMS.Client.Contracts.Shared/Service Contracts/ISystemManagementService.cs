using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using TimeScheduleType = GalaxySMS.Common.Enums.TimeScheduleType;

#if NETCOREAPP
using GalaxySMS.Business.Entities.NetStd2;
namespace GalaxySMS.Client.Contracts.NetCore
#else
namespace GalaxySMS.Client.Contracts
#endif
{
    [ServiceContract]
    public interface ISystemManagementService : IServiceContract
    {
        #region Region Operations
        #region Synchronous operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Region SaveRegion(SaveParameters<Region> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteRegionByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteRegion(DeleteParameters<Region> parameters);

        [OperationContract]
        bool IsRegionReferenced(Guid regionUId);

        [OperationContract]
        bool IsRegionUnique(Region region);
        #endregion

        #region Async operations
        [OperationContract]
        Task<Region[]> GetAllRegionsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Region[]> GetAllRegionsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllRegionsListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllRegionsListEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Region> GetRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Region> SaveRegionAsync(SaveParameters<Region> parameters);

        [OperationContract]
        Task<int> DeleteRegionByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteRegionAsync(DeleteParameters<Region> parameters);

        [OperationContract]
        Task<bool> IsRegionReferencedAsync(Guid regionUId);

        [OperationContract]
        Task<bool> IsRegionUniqueAsync(Region region);
        #endregion

        #endregion

        #region Site Operations

        #region Synchronous operations
        [OperationContract]
        Site[] GetAllSites(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllSitesList(GetParametersWithPhoto parameters);

        [OperationContract]
        Site[] GetAllSitesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllSitesForEntityList(GetParametersWithPhoto parameters);

        [OperationContract]
        Site[] GetAllSitesForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        ListItemBase[] GetAllSitesForRegionList(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Site GetSite(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Site SaveSite(SaveParameters<Site> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteSiteByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteSite(DeleteParameters<Site> parameters);

        [OperationContract]
        bool IsSiteReferenced(Guid siteUId);

        [OperationContract]
        bool IsSiteUnique(Site site);
        #endregion

        #region Async operations
        [OperationContract]
        Task<Site[]> GetAllSitesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllSitesListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Site[]> GetAllSitesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllSitesForEntityListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Site[]> GetAllSitesForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllSitesForRegionListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Site> GetSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Site> SaveSiteAsync(SaveParameters<Site> parameters);

        [OperationContract]
        Task<int> DeleteSiteByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteSiteAsync(DeleteParameters<Site> parameters);

        [OperationContract]
        Task<bool> IsSiteReferencedAsync(Guid siteUId);

        [OperationContract]
        Task<bool> IsSiteUniqueAsync(Site site);
        #endregion

        #endregion

        #region Seed Database

        #region Synchronous operations

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool SeedDatabase(SaveParameters<SeedDatabaseRequest> parameters);

        #endregion

        #region Async operations

        [OperationContract]
        Task<bool> SeedDatabaseAsync(SaveParameters<SeedDatabaseRequest> parameters);

        #endregion

        #endregion

        #region Brand Operations

        #region Synchronous operations

        [OperationContract]
        Brand[] GetAllBrands(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Brand GetBrand(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Brand SaveBrand(SaveParameters<Brand> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteBrandByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteBrand(DeleteParameters<Brand> parameters);

        [OperationContract]
        bool IsBrandReferenced(Guid uid);

        [OperationContract]
        bool IsBrandUnique(Brand data);

        #endregion

        #region Async operations

        [OperationContract]
        Task<Brand[]> GetAllBrandsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Brand> GetBrandAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Brand> SaveBrandAsync(SaveParameters<Brand> parameters);

        [OperationContract]
        Task<int> DeleteBrandByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteBrandAsync(DeleteParameters<Brand> parameters);

        [OperationContract]
        Task<bool> IsBrandReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsBrandUniqueAsync(Brand data);

        #endregion

        #endregion

        #region Credential Reader Data Format Operations

        #region Synchronous operations

        [OperationContract]
        CredentialReaderDataFormat[] GetAllCredentialReaderDataFormats(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderDataFormat GetCredentialReaderDataFormat(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderDataFormat SaveCredentialReaderDataFormat(SaveParameters<CredentialReaderDataFormat> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderDataFormatByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderDataFormat(DeleteParameters<CredentialReaderDataFormat> parameters);

        [OperationContract]
        bool IsCredentialReaderDataFormatReferenced(Guid uid);

        [OperationContract]
        bool IsCredentialReaderDataFormatUnique(CredentialReaderDataFormat data);

        #endregion

        #region Async operations

        [OperationContract]
        Task<CredentialReaderDataFormat[]> GetAllCredentialReaderDataFormatsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CredentialReaderDataFormat> GetCredentialReaderDataFormatAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CredentialReaderDataFormat> SaveCredentialReaderDataFormatAsync(SaveParameters<CredentialReaderDataFormat> parameters);

        [OperationContract]
        Task<int> DeleteCredentialReaderDataFormatByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteCredentialReaderDataFormatAsync(DeleteParameters<CredentialReaderDataFormat> parameters);

        [OperationContract]
        Task<bool> IsCredentialReaderDataFormatReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsCredentialReaderDataFormatUniqueAsync(CredentialReaderDataFormat data);

        #endregion

        #endregion

        #region Credential Reader Type Operations

        #region Synchronous operations

        [OperationContract]
        CredentialReaderType[] GetAllCredentialReaderTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderType GetCredentialReaderType(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderType SaveCredentialReaderType(SaveParameters<CredentialReaderType> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderTypeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderType(DeleteParameters<CredentialReaderType> parameters);

        [OperationContract]
        bool IsCredentialReaderTypeReferenced(Guid uid);

        [OperationContract]
        bool IsCredentialReaderTypeUnique(CredentialReaderType data);

        #endregion

        #region Async operations

        [OperationContract]
        Task<CredentialReaderType[]> GetAllCredentialReaderTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CredentialReaderType> GetCredentialReaderTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CredentialReaderType> SaveCredentialReaderTypeAsync(SaveParameters<CredentialReaderType> parameters);

        [OperationContract]
        Task<int> DeleteCredentialReaderTypeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteCredentialReaderTypeAsync(DeleteParameters<CredentialReaderType> parameters);

        [OperationContract]
        Task<bool> IsCredentialReaderTypeReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsCredentialReaderTypeUniqueAsync(CredentialReaderType data);

        #endregion

        #endregion

        #region Feature Operations

        #region Synchronous operations

        [OperationContract]
        Feature[] GetAllFeatures(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Feature GetFeature(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Feature SaveFeature(SaveParameters<Feature> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteFeatureByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteFeature(DeleteParameters<Feature> parameters);

        [OperationContract]
        bool IsFeatureReferenced(Guid uid);

        [OperationContract]
        bool IsFeatureUnique(Feature data);

        #endregion

        #region Async operations

        [OperationContract]
        Task<Feature[]> GetAllFeaturesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Feature> GetFeatureAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Feature> SaveFeatureAsync(SaveParameters<Feature> parameters);

        [OperationContract]
        Task<int> DeleteFeatureByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteFeatureAsync(DeleteParameters<Feature> parameters);

        [OperationContract]
        Task<bool> IsFeatureReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsFeatureUniqueAsync(Feature data);

        #endregion

        #region Feature Item Operations

        #region Synchronous operations

        [OperationContract]
        FeatureItem[] GetAllFeatureItemsForFeature(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        FeatureItem GetFeatureItem(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        FeatureItem SaveFeatureItem(SaveParameters<FeatureItem> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteFeatureItemByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteFeatureItem(DeleteParameters<FeatureItem> parameters);

        [OperationContract]
        bool IsFeatureItemReferenced(Guid uid);

        [OperationContract]
        bool IsFeatureItemUnique(FeatureItem data);

        #endregion

        #region Async operations

        [OperationContract]
        Task<FeatureItem[]> GetAllFeatureItemsForFeatureAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<FeatureItem> GetFeatureItemAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<FeatureItem> SaveFeatureItemAsync(SaveParameters<FeatureItem> parameters);

        [OperationContract]
        Task<int> DeleteFeatureItemByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteFeatureItemAsync(DeleteParameters<FeatureItem> parameters);

        [OperationContract]
        Task<bool> IsFeatureItemReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsFeatureItemUniqueAsync(FeatureItem data);

        #endregion

        #endregion

        #endregion

        #region Credential Reader Type Feature Map Operations

        #region Synchronous operations

        [OperationContract]
        CredentialReaderTypeFeatureMap[] GetAllCredentialReaderTypeFeatureMapForCredentialReaderType(
            GetParametersWithPhoto parameters);

        [OperationContract]
        CredentialReaderTypeFeatureMap[] GetAllCredentialReaderTypeFeatureMapForFeature(
            GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderTypeFeatureMap GetCredentialReaderTypeFeatureMap(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderTypeFeatureMap SaveCredentialReaderTypeFeatureMap(
            SaveParameters<CredentialReaderTypeFeatureMap> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderTypeFeatureMapByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCredentialReaderTypeFeatureMap(DeleteParameters<CredentialReaderTypeFeatureMap> parameters);

        [OperationContract]
        bool IsCredentialReaderTypeFeatureMapReferenced(Guid uid);

        [OperationContract]
        bool IsCredentialReaderTypeFeatureMapUnique(CredentialReaderTypeFeatureMap data);

        #endregion

        #region Async operations

        [OperationContract]
        Task<CredentialReaderTypeFeatureMap[]> GetAllCredentialReaderTypeFeatureMapForCredentialReaderTypeAsync(
            GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CredentialReaderTypeFeatureMap[]> GetAllCredentialReaderTypeFeatureMapForFeatureAsync(
            GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CredentialReaderTypeFeatureMap> GetCredentialReaderTypeFeatureMapAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CredentialReaderTypeFeatureMap> SaveCredentialReaderTypeFeatureMapAsync(
            SaveParameters<CredentialReaderTypeFeatureMap> parameters);

        [OperationContract]
        Task<int> DeleteCredentialReaderTypeFeatureMapByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteCredentialReaderTypeFeatureMapAsync(DeleteParameters<CredentialReaderTypeFeatureMap> parameters);

        [OperationContract]
        Task<bool> IsCredentialReaderTypeFeatureMapReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsCredentialReaderTypeFeatureMapUniqueAsync(CredentialReaderTypeFeatureMap data);

        #endregion

        #endregion 

        #region AccessPortalType Operations
        #region Synchronous operations
        [OperationContract]
        AccessPortalType[] GetAllAccessPortalTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessPortalType GetAccessPortalType(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessPortalType SaveAccessPortalType(SaveParameters<AccessPortalType> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessPortalTypeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessPortalType(DeleteParameters<AccessPortalType> parameters);

        [OperationContract]
        bool IsAccessPortalTypeReferenced(Guid uid);

        [OperationContract]
        bool IsAccessPortalTypeUnique(AccessPortalType data);
        #endregion
        #region Async operations
        [OperationContract]
        Task<AccessPortalType[]> GetAllAccessPortalTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessPortalType> GetAccessPortalTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessPortalType> SaveAccessPortalTypeAsync(SaveParameters<AccessPortalType> parameters);

        [OperationContract]
        Task<int> DeleteAccessPortalTypeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteAccessPortalTypeAsync(DeleteParameters<AccessPortalType> parameters);

        [OperationContract]
        Task<bool> IsAccessPortalTypeReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsAccessPortalTypeUniqueAsync(AccessPortalType data);
        #endregion
        #endregion

        #region AccessPortal Operations
        #region Synchronous operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessPortal SaveAccessPortal(SaveParameters<AccessPortal> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessPortalByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CommandResponse<AccessPortalCommandAction> ExecuteAccessPortalCommand(CommandParameters<AccessPortalCommandAction> parameters);

        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetAccessPortalActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateAccessPortal(SaveParameters<AccessPortal> parameters);
        #endregion
        #region Async operations
        [OperationContract]
        Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortal>> GetAccessPortalsByTextSearchAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortalListItemCommands>> GetAccessPortalsListByTextSearchAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForGalaxyPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForGalaxyPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessPortalListItem>> GetAccessPortalListItemsForGalaxyPanelAsync(GetParameters parameters);

        [OperationContract]
        Task<AccessPortalListItem> GetAccessPortalListItemAsync(GetParameters parameters);

        [OperationContract]
        Task<AccessPortal> GetAccessPortalAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessPortal> SaveAccessPortalAsync(SaveParameters<AccessPortal> parameters);

        [OperationContract]
        Task<int> DeleteAccessPortalByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteAccessPortalAsync(DeleteParameters<AccessPortal> parameters);

        [OperationContract]
        Task<bool> IsAccessPortalReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsAccessPortalUniqueAsync(AccessPortal data);

        [OperationContract]
        Task<AccessPortalGalaxyCommonEditingData> GetAccessPortalGalaxyCommonEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessPortalGalaxyPanelSpecificEditingData> GetAccessPortalGalaxyPanelSpecificEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CommandResponse<AccessPortalCommandAction>> ExecuteAccessPortalCommandAsync(CommandParameters<AccessPortalCommandAction> parameters);

        [OperationContract]
        Task<ArrayResponse<ActivityHistoryEvent>> GetAccessPortalActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters);

        [OperationContract]
        Task<ValidationProblemDetails> ValidateAccessPortalAsync(SaveParameters<AccessPortal> parameters);

        #endregion
        #endregion

        #region InputDevice Operations
        #region Synchronous operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        InputDevice SaveInputDevice(SaveParameters<InputDevice> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteInputDeviceByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CommandResponse<InputDeviceCommandAction> ExecuteInputDeviceCommand(CommandParameters<InputDeviceCommandAction> parameters);

        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetInputDeviceActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);

        #endregion
        #region Async operations
        [OperationContract]
        Task<ArrayResponse<InputDevice>> GetAllInputDevicesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListAsync(GetParametersWithPhoto parameters);


        [OperationContract]
        Task<ArrayResponse<InputDevice>> GetInputDevicesByTextSearchAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDeviceListItemCommands>> GetInputDevicesListByTextSearchAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDevice>> GetAllInputDevicesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDevice>> GetAllInputDevicesForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDevice>> GetAllInputDevicesForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDevice>> GetAllInputDevicesForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDevice>> GetAllInputDevicesForGalaxyPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListForGalaxyPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputDeviceListItem>> GetInputDeviceListItemsForGalaxyPanelAsync(GetParameters parameters);

        [OperationContract]
        Task<InputDeviceListItem> GetInputDeviceListItemAsync(GetParameters parameters);

        [OperationContract]
        Task<InputDevice> GetInputDeviceAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InputDevice> SaveInputDeviceAsync(SaveParameters<InputDevice> parameters);

        [OperationContract]
        Task<int> DeleteInputDeviceByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteInputDeviceAsync(DeleteParameters<InputDevice> parameters);

        [OperationContract]
        Task<bool> IsInputDeviceReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsInputDeviceUniqueAsync(InputDevice data);

        [OperationContract]
        Task<InputDeviceGalaxyCommonEditingData> GetInputDeviceGalaxyCommonEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InputDeviceHardwareSpecificEditingData> GetInputDeviceHardwareSpecificEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CommandResponse<InputDeviceCommandAction>> ExecuteInputDeviceCommandAsync(CommandParameters<InputDeviceCommandAction> parameters);

        [OperationContract]
        Task<ArrayResponse<ActivityHistoryEvent>> GetInputDeviceActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters);

        #endregion
        #endregion

        #region OutputDevice Operations
        #region Synchronous operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        OutputDevice SaveOutputDevice(SaveParameters<OutputDevice> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteOutputDeviceByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CommandResponse<OutputDeviceCommandAction> ExecuteOutputDeviceCommand(CommandParameters<OutputDeviceCommandAction> parameters);

        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetOutputDeviceActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);
        #endregion
        #region Async operations
        [OperationContract]
        Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDevice>> GetOutputDevicesByTextSearchAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDeviceListItemCommands>> GetOutputDevicesListByTextSearchAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesForGalaxyPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListForGalaxyPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<OutputDeviceListItem>> GetOutputDeviceListItemsForGalaxyPanelAsync(GetParameters parameters);

        [OperationContract]
        Task<OutputDeviceListItem> GetOutputDeviceListItemAsync(GetParameters parameters);

        [OperationContract]
        Task<OutputDevice> GetOutputDeviceAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<OutputDevice> SaveOutputDeviceAsync(SaveParameters<OutputDevice> parameters);

        [OperationContract]
        Task<int> DeleteOutputDeviceByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteOutputDeviceAsync(DeleteParameters<OutputDevice> parameters);

        [OperationContract]
        Task<bool> IsOutputDeviceReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsOutputDeviceUniqueAsync(OutputDevice data);

        [OperationContract]
        Task<OutputDeviceGalaxyCommonEditingData> GetOutputDeviceGalaxyCommonEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<OutputDeviceHardwareSpecificEditingData> GetOutputDeviceHardwareSpecificEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CommandResponse<OutputDeviceCommandAction>> ExecuteOutputDeviceCommandAsync(CommandParameters<OutputDeviceCommandAction> parameters);

        [OperationContract]
        Task<ArrayResponse<ActivityHistoryEvent>> GetOutputDeviceActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters);
        #endregion
        #endregion

        #region Time Schedule Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        TimeSchedule SaveTimeSchedule(SaveParameters<TimeSchedule> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteTimeScheduleByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteTimeSchedule(DeleteParameters<TimeSchedule> parameters);

        [OperationContract]
        bool IsTimeScheduleReferenced(Guid uid);

        [OperationContract]
        bool IsTimeScheduleUnique(TimeSchedule data);

        [OperationContract]
        bool IsTimeScheduleActive(Guid timeScheduleUid, GalaxySMS.Common.Enums.TimeScheduleType scheduleType, Guid clusterUid, DateTimeOffset dateTime);

        [OperationContract]
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

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<TimeScheduleListItem>> GetAllTimeSchedulesListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<TimeScheduleListItem>> GetAllTimeSchedulesForEntityListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesForMappedEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<TimeScheduleListItem>> GetAllTimeSchedulesForClusterListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesForAssaAbloyDsrAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<TimeScheduleClusterItem>> GetTimeScheduleClusterItemsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<TimeSchedule> GetTimeScheduleAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<TimeSchedule> SaveTimeScheduleAsync(SaveParameters<TimeSchedule> parameters);

        [OperationContract]
        Task<int> DeleteTimeScheduleByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteTimeScheduleAsync(DeleteParameters<TimeSchedule> parameters);

        [OperationContract]
        Task<bool> IsTimeScheduleReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsTimeScheduleUniqueAsync(TimeSchedule data);

        [OperationContract]
        Task<bool> IsTimeScheduleActiveAsync(Guid timeScheduleUid, GalaxySMS.Common.Enums.TimeScheduleType scheduleType, Guid clusterUid, DateTimeOffset dateTime);

        [OperationContract]
        Task<GalaxyClusterTimeScheduleMap> SetTimeScheduleToClusterMappingAsync(Guid timeScheduleUid, Guid clusterUid, bool isMapped, bool fifteenMinuteFormatUsesHolidays);

        [OperationContract]
        Task<bool> CanTimeScheduleBeUnmappedFromClusterAsync(Guid timeScheduleUid, Guid clusterUid);

        [OperationContract]
        Task<bool> CanTimeScheduleBeDeletedAsync(Guid timeScheduleUid);

        [OperationContract]
        Task<TimeScheduleUsageData> GetTimeScheduleUsageInformationAsync(Guid timeScheduleUid, Guid clusterUid);
        #endregion
        #endregion

        #region Time Period Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        TimePeriod SaveTimePeriod(SaveParameters<TimePeriod> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteTimePeriodByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteTimePeriod(DeleteParameters<TimePeriod> parameters);

        [OperationContract]
        bool IsTimePeriodReferenced(Guid uid);

        [OperationContract]
        bool IsTimePeriodUnique(TimePeriod data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<TimePeriod[]> GetAllTimePeriodsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllTimePeriodsListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<TimePeriod[]> GetAllTimePeriodsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllTimePeriodsForEntityListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<TimePeriod> GetTimePeriodAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<TimePeriod> FindTimePeriodByTimesAsync(GetParameters<TimePeriod> parameters);

        [OperationContract]
        Task<TimePeriod> SaveTimePeriodAsync(SaveParameters<TimePeriod> parameters);

        [OperationContract]
        Task<int> DeleteTimePeriodByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteTimePeriodAsync(DeleteParameters<TimePeriod> parameters);

        [OperationContract]
        Task<bool> IsTimePeriodReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsTimePeriodUniqueAsync(TimePeriod data);
        #endregion
        #endregion

        #region Galaxy Time Period Operations
        #region Synchronous Operations
        [OperationContract]
        ArrayResponse<GalaxyTimePeriod> GetAllGalaxyTimePeriods(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<GalaxyTimePeriodListItem> GetAllGalaxyTimePeriodsList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<GalaxyTimePeriod> GetAllGalaxyTimePeriodsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<GalaxyTimePeriodListItem> GetAllGalaxyTimePeriodsListForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyTimePeriod GetGalaxyTimePeriod(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyTimePeriod SaveGalaxyTimePeriod(SaveParameters<GalaxyTimePeriod> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyTimePeriodByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyTimePeriod(DeleteParameters<GalaxyTimePeriod> parameters);

        [OperationContract]
        bool IsGalaxyTimePeriodReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyTimePeriodUnique(GalaxyTimePeriod data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<GalaxyTimePeriod>> GetAllGalaxyTimePeriodsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<GalaxyTimePeriodListItem>> GetAllGalaxyTimePeriodsListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<GalaxyTimePeriod>> GetAllGalaxyTimePeriodsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<GalaxyTimePeriodListItem>> GetAllGalaxyTimePeriodsListForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyTimePeriod> GetGalaxyTimePeriodAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyTimePeriod> SaveGalaxyTimePeriodAsync(SaveParameters<GalaxyTimePeriod> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyTimePeriodByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyTimePeriodAsync(DeleteParameters<GalaxyTimePeriod> parameters);

        [OperationContract]
        Task<bool> IsGalaxyTimePeriodReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyTimePeriodUniqueAsync(GalaxyTimePeriod data);
        #endregion
        #endregion

        #region Day Type Operations
        #region Synchronous Operations
        [OperationContract]
        ArrayResponse<DayType> GetAllDayTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayTypeListItem> GetAllDayTypesList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayType> GetAllDayTypesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DayTypeListItem> GetAllDayTypesListForEntity(GetParametersWithPhoto parameters);

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
        DayTypeDateValidationError[] ValidateDatesForDayType(DayType data);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        DayType SaveDayType(SaveParameters<DayType> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        ArrayResponse<DayType> EnsureDefaultDayTypesExistForEntity(SaveParameters<DayType> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDayTypeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDayType(DeleteParameters<DayType> parameters);

        [OperationContract]
        bool IsDayTypeReferenced(Guid uid);

        [OperationContract]
        bool IsDayTypeUnique(DayType data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<DayType>> GetAllDayTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DayTypeListItem>> GetAllDayTypesListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DayType>> GetAllDayTypesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DayTypeListItem>> GetAllDayTypesListForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DayType>> GetAllDayTypesForMappedEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DayTypeListItem>> GetAllDayTypesListForMappedEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DayType>> GetAllDayTypesForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DayTypeListItem>> GetAllDayTypesListForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DayType>> GetAllDayTypesForAssaAbloyDsrAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DayTypeListItem>> GetAllDayTypesListForAssaAbloyDsrAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DayType> GetDayTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DayTypeDateValidationError[]> ValidateDatesForDayTypeAsync(DayType data);

        [OperationContract]
        Task<DayType> SaveDayTypeAsync(SaveParameters<DayType> parameters);

        [OperationContract]
        Task<ArrayResponse<DayType>> EnsureDefaultDayTypesExistForEntityAsync(SaveParameters<DayType> parameters);

        [OperationContract]
        Task<int> DeleteDayTypeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteDayTypeAsync(DeleteParameters<DayType> parameters);

        [OperationContract]
        Task<bool> IsDayTypeReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsDayTypeUniqueAsync(DayType data);
        #endregion
        #endregion

        #region Date Type Operations
        #region Synchronous Operations
        [OperationContract]
        ArrayResponse<DateType> GetAllDateTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DateType> GetAllDateTypesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DateType> GetAllDateTypesForMappedEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<DateType> GetAllDateTypesForDayType(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        DateType GetDateType(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        DateType SaveDateType(SaveParameters<DateType> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDateTypeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDateType(DeleteParameters<DateType> parameters);

        [OperationContract]
        bool IsDateTypeReferenced(Guid uid);

        [OperationContract]
        bool IsDateTypeUnique(DateType data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<DateType>> GetAllDateTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DateType>> GetAllDateTypesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DateType>> GetAllDateTypesForMappedEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<DateType>> GetAllDateTypesForDayTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DateType> GetDateTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DateType> SaveDateTypeAsync(SaveParameters<DateType> parameters);

        [OperationContract]
        Task<int> DeleteDateTypeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteDateTypeAsync(DeleteParameters<DateType> parameters);

        [OperationContract]
        Task<bool> IsDateTypeReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsDateTypeUniqueAsync(DateType data);
        #endregion
        #endregion

        #region Date Type Default Behavior Operations
        #region Synchronous Operations

        [OperationContract]
        DateTypeDefaultBehavior GetDateTypeDefaultBehaviorForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        DateTypeDefaultBehavior GetDateTypeDefaultBehavior(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        DateTypeDefaultBehavior SaveDateTypeDefaultBehavior(SaveParameters<DateTypeDefaultBehavior> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDateTypeDefaultBehaviorByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDateTypeDefaultBehavior(DeleteParameters<DateTypeDefaultBehavior> parameters);

        [OperationContract]
        bool IsDateTypeDefaultBehaviorReferenced(Guid uid);

        [OperationContract]
        bool IsDateTypeDefaultBehaviorUnique(DateTypeDefaultBehavior data);
        #endregion

        #region Async Operations

        [OperationContract]
        Task<DateTypeDefaultBehavior> GetDateTypeDefaultBehaviorForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DateTypeDefaultBehavior> GetDateTypeDefaultBehaviorAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DateTypeDefaultBehavior> SaveDateTypeDefaultBehaviorAsync(SaveParameters<DateTypeDefaultBehavior> parameters);

        [OperationContract]
        Task<int> DeleteDateTypeDefaultBehaviorByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteDateTypeDefaultBehaviorAsync(DeleteParameters<DateTypeDefaultBehavior> parameters);

        [OperationContract]
        Task<bool> IsDateTypeDefaultBehaviorReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsDateTypeDefaultBehaviorUniqueAsync(DateTypeDefaultBehavior data);

        #endregion

        #endregion

        #region AssaDayPeriod Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaDayPeriod SaveAssaDayPeriod(SaveParameters<AssaDayPeriod> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaDayPeriodByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaDayPeriod(DeleteParameters<AssaDayPeriod> parameters);

        [OperationContract]
        bool IsAssaDayPeriodReferenced(Guid uid);

        [OperationContract]
        bool IsAssaDayPeriodUnique(AssaDayPeriod data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<AssaDayPeriod[]> GetAllAssaDayPeriodsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaDayPeriod[]> GetAllAssaDayPeriodsForEntityAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<AssaDayPeriod[]> GetAllAssaDayPeriodsForClusterAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<AssaDayPeriod[]> GetAllAssaDayPeriodsForAssaAbloyDsrAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaDayPeriod> GetAssaDayPeriodAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaDayPeriod> SaveAssaDayPeriodAsync(SaveParameters<AssaDayPeriod> parameters);

        [OperationContract]
        Task<int> DeleteAssaDayPeriodByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteAssaDayPeriodAsync(DeleteParameters<AssaDayPeriod> parameters);

        [OperationContract]
        Task<bool> IsAssaDayPeriodReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsAssaDayPeriodUniqueAsync(AssaDayPeriod data);
        #endregion
        #endregion

        #region Assa Abloy DSR Operations
        #region Synchronous Operations
        [OperationContract]
        AssaDsr[] GetAllAssaDsrs(GetParametersWithPhoto parameters);

        [OperationContract]
        AssaDsr[] GetAllAssaDsrsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaDsr GetAssaDsr(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaDsr SaveAssaDsr(SaveParameters<AssaDsr> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaDsrByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaDsr(DeleteParameters<AssaDsr> parameters);

        [OperationContract]
        bool IsAssaDsrReferenced(Guid uid);

        [OperationContract]
        bool IsAssaDsrUnique(AssaDsr data);

        [OperationContract]
        AssaDsr ImportAssaAccessPointsFromDsr(GetParametersWithPhoto parameters);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<AssaDsr[]> GetAllAssaDsrsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaDsr[]> GetAllAssaDsrsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaDsr> GetAssaDsrAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaDsr> SaveAssaDsrAsync(SaveParameters<AssaDsr> parameters);

        [OperationContract]
        Task<int> DeleteAssaDsrByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteAssaDsrAsync(DeleteParameters<AssaDsr> parameters);

        [OperationContract]
        Task<bool> IsAssaDsrReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsAssaDsrUniqueAsync(AssaDsr data);

        [OperationContract]
        Task<AssaDsr> ImportAssaAccessPointsFromDsrAsync(GetParametersWithPhoto parameters);
        #endregion
        #endregion

        #region Assa Abloy Access Point Operations
        #region Synchronous Operations

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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaAccessPoint SaveAssaAccessPoint(SaveParameters<AssaAccessPoint> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaAccessPointByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAssaAccessPoint(DeleteParameters<AssaAccessPoint> parameters);

        [OperationContract]
        bool IsAssaAccessPointReferenced(Guid uid);

        [OperationContract]
        bool IsAssaAccessPointUnique(AssaAccessPoint data);
        #endregion
        [OperationContract]
        AssaAccessPoint AssaConfirmAccessPoint(SaveParameters<AssaAccessPoint> parameters);

        #region Async Operations
        [OperationContract]
        Task<AssaAccessPoint[]> GetAllAssaAccessPointsFromDsrAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaAccessPoint[]> GetAllAssaAccessPointsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaAccessPoint[]> GetAllAssaAccessPointsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaAccessPoint[]> GetAllAssaAccessPointsForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaAccessPoint> GetAssaAccessPointAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaAccessPoint> GetAssaAccessPointByAssaUniqueIdAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaAccessPoint> GetAssaAccessPointByAssaSerialNumberAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaAccessPoint> SaveAssaAccessPointAsync(SaveParameters<AssaAccessPoint> parameters);

        [OperationContract]
        Task<int> DeleteAssaAccessPointByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteAssaAccessPointAsync(DeleteParameters<AssaAccessPoint> parameters);

        [OperationContract]
        Task<bool> IsAssaAccessPointReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsAssaAccessPointUniqueAsync(AssaAccessPoint data);
        #endregion
        [OperationContract]
        Task<AssaAccessPoint> AssaConfirmAccessPointAsync(SaveParameters<AssaAccessPoint> parameters);

        #endregion

        #region Assa Abloy Access Point Type Operations
        #region Synchronous Operations
        [OperationContract]
        AssaAccessPointType[] GetAllAssaAccessPointTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        AssaAccessPointType GetAssaAccessPointTypeById(GetParametersWithPhoto parameters);

        [OperationContract]
        AssaAccessPointType GetAssaAccessPointType(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AssaAccessPointType SaveAssaAccessPointType(SaveParameters<AssaAccessPointType> parameters);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<AssaAccessPointType[]> GetAllAssaAccessPointTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaAccessPointType> GetAssaAccessPointByIdAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaAccessPointType> GetAssaAccessPointTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AssaAccessPointType> SaveAssaAccessPointTypeAsync(SaveParameters<AssaAccessPointType> parameters);
        #endregion

        #endregion

        #region Galaxy Hardware Operations

        #region ClusterType Operations
        #region Synchronous Operations
        [OperationContract]
        ClusterType[] GetAllClusterTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ClusterType GetClusterType(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        ClusterType SaveClusterType(SaveParameters<ClusterType> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteClusterTypeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteClusterType(DeleteParameters<ClusterType> parameters);

        [OperationContract]
        bool IsClusterTypeReferenced(Guid uid);

        [OperationContract]
        bool IsClusterTypeUnique(ClusterType data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<ClusterType[]> GetAllClusterTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ClusterType> GetClusterTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ClusterType> SaveClusterTypeAsync(SaveParameters<ClusterType> parameters);

        [OperationContract]
        Task<int> DeleteClusterTypeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteClusterTypeAsync(DeleteParameters<ClusterType> parameters);

        [OperationContract]
        Task<bool> IsClusterTypeReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsClusterTypeUniqueAsync(ClusterType data);
        #endregion 
        #endregion 

        #region ClusterCommand Operations
        #region Synchronous Operations
        [OperationContract]
        ClusterCommand[] GetAllClusterCommands(GetParametersWithPhoto parameters);

        [OperationContract]
        ClusterCommand[] GetClusterCommandsByClusterType(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ClusterCommand GetClusterCommand(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        ClusterCommand SaveClusterCommand(SaveParameters<ClusterCommand> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteClusterCommandByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteClusterCommand(DeleteParameters<ClusterCommand> parameters);

        [OperationContract]
        bool IsClusterCommandReferenced(Guid uid);

        [OperationContract]
        bool IsClusterCommandUnique(ClusterCommand data);

        #endregion

        #region Async Operations
        [OperationContract]
        Task<ClusterCommand[]> GetAllClusterCommandsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ClusterCommand[]> GetClusterCommandsByClusterTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ClusterCommand> GetClusterCommandAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ClusterCommand> SaveClusterCommandAsync(SaveParameters<ClusterCommand> parameters);

        [OperationContract]
        Task<int> DeleteClusterCommandByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteClusterCommandAsync(DeleteParameters<ClusterCommand> parameters);

        [OperationContract]
        Task<bool> IsClusterCommandReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsClusterCommandUniqueAsync(ClusterCommand data);
        #endregion 
        #endregion 

        #region Cluster Operations
        #region Synchronous Operations
        [OperationContract]
        //        Cluster[] GetAllClusters(GetParametersWithPhoto parameters);
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
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateCluster(SaveParameters<Cluster> parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Cluster SaveCluster(SaveParameters<Cluster> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteClusterByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
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

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<Cluster>> GetAllClustersAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<ClusterListItemCommands>> GetAllClustersListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<Cluster>> GetAllClustersForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<ClusterListItemCommands>> GetAllClustersForEntityListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<ClusterGalaxyPanelMinimal>> GetClustersWithGalaxyPanelInfoAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<Cluster>> GetAllClustersForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<ClusterListItemCommands>> GetAllClustersForSiteListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Cluster> GetClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Cluster> GetClusterByHardwareAddressAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ValidationProblemDetails> ValidateClusterAsync(SaveParameters<Cluster> parameters);

        [OperationContract]
        Task<Cluster> SaveClusterAsync(SaveParameters<Cluster> parameters);

        [OperationContract]
        Task<int> DeleteClusterByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteClusterAsync(DeleteParameters<Cluster> parameters);

        [OperationContract]
        Task<bool> IsClusterReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsClusterUniqueAsync(Cluster data);

        [OperationContract]
        Task<ClusterEditingData> GetClusterEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
//        Task<CommandResponse<ClusterDataLoadParameters>> SendClusterDataToPanelsAsync(CommandParameters<ClusterDataLoadParameters> parameters);
        Task<LoadDataCommandResponse<ClusterDataLoadParameters>> SendClusterDataToPanelsAsync(CommandParameters<ClusterDataLoadParameters> parameters);
        
        [OperationContract]
//        Task<BackgroundJobInfo<CommandResponse<ClusterDataLoadParameters>>> SendClusterDataToPanelsJobAsync(CommandParameters<ClusterDataLoadParameters> parameters);
        Task<BackgroundJobInfo<LoadDataCommandResponse<ClusterDataLoadParameters>>> SendClusterDataToPanelsJobAsync(CommandParameters<ClusterDataLoadParameters> parameters);
        #endregion
        #endregion

        #region Galaxy Panel Model Operations
        #region Synchronous Operations
        [OperationContract]
        GalaxyPanelModel[] GetAllGalaxyPanelModels(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanelModel GetGalaxyPanelModel(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanelModel SaveGalaxyPanelModel(SaveParameters<GalaxyPanelModel> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanelModelByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanelModel(DeleteParameters<GalaxyPanelModel> parameters);

        [OperationContract]
        bool IsGalaxyPanelModelReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyPanelModelUnique(GalaxyPanelModel data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyPanelModel[]> GetAllGalaxyPanelModelsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanelModel> GetGalaxyPanelModelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanelModel> SaveGalaxyPanelModelAsync(SaveParameters<GalaxyPanelModel> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyPanelModelByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyPanelModelAsync(DeleteParameters<GalaxyPanelModel> parameters);

        [OperationContract]
        Task<bool> IsGalaxyPanelModelReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyPanelModelUniqueAsync(GalaxyPanelModel data);
        #endregion 
        #endregion

        #region GalaxyPanelCommand Operations
        #region Synchronous Operations
        [OperationContract]
        GalaxyPanelCommand[] GetAllGalaxyPanelCommands(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyPanelCommand[] GetGalaxyPanelCommandsByPanelModel(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanelCommand GetGalaxyPanelCommand(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanelCommand SaveGalaxyPanelCommand(SaveParameters<GalaxyPanelCommand> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanelCommandByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanelCommand(DeleteParameters<GalaxyPanelCommand> parameters);

        [OperationContract]
        bool IsGalaxyPanelCommandReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyPanelCommandUnique(GalaxyPanelCommand data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyPanelCommand[]> GetAllGalaxyPanelCommandsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanelCommand[]> GetGalaxyPanelCommandsByPanelModelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanelCommand> GetGalaxyPanelCommandAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanelCommand> SaveGalaxyPanelCommandAsync(SaveParameters<GalaxyPanelCommand> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyPanelCommandByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyPanelCommandAsync(DeleteParameters<GalaxyPanelCommand> parameters);

        [OperationContract]
        Task<bool> IsGalaxyPanelCommandReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyPanelCommandUniqueAsync(GalaxyPanelCommand data);
        #endregion 
        #endregion 

        #region Galaxy Panel Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanel SaveGalaxyPanel(SaveParameters<GalaxyPanel> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanelByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyPanel(DeleteParameters<GalaxyPanel> parameters);

        [OperationContract]
        bool IsGalaxyPanelReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyPanelUnique(GalaxyPanel data);

        [OperationContract]
        GalaxyPanelEditingData GetGalaxyPanelEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetGalaxyPanelActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        ValidationProblemDetails ValidateGalaxyPanel(SaveParameters<GalaxyPanel> parameters);

        #endregion

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<GalaxyPanel>> GetAllGalaxyPanelsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<GalaxyPanel>> GetAllGalaxyPanelsForClusterAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<GalaxyPanel[]> GetAllGalaxyPanelsForEntityAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<GalaxyPanel[]> GetAllGalaxyPanelsForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<GalaxyPanel>> GetAllGalaxyPanelsForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanel> GetGalaxyPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanel> GetGalaxyPanelByHardwareAddressAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanel> SaveGalaxyPanelAsync(SaveParameters<GalaxyPanel> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyPanelByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyPanelAsync(DeleteParameters<GalaxyPanel> parameters);

        [OperationContract]
        Task<bool> IsGalaxyPanelReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyPanelUniqueAsync(GalaxyPanel data);

        [OperationContract]
        Task<GalaxyPanelEditingData> GetGalaxyPanelEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<ActivityHistoryEvent>> GetGalaxyPanelActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters);

        [OperationContract]
        Task<ValidationProblemDetails> ValidateGalaxyPanelAsync(SaveParameters<GalaxyPanel> parameters);
        #endregion 
        #endregion 

        #region Galaxy CPU Model Operations
        #region Synchronous Operations
        [OperationContract]
        GalaxyCpuModel[] GetAllGalaxyCpuModels(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyCpuModel GetGalaxyCpuModel(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyCpuModel SaveGalaxyCpuModel(SaveParameters<GalaxyCpuModel> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyCpuModelByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyCpuModel(DeleteParameters<GalaxyCpuModel> parameters);

        [OperationContract]
        bool IsGalaxyCpuModelReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyCpuModelUnique(GalaxyCpuModel data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyCpuModel[]> GetAllGalaxyCpuModelsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyCpuModel> GetGalaxyCpuModelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyCpuModel> SaveGalaxyCpuModelAsync(SaveParameters<GalaxyCpuModel> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyCpuModelByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyCpuModelAsync(DeleteParameters<GalaxyCpuModel> parameters);

        [OperationContract]
        Task<bool> IsGalaxyCpuModelReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyCpuModelUniqueAsync(GalaxyCpuModel data);
        #endregion 
        #endregion 

        #region Galaxy CPU Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyCpu SaveGalaxyCpu(SaveParameters<GalaxyCpu> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyCpuDatabaseInformation SaveGalaxyCpuConnectionInfo(SaveParameters<CpuConnectionInfo> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyCpuByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyCpu(DeleteParameters<GalaxyCpu> parameters);

        [OperationContract]
        bool IsGalaxyCpuReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyCpuUnique(GalaxyCpu data);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyCpuLoggingControl SaveGalaxyCpuLoggingControl(SaveParameters<GalaxyCpuLoggingControl> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool ExecuteGalaxyCpuCommand(CommandParameters<GalaxyCpuCommandAction> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CommandResponse<GalaxyCpuCommandAction> ExecuteClusterCommand(CommandParameters<GalaxyCpuCommandAction> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool ExecuteGalaxyLoadFlashCommand(CommandParameters<GalaxyLoadFlashCommandAction> parameters);

        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyCpu[]> GetAllGalaxyCpusAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyCpu[]> GetAllGalaxyCpusForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyCpu[]> GetAllGalaxyCpusForPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyCpu> GetGalaxyCpuAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyCpu> SaveGalaxyCpuAsync(SaveParameters<GalaxyCpu> parameters);

        [OperationContract]
        Task<GalaxyCpuDatabaseInformation> SaveGalaxyCpuConnectionInfoAsync(SaveParameters<CpuConnectionInfo> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyCpuByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyCpuAsync(DeleteParameters<GalaxyCpu> parameters);

        [OperationContract]
        Task<bool> IsGalaxyCpuReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyCpuUniqueAsync(GalaxyCpu data);

        [OperationContract]
        Task<GalaxyCpuLoggingControl> SaveGalaxyCpuLoggingControlAsync(SaveParameters<GalaxyCpuLoggingControl> parameters);

        [OperationContract]
        Task<bool> ExecuteGalaxyCpuCommandAsync(CommandParameters<GalaxyCpuCommandAction> parameters);

        [OperationContract]
        Task<CommandResponse<GalaxyCpuCommandAction>> ExecuteClusterCommandAsync(CommandParameters<GalaxyCpuCommandAction> parameters);

        [OperationContract]
        Task<bool> ExecuteGalaxyLoadFlashCommandAsync(CommandParameters<GalaxyLoadFlashCommandAction> parameters);
        #endregion 

        #endregion

        #region Galaxy Interface Board Type Operations
        #region Synchronous Operations
        [OperationContract]
        InterfaceBoardType[] GetAllGalaxyInterfaceBoardTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        InterfaceBoardType GetGalaxyInterfaceBoardType(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        InterfaceBoardType SaveGalaxyInterfaceBoardType(SaveParameters<InterfaceBoardType> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardTypeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardType(DeleteParameters<InterfaceBoardType> parameters);

        [OperationContract]
        bool IsGalaxyInterfaceBoardTypeReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyInterfaceBoardTypeUnique(InterfaceBoardType data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<InterfaceBoardType[]> GetAllGalaxyInterfaceBoardTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InterfaceBoardType> GetGalaxyInterfaceBoardTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InterfaceBoardType> SaveGalaxyInterfaceBoardTypeAsync(SaveParameters<InterfaceBoardType> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyInterfaceBoardTypeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyInterfaceBoardTypeAsync(DeleteParameters<InterfaceBoardType> parameters);

        [OperationContract]
        Task<bool> IsGalaxyInterfaceBoardTypeReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyInterfaceBoardTypeUniqueAsync(InterfaceBoardType data);
        #endregion 
        #endregion

        #region Galaxy Interface Board Section Mode Operations
        #region Synchronous Operations
        [OperationContract]
        InterfaceBoardSectionMode[] GetAllGalaxyInterfaceBoardSectionModes(GetParametersWithPhoto parameters);

        [OperationContract]
        InterfaceBoardSectionMode[] GetAllGalaxyInterfaceBoardSectionModesForType(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        InterfaceBoardSectionMode GetGalaxyInterfaceBoardSectionMode(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        InterfaceBoardSectionMode SaveGalaxyInterfaceBoardSectionMode(SaveParameters<InterfaceBoardSectionMode> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionModeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionMode(DeleteParameters<InterfaceBoardSectionMode> parameters);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionModeReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionModeUnique(InterfaceBoardSectionMode data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<InterfaceBoardSectionMode[]> GetAllGalaxyInterfaceBoardSectionModesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InterfaceBoardSectionMode[]> GetAllGalaxyInterfaceBoardSectionModesForTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InterfaceBoardSectionMode> GetGalaxyInterfaceBoardSectionModeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InterfaceBoardSectionMode> SaveGalaxyInterfaceBoardSectionModeAsync(SaveParameters<InterfaceBoardSectionMode> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyInterfaceBoardSectionModeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyInterfaceBoardSectionModeAsync(DeleteParameters<InterfaceBoardSectionMode> parameters);

        [OperationContract]
        Task<bool> IsGalaxyInterfaceBoardSectionModeReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyInterfaceBoardSectionModeUniqueAsync(InterfaceBoardSectionMode data);
        #endregion 
        #endregion 

        #region Galaxy Hardware Module Type Operations
        #region Synchronous Operations
        [OperationContract]
        GalaxyHardwareModuleType[] GetAllGalaxyHardwareModuleTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyHardwareModuleType GetGalaxyHardwareModuleType(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyHardwareModuleType SaveGalaxyHardwareModuleType(SaveParameters<GalaxyHardwareModuleType> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyHardwareModuleTypeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyHardwareModuleType(DeleteParameters<GalaxyHardwareModuleType> parameters);

        [OperationContract]
        bool IsGalaxyHardwareModuleTypeReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyHardwareModuleTypeUnique(GalaxyHardwareModuleType data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyHardwareModuleType[]> GetAllGalaxyHardwareModuleTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModuleType> GetGalaxyHardwareModuleTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModuleType> SaveGalaxyHardwareModuleTypeAsync(SaveParameters<GalaxyHardwareModuleType> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyHardwareModuleTypeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyHardwareModuleTypeAsync(DeleteParameters<GalaxyHardwareModuleType> parameters);

        [OperationContract]
        Task<bool> IsGalaxyHardwareModuleTypeReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyHardwareModuleTypeUniqueAsync(GalaxyHardwareModuleType data);
        #endregion 
        #endregion 

        #region Galaxy Interface Board Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoard SaveGalaxyInterfaceBoard(SaveParameters<GalaxyInterfaceBoard> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
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

        #region Async Operations
        [OperationContract]
        Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsForPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsForPanelAddressAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoard> GetGalaxyInterfaceBoardAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoard> SaveGalaxyInterfaceBoardAsync(SaveParameters<GalaxyInterfaceBoard> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyInterfaceBoardByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyInterfaceBoardAsync(DeleteParameters<GalaxyInterfaceBoard> parameters);

        [OperationContract]
        Task<bool> IsGalaxyInterfaceBoardReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyInterfaceBoardUniqueAsync(GalaxyInterfaceBoard data);

        [OperationContract]
        Task<ValidationProblemDetails> ValidateGalaxyInterfaceBoardAsync(SaveParameters<GalaxyInterfaceBoard> parameters);
        #endregion
        #endregion

        #region Galaxy Interface Board Section Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoardSection SaveGalaxyInterfaceBoardSection(SaveParameters<GalaxyInterfaceBoardSection> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSection(DeleteParameters<GalaxyInterfaceBoardSection> parameters);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionUnique(GalaxyInterfaceBoardSection data);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool ExecuteGalaxyInterfaceBoardSectionCommand(CommandParameters<GalaxyInterfaceBoardSectionCommandAction> parameters);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsForPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsForPanelAddressAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsForInterfaceBoardAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSection> GetGalaxyInterfaceBoardSectionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSection> SaveGalaxyInterfaceBoardSectionAsync(SaveParameters<GalaxyInterfaceBoardSection> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyInterfaceBoardSectionByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyInterfaceBoardSectionAsync(DeleteParameters<GalaxyInterfaceBoardSection> parameters);

        [OperationContract]
        Task<bool> IsGalaxyInterfaceBoardSectionReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyInterfaceBoardSectionUniqueAsync(GalaxyInterfaceBoardSection data);

        [OperationContract]
        Task<bool> ExecuteGalaxyInterfaceBoardSectionCommandAsync(CommandParameters<GalaxyInterfaceBoardSectionCommandAction> parameters);
        #endregion 
        #endregion

        #region Galaxy Hardware Module Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyHardwareModule SaveGalaxyHardwareModule(SaveParameters<GalaxyHardwareModule> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyHardwareModuleByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyHardwareModule(DeleteParameters<GalaxyHardwareModule> parameters);

        [OperationContract]
        bool IsGalaxyHardwareModuleReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyHardwareModuleUnique(GalaxyHardwareModule data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForPanelAddressAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForInterfaceBoardAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForInterfaceBoardSectionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModule> GetGalaxyHardwareModuleAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModule> SaveGalaxyHardwareModuleAsync(SaveParameters<GalaxyHardwareModule> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyHardwareModuleByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyHardwareModuleAsync(DeleteParameters<GalaxyHardwareModule> parameters);

        [OperationContract]
        Task<bool> IsGalaxyHardwareModuleReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyHardwareModuleUniqueAsync(GalaxyHardwareModule data);
        #endregion 
        #endregion

        #region Galaxy Interface Board Section Node Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyInterfaceBoardSectionNode SaveGalaxyInterfaceBoardSectionNode(SaveParameters<GalaxyInterfaceBoardSectionNode> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionNodeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyInterfaceBoardSectionNode(DeleteParameters<GalaxyInterfaceBoardSectionNode> parameters);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionNodeReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyInterfaceBoardSectionNodeUnique(GalaxyInterfaceBoardSectionNode data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForPanelAddressAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSectionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModuleAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode> GetGalaxyInterfaceBoardSectionNodeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode> SaveGalaxyInterfaceBoardSectionNodeAsync(SaveParameters<GalaxyInterfaceBoardSectionNode> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyInterfaceBoardSectionNodeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyInterfaceBoardSectionNodeAsync(DeleteParameters<GalaxyInterfaceBoardSectionNode> parameters);

        [OperationContract]
        Task<bool> IsGalaxyInterfaceBoardSectionNodeReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyInterfaceBoardSectionNodeUniqueAsync(GalaxyInterfaceBoardSectionNode data);
        #endregion
        #endregion

        #region Galaxy CPU Flash Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyFlashImage SaveGalaxyFlashImage(SaveParameters<GalaxyFlashImage> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyFlashImageByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyFlashImage(DeleteParameters<GalaxyFlashImage> parameters);

        [OperationContract]
        bool IsGalaxyFlashImageReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyFlashImageUnique(GalaxyFlashImage data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyFlashImage[]> GetAllGalaxyFlashImagesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyFlashImage[]> GetAllGalaxyFlashImagesForGalaxyCpuModelTypeCodeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyFlashImage[]> GetAllGalaxyFlashImagesForGalaxyCpuModelUidAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyFlashImage> GetGalaxyFlashImageAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyFlashImage> SaveGalaxyFlashImageAsync(SaveParameters<GalaxyFlashImage> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyFlashImageByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyFlashImageAsync(DeleteParameters<GalaxyFlashImage> parameters);

        [OperationContract]
        Task<bool> IsGalaxyFlashImageReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyFlashImageUniqueAsync(GalaxyFlashImage data);
        #endregion
        #endregion
        #endregion

        #region Galaxy Data Operations

        #region Galaxy Access Group Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessGroupEx SaveAccessGroup(SaveParameters<AccessGroup> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessGroupByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
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

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<AccessGroupEx>> GetAllAccessGroupsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessGroupEx>> GetAllAccessGroupsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessGroupEx>> GetAllAccessGroupsForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessGroupEx> GetAccessGroupAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessGroupEx> SaveAccessGroupAsync(SaveParameters<AccessGroup> parameters);

        [OperationContract]
        Task<int> DeleteAccessGroupByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteAccessGroupAsync(DeleteParameters<AccessGroup> parameters);

        [OperationContract]
        Task<bool> IsAccessGroupReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsAccessGroupUniqueAsync(AccessGroup data);

        [OperationContract]
        Task<int> GetAvailableAccessGroupNumberAsync(Guid clusterUid, GalaxySMS.Common.Enums.ChooseAvailableAccessGroupNumberRange rangeOption);

        [OperationContract]
        Task<AccessGroupEditingData> GetAccessGroupEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessGroupPersonInfo>> GetPersonInfoForAccessGroupAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ValidationProblemDetails> ValidateAccessGroupAsync(SaveParameters<AccessGroup> parameters);

        #endregion 

        #endregion

        ////#region Galaxy Schedule Operations
        ////[OperationContract]
        ////GalaxyClusterTimeScheduleMap[] GetAllGalaxyClusterTimeScheduleMaps(GetParametersWithPhoto parameters);

        ////[OperationContract]
        ////GalaxyClusterTimeScheduleMap[] GetAllGalaxyClusterTimeScheduleMapsForEntity(GetParametersWithPhoto parameters);

        ////[OperationContract]
        ////GalaxyClusterTimeScheduleMap[] GetAllGalaxyClusterTimeScheduleMapsForCluster(GetParametersWithPhoto parameters);

        ////[OperationContract]
        ////[FaultContract(typeof(ExceptionDetailEx))]
        ////GalaxyClusterTimeScheduleMap GetGalaxyClusterTimeScheduleMap(GetParametersWithPhoto parameters);

        ////[OperationContract]
        //////[TransactionFlow(TransactionFlowOption.Allowed)]
        ////[FaultContract(typeof(ExceptionDetailEx))]
        ////GalaxyClusterTimeScheduleMap SaveGalaxyClusterTimeScheduleMap(SaveParameters<GalaxyClusterTimeScheduleMap> parameters);

        ////[OperationContract]
        //////[TransactionFlow(TransactionFlowOption.Allowed)]
        ////[FaultContract(typeof(ExceptionDetailEx))]
        ////int DeleteGalaxyClusterTimeScheduleMapByPk(DeleteParameters parameters);

        ////[OperationContract]
        //////[TransactionFlow(TransactionFlowOption.Allowed)]
        ////[FaultContract(typeof(ExceptionDetailEx))]
        ////int DeleteGalaxyClusterTimeScheduleMap(DeleteParameters<GalaxyClusterTimeScheduleMap> parameters);

        ////[OperationContract]
        ////bool IsGalaxyClusterTimeScheduleMapReferenced(Guid uid);

        ////[OperationContract]
        ////bool IsGalaxyClusterTimeScheduleMapUnique(GalaxyClusterTimeScheduleMap data);

        ////#endregion

        #region Galaxy Area Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Area SaveArea(SaveParameters<Area> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAreaByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteArea(DeleteParameters<Area> parameters);

        [OperationContract]
        bool IsAreaReferenced(Guid uid);

        [OperationContract]
        bool IsAreaUnique(Area data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<Area>> GetAllAreasAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<Area>> GetAllAreasForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<Area>> GetAllAreasForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Area> GetAreaAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Area> SaveAreaAsync(SaveParameters<Area> parameters);

        [OperationContract]
        Task<int> DeleteAreaByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteAreaAsync(DeleteParameters<Area> parameters);

        [OperationContract]
        Task<bool> IsAreaReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsAreaUniqueAsync(Area data);
        #endregion 

        #endregion

        #region Galaxy Input Output Group Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        InputOutputGroup SaveInputOutputGroup(SaveParameters<InputOutputGroup> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteInputOutputGroupByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteInputOutputGroup(DeleteParameters<InputOutputGroup> parameters);

        [OperationContract]
        bool IsInputOutputGroupReferenced(Guid uid);

        [OperationContract]
        bool IsInputOutputGroupUnique(InputOutputGroup data);


        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool ExecuteInputOutputGroupCommand(CommandParameters<InputOutputGroupCommandAction> parameters);

        #endregion

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<InputOutputGroup>> GetAllInputOutputGroupsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputOutputGroup>> GetAllInputOutputGroupsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputOutputGroup>> GetAllInputOutputGroupsForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<InputOutputGroup>> GetAllInputOutputGroupsForClusterAddressAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InputOutputGroup> GetInputOutputGroupForClusterAddressAndInputOutputGroupNumberAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InputOutputGroupAssignmentSource[]> GetInputOutputGroupAssignmentSourcesForInputOutputGroupAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InputOutputGroup> GetInputOutputGroupAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InputOutputGroup> SaveInputOutputGroupAsync(SaveParameters<InputOutputGroup> parameters);

        [OperationContract]
        Task<int> DeleteInputOutputGroupByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteInputOutputGroupAsync(DeleteParameters<InputOutputGroup> parameters);

        [OperationContract]
        Task<bool> IsInputOutputGroupReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsInputOutputGroupUniqueAsync(InputOutputGroup data);

        [OperationContract]
        Task<bool> ExecuteInputOutputGroupCommandAsync(CommandParameters<InputOutputGroupCommandAction> parameters);
        #endregion 

        #endregion
        #endregion

        #region Access Profile Operations
        #region Synchronous Operations
        [OperationContract]
        ArrayResponse<AccessProfile> GetAllAccessProfiles(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessProfileListItem> GetAllAccessProfilesList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessProfile> GetAllAccessProfilesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<AccessProfileListItem> GetAllAccessProfilesListForEntity(GetParametersWithPhoto parameters);


        [OperationContract]
        ArrayResponse<AccessProfile> GetAllAccessProfilesForMappedEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessProfile GetAccessProfile(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessProfile SaveAccessProfile(SaveParameters<AccessProfile> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteAccessProfileByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int SyncPersonsWithAccessProfile(SaveParameters<AccessProfile> parameters);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<AccessProfile>> GetAllAccessProfilesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessProfileListItem>> GetAllAccessProfilesListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessProfile>> GetAllAccessProfilesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessProfileListItem>> GetAllAccessProfilesListForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<AccessProfile>> GetAllAccessProfilesForMappedEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessProfile> GetAccessProfileAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessProfile> SaveAccessProfileAsync(SaveParameters<AccessProfile> parameters);

        [OperationContract]
        Task<int> DeleteAccessProfileByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteAccessProfileAsync(DeleteParameters<AccessProfile> parameters);

        [OperationContract]
        Task<bool> IsAccessProfileReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsAccessProfileUniqueAsync(AccessProfile data);

        [OperationContract]
        Task<AccessProfileEditingData> GetAccessProfileEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessAndAlarmControlPermissionsEditingData> GetAccessProfileClusterPermissionsEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<int> SyncPersonsWithAccessProfileAsync(SaveParameters<AccessProfile> parameters);

        #endregion
        #endregion

        #region Department Operations
        #region Synchronous operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Department SaveDepartment(SaveParameters<Department> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDepartmentByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteDepartment(DeleteParameters<Department> parameters);

        [OperationContract]
        bool IsDepartmentReferenced(Guid departmentUId);

        [OperationContract]
        bool IsDepartmentUnique(Department department);
        #endregion

        #region Async operations
        [OperationContract]
        Task<ArrayResponse<Department>> GetAllDepartmentsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<Department>> GetAllDepartmentsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<ListItemBase>> GetAllDepartmentsListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<ListItemBase>> GetAllDepartmentsListEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Department> GetDepartmentAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Department> SaveDepartmentAsync(SaveParameters<Department> parameters);

        [OperationContract]
        Task<int> DeleteDepartmentByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteDepartmentAsync(DeleteParameters<Department> parameters);

        [OperationContract]
        Task<bool> IsDepartmentReferencedAsync(Guid departmentUId);

        [OperationContract]
        Task<bool> IsDepartmentUniqueAsync(Department department);
        #endregion

        #endregion

        #region BadgeTemplate Operations
        #region Synchronous operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        BadgeTemplate SaveBadgeTemplate(SaveParameters<BadgeTemplate> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteBadgeTemplateByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteBadgeTemplate(DeleteParameters<BadgeTemplate> parameters);

        [OperationContract]
        bool IsBadgeTemplateReferenced(Guid badgeTemplateUId);

        [OperationContract]
        bool IsBadgeTemplateUnique(BadgeTemplate badgeTemplate);
        #endregion

        #region Async operations
        [OperationContract]
        Task<BadgeTemplate[]> GetAllBadgeTemplatesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<BadgeTemplate[]> GetAllBadgeTemplatesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllBadgeTemplatesListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllBadgeTemplatesListEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<BadgeTemplate> GetBadgeTemplateAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<BadgeTemplate> SaveBadgeTemplateAsync(SaveParameters<BadgeTemplate> parameters);

        [OperationContract]
        Task<int> DeleteBadgeTemplateByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteBadgeTemplateAsync(DeleteParameters<BadgeTemplate> parameters);

        [OperationContract]
        Task<bool> IsBadgeTemplateReferencedAsync(Guid badgeTemplateUId);

        [OperationContract]
        Task<bool> IsBadgeTemplateUniqueAsync(BadgeTemplate badgeTemplate);
        #endregion

        #endregion

        #region PersonRecordType Operations
        #region Synchronous operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        PersonRecordType SavePersonRecordType(SaveParameters<PersonRecordType> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePersonRecordTypeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePersonRecordType(DeleteParameters<PersonRecordType> parameters);

        [OperationContract]
        bool IsPersonRecordTypeReferenced(Guid personRecordTypeUId);

        [OperationContract]
        bool IsPersonRecordTypeUnique(PersonRecordType personRecordType);
        #endregion

        #region Async operations
        [OperationContract]
        Task<PersonRecordType[]> GetAllPersonRecordTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<PersonRecordType[]> GetAllPersonRecordTypesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllPersonRecordTypesListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ListItemBase[]> GetAllPersonRecordTypesListEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<PersonRecordType> GetPersonRecordTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<PersonRecordType> SavePersonRecordTypeAsync(SaveParameters<PersonRecordType> parameters);

        [OperationContract]
        Task<int> DeletePersonRecordTypeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeletePersonRecordTypeAsync(DeleteParameters<PersonRecordType> parameters);

        [OperationContract]
        Task<bool> IsPersonRecordTypeReferencedAsync(Guid personRecordTypeUId);

        [OperationContract]
        Task<bool> IsPersonRecordTypeUniqueAsync(PersonRecordType personRecordType);
        #endregion

        #endregion

        #region Person Operations
        #region Synchronous Operations
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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Person SavePerson(SaveParameters<Person> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePersonByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePerson(DeleteParameters<Person> parameters);

        [OperationContract]
        bool IsPersonReferenced(Guid uid);

        [OperationContract]
        bool IsPersonUnique(Person data);

        [OperationContract]
        PersonEditingData GetPersonEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessAndAlarmControlPermissionsEditingData GetAccessAndAlarmControlPermissionsEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        UserInterfacePageControlData GetPersonUserInterfacePageControlData(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Person SyncPersonWithAccessProfile(GetParametersWithPhoto parameters);


        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        SaveDefaultPhotoResponse SavePersonPhoto(SaveParameters<SavePhotoParameters> parameters);

        [OperationContract]
        PersonInfoWithMissingPhotoUrl[] GetPersonInfoWithNoPhotoPublicUrl(Guid entityId);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        PersonSavePhotoResponse[] SendPersonPhotosToCdn(Guid personUid);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePersonPhoto(DeleteParameters parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Person UpdatePersonProperties(SaveParameters<SavePersonPropertiesParameters> parameters);

        #endregion

        #region Async Operations
        [OperationContract]
        Task<Person[]> GetAllPersonsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Person[]> GetAllPersonsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<PersonSummary[]> SearchPersonsAsync(PersonSummarySearchParameters parameters);

        [OperationContract]
        Task<ArrayResponse<PersonSummary>> SearchPersonsPagedAsync(PersonSummarySearchParameters parameters);


        [OperationContract]
        Task<Person> GetPersonAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Person> SavePersonAsync(SaveParameters<Person> parameters);

        [OperationContract]
        Task<int> DeletePersonByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeletePersonAsync(DeleteParameters<Person> parameters);

        [OperationContract]
        Task<bool> IsPersonReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsPersonUniqueAsync(Person data);

        [OperationContract]
        Task<PersonEditingData> GetPersonEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessAndAlarmControlPermissionsEditingData> GetAccessAndAlarmControlPermissionsEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<UserInterfacePageControlData> GetPersonUserInterfacePageControlDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Person> SyncPersonWithAccessProfileAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<SaveDefaultPhotoResponse> SavePersonPhotoAsync(SaveParameters<SavePhotoParameters> parameters);

        [OperationContract]
        Task<PersonInfoWithMissingPhotoUrl[]> GetPersonInfoWithNoPhotoPublicUrlAsync(Guid entityId);

        [OperationContract]
        Task<PersonSavePhotoResponse[]> SendPersonPhotosToCdnAsync(Guid personUid);

        [OperationContract]
        Task<int> DeletePersonPhotoAsync(DeleteParameters parameters);

        [OperationContract]
        Task<Person> UpdatePersonPropertiesAsync(SaveParameters<SavePersonPropertiesParameters> parameters);
        #endregion
        #endregion

        #region User Defined Property Operations
        #region Synchronous Operations

        [OperationContract]
        UserDefinedProperty[] GetAllUserDefinedProperties(GetParametersWithPhoto parameters);

        [OperationContract]
        UserDefinedProperty[] GetAllUserDefinedPropertiesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserDefinedProperty GetUserDefinedProperty(GetParametersWithPhoto parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserDefinedProperty SaveUserDefinedProperty(SaveParameters<UserDefinedProperty> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUserDefinedPropertyByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUserDefinedProperty(DeleteParameters<UserDefinedProperty> parameters);

        [OperationContract]
        bool IsUserDefinedPropertyReferenced(Guid uid);

        [OperationContract]
        bool IsUserDefinedPropertyUnique(UserDefinedProperty data);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserInterfacePageControlData SaveUserDefinedProperties(SaveParameters<List<UserDefinedProperty>> parameters);
        #endregion

        #region Async Operations

        [OperationContract]
        Task<UserDefinedProperty[]> GetAllUserDefinedPropertiesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<UserDefinedProperty[]> GetAllUserDefinedPropertiesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<UserDefinedProperty> GetUserDefinedPropertyAsync(GetParametersWithPhoto parameters);


        [OperationContract]
        Task<UserDefinedProperty> SaveUserDefinedPropertyAsync(SaveParameters<UserDefinedProperty> parameters);

        [OperationContract]
        Task<int> DeleteUserDefinedPropertyByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteUserDefinedPropertyAsync(DeleteParameters<UserDefinedProperty> parameters);

        [OperationContract]
        Task<bool> IsUserDefinedPropertyReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsUserDefinedPropertyUniqueAsync(UserDefinedProperty data);


        [OperationContract]
        Task<UserInterfacePageControlData> SaveUserDefinedPropertiesAsync(SaveParameters<List<UserDefinedProperty>> parameters);
        #endregion
        #endregion

        #region Credential Operations
        #region Synchronous Operations
        [OperationContract]
        DecodedCredential[] DecodeCredentialNumber(DecodeCredentialNumberParameters parameters);

        [OperationContract]
        Credential_PanelLoadData[] GetCredentialDataChangesToLoadForCpu(GetParametersWithPhoto parameters);

        [OperationContract]
        Credential_PanelLoadData[] GetAllCredentialPanelData(GetParametersWithPhoto parameters);

        [OperationContract]
        CredentialToDeleteFromCpu[] GetCredentialDataToDeleteLoadForCpu(GetParametersWithPhoto parameters);

        [OperationContract]
        CredentialFormat GetCredentialFormat(GetParametersWithPhoto parameters);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<DecodedCredential[]> DecodeCredentialNumberAsync(DecodeCredentialNumberParameters parameters);
        [OperationContract]
        Task<Credential_PanelLoadData[]> GetCredentialDataChangesToLoadForCpuAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Credential_PanelLoadData[]> GetAllCredentialPanelDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CredentialToDeleteFromCpu[]> GetCredentialDataToDeleteLoadForCpuAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<CredentialFormat> GetCredentialFormatAsync(GetParametersWithPhoto parameters);
        #endregion
        #endregion

        #region Activity Event Data Operations
        #region Synchronous Operations
        [OperationContract]
        Credential_ActivityEventData GetCredentialActivityEventData(byte[] parameters);
        #endregion
        #region Asynchronous Operations
        [OperationContract]
        Task<Credential_ActivityEventData> GetCredentialActivityEventDataAsync(byte[] parameters);
        #endregion
        #endregion

        #region GalaxyActivityEventType
        #region Synchronous Operations

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
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyActivityEventType SaveGalaxyActivityEventType(SaveParameters<GalaxyActivityEventType> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyActivityEventTypeByPk(DeleteParameters parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteGalaxyActivityEventType(DeleteParameters<GalaxyActivityEventType> parameters);

        [OperationContract]
        bool IsGalaxyActivityEventTypeReferenced(Guid uid);

        [OperationContract]
        bool IsGalaxyActivityEventTypeUnique(GalaxyActivityEventType data);
        #endregion

        #region Async Operations

        [OperationContract]
        Task<GalaxyActivityEventType[]> GetAllGalaxyActivityEventTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyActivityEventTypeBasicGroups> GetGalaxyActivityEventTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyActivityEventType[]> GetAllGalaxyActivityEventTypeForCultureAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyActivityEventType> GetGalaxyActivityEventTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyActivityEventType> GetGalaxyActivityEventTypeByEventTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyActivityEventType> SaveGalaxyActivityEventTypeAsync(SaveParameters<GalaxyActivityEventType> parameters);

        [OperationContract]
        Task<int> DeleteGalaxyActivityEventTypeByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteGalaxyActivityEventTypeAsync(DeleteParameters<GalaxyActivityEventType> parameters);

        [OperationContract]
        Task<bool> IsGalaxyActivityEventTypeReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsGalaxyActivityEventTypeUniqueAsync(GalaxyActivityEventType data);
        #endregion
        #endregion

        #region Alarm Acknowledgement Operations
        #region Synchronous Operations

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AcknowledgedAlarmBasicData AcknowledgeAlarmEvent(SaveParameters<AcknowledgeAlarmEventParameters> parameters);

        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int UnacknowledgeAlarmEvent(SaveParameters<UnacknowledgeAlarmEventParameters> parameters);

        [OperationContract]
        PanelActivityLogMessage[] GetUnacknowledgedAlarms(GetParametersWithPhoto parameters);

        #endregion

        #region Async Operations
        [OperationContract]
        Task<AcknowledgedAlarmBasicData> AcknowledgeAlarmEventAsync(SaveParameters<AcknowledgeAlarmEventParameters> parameters);
 
        [OperationContract]
        Task<int> UnacknowledgeAlarmEventAsync(SaveParameters<UnacknowledgeAlarmEventParameters> parameters);

        [OperationContract]
        Task<PanelActivityLogMessage[]> GetUnacknowledgedAlarmsAsync(GetParametersWithPhoto parameters);

        #endregion
        #endregion

        #region idPRODUCER Operations

        #region Sync Operations

        [OperationContract]
        //        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        SubscriptionData IdProducerEnsureIsLicensed(SaveParameters<IdProducerSaveMasterLicenseParameters> parameters);

        [OperationContract]
        //       [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool IdProducerUpdateRootSubscriptionCompanyName(SaveParameters<IdProducerUpdateRootCustomerNameParameters> parameters);

        [OperationContract]
        //        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        SubscriptionData IdProducerSyncSubscriptionAndEntity(SaveParameters<IdProducerSyncSubscriptionAndEntityParameters> parameters);

        [OperationContract]
        SubscriptionData[] IdProducerGetSubscriptions(GetParametersWithPhoto parameters);

        [OperationContract]
        SubscriptionData IdProducerGetRootSubscription(GetParametersWithPhoto parameters);

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

        #region Async operations
        [OperationContract]
        Task<SubscriptionData> IdProducerEnsureIsLicensedAsync(SaveParameters<IdProducerSaveMasterLicenseParameters> parameters);

        [OperationContract]
        Task<bool> IdProducerUpdateRootSubscriptionCompanyNameAsync(SaveParameters<IdProducerUpdateRootCustomerNameParameters> parameters);

        [OperationContract]
        Task<SubscriptionData> IdProducerSyncSubscriptionAndEntityAsync(SaveParameters<IdProducerSyncSubscriptionAndEntityParameters> parameters);

        [OperationContract]
        Task<SubscriptionData[]> IdProducerGetSubscriptionsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<SubscriptionData> IdProducerGetRootSubscriptionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<PrintDispatcher[]> GetPrintDispatchersAsync(GetParametersWithPhoto<IdProducerRequestParameters> parameters);

        [OperationContract]
        Task<Printer[]> GetPrintersAsync(GetParametersWithPhoto<IdProducerRequestParameters> parameters);

        [OperationContract]
        Task<PreviewData> GetPreviewImagesForCredentialAsync(GetParametersWithPhoto<IdProducerPrintPreviewRequestParameters> parameters);

        [OperationContract]
        Task<CreatedPrintRequest[]> CreatePrintRequestForCredentialAsync(GetParametersWithPhoto<IdProducerPrintRequestParameters> parameters);

        [OperationContract]
        Task<ServerVersionNumber> GetIdProducerVersionAsync();
        #endregion

        #endregion

        #region Validation Operations
        #region Sync Operations
        [OperationContract]
        //        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]

        ValidationProblemDetails ValidateByGuid(GuidValidationRequest data);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<ValidationProblemDetails> ValidateByGuidAsync(GuidValidationRequest data);

        #endregion
        #endregion


        #region Event Operations
        #region Sync Operations
        [OperationContract]
        ArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters);

        [OperationContract]
        EventFilterData GetEventFilterData(EventFilterDataSelectionParameters parameters);
        
        [OperationContract]
        EntityDeviceAlertEventSettings GetDeviceAlertEventSettings(GetParametersWithPhoto parameters);
        
        [OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        EntityDeviceAlertEventSettings SaveDeviceAlertEventSettings(SaveParameters<EntityDeviceAlertEventSettings> parameters);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<ArrayResponse<ActivityHistoryEvent>> GetActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters);

        [OperationContract]
        Task<EventFilterData> GetEventFilterDataAsync(EventFilterDataSelectionParameters parameters);
   
        [OperationContract]
        Task<EntityDeviceAlertEventSettings> GetDeviceAlertEventSettingsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<EntityDeviceAlertEventSettings> SaveDeviceAlertEventSettingsAsync(SaveParameters<EntityDeviceAlertEventSettings> parameters);
        #endregion
        #endregion

    }

}
