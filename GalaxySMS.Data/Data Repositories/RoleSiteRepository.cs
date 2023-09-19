using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using System.Data.Entity;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Shared.Utils;
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using GCS.Framework.Caching;

namespace GalaxySMS.Data
{
    [Export(typeof(IRoleSiteRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RoleSiteRepository : DataRepositoryBase<RoleSite>, IRoleSiteRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private ICacheManager _cacheManager;

        protected override RoleSite AddEntity(RoleSite entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new RoleSitePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.RoleSiteUid, entity);
                    var result = GetEntityByGuidId(entity.RoleSiteUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::AddEntity", ex);
                throw;
            }
        }

        protected override RoleSite UpdateEntity(RoleSite entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.RoleSiteUid, sessionData, null);
                var mgr = new RoleSitePDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.RoleSiteUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.RoleSiteUid, entity);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.RoleSiteUid, sessionData, new GetParametersWithPhoto()
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
                throw new Exception($"{entity.GetType().Name} {entity.RoleSiteUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void EnsureChildRecordsExist(RoleSite entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.Clusters)) && entity.Clusters != null)
                SaveClusterFilters(entity, sessionData, saveParams);
        }

        private void SaveClusterFilters(RoleSite entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //            if (entity.PersonClusterPermissions == null || !entity.PersonClusterPermissions.Any() || saveParams.Ignore(nameof(entity.PersonClusterPermissions)))
            if (entity.Clusters == null || saveParams.Ignore(nameof(entity.Clusters)))
                return;

            // Don't support this capability
            //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveRoleFiltersOption).ToString());

            //bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
            //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
            //                           kvpSaveOption.Value == SaveRoleFiltersOption.DeleteMissingItems.ToString();

            var roleClusterRepository = _dataRepositoryFactory.GetDataRepository<IRoleClusterRepository>();
            var clusterRepository = _dataRepositoryFactory.GetDataRepository<IClusterRepository>();
            var clusterUids = clusterRepository.GetAllPrimaryKeyUidsFromRoleIdAndSiteUid(entity.RoleId, entity.SiteUid);

            var existingClusters = roleClusterRepository.GetAllForRoleIdAndSiteUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId, CurrentSiteUid = entity.SiteUid, IncludeMemberCollections = true }).ToList();
            var addTheseClusters = entity.Clusters.Where(o => existingClusters.All(o2 => o2.ClusterUid != o.ClusterUid)).ToList();
            var updateTheseClusters = entity.Clusters.Where(o => existingClusters.All(o2 => o2.ClusterUid == o.ClusterUid)).ToList();
            foreach (var c in entity.Clusters)
            {
                var existingC = existingClusters.FirstOrDefault(o => o.ClusterUid == c.ClusterUid);
                if( existingC != null)
                    updateTheseClusters.Add(c);
            }

