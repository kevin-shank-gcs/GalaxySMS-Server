using GalaxySMS.Client.Entities;
using GalaxySMS.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Security;

namespace GalaxySMS.Client.Contracts
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
        Site[] GetAllSitesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        Site[] GetAllSitesForRegion(GetParametersWithPhoto parameters);

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
        bool IsSiteReferenced(Guid siteUId);

        [OperationContract]
        bool IsSiteUnique(Site site);
        #endregion

        #region Async operations
        [OperationContract]
        Task<Site[]> GetAllSitesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Site[]> GetAllSitesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Site[]> GetAllSitesForRegionAsync(GetParametersWithPhoto parameters);

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
        [TransactionFlow(TransactionFlowOption.Allowed)]
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
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        CredentialReaderTypeFeatureMap SaveCredentialReaderTypeFeatureMap(
            SaveParameters<CredentialReaderTypeFeatureMap> parameters);

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
        AccessPortal[] GetAllAccessPortals(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessPortal[] GetAllAccessPortalsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessPortal[] GetAllAccessPortalsForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessPortal[] GetAllAccessPortalsForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessPortal[] GetAllAccessPortalsForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessPortal[] GetAllAccessPortalsForGalaxyPanel(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessPortalListItem[] GetAccessPortalListItemsForGalaxyPanel(GetParameters parameters);

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
        bool ExecuteAccessPortalCommand(CommandParameters<AccessPortalCommandAction> parameters);

        #endregion
        #region Async operations
        [OperationContract]
        Task<AccessPortal[]> GetAllAccessPortalsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessPortal[]> GetAllAccessPortalsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessPortal[]> GetAllAccessPortalsForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessPortal[]> GetAllAccessPortalsForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessPortal[]> GetAllAccessPortalsForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessPortal[]> GetAllAccessPortalsForGalaxyPanelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessPortalListItem[]> GetAccessPortalListItemsForGalaxyPanelAsync(GetParameters parameters);

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
        Task<bool> ExecuteAccessPortalCommandAsync(CommandParameters<AccessPortalCommandAction> parameters);

        #endregion
        #endregion

        #region Time Schedule Operations
        #region Synchronous Operations
        [OperationContract]
        TimeSchedule[] GetAllTimeSchedules(GetParametersWithPhoto parameters);

        [OperationContract]
        TimeSchedule[] GetAllTimeSchedulesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        TimeSchedule[] GetAllTimeSchedulesForMappedEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        TimeSchedule[] GetAllTimeSchedulesForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        TimeSchedule[] GetAllTimeSchedulesForAssaAbloyDsr(GetParametersWithPhoto parameters);

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
        #endregion

        #region Async Operations
        [OperationContract]
        Task<TimeSchedule[]> GetAllTimeSchedulesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<TimeSchedule[]> GetAllTimeSchedulesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<TimeSchedule[]> GetAllTimeSchedulesForMappedEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<TimeSchedule[]> GetAllTimeSchedulesForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<TimeSchedule[]> GetAllTimeSchedulesForAssaAbloyDsrAsync(GetParametersWithPhoto parameters);

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
        #endregion
        #endregion

        #region Time Period Operations
        #region Synchronous Operations
        [OperationContract]
        TimePeriod[] GetAllTimePeriods(GetParametersWithPhoto parameters);

        [OperationContract]
        TimePeriod[] GetAllTimePeriodsForEntity(GetParametersWithPhoto parameters);

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

        #region Async Operations
        [OperationContract]
        Task<TimePeriod[]> GetAllTimePeriodsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<TimePeriod[]> GetAllTimePeriodsForEntityAsync(GetParametersWithPhoto parameters);

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
        GalaxyTimePeriod[] GetAllGalaxyTimePeriods(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyTimePeriod[] GetAllGalaxyTimePeriodsForEntity(GetParametersWithPhoto parameters);

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

        #region Async Operations
        [OperationContract]
        Task<GalaxyTimePeriod[]> GetAllGalaxyTimePeriodsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyTimePeriod[]> GetAllGalaxyTimePeriodsForEntityAsync(GetParametersWithPhoto parameters);

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
        DayType[] GetAllDayTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        DayType[] GetAllDayTypesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        DayType[] GetAllDayTypesForMappedEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        DayType[] GetAllDayTypesForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        DayType[] GetAllDayTypesForAssaAbloyDsr(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        DayType GetDayType(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        DayType SaveDayType(SaveParameters<DayType> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        DayType[] EnsureDefaultDayTypesExistForEntity(SaveParameters<DayType> parameters);

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

        #region Async Operations
        [OperationContract]
        Task<DayType[]> GetAllDayTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DayType[]> GetAllDayTypesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DayType[]> GetAllDayTypesForMappedEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DayType[]> GetAllDayTypesForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DayType[]> GetAllDayTypesForAssaAbloyDsrAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DayType> GetDayTypeAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DayType> SaveDayTypeAsync(SaveParameters<DayType> parameters);

        [OperationContract]
        Task<DayType[]> EnsureDefaultDayTypesExistForEntityAsync(SaveParameters<DayType> parameters);

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
        DateType[] GetAllDateTypes(GetParametersWithPhoto parameters);

        [OperationContract]
        DateType[] GetAllDateTypesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        DateType[] GetAllDateTypesForMappedEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        DateType[] GetAllDateTypesForDayType(GetParametersWithPhoto parameters);

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

        #region Async Operations
        [OperationContract]
        Task<DateType[]> GetAllDateTypesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DateType[]> GetAllDateTypesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DateType[]> GetAllDateTypesForMappedEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<DateType[]> GetAllDateTypesForDayTypeAsync(GetParametersWithPhoto parameters);

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
        [TransactionFlow(TransactionFlowOption.Allowed)]
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
        Cluster[] GetAllClusters(GetParametersWithPhoto parameters);

        [OperationContract]
        Cluster[] GetAllClustersForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        Cluster[] GetAllClustersForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Cluster GetCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Cluster GetClusterByHardwareAddress(GetParametersWithPhoto parameters);

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
        #endregion

        #region Async Operations
        [OperationContract]
        Task<Cluster[]> GetAllClustersAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Cluster[]> GetAllClustersForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Cluster[]> GetAllClustersForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Cluster> GetClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Cluster> GetClusterByHardwareAddressAsync(GetParametersWithPhoto parameters);

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
        GalaxyPanel[] GetAllGalaxyPanels(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyPanel[] GetAllGalaxyPanelsForCluster(GetParametersWithPhoto parameters);

        //[OperationContract]
        //GalaxyPanel[] GetAllGalaxyPanelsForEntity(GetParametersWithPhoto parameters);

        //[OperationContract]
        //GalaxyPanel[] GetAllGalaxyPanelsForRegion(GetParametersWithPhoto parameters);

        [OperationContract]
        GalaxyPanel[] GetAllGalaxyPanelsForSite(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        GalaxyPanel GetGalaxyPanel(GetParametersWithPhoto parameters);

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
        GalaxyPanelEditingData GetGalaxyPanelEditingData(GetParametersWithPhoto parameters);

        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyPanel[]> GetAllGalaxyPanelsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanel[]> GetAllGalaxyPanelsForClusterAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<GalaxyPanel[]> GetAllGalaxyPanelsForEntityAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<GalaxyPanel[]> GetAllGalaxyPanelsForRegionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanel[]> GetAllGalaxyPanelsForSiteAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyPanel> GetGalaxyPanelAsync(GetParametersWithPhoto parameters);

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
        GalaxyCpuLoggingControl SaveGalaxyCpuLoggingControl(SaveParameters<GalaxyCpuLoggingControl> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool ExecuteGalaxyCpuCommand(CommandParameters<GalaxyCpuCommandAction> parameters);

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
        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsForPanelAsync(GetParametersWithPhoto parameters);

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
        #endregion

        #region Async Operations
        [OperationContract]
        Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsForPanelAsync(GetParametersWithPhoto parameters);

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

        #region Async Operations
        [OperationContract]
        Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForPanelAsync(GetParametersWithPhoto parameters);

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

        #region Async Operations
        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForPanelAsync(GetParametersWithPhoto parameters);

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
        #endregion

        #region Galaxy Data Operations

        #region Galaxy Access Group Operations
        #region Synchronous Operations
        [OperationContract]
        AccessGroup[] GetAllAccessGroups(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessGroup[] GetAllAccessGroupsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        AccessGroup[] GetAllAccessGroupsForCluster(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessGroup GetAccessGroup(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        AccessGroup SaveAccessGroup(SaveParameters<AccessGroup> parameters);

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
        #endregion

        #region Async Operations
        [OperationContract]
        Task<AccessGroup[]> GetAllAccessGroupsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessGroup[]> GetAllAccessGroupsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessGroup[]> GetAllAccessGroupsForClusterAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessGroup> GetAccessGroupAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<AccessGroup> SaveAccessGroupAsync(SaveParameters<AccessGroup> parameters);

        [OperationContract]
        Task<int> DeleteAccessGroupByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteAccessGroupAsync(DeleteParameters<AccessGroup> parameters);

        [OperationContract]
        Task<bool> IsAccessGroupReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsAccessGroupUniqueAsync(AccessGroup data);
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
        ////[TransactionFlow(TransactionFlowOption.Allowed)]
        ////[FaultContract(typeof(ExceptionDetailEx))]
        ////GalaxyClusterTimeScheduleMap SaveGalaxyClusterTimeScheduleMap(SaveParameters<GalaxyClusterTimeScheduleMap> parameters);

        ////[OperationContract]
        ////[TransactionFlow(TransactionFlowOption.Allowed)]
        ////[FaultContract(typeof(ExceptionDetailEx))]
        ////int DeleteGalaxyClusterTimeScheduleMapByPk(DeleteParameters parameters);

        ////[OperationContract]
        ////[TransactionFlow(TransactionFlowOption.Allowed)]
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
        Area[] GetAllAreas(GetParametersWithPhoto parameters);

        [OperationContract]
        Area[] GetAllAreasForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        Area[] GetAllAreasForCluster(GetParametersWithPhoto parameters);

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

        #region Async Operations
        [OperationContract]
        Task<Area[]> GetAllAreasAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Area[]> GetAllAreasForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Area[]> GetAllAreasForClusterAsync(GetParametersWithPhoto parameters);

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
        InputOutputGroup[] GetAllInputOutputGroups(GetParametersWithPhoto parameters);

        [OperationContract]
        InputOutputGroup[] GetAllInputOutputGroupsForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        InputOutputGroup[] GetAllInputOutputGroupsForCluster(GetParametersWithPhoto parameters);

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
        #endregion

        #region Async Operations
        [OperationContract]
        Task<InputOutputGroup[]> GetAllInputOutputGroupsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InputOutputGroup[]> GetAllInputOutputGroupsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<InputOutputGroup[]> GetAllInputOutputGroupsForClusterAsync(GetParametersWithPhoto parameters);

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
        #endregion 

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

        [OperationContract]
        AccessAndAlarmControlPermissionsEditingData GetAccessAndAlarmControlPermissionsEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        UserInterfacePageControlData GetPersonUserInterfacePageControlData(GetParametersWithPhoto parameters);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<Person[]> GetAllPersonsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Person[]> GetAllPersonsForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<PersonSummary[]> SearchPersonsAsync(PersonSummarySearchParameters parameters);

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
        List<DecodedCredential> DecodeCredentialNumber(DecodeCredentialNumberParameters parameters);
        #endregion

        #region Async Operations
        [OperationContract]
        Task<List<DecodedCredential>> DecodeCredentialNumberAsync(DecodeCredentialNumberParameters parameters);
        #endregion
        #endregion

        #region Activity Event Data Operations
        #region Synchronous Operations
        [OperationContract]
        Credential_ActivityEventData GetCredentialActivityEventData(byte[] parameters);
        #endregion
        #region Synchronous Operations
        [OperationContract]
        Task<Credential_ActivityEventData> GetCredentialActivityEventDataAsync(byte[] parameters);
        #endregion
        #endregion
    }

}
