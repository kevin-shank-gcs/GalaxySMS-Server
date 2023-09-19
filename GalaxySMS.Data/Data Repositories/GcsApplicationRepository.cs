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
    [Export(typeof(IGcsApplicationRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsApplicationRepository : DataRepositoryBase<gcsApplication>, IGcsApplicationRepository
    {
        //[Import] private IGcsRoleRepository _roleRepository;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;

        protected override gcsApplication AddEntity(gcsApplication entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.ApplicationId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsApplication UpdateEntity(gcsApplication entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.ApplicationId, sessionData, null);
                entity.InsertDate = originalEntity.InsertDate;
                entity.InsertName = originalEntity.InsertName;
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.ApplicationId);
                // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.ApplicationId, sessionData, null);
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                        mgr.DataObject.AuditRowAsXml);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::UpdateEntity", ex);
                throw;
            }
        }

        // Assign all users the SystemRole for the application for each entity the user is assigned to ( except System Entity)
        public bool EnsureDefaultUserEntityApplicationRolesExist(gcsApplication entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                //if (!entity.SystemRoleId.HasValue)
                //    return false;

                //var entityApplicationRoleRepository = new GcsEntityApplicationRoleRepository();
                //var entityApplicationRoles = entityApplicationRoleRepository.GetAllEntityApplicationRolesForRole(entity.SystemRoleId.Value);
                //var entityApplicationRole = entityApplicationRoles.FirstOrDefault();
                //if (entityApplicationRole == null)
                //    return false;

                var userRepository = new GcsUserRepository();
                var userEntityRepository = new GcsUserEntityRepository();
                //var userEntityApplicationRoleRepository = new GcsUserEntityApplicationRoleRepository();

                var getParams = new GetParametersWithPhoto() { IncludePhoto = false, IncludeMemberCollections = false };
                var users = userRepository.Get(sessionData, getParams);
                var userEntities = userEntityRepository.GetAll(sessionData, getParams);
                //var userEntityApplicationRoles = userEntityApplicationRoleRepository.GetAll(sessionData, getParams);

                // Spin though all users
                foreach (var u in users)
                {
                    // Spin though all entities that the user is assigned to
                    foreach (var ue in userEntities.Where(o => o.UserId == u.UserId && o.EntityId != GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id))
                    {
                        //var userEntityApplicationRole = userEntityApplicationRoles.FirstOrDefault(o => o.UserEntityId == ue.UserEntityId &&
                        //o.EntityApplicationRoleId == entityApplicationRole.EntityApplicationRoleId);
                        //if (userEntityApplicationRole == null)
                        //{
                        //    userEntityApplicationRole = new gcsUserEntityApplicationRole()
                        //    {
                        //        UserEntityApplicationRoleId = GuidUtilities.GenerateComb(),
                        //        UserEntityId = ue.UserEntityId,
                        //        EntityApplicationRoleId = entityApplicationRole.EntityApplicationRoleId,
                        //    };
                        //    UpdateTableEntityBaseProperties(userEntityApplicationRole, sessionData);
                        //    var savedEntity = userEntityApplicationRoleRepository.Add(userEntityApplicationRole, sessionData, null, null);
                        //}
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::UpdateEntity", ex);
                throw;
            }

        }

        protected override int DeleteEntity(gcsApplication entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.ApplicationId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id);
                // must read the original record from the database so the PDSA object can detect changes
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsApplication> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (gcsApplication entity in entities)
                    {
                        FillMemberCollections(entity, sessionData, getParameters);
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsApplication> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsApplication GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsApplication GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsApplication result = new gcsApplication();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData,
            gcsApplication originalEntity, gcsApplication newEntity, string auditXml)
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
                            throw new ArgumentNullException("newEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        List<String> propertiesToIgnore = new List<string>(); propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        propertiesToIgnore.Add("UserSettings");
                        propertiesToIgnore.Add("EntityApplications");
                        propertiesToIgnore.Add("AllRoles");
                        propertiesToIgnore.Add("PermissionCategories");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "ApplicationId";
                        mgr.Entity.PrimaryKeyValue = newEntity.ApplicationId;
                        mgr.Entity.RecordTag = newEntity.ApplicationName;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;

                        if (string.IsNullOrEmpty(auditXml) == false)
                        {
                            mgr.Entity.AuditXml = auditXml;
                            mgr.Execute();
                        }


                        mgr.Entity.AuditXml = null;

                        SimpleObjectDifferenceDetector.CompareResults differences =
                            SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity, propertiesToIgnore);
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
                            throw new ArgumentNullException("newEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "ApplicationId";
                        mgr.Entity.PrimaryKeyValue = newEntity.ApplicationId;
                        mgr.Entity.RecordTag = newEntity.ApplicationName;
                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "ApplicationId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.ApplicationId;
                        mgr.Entity.RecordTag = originalEntity.ApplicationName;
                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {
                // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsApplication entity,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                getParameters = new GetParametersWithPhoto();

            //var roleRepository = _dataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();
            //entity.AllRoles = roleRepository.GetAllRolesForApplication(entity.ApplicationId, getParameters).ToCollection();

            //var excludeRolePermissions = getParameters.ExcludeMemberCollectionSettings.Where(o => o.Key == nameof(gcsPermissionCategory)).FirstOrDefault();
            //if (excludeRolePermissions.Value == true)
            //    return;
            if (getParameters.IsExcluded(nameof(gcsPermissionCategory)))
                return;

            var permissionCategoryRepository = new GcsPermissionCategoryRepository();
            entity.PermissionCategories =
                permissionCategoryRepository.GetAllPermissionCategoriesForApplication(entity.ApplicationId, getParameters)
                    .ToCollection();
        }
        private void FillMemberCollections(gcsApplicationBasic entity,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                getParameters = new GetParametersWithPhoto();

            //var roleRepository = new GcsRoleRepository();
            //var roles = roleRepository.GetAllRolesForApplication(entity.ApplicationId, getParameters).ToCollection();
            //foreach (var r in roles)
            //{
            //    entity.Roles.Add(new gcsEntityRoleBasic(r));
            //}

            //if (getParameters.IsExcluded(nameof(gcsPermissionCategory)))
            //    return;

            //var permissionCategoryRepository = new GcsPermissionCategoryRepository();
            //entity.gcsPermissionCategories =
            //    permissionCategoryRepository.GetAllPermissionCategoriesForApplication(entity.ApplicationId, getParameters)
            //        .ToCollection();
        }

        public IEnumerable<gcsApplicationBasic> GetAllApplicationsBasic(IGetParametersWithPhoto getParameters, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                var results = new List<gcsApplicationBasic>();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (gcsApplication entity in entities)
                    {
                        var ab = new gcsApplicationBasic(entity);

                        FillMemberCollections(ab, sessionData, getParameters);
                        results.Add(ab);
                    }
                    return results;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::GetEntities", ex);
                throw;
            }


        }


        public IEnumerable<gcsApplication> GetAllApplicationsForEntity(Guid entityId, IGetParametersWithPhoto getParameters)
        {   // This collection will only include applications which are authorized for use by the entity.
            // each gcsApplication will only include those gcsRoles (AllRoles) which are authorized for use by the entity
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                mgr.DataObject.SelectFilter = gcsApplicationPDSAData.SelectFilters.ByEntityId;
                mgr.Entity.EntityId = entityId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (gcsApplication entity in entities)
                    {
                        //entity.RoleCollectionsMode = gcsApplication.RoleDataCollectionsMode.ForEntity;
                        //GcsRoleRepository roleRepository = new GcsRoleRepository();
                        //entity.RoleCollectionsMode = gcsApplication.RoleDataCollectionsMode.ForEntity;
                        //entity.AllRoles = roleRepository.GetAllRolesForApplicationAndEntity(entity.ApplicationId, entityId, getParameters).ToCollection();

                        var permissionCategoryRepository = new GcsPermissionCategoryRepository();
                        entity.PermissionCategories =
                            permissionCategoryRepository.GetAllPermissionCategoriesForApplication(entity.ApplicationId, getParameters).ToCollection();

                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::GetAllForEntity", ex);
                throw;
            }
        }

        public IEnumerable<gcsApplication> GetAllApplicationsForUser(Guid userId, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                mgr.DataObject.SelectFilter = gcsApplicationPDSAData.SelectFilters.ByUserId;
                mgr.Entity.UserId = userId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    //foreach (gcsApplication entity in entities)
                    //{
                    //    GcsRoleRepository repository = new GcsRoleRepository();
                    //    entity.gcsRoles = repository.GetAllRolesForApplicationAndEntity(entity.ApplicationId, entityId).ToCollection();
                    //}
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::GetAllForEntity", ex);
                throw;
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsApplication", "ApplicationId", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsApplication", "ApplicationId", id);
            if (count == 0)
                return true;
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsApplication application)
        {
            gcs_IsApplicationUniquePDSAManager mgr = new gcs_IsApplicationUniquePDSAManager();
            mgr.Entity.ApplicationId = application.ApplicationId;
            mgr.Entity.ApplicationName = application.ApplicationName;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsApplication", "ApplicationId", id);
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