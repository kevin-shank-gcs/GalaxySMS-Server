using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Reflection;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsApplicationAuditRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsApplicationAuditRepository : DataRepositoryBase<gcsApplicationAudit>, IGcsApplicationAuditRepository
    {
        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new gcsApplicationAuditPDSAManager();

                // PDSA Audit Tracking setup phase
                var rowsLoaded = mgr.DataObject.LoadByPK(id);
                // must read the original record from the database so the PDSA object can detect changes
                if (rowsLoaded == 1 && originalEntity != null)
                {
                    var rowsDeleted = mgr.DataObject.DeleteByPK(id);
                    if (rowsDeleted > 0)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Delete, sessionData, originalEntity, null,
                            mgr.DataObject.AuditRowAsXml);
                    }
                    return rowsDeleted;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationAuditRepository::Remove", ex);
                throw;
            }
            return 0;
        }

        public void InsertEntity(gcsApplicationAudit entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new gcsApplicationAuditPDSA_InsertPDSAManager();
                mgr.Entity.AuditId = entity.AuditId;
                mgr.Entity.ApplicationAuditTypeId = entity.ApplicationAuditTypeId;
                mgr.Entity.TransactionId = entity.TransactionId;
                mgr.Entity.ApplicationId = entity.ApplicationId;
                mgr.Entity.UserId = entity.UserId;
                mgr.Entity.ApplicationName = entity.ApplicationName;
                mgr.Entity.ApplicationVersion = entity.ApplicationVersion;
                mgr.Entity.MachineName = entity.MachineName;
                mgr.Entity.LoginName = entity.LoginName;
                mgr.Entity.WindowsUserName = entity.WindowsUserName;
                mgr.Entity.AuditDetails = entity.AuditDetails;
                mgr.Entity.AuditXml = entity.AuditXml;
                mgr.Entity.InsertName = entity.InsertName;
                mgr.Entity.InsertDate = entity.InsertDate;
                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                var dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationAuditRepository::InsertEntity", ex);
                throw;
            }
        }

        protected override gcsApplicationAudit AddEntity(gcsApplicationAudit entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new gcsApplicationAuditPDSAManager();
                mgr.InitEntityObject(entity);
                var rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.AuditId, sessionData, null);
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
                var dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationAuditRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsApplicationAudit UpdateEntity(gcsApplicationAudit entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.AuditId, sessionData, null);
                var mgr = new gcsApplicationAuditPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.AuditId);
                // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                var rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.AuditId, sessionData, null);
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                        mgr.DataObject.AuditRowAsXml);
                    return updatedEntity;
                }
                return entity;
            }
            catch (PDSAValidationException ex)
            {
                var dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationAuditRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsApplicationAudit entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new gcsApplicationAuditPDSAManager();
                mgr.InitEntityObject(entity);
                var rowsDeleted = mgr.DataObject.DeleteByPK(entity.AuditId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationAuditRepository::DeleteEntity", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsApplicationAudit> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new gcsApplicationAuditPDSAManager();

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
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationAuditRepository::GetEntities", ex);
                throw;
            }
        }
        protected override IEnumerable<gcsApplicationAudit> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsApplicationAudit GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsApplicationAudit GetEntityByGuidId(Guid guid,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new gcsApplicationAuditPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    var result = new gcsApplicationAudit();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    FillMemberCollections(result, sessionData, getParameters);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationAuditRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData,
            gcsApplicationAudit originalEntity, gcsApplicationAudit newEntity, string auditXml)
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
                                ReflectionExtensions.GetFullMethodName(MethodBase.GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(MethodBase.GetCurrentMethod()));

                        var propertiesToIgnore = new List<string>(); propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "AuditId";
                        mgr.Entity.PrimaryKeyValue = newEntity.AuditId;
                        mgr.Entity.RecordTag = newEntity.ApplicationName;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;

                        if (string.IsNullOrEmpty(auditXml) == false)
                        {
                            mgr.Entity.AuditXml = auditXml;
                            mgr.Execute();
                        }


                        mgr.Entity.AuditXml = null;

                        var differences = SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity,
                            propertiesToIgnore);
                        foreach (var property in differences.PropertyChanges)
                        {
                            //System.Diagnostics.Trace.WriteLine(property.ToString());
                            mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                            mgr.Entity.ColumnName = property.Value.PropertyName;
                            if (property.Value.PropertyType == typeof(byte[]))
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
                                ReflectionExtensions.GetFullMethodName(MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "AuditId";
                        mgr.Entity.PrimaryKeyValue = newEntity.AuditId;
                        mgr.Entity.RecordTag = newEntity.ApplicationName;
mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "AuditId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AuditId;
                        mgr.Entity.RecordTag = originalEntity.ApplicationName;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationAuditRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsApplicationAudit entity,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }

        protected override bool IsEntityReferenced(Guid entityId)
        {
            var applicationAuditCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue(
                "gcsApplicationAudit", "AuditId", entityId);

            if (applicationAuditCount != 0)
                return true;

            var count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsApplicationAudit", "AuditId",
                entityId);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid entityId)
        {
            var count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsApplicationAudit", "AuditId", entityId);
            if (count == 0)
                return true;
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsApplicationAudit entity)
        {
            //gcs_IsEntityUniquePDSAManager mgr = new gcs_IsEntityUniquePDSAManager();
            //mgr.Entity.EntityId = entity.EntityId;
            //mgr.Entity.EntityName = entity.EntityName;
            //mgr.BuildCollection();


            //if (Convert.ToInt32(mgr.Entity.Result) == 0)
            //    return true;
            //return false;
            return true;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            var count = GalaxySMSDatabaseManager.DoesRowExist("gcsApplicationAudit", "AuditId", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }

        public RowReferenceResult[] GetReferencingRows(Guid entityId)
        {
            return null;
        }

        public gcsApplicationAudit CreateApplicationAuditInstance(IApplicationUserSessionDataHeader sessionData)
        {
            var applicationAudit = new gcsApplicationAudit();
            applicationAudit.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
            applicationAudit.TransactionId = sessionData.OperationGuid;
            applicationAudit.ApplicationId = sessionData.ApplicationId;
            applicationAudit.ApplicationName = sessionData.ApplicationName;
            applicationAudit.ApplicationVersion = sessionData.ApplicationVersion;
            applicationAudit.UserId = Guid.Empty;
            applicationAudit.WindowsUserName = sessionData.UserName;
            applicationAudit.MachineName = sessionData.MachineName;
            applicationAudit.InsertDate = DateTimeOffset.Now;
            applicationAudit.InsertName = sessionData.UserName;
            return applicationAudit;
        }
    }
}