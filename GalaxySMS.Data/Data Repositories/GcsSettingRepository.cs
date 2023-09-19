using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using GCS.Framework.Caching;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsSettingRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsSettingRepository : DataRepositoryBase<gcsSetting>, IGcsSettingRepository
    {
        [Import] private ICacheManager _cacheManager;

        protected override gcsSetting AddEntity(gcsSetting entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.SettingKey.ToLower().Contains(MagicStrings.password))
                {
                    if (entity.SettingId == Guid.Empty)
                        entity.SettingId = GuidUtilities.GenerateComb();

                    var pwd = GCS.Framework.Security.Crypto.Encrypt(entity.Value, entity.SettingId.ToString());
                    entity.Value = pwd;
                }

                gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.SettingId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsSetting UpdateEntity(gcsSetting entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.SettingId, sessionData, null);
                gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();

                if (entity.SettingKey.ToLower().Contains(MagicStrings.password))
                {
                    var pwd = GCS.Framework.Security.Crypto.Encrypt(entity.Value, entity.SettingId.ToString());
                    entity.Value = pwd;
                }

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.SettingId) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.SettingId, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.SettingId} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsSetting entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.SettingId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsSetting> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    var passwordEntities = entities.Where(o => o.SettingKey.ToLower().Contains(MagicStrings.password));
                    foreach (var e in passwordEntities)
                    {
                        var pwd = GCS.Framework.Security.Crypto.Decrypt(e.Value, e.SettingId.ToString());
                        e.Value = pwd;
                    }

                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsSetting> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsSetting GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsSetting GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    if (mgr.Entity.SettingKey.ToLower().Contains(MagicStrings.password))
                    {
                        var pwd = GCS.Framework.Security.Crypto.Decrypt(mgr.Entity.Value, mgr.Entity.SettingId.ToString());
                        mgr.Entity.Value = pwd;
                    }
                    gcsSetting result = new gcsSetting();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsSetting originalEntity, gcsSetting newEntity, string auditXml)
        {
            try
            {
                if (!string.IsNullOrEmpty(auditXml))
                {
                    auditXml = auditXml.EncodeForXml();
                    //if (!auditXml.ValidateXml())
                    //    auditXml = string.Empty;
                }

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
                        mgr.Entity.PrimaryKeyColumn = "SettingId";
                        mgr.Entity.PrimaryKeyValue = newEntity.SettingId;
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
                        mgr.Entity.PrimaryKeyColumn = "SettingId";
                        mgr.Entity.PrimaryKeyValue = newEntity.SettingId;
                        mgr.Entity.RecordTag = newEntity.SettingKey;
                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        try
                        {
                            mgr.Execute();
                        }
                        catch (Exception e)
                        {
                            if (e.InnerException != null)
                            {
                                if (e.InnerException.Message.StartsWith("XML parsing"))
                                {
                                    mgr.Entity.AuditXml = string.Empty;
                                    mgr.Execute();
                                }
                            }
                        }
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
                        mgr.Entity.PrimaryKeyColumn = "SettingId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.SettingId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsSetting entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsSetting Setting)
        {
            gcs_IsSettingUniquePDSAManager mgr = new gcs_IsSettingUniquePDSAManager();
            mgr.Entity.SettingId = Setting.SettingId;
            mgr.Entity.EntityId = Setting.EntityId;

            mgr.Entity.SettingKey = Setting.SettingKey;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsSetting", "SettingId", id);
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

        #region IGcsSettingRepository Members
        public int DeleteByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey,
                   IApplicationUserSessionDataHeader sessionData)
        {
            gcsSetting Setting = GetByUniqueKey(entityId, settingGroup, settingSubGroup, settingKey);
            if (Setting != null)
            {
                return Remove(Setting.SettingId, sessionData);
            }
            return 0;
        }

        public gcsSetting GetByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey)
        {
            try
            {
                gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();
                mgr.DataObject.SelectFilter = gcsSettingPDSAData.SelectFilters.ByEntityGroupSubGroupKey;
                mgr.DataObject.Entity.EntityId = entityId;
                mgr.DataObject.Entity.SettingGroup = settingGroup;
                mgr.DataObject.Entity.SettingSubGroup = settingSubGroup;
                mgr.DataObject.Entity.SettingKey = settingKey;
                var results = mgr.BuildCollection();
                if (results != null)
                {
                    var settings = mgr.ConvertPDSACollection(results);
                    var returnValue = settings.FirstOrDefault();
                    if (returnValue != null)
                    {
                        if (returnValue.SettingKey.ToLower().Contains(MagicStrings.password))
                        {
                            var pwd = GCS.Framework.Security.Crypto.Decrypt(returnValue.Value, returnValue.SettingId.ToString());
                            returnValue.Value = pwd;
                        }
                    }
                    return returnValue;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetByUniqueKey", ex);
                throw;
            }
        }

        public int GetByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, int defaultValue, bool bCreateIfNotFound, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var setting = GetByUniqueKey(entityId, settingGroup, settingSubGroup, settingKey);
                if (setting == null && bCreateIfNotFound)
                {
                    setting = Save(entityId, settingGroup, settingSubGroup, settingKey, defaultValue.ToString(), sessionData, null);
                }

                if (setting != null)
                {
                    int ret = 0;
                    if (int.TryParse(setting.Value, out ret))
                        return ret;
                    return defaultValue;
                }
                return defaultValue;

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetByUniqueKey", ex);
                throw;
            }
        }
        public string GetByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, string defaultValue, bool bCreateIfNotFound, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var setting = GetByUniqueKey(entityId, settingGroup, settingSubGroup, settingKey);
                if (setting == null && bCreateIfNotFound)
                {
                    setting = Save(entityId, settingGroup, settingSubGroup, settingKey, defaultValue, sessionData, null);
                }
                else if (setting != null && setting.SettingKey.ToLower().Contains(MagicStrings.password))
                {
                    var saveParams = new SaveParameters();
                    saveParams.Options.Add(new KeyValuePair<string, string>(nameof(GalaxySMS.Common.Enums.SaveSettingOption).ToString(), SaveSettingOption.Encrypt.ToString()));

                    setting = Save(entityId, settingGroup, settingSubGroup, settingKey, setting.Value, sessionData, saveParams);
                }

                if (setting != null)
                {
                    return setting.Value;
                }
                return defaultValue;

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetByUniqueKey", ex);
                throw;
            }
        }
        public bool GetByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, bool defaultValue, bool bCreateIfNotFound, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var setting = GetByUniqueKey(entityId, settingGroup, settingSubGroup, settingKey);
                if (setting == null && bCreateIfNotFound)
                {
                    setting = Save(entityId, settingGroup, settingSubGroup, settingKey, defaultValue.ToString(), sessionData, null);
                }

                if (setting != null)
                {
                    bool ret = false;
                    if (bool.TryParse(setting.Value, out ret))
                        return ret;
                    return defaultValue;
                }
                return defaultValue;

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetByUniqueKey", ex);
                throw;
            }
        }
        public Guid GetByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, Guid defaultValue, bool bCreateIfNotFound, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var setting = GetByUniqueKey(entityId, settingGroup, settingSubGroup, settingKey);
                if (setting == null && bCreateIfNotFound)
                {
                    setting = Save(entityId, settingGroup, settingSubGroup, settingKey, defaultValue.ToString().ToLower(), sessionData, null);
                }

                if (setting != null)
                {
                    Guid ret = Guid.Empty;
                    if (Guid.TryParse(setting.Value, out ret))
                        return ret;
                    return defaultValue;
                }
                return defaultValue;

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetByUniqueKey", ex);
                throw;
            }
        }

        //public IEnumerable<gcsSetting> GetAllForEntity(Guid entityId)
        //{
        //    try
        //    {
        //        gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();
        //        mgr.DataObject.SelectFilter = gcsSettingPDSAData.SelectFilters.AllByEntityId;
        //        mgr.DataObject.Entity.EntityId = entityId;
        //        var results = mgr.BuildCollection();
        //        if (results != null)
        //        {
        //            var settings = mgr.ConvertPDSACollection(results);
        //            return settings;
        //        }
        //        return null;

        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetAllForUser", ex);
        //        throw;
        //    }
        //}

        public IEnumerable<gcsSetting> GetAllForEntity(Guid entityId)
        {
            try
            {
                gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();
                mgr.DataObject.SelectFilter = gcsSettingPDSAData.SelectFilters.AllByEntityId;
                mgr.DataObject.Entity.EntityId = entityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetAllForUser", ex);
                throw;
            }
        }

        public IEnumerable<gcsSetting> GetSettingsForEntityAndGroup(Guid entityId, string group)
        {
            try
            {
                gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();
                mgr.DataObject.SelectFilter = gcsSettingPDSAData.SelectFilters.ByEntityAndGroup;
                mgr.DataObject.Entity.EntityId = entityId;
                mgr.DataObject.Entity.SettingGroup = group;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetAllForUser", ex);
                throw;
            }

        }

        public IEnumerable<gcsSetting> GetSettingsForEntityGroupAndSubGroup(Guid entityId, string group, string subGroup)
        {
            try
            {
                gcsSettingPDSAManager mgr = new gcsSettingPDSAManager();
                mgr.DataObject.SelectFilter = gcsSettingPDSAData.SelectFilters.ByEntityGroupAndSubGroup;
                mgr.DataObject.Entity.EntityId = entityId;
                mgr.DataObject.Entity.SettingGroup = group;
                mgr.DataObject.Entity.SettingSubGroup = subGroup;

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsSettingRepository::GetAllForUser", ex);
                throw;
            }

        }

        public gcsSetting Save(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, string value, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var gcsSetting = GetByUniqueKey(entityId, settingGroup, settingSubGroup, settingKey);

                var bEncrypt = false;

                if (saveParams != null)
                {
                    var kvpAlwaysEncrypt = saveParams.Options.FirstOrDefault(o => o.Key == nameof(SaveSettingOption).ToString());
                    bEncrypt = !string.IsNullOrEmpty(kvpAlwaysEncrypt.Key) &&
                                     !string.IsNullOrEmpty(kvpAlwaysEncrypt.Value) &&
                                     kvpAlwaysEncrypt.Value == SaveSettingOption.Encrypt.ToString();
                }


                if (gcsSetting != null && gcsSetting.Value != value || bEncrypt)
                {
                    if (!settingKey.ToLower().Contains(MagicStrings.password) && bEncrypt)
                    {
                        var encryptedValue = GCS.Framework.Security.Crypto.Encrypt(value, gcsSetting.SettingId.ToString());
                        gcsSetting.Value = encryptedValue;
                    }
                    else
                    {
                        gcsSetting.Value = value;
                    }
                    UpdateTableEntityBaseProperties(gcsSetting, sessionData);
                    return UpdateEntity(gcsSetting, sessionData, saveParams);
                }
                else
                {

                    gcsSetting = new gcsSetting()
                    {
                        EntityId = entityId,
                        SettingGroup = settingGroup,
                        SettingSubGroup = settingSubGroup,
                        SettingKey = settingKey,
                        Value = value,
                        SettingId = GuidUtilities.GenerateComb()
                    };

                    if (!settingKey.ToLower().Contains(MagicStrings.password) && bEncrypt)
                    {
                        var encryptedValue = GCS.Framework.Security.Crypto.Encrypt(value, gcsSetting.SettingId.ToString());
                        gcsSetting.Value = encryptedValue;
                    }
                    else
                    {
                        gcsSetting.Value = value;
                    }

                    UpdateTableEntityBaseProperties(gcsSetting, sessionData);
                    return AddEntity(gcsSetting, sessionData, saveParams);
                }
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

        #endregion
    }
}
