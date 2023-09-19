using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using GCS.Framework.Caching;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace GalaxySMS.Data
{
    [Export(typeof(ISiteRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SiteRepository : DataRepositoryBase<Site>, ISiteRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import]
        private IRegionRepository _regionRepository;

        [Import]
        private IAddressRepository _addressRepository;

        [Import]
        private ISiteEntityMapRepository _entityMapRepository;

        [Import] private IRoleSiteRepository _roleSiteRepository;

        [Import]
        private IClusterRepository _clusterRepository;

        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        [Import] private ICacheManager _cacheManager;

        protected override Site AddEntity(Site entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                _addressRepository.SaveAddress(entity, sessionData, saveParams);

                var mgr = new SitePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.SiteUid, entity, saveParams);
                    SaveRoleMappings(sessionData, entity.SiteUid, entity, saveParams);

                    var result = GetEntityByGuidId(entity.SiteUid, sessionData, new GetParametersWithPhoto()
                    {
                        RefreshCache = true,
                        IncludeMemberCollections = true,
                        IncludePhoto = true
                    });
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        UpdateEntityCount(entity.EntityId);

                        //  Update selection items cache data
                        UpdateCache(result);
                    }
                    return result;
                }
                return entity;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::AddEntity", ex);
                throw;
            }
        }

        // Replaced when permission level was added
        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllSiteEntityMapsForSite(sessionData, getParameters);
            var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
            var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

            foreach (var existingEntityId in existingEntityIds)
            {
                if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
                {
                    var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
                    if (deleteThisExistingEntityMap != null)
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.SiteEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new SiteEntityMap();
                    entityMap.SiteEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.SiteUid = uid;
                    entityMap.EntityId = entityId;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }
        protected override Site UpdateEntity(Site entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.gcsBinaryResource?.HasBeenModified == true)
                    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                _addressRepository.SaveAddress(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.SiteUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true, IncludePhoto = true });
                var mgr = new SitePDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.SiteUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;
                    // if RegionUid is = Guid.Empty or null, then use the value from the original record
                    if (entity.RegionUid == null || entity.RegionUid == Guid.Empty)
                        entity.RegionUid = mgr.Entity.RegionUid;

                    // if SiteId is null or empty, then use the value from the original record
                    if (string.IsNullOrEmpty(entity.SiteId))
                        entity.SiteId = mgr.Entity.SiteId;

                    if (entity.BinaryResourceUid == null || entity.BinaryResourceUid == Guid.Empty)
                        entity.BinaryResourceUid = mgr.Entity.BinaryResourceUid;
                    if (entity.AddressUid == null || entity.AddressUid == Guid.Empty)
                        entity.AddressUid = mgr.Entity.AddressUid;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.SiteUid, entity, saveParams);
                        SaveRoleMappings(sessionData, entity.SiteUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.SiteUid, sessionData, new GetParametersWithPhoto()
                        {
                            RefreshCache = true,
                            IncludeMemberCollections = true,
                            IncludePhoto = true
                        });
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);
                        
                        //  Update selection items cache data
                        UpdateCache(updatedEntity);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.SiteUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::UpdateEntity", ex);
                throw;
            }
        }
        private void SaveRoleMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasRoleMappingList entity, ISaveParameters saveParams)
        {
            if (entity.RoleIds == null || !entity.RoleIds.Any() || saveParams.Ignore(nameof(entity.RoleIds)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingRoleSites = _roleSiteRepository.GetAllForSiteUid(sessionData, getParameters);
            var existingRoleIds = new HashSet<Guid>(existingRoleSites.Select(e => e.RoleId));
            var deleteRoleIds = existingRoleIds.Except(entity.RoleIds);

            foreach (var rid in deleteRoleIds)
            {
                var rc = existingRoleSites.FirstOrDefault(o => o.RoleId == rid);
                if (rc != null)
                    _roleSiteRepository.Remove(rc.RoleSiteUid, sessionData);
            }

            foreach (var roleId in entity.RoleIds)
            {
                if (!existingRoleIds.Contains(roleId))
                {
                    var roleSite = new RoleSite
                    {
                        RoleSiteUid = GuidUtilities.GenerateComb(),
                        SiteUid = uid,
                        RoleId = roleId,
                        IncludeAllClusters = true
                    };
                    UpdateTableEntityBaseProperties(roleSite, sessionData);

                    _roleSiteRepository.Add(roleSite, sessionData, saveParams);
                }
            }
        }


        protected override int DeleteEntity(Site entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new SitePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.SiteUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                    UpdateEntityCount(entity.EntityId);

                    if (_cacheManager?.IsInitialized == true)
                    {
                        var cacheKey = GetItemCacheKey(entity.SiteUid);
                        var deleted = _cacheManager.DeleteCachedItem(cacheKey);
                    }

                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new SitePDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id); // must read the original record from the database so the PDSA object can detect changes
                if (rowsLoaded == 1 && originalEntity != null)
                {
                    rowsDeleted = mgr.DataObject.DeleteByPK(id);
                    if (rowsDeleted > 0)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Delete, sessionData, originalEntity, null, mgr.DataObject.AuditRowAsXml);
                        if (_cacheManager?.IsInitialized == true)
                        {
                            var cacheKey = GetItemCacheKey(id);
                            var deleted = _cacheManager.DeleteCachedItem(cacheKey);
                        }
                        UpdateEntityCount(originalEntity.EntityId);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::Remove", ex);
                throw;
            }
        }

        // GetAllSites in a region
        protected override IEnumerable<Site> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new SitePDSAManager();
                mgr.DataObject.SelectFilter = SitePDSAData.SelectFilters.ByRegionUid;
                mgr.DataObject.Entity.RegionUid = getParameters.UniqueId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (Site entity in entities)
                    {
                        FillMemberCollections(entity, sessionData, getParameters);
                    }
                    return entities;
                }
                return null;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<Site> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new SitePDSAManager();
                mgr.DataObject.SelectFilter = SitePDSAData.SelectFilters.All;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (Site entity in entities)
                    {
                        FillMemberCollections(entity, sessionData, getParameters);
                    }
                    return entities;
                }
                return null;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<Site> GetAllSitesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new SitePDSAManager();
                mgr.DataObject.SelectFilter = SitePDSAData.SelectFilters.ByEntityId;

                if (getParameters.CurrentEntityId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.CurrentEntityId;
                else if (getParameters.UniqueId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.UniqueId;
                else
                    mgr.DataObject.Entity.EntityId = sessionData.CurrentEntityId;

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (Site entity in entities)
                    {
                        FillMemberCollections(entity, sessionData, getParameters);
                    }
                    return entities;
                }
                return null;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::GetEntities", ex);
                throw;
            }
        }

        private string GetItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(Site), uid, false);
        }

        private string GetSiteSelectionItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(SiteSelectionItemBasic), uid, true);
        }

        //public IEnumerable<SiteSelectionItemBasic> GetAllSiteSelectionItemsForEntityAndRegion(IApplicationUserSessionDataHeader sessionData,
        //    IGetParametersWithPhoto parameters)
        //{
        //    try
        //    {
        //        var mgr = new Site_SelectionListForEntityAndRegionPDSAManager();
        //        mgr.Entity.EntityId = parameters.CurrentEntityId;
        //        mgr.Entity.RegionUid = parameters.UniqueId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = new List<SiteSelectionItemBasic>();
        //            foreach (var entity in pdsaEntities)
        //            {
        //                var newEntity = new SiteSelectionItemBasic();
        //                SimpleMapper.PropertyMap(entity, newEntity);
        //                if (parameters.IncludeMemberCollections || parameters.IncludePhoto)
        //                    FillMemberCollections(newEntity, sessionData, parameters);
        //                if (parameters.IncludePhoto == false && newEntity.Photo != null)
        //                    newEntity.Photo = null;
        //                entities.Add(newEntity);
        //            }
        //            return entities;
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::GetAllSiteSelectionItemsForEntityAndRegion", ex);
        //        throw;
        //    }
        //}
        public IEnumerable<SiteSelectionItemBasic> GetAllSiteSelectionItemsForEntityAndRegion(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                List<SiteSelectionItemBasic> entities = null;
                var cacheKey = GetSiteSelectionItemCacheKey(getParameters.UniqueId);
                if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters))
                {
                    entities = _cacheManager.GetCachedItem<List<SiteSelectionItemBasic>>(cacheKey);
                    if (entities == null) // if no cached item is found, set RefreshCache = true to force writing to cache
                        getParameters.RefreshCache = true;
                }

                if (entities == null || !entities.Any())
                {
                    entities = new List<SiteSelectionItemBasic>();
                    var mgr = new Site_SelectionListForEntityAndRegionPDSAManager
                    {
                        Entity =
                        {
                            EntityId = getParameters.CurrentEntityId,
                            RegionUid = getParameters.UniqueId
                        }
                    };
                    var pdsaEntities = mgr.BuildCollection();
                    if (pdsaEntities != null)
                    {
                        foreach (var entity in pdsaEntities)
                        {
                            var newEntity = new SiteSelectionItemBasic();
                            SimpleMapper.PropertyMap(entity, newEntity);
                            entities.Add(newEntity);
                        }

                        if (CacheHelpers.ShouldCacheBeUpdated(_cacheManager, getParameters))
                        {
                            var bCached = _cacheManager.SetCachedItem(cacheKey, entities);
                        }
                    }
                }

                if (entities != null)
                {
                    foreach (var entity in entities)
                    {
                        if (getParameters.IncludeMemberCollections || getParameters.IncludePhoto)
                            FillMemberCollections(entity, sessionData, getParameters);
                        if (getParameters.IncludePhoto == false && entity.Photo != null)
                            entity.Photo = null;
                    }
                }
                return entities;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //SiteRepository::GetAllSiteSelectionItemsForEntityAndRegion", ex);
                throw;
            }
        }


        protected override Site GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        private bool UpdateCache(Site updatedItem)
        {
            if (_cacheManager?.IsInitialized == true)
            {
                var cacheKey = GetSiteSelectionItemCacheKey(updatedItem.RegionUid);

                var items = _cacheManager.GetCachedItem<List<SiteSelectionItemBasic>>(cacheKey);
                if (items == null)
                    items = new List<SiteSelectionItemBasic>();

                var item = items.FirstOrDefault(o => o.SiteUid == updatedItem.SiteUid);
                if (item != null)
                    item.UpdateFromSite(updatedItem);
                else
                {
                    items.Add(new SiteSelectionItemBasic(updatedItem));
                }
                return _cacheManager.SetCachedItem(cacheKey, items);
            }

            return false;
        }

        //protected override Site GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        var mgr = new SitePDSAManager();
        //        var count = mgr.DataObject.LoadByPK(guid);

        //        if (count == 1)
        //        {
        //            Site result = new Site();
        //            SimpleMapper.PropertyMap(mgr.Entity, result);
        //            FillMemberCollections(result, sessionData, getParameters);
        //            return result;
        //        }
        //        return null;
        //    }
        //    catch (PDSAValidationException ex)
        //    {
        //        DataValidationException dve = Converters.ConvertToDataValidationException(ex);
        //        throw dve;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::GetEntityByGuidId", ex);
        //        throw;
        //    }
        //}

        protected override Site GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                Site result = null;
                var cacheKey = GetItemCacheKey(guid);
                if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters))
                {
                    result = _cacheManager.GetCachedItem<Site>(cacheKey);
                }

                if (result == null)
                {
                    var mgr = new SitePDSAManager();
                    var count = mgr.DataObject.LoadByPK(guid);

                    if (count == 1)
                    {
                        result = new Site();
                        SimpleMapper.PropertyMap(mgr.Entity, result);
                        if (CacheHelpers.ShouldCacheBeUpdated(_cacheManager, getParameters))
                        {
                            var bCached = _cacheManager.SetCachedItem(cacheKey, result);
                        }
                    }
                }

                if (result != null && result.SiteUid == guid)
                {
                    FillMemberCollections(result, sessionData, getParameters);
                }
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, Site originalEntity, Site newEntity, string auditXml)
        {
            try
            {
                if (!string.IsNullOrEmpty(auditXml))
                    auditXml = auditXml.EncodeForXml();
                var mgr = new gcsAudit_InsertPDSAManager();

                switch (operationType)
                {
                    case OperationType.Update:
                        if (newEntity == null)
                            throw new ArgumentNullException("newEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        List<String> propertiesToIgnore = new List<string>();
                        propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "SiteUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.SiteUid;
                        mgr.Entity.RecordTag = newEntity.SiteName;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;

                        if (string.IsNullOrEmpty(auditXml) == false)
                        {
                            mgr.Entity.AuditXml = auditXml;
                            mgr.Execute();
                        }


                        mgr.Entity.AuditXml = null;

                        SimpleObjectDifferenceDetector.CompareResults differences = SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity, propertiesToIgnore);
                        foreach (var property in differences.PropertyChanges)
                        {
                            //System.Diagnostics.Trace.WriteLine(property.ToString());
                            mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                            mgr.Entity.ColumnName = property.Value.PropertyName;
                            if (property.Value.PropertyType == typeof(System.Byte[]))
                            {
                                mgr.Entity.OriginalValue = null;
                                mgr.Entity.NewValue = null;
                                mgr.Entity.OriginalBinaryValue = property.Value.OriginalValue as byte[];
                                mgr.Entity.NewBinaryValue = property.Value.NewValue as byte[];
                            }
                            else
                            {
                                mgr.Entity.OriginalValue = property.Value.OriginalValue?.ToString();
                                mgr.Entity.NewValue = property.Value.NewValue.ToString();
                                mgr.Entity.OriginalBinaryValue = null;
                                mgr.Entity.NewBinaryValue = null;
                            }
                            mgr.Execute();
                        }
                        break;

                    case OperationType.Insert:
                        if (newEntity == null)
                            throw new ArgumentNullException("newEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "SiteUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.SiteUid;
                        mgr.Entity.RecordTag = newEntity.SiteName; mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "SiteUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.SiteUid;
                        mgr.Entity.RecordTag = originalEntity.SiteName; mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//SiteRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(Site entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty && getParameters.IncludePhoto)
            {
                entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, getParameters);
            }

            if (entity.AddressUid.HasValue && entity.AddressUid.Value != Guid.Empty)
            {
                entity.Address = _addressRepository.Get(entity.AddressUid.Value, sessionData, new GetParametersWithPhoto()
                {
                    UniqueId = entity.RegionUid,
                    IncludePhoto = false,
                    IncludeMemberCollections = true
                });
            }

            entity.Region = _regionRepository.Get(entity.RegionUid, sessionData, new GetParametersWithPhoto() { UniqueId = entity.RegionUid, IncludePhoto = false });

            var entityMaps = _entityMapRepository.GetAllSiteEntityMapsForSite(sessionData, new GetParametersWithPhoto() { UniqueId = entity.SiteUid });
            var entityIds = (from e in entityMaps select e.EntityId).ToList();
            entity.EntityIds.AddRange(entityIds);

            entity.EntityIds.Add(entity.Region.EntityId);


            if (!getParameters.IsExcluded(nameof(entity.RoleIds)))
            {
                var roleFilters = _roleSiteRepository.GetAllForSiteUid(sessionData,
                    new GetParametersWithPhoto() { UniqueId = entity.SiteUid });
                var roleIds = (from e in roleFilters select e.RoleId).ToList();
                entity.RoleIds.AddRange(roleIds);
            }

            //entity.Clusters = _clusterRepository.GetAllClustersForSite(sessionData, new GetParametersWithPhoto() { UniqueId = entity.SiteUid }).ToCollection();

        }

        protected void FillMemberCollections(SiteSelectionItemBasic entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (entity.Photo != null && entity.Photo.Length > 0 && getParameters.IncludePhoto && getParameters.PhotoPixelWidth > 0)
            {
                var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                    GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.Photo), getParameters.PhotoPixelWidth);
                entity.Photo = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
            }
            if (getParameters.IncludePhoto == false && entity.Photo != null)
                entity.Photo = null;

            if (getParameters.IncludeMemberCollections && !getParameters.IsExcluded(nameof(entity.Clusters)))
            {
                var clusterRepository = _dataRepositoryFactory.GetDataRepository<IClusterRepository>();
                getParameters.CurrentSiteUid = entity.SiteUid;
                //                entity.Clusters = clusterRepository.GetAllClusterSelectionItemsForEntityAndSite(sessionData, getParameters).ToCollection();
                entity.Clusters = clusterRepository.GetAllClusterSelectionItemsForSite(sessionData, getParameters).Items.ToCollection();
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("Site", "SiteUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("Site", "SiteUid", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(Site site)
        {
            var mgr = new IsSiteUniquePDSAManager();
            mgr.Entity.SiteUid = site.SiteUid;
            mgr.Entity.SiteName = site.SiteName;
            mgr.Entity.SiteId = site.SiteId;
            mgr.Entity.RegionUid = site.RegionUid;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("Site", "SiteUid", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid id)
        {
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("Site", "SiteUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertSiteCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new Site_GetAllUidsFromRoleIdPDSAManager();
            mgr.Entity.RoleId = roleId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.SiteUid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndRegionUid(Guid roleId, Guid regionUid)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new Site_GetAllUidsFromRoleIdAndRegionUidPDSAManager();
            mgr.Entity.RoleId = roleId;
            mgr.Entity.RegionUid = regionUid;
            var results = mgr.BuildCollection();
            return results.Select(o => o.SiteUid);
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForSitePDSAManager
            {
                Entity =
                {
                    uid = uid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId;
            return Guid.Empty;
        }

    }
}
