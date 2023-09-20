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
    [Export(typeof(IRoleRegionRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RoleRegionRepository : DataRepositoryBase<RoleRegion>, IRoleRegionRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private ICacheManager _cacheManager;

        protected override RoleRegion AddEntity(RoleRegion entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new RoleRegionPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.RoleRegionUid, entity);
                    var result = GetEntityByGuidId(entity.RoleRegionUid, sessionData, new GetParametersWithPhoto() { RefreshCache = true,IncludeMemberCollections = false });
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleRegionRepository::AddEntity", ex);
                throw;
            }
        }

        protected override RoleRegion UpdateEntity(RoleRegion entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.RoleRegionUid, sessionData, new GetParametersWithPhoto());
                var mgr = new RoleRegionPDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.RoleRegionUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.RoleRegionUid, entity);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.RoleRegionUid, sessionData,
                            new GetParametersWithPhoto(){RefreshCache = true, IncludeMemberCollections = true});
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        return updatedEntity;
                    }

                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.RoleRegionUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleRegionRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void EnsureChildRecordsExist(RoleRegion entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.Sites)) && entity.Sites != null)
                SaveSiteFilters(entity, sessionData, saveParams);
        }

        private void SaveSiteFilters(RoleRegion entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.Sites == null || saveParams.Ignore(nameof(entity.Sites)))
                return;

            // Don't support this capability
            //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveRoleFiltersOption).ToString());

            //bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
            //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
            //                           kvpSaveOption.Value == SaveRoleFiltersOption.DeleteMissingItems.ToString();

            var roleSiteRepository = _dataRepositoryFactory.GetDataRepository<IRoleSiteRepository>();
            var siteRepository = _dataRepositoryFactory.GetDataRepository<ISiteRepository>();
            var siteUids = siteRepository.GetAllPrimaryKeyUidsFromRoleIdAndRegionUid(entity.RoleId, entity.RegionUid);

            var existingSites = roleSiteRepository.GetAllForRoleId(sessionData, new GetParametersWithPhoto() { UniqueId = entity.RoleId, IncludeMemberCollections = true }).ToList();
            var addTheseSites = entity.Sites.Where(o => existingSites.All(o2 => o2.SiteUid != o.SiteUid)).ToList();
            var updateTheseSites = entity.Sites.Where(o => existingSites.All(o2 => o2.SiteUid == o.SiteUid)).ToList();

            if (entity.IncludeAllSites)
            {
                foreach (var siteUid in siteUids)
                {
                    var existingRoleSite = existingSites.FirstOrDefault(o => o.SiteUid == siteUid);
                    if (existingRoleSite == null)
                    {
                        var existingAddRoleSite = addTheseSites.FirstOrDefault(o => o.SiteUid == siteUid);
                        if (existingAddRoleSite == null)
                        {
                            addTheseSites.Add(new RoleSite()
                            {
                                SiteUid = siteUid,
                                IncludeAllClusters = entity.IncludeAllClusters,
                                IncludeAllAccessPortals = entity.IncludeAllAccessPortals,
                                IncludeAllInputDevices = entity.IncludeAllInputDevices,
                                IncludeAllOutputDevices = entity.IncludeAllOutputDevices,
                                IncludeAllInputOutputGroups = entity.IncludeAllInputOutputGroups
                            });
                        }
                    }
                }
            }

            var propsToInclude = new List<string>();

            var propsToIgnore = new List<string>
            {
                nameof(RoleSite.IsDirty),
                nameof(RoleSite.IsAnythingDirty),
                nameof(RoleSite.IsPanelDataDirty)
            };

            var dirtyRoleSites = new List<RoleSite>();
            foreach (var rs in updateTheseSites)
            {
                // Grab the existing item and see if any properties are different. If so, update the record
                var existingItem = existingSites.FirstOrDefault(o => o.SiteUid == rs.SiteUid);
                if (existingItem == null)
                    continue;

                //if (rs.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(rs, existingItem, propsToInclude, propsToIgnore))
                //{
                UpdateTableEntityBasePropertiesFromExisting(rs, existingItem);
                rs.RoleSiteUid = existingItem.RoleSiteUid;
                dirtyRoleSites.Add(rs);
                //}
            }

            // spin through all the dirty role cluster permissions
            foreach (var rs in dirtyRoleSites)
            {
                rs.RoleId = entity.RoleId;

                UpdateTableEntityBaseProperties(rs, sessionData);
                roleSiteRepository.Update(rs, sessionData, saveParams);
            }

            // spin through all the new role cluster permissions
            foreach (var rs in addTheseSites)
            {
                rs.RoleId = entity.RoleId;

                UpdateTableEntityBaseProperties(rs, sessionData);
                if (rs.RoleSiteUid == Guid.Empty)
                {
                    rs.RoleSiteUid = GuidUtilities.GenerateComb();
                    roleSiteRepository.Add(rs, sessionData, saveParams);
                }
            }

            // Delete existing role clusters that are not included in the incoming data set if IncludeAllClusters is false
            if (!entity.IncludeAllSites)
            {
                var deleteTheseItems = existingSites.Where(c => entity.Sites.All(c2 => c2.SiteUid != c.SiteUid)).ToList();
                foreach (var rap in deleteTheseItems)
                {
                    // must explicitly delete the credential first
                    roleSiteRepository.Remove(rap.RoleSiteUid, sessionData);
                }
            }
        }

        protected override int DeleteEntity(RoleRegion entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new RoleRegionPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.RoleRegionUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleRegionRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new RoleRegionPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleRegionRepository::Remove", ex);
                throw;
            }
        }

        //private IEnumerable<RoleRegion> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, RoleRegionPDSAManager mgr)
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

        private IEnumerable<RoleRegion> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, RoleRegionPDSAManager mgr)
        {
            IEnumerable<RoleRegion> entities = null;
            var cacheKey = string.Empty;
            switch (mgr.DataObject.SelectFilter)
            {
                case RoleRegionPDSAData.SelectFilters.All:
                    cacheKey = GetItemsCacheKey(Guid.Empty, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleRegionPDSAData.SelectFilters.ByRegionUid:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RegionUid, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleRegionPDSAData.SelectFilters.ByRoleId:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RoleId, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
            }
            if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters) && !string.IsNullOrEmpty(cacheKey))
            {
                entities = _cacheManager.GetCachedItem<List<RoleRegion>>(cacheKey);
                if (entities == null) // if no cached item is found, set RefreshCache = true to force writing to cache
                    getParameters.RefreshCache = true;
            }

            if (entities == null )//|| !entities.Any())
            {
                entities = new List<RoleRegion>();

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


        // GetAllRoleRegions for an Entity
        protected override IEnumerable<RoleRegion> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetAllEntities(sessionData, getParameters);
            //try
            //{
            //    var mgr = new RoleRegionPDSAManager();
            //    mgr.DataObject.SelectFilter = RoleRegionPDSAData.SelectFilters.All;

            //    return GetIEnumerable(sessionData, getParameters, mgr);
            //}
            //catch (PDSAValidationException ex)
            //{
            //    DataValidationException dve = Converters.ConvertToDataValidationException(ex);
            //    throw dve;
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleRegionRepository::GetEntities", ex);
            //    throw;
            //}
        }

        protected override IEnumerable<RoleRegion> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleRegionPDSAManager();
                mgr.DataObject.SelectFilter = RoleRegionPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleRegionRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<RoleRegion> GetAllForRoleId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleRegionPDSAManager();
                mgr.DataObject.SelectFilter = RoleRegionPDSAData.SelectFilters.ByRoleId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleRegionRepository::GetAllForRoleId", ex);
                throw;
            }
        }

        public IEnumerable<RoleRegion> GetAllForRegionUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleRegionPDSAManager();
                mgr.DataObject.SelectFilter = RoleRegionPDSAData.SelectFilters.ByRegionUid;
                mgr.Entity.RegionUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleRegionRepository::GetAllForClusterUid", ex);
                throw;
            }
        }

        protected override RoleRegion GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        private string GetItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleRegion), uid, false);
        }

        private string GetItemsCacheKey(Guid uid, string prefix)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleRegion), uid, true, prefix);
        }

        protected override RoleRegion GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleRegionPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    RoleRegion result = new RoleRegion();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleRegionRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, RoleRegion originalEntity, RoleRegion newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "RoleRegionUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleRegionUid;
                        mgr.Entity.RecordTag = newEntity.RoleRegionUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "RoleRegionUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleRegionUid;
                        mgr.Entity.RecordTag = newEntity.RoleRegionUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "RoleRegionUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.RoleRegionUid;
                        mgr.Entity.RecordTag = originalEntity.RoleRegionUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleRegionRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(RoleRegion entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                getParameters = new GetParametersWithPhoto();
            if (!getParameters.IsExcluded(nameof(entity.Sites)))
            {
                var roleSiteRepository =
                    _dataRepositoryFactory.GetDataRepository<IRoleSiteRepository>();
                entity.Sites = roleSiteRepository.GetAllForRoleIdAndRegionUid(sessionData,
                    new GetParametersWithPhoto(getParameters) { UniqueId = entity.RoleId, GetGuid = entity.RegionUid, RefreshCache = getParameters.RefreshCache}).ToCollection();
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("RoleRegion", "RoleRegionUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("RoleRegion", "RoleRegionUid", id);
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

        protected override bool IsEntityUnique(RoleRegion entity)
        {
            var mgr = new IsRoleRegionUniquePDSAManager();
            mgr.Entity.RoleRegionUid = entity.RoleRegionUid;
            mgr.Entity.RoleId = entity.RoleId;
            mgr.Entity.RegionUid = entity.RegionUid;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("RoleRegion", "RoleRegionUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("RoleRegion", "RoleRegionUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }


    }
}
