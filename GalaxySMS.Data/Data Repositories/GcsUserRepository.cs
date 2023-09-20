using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Data;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using GCS.Framework.Security;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GCS.Core.Common.ServiceModel;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using GalaxySMS.Common.Interfaces;
using SharedResources = GalaxySMS.Resources;
using System.Security.Cryptography;
using GCS.Framework.Email;
using GCS.Framework.Sms;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsUserRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserRepository : PagedDataRepositoryBase<gcsUser>, IGcsUserRepository
    {
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private IGcsUserOldPasswordRepository _oldPasswordRepository;

        protected override gcsUser AddEntity(gcsUser entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                VerifyEntityIsValid(entity);

                if (entity.LanguageId == null || entity.LanguageId == Guid.Empty)
                    entity.LanguageId = GalaxySMS.Common.Constants.LanguageIds.GalaxySMS_EN_US_Language_Id;

                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveUserEntities(ref entity, false, sessionData, saveParams);
                    var result = GetEntityByGuidId(entity.UserId, sessionData, new GetParametersWithPhoto(saveParams));
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        result.UserPassword = string.Empty;
                        // Don't need to get old passwords because this is a new user. There are no old passwords
                        UpdateEntityCount(result.PrimaryEntityId);

                        return result;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::AddEntity", ex);
                throw;
            }
        }

        private static void VerifyEntityIsValid(gcsUser entity)
        {

            if (!string.IsNullOrEmpty(entity.Email))
                entity.NormalizedEmail = entity.Email.ToUpper();
            else
                entity.NormalizedEmail = entity.Email;

            if (string.IsNullOrEmpty(entity.UserName) && !string.IsNullOrEmpty(entity.Email))
            {
                if (entity.Email.Length <= 100)
                    entity.UserName = entity.Email;
                else
                {
                    entity.UserName = entity.Email.Substring(0, 100);
                }

            }

            if (!string.IsNullOrEmpty(entity.UserName))
                entity.NormalizedUserName = entity.UserName.ToUpper();
            else
                entity.NormalizedUserName = entity.UserName;


            //if (string.IsNullOrEmpty(entity.NormalizedEmail) && !string.IsNullOrEmpty(entity.Email))
            //    entity.NormalizedEmail = entity.Email.ToUpper();
            //if (string.IsNullOrEmpty(entity.NormalizedUserName) && !string.IsNullOrEmpty(entity.UserName))
            //    entity.NormalizedUserName = entity.UserName.ToUpper();
        }

        private void SaveUserEntities(ref gcsUser user, bool bAddingNewParent, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (saveParams.Ignore("UserEntities") || user == null)
                return;

            if (user.UserEntities != null)
            {
                var dontValidateAuthorization = saveParams.OptionValue<bool>(GalaxySMS.Common.Enums.InitializingSystemOption.DontValidateAuthorization.ToString());
                var userEntityRepository = _dataRepositoryFactory.GetDataRepository<IGcsUserEntityRepository>(); //new GcsUserEntityRepository();
                var entityRepo = _dataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();
                var roleRepo = _dataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

                var ues = user.UserEntities.ToList();
                // Grab the current gcsUserEntity records from the database, then delete any that have a matching gcsEntity object in user.AllEntities with IsAuthorized == false
                var existingUserEntities = userEntityRepository.GetByUserId(user.UserId, new GetParametersWithPhoto());
                var deleteTheseUserEntities = existingUserEntities.Where(p => ues.All(p2 => p2.EntityId != p.EntityId)).ToList();
                var addTheseUserEntities = ues.Where(p => existingUserEntities.All(p2 => p2.EntityId != p.EntityId)).ToList();
                var updateTheseUserEntities = ues.Where(p => existingUserEntities.Any(p2 => p2.EntityId == p.EntityId)).ToList();

                #region Update existing userEntity items, only if IsAdministrator is different from before
                foreach (var ue in updateTheseUserEntities)
                {
                    var existingUe = existingUserEntities.FirstOrDefault(o => o.EntityId == ue.EntityId);
                    if (existingUe != null && ue.IsAdministrator != existingUe.IsAdministrator)
                    {
                        var bIsUserAdmin =
                            DoesUserHaveAdminRole(sessionData.UserId, ue.EntityId);
                        if (!bIsUserAdmin && ue.IsAdministrator && !dontValidateAuthorization)
                        {
                            var entityName = entityRepo.GetEntityName(ue.EntityId);
                            var ex = new UnauthorizedAccessException(
                                $"{MagicExceptionStrings.forbidden}. The current user is not permitted to assign {nameof(ue.IsAdministrator)}={ue.IsAdministrator} to the user being saved because the current user does not have administrator permissions to entity '{entityName}', Id '{ue.EntityId}'.");
                            throw ex;
                        }

                        ue.UserId = user.UserId;
                        ue.UserEntityId = existingUe.UserEntityId;
                        UpdateTableEntityBaseProperties(ue, sessionData);

                        this.Log().Info($"Updating UserEntity - UserId: {ue.UserId}, EntityId: {ue.EntityId}.");
                        var updatedUe = userEntityRepository.Update(ue, sessionData, saveParams);
                    }
                }
                #endregion

                #region Delete all gcsUserEntity records that are no longer authorized

                foreach (var ue in deleteTheseUserEntities)
                {
                    var bIsUserAdmin = DoesUserHaveAdminRole(sessionData.UserId, ue.EntityId);
                    if (!bIsUserAdmin && !dontValidateAuthorization)
                    {
                        var entityName = entityRepo.GetEntityName(ue.EntityId);
                        var ex = new UnauthorizedAccessException(
                            $"{MagicExceptionStrings.forbidden}. The current user is not permitted to delete entity '{entityName}', Id '{ue.EntityId}' from the user being saved because the current user does not have administrator permissions to entity '{entityName}'.");
                        throw ex;
                    }

                    this.Log().Info($"Deleting UserEntity - UserEntityId: {ue.UserEntityId}, UserId: {ue.UserId}, EntityId: {ue.EntityId}.");
                    userEntityRepository.Remove(ue.UserEntityId, sessionData);
                }
                #endregion

                #region Add new userEntity items
                foreach (var ue in addTheseUserEntities)
                {
                    ue.UserId = user.UserId;
                    if (ue.UserEntityId == Guid.Empty)
                        ue.UserEntityId = GuidUtilities.GenerateComb();
                    UpdateTableEntityBaseProperties(ue, sessionData);
                    if (userEntityRepository.DoesExist(ue.UserEntityId) == false)
                    {
                        var bIsUserAdmin = DoesUserHaveAdminRole(sessionData.UserId, ue.EntityId);
                        if (!bIsUserAdmin && !dontValidateAuthorization)
                        {
                            var entityName = entityRepo.GetEntityName(ue.EntityId);
                            var ex = new UnauthorizedAccessException(
                                $"{MagicExceptionStrings.forbidden}. The current user is not permitted to add entity '{entityName}', Id '{ue.EntityId}' to the user being saved because the current user does not have administrator permissions to entity '{entityName}'.");
                            throw ex;
                        }

                        this.Log().Info($"Adding UserEntity - UserId: {ue.UserId}, EntityId: {ue.EntityId}.");
                        var updatedUe = userEntityRepository.Add(ue, sessionData, saveParams);
                    }
                }
                #endregion

                #region Add & delete roles
                // Now deal with adding and removing Roles for the UserEntites that are being added or kept
                var validUes = addTheseUserEntities.ToList();
                validUes.AddRange(updateTheseUserEntities);

                var userEntityRoleRepository = new GcsUserEntityRoleRepository();

                foreach (var userEntity in validUes)
                {
                    var existingUe = existingUserEntities.FirstOrDefault(o => o.EntityId == userEntity.EntityId);
                    if (existingUe != null)
                        userEntity.UserEntityId = existingUe.UserEntityId;
                    var existingRoles = userEntityRoleRepository.GetByUserEntityId(userEntity.UserEntityId).ToList();
                    var deleteTheseRoles = existingRoles.Where(p => userEntity.UserEntityRoles.All(p2 => p2.RoleId != p.RoleId)).ToList();
                    var addTheseRoles = userEntity.UserEntityRoles.Where(p => existingRoles.All(p2 => p2.RoleId != p.RoleId)).ToList();
                    var keepTheseRoles = existingRoles.Where(p => userEntity.UserEntityRoles.Any(p2 => p2.RoleId == p.RoleId)).ToList();
                    var bIsUserAdmin = DoesUserHaveAdminRole(sessionData.UserId, userEntity.EntityId);

                    foreach (var uer in deleteTheseRoles)
                    {
                        var bRolePermitted = IsUserInRole(sessionData.UserId, uer.RoleId);
                        if (!bIsUserAdmin && bRolePermitted == false && !dontValidateAuthorization)
                        {
                            var roleName = roleRepo.GetRoleName(uer.RoleId);
                            var ex = new UnauthorizedAccessException(
                                $"{MagicExceptionStrings.forbidden}. The current user is not permitted to delete role '{roleName}' from the user being saved because the current user is not a member of that role.");
                            throw ex;
                        }

                        this.Log().Info($"Deleting UserEntityRole - UserEntityRoleId: {uer.UserEntityRoleId}, UserId: {userEntity.UserId}, EntityId: {userEntity.EntityId}, RoleId: {uer.RoleId}.");
                        userEntityRoleRepository.Remove(uer.UserEntityRoleId, sessionData);
                    }

                    foreach (var uer in addTheseRoles)
                    {
                        this.Log().Info($"Adding UserEntityRole - UserEntityRoleId: {uer.UserEntityRoleId}, UserId: {userEntity.UserId}, EntityId: {userEntity.EntityId}, RoleId: {uer.RoleId}.");
                        if (uer.UserEntityRoleId == Guid.Empty)
                            uer.UserEntityRoleId = GuidUtilities.GenerateComb();
                        UpdateTableEntityBaseProperties(uer, sessionData);

                        if (userEntityRoleRepository.DoesExist(uer.UserEntityRoleId) == false)
                        {
                            var bRolePermitted = IsUserInRole(sessionData.UserId, uer.RoleId);
                            if (!bIsUserAdmin && bRolePermitted == false && !dontValidateAuthorization)
                            {
                                var roleName = roleRepo.GetRoleName(uer.RoleId);
                                var ex = new UnauthorizedAccessException(
                                    $"{MagicExceptionStrings.forbidden}. The current user is not permitted to add role '{roleName}' to the user being saved because the current user is not a member of that role.");
                                throw ex;
                            }
                            uer.UserEntityId = userEntity.UserEntityId;
                            userEntityRoleRepository.Add(uer, sessionData, saveParams);
                        }
                    }

                }
                #endregion

            }
        }

        protected override gcsUser UpdateEntity(gcsUser entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                VerifyEntityIsValid(entity);
                var saveOldPassword = false;
                var currentPassword = string.Empty;
                // The user could come into this method without any password. If this is the case, the current
                // password must be retrieved and plugged into the user object so the update mechanism does not
                // erase the current password
                if (string.IsNullOrEmpty(entity.UserPassword))
                {
                    entity.UserPassword = GetPasswordForUser(entity.UserId, sessionData);
                }
                else
                {   // If the incoming entity has a password value (not an empty string), then 
                    currentPassword = GetPasswordForUser(entity.UserId, sessionData);
                    if(currentPassword != entity.UserPassword) 
                        saveOldPassword = true;
                }

                if (entity.LanguageId == null || entity.LanguageId == Guid.Empty)
                    entity.LanguageId = GalaxySMS.Common.Constants.LanguageIds.GalaxySMS_EN_US_Language_Id;

                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(entity.UserId, sessionData, new GetParametersWithPhoto()
                {
                    ExcludeMemberCollectionSettings = new List<string>() { nameof(gcsUser.UserOldPasswords) }
                });

                var changePasswordResponseUrl = string.Empty;
                var resetPassword = false;
                if (originalEntity != null && !originalEntity.ResetPasswordFlag && entity.ResetPasswordFlag)
                {   // ResetPasswordFlag is being set from false to true
                    resetPassword = true;
                    changePasswordResponseUrl = saveParams.OptionValue<string>(SaveUserOption.ChangePasswordResponseUrl.ToString());
                }

                gcsUserPDSAManager mgr = new gcsUserPDSAManager();

                // must read the original record from the database so the PDSA object can detect changes
                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.UserId) > 0)
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;
                    //entity.LockoutEnabled = mgr.Entity.LockoutEnabled.Value;
                    //entity.PasswordHash = mgr.Entity.PasswordHash;
                    // if PrimaryEntityId is = Guid.Empty or null, then use the value from the original record
                    entity.PrimaryEntityId = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.PrimaryEntityId, entity.PrimaryEntityId);

                    if (!saveParams.SavePhoto)
                    {
                        entity.SecurityImage = mgr.Entity.SecurityImage;
                        entity.UserImage = mgr.Entity.UserImage;
                    }
                    // always preserve these properties. Do not overwrite 
                    entity.LastLoginDate = mgr.Entity.LastLoginDate;
                    entity.LastPasswordResetDate = mgr.Entity.LastPasswordResetDate;
                    entity.SecurityStamp = mgr.Entity.SecurityStamp;
                    entity.ConcurrencyStamp = mgr.Entity.ConcurrencyStamp;

                    if (mgr.Entity.IsLockedOut == true && entity.IsLockedOut == false)
                    {
                        mgr.Entity.IsLockedOut = false;
                        entity.IsLockedOutClearedDate = DateTimeOffset.Now;
                    }

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        if (saveOldPassword && !string.IsNullOrEmpty(currentPassword))
                        {
                            SaveOldPassword(entity.UserId, currentPassword, sessionData);
                        }

                        SaveUserEntities(ref entity, false, sessionData, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.UserId, sessionData, new GetParametersWithPhoto(saveParams));
                        if (updatedEntity != null)
                        {
                            DataStoreTableName = mgr.DataObject.DBObjectName;
                            SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                                mgr.DataObject.AuditRowAsXml);
                            //ts.Complete();
                            UpdateEntityCount(updatedEntity.PrimaryEntityId);
                            if (originalEntity.PrimaryEntityId != updatedEntity.PrimaryEntityId)
                                UpdateEntityCount(originalEntity.PrimaryEntityId);

                            if (resetPassword && !String.IsNullOrEmpty(changePasswordResponseUrl))
                            {
                                var data = RequestUserPasswordChangeToken(new UserRequestPasswordChangeToken()
                                {
                                    ChangePasswordResponseUrl = changePasswordResponseUrl,
                                    SendViaEmail = updatedEntity.EmailConfirmed &&
                                                   !string.IsNullOrEmpty(updatedEntity.Email),
                                    SendViaSms = updatedEntity.PhoneNumberConfirmed &&
                                                 !string.IsNullOrEmpty(updatedEntity.PhoneNumber)

                                }, sessionData, updatedEntity);
                            }


                            return updatedEntity;
                        }
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.UserId} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsUser entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.UserId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                    UpdateEntityCount(entity.PrimaryEntityId);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(gcsUser entity, IApplicationUserSessionDataHeader sessionData)
        {
            return base.Remove(entity, sessionData);
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();

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
                        UpdateEntityCount(originalEntity.PrimaryEntityId);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::Remove", ex);
                throw;
            }
        }

        //private void PrepareUserForReturning(gcsUser user, IGetParametersWithPhoto getParameters, IApplicationUserSessionDataHeader sessionData, IEnumerable<Guid> entityIds)
        //{
        //    if (user != null)
        //    {
        //        if (user.UserImage != null && user.UserImage.Length == 0)
        //            user.UserImage = null;

        //        if (user.SecurityImage != null && user.SecurityImage.Length == 0)
        //            user.SecurityImage = null;

        //        user.gcsUserOldPasswords = GetOldPasswordsForUser(user, -1, sessionData).ToCollection();
        //        user.UserPassword = string.Empty;
        //        user.UserEntities = GetEntitiesForUserId(user.UserId).ToCollection();

        //        // Sort out the entites that the user is authorized to use
        //        GcsEntityRepository entityRepository = new GcsEntityRepository();
        //        GcsApplicationRepository applicationRepository = new GcsApplicationRepository();
        //        GcsRoleRepository roleRepository = new GcsRoleRepository();
        //        GcsUserEntityApplicationRoleRepository userEntityApplicationRoleRepository = new GcsUserEntityApplicationRoleRepository();
        //        GcsUserSettingRepository userSettingRepository = new GcsUserSettingRepository();

        //        var p = new GetParametersWithPhoto(getParameters);
        //        if (getParameters == null)
        //        {
        //            p.IncludePhoto = true;
        //            p.PhotoPixelWidth = 200;
        //            p.IncludeMemberCollections = false;
        //        }

        //        user.AllEntities = entityRepository.Get(sessionData, p).ToCollection();
        //        user.gcsUserSettings = userSettingRepository.GetAllForUser(user.UserId).ToCollection();
        //        foreach (var ue in user.UserEntities)
        //        {
        //            var entity = (from e in user.AllEntities
        //                          where e.EntityId == ue.EntityId
        //                          select e).FirstOrDefault();
        //            if (entity != null)
        //            {
        //                entity.IsAuthorized = true;
        //                // The original entity.AllApplications collection contains all applications. 
        //                // Because we only want the applications that the entity is authorized to use to be available to the user,
        //                // that collection must be replaced with only the applications authorized for the entity.
        //                entity.CollectionsMode = gcsEntity.DataCollectionsMode.ForUser;
        //                entity.AllApplications =
        //                    applicationRepository.GetAllApplicationsForEntity(entity.EntityId, null).ToCollection();

        //                //                       ue.gcsEntity = entity;
        //                // now that only the applications that are permitted for the entity are in the AllApplications collection
        //                // the IsAuthorized flag must be set based on if this user has any roles for the application
        //                // Now, iterate through the AllApplications collection and retrieve all userEntityApplicationRoles from the database for this userEntity and the application 

        //                foreach (var application in entity.AllApplications)
        //                {
        //                    //TODO must retrieve roles that the user has for this application and entity
        //                    var userRoles = roleRepository.GetAllRolesForUserEntityAndApplication(ue.UserEntityId, application.ApplicationId, null);

        //                    foreach (var userRole in userRoles)
        //                    {
        //                        application.IsAuthorized = true;    // if at least one role has been assigned, then the application is authorized for the user

        //                        var role = (from ar in application.AllRoles
        //                                    where ar.RoleId == userRole.RoleId
        //                                    select ar).FirstOrDefault();
        //                        if (role != null)
        //                            role.IsAuthorized = role.IsActive;///true;
        //                    }

        //                    if (ue.gcsUserEntityApplicationRoles == null)
        //                        ue.gcsUserEntityApplicationRoles =
        //                        userEntityApplicationRoleRepository.GetByUserEntityIdAndApplicationId(ue.UserEntityId, application.ApplicationId).ToCollection();
        //                    else
        //                        ue.gcsUserEntityApplicationRoles.AddRange(userEntityApplicationRoleRepository.GetByUserEntityIdAndApplicationId(ue.UserEntityId, application.ApplicationId));

        //                    foreach (var userEntityApplicationRole in ue.gcsUserEntityApplicationRoles)
        //                    {
        //                        application.IsAuthorized = true;    // if at least one role has been assigned, then the application is authorized for the user
        //                    }
        //                }
        //            }
        //        }

        //    }
        //}

        private void PrepareUserForReturning(gcsUser user, IGetParametersWithPhoto getParameters, IApplicationUserSessionDataHeader sessionData)
        {
            if (user != null)
            {
                if (user.UserImage != null && user.UserImage.Length == 0)
                    user.UserImage = null;

                if (user.SecurityImage != null && user.SecurityImage.Length == 0)
                    user.SecurityImage = null;

                if (getParameters == null)
                {
                    getParameters = new GetParametersWithPhoto();
                    getParameters.ExcludeMemberCollectionSettings.Add(nameof(gcsUser.UserOldPasswords));
                    getParameters.ExcludeMemberCollectionSettings.Add(nameof(gcsUser.UserEntities));
                    getParameters.ExcludeMemberCollectionSettings.Add(nameof(gcsUser.UserSettings));
                }
                if (!getParameters.IsExcluded(nameof(user.UserOldPasswords)))
                    user.UserOldPasswords = GetOldPasswordsForUser(user, -1, sessionData).ToCollection();

                user.UserPassword = string.Empty;

                if (!getParameters.IsExcluded(nameof(user.UserEntities)))
                {
                    user.UserEntities = GetEntitiesForUserId(user.UserId, getParameters).ToCollection();
                }

                if (!getParameters.IsExcluded(nameof(user.UserSettings)))
                {
                    var userSettingRepository = new GcsUserSettingRepository();
                    user.UserSettings = userSettingRepository.GetAllForUser(user.UserId).ToCollection();
                }
            }
        }

        private void PrepareUserForReturningSignOnRequest(gcsUser user, IGetParametersWithPhoto getParameters, IApplicationUserSessionDataHeader sessionData, IEnumerable<Guid> permissionsForEntityIds)
        {
            if (user != null)
            {
                if (user.UserImage != null && user.UserImage.Length == 0)
                    user.UserImage = null;

                if (user.SecurityImage != null && user.SecurityImage.Length == 0)
                    user.SecurityImage = null;

                if (!getParameters.IsExcluded(nameof(user.UserOldPasswords)))
                    user.UserOldPasswords = GetOldPasswordsForUser(user, -1, sessionData).ToCollection();

                if (!getParameters.IsExcluded(nameof(user.UserSettings)))
                {
                    var userSettingRepository = new GcsUserSettingRepository();
                    user.UserSettings = userSettingRepository.GetAllForUser(user.UserId).ToCollection();
                }

                user.UserPassword = string.Empty;

                if (!getParameters.IsExcluded(nameof(user.UserEntities)))
                {
                    user.UserEntities = GetEntitiesForUserId(user.UserId, getParameters).ToCollection();

                }
            }
        }

        public IEnumerable<gcsUserBasic> GetUserList(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                if (getParameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.ByPrimaryEntityId;
                    mgr.Entity.PrimaryEntityId = getParameters.UniqueId;
                }

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    // Blank out the password so it does not get returned to the client.
                    IList<gcsUserBasic> results = new List<gcsUserBasic>();
                    foreach (gcsUser entity in entities)
                    {
                        if (getParameters.IncludePhoto == false)
                        {
                            entity.UserImage = null;
                        }
                        else if (getParameters.PhotoPixelWidth > 0 && entity.UserImage != null)
                        {
                            var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                            GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.UserImage), getParameters.PhotoPixelWidth);
                            entity.UserImage = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
                        }
                        results.Add(new gcsUserBasic(entity));
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntities", ex);
                throw;
            }

        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, gcsUserPDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<UserSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }

        public ArrayResponse<gcsUserBasic> GetUserListPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                if (getParameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.ByPrimaryEntityId;
                    mgr.Entity.PrimaryEntityId = getParameters.UniqueId;
                }

                SetSortColumnAndOrder(getParameters, mgr);
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var totalCount = 0;
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    // Blank out the password so it does not get returned to the client.
                    IList<gcsUserBasic> results = new List<gcsUserBasic>();
                    foreach (gcsUser entity in entities)
                    {
                        if (totalCount == 0)
                            totalCount = entity.TotalRowCount;
                        if (getParameters.IncludePhoto == false)
                        {
                            entity.UserImage = null;
                        }
                        else if (getParameters.PhotoPixelWidth > 0 && entity.UserImage != null)
                        {
                            var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                            GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.UserImage), getParameters.PhotoPixelWidth);
                            entity.UserImage = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
                        }

                        var entityBasic = new gcsUserBasic(entity);
                        if (getParameters.IncludeMemberCollections)
                        {
                            FillMemberCollections(entityBasic, sessionData, getParameters);
                        }
                        results.Add(entityBasic);
                    }
                    return ArrayResponseHelpers.ToArrayResponse(results, getParameters.PageNumber, getParameters.PageSize, totalCount);
                }
                return new ArrayResponse<gcsUserBasic>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntities", ex);
                throw;
            }

        }

        public ArrayResponse<gcsUser> GetByPrimaryEntityId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.ByPrimaryEntityId;
                mgr.Entity.PrimaryEntityId = getParameters.UniqueId;
                if (mgr.Entity.PrimaryEntityId == Guid.Empty)
                    mgr.Entity.PrimaryEntityId = sessionData.CurrentEntityId;
                mgr.Entity.PageNumber = getParameters.PageNumber;
                mgr.Entity.PageSize = getParameters.PageSize;

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    var totalCount = 0;
                    // Blank out the password so it does not get returned to the client.
                    IList<gcsUser> results = new List<gcsUser>();
                    foreach (gcsUser entity in entities)
                    {
                        if (totalCount == 0)
                            totalCount = entity.TotalRowCount;
                        PrepareUserForReturning(entity, getParameters, sessionData);
                        results.Add(entity);
                    }
                    return ArrayResponseHelpers.ToArrayResponse(results, getParameters.PageNumber, getParameters.PageSize, totalCount);
                }
                return new ArrayResponse<gcsUser>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntities", ex);
                throw;
            }

        }

        protected override IEnumerable<gcsUser> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);

                    // Blank out the password so it does not get returned to the client.
                    IList<gcsUser> results = new List<gcsUser>();
                    foreach (gcsUser entity in entities)
                    {
                        PrepareUserForReturning(entity, getParameters, sessionData);
                        results.Add(entity);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsUser> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsUser GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsUser GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsUser result = new gcsUser();
                    SimpleMapper.PropertyMap(mgr.Entity, result);

                    PrepareUserForReturning(result, getParameters, sessionData);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        private gcsUser GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, Guid applicationId, IEnumerable<Guid> permissionsForEntityIds)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsUser result = new gcsUser();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    PrepareUserForReturningSignOnRequest(result, getParameters, sessionData, permissionsForEntityIds);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsUser originalEntity, gcsUser newEntity, string auditXml)
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
                        propertiesToIgnore.Add("AllEntities");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "UserId";
                        mgr.Entity.PrimaryKeyValue = newEntity.UserId;
                        mgr.Entity.RecordTag = newEntity.DisplayName;
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
                        mgr.Entity.PrimaryKeyColumn = "UserId";
                        mgr.Entity.PrimaryKeyValue = newEntity.UserId;
                        mgr.Entity.RecordTag = newEntity.DisplayName;
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
                        mgr.Entity.PrimaryKeyColumn = "UserId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.UserId;
                        mgr.Entity.RecordTag = originalEntity.DisplayName;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::SaveAuditData", ex);
                                                                                                                        //throw;
            }
        }

        protected override void FillMemberCollections(gcsUser entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {

        }

        protected void FillMemberCollections(gcsUserBasic entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var userEntityRepo = _dataRepositoryFactory.GetDataRepository<IGcsUserEntityRepository>();
            entity.Entities = userEntityRepo.GetMinimalByUserId(entity.UserId, getParameters);

        }

        public gcsUser GetByUserName(string userName, IApplicationUserSessionDataHeader sessionData, bool prepareForReturn)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.ByUserName;
                mgr.DataObject.Entity.UserName = userName;
                var results = mgr.BuildCollection();

                if (results != null && results.Count == 1)
                {
                    var users = mgr.ConvertPDSACollection(results);
                    foreach (var user in users)
                    {
                        if (prepareForReturn)
                            PrepareUserForReturning(user, null, sessionData);
                        return user;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        public gcsUser GetByEmail(string email, IApplicationUserSessionDataHeader sessionData, bool prepareForReturn)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.ByEmail;
                mgr.DataObject.Entity.Email = email;
                var results = mgr.BuildCollection();

                if (results != null && results.Count == 1)
                {
                    var users = mgr.ConvertPDSACollection(results);
                    foreach (var user in users)
                    {
                        if (prepareForReturn)
                            PrepareUserForReturning(user, null, sessionData);
                        return user;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        public PasswordValidationInfo IsPasswordValid(gcsUser user, bool isEncrypted)
        {
            var results = new PasswordValidationInfo();

            if (user == null)
            {
                results.Results.Add(new PasswordValidationItem()
                {
                    Result = PasswordValidationResult.InvalidParameter,
                    Message = string.Format(SharedResources.Resources.PasswordValidation_UserIsNull)
                });
                return results;
            }
            if (user.PrimaryEntityId == Guid.Empty)
            {
                results.Results.Add(new PasswordValidationItem()
                {
                    Result = PasswordValidationResult.InvalidParameter,
                    Message = $"{nameof(user.PrimaryEntityId)} {SharedResources.Resources.PasswordValidation_IsNotValid}"
                });
                return results;
            }

            if (results.Result != PasswordValidationResult.Valid)
                return results;

            // Retrieve the UserRequirements for the users' primary entity and validate the password accordingly
            // The password is encrypted coming into this method, so it must be decrypted to test for minimum character types
            var newPwd = user.UserPassword;
            if( isEncrypted)
                newPwd = Crypto.DecryptString(user.UserPassword, user.UserId.ToString());//user.LoginName);

            if (newPwd == string.Empty && user.UserId != Guid.Empty)
            {   // this means that the current password is not being changed, so don't bother validating anything
                results.Results.Add(new PasswordValidationItem()
                {
                    Result = PasswordValidationResult.Valid,
                    Message = string.Empty
                });
                return results;
            }

            if (newPwd.Contains(' '))
            {
                results.Results.Add(new PasswordValidationItem()
                {
                    Result = PasswordValidationResult.InvalidContainsIllegalContent,
                    Message = $"{SharedResources.Resources.PasswordValidation_InvalidContainsIllegalContent}"
                });
                return results;

            }

            var userRequirementsRepository = new GcsUserRequirementsRepository();
            var userReqs = userRequirementsRepository.GetByEntityId(user.PrimaryEntityId);
            var validator = new PasswordGeneratorValidator();
            var validationParameters = new ValidatePasswordParameters()
            {
                CustomRegularExpression = userReqs.PasswordCustomRegEx,
                MaximumLength = userReqs.PasswordMaximumLength,
                MinimumLength = userReqs.PasswordMinimumLength,
                RequiredLowerCaseCharacterCount = userReqs.RequireLowerCaseLetterCount,
                RequiredNumericDigitCount = userReqs.RequireNumericDigitCount,
                RequiredSpecialCharacterCount = userReqs.RequireSpecialCharacterCount,
                RequiredUpperCaseCharacterCount = userReqs.RequireUpperCaseLetterCount,
                UseCustomRegularExpression = userReqs.UseCustomRegEx
            };

            if (userReqs.PasswordCannotContainName)
            {
                validationParameters.AddIllegalContent(user.LastName);
                validationParameters.AddIllegalContent(user.FirstName);
                validationParameters.AddIllegalContent(user.DisplayName);
                validationParameters.AddIllegalContent(user.UserName);
                validationParameters.AddIllegalContent(user.UserInitials);
                validationParameters.AddIllegalContent(user.Email);
            }

            var validationResults = validator.ValidatePassword(newPwd, validationParameters).ToList();

            if (validationResults.Count > 0)
            {
                if (user.UserId == Guid.Empty)
                {
                    // New Users will have UserId value of Guid.Empty. There are no previous passwords to look at, so return the results
                    results.Results.Add(new PasswordValidationItem()
                    {
                        Result = PasswordValidationResult.Valid,
                        Message = string.Empty
                    });
                    return results;
                }

                foreach (var vr in validationResults)
                {
                    var validationItem = new PasswordValidationItem()
                    {
                        Result = vr
                    };

                    switch (vr)
                    {
                        case PasswordValidationResult.Valid:
                            validationItem.Message = string.Empty;
                            break;
                        case PasswordValidationResult.Unknown:
                            validationItem.Message = string.Empty;
                            break;
                        case PasswordValidationResult.InvalidIsEmpty:
                            validationItem.Message = $"{SharedResources.Resources.PasswordValidation_InvalidIsEmpty}";
                            break;
                        case PasswordValidationResult.InvalidLengthToShort:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InvalidLengthToShort,
                                    userReqs.PasswordMinimumLength);
                            break;
                        case PasswordValidationResult.InvalidLengthToLong:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InvalidLengthToLong,
                                    userReqs.PasswordMaximumLength);
                            break;
                        case PasswordValidationResult.InsufficientUpperCaseCharacters:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InsufficientUpperCaseCharacters,
                                    userReqs.RequireUpperCaseLetterCount);
                            break;
                        case PasswordValidationResult.InsufficientLowerCaseCharacters:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InsufficientLowerCaseCharacters,
                                    userReqs.RequireLowerCaseLetterCount);
                            break;
                        case PasswordValidationResult.InsufficientNumericDigits:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InsufficientNumericDigits,
                                    userReqs.RequireNumericDigitCount);
                            break;
                        case PasswordValidationResult.InsufficientSpecialCharacters:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InsufficientSpecialCharacters,
                                    userReqs.RequireSpecialCharacterCount);
                            break;
                        case PasswordValidationResult.InvalidMatchesPreviousPassword:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InvalidMatchesPreviousPassword,
                                    userReqs.MaintainPasswordHistoryCount);
                            break;
                        case PasswordValidationResult.InsufficientNumberOfCharactersChanged:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InsufficientNumberOfCharactersChanged,
                                    userReqs.PasswordMinimumLength);
                            break;
                        case PasswordValidationResult.InvalidContainsIllegalContent:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InvalidContainsIllegalContent);
                            break;
                        case PasswordValidationResult.InvalidDoesNotMatchRegularExpression:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InvalidDoesNotMatchRegularExpression,
                                    userReqs.PasswordCustomRegEx);
                            break;
                        case PasswordValidationResult.InvalidParameter:
                        default:
                            break;
                    }
                    results.Results.Add(validationItem);

                }

                //var userOldPasswordRepository = new GcsUserOldPasswordRepository();
                IEnumerable<gcsUserOldPassword> oldPasswords = _oldPasswordRepository.GetByUserId(user.UserId,
                    userReqs.MaintainPasswordHistoryCount);
                int x = 0;
                foreach (gcsUserOldPassword oldPassword in oldPasswords)
                {
                    String oldPwd = Crypto.DecryptString(oldPassword.Password, user.UserId.ToString());//user.LoginName);
                    if (newPwd == oldPwd)
                    {
                        results.Results.Clear();
                        results.Results.Add(new PasswordValidationItem()
                        {
                            Result = PasswordValidationResult.InvalidMatchesPreviousPassword,
                            Message = string.Format(SharedResources.Resources.PasswordValidation_InvalidMatchesPreviousPassword, userReqs.MaintainPasswordHistoryCount)
                        });
                        return results;
                    }

                    if (x == 0)
                    {
                        int differentCharacterCount = 0;
                        int pwdLen = newPwd.Length;
                        if (newPwd.Length > oldPwd.Length)
                            pwdLen = oldPwd.Length;

                        for (int c = 0; c < pwdLen; c++)
                        {
                            if (newPwd[c] != oldPwd[c])
                                differentCharacterCount++;
                        }

                        if (newPwd.Length > oldPwd.Length)
                        {
                            differentCharacterCount += newPwd.Length - oldPwd.Length;
                        }
                        else if (oldPwd.Length > newPwd.Length)
                        {
                            differentCharacterCount += oldPwd.Length - newPwd.Length;
                        }

                        if (differentCharacterCount < userReqs.PasswordMinimumChangeCharacters)
                        {
                            results.Results.Add(new PasswordValidationItem()
                            {
                                Result = PasswordValidationResult.InsufficientNumberOfCharactersChanged,
                                Message = string.Format(SharedResources.Resources.PasswordValidation_InsufficientNumberOfCharactersChanged, userReqs.PasswordMinimumChangeCharacters)
                            });
                        }
                    }
                    x++;
                }

                if (validationResults.Count == 0)
                {
                    results.Results.Add(new PasswordValidationItem()
                    {
                        Result = PasswordValidationResult.Valid,
                        Message = string.Empty
                    });
                }
            }
            return results;
        }

        public PasswordValidationInfo IsPasswordValid(gcsUserSave user)
        {
            var results = new PasswordValidationInfo();

            if (user == null)
            {
                results.Results.Add(new PasswordValidationItem()
                {
                    Result = PasswordValidationResult.InvalidParameter,
                    Message = string.Format(SharedResources.Resources.PasswordValidation_UserIsNull)
                });
                return results;
            }
            if (user.PrimaryEntityId == Guid.Empty)
            {
                results.Results.Add(new PasswordValidationItem()
                {
                    Result = PasswordValidationResult.InvalidParameter,
                    Message = $"{nameof(user.PrimaryEntityId)} {SharedResources.Resources.PasswordValidation_IsNotValid}"
                });
                return results;
            }

            if (results.Result != PasswordValidationResult.Valid)
                return results;

            // Retrieve the UserRequirements for the users' primary entity and validate the password accordingly
            // The password is encrypted coming into this method, so it must be decrypted to test for minimum character types
            String newPwd = Crypto.DecryptString(user.UserPassword, user.UserId.ToString());//user.LoginName);

            if (newPwd == string.Empty && user.UserId != Guid.Empty)
            {   // this means that the current password is not being changed, so don't bother validating anything
                results.Results.Add(new PasswordValidationItem()
                {
                    Result = PasswordValidationResult.Valid,
                    Message = string.Empty
                });
                return results;
            }

            var userRequirementsRepository = new GcsUserRequirementsRepository();
            var userReqs = userRequirementsRepository.GetByEntityId(user.PrimaryEntityId);
            var validator = new PasswordGeneratorValidator();
            var validationParameters = new ValidatePasswordParameters()
            {
                CustomRegularExpression = userReqs.PasswordCustomRegEx,
                MaximumLength = userReqs.PasswordMaximumLength,
                MinimumLength = userReqs.PasswordMinimumLength,
                RequiredLowerCaseCharacterCount = userReqs.RequireLowerCaseLetterCount,
                RequiredNumericDigitCount = userReqs.RequireNumericDigitCount,
                RequiredSpecialCharacterCount = userReqs.RequireSpecialCharacterCount,
                RequiredUpperCaseCharacterCount = userReqs.RequireUpperCaseLetterCount,
                UseCustomRegularExpression = userReqs.UseCustomRegEx
            };

            if (userReqs.PasswordCannotContainName)
            {
                validationParameters.AddIllegalContent(user.LastName);
                validationParameters.AddIllegalContent(user.FirstName);
                validationParameters.AddIllegalContent(user.DisplayName);
                validationParameters.AddIllegalContent(user.UserName);
                validationParameters.AddIllegalContent(user.UserInitials);
                validationParameters.AddIllegalContent(user.Email);
            }

            var validationResults = validator.ValidatePassword(newPwd, validationParameters).ToList();

            if (validationResults.Count > 0)
            {
                if (user.UserId == Guid.Empty)
                {
                    // New Users will have UserId value of Guid.Empty. There are no previous passwords to look at, so return the results
                    results.Results.Add(new PasswordValidationItem()
                    {
                        Result = PasswordValidationResult.Valid,
                        Message = string.Empty
                    });
                    return results;
                }

                foreach (var vr in validationResults)
                {
                    var validationItem = new PasswordValidationItem()
                    {
                        Result = vr
                    };

                    switch (vr)
                    {
                        case PasswordValidationResult.Valid:
                            validationItem.Message = string.Empty;
                            break;
                        case PasswordValidationResult.Unknown:
                            validationItem.Message = string.Empty;
                            break;
                        case PasswordValidationResult.InvalidIsEmpty:
                            validationItem.Message = $"{SharedResources.Resources.PasswordValidation_InvalidIsEmpty}";
                            break;
                        case PasswordValidationResult.InvalidLengthToShort:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InvalidLengthToShort,
                                    userReqs.PasswordMinimumLength);
                            break;
                        case PasswordValidationResult.InvalidLengthToLong:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InvalidLengthToLong,
                                    userReqs.PasswordMaximumLength);
                            break;
                        case PasswordValidationResult.InsufficientUpperCaseCharacters:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InsufficientUpperCaseCharacters,
                                    userReqs.RequireUpperCaseLetterCount);
                            break;
                        case PasswordValidationResult.InsufficientLowerCaseCharacters:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InsufficientLowerCaseCharacters,
                                    userReqs.RequireLowerCaseLetterCount);
                            break;
                        case PasswordValidationResult.InsufficientNumericDigits:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InsufficientNumericDigits,
                                    userReqs.RequireNumericDigitCount);
                            break;
                        case PasswordValidationResult.InsufficientSpecialCharacters:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InsufficientSpecialCharacters,
                                    userReqs.RequireSpecialCharacterCount);
                            break;
                        case PasswordValidationResult.InvalidMatchesPreviousPassword:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InvalidMatchesPreviousPassword,
                                    userReqs.MaintainPasswordHistoryCount);
                            break;
                        case PasswordValidationResult.InsufficientNumberOfCharactersChanged:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InsufficientNumberOfCharactersChanged,
                                    userReqs.PasswordMinimumLength);
                            break;
                        case PasswordValidationResult.InvalidContainsIllegalContent:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InvalidContainsIllegalContent);
                            break;
                        case PasswordValidationResult.InvalidDoesNotMatchRegularExpression:
                            validationItem.Message =
                                string.Format(SharedResources.Resources.PasswordValidation_InvalidDoesNotMatchRegularExpression,
                                    userReqs.PasswordCustomRegEx);
                            break;
                        case PasswordValidationResult.InvalidParameter:
                        default:
                            break;
                    }
                    results.Results.Add(validationItem);

                }

                //var userOldPasswordRepository = new GcsUserOldPasswordRepository();
                IEnumerable<gcsUserOldPassword> oldPasswords = _oldPasswordRepository.GetByUserId(user.UserId,
                    userReqs.MaintainPasswordHistoryCount);
                int x = 0;
                foreach (gcsUserOldPassword oldPassword in oldPasswords)
                {
                    String oldPwd = Crypto.DecryptString(oldPassword.Password, user.UserId.ToString());//user.LoginName);
                    if (newPwd == oldPwd)
                    {
                        results.Results.Add(new PasswordValidationItem()
                        {
                            Result = PasswordValidationResult.InvalidMatchesPreviousPassword,
                            Message = string.Format(SharedResources.Resources.PasswordValidation_InvalidMatchesPreviousPassword, userReqs.MaintainPasswordHistoryCount)
                        });
                        return results;
                    }

                    if (x == 0)
                    {
                        int differentCharacterCount = 0;
                        int pwdLen = newPwd.Length;
                        if (newPwd.Length > oldPwd.Length)
                            pwdLen = oldPwd.Length;

                        for (int c = 0; c < pwdLen; c++)
                        {
                            if (newPwd[c] != oldPwd[c])
                                differentCharacterCount++;
                        }

                        if (newPwd.Length > oldPwd.Length)
                        {
                            differentCharacterCount += newPwd.Length - oldPwd.Length;
                        }
                        else if (oldPwd.Length > newPwd.Length)
                        {
                            differentCharacterCount += oldPwd.Length - newPwd.Length;
                        }

                        if (differentCharacterCount < userReqs.PasswordMinimumChangeCharacters)
                        {
                            results.Results.Add(new PasswordValidationItem()
                            {
                                Result = PasswordValidationResult.InsufficientNumberOfCharactersChanged,
                                Message = string.Format(SharedResources.Resources.PasswordValidation_InsufficientNumberOfCharactersChanged, userReqs.PasswordMinimumChangeCharacters)
                            });
                        }
                    }
                    x++;
                }

                if (validationResults.Count == 0)
                {
                    results.Results.Add(new PasswordValidationItem()
                    {
                        Result = PasswordValidationResult.Valid,
                        Message = string.Empty
                    });
                }
            }
            return results;
        }
        public PasswordValidationInfo IsPasswordValidForEntityGuid(gcsUser user, Guid entityGuid)
        {
            if (user != null)
            {
                user.PrimaryEntityId = entityGuid;
            }
            return IsPasswordValid(user, true);
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

        protected override bool IsEntityUnique(gcsUser user)
        {
            if (string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Email))
            {
                if (user.Email.Length <= 100)
                    user.UserName = user.Email;
                else
                    user.UserName = user.Email.Substring(0, 100);
            }


            gcs_IsUserUniquePDSAManager mgr = new gcs_IsUserUniquePDSAManager();
            mgr.Entity.UserId = user.UserId;
            mgr.Entity.LoginName = user.UserName;
            mgr.Entity.EmailAddress = user.Email;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        public bool IsUnique(gcsUserSave user)
        {
            gcs_IsUserUniquePDSAManager mgr = new gcs_IsUserUniquePDSAManager();
            mgr.Entity.UserId = user.UserId;
            mgr.Entity.LoginName = user.UserName;
            mgr.Entity.EmailAddress = user.Email;
            var results = mgr.BuildCollection();
            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        public bool IsUniqueProperty(gcsUserSave user, ref string propertyName)
        {
            gcs_IsUserPropertyUniquePDSAManager mgr = new gcs_IsUserPropertyUniquePDSAManager();
            mgr.Entity.UserId = user.UserId;
            mgr.Entity.LoginName = user.UserName;
            mgr.Entity.EmailAddress = user.Email;
            var results = mgr.BuildCollection();
            propertyName = mgr.DataObject.AllParameters[4].Value?.ToString();
            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        public bool IsUniqueProperty(gcsUser user, ref string propertyName)
        {
            gcs_IsUserPropertyUniquePDSAManager mgr = new gcs_IsUserPropertyUniquePDSAManager();
            mgr.Entity.UserId = user.UserId;
            mgr.Entity.LoginName = user.UserName;
            mgr.Entity.EmailAddress = user.Email;
            var results = mgr.BuildCollection();
            propertyName = mgr.DataObject.AllParameters[4].Value?.ToString();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }


        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsUser", "UserId", id);
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

        public String GetPasswordForUser(Guid userId, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.PasswordForUser;
                mgr.DataObject.Entity.UserId = userId;
                var results = mgr.BuildCollection();
                if (results != null && results.Count == 1)
                {
                    var users = mgr.ConvertPDSACollection(results);
                    foreach (var user in users)
                    {
                        return user.UserPassword;
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetPasswordForUser", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserOldPassword> GetOldPasswordsForUser(gcsUser user, int howMany, IApplicationUserSessionDataHeader sessionData)
        {
            if (howMany < 0)
            {
                var userRequirementsRepository = new GcsUserRequirementsRepository();
                var userReqs = userRequirementsRepository.GetByEntityId(user.PrimaryEntityId);
                if (userReqs != null)
                    howMany = userReqs.MaintainPasswordHistoryCount;
                else
                    howMany = 0;
            }

            //GcsUserOldPasswordRepository userOldPasswordRepository = new GcsUserOldPasswordRepository();
            var oldPasswords = _oldPasswordRepository.GetByUserId(user.UserId, howMany).ToCollection();
            oldPasswords.Add(new gcsUserOldPassword() { Password = GetPasswordForUser(user.UserId, sessionData) });

            return oldPasswords;
        }

        public UserSignInResult SignInRequest(UserSignInRequest requestData, IApplicationUserSessionDataHeader sessionData, TwoFactorAuthParameters twoFactorAuthParameters)
        {
            try
            {
                var result = new UserSignInResult
                {
                    RequestData = requestData
                };

                var twoFactorToken = string.Empty;

                if (string.IsNullOrEmpty(sessionData.UserName))
                    sessionData.UserName = requestData.UserName;
                var applicationAuditRepository = new GcsApplicationAuditRepository();
                var applicationAudit = applicationAuditRepository.CreateApplicationAuditInstance(sessionData);
                applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInRequest;
                applicationAudit.LoginName = requestData.UserName;
                applicationAudit.InsertName = sessionData.UserName;
                applicationAuditRepository.InsertEntity(applicationAudit, sessionData);

                applicationAudit = applicationAuditRepository.CreateApplicationAuditInstance(sessionData);

                gcsUserPDSAManager mgr = new gcsUserPDSAManager();

                switch (requestData.SignInBy)
                {
                    case SignInUsing.UserName:
                        mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.ByUserName;
                        mgr.DataObject.Entity.UserName = requestData.UserName;
                        break;
                    case SignInUsing.Email:
                        mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.ByEmail;
                        mgr.DataObject.Entity.Email = requestData.UserName;
                        break;
                    case SignInUsing.AutoDetect:
                        if (requestData.UserName.IsValidEmailAddress())
                        {
                            mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.ByEmail;
                            mgr.DataObject.Entity.Email = requestData.UserName;
                        }
                        else
                        {
                            mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.ByUserNameOrEmail;
                            mgr.DataObject.Entity.UserName = requestData.UserName;
                            mgr.DataObject.Entity.Email = requestData.UserName;
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var results = mgr.BuildCollection();
                if (results != null && results.Count == 1)
                {
                    var users = mgr.ConvertPDSACollection(results).ToArray();
                    var user = users[0];
                    if (user != null)
                    {
                        applicationAudit.UserId = user.UserId;
                        var encryptPasspharase = requestData.SignInRequestDateTime.Ticks.ToString();
                        foreach (var ipAddr in requestData.ComputerInformation.IPAddresses)
                            encryptPasspharase += ipAddr;
                        encryptPasspharase += requestData.ComputerInformation.MachineName;
                        encryptPasspharase += requestData.ApplicationName;
                        encryptPasspharase += requestData.ComputerInformation.DomainName;
                        encryptPasspharase += requestData.CurrentWindowsUserIdentity?.DomainName;
                        encryptPasspharase += requestData.CurrentWindowsUserIdentity?.Name;
                        encryptPasspharase += requestData.ApplicationId.ToString();
                        var decryptedRequestPassword = Crypto.DecryptString(requestData.Password, encryptPasspharase);
                        requestData.Password = decryptedRequestPassword;

                        var encryptedPassword = Crypto.EncryptString(requestData.Password, user.UserId.ToString());
                        requestData.Password = string.Empty;
                        if (encryptedPassword != user.UserPassword)
                        {
                            result.RequestResult = UserSignInRequestResult.InvalidPassword;
                            applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultInvalidPassword;
                        }
                        else
                        {
                            // The user name and password are valid, now check the various flags and date requirements
                            //if (user.IsActive != true || (user.UserActivationDate.IsValueNotEquivalentToSqlNull() && user.UserActivationDate.Value > DateTimeOffset.Now) || (user.UserExpirationDate.IsValueNotEquivalentToSqlNull() && user.UserExpirationDate.Value < DateTimeOffset.Now))                            //if (user.IsActive != true || (user.UserActivationDate.IsValueNotEquivalentToSqlNull() && user.UserActivationDate.Value > DateTimeOffset.Now) || (user.UserExpirationDate.IsValueNotEquivalentToSqlNull() && user.UserExpirationDate.Value < DateTimeOffset.Now))
                            //{
                            //    result.RequestResult = UserSignInRequestResult.UserAccountIsNotActive;
                            //    applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultUserAccountIsNotActive;
                            //}
                            if (user.IsActive != true || (user.UserActivationDate.IsValueNotEquivalentToSqlNull() && user.UserActivationDate.Value > DateTimeOffset.Now) || (user.UserExpirationDate.IsValueNotEquivalentToSqlNull() && user.UserExpirationDate.Value < DateTimeOffset.Now))
                            {
                                result.RequestResult = UserSignInRequestResult.UserAccountIsNotActive;
                                applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultUserAccountIsNotActive;
                            }
                            else if (user.IsLockedOut != false)
                            {
                                result.RequestResult = UserSignInRequestResult.UserAccountIsLockedOut;
                                applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultUserAccountIsLockedOut;
                            }
                            else
                            {
                                // if the basics are OK, now grab the UserRequirements for the users PrimaryEntity and verify against those requirements
                                var userRequirementsRepository = new GcsUserRequirementsRepository();
                                var userRequirements = userRequirementsRepository.GetByEntityId(user.PrimaryEntityId);
                                if (userRequirements != null)
                                {
                                    if (userRequirements.LockoutUserIfInactiveForDays > 0)
                                    {
                                        // If a LockoutUserIfInactiveForDays is specified, compare against the user LastLoginDate for the user
                                        DateTimeOffset lastLoginTime = user.InsertDate;

                                        if (user.LastLoginDate.HasValue)
                                        {
                                            if (user.LastLoginDate.Value.Date > SqlDateTime.MinValue)
                                            {
                                                lastLoginTime = user.LastLoginDate.Value;
                                            }
                                        }

                                        if (user.IsLockedOutClearedDate.HasValue && user.IsLockedOutClearedDate.Value > lastLoginTime)
                                        {
                                            lastLoginTime = user.IsLockedOutClearedDate.Value;
                                        }

                                        if ((DateTimeOffset.Now - lastLoginTime).TotalDays > userRequirements.LockoutUserIfInactiveForDays)
                                        {
                                            // The user hasn't signed in in a while, longer than the allowable # of days as specified by userRequirements.LockoutUserIfInactiveForDays
                                            result.RequestResult = UserSignInRequestResult.UserAccountIsLockedOut;
                                            applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultUserAccountIsLockedOut;

                                            // Update the users IsLockedOut property to false
                                            mgr.DataObject.LoadByPK(user.UserId);
                                            mgr.DataObject.Entity.IsLockedOut = true;
                                            mgr.DataObject.UpdateFilter = gcsUserPDSAData.UpdateFilters.UpdateIsLockedOut;
                                            mgr.DataObject.Update();
                                        }
                                    }

                                    if (result.RequestResult == UserSignInRequestResult.Unknown)
                                    {
                                        if (userRequirements.RequireTwoFactorAuthentication && twoFactorAuthParameters != null)
                                        {
                                            if (user.PhoneNumberConfirmed || user.EmailConfirmed)
                                            {
                                                var tempToken = GCS.Framework.Security.RandomTokenGenerator.GenerateRandomNumber();
                                                twoFactorToken = tempToken.ToString();

                                                var settingsRepo = new GcsSettingRepository();

                                                if (!string.IsNullOrEmpty(user.PhoneNumber) && user.PhoneNumberConfirmed == true)
                                                {
                                                    var twilioSettings = GetTwilioSettings(sessionData, settingsRepo, user.PrimaryEntityId);

                                                    if (twilioSettings.Sid != MagicStrings.EnterValueHere &&
                                                        twilioSettings.AuthToken != MagicStrings.EnterValueHere &&
                                                        twilioSettings.PhoneNumber != MagicStrings.EnterValueHere)
                                                    {
                                                        // sent text message
                                                        string messageBody = string.Empty;
                                                        Task.Run(async () =>
                                                        {
                                                            var parameters = new List<KeyValuePair<string, string>>();
                                                            parameters.Add(new KeyValuePair<string, string>("{subject}", twoFactorAuthParameters.TwoFactorAuthTokenEmailSubject));
                                                            parameters.Add(new KeyValuePair<string, string>("{twoFactorToken}", twoFactorToken));
                                                            parameters.Add(new KeyValuePair<string, string>("{tokenLifespan}", twoFactorAuthParameters.TwoFactorTokenLifespan.ToString()));

                                                            messageBody = await Create2FATokenSMSBody(twoFactorAuthParameters.TwoFactorAuthTokenSmsTemplate, parameters);
                                                        }).Wait();
                                                        var smsHandler = new GCS.Framework.Sms.GcsSmsHandler(twilioSettings.Sid, twilioSettings.AuthToken);

                                                        // Purposely don't await. This is a fire and forget operation
                                                        smsHandler.SendMessage(user.PhoneNumber, twilioSettings.PhoneNumber, messageBody);
                                                    }
                                                }

                                                if (!string.IsNullOrEmpty(user.Email) && user.EmailConfirmed == true)
                                                {
                                                    var mailSettings = GetMailServerSettings(sessionData, settingsRepo, user.PrimaryEntityId);

                                                    if (mailSettings.Host != MagicStrings.EnterValueHere &&
                                                        mailSettings.UserName != MagicStrings.EnterValueHere &&
                                                        mailSettings.Password != MagicStrings.EnterValueHere)
                                                    {
                                                        string emailBody = string.Empty;
                                                        Task.Run(async () =>
                                                        {
                                                            var parameters = new List<KeyValuePair<string, string>>();
                                                            parameters.Add(new KeyValuePair<string, string>("{subject}", twoFactorAuthParameters.TwoFactorAuthTokenEmailSubject));
                                                            parameters.Add(new KeyValuePair<string, string>("{twoFactorToken}", twoFactorToken));
                                                            parameters.Add(new KeyValuePair<string, string>("{tokenLifespan}", twoFactorAuthParameters.TwoFactorTokenLifespan.ToString()));

                                                            emailBody = await Create2FATokenEmailBody(twoFactorAuthParameters.TwoFactorAuthTokenEmailTemplate, parameters);
                                                        }).Wait();
                                                        var emailSender = new GCS.Framework.Email.GcsEmailSender(mailSettings.Host, mailSettings.HostPort, mailSettings.UseSSL, mailSettings.UserName, mailSettings.Password);
                                                        // Purposely don't await. This is a fire and forget operation
                                                        emailSender.SendEmailAsync(user.Email, mailSettings.UserName,
                                                            twoFactorAuthParameters.TwoFactorAuthTokenEmailSubject,
                                                            emailBody);
                                                    }
                                                }
                                            }
                                            else
                                            {   // two factor required but neither the phone # or email have been confirmed

                                                result.RequestResult = UserSignInRequestResult.EmailAndPhoneNumberNotConfirmed;
                                            }
                                        }


                                        if (result.RequestResult != UserSignInRequestResult.EmailAndPhoneNumberNotConfirmed)
                                        {
                                            // if the result has still not been determined, now check the password age and set the result accordingly
                                            if (userRequirements.MaximumPasswordAge > 0)
                                            {
                                                // If a MaximumPasswordAge is specified, compare against the LastPasswordResetDate for the user
                                                DateTimeOffset lastPasswordResetDate = user.InsertDate; // default to the user insertdate in case the password has never been changed

                                                if (user.LastPasswordResetDate.HasValue)
                                                {
                                                    if (user.LastPasswordResetDate.Value.Date > SqlDateTime.MinValue)
                                                    {
                                                        lastPasswordResetDate = user.LastPasswordResetDate.Value;
                                                    }
                                                }

                                                if ((DateTimeOffset.Now - lastPasswordResetDate).TotalDays >
                                                    userRequirements.MaximumPasswordAge)
                                                {
                                                    // The user hasn't signed in in a while, longer than the allowable # of days as specified by userRequirements.MaximumPasswordAge
                                                    result.RequestResult = UserSignInRequestResult.SuccessWithInfo;
                                                    result.SuccessInformation.Add(SuccessInfo.PasswordMustBeChanged);
                                                    result.SuccessInformationMessages.Add(Resources.Resources.UserSignOn_SuccessInfo_PasswordMustBeChanged);
                                                    result.PasswordChangeDays =
                                                        Convert.ToInt32(
                                                            (DateTimeOffset.Now - lastPasswordResetDate).TotalDays);
                                                    applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds
                                                        .GalaxySMS_UserSignInSuccessInfoPasswordMustBeChanged;
                                                }
                                                else
                                                {
                                                    result.RequestResult = UserSignInRequestResult.Success;
                                                    applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultSuccess;
                                                }
                                            }
                                            else
                                            {
                                                // There is no maximumPasswordAge specified
                                                result.RequestResult = UserSignInRequestResult.Success;
                                                applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultSuccess;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // there are no user requirements
                                    result.RequestResult = UserSignInRequestResult.Success;
                                    applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultSuccess;
                                }
                                if (result.RequestResult == UserSignInRequestResult.Success || result.RequestResult == UserSignInRequestResult.SuccessWithInfo)
                                {
                                    mgr.DataObject.LoadByPK(user.UserId);
                                    mgr.DataObject.UpdateFilter = gcsUserPDSAData.UpdateFilters.UpdateLastLoginDate;
                                    mgr.DataObject.Entity.LastLoginDate = DateTimeOffset.Now;
                                    mgr.DataObject.Update();
                                    if (user.UserExpirationDate.HasValue && user.UserExpirationDate.Value > DateTimeOffset.Now)
                                    {
                                        if ((user.UserExpirationDate.Value - DateTimeOffset.Now).TotalDays <= 14)
                                        {
                                            result.RequestResult = UserSignInRequestResult.SuccessWithInfo;
                                            result.SuccessInformation.Add(SuccessInfo.UserAccountSoonToExpire);
                                            result.SuccessInformationMessages.Add(Resources.Resources.UserSignOn_SuccessInfo_UserAccountSoonToExpire);
                                            result.AccountSoonToExpireDays = Convert.ToInt32((user.UserExpirationDate.Value - DateTimeOffset.Now).TotalDays);
                                            applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInSuccessInfoUserAccountSoonToExpire;
                                        }
                                    }

                                    if (user.ResetPasswordFlag)
                                    {
                                        result.RequestResult = UserSignInRequestResult.SuccessWithInfo;
                                        result.SuccessInformation.Add(SuccessInfo.PasswordMustBeChanged);
                                        result.SuccessInformationMessages.Add(Resources.Resources.UserSignOn_SuccessInfo_PasswordMustBeChanged);
                                        //                                        applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInSuccessInfoPasswordMustBeChanged;
                                    }

                                    //result.SessionToken = GetUserSessionTokenForApplications(user.UserId, requestData.ApplicationId, requestData.PermissionsForApplicationIds, requestData.IncludeEntityPhotos, requestData.EntityPhotosPixelWidth, requestData.IncludeUserPhotos, requestData.UserPhotosPixelWidth);
                                    var getPermissionsForEntityIds = new List<Guid>();
                                    getPermissionsForEntityIds.Add(user.PrimaryEntityId);
                                    if (user.PrimaryEntityId != EntityIds.GalaxySMS_SystemEntity_Id)
                                        getPermissionsForEntityIds.Add(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id);
                                    result.SessionToken = GetUserSessionTokenForSignInRequest(user.UserId, requestData.ApplicationId, requestData.PermissionsForApplicationIds, requestData.IncludeEntityPhotos, requestData.EntityPhotosPixelWidth, requestData.IncludeUserPhotos, requestData.UserPhotosPixelWidth, getPermissionsForEntityIds, sessionData);
                                    result.SessionToken.RequestData = requestData;
                                    if (result.SessionToken.ApplicationId == Guid.Empty)
                                    {
                                        applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultApplicationNotPermitted;
                                        result.RequestResult = UserSignInRequestResult.ApplicationNotPermitted;
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(twoFactorToken))
                                            result.RequestResult = UserSignInRequestResult.MustProvideTwoFactorToken;

                                        var sessionMgr = new GcsUserSessionRepository();
                                        sessionMgr.Add(new gcsUserSession()
                                        {
                                            gcsUserSessionUid = result.SessionToken.SessionId,
                                            ApplicationId = result.SessionToken.ApplicationId,
                                            ApplicationName = result.SessionToken.ApplicationName,
                                            UserId = result.SessionToken.UserData.UserId,
                                            UserName = result.SessionToken.UserData.UserName,
                                            TwoFactorToken = twoFactorToken,
                                            InsertName = sessionData.UserName,
                                            InsertDate = DateTimeOffset.Now,
                                            UpdateName = sessionData.UserName,
                                            UpdateDate = DateTimeOffset.Now
                                        }, sessionData, null);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        result.RequestResult = UserSignInRequestResult.InvalidUserName;
                        applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultInvalidUserName;
                    }
                }
                else
                {
                    result.RequestResult = UserSignInRequestResult.InvalidUserName;
                    applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultInvalidUserName;
                }

                if (applicationAudit.ApplicationAuditTypeId != Guid.Empty)
                {
                    applicationAudit.LoginName = requestData.UserName;
                    applicationAudit.InsertDate = DateTimeOffset.Now;
                    applicationAudit.InsertName = sessionData.UserName;
                    applicationAuditRepository.InsertEntity(applicationAudit, sessionData);
                }

                return result;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::SignInRequest", ex);
                throw;
            }
        }

        private static MailServerSettings GetMailServerSettings(IApplicationUserSessionDataHeader sessionData,
            GcsSettingRepository settingsRepo, Guid entityId)
        {
            var mailSettings = new MailServerSettings();
            mailSettings.Host = settingsRepo.GetByUniqueKey(entityId,
                GCS.Core.Common.Utils.SystemUtilities.MyProcessName,
                MagicStrings.Security,
                MagicStrings.EmailHost, MagicStrings.EnterValueHere, true, sessionData);

            mailSettings.HostPort = settingsRepo.GetByUniqueKey(entityId,
                GCS.Core.Common.Utils.SystemUtilities.MyProcessName,
                MagicStrings.Security,
                MagicStrings.EmailHostPort, 587, true, sessionData);

            mailSettings.UseSSL = settingsRepo.GetByUniqueKey(entityId,
                GCS.Core.Common.Utils.SystemUtilities.MyProcessName,
                MagicStrings.Security,
                MagicStrings.EmailUsesSSL, true, true, sessionData);

            mailSettings.UserName = settingsRepo.GetByUniqueKey(entityId,
                GCS.Core.Common.Utils.SystemUtilities.MyProcessName,
                MagicStrings.Security,
                MagicStrings.EmailUserName, MagicStrings.EnterValueHere, true, sessionData);

            mailSettings.Password = settingsRepo.GetByUniqueKey(entityId,
                GCS.Core.Common.Utils.SystemUtilities.MyProcessName,
                MagicStrings.Security,
                MagicStrings.EmailPassword, MagicStrings.EnterValueHere, true, sessionData);
            return mailSettings;
        }

        private static TwilioSettings GetTwilioSettings(IApplicationUserSessionDataHeader sessionData, GcsSettingRepository settingsRepo, Guid entityId)
        {
            var data = new TwilioSettings();
            data.Sid = settingsRepo.GetByUniqueKey(entityId,
                GCS.Core.Common.Utils.SystemUtilities.MyProcessName,
                MagicStrings.Security,
                MagicStrings.TwilioSid, MagicStrings.EnterValueHere, true, sessionData);

            data.AuthToken = settingsRepo.GetByUniqueKey(entityId,
                GCS.Core.Common.Utils.SystemUtilities.MyProcessName,
                MagicStrings.Security,
                MagicStrings.TwilioAuthToken, MagicStrings.EnterValueHere, true, sessionData);

            data.PhoneNumber = settingsRepo.GetByUniqueKey(entityId,
                GCS.Core.Common.Utils.SystemUtilities.MyProcessName,
                MagicStrings.Security,
                MagicStrings.TwilioPhoneNumber, MagicStrings.EnterValueHere, true, sessionData);
            return data;
        }


        private async Task<string> Create2FATokenEmailBody(string templateFilename, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var body = string.Empty;
            if (!File.Exists(templateFilename))
            {
                body = "<!DOCTYPE html><html><head><title>{subject}</title></head><body><h1>{subject}</h1><p>Your token value is {twoFactorToken}. The token is valid for {tokenLifespan} minutes.</p></body></html>";
            }
            else
            {
                using (StreamReader reader = new StreamReader(templateFilename))
                {
                    body = await reader.ReadToEndAsync();
                }
            }
            foreach (var kvp in parameters)
            {
                body = body.Replace(kvp.Key, kvp.Value);
            }
            return body;
        }


        private async Task<string> Create2FATokenSMSBody(string templateFilename, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var body = string.Empty;
            if (!File.Exists(templateFilename))
            {
                body = "GalaxySMS Two Factor One-Time Use Access Token. Your token value is {twoFactorToken}. The token is valid for {tokenLifespan} minutes.";
            }
            else
            {
                using (StreamReader reader = new StreamReader(templateFilename))
                {
                    body = await reader.ReadToEndAsync();
                }
            }
            foreach (var kvp in parameters)
            {
                body = body.Replace(kvp.Key, kvp.Value);
            }
            return body;
        }

        private async Task<string> CreatePasswordResetTokenEmailBody(string templateFilename, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var body = string.Empty;
            if (!File.Exists(templateFilename))
            {
                body = "<!DOCTYPE html><html><head><title>{subject}</title></head><body><h1>{subject}</h1><p>Your token value is {token}. The token is valid for {tokenLifespan} minutes.</p></body></html>";
            }
            else
            {
                using (StreamReader reader = new StreamReader(templateFilename))
                {
                    body = await reader.ReadToEndAsync();
                }
            }
            foreach (var kvp in parameters)
            {
                body = body.Replace(kvp.Key, kvp.Value);
            }
            return body;
        }


        private async Task<string> CreatePasswordResetTokenSMSBody(string templateFilename, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var body = string.Empty;
            if (!File.Exists(templateFilename))
            {
                body = "GalaxySMS Password Reset One-Time Use Access Token. Your token value is {token}. The token is valid for {tokenLifespan} minutes.";
            }
            else
            {
                using (StreamReader reader = new StreamReader(templateFilename))
                {
                    body = await reader.ReadToEndAsync();
                }
            }
            foreach (var kvp in parameters)
            {
                body = body.Replace(kvp.Key, kvp.Value);
            }
            return body;
        }

        public bool VerifyTwoFactorAuthenticationToken(TwoFactorAuthenticationData requestData, IApplicationUserSessionDataHeader sessionData, int tokenLifespan)
        {
            if (requestData.SessionId != sessionData.SessionGuid)
                return false;
            if (requestData.SessionId == Guid.Empty)
                return false;

            if (string.IsNullOrEmpty(requestData.TwoFactorToken))
                return false;

            var sessionMgr = new GcsUserSessionRepository();
            var session = sessionMgr.Get(requestData.SessionId, sessionData, null);
            if (session == null)
                return false;

            if (string.IsNullOrEmpty(session.TwoFactorToken))
                return false;
            var token = session.TwoFactorToken;
            // clear it out of the database
            session.TwoFactorToken = "******";
            sessionMgr.Update(session, sessionData, null);

            if (token == requestData.TwoFactorToken.Trim() && DateTimeOffset.Now < session.InsertDate + TimeSpan.FromMinutes(tokenLifespan))
                return true;
            return false;
        }

        private UserSessionToken GetUserSessionTokenForApplication(Guid userId, Guid applicationId)
        {
            var result = new UserSessionToken();
            result.SessionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
            var user = GetEntityByGuidId(userId, null, null);

            result.UserData = new UserData(user, true);
            var permissionRepository = new gcsPermissionRepository();
            foreach (var entity in user.AllEntities)
            {
                if (entity.IsAuthorized && entity.IsActive)
                {
                    var userEntity = new UserEntity(entity);

                    var roles = (from r in entity.AllRoles where r.IsAuthorized == true select r).ToList();
                    foreach (var role in roles)
                    {
                        var userRole = new UserRole(role);
                        var permissions = permissionRepository.GetAllPermissionsForRole(role.RoleId, null);
                        foreach (var permission in permissions)
                        {
                            var userPermission = new UserPermission(permission);
                            userRole.UserPermissions.Add(userPermission);
                        }
                        userEntity.UserRoles.Add(userRole);
                    }
                    result.UserData.UserEntities.Add(userEntity);
                    if (userEntity.EntityId == user.PrimaryEntityId)
                        result.CurrentEntityId = user.PrimaryEntityId;
                }
            }

            return result;
        }

        public UserEntity GetUserEntityViaSp(Guid userId, Guid entityId)
        {
            var userHasEntity = DoesUserHaveEntity(userId, entityId);
            if (userHasEntity)
            {
                var mgr = new GetPermissionsForUserEntityPDSAManager();
                mgr.Entity.userId = userId;
                mgr.Entity.entityId = entityId;
                mgr.Entity.permissionCategoryId = Guid.Empty;
                var data = mgr.BuildCollection();

                if (data.Count > 0)
                {
                    var userEntity = new UserEntity();
                    var first = data.First();
                    userEntity.EntityDescription = first.EntityDescription;
                    userEntity.EntityName = first.EntityName;
                    userEntity.EntityId = first.EntityId;
                    userEntity.ParentEntityId = first.ParentEntityId;
                    userEntity.IsActive = true;
                    var distinctRoles = data.GroupBy(o => new { o.RoleId, o.RoleName, o.IsAdministratorRole })
                        .Select(y => new
                        {
                            RoleId = y.Key.RoleId,
                            RoleName = y.Key.RoleName,
                            IsAdministratorRole = y.Key.IsAdministratorRole
                        }
                        ).ToList();

                    foreach (var r in distinctRoles)
                    {

                        var userRole = new UserRole()
                        {
                            RoleId = r.RoleId,
                            RoleName = r.RoleName,
                            IsActive = true,
                            IsAdministratorRole = r.IsAdministratorRole
                        };
                        var rolePerms = data.Where(o => o.RoleId == r.RoleId);
                        foreach (var p in rolePerms)
                        {
                            userRole.UserPermissions.Add(new UserPermission()
                            {
                                PermissionId = p.PermissionId,
                                PermissionName = p.PermissionName,
                            });
                        }
                        userEntity.UserRoles.Add(userRole);
                    }


                    return userEntity;
                }
            }

            return null;
        }

        public IEnumerable<Guid> GetPermissionIdsForUserEntityPermissionCategory(Guid userId, Guid entityId, Guid permissionCategoryId)
        {
            var results = new List<Guid>();
            var userHasEntity = DoesUserHaveEntity(userId, entityId);
            if (userHasEntity)
            {
                var mgr = new GetPermissionsForUserEntityPDSAManager();
                mgr.Entity.userId = userId;
                mgr.Entity.entityId = entityId;
                mgr.Entity.permissionCategoryId = permissionCategoryId;
                var data = mgr.BuildCollection();
                results.AddRange(data.Select(o => o.PermissionId));
            }

            return results;

        }
        //public UserSessionToken GetUserSessionTokenForApplications(Guid userId, Guid applicationId, IEnumerable<Guid> applicationIds, bool bIncludeEntityPhotos, int entityPhotosPixelWidth, bool bIncludeUserImages, int userImagesPixelWidth)
        //{
        //    this.Log().Info($"Building UserSessionToken...");

        //    var result = new UserSessionToken();
        //    result.SessionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
        //    var getParams = new GetParametersWithPhoto()
        //    {
        //        IncludePhoto = bIncludeEntityPhotos,
        //        PhotoPixelWidth = entityPhotosPixelWidth,
        //    };

        //    //var user = GetEntityByGuidId(userId, null, null);
        //    var user = GetEntityByGuidId(userId, null, getParams);

        //    result.UserData = new UserData(user, bIncludeUserImages);
        //    if (userImagesPixelWidth > 0)
        //    {
        //        if (result.UserData.UserImage != null)
        //        {
        //            var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
        //            GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(result.UserData.UserImage), userImagesPixelWidth);
        //            result.UserData.UserImage = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
        //        }

        //        if (result.UserData.SecurityImage != null)
        //        {
        //            var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
        //            GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(result.UserData.SecurityImage), userImagesPixelWidth);
        //            result.UserData.SecurityImage = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
        //        }
        //    }

        //    var permissionRepository = new gcsPermissionRepository();
        //    foreach (var entity in user.AllEntities)
        //    {
        //        if (entity.IsAuthorized && entity.IsActive)
        //        {
        //            var userEntity = new UserEntity(entity);

        //            var application =
        //                (from a in entity.AllApplications
        //                 where (a.ApplicationId == applicationId && a.IsAuthorized == true)
        //                 select a).FirstOrDefault();
        //            if (application != null)
        //            {
        //                result.ApplicationId = application.ApplicationId;
        //                result.ApplicationName = application.ApplicationName;
        //                var userApplication = new UserApplication(application);

        //                //var roles = (from r in application.AllRoles where r.IsAuthorized == true select r).ToList();
        //                //foreach (var role in roles)
        //                //{
        //                //    var userRole = new UserRole(role);
        //                //    var permissions = permissionRepository.GetAllPermissionsForRole(role.RoleId, null);
        //                //    foreach (var permission in permissions)
        //                //    {
        //                //        var userPermission = new UserPermission(permission);
        //                //        userRole.UserPermissions.Add(userPermission);
        //                //    }

        //                //    userApplication.UserRoles.Add(userRole);
        //                //}
        //                userEntity.UserApplications.Add(userApplication);
        //            }


        //            foreach (var appId in applicationIds)
        //            {
        //                application = (from a in entity.AllApplications
        //                               where (a.ApplicationId == appId && a.IsAuthorized == true)
        //                               select a).FirstOrDefault();
        //                if (application != null)
        //                {
        //                    var userApplication = new UserApplication(application);

        //                    //var roles = (from r in application.AllRoles where r.IsAuthorized == true select r).ToList();
        //                    //foreach (var role in roles)
        //                    //{
        //                    //    var userRole = new UserRole(role);
        //                    //    var permissions = permissionRepository.GetAllPermissionsForRole(role.RoleId, null);
        //                    //    foreach (var permission in permissions)
        //                    //    {
        //                    //        var userPermission = new UserPermission(permission);
        //                    //        userRole.UserPermissions.Add(userPermission);
        //                    //    }

        //                    //    userApplication.UserRoles.Add(userRole);
        //                    //}
        //                    userEntity.UserApplications.Add(userApplication);
        //                }
        //            }

        //            if (userEntity.UserApplications.FirstOrDefault(a => a.ApplicationId == applicationId) !=
        //                null)
        //            {
        //                result.UserData.UserEntities.Add(userEntity);
        //                if (userEntity.EntityId == user.PrimaryEntityId)
        //                    result.CurrentEntityId = user.PrimaryEntityId;
        //            }
        //        }
        //    }

        //    // Generate the UserEntity children 
        //    foreach (var ue in result.UserData.UserEntities)
        //    {
        //        var children = result.UserData.UserEntities.Where(o => o.ParentEntityId == ue.EntityId).ToCollection();
        //        ue.ChildUserEntities = children;
        //    }

        //    if (result.UserData.LanguageId.HasValue)
        //    {
        //        if (result.UserData.LanguageId == Guid.Empty)
        //            result.UserData.LanguageId = GalaxySMS.Common.Constants.LanguageIds.GalaxySMS_EN_US_Language_Id;
        //        var langRepository = new GcsLanguageRepository();
        //        var lang = langRepository.Get(result.UserData.LanguageId.Value, null, null);
        //        if (lang == null)
        //            result.UserData.LanguageCulture = GalaxySMS.Common.Constants.LanguageCultures.EnglishUs;
        //        else
        //            result.UserData.LanguageCulture = lang.CultureName;
        //    }

        //    this.Log().Info($"Finished building UserSessionToken...");

        //    return result;
        //}

        public UserSessionToken GetUserSessionTokenForApplications(Guid userId, Guid applicationId, UserSignInRequest requestData)
        {
            this.Log().Info($"Building UserSessionToken...");

            var result = new UserSessionToken();
            result.SessionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
            var getParams = new GetParametersWithPhoto()
            {
                IncludePhoto = requestData.IncludeEntityPhotos,
                PhotoPixelWidth = requestData.EntityPhotosPixelWidth,
            };

            //var user = GetEntityByGuidId(userId, null, null);
            var user = GetEntityByGuidId(userId, null, getParams);

            result.UserData = new UserData(user, requestData.IncludeUserPhotos);
            if (requestData.UserPhotosPixelWidth > 0)
            {
                if (result.UserData.UserImage != null)
                {
                    var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                    GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(result.UserData.UserImage), requestData.UserPhotosPixelWidth);
                    result.UserData.UserImage = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
                }

                if (result.UserData.SecurityImage != null)
                {
                    var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                    GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(result.UserData.SecurityImage), requestData.UserPhotosPixelWidth);
                    result.UserData.SecurityImage = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
                }
            }

            var permissionRepository = new gcsPermissionRepository();
            foreach (var entity in user.AllEntities)
            {
                if (entity.IsAuthorized && entity.IsActive)
                {
                    var userEntity = new UserEntity(entity);

                    var roles = (from r in entity.AllRoles where r.IsAuthorized == true select r).ToList();
                    foreach (var role in roles)
                    {
                        var userRole = new UserRole(role);
                        var permissions = permissionRepository.GetAllPermissionsForRole(role.RoleId, null);
                        foreach (var permission in permissions)
                        {
                            var userPermission = new UserPermission(permission);
                            userRole.UserPermissions.Add(userPermission);
                        }

                        userEntity.UserRoles.Add(userRole);
                    }
                }
            }

            // Generate the UserEntity children 
            foreach (var ue in result.UserData.UserEntities)
            {
                var children = result.UserData.UserEntities.Where(o => o.ParentEntityId == ue.EntityId).ToCollection();
                ue.ChildUserEntities = children;
            }

            if (result.UserData.LanguageId.HasValue)
            {
                if (result.UserData.LanguageId == Guid.Empty)
                    result.UserData.LanguageId = GalaxySMS.Common.Constants.LanguageIds.GalaxySMS_EN_US_Language_Id;
                var langRepository = new GcsLanguageRepository();
                var lang = langRepository.Get(result.UserData.LanguageId.Value, null, null);
                if (lang == null)
                    result.UserData.LanguageCulture = GalaxySMS.Common.Constants.LanguageCultures.EnglishUs;
                else
                    result.UserData.LanguageCulture = lang.CultureName;
            }

            result.RequestData = requestData;
            this.Log().Info($"Finished building UserSessionToken...");

            return result;
        }

        public UserSessionToken GetUserSessionTokenForSignInRequest(Guid userId, Guid applicationId, IEnumerable<Guid> applicationIds, bool bIncludeEntityPhotos, int entityPhotosPixelWidth, bool bIncludeUserImages, int userImagesPixelWidth, IEnumerable<Guid> permissionsForEntityIds, IApplicationUserSessionDataHeader sessionData)
        {
            this.Log().Info($"Building UserSessionToken...");

            var result = new UserSessionToken
            {
                SessionId = GuidUtilities.GenerateComb() // Guid.NewGuid();
            };
            var getParams = new GetParametersWithPhoto()
            {
                IncludePhoto = bIncludeEntityPhotos,
                PhotoPixelWidth = entityPhotosPixelWidth,
            };
            getParams.ExcludeMemberCollectionSettings.Add(nameof(gcsUser.UserOldPasswords));
            getParams.ExcludeMemberCollectionSettings.Add(nameof(UserRole.UserPermissions));
            //getParams.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.AllApplications));
            //            getParams.ExcludeMemberCollectionSettings.Add(nameof(gcsUser.gcsUserSettings));
            getParams.ExcludeMemberCollectionSettings.Add(nameof(gcsUser.UserEntities));

            //var user = GetEntityByGuidId(userId, null, null);
            var user = GetEntityByGuidId(userId, null, getParams, applicationId, permissionsForEntityIds);

            result.UserData = new UserData(user, bIncludeUserImages);
            if (userImagesPixelWidth > 0)
            {
                if (result.UserData.UserImage != null)
                {
                    var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                    GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(result.UserData.UserImage), userImagesPixelWidth);
                    result.UserData.UserImage = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
                }

                if (result.UserData.SecurityImage != null)
                {
                    var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                    GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(result.UserData.SecurityImage), userImagesPixelWidth);
                    result.UserData.SecurityImage = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
                }
            }

            if (!user.AllEntities.Any())
            {
                var appRepo = new GcsApplicationRepository();
                var app = appRepo.Get(applicationId, null, null);
                if (app != null)
                {
                    result.ApplicationId = applicationId;
                    result.ApplicationName = app.ApplicationName;
                    result.CurrentEntityId = user.PrimaryEntityId;
                }
            }
            else
            {
                var permsForEntityIds = permissionsForEntityIds.ToList();
                var permissionRepository = new gcsPermissionRepository();
                foreach (var entity in user.AllEntities)
                {
                    if (entity.IsAuthorized && entity.IsActive && permsForEntityIds.Contains(entity.EntityId))
                    {
                        var userEntity = new UserEntity(entity);

                        var roles = (from r in entity.AllRoles where r.IsAuthorized == true select r).ToList();
                        foreach (var role in roles)
                        {
                            var userRole = new UserRole(role);
                            if (!getParams.IsExcluded(nameof(UserRole.UserPermissions)))
                            {
                                var permissions = permissionRepository.GetAllPermissionsForRole(role.RoleId, null);
                                foreach (var permission in permissions)
                                {
                                    var userPermission = new UserPermission(permission);
                                    userRole.UserPermissions.Add(userPermission);
                                }
                            }

                            userEntity.UserRoles.Add(userRole);
                        }
                    }
                }
            }

            var currentEntityInfo =
                GetCurrentEntityId(result.UserData.UserId, result.UserData.PrimaryEntityId, sessionData);
            if (currentEntityInfo != null)
            {
                result.CurrentEntityId = currentEntityInfo.CurrentEntityId;
                result.UserData.CurrentEntityId = currentEntityInfo.CurrentEntityId;
                result.UserData.CurrentEntityName = currentEntityInfo.CurrentEntityName;
                result.UserData.CurrentEntityType = currentEntityInfo.CurrentEntityType;
            }


            // Generate the UserEntity children 
            foreach (var ue in result.UserData.UserEntities)
            {
                var children = result.UserData.UserEntities.Where(o => o.ParentEntityId == ue.EntityId).ToCollection();
                ue.ChildUserEntities = children;
            }

            if (result.UserData.LanguageId.HasValue)
            {
                if (result.UserData.LanguageId == Guid.Empty)
                    result.UserData.LanguageId = GalaxySMS.Common.Constants.LanguageIds.GalaxySMS_EN_US_Language_Id;
                var langRepository = new GcsLanguageRepository();
                var lang = langRepository.Get(result.UserData.LanguageId.Value, null, null);
                if (lang == null)
                    result.UserData.LanguageCulture = GalaxySMS.Common.Constants.LanguageCultures.EnglishUs;
                else
                    result.UserData.LanguageCulture = lang.CultureName;
            }


            this.Log().Info($"Finished building UserSessionToken...");

            return result;
        }

        public UserSessionToken SignOut(UserSessionToken userToken, IApplicationUserSessionDataHeader sessionData)
        {
            if (userToken != null)
            {
                var applicationAuditRepository = new GcsApplicationAuditRepository();
                var applicationAudit = applicationAuditRepository.CreateApplicationAuditInstance(sessionData);
                applicationAudit.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignOut;
                applicationAudit.LoginName = userToken.UserData.UserName;
                applicationAuditRepository.InsertEntity(applicationAudit, sessionData);

                userToken.SignedOutDateTime = DateTimeOffset.Now;
                userToken.SessionId = Guid.Empty;
                userToken.UserData = null;
            }
            return userToken;
        }

        public UserSessionToken RefreshUserToken(UserSessionToken userToken)
        {
            return userToken;
        }

        public UserData GetUserDataForApplicationByUserId(Guid userId, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var result = GetUserSessionTokenForApplication(userId, sessionData.ApplicationId);
                return result.UserData;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetUserDataForApplicationByUserId", ex);
                throw;
            }
        }

        public UserData GetUserDataForApplicationByUserName(string userName, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var user = GetByUserName(userName, sessionData, true);
                if (user != null)
                {
                    var result = GetUserSessionTokenForApplication(user.UserId, sessionData.ApplicationId);
                    return result.UserData;
                }
                return GetUserDataForApplicationByUserId(Guid.Empty, sessionData);

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetUserDataForApplicationByUserName", ex);
                throw;
            }
        }

        public UserData GetUserDataForApplicationByEmail(string email, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var user = GetByEmail(email, sessionData, true);
                if (user != null)
                {
                    var result = GetUserSessionTokenForApplication(user.UserId, sessionData.ApplicationId);
                    return result.UserData;
                }
                return GetUserDataForApplicationByUserId(Guid.Empty, sessionData);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetUserDataForApplicationByEmail", ex);
                throw;
            }
        }

        public string GeneratePasswordResetToken(Guid userId, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var user = GetEntityByGuidId(userId, sessionData, null);
                if (user != null)
                {
                    var userRequirementsRepository = new GcsUserRequirementsRepository();
                    var userReqs = userRequirementsRepository.GetByEntityId(user.PrimaryEntityId);
                    var validator = new PasswordGeneratorValidator();
                    var passwordParameters = new GeneratePasswordParameters()
                    {
                        MaximumLength = userReqs.PasswordMaximumLength,
                        MinimumLength = userReqs.PasswordMinimumLength,
                        IncludeLowerCaseCharacterCount = userReqs.RequireLowerCaseLetterCount,
                        IncludeNumericDigitCount = userReqs.RequireNumericDigitCount,
                        IncludeSpecialCharacterCount = userReqs.RequireSpecialCharacterCount,
                        IncludeUpperCaseCharacterCount = userReqs.RequireUpperCaseLetterCount,
                    };

                    user.UserPassword = validator.GeneratePassword(passwordParameters);
                    UpdateEntity(user, sessionData, null);
                    var encryptedPassword = Crypto.EncryptString(user.UserPassword, user.UserId.ToString());
                    return encryptedPassword;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GeneratePasswordResetToken", ex);
                throw;
            }
        }

        public gcsUser GetByPassword(string password, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserPDSAData.SelectFilters.ByUserPassword;
                mgr.DataObject.Entity.UserPassword = password;
                var results = mgr.BuildCollection();

                if (results != null && results.Count == 1)
                {
                    var users = mgr.ConvertPDSACollection(results);
                    foreach (var user in users)
                    {
                        PrepareUserForReturning(user, null, sessionData);
                        return user;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetByPassword", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserEntity> GetEntitiesForUserId(Guid userId, IGetParametersWithPhoto getParameters)
        {
            GcsUserEntityRepository userEntityRepository = new GcsUserEntityRepository();
            var results = userEntityRepository.GetByUserId(userId, getParameters).ToCollection();

            return results;
        }

        public bool DoesUserHavePermission(Guid userId, Guid entityId, Guid permissionId)
        {
            var mgr = new gcs_DoesUserHavePermissionPDSAManager();
            mgr.Entity.UserId = userId;
            mgr.Entity.EntityId = entityId;
            mgr.Entity.PermissionId = permissionId;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return false;
            return true;
        }

        //public bool DoesUserHaveEntityApplication(Guid userId, Guid entityId, Guid applicationId)
        //{
        //    var mgr = new gcs_DoesUserHaveEntityApplicationPDSAManager();
        //    mgr.Entity.UserId = userId;
        //    mgr.Entity.EntityId = entityId;
        //    mgr.Entity.ApplicationId = applicationId;
        //    mgr.BuildCollection();

        //    if (Convert.ToInt32(mgr.Entity.Result) == 0)
        //        return false;
        //    return true;
        //}

        //public bool DoesUserHaveEntityPermission(Guid userId, Guid entityId, Guid permissionId)
        //{
        //    var mgr = new gcs_DoesUserHaveEntityPermissionPDSAManager();
        //    mgr.Entity.UserId = userId;
        //    mgr.Entity.EntityId = entityId;
        //    mgr.Entity.PermissionId = permissionId;
        //    mgr.BuildCollection();

        //    if (Convert.ToInt32(mgr.Entity.Result) == 0)
        //        return false;
        //    return true;
        //}

        public ICurrentEntityInfo SetCurrentEntityId(Guid userId, Guid entityId,
            IApplicationUserSessionDataHeader sessionData)
        {
            var userSettingRepo = _dataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();
            var currentEntitySetting = userSettingRepo.GetByUniqueKey(userId, null,
                GalaxySMS.Common.Constants.gcsUserSettingCategory.UserSession, gcsUserSettingKey.CurrentEntityId);
            gcsUserSetting updatedSetting = null;
            if (currentEntitySetting == null)
            {
                currentEntitySetting = new gcsUserSetting()
                {
                    UserSettingId = GuidUtilities.GenerateComb(),
                    Category = gcsUserSettingCategory.UserSession,
                    SettingKey = gcsUserSettingKey.CurrentEntityId,
                    SettingValue = entityId.ToString(),
                    ConcurrencyValue = 0
                };
                updatedSetting = userSettingRepo.Add(currentEntitySetting, sessionData, null);
            }
            else
            {
                currentEntitySetting.SettingValue = entityId.ToString();
                updatedSetting = userSettingRepo.Update(currentEntitySetting, sessionData, null);
            }

            if (updatedSetting != null)
            {
                var eid = Guid.Empty;
                if (Guid.TryParse(updatedSetting.SettingValue, out eid))
                {
                    var mgr = new GetCurrentEntityInfoPDSAManager();
                    mgr.DataObject.Entity.EntityId = eid;
                    var currentEntityInfo = mgr.BuildCollection();
                    if (currentEntityInfo?.Count == 1)
                        return new CurrentEntityInfo()
                        {
                            CurrentEntityId = currentEntityInfo[0].CurrentEntityId,
                            CurrentEntityName = currentEntityInfo[0].CurrentEntityName,
                            CurrentEntityType = currentEntityInfo[0].CurrentEntityType
                        };
                }

            }
            return new CurrentEntityInfo();
        }


        public ICurrentEntityInfo GetCurrentEntityId(Guid userId, Guid defaultEntityId, IApplicationUserSessionDataHeader sessionData)
        {
            var userSettingRepo = _dataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();
            var currentEntitySetting = userSettingRepo.GetByUniqueKey(userId, null,
                GalaxySMS.Common.Constants.gcsUserSettingCategory.UserSession, gcsUserSettingKey.CurrentEntityId);

            if (currentEntitySetting == null)
            {
                currentEntitySetting = new gcsUserSetting()
                {
                    UserSettingId = GuidUtilities.GenerateComb(),
                    UserId = userId,
                    Category = gcsUserSettingCategory.UserSession,
                    SettingKey = gcsUserSettingKey.CurrentEntityId,
                    SettingValue = defaultEntityId.ToString(),
                    ConcurrencyValue = 0
                };
                currentEntitySetting = userSettingRepo.Add(currentEntitySetting, sessionData, null);
            }

            if (currentEntitySetting != null)
            {
                var eid = Guid.Empty;
                if (Guid.TryParse(currentEntitySetting.SettingValue, out eid))
                {
                    var mgr = new GetCurrentEntityInfoPDSAManager();
                    mgr.DataObject.Entity.EntityId = eid;
                    var currentEntityInfo = mgr.BuildCollection();
                    if (currentEntityInfo?.Count == 1)
                        return new CurrentEntityInfo()
                        {
                            CurrentEntityId = currentEntityInfo[0].CurrentEntityId,
                            CurrentEntityName = currentEntityInfo[0].CurrentEntityName,
                            CurrentEntityType = currentEntityInfo[0].CurrentEntityType
                        };
                }

            }
            return new CurrentEntityInfo() { CurrentEntityId = defaultEntityId };
        }


        public bool DoesUserHaveEntity(Guid userId, Guid entityId)
        {
            var mgr = new gcs_DoesUserHaveEntityPDSAManager();
            mgr.Entity.UserId = userId;
            mgr.Entity.EntityId = entityId;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return false;
            return true;
        }

        public bool DoesUserHaveAdminRole(Guid userId, Guid entityId)
        {
            var mgr = new gcs_DoesUserHaveAdminRolePDSAManager();
            mgr.Entity.UserId = userId;
            mgr.Entity.EntityId = entityId;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return false;
            return true;
        }

        public bool IsUserInRole(Guid userId, Guid entityId, Guid roleId)
        {
            var mgr = new gcs_IsUserInRolePDSAManager();
            mgr.Entity.UserId = userId;
            mgr.Entity.EntityId = entityId;
            mgr.Entity.RoleId = roleId;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return false;
            return true;
        }

        public bool IsUserInRole(Guid userId, Guid entityId, string roleName)
        {
            var mgr = new gcs_IsUserInRoleNamePDSAManager();
            mgr.Entity.UserId = userId;
            mgr.Entity.EntityId = entityId;
            mgr.Entity.RoleName = roleName;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return false;
            return true;
        }

        //public bool IsUserInEntityApplicationRole(Guid userId, Guid entityApplicationRoleId)
        //{
        //    var mgr = new gcs_UserEntityApplicationRolesForUserIdPDSAManager();
        //    mgr.Entity.UserId = userId;
        //    var results = mgr.BuildCollection();
        //    var ear = results?.FirstOrDefault(o => o.EntityApplicationRoleId == entityApplicationRoleId);
        //    return ear != null;
        //}
        public bool IsUserInRole(Guid userId, Guid roleId)
        {
            var mgr = new gcs_UserEntityRolesForUserIdPDSAManager();
            mgr.Entity.UserId = userId;
            var results = mgr.BuildCollection();
            var ear = results?.FirstOrDefault(o => o.RoleId == roleId);
            return ear != null;
        }

        //public bool IsUserInAllEntityApplicationRoles(Guid userId, IEnumerable<Guid> entityApplicationRoleIds)
        //{
        //    var mgr = new gcs_UserEntityApplicationRolesForUserIdPDSAManager();
        //    mgr.Entity.UserId = userId;
        //    var results = mgr.BuildCollection();
        //    if (results.Count() == 0)
        //        return false;
        //    foreach (var id in entityApplicationRoleIds)
        //    {
        //        var ear = results?.FirstOrDefault(o => o.EntityApplicationRoleId == id);
        //        if (ear == null)
        //            return false;
        //    }

        //    return true;
        //}

        public bool IsUserInAllRoles(Guid userId, IEnumerable<Guid> roleIds)
        {
            var mgr = new gcs_UserEntityRolesForUserIdPDSAManager();
            mgr.Entity.UserId = userId;
            var results = mgr.BuildCollection();
            if (results.Count() == 0)
                return false;
            foreach (var id in roleIds)
            {
                var ear = results?.FirstOrDefault(o => o.RoleId == id);
                if (ear == null)
                    return false;
            }

            return true;
        }


        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertPrimaryUserCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        protected override IArrayResponse<gcsUser> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserPDSAManager mgr = new gcsUserPDSAManager();
                mgr.Entity.PageNumber = getParameters.PageNumber;
                mgr.Entity.PageSize = getParameters.PageSize;

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    var totalCount = 0;

                    // Blank out the password so it does not get returned to the client.
                    IList<gcsUser> results = new List<gcsUser>();
                    foreach (gcsUser entity in entities)
                    {
                        if (totalCount == 0)
                            totalCount = entity.TotalRowCount;
                        PrepareUserForReturning(entity, getParameters, sessionData);
                        results.Add(entity);
                    }
                    return ArrayResponseHelpers.ToArrayResponse(results, getParameters.PageNumber, getParameters.PageSize, totalCount);
                }
                return new ArrayResponse<gcsUser>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<gcsUser> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }


        public Guid GetPrimaryEntityId(Guid uid)
        {
            var mgr = new GetPrimaryEntityIdForUserPDSAManager()
            {
                Entity =
                {
                    uid = uid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.PrimaryEntityId;
            return Guid.Empty;
        }


        public UserPasswordResetInformation GetPasswordResetInformation(Guid userId,
            IApplicationUserSessionDataHeader sessionData)
        {
            var mgr = new gcsUser_GetPasswordResetInfoPDSAManager();
            mgr.Entity.UserId = userId;
            var results = mgr.BuildCollection();
            if (results.Count() == 0)
                return null;

            var r = results.FirstOrDefault();
            if (r != null)
            {
                var result = new UserPasswordResetInformation()
                {
                    UserId = r.UserId,
                    Email = r.Email,
                    LastPasswordResetDate = r.LastPasswordResetDate,
                    PrimaryEntityId = r.PrimaryEntityId,
                    UserName = r.UserName,
                    ResetPasswordFlag = r.ResetPasswordFlag,
                    PasswordResetToken = r.PasswordResetToken,
                    PasswordResetTokenExpiration = r.PasswordResetTokenExpiration
                };
                return result;
            }
            return null;

        }

        public UserRequestPasswordChangeTokenResponse RequestUserPasswordChangeToken(UserRequestPasswordChangeToken parameters, IApplicationUserSessionDataHeader sessionData, gcsUser user)
        {
            try
            {
                var result = new UserRequestPasswordChangeTokenResponse()
                {
                    Token = string.Empty,
                    UnknownUser = true
                };

                if (user == null || user.UserId == Guid.Empty)
                {
                    user = GetByUserName(parameters.UserName, sessionData, false);
                    if (user == null)
                        user = GetByEmail(parameters.UserName, sessionData, false);
                    if (user == null)
                        return result;
                }

                var currentPassword = GetPasswordForUser(user.UserId, sessionData);
                result.UnknownUser = false;

                var token = GCS.Framework.Security.RandomTokenGenerator.GenerateRandomNumber();
                var pwdGen = new PasswordGeneratorValidator();

                var tempPassword = pwdGen.GeneratePassword(new GeneratePasswordParameters()
                {
                    MinimumLength = 20,
                    MaximumLength = 20,
                    //IncludeUpperCaseCharacterCount = 1,
                    //IncludeNumericDigitCount = 1,
                    AllowLowerCase = false,
                    AllowSpecialCharacters = false,
                    AllowUpperCase = true,
                    AllowNumerics = true,
                    IncludeSpecialCharacterCount = 0,
                    IncludeLowerCaseCharacterCount = 0
                });

                SaveOldPassword(user.UserId, currentPassword, sessionData);

                var encryptedPassword = Crypto.EncryptString(tempPassword, user.UserId.ToString());

                result.Token = token.ToString();
                result.TokenExpiration = DateTimeOffset.Now + TimeSpan.FromMinutes(240);
                var mgr = new gcsUser_UpdatePasswordChangeTokenPDSAManager();
                mgr.DataObject.Entity.UserId = user.UserId;
                mgr.DataObject.Entity.PasswordResetToken = result.Token;
                mgr.DataObject.Entity.PasswordResetTokenExpiration = result.TokenExpiration;
                mgr.DataObject.Entity.TempPassword = encryptedPassword;
                var cnt = mgr.Execute();
                if (cnt == 1)
                {
                    var settingsRepo = new GcsSettingRepository();

                    if (parameters.SendViaEmail && user.EmailConfirmed && !string.IsNullOrEmpty(user.Email))
                    {
                        var mailSettings = GetMailServerSettings(sessionData, settingsRepo, user.PrimaryEntityId);

                        if (mailSettings.Host != MagicStrings.EnterValueHere &&
                            mailSettings.UserName != MagicStrings.EnterValueHere &&
                            mailSettings.Password != MagicStrings.EnterValueHere)
                        {
                            string emailBody = string.Empty;
                            Task.Run(async () =>
                            {
                                var p = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("{subject}",
                                        PasswordResetParameters.TokenEmailSubject),
                                    new KeyValuePair<string, string>("{token}", result.Token),
                                    new KeyValuePair<string, string>("{tokenLifespan}", PasswordResetParameters.TokenLifespan.ToString()),
                                    new KeyValuePair<string, string>("{responseUrl}", parameters.ChangePasswordResponseUrl),
                                    new KeyValuePair<string, string>("{tempPassword}", tempPassword),
                                    new KeyValuePair<string, string>("{encryptedPassword}", encryptedPassword)
                                };
                                emailBody = await CreatePasswordResetTokenEmailBody(PasswordResetParameters.TokenEmailTemplate, p);
                            }).Wait();
                            var emailSender = new GCS.Framework.Email.GcsEmailSender(mailSettings.Host, mailSettings.HostPort, mailSettings.UseSSL, mailSettings.UserName, mailSettings.Password);
                            // Purposely don't await. This is a fire and forget operation
                            emailSender.SendEmailAsync(user.Email, mailSettings.UserName,
                                PasswordResetParameters.TokenEmailSubject,
                                emailBody);
                        }

                    }

                    if (parameters.SendViaSms && user.PhoneNumberConfirmed && !string.IsNullOrEmpty(user.PhoneNumber))
                    {
                        var twilioSettings = GetTwilioSettings(sessionData, settingsRepo, user.PrimaryEntityId);

                        if (twilioSettings.Sid != MagicStrings.EnterValueHere &&
                            twilioSettings.AuthToken != MagicStrings.EnterValueHere &&
                            twilioSettings.PhoneNumber != MagicStrings.EnterValueHere)
                        {
                            // sent text message
                            string messageBody = string.Empty;
                            Task.Run(async () =>
                            {
                                var p = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("{subject}",
                                        PasswordResetParameters.TokenEmailSubject),
                                    new KeyValuePair<string, string>("{token}", result.Token),
                                    new KeyValuePair<string, string>("{tokenLifespan}", PasswordResetParameters.TokenLifespan.ToString()),
                                    new KeyValuePair<string, string>("{responseUrl}", parameters.ChangePasswordResponseUrl),
                                    new KeyValuePair<string, string>("{tempPassword}", tempPassword),
                                    new KeyValuePair<string, string>("{encryptedPassword}", encryptedPassword)
                                };

                                messageBody = await CreatePasswordResetTokenSMSBody(PasswordResetParameters.TokenSmsTemplate, p);
                            }).Wait();
                            var smsHandler = new GCS.Framework.Sms.GcsSmsHandler(twilioSettings.Sid, twilioSettings.AuthToken);

                            // Purposely don't await. This is a fire and forget operation
                            smsHandler.SendMessage(user.PhoneNumber, twilioSettings.PhoneNumber, messageBody);
                        }
                    }

                    return result;
                }
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntities", ex);
                throw;
            }

            return null;
        }

        public UpdateUserPasswordResult UpdateUserPassword(UpdateUserPasswordParameters parameters, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var currentPassword = GetPasswordForUser(parameters.UserId, sessionData);
                var result = new UpdateUserPasswordResult();
                var mgr = new gcsUser_UpdatePasswordPDSAManager
                {
                    Entity =
                    {
                        UserId = parameters.UserId,
                        Password = parameters.NewPassword,
                        UpdateDate = DateTimeOffset.Now,
                        UserName = sessionData.UserName
                    }
                };
                var count = mgr.Execute();
                if (count > 0)
                {
                    result.Result = UpdateUserPasswordResult.UpdateUserPasswordResultCodes.Success;
                    SaveOldPassword(parameters.UserId, currentPassword, sessionData);
                }
                else
                {
                    result.Result = UpdateUserPasswordResult.UpdateUserPasswordResultCodes.UserNotFound;
                }

                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntities", ex);
                throw;
            }
            return null;

        }

        private void SaveOldPassword(Guid userId, string oldPassword, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                _oldPasswordRepository.Add(new gcsUserOldPassword()
                {
                    UserOldPasswordId = GuidUtilities.GenerateComb(),
                    UserId = userId,
                    Password = oldPassword,
                    ConcurrencyValue = 0,
                    InsertName = sessionData.UserName,
                    UpdateName = sessionData.UserName,
                    InsertDate = DateTimeOffset.Now,
                    UpdateDate = DateTimeOffset.Now
                }, sessionData, null);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRepository::GetEntities", ex);
                throw;
            }
        }

        public PasswordResetParameters PasswordResetParameters { get; set; }

        public UserEntityPermissions GetUserPermissions(GetParametersWithPhoto parameters)
        {
            var result = new UserEntityPermissions()
            {
                CurrentEntityId = parameters.CurrentEntityId,
                RolePermissions = new List<string>()
            };
            var mgr = new SelectUserEffectivePermissionsPDSAManager
            {
                Entity =
                {
                    userId = parameters.UniqueId,
                    entityId = parameters.CurrentEntityId
                }
            };
            var results = mgr.BuildCollection();
            if (!results.Any())
                return null;

            result.RolePermissions.AddRange(results.Select(o=>o.PermissionCode).Distinct());
            return result;
        }
    }
}