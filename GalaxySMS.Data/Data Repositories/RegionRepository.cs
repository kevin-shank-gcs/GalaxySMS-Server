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
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using GCS.Framework.Caching;

namespace GalaxySMS.Data
{
    [Export(typeof(IRegionRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RegionRepository : DataRepositoryBase<Region>, IRegionRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;

        [Import] private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import] private IRegionEntityMapRepository _entityMapRepository;

        [Import] private IRoleRegionRepository _roleRegionRepository;

        [Import] private ICacheManager _cacheManager;

        protected override Region AddEntity(Region entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (saveParams.SavePhoto)
                    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                RegionPDSAManager mgr = new RegionPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.RegionUid, entity, saveParams);
                    SaveRoleMappings(sessionData, entity.RegionUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.RegionUid, sessionData,
                        new GetParametersWithPhoto()
                        {
                            //ReadFromCache = false,
                            RefreshCache = true,
                            IncludeMemberCollections = true,
                            IncludePhoto = true
                        });
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);

                        UpdateEntityCount(result.EntityId);

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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::AddEntity", ex);
                throw;
            }
        }

        protected override Region UpdateEntity(Region entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.gcsBinaryResource?.HasBeenModified == true && saveParams.SavePhoto)
                    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var getParams = new GetParametersWithPhoto()
                { IncludeMemberCollections = true, IncludePhoto = true };

                var originalEntity = GetEntityByGuidId(entity.RegionUid, sessionData, getParams);
                var mgr = new RegionPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.RegionUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;
                    if (entity.BinaryResourceUid == null || entity.BinaryResourceUid == Guid.Empty)
                        entity.BinaryResourceUid = mgr.Entity.BinaryResourceUid;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.RegionUid, entity, saveParams);
                        SaveRoleMappings(sessionData, entity.RegionUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        //getParams.ReadFromCache = false;
                        getParams.RefreshCache = true;

                        var updatedEntity = GetEntityByGuidId(entity.RegionUid, sessionData, getParams);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);

                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);

                        //  Update selection items cache data
                        UpdateCache(updatedEntity);
                        return updatedEntity;
                    }

                    return entity;
                }

                throw new Exception($"Region not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void SaveRoleMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasRoleMappingList entity, ISaveParameters saveParams)
        {
            if (entity.RoleIds == null || !entity.RoleIds.Any() || saveParams.Ignore(nameof(entity.RoleIds)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingRoleRegions = _roleRegionRepository.GetAllForRegionUid(sessionData, getParameters);
            var existingRoleIds = new HashSet<Guid>(existingRoleRegions.Select(e => e.RoleId));
            var deleteRoleIds = existingRoleIds.Except(entity.RoleIds);

            foreach (var rid in deleteRoleIds)
            {
                var rc = existingRoleRegions.FirstOrDefault(o => o.RoleId == rid);
                if (rc != null)
                    _roleRegionRepository.Remove(rc.RoleRegionUid, sessionData);
            }

            foreach (var roleId in entity.RoleIds)
            {
                if (!existingRoleIds.Contains(roleId))
                {
                    var roleRegion = new RoleRegion
                    {
                        RoleRegionUid = GuidUtilities.GenerateComb(),
                        RegionUid = uid,
                        RoleId = roleId,
                        IncludeAllSites = true,
                        IncludeAllClusters = true,
                        IncludeAllAccessPortals = true,
                        IncludeAllInputDevices = true,
                        IncludeAllOutputDevices = true,
                        IncludeAllInputOutputGroups = true
                    };
                    UpdateTableEntityBaseProperties(roleRegion, sessionData);

                    _roleRegionRepository.Add(roleRegion, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(Region entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                RegionPDSAManager mgr = new RegionPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.RegionUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);

                    UpdateEntityCount(entity.EntityId);

                    if (_cacheManager?.IsInitialized == true)
                    {
                        var cacheKey = GetItemCacheKey(entity.RegionUid);
                        var deleted = _cacheManager.DeleteCachedItem(cacheKey);
                    }

                }

                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData,
                    new GetParametersWithPhoto() { IncludeMemberCollections = false });
                RegionPDSAManager mgr = new RegionPDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded =
                    mgr.DataObject
                        .LoadByPK(id); // must read the original record from the database so the PDSA object can detect changes
                if (rowsLoaded == 1 && originalEntity != null)
                {
                    rowsDeleted = mgr.DataObject.DeleteByPK(id);
                    if (rowsDeleted > 0)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Delete, sessionData, originalEntity, null,
                            mgr.DataObject.AuditRowAsXml);

                        UpdateEntityCount(originalEntity.EntityId);
                        if (_cacheManager?.IsInitialized == true)
                        {
                            var cacheKey = GetItemCacheKey(id);
                            var deleted = _cacheManager.DeleteCachedItem(cacheKey);
                        }
                    }
                }

                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<Region> GetEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                RegionPDSAManager mgr = new RegionPDSAManager();
                mgr.DataObject.SelectFilter = RegionPDSAData.SelectFilters.ByEntityId;
                mgr.DataObject.Entity.EntityId = sessionData.CurrentEntityId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (Region entity in entities)
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<Region> GetAllEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                RegionPDSAManager mgr = new RegionPDSAManager();
                mgr.DataObject.SelectFilter = RegionPDSAData.SelectFilters.All;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (Region entity in entities)
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<Region> GetAllRegionsForEntity(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RegionPDSAManager();
                mgr.DataObject.SelectFilter = RegionPDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.UniqueId;
                else
                    mgr.DataObject.Entity.EntityId = sessionData.CurrentEntityId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (var entity in entities)
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::GetAllRegionsForEntity", ex);
                throw;
            }
        }

        //public IEnumerable<RegionSelectionItemBasic> GetAllRegionSelectionItemsForEntity(
        //    IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        var mgr = new Region_SelectionListForEntityPDSAManager();
        //        if (getParameters.UniqueId != Guid.Empty)
        //            getParameters.CurrentEntityId = getParameters.UniqueId;
        //        if (getParameters.CurrentEntityId == Guid.Empty)
        //            getParameters.CurrentEntityId = sessionData.CurrentEntityId;

        //        mgr.Entity.EntityId = getParameters.CurrentEntityId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = new List<RegionSelectionItemBasic>();
        //            foreach (var entity in pdsaEntities)
        //            {
        //                var newEntity = new RegionSelectionItemBasic();
        //                if (getParameters.IncludePhoto == false && entity.BinaryResource != null)
        //                    entity.BinaryResource = null;

        //                SimpleMapper.PropertyMap(entity, newEntity);
        //                if (getParameters.IncludeMemberCollections)
        //                    FillMemberCollections(newEntity, sessionData, getParameters);
        //                entities.Add(newEntity);
        //            }

        //            return entities;
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error(
        //            $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::GetAllRegionSelectionItemsForEntity", ex);
        //        throw;
        //    }
        //}
        private string GetItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(Region), uid, false);
        }

        private string GetItemsCacheKey(Guid uid, string suffix)
        {
            return CacheHelpers.GetCacheKey(typeof(RegionSelectionItemBasic), uid, true, suffix);
        }

        public IEnumerable<RegionSelectionItemBasic> GetAllRegionSelectionItemsForEntity(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                if (getParameters.UniqueId != Guid.Empty)
                    getParameters.CurrentEntityId = getParameters.UniqueId;
                if (getParameters.CurrentEntityId == Guid.Empty)
                    getParameters.CurrentEntityId = sessionData.CurrentEntityId;

                List<RegionSelectionItemBasic> entities = null;
                var cacheKey = GetItemsCacheKey(getParameters.CurrentEntityId, string.Empty);
                if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters))
                {
                    entities = _cacheManager.GetCachedItem<List<RegionSelectionItemBasic>>(cacheKey);
                    if (entities == null)   // if no cached item is found, set RefreshCache = true to force writing to cache
                        getParameters.RefreshCache = true;
                }

                if (entities == null || !entities.Any())
                {
                    entities = new List<RegionSelectionItemBasic>();
                    var mgr = new Region_SelectionListForEntityPDSAManager
                    {
                        Entity =
                        {
                            EntityId = getParameters.CurrentEntityId
                        }
                    };

                    var pdsaEntities = mgr.BuildCollection();
                    if (pdsaEntities != null)
                    {
                        foreach (var entity in pdsaEntities)
                        {
                            var newEntity = new RegionSelectionItemBasic();
                            if (getParameters.IncludePhoto == false && entity.BinaryResource != null)
                                entity.BinaryResource = null;

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
                        if (getParameters.IncludeMemberCollections)
                            FillMemberCollections(entity, sessionData, getParameters);
                    }
                }

                return entities;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::GetAllRegionSelectionItemsForEntity", ex);
                throw;
            }
        }


        private bool UpdateCache(Region updatedItem)
        {
            if (_cacheManager?.IsInitialized == true)
            {
                var cacheKey = GetItemsCacheKey(updatedItem.EntityId, string.Empty);

                var items = _cacheManager.GetCachedItem<List<RegionSelectionItemBasic>>(cacheKey);
                if (items == null)
                    items = new List<RegionSelectionItemBasic>();

                var item = items.FirstOrDefault(o => o.RegionUid == updatedItem.RegionUid);
                if (item != null)
                    item.UpdateFromRegion(updatedItem);
                else
                {
                    items.Add(new RegionSelectionItemBasic(updatedItem));
                }
                return _cacheManager.SetCachedItem(cacheKey, items);
            }

            return false;
        }

        protected override Region GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        //protected override Region GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData,
        //    IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        RegionPDSAManager mgr = new RegionPDSAManager();
        //        var count = mgr.DataObject.LoadByPK(guid);

        //        if (count == 1)
        //        {
        //            Region result = new Region();
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
        //        this.Log().Error(
        //            $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::GetEntityByGuidId", ex);
        //        throw;
        //    }
        //}
        protected override Region GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                Region result = null;
                var cacheKey = GetItemCacheKey(guid);
                if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters))
                {
                    result = _cacheManager.GetCachedItem<Region>(cacheKey);
                }

                if (result == null)
                {
                    RegionPDSAManager mgr = new RegionPDSAManager();
                    var count = mgr.DataObject.LoadByPK(guid);

                    if (count == 1)
                    {
                        result = new Region();
                        SimpleMapper.PropertyMap(mgr.Entity, result);

                        if (CacheHelpers.ShouldCacheBeUpdated(_cacheManager, getParameters))
                        {
                            var bCached = _cacheManager.SetCachedItem(cacheKey, result);
                        }
                    }
                }

                if (result != null && result.RegionUid == guid)
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType,
            IApplicationUserSessionDataHeader sessionData, Region originalEntity, Region newEntity, string auditXml)
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
                            throw new ArgumentNullException("newEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase
                                    .GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase
                                    .GetCurrentMethod()));

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
                        mgr.Entity.PrimaryKeyColumn = "RegionUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RegionUid;
                        mgr.Entity.RecordTag = newEntity.RegionName;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;

                        if (string.IsNullOrEmpty(auditXml) == false)
                        {
                            mgr.Entity.AuditXml = auditXml;
                            mgr.Execute();
                        }


                        mgr.Entity.AuditXml = null;

                        SimpleObjectDifferenceDetector.CompareResults differences =
                            SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity,
                                propertiesToIgnore);
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
                            throw new ArgumentNullException("newEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase
                                    .GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "RegionUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RegionUid;
                        mgr.Entity.RecordTag = newEntity.RegionName;
                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase
                                    .GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "RegionUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.RegionUid;
                        mgr.Entity.RecordTag = originalEntity.RegionName;
                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {
                // log the exception and swallow the exception. Do not re-throw
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //RegionRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(Region entity, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty &&
                getParameters.IncludePhoto)
            {
                entity.gcsBinaryResource =
                    _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, getParameters);
            }

            if (getParameters.IncludeMemberCollections)
            {
                var entityMaps = _entityMapRepository.GetAllRegionEntityMapsForRegion(sessionData,
                    new GetParametersWithPhoto() { UniqueId = entity.RegionUid });
                var entityIds = (from e in entityMaps select e.EntityId).ToList();
                entity.EntityIds.AddRange(entityIds);

                entity.EntityIds.Add(entity.EntityId);

                foreach (var e in entityMaps)
                {
                    entity.MappedEntitiesPermissionLevels.Add(new EntityIdEntityMapPermissionLevel()
                    {
                        EntityId = e.EntityId,
                        EntityMapPermissionLevelUid = e.EntityMapPermissionLevelUid
                    });
                }

                if (!getParameters.IsExcluded(nameof(entity.RoleIds)))
                {
                    var roleFilters = _roleRegionRepository.GetAllForRegionUid(sessionData,
                        new GetParametersWithPhoto() { UniqueId = entity.RegionUid });
                    var roleIds = (from e in roleFilters select e.RoleId).ToList();
                    entity.RoleIds.AddRange(roleIds);
                }
            }
        }

        protected void FillMemberCollections(RegionSelectionItemBasic entity,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (entity.Photo != null && entity.Photo.Length > 0 && getParameters.IncludePhoto &&
                getParameters.PhotoPixelWidth > 0)
            {
                var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                    GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.Photo),
                    getParameters.PhotoPixelWidth);
                entity.Photo = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
            }

            if (getParameters.IncludeMemberCollections && !getParameters.IsExcluded(nameof(entity.Sites)))
            {
                var siteRepository = _dataRepositoryFactory.GetDataRepository<ISiteRepository>();
                var getSitesParams = new GetParametersWithPhoto(getParameters)
                {
                    UniqueId = entity.RegionUid
                };
                entity.Sites = siteRepository.GetAllSiteSelectionItemsForEntityAndRegion(sessionData, getSitesParams)
                    .ToCollection();
            }
        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid,
            IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings =
                _entityMapRepository.GetAllRegionEntityMapsForRegion(sessionData, getParameters);
            var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
            var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);
            foreach (var existingEntityId in existingEntityIds)
            {
                if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
                {
                    var deleteThisExistingEntityMap =
                        (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem)
                        .FirstOrDefault();
                    if (deleteThisExistingEntityMap != null)
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.RegionEntityMapUid, sessionData);
                }
            }

            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new RegionEntityMap();
                    entityMap.RegionEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.RegionUid = uid;
                    entityMap.EntityId = entityId;
                    //var mappedData = entity.MappedEntitiesPermissionLevels.Where(m => m.EntityId == entityId).FirstOrDefault();
                    //if (mappedData != null)
                    //    entityMap.EntityMapPermissionLevelUid = mappedData.EntityMapPermissionLevelUid;
                    //else
                    //    entityMap.EntityMapPermissionLevelUid = GalaxySMS.Common.Constants.EntityPermissionLevelIds.PermissionLevel_None_Id;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        //private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity)
        //{
        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingEntityMappings = _entityMapRepository.GetAllRegionEntityMapsForRegion(sessionData, getParameters);
        //    var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
        //    var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

        //    foreach (var currentEntityMap in entity.MappedEntitiesPermissionLevels)
        //    {
        //        var existingMap = existingEntityMappings.Where(m => m.EntityId == currentEntityMap.EntityId).FirstOrDefault();
        //        if (existingMap == null)
        //        {
        //            // Add a new one
        //            var entityMap = new RegionEntityMap();
        //            entityMap.RegionEntityMapUid = GuidUtilities.GenerateComb();
        //            entityMap.RegionUid = uid;
        //            entityMap.EntityId = currentEntityMap.EntityId;
        //            if (currentEntityMap.EntityMapPermissionLevelUid == Guid.Empty)
        //                currentEntityMap.EntityMapPermissionLevelUid =
        //                    GalaxySMS.Common.Constants.EntityPermissionLevelIds.PermissionLevel_None_Id;
        //            entityMap.EntityMapPermissionLevelUid = currentEntityMap.EntityMapPermissionLevelUid;
        //            entityMap.UpdateDate = DateTimeOffset.Now;
        //            entityMap.UpdateName = sessionData.UserName;
        //            entityMap.InsertDate = DateTimeOffset.Now;
        //            entityMap.InsertName = sessionData.UserName;

        //            _entityMapRepository.Add(entityMap, sessionData, null);
        //        }
        //        else
        //        {
        //            if (existingMap.EntityMapPermissionLevelUid != currentEntityMap.EntityMapPermissionLevelUid)
        //            {
        //                if (currentEntityMap.EntityMapPermissionLevelUid == Guid.Empty)
        //                    currentEntityMap.EntityMapPermissionLevelUid =
        //                        GalaxySMS.Common.Constants.EntityPermissionLevelIds.PermissionLevel_None_Id;
        //                existingMap.EntityMapPermissionLevelUid = currentEntityMap.EntityMapPermissionLevelUid;
        //                existingMap.UpdateDate = DateTimeOffset.Now;
        //                existingMap.UpdateName = sessionData.UserName;
        //                _entityMapRepository.Update(existingMap, sessionData, null);
        //            }
        //        }
        //    }
        //}

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("Region", "RegionUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("Region", "RegionUid", id);
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

        protected override bool IsEntityUnique(Region role)
        {
            IsRegionUniquePDSAManager mgr = new IsRegionUniquePDSAManager();
            mgr.Entity.RegionUid = role.RegionUid;
            mgr.Entity.RegionName = role.RegionName;
            mgr.Entity.RegionId = role.RegionId;
            mgr.Entity.EntityId = role.EntityId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("Region", "RegionUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("Region", "RegionUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new Region_GetAllUidsFromRoleIdPDSAManager();
            mgr.Entity.RoleId = roleId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.RegionUid);

        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertRegionCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }
        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForRegionPDSAManager
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