using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Data;
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
using GCS.Core.Common.Shared.Utils;
using GCS.Framework.Caching;

namespace GalaxySMS.Data
{
    [Export(typeof(IRoleFiltersRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RoleFiltersRepository : DataRepositoryBase<RoleFilters>, IRoleFiltersRepository
    {
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private ICacheManager _cacheManager;

        protected override RoleFilters AddEntity(RoleFilters entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                RoleFiltersPDSAManager mgr = new RoleFiltersPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.RoleId, sessionData, null);
                    if (result != null)
                    {
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleFiltersRepository::AddEntity", ex);
                throw;
            }
        }

        protected override RoleFilters UpdateEntity(RoleFilters entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.RoleId, sessionData, null);
                RoleFiltersPDSAManager mgr = new RoleFiltersPDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.RoleId) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.RoleId, sessionData, new GetParametersWithPhoto()
                        {
                            RefreshCache = true,
                            IncludeMemberCollections = true
                        });
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.RoleId} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleFiltersRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void EnsureChildRecordsExist(RoleFilters entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //if (!saveParams.Ignore(nameof(entity.Clusters)) && entity.Clusters != null)
            //    SaveClusterFilters(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.Regions)) && entity.Regions != null)
                SaveRegionFilters(entity, sessionData, saveParams);
        }

        //private void SaveClusterFilters(RoleFilters entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    //            if (entity.PersonClusterPermissions == null || !entity.PersonClusterPermissions.Any() || saveParams.Ignore(nameof(entity.PersonClusterPermissions)))
        //    if (entity.Clusters == null || saveParams.Ignore(nameof(entity.Clusters)))
        //        return;

        //    // Don't support this capability
        //    //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveRoleFiltersOption).ToString());

        //    //bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
        //    //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
        //    //                           kvpSaveOption.Value == SaveRoleFiltersOption.DeleteMissingItems.ToString();

        //    var roleClusterRepository = _dataRepositoryFactory.GetDataRepository<IRoleClusterRepository>();
        //    var clusterRepository = _dataRepositoryFactory.GetDataRepository<IClusterRepository>();
        //    var clusterUids = clusterRepository.GetAllPrimaryKeyUidsFromRoleId(entity.RoleId);

        //    var existingClusters = roleClusterRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId, IncludeMemberCollections = true }).ToList();
        //    var addTheseClusters = entity.Clusters.Where(o => existingClusters.All(o2 => o2.ClusterUid != o.ClusterUid)).ToList();
        //    var updateTheseClusters = entity.Clusters.Where(o => existingClusters.All(o2 => o2.ClusterUid == o.ClusterUid));

        //    if (entity.IncludeAllClusters)
        //    {
        //        foreach (var clusterUid in clusterUids)
        //        {
        //            var existingRc = existingClusters.FirstOrDefault(o => o.ClusterUid == clusterUid);
        //            if (existingRc == null)
        //            {
        //                var existingAddRc = addTheseClusters.FirstOrDefault(o => o.ClusterUid == clusterUid);
        //                if (existingAddRc == null)
        //                {
        //                    addTheseClusters.Add(new RoleCluster()
        //                    {
        //                        ClusterUid = clusterUid,
        //                        IncludeAllAccessPortals = true,
        //                        IncludeAllInputDevices = true,
        //                        IncludeAllInputOutputGroups = true,
        //                        IncludeAllOutputDevices = true
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    var propsToInclude = new List<string>();

        //    var propsToIgnore = new List<string>
        //    {
        //        nameof(RoleCluster.IsDirty),
        //        nameof(RoleCluster.IsAnythingDirty),
        //        nameof(RoleCluster.IsPanelDataDirty)
        //    };

        //    var dirtyRoleClusters = new List<RoleCluster>();
        //    foreach (var rc in updateTheseClusters)
        //    {
        //        // Grab the existing item and see if any properties are different. If so, update the record
        //        var existingItem = existingClusters.FirstOrDefault(o => o.ClusterUid == rc.ClusterUid);
        //        if (existingItem == null)
        //            continue;

        //        if (rc.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(rc, existingItem, propsToInclude, propsToIgnore))
        //        {
        //            dirtyRoleClusters.Add(rc);
        //        }
        //    }