            if (entity.IncludeAllClusters)
            {
                foreach (var clusterUid in clusterUids)
                {
                    var existingRc = existingClusters.FirstOrDefault(o => o.ClusterUid == clusterUid);
                    if (existingRc == null)
                    {
                        var existingAddRc = addTheseClusters.FirstOrDefault(o => o.ClusterUid == clusterUid);
                        if (existingAddRc == null)
                        {
                            addTheseClusters.Add(new RoleCluster()
                            {
                                ClusterUid = clusterUid,
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
                nameof(RoleCluster.IsDirty),
                nameof(RoleCluster.IsAnythingDirty),
                nameof(RoleCluster.IsPanelDataDirty)
            };

            var dirtyRoleClusters = new List<RoleCluster>();
            foreach (var rc in updateTheseClusters)
            {
                // Grab the existing item and see if any properties are different. If so, update the record
                var existingItem = existingClusters.FirstOrDefault(o => o.ClusterUid == rc.ClusterUid);
                if (existingItem == null)
                    continue;

                //if (rc.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(rc, existingItem, propsToInclude, propsToIgnore))
                //{
                UpdateTableEntityBasePropertiesFromExisting(rc, existingItem);
                rc.RoleClusterUid = existingItem.RoleClusterUid;
                dirtyRoleClusters.Add(rc);
                //}
            }

            // spin through all the dirty role cluster permissions
            foreach (var rc in dirtyRoleClusters)
            {
                rc.RoleId = entity.RoleId;

                UpdateTableEntityBaseProperties(rc, sessionData);
                roleClusterRepository.Update(rc, sessionData, saveParams);
            }

            // spin through all the new role cluster permissions
            foreach (var rc in addTheseClusters)
            {
                rc.RoleId = entity.RoleId;

                UpdateTableEntityBaseProperties(rc, sessionData);
                if (rc.RoleClusterUid == Guid.Empty)
                {
                    rc.RoleClusterUid = GuidUtilities.GenerateComb();
                    roleClusterRepository.Add(rc, sessionData, saveParams);
                }
            }

            // Delete existing role clusters that are not included in the incoming data set if IncludeAllClusters is false
            if (!entity.IncludeAllClusters)
            {
                var deleteTheseClusters = existingClusters.Where(c => entity.Clusters.All(c2 => c2.ClusterUid != c.ClusterUid)).ToList();
                foreach (var rc in deleteTheseClusters)
                {
                    // must explicitly delete the credential first
                    roleClusterRepository.Remove(rc.RoleClusterUid, sessionData);
                }
            }
        }

        protected override int DeleteEntity(RoleSite entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new RoleSitePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.RoleSiteUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new RoleSitePDSAManager();

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
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<RoleSite> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, RoleSitePDSAManager mgr)
        {
            IEnumerable<RoleSite> entities = null;
            var cacheKey = string.Empty;
            switch (mgr.DataObject.SelectFilter)
            {
                case RoleSitePDSAData.SelectFilters.All:
                    cacheKey = GetItemsCacheKey(Guid.Empty, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleSitePDSAData.SelectFilters.ByRoleId:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RoleId, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleSitePDSAData.SelectFilters.ByRoleIdAndRegionUid:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RoleId, mgr.Entity.RegionUid, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleSitePDSAData.SelectFilters.BySiteUid:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RegionUid, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                //case RoleSitePDSAData.SelectFilters.ListBox:
                    //    break;
                    //case RoleSitePDSAData.SelectFilters.PrimaryKey:
                    //    break;
                    //case RoleSitePDSAData.SelectFilters.Search:
                    //    break;
                    //case RoleSitePDSAData.SelectFilters.Custom:
                    //    break;
                    //default:
                    //    throw new ArgumentOutOfRangeException();
            }
            if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters) && !string.IsNullOrEmpty(cacheKey))
            {
                entities = _cacheManager.GetCachedItem<List<RoleSite>>(cacheKey);
                if (entities == null) // if no cached item is found, set RefreshCache = true to force writing to cache
                    getParameters.RefreshCache = true;
            }

            if (entities == null)// || !entities.Any())
            {
                entities = new List<RoleSite>();
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    entities = mgr.ConvertPDSACollection(pdsaEntities);
                    if (CacheHelpers.ShouldCacheBeUpdated(_cacheManager, getParameters) && !string.IsNullOrEmpty(cacheKey))
                    {
                        var bCached = _cacheManager.SetCachedItem(cacheKey, entities);
                    }
                }
            }

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
            }

            return entities;
        }

        //private IEnumerable<RoleSite> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, RoleSitePDSAManager mgr)
        //{
        //    var pdsaEntities = mgr.BuildCollection();
        //    if (pdsaEntities != null)
        //    {
        //        var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //        foreach (var entity in entities)
        //        {
        //            if (getParameters == null || getParameters.IncludeMemberCollections)
        //                FillMemberCollections(entity, null, getParameters);
        //        }
        //        return entities;
        //    }
        //    return null;
        //}

        // GetAllRoleSites for an Entity
        protected override IEnumerable<RoleSite> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetAllEntities(sessionData, getParameters);
            //try
            //{
            //    var mgr = new RoleSitePDSAManager();
            //    mgr.DataObject.SelectFilter = RoleSitePDSAData.SelectFilters.All;

            //    return GetIEnumerable(sessionData, getParameters, mgr);
            //}
            //catch (PDSAValidationException ex)
            //{
            //    DataValidationException dve = Converters.ConvertToDataValidationException(ex);
            //    throw dve;
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::GetEntities", ex);
            //    throw;
            //}
        }

