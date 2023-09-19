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
    [Export(typeof(IGcsResourceStringLanguageRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsResourceStringLanguageRepository : DataRepositoryBase<gcsResourceStringLanguage>, IGcsResourceStringLanguageRepository
    {
        [Import]
        private IGcsLanguageRepository _languageRepository;

        //public gcsResourceStringLanguage SaveResourceStringLanguage(gcsResourceStringLanguage resource, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    if (resource == null)
        //        return null;
        //    resource.UpdateDate = DateTimeOffset.Now;
        //    resource.UpdateName = sessionData.UserName;

        //    if (resource.ResourceStringLanguageId != Guid.Empty)
        //    {
        //        if (DoesExist(resource.ResourceStringLanguageId))
        //        {
        //            //var existingResource = Get(resource.ResourceId, sessionData, null);
        //            //if (existingResource != null && existingResource.ResourceName == resource.ResourceName)
        //            //    return existingResource;
        //            return Update(resource, sessionData);
        //        }
        //    }
        //    else
        //    {
        //        resource.ResourceStringLanguageId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
        //    }

        //    if( resource.LanguageId == Guid.Empty)
        //    {
        //        var lang = _languageRepository.GetLanguageByCultureName(sessionData.Culture);
        //        if( lang != null)
        //            resource.LanguageId = lang.LanguageId;
        //    }

        //    if (IsUnique(resource) == false)
        //        return this.GetByResourceIdLanguageId(resource.ResourceId,resource.LanguageId, sessionData).FirstOrDefault();

        //    resource.InsertDate = DateTimeOffset.Now;
        //    resource.InsertName = sessionData.UserName;
        //    var savedResource = Add(resource, sessionData);
        //    return savedResource;
        //}

        public gcsResourceStringLanguage SaveResourceStringLanguage(gcsResourceStringLanguage resource, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (resource == null)
                return null;

            if (resource.LanguageId == Guid.Empty)
            {
                var lang = _languageRepository.GetLanguageByCultureName(sessionData.Culture);
                if (lang != null)
                    resource.LanguageId = lang.LanguageId;
                else
                {
                    int x = 0;

                }
            }

            var existingResource = this.GetByResourceIdLanguageId(resource.ResourceId, resource.LanguageId, sessionData).FirstOrDefault();
            if (existingResource != null)
            {
                resource.ResourceStringLanguageId = existingResource.ResourceStringLanguageId;
                UpdateTableEntityBaseProperties(resource, sessionData);
                resource.ConcurrencyValue = existingResource.ConcurrencyValue;
            }

            if (resource.ResourceStringLanguageId != Guid.Empty)
            {
                if (DoesExist(resource.ResourceStringLanguageId))
                {
                    UpdateTableEntityBaseProperties(resource, sessionData);
                    return Update(resource, sessionData, saveParams);
                }
            }
            else
            {
                resource.ResourceStringLanguageId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
            }

            if (IsUnique(resource) == false)
                return existingResource;
            UpdateTableEntityBaseProperties(resource, sessionData);
            var savedResource = Add(resource, sessionData, saveParams);
            return savedResource;
        }

        protected override gcsResourceStringLanguage AddEntity(gcsResourceStringLanguage entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                gcsResourceStringLanguagePDSAManager mgr = new gcsResourceStringLanguagePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.ResourceStringLanguageId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsResourceStringLanguage UpdateEntity(gcsResourceStringLanguage entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.ResourceStringLanguageId, sessionData, null);
                gcsResourceStringLanguagePDSAManager mgr = new gcsResourceStringLanguagePDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.ResourceStringLanguageId); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.ResourceStringLanguageId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsResourceStringLanguage entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsResourceStringLanguagePDSAManager mgr = new gcsResourceStringLanguagePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.ResourceStringLanguageId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsResourceStringLanguagePDSAManager mgr = new gcsResourceStringLanguagePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsResourceStringLanguage> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsResourceStringLanguagePDSAManager mgr = new gcsResourceStringLanguagePDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsResourceStringLanguage> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsResourceStringLanguage GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsResourceStringLanguage GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsResourceStringLanguagePDSAManager mgr = new gcsResourceStringLanguagePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsResourceStringLanguage result = new gcsResourceStringLanguage();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsResourceStringLanguage originalEntity, gcsResourceStringLanguage newEntity, string auditXml)
        {
            try
            {
                if (!string.IsNullOrEmpty(auditXml))
                    auditXml = auditXml.EncodeForXml();
                var mgr = new gcsAudit_InsertPDSAManager();
                if (!string.IsNullOrEmpty(auditXml))
                    auditXml = auditXml.EncodeForXml();

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
                        propertiesToIgnore.Add("gcsUsers");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "ResourceStringLanguageId";
                        mgr.Entity.PrimaryKeyValue = newEntity.ResourceStringLanguageId;
                        mgr.Entity.RecordTag = newEntity.ResourceId.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "ResourceStringLanguageId";
                        mgr.Entity.PrimaryKeyValue = newEntity.ResourceStringLanguageId;
                        mgr.Entity.RecordTag = newEntity.ResourceId.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "ResourceStringLanguageId";
                        mgr.Entity.PrimaryKeyValue = newEntity.ResourceStringLanguageId;
                        mgr.Entity.RecordTag = originalEntity.ResourceId.ToString();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsResourceStringLanguage entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {

        }

        public IEnumerable<gcsResourceStringLanguage> GetAllForLanguageId(Guid languageId, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsResourceStringLanguagePDSAManager mgr = new gcsResourceStringLanguagePDSAManager();
                mgr.DataObject.SelectFilter = gcsResourceStringLanguagePDSAData.SelectFilters.ByLanguageId;
                mgr.DataObject.Entity.LanguageId = languageId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::GetAllForLanguageId", ex);
                throw;
            }
        }

        public IEnumerable<gcsResourceStringLanguage> GetAllForCultureName(string cultureName, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsResourceStringLanguagePDSAManager mgr = new gcsResourceStringLanguagePDSAManager();
                mgr.DataObject.SelectFilter = gcsResourceStringLanguagePDSAData.SelectFilters.ByCultureName;
                mgr.DataObject.Entity.CultureName = cultureName;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::GetAllForCultureName", ex);
                throw;
            }
        }

        public IEnumerable<gcsResourceStringLanguage> GetByResourceIdLanguageId(Guid resourceId, Guid languageId, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsResourceStringLanguagePDSAManager mgr = new gcsResourceStringLanguagePDSAManager();
                mgr.DataObject.SelectFilter = gcsResourceStringLanguagePDSAData.SelectFilters.ByResourceIdLanguageId;
                mgr.DataObject.Entity.ResourceId = resourceId;
                mgr.DataObject.Entity.LanguageId = languageId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::GetAllForCultureName", ex);
                throw;
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsResourceStringLanguage", "ResourceStringLanguageId", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsResourceStringLanguage", "ResourceStringLanguageId", id);
            if (count == 0)
                return true;
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsResourceStringLanguage language)
        {
            var mgr = new gcs_IsResourceStringLanguageUniquePDSAManager();
            mgr.Entity.ResourceStringLanguageId = language.ResourceStringLanguageId;
            mgr.Entity.LanguageId = language.LanguageId;
            mgr.Entity.ResourceId = language.ResourceId;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsResourceStringLanguage", "ResourceStringLanguageId", id);
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
