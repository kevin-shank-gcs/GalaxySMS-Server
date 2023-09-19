using GalaxySMS.Client.Entities;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Security;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

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

        #region Async operations
        [OperationContract]
        Task<gcsSystem[]> GetAllSystemsAsync();

        [OperationContract]
        Task<gcsSystem> GetSystemAsync(Guid systemId);

        [OperationContract]
        Task<gcsSystem> SaveSystemAsync(SaveParameters<gcsSystem> parameters);

        [OperationContract]
        Task<int> DeleteSystemAsync(gcsSystem system);

        [OperationContract]
        Task<gcsSystem> SaveSystemLicenseAsync(Guid systemId, string publicKey, string license);

        #endregion
        #endregion

        //#region Entity Operations
        //#region Synchronous operations
        //[OperationContract]
        //gcsEntity[] GetAllEntities(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntity[] GetAllEntitiesForUser(GetParametersWithPhoto parameters);


        //[OperationContract]
        //gcsEntity[] GetAllEntitiesForApplication(GetParametersWithPhoto parameters);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //gcsEntity GetEntity(GetParametersWithPhoto parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //gcsEntity SaveEntity(SaveParameters<gcsEntity> parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //int DeleteEntityByPk(DeleteParameters parameters);

        //[OperationContract]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //int DeleteEntity(DeleteParameters<gcsEntity> parameters);

        //[OperationContract]
        //bool IsEntityReferenced(Guid entityId);

        //[OperationContract]
        //bool IsEntityUnique(gcsEntity entity);

        //[OperationContract]
        //EntityMapPermissionLevel[] GetEntityMapPermissionLevels(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityBasic[] GetEntityList(GetParametersWithPhoto parameters);

        //#endregion

        //#region Async operations
        //[OperationContract]
        //Task<gcsEntity[]> GetAllEntitiesAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntity[]> GetAllEntitiesForUserAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntity[]> GetAllEntitiesForApplicationAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntity> GetEntityAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntity> SaveEntityAsync(SaveParameters<gcsEntity> parameters);

        //[OperationContract]
        //Task<int> DeleteEntityByPkAsync(DeleteParameters parameters);

        //[OperationContract]
        //Task<int> DeleteEntityAsync(DeleteParameters<gcsEntity> parameters);

        //[OperationContract]
        //Task<bool> IsEntityReferencedAsync(Guid entityId);

        //[OperationContract]
        //Task<bool> IsEntityUniqueAsync(gcsEntity entity);

        //[OperationContract]
        //Task<EntityMapPermissionLevel[]> GetEntityMapPermissionLevelsAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntityBasic[]> GetEntityListAsync(GetParametersWithPhoto parameters);


        //#endregion
        //#endregion
        #region Entity Operations
        #region Synchronous operations
        //[OperationContract]
        //gcsEntityEx[] GetAllEntities(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityEx[] GetAllEntitiesForUser(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsEntityEx> GetAllEntities(GetParametersWithPhoto parameters);

        [OperationContract]
        ArrayResponse<gcsEntityEx> GetAllEntitiesForUser(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityEx[] GetAllEntitiesForApplication(GetParametersWithPhoto parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsEntityEx GetEntity(GetParametersWithPhoto parameters);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ExceptionDetailEx))]
        gcsEntityEx SaveEntity(SaveParameters<gcsEntity> parameters);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionDetailEx))]
        //BackgroundJobInfo SaveEntityJob(SaveParameters<gcsEntity> parameters);

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
        EntityEditingData GetEntityEditingData(GetParametersWithPhoto parameters);

        [OperationContract]
        EntityMapPermissionLevel[] GetEntityMapPermissionLevels(GetParametersWithPhoto parameters);

        //[OperationContract]
        //gcsEntityExBasic[] GetEntityList(GetParametersWithPhoto parameters);

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

        #region Async operations
        //[OperationContract]
        //Task<gcsEntityEx[]> GetAllEntitiesAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntityEx[]> GetAllEntitiesForUserAsync(GetParametersWithPhoto parameters);
        [OperationContract]
        Task<ArrayResponse<gcsEntityEx>> GetAllEntitiesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<gcsEntityEx>> GetAllEntitiesForUserAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<gcsEntityEx> GetEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<gcsEntityEx> SaveEntityAsync(SaveParameters<gcsEntity> parameters);
  
        //[OperationContract]
        //Task<BackgroundJobInfo> SaveEntityJobAsync(SaveParameters<gcsEntity> parameters);

        [OperationContract]
        Task<int> DeleteEntityByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeleteEntityAsync(DeleteParameters<gcsEntity> parameters);

        [OperationContract]
        Task<bool> IsEntityReferencedAsync(Guid entityId);

        [OperationContract]
        Task<bool> IsEntityUniqueAsync(gcsEntity entity);
        
        [OperationContract]
        Task<EntityEditingData> GetEntityEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<EntityMapPermissionLevel[]> GetEntityMapPermissionLevelsAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntityExBasic[]> GetEntityListAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntityExBasic[]> GetEntityListByNameAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntityEx[]> GetEntitiesByNameAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntityExBasic[]> GetEntityListByDescriptionAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntityEx[]> GetEntitiesByDescriptionAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntityExBasic[]> GetEntityListByNameOrDescriptionAsync(GetParametersWithPhoto parameters);

        //[OperationContract]
        //Task<gcsEntityEx[]> GetEntitiesByNameOrDescriptionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<gcsEntityExBasic>> GetEntityListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<gcsEntityExBasic>> GetEntityListForUserAsync(GetParametersWithPhoto parameters);
        
        [OperationContract]
        Task<ArrayResponse<gcsEntityExBasic>> GetEntityListByNameAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<gcsEntityEx>> GetEntitiesByNameAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<gcsEntityExBasic>> GetEntityListByDescriptionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<gcsEntityEx>> GetEntitiesByDescriptionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<gcsEntityExBasic>> GetEntityListByNameOrDescriptionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<gcsEntityEx>> GetEntitiesByNameOrDescriptionAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<gcsEntityCounts> UpdateCountsForEntityAsync(Guid entityId);

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

        #region Async operations
        [OperationContract]
        Task<gcsLanguage[]> GetAllLanguagesAsync();

        [OperationContract]
        Task<gcsLanguage[]> GetAllLanguagesForBaseAsync(string baseLanguageCode);

        [OperationContract]
        Task<gcsLanguage> GetLanguageAsync(Guid languageId);

        [OperationContract]
        Task<gcsLanguage> SaveLanguageAsync(SaveParameters<gcsLanguage> parameters);

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
        #region Async operations
        [OperationContract]
        Task<gcsApplication[]> GetAllApplicationsAsync();

        [OperationContract]
        Task<gcsApplicationBasic[]> GetAllApplicationBasicAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<gcsApplication[]> GetAllApplicationsForEntityAsync(Guid entityId);

        [OperationContract]
        Task<gcsApplication> GetApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<gcsApplication> SaveApplicationAsync(SaveParameters<gcsApplication> parameters);

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
        Task SaveApplicationAuditDataAsync(SaveParameters<gcsApplicationAudit> parameters);

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
        Task<gcsApplicationSetting> SaveApplicationSettingAsync(SaveParameters<gcsApplicationSetting> parameters);

        [OperationContract]
        Task<int> DeleteApplicationSettingByPkAsync(Guid applicationSettingId);

        [OperationContract]
        Task<int> DeleteApplicationSettingAsync(gcsApplicationSetting applicationSetting);

        [OperationContract]
        Task<int> DeleteApplicationSettingFromParamsAsync(Guid applicationId, string category, string settingKey);
        #endregion
        #endregion

        #region Serialized Object Operations

        #region Synchronous operations

        [OperationContract]
        gcsSerializedObject GetSerializedObject(Guid serializedObjectId);

        [OperationContract]
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

        #region Async operations

        [OperationContract]
        Task<gcsSerializedObject> GetSerializedObjectAsync(Guid serializedObjectId);

        [OperationContract]
        Task<gcsSerializedObject> GetSerializedObjectByApplicationIdAndKeyAsync(Guid applicationId, string key);

        [OperationContract]
        Task<gcsSerializedObject> SaveSerializedObjectAsync(SaveParameters<gcsSerializedObject> parameters);

        [OperationContract]
        Task<int> DeleteSerializedObjectByPkAsync(Guid serializedObjectId);

        #endregion

        #endregion

        #region Large Object Storage Operations

        #region Synchronous operations
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

        #region Async operations
        [OperationContract]
        Task<gcsLargeObjectStorage> GetLargeObjectAsync(Guid uid);

        [OperationContract]
        Task<gcsLargeObjectStorage> GetLargeObjectByEntityIdAndUniqueTagAsync(Guid entityId, string uniqueTag);

        [OperationContract]
        Task<gcsLargeObjectStorage> SaveLargeObjectAsync(SaveParameters<gcsLargeObjectStorage> parameters);

        [OperationContract]
        Task<int> DeleteLargeObjectByPkAsync(Guid uid);

        #endregion
        #endregion

        #region Role Operations
        #region Synchronous operations
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

        #region Async operations
        [OperationContract]
        Task<ArrayResponse<gcsRole>> GetAllRolesAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<gcsRole>> GetAllRolesForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<gcsRole> GetRoleAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<gcsRole> SaveRoleAsync(SaveParameters<gcsRole> parameters);

        [OperationContract]
        Task<int> DeleteRoleByPkAsync(Guid roleId);

        [OperationContract]
        Task<int> DeleteRoleAsync(gcsRole role);

        [OperationContract]
        Task<bool> IsRoleReferencedAsync(Guid roleId);

        [OperationContract]
        Task<bool> IsRoleUniqueAsync(gcsRole role);

        [OperationContract]
        Task<EntityRoleEditingData> GetRoleEditingDataAsync(GetParametersWithPhoto parameters);

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

        #region Async operations
        [OperationContract]
        Task<gcsPermissionCategory[]> GetAllPermissionCategoriesAsync();

        [OperationContract]
        Task<gcsPermissionCategory[]> GetAllPermissionCategoriesForApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<gcsPermissionCategory> GetPermissionCategoryAsync(Guid permissionCategoryId);

        [OperationContract]
        Task<gcsPermissionCategory> SavePermissionCategoryAsync(SaveParameters<gcsPermissionCategory> parameters);

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
        Task<gcsPermission> SavePermissionAsync(SaveParameters<gcsPermission> parameters);

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

        #region Property Sensitivity Level Operations
        #region Synchronous operations
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

        #region Async operations
        [OperationContract]
        Task<PropertySensitivityLevel[]> GetAllPropertySensitivityLevelsAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<PropertySensitivityLevel> GetPropertySensitivityLevelAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<PropertySensitivityLevel> SavePropertySensitivityLevelAsync(SaveParameters<PropertySensitivityLevel> parameters);

        [OperationContract]
        Task<int> DeletePropertySensitivityLevelByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<int> DeletePropertySensitivityLevelAsync(DeleteParameters<PropertySensitivityLevel> parameters);

        [OperationContract]
        Task<bool> IsPropertySensitivityLevelReferencedAsync(Guid uid);

        [OperationContract]
        Task<bool> IsPropertySensitivityLevelUniqueAsync(PropertySensitivityLevel data);
        #endregion
        #endregion

        #region User Operations
        #region Synchronous operations
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

        #region Async operations
        [OperationContract]
        Task<ArrayResponse<gcsUser>> GetAllUsersAsync();

        [OperationContract]
        Task<ArrayResponse<gcsUserBasic>> GetAllUsersListAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<ArrayResponse<gcsUser>> GetAllUsersForApplicationAsync(Guid applicationId);

        [OperationContract]
        Task<ArrayResponse<gcsUser>> GetAllUsersForRoleAsync(Guid roleId);

        [OperationContract]
        Task<ArrayResponse<gcsUser>> GetAllUsersForEntityAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        //       Task<gcsUser> GetUserAsync(Guid userId);
        Task<gcsUser> GetUserAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<gcsUser> SaveUserAsync(SaveParameters<gcsUser> parameters);

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
        Task<PasswordValidationInfo> ValidatePasswordAsync(gcsUser user, bool isEncrypted);

        [OperationContract]
        Task<PasswordValidationInfo> ValidatePasswordForEntityAsync(gcsUser user, Guid entityGuid);

        [OperationContract]
        Task<gcsUserOldPassword[]> GetOldPasswordsForUserAsync(gcsUser user, int howMany);
        
        [OperationContract]
        Task<gcsUserEditingData> GetUserEditingDataAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<UserRequestPasswordChangeTokenResponse> RequestUserPasswordChangeTokenAsync(UserRequestPasswordChangeToken parameters);

        [OperationContract]
        Task<UpdateUserPasswordResult> UpdateUserPasswordAsync(UpdateUserPasswordParameters parameters);

        [OperationContract]
        Task<UserEntityPermissions> GetUserPermissionsAsync(GetParametersWithPhoto parameters);
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

        #region Async operations
        [OperationContract]
        Task<gcsUserRequirement> GetUserRequirementForEntityAsync(Guid entityId);

        [OperationContract]
        Task<gcsUserRequirement[]> GetAllUserRequirementsAsync();

        [OperationContract]
        Task<gcsUserRequirement> SaveUserRequirementAsync(SaveParameters<gcsUserRequirement> parameters);

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
        #region Async operations
        [OperationContract]
        Task<gcsUserSetting> GetUserSettingAsync(gcsUserSetting userSetting, bool bCreateIfNotFound);

        [OperationContract]
        Task<gcsUserSetting> GetUserSettingFromParamsAsync(Guid userId, Guid? applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound);

        [OperationContract]
        Task<gcsUserSetting[]> GetAllUserSettingsForUserAsync(Guid userId);

        [OperationContract]
        Task<gcsUserSetting[]> GetAllUserSettingsForUserApplicationAsync(Guid userId, Guid? applicationId);

        [OperationContract]
        Task<gcsUserSetting[]> GetAllUserSettingsForUserApplicationCategoryAsync(Guid userId, Guid? applicationId, string category);

        [OperationContract]
        Task<gcsUserSetting[]> GetAllUserSettingsForApplicationAsync(Guid? applicationId);

        [OperationContract]
        Task<gcsUserSetting> SaveUserSettingAsync(SaveParameters<gcsUserSetting> parameters);

        [OperationContract]
        Task<int> DeleteUserSettingByPkAsync(Guid userSettingId);

        [OperationContract]
        Task<int> DeleteUserSettingAsync(gcsUserSetting userSetting);

        [OperationContract]
        Task<int> DeleteUserSettingFromParamsAsync(Guid userId, Guid? applicationId, string category, string settingKey);
        #endregion
        #endregion

        #region gcsSetting Operations
        #region Synchronous operations

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

        #region Async operations

        [OperationContract]
        Task<gcsSetting> GetSettingAsync(gcsSetting setting, bool bCreateIfNotFound);

        [OperationContract]
        Task<gcsSetting> GetSettingFromParamsAsync(Guid entityId, string group, string subGroup, string key, string defaultValue, bool bCreateIfNotFound);

        [OperationContract]
        Task<gcsSetting[]> GetSettingsForEntityAsync(Guid entityId);

        [OperationContract]
        Task<gcsSetting[]> GetSettingsForEntityAndGroupAsync(Guid entityId, string group);

        [OperationContract]
        Task<gcsSetting[]> GetSettingsForEntityGroupAndSubGroupAsync(Guid entityId, string group, string subGroup);

        [OperationContract]
        Task<gcsSetting> SaveSettingAsync(SaveParameters<gcsSetting> parameters);

        [OperationContract]
        Task<int> DeleteSettingByPkAsync(Guid settingId);

        [OperationContract]
        Task<int> DeleteSettingAsync(gcsSetting setting);

        [OperationContract]
        Task<int> DeleteSettingFromParamsAsync(Guid entityId, string group, string subGroup, string key);
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

        #region Background Job Operations
        #region Synchronous operations
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

        #region Asynchronous operations
        [OperationContract]
        Task<BackgroundJobInfo[]> GetBackgroundJobsAsync(GetParametersWithPhoto parameters, BackgroundJobState state);

        [OperationContract]
        Task<BackgroundJobInfo> GetBackgroundJobAsync(GetParametersWithPhoto parameters);

        [OperationContract]
        Task<int> DeleteBackgroundJobByPkAsync(DeleteParameters parameters);

        [OperationContract]
        Task<BackgroundJobInfo> SaveBackgroundJobStateChangeAsync(Guid backgroundJobId, BackgroundJobState state, string info);
        #endregion
        #endregion
    }

}
