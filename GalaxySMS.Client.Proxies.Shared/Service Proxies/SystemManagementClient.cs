using GalaxySMS.Client.Contracts;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.ServiceModel.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using TimeScheduleType = GalaxySMS.Common.Enums.TimeScheduleType;
using System.Security.Cryptography;

namespace GalaxySMS.Client.Proxies
{
    [Export(typeof(ISystemManagementService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ApplicationUserSessionHeaderInspectorBehavior]
    public class SystemManagementClient : UserClientBase<ISystemManagementService>, ISystemManagementService
    {
        #region Region operations
        #region Synchronous operations
        public Region[] GetAllRegions(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRegions(parameters);
        }
        public Region[] GetAllRegionsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRegionsForEntity(parameters);
        }

        public Region GetRegion(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetRegion(parameters);
        }

        public ListItemBase[] GetAllRegionsList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRegionsList(parameters);
        }

        public ListItemBase[] GetAllRegionsListEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRegionsListEntity(parameters);
        }

        public Region SaveRegion(SaveParameters<Region> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveRegion(parameters);
        }

        public int DeleteRegionByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteRegionByPk(parameters);
        }

        public int DeleteRegion(DeleteParameters<Region> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteRegion(parameters);
        }

        public bool IsRegionReferenced(Guid regionUId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsRegionReferenced(regionUId);
        }

        public bool IsRegionUnique(Region region)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsRegionUnique(region);
        }

        #endregion

        #region Async operations
        public Task<Region[]> GetAllRegionsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRegionsAsync(parameters);
        }

        public Task<Region[]> GetAllRegionsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRegionsForEntityAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllRegionsListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRegionsListAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllRegionsListEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRegionsListEntityAsync(parameters);
        }

        public Task<Region> GetRegionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetRegionAsync(parameters);
        }

        public Task<Region> SaveRegionAsync(SaveParameters<Region> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveRegionAsync(parameters);
        }

        public Task<int> DeleteRegionByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteRegionByPkAsync(parameters);
        }

        public Task<int> DeleteRegionAsync(DeleteParameters<Region> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteRegionAsync(parameters);
        }

        public Task<bool> IsRegionReferencedAsync(Guid regionUId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsRegionReferencedAsync(regionUId);
        }

        public Task<bool> IsRegionUniqueAsync(Region region)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsRegionUniqueAsync(region);
        }
        #endregion
        #endregion

        #region Site operations
        #region Synchronous operations
        public Site[] GetAllSites(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSites(parameters);
        }

        public ListItemBase[] GetAllSitesList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesList(parameters);
        }

        public Site[] GetAllSitesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesForEntity(parameters);
        }

        public ListItemBase[] GetAllSitesForEntityList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesForEntityList(parameters);
        }

        public Site[] GetAllSitesForRegion(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesForRegion(parameters);
        }

        public ListItemBase[] GetAllSitesForRegionList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesForRegionList(parameters);
        }

        public Site GetSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSite(parameters);
        }

        public Site SaveSite(SaveParameters<Site> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSite(parameters);
        }

        public int DeleteSiteByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSiteByPk(parameters);
        }

        public int DeleteSite(DeleteParameters<Site> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSite(parameters);
        }

        public bool IsSiteReferenced(Guid siteUId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsSiteReferenced(siteUId);
        }

        public bool IsSiteUnique(Site site)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsSiteUnique(site);
        }
        #endregion

        #region Async operations

        public Task<Site[]> GetAllSitesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllSitesListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesListAsync(parameters);
        }

        public Task<Site[]> GetAllSitesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesForEntityAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllSitesForEntityListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesForEntityListAsync(parameters);
        }

        public Task<Site[]> GetAllSitesForRegionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesForRegionAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllSitesForRegionListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSitesForRegionListAsync(parameters);
        }

        public Task<Site> GetSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSiteAsync(parameters);
        }

        public Task<Site> SaveSiteAsync(SaveParameters<Site> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSiteAsync(parameters);
        }

        public Task<int> DeleteSiteByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSiteByPkAsync(parameters);
        }

        public Task<int> DeleteSiteAsync(DeleteParameters<Site> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSiteAsync(parameters);
        }

        public Task<bool> IsSiteReferencedAsync(Guid siteUId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsSiteReferencedAsync(siteUId);
        }

        public Task<bool> IsSiteUniqueAsync(Site site)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsSiteUniqueAsync(site);
        }
        #endregion
        #endregion

        #region SeedDatabase operations
        #region Synchronous operations

        public bool SeedDatabase(SaveParameters<SeedDatabaseRequest> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SeedDatabase(parameters);
        }
        #endregion

        #region Async operations

        public Task<bool> SeedDatabaseAsync(SaveParameters<SeedDatabaseRequest> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SeedDatabaseAsync(parameters);
        }
        #endregion
        #endregion

        #region Brand operations
        #region Synchronous operations

        public Brand[] GetAllBrands(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllBrands(parameters);
        }

        public Brand GetBrand(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetBrand(parameters);
        }

        public Brand SaveBrand(SaveParameters<Brand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveBrand(parameters);
        }

        public int DeleteBrandByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteBrandByPk(parameters);
        }

        public int DeleteBrand(DeleteParameters<Brand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteBrand(parameters);
        }

        public bool IsBrandReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsBrandReferenced(uid);
        }

        public bool IsBrandUnique(Brand data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsBrandUnique(data);
        }
        #endregion

        #region Async operations

        public Task<Brand[]> GetAllBrandsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllBrandsAsync(parameters);
        }

        public Task<Brand> GetBrandAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetBrandAsync(parameters);
        }

        public Task<Brand> SaveBrandAsync(SaveParameters<Brand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveBrandAsync(parameters);
        }

        public Task<int> DeleteBrandByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteBrandByPkAsync(parameters);
        }

        public Task<int> DeleteBrandAsync(DeleteParameters<Brand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteBrandAsync(parameters);
        }

        public Task<bool> IsBrandReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsBrandReferencedAsync(uid);
        }

        public Task<bool> IsBrandUniqueAsync(Brand data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsBrandUniqueAsync(data);
        }
        #endregion
        #endregion

        #region CredentialReaderDataFormat operations
        #region Synchronous operations

        public CredentialReaderDataFormat[] GetAllCredentialReaderDataFormats(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCredentialReaderDataFormats(parameters);
        }

        public CredentialReaderDataFormat GetCredentialReaderDataFormat(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialReaderDataFormat(parameters);
        }

        public CredentialReaderDataFormat SaveCredentialReaderDataFormat(SaveParameters<CredentialReaderDataFormat> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveCredentialReaderDataFormat(parameters);
        }

        public int DeleteCredentialReaderDataFormatByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderDataFormatByPk(parameters);
        }

        public int DeleteCredentialReaderDataFormat(DeleteParameters<CredentialReaderDataFormat> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderDataFormat(parameters);
        }

        public bool IsCredentialReaderDataFormatReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderDataFormatReferenced(uid);
        }

        public bool IsCredentialReaderDataFormatUnique(CredentialReaderDataFormat data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderDataFormatUnique(data);
        }
        #endregion

        #region Async operations

        public Task<CredentialReaderDataFormat[]> GetAllCredentialReaderDataFormatsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCredentialReaderDataFormatsAsync(parameters);
        }

        public Task<CredentialReaderDataFormat> GetCredentialReaderDataFormatAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialReaderDataFormatAsync(parameters);
        }

        public Task<CredentialReaderDataFormat> SaveCredentialReaderDataFormatAsync(SaveParameters<CredentialReaderDataFormat> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveCredentialReaderDataFormatAsync(parameters);
        }

        public Task<int> DeleteCredentialReaderDataFormatByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderDataFormatByPkAsync(parameters);
        }

        public Task<int> DeleteCredentialReaderDataFormatAsync(DeleteParameters<CredentialReaderDataFormat> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderDataFormatAsync(parameters);
        }

        public Task<bool> IsCredentialReaderDataFormatReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderDataFormatReferencedAsync(uid);
        }

        public Task<bool> IsCredentialReaderDataFormatUniqueAsync(CredentialReaderDataFormat data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderDataFormatUniqueAsync(data);
        }
        #endregion
        #endregion

        #region CredentialReaderType operations
        #region Synchronous operations
        public CredentialReaderType[] GetAllCredentialReaderTypes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCredentialReaderTypes(parameters);
        }

        public CredentialReaderType GetCredentialReaderType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialReaderType(parameters);
        }

        public CredentialReaderType SaveCredentialReaderType(SaveParameters<CredentialReaderType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveCredentialReaderType(parameters);
        }

        public int DeleteCredentialReaderTypeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderTypeByPk(parameters);
        }

        public int DeleteCredentialReaderType(DeleteParameters<CredentialReaderType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderType(parameters);
        }

        public bool IsCredentialReaderTypeReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderTypeReferenced(uid);
        }

        public bool IsCredentialReaderTypeUnique(CredentialReaderType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderTypeUnique(data);
        }
        #endregion
        #region Async operations

        public Task<CredentialReaderType[]> GetAllCredentialReaderTypesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCredentialReaderTypesAsync(parameters);
        }

        public Task<CredentialReaderType> GetCredentialReaderTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialReaderTypeAsync(parameters);
        }

        public Task<CredentialReaderType> SaveCredentialReaderTypeAsync(SaveParameters<CredentialReaderType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveCredentialReaderTypeAsync(parameters);
        }

        public Task<int> DeleteCredentialReaderTypeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderTypeByPkAsync(parameters);
        }

        public Task<int> DeleteCredentialReaderTypeAsync(DeleteParameters<CredentialReaderType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderTypeAsync(parameters);
        }

        public Task<bool> IsCredentialReaderTypeReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderTypeReferencedAsync(uid);
        }

        public Task<bool> IsCredentialReaderTypeUniqueAsync(CredentialReaderType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderTypeUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Features operations
        #region Synchronous operations

        public Feature[] GetAllFeatures(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllFeatures(parameters);
        }

        public Feature GetFeature(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetFeature(parameters);
        }

        public Feature SaveFeature(SaveParameters<Feature> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveFeature(parameters);
        }

        public int DeleteFeatureByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteFeatureByPk(parameters);
        }

        public int DeleteFeature(DeleteParameters<Feature> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteFeature(parameters);
        }

        public bool IsFeatureReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsFeatureReferenced(uid);
        }

        public bool IsFeatureUnique(Feature data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsFeatureUnique(data);
        }
        #endregion

        #region Async operations

        public Task<Feature[]> GetAllFeaturesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllFeaturesAsync(parameters);
        }

        public Task<Feature> GetFeatureAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetFeatureAsync(parameters);
        }

        public Task<Feature> SaveFeatureAsync(SaveParameters<Feature> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveFeatureAsync(parameters);
        }

        public Task<int> DeleteFeatureByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteFeatureByPkAsync(parameters);
        }

        public Task<int> DeleteFeatureAsync(DeleteParameters<Feature> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteFeatureAsync(parameters);
        }

        public Task<bool> IsFeatureReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsFeatureReferencedAsync(uid);
        }

        public Task<bool> IsFeatureUniqueAsync(Feature data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsFeatureUniqueAsync(data);
        }
        #endregion
        #endregion

        #region FeatureItem operations
        #region Synchronous operations

        public FeatureItem[] GetAllFeatureItemsForFeature(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllFeatureItemsForFeature(parameters);
        }

        public FeatureItem GetFeatureItem(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetFeatureItem(parameters);
        }

        public FeatureItem SaveFeatureItem(SaveParameters<FeatureItem> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveFeatureItem(parameters);
        }

        public int DeleteFeatureItemByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteFeatureItemByPk(parameters);
        }

        public int DeleteFeatureItem(DeleteParameters<FeatureItem> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteFeatureItem(parameters);
        }

        public bool IsFeatureItemReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsFeatureItemReferenced(uid);
        }

        public bool IsFeatureItemUnique(FeatureItem data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsFeatureItemUnique(data);
        }
        #endregion

        #region Async operations

        public Task<FeatureItem[]> GetAllFeatureItemsForFeatureAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllFeatureItemsForFeatureAsync(parameters);
        }

        public Task<FeatureItem> GetFeatureItemAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetFeatureItemAsync(parameters);
        }

        public Task<FeatureItem> SaveFeatureItemAsync(SaveParameters<FeatureItem> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveFeatureItemAsync(parameters);
        }

        public Task<int> DeleteFeatureItemByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteFeatureItemByPkAsync(parameters);
        }

        public Task<int> DeleteFeatureItemAsync(DeleteParameters<FeatureItem> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteFeatureItemAsync(parameters);
        }

        public Task<bool> IsFeatureItemReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsFeatureItemReferencedAsync(uid);
        }

        public Task<bool> IsFeatureItemUniqueAsync(FeatureItem data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsFeatureItemUniqueAsync(data);
        }
        #endregion
        #endregion

        #region CredentialReaderTypeFeatureMap operations
        #region Synchronous operations

        public CredentialReaderTypeFeatureMap[] GetAllCredentialReaderTypeFeatureMapForCredentialReaderType(
            GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCredentialReaderTypeFeatureMapForCredentialReaderType(parameters);
        }

        public CredentialReaderTypeFeatureMap[] GetAllCredentialReaderTypeFeatureMapForFeature(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCredentialReaderTypeFeatureMapForFeature(parameters);
        }

        public CredentialReaderTypeFeatureMap GetCredentialReaderTypeFeatureMap(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialReaderTypeFeatureMap(parameters);
        }

        public CredentialReaderTypeFeatureMap SaveCredentialReaderTypeFeatureMap(SaveParameters<CredentialReaderTypeFeatureMap> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveCredentialReaderTypeFeatureMap(parameters);
        }

        public int DeleteCredentialReaderTypeFeatureMapByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderTypeFeatureMapByPk(parameters);
        }

        public int DeleteCredentialReaderTypeFeatureMap(DeleteParameters<CredentialReaderTypeFeatureMap> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderTypeFeatureMap(parameters);
        }

        public bool IsCredentialReaderTypeFeatureMapReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderTypeFeatureMapReferenced(uid);
        }

        public bool IsCredentialReaderTypeFeatureMapUnique(CredentialReaderTypeFeatureMap data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderTypeFeatureMapUnique(data);
        }
        #endregion

        #region Async operations

        public Task<CredentialReaderTypeFeatureMap[]> GetAllCredentialReaderTypeFeatureMapForCredentialReaderTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCredentialReaderTypeFeatureMapForCredentialReaderTypeAsync(parameters);
        }

        public Task<CredentialReaderTypeFeatureMap[]> GetAllCredentialReaderTypeFeatureMapForFeatureAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCredentialReaderTypeFeatureMapForFeatureAsync(parameters);
        }

        public Task<CredentialReaderTypeFeatureMap> GetCredentialReaderTypeFeatureMapAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialReaderTypeFeatureMapAsync(parameters);
        }

        public Task<CredentialReaderTypeFeatureMap> SaveCredentialReaderTypeFeatureMapAsync(SaveParameters<CredentialReaderTypeFeatureMap> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveCredentialReaderTypeFeatureMapAsync(parameters);
        }

        public Task<int> DeleteCredentialReaderTypeFeatureMapByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderTypeFeatureMapByPkAsync(parameters);
        }

        public Task<int> DeleteCredentialReaderTypeFeatureMapAsync(DeleteParameters<CredentialReaderTypeFeatureMap> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCredentialReaderTypeFeatureMapAsync(parameters);
        }

        public Task<bool> IsCredentialReaderTypeFeatureMapReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderTypeFeatureMapReferencedAsync(uid);
        }

        public Task<bool> IsCredentialReaderTypeFeatureMapUniqueAsync(CredentialReaderTypeFeatureMap data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsCredentialReaderTypeFeatureMapUniqueAsync(data);
        }


        #endregion
        #endregion

        #region AccessPortalType operations
        #region Synchronous operations

        public AccessPortalType[] GetAllAccessPortalTypes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalTypes(parameters);
        }

        public AccessPortalType GetAccessPortalType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalType(parameters);
        }

        public AccessPortalType SaveAccessPortalType(SaveParameters<AccessPortalType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAccessPortalType(parameters);
        }

        public int DeleteAccessPortalTypeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessPortalTypeByPk(parameters);
        }

        public int DeleteAccessPortalType(DeleteParameters<AccessPortalType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessPortalType(parameters);
        }

        public bool IsAccessPortalTypeReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessPortalTypeReferenced(uid);
        }

        public bool IsAccessPortalTypeUnique(AccessPortalType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessPortalTypeUnique(data);
        }

        #endregion

        #region Async operations
        public Task<AccessPortalType[]> GetAllAccessPortalTypesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalTypesAsync(parameters);
        }

        public Task<AccessPortalType> GetAccessPortalTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalTypeAsync(parameters);
        }

        public Task<AccessPortalType> SaveAccessPortalTypeAsync(SaveParameters<AccessPortalType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAccessPortalTypeAsync(parameters);
        }

        public Task<int> DeleteAccessPortalTypeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessPortalTypeByPkAsync(parameters);
        }

        public Task<int> DeleteAccessPortalTypeAsync(DeleteParameters<AccessPortalType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessPortalTypeAsync(parameters);
        }

        public Task<bool> IsAccessPortalTypeReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessPortalTypeReferencedAsync(uid);
        }

        public Task<bool> IsAccessPortalTypeUniqueAsync(AccessPortalType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessPortalTypeUniqueAsync(data);
        }
        #endregion
        #endregion

        #region AccessPortal operations
        #region Synchronous operations
        public ArrayResponse<AccessPortal> GetAllAccessPortals(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortals(parameters);
        }

        //public ListItemBase[] GetAllAccessPortalsList(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsList(parameters);
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsList(parameters);
        }

        public ArrayResponse<AccessPortal> GetAccessPortalsByTextSearch(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalsByTextSearch(parameters);
        }

        public ArrayResponse<AccessPortalListItemCommands> GetAccessPortalsListByTextSearch(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalsListByTextSearch(parameters);
        }

        public ArrayResponse<AccessPortal> GetAllAccessPortalsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsForEntity(parameters);
        }

        //public ListItemBase[] GetAllAccessPortalsListForEntity(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListForEntity(parameters);
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListForEntity(parameters);
        }

        public ArrayResponse<AccessPortal> GetAllAccessPortalsForRegion(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsForRegion(parameters);
        }

        //public ListItemBase[] GetAllAccessPortalsListForRegion(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListForRegion(parameters);
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForRegion(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListForRegion(parameters);
        }

        public ArrayResponse<AccessPortal> GetAllAccessPortalsForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsForSite(parameters);
        }

        //public ListItemBase[] GetAllAccessPortalsListForSite(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListForSite(parameters);
        //}

        public ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListForSite(parameters);
        }

        public ArrayResponse<AccessPortal> GetAllAccessPortalsForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsForCluster(parameters);
        }

        //public ListItemBase[] GetAllAccessPortalsListForCluster(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListForCluster(parameters);
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListForCluster(parameters);
        }

        public ArrayResponse<AccessPortal> GetAllAccessPortalsForGalaxyPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsForGalaxyPanel(parameters);
        }

        //public ListItemBase[] GetAllAccessPortalsListForGalaxyPanel(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListForGalaxyPanel(parameters);
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForGalaxyPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListForGalaxyPanel(parameters);
        }

        public ArrayResponse<AccessPortalListItem> GetAccessPortalListItemsForGalaxyPanel(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalListItemsForGalaxyPanel(parameters);
        }

        public AccessPortalListItem GetAccessPortalListItem(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalListItem(parameters);
        }

        public AccessPortal GetAccessPortal(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortal(parameters);
        }

        public AccessPortal SaveAccessPortal(SaveParameters<AccessPortal> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAccessPortal(parameters);
        }

        public int DeleteAccessPortalByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessPortalByPk(parameters);
        }

        public int DeleteAccessPortal(DeleteParameters<AccessPortal> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessPortal(parameters);
        }

        public bool IsAccessPortalReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessPortalReferenced(uid);
        }

        public bool IsAccessPortalUnique(AccessPortal data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessPortalUnique(data);
        }

        public AccessPortalGalaxyCommonEditingData GetAccessPortalGalaxyCommonEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalGalaxyCommonEditingData(parameters);
        }

        public AccessPortalGalaxyPanelSpecificEditingData GetAccessPortalGalaxyPanelSpecificEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalGalaxyPanelSpecificEditingData(parameters);
        }

        public CommandResponse<AccessPortalCommandAction> ExecuteAccessPortalCommand(CommandParameters<AccessPortalCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteAccessPortalCommand(parameters);
        }

        public ArrayResponse<ActivityHistoryEvent> GetAccessPortalActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalActivityHistoryEvents(parameters);
        }

        public ValidationProblemDetails ValidateAccessPortal(SaveParameters<AccessPortal> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateAccessPortal(parameters);
        }

        #endregion

        #region Async operations
        public Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsAsync(parameters);
        }

        //public Task<ListItemBase[]> GetAllAccessPortalsListAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListAsync(parameters);
        //}

        public Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListAsync(parameters);
        }

        public Task<ArrayResponse<AccessPortal>> GetAccessPortalsByTextSearchAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalsByTextSearchAsync(parameters);
        }

        public Task<ArrayResponse<AccessPortalListItemCommands>> GetAccessPortalsListByTextSearchAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalsListByTextSearchAsync(parameters);
        }


        public Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsForEntityAsync(parameters);
        }

        //public Task<ListItemBase[]> GetAllAccessPortalsListForEntityAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListForEntityAsync(parameters);
        //}
        public Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListForEntityAsync(parameters);
        }

        public Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForRegionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsForRegionAsync(parameters);
        }

        //public Task<ListItemBase[]> GetAllAccessPortalsListForRegionAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListForRegionAsync(parameters);
        //}

        public Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForRegionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListForRegionAsync(parameters);
        }

        public Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsForSiteAsync(parameters);
        }

        //public Task<ListItemBase[]> GetAllAccessPortalsListForSiteAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListForSiteAsync(parameters);
        //}

        public Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListForSiteAsync(parameters);
        }

        public Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsForClusterAsync(parameters);
        }

        //public Task<ListItemBase[]> GetAllAccessPortalsListForClusterAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListForClusterAsync(parameters);
        //}
        public Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListForClusterAsync(parameters);
        }

        public Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForGalaxyPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsForGalaxyPanelAsync(parameters);
        }

        //public Task<ListItemBase[]> GetAllAccessPortalsListForGalaxyPanelAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAccessPortalsListForGalaxyPanelAsync(parameters);
        //}

        public Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForGalaxyPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessPortalsListForGalaxyPanelAsync(parameters);
        }

        public Task<ArrayResponse<AccessPortalListItem>> GetAccessPortalListItemsForGalaxyPanelAsync(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalListItemsForGalaxyPanelAsync(parameters);
        }

        public Task<AccessPortalListItem> GetAccessPortalListItemAsync(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalListItemAsync(parameters);
        }


        public Task<AccessPortal> GetAccessPortalAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalAsync(parameters);
        }

        public Task<AccessPortal> SaveAccessPortalAsync(SaveParameters<AccessPortal> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAccessPortalAsync(parameters);
        }

        public Task<int> DeleteAccessPortalByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessPortalByPkAsync(parameters);
        }

        public Task<int> DeleteAccessPortalAsync(DeleteParameters<AccessPortal> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessPortalAsync(parameters);
        }

        public Task<bool> IsAccessPortalReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessPortalReferencedAsync(uid);
        }

        public Task<bool> IsAccessPortalUniqueAsync(AccessPortal data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessPortalUniqueAsync(data);
        }

        public Task<AccessPortalGalaxyCommonEditingData> GetAccessPortalGalaxyCommonEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalGalaxyCommonEditingDataAsync(parameters);
        }

        public Task<AccessPortalGalaxyPanelSpecificEditingData> GetAccessPortalGalaxyPanelSpecificEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalGalaxyPanelSpecificEditingDataAsync(parameters);
        }
        public Task<CommandResponse<AccessPortalCommandAction>> ExecuteAccessPortalCommandAsync(CommandParameters<AccessPortalCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteAccessPortalCommandAsync(parameters);
        }

        public Task<ArrayResponse<ActivityHistoryEvent>> GetAccessPortalActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessPortalActivityHistoryEventsAsync(parameters);
        }

        public Task<ValidationProblemDetails> ValidateAccessPortalAsync(SaveParameters<AccessPortal> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateAccessPortalAsync(parameters);
        }

        #endregion
        #endregion

        #region InputDevice operations
        #region Synchronous operations
        public ArrayResponse<InputDevice> GetAllInputDevices(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevices(parameters);
        }

        public ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesList(parameters);
        }

        public ArrayResponse<InputDevice> GetAllInputDevicesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesForEntity(parameters);
        }

        public ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesListForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListForEntity(parameters);
        }

        public ArrayResponse<InputDevice> GetAllInputDevicesForRegion(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesForRegion(parameters);
        }

        public ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesListForRegion(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListForRegion(parameters);
        }

        public ArrayResponse<InputDevice> GetAllInputDevicesForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesForSite(parameters);
        }

        public ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesListForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListForSite(parameters);
        }

        public ArrayResponse<InputDevice> GetAllInputDevicesForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesForCluster(parameters);
        }

        public ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesListForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListForCluster(parameters);
        }

        public ArrayResponse<InputDevice> GetAllInputDevicesForGalaxyPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesForGalaxyPanel(parameters);
        }

        public ArrayResponse<InputDeviceListItemCommands> GetAllInputDevicesListForGalaxyPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListForGalaxyPanel(parameters);
        }

        public ArrayResponse<InputDeviceListItem> GetInputDeviceListItemsForGalaxyPanel(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceListItemsForGalaxyPanel(parameters);
        }

        public InputDeviceListItem GetInputDeviceListItem(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceListItem(parameters);
        }

        public InputDevice GetInputDevice(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDevice(parameters);
        }

        public InputDevice SaveInputDevice(SaveParameters<InputDevice> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveInputDevice(parameters);
        }

        public int DeleteInputDeviceByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteInputDeviceByPk(parameters);
        }

        public int DeleteInputDevice(DeleteParameters<InputDevice> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteInputDevice(parameters);
        }

        public bool IsInputDeviceReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsInputDeviceReferenced(uid);
        }

        public bool IsInputDeviceUnique(InputDevice data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsInputDeviceUnique(data);
        }

        public InputDeviceGalaxyCommonEditingData GetInputDeviceGalaxyCommonEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceGalaxyCommonEditingData(parameters);
        }

        public InputDeviceHardwareSpecificEditingData GetInputDeviceHardwareSpecificEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceHardwareSpecificEditingData(parameters);
        }

        public CommandResponse<InputDeviceCommandAction> ExecuteInputDeviceCommand(CommandParameters<InputDeviceCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteInputDeviceCommand(parameters);
        }

        public ArrayResponse<ActivityHistoryEvent> GetInputDeviceActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceActivityHistoryEvents(parameters);
        }

        public ArrayResponse<InputDevice> GetInputDevicesByTextSearch(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDevicesByTextSearch(parameters);
        }

        public ArrayResponse<InputDeviceListItemCommands> GetInputDevicesListByTextSearch(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDevicesListByTextSearch(parameters);
        }

        #endregion

        #region Async operations
        public Task<ArrayResponse<InputDevice>> GetAllInputDevicesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesAsync(parameters);
        }

        public Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListAsync(parameters);
        }

        public Task<ArrayResponse<InputDevice>> GetAllInputDevicesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesForEntityAsync(parameters);
        }

        public Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListForEntityAsync(parameters);
        }

        public Task<ArrayResponse<InputDevice>> GetAllInputDevicesForRegionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesForRegionAsync(parameters);
        }

        public Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListForRegionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListForRegionAsync(parameters);
        }

        public Task<ArrayResponse<InputDevice>> GetAllInputDevicesForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesForSiteAsync(parameters);
        }

        public Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListForSiteAsync(parameters);
        }

        public Task<ArrayResponse<InputDevice>> GetAllInputDevicesForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesForClusterAsync(parameters);
        }

        public Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListForClusterAsync(parameters);
        }

        public Task<ArrayResponse<InputDevice>> GetAllInputDevicesForGalaxyPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesForGalaxyPanelAsync(parameters);
        }

        public Task<ArrayResponse<InputDeviceListItemCommands>> GetAllInputDevicesListForGalaxyPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputDevicesListForGalaxyPanelAsync(parameters);
        }

        public Task<ArrayResponse<InputDeviceListItem>> GetInputDeviceListItemsForGalaxyPanelAsync(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceListItemsForGalaxyPanelAsync(parameters);
        }

        public Task<InputDeviceListItem> GetInputDeviceListItemAsync(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceListItemAsync(parameters);
        }

        public Task<InputDevice> GetInputDeviceAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceAsync(parameters);
        }

        public Task<InputDevice> SaveInputDeviceAsync(SaveParameters<InputDevice> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveInputDeviceAsync(parameters);
        }

        public Task<int> DeleteInputDeviceByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteInputDeviceByPkAsync(parameters);
        }

        public Task<int> DeleteInputDeviceAsync(DeleteParameters<InputDevice> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteInputDeviceAsync(parameters);
        }

        public Task<bool> IsInputDeviceReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsInputDeviceReferencedAsync(uid);
        }

        public Task<bool> IsInputDeviceUniqueAsync(InputDevice data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsInputDeviceUniqueAsync(data);
        }

        public Task<InputDeviceGalaxyCommonEditingData> GetInputDeviceGalaxyCommonEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceGalaxyCommonEditingDataAsync(parameters);
        }

        public Task<InputDeviceHardwareSpecificEditingData> GetInputDeviceHardwareSpecificEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceHardwareSpecificEditingDataAsync(parameters);
        }

        public Task<CommandResponse<InputDeviceCommandAction>> ExecuteInputDeviceCommandAsync(CommandParameters<InputDeviceCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteInputDeviceCommandAsync(parameters);
        }

        public Task<ArrayResponse<ActivityHistoryEvent>> GetInputDeviceActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDeviceActivityHistoryEventsAsync(parameters);
        }

        public Task<ArrayResponse<InputDevice>> GetInputDevicesByTextSearchAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDevicesByTextSearchAsync(parameters);
        }

        public Task<ArrayResponse<InputDeviceListItemCommands>> GetInputDevicesListByTextSearchAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputDevicesListByTextSearchAsync(parameters);
        }

        #endregion
        #endregion

        #region OutputDevice operations
        #region Synchronous operations
        public ArrayResponse<OutputDevice> GetAllOutputDevices(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevices(parameters);
        }

        public ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesList(parameters);
        }

        public ArrayResponse<OutputDevice> GetAllOutputDevicesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesForEntity(parameters);
        }

        public ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesListForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListForEntity(parameters);
        }

        public ArrayResponse<OutputDevice> GetAllOutputDevicesForRegion(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesForRegion(parameters);
        }

        public ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesListForRegion(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListForRegion(parameters);
        }

        public ArrayResponse<OutputDevice> GetAllOutputDevicesForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesForSite(parameters);
        }

        public ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesListForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListForSite(parameters);
        }

        public ArrayResponse<OutputDevice> GetAllOutputDevicesForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesForCluster(parameters);
        }

        public ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesListForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListForCluster(parameters);
        }

        public ArrayResponse<OutputDevice> GetAllOutputDevicesForGalaxyPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesForGalaxyPanel(parameters);
        }

        public ArrayResponse<OutputDeviceListItemCommands> GetAllOutputDevicesListForGalaxyPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListForGalaxyPanel(parameters);
        }

        public ArrayResponse<OutputDeviceListItem> GetOutputDeviceListItemsForGalaxyPanel(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceListItemsForGalaxyPanel(parameters);
        }

        public OutputDeviceListItem GetOutputDeviceListItem(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceListItem(parameters);
        }

        public OutputDevice GetOutputDevice(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDevice(parameters);
        }

        public OutputDevice SaveOutputDevice(SaveParameters<OutputDevice> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveOutputDevice(parameters);
        }

        public int DeleteOutputDeviceByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteOutputDeviceByPk(parameters);
        }

        public int DeleteOutputDevice(DeleteParameters<OutputDevice> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteOutputDevice(parameters);
        }

        public bool IsOutputDeviceReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsOutputDeviceReferenced(uid);
        }

        public bool IsOutputDeviceUnique(OutputDevice data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsOutputDeviceUnique(data);
        }

        public OutputDeviceGalaxyCommonEditingData GetOutputDeviceGalaxyCommonEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceGalaxyCommonEditingData(parameters);
        }

        public OutputDeviceHardwareSpecificEditingData GetOutputDeviceHardwareSpecificEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceHardwareSpecificEditingData(parameters);
        }

        public CommandResponse<OutputDeviceCommandAction> ExecuteOutputDeviceCommand(CommandParameters<OutputDeviceCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteOutputDeviceCommand(parameters);
        }

        public ArrayResponse<ActivityHistoryEvent> GetOutputDeviceActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceActivityHistoryEvents(parameters);
        }

        public ArrayResponse<OutputDevice> GetOutputDevicesByTextSearch(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDevicesByTextSearch(parameters);
        }

        public ArrayResponse<OutputDeviceListItemCommands> GetOutputDevicesListByTextSearch(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDevicesListByTextSearch(parameters);
        }
        #endregion

        #region Async operations
        public Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesAsync(parameters);
        }

        public Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListAsync(parameters);
        }

        public Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesForEntityAsync(parameters);
        }

        public Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListForEntityAsync(parameters);
        }

        public Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesForRegionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesForRegionAsync(parameters);
        }

        public Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListForRegionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListForRegionAsync(parameters);
        }

        public Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesForSiteAsync(parameters);
        }

        public Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListForSiteAsync(parameters);
        }

        public Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesForClusterAsync(parameters);
        }

        public Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListForClusterAsync(parameters);
        }

        public Task<ArrayResponse<OutputDevice>> GetAllOutputDevicesForGalaxyPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesForGalaxyPanelAsync(parameters);
        }

        public Task<ArrayResponse<OutputDeviceListItemCommands>> GetAllOutputDevicesListForGalaxyPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllOutputDevicesListForGalaxyPanelAsync(parameters);
        }

        public Task<ArrayResponse<OutputDeviceListItem>> GetOutputDeviceListItemsForGalaxyPanelAsync(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceListItemsForGalaxyPanelAsync(parameters);
        }

        public Task<OutputDeviceListItem> GetOutputDeviceListItemAsync(GetParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceListItemAsync(parameters);
        }


        public Task<OutputDevice> GetOutputDeviceAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceAsync(parameters);
        }

        public Task<OutputDevice> SaveOutputDeviceAsync(SaveParameters<OutputDevice> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveOutputDeviceAsync(parameters);
        }

        public Task<int> DeleteOutputDeviceByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteOutputDeviceByPkAsync(parameters);
        }

        public Task<int> DeleteOutputDeviceAsync(DeleteParameters<OutputDevice> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteOutputDeviceAsync(parameters);
        }

        public Task<bool> IsOutputDeviceReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsOutputDeviceReferencedAsync(uid);
        }

        public Task<bool> IsOutputDeviceUniqueAsync(OutputDevice data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsOutputDeviceUniqueAsync(data);
        }

        public Task<OutputDeviceGalaxyCommonEditingData> GetOutputDeviceGalaxyCommonEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceGalaxyCommonEditingDataAsync(parameters);
        }

        public Task<OutputDeviceHardwareSpecificEditingData> GetOutputDeviceHardwareSpecificEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceHardwareSpecificEditingDataAsync(parameters);
        }

        public Task<CommandResponse<OutputDeviceCommandAction>> ExecuteOutputDeviceCommandAsync(CommandParameters<OutputDeviceCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteOutputDeviceCommandAsync(parameters);
        }

        public Task<ArrayResponse<ActivityHistoryEvent>> GetOutputDeviceActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDeviceActivityHistoryEventsAsync(parameters);
        }

        public Task<ArrayResponse<OutputDevice>> GetOutputDevicesByTextSearchAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDevicesByTextSearchAsync(parameters);
        }

        public Task<ArrayResponse<OutputDeviceListItemCommands>> GetOutputDevicesListByTextSearchAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOutputDevicesListByTextSearchAsync(parameters);
        }
        #endregion
        #endregion

        #region Time Schedule Operations
        #region Synchronous Operations
        public ArrayResponse<TimeSchedule> GetAllTimeSchedules(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedules(parameters);
        }

        public ArrayResponse<TimeScheduleListItem> GetAllTimeSchedulesList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesList(parameters);
        }

        public ArrayResponse<TimeSchedule> GetAllTimeSchedulesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForEntity(parameters);
        }

        public ArrayResponse<TimeScheduleListItem> GetAllTimeSchedulesForEntityList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForEntityList(parameters);
        }

        public ArrayResponse<TimeSchedule> GetAllTimeSchedulesForMappedEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForMappedEntity(parameters);
        }

        public ArrayResponse<TimeSchedule> GetAllTimeSchedulesForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForCluster(parameters);
        }

        public ArrayResponse<TimeScheduleListItem> GetAllTimeSchedulesForClusterList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForClusterList(parameters);
        }

        public ArrayResponse<TimeSchedule> GetAllTimeSchedulesForAssaAbloyDsr(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForAssaAbloyDsr(parameters);
        }

        public ArrayResponse<TimeScheduleClusterItem> GetTimeScheduleClusterItems(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTimeScheduleClusterItems(parameters);
        }

        public TimeSchedule GetTimeSchedule(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTimeSchedule(parameters);
        }

        public TimeSchedule SaveTimeSchedule(SaveParameters<TimeSchedule> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveTimeSchedule(parameters);
        }

        public int DeleteTimeScheduleByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteTimeScheduleByPk(parameters);
        }

        public int DeleteTimeSchedule(DeleteParameters<TimeSchedule> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteTimeSchedule(parameters);
        }

        public bool IsTimeScheduleReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsTimeScheduleReferenced(uid);
        }

        public bool IsTimeScheduleUnique(TimeSchedule data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsTimeScheduleUnique(data);
        }

        public bool IsTimeScheduleActive(Guid timeScheduleUid, TimeScheduleType scheduleType, Guid clusterUid, DateTimeOffset dateTime)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsTimeScheduleActive(timeScheduleUid, scheduleType, clusterUid, dateTime);
        }

        public GalaxyClusterTimeScheduleMap SetTimeScheduleToClusterMapping(Guid timeScheduleUid, Guid clusterUid,
            bool isMapped,
            bool fifteenMinuteFormatUsesHolidays)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SetTimeScheduleToClusterMapping(timeScheduleUid, clusterUid, isMapped, fifteenMinuteFormatUsesHolidays);
        }

        public bool CanTimeScheduleBeUnmappedFromCluster(Guid timeScheduleUid, Guid clusterUid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.CanTimeScheduleBeUnmappedFromCluster(timeScheduleUid, clusterUid);
        }

        public bool CanTimeScheduleBeDeleted(Guid timeScheduleUid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.CanTimeScheduleBeDeleted(timeScheduleUid);
        }

        public TimeScheduleUsageData GetTimeScheduleUsageInformation(Guid timeScheduleUid, Guid clusterUid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTimeScheduleUsageInformation(timeScheduleUid, clusterUid);
        }

        #endregion

        #region Async Operations
        public Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesAsync(parameters);
        }

        public Task<ArrayResponse<TimeScheduleListItem>> GetAllTimeSchedulesListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesListAsync(parameters);
        }

        public Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForEntityAsync(parameters);
        }

        public Task<ArrayResponse<TimeScheduleListItem>> GetAllTimeSchedulesForEntityListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForEntityListAsync(parameters);
        }

        public Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesForMappedEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForMappedEntityAsync(parameters);
        }

        public Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForClusterAsync(parameters);
        }

        public Task<ArrayResponse<TimeScheduleListItem>> GetAllTimeSchedulesForClusterListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForClusterListAsync(parameters);
        }

        public Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesForAssaAbloyDsrAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimeSchedulesForAssaAbloyDsrAsync(parameters);
        }

        public Task<ArrayResponse<TimeScheduleClusterItem>> GetTimeScheduleClusterItemsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTimeScheduleClusterItemsAsync(parameters);
        }

        public Task<TimeSchedule> GetTimeScheduleAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTimeScheduleAsync(parameters);
        }

        public Task<TimeSchedule> SaveTimeScheduleAsync(SaveParameters<TimeSchedule> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveTimeScheduleAsync(parameters);
        }

        public Task<int> DeleteTimeScheduleByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteTimeScheduleByPkAsync(parameters);
        }

        public Task<int> DeleteTimeScheduleAsync(DeleteParameters<TimeSchedule> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteTimeScheduleAsync(parameters);
        }

        public Task<bool> IsTimeScheduleReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsTimeScheduleReferencedAsync(uid);
        }

        public Task<bool> IsTimeScheduleUniqueAsync(TimeSchedule data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsTimeScheduleUniqueAsync(data);
        }

        public Task<bool> IsTimeScheduleActiveAsync(Guid timeScheduleUid, TimeScheduleType scheduleType, Guid clusterUid, DateTimeOffset dateTime)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsTimeScheduleActiveAsync(timeScheduleUid, scheduleType, clusterUid, dateTime);
        }

        public Task<GalaxyClusterTimeScheduleMap> SetTimeScheduleToClusterMappingAsync(Guid timeScheduleUid,
            Guid clusterUid, bool isMapped,
            bool fifteenMinuteFormatUsesHolidays)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SetTimeScheduleToClusterMappingAsync(timeScheduleUid, clusterUid, isMapped, fifteenMinuteFormatUsesHolidays);
        }

        public Task<bool> CanTimeScheduleBeUnmappedFromClusterAsync(Guid timeScheduleUid, Guid clusterUid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.CanTimeScheduleBeUnmappedFromClusterAsync(timeScheduleUid, clusterUid);
        }

        public Task<bool> CanTimeScheduleBeDeletedAsync(Guid timeScheduleUid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.CanTimeScheduleBeDeletedAsync(timeScheduleUid);
        }

        public Task<TimeScheduleUsageData> GetTimeScheduleUsageInformationAsync(Guid timeScheduleUid, Guid clusterUid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTimeScheduleUsageInformationAsync(timeScheduleUid, clusterUid);
        }

        #endregion
        #endregion

        #region Time Period Operations

        #region Synchronous Operations
        public TimePeriod[] GetAllTimePeriods(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimePeriods(parameters);
        }

        public ListItemBase[] GetAllTimePeriodsList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimePeriodsList(parameters);
        }

        public TimePeriod[] GetAllTimePeriodsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimePeriodsForEntity(parameters);
        }

        public ListItemBase[] GetAllTimePeriodsForEntityList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimePeriodsForEntityList(parameters);
        }

        public TimePeriod GetTimePeriod(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTimePeriod(parameters);
        }

        public TimePeriod FindTimePeriodByTimes(GetParameters<TimePeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.FindTimePeriodByTimes(parameters);
        }

        public TimePeriod SaveTimePeriod(SaveParameters<TimePeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveTimePeriod(parameters);
        }

        public int DeleteTimePeriodByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteTimePeriodByPk(parameters);
        }

        public int DeleteTimePeriod(DeleteParameters<TimePeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteTimePeriod(parameters);
        }

        public bool IsTimePeriodReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsTimeScheduleReferenced(uid);
        }

        public bool IsTimePeriodUnique(TimePeriod data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsTimePeriodUnique(data);
        }
        #endregion

        #region Async Operations
        public Task<TimePeriod[]> GetAllTimePeriodsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimePeriodsAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllTimePeriodsListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimePeriodsListAsync(parameters);
        }

        public Task<TimePeriod[]> GetAllTimePeriodsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimePeriodsForEntityAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllTimePeriodsForEntityListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllTimePeriodsForEntityListAsync(parameters);
        }

        //public Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesForClusterAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllTimeSchedulesForClusterAsync(parameters);
        //}

        //public Task<ArrayResponse<TimeSchedule>> GetAllTimeSchedulesForAssaAbloyDsrAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllTimeSchedulesForAssaAbloyDsrAsync(parameters);
        //}
        public Task<TimePeriod> GetTimePeriodAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTimePeriodAsync(parameters);
        }

        public Task<TimePeriod> FindTimePeriodByTimesAsync(GetParameters<TimePeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.FindTimePeriodByTimesAsync(parameters);
        }

        public Task<TimePeriod> SaveTimePeriodAsync(SaveParameters<TimePeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveTimePeriodAsync(parameters);
        }

        public Task<int> DeleteTimePeriodByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteTimePeriodByPkAsync(parameters);
        }

        public Task<int> DeleteTimePeriodAsync(DeleteParameters<TimePeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteTimePeriodAsync(parameters);
        }

        public Task<bool> IsTimePeriodReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsTimePeriodReferencedAsync(uid);
        }

        public Task<bool> IsTimePeriodUniqueAsync(TimePeriod data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsTimePeriodUniqueAsync(data);
        }
        #endregion

        #endregion

        #region Galaxy Time Period Operations
        #region Synchronous Operations
        public ArrayResponse<GalaxyTimePeriod> GetAllGalaxyTimePeriods(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyTimePeriods(parameters);
        }

        public ArrayResponse<GalaxyTimePeriodListItem> GetAllGalaxyTimePeriodsList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyTimePeriodsList(parameters);
        }

        public ArrayResponse<GalaxyTimePeriod> GetAllGalaxyTimePeriodsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyTimePeriodsForEntity(parameters);
        }

        public ArrayResponse<GalaxyTimePeriodListItem> GetAllGalaxyTimePeriodsListForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyTimePeriodsListForEntity(parameters);
        }

        public GalaxyTimePeriod GetGalaxyTimePeriod(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyTimePeriod(parameters);
        }

        public GalaxyTimePeriod SaveGalaxyTimePeriod(SaveParameters<GalaxyTimePeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyTimePeriod(parameters);
        }

        public int DeleteGalaxyTimePeriodByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyTimePeriodByPk(parameters);
        }

        public int DeleteGalaxyTimePeriod(DeleteParameters<GalaxyTimePeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyTimePeriod(parameters);
        }

        public bool IsGalaxyTimePeriodReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyTimePeriodReferenced(uid);
        }

        public bool IsGalaxyTimePeriodUnique(GalaxyTimePeriod data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyTimePeriodUnique(data);
        }

        #endregion

        #region Async Operations
        public Task<ArrayResponse<GalaxyTimePeriod>> GetAllGalaxyTimePeriodsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyTimePeriodsAsync(parameters);
        }

        public Task<ArrayResponse<GalaxyTimePeriodListItem>> GetAllGalaxyTimePeriodsListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyTimePeriodsListAsync(parameters);
        }

        public Task<ArrayResponse<GalaxyTimePeriod>> GetAllGalaxyTimePeriodsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyTimePeriodsForEntityAsync(parameters);
        }

        public Task<ArrayResponse<GalaxyTimePeriodListItem>> GetAllGalaxyTimePeriodsListForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyTimePeriodsListForEntityAsync(parameters);
        }


        public Task<GalaxyTimePeriod> GetGalaxyTimePeriodAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyTimePeriodAsync(parameters);
        }

        public Task<GalaxyTimePeriod> SaveGalaxyTimePeriodAsync(SaveParameters<GalaxyTimePeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyTimePeriodAsync(parameters);
        }

        public Task<int> DeleteGalaxyTimePeriodByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyTimePeriodByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyTimePeriodAsync(DeleteParameters<GalaxyTimePeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyTimePeriodAsync(parameters);
        }

        public Task<bool> IsGalaxyTimePeriodReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyTimePeriodReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyTimePeriodUniqueAsync(GalaxyTimePeriod data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyTimePeriodUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Day Type Operations
        #region Synchronous Operations
        public ArrayResponse<DayType> GetAllDayTypes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypes(parameters);
        }

        public ArrayResponse<DayTypeListItem> GetAllDayTypesList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesList(parameters);
        }

        public ArrayResponse<DayType> GetAllDayTypesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesForEntity(parameters);
        }

        public ArrayResponse<DayTypeListItem> GetAllDayTypesListForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesListForEntity(parameters);
        }

        public ArrayResponse<DayType> GetAllDayTypesForMappedEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesForMappedEntity(parameters);
        }

        public ArrayResponse<DayTypeListItem> GetAllDayTypesListForMappedEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesListForMappedEntity(parameters);
        }

        public ArrayResponse<DayType> GetAllDayTypesForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesForCluster(parameters);
        }

        public ArrayResponse<DayTypeListItem> GetAllDayTypesListForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesListForCluster(parameters);
        }

        public ArrayResponse<DayType> GetAllDayTypesForAssaAbloyDsr(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesForAssaAbloyDsr(parameters);
        }

        public ArrayResponse<DayTypeListItem> GetAllDayTypesListForAssaAbloyDsr(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesListForAssaAbloyDsr(parameters);
        }

        public DayType GetDayType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDayType(parameters);
        }

        public DayTypeDateValidationError[] ValidateDatesForDayType(DayType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateDatesForDayType(data);
        }

        public DayType SaveDayType(SaveParameters<DayType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveDayType(parameters);
        }

        public ArrayResponse<DayType> EnsureDefaultDayTypesExistForEntity(SaveParameters<DayType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.EnsureDefaultDayTypesExistForEntity(parameters);
        }

        public int DeleteDayTypeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDayTypeByPk(parameters);
        }

        public int DeleteDayType(DeleteParameters<DayType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDayType(parameters);
        }

        public bool IsDayTypeReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDayTypeReferenced(uid);
        }

        public bool IsDayTypeUnique(DayType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDayTypeUnique(data);
        }

        #endregion

        #region Async Operations
        public Task<ArrayResponse<DayType>> GetAllDayTypesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesAsync(parameters);
        }

        public Task<ArrayResponse<DayTypeListItem>> GetAllDayTypesListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesListAsync(parameters);
        }

        public Task<ArrayResponse<DayType>> GetAllDayTypesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesForEntityAsync(parameters);
        }

        public Task<ArrayResponse<DayTypeListItem>> GetAllDayTypesListForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesListForEntityAsync(parameters);
        }

        public Task<ArrayResponse<DayType>> GetAllDayTypesForMappedEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesForMappedEntityAsync(parameters);
        }

        public Task<ArrayResponse<DayTypeListItem>> GetAllDayTypesListForMappedEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesListForMappedEntityAsync(parameters);
        }

        public Task<ArrayResponse<DayType>> GetAllDayTypesForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesForClusterAsync(parameters);
        }

        public Task<ArrayResponse<DayTypeListItem>> GetAllDayTypesListForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesListForClusterAsync(parameters);
        }

        public Task<ArrayResponse<DayType>> GetAllDayTypesForAssaAbloyDsrAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesForAssaAbloyDsrAsync(parameters);
        }

        public Task<ArrayResponse<DayTypeListItem>> GetAllDayTypesListForAssaAbloyDsrAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDayTypesListForAssaAbloyDsrAsync(parameters);
        }


        public Task<DayType> GetDayTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDayTypeAsync(parameters);
        }

        public Task<DayTypeDateValidationError[]> ValidateDatesForDayTypeAsync(DayType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateDatesForDayTypeAsync(data);
        }

        public Task<DayType> SaveDayTypeAsync(SaveParameters<DayType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveDayTypeAsync(parameters);
        }

        public Task<ArrayResponse<DayType>> EnsureDefaultDayTypesExistForEntityAsync(SaveParameters<DayType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.EnsureDefaultDayTypesExistForEntityAsync(parameters);
        }

        public Task<int> DeleteDayTypeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDayTypeByPkAsync(parameters);
        }

        public Task<int> DeleteDayTypeAsync(DeleteParameters<DayType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDayTypeAsync(parameters);
        }

        public Task<bool> IsDayTypeReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDayTypeReferencedAsync(uid);
        }

        public Task<bool> IsDayTypeUniqueAsync(DayType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDayTypeUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Date Type Operations
        #region Synchronous Operations
        public ArrayResponse<DateType> GetAllDateTypes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDateTypes(parameters);
        }

        public ArrayResponse<DateType> GetAllDateTypesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDateTypesForEntity(parameters);
        }

        public ArrayResponse<DateType> GetAllDateTypesForMappedEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDateTypesForMappedEntity(parameters);
        }

        public ArrayResponse<DateType> GetAllDateTypesForDayType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDateTypesForDayType(parameters);
        }
        public DateType GetDateType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDateType(parameters);
        }

        public DateType SaveDateType(SaveParameters<DateType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveDateType(parameters);
        }

        public int DeleteDateTypeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDateTypeByPk(parameters);
        }

        public int DeleteDateType(DeleteParameters<DateType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDateType(parameters);
        }

        public bool IsDateTypeReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDateTypeReferenced(uid);
        }

        public bool IsDateTypeUnique(DateType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDateTypeUnique(data);
        }

        #endregion

        #region Async Operations
        public Task<ArrayResponse<DateType>> GetAllDateTypesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDateTypesAsync(parameters);
        }

        public Task<ArrayResponse<DateType>> GetAllDateTypesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDateTypesForEntityAsync(parameters);
        }

        public Task<ArrayResponse<DateType>> GetAllDateTypesForMappedEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDateTypesForMappedEntityAsync(parameters);
        }

        public Task<ArrayResponse<DateType>> GetAllDateTypesForDayTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDateTypesForDayTypeAsync(parameters);
        }
        public Task<DateType> GetDateTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDateTypeAsync(parameters);
        }

        public Task<DateType> SaveDateTypeAsync(SaveParameters<DateType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveDateTypeAsync(parameters);
        }

        public Task<int> DeleteDateTypeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDateTypeByPkAsync(parameters);
        }

        public Task<int> DeleteDateTypeAsync(DeleteParameters<DateType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDateTypeAsync(parameters);
        }

        public Task<bool> IsDateTypeReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDateTypeReferencedAsync(uid);
        }

        public Task<bool> IsDateTypeUniqueAsync(DateType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDateTypeUniqueAsync(data);
        }


        #endregion
        #endregion

        #region Date Type Default Behavior Operations
        #region Synchronous Operations

        public DateTypeDefaultBehavior GetDateTypeDefaultBehaviorForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDateTypeDefaultBehaviorForEntity(parameters);
        }

        public DateTypeDefaultBehavior GetDateTypeDefaultBehavior(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDateTypeDefaultBehavior(parameters);
        }

        public DateTypeDefaultBehavior SaveDateTypeDefaultBehavior(SaveParameters<DateTypeDefaultBehavior> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveDateTypeDefaultBehavior(parameters);
        }

        public int DeleteDateTypeDefaultBehaviorByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDateTypeDefaultBehaviorByPk(parameters);
        }

        public int DeleteDateTypeDefaultBehavior(DeleteParameters<DateTypeDefaultBehavior> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDateTypeDefaultBehavior(parameters);
        }

        public bool IsDateTypeDefaultBehaviorReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDateTypeDefaultBehaviorReferenced(uid);
        }

        public bool IsDateTypeDefaultBehaviorUnique(DateTypeDefaultBehavior data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDateTypeDefaultBehaviorUnique(data);
        }
        #endregion

        #region Async Operations
        public Task<DateTypeDefaultBehavior> GetDateTypeDefaultBehaviorForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDateTypeDefaultBehaviorForEntityAsync(parameters);
        }

        public Task<DateTypeDefaultBehavior> GetDateTypeDefaultBehaviorAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDateTypeDefaultBehaviorAsync(parameters);
        }

        public Task<DateTypeDefaultBehavior> SaveDateTypeDefaultBehaviorAsync(SaveParameters<DateTypeDefaultBehavior> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveDateTypeDefaultBehaviorAsync(parameters);
        }

        public Task<int> DeleteDateTypeDefaultBehaviorByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDateTypeDefaultBehaviorByPkAsync(parameters);
        }

        public Task<int> DeleteDateTypeDefaultBehaviorAsync(DeleteParameters<DateTypeDefaultBehavior> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDateTypeDefaultBehaviorAsync(parameters);
        }

        public Task<bool> IsDateTypeDefaultBehaviorReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDateTypeDefaultBehaviorReferencedAsync(uid);
        }

        public Task<bool> IsDateTypeDefaultBehaviorUniqueAsync(DateTypeDefaultBehavior data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDateTypeDefaultBehaviorUniqueAsync(data);
        }
        #endregion

        #endregion

        #region Assa DSR Operations
        #region Synchronous Operations
        public AssaDsr[] GetAllAssaDsrs(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaDsrs(parameters);
        }

        public AssaDsr[] GetAllAssaDsrsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaDsrsForEntity(parameters);
        }

        public AssaDsr GetAssaDsr(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaDsr(parameters);
        }

        public AssaDsr SaveAssaDsr(SaveParameters<AssaDsr> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAssaDsr(parameters);
        }

        public int DeleteAssaDsrByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaDsrByPk(parameters);
        }

        public int DeleteAssaDsr(DeleteParameters<AssaDsr> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaDsr(parameters);
        }

        public bool IsAssaDsrReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaDsrReferenced(uid);
        }

        public bool IsAssaDsrUnique(AssaDsr data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaDsrUnique(data);
        }

        public AssaDsr ImportAssaAccessPointsFromDsr(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ImportAssaAccessPointsFromDsr(parameters);
        }

        public Task<AssaDsr[]> GetAllAssaDsrsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaDsrsAsync(parameters);
        }

        #endregion
        #region Async Operations
        public Task<AssaDsr[]> GetAllAssaDsrsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaDsrsForEntityAsync(parameters);
        }

        public Task<AssaDsr> GetAssaDsrAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaDsrAsync(parameters);
        }

        public Task<AssaDsr> SaveAssaDsrAsync(SaveParameters<AssaDsr> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAssaDsrAsync(parameters);
        }

        public Task<int> DeleteAssaDsrByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaDsrByPkAsync(parameters);
        }

        public Task<int> DeleteAssaDsrAsync(DeleteParameters<AssaDsr> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaDsrAsync(parameters);
        }

        public Task<bool> IsAssaDsrReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaDsrReferencedAsync(uid);
        }

        public Task<bool> IsAssaDsrUniqueAsync(AssaDsr data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaDsrUniqueAsync(data);
        }

        public Task<AssaDsr> ImportAssaAccessPointsFromDsrAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ImportAssaAccessPointsFromDsrAsync(parameters);
        }
        #endregion

        #endregion

        #region Assa Access Point Operations
        #region Synchronous Operations
        public AssaAccessPoint[] GetAllAssaAccessPoints(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaAccessPoints(parameters);
        }

        public AssaAccessPoint[] GetAllAssaAccessPointsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaAccessPointsForEntity(parameters);
        }

        public AssaAccessPoint[] GetAllAssaAccessPointsForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaAccessPointsForSite(parameters);
        }
        public AssaAccessPoint[] GetAllAssaAccessPointsFromDsr(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaAccessPointsFromDsr(parameters);
        }

        public AssaAccessPoint GetAssaAccessPoint(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaAccessPoint(parameters);
        }

        public AssaAccessPoint GetAssaAccessPointByAssaUniqueId(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaAccessPointByAssaUniqueId(parameters);
        }

        public AssaAccessPoint GetAssaAccessPointByAssaSerialNumber(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaAccessPointByAssaSerialNumber(parameters);
        }

        public AssaAccessPoint SaveAssaAccessPoint(SaveParameters<AssaAccessPoint> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAssaAccessPoint(parameters);
        }

        public int DeleteAssaAccessPointByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaAccessPointByPk(parameters);
        }

        public int DeleteAssaAccessPoint(DeleteParameters<AssaAccessPoint> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaAccessPoint(parameters);
        }

        public bool IsAssaAccessPointReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaAccessPointReferenced(uid);
        }

        public bool IsAssaAccessPointUnique(AssaAccessPoint data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaAccessPointUnique(data);
        }
        public AssaAccessPoint AssaConfirmAccessPoint(SaveParameters<AssaAccessPoint> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.AssaConfirmAccessPoint(parameters);
        }


        #endregion
        #region Asynchronous Operations
        public Task<AssaAccessPoint[]> GetAllAssaAccessPointsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaAccessPointsAsync(parameters);
        }

        public Task<AssaAccessPoint[]> GetAllAssaAccessPointsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaAccessPointsForEntityAsync(parameters);
        }

        public Task<AssaAccessPoint[]> GetAllAssaAccessPointsForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaAccessPointsForSiteAsync(parameters);
        }

        public Task<AssaAccessPoint[]> GetAllAssaAccessPointsFromDsrAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaAccessPointsFromDsrAsync(parameters);
        }

        public Task<AssaAccessPoint> GetAssaAccessPointAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaAccessPointAsync(parameters);
        }

        public Task<AssaAccessPoint> GetAssaAccessPointByAssaUniqueIdAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaAccessPointByAssaUniqueIdAsync(parameters);
        }

        public Task<AssaAccessPoint> GetAssaAccessPointByAssaSerialNumberAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaAccessPointByAssaSerialNumberAsync(parameters);
        }

        public Task<AssaAccessPoint> SaveAssaAccessPointAsync(SaveParameters<AssaAccessPoint> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAssaAccessPointAsync(parameters);
        }

        public Task<int> DeleteAssaAccessPointByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaAccessPointByPkAsync(parameters);
        }

        public Task<int> DeleteAssaAccessPointAsync(DeleteParameters<AssaAccessPoint> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaAccessPointAsync(parameters);
        }

        public Task<bool> IsAssaAccessPointReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaAccessPointReferencedAsync(uid);
        }

        public Task<bool> IsAssaAccessPointUniqueAsync(AssaAccessPoint data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaAccessPointUniqueAsync(data);
        }

        public Task<AssaAccessPoint> AssaConfirmAccessPointAsync(SaveParameters<AssaAccessPoint> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.AssaConfirmAccessPointAsync(parameters);
        }
        #endregion
        #endregion

        #region Assa Access Point Type Operations
        #region Synchronous Operations
        public AssaAccessPointType[] GetAllAssaAccessPointTypes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaAccessPointTypes(parameters);
        }

        public AssaAccessPointType GetAssaAccessPointTypeById(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaAccessPointTypeById(parameters);
        }

        public AssaAccessPointType GetAssaAccessPointType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaAccessPointType(parameters);
        }

        public AssaAccessPointType SaveAssaAccessPointType(SaveParameters<AssaAccessPointType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAssaAccessPointType(parameters);
        }
        #endregion
        #region Async Operations
        public Task<AssaAccessPointType[]> GetAllAssaAccessPointTypesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaAccessPointTypesAsync(parameters);
        }

        public Task<AssaAccessPointType> GetAssaAccessPointByIdAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaAccessPointByIdAsync(parameters);
        }


        public Task<AssaAccessPointType> GetAssaAccessPointTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaAccessPointTypeAsync(parameters);
        }

        public Task<AssaAccessPointType> SaveAssaAccessPointTypeAsync(SaveParameters<AssaAccessPointType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAssaAccessPointTypeAsync(parameters);
        }
        #endregion
        #endregion

        #region Assa Day Period Operations
        #region Synchronous Operations
        public AssaDayPeriod[] GetAllAssaDayPeriods(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaDayPeriods(parameters);
        }

        public AssaDayPeriod[] GetAllAssaDayPeriodsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaDayPeriodsForEntity(parameters);
        }

        //public AssaDayPeriod[] GetAllAssaDayPeriodsForCluster(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAssaDayPeriodsForCluster(parameters);
        //}

        //public AssaDayPeriod[] GetAllAssaDayPeriodsForAssaAbloyDsr(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAssaDayPeriodsForAssaAbloyDsr(parameters);
        //}

        public AssaDayPeriod GetAssaDayPeriod(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaDayPeriod(parameters);
        }

        public AssaDayPeriod SaveAssaDayPeriod(SaveParameters<AssaDayPeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAssaDayPeriod(parameters);
        }

        public int DeleteAssaDayPeriodByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaDayPeriodByPk(parameters);
        }

        public int DeleteAssaDayPeriod(DeleteParameters<AssaDayPeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaDayPeriod(parameters);
        }

        public bool IsAssaDayPeriodReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaDayPeriodReferenced(uid);
        }

        public bool IsAssaDayPeriodUnique(AssaDayPeriod data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaDayPeriodUnique(data);
        }
        #endregion

        #region Async operations

        public Task<AssaDayPeriod[]> GetAllAssaDayPeriodsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaDayPeriodsAsync(parameters);
        }

        public Task<AssaDayPeriod[]> GetAllAssaDayPeriodsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAssaDayPeriodsForEntityAsync(parameters);
        }

        //public Task<AssaDayPeriod[]> GetAllAssaDayPeriodsForClusterAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAssaDayPeriodsForClusterAsync(parameters);
        //}

        //public Task<AssaDayPeriod[]> GetAllAssaDayPeriodsForAssaAbloyDsrAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllAssaDayPeriodsForAssaAbloyDsrAsync(parameters);
        //}

        public Task<AssaDayPeriod> GetAssaDayPeriodAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAssaDayPeriodAsync(parameters);
        }

        public Task<AssaDayPeriod> SaveAssaDayPeriodAsync(SaveParameters<AssaDayPeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAssaDayPeriodAsync(parameters);
        }

        public Task<int> DeleteAssaDayPeriodByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaDayPeriodByPkAsync(parameters);
        }

        public Task<int> DeleteAssaDayPeriodAsync(DeleteParameters<AssaDayPeriod> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAssaDayPeriodAsync(parameters);
        }

        public Task<bool> IsAssaDayPeriodReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaDayPeriodReferencedAsync(uid);
        }

        public Task<bool> IsAssaDayPeriodUniqueAsync(AssaDayPeriod data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAssaDayPeriodUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Cluster Type Operations
        #region Synchronous operations

        public ClusterType[] GetAllClusterTypes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClusterTypes(parameters);
        }

        public ClusterType GetClusterType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterType(parameters);
        }

        public ClusterType SaveClusterType(SaveParameters<ClusterType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveClusterType(parameters);
        }

        public int DeleteClusterTypeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterTypeByPk(parameters);
        }

        public int DeleteClusterType(DeleteParameters<ClusterType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterType(parameters);
        }

        public bool IsClusterTypeReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterTypeReferenced(uid);
        }

        public bool IsClusterTypeUnique(ClusterType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterTypeUnique(data);
        }
        #endregion

        #region Async operations

        public Task<ClusterType[]> GetAllClusterTypesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClusterTypesAsync(parameters);
        }

        public Task<ClusterType> GetClusterTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterTypeAsync(parameters);
        }

        public Task<ClusterType> SaveClusterTypeAsync(SaveParameters<ClusterType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveClusterTypeAsync(parameters);
        }

        public Task<int> DeleteClusterTypeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterTypeByPkAsync(parameters);
        }

        public Task<int> DeleteClusterTypeAsync(DeleteParameters<ClusterType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterTypeAsync(parameters);
        }

        public Task<bool> IsClusterTypeReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterTypeReferencedAsync(uid);
        }

        public Task<bool> IsClusterTypeUniqueAsync(ClusterType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterTypeUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Cluster Command Operations
        #region Synchronous operations
        public ClusterCommand[] GetAllClusterCommands(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClusterCommands(parameters);
        }

        public ClusterCommand[] GetClusterCommandsByClusterType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterCommandsByClusterType(parameters);
        }

        public ClusterCommand GetClusterCommand(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterCommand(parameters);
        }

        public ClusterCommand SaveClusterCommand(SaveParameters<ClusterCommand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveClusterCommand(parameters);
        }

        public int DeleteClusterCommandByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterCommandByPk(parameters);
        }

        public int DeleteClusterCommand(DeleteParameters<ClusterCommand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterCommand(parameters);
        }

        public bool IsClusterCommandReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterCommandReferenced(uid);
        }

        public bool IsClusterCommandUnique(ClusterCommand data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterCommandUnique(data);
        }
        #endregion

        #region Async operations

        public Task<ClusterCommand[]> GetAllClusterCommandsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClusterCommandsAsync(parameters);
        }

        public Task<ClusterCommand[]> GetClusterCommandsByClusterTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterCommandsByClusterTypeAsync(parameters);
        }

        public Task<ClusterCommand> GetClusterCommandAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterCommandAsync(parameters);
        }

        public Task<ClusterCommand> SaveClusterCommandAsync(SaveParameters<ClusterCommand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveClusterCommandAsync(parameters);
        }

        public Task<int> DeleteClusterCommandByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterCommandByPkAsync(parameters);
        }

        public Task<int> DeleteClusterCommandAsync(DeleteParameters<ClusterCommand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterCommandAsync(parameters);
        }

        public Task<bool> IsClusterCommandReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterCommandReferencedAsync(uid);
        }

        public Task<bool> IsClusterCommandUniqueAsync(ClusterCommand data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterCommandUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Cluster Operations
        #region Synchronous operations

        //        public Cluster[] GetAllClusters(GetParametersWithPhoto parameters)
        public ArrayResponse<Cluster> GetAllClusters(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClusters(parameters);
        }

        public ArrayResponse<ClusterListItemCommands> GetAllClustersList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersList(parameters);
        }

        //        public Cluster[] GetAllClustersForEntity(GetParametersWithPhoto parameters)
        public ArrayResponse<Cluster> GetAllClustersForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersForEntity(parameters);
        }

        public ArrayResponse<ClusterListItemCommands> GetAllClustersForEntityList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersForEntityList(parameters);
        }


        public ArrayResponse<ClusterGalaxyPanelMinimal> GetClustersWithGalaxyPanelInfo(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClustersWithGalaxyPanelInfo(parameters);
        }

        //        public Cluster[] GetAllClustersForSite(GetParametersWithPhoto parameters)
        public ArrayResponse<Cluster> GetAllClustersForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersForSite(parameters);
        }

        public ArrayResponse<ClusterListItemCommands> GetAllClustersForSiteList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersForSiteList(parameters);
        }

        public Cluster GetCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCluster(parameters);
        }

        public Cluster GetClusterByHardwareAddress(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterByHardwareAddress(parameters);
        }

        public ValidationProblemDetails ValidateCluster(SaveParameters<Cluster> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateCluster(parameters);
        }

        public Cluster SaveCluster(SaveParameters<Cluster> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveCluster(parameters);
        }

        public int DeleteClusterByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterByPk(parameters);
        }

        public int DeleteCluster(DeleteParameters<Cluster> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCluster(parameters);
        }

        public bool IsClusterReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterReferenced(uid);
        }

        public bool IsClusterUnique(Cluster data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterUnique(data);
        }

        public ClusterEditingData GetClusterEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterEditingData(parameters);
        }

        public LoadDataCommandResponse<ClusterDataLoadParameters> SendClusterDataToPanels(
            CommandParameters<ClusterDataLoadParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendClusterDataToPanels(parameters);
        }

        public BackgroundJobInfo<LoadDataCommandResponse<ClusterDataLoadParameters>> SendClusterDataToPanelsJob(CommandParameters<ClusterDataLoadParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendClusterDataToPanelsJob(parameters);
        }

        #endregion

        #region Async operations

        //        public Task<Cluster[]> GetAllClustersAsync(GetParametersWithPhoto parameters)
        public Task<ArrayResponse<Cluster>> GetAllClustersAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersAsync(parameters);
        }

        public Task<ArrayResponse<ClusterListItemCommands>> GetAllClustersListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersListAsync(parameters);
        }

        //        public Task<Cluster[]> GetAllClustersForEntityAsync(GetParametersWithPhoto parameters)
        public Task<ArrayResponse<Cluster>> GetAllClustersForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersForEntityAsync(parameters);
        }

        public Task<ArrayResponse<ClusterListItemCommands>> GetAllClustersForEntityListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersForEntityListAsync(parameters);
        }

        public Task<ArrayResponse<ClusterGalaxyPanelMinimal>> GetClustersWithGalaxyPanelInfoAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClustersWithGalaxyPanelInfoAsync(parameters);
        }

        //        public Task<Cluster[]> GetAllClustersForSiteAsync(GetParametersWithPhoto parameters)
        public Task<ArrayResponse<Cluster>> GetAllClustersForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersForSiteAsync(parameters);
        }

        public Task<ArrayResponse<ClusterListItemCommands>> GetAllClustersForSiteListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllClustersForSiteListAsync(parameters);
        }

        public Task<Cluster> GetClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterAsync(parameters);
        }

        public Task<Cluster> GetClusterByHardwareAddressAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterByHardwareAddressAsync(parameters);
        }

        public Task<ValidationProblemDetails> ValidateClusterAsync(SaveParameters<Cluster> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateClusterAsync(parameters);
        }

        public Task<Cluster> SaveClusterAsync(SaveParameters<Cluster> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveClusterAsync(parameters);
        }

        public Task<int> DeleteClusterByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterByPkAsync(parameters);
        }

        public Task<int> DeleteClusterAsync(DeleteParameters<Cluster> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteClusterAsync(parameters);
        }

        public Task<bool> IsClusterReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterReferencedAsync(uid);
        }

        public Task<bool> IsClusterUniqueAsync(Cluster data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsClusterUniqueAsync(data);
        }

        public Task<ClusterEditingData> GetClusterEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetClusterEditingDataAsync(parameters);
        }

        public Task<LoadDataCommandResponse<ClusterDataLoadParameters>> SendClusterDataToPanelsAsync(
            CommandParameters<ClusterDataLoadParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendClusterDataToPanelsAsync(parameters);
        }

        public Task<BackgroundJobInfo<LoadDataCommandResponse<ClusterDataLoadParameters>>> SendClusterDataToPanelsJobAsync(CommandParameters<ClusterDataLoadParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendClusterDataToPanelsJobAsync(parameters);

        }

        #endregion
        #endregion

        #region Galaxy Panel Model Operations
        #region Synchronous operations

        public GalaxyPanelModel[] GetAllGalaxyPanelModels(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyPanelModels(parameters);
        }

        public GalaxyPanelModel GetGalaxyPanelModel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelModel(parameters);
        }

        public GalaxyPanelModel SaveGalaxyPanelModel(SaveParameters<GalaxyPanelModel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyPanelModel(parameters);
        }

        public int DeleteGalaxyPanelModelByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelModelByPk(parameters);
        }

        public int DeleteGalaxyPanelModel(DeleteParameters<GalaxyPanelModel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelModel(parameters);
        }

        public bool IsGalaxyPanelModelReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelModelReferenced(uid);
        }

        public bool IsGalaxyPanelModelUnique(GalaxyPanelModel data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelModelUnique(data);
        }
        #endregion

        #region Async operations

        public Task<GalaxyPanelModel[]> GetAllGalaxyPanelModelsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyPanelModelsAsync(parameters);
        }

        public Task<GalaxyPanelModel> GetGalaxyPanelModelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelModelAsync(parameters);
        }

        public Task<GalaxyPanelModel> SaveGalaxyPanelModelAsync(SaveParameters<GalaxyPanelModel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyPanelModelAsync(parameters);
        }

        public Task<int> DeleteGalaxyPanelModelByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelModelByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyPanelModelAsync(DeleteParameters<GalaxyPanelModel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelModelAsync(parameters);
        }

        public Task<bool> IsGalaxyPanelModelReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelModelReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyPanelModelUniqueAsync(GalaxyPanelModel data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelModelUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Galaxy Panel Command Operations
        #region Synchronous operations

        public GalaxyPanelCommand[] GetAllGalaxyPanelCommands(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyPanelCommands(parameters);
        }

        public GalaxyPanelCommand[] GetGalaxyPanelCommandsByPanelModel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelCommandsByPanelModel(parameters);
        }

        public GalaxyPanelCommand GetGalaxyPanelCommand(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelCommand(parameters);
        }

        public GalaxyPanelCommand SaveGalaxyPanelCommand(SaveParameters<GalaxyPanelCommand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyPanelCommand(parameters);
        }

        public int DeleteGalaxyPanelCommandByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelCommandByPk(parameters);
        }

        public int DeleteGalaxyPanelCommand(DeleteParameters<GalaxyPanelCommand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelCommand(parameters);
        }

        public bool IsGalaxyPanelCommandReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelCommandReferenced(uid);
        }

        public bool IsGalaxyPanelCommandUnique(GalaxyPanelCommand data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelCommandUnique(data);
        }
        #endregion

        #region Async operations

        public Task<GalaxyPanelCommand[]> GetAllGalaxyPanelCommandsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyPanelCommandsAsync(parameters);
        }

        public Task<GalaxyPanelCommand[]> GetGalaxyPanelCommandsByPanelModelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelCommandsByPanelModelAsync(parameters);
        }

        public Task<GalaxyPanelCommand> GetGalaxyPanelCommandAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelCommandAsync(parameters);
        }

        public Task<GalaxyPanelCommand> SaveGalaxyPanelCommandAsync(SaveParameters<GalaxyPanelCommand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyPanelCommandAsync(parameters);
        }

        public Task<int> DeleteGalaxyPanelCommandByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelCommandByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyPanelCommandAsync(DeleteParameters<GalaxyPanelCommand> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelCommandAsync(parameters);
        }

        public Task<bool> IsGalaxyPanelCommandReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelCommandReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyPanelCommandUniqueAsync(GalaxyPanelCommand data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelCommandUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Galaxy Panel Operations
        #region Synchronous operations

        public ArrayResponse<GalaxyPanel> GetAllGalaxyPanels(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyPanels(parameters);
        }

        public ArrayResponse<GalaxyPanel> GetAllGalaxyPanelsForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyPanelsForCluster(parameters);
        }

        //public GalaxyPanel[] GetAllGalaxyPanelsForEntity(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllGalaxyPanelsForEntity(parameters);
        //}

        //public GalaxyPanel[] GetAllGalaxyPanelsForRegion(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllGalaxyPanelsForRegion(parameters);
        //}

        public ArrayResponse<GalaxyPanel> GetAllGalaxyPanelsForSite(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyPanelsForSite(parameters);
        }

        public GalaxyPanel GetGalaxyPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanel(parameters);
        }

        public GalaxyPanel GetGalaxyPanelByHardwareAddress(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelByHardwareAddress(parameters);
        }

        public GalaxyPanel SaveGalaxyPanel(SaveParameters<GalaxyPanel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyPanel(parameters);
        }

        public int DeleteGalaxyPanelByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelByPk(parameters);
        }

        public int DeleteGalaxyPanel(DeleteParameters<GalaxyPanel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanel(parameters);
        }

        public bool IsGalaxyPanelReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelReferenced(uid);
        }

        public bool IsGalaxyPanelUnique(GalaxyPanel data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelUnique(data);
        }

        public GalaxyPanelEditingData GetGalaxyPanelEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelEditingData(parameters);
        }


        public ArrayResponse<ActivityHistoryEvent> GetGalaxyPanelActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelActivityHistoryEvents(parameters);
        }

        public ValidationProblemDetails ValidateGalaxyPanel(SaveParameters<GalaxyPanel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateGalaxyPanel(parameters);
        }

        #endregion

        #region Async operations

        public Task<ArrayResponse<GalaxyPanel>> GetAllGalaxyPanelsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyPanelsAsync(parameters);
        }

        public Task<ArrayResponse<GalaxyPanel>> GetAllGalaxyPanelsForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyPanelsForClusterAsync(parameters);
        }

        //public Task<GalaxyPanel[]> GetAllGalaxyPanelsForEntityAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllGalaxyPanelsForEntityAsync(parameters);
        //}

        //public Task<GalaxyPanel[]> GetAllGalaxyPanelsForRegionAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllGalaxyPanelsForRegionAsync(parameters);
        //}

        public Task<ArrayResponse<GalaxyPanel>> GetAllGalaxyPanelsForSiteAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyPanelsForSiteAsync(parameters);
        }

        public Task<GalaxyPanel> GetGalaxyPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelAsync(parameters);
        }

        public Task<GalaxyPanel> GetGalaxyPanelByHardwareAddressAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelByHardwareAddressAsync(parameters);
        }

        public Task<GalaxyPanel> SaveGalaxyPanelAsync(SaveParameters<GalaxyPanel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyPanelAsync(parameters);
        }

        public Task<int> DeleteGalaxyPanelByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyPanelAsync(DeleteParameters<GalaxyPanel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyPanelAsync(parameters);
        }

        public Task<bool> IsGalaxyPanelReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyPanelUniqueAsync(GalaxyPanel data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyPanelUniqueAsync(data);
        }

        public Task<GalaxyPanelEditingData> GetGalaxyPanelEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelEditingDataAsync(parameters);
        }


        public Task<ArrayResponse<ActivityHistoryEvent>> GetGalaxyPanelActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyPanelActivityHistoryEventsAsync(parameters);
        }

        public Task<ValidationProblemDetails> ValidateGalaxyPanelAsync(SaveParameters<GalaxyPanel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateGalaxyPanelAsync(parameters);
        }

        #endregion
        #endregion

        #region Galaxy CPU Model Operations
        #region Synchronous operations

        public GalaxyCpuModel[] GetAllGalaxyCpuModels(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyCpuModels(parameters);
        }

        public GalaxyCpuModel GetGalaxyCpuModel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyCpuModel(parameters);
        }

        public GalaxyCpuModel SaveGalaxyCpuModel(SaveParameters<GalaxyCpuModel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyCpuModel(parameters);
        }

        public int DeleteGalaxyCpuModelByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyCpuModelByPk(parameters);
        }

        public int DeleteGalaxyCpuModel(DeleteParameters<GalaxyCpuModel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyCpuModel(parameters);
        }

        public bool IsGalaxyCpuModelReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyCpuModelReferenced(uid);
        }

        public bool IsGalaxyCpuModelUnique(GalaxyCpuModel data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyCpuModelUnique(data);
        }
        #endregion

        #region Async operations

        public Task<GalaxyCpuModel[]> GetAllGalaxyCpuModelsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyCpuModelsAsync(parameters);
        }

        public Task<GalaxyCpuModel> GetGalaxyCpuModelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyCpuModelAsync(parameters);
        }

        public Task<GalaxyCpuModel> SaveGalaxyCpuModelAsync(SaveParameters<GalaxyCpuModel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyCpuModelAsync(parameters);
        }

        public Task<int> DeleteGalaxyCpuModelByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyCpuModelByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyCpuModelAsync(DeleteParameters<GalaxyCpuModel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyCpuModelAsync(parameters);
        }

        public Task<bool> IsGalaxyCpuModelReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyCpuModelReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyCpuModelUniqueAsync(GalaxyCpuModel data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyCpuModelUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Galaxy CPU Operations
        #region Synchronous operations
        public GalaxyCpu[] GetAllGalaxyCpus(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyCpus(parameters);
        }

        public GalaxyCpu[] GetAllGalaxyCpusForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyCpusForCluster(parameters);
        }

        public GalaxyCpu[] GetAllGalaxyCpusForPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyCpusForPanel(parameters);
        }

        public GalaxyCpu GetGalaxyCpu(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyCpu(parameters);
        }

        public GalaxyCpu SaveGalaxyCpu(SaveParameters<GalaxyCpu> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyCpu(parameters);
        }

        public GalaxyCpuDatabaseInformation SaveGalaxyCpuConnectionInfo(SaveParameters<CpuConnectionInfo> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyCpuConnectionInfo(parameters);
        }

        public int DeleteGalaxyCpuByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyCpuByPk(parameters);
        }

        public int DeleteGalaxyCpu(DeleteParameters<GalaxyCpu> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyCpu(parameters);
        }

        public bool IsGalaxyCpuReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyCpuReferenced(uid);
        }

        public bool IsGalaxyCpuUnique(GalaxyCpu data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyCpuUnique(data);
        }

        public GalaxyCpuLoggingControl SaveGalaxyCpuLoggingControl(SaveParameters<GalaxyCpuLoggingControl> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyCpuLoggingControl(parameters);
        }

        public bool ExecuteGalaxyCpuCommand(CommandParameters<GalaxyCpuCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteGalaxyCpuCommand(parameters);
        }

        public CommandResponse<GalaxyCpuCommandAction> ExecuteClusterCommand(CommandParameters<GalaxyCpuCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteClusterCommand(parameters);
        }

        public bool ExecuteGalaxyLoadFlashCommand(CommandParameters<GalaxyLoadFlashCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteGalaxyLoadFlashCommand(parameters);
        }
        #endregion

        #region Async operations

        public Task<GalaxyCpu[]> GetAllGalaxyCpusAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyCpusAsync(parameters);
        }

        public Task<GalaxyCpu[]> GetAllGalaxyCpusForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyCpusForClusterAsync(parameters);
        }

        public Task<GalaxyCpu[]> GetAllGalaxyCpusForPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyCpusForPanelAsync(parameters);
        }

        public Task<GalaxyCpu> GetGalaxyCpuAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyCpuAsync(parameters);
        }

        public Task<GalaxyCpu> SaveGalaxyCpuAsync(SaveParameters<GalaxyCpu> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyCpuAsync(parameters);
        }

        public Task<GalaxyCpuDatabaseInformation> SaveGalaxyCpuConnectionInfoAsync(SaveParameters<CpuConnectionInfo> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyCpuConnectionInfoAsync(parameters);
        }


        public Task<int> DeleteGalaxyCpuByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyCpuByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyCpuAsync(DeleteParameters<GalaxyCpu> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyCpuAsync(parameters);
        }

        public Task<bool> IsGalaxyCpuReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyCpuReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyCpuUniqueAsync(GalaxyCpu data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyCpuUniqueAsync(data);
        }

        public Task<GalaxyCpuLoggingControl> SaveGalaxyCpuLoggingControlAsync(SaveParameters<GalaxyCpuLoggingControl> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyCpuLoggingControlAsync(parameters);
        }

        public Task<bool> ExecuteGalaxyCpuCommandAsync(CommandParameters<GalaxyCpuCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteGalaxyCpuCommandAsync(parameters);
        }

        public Task<CommandResponse<GalaxyCpuCommandAction>> ExecuteClusterCommandAsync(CommandParameters<GalaxyCpuCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteClusterCommandAsync(parameters);
        }

        public Task<bool> ExecuteGalaxyLoadFlashCommandAsync(CommandParameters<GalaxyLoadFlashCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteGalaxyLoadFlashCommandAsync(parameters);
        }

        #endregion
        #endregion

        #region Galaxy Interface Board Type Operations
        #region Synchronous operations
        public InterfaceBoardType[] GetAllGalaxyInterfaceBoardTypes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardTypes(parameters);
        }

        public InterfaceBoardType GetGalaxyInterfaceBoardType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyInterfaceBoardType(parameters);
        }

        public InterfaceBoardType SaveGalaxyInterfaceBoardType(SaveParameters<InterfaceBoardType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyInterfaceBoardType(parameters);
        }

        public int DeleteGalaxyInterfaceBoardTypeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardTypeByPk(parameters);
        }

        public int DeleteGalaxyInterfaceBoardType(DeleteParameters<InterfaceBoardType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardType(parameters);
        }

        public bool IsGalaxyInterfaceBoardTypeReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardTypeReferenced(uid);
        }

        public bool IsGalaxyInterfaceBoardTypeUnique(InterfaceBoardType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardTypeUnique(data);
        }
        #endregion

        #region Async operations

        public Task<InterfaceBoardType[]> GetAllGalaxyInterfaceBoardTypesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardTypesAsync(parameters);
        }

        public Task<InterfaceBoardType> GetGalaxyInterfaceBoardTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyInterfaceBoardTypeAsync(parameters);
        }

        public Task<InterfaceBoardType> SaveGalaxyInterfaceBoardTypeAsync(SaveParameters<InterfaceBoardType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyInterfaceBoardTypeAsync(parameters);
        }

        public Task<int> DeleteGalaxyInterfaceBoardTypeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardTypeByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyInterfaceBoardTypeAsync(DeleteParameters<InterfaceBoardType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardTypeAsync(parameters);
        }

        public Task<bool> IsGalaxyInterfaceBoardTypeReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardTypeReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyInterfaceBoardTypeUniqueAsync(InterfaceBoardType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardTypeUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Galaxy Interface Board Section Mode Operations
        #region Synchronous operations

        public InterfaceBoardSectionMode[] GetAllGalaxyInterfaceBoardSectionModes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionModes(parameters);
        }

        public InterfaceBoardSectionMode[] GetAllGalaxyInterfaceBoardSectionModesForType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionModesForType(parameters);
        }

        public InterfaceBoardSectionMode GetGalaxyInterfaceBoardSectionMode(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyInterfaceBoardSectionMode(parameters);
        }

        public InterfaceBoardSectionMode SaveGalaxyInterfaceBoardSectionMode(SaveParameters<InterfaceBoardSectionMode> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyInterfaceBoardSectionMode(parameters);
        }

        public int DeleteGalaxyInterfaceBoardSectionModeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionModeByPk(parameters);
        }

        public int DeleteGalaxyInterfaceBoardSectionMode(DeleteParameters<InterfaceBoardSectionMode> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionMode(parameters);
        }

        public bool IsGalaxyInterfaceBoardSectionModeReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionModeReferenced(uid);
        }

        public bool IsGalaxyInterfaceBoardSectionModeUnique(InterfaceBoardSectionMode data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionModeUnique(data);
        }
        #endregion

        #region Async operations

        public Task<InterfaceBoardSectionMode[]> GetAllGalaxyInterfaceBoardSectionModesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionModesAsync(parameters);
        }

        public Task<InterfaceBoardSectionMode[]> GetAllGalaxyInterfaceBoardSectionModesForTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionModesForTypeAsync(parameters);
        }

        public Task<InterfaceBoardSectionMode> GetGalaxyInterfaceBoardSectionModeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyInterfaceBoardSectionModeAsync(parameters);
        }

        public Task<InterfaceBoardSectionMode> SaveGalaxyInterfaceBoardSectionModeAsync(SaveParameters<InterfaceBoardSectionMode> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyInterfaceBoardSectionModeAsync(parameters);
        }

        public Task<int> DeleteGalaxyInterfaceBoardSectionModeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionModeByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyInterfaceBoardSectionModeAsync(DeleteParameters<InterfaceBoardSectionMode> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionModeAsync(parameters);
        }

        public Task<bool> IsGalaxyInterfaceBoardSectionModeReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionModeReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyInterfaceBoardSectionModeUniqueAsync(InterfaceBoardSectionMode data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionModeUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Galaxy Hardware Module Type Operations
        #region Synchronous operations

        public GalaxyHardwareModuleType[] GetAllGalaxyHardwareModuleTypes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModuleTypes(parameters);
        }

        public GalaxyHardwareModuleType GetGalaxyHardwareModuleType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyHardwareModuleType(parameters);
        }

        public GalaxyHardwareModuleType SaveGalaxyHardwareModuleType(SaveParameters<GalaxyHardwareModuleType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyHardwareModuleType(parameters);
        }

        public int DeleteGalaxyHardwareModuleTypeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyHardwareModuleTypeByPk(parameters);
        }

        public int DeleteGalaxyHardwareModuleType(DeleteParameters<GalaxyHardwareModuleType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyHardwareModuleType(parameters);
        }

        public bool IsGalaxyHardwareModuleTypeReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyHardwareModuleTypeReferenced(uid);
        }

        public bool IsGalaxyHardwareModuleTypeUnique(GalaxyHardwareModuleType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyHardwareModuleTypeUnique(data);
        }
        #endregion

        #region Async operations

        public Task<GalaxyHardwareModuleType[]> GetAllGalaxyHardwareModuleTypesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModuleTypesAsync(parameters);
        }

        public Task<GalaxyHardwareModuleType> GetGalaxyHardwareModuleTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyHardwareModuleTypeAsync(parameters);
        }

        public Task<GalaxyHardwareModuleType> SaveGalaxyHardwareModuleTypeAsync(SaveParameters<GalaxyHardwareModuleType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyHardwareModuleTypeAsync(parameters);
        }

        public Task<int> DeleteGalaxyHardwareModuleTypeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyHardwareModuleTypeByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyHardwareModuleTypeAsync(DeleteParameters<GalaxyHardwareModuleType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyHardwareModuleTypeAsync(parameters);
        }

        public Task<bool> IsGalaxyHardwareModuleTypeReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyHardwareModuleTypeReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyHardwareModuleTypeUniqueAsync(GalaxyHardwareModuleType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyHardwareModuleTypeUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Galaxy Interface Board Operations
        #region Synchronous operations

        public GalaxyInterfaceBoard[] GetAllGalaxyInterfaceBoards(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoards(parameters);
        }

        public GalaxyInterfaceBoard[] GetAllGalaxyInterfaceBoardsForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardsForCluster(parameters);
        }

        public GalaxyInterfaceBoard[] GetAllGalaxyInterfaceBoardsForPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardsForPanel(parameters);
        }

        public GalaxyInterfaceBoard[] GetAllGalaxyInterfaceBoardsForPanelAddress(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardsForPanelAddress(parameters);
        }

        public GalaxyInterfaceBoard GetGalaxyInterfaceBoard(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyInterfaceBoard(parameters);
        }

        public GalaxyInterfaceBoard SaveGalaxyInterfaceBoard(SaveParameters<GalaxyInterfaceBoard> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyInterfaceBoard(parameters);
        }

        public int DeleteGalaxyInterfaceBoardByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardByPk(parameters);
        }

        public int DeleteGalaxyInterfaceBoard(DeleteParameters<GalaxyInterfaceBoard> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoard(parameters);
        }

        public bool IsGalaxyInterfaceBoardReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardReferenced(uid);
        }

        public bool IsGalaxyInterfaceBoardUnique(GalaxyInterfaceBoard data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardUnique(data);
        }

        public ValidationProblemDetails ValidateGalaxyInterfaceBoard(SaveParameters<GalaxyInterfaceBoard> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateGalaxyInterfaceBoard(parameters);
        }

        #endregion

        #region Async operations
        public Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardsAsync(parameters);
        }

        public Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardsForClusterAsync(parameters);
        }

        public Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsForPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardsForPanelAsync(parameters);
        }

        public Task<GalaxyInterfaceBoard[]> GetAllGalaxyInterfaceBoardsForPanelAddressAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardsForPanelAddressAsync(parameters);
        }

        public Task<GalaxyInterfaceBoard> GetGalaxyInterfaceBoardAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyInterfaceBoardAsync(parameters);
        }

        public Task<GalaxyInterfaceBoard> SaveGalaxyInterfaceBoardAsync(SaveParameters<GalaxyInterfaceBoard> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyInterfaceBoardAsync(parameters);
        }

        public Task<int> DeleteGalaxyInterfaceBoardByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyInterfaceBoardAsync(DeleteParameters<GalaxyInterfaceBoard> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardAsync(parameters);
        }

        public Task<bool> IsGalaxyInterfaceBoardReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyInterfaceBoardUniqueAsync(GalaxyInterfaceBoard data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardUniqueAsync(data);
        }

        public Task<ValidationProblemDetails> ValidateGalaxyInterfaceBoardAsync(SaveParameters<GalaxyInterfaceBoard> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateGalaxyInterfaceBoardAsync(parameters);
        }

        #endregion
        #endregion

        #region Galaxy Interface Board Section Operations
        #region Synchronous operations
        public GalaxyInterfaceBoardSection[] GetAllGalaxyInterfaceBoardSections(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSections(parameters);
        }

        public GalaxyInterfaceBoardSection[] GetAllGalaxyInterfaceBoardSectionsForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionsForCluster(parameters);
        }

        public GalaxyInterfaceBoardSection[] GetAllGalaxyInterfaceBoardSectionsForPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionsForPanel(parameters);
        }

        public GalaxyInterfaceBoardSection[] GetAllGalaxyInterfaceBoardSectionsForPanelAddress(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionsForPanelAddress(parameters);
        }

        public GalaxyInterfaceBoardSection[] GetAllGalaxyInterfaceBoardSectionsForInterfaceBoard(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionsForInterfaceBoard(parameters);
        }

        public GalaxyInterfaceBoardSection GetGalaxyInterfaceBoardSection(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyInterfaceBoardSection(parameters);
        }

        public GalaxyInterfaceBoardSection SaveGalaxyInterfaceBoardSection(SaveParameters<GalaxyInterfaceBoardSection> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyInterfaceBoardSection(parameters);
        }

        public int DeleteGalaxyInterfaceBoardSectionByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionByPk(parameters);
        }

        public int DeleteGalaxyInterfaceBoardSection(DeleteParameters<GalaxyInterfaceBoardSection> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSection(parameters);
        }

        public bool IsGalaxyInterfaceBoardSectionReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionReferenced(uid);
        }

        public bool IsGalaxyInterfaceBoardSectionUnique(GalaxyInterfaceBoardSection data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionUnique(data);
        }

        public bool ExecuteGalaxyInterfaceBoardSectionCommand(CommandParameters<GalaxyInterfaceBoardSectionCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteGalaxyInterfaceBoardSectionCommand(parameters);
        }
        #endregion

        #region Async operations
        public Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionsAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionsForClusterAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsForPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionsForPanelAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsForPanelAddressAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionsForPanelAddressAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSection[]> GetAllGalaxyInterfaceBoardSectionsForInterfaceBoardAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionsForInterfaceBoardAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSection> GetGalaxyInterfaceBoardSectionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyInterfaceBoardSectionAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSection> SaveGalaxyInterfaceBoardSectionAsync(SaveParameters<GalaxyInterfaceBoardSection> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyInterfaceBoardSectionAsync(parameters);
        }

        public Task<int> DeleteGalaxyInterfaceBoardSectionByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyInterfaceBoardSectionAsync(DeleteParameters<GalaxyInterfaceBoardSection> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionAsync(parameters);
        }

        public Task<bool> IsGalaxyInterfaceBoardSectionReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyInterfaceBoardSectionUniqueAsync(GalaxyInterfaceBoardSection data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionUniqueAsync(data);
        }

        public Task<bool> ExecuteGalaxyInterfaceBoardSectionCommandAsync(CommandParameters<GalaxyInterfaceBoardSectionCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteGalaxyInterfaceBoardSectionCommandAsync(parameters);
        }

        #endregion
        #endregion

        #region Galaxy Hardware Module Operations
        #region Synchronous operations
        public GalaxyHardwareModule[] GetAllGalaxyHardwareModules(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModules(parameters);
        }

        public GalaxyHardwareModule[] GetAllGalaxyHardwareModulesForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesForCluster(parameters);
        }

        public GalaxyHardwareModule[] GetAllGalaxyHardwareModulesForPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesForPanel(parameters);
        }

        public GalaxyHardwareModule[] GetAllGalaxyHardwareModulesForPanelAddress(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesForPanelAddress(parameters);
        }


        public GalaxyHardwareModule[] GetAllGalaxyHardwareModulesForInterfaceBoard(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesForInterfaceBoard(parameters);
        }

        public GalaxyHardwareModule[] GetAllGalaxyHardwareModulesForInterfaceBoardSection(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesForInterfaceBoardSection(parameters);
        }

        public GalaxyHardwareModule GetGalaxyHardwareModule(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyHardwareModule(parameters);
        }

        public GalaxyHardwareModule SaveGalaxyHardwareModule(SaveParameters<GalaxyHardwareModule> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyHardwareModule(parameters);
        }

        public int DeleteGalaxyHardwareModuleByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyHardwareModuleByPk(parameters);
        }

        public int DeleteGalaxyHardwareModule(DeleteParameters<GalaxyHardwareModule> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyHardwareModule(parameters);
        }

        public bool IsGalaxyHardwareModuleReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyHardwareModuleReferenced(uid);
        }

        public bool IsGalaxyHardwareModuleUnique(GalaxyHardwareModule data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyHardwareModuleUnique(data);
        }
        #endregion

        #region Async operations
        public Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesAsync(parameters);
        }

        public Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesForClusterAsync(parameters);
        }

        public Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesForPanelAsync(parameters);
        }

        public Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForPanelAddressAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesForPanelAddressAsync(parameters);
        }

        public Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForInterfaceBoardAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesForInterfaceBoardAsync(parameters);
        }

        public Task<GalaxyHardwareModule[]> GetAllGalaxyHardwareModulesForInterfaceBoardSectionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyHardwareModulesForInterfaceBoardSectionAsync(parameters);
        }

        public Task<GalaxyHardwareModule> GetGalaxyHardwareModuleAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyHardwareModuleAsync(parameters);
        }

        public Task<GalaxyHardwareModule> SaveGalaxyHardwareModuleAsync(SaveParameters<GalaxyHardwareModule> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyHardwareModuleAsync(parameters);
        }

        public Task<int> DeleteGalaxyHardwareModuleByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyHardwareModuleByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyHardwareModuleAsync(DeleteParameters<GalaxyHardwareModule> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyHardwareModuleAsync(parameters);
        }

        public Task<bool> IsGalaxyHardwareModuleReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyHardwareModuleReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyHardwareModuleUniqueAsync(GalaxyHardwareModule data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyHardwareModuleUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Galaxy Interface Board Section Node Operations
        #region Synchronous operations
        public GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodes(parameters);
        }

        public GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForCluster(parameters);
        }

        public GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForPanel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForPanel(parameters);
        }

        public GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForPanelAddress(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForPanelAddress(parameters);
        }

        public GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoard(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoard(parameters);
        }

        public GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSection(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSection(parameters);
        }

        public GalaxyInterfaceBoardSectionNode[] GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModule(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModule(parameters);
        }

        public GalaxyInterfaceBoardSectionNode GetGalaxyInterfaceBoardSectionNode(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyInterfaceBoardSectionNode(parameters);
        }

        public GalaxyInterfaceBoardSectionNode SaveGalaxyInterfaceBoardSectionNode(SaveParameters<GalaxyInterfaceBoardSectionNode> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyInterfaceBoardSectionNode(parameters);
        }

        public int DeleteGalaxyInterfaceBoardSectionNodeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionNodeByPk(parameters);
        }

        public int DeleteGalaxyInterfaceBoardSectionNode(DeleteParameters<GalaxyInterfaceBoardSectionNode> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionNode(parameters);
        }

        public bool IsGalaxyInterfaceBoardSectionNodeReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionNodeReferenced(uid);
        }

        public bool IsGalaxyInterfaceBoardSectionNodeUnique(GalaxyInterfaceBoardSectionNode data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionNodeUnique(data);
        }
        #endregion

        #region Async operations
        public Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForClusterAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForPanelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForPanelAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForPanelAddressAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForPanelAddressAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSectionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSectionAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSectionNode[]> GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModuleAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModuleAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSectionNode> GetGalaxyInterfaceBoardSectionNodeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyInterfaceBoardSectionNodeAsync(parameters);
        }

        public Task<GalaxyInterfaceBoardSectionNode> SaveGalaxyInterfaceBoardSectionNodeAsync(SaveParameters<GalaxyInterfaceBoardSectionNode> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyInterfaceBoardSectionNodeAsync(parameters);
        }

        public Task<int> DeleteGalaxyInterfaceBoardSectionNodeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionNodeByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyInterfaceBoardSectionNodeAsync(DeleteParameters<GalaxyInterfaceBoardSectionNode> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyInterfaceBoardSectionNodeAsync(parameters);
        }

        public Task<bool> IsGalaxyInterfaceBoardSectionNodeReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionNodeReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyInterfaceBoardSectionNodeUniqueAsync(GalaxyInterfaceBoardSectionNode data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyInterfaceBoardSectionNodeUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Galaxy CPU Flash Operations
        #region Synchronous operations

        public GalaxyFlashImage[] GetAllGalaxyFlashImages(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyFlashImages(parameters);
        }
        public GalaxyFlashImage[] GetAllGalaxyFlashImagesForGalaxyCpuModelTypeCode(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyFlashImagesForGalaxyCpuModelTypeCode(parameters);
        }
        public GalaxyFlashImage[] GetAllGalaxyFlashImagesForGalaxyCpuModelUid(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyFlashImagesForGalaxyCpuModelUid(parameters);
        }

        public GalaxyFlashImage GetGalaxyFlashImage(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyFlashImage(parameters);
        }

        public GalaxyFlashImage SaveGalaxyFlashImage(SaveParameters<GalaxyFlashImage> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyFlashImage(parameters);
        }

        public int DeleteGalaxyFlashImageByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyFlashImageByPk(parameters);
        }

        public int DeleteGalaxyFlashImage(DeleteParameters<GalaxyFlashImage> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyFlashImage(parameters);
        }

        public bool IsGalaxyFlashImageReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyFlashImageReferenced(uid);
        }

        public bool IsGalaxyFlashImageUnique(GalaxyFlashImage data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyFlashImageUnique(data);
        }
        #endregion

        #region Async operations

        public Task<GalaxyFlashImage[]> GetAllGalaxyFlashImagesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyFlashImagesAsync(parameters);
        }
        public Task<GalaxyFlashImage[]> GetAllGalaxyFlashImagesForGalaxyCpuModelTypeCodeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyFlashImagesForGalaxyCpuModelTypeCodeAsync(parameters);
        }
        public Task<GalaxyFlashImage[]> GetAllGalaxyFlashImagesForGalaxyCpuModelUidAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyFlashImagesForGalaxyCpuModelUidAsync(parameters);
        }

        public Task<GalaxyFlashImage> GetGalaxyFlashImageAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyFlashImageAsync(parameters);
        }

        public Task<GalaxyFlashImage> SaveGalaxyFlashImageAsync(SaveParameters<GalaxyFlashImage> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyFlashImageAsync(parameters);
        }

        public Task<int> DeleteGalaxyFlashImageByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyFlashImageByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyFlashImageAsync(DeleteParameters<GalaxyFlashImage> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyFlashImageAsync(parameters);
        }

        public Task<bool> IsGalaxyFlashImageReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyFlashImageReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyFlashImageUniqueAsync(GalaxyFlashImage data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyFlashImageUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Galaxy Access Group Operations
        #region Synchronous operations
        public ArrayResponse<AccessGroupEx> GetAllAccessGroups(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessGroups(parameters);
        }

        public ArrayResponse<AccessGroupEx> GetAllAccessGroupsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessGroupsForEntity(parameters);
        }

        public ArrayResponse<AccessGroupEx> GetAllAccessGroupsForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessGroupsForCluster(parameters);
        }

        public AccessGroupEx GetAccessGroup(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessGroup(parameters);
        }

        public AccessGroupEx SaveAccessGroup(SaveParameters<AccessGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAccessGroup(parameters);
        }

        public int DeleteAccessGroupByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessGroupByPk(parameters);
        }

        public int DeleteAccessGroup(DeleteParameters<AccessGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessGroup(parameters);
        }

        public bool IsAccessGroupReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessGroupReferenced(uid);
        }

        public bool IsAccessGroupUnique(AccessGroup data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessGroupUnique(data);
        }

        public int GetAvailableAccessGroupNumber(Guid clusterUid, GalaxySMS.Common.Enums.ChooseAvailableAccessGroupNumberRange rangeOption)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAvailableAccessGroupNumber(clusterUid, rangeOption);
        }

        public AccessGroupEditingData GetAccessGroupEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessGroupEditingData(parameters);
        }

        public ArrayResponse<AccessGroupPersonInfo> GetPersonInfoForAccessGroup(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonInfoForAccessGroup(parameters);
        }

        public ValidationProblemDetails ValidateAccessGroup(SaveParameters<AccessGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateAccessGroup(parameters);
        }

        #endregion

        #region Async operations
        public Task<ArrayResponse<AccessGroupEx>> GetAllAccessGroupsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessGroupsAsync(parameters);
        }

        public Task<ArrayResponse<AccessGroupEx>> GetAllAccessGroupsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessGroupsForEntityAsync(parameters);
        }

        public Task<ArrayResponse<AccessGroupEx>> GetAllAccessGroupsForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessGroupsForClusterAsync(parameters);
        }

        public Task<AccessGroupEx> GetAccessGroupAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessGroupAsync(parameters);
        }


        public Task<AccessGroupEx> SaveAccessGroupAsync(SaveParameters<AccessGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAccessGroupAsync(parameters);
        }


        public Task<int> DeleteAccessGroupByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessGroupByPkAsync(parameters);
        }

        public Task<int> DeleteAccessGroupAsync(DeleteParameters<AccessGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessGroupAsync(parameters);
        }

        public Task<bool> IsAccessGroupReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessGroupReferencedAsync(uid);
        }

        public Task<bool> IsAccessGroupUniqueAsync(AccessGroup data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessGroupUniqueAsync(data);
        }

        public Task<int> GetAvailableAccessGroupNumberAsync(Guid clusterUid, GalaxySMS.Common.Enums.ChooseAvailableAccessGroupNumberRange rangeOption)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAvailableAccessGroupNumberAsync(clusterUid, rangeOption);
        }

        public Task<AccessGroupEditingData> GetAccessGroupEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessGroupEditingDataAsync(parameters);
        }

        public Task<ArrayResponse<AccessGroupPersonInfo>> GetPersonInfoForAccessGroupAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonInfoForAccessGroupAsync(parameters);
        }

        public Task<ValidationProblemDetails> ValidateAccessGroupAsync(SaveParameters<AccessGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateAccessGroupAsync(parameters);

        }

        #endregion
        #endregion

        #region Galaxy Area Operations
        #region Synchronous operations
        public ArrayResponse<Area> GetAllAreas(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAreas(parameters);
        }

        public ArrayResponse<Area> GetAllAreasForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAreasForEntity(parameters);
        }

        public ArrayResponse<Area> GetAllAreasForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAreasForCluster(parameters);
        }

        public Area GetArea(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetArea(parameters);
        }

        public Area SaveArea(SaveParameters<Area> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveArea(parameters);
        }

        public int DeleteAreaByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAreaByPk(parameters);
        }

        public int DeleteArea(DeleteParameters<Area> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteArea(parameters);
        }

        public bool IsAreaReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAreaReferenced(uid);
        }

        public bool IsAreaUnique(Area data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAreaUnique(data);
        }
        #endregion

        #region Async operations
        public Task<ArrayResponse<Area>> GetAllAreasAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAreasAsync(parameters);
        }

        public Task<ArrayResponse<Area>> GetAllAreasForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAreasForEntityAsync(parameters);
        }

        public Task<ArrayResponse<Area>> GetAllAreasForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAreasForClusterAsync(parameters);
        }

        public Task<Area> GetAreaAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAreaAsync(parameters);
        }

        public Task<Area> SaveAreaAsync(SaveParameters<Area> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAreaAsync(parameters);
        }

        public Task<int> DeleteAreaByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAreaByPkAsync(parameters);
        }

        public Task<int> DeleteAreaAsync(DeleteParameters<Area> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAreaAsync(parameters);
        }

        public Task<bool> IsAreaReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAreaReferencedAsync(uid);
        }

        public Task<bool> IsAreaUniqueAsync(Area data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAreaUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Galaxy Input Output Group Operations
        #region Synchronous operations
        public ArrayResponse<InputOutputGroup> GetAllInputOutputGroups(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputOutputGroups(parameters);
        }

        public ArrayResponse<InputOutputGroup> GetAllInputOutputGroupsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputOutputGroupsForEntity(parameters);
        }

        public ArrayResponse<InputOutputGroup> GetAllInputOutputGroupsForCluster(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputOutputGroupsForCluster(parameters);
        }

        public ArrayResponse<InputOutputGroup> GetAllInputOutputGroupsForClusterAddress(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputOutputGroupsForClusterAddress(parameters);
        }


        public InputOutputGroup GetInputOutputGroupForClusterAddressAndInputOutputGroupNumber(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputOutputGroupForClusterAddressAndInputOutputGroupNumber(parameters);
        }

        public InputOutputGroupAssignmentSource[] GetInputOutputGroupAssignmentSourcesForInputOutputGroup(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputOutputGroupAssignmentSourcesForInputOutputGroup(parameters);
        }

        public InputOutputGroup GetInputOutputGroup(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputOutputGroup(parameters);
        }

        public InputOutputGroup SaveInputOutputGroup(SaveParameters<InputOutputGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveInputOutputGroup(parameters);
        }

        public int DeleteInputOutputGroupByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteInputOutputGroupByPk(parameters);
        }

        public int DeleteInputOutputGroup(DeleteParameters<InputOutputGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteInputOutputGroup(parameters);
        }

        public bool IsInputOutputGroupReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsInputOutputGroupReferenced(uid);
        }

        public bool IsInputOutputGroupUnique(InputOutputGroup data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsInputOutputGroupUnique(data);
        }

        public bool ExecuteInputOutputGroupCommand(CommandParameters<InputOutputGroupCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteInputOutputGroupCommand(parameters);
        }
        #endregion

        #region Async operations
        public Task<ArrayResponse<InputOutputGroup>> GetAllInputOutputGroupsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputOutputGroupsAsync(parameters);
        }

        public Task<ArrayResponse<InputOutputGroup>> GetAllInputOutputGroupsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputOutputGroupsForEntityAsync(parameters);
        }

        public Task<ArrayResponse<InputOutputGroup>> GetAllInputOutputGroupsForClusterAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputOutputGroupsForClusterAsync(parameters);
        }


        public Task<ArrayResponse<InputOutputGroup>> GetAllInputOutputGroupsForClusterAddressAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllInputOutputGroupsForClusterAddressAsync(parameters);
        }

        public Task<InputOutputGroup> GetInputOutputGroupForClusterAddressAndInputOutputGroupNumberAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputOutputGroupForClusterAddressAndInputOutputGroupNumberAsync(parameters);
        }

        public Task<InputOutputGroup> GetInputOutputGroupAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputOutputGroupAsync(parameters);
        }

        public Task<InputOutputGroupAssignmentSource[]> GetInputOutputGroupAssignmentSourcesForInputOutputGroupAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetInputOutputGroupAssignmentSourcesForInputOutputGroupAsync(parameters);
        }

        public Task<InputOutputGroup> SaveInputOutputGroupAsync(SaveParameters<InputOutputGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveInputOutputGroupAsync(parameters);
        }

        public Task<int> DeleteInputOutputGroupByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteInputOutputGroupByPkAsync(parameters);
        }

        public Task<int> DeleteInputOutputGroupAsync(DeleteParameters<InputOutputGroup> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteInputOutputGroupAsync(parameters);
        }

        public Task<bool> IsInputOutputGroupReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsInputOutputGroupReferencedAsync(uid);
        }

        public Task<bool> IsInputOutputGroupUniqueAsync(InputOutputGroup data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsInputOutputGroupUniqueAsync(data);
        }

        public Task<bool> ExecuteInputOutputGroupCommandAsync(CommandParameters<InputOutputGroupCommandAction> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ExecuteInputOutputGroupCommandAsync(parameters);
        }


        #endregion
        #endregion

        #region Access Profile Operations
        #region Synchronous Operations
        public ArrayResponse<AccessProfile> GetAllAccessProfiles(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessProfiles(parameters);
        }

        public ArrayResponse<AccessProfileListItem> GetAllAccessProfilesList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessProfilesList(parameters);
        }

        public ArrayResponse<AccessProfile> GetAllAccessProfilesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessProfilesForEntity(parameters);
        }

        public ArrayResponse<AccessProfileListItem> GetAllAccessProfilesListForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessProfilesListForEntity(parameters);
        }


        public ArrayResponse<AccessProfile> GetAllAccessProfilesForMappedEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessProfilesForMappedEntity(parameters);
        }

        public AccessProfile GetAccessProfile(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessProfile(parameters);
        }

        public AccessProfile SaveAccessProfile(SaveParameters<AccessProfile> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAccessProfile(parameters);
        }

        public int DeleteAccessProfileByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessProfileByPk(parameters);
        }

        public int DeleteAccessProfile(DeleteParameters<AccessProfile> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessProfile(parameters);
        }

        public bool IsAccessProfileReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessProfileReferenced(uid);
        }

        public bool IsAccessProfileUnique(AccessProfile data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessProfileUnique(data);
        }

        public AccessProfileEditingData GetAccessProfileEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessProfileEditingData(parameters);
        }

        public AccessAndAlarmControlPermissionsEditingData GetAccessProfileClusterPermissionsEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessProfileClusterPermissionsEditingData(parameters);
        }

        public int SyncPersonsWithAccessProfile(SaveParameters<AccessProfile> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SyncPersonsWithAccessProfile(parameters);
        }


        #endregion

        #region Async Operations
        public Task<ArrayResponse<AccessProfile>> GetAllAccessProfilesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessProfilesAsync(parameters);
        }
        public Task<ArrayResponse<AccessProfileListItem>> GetAllAccessProfilesListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessProfilesListAsync(parameters);
        }

        public Task<ArrayResponse<AccessProfile>> GetAllAccessProfilesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessProfilesForEntityAsync(parameters);
        }

        public Task<ArrayResponse<AccessProfileListItem>> GetAllAccessProfilesListForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessProfilesListForEntityAsync(parameters);
        }

        public Task<ArrayResponse<AccessProfile>> GetAllAccessProfilesForMappedEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllAccessProfilesForMappedEntityAsync(parameters);
        }

        public Task<AccessProfile> GetAccessProfileAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessProfileAsync(parameters);
        }

        public Task<AccessProfile> SaveAccessProfileAsync(SaveParameters<AccessProfile> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveAccessProfileAsync(parameters);
        }

        public Task<int> DeleteAccessProfileByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessProfileByPkAsync(parameters);
        }

        public Task<int> DeleteAccessProfileAsync(DeleteParameters<AccessProfile> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteAccessProfileAsync(parameters);
        }

        public Task<bool> IsAccessProfileReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessProfileReferencedAsync(uid);
        }

        public Task<bool> IsAccessProfileUniqueAsync(AccessProfile data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsAccessProfileUniqueAsync(data);
        }

        public Task<AccessProfileEditingData> GetAccessProfileEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessProfileEditingDataAsync(parameters);
        }

        public Task<AccessAndAlarmControlPermissionsEditingData> GetAccessProfileClusterPermissionsEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessProfileClusterPermissionsEditingDataAsync(parameters);
        }

        public Task<int> SyncPersonsWithAccessProfileAsync(SaveParameters<AccessProfile> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SyncPersonsWithAccessProfileAsync(parameters);
        }

        #endregion
        #endregion

        #region Department operations
        #region Synchronous operations
        public ArrayResponse<Department> GetAllDepartments(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDepartments(parameters);
        }
        public ArrayResponse<Department> GetAllDepartmentsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDepartmentsForEntity(parameters);
        }

        public Department GetDepartment(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDepartment(parameters);
        }

        public ArrayResponse<ListItemBase> GetAllDepartmentsList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDepartmentsList(parameters);
        }

        public ArrayResponse<ListItemBase> GetAllDepartmentsListEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDepartmentsListEntity(parameters);
        }

        public Department SaveDepartment(SaveParameters<Department> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveDepartment(parameters);
        }

        public int DeleteDepartmentByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDepartmentByPk(parameters);
        }

        public int DeleteDepartment(DeleteParameters<Department> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDepartment(parameters);
        }

        public bool IsDepartmentReferenced(Guid departmentUId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDepartmentReferenced(departmentUId);
        }

        public bool IsDepartmentUnique(Department department)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDepartmentUnique(department);
        }

        #endregion

        #region Async operations
        public Task<ArrayResponse<Department>> GetAllDepartmentsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDepartmentsAsync(parameters);
        }

        public Task<ArrayResponse<Department>> GetAllDepartmentsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDepartmentsForEntityAsync(parameters);
        }

        public Task<ArrayResponse<ListItemBase>> GetAllDepartmentsListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDepartmentsListAsync(parameters);
        }

        public Task<ArrayResponse<ListItemBase>> GetAllDepartmentsListEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllDepartmentsListEntityAsync(parameters);
        }

        public Task<Department> GetDepartmentAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDepartmentAsync(parameters);
        }

        public Task<Department> SaveDepartmentAsync(SaveParameters<Department> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveDepartmentAsync(parameters);
        }

        public Task<int> DeleteDepartmentByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDepartmentByPkAsync(parameters);
        }

        public Task<int> DeleteDepartmentAsync(DeleteParameters<Department> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteDepartmentAsync(parameters);
        }

        public Task<bool> IsDepartmentReferencedAsync(Guid departmentUId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDepartmentReferencedAsync(departmentUId);
        }

        public Task<bool> IsDepartmentUniqueAsync(Department department)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsDepartmentUniqueAsync(department);
        }
        #endregion
        #endregion

        #region BadgeTemplate operations
        #region Synchronous operations
        public BadgeTemplate[] GetAllBadgeTemplates(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllBadgeTemplates(parameters);
        }
        public BadgeTemplate[] GetAllBadgeTemplatesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllBadgeTemplatesForEntity(parameters);
        }

        public BadgeTemplate GetBadgeTemplate(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetBadgeTemplate(parameters);
        }

        public ListItemBase[] GetAllBadgeTemplatesList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllBadgeTemplatesList(parameters);
        }

        public ListItemBase[] GetAllBadgeTemplatesListEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllBadgeTemplatesListEntity(parameters);
        }

        public BadgeTemplate SaveBadgeTemplate(SaveParameters<BadgeTemplate> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveBadgeTemplate(parameters);
        }

        public int DeleteBadgeTemplateByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteBadgeTemplateByPk(parameters);
        }

        public int DeleteBadgeTemplate(DeleteParameters<BadgeTemplate> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteBadgeTemplate(parameters);
        }

        public bool IsBadgeTemplateReferenced(Guid badgeTemplateUId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsBadgeTemplateReferenced(badgeTemplateUId);
        }

        public bool IsBadgeTemplateUnique(BadgeTemplate badgeTemplate)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsBadgeTemplateUnique(badgeTemplate);
        }

        #endregion

        #region Async operations
        public Task<BadgeTemplate[]> GetAllBadgeTemplatesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllBadgeTemplatesAsync(parameters);
        }

        public Task<BadgeTemplate[]> GetAllBadgeTemplatesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllBadgeTemplatesForEntityAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllBadgeTemplatesListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllBadgeTemplatesListAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllBadgeTemplatesListEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllBadgeTemplatesListEntityAsync(parameters);
        }

        public Task<BadgeTemplate> GetBadgeTemplateAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetBadgeTemplateAsync(parameters);
        }

        public Task<BadgeTemplate> SaveBadgeTemplateAsync(SaveParameters<BadgeTemplate> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveBadgeTemplateAsync(parameters);
        }

        public Task<int> DeleteBadgeTemplateByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteBadgeTemplateByPkAsync(parameters);
        }

        public Task<int> DeleteBadgeTemplateAsync(DeleteParameters<BadgeTemplate> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteBadgeTemplateAsync(parameters);
        }

        public Task<bool> IsBadgeTemplateReferencedAsync(Guid badgeTemplateUId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsBadgeTemplateReferencedAsync(badgeTemplateUId);
        }

        public Task<bool> IsBadgeTemplateUniqueAsync(BadgeTemplate badgeTemplate)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsBadgeTemplateUniqueAsync(badgeTemplate);
        }
        #endregion
        #endregion

        #region PersonRecordType operations
        #region Synchronous operations
        public PersonRecordType[] GetAllPersonRecordTypes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonRecordTypes(parameters);
        }
        public PersonRecordType[] GetAllPersonRecordTypesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonRecordTypesForEntity(parameters);
        }

        public PersonRecordType GetPersonRecordType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonRecordType(parameters);
        }

        public ListItemBase[] GetAllPersonRecordTypesList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonRecordTypesList(parameters);
        }

        public ListItemBase[] GetAllPersonRecordTypesListEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonRecordTypesListEntity(parameters);
        }

        public PersonRecordType SavePersonRecordType(SaveParameters<PersonRecordType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePersonRecordType(parameters);
        }

        public int DeletePersonRecordTypeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePersonRecordTypeByPk(parameters);
        }

        public int DeletePersonRecordType(DeleteParameters<PersonRecordType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePersonRecordType(parameters);
        }

        public bool IsPersonRecordTypeReferenced(Guid personRecordTypeUId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPersonRecordTypeReferenced(personRecordTypeUId);
        }

        public bool IsPersonRecordTypeUnique(PersonRecordType personRecordType)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPersonRecordTypeUnique(personRecordType);
        }

        #endregion

        #region Async operations
        public Task<PersonRecordType[]> GetAllPersonRecordTypesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonRecordTypesAsync(parameters);
        }

        public Task<PersonRecordType[]> GetAllPersonRecordTypesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonRecordTypesForEntityAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllPersonRecordTypesListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonRecordTypesListAsync(parameters);
        }

        public Task<ListItemBase[]> GetAllPersonRecordTypesListEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonRecordTypesListEntityAsync(parameters);
        }

        public Task<PersonRecordType> GetPersonRecordTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonRecordTypeAsync(parameters);
        }

        public Task<PersonRecordType> SavePersonRecordTypeAsync(SaveParameters<PersonRecordType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePersonRecordTypeAsync(parameters);
        }

        public Task<int> DeletePersonRecordTypeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePersonRecordTypeByPkAsync(parameters);
        }

        public Task<int> DeletePersonRecordTypeAsync(DeleteParameters<PersonRecordType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePersonRecordTypeAsync(parameters);
        }

        public Task<bool> IsPersonRecordTypeReferencedAsync(Guid personRecordTypeUId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPersonRecordTypeReferencedAsync(personRecordTypeUId);
        }

        public Task<bool> IsPersonRecordTypeUniqueAsync(PersonRecordType personRecordType)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPersonRecordTypeUniqueAsync(personRecordType);
        }
        #endregion
        #endregion

        #region Person operations
        #region Synchronous operations
        public Person[] GetAllPersons(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersons(parameters);
        }

        public Person[] GetAllPersonsForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonsForEntity(parameters);
        }

        public PersonSummary[] SearchPersons(PersonSummarySearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SearchPersons(parameters);
        }
        public ArrayResponse<PersonSummary> SearchPersonsPaged(PersonSummarySearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SearchPersonsPaged(parameters);
        }

        public Person GetPerson(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPerson(parameters);
        }

        public Person SavePerson(SaveParameters<Person> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePerson(parameters);
        }

        public int DeletePersonByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePersonByPk(parameters);
        }

        public int DeletePerson(DeleteParameters<Person> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePerson(parameters);
        }

        public bool IsPersonReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPersonReferenced(uid);
        }

        public bool IsPersonUnique(Person data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPersonUnique(data);
        }

        public PersonEditingData GetPersonEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonEditingData(parameters);
        }

        //public PersonEditingData GetPersonEditingDataWpf(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetPersonEditingDataWpf(parameters);
        //}

        public AccessAndAlarmControlPermissionsEditingData GetAccessAndAlarmControlPermissionsEditingData(
            GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessAndAlarmControlPermissionsEditingData(parameters);
        }

        //public AccessAndAlarmControlPermissionsEditingData GetAccessAndAlarmControlPermissionsEditingDataWpf(
        //    GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAccessAndAlarmControlPermissionsEditingDataWpf(parameters);
        //}

        public UserInterfacePageControlData GetPersonUserInterfacePageControlData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonUserInterfacePageControlData(parameters);
        }

        public Person SyncPersonWithAccessProfile(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SyncPersonWithAccessProfile(parameters);
        }

        public SaveDefaultPhotoResponse SavePersonPhoto(SaveParameters<SavePhotoParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePersonPhoto(parameters);
        }

        public PersonInfoWithMissingPhotoUrl[] GetPersonInfoWithNoPhotoPublicUrl(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonInfoWithNoPhotoPublicUrl(entityId);
        }

        public PersonSavePhotoResponse[] SendPersonPhotosToCdn(Guid personUid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendPersonPhotosToCdn(personUid);
        }

        public int DeletePersonPhoto(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePersonPhoto(parameters);
        }

        public Person UpdatePersonProperties(SaveParameters<SavePersonPropertiesParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UpdatePersonProperties(parameters);
        }

        #endregion

        #region Async operations
        public Task<Person[]> GetAllPersonsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonsAsync(parameters);
        }

        public Task<Person[]> GetAllPersonsForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPersonsForEntityAsync(parameters);
        }

        public Task<PersonSummary[]> SearchPersonsAsync(PersonSummarySearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SearchPersonsAsync(parameters);
        }

        public Task<ArrayResponse<PersonSummary>> SearchPersonsPagedAsync(PersonSummarySearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SearchPersonsPagedAsync(parameters);
        }

        public Task<Person> GetPersonAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonAsync(parameters);
        }

        public Task<Person> SavePersonAsync(SaveParameters<Person> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePersonAsync(parameters);
        }

        public Task<int> DeletePersonByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePersonByPkAsync(parameters);
        }

        public Task<int> DeletePersonAsync(DeleteParameters<Person> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePersonAsync(parameters);
        }

        public Task<bool> IsPersonReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPersonReferencedAsync(uid);
        }

        public Task<bool> IsPersonUniqueAsync(Person data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPersonUniqueAsync(data);
        }

        public Task<PersonEditingData> GetPersonEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonEditingDataAsync(parameters);
        }

        //public Task<PersonEditingData> GetPersonEditingDataWpfAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetPersonEditingDataWpfAsync(parameters);
        //}

        public Task<AccessAndAlarmControlPermissionsEditingData> GetAccessAndAlarmControlPermissionsEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAccessAndAlarmControlPermissionsEditingDataAsync(parameters);
        }

        //public Task<AccessAndAlarmControlPermissionsEditingData> GetAccessAndAlarmControlPermissionsEditingDataWpfAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAccessAndAlarmControlPermissionsEditingDataWpfAsync(parameters);
        //}

        public Task<UserInterfacePageControlData> GetPersonUserInterfacePageControlDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonUserInterfacePageControlDataAsync(parameters);
        }

        public Task<Person> SyncPersonWithAccessProfileAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SyncPersonWithAccessProfileAsync(parameters);
        }

        public Task<SaveDefaultPhotoResponse> SavePersonPhotoAsync(SaveParameters<SavePhotoParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePersonPhotoAsync(parameters);
        }

        public Task<PersonInfoWithMissingPhotoUrl[]> GetPersonInfoWithNoPhotoPublicUrlAsync(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPersonInfoWithNoPhotoPublicUrlAsync(entityId);
        }

        public Task<PersonSavePhotoResponse[]> SendPersonPhotosToCdnAsync(Guid personUid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendPersonPhotosToCdnAsync(personUid);
        }

        public Task<int> DeletePersonPhotoAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePersonPhotoAsync(parameters);
        }

        public Task<Person> UpdatePersonPropertiesAsync(SaveParameters<SavePersonPropertiesParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UpdatePersonPropertiesAsync(parameters);
        }

        #endregion
        #endregion

        #region User Defined Property Opertions
        #region Synchronous Operations

        public UserDefinedProperty[] GetAllUserDefinedProperties(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserDefinedProperties(parameters);
        }

        public UserDefinedProperty[] GetAllUserDefinedPropertiesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserDefinedPropertiesForEntity(parameters);
        }

        public UserDefinedProperty GetUserDefinedProperty(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserDefinedProperty(parameters);
        }

        public UserDefinedProperty SaveUserDefinedProperty(SaveParameters<UserDefinedProperty> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserDefinedProperty(parameters);
        }

        public int DeleteUserDefinedPropertyByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserDefinedPropertyByPk(parameters);
        }

        public int DeleteUserDefinedProperty(DeleteParameters<UserDefinedProperty> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserDefinedProperty(parameters);
        }

        public bool IsUserDefinedPropertyReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserDefinedPropertyReferenced(uid);
        }

        public bool IsUserDefinedPropertyUnique(UserDefinedProperty data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserDefinedPropertyUnique(data);
        }

        public UserInterfacePageControlData SaveUserDefinedProperties(SaveParameters<List<UserDefinedProperty>> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserDefinedProperties(parameters);
        }

        #endregion

        #region Async Operations

        public Task<UserDefinedProperty[]> GetAllUserDefinedPropertiesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserDefinedPropertiesAsync(parameters);
        }

        public Task<UserDefinedProperty[]> GetAllUserDefinedPropertiesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserDefinedPropertiesForEntityAsync(parameters);
        }

        public Task<UserDefinedProperty> GetUserDefinedPropertyAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserDefinedPropertyAsync(parameters);
        }

        public Task<UserDefinedProperty> SaveUserDefinedPropertyAsync(SaveParameters<UserDefinedProperty> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserDefinedPropertyAsync(parameters);
        }
        public Task<int> DeleteUserDefinedPropertyByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserDefinedPropertyByPkAsync(parameters);
        }

        public Task<int> DeleteUserDefinedPropertyAsync(DeleteParameters<UserDefinedProperty> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserDefinedPropertyAsync(parameters);
        }

        public Task<bool> IsUserDefinedPropertyReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserDefinedPropertyReferencedAsync(uid);
        }

        public Task<bool> IsUserDefinedPropertyUniqueAsync(UserDefinedProperty data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserDefinedPropertyUniqueAsync(data);
        }
        public Task<UserInterfacePageControlData> SaveUserDefinedPropertiesAsync(SaveParameters<List<UserDefinedProperty>> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserDefinedPropertiesAsync(parameters);
        }
        #endregion
        #endregion

        #region Credential Operations
        #region Synchronous Operations
        public DecodedCredential[] DecodeCredentialNumber(DecodeCredentialNumberParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DecodeCredentialNumber(parameters);
        }

        public Credential_PanelLoadData[] GetCredentialDataChangesToLoadForCpu(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialDataChangesToLoadForCpu(parameters);
        }

        public Credential_PanelLoadData[] GetAllCredentialPanelData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCredentialPanelData(parameters);
        }

        public CredentialToDeleteFromCpu[] GetCredentialDataToDeleteLoadForCpu(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialDataToDeleteLoadForCpu(parameters);
        }

        public CredentialFormat GetCredentialFormat(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialFormat(parameters);
        }

        #endregion

        #region Async Operations

        public Task<DecodedCredential[]> DecodeCredentialNumberAsync(DecodeCredentialNumberParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DecodeCredentialNumberAsync(parameters);
        }


        public Task<Credential_PanelLoadData[]> GetCredentialDataChangesToLoadForCpuAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialDataChangesToLoadForCpuAsync(parameters);
        }

        public Task<Credential_PanelLoadData[]> GetAllCredentialPanelDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCredentialPanelDataAsync(parameters);
        }

        public Task<CredentialToDeleteFromCpu[]> GetCredentialDataToDeleteLoadForCpuAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialDataToDeleteLoadForCpuAsync(parameters);
        }

        public Task<CredentialFormat> GetCredentialFormatAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialFormatAsync(parameters);
        }

        #endregion
        #endregion

        #region GalaxyActivityEventType
        #region Synchronous Operations

        public GalaxyActivityEventType[] GetAllGalaxyActivityEventType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyActivityEventType(parameters);
        }

        public GalaxyActivityEventTypeBasicGroups GetGalaxyActivityEventTypes(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyActivityEventTypes(parameters);
        }

        public GalaxyActivityEventType[] GetAllGalaxyActivityEventTypeForCulture(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyActivityEventTypeForCulture(parameters);
        }

        public GalaxyActivityEventType GetGalaxyActivityEventType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyActivityEventType(parameters);
        }

        public GalaxyActivityEventType GetGalaxyActivityEventTypeByEventType(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyActivityEventTypeByEventType(parameters);
        }

        public GalaxyActivityEventType SaveGalaxyActivityEventType(SaveParameters<GalaxyActivityEventType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyActivityEventType(parameters);
        }

        public int DeleteGalaxyActivityEventTypeByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyActivityEventTypeByPk(parameters);
        }

        public int DeleteGalaxyActivityEventType(DeleteParameters<GalaxyActivityEventType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyActivityEventType(parameters);
        }

        public bool IsGalaxyActivityEventTypeReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyActivityEventTypeReferenced(uid);
        }

        public bool IsGalaxyActivityEventTypeUnique(GalaxyActivityEventType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyActivityEventTypeUnique(data);
        }

        #endregion

        #region Async Operations

        public Task<GalaxyActivityEventType[]> GetAllGalaxyActivityEventTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyActivityEventTypeAsync(parameters);
        }

        public Task<GalaxyActivityEventTypeBasicGroups> GetGalaxyActivityEventTypesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyActivityEventTypesAsync(parameters);
        }

        public Task<GalaxyActivityEventType[]> GetAllGalaxyActivityEventTypeForCultureAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllGalaxyActivityEventTypeForCultureAsync(parameters);
        }

        public Task<GalaxyActivityEventType> GetGalaxyActivityEventTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyActivityEventTypeAsync(parameters);
        }

        public Task<GalaxyActivityEventType> GetGalaxyActivityEventTypeByEventTypeAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetGalaxyActivityEventTypeByEventTypeAsync(parameters);
        }

        public Task<GalaxyActivityEventType> SaveGalaxyActivityEventTypeAsync(SaveParameters<GalaxyActivityEventType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveGalaxyActivityEventTypeAsync(parameters);
        }

        public Task<int> DeleteGalaxyActivityEventTypeByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyActivityEventTypeByPkAsync(parameters);
        }

        public Task<int> DeleteGalaxyActivityEventTypeAsync(DeleteParameters<GalaxyActivityEventType> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteGalaxyActivityEventTypeAsync(parameters);
        }
        public Task<bool> IsGalaxyActivityEventTypeReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyActivityEventTypeReferencedAsync(uid);
        }

        public Task<bool> IsGalaxyActivityEventTypeUniqueAsync(GalaxyActivityEventType data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsGalaxyActivityEventTypeUniqueAsync(data);
        }
        #endregion
        #endregion

        #region Activity Event Data Operations
        #region Synchronous Operations
        public Credential_ActivityEventData GetCredentialActivityEventData(byte[] parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialActivityEventData(parameters);
        }

        #endregion
        #region Async Operations

        public Task<Credential_ActivityEventData> GetCredentialActivityEventDataAsync(byte[] parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCredentialActivityEventDataAsync(parameters);
        }

        #endregion
        #endregion

        #region Alarm Acknowledgement Operations
        #region Synchronous Operations

        public AcknowledgedAlarmBasicData AcknowledgeAlarmEvent(SaveParameters<AcknowledgeAlarmEventParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.AcknowledgeAlarmEvent(parameters);
        }

        public int UnacknowledgeAlarmEvent(SaveParameters<UnacknowledgeAlarmEventParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UnacknowledgeAlarmEvent(parameters);
        }

        public PanelActivityLogMessage[] GetUnacknowledgedAlarms(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUnacknowledgedAlarms(parameters);
        }

        #endregion

        #region Async Operations

        public Task<AcknowledgedAlarmBasicData> AcknowledgeAlarmEventAsync(SaveParameters<AcknowledgeAlarmEventParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.AcknowledgeAlarmEventAsync(parameters);
        }

        public Task<int> UnacknowledgeAlarmEventAsync(SaveParameters<UnacknowledgeAlarmEventParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UnacknowledgeAlarmEventAsync(parameters);

        }

        public Task<PanelActivityLogMessage[]> GetUnacknowledgedAlarmsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUnacknowledgedAlarmsAsync(parameters);
        }

        #endregion
        #endregion

        #region idPRODUCER Operations

        #region Sync Operations
        public SubscriptionData IdProducerEnsureIsLicensed(SaveParameters<IdProducerSaveMasterLicenseParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IdProducerEnsureIsLicensed(parameters);
        }

        public bool IdProducerUpdateRootSubscriptionCompanyName(SaveParameters<IdProducerUpdateRootCustomerNameParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IdProducerUpdateRootSubscriptionCompanyName(parameters);
        }

        public SubscriptionData IdProducerSyncSubscriptionAndEntity(SaveParameters<IdProducerSyncSubscriptionAndEntityParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IdProducerSyncSubscriptionAndEntity(parameters);
        }

        public SubscriptionData[] IdProducerGetSubscriptions(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IdProducerGetSubscriptions(parameters);
        }

        public SubscriptionData IdProducerGetRootSubscription(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IdProducerGetRootSubscription(parameters);
        }


        public PrintDispatcher[] GetPrintDispatchers(GetParametersWithPhoto<IdProducerRequestParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPrintDispatchers(parameters);
        }


        public Printer[] GetPrinters(GetParametersWithPhoto<IdProducerRequestParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPrinters(parameters);
        }

        public PreviewData GetPreviewImagesForCredential(GetParametersWithPhoto<IdProducerPrintPreviewRequestParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPreviewImagesForCredential(parameters);
        }

        public CreatedPrintRequest[] CreatePrintRequestForCredential(GetParametersWithPhoto<IdProducerPrintRequestParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.CreatePrintRequestForCredential(parameters);
        }

        public ServerVersionNumber GetIdProducerVersion()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetIdProducerVersion();
        }

        #endregion

        #region Async operations
        public Task<SubscriptionData> IdProducerEnsureIsLicensedAsync(SaveParameters<IdProducerSaveMasterLicenseParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IdProducerEnsureIsLicensedAsync(parameters);
        }

        public Task<bool> IdProducerUpdateRootSubscriptionCompanyNameAsync(SaveParameters<IdProducerUpdateRootCustomerNameParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IdProducerUpdateRootSubscriptionCompanyNameAsync(parameters);
        }

        public Task<SubscriptionData> IdProducerSyncSubscriptionAndEntityAsync(SaveParameters<IdProducerSyncSubscriptionAndEntityParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IdProducerSyncSubscriptionAndEntityAsync(parameters);
        }

        public Task<SubscriptionData[]> IdProducerGetSubscriptionsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IdProducerGetSubscriptionsAsync(parameters);
        }


        public Task<SubscriptionData> IdProducerGetRootSubscriptionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IdProducerGetRootSubscriptionAsync(parameters);
        }

        public Task<PrintDispatcher[]> GetPrintDispatchersAsync(GetParametersWithPhoto<IdProducerRequestParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPrintDispatchersAsync(parameters);
        }


        public Task<Printer[]> GetPrintersAsync(GetParametersWithPhoto<IdProducerRequestParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPrintersAsync(parameters);
        }

        public Task<PreviewData> GetPreviewImagesForCredentialAsync(GetParametersWithPhoto<IdProducerPrintPreviewRequestParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPreviewImagesForCredentialAsync(parameters);
        }

        public Task<CreatedPrintRequest[]> CreatePrintRequestForCredentialAsync(GetParametersWithPhoto<IdProducerPrintRequestParameters> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.CreatePrintRequestForCredentialAsync(parameters);
        }

        public Task<ServerVersionNumber> GetIdProducerVersionAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetIdProducerVersionAsync();
        }

        public ValidationProblemDetails ValidateByGuid(GuidValidationRequest data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateByGuid(data);
        }

        public Task<ValidationProblemDetails> ValidateByGuidAsync(GuidValidationRequest data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidateByGuidAsync(data);
        }

        public ArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetActivityHistoryEvents(parameters);
        }

        public EventFilterData GetEventFilterData(EventFilterDataSelectionParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEventFilterData(parameters);
        }

        public EntityDeviceAlertEventSettings GetDeviceAlertEventSettings(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDeviceAlertEventSettings(parameters);
        }

        public EntityDeviceAlertEventSettings SaveDeviceAlertEventSettings(SaveParameters<EntityDeviceAlertEventSettings> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveDeviceAlertEventSettings(parameters);
        }

        public Task<ArrayResponse<ActivityHistoryEvent>> GetActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetActivityHistoryEventsAsync(parameters);
        }

        public Task<EventFilterData> GetEventFilterDataAsync(EventFilterDataSelectionParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEventFilterDataAsync(parameters);

        }

        public Task<EntityDeviceAlertEventSettings> GetDeviceAlertEventSettingsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetDeviceAlertEventSettingsAsync(parameters);
        }

        public Task<EntityDeviceAlertEventSettings> SaveDeviceAlertEventSettingsAsync(SaveParameters<EntityDeviceAlertEventSettings> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveDeviceAlertEventSettingsAsync(parameters);
        }

        #endregion

        #endregion

    }
}
