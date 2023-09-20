using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.BusinessClasses;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Config;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using GCS.Framework.Security;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsEntityIdProducerRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsEntityIdProducerRepository : DataRepositoryBase<gcsEntityIdProducer>, IGcsEntityIdProducerRepository
    {
        public GcsEntityIdProducerRepository()
        {
        }


        protected override gcsEntityIdProducer AddEntity(gcsEntityIdProducer entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId == Guid.Empty)
                    entity.EntityId = GuidUtilities.GenerateComb();

                var pwd = GCS.Framework.Security.Crypto.Encrypt(entity.idProducerPassword, entity.EntityId.ToString());
                entity.idProducerPassword = pwd;
                gcsEntityIdProducerPDSAManager mgr = new gcsEntityIdProducerPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.EntityId, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true });
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityIdProducerRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsEntityIdProducer UpdateEntity(gcsEntityIdProducer entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.EntityId, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false });
                gcsEntityIdProducerPDSAManager mgr = new gcsEntityIdProducerPDSAManager();

                var pwd = GCS.Framework.Security.Crypto.Encrypt(entity.idProducerPassword, entity.EntityId.ToString());
                entity.idProducerPassword = pwd;

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.EntityId) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.EntityId, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true });
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.EntityId} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityIdProducerRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsEntityIdProducer entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsEntityIdProducerPDSAManager mgr = new gcsEntityIdProducerPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.EntityId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityIdProducerRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false });
                gcsEntityIdProducerPDSAManager mgr = new gcsEntityIdProducerPDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id); // must read the original record from the database so the PDSA object can detect changes
                if (rowsLoaded == 1 && originalEntity != null)
                {
                    rowsDeleted = mgr.DataObject.DeleteByPK(id);
                    if (rowsDeleted > 0)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Delete, sessionData, originalEntity, null,
                            mgr.DataObject.AuditRowAsXml);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityIdProducerRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsEntityIdProducer> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsEntityIdProducerPDSAManager mgr = new gcsEntityIdProducerPDSAManager();

                if (getParameters?.Options?.Count > 0)
                {
                    var buildAsTree = getParameters.Options.Where(o => o.Key == GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure).FirstOrDefault();
                    if (buildAsTree.Value == true)
                    {
                        mgr.DataObject.SelectFilter = DataLayer.gcsEntityIdProducerPDSAData.SelectFilters.All;
                    }
                }

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);

                    foreach (gcsEntityIdProducer entity in entities)
                    {
                        var pwd = GCS.Framework.Security.Crypto.Decrypt(entity.idProducerPassword, entity.EntityId.ToString());
                        entity.idProducerPassword = pwd;
                        FillMemberCollections(entity, sessionData, getParameters);
                    }
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityIdProducerRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsEntityIdProducer> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsEntityIdProducer GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsEntityIdProducer GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsEntityIdProducerPDSAManager mgr = new gcsEntityIdProducerPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsEntityIdProducer result = new gcsEntityIdProducer();
                    var bPasswordIsEncrypted = GCS.Framework.Security.Crypto.IsEncrypted(mgr.Entity.idProducerPassword);
                    var pwd = GCS.Framework.Security.Crypto.Decrypt(mgr.Entity.idProducerPassword, mgr.Entity.EntityId.ToString());
                    mgr.Entity.idProducerPassword = pwd;
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    FillMemberCollections(result, sessionData, getParameters);
                    if (!bPasswordIsEncrypted)
                    {
                        mgr.Entity.idProducerPassword = GCS.Framework.Security.Crypto.Encrypt(mgr.Entity.idProducerPassword, mgr.Entity.EntityId.ToString());
                        int rowsUpdated = mgr.DataObject.Update();
                    }
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityIdProducerRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        public gcsEntityIdProducer GetByIdProducerSubscriptionId(int subscriptionId, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsEntityIdProducerPDSAManager mgr = new gcsEntityIdProducerPDSAManager();
                mgr.DataObject.SelectFilter = gcsEntityIdProducerPDSAData.SelectFilters.BySubscriptionId;
                mgr.Entity.SubscriptionId = subscriptionId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    if (pdsaEntities.Count == 1)
                    {
                        var pwd = GCS.Framework.Security.Crypto.Decrypt(pdsaEntities[0].idProducerPassword, pdsaEntities[0].EntityId.ToString());
                        pdsaEntities[0].idProducerPassword = pwd;
                        gcsEntityIdProducer result = new gcsEntityIdProducer();
                        SimpleMapper.PropertyMap(pdsaEntities[0], result);
                        return result;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityIdProducerRepository::GetEntityByGuidId", ex);
                throw;
            }

        }

        public gcsEntityIdProducer GetByPersonUid(Guid personUid, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsEntityIdProducerPDSAManager mgr = new gcsEntityIdProducerPDSAManager();
                mgr.DataObject.SelectFilter = gcsEntityIdProducerPDSAData.SelectFilters.ByPersonUid;
                mgr.Entity.PersonUid = personUid;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    if (pdsaEntities.Count == 1)
                    {
                        var pwd = GCS.Framework.Security.Crypto.Decrypt(pdsaEntities[0].idProducerPassword, pdsaEntities[0].EntityId.ToString());
                        pdsaEntities[0].idProducerPassword = pwd;
                        gcsEntityIdProducer result = new gcsEntityIdProducer();
                        SimpleMapper.PropertyMap(pdsaEntities[0], result);
                        return result;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityIdProducerRepository::GetEntityByGuidId", ex);
                throw;
            }

        }


        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsEntityIdProducer originalEntity, gcsEntityIdProducer newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "EntityId";
                        mgr.Entity.PrimaryKeyValue = newEntity.EntityId;
                        mgr.Entity.RecordTag = newEntity.Url;
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
                        mgr.Entity.PrimaryKeyColumn = "EntityId";
                        mgr.Entity.PrimaryKeyValue = newEntity.EntityId;
                        mgr.Entity.RecordTag = newEntity.Url;
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
                        mgr.Entity.PrimaryKeyColumn = "EntityId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.EntityId;
                        mgr.Entity.RecordTag = originalEntity.Url;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityIdProducerRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsEntityIdProducer entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                return;
        }

        protected override bool IsEntityReferenced(Guid entityId)
        {

            //int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsEntityIdProducer", "EntityId", entityId);
            //if (count == 0)
            //    return false;
            return true;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid entityId)
        {
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsEntityIdProducer", "EntityId", entityId);
            if (count == 0)
                return true;
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsEntityIdProducer entity)
        {
            var mgr = new IsgcsEntityIdProducerUniquePDSAManager();
            mgr.Entity.EntityId = entity.EntityId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsEntityIdProducer", "EntityId", id);
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
    }
}
