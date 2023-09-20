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
using GCS.Framework.Caching;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsRoleRepository : PagedDataRepositoryBase<gcsRole>, IGcsRoleRepository
    {
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private ICacheManager _cacheManager;

        protected override gcsRole AddEntity(gcsRole entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (string.IsNullOrEmpty(entity.RoleDescription))
                //    entity.RoleDescription = entity.RoleName;

                gcsRolePDSAManager mgr = new gcsRolePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.RoleId, sessionData, null);
                    if (result != null)
                    {
                        SaveRoleFilters(entity, sessionData, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsRole UpdateEntity(gcsRole entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.RoleId, sessionData, null);
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.RoleId) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    //if (string.IsNullOrEmpty(entity.RoleDescription))
                    //    entity.RoleDescription = mgr.Entity.RoleDescription;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveRoleFilters(entity, sessionData, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.RoleId, sessionData, new GetParametersWithPhoto()
                        {
                            RefreshCache = true,
                            IncludeMemberCollections = true
                        });
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void SaveRoleFilters(gcsRole entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.DeviceFilters == null || saveParams.Ignore(nameof(entity.DeviceFilters)))
                return;

            var roleFiltersRepository = _dataRepositoryFactory.GetDataRepository<IRoleFiltersRepository>();
            entity.DeviceFilters.RoleId = entity.RoleId;

            UpdateTableEntityBaseProperties(entity.DeviceFilters, sessionData);
            if (roleFiltersRepository.DoesExist(entity.RoleId))
            {
                entity.DeviceFilters = roleFiltersRepository.Update(entity.DeviceFilters, sessionData, saveParams);
            }
            else
            {
                entity.DeviceFilters = roleFiltersRepository.Add(entity.DeviceFilters, sessionData, saveParams);
            }
        }

        protected override int DeleteEntity(gcsRole entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.RoleId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);

                    if (_cacheManager?.IsInitialized == true)
                    {
                        var cacheKey = GetItemCacheKey(entity.EntityId);
                        var deleted = _cacheManager.DeleteCachedItem(cacheKey);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsRole> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (gcsRole entity in entities)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsRole> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsRole GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        private string GetItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(gcsRole), uid, false);
        }

        private string GetRolesForEntityCacheKey(Guid uid, string prefix)
        {
            return CacheHelpers.GetCacheKey(typeof(gcsRole), uid, true, prefix);
        }

        //protected override gcsRole GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        gcsRolePDSAManager mgr = new gcsRolePDSAManager();
        //        var count = mgr.DataObject.LoadByPK(guid);

        //        if (count == 1)
        //        {
        //            gcsRole result = new gcsRole();
        //            SimpleMapper.PropertyMap(mgr.Entity, result);
        //            if (getParameters == null || getParameters.IncludeMemberCollections)
        //                FillMemberCollections(result, sessionData, getParameters);
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
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetEntityByGuidId", ex);
        //        throw;
        //    }
        //}
        protected override gcsRole GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsRole result = null;
                var cacheKey = GetItemCacheKey(guid);
                if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters))
                {
                    result = _cacheManager.GetCachedItem<gcsRole>(cacheKey);
                }

                if (result == null)
                {
                    gcsRolePDSAManager mgr = new gcsRolePDSAManager();
                    var count = mgr.DataObject.LoadByPK(guid);

                    if (count == 1)
                    {
                        result = new gcsRole();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsRole originalEntity, gcsRole newEntity, string auditXml)
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
                        mgr.Entity.RecordTag = newEntity.RoleName;
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
                        mgr.Entity.RecordTag = newEntity.RoleName;
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
                        mgr.Entity.RecordTag = originalEntity.RoleName;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsRole entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            bool bSkipIt = false;
            if (getParameters == null)
                getParameters = new GetParametersWithPhoto();
            if (getParameters != null)
            {
                bSkipIt = getParameters.IsExcluded(nameof(entity.RolePermissions));
            }

            if (bSkipIt == false)
            {
                var rolePermissionRepository = _dataRepositoryFactory.GetDataRepository<IGcsRolePermissionRepository>();
                if (!getParameters.AllowedApplicationIds.Any() || (getParameters.AllowedApplicationIds.Count == 1 && getParameters.AllowedApplicationIds.Contains(Guid.Empty)))
                    entity.RolePermissions = rolePermissionRepository.GetAllForRole(entity.RoleId).ToCollection();
                else
                {
                    foreach (var appid in getParameters.AllowedApplicationIds)
                    {
                        var rolePermissions = rolePermissionRepository
                            .GetAllForRoleAndApplication(entity.RoleId, appid);
                        entity.RolePermissions.AddRange(rolePermissions);
                    }

                }
            }

            bSkipIt = getParameters.IsExcluded(nameof(entity.DeviceFilters));
            if (bSkipIt == false)
            {
                var roleFiltersRepository = _dataRepositoryFactory.GetDataRepository<IRoleFiltersRepository>();
                entity.DeviceFilters = roleFiltersRepository.Get(entity.RoleId, sessionData, getParameters);
            }

            //bSkipIt = getParameters.IsExcluded(nameof(entity.RoleFilters.RoleC));
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
            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsRole", "RoleId", roleId);
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

        protected override bool IsEntityUnique(gcsRole role)
        {
            gcs_IsRoleUniquePDSAManager mgr = new gcs_IsRoleUniquePDSAManager();
            mgr.Entity.RoleId = role.RoleId;
            mgr.Entity.RoleName = role.RoleName;
            mgr.Entity.EntityId = role.EntityId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsRole", "RoleId", id);
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
        public IEnumerable<gcsRole> GetAllRolesForEntity(Guid entityId, IGetParametersWithPhoto getParameters)
        {
            try
            {
                IEnumerable<gcsRole> entities = null;
                var cacheKey = GetRolesForEntityCacheKey(entityId, System.Reflection.MethodBase.GetCurrentMethod()?.Name);

                if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters))
                {
                    entities = _cacheManager.GetCachedItem<List<gcsRole>>(cacheKey);
                    if (entities == null) // if no cached item is found, set RefreshCache = true to force writing to cache
                        getParameters.RefreshCache = true;
                }

                if (entities == null || !entities.Any())
                {
                    entities = new List<gcsRole>();
                    var mgr = new gcsRolePDSAManager
                    {
                        DataObject =
                        {
                            SelectFilter = gcsRolePDSAData.SelectFilters.ByEntityId,
                            Entity =
                            {
                                EntityId = entityId
                            }
                        }
                    };
                    var pdsaEntities = mgr.BuildCollection();
                    if (pdsaEntities != null)
                    {
                        entities = mgr.ConvertPDSACollection(pdsaEntities);
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
                        if (getParameters == null || getParameters.IncludeMemberCollections)
                            FillMemberCollections(entity, null, getParameters);
                    }
                }

                return entities;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetAllRolesForApplication", ex);
                throw;
            }
        }
        //public IEnumerable<gcsRole> GetAllRolesForEntity(Guid entityId, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        gcsRolePDSAManager mgr = new gcsRolePDSAManager();
        //        mgr.DataObject.SelectFilter = gcsRolePDSAData.SelectFilters.ByEntityId;
        //        mgr.DataObject.Entity.EntityId = entityId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //            foreach (gcsRole entity in entities)
        //            {
        //                if (getParameters == null || getParameters.IncludeMemberCollections)
        //                    FillMemberCollections(entity, null, getParameters);
        //            }

        //            return entities;
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
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetAllRolesForApplication", ex);
        //        throw;
        //    }
        //}

        //public IEnumerable<gcsRole> GetAllRolesForApplication(Guid applicationId, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        gcsRolePDSAManager mgr = new gcsRolePDSAManager();
        //        mgr.DataObject.SelectFilter = gcsRolePDSAData.SelectFilters.ByApplicationId;
        //        mgr.DataObject.Entity.ApplicationId = applicationId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //            foreach (gcsRole entity in entities)
        //            {
        //                if (getParameters == null || getParameters.IncludeMemberCollections)
        //                    FillMemberCollections(entity, null, getParameters);
        //            }

        //            return entities;
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
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetAllRolesForApplication", ex);
        //        throw;
        //    }
        //}

        //public IEnumerable<gcsRole> GetAllRolesForApplicationAndEntity(Guid applicationId, Guid entityId, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        gcsRolePDSAManager mgr = new gcsRolePDSAManager();
        //        mgr.DataObject.SelectFilter = gcsRolePDSAData.SelectFilters.ByApplicationIdEntityId;
        //        mgr.DataObject.Entity.ApplicationId = applicationId;
        //        mgr.DataObject.Entity.EntityId = entityId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //            foreach (gcsRole entity in entities)
        //            {
        //                if (getParameters == null || getParameters.IncludeMemberCollections)
        //                    FillMemberCollections(entity, null, getParameters);
        //            }
        //            return entities;
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
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetAllRolesForApplication", ex);
        //        throw;
        //    }
        //}

        //public IEnumerable<gcsRole> GetAllRolesForUserAndEntityAndApplication(Guid userId, Guid entityId, Guid applicationId, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        gcsRolePDSAManager mgr = new gcsRolePDSAManager();
        //        mgr.DataObject.SelectFilter = gcsRolePDSAData.SelectFilters.ByUserIdEntityIdApplicationId;
        //        mgr.DataObject.Entity.UserId = userId;
        //        mgr.DataObject.Entity.EntityId = entityId;
        //        mgr.DataObject.Entity.ApplicationId = applicationId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //            foreach (gcsRole entity in entities)
        //            {
        //                if (getParameters == null || getParameters.IncludeMemberCollections)
        //                    FillMemberCollections(entity, null, getParameters);
        //            }
        //            return entities;
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
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetAllRolesForUserAndEntityAndApplication", ex);
        //        throw;
        //    }
        //}

        //public IEnumerable<gcsRole> GetAllRolesForUserEntityAndApplication(Guid userEntityId, Guid applicationId, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        gcsRolePDSAManager mgr = new gcsRolePDSAManager();
        //        mgr.DataObject.SelectFilter = gcsRolePDSAData.SelectFilters.ByUserEntityIdApplicationId;
        //        mgr.DataObject.Entity.UserEntityId = userEntityId;
        //        mgr.DataObject.Entity.ApplicationId = applicationId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //            foreach (gcsRole entity in entities)
        //            {
        //                if (getParameters == null || getParameters.IncludeMemberCollections)
        //                    FillMemberCollections(entity, null, getParameters);
        //            }
        //            return entities;
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
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetAllRolesForUserEntityAndApplication", ex);
        //        throw;
        //    }
        //}

        public IEnumerable<Guid> GetAllPrimaryKeyUids(Guid entityId)
        {
            if (entityId == Guid.Empty)
                return GalaxySMSDatabaseManager.GetAllUidsFromTable("GCS", "gcsRole", "RoleId");
            return GalaxySMSDatabaseManager.GetAllUidsFromTable("GCS", "gcsRole", "RoleId",
                $"EntityId = '{entityId}'");
        }

        public IEnumerable<Guid> GetAllDefaultUids(Guid entityId)
        {
            return GalaxySMSDatabaseManager.GetAllUidsFromTable("GCS", "gcsRole", "RoleId",
                $"EntityId = '{entityId}' AND IsDefault=1");
        }

        private void SetSortColumnAndOrder(IGetParametersWithPhoto getParameters, gcsRolePDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<RoleSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }

        protected override IArrayResponse<gcsRole> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();

                SetSortColumnAndOrder(getParameters, mgr);

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    var totalRowCount = 0;

                    foreach (gcsRole entity in entities)
                    {
                        if (totalRowCount == 0)
                            totalRowCount = entity.TotalRowCount;

                        if (getParameters == null || getParameters.IncludeMemberCollections)
                            FillMemberCollections(entity, sessionData, getParameters);
                    }
                    //if (getParameters.DescendingOrder)
                    //    return ArrayResponseHelpers.ToArrayResponse(entities.OrderByDescending(o => o.RoleName),
                    //        getParameters.PageNumber, getParameters.PageSize, totalRowCount);

                    return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalRowCount);
                }
                return new ArrayResponse<gcsRole>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<gcsRole> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }

        public IArrayResponse<gcsRole> GetAllRolesForEntityPaged(Guid entityId, IGetParametersWithPhoto getParameters, Guid userId)
        {
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();
                var getForCurrentUserOption = getParameters.GetOption(GetRoleOption.ForCurrentUser.ToString());
                if (getForCurrentUserOption.HasValue && getForCurrentUserOption.Value)
                {
                    mgr.DataObject.SelectFilter = gcsRolePDSAData.SelectFilters.ByEntityIdForUser;
                    mgr.DataObject.Entity.UserId = userId;
                }
                else
                    mgr.DataObject.SelectFilter = gcsRolePDSAData.SelectFilters.ByEntityId;
                mgr.DataObject.Entity.EntityId = entityId;
                SetSortColumnAndOrder(getParameters, mgr);
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    var totalRowCount = 0;
                    foreach (gcsRole entity in entities)
                    {
                        if (totalRowCount == 0)
                            totalRowCount = entity.TotalRowCount;
                        if (getParameters == null || getParameters.IncludeMemberCollections)
                            FillMemberCollections(entity, null, getParameters);
                    }

                    return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalRowCount);
                }
                return new ArrayResponse<gcsRole>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetAllRolesForApplication", ex);
                throw;
            }
        }

        public string GetRoleName(Guid roleId)
        {
            try
            {
                var mgr = new gcsRolePDSA_SelectNameByPKPDSAManager();
                mgr.Entity.RoleId = roleId;
                var results = mgr.BuildCollection();
                if (results != null && results.Count == 1)
                {
                    return results[0].RoleName;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::Remove", ex);
                throw;
            }

        }


        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForRolePDSAManager
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
