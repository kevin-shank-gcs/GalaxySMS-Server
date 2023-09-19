using System.ComponentModel;
using GalaxySMS.Business.Entities;
using GalaxySMS.Common;
using GCS.Core.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Security;

namespace GalaxySMS.Business.Contracts
{
    [ServiceContract]
    public interface IAdministrationService
    {
        #region System Operations

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
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsSystem SaveSystemLicense(Guid systemId, string publicKey, string license);

        #endregion

        #region Entity Operations
        [OperationContract]
        gcsEntity[] GetAllEntities(GetParametersWithPhoto parameters);

        [OperationContract]
        gcsEntity[] GetAllEntitiesForUser(Guid userId);

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

        #region Language Operations
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

        #region Application Operations
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

        #region Application Setting Operations

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

        #region Role Operations
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

        #region Permission Category Operations
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
        
        #region Permission Operations
        [OperationContract]
        gcsPermission[] GetAllPermissions();

        [OperationContract]
        gcsPermission[] GetAllPermissionsForApplication(Guid applicationId);

        [OperationContract]
        gcsPermission[] GetAllPermissionsForPermissionCategory(Guid permissionCategoryId);

        [OperationContract]
        gcsPermission[] GetAllPermissionsForRole(Guid roleId);

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
        bool IsPermissionUnique(gcsPermission permissiony);
        #endregion

        #region User Operations
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

        #region User Requirements Operations
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

        #region User Setting Operations

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

        #region Initialize System Database
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool InitializeSystemDatabase(InitializeSystemDatabaseRequest requestData);
        #endregion

        #region Country Operations

        [OperationContract]
        Country[] GetAllCountries(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Country GetCountry(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        Country SaveCountry(SaveParameters<Country> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCountryByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteCountry(DeleteParameters<Country> parameters);

        #endregion

        #region StateProvince Operations

        [OperationContract]
        StateProvince[] GetAllStatesProvinces(GetParametersWithPhoto parameters);

        [OperationContract]
        StateProvince[] GetAllStatesProvincesForCountry(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        StateProvince GetStateProvince(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        StateProvince SaveStateProvince(SaveParameters<StateProvince> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteStateProvinceByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteStateProvince(DeleteParameters<StateProvince> parameters);

        #endregion
    }
}
