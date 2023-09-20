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
using GalaxySMS.Common.Enums;
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
    [Export(typeof(IUserDefinedPropertyRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserDefinedPropertyRepository : DataRepositoryBase<UserDefinedProperty>, IUserDefinedPropertyRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;


        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        [Import]
        private IDataRepositoryFactory _DataRepositoryFactory;

        protected override UserDefinedProperty AddEntity(UserDefinedProperty entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var mgr = new UserDefinedPropertyPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveChildren(sessionData, entity, saveParams);

                    var result = GetEntityByGuidId(entity.UserDefinedPropertyUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        protected override UserDefinedProperty UpdateEntity(UserDefinedProperty entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.UserDefinedPropertyUid, sessionData, null);
                var mgr = new UserDefinedPropertyPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.UserDefinedPropertyUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    SaveChildren(sessionData, entity, saveParams);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.UserDefinedPropertyUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        private void SaveChildren(IApplicationUserSessionDataHeader sessionData, UserDefinedProperty entity, ISaveParameters saveParams)
        {
            if (entity.UserDefinedTextPropertyRules != null && entity.UserDefinedTextPropertyRules.IsDirty)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedTextPropertyRulesRepository>();
                entity.UserDefinedTextPropertyRules.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
                var existing = repo.Get(entity.UserDefinedPropertyUid, sessionData, null);
                UpdateTableEntityBaseProperties(entity.UserDefinedTextPropertyRules, sessionData);
                if (existing == null)
                {
                    repo.Add(entity.UserDefinedTextPropertyRules, sessionData, saveParams);
                }
                else
                {
                    UpdateTableEntityBasePropertiesFromExisting(entity.UserDefinedTextPropertyRules, existing);
                    repo.Update(entity.UserDefinedTextPropertyRules, sessionData, saveParams);
                }
            }

            if (entity.UserDefinedGuidPropertyRules != null && entity.UserDefinedGuidPropertyRules.IsDirty)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedGuidPropertyRulesRepository>();
                entity.UserDefinedGuidPropertyRules.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
                var existing = repo.Get(entity.UserDefinedPropertyUid, sessionData, null);
                UpdateTableEntityBaseProperties(entity.UserDefinedGuidPropertyRules, sessionData);
                if (existing == null)
                {
                    repo.Add(entity.UserDefinedGuidPropertyRules, sessionData, saveParams);
                }
                else
                {
                    UpdateTableEntityBasePropertiesFromExisting(entity.UserDefinedGuidPropertyRules, existing);
                    repo.Update(entity.UserDefinedGuidPropertyRules, sessionData, saveParams);
                }
            }

            if (entity.UserDefinedNumberPropertyRules != null && entity.UserDefinedNumberPropertyRules.IsDirty)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedNumberPropertyRulesRepository>();
                entity.UserDefinedNumberPropertyRules.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
                var existing = repo.Get(entity.UserDefinedPropertyUid, sessionData, null);
                UpdateTableEntityBaseProperties(entity.UserDefinedNumberPropertyRules, sessionData);
                if (existing == null)
                {
                    repo.Add(entity.UserDefinedNumberPropertyRules, sessionData, saveParams);
                }
                else
                {
                    UpdateTableEntityBasePropertiesFromExisting(entity.UserDefinedTextPropertyRules, existing);
                    repo.Update(entity.UserDefinedNumberPropertyRules, sessionData, saveParams);
                }
            }

            if (entity.UserDefinedDatePropertyRules != null && entity.UserDefinedDatePropertyRules.IsDirty)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedDatePropertyRulesRepository>();
                entity.UserDefinedDatePropertyRules.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
                var existing = repo.Get(entity.UserDefinedPropertyUid, sessionData, null);
                UpdateTableEntityBaseProperties(entity.UserDefinedDatePropertyRules, sessionData);
                if (existing == null)
                {
                    repo.Add(entity.UserDefinedDatePropertyRules, sessionData, saveParams);
                }
                else
                {
                    UpdateTableEntityBasePropertiesFromExisting(entity.UserDefinedDatePropertyRules, existing);
                    repo.Update(entity.UserDefinedDatePropertyRules, sessionData, saveParams);
                }
            }

            if (entity.UserDefinedBooleanPropertyRules != null && entity.UserDefinedBooleanPropertyRules.IsDirty)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedBooleanPropertyRulesRepository>();
                entity.UserDefinedBooleanPropertyRules.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
                var existing = repo.Get(entity.UserDefinedPropertyUid, sessionData, null);
                UpdateTableEntityBaseProperties(entity.UserDefinedBooleanPropertyRules, sessionData);
                if (existing == null)
                {
                    repo.Add(entity.UserDefinedBooleanPropertyRules, sessionData, saveParams);
                }
                else
                {
                    UpdateTableEntityBasePropertiesFromExisting(entity.UserDefinedBooleanPropertyRules, existing);
                    repo.Update(entity.UserDefinedBooleanPropertyRules, sessionData, saveParams);
                }
            }

            if (entity.UserDefinedListPropertyRules != null && entity.UserDefinedListPropertyRules.IsDirty)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedListPropertyRulesRepository>();
                entity.UserDefinedListPropertyRules.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
                var existing = repo.Get(entity.UserDefinedPropertyUid, sessionData, null);
                UpdateTableEntityBaseProperties(entity.UserDefinedListPropertyRules, sessionData);
                if (existing == null)
                {
                    repo.Add(entity.UserDefinedListPropertyRules, sessionData, saveParams);
                }
                else
                {
                    UpdateTableEntityBasePropertiesFromExisting(entity.UserDefinedListPropertyRules, existing);
                    repo.Update(entity.UserDefinedListPropertyRules, sessionData, saveParams);
                }
            }

            foreach (var li in entity.UserDefinedListPropertyItems.Where(i => i.IsDirty == true).ToList())
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedListPropertyItemRepository>();
                li.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
                var existing = repo.GetByUserDefinedPropertyUidAndDisplay(sessionData, new GetParametersWithPhoto()
                {
                    UniqueId = li.UserDefinedPropertyUid,
                    GetString = li.Display
                });
                UpdateTableEntityBaseProperties(li, sessionData);
                if (existing == null)
                {
                    repo.Add(li, sessionData, saveParams);
                }
                else
                {
                    li.UserDefinedListPropertyItemUid = existing.UserDefinedListPropertyItemUid;
                    UpdateTableEntityBasePropertiesFromExisting(li, existing);
                    repo.Update(li, sessionData, saveParams);
                }
            }

            //foreach( var p in entity.UserDefinedPropertyPermissions.Where(i => i.IsDirty == true).ToList())
            //{
            //    var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedPropertyPermissionRepository>();
            //    p.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
            //    var existing = repo.GetUserDefinedPropertyPermissionByPropertyUidAndPermissionId(sessionData, 
            //        new GetParametersWithPhoto()
            //    {
            //        UniqueId = p.UserDefinedPropertyUid,
            //        GetGuid = p.PermissionId
            //    });
            //    UpdateTableEntityBaseProperties(p, sessionData);
            //    if (existing == null)
            //    {
            //        repo.Add(p, sessionData);
            //    }
            //    else
            //    {
            //        UpdateTableEntityBasePropertiesFromExisting(p, existing);
            //        repo.Update(p, sessionData);
            //    }

            //}
        }

        protected override int DeleteEntity(UserDefinedProperty entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new UserDefinedPropertyPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.UserDefinedPropertyUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new UserDefinedPropertyPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        //private IEnumerable<UserDefinedProperty> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, UserDefinedPropertyPDSAManager mgr)
        //{
        //    var pdsaEntities = mgr.BuildCollection();
        //    if (pdsaEntities != null)
        //    {
        //        var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //        foreach (var entity in entities)
        //        {
        //            if (getParameters == null || getParameters.IncludeMemberCollections)
        //                FillMemberCollections(entity, sessionData, getParameters);
        //        }
        //        return entities;
        //    }
        //    return null;
        //}
        private IEnumerable<UserDefinedProperty> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, UserDefinedPropertyPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                if (getParameters == null || getParameters.IncludeMemberCollections)
                {
                    var sensitivityLevelRepo = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelRepository>();
                    var sensitivityLevels = sensitivityLevelRepo.GetAll(sessionData, getParameters);

                    foreach (var entity in entities)
                    {
                        FillMemberCollections(entity, sessionData, getParameters);
                        entity.PropertySensitivityLevel = sensitivityLevels.FirstOrDefault(o => o.PropertySensitivityLevelUid == entity.PropertySensitivityLevelUid);
                    }
                }
                return entities;
            }
            return null;
        }
        protected override IEnumerable<UserDefinedProperty> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new UserDefinedPropertyPDSAManager();
                mgr.DataObject.SelectFilter = UserDefinedPropertyPDSAData.SelectFilters.ByEntityId;
                if (getParameters == null || getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                else
                    mgr.Entity.EntityId = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        protected override IEnumerable<UserDefinedProperty> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new UserDefinedPropertyPDSAManager();
                mgr.DataObject.SelectFilter = UserDefinedPropertyPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        public IEnumerable<UserDefinedProperty> GetAllUserDefinedPropertiesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new UserDefinedPropertyPDSAManager();
                mgr.DataObject.SelectFilter = UserDefinedPropertyPDSAData.SelectFilters.ByEntityId;
                if (parameters.UniqueId != Guid.Empty)
                    mgr.Entity.EntityId = parameters.UniqueId;
                else
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;

                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = parameters.CurrentEntityId;

                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        public UserDefinedProperty GetByEntityIdAndPropertyName(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new UserDefinedPropertyPDSAManager();
                mgr.DataObject.SelectFilter = UserDefinedPropertyPDSAData.SelectFilters.ByEntityIdAndPropertyName;
                mgr.Entity.EntityId = parameters.UniqueId;
                mgr.Entity.PropertyName = parameters.GetString;
                return GetIEnumerable(sessionData, parameters, mgr).FirstOrDefault();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        protected override UserDefinedProperty GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override UserDefinedProperty GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new UserDefinedPropertyPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    UserDefinedProperty result = new UserDefinedProperty();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, UserDefinedProperty originalEntity, UserDefinedProperty newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "UserDefinedPropertyUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.UserDefinedPropertyUid;
                        mgr.Entity.RecordTag = newEntity.UserDefinedPropertyUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "UserDefinedPropertyUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.UserDefinedPropertyUid;
                        mgr.Entity.RecordTag = newEntity.UserDefinedPropertyUid.ToString(); 
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
                        mgr.Entity.PrimaryKeyColumn = "UserDefinedPropertyUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.UserDefinedPropertyUid;
                        mgr.Entity.RecordTag = originalEntity.UserDefinedPropertyUid.ToString(); 
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                //throw;
            }
        }

        protected override void FillMemberCollections(UserDefinedProperty entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                getParameters = new GetParametersWithPhoto() { UniqueId = entity.UserDefinedPropertyUid };

            if (entity.PropertyTypeUid == Common.Constants.UserDefinedPropertyTypeIds.Text)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedTextPropertyRulesRepository>();
                entity.UserDefinedTextPropertyRules = repo.Get(entity.UserDefinedPropertyUid, sessionData, getParameters);
            }
            else if (entity.PropertyTypeUid == Common.Constants.UserDefinedPropertyTypeIds.Number)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedNumberPropertyRulesRepository>();
                entity.UserDefinedNumberPropertyRules = repo.Get(entity.UserDefinedPropertyUid, sessionData, getParameters);
            }
            else if (entity.PropertyTypeUid == Common.Constants.UserDefinedPropertyTypeIds.Boolean)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedBooleanPropertyRulesRepository>();
                entity.UserDefinedBooleanPropertyRules = repo.Get(entity.UserDefinedPropertyUid, sessionData, getParameters);
            }
            else if (entity.PropertyTypeUid == Common.Constants.UserDefinedPropertyTypeIds.Date)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedDatePropertyRulesRepository>();
                entity.UserDefinedDatePropertyRules = repo.Get(entity.UserDefinedPropertyUid, sessionData, getParameters);
            }
            else if (entity.PropertyTypeUid == Common.Constants.UserDefinedPropertyTypeIds.List)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedListPropertyRulesRepository>();
                entity.UserDefinedListPropertyRules = repo.Get(entity.UserDefinedPropertyUid, sessionData, getParameters);
            }
            else if (entity.PropertyTypeUid == Common.Constants.UserDefinedPropertyTypeIds.Guid)
            {
                var repo = _DataRepositoryFactory.GetDataRepository<IUserDefinedGuidPropertyRulesRepository>();
                entity.UserDefinedGuidPropertyRules = repo.Get(entity.UserDefinedPropertyUid, sessionData, getParameters);
            }
            //var permissionRepo = _DataRepositoryFactory.GetDataRepository<IUserDefinedPropertyPermissionRepository>();
            //getParameters.UniqueId = entity.UserDefinedPropertyUid;
            //entity.UserDefinedPropertyPermissions = permissionRepo.GetAllUserDefinedPropertyPermissionForUserDefinedProperty(sessionData, getParameters).ToCollection();

            //var sensitivityLevelRepo = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelRepository>();
            //entity.PropertySensitivityLevel = sensitivityLevelRepo.Get(entity.PropertySensitivityLevelUid, sessionData, getParameters);
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("UserDefinedProperty", "UserDefinedPropertyUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("UserDefinedProperty", "UserDefinedPropertyUid", id);
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

        protected override bool IsEntityUnique(UserDefinedProperty entity)
        {
            var mgr = new IsUserDefinedPropertyUniquePDSAManager();
            mgr.Entity.UserDefinedPropertyUid = entity.UserDefinedPropertyUid;
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.PropertyName = entity.PropertyName;
            mgr.Entity.SchemaName = entity.SchemaName;
            mgr.Entity.TableName = entity.TableName;
            mgr.Entity.ColumnName = entity.ColumnName;
            mgr.Entity.UniquePropertyName = entity.UniquePropertyName;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("UserDefinedProperty", "UserDefinedPropertyUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("UserDefinedProperty", "UserDefinedPropertyUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }


    }
}
