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
    [Export(typeof(IGcsUserSettingRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserSettingRepository : DataRepositoryBase<gcsUserSetting>, IGcsUserSettingRepository
    {

        protected override gcsUserSetting AddEntity(gcsUserSetting entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.ApplicationId == Guid.Empty)
                    entity.ApplicationId = null;
                entity.InsertName = sessionData.UserName;
                entity.InsertDate = DateTimeOffset.Now;
                entity.UpdateName = sessionData.UserName;
                entity.UpdateDate = DateTimeOffset.Now;

                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.UserSettingId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsUserSetting UpdateEntity(gcsUserSetting entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.UserSettingId, sessionData, null);
                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.UserSettingId) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    if (entity.ApplicationId == Guid.Empty)
                        entity.ApplicationId = null;

                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;
                    entity.UpdateName = sessionData.UserName;
                    entity.UpdateDate = DateTimeOffset.Now;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.UserSettingId, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.UserSettingId} not found");

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsUserSetting entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.UserSettingId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsUserSetting> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsUserSetting> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsUserSetting GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        public int DeleteByUniqueKey(Guid userId, Guid? applicationId, string category, string settingKey, IApplicationUserSessionDataHeader sessionData)
        {
            gcsUserSetting userSetting = GetByUniqueKey(userId, applicationId, category, settingKey);
            if (userSetting != null)
                return Remove(userSetting.UserSettingId, sessionData);
            return 0;
        }

        protected override gcsUserSetting GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsUserSetting result = new gcsUserSetting();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsUserSetting originalEntity, gcsUserSetting newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "UserSettingId";
                        mgr.Entity.PrimaryKeyValue = newEntity.UserSettingId;
                        mgr.Entity.RecordTag = newEntity.SettingKey;
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
                        mgr.Entity.PrimaryKeyColumn = "UserSettingId";
                        mgr.Entity.PrimaryKeyValue = newEntity.UserSettingId;
                        mgr.Entity.RecordTag = newEntity.SettingKey;
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
                        mgr.Entity.PrimaryKeyColumn = "UserSettingId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.UserSettingId;
                        mgr.Entity.RecordTag = originalEntity.SettingKey;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsUserSetting entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsUserSetting userSetting)
        {
            gcs_IsUserSettingUniquePDSAManager mgr = new gcs_IsUserSettingUniquePDSAManager();
            mgr.Entity.UserSettingId = userSetting.UserSettingId;
            mgr.Entity.UserId = userSetting.UserId;
            if (userSetting.ApplicationId.HasValue)
                mgr.Entity.ApplicationId = userSetting.ApplicationId.Value;
            else
            {
                mgr.Entity.ApplicationId = Guid.Empty;
            }
            mgr.Entity.Category = userSetting.Category;
            mgr.Entity.SettingKey = userSetting.SettingKey;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsUserSetting", "UserSettingId", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }

        protected override bool IsEntityReferenced(Guid userId)
        {
            return false;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid id)
        {
            return true;
        }

        #region IGcsUserSettingRepository Members

        public gcsUserSetting GetByUniqueKey(Guid userId, Guid? applicationId, string category, string settingKey)
        {
            try
            {
                if (applicationId == null)
                    applicationId = Guid.Empty;

                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserSettingPDSAData.SelectFilters.ByUserIdApplicationIdCategorySettingKey;
                mgr.DataObject.Entity.UserId = userId;
                mgr.DataObject.Entity.ApplicationId = applicationId.Value;
                mgr.DataObject.Entity.Category = category;
                mgr.DataObject.Entity.SettingKey = settingKey;
                var results = mgr.BuildCollection();
                if (results != null && results.Count > 0)
                {
                    var entities = mgr.ConvertPDSACollection(results);
                    return entities.FirstOrDefault();
                }
                return null;

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::GetByUniqueKey", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserSetting> GetAllForUser(Guid userId)
        {
            try
            {
                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserSettingPDSAData.SelectFilters.ByUserId;
                mgr.DataObject.Entity.UserId = userId;
                var results = mgr.BuildCollection();
                if (results != null)
                {
                    var settings = mgr.ConvertPDSACollection(results);
                    return settings;
                }
                return null;

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::GetAllForUser", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserSetting> GetAllForUserApplication(Guid userId, Guid? applicationId)
        {
            try
            {
                if (applicationId == null)
                    applicationId = Guid.Empty;

                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserSettingPDSAData.SelectFilters.ByUserIdApplicationId;
                mgr.DataObject.Entity.UserId = userId;
                mgr.DataObject.Entity.ApplicationId = applicationId.Value;
                var results = mgr.BuildCollection();
                if (results != null)
                {
                    var settings = mgr.ConvertPDSACollection(results);
                    return settings;
                }
                return null;

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::GetAllForUserApplication", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserSetting> GetAllForUserApplicationCategory(Guid userId, Guid? applicationId, string category)
        {
            try
            {
                if (applicationId == null)
                    applicationId = Guid.Empty;

                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserSettingPDSAData.SelectFilters.ByUserIdApplicationIdCategory;
                mgr.DataObject.Entity.UserId = userId;
                mgr.DataObject.Entity.ApplicationId = applicationId.Value;
                mgr.DataObject.Entity.Category = category;
                var results = mgr.BuildCollection();
                if (results != null)
                {
                    var settings = mgr.ConvertPDSACollection(results);
                    return settings;
                }
                return null;

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::GetAllForUserApplicationCategory", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserSetting> GetAllForApplication(Guid? applicationId)
        {
            try
            {
                if (applicationId == null)
                    applicationId = Guid.Empty;

                gcsUserSettingPDSAManager mgr = new gcsUserSettingPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserSettingPDSAData.SelectFilters.ByApplicationId;
                mgr.DataObject.Entity.ApplicationId = applicationId.Value;
                var results = mgr.BuildCollection();
                if (results != null)
                {
                    var settings = mgr.ConvertPDSACollection(results);
                    return settings;
                }
                return null;

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::GetAllForApplication", ex);
                throw;
            }
        }

        #endregion
    }
}
