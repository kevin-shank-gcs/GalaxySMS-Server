using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsLargeObjectStorageRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsLargeObjectStorageRepository : DataRepositoryBase<gcsLargeObjectStorage>, IGcsLargeObjectStorageRepository
    {
        //[Import] private IGcsRoleRepository _roleRepository;

        protected override gcsLargeObjectStorage AddEntity(gcsLargeObjectStorage entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                gcsLargeObjectStoragePDSAManager mgr = new gcsLargeObjectStoragePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.Uid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLargeObjectStorageRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsLargeObjectStorage UpdateEntity(gcsLargeObjectStorage entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.Uid, sessionData, null);
                entity.InsertDate = originalEntity.InsertDate;
                entity.InsertName = originalEntity.InsertName;
                gcsLargeObjectStoragePDSAManager mgr = new gcsLargeObjectStoragePDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.Uid) > 0)
                {
                    // must read the original record from the database so the PDSA object can detect changes

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.Uid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.Uid} not found");

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLargeObjectStorageRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsLargeObjectStorage entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsLargeObjectStoragePDSAManager mgr = new gcsLargeObjectStoragePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.Uid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLargeObjectStorageRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsLargeObjectStoragePDSAManager mgr = new gcsLargeObjectStoragePDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id);
                // must read the original record from the database so the PDSA object can detect changes
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLargeObjectStorageRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsLargeObjectStorage> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsLargeObjectStoragePDSAManager mgr = new gcsLargeObjectStoragePDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (gcsLargeObjectStorage entity in entities)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLargeObjectStorageRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsLargeObjectStorage> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsLargeObjectStorage GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsLargeObjectStorage GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsLargeObjectStoragePDSAManager mgr = new gcsLargeObjectStoragePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsLargeObjectStorage result = new gcsLargeObjectStorage();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLargeObjectStorageRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData,
            gcsLargeObjectStorage originalEntity, gcsLargeObjectStorage newEntity, string auditXml)
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
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        List<String> propertiesToIgnore = new List<string>(); propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        propertiesToIgnore.Add("UserSettings");
                        propertiesToIgnore.Add("EntityApplications");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "Uid";
                        mgr.Entity.PrimaryKeyValue = newEntity.Uid;
                        mgr.Entity.RecordTag = newEntity.UniqueTag;
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
                            SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity, propertiesToIgnore);
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
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "Uid";
                        mgr.Entity.PrimaryKeyValue = newEntity.Uid;
                        mgr.Entity.RecordTag = newEntity.UniqueTag;
mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "Uid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.Uid;
                        mgr.Entity.RecordTag = originalEntity.UniqueTag;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLargeObjectStorageRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsLargeObjectStorage entity,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }


        public gcsLargeObjectStorage GetForEntityAndUniqueTag(Guid entityId, string uniqueTag, IApplicationUserSessionDataHeader sessionData)
        {   // This collection will only include applications which are authorized for use by the entity.
            // each gcsLargeObjectStorage will only include those gcsRoles (AllRoles) which are authorized for use by the entity
            try
            {
                gcsLargeObjectStoragePDSAManager mgr = new gcsLargeObjectStoragePDSAManager();
                mgr.DataObject.SelectFilter = gcsLargeObjectStoragePDSAData.SelectFilters.ByEntityIdAndUniqueTag;
                mgr.Entity.EntityId = entityId;
                mgr.Entity.UniqueTag = uniqueTag;

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities.FirstOrDefault();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLargeObjectStorageRepository::GetAllForEntity", ex);
                throw;
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsLargeObjectStorage", "Uid", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid id)
        {
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsLargeObjectStorage", "Uid", id);
            if (count == 0)
                return true;
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsLargeObjectStorage obj)
        {
            var mgr = new gcs_IsLargeObjectStorageUniquePDSAManager();
            mgr.Entity.Uid = obj.Uid;
            mgr.Entity.EntityId = obj.EntityId.Value;
            mgr.Entity.UniqueTag = obj.UniqueTag;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsLargeObjectStorage", "Uid", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }
    }
}