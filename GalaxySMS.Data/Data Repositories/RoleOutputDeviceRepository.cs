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
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using GCS.Framework.Caching;

namespace GalaxySMS.Data
{
    [Export(typeof(IRoleOutputDeviceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RoleOutputDeviceRepository : DataRepositoryBase<RoleOutputDevice>, IRoleOutputDeviceRepository, IPartImportsSatisfiedNotification
    {
        [Import] private ICacheManager _cacheManager;

        protected override RoleOutputDevice AddEntity(RoleOutputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new RoleOutputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.RoleOutputDeviceUid, entity);
                    var result = GetEntityByGuidId(entity.RoleOutputDeviceUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleOutputDeviceRepository::AddEntity", ex);
                throw;
            }
        }

        protected override RoleOutputDevice UpdateEntity(RoleOutputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.RoleOutputDeviceUid, sessionData, null);
                var mgr = new RoleOutputDevicePDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.RoleOutputDeviceUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    //SaveEntityMappings(sessionData, entity.RoleOutputDeviceUid, entity);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.RoleOutputDeviceUid, sessionData, new GetParametersWithPhoto()
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleOutputDeviceRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(RoleOutputDevice entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new RoleOutputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.RoleOutputDeviceUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleOutputDeviceRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new RoleOutputDevicePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleOutputDeviceRepository::Remove", ex);
                throw;
            }
        }

        //private IEnumerable<RoleOutputDevice> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, RoleOutputDevicePDSAManager mgr)
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

        private IEnumerable<RoleOutputDevice> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, RoleOutputDevicePDSAManager mgr)
        {
            IEnumerable<RoleOutputDevice> entities = null;
            var cacheKey = string.Empty;

            switch (mgr.DataObject.SelectFilter)
            {
                case RoleOutputDevicePDSAData.SelectFilters.All:
                    cacheKey = GetItemsCacheKey(Guid.Empty, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}"); break;
                case RoleOutputDevicePDSAData.SelectFilters.ByOutputDeviceUid:
                    cacheKey = GetItemsCacheKey(mgr.Entity.OutputDeviceUid, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleOutputDevicePDSAData.SelectFilters.ByRoleId:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RoleId, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}");
                    break;
                case RoleOutputDevicePDSAData.SelectFilters.ByRoleIdAndClusterUid:
                    cacheKey = GetItemsCacheKey(mgr.Entity.RoleId, mgr.Entity.ClusterUid, $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}.{mgr.DataObject.SelectFilter}"); break;
            }
            if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters) && !string.IsNullOrEmpty(cacheKey))
            {
                entities = _cacheManager.GetCachedItem<List<RoleOutputDevice>>(cacheKey);
                if (entities == null) // if no cached item is found, set RefreshCache = true to force writing to cache
                    getParameters.RefreshCache = true;
            }

            if (entities == null) // || !entities.Any())
            {
                entities = new List<RoleOutputDevice>();

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

        // GetAllRoleOutputDevices for an Entity
        protected override IEnumerable<RoleOutputDevice> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetAllEntities(sessionData, getParameters);
            //try
            //{
            //    var mgr = new RoleOutputDevicePDSAManager();
            //    mgr.DataObject.SelectFilter = RoleOutputDevicePDSAData.SelectFilters.All;

            //    return GetIEnumerable(sessionData, getParameters, mgr);
            //}
            //catch (PDSAValidationException ex)
            //{
            //    DataValidationException dve = Converters.ConvertToDataValidationException(ex);
            //    throw dve;
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleOutputDeviceRepository::GetEntities", ex);
            //    throw;
            //}
        }

        protected override IEnumerable<RoleOutputDevice> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleOutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = RoleOutputDevicePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleOutputDeviceRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<RoleOutputDevice> GetAllForRoleId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleOutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = RoleOutputDevicePDSAData.SelectFilters.ByRoleId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleOutputDeviceRepository::GetAllForRoleId", ex);
                throw;
            }
        }

        public IEnumerable<RoleOutputDevice> GetAllForRoleIdAndClusterUid(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new RoleOutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = RoleOutputDevicePDSAData.SelectFilters.ByRoleIdAndClusterUid;
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

        public IEnumerable<RoleOutputDevice> GetAllForOutputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleOutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = RoleOutputDevicePDSAData.SelectFilters.ByOutputDeviceUid;
                mgr.Entity.OutputDeviceUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleOutputDeviceRepository::GetAllForOutputDeviceUid", ex);
                throw;
            }
        }


        protected override RoleOutputDevice GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override RoleOutputDevice GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new RoleOutputDevicePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    RoleOutputDevice result = new RoleOutputDevice();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleOutputDeviceRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        private string GetItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleOutputDevice), uid, false);
        }
        private string GetItemsCacheKey(Guid uid, string suffix)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleOutputDevice), uid, true, suffix);
        }
        private string GetItemsCacheKey(Guid uid, Guid uid2, string suffix)
        {
            return CacheHelpers.GetCacheKey(typeof(RoleOutputDevice), uid, uid2, true, suffix);
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, RoleOutputDevice originalEntity, RoleOutputDevice newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "RoleOutputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleOutputDeviceUid;
                        mgr.Entity.RecordTag = newEntity.RoleOutputDeviceUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "RoleOutputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.RoleOutputDeviceUid;
                        mgr.Entity.RecordTag = newEntity.RoleOutputDeviceUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "RoleOutputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.RoleOutputDeviceUid;
                        mgr.Entity.RecordTag = originalEntity.RoleOutputDeviceUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//RoleOutputDeviceRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(RoleOutputDevice entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("RoleOutputDevice", "RoleOutputDeviceUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("RoleOutputDevice", "RoleOutputDeviceUid", id);
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

        protected override bool IsEntityUnique(RoleOutputDevice entity)
        {
            var mgr = new IsRoleOutputDeviceUniquePDSAManager();
            mgr.Entity.RoleOutputDeviceUid = entity.RoleOutputDeviceUid;
            mgr.Entity.RoleId = entity.RoleId;
            mgr.Entity.OutputDeviceUid = entity.OutputDeviceUid;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("RoleOutputDevice", "RoleOutputDeviceUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("RoleOutputDevice", "RoleOutputDeviceUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }


    }
}
