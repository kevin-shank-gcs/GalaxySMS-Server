using System;
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
using GCS.Core.Common.Config;
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
    [Export(typeof(IGcsBinaryResourceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsBinaryResourceRepository : DataRepositoryBase<gcsBinaryResource>, IGcsBinaryResourceRepository
    {

        public IHasBinaryResource SaveBinaryResource(IHasBinaryResource entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (saveParams.SavePhoto && entity?.gcsBinaryResource?.HasBeenModified == true)
            {
                if (entity.gcsBinaryResource?.BinaryResource != null &&
                    entity.gcsBinaryResource.BinaryResource.Length > 0)
                {   // if the BinaryResource contains data, then save the record
                    if (string.IsNullOrEmpty(entity.gcsBinaryResource.DataType))
                        entity.gcsBinaryResource.DataType = "Image";

                    if (string.IsNullOrEmpty(entity.gcsBinaryResource.Category))
                        entity.gcsBinaryResource.Category = entity.GetType().FullName;

                    if (string.IsNullOrEmpty(entity.gcsBinaryResource.Tag))
                        entity.gcsBinaryResource.Tag = entity.Name;

                    var savedBinaryResource = SaveBinaryResource(entity.gcsBinaryResource, sessionData, saveParams);
                    if (savedBinaryResource != null &&
                        savedBinaryResource.BinaryResourceUid != entity.BinaryResourceUid)
                        entity.BinaryResourceUid = savedBinaryResource.BinaryResourceUid;
                }
                else
                {   // if binary resource contains no data, then delete the record
                    var ret = DeleteEntity(entity.gcsBinaryResource, sessionData);
                    if (ret == 1)
                        entity.BinaryResourceUid = null;
                }
            }
            return entity;
        }

        public gcsBinaryResource SaveBinaryResource(gcsBinaryResource resource, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (resource == null)
                return null;
            resource.UpdateDate = DateTimeOffset.Now;
            resource.UpdateName = sessionData.UserName;

            if (resource.BinaryResourceUid != Guid.Empty)
            {
                if (DoesExist(resource.BinaryResourceUid))
                {
                    return Update(resource, sessionData, saveParams);
                }
            }
            else
            {
                resource.BinaryResourceUid = GuidUtilities.GenerateComb(); // Guid.NewGuid();
            }

            resource.InsertDate = DateTimeOffset.Now;
            resource.InsertName = sessionData.UserName;
            return Add(resource, sessionData, saveParams);
        }

        protected override gcsBinaryResource AddEntity(gcsBinaryResource entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new gcsBinaryResourcePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.BinaryResourceUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsBinaryResourceRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsBinaryResource UpdateEntity(gcsBinaryResource entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.BinaryResourceUid, sessionData, null);
                var mgr = new gcsBinaryResourcePDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.BinaryResourceUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.BinaryResourceUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"gcsBinaryResource not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsBinaryResourceRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsBinaryResource entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new gcsBinaryResourcePDSAManager();
                var origEntity = GetEntityByGuidId(entity.BinaryResourceUid, sessionData, null);
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.BinaryResourceUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, origEntity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsBinaryResourceRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new gcsBinaryResourcePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsBinaryResourceRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsBinaryResource> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new gcsBinaryResourcePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsBinaryResourceRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsBinaryResource> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsBinaryResource GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsBinaryResource GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new gcsBinaryResourcePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    var result = new gcsBinaryResource();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    FillMemberCollections(result, sessionData, getParameters);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsBinaryResourceRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsBinaryResource originalEntity, gcsBinaryResource newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "BinaryResourceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.BinaryResourceUid;
                        mgr.Entity.RecordTag = newEntity.Tag;
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
                        mgr.Entity.PrimaryKeyColumn = "BinaryResourceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.BinaryResourceUid;
                        mgr.Entity.RecordTag = newEntity.Tag;
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
                        mgr.Entity.PrimaryKeyColumn = "BinaryResourceUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.BinaryResourceUid;
                        mgr.Entity.RecordTag = originalEntity.Tag;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsBinaryResourceRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsBinaryResource entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters != null &&
                getParameters.IncludePhoto &&
                getParameters.PhotoPixelWidth > 0 && entity?.BinaryResource != null && entity.BinaryResource.Length > 0)
            {
                var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                    GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.BinaryResource), getParameters.PhotoPixelWidth);
                entity.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
            }
        }

        protected override bool IsEntityReferenced(Guid entityId)
        {

            int applicationAuditCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("gcsApplicationAudit", "BinaryResourceUid", entityId);

            if (applicationAuditCount != 0)
                return true;

            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsBinaryResource", "BinaryResourceUid", entityId);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsBinaryResource", "BinaryResourceUid", entityId);
            if (count == 0)
                return true;
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsBinaryResource entity)
        {
            var mgr = new gcs_IsBinaryResourceUniquePDSAManager();
            mgr.Entity.BinaryResourceUid = entity.BinaryResourceUid;
            mgr.Entity.Category = entity.Category;
            mgr.Entity.DataType = entity.DataType;
            mgr.Entity.Tag = entity.Tag;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsBinaryResource", "BinaryResourceUid", id);
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