        //    // spin through all the dirty role cluster permissions
        //    foreach (var rc in dirtyRoleClusters)
        //    {
        //        rc.RoleId = entity.RoleId;

        //        UpdateTableEntityBaseProperties(rc, sessionData);
        //        roleClusterRepository.Update(rc, sessionData, null, saveParams);
        //    }

        //    // spin through all the new role cluster permissions
        //    foreach (var rc in addTheseClusters)
        //    {
        //        rc.RoleId = entity.RoleId;

        //        UpdateTableEntityBaseProperties(rc, sessionData);
        //        if (rc.RoleClusterUid == Guid.Empty)
        //        {
        //            rc.RoleClusterUid = GuidUtilities.GenerateComb();
        //            roleClusterRepository.Add(rc, sessionData, null, saveParams);
        //        }
        //    }

        //    // Delete existing role clusters that are not included in the incoming data set if IncludeAllClusters is false
        //    if (!entity.IncludeAllClusters)
        //    {
        //        var deleteTheseClusters = existingClusters.Where(c => entity.Clusters.All(c2 => c2.ClusterUid != c.ClusterUid)).ToList();
        //        foreach (var rc in deleteTheseClusters)
        //        {
        //            // must explicitly delete the credential first
        //            roleClusterRepository.Remove(rc.RoleClusterUid, sessionData);
        //        }
        //    }
        //}


