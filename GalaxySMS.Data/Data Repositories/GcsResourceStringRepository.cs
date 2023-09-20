using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
    [Export(typeof(IGcsResourceStringRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsResourceStringRepository : DataRepositoryBase<gcsResourceString>, IGcsResourceStringRepository
    {
        [Import]
        private IGcsResourceStringLanguageRepository _resourceStringLanguageRepository;

        public gcsResourceString GetByResourceName(string resourceName, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new gcsResourceStringPDSAManager();
                mgr.DataObject.SelectFilter = DataLayer.gcsResourceStringPDSAData.SelectFilters.Search;
                mgr.DataObject.Entity.ResourceName = resourceName;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    if (entities != null && entities.Count() == 1)
                        return entities.ToList()[0];
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AddressRepository::GetEntities", ex);
                throw;
            }

        }

        public IHasDisplayResourceKey SaveDisplayResource(IHasDisplayResourceKey entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //if (entity == null || string.IsNullOrEmpty(entity.Display))
            //    return null;

            gcsResourceString resourceString = null;

            if (entity.DisplayResourceKey != null && entity.DisplayResourceKey.Value != Guid.Empty)
                resourceString = Get(entity.DisplayResourceKey.Value, sessionData, null);

            if (resourceString == null)
            {
                resourceString = new gcsResourceString();
            }

            if (string.IsNullOrEmpty(resourceString.ResourceClassName))
                resourceString.ResourceClassName = entity.ResourceClassName;

            if (string.IsNullOrEmpty(resourceString.ResourceName))
            {
                if (string.IsNullOrEmpty(entity.DisplayResourceName))
                    resourceString.ResourceName = string.Format("{0}_{1}_DisplayResourceName",
                        entity.ResourceClassName,
                        entity.UniqueResourceName);
                else
                    resourceString.ResourceName = string.Format("{0}_{1}_{2}",
                        entity.ResourceClassName,
                        entity.UniqueResourceName,
                        entity.DisplayResourceName);
            }

            if (resourceString.ResourceName.Length > 255)
                resourceString.ResourceName = resourceString.ResourceName.Truncate(255);

            resourceString.DefaultValue = entity.Display;

            //if( string.IsNullOrEmpty(resourceString.DefaultValue))
            //    Trace.WriteLine("empty");

            var savedResourceString = SaveResourceString(resourceString, sessionData, saveParams);
            if ((savedResourceString != null && entity.DisplayResourceKey == null) ||
                (savedResourceString.ResourceId != entity.DisplayResourceKey.Value))
                entity.DisplayResourceKey = savedResourceString.ResourceId;
            return entity;
        }

        public IHasDescriptionResourceKey SaveDescriptionResource(IHasDescriptionResourceKey entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //if (entity == null || string.IsNullOrEmpty(entity.Description))
            //    return null;
            gcsResourceString resourceString = null;

            if (entity.DescriptionResourceKey != null && entity.DescriptionResourceKey.Value != Guid.Empty)
                resourceString = Get(entity.DescriptionResourceKey.Value, sessionData, null);

            if (resourceString == null)
                resourceString = new gcsResourceString();

            if (string.IsNullOrEmpty(resourceString.ResourceClassName))
                resourceString.ResourceClassName = entity.ResourceClassName;

            if (string.IsNullOrEmpty(resourceString.ResourceName))
            {
                var suffix = "DescriptionResourceName";

                if (string.IsNullOrEmpty(entity.DescriptionResourceName))
                {
                    resourceString.ResourceName = string.Format("{0}_{1}_{2}",
                        entity.ResourceClassName,
                        entity.UniqueResourceName,
                        suffix);
                }
                else
                {
                    resourceString.ResourceName = string.Format("{0}_{1}_{2}",
                        entity.ResourceClassName,
                        entity.UniqueResourceName,
                        entity.DescriptionResourceName);
                }
            }
            if (resourceString.ResourceName.Length > 255)
                resourceString.ResourceName = resourceString.ResourceName.Truncate(255);

            resourceString.DefaultValue = entity.Description;

            var savedResourceString = SaveResourceString(resourceString, sessionData, saveParams);
            if ((savedResourceString != null && entity.DescriptionResourceKey == null) ||
                (savedResourceString.ResourceId != entity.DescriptionResourceKey.Value))
                entity.DescriptionResourceKey = savedResourceString.ResourceId;
            return entity;
        }

        public gcsResourceString SaveResourceString(gcsResourceString resource, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (resource == null)
                return null;

            UpdateTableEntityBaseProperties(resource, sessionData);

            if (resource.ResourceId != Guid.Empty)
            {
                if (DoesExist(resource.ResourceId))
                {
                    _resourceStringLanguageRepository.SaveResourceStringLanguage(
                        new gcsResourceStringLanguage() { ResourceId = resource.ResourceId, StringValue = resource.DefaultValue }, sessionData, saveParams);

                    if (sessionData.Culture.ToLower() == "en-us")
                    {
                        var updatedResource = Update(resource, sessionData, saveParams);

                        return updatedResource;

                    }
                    return resource;
                }
            }
            else
            {
                resource.ResourceId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
            }

            if (IsUnique(resource) == false)
                return GetByResourceName(resource.ResourceName, sessionData);

            var savedResource = Add(resource, sessionData, saveParams);
            _resourceStringLanguageRepository.SaveResourceStringLanguage(
                new gcsResourceStringLanguage() { ResourceId = resource.ResourceId, StringValue = resource.DefaultValue }, sessionData, saveParams);
            return savedResource;
        }

        protected override gcsResourceString AddEntity(gcsResourceString entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new gcsResourceStringPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.ResourceId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//gcsResourceStringRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsResourceString UpdateEntity(gcsResourceString entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.ResourceId, sessionData, null);
                var mgr = new gcsResourceStringPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.ResourceId); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.ResourceId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//gcsResourceStringRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsResourceString entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new gcsResourceStringPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.ResourceId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//gcsResourceStringRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new gcsResourceStringPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//gcsResourceStringRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsResourceString> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new gcsResourceStringPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//gcsResourceStringRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsResourceString> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsResourceString GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsResourceString GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new gcsResourceStringPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    var result = new gcsResourceString();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    FillMemberCollections(result, sessionData, getParameters);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//gcsResourceStringRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsResourceString originalEntity, gcsResourceString newEntity, string auditXml)
        {
            try
            {
                //                auditXml = auditXml.EncodeForXml();
                if (!string.IsNullOrEmpty(auditXml))
                    auditXml = auditXml.EncodeForXml(); if (!string.IsNullOrEmpty(auditXml))
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
                        mgr.Entity.PrimaryKeyColumn = "ResourceId";
                        mgr.Entity.PrimaryKeyValue = newEntity.ResourceId;
                        mgr.Entity.RecordTag = newEntity.ResourceName;
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
                        mgr.Entity.PrimaryKeyColumn = "ResourceId";
                        mgr.Entity.PrimaryKeyValue = newEntity.ResourceId;
                        mgr.Entity.RecordTag = newEntity.ResourceName;
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
                        mgr.Entity.PrimaryKeyColumn = "ResourceId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.ResourceId;
                        mgr.Entity.RecordTag = originalEntity.ResourceName;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//gcsResourceStringRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsResourceString entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }

        protected override bool IsEntityReferenced(Guid entityId)
        {

            int applicationAuditCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("gcsApplicationAudit", "ResourceId", entityId);

            if (applicationAuditCount != 0)
                return true;

            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsResourceString", "ResourceId", entityId);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsResourceString", "ResourceId", entityId);
            if (count == 0)
                return true;
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsResourceString entity)
        {
            var mgr = new gcs_IsResourceStringUniquePDSAManager();
            mgr.Entity.ResourceId = entity.ResourceId;
            mgr.Entity.ResourceName = entity.ResourceName;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsResourceString", "ResourceId", id);
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
