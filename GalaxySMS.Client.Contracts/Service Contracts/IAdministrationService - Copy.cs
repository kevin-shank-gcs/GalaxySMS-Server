using GalaxySMS.Client.Entities;
using GalaxySMS.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Security;

namespace GalaxySMS.Client.Contracts
{
    [ServiceContract]
    public interface IAdministrationService : IServiceContract
    {
        #region System Operations
        #region Synchronous operations

        [OperationContract]
        gcsSystem[] GetAllSystems();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsSystem GetSystem(Guid systemId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsSystem SaveSystem(gcsSystem system);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteSystem(gcsSystem system);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof (ExceptionDetailEx))]
        gcsSystem SaveSystemLicense(Guid systemId, string publicKey, string license);
        #endregion

        #region Async operations
        [OperationContract]
        Task<gcsSystem[]> GetAllSystemsAsync();

        [OperationContract]
        Task<gcsSystem> GetSystemAsync(Guid systemId);

        [OperationContract]
        Task<gcsSystem> SaveSystemAsync(gcsSystem system);

        [OperationContract]
        Task<int> DeleteSystemAsync(gcsSystem system);

        [OperationContract]
        Task<gcsSystem> SaveSystemLicenseAsync(Guid systemId, string publicKey, string license);

        #endregion
        #endregion

        #region Entity Operations
        #region Synchronous operations
        [OperationContract]
        gcsEntity[] GetAllEntities(GetParametersWithPhoto parameters);

        [OperationContract]
        gcsEntity[] GetAllEntitiesForUser(Guid userId);


