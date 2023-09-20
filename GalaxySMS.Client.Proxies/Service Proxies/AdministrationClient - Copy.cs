using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.Mime;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Contracts;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.ServiceModel.Extensions;
using GCS.Framework.Security;

namespace GalaxySMS.Client.Proxies
{
    [Export(typeof(IAdministrationService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ApplicationUserSessionHeaderInspectorBehavior]
    public class AdministrationClient : UserClientBase<IAdministrationService>, IAdministrationService
    {

        #region System Operations
        #region Synchronouse operations

        public gcsSystem[] GetAllSystems()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSystems();
        }

        public gcsSystem GetSystem(Guid systemId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSystem(systemId);
        }

        public gcsSystem SaveSystem(gcsSystem system)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSystem(system);
        }

        public int DeleteSystem(gcsSystem system)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSystem(system);
        }

        public gcsSystem SaveSystemLicense(Guid systemId, string publicKey, string license)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSystemLicense(systemId, publicKey, license);
        }

        #endregion

        #region Async operations
        public Task<gcsSystem[]> GetAllSystemsAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllSystemsAsync();
        }

        public Task<gcsSystem> GetSystemAsync(Guid systemId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSystemAsync(systemId);
        }

        public Task<gcsSystem> SaveSystemAsync(gcsSystem system)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSystemAsync(system);
        }

        public Task<int> DeleteSystemAsync(gcsSystem system)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSystemAsync(system);
        }
        public Task<gcsSystem> SaveSystemLicenseAsync(Guid systemId, string publicKey, string license)
        {
            base.InsertUserDataToOutgoingHeader();
            var ret = Channel.SaveSystemLicenseAsync(systemId, publicKey, license);
            return ret;
        }
        #endregion

        #endregion

        #region Entity operations
        #region Synchronous operations
        public gcsEntity[] GetAllEntities(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllEntities(parameters);
        }

        public gcsEntity[] GetAllEntitiesForUser(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllEntitiesForUser(userId);
        }

        public gcsEntity[] GetAllEntitiesForApplication(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllEntitiesForApplication(applicationId);
        }

        public gcsEntity GetEntity(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntity(entityId);
        }

        public gcsEntity SaveEntity(gcsEntity entity)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveEntity(entity);
        }

        public int DeleteEntityByPk(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteEntityByPk(entityId);
        }

        public int DeleteEntity(gcsEntity entity)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteEntity(entity);
        }

        public bool IsEntityReferenced(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsEntityReferenced(entityId);
        }

        public bool IsEntityUnique(gcsEntity entity)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsEntityUnique(entity);
        }
        #endregion

        #region Async operations
        public Task<gcsEntity[]> GetAllEntitiesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllEntitiesAsync(parameters);
        }

        public Task<gcsEntity[]> GetAllEntitiesForUserAsync(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllEntitiesForUserAsync(userId);
        }

        public Task<gcsEntity[]> GetAllEntitiesForApplicationAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllEntitiesForApplicationAsync(applicationId);
        }

        public Task<gcsEntity> GetEntityAsync(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityAsync(entityId);
        }

        public Task<gcsEntity> SaveEntityAsync(gcsEntity entity)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveEntityAsync(entity);
        }

        public Task<int> DeleteEntityByPkAsync(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteEntityByPkAsync(entityId);
        }

        public Task<int> DeleteEntityAsync(gcsEntity entity)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteEntityAsync(entity);
        }

        public Task<bool> IsEntityReferencedAsync(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsEntityReferencedAsync(entityId);
        }

        public Task<bool> IsEntityUniqueAsync(gcsEntity entity)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsEntityUniqueAsync(entity);
        }
        #endregion
        #endregion

        #region Language operations
        #region Synchronous operations
        public gcsLanguage[] GetAllLanguages()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllLanguages();
        }

        public gcsLanguage[] GetAllLanguagesForBase(string baseLanguageCode)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllLanguagesForBase(baseLanguageCode);
        }

        public gcsLanguage GetLanguage(Guid languageId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetLanguage(languageId);
        }

        public gcsLanguage SaveLanguage(gcsLanguage language)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveLanguage(language);
        }

        public int DeleteLanguageByPk(Guid languageId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteLanguageByPk(languageId);
        }
        public int DeleteLanguage(gcsLanguage language)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteLanguage(language);
        }

        public bool IsLanguageReferenced(Guid languageId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsLanguageReferenced(languageId);
        }

        public bool IsLanguageUnique(gcsLanguage language)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsLanguageUnique(language);
        }
        #endregion

        #region Async operations
        public Task<gcsLanguage[]> GetAllLanguagesAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllLanguagesAsync();
        }

        public Task<gcsLanguage[]> GetAllLanguagesForBaseAsync(string baseLanguageCode)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllLanguagesForBaseAsync(baseLanguageCode);
        }

        public Task<gcsLanguage> GetLanguageAsync(Guid languageId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetLanguageAsync(languageId);
        }

        public Task<gcsLanguage> SaveLanguageAsync(gcsLanguage language)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveLanguageAsync(language);
        }

        public Task<int> DeleteLanguageByPkAsync(Guid languageId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteLanguageByPkAsync(languageId);
        }

        public Task<int> DeleteLanguageAsync(gcsLanguage language)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteLanguageAsync(language);
        }

        public Task<bool> IsLanguageReferencedAsync(Guid languageId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsLanguageReferencedAsync(languageId);
        }

        public Task<bool> IsLanguageUniqueAsync(gcsLanguage language)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsLanguageUniqueAsync(language);
        }
        #endregion
        #endregion

        #region Application operations
        #region Synchronous operations
        public gcsApplication[] GetAllApplications()
        {
            base.InsertUserDataToOutgoingHeader();
            var results = Channel.GetAllApplications();
            return results;
        }

        public gcsApplication[] GetAllApplicationsForEntity(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllApplicationsForEntity(entityId);
        }

        public gcsApplication GetApplication(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetApplication(applicationId);
        }

        public gcsApplication SaveApplication(gcsApplication application)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveApplication(application);
        }

        public int DeleteApplicationByPk(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteApplicationByPk(applicationId);
        }

        public int DeleteApplication(gcsApplication application)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteApplication(application);
        }

        public bool IsApplicationReferenced(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsApplicationReferenced(applicationId);
        }

        public bool IsApplicationUnique(gcsApplication application)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsApplicationUnique(application);
        }

        public bool IsApplicationInDatabase(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsApplicationInDatabase(applicationId);
        }


        public void SaveApplicationAuditData(gcsApplicationAudit auditData)
        {
            base.InsertUserDataToOutgoingHeader();
            Channel.SaveApplicationAuditData(auditData);
        }

        #endregion

        #region Async operations
        //public Task<gcsApplication[]> GetAllApplicationsAsync()
        public Task<gcsApplication[]> GetAllApplicationsAsync()

        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllApplicationsAsync();
        }

        public Task<gcsApplication[]> GetAllApplicationsForEntityAsync(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllApplicationsForEntityAsync(entityId);
        }

        public Task<gcsApplication> GetApplicationAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetApplicationAsync(applicationId);
        }

        public Task<gcsApplication> SaveApplicationAsync(gcsApplication application)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveApplicationAsync(application);
        }

        public Task<int> DeleteApplicationByPkAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteApplicationByPkAsync(applicationId);
        }

        public Task<int> DeleteApplicationAsync(gcsApplication application)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteApplicationAsync(application);
        }

        public Task<bool> IsApplicationReferencedAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsApplicationReferencedAsync(applicationId);
        }

        public Task<bool> IsApplicationUniqueAsync(gcsApplication application)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsApplicationUniqueAsync(application);
        }
 
        public Task<bool> IsApplicationInDatabaseAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsApplicationInDatabaseAsync(applicationId);
        }

        public Task SaveApplicationAuditDataAsync(gcsApplicationAudit auditData)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveApplicationAuditDataAsync(auditData);
        }
        #endregion
        #endregion

        #region Application Setting operations
        #region Synchronous operations

        public gcsApplicationSetting GetApplicationSetting(gcsApplicationSetting applicationSetting, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetApplicationSetting(applicationSetting, bCreateIfNotFound);
        }

        public gcsApplicationSetting GetApplicationSettingFromParams(Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetApplicationSettingFromParams(applicationId, category, settingKey, defaultValue, defaultDescription, bCreateIfNotFound);
        }

        public gcsApplicationSetting[] GetAllApplicationSettingsForApplication(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllApplicationSettingsForApplication(applicationId);
        }

        public gcsApplicationSetting[] GetAllApplicationSettingsForApplicationCategory(Guid applicationId, string category)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllApplicationSettingsForApplicationCategory(applicationId, category);
        }

        public gcsApplicationSetting SaveApplicationSetting(gcsApplicationSetting applicationSetting)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveApplicationSetting(applicationSetting);
        }

        public int DeleteApplicationSettingByPk(Guid applicationSettingId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteApplicationSettingByPk(applicationSettingId);
        }

        public int DeleteApplicationSetting(gcsApplicationSetting applicationSetting)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteApplicationSetting(applicationSetting);
        }

        public int DeleteApplicationSettingFromParams(Guid applicationId, string category, string settingKey)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteApplicationSettingFromParams(applicationId, category, settingKey);
        }
        #endregion

        #region Async operations
        public Task<gcsApplicationSetting> GetApplicationSettingAsync(gcsApplicationSetting applicationSetting, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetApplicationSettingAsync(applicationSetting, bCreateIfNotFound);
        }

        public Task<gcsApplicationSetting> GetApplicationSettingFromParamsAsync(Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetApplicationSettingFromParamsAsync(applicationId, category, settingKey, defaultValue, defaultDescription, bCreateIfNotFound);
        }

        public Task<gcsApplicationSetting[]> GetAllApplicationSettingsForApplicationAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllApplicationSettingsForApplicationAsync(applicationId);
        }

        public Task<gcsApplicationSetting[]> GetAllApplicationSettingsForApplicationCategoryAsync(Guid applicationId, string category)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllApplicationSettingsForApplicationCategoryAsync(applicationId, category);
        }

        public Task<gcsApplicationSetting> SaveApplicationSettingAsync(gcsApplicationSetting applicationSetting)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveApplicationSettingAsync(applicationSetting);
        }

        public Task<int> DeleteApplicationSettingByPkAsync(Guid applicationSettingId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteApplicationSettingByPkAsync(applicationSettingId);
        }

        public Task<int> DeleteApplicationSettingAsync(gcsApplicationSetting applicationSetting)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteApplicationSettingAsync(applicationSetting);
        }

        public Task<int> DeleteApplicationSettingFromParamsAsync(Guid applicationId, string category, string settingKey)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteApplicationSettingFromParamsAsync(applicationId, category, settingKey);
        }
        #endregion
        #endregion

        #region Role operations
        #region Synchronous operations
        public gcsRole[] GetAllRoles()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRoles();
        }

        public gcsRole[] GetAllRolesForApplication(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRolesForApplication(applicationId);
        }

        public gcsRole GetRole(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetRole(roleId);
        }

        public gcsRole SaveRole(gcsRole role)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveRole(role);
        }

        public int DeleteRoleByPk(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteRoleByPk(roleId);
        }
        public int DeleteRole(gcsRole role)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteRole(role);
        }

        public bool IsRoleReferenced(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsRoleReferenced(roleId);
        }

        public bool IsRoleUnique(gcsRole role)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsRoleUnique(role);
        }
        #endregion

        #region Async operations
        public Task<gcsRole[]> GetAllRolesAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRolesAsync();
        }

        public Task<gcsRole[]> GetAllRolesForApplicationAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRolesForApplicationAsync(applicationId);
        }

        public Task<gcsRole> GetRoleAsync(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetRoleAsync(roleId);
        }

        public Task<gcsRole> SaveRoleAsync(gcsRole role)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveRoleAsync(role);
        }

        public Task<int> DeleteRoleByPkAsync(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteRoleByPkAsync(roleId);
        }

        public Task<int> DeleteRoleAsync(gcsRole role)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteRoleAsync(role);
        }

        public Task<bool> IsRoleReferencedAsync(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsRoleReferencedAsync(roleId);
        }

        public Task<bool> IsRoleUniqueAsync(gcsRole role)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsRoleUniqueAsync(role);
        }
        #endregion
        #endregion

        #region Permission Category operations

        #region Synchronous operations

        public gcsPermissionCategory[] GetAllPermissionCategories()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionCategories();
        }

        public gcsPermissionCategory[] GetAllPermissionCategoriesForApplication(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionCategoriesForApplication(applicationId);
        }

        public gcsPermissionCategory GetPermissionCategory(Guid permissionCategoryId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPermissionCategory(permissionCategoryId);
        }

        public gcsPermissionCategory SavePermissionCategory(gcsPermissionCategory permissionCategory)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePermissionCategory(permissionCategory);
        }

        public int DeletePermissionCategoryByPk(Guid permissionCategoryId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePermissionCategoryByPk(permissionCategoryId);
        }

        public int DeletePermissionCategory(gcsPermissionCategory permissionCategory)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePermissionCategory(permissionCategory);
        }

        public bool IsPermissionCategoryReferenced(Guid permissionCategoryId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPermissionCategoryReferenced(permissionCategoryId);
        }

        public bool IsPermissionCategoryUnique(gcsPermissionCategory permissionCategory)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPermissionCategoryUnique(permissionCategory);
        }
        #endregion

        #region Async operations
        public Task<gcsPermissionCategory[]> GetAllPermissionCategoriesAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionCategoriesAsync();
        }

        public Task<gcsPermissionCategory[]> GetAllPermissionCategoriesForApplicationAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionCategoriesForApplicationAsync(applicationId);
        }

        public Task<gcsPermissionCategory> GetPermissionCategoryAsync(Guid permissionCategoryId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPermissionCategoryAsync(permissionCategoryId);
        }

        public Task<gcsPermissionCategory> SavePermissionCategoryAsync(gcsPermissionCategory permissionCategory)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePermissionCategoryAsync(permissionCategory);
        }

        public Task<int> DeletePermissionCategoryByPkAsync(Guid permissionCategoryId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePermissionCategoryByPkAsync(permissionCategoryId);
        }

        public Task<int> DeletePermissionCategoryAsync(gcsPermissionCategory permissionCategory)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePermissionCategoryAsync(permissionCategory);
        }

        public Task<bool> IsPermissionCategoryReferencedAsync(Guid permissionCategoryId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPermissionCategoryReferencedAsync(permissionCategoryId);
        }

        public Task<bool> IsPermissionCategoryUniqueAsync(gcsPermissionCategory permissionCategory)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPermissionCategoryUniqueAsync(permissionCategory);
        }

        #endregion

        #endregion

        #region Permission Operations
        #region Synchronous Operations
        public gcsPermission[] GetAllPermissions()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissions();
        }

        public gcsPermission[] GetAllPermissionsForApplication(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionsForApplication(applicationId);
        }

        public gcsPermission[] GetAllPermissionsForRole(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionsForRole(roleId);
        }

        public gcsPermission[] GetAllPermissionsForPermissionCategory(Guid permissionCategoryId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionsForPermissionCategory(permissionCategoryId);
        }

        public gcsPermission GetPermission(Guid permissionId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPermission(permissionId);
        }

        public gcsPermission SavePermission(gcsPermission permission)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePermission(permission);
        }

        public int DeletePermissionByPk(Guid permissionId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePermissionByPk(permissionId);
        }

        public int DeletePermission(gcsPermission permission)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePermission(permission);
        }

        public bool IsPermissionReferenced(Guid permissionId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPermissionReferenced(permissionId);
        }

        public bool IsPermissionUnique(gcsPermission permission)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPermissionUnique(permission);
        }
        #endregion

        #region Async Operations
        public Task<gcsPermission[]> GetAllPermissionsAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionsAsync();
        }

        public Task<gcsPermission[]> GetAllPermissionsForApplicationAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionsForApplicationAsync(applicationId);
        }

        public Task<gcsPermission[]> GetAllPermissionsForRoleAsync(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionsForRoleAsync(roleId);
        }

        public Task<gcsPermission[]> GetAllPermissionsForPermissionCategoryAsync(Guid permissionCategoryId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPermissionsForPermissionCategoryAsync(permissionCategoryId);
        }

        public Task<gcsPermission> GetPermissionAsync(Guid permissionId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPermissionAsync(permissionId);
        }

        public Task<gcsPermission> SavePermissionAsync(gcsPermission permission)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePermissionAsync(permission);
        }

        public Task<int> DeletePermissionByPkAsync(Guid permissionId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePermissionByPkAsync(permissionId);
        }

        public Task<int> DeletePermissionAsync(gcsPermission permission)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePermissionAsync(permission);
        }

        public Task<bool> IsPermissionReferencedAsync(Guid permissionId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPermissionReferencedAsync(permissionId);
        }

        public Task<bool> IsPermissionUniqueAsync(gcsPermission permission)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPermissionUniqueAsync(permission);
        }
        #endregion
        #endregion

        #region User operations
        #region Synchronous operations

        public gcsUser[] GetAllUsers()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsers();
        }

        public gcsUser[] GetAllUsersForApplication(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForApplication(applicationId);
        }

        public gcsUser[] GetAllUsersForRole(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForRole(roleId);
        }

        public gcsUser[] GetAllUsersForEntity(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForEntity(entityId);
        }

        public gcsUser GetUser(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUser(userId);
        }

        public gcsUser SaveUser(gcsUser user)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUser(user);
        }

        public gcsUser SaveUserAccountRequest(gcsUser user)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserAccountRequest(user);
        }

        public int DeleteUserByPk(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserByPk(userId);
        }

        public int DeleteUser(gcsUser user)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUser(user);
        }

        public gcsUser GetByUserName(string userName)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetByUserName(userName);
        }

        public gcsUser GetByEmail(string email)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetByEmail(email);
        }

        public gcsUser GetByPassword(string password)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetByPassword(password);
        }

        public string GeneratePasswordResetToken(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GeneratePasswordResetToken(userId);
        }

        public void ResetPassword(Guid userId, string newPassword)
        {
            base.InsertUserDataToOutgoingHeader();
            Channel.ResetPassword(userId, newPassword);
        }

        public string ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ChangePassword(userId, currentPassword, newPassword);
        }

        public bool IsUserReferenced(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserReferenced(userId);
        }

        public bool IsUserUnique(gcsUser user)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserUnique(user);
        }
        public PasswordValidationResult[] ValidatePassword(gcsUser user)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidatePassword(user);
        }

        public PasswordValidationResult[] ValidatePasswordForEntity(gcsUser user, Guid entityGuid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidatePasswordForEntity(user, entityGuid);
        }

        public gcsUserOldPassword[] GetOldPasswordsForUser(gcsUser user, int howMany)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOldPasswordsForUser(user, howMany);
        }
  
        #endregion

        #region Async operations
        public Task<gcsUser[]> GetAllUsersAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersAsync();
        }

        public Task<gcsUser[]> GetAllUsersForApplicationAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForApplicationAsync(applicationId);
        }

        public Task<gcsUser[]> GetAllUsersForRoleAsync(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForRoleAsync(roleId);
        }

        public Task<gcsUser[]> GetAllUsersForEntityAsync(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForEntityAsync(entityId);
        }

        public Task<gcsUser> GetUserAsync(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserAsync(userId);
        }

        public Task<gcsUser> SaveUserAsync(gcsUser user)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserAsync(user);
        }

        public Task<gcsUser> SaveUserAccountRequestAsync(gcsUser user)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserAccountRequestAsync(user);
        }


        public Task<int> DeleteUserByPkAsync(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserByPkAsync(userId);
        }

        public Task<int> DeleteUserAsync(gcsUser user)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserAsync(user);
        }

        public Task<gcsUser> GetByUserNameAsync(string userName)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetByUserNameAsync(userName);
        }

        public Task<gcsUser> GetByEmailAsync(string email)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetByEmailAsync(email);
        }
        
        public Task<gcsUser> GetByPasswordAsync(string password)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetByPasswordAsync(password);
        }

        public Task<string> GeneratePasswordResetTokenAsync(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GeneratePasswordResetTokenAsync(userId);
        }

        public Task ResetPasswordAsync(Guid userId, string newPassword)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ResetPasswordAsync(userId, newPassword);
        }

        public Task<string> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ChangePasswordAsync(userId, currentPassword, newPassword);
        }

        public Task<bool> IsUserReferencedAsync(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserReferencedAsync(userId);
        }

        public Task<bool> IsUserUniqueAsync(gcsUser user)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserUniqueAsync(user);
        }

        public Task<PasswordValidationResult[]> ValidatePasswordAsync(gcsUser user)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidatePasswordAsync(user);
        }
        public Task<PasswordValidationResult[]> ValidatePasswordForEntityAsync(gcsUser user, Guid entityGuid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidatePasswordForEntityAsync(user, entityGuid);
        }

        public Task<gcsUserOldPassword[]> GetOldPasswordsForUserAsync(gcsUser user, int howMany)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOldPasswordsForUserAsync(user, howMany);
        }      
        #endregion
        #endregion

        #region User Requirements operations
        #region Synchronous operations

        public gcsUserRequirement GetUserRequirementForEntity(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserRequirementForEntity(entityId);
        }

        public gcsUserRequirement[] GetAllUserRequirements()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserRequirements();
        }

        public gcsUserRequirement SaveUserRequirement(gcsUserRequirement userRequirement)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserRequirement(userRequirement);
        }

        public int DeleteUserRequirementByPk(Guid userRequirementId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserRequirementByPk(userRequirementId);
        }

        public int DeleteUserRequirement(gcsUserRequirement userRequirement)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserRequirement(userRequirement);
        }
        #endregion

        #region Async operations
        public Task<gcsUserRequirement> GetUserRequirementForEntityAsync(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserRequirementForEntityAsync(entityId);
        }

        public Task<gcsUserRequirement[]> GetAllUserRequirementsAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserRequirementsAsync();
        }

        public Task<gcsUserRequirement> SaveUserRequirementAsync(gcsUserRequirement userRequirement)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserRequirementAsync(userRequirement);
        }

        public Task<int> DeleteUserRequirementByPkAsync(Guid userRequirementId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserRequirementByPkAsync(userRequirementId);
        }

        public Task<int> DeleteUserRequirementAsync(gcsUserRequirement userRequirement)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserRequirementAsync(userRequirement);
        }
        #endregion
        #endregion

        #region User Setting operations
        #region Synchronous operations
        public gcsUserSetting GetUserSetting(gcsUserSetting userSetting, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserSetting(userSetting, bCreateIfNotFound);
        }

        public gcsUserSetting GetUserSettingFromParams(Guid userId, Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserSettingFromParams(userId, applicationId, category, settingKey, defaultValue, defaultDescription, bCreateIfNotFound);
        }

        public gcsUserSetting[] GetAllUserSettingsForUser(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUser(userId);
        }

        public gcsUserSetting[] GetAllUserSettingsForUserApplication(Guid userId, Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUserApplication(userId, applicationId);
        }

        public gcsUserSetting[] GetAllUserSettingsForUserApplicationCategory(Guid userId, Guid applicationId, string category)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUserApplicationCategory(userId, applicationId, category);
        }

        public gcsUserSetting[] GetAllUserSettingsForApplication(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForApplication(applicationId);
        }

        public gcsUserSetting SaveUserSetting(gcsUserSetting userSetting)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserSetting(userSetting);
        }

        public int DeleteUserSettingByPk(Guid userSettingId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserSettingByPk(userSettingId);
        }

        public int DeleteUserSetting(gcsUserSetting userSetting)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserSetting(userSetting);
        }

        public int DeleteUserSettingFromParams(Guid userId, Guid applicationId, string category, string settingKey)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserSettingFromParams(userId, applicationId, category, settingKey);
        }
        #endregion

        #region Async operations
        public Task<gcsUserSetting> GetUserSettingAsync(gcsUserSetting userSetting, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserSettingAsync(userSetting, bCreateIfNotFound);
        }

        public Task<gcsUserSetting> GetUserSettingFromParamsAsync(Guid userId, Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserSettingFromParamsAsync(userId, applicationId, category, settingKey, defaultValue, defaultDescription, bCreateIfNotFound);
        }

        public Task<gcsUserSetting[]> GetAllUserSettingsForUserAsync(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUserAsync(userId);
        }

        public Task<gcsUserSetting[]> GetAllUserSettingsForUserApplicationAsync(Guid userId, Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUserApplicationAsync(userId, applicationId);
        }

        public Task<gcsUserSetting[]> GetAllUserSettingsForUserApplicationCategoryAsync(Guid userId, Guid applicationId, string category)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUserApplicationCategoryAsync(userId, applicationId, category);
        }

        public Task<gcsUserSetting[]> GetAllUserSettingsForApplicationAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForApplicationAsync(applicationId);
        }

        public Task<gcsUserSetting> SaveUserSettingAsync(gcsUserSetting userSetting)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserSettingAsync(userSetting);
        }

        public Task<int> DeleteUserSettingByPkAsync(Guid userSettingId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserSettingByPkAsync(userSettingId);
        }

        public Task<int> DeleteUserSettingAsync(gcsUserSetting userSetting)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserSettingAsync(userSetting);
        }

        public Task<int> DeleteUserSettingFromParamsAsync(Guid userId, Guid applicationId, string category, string settingKey)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserSettingFromParamsAsync(userId, applicationId, category, settingKey);
        }

        #endregion
        #endregion

        #region Initialize System Database
        #region Synchronous operations
        public bool InitializeSystemDatabase(InitializeSystemDatabaseRequest requestData)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.InitializeSystemDatabase(requestData);
        }

        #endregion
        #region Async operations

        public Task<bool> InitializeSystemDatabaseAsync(InitializeSystemDatabaseRequest requestData)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.InitializeSystemDatabaseAsync(requestData);
        }

        #endregion
        #endregion

        #region Country Operations

        #region Synchronous operations

        public Country[] GetAllCountries(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCountries(parameters);
        }

        public Country GetCountry(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCountry(parameters);
        }

        public Country SaveCountry(SaveParameters<Country> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveCountry(parameters);
        }

        public int DeleteCountryByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCountryByPk(parameters);
        }

        public int DeleteCountry(DeleteParameters<Country> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCountry(parameters);
        }

        #endregion

        #region Async Operations

        public Task<Country[]> GetAllCountriesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllCountriesAsync(parameters);
        }

        public Task<Country> GetCountryAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCountryAsync(parameters);
        }

        public Task<Country> SaveCountryAsync(SaveParameters<Country> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveCountryAsync(parameters);
        }

        public Task<int> DeleteCountryByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCountryByPkAsync(parameters);
        }

        public Task<int> DeleteCountryAsync(DeleteParameters<Country> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteCountryAsync(parameters);
        }

        #endregion


        #endregion


        #region StateProvince Operations

        #region Synchronous Operations

        public StateProvince[] GetAllStatesProvinces(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllStatesProvinces(parameters);
        }

        public StateProvince[] GetAllStatesProvincesForCountry(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllStatesProvincesForCountry(parameters);
        }

        public StateProvince GetStateProvince(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetStateProvince(parameters);
        }

        public StateProvince SaveStateProvince(SaveParameters<StateProvince> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveStateProvince(parameters);
        }

        public int DeleteStateProvinceByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteStateProvinceByPk(parameters);
        }

        public int DeleteStateProvince(DeleteParameters<StateProvince> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteStateProvince(parameters);
        }

        #endregion

        #region Async Operations

        public Task<StateProvince[]> GetAllStatesProvincesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllStatesProvincesAsync(parameters);
        }

        public Task<StateProvince[]> GetAllStatesProvincesForCountryAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllStatesProvincesForCountryAsync(parameters);
        }

        public Task<StateProvince> GetStateProvinceAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetStateProvinceAsync(parameters);
        }

        public Task<StateProvince> SaveStateProvinceAsync(SaveParameters<StateProvince> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveStateProvinceAsync(parameters);
        }

        public Task<int> DeleteStateProvinceByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteStateProvinceByPkAsync(parameters);
        }

        public Task<int> DeleteStateProvinceAsync(DeleteParameters<StateProvince> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteStateProvinceAsync(parameters);
        }

        #endregion

        #endregion

    }
}
