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
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IPersonCredentialRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonCredentialRepository : DataRepositoryBase<PersonCredential>, IPersonCredentialRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private ICredentialRepository _credentialRepository;

        protected override PersonCredential AddEntity(PersonCredential entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.Credential.IsAnythingDirty)
                {
                    var c = _credentialRepository.SaveCredential(entity.Credential, sessionData, saveParams);
                    entity.Credential = c;
                }

                if (string.IsNullOrEmpty(entity.CredentialDescription))
                    entity.CredentialDescription = entity.Credential.CredentialFormatDescription;

                if (entity.PersonCredentialRoleUid == Guid.Empty)
                    entity.PersonCredentialRoleUid = GalaxySMS.Common.Constants.PersonCredentialRoleIds.AccessControl;

                if (entity.PersonActivationModeUid == Guid.Empty)
                {
                    if (entity.ActivationDateTime.HasValue && entity.ActivationDateTime.Value > DateTimeOffset.Now.MinSqlDateTime())
                    {
                        if (entity.ActivationDateTime.Value.TimeOfDay > TimeSpan.Zero)
                            entity.PersonActivationModeUid = GalaxySMS.Common.Constants.PersonActivationModeIds.ActivateByDateAndTime;
                        else
                            entity.PersonActivationModeUid = GalaxySMS.Common.Constants.PersonActivationModeIds.ActivateByDate;
                    }
                    else
                        entity.PersonActivationModeUid =
                        GalaxySMS.Common.Constants.PersonActivationModeIds.ImmediatelyActive;
                }

                if (entity.PersonActivationModeUid == GalaxySMS.Common.Constants.PersonActivationModeIds.ActivateByDate &&
                    entity.ActivationDateTime.HasValue &&
                    entity.ActivationDateTime.Value.TimeOfDay != TimeSpan.Zero)
                    entity.ActivationDateTime = new DateTimeOffset(entity.ActivationDateTime.Value.Date.Year, entity.ActivationDateTime.Value.Date.Month, entity.ActivationDateTime.Value.Date.Day, 0, 0, 0, TimeSpan.Zero);

                if (entity.PersonExpirationModeUid == Guid.Empty)
                {
                    if (entity.ExpirationDateTime.HasValue && entity.ExpirationDateTime.Value > DateTimeOffset.Now.MinSqlDateTime())
                    {
                        if (entity.ExpirationDateTime.Value.Hour != 23 || entity.ExpirationDateTime.Value.Minute != 59 || entity.ExpirationDateTime.Value.Second != 59)
                            entity.PersonExpirationModeUid =
                                GalaxySMS.Common.Constants.PersonExpirationModeIds.ExpireByDateAndTime;
                        else
                            entity.PersonExpirationModeUid = GalaxySMS.Common.Constants.PersonExpirationModeIds.ExpireByDate;
                    }
                    else if (entity.UsageCount != 0)
                        entity.PersonExpirationModeUid = GalaxySMS.Common.Constants.PersonExpirationModeIds.ExpireByUsageCount;
                    else
                        entity.PersonExpirationModeUid = GalaxySMS.Common.Constants.PersonExpirationModeIds.NeverExpires;
                }

                if (entity.PersonExpirationModeUid == GalaxySMS.Common.Constants.PersonExpirationModeIds.ExpireByDate &&
                    entity.ExpirationDateTime.HasValue &&
                    entity.ExpirationDateTime.Value.TimeOfDay != TimeSpan.Zero)
                    entity.ExpirationDateTime = new DateTimeOffset(entity.ExpirationDateTime.Value.Date.Year, entity.ExpirationDateTime.Value.Date.Month, entity.ExpirationDateTime.Value.Date.Day, 23, 59, 59, TimeSpan.Zero);

                if (entity.BadgeTemplateUid == Guid.Empty)
                    entity.BadgeTemplateUid = GalaxySMS.Common.Constants.BadgeTemplateIds.BadgeTemplateUid_None;

                if (entity.DossierBadgeTemplateUid == Guid.Empty)
                    entity.DossierBadgeTemplateUid = GalaxySMS.Common.Constants.BadgeTemplateIds.BadgeTemplateUid_None;

                if (entity.AccessPortalDeferToServerBehaviorUid == Guid.Empty)
                    entity.AccessPortalDeferToServerBehaviorUid = GalaxySMS.Common.Constants.AccessPortalDeferToServerBehaviorIds.Never;

                if (entity.AccessPortalNoServerReplyBehaviorUid == Guid.Empty)
                    entity.AccessPortalNoServerReplyBehaviorUid = GalaxySMS.Common.Constants.AccessPortalNoServerReplyBehaviorIds.FollowPanelDecision;

                var mgr = new PersonCredentialPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.PersonCredentialUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::AddEntity", ex);
                throw;
            }
        }

        protected override PersonCredential UpdateEntity(PersonCredential entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.PersonCredentialUid, sessionData, null);
                var mgr = new PersonCredentialPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.PersonCredentialUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    if (string.IsNullOrEmpty(entity.CredentialDescription))
                        entity.CredentialDescription = mgr.Entity.CredentialDescription;

                    // if PersonCredentialRoleUid is = Guid.Empty or null, then use the value from the original record
                    entity.PersonCredentialRoleUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.PersonCredentialRoleUid, entity.PersonCredentialRoleUid);

                    // if PersonActivationModeUid is = Guid.Empty or null, then use the value from the original record
                    entity.PersonActivationModeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.PersonActivationModeUid, entity.PersonActivationModeUid);

                    // if PersonExpirationModeUid is = Guid.Empty or null, then use the value from the original record
                    entity.PersonExpirationModeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.PersonExpirationModeUid, entity.PersonExpirationModeUid);

                    // if BadgeTemplateUid is = Guid.Empty or null, then use the value from the original record
                    entity.BadgeTemplateUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.BadgeTemplateUid, entity.BadgeTemplateUid);

                    // if DossierBadgeTemplateUid is = Guid.Empty or null, then use the value from the original record
                    entity.DossierBadgeTemplateUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.DossierBadgeTemplateUid, entity.DossierBadgeTemplateUid);

                    // if AccessPortalNoServerReplyBehaviorUid is = Guid.Empty or null, then use the value from the original record
                    entity.AccessPortalNoServerReplyBehaviorUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessPortalNoServerReplyBehaviorUid, entity.AccessPortalNoServerReplyBehaviorUid);

                    // if AccessPortalDeferToServerBehaviorUid is = Guid.Empty or null, then use the value from the original record
                    entity.AccessPortalDeferToServerBehaviorUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessPortalDeferToServerBehaviorUid, entity.AccessPortalDeferToServerBehaviorUid);

                    if (string.IsNullOrEmpty(entity.CredentialDescription))
                        entity.CredentialDescription = mgr.Entity.CredentialDescription;

                    if (entity.PersonActivationModeUid == GalaxySMS.Common.Constants.PersonActivationModeIds.ActivateByDate &&
                        entity.ActivationDateTime.HasValue &&
                        entity.ActivationDateTime.Value.TimeOfDay != TimeSpan.Zero)
                        entity.ActivationDateTime = new DateTimeOffset(entity.ActivationDateTime.Value.Date.Year, entity.ActivationDateTime.Value.Date.Month, entity.ActivationDateTime.Value.Date.Day, 0, 0, 0, TimeSpan.Zero);

                    if (entity.PersonExpirationModeUid == GalaxySMS.Common.Constants.PersonExpirationModeIds.ExpireByDate &&
                        entity.ExpirationDateTime.HasValue &&
                        entity.ExpirationDateTime.Value.TimeOfDay != TimeSpan.Zero)
                        entity.ExpirationDateTime = new DateTimeOffset(entity.ExpirationDateTime.Value.Date.Year, entity.ExpirationDateTime.Value.Date.Month, entity.ExpirationDateTime.Value.Date.Day, 23, 59, 59, TimeSpan.Zero);

                    mgr.InitEntityObject(entity);
                    //int rowsUpdated = mgr.DataObject.Update();
                    //if (rowsUpdated > 0)
                    int rowsUpdated = 0;
                    rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.PersonCredentialUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.PersonCredentialUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MagicExceptionStrings.no_rows_updated, StringComparison.OrdinalIgnoreCase) && entity.IndexValue != -1)
                {
                    var dve = new DataValidationException(new ValidationRule($"{entity.OwnerPropertyName}[{entity.IndexValue}].{nameof(entity.ConcurrencyValue)}", Resources.Resources.ExceptionMessage_ConcurrencyValueWrong));
                    throw dve;
                }
                else
                {
                    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::UpdateEntity", ex);
                    throw;
                }
            }
        }

        protected override int DeleteEntity(PersonCredential entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new PersonCredentialPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.PersonCredentialUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new PersonCredentialPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::Remove", ex);
                throw;
            }
        }

        // GetAllPersonCredentials in a region
        protected override IEnumerable<PersonCredential> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonCredentialPDSAManager();
                mgr.DataObject.SelectFilter = PersonCredentialPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<PersonCredential> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, PersonCredentialPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (PersonCredential entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<PersonCredential> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonCredentialPDSAManager();
                mgr.DataObject.SelectFilter = PersonCredentialPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<PersonCredential> GetAllPersonCredentialsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonCredentialPDSAManager();
                mgr.DataObject.SelectFilter = PersonCredentialPDSAData.SelectFilters.ByPersonUid;
                mgr.Entity.PersonUid = getParameters.PersonUid;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::GetAllPersonCredentialsForPerson", ex);
                throw;
            }
        }

        public IEnumerable<PersonCredential> GetAllPersonCredentialsForCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonCredentialPDSAManager();
                mgr.DataObject.SelectFilter = PersonCredentialPDSAData.SelectFilters.ByCredentialUid;
                mgr.Entity.CredentialUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::GetAllPersonCredentialsForCredential", ex);
                throw;
            }
        }

        public PersonCredential GetByCredentialUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetAllPersonCredentialsForCredential(sessionData, getParameters).FirstOrDefault();
        }

        public PersonCredentialBadgeDataView GetPersonCredentialBadgeDataView(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonCredentialBadgeDataView_ByPersonCredentialUidPDSAManager();
                mgr.Entity.PersonCredentialUid = getParameters.UniqueId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null && pdsaEntities.Count > 0)
                {
                    var entity = pdsaEntities[0];
                    var length = entity?.PersonPhotoMainPhoto?.Length;
                    var newEntity = new PersonCredentialBadgeDataView();
                    SimpleMapper.PropertyMap(entity, newEntity);
                    return newEntity;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::GetAllPersonCredentialsForCredential", ex);
                throw;
            }
        }

        protected override PersonCredential GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override PersonCredential GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonCredentialPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    PersonCredential result = new PersonCredential();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, PersonCredential originalEntity, PersonCredential newEntity, string auditXml)
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
                        propertiesToIgnore.Add("PersonCredentialCommandScripts");
                        propertiesToIgnore.Add("PersonClusterPermissions");
                        propertiesToIgnore.Add("Credential");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "PersonCredentialUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.PersonCredentialUid;
                        mgr.Entity.RecordTag = newEntity.PersonCredentialUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "PersonCredentialUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.PersonCredentialUid;
                        mgr.Entity.RecordTag = newEntity.PersonCredentialUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "PersonCredentialUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.PersonCredentialUid;
                        mgr.Entity.RecordTag = originalEntity.PersonCredentialUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonCredentialRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(PersonCredential entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            entity.Credential = _credentialRepository.Get(entity.CredentialUid, sessionData, new GetParametersWithPhoto() { UniqueId = entity.CredentialUid, IncludeMemberCollections = true, });
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("PersonCredential", "PersonCredentialUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("PersonCredential", "PersonCredentialUid", id);
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

        protected override bool IsEntityUnique(PersonCredential entity)
        {
            return true;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("PersonCredential", "PersonCredentialUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("PersonCredential", "PersonCredentialUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