        [OperationContract]
        gcsEntity[] GetAllEntitiesForApplication(Guid applicationId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsEntity GetEntity(Guid entityId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsEntity SaveEntity(gcsEntity entity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteEntityByPk(Guid entityId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteEntity(gcsEntity entity);

        [OperationContract]
        bool IsEntityReferenced(Guid entityId);

        [OperationContract]
        bool IsEntityUnique(gcsEntity entity);
        #endregion

        #region Async operations
        [OperationContract]
        Task<gcsEntity[]> GetAllEntitiesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<gcsEntity[]> GetAllEntitiesForUserAsync(Guid userId);

        [OperationContract]
        Task<gcsEntity[]> GetAllEntitiesForApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<gcsEntity> GetEntityAsync(Guid entityId);

        [OperationContract]
        Task<gcsEntity> SaveEntityAsync(gcsEntity entity);

        [OperationContract]
        Task<int> DeleteEntityByPkAsync(Guid entityId);

        [OperationContract]
        Task<int> DeleteEntityAsync(gcsEntity entity);

        [OperationContract]
        Task<bool> IsEntityReferencedAsync(Guid entityId);

        [OperationContract]
        Task<bool> IsEntityUniqueAsync(gcsEntity entity);
        #endregion
        #endregion

        #region Language Operations
        #region Synchronous operations
        [OperationContract]
        gcsLanguage[] GetAllLanguages();

        [OperationContract]
        gcsLanguage[] GetAllLanguagesForBase(string baseLanguageCode);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsLanguage GetLanguage(Guid languageId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsLanguage SaveLanguage(gcsLanguage language);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteLanguageByPk(Guid languageId);


        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteLanguage(gcsLanguage language);

        [OperationContract]
        bool IsLanguageReferenced(Guid languageId);

        [OperationContract]
        bool IsLanguageUnique(gcsLanguage language);
        #endregion

        #region Async operations
        [OperationContract]
        Task<gcsLanguage[]> GetAllLanguagesAsync();

        [OperationContract]
        Task<gcsLanguage[]> GetAllLanguagesForBaseAsync(string baseLanguageCode);

        [OperationContract]
        Task<gcsLanguage> GetLanguageAsync(Guid languageId);

        [OperationContract]
        Task<gcsLanguage> SaveLanguageAsync(gcsLanguage language);

        [OperationContract]
        Task<int> DeleteLanguageByPkAsync(Guid languageId);

        [OperationContract]
        Task<int> DeleteLanguageAsync(gcsLanguage language);

        [OperationContract]
        Task<bool> IsLanguageReferencedAsync(Guid languageId);

        [OperationContract]
        Task<bool> IsLanguageUniqueAsync(gcsLanguage language);
        #endregion

        #endregion

        #region Application Operations
        #region Synchronous operations

        [OperationContract]
        gcsApplication[] GetAllApplications();

        [OperationContract]
        gcsApplication[] GetAllApplicationsForEntity(Guid entityId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsApplication GetApplication(Guid applicationId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsApplication SaveApplication(gcsApplication application);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteApplicationByPk(Guid applicationId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteApplication(gcsApplication application);
        [OperationContract]
        bool IsApplicationReferenced(Guid applicationId);

        [OperationContract]
        bool IsApplicationUnique(gcsApplication application);
       
        [OperationContract]
        bool IsApplicationInDatabase(Guid applicationId);

        [OperationContract]
        void SaveApplicationAuditData(gcsApplicationAudit auditData);

        #endregion
        #region Async operations
        [OperationContract]
        Task<gcsApplication[]> GetAllApplicationsAsync();


        [OperationContract]
        Task<gcsApplication[]> GetAllApplicationsForEntityAsync(Guid entityId);

        [OperationContract]
        Task<gcsApplication> GetApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<gcsApplication> SaveApplicationAsync(gcsApplication application);

        [OperationContract]
        Task<int> DeleteApplicationByPkAsync(Guid applicationId);

        [OperationContract]
        Task<int> DeleteApplicationAsync(gcsApplication application);

        [OperationContract]
        Task<bool> IsApplicationReferencedAsync(Guid applicationId);

        [OperationContract]
        Task<bool> IsApplicationUniqueAsync(gcsApplication application);

        [OperationContract]
        Task<bool> IsApplicationInDatabaseAsync(Guid applicationId);

        [OperationContract]
        Task SaveApplicationAuditDataAsync(gcsApplicationAudit auditData);

        #endregion
        #endregion

        #region Application Setting Operations
        #region Synchronous operations
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsApplicationSetting GetApplicationSetting(gcsApplicationSetting applicationSetting, bool bCreateIfNotFound);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsApplicationSetting GetApplicationSettingFromParams(Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound);

        [OperationContract]
        gcsApplicationSetting[] GetAllApplicationSettingsForApplication(Guid applicationId);

        [OperationContract]
        gcsApplicationSetting[] GetAllApplicationSettingsForApplicationCategory(Guid applicationId, string category);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsApplicationSetting SaveApplicationSetting(gcsApplicationSetting applicationSetting);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteApplicationSettingByPk(Guid applicationSettingId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteApplicationSetting(gcsApplicationSetting applicationSetting);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteApplicationSettingFromParams(Guid applicationId, string category, string settingKey);
        #endregion

        #region Async operations
        [OperationContract]
        Task<gcsApplicationSetting> GetApplicationSettingAsync(gcsApplicationSetting applicationSetting, bool bCreateIfNotFound);

        [OperationContract]
        Task<gcsApplicationSetting> GetApplicationSettingFromParamsAsync(Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound);

        [OperationContract]
        Task<gcsApplicationSetting[]> GetAllApplicationSettingsForApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<gcsApplicationSetting[]> GetAllApplicationSettingsForApplicationCategoryAsync(Guid applicationId, string category);

        [OperationContract]
        Task<gcsApplicationSetting> SaveApplicationSettingAsync(gcsApplicationSetting applicationSetting);

        [OperationContract]
        Task<int> DeleteApplicationSettingByPkAsync(Guid applicationSettingId);

        [OperationContract]
        Task<int> DeleteApplicationSettingAsync(gcsApplicationSetting applicationSetting);

        [OperationContract]
        Task<int> DeleteApplicationSettingFromParamsAsync(Guid applicationId, string category, string settingKey);
        #endregion
        #endregion

        #region Role Operations
        #region Synchronous operations
        [OperationContract]
        gcsRole[] GetAllRoles();

        [OperationContract]
        gcsRole[] GetAllRolesForApplication(Guid applicationId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsRole GetRole(Guid roleId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsRole SaveRole(gcsRole role);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteRoleByPk(Guid roleId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteRole(gcsRole role);

        [OperationContract]
        bool IsRoleReferenced(Guid roleId);

        [OperationContract]
        bool IsRoleUnique(gcsRole role);
        #endregion

        #region Async operations
        [OperationContract]
        Task<gcsRole[]> GetAllRolesAsync();

        [OperationContract]
        Task<gcsRole[]> GetAllRolesForApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<gcsRole> GetRoleAsync(Guid roleId);

        [OperationContract]
        Task<gcsRole> SaveRoleAsync(gcsRole role);

        [OperationContract]
        Task<int> DeleteRoleByPkAsync(Guid roleId);

        [OperationContract]
        Task<int> DeleteRoleAsync(gcsRole role);

        [OperationContract]
        Task<bool> IsRoleReferencedAsync(Guid roleId);

        [OperationContract]
        Task<bool> IsRoleUniqueAsync(gcsRole role);
        #endregion
        #endregion

        #region Permission Category Operations
        #region Synchronous operations
        [OperationContract]
        gcsPermissionCategory[] GetAllPermissionCategories();

        [OperationContract]
        gcsPermissionCategory[] GetAllPermissionCategoriesForApplication(Guid applicationId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsPermissionCategory GetPermissionCategory(Guid permissionCategoryId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsPermissionCategory SavePermissionCategory(gcsPermissionCategory permissionCategory);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePermissionCategoryByPk(Guid permissionCategoryId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePermissionCategory(gcsPermissionCategory permissionCategory);

        [OperationContract]
        bool IsPermissionCategoryReferenced(Guid permissionCategoryId);

        [OperationContract]
        bool IsPermissionCategoryUnique(gcsPermissionCategory permissionCategory);
        #endregion

        #region Async operations
        [OperationContract]
        Task<gcsPermissionCategory[]> GetAllPermissionCategoriesAsync();

        [OperationContract]
        Task<gcsPermissionCategory[]> GetAllPermissionCategoriesForApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<gcsPermissionCategory> GetPermissionCategoryAsync(Guid permissionCategoryId);

        [OperationContract]
        Task<gcsPermissionCategory> SavePermissionCategoryAsync(gcsPermissionCategory permissionCategory);

        [OperationContract]
        Task<int> DeletePermissionCategoryByPkAsync(Guid permissionCategoryId);

        [OperationContract]
        Task<int> DeletePermissionCategoryAsync(gcsPermissionCategory permissionCategory);

        [OperationContract]
        Task<bool> IsPermissionCategoryReferencedAsync(Guid permissionCategoryId);

        [OperationContract]
        Task<bool> IsPermissionCategoryUniqueAsync(gcsPermissionCategory permissionCategory);
        #endregion
        #endregion
        
        #region Permission Operations

        #region Synchronous operations
        [OperationContract]
        gcsPermission[] GetAllPermissions();

        [OperationContract]
        gcsPermission[] GetAllPermissionsForApplication(Guid applicationId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsPermission[] GetAllPermissionsForRole(Guid roleId);

        [OperationContract]
        gcsPermission[] GetAllPermissionsForPermissionCategory(Guid permissionCategoryId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsPermission GetPermission(Guid permissionId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsPermission SavePermission(gcsPermission permission);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePermissionByPk(Guid permissionId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePermission(gcsPermission permission);

        [OperationContract]
        bool IsPermissionReferenced(Guid permissionId);

        [OperationContract]
        bool IsPermissionUnique(gcsPermission permission);
        #endregion

        #region Async operations
        [OperationContract]
        Task<gcsPermission[]> GetAllPermissionsAsync();

        [OperationContract]
        Task<gcsPermission[]> GetAllPermissionsForApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<gcsPermission[]> GetAllPermissionsForRoleAsync(Guid roleId);


        [OperationContract]
        Task<gcsPermission[]> GetAllPermissionsForPermissionCategoryAsync(Guid permissionCategoryId);

        [OperationContract]
        Task<gcsPermission> GetPermissionAsync(Guid permissionId);

        [OperationContract]
        Task<gcsPermission> SavePermissionAsync(gcsPermission permission);

        [OperationContract]
        Task<int> DeletePermissionByPkAsync(Guid permissionId);

        [OperationContract]
        Task<int> DeletePermissionAsync(gcsPermission permission);

        [OperationContract]
        Task<bool> IsPermissionReferencedAsync(Guid permissionId);

        [OperationContract]
        Task<bool> IsPermissionUniqueAsync(gcsPermission permission);
        #endregion
        #endregion

        #region User Operations
        #region Synchronous operations
        [OperationContract]
        gcsUser[] GetAllUsers();

        [OperationContract]
        gcsUser[] GetAllUsersForApplication(Guid applicationId);

        [OperationContract]
        gcsUser[] GetAllUsersForRole(Guid roleId);

        [OperationContract]
        gcsUser[] GetAllUsersForEntity(Guid entityId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUser GetUser(Guid userId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUser SaveUser(gcsUser user);


        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUser SaveUserAccountRequest(gcsUser user);
        
         [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUserByPk(Guid userId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUser(gcsUser user);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUser GetByUserName(string userName);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUser GetByEmail(string email);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUser GetByPassword(string password);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        string GeneratePasswordResetToken(Guid userId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        void ResetPassword(Guid userId, string newPassword);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        string ChangePassword(Guid userId, string currentPassword, string newPassword);

        [OperationContract]
        bool IsUserReferenced(Guid userId);

        [OperationContract]
        bool IsUserUnique(gcsUser user);

        [OperationContract]
        PasswordValidationResult[] ValidatePassword(gcsUser user);

        [OperationContract]
        PasswordValidationResult[] ValidatePasswordForEntity(gcsUser user, Guid entityGuid);

        [OperationContract]
        gcsUserOldPassword[] GetOldPasswordsForUser(gcsUser user, int howMany);
        #endregion

        #region Async operations
        [OperationContract]
        Task<gcsUser[]> GetAllUsersAsync();

        [OperationContract]
        Task<gcsUser[]> GetAllUsersForApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<gcsUser[]> GetAllUsersForRoleAsync(Guid roleId);

        [OperationContract]
        Task<gcsUser[]> GetAllUsersForEntityAsync(Guid entityId);

        [OperationContract]
        Task<gcsUser> GetUserAsync(Guid userId);

        [OperationContract]
        Task<gcsUser> SaveUserAsync(gcsUser user);

        [OperationContract]
        Task<gcsUser> SaveUserAccountRequestAsync(gcsUser user);
        
        [OperationContract]
        Task<int> DeleteUserByPkAsync(Guid userId);

        [OperationContract]
        Task<int> DeleteUserAsync(gcsUser user);

        [OperationContract]
        Task<gcsUser> GetByUserNameAsync(string userName);

        [OperationContract]
        Task<gcsUser> GetByEmailAsync(string email);

        [OperationContract]
        Task<gcsUser> GetByPasswordAsync(string password);

        [OperationContract]
        Task<string> GeneratePasswordResetTokenAsync(Guid userId);

        [OperationContract]
        Task ResetPasswordAsync(Guid userId, string newPassword);

        [OperationContract]
        Task<string> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);

        [OperationContract]
        Task<bool> IsUserReferencedAsync(Guid userId);

        [OperationContract]
        Task<bool> IsUserUniqueAsync(gcsUser user);

        [OperationContract]
        Task<PasswordValidationResult[]> ValidatePasswordAsync(gcsUser user);
        
        [OperationContract]
        Task<PasswordValidationResult[]> ValidatePasswordForEntityAsync(gcsUser user, Guid entityGuid);

        [OperationContract]
        Task<gcsUserOldPassword[]> GetOldPasswordsForUserAsync(gcsUser user, int howMany);
        #endregion
        #endregion

        #region User Requirements Operations
        #region Synchronous operations
        [OperationContract]
        gcsUserRequirement GetUserRequirementForEntity(Guid entityId);

        [OperationContract]
        gcsUserRequirement[] GetAllUserRequirements();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUserRequirement SaveUserRequirement(gcsUserRequirement userRequirement);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUserRequirementByPk(Guid userRequirementId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUserRequirement(gcsUserRequirement userRequirement);
        #endregion

        #region Async operations
        [OperationContract]
        Task<gcsUserRequirement> GetUserRequirementForEntityAsync(Guid entityId);

        [OperationContract]
        Task<gcsUserRequirement[]> GetAllUserRequirementsAsync();

        [OperationContract]
        Task<gcsUserRequirement> SaveUserRequirementAsync(gcsUserRequirement userRequirement);

        [OperationContract]
        Task<int> DeleteUserRequirementByPkAsync(Guid userRequirementId);

        [OperationContract]
        Task<int> DeleteUserRequirementAsync(gcsUserRequirement userRequirement);
        #endregion
        #endregion

        #region User Setting Operations
        #region Synchronous operations
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUserSetting GetUserSetting(gcsUserSetting userSetting, bool bCreateIfNotFound);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUserSetting GetUserSettingFromParams(Guid userId, Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound);

        [OperationContract]
        gcsUserSetting[] GetAllUserSettingsForUser(Guid userId);

        [OperationContract]
        gcsUserSetting[] GetAllUserSettingsForUserApplication(Guid userId, Guid applicationId);

        [OperationContract]
        gcsUserSetting[] GetAllUserSettingsForUserApplicationCategory(Guid userId, Guid applicationId, string category);

        [OperationContract]
        gcsUserSetting[] GetAllUserSettingsForApplication(Guid applicationId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUserSetting SaveUserSetting(gcsUserSetting userSetting);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUserSettingByPk(Guid userSettingId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUserSetting(gcsUserSetting userSetting);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteUserSettingFromParams(Guid userId, Guid applicationId, string category, string settingKey);
        #endregion
        #region Async operations
        [OperationContract]
        Task<gcsUserSetting> GetUserSettingAsync(gcsUserSetting userSetting, bool bCreateIfNotFound);

        [OperationContract]
        Task<gcsUserSetting> GetUserSettingFromParamsAsync(Guid userId, Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound);

        [OperationContract]
        Task<gcsUserSetting[]> GetAllUserSettingsForUserAsync(Guid userId);

        [OperationContract]
        Task<gcsUserSetting[]> GetAllUserSettingsForUserApplicationAsync(Guid userId, Guid applicationId);

        [OperationContract]
        Task<gcsUserSetting[]> GetAllUserSettingsForUserApplicationCategoryAsync(Guid userId, Guid applicationId, string category);

        [OperationContract]
        Task<gcsUserSetting[]> GetAllUserSettingsForApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<gcsUserSetting> SaveUserSettingAsync(gcsUserSetting userSetting);

        [OperationContract]
        Task<int> DeleteUserSettingByPkAsync(Guid userSettingId);

        [OperationContract]
        Task<int> DeleteUserSettingAsync(gcsUserSetting userSetting);

        [OperationContract]
        Task<int> DeleteUserSettingFromParamsAsync(Guid userId, Guid applicationId, string category, string settingKey);        
        #endregion
        #endregion

        #region Initialize System Database
        #region Synchronous operations
        [OperationContract]
        bool InitializeSystemDatabase(InitializeSystemDatabaseRequest requestData);

        #endregion
        #region Async operations
        [OperationContract]
        Task<bool> InitializeSystemDatabaseAsync(InitializeSystemDatabaseRequest requestData);
        #endregion
        #endregion

        #region Country Operations

        #region Synchronous operations

        [OperationContract]
        Country[] GetAllCountries(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof (ExceptionDetailEx))]
        Country GetCountry(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof (ExceptionDetailEx))]
        Country SaveCountry(SaveParameters<Country> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCountryByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof (ExceptionDetailEx))]
        int DeleteCountry(DeleteParameters<Country> parameters);

        #endregion

        #region Async operations

        [OperationContract]
        Task<Country[]> GetAllCountriesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Country> GetCountryAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<Country> SaveCountryAsync(SaveParameters<Country> parameters);

        [OperationContract]
        Task<int> DeleteCountryByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteCountryAsync(DeleteParameters<Country> parameters);

        #endregion

        #endregion

        #region StateProvince Operations

        #region Synchronous operations

        [OperationContract]
        StateProvince[] GetAllStatesProvinces(GetParametersWithPhoto parameters);

        [OperationContract]
        StateProvince[] GetAllStatesProvincesForCountry(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof (ExceptionDetailEx))]
        StateProvince GetStateProvince(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof (ExceptionDetailEx))]
        StateProvince SaveStateProvince(SaveParameters<StateProvince> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteStateProvinceByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof (ExceptionDetailEx))]
        int DeleteStateProvince(DeleteParameters<StateProvince> parameters);

        #endregion

        #region Async operations

        [OperationContract]
        Task<StateProvince[]> GetAllStatesProvincesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<StateProvince[]> GetAllStatesProvincesForCountryAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<StateProvince> GetStateProvinceAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<StateProvince> SaveStateProvinceAsync(SaveParameters<StateProvince> parameters);

        [OperationContract]
        Task<int> DeleteStateProvinceByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteStateProvinceAsync(DeleteParameters<StateProvince> parameters);

        #endregion

        #endregion
    }

}
