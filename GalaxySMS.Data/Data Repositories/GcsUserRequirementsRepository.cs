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
using GCS.Core.Common.Config;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using GCS.Framework.Caching;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsUserRequirementsRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserRequirementsRepository : DataRepositoryBase<gcsUserRequirement>, IGcsUserRequirementsRepository
    {
        [Import] private ICacheManager _cacheManager;

        protected override gcsUserRequirement AddEntity(gcsUserRequirement entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.UserRequirementsId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsUserRequirement UpdateEntity(gcsUserRequirement entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.UserRequirementsId, sessionData, null);
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.UserRequirementsId) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertName = originalEntity.InsertName;
                    entity.InsertDate = originalEntity.InsertDate;

                    if (entity.EntityId == null || entity.EntityId == Guid.Empty)
                        entity.EntityId = mgr.Entity.EntityId;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.UserRequirementsId, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.UserRequirementsId} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsUserRequirement entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.UserRequirementsId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsUserRequirement> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsUserRequirement> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsUserRequirement GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsUserRequirement GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsUserRequirement result = new gcsUserRequirement();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsUserRequirement originalEntity, gcsUserRequirement newEntity, string auditXml)
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
                        propertiesToIgnore.Add("UserSettings");
                        propertiesToIgnore.Add("UserOldPasswords");
                        propertiesToIgnore.Add("UserApplicationEntities");
                        propertiesToIgnore.Add("UserEntities");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "UserRequirementsId";
                        mgr.Entity.PrimaryKeyValue = newEntity.UserRequirementsId;
                        mgr.Entity.RecordTag = string.Empty;
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
                        mgr.Entity.PrimaryKeyColumn = "UserRequirementsId";
                        mgr.Entity.PrimaryKeyValue = newEntity.UserRequirementsId;
                        mgr.Entity.RecordTag = string.Empty;
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
                        mgr.Entity.PrimaryKeyColumn = "UserRequirementsId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.UserRequirementsId;
                        mgr.Entity.RecordTag = string.Empty;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsUserRequirement entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }

        public gcsUserRequirement GetByEntityId(Guid entityId)
        {
            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserRequirementsPDSAData.SelectFilters.ByEntityId;
                mgr.Entity.EntityId = entityId;
                var count = mgr.DataObject.Load();
                if (count == 1)
                {
                    gcsUserRequirement result = new gcsUserRequirement();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::GetByEntityId", ex);
                throw;
            }

        }

        protected override bool IsEntityReferenced(Guid userRequirementId)
        {
            return false;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsUserRequirement userRequirement)
        {
            gcs_IsUserRequirementUniquePDSAManager mgr = new gcs_IsUserRequirementUniquePDSAManager();
            mgr.Entity.UserRequirementsId = userRequirement.UserRequirementsId;
            mgr.Entity.EntityId = userRequirement.EntityId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsUserRequirements", "UserRequirementsId", id);
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
            return true;
        }

        public gcsUserRequirement GetDefaultValue()
        {
            return new gcsUserRequirement()
            {
                PasswordCannotContainName = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordCannotContainName", true, true),
                UseCustomRegEx = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordUseCustomRegEx", false, true),
                PasswordCustomRegEx = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordCustomRegEx", string.Empty, true),
                PasswordMinimumLength = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordMinimumLength", 1, true),
                PasswordMaximumLength = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordMaximumLength", 15, true),
                PasswordMinimumChangeCharacters = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordMinimumChangeCharacters", 1, true),
                MaintainPasswordHistoryCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "MaintainPasswordHistoryCount", 3, true),
                AllowPasswordChangeAttempt = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "AllowPasswordChangeAttempt", true, true),
                MinimumPasswordAge = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "MinimumPasswordAge", 0, true),
                MaximumPasswordAge = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "MaximumPasswordAge", 0, true),
                DefaultExpirationDays = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "DefaultExpirationDays", 0, true),
                LockoutUserIfInactiveForDays = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "LockoutUserIfInactiveForDays", 14, true),
                RequireLowerCaseLetterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireLowerCaseLetterCount", 0, true),
                RequireNumericDigitCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireNumericDigitCount", 0, true),
                RequireSpecialCharacterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireSpecialCharacterCount", 0, true),
                RequireUpperCaseLetterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireUpperCaseLetterCount", 0, true),
                RegularExpressionDescription = string.Empty
            };
        }

    }
}