        protected override IEnumerable<RoleSite> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleSitePDSAManager();
                mgr.DataObject.SelectFilter = RoleSitePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<RoleSite> GetAllForRoleId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleSitePDSAManager();
                mgr.DataObject.SelectFilter = RoleSitePDSAData.SelectFilters.ByRoleId;
                mgr.Entity.RoleId = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::GetAllForRoleId", ex);
                throw;
            }
        }

        public IEnumerable<RoleSite> GetAllForSiteUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleSitePDSAManager();
                mgr.DataObject.SelectFilter = RoleSitePDSAData.SelectFilters.BySiteUid;
                mgr.Entity.SiteUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::GetAllForClusterUid", ex);
                throw;
            }
        }


        //public IEnumerable<RoleSite> GetAllForRoleIdAndRegionUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        //{
        //    try
        //    {
        //        var mgr = new RoleSitePDSAManager();
        //        mgr.DataObject.SelectFilter = RoleSitePDSAData.SelectFilters.ByRoleIdAndRegionUid;
        //        mgr.Entity.RoleId = parameters.UniqueId;
        //        mgr.Entity.RegionUid = parameters.GetGuid;
        //        return GetIEnumerable(sessionData, parameters, mgr);
        //    }
        //    catch (PDSAValidationException ex)
        //    {
        //        DataValidationException dve = Converters.ConvertToDataValidationException(ex);
        //        throw dve;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::GetAllForClusterUid", ex);
        //        throw;
        //    }
        //}
        public IEnumerable<RoleSite> GetAllForRoleIdAndRegionUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new RoleSitePDSAManager
                {
                    DataObject =
                    {
                        SelectFilter = RoleSitePDSAData.SelectFilters.ByRoleIdAndRegionUid
                    },
                    Entity =
                    {
                        RoleId = parameters.UniqueId,
                        RegionUid = parameters.GetGuid
                    }
                };
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::GetAllForClusterUid", ex);
                throw;
            }
        }

        protected override RoleSite GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override RoleSite GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleSitePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    RoleSite result = new RoleSite();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(result, sessionData, getParameters);
                    return result;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        private string GetItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleSite), uid, false);
        }

        private string GetItemsCacheKey(Guid uid, string suffix)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleSite), uid, true, suffix);
        }

        private string GetItemsCacheKey(Guid uid, Guid uid2, string suffix)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleSite), uid, uid2, true, suffix);
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, RoleSite originalEntity, RoleSite newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "RoleSiteUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleSiteUid;
                        mgr.Entity.RecordTag = newEntity.RoleSiteUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "RoleSiteUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleSiteUid;
                        mgr.Entity.RecordTag = newEntity.RoleSiteUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "RoleSiteUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.RoleSiteUid;
                        mgr.Entity.RecordTag = originalEntity.RoleSiteUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleSiteRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(RoleSite entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            bool bSkipIt = false;
            if (getParameters == null)
                getParameters = new GetParametersWithPhoto();
            if (getParameters != null)
            {
                //var excludeRolePermissions = getParameters.ExcludeMemberCollectionSettings.Where(o => o.Key == nameof(RoleFiltersPermission)).FirstOrDefault();
                //if(excludeRolePermissions.Value == true )
                //bSkipIt = true;
                bSkipIt = getParameters.IsExcluded(nameof(entity.Clusters));
            }

            if (bSkipIt == false)
            {
                var roleClusterRepository = _dataRepositoryFactory.GetDataRepository<IRoleClusterRepository>();
                entity.Clusters = roleClusterRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId, IncludeMemberCollections = true, RefreshCache = getParameters.RefreshCache }).ToCollection();
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("RoleSite", "RoleSiteUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("RoleSite", "RoleSiteUid", id);
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

        protected override bool IsEntityUnique(RoleSite entity)
        {
            var mgr = new IsRoleSiteUniquePDSAManager();
            mgr.Entity.RoleSiteUid = entity.RoleSiteUid;
            mgr.Entity.RoleId = entity.RoleId;
            mgr.Entity.SiteUid = entity.SiteUid;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("RoleSite", "RoleSiteUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("RoleSite", "RoleSiteUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
