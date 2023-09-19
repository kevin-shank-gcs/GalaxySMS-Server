using GalaxySMS.Business.Entities;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Security;
using System;
using System.ServiceModel;
using GalaxySMS.Common.Enums;

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
        gcsSystem SaveSystem(SaveParameters<gcsSystem> parameters);

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
        ArrayResponse<gcsEntityEx> GetAllEntities(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsEntityEx> GetAllEntitiesForUser(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsEntityEx GetEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsEntityEx SaveEntity(SaveParameters<gcsEntity> parameters);
        
        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        BackgroundJobInfo SaveEntityJob(SaveParameters<gcsEntity> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteEntityByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteEntity(DeleteParameters<gcsEntity> parameters);

        [OperationContract]
        bool IsEntityReferenced(Guid entityId);

        [OperationContract]
        bool IsEntityUnique(gcsEntity entity);

        [OperationContract]
        EntityMapPermissionLevel[] GetEntityMapPermissionLevels(GetParametersWithPhoto parameters);

        [OperationContract]
        EntityEditingData GetEntityEditingData(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityExBasic[] GetEntityList(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityExBasic[] GetEntityListForUser(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityExBasic[] GetEntityListByName(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityEx[] GetEntitiesByName(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityExBasic[] GetEntityListByDescription(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityEx[] GetEntitiesByDescription(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityExBasic[] GetEntityListByNameOrDescription(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityEx[] GetEntitiesByNameOrDescription(GetParametersWithPhoto parameters);


        [OperationContract]
        ArrayResponse<gcsEntityExBasic> GetEntityList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsEntityExBasic> GetEntityListForUser(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsEntityExBasic> GetEntityListByName(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsEntityEx> GetEntitiesByName(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsEntityExBasic> GetEntityListByDescription(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsEntityEx> GetEntitiesByDescription(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsEntityExBasic> GetEntityListByNameOrDescription(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsEntityEx> GetEntitiesByNameOrDescription(GetParametersWithPhoto parameters);



        [OperationContract]
        gcsEntityCounts UpdateCountsForEntity(Guid entityId);

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
        gcsLanguage SaveLanguage(SaveParameters<gcsLanguage> parameters);

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
        gcsApplicationBasic[] GetAllApplicationBasic(GetParametersWithPhoto parameters);

        [OperationContract]
        gcsApplication[] GetAllApplicationsForEntity(Guid entityId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsApplication GetApplication(Guid applicationId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsApplication SaveApplication(SaveParameters<gcsApplication> parameters);

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
        void SaveApplicationAuditData(SaveParameters<gcsApplicationAudit> parameters);
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
        gcsApplicationSetting SaveApplicationSetting(SaveParameters<gcsApplicationSetting> parameters);

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

        #region Serialized Object Operations

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsSerializedObject GetSerializedObject(Guid serializedObjectId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsSerializedObject GetSerializedObjectByApplicationIdAndKey(Guid applicationId, string key);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsSerializedObject SaveSerializedObject(SaveParameters<gcsSerializedObject> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteSerializedObjectByPk(Guid serializedObjectId);

        #endregion

        #region Large Object Storage Operations

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsLargeObjectStorage GetLargeObject(Guid uid);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsLargeObjectStorage GetLargeObjectByEntityIdAndUniqueTag(Guid entityId, string uniqueTag);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsLargeObjectStorage SaveLargeObject(SaveParameters<gcsLargeObjectStorage> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteLargeObjectByPk(Guid uid);

        #endregion

        #region Role Operations
        [OperationContract]
        ArrayResponse<gcsRole> GetAllRoles(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsRole> GetAllRolesForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsRole GetRole(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsRole SaveRole(SaveParameters<gcsRole> parameters);

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

        [OperationContract]
        EntityRoleEditingData GetRoleEditingData(GetParametersWithPhoto parameters);

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
        gcsPermissionCategory SavePermissionCategory(SaveParameters<gcsPermissionCategory> parameters);

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
        gcsPermission SavePermission(SaveParameters<gcsPermission> parameters);

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

        #region Property Sensitivity Level Operations
        [OperationContract]
        PropertySensitivityLevel[] GetAllPropertySensitivityLevels(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        PropertySensitivityLevel GetPropertySensitivityLevel(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        PropertySensitivityLevel SavePropertySensitivityLevel(SaveParameters<PropertySensitivityLevel> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePropertySensitivityLevelByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeletePropertySensitivityLevel(DeleteParameters<PropertySensitivityLevel> parameters);

        [OperationContract]
        bool IsPropertySensitivityLevelReferenced(Guid uid);

        [OperationContract]
        bool IsPropertySensitivityLevelUnique(PropertySensitivityLevel data);
        #endregion

        #region User Operations
        [OperationContract]
        ArrayResponse<gcsUser> GetAllUsers();

        [OperationContract]
        ArrayResponse<gcsUserBasic> GetAllUsersList(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsUser> GetAllUsersForApplication(Guid applicationId);

        [OperationContract]
        ArrayResponse<gcsUser> GetAllUsersForRole(Guid roleId);

        [OperationContract]
        ArrayResponse<gcsUser> GetAllUsersForEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        //gcsUser GetUser(Guid userId);
        gcsUser GetUser(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUser SaveUser(SaveParameters<gcsUser> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUser SaveUserSave(SaveParameters<gcsUserSave> parameters);

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
        //PasswordValidationResult[] ValidatePassword(gcsUser user);
        PasswordValidationInfo ValidatePassword(gcsUser user, bool isEncrypted);

        [OperationContract]
        //PasswordValidationResult[] ValidatePasswordForEntity(gcsUser user, Guid entityGuid);
        PasswordValidationInfo ValidatePasswordForEntity(gcsUser user, Guid entityGuid);

        [OperationContract]
        gcsUserOldPassword[] GetOldPasswordsForUser(gcsUser user, int howMany);

        [OperationContract]
        gcsUserEditingData GetUserEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserRequestPasswordChangeTokenResponse RequestUserPasswordChangeToken(UserRequestPasswordChangeToken parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UpdateUserPasswordResult UpdateUserPassword(UpdateUserPasswordParameters parameters);

        [OperationContract]
        UserEntityPermissions GetUserPermissions(GetParametersWithPhoto parameters);

        #endregion

        #region User Requirements Operations
        [OperationContract]
        gcsUserRequirement GetUserRequirementForEntity(Guid entityId);

        [OperationContract]
        gcsUserRequirement[] GetAllUserRequirements();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUserRequirement SaveUserRequirement(SaveParameters<gcsUserRequirement> parameters);

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
        gcsUserSetting GetUserSettingFromParams(Guid userId, Guid? applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound);

        [OperationContract]
        gcsUserSetting[] GetAllUserSettingsForUser(Guid userId);

        [OperationContract]
        gcsUserSetting[] GetAllUserSettingsForUserApplication(Guid userId, Guid? applicationId);

        [OperationContract]
        gcsUserSetting[] GetAllUserSettingsForUserApplicationCategory(Guid userId, Guid? applicationId, string category);

        [OperationContract]
        gcsUserSetting[] GetAllUserSettingsForApplication(Guid? applicationId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsUserSetting SaveUserSetting(SaveParameters<gcsUserSetting> parameters);

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
        int DeleteUserSettingFromParams(Guid userId, Guid? applicationId, string category, string settingKey);
        #endregion

        #region gcsSetting Operations

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsSetting GetSetting(gcsSetting setting, bool bCreateIfNotFound);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsSetting GetSettingFromParams(Guid entityId, string group, string subGroup, string key, string defaultValue, bool bCreateIfNotFound);

        [OperationContract]
        gcsSetting[] GetSettingsForEntity(Guid entityId);

        [OperationContract]
        gcsSetting[] GetSettingsForEntityAndGroup(Guid entityId, string group);

        [OperationContract]
        gcsSetting[] GetSettingsForEntityGroupAndSubGroup(Guid entityId, string group, string subGroup);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsSetting SaveSetting(SaveParameters<gcsSetting> parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteSettingByPk(Guid settingId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteSetting(gcsSetting setting);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteSettingFromParams(Guid entityId, string group, string subGroup, string key);
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
        [FaultContract(typeof(ExceptionDetailEx))]
        Country GetCountryByIso(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Country GetCountryByIso3(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        Country[] GetCountriesByCountryName(GetParametersWithPhoto parameters);



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

        #region Background Job Operations

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        BackgroundJobInfo[] GetBackgroundJobs(GetParametersWithPhoto parameters, BackgroundJobState state);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        BackgroundJobInfo GetBackgroundJob(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        int DeleteBackgroundJobByPk(DeleteParameters parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        BackgroundJobInfo SaveBackgroundJobStateChange(Guid backgroundJobId, BackgroundJobState state, string info);

        #endregion

    }
}
