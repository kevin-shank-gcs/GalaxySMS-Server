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
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsUserEntityRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserEntityRepository : DataRepositoryBase<gcsUserEntity>, IGcsUserEntityRepository
    {
        protected override gcsUserEntity AddEntity(gcsUserEntity entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                gcsUserEntityPDSAManager mgr = new gcsUserEntityPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveUserEntityRoles(ref entity, true, sessionData, saveParams);
                    var result = GetEntityByGuidId(entity.UserEntityId, sessionData, new GetParametersWithPhoto());
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        UpdateEntityCount(entity.EntityId);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::AddEntity", ex);
                throw;
            }
        }

        private void SaveUserEntityRoles(ref gcsUserEntity userEntity, bool bAddingNewParent, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (userEntity != null)
            {
                if (userEntity.UserEntityRoles != null)
                {
                    //GcsUserEntityApplicationRoleRepository repository = new GcsUserEntityApplicationRoleRepository();
                    //foreach (var userEntityApplicationRole in userEntity.gcsUserEntityRoles)
                    //{
                    //    userEntityApplicationRole.UserEntityId = userEntity.UserEntityId;
                    //    userEntityApplicationRole.UpdateName = userEntity.UpdateName;
                    //    userEntityApplicationRole.UpdateDate = userEntity.UpdateDate;
                    //    if (userEntityApplicationRole.UserEntityApplicationRoleId == Guid.Empty)
                    //    {
                    //        userEntityApplicationRole.UserEntityApplicationRoleId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                    //        if (bAddingNewParent == true)
                    //        {
                    //            userEntityApplicationRole.InsertName = userEntity.InsertName;
                    //            userEntityApplicationRole.InsertDate = userEntity.InsertDate;
                    //        }
                    //        else
                    //        {
                    //            userEntityApplicationRole.InsertName = userEntity.UpdateName;
                    //            if (userEntity.UpdateDate.HasValue == true)
                    //                userEntityApplicationRole.InsertDate = userEntity.UpdateDate.Value;
                    //            else
                    //                userEntityApplicationRole.InsertDate = DateTimeOffset.Now;
                    //        }
                    //        repository.Add(userEntityApplicationRole, sessionData, saveParams);
                    //    }
                    //    else
                    //    {   // this is not a new insert, the update name and date must be assigned
                    //        repository.Update(userEntityApplicationRole, sessionData, saveParams);
                    //    }
                    //}

                    //// Now delete the roles that are no longer assigned to the userEntity
                    //var includedUserEntityApplicationRoleIds = (from uear in userEntity.gcsUserEntityRoles
                    //                                            select uear.UserEntityApplicationRoleId).ToList();
                    //var currentUserEntityApplicationRoles = repository.GetByUserEntityId(userEntity.UserEntityId);
                    //foreach (var currentUserEntityApplicationRole in currentUserEntityApplicationRoles)
                    //{
                    //    if (includedUserEntityApplicationRoleIds.Contains(currentUserEntityApplicationRole.UserEntityApplicationRoleId) == false)
                    //    {
                    //        repository.Remove(currentUserEntityApplicationRole.UserEntityApplicationRoleId, sessionData);
                    //    }
                    //}
                }
            }
        }

        protected override gcsUserEntity UpdateEntity(gcsUserEntity entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.UserEntityId, sessionData, new GetParametersWithPhoto());
                gcsUserEntityPDSAManager mgr = new gcsUserEntityPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.UserEntityId); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    SaveUserEntityRoles(ref entity, false, sessionData, saveParams);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.UserEntityId, sessionData, new GetParametersWithPhoto());
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                    UpdateEntityCount(updatedEntity.EntityId);
                    if (updatedEntity.EntityId != originalEntity.EntityId)
                        UpdateEntityCount(originalEntity.EntityId);

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsUserEntity entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsUserEntityPDSAManager mgr = new gcsUserEntityPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.UserEntityId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                    UpdateEntityCount(entity.EntityId);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsUserEntityPDSAManager mgr = new gcsUserEntityPDSAManager();

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
                        UpdateEntityCount(originalEntity.EntityId);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsUserEntity> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserEntityPDSAManager mgr = new gcsUserEntityPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsUserEntity> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsUserEntity GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsUserEntity GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                if (getParameters == null)
                    getParameters = new GetParametersWithPhoto();
                gcsUserEntityPDSAManager mgr = new gcsUserEntityPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsUserEntity result = new gcsUserEntity();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    FillMemberCollections(result, sessionData, getParameters);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsUserEntity originalEntity, gcsUserEntity newEntity, string auditXml)
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
                        propertiesToIgnore.Add("gcsEntity");
                        propertiesToIgnore.Add("gcsUser");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "UserEntityId";
                        mgr.Entity.PrimaryKeyValue = newEntity.UserEntityId;
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
                        mgr.Entity.PrimaryKeyColumn = "UserEntityId";
                        mgr.Entity.PrimaryKeyValue = newEntity.UserEntityId;
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
                        mgr.Entity.PrimaryKeyColumn = "UserEntityId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.UserEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsUserEntity entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (!getParameters.IsExcluded(nameof(gcsUserEntity.UserEntityRoles)))
            {
                var repo = new GcsUserEntityRoleRepository();
                entity.UserEntityRoles = repo.GetByUserEntityId(entity.UserEntityId).ToCollection();
            }
            //            GcsApplicationRepository repository = new GcsApplicationRepository();
            //entity.ApplicationsPermittedToEntity = repository.GetAllApplicationsForEntity(entity.EntityId).ToCollection();
            //entity.ApplicationsAuthorizedForUser = repository.GetAllApplicationsForUser(entity.UserId).ToCollection();
            ////entity.ApplicationsNotAuthorizedForUser =
            ////    entity.gcsApplicationsPermittedToEntity.Except(entity.ApplicationsAuthorizedForUser).ToCollection();
            //entity.ApplicationsNotAuthorizedForUser =
            //    entity.ApplicationsPermittedToEntity.Where(permittedApps => entity.ApplicationsAuthorizedForUser.All(authorizedApps => authorizedApps.ApplicationId != permittedApps.ApplicationId)).ToCollection();
        }

        protected override bool IsEntityReferenced(Guid id)
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

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsUserEntity userEntity)
        {
            gcs_IsUserEntityUniquePDSAManager mgr = new gcs_IsUserEntityUniquePDSAManager();
            mgr.Entity.UserEntityId = userEntity.UserEntityId;
            mgr.Entity.UserId = userEntity.UserId;
            mgr.Entity.EntityId = userEntity.EntityId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsUserEntity", "UserEntityId", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }

        public IEnumerable<gcsUserEntity> GetByUserId(Guid userId, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserEntityPDSAManager mgr = new gcsUserEntityPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityPDSAData.SelectFilters.ByUserId;
                mgr.DataObject.Entity.UserId = userId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);

                    foreach (var entity in entities)
                    {
                        FillMemberCollections(entity, null, getParameters);
                    }
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::GetEntities", ex);
                throw;
            }
        }
        public IEnumerable<gcsUserEntity> GetByEntityId(Guid entityId, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserEntityPDSAManager mgr = new gcsUserEntityPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityPDSAData.SelectFilters.ByEntityId;
                mgr.DataObject.Entity.EntityId = entityId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);

                    foreach (var entity in entities)
                    {
                        FillMemberCollections(entity, null, getParameters);
                    }
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::GetEntities", ex);
                throw;
            }
        }

        public gcsUserEntity GetByUserIdAndEntityId(Guid userId, Guid entityId, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new gcsUserEntityPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityPDSAData.SelectFilters.ByUserIdAndEntityId;
                mgr.DataObject.Entity.UserId = userId;
                mgr.DataObject.Entity.EntityId = entityId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    var entity = entities.FirstOrDefault();
                    //if( entity != null)
                    //{
                    //    FillMemberCollections(entity, null, getParameters);
                    //}
                    return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::GetEntities", ex);
                throw;
            }

        }

        public IEnumerable<gcsUserEntityMinimal> GetMinimalByUserId(Guid userId, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new gcsUserEntityRoles_GetMinimalInfoForUserIdPDSAManager();
                mgr.Entity.UserId = userId;
                mgr.Entity.EntityId = getParameters.UniqueId;
                var data = mgr.BuildCollection();

                var groupedByEntity = data.GroupBy(o => o.EntityId);
                var results = new HashSet<gcsUserEntityMinimal>();
                foreach (var group in groupedByEntity)
                {
                    var userEntity = new gcsUserEntityMinimal();

                    foreach (var r in group)
                    {
                        userEntity.EntityName = r.EntityName;
                        userEntity.IsAdministrator = r.IsAdministrator;
                        userEntity.Roles.Add(r.RoleName);
                    }

                    results.Add(userEntity);
                }

                return results;

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRepository::GetEntities", ex);
                throw;
            }
        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertEntityUserCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }
    }
}
