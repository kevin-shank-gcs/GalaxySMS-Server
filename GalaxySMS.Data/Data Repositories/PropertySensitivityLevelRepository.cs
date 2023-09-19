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

namespace GalaxySMS.Data
{
    [Export(typeof(IPropertySensitivityLevelRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PropertySensitivityLevelRepository : DataRepositoryBase<PropertySensitivityLevel>, IPropertySensitivityLevelRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import]
        private IDataRepositoryFactory _DataRepositoryFactory;

        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        protected override PropertySensitivityLevel AddEntity(PropertySensitivityLevel entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var mgr = new PropertySensitivityLevelPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveChildren(sessionData, entity, saveParams);
                    var result = GetEntityByGuidId(entity.PropertySensitivityLevelUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PropertySensitivityLevelRepository::AddEntity", ex);
                throw;
            }
        }

        protected override PropertySensitivityLevel UpdateEntity(PropertySensitivityLevel entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.PropertySensitivityLevelUid, sessionData, null);
                var mgr = new PropertySensitivityLevelPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.PropertySensitivityLevelUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);

                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    SaveChildren(sessionData, entity, saveParams);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.PropertySensitivityLevelUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PropertySensitivityLevelRepository::UpdateEntity", ex);
                throw;
            }
        }


        private void SaveChildren(IApplicationUserSessionDataHeader sessionData, PropertySensitivityLevel entity, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.PropertySensitivityLevelPermissions)))
            {
                foreach (var p in entity.PropertySensitivityLevelPermissions.Where(i => i.IsDirty == true).ToList())
                {
                    var repo = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelPermissionRepository>();
                    p.PropertySensitivityLevelUid = entity.PropertySensitivityLevelUid;
                    var existing = repo.GetPropertySensitivityLevelPermissionBySensitivityLevelUidAndPermissionId(sessionData,
                        new GetParametersWithPhoto()
                        {
                            UniqueId = p.PropertySensitivityLevelUid,
                            GetGuid = p.PermissionId
                        });
                    UpdateTableEntityBaseProperties(p, sessionData);
                    if (existing == null)
                    {
                        repo.Add(p, sessionData, saveParams);
                    }
                    else
                    {
                        UpdateTableEntityBasePropertiesFromExisting(p, existing);
                        repo.Update(p, sessionData, saveParams);
                    }
                }
            }
        }



        protected override int DeleteEntity(PropertySensitivityLevel entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new PropertySensitivityLevelPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.PropertySensitivityLevelUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PropertySensitivityLevelRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new PropertySensitivityLevelPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PropertySensitivityLevelRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<PropertySensitivityLevel> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PropertySensitivityLevelPDSAManager();
                mgr.DataObject.SelectFilter = PropertySensitivityLevelPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PropertySensitivityLevelRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<PropertySensitivityLevel> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, PropertySensitivityLevelPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (PropertySensitivityLevel entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<PropertySensitivityLevel> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PropertySensitivityLevelPDSAManager();
                mgr.DataObject.SelectFilter = PropertySensitivityLevelPDSAData.SelectFilters.AllByCultureName;
                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PropertySensitivityLevelRepository::GetAllEntities", ex);
                throw;
            }
        }

        protected override PropertySensitivityLevel GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override PropertySensitivityLevel GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PropertySensitivityLevelPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    PropertySensitivityLevel result = new PropertySensitivityLevel();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PropertySensitivityLevelRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, PropertySensitivityLevel originalEntity, PropertySensitivityLevel newEntity, string auditXml)
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
                        propertiesToIgnore.Add("PropertySensitivityLevelPermissions");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "PropertySensitivityLevelUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.PropertySensitivityLevelUid;
                        mgr.Entity.RecordTag = newEntity.PropertySensitivityLevelUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "PropertySensitivityLevelUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.PropertySensitivityLevelUid;
                        mgr.Entity.RecordTag = newEntity.PropertySensitivityLevelUid.ToString(); 
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
                        mgr.Entity.PrimaryKeyColumn = "PropertySensitivityLevelUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.PropertySensitivityLevelUid;
                        mgr.Entity.RecordTag = originalEntity.PropertySensitivityLevelUid.ToString(); 
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PropertySensitivityLevelRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(PropertySensitivityLevel entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                getParameters = new GetParametersWithPhoto() { UniqueId = entity.PropertySensitivityLevelUid };


            var permissionRepo = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelPermissionRepository>();
            getParameters.UniqueId = entity.PropertySensitivityLevelUid;
            entity.PropertySensitivityLevelPermissions = permissionRepo.GetAllPropertySensitivityLevelPermissionForSensitivityLevel(sessionData, getParameters).ToCollection();
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("PropertySensitivityLevel", "PropertySensitivityLevelUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("PropertySensitivityLevel", "PropertySensitivityLevelUid", id);
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

        protected override bool IsEntityUnique(PropertySensitivityLevel entity)
        {
            var mgr = new IsPropertySensitivityLevelUniquePDSAManager();
            mgr.Entity.PropertySensitivityLevelUid = entity.PropertySensitivityLevelUid;
            mgr.Entity.Display = entity.Display;
            mgr.Entity.SensitivityLevel = (short)entity.SensitivityLevel;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("PropertySensitivityLevel", "PropertySensitivityLevelUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("PropertySensitivityLevel", "PropertySensitivityLevelUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