        private void SaveRegionFilters(RoleFilters entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //            if (entity.PersonRegionPermissions == null || !entity.PersonRegionPermissions.Any() || saveParams.Ignore(nameof(entity.PersonRegionPermissions)))
            if (entity.Regions == null || saveParams.Ignore(nameof(entity.Regions)))
                return;

            // Don't support this capability
            //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveRoleFiltersOption).ToString());

            //bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
            //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
            //                           kvpSaveOption.Value == SaveRoleFiltersOption.DeleteMissingItems.ToString();

            var roleRegionRepository = _dataRepositoryFactory.GetDataRepository<IRoleRegionRepository>();
            var regionRepository = _dataRepositoryFactory.GetDataRepository<IRegionRepository>();
            var regionUids = regionRepository.GetAllPrimaryKeyUidsFromRoleId(entity.RoleId);

            var existingRegions = roleRegionRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId, IncludeMemberCollections = true, RefreshCache = true}).ToList();
            var addTheseRegions = entity.Regions.Where(o => existingRegions.All(o2 => o2.RegionUid != o.RegionUid)).ToList();
            var updateTheseRegions = entity.Regions.Where(o => existingRegions.All(o2 => o2.RegionUid == o.RegionUid)).ToList();

            if (entity.IncludeAllRegions)
            {
                foreach (var regionUid in regionUids)
                {
                    var existingRoleRegion = existingRegions.FirstOrDefault(o => o.RegionUid == regionUid);
                    if (existingRoleRegion == null)
                    {
                        var existingAddRoleRegion = addTheseRegions.FirstOrDefault(o => o.RegionUid == regionUid);
                        if (existingAddRoleRegion == null)
                        {
                            addTheseRegions.Add(new RoleRegion()
                            {
                                RegionUid = regionUid,
                                IncludeAllSites = entity.IncludeAllSites,
                                IncludeAllClusters = entity.IncludeAllClusters,
                                IncludeAllAccessPortals = entity.IncludeAllAccessPortals,
                                IncludeAllInputDevices = entity.IncludeAllInputDevices,
                                IncludeAllInputOutputGroups = entity.IncludeAllInputOutputGroups,
                                IncludeAllOutputDevices = entity.IncludeAllOutputDevices
                            });
                        }
                    }
                }
            }

            var propsToInclude = new List<string>();

            var propsToIgnore = new List<string>
            {
                nameof(RoleRegion.IsDirty),
                nameof(RoleRegion.IsAnythingDirty),
                nameof(RoleRegion.IsPanelDataDirty)
            };

            var dirtyRoleRegions = new List<RoleRegion>();
            foreach (var rr in updateTheseRegions)
            {
                // Grab the existing item and see if any properties are different. If so, update the record
                var existingItem = existingRegions.FirstOrDefault(o => o.RegionUid == rr.RegionUid);
                if (existingItem == null)
                    continue;
                UpdateTableEntityBasePropertiesFromExisting(rr, existingItem);
                rr.RoleRegionUid = existingItem.RoleRegionUid;
                //if (rr.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(rr, existingItem, propsToInclude, propsToIgnore))
                //{
                    dirtyRoleRegions.Add(rr);
                //}
            }

            // spin through all the dirty role cluster permissions
            foreach (var rr in dirtyRoleRegions)
            {
                rr.RoleId = entity.RoleId;

                UpdateTableEntityBaseProperties(rr, sessionData);
                roleRegionRepository.Update(rr, sessionData, saveParams);
            }

            // spin through all the new role cluster permissions
            foreach (var rr in addTheseRegions)
            {
                rr.RoleId = entity.RoleId;

                UpdateTableEntityBaseProperties(rr, sessionData);
                if (rr.RoleRegionUid == Guid.Empty)
                {
                    rr.RoleRegionUid = GuidUtilities.GenerateComb();
                    roleRegionRepository.Add(rr, sessionData, saveParams);
                }
            }

            // Delete existing role clusters that are not included in the incoming data set if IncludeAllRegions is false
            if (!entity.IncludeAllRegions)
            {
                var deleteTheseRegions = existingRegions.Where(c => entity.Regions.All(c2 => c2.RegionUid != c.RegionUid)).ToList();
                foreach (var rr in deleteTheseRegions)
                {
                    // must explicitly delete the credential first
                    roleRegionRepository.Remove(rr.RoleRegionUid, sessionData);
                }
            }
        }


        protected override int DeleteEntity(RoleFilters entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                RoleFiltersPDSAManager mgr = new RoleFiltersPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.RoleId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);

                    if (_cacheManager?.IsInitialized == true)
                    {
                        var cacheKey = GetItemCacheKey(entity.RoleId);
                        var deleted = _cacheManager.DeleteCachedItem(cacheKey);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleFiltersRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                RoleFiltersPDSAManager mgr = new RoleFiltersPDSAManager();

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
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleFiltersRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<RoleFilters> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                RoleFiltersPDSAManager mgr = new RoleFiltersPDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (RoleFilters entity in entities)
                    {
                        if (getParameters == null || getParameters.IncludeMemberCollections)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleFiltersRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<RoleFilters> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override RoleFilters GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        private string GetItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleFilters), uid, false);
        }

        private string GetRolePermissionsCacheKey(Guid uid, string prefix)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleFilters), uid, true, prefix);
        }

        //protected override RoleFilters GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //            RoleFiltersPDSAManager mgr = new RoleFiltersPDSAManager();
        //            var count = mgr.DataObject.LoadByPK(guid);

        //            if (count == 1)
        //            {
        //                RoleFilters result = new RoleFilters();
        //                SimpleMapper.PropertyMap(mgr.Entity, result);
        //                if (getParameters == null || getParameters.IncludeMemberCollections)
        //                    FillMemberCollections(result, sessionData, getParameters);
        //                return result;
        //            }

        //            return null;
        //        }
        //    }
        //    catch (PDSAValidationException ex)
        //    {
        //        DataValidationException dve = Converters.ConvertToDataValidationException(ex);
        //        throw dve;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleFiltersRepository::GetEntityByGuidId", ex);
        //        throw;
        //    }
        //}
        protected override RoleFilters GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                RoleFilters result = null;
                var cacheKey = GetItemCacheKey(guid);
                if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters))
                {
                    result = _cacheManager.GetCachedItem<RoleFilters>(cacheKey);
                    if (result == null) // if no cached item is found, set RefreshCache = true to force writing to cache
                        getParameters.RefreshCache = true;
                }

                if (result == null)
                {
                    RoleFiltersPDSAManager mgr = new RoleFiltersPDSAManager();
                    var count = mgr.DataObject.LoadByPK(guid);

                    if (count == 1)
                    {
                        result = new RoleFilters();
                        SimpleMapper.PropertyMap(mgr.Entity, result);
                        if (CacheHelpers.ShouldCacheBeUpdated(_cacheManager, getParameters))
                        {
                            var bCached = _cacheManager.SetCachedItem(cacheKey, result);
                        }
                    }
                }

                if (result != null && result.RoleId == guid)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleFiltersRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, RoleFilters originalEntity, RoleFilters newEntity, string auditXml)
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

                        List<String> propertiesToIgnore = new List<string>(); propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "RoleId";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleId;
                        mgr.Entity.RecordTag = newEntity.RoleId.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "RoleId";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleId;
                        mgr.Entity.RecordTag = newEntity.RoleId.ToString();
                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "RoleId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.RoleId;
                        mgr.Entity.RecordTag = originalEntity.RoleId.ToString();
                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleFiltersRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(RoleFilters entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            bool bSkipIt = false;
            if (getParameters == null)
                getParameters = new GetParametersWithPhoto();

            if (getParameters != null)
            {
                //var excludeRolePermissions = getParameters.ExcludeMemberCollectionSettings.Where(o => o.Key == nameof(RoleFiltersPermission)).FirstOrDefault();
                //if(excludeRolePermissions.Value == true )
                //bSkipIt = true;
                bSkipIt = getParameters.IsExcluded(nameof(entity.Regions));
            }

            if (bSkipIt == false)
            {
                var roleRegionRepository = _dataRepositoryFactory.GetDataRepository<IRoleRegionRepository>();
                entity.Regions = roleRegionRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId, IncludeMemberCollections = true, RefreshCache = getParameters.RefreshCache}).ToCollection();
            }

            //if (getParameters != null)
            //{
            //    //var excludeRolePermissions = getParameters.ExcludeMemberCollectionSettings.Where(o => o.Key == nameof(RoleFiltersPermission)).FirstOrDefault();
            //    //if(excludeRolePermissions.Value == true )
            //    //bSkipIt = true;
            //    bSkipIt = getParameters.IsExcluded(nameof(entity.Clusters));
            //}

            //if (bSkipIt == false)
            //{
            //    var roleClusterRepository = _dataRepositoryFactory.GetDataRepository<IRoleClusterRepository>();
            //    entity.Clusters = roleClusterRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto(){UniqueId = entity.RoleId, IncludeMemberCollections = true}).ToCollection();
            //}

            //bSkipIt = getParameters.IsExcluded(nameof(entity.AccessPortals));
            //if (bSkipIt == false)
            //{
            //    var roleAccessPortalRepository = new RoleAccessPortalRepository();
            //    entity.AccessPortals = roleAccessPortalRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId }).ToCollection();
            //}

            //bSkipIt = getParameters.IsExcluded(nameof(entity.InputDevices));
            //if (bSkipIt == false)
            //{
            //    var roleInputDeviceRepository = new RoleInputDeviceRepository();
            //    entity.InputDevices = roleInputDeviceRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId }).ToCollection();
            //}

            //bSkipIt = getParameters.IsExcluded(nameof(entity.OutputDevices));
            //if (bSkipIt == false)
            //{
            //    var roleOutputDeviceRepository = new RoleOutputDeviceRepository();
            //    entity.OutputDevices = roleOutputDeviceRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId }).ToCollection();
            //}

            //bSkipIt = getParameters.IsExcluded(nameof(entity.Clusters));
            //if (bSkipIt == false)
            //{
            //    var roleClusterRepository = new RoleClusterRepository();
            //    entity.Clusters = roleClusterRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId }).ToCollection();
            //}

            //bSkipIt = getParameters.IsExcluded(nameof(entity.InputOutputGroups));
            //if (bSkipIt == false)
            //{
            //    var roleInputOutputGroupRepository = new RoleInputOutputGroupRepository();
            //    entity.InputOutputGroups = roleInputOutputGroupRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId }).ToCollection();
            //}

        }

        protected override bool IsEntityReferenced(Guid roleId)
        {
            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("RoleFilters", "RoleId", roleId);
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

        protected override bool IsEntityUnique(RoleFilters role)
        {
            gcs_IsRoleUniquePDSAManager mgr = new gcs_IsRoleUniquePDSAManager();
            mgr.Entity.RoleId = role.RoleId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("RoleFilters", "RoleId", id);
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
            return true;
        }

    }
}
