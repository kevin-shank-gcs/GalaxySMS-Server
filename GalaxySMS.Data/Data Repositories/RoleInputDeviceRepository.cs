﻿using System;
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
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using GCS.Framework.Caching;

namespace GalaxySMS.Data
{
    [Export(typeof(IRoleInputDeviceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RoleInputDeviceRepository : DataRepositoryBase<RoleInputDevice>, IRoleInputDeviceRepository, IPartImportsSatisfiedNotification
    {
        [Import] private ICacheManager _cacheManager;

        protected override RoleInputDevice AddEntity(RoleInputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new RoleInputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.RoleInputDeviceUid, entity);
                    var result = GetEntityByGuidId(entity.RoleInputDeviceUid, sessionData, null);
                    if (result != null)
                    {
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleInputDeviceRepository::AddEntity", ex);
                throw;
            }
        }

        protected override RoleInputDevice UpdateEntity(RoleInputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.RoleInputDeviceUid, sessionData, null);
                var mgr = new RoleInputDevicePDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.RoleInputDeviceUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    //SaveEntityMappings(sessionData, entity.RoleInputDeviceUid, entity);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.RoleInputDeviceUid, sessionData, new GetParametersWithPhoto()
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
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleInputDeviceRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(RoleInputDevice entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new RoleInputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.RoleInputDeviceUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleInputDeviceRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new RoleInputDevicePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleInputDeviceRepository::Remove", ex);
                throw;
            }
        }

        //private IEnumerable<RoleInputDevice> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, RoleInputDevicePDSAManager mgr)
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

        private IEnumerable<RoleInputDevice> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, RoleInputDevicePDSAManager mgr)
        {
            IEnumerable<RoleInputDevice> entities = null;
            var cacheKey = string.Empty;

            switch (mgr.DataObject.SelectFilter)
            {
                case RoleInputDevicePDSAData.SelectFilters.All:
                    cacheKey = GetItemsCacheKey(Guid.Empty, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleInputDevicePDSAData.SelectFilters.ByInputDeviceUid:
                    cacheKey = GetItemsCacheKey(mgr.Entity.InputDeviceUid, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleInputDevicePDSAData.SelectFilters.ByRoleId:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RoleId, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleInputDevicePDSAData.SelectFilters.ByRoleIdAndClusterUid:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RoleId, mgr.Entity.ClusterUid, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
            }
            if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters) && !string.IsNullOrEmpty(cacheKey))
            {
                entities = _cacheManager.GetCachedItem<List<RoleInputDevice>>(cacheKey);
                if (entities == null) // if no cached item is found, set RefreshCache = true to force writing to cache
                    getParameters.RefreshCache = true;
            }

            if (entities == null) // || !entities.Any())
            {
                entities = new List<RoleInputDevice>();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    entities = mgr.ConvertPDSACollection(pdsaEntities);
                    if (CacheHelpers.ShouldCacheBeUpdated(_cacheManager, getParameters) &&
                        !string.IsNullOrEmpty(cacheKey))
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
        // GetAllRoleInputDevices for an Entity
        protected override IEnumerable<RoleInputDevice> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetAllEntities(sessionData, getParameters);
            //try
            //{
            //    var mgr = new RoleInputDevicePDSAManager();
            //    mgr.DataObject.SelectFilter = RoleInputDevicePDSAData.SelectFilters.All;

            //    return GetIEnumerable(sessionData, getParameters, mgr);
            //}
            //catch (PDSAValidationException ex)
            //{
            //    DataValidationException dve = Converters.ConvertToDataValidationException(ex);
            //    throw dve;
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleInputDeviceRepository::GetEntities", ex);
            //    throw;
            //}
        }

        protected override IEnumerable<RoleInputDevice> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleInputDevicePDSAManager();
                mgr.DataObject.SelectFilter = RoleInputDevicePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleInputDeviceRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<RoleInputDevice> GetAllForRoleId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleInputDevicePDSAManager();
                mgr.DataObject.SelectFilter = RoleInputDevicePDSAData.SelectFilters.ByRoleId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleInputDeviceRepository::GetAllForRoleId", ex);
                throw;
            }
        }

        public IEnumerable<RoleInputDevice> GetAllForRoleIdAndClusterUid(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new RoleInputDevicePDSAManager();
                mgr.DataObject.SelectFilter = RoleInputDevicePDSAData.SelectFilters.ByRoleIdAndClusterUid;
                mgr.Entity.RoleId = parameters.UniqueId;
                mgr.Entity.ClusterUid = parameters.ClusterUid;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleAccessPortalRepository::GetAllForRoleId", ex);
                throw;
            }
        }


        public IEnumerable<RoleInputDevice> GetAllForInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleInputDevicePDSAManager();
                mgr.DataObject.SelectFilter = RoleInputDevicePDSAData.SelectFilters.ByInputDeviceUid;
                mgr.Entity.InputDeviceUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleInputDeviceRepository::GetAllForInputDeviceUid", ex);
                throw;
            }
        }


        protected override RoleInputDevice GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override RoleInputDevice GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleInputDevicePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    RoleInputDevice result = new RoleInputDevice();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleInputDeviceRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        private string GetItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleInputDevice), uid, false);
        }

        private string GetItemsCacheKey(Guid uid, string suffix)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleInputDevice), uid, true, suffix);
        }
        private string GetItemsCacheKey(Guid uid, Guid uid2, string suffix)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleInputDevice), uid, uid2, true, suffix);
        }


        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, RoleInputDevice originalEntity, RoleInputDevice newEntity, string auditXml)
        {
            try
            {                if( !string.IsNullOrEmpty(auditXml))
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
                        mgr.Entity.PrimaryKeyColumn = "RoleInputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleInputDeviceUid;
                        mgr.Entity.RecordTag = newEntity.RoleInputDeviceUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "RoleInputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleInputDeviceUid;
                        mgr.Entity.RecordTag = newEntity.RoleInputDeviceUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "RoleInputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.RoleInputDeviceUid;
                        mgr.Entity.RecordTag = originalEntity.RoleInputDeviceUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleInputDeviceRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(RoleInputDevice entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("RoleInputDevice", "RoleInputDeviceUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("RoleInputDevice", "RoleInputDeviceUid", id);
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

        protected override bool IsEntityUnique(RoleInputDevice entity)
        {
            var mgr = new IsRoleInputDeviceUniquePDSAManager();
            mgr.Entity.RoleInputDeviceUid = entity.RoleInputDeviceUid;
            mgr.Entity.RoleId = entity.RoleId;
            mgr.Entity.InputDeviceUid = entity.InputDeviceUid;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("RoleInputDevice", "RoleInputDeviceUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("RoleInputDevice", "RoleInputDeviceUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }


    }
}
