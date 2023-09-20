using GalaxySMS.Client.Contracts;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.ServiceModel.Extensions;
using GCS.Framework.Security;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Enums;

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

        public gcsSystem SaveSystem(SaveParameters<gcsSystem> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSystem(parameters);
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

        public Task<gcsSystem> SaveSystemAsync(SaveParameters<gcsSystem> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSystemAsync(parameters);
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

        //#region Entity operations
        //#region Synchronous operations
        //public gcsEntity[] GetAllEntities(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllEntities(parameters);
        //}

        //public gcsEntity[] GetAllEntitiesForUser(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllEntitiesForUser(parameters);
        //}

        //public gcsEntity[] GetAllEntitiesForApplication(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllEntitiesForApplication(parameters);
        //}

        //public gcsEntity GetEntity(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntity(parameters);
        //}

        //public gcsEntity SaveEntity(SaveParameters<gcsEntity> parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.SaveEntity(parameters);
        //}

        //public int DeleteEntityByPk(DeleteParameters parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.DeleteEntityByPk(parameters);
        //}

        //public int DeleteEntity(DeleteParameters<gcsEntity> parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.DeleteEntity(parameters);
        //}

        //public bool IsEntityReferenced(Guid entityId)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.IsEntityReferenced(entityId);
        //}

        //public bool IsEntityUnique(gcsEntity entity)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.IsEntityUnique(entity);
        //}

        //public EntityMapPermissionLevel[] GetEntityMapPermissionLevels(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntityMapPermissionLevels(parameters);
        //}

        //public gcsEntityBasic[] GetEntityList(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntityList(parameters);
        //}
        //#endregion

        //#region Async operations
        //public Task<gcsEntity[]> GetAllEntitiesAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllEntitiesAsync(parameters);
        //}

        //public Task<gcsEntity[]> GetAllEntitiesForUserAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllEntitiesForUserAsync(parameters);
        //}

        //public Task<gcsEntity[]> GetAllEntitiesForApplicationAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllEntitiesForApplicationAsync(parameters);
        //}

        //public Task<gcsEntity> GetEntityAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntityAsync(parameters);
        //}

        //public Task<gcsEntity> SaveEntityAsync(SaveParameters<gcsEntity> parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.SaveEntityAsync(parameters);
        //}

        //public Task<int> DeleteEntityByPkAsync(DeleteParameters parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.DeleteEntityByPkAsync(parameters);
        //}

        //public Task<int> DeleteEntityAsync(DeleteParameters<gcsEntity> parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.DeleteEntityAsync(parameters);
        //}

        //public Task<bool> IsEntityReferencedAsync(Guid entityId)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.IsEntityReferencedAsync(entityId);
        //}

        //public Task<bool> IsEntityUniqueAsync(gcsEntity entity)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.IsEntityUniqueAsync(entity);
        //}

        //public Task<EntityMapPermissionLevel[]> GetEntityMapPermissionLevelsAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntityMapPermissionLevelsAsync(parameters);
        //}

        //public Task<gcsEntityBasic[]> GetEntityListAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntityListAsync(parameters);
        //}

        //#endregion
        //#endregion
        #region Entity operations
        #region Synchronous operations
        //public gcsEntityEx[] GetAllEntities(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllEntities(parameters);
        //}

        //public gcsEntityEx[] GetAllEntitiesForUser(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllEntitiesForUser(parameters);
        //}

        public ArrayResponse<gcsEntityEx> GetAllEntities(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllEntities(parameters);
        }

        public ArrayResponse<gcsEntityEx> GetAllEntitiesForUser(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllEntitiesForUser(parameters);
        }

        public gcsEntityEx GetEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntity(parameters);
        }

        public gcsEntityEx SaveEntity(SaveParameters<gcsEntity> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveEntity(parameters);
        }

        public BackgroundJobInfo SaveEntityJob(SaveParameters<gcsEntity> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveEntityJob(parameters);
        }

        public int DeleteEntityByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteEntityByPk(parameters);
        }

        public int DeleteEntity(DeleteParameters<gcsEntity> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteEntity(parameters);
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

        public EntityEditingData GetEntityEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityEditingData(parameters);
        }

        public EntityMapPermissionLevel[] GetEntityMapPermissionLevels(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityMapPermissionLevels(parameters);
        }

        //public gcsEntityExBasic[] GetEntityList(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntityList(parameters);
        //}

        //public gcsEntityExBasic[] GetEntityListByName(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntityListByName(parameters);
        //}

        //public gcsEntityEx[] GetEntitiesByName(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntitiesByName(parameters);
        //}

        //public gcsEntityExBasic[] GetEntityListByDescription(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntityListByDescription(parameters);
        //}

        //public gcsEntityEx[] GetEntitiesByDescription(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntitiesByDescription(parameters);
        //}

        //public gcsEntityExBasic[] GetEntityListByNameOrDescription(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntityListByNameOrDescription(parameters);
        //}

        //public gcsEntityEx[] GetEntitiesByNameOrDescription(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetEntitiesByNameOrDescription(parameters);
        //}
        public ArrayResponse<gcsEntityExBasic> GetEntityList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityList(parameters);
        }

        public ArrayResponse<gcsEntityExBasic> GetEntityListForUser(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityListForUser(parameters);
        }

        public ArrayResponse<gcsEntityExBasic> GetEntityListByName(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityListByName(parameters);
        }

        public ArrayResponse<gcsEntityEx> GetEntitiesByName(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntitiesByName(parameters);
        }

        public ArrayResponse<gcsEntityExBasic> GetEntityListByDescription(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityListByDescription(parameters);
        }

        public ArrayResponse<gcsEntityEx> GetEntitiesByDescription(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntitiesByDescription(parameters);
        }

        public ArrayResponse<gcsEntityExBasic> GetEntityListByNameOrDescription(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityListByNameOrDescription(parameters);
        }

        public ArrayResponse<gcsEntityEx> GetEntitiesByNameOrDescription(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntitiesByNameOrDescription(parameters);
        }


        public gcsEntityCounts UpdateCountsForEntity(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UpdateCountsForEntity(entityId);
        }

        #endregion

        #region Async operations
        //public Task<gcsEntityEx[]> GetAllEntitiesAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllEntitiesAsync(parameters);
        //}

        //public Task<gcsEntityEx[]> GetAllEntitiesForUserAsync(GetParametersWithPhoto parameters)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetAllEntitiesForUserAsync(parameters);
        //}
        public Task<ArrayResponse<gcsEntityEx>> GetAllEntitiesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllEntitiesAsync(parameters);
        }

        public Task<ArrayResponse<gcsEntityEx>> GetAllEntitiesForUserAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllEntitiesForUserAsync(parameters);
        }


        public Task<gcsEntityEx> GetEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityAsync(parameters);
        }

        public Task<gcsEntityEx> SaveEntityAsync(SaveParameters<gcsEntity> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveEntityAsync(parameters);
        }

        public Task<BackgroundJobInfo> SaveEntityJobAsync(SaveParameters<gcsEntity> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveEntityJobAsync(parameters);
        }

        public Task<int> DeleteEntityByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteEntityByPkAsync(parameters);
        }

        public Task<int> DeleteEntityAsync(DeleteParameters<gcsEntity> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteEntityAsync(parameters);
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

        public Task<EntityEditingData> GetEntityEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityEditingDataAsync(parameters);
        }

        public Task<EntityMapPermissionLevel[]> GetEntityMapPermissionLevelsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityMapPermissionLevelsAsync(parameters);
        }

        public Task<ArrayResponse<gcsEntityExBasic>> GetEntityListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityListAsync(parameters);
        }

        public Task<ArrayResponse<gcsEntityExBasic>> GetEntityListForUserAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityListForUserAsync(parameters);
        }

        public Task<ArrayResponse<gcsEntityExBasic>> GetEntityListByNameAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityListByNameAsync(parameters);
        }

        public Task<ArrayResponse<gcsEntityEx>> GetEntitiesByNameAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntitiesByNameAsync(parameters);
        }

        public Task<ArrayResponse<gcsEntityExBasic>> GetEntityListByDescriptionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityListByDescriptionAsync(parameters);
        }

        public Task<ArrayResponse<gcsEntityEx>> GetEntitiesByDescriptionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntitiesByDescriptionAsync(parameters);
        }
        public Task<ArrayResponse<gcsEntityExBasic>> GetEntityListByNameOrDescriptionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntityListByNameOrDescriptionAsync(parameters);
        }

        public Task<ArrayResponse<gcsEntityEx>> GetEntitiesByNameOrDescriptionAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetEntitiesByNameOrDescriptionAsync(parameters);
        }

        public Task<gcsEntityCounts> UpdateCountsForEntityAsync(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UpdateCountsForEntityAsync(entityId);
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

        public gcsLanguage SaveLanguage(SaveParameters<gcsLanguage> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveLanguage(parameters);
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

        public Task<gcsLanguage> SaveLanguageAsync(SaveParameters<gcsLanguage> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveLanguageAsync(parameters);
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

        public gcsApplicationBasic[] GetAllApplicationBasic(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            var results = Channel.GetAllApplicationBasic(parameters);
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

        public gcsApplication SaveApplication(SaveParameters<gcsApplication> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveApplication(parameters);
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


        public void SaveApplicationAuditData(SaveParameters<gcsApplicationAudit> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            Channel.SaveApplicationAuditData(parameters);
        }

        #endregion

        #region Async operations
        //public Task<gcsApplication[]> GetAllApplicationsAsync()
        public Task<gcsApplication[]> GetAllApplicationsAsync()

        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllApplicationsAsync();
        }
        public Task<gcsApplicationBasic[]> GetAllApplicationBasicAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllApplicationBasicAsync(parameters);
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

        public Task<gcsApplication> SaveApplicationAsync(SaveParameters<gcsApplication> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveApplicationAsync(parameters);
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

        public Task SaveApplicationAuditDataAsync(SaveParameters<gcsApplicationAudit> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveApplicationAuditDataAsync(parameters);
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

        public gcsApplicationSetting SaveApplicationSetting(SaveParameters<gcsApplicationSetting> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveApplicationSetting(parameters);
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

        public Task<gcsApplicationSetting> SaveApplicationSettingAsync(SaveParameters<gcsApplicationSetting> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveApplicationSettingAsync(parameters);
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

        #region Serialized Object operations

        #region Synchronous operations
        public gcsSerializedObject GetSerializedObject(Guid serializedObjectId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSerializedObject(serializedObjectId);
        }

        public gcsSerializedObject GetSerializedObjectByApplicationIdAndKey(Guid applicationId, string key)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSerializedObjectByApplicationIdAndKey(applicationId, key);
        }

        public gcsSerializedObject SaveSerializedObject(SaveParameters<gcsSerializedObject> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSerializedObject(parameters);
        }

        public int DeleteSerializedObjectByPk(Guid serializedObjectId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSerializedObjectByPk(serializedObjectId);
        }

        #endregion

        #region Async operations

        public Task<gcsSerializedObject> GetSerializedObjectAsync(Guid serializedObjectId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSerializedObjectAsync(serializedObjectId);
        }

        public Task<gcsSerializedObject> GetSerializedObjectByApplicationIdAndKeyAsync(Guid applicationId, string key)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSerializedObjectByApplicationIdAndKeyAsync(applicationId, key);
        }

        public Task<gcsSerializedObject> SaveSerializedObjectAsync(SaveParameters<gcsSerializedObject> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSerializedObjectAsync(parameters);
        }

        public Task<int> DeleteSerializedObjectByPkAsync(Guid serializedObjectId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSerializedObjectByPkAsync(serializedObjectId);
        }



        #endregion
        #endregion

        #region Large Object operations

        #region Synchronous operations
        public gcsLargeObjectStorage GetLargeObject(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetLargeObject(uid);
        }

        public gcsLargeObjectStorage GetLargeObjectByEntityIdAndUniqueTag(Guid entityId, string uniqueTag)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetLargeObjectByEntityIdAndUniqueTag(entityId, uniqueTag);
        }

        public gcsLargeObjectStorage SaveLargeObject(SaveParameters<gcsLargeObjectStorage> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveLargeObject(parameters);
        }

        public int DeleteLargeObjectByPk(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteLargeObjectByPk(uid);
        }

        #endregion

        #region Async operations

        public Task<gcsLargeObjectStorage> GetLargeObjectAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetLargeObjectAsync(uid);
        }

        public Task<gcsLargeObjectStorage> GetLargeObjectByEntityIdAndUniqueTagAsync(Guid entityId, string uniqueTag)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetLargeObjectByEntityIdAndUniqueTagAsync(entityId, uniqueTag);
        }

        public Task<gcsLargeObjectStorage> SaveLargeObjectAsync(SaveParameters<gcsLargeObjectStorage> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveLargeObjectAsync(parameters);
        }

        public Task<int> DeleteLargeObjectByPkAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteLargeObjectByPkAsync(uid);
        }

        #endregion
        #endregion

        #region Role operations
        #region Synchronous operations
        public ArrayResponse<gcsRole> GetAllRoles(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRoles(parameters);
        }

        public ArrayResponse<gcsRole> GetAllRolesForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRolesForEntity(parameters);
        }

        public gcsRole GetRole(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetRole(parameters);
        }

        public gcsRole SaveRole(SaveParameters<gcsRole> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveRole(parameters);
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

        public EntityRoleEditingData GetRoleEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetRoleEditingData(parameters);
        }
        #endregion

        #region Async operations
        public Task<ArrayResponse<gcsRole>> GetAllRolesAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRolesAsync(parameters);
        }

        public Task<ArrayResponse<gcsRole>> GetAllRolesForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllRolesForEntityAsync(parameters);
        }

        public Task<gcsRole> GetRoleAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetRoleAsync(parameters);
        }

        public Task<gcsRole> SaveRoleAsync(SaveParameters<gcsRole> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveRoleAsync(parameters);
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

        public Task<EntityRoleEditingData> GetRoleEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetRoleEditingDataAsync(parameters);
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

        public gcsPermissionCategory SavePermissionCategory(SaveParameters<gcsPermissionCategory> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePermissionCategory(parameters);
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

        public Task<gcsPermissionCategory> SavePermissionCategoryAsync(SaveParameters<gcsPermissionCategory> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePermissionCategoryAsync(parameters);
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

        public gcsPermission SavePermission(SaveParameters<gcsPermission> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePermission(parameters);
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

        public Task<gcsPermission> SavePermissionAsync(SaveParameters<gcsPermission> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePermissionAsync(parameters);
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

        #region Property Sensitivity Level Operations
        #region Synchronous Operations
        public PropertySensitivityLevel[] GetAllPropertySensitivityLevels(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPropertySensitivityLevels(parameters);
        }

        public PropertySensitivityLevel GetPropertySensitivityLevel(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPropertySensitivityLevel(parameters);
        }

        public PropertySensitivityLevel SavePropertySensitivityLevel(SaveParameters<PropertySensitivityLevel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePropertySensitivityLevel(parameters);
        }

        public int DeletePropertySensitivityLevelByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePropertySensitivityLevelByPk(parameters);
        }

        public int DeletePropertySensitivityLevel(DeleteParameters<PropertySensitivityLevel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePropertySensitivityLevel(parameters);
        }

        public bool IsPropertySensitivityLevelReferenced(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPropertySensitivityLevelReferenced(uid);
        }

        public bool IsPropertySensitivityLevelUnique(PropertySensitivityLevel data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPropertySensitivityLevelUnique(data);
        }
        #endregion
        #region Async Operations
        public Task<PropertySensitivityLevel[]> GetAllPropertySensitivityLevelsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllPropertySensitivityLevelsAsync(parameters);
        }

        public Task<PropertySensitivityLevel> GetPropertySensitivityLevelAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetPropertySensitivityLevelAsync(parameters);
        }

        public Task<PropertySensitivityLevel> SavePropertySensitivityLevelAsync(SaveParameters<PropertySensitivityLevel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SavePropertySensitivityLevelAsync(parameters);
        }

        public Task<int> DeletePropertySensitivityLevelByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePropertySensitivityLevelByPkAsync(parameters);
        }

        public Task<int> DeletePropertySensitivityLevelAsync(DeleteParameters<PropertySensitivityLevel> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeletePropertySensitivityLevelAsync(parameters);
        }

        public Task<bool> IsPropertySensitivityLevelReferencedAsync(Guid uid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPropertySensitivityLevelReferencedAsync(uid);
        }

        public Task<bool> IsPropertySensitivityLevelUniqueAsync(PropertySensitivityLevel data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsPropertySensitivityLevelUniqueAsync(data);
        }
        #endregion
        #endregion

        #region User operations
        #region Synchronous operations

        public ArrayResponse<gcsUser> GetAllUsers()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsers();
        }

        public ArrayResponse<gcsUserBasic> GetAllUsersList(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersList(parameters);
        }

        public ArrayResponse<gcsUser> GetAllUsersForApplication(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForApplication(applicationId);
        }

        public ArrayResponse<gcsUser> GetAllUsersForRole(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForRole(roleId);
        }

        public ArrayResponse<gcsUser> GetAllUsersForEntity(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForEntity(parameters);
        }

        //public gcsUser GetUser(Guid userId)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetUser(userId);
        //}
        public gcsUser GetUser(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUser(parameters);
        }

        public gcsUser SaveUser(SaveParameters<gcsUser> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUser(parameters);
        }

        public gcsUser SaveUserSave(SaveParameters<gcsUserSave> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserSave(parameters);
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
        public PasswordValidationInfo ValidatePassword(gcsUser user, bool isEncrypted)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidatePassword(user, isEncrypted);
        }

        public PasswordValidationInfo ValidatePasswordForEntity(gcsUser user, Guid entityGuid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidatePasswordForEntity(user, entityGuid);
        }

        public gcsUserOldPassword[] GetOldPasswordsForUser(gcsUser user, int howMany)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOldPasswordsForUser(user, howMany);
        }

        public gcsUserEditingData GetUserEditingData(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserEditingData(parameters);
        }

        public UserRequestPasswordChangeTokenResponse RequestUserPasswordChangeToken(UserRequestPasswordChangeToken parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.RequestUserPasswordChangeToken(parameters);
        }

        public UpdateUserPasswordResult UpdateUserPassword(UpdateUserPasswordParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UpdateUserPassword(parameters);
        }

        public UserEntityPermissions GetUserPermissions(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserPermissions(parameters);
        }

        #endregion

        #region Async operations
        public Task<ArrayResponse<gcsUser>> GetAllUsersAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersAsync();
        }

        public Task<ArrayResponse<gcsUserBasic>> GetAllUsersListAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersListAsync(parameters);
        }

        public Task<ArrayResponse<gcsUser>> GetAllUsersForApplicationAsync(Guid applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForApplicationAsync(applicationId);
        }

        public Task<ArrayResponse<gcsUser>> GetAllUsersForRoleAsync(Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForRoleAsync(roleId);
        }

        public Task<ArrayResponse<gcsUser>> GetAllUsersForEntityAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUsersForEntityAsync(parameters);
        }

        //public Task<gcsUser> GetUserAsync(Guid userId)
        //{
        //    base.InsertUserDataToOutgoingHeader();
        //    return Channel.GetUserAsync(userId);
        //}

        public Task<gcsUser> GetUserAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserAsync(parameters);
        }

        public Task<gcsUser> SaveUserAsync(SaveParameters<gcsUser> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserAsync(parameters);
        }

        public Task<gcsUser> SaveUserSaveAsync(SaveParameters<gcsUserSave> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserSaveAsync(parameters);
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

        public Task<PasswordValidationInfo> ValidatePasswordAsync(gcsUser user, bool isEncrypted)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidatePasswordAsync(user, isEncrypted);
        }
        public Task<PasswordValidationInfo> ValidatePasswordForEntityAsync(gcsUser user, Guid entityGuid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.ValidatePasswordForEntityAsync(user, entityGuid);
        }

        public Task<gcsUserOldPassword[]> GetOldPasswordsForUserAsync(gcsUser user, int howMany)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetOldPasswordsForUserAsync(user, howMany);
        }

        public Task<gcsUserEditingData> GetUserEditingDataAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserEditingDataAsync(parameters);
        }

        public Task<UserRequestPasswordChangeTokenResponse> RequestUserPasswordChangeTokenAsync(UserRequestPasswordChangeToken parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.RequestUserPasswordChangeTokenAsync(parameters);
        }

        public Task<UpdateUserPasswordResult> UpdateUserPasswordAsync(UpdateUserPasswordParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UpdateUserPasswordAsync(parameters);
        }

        public Task<UserEntityPermissions> GetUserPermissionsAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserPermissionsAsync(parameters);
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

        public gcsUserRequirement SaveUserRequirement(SaveParameters<gcsUserRequirement> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserRequirement(parameters);
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

        public Task<gcsUserRequirement> SaveUserRequirementAsync(SaveParameters<gcsUserRequirement> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserRequirementAsync(parameters);
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

        public gcsUserSetting GetUserSettingFromParams(Guid userId, Guid? applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserSettingFromParams(userId, applicationId, category, settingKey, defaultValue, defaultDescription, bCreateIfNotFound);
        }

        public gcsUserSetting[] GetAllUserSettingsForUser(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUser(userId);
        }

        public gcsUserSetting[] GetAllUserSettingsForUserApplication(Guid userId, Guid? applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUserApplication(userId, applicationId);
        }

        public gcsUserSetting[] GetAllUserSettingsForUserApplicationCategory(Guid userId, Guid? applicationId, string category)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUserApplicationCategory(userId, applicationId, category);
        }

        public gcsUserSetting[] GetAllUserSettingsForApplication(Guid? applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForApplication(applicationId);
        }

        public gcsUserSetting SaveUserSetting(SaveParameters<gcsUserSetting> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserSetting(parameters);
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

        public int DeleteUserSettingFromParams(Guid userId, Guid? applicationId, string category, string settingKey)
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

        public Task<gcsUserSetting> GetUserSettingFromParamsAsync(Guid userId, Guid? applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserSettingFromParamsAsync(userId, applicationId, category, settingKey, defaultValue, defaultDescription, bCreateIfNotFound);
        }

        public Task<gcsUserSetting[]> GetAllUserSettingsForUserAsync(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUserAsync(userId);
        }

        public Task<gcsUserSetting[]> GetAllUserSettingsForUserApplicationAsync(Guid userId, Guid? applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUserApplicationAsync(userId, applicationId);
        }

        public Task<gcsUserSetting[]> GetAllUserSettingsForUserApplicationCategoryAsync(Guid userId, Guid? applicationId, string category)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForUserApplicationCategoryAsync(userId, applicationId, category);
        }

        public Task<gcsUserSetting[]> GetAllUserSettingsForApplicationAsync(Guid? applicationId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetAllUserSettingsForApplicationAsync(applicationId);
        }

        public Task<gcsUserSetting> SaveUserSettingAsync(SaveParameters<gcsUserSetting> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveUserSettingAsync(parameters);
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

        public Task<int> DeleteUserSettingFromParamsAsync(Guid userId, Guid? applicationId, string category, string settingKey)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteUserSettingFromParamsAsync(userId, applicationId, category, settingKey);
        }

        #endregion
        #endregion

        #region gcsSetting Operations
        #region Synchronous operations

        public gcsSetting GetSetting(gcsSetting setting, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSetting(setting, bCreateIfNotFound);
        }

        public gcsSetting GetSettingFromParams(Guid entityId, string group, string subGroup, string key, string defaultValue, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSettingFromParams(entityId, group, subGroup, key, defaultValue, bCreateIfNotFound);
        }

        public gcsSetting[] GetSettingsForEntity(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSettingsForEntity(entityId);
        }

        public gcsSetting[] GetSettingsForEntityAndGroup(Guid entityId, string group)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSettingsForEntityAndGroup(entityId, group);
        }

        public gcsSetting[] GetSettingsForEntityGroupAndSubGroup(Guid entityId, string group, string subGroup)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSettingsForEntityGroupAndSubGroup(entityId, group, subGroup);
        }

        public gcsSetting SaveSetting(SaveParameters<gcsSetting> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSetting(parameters);
        }

        public int DeleteSettingByPk(Guid settingId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSettingByPk(settingId);
        }

        public int DeleteSetting(gcsSetting setting)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSetting(setting);
        }

        public int DeleteSettingFromParams(Guid entityId, string group, string subGroup, string key)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSettingFromParams(entityId, group, subGroup, key);
        }
        #endregion

        #region Async operations

        public Task<gcsSetting> GetSettingAsync(gcsSetting setting, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSettingAsync(setting, bCreateIfNotFound);
        }

        public Task<gcsSetting> GetSettingFromParamsAsync(Guid entityId, string group, string subGroup, string key, string defaultValue, bool bCreateIfNotFound)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSettingFromParamsAsync(entityId, group, subGroup, key, defaultValue, bCreateIfNotFound);
        }

        public Task<gcsSetting[]> GetSettingsForEntityAsync(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSettingsForEntityAsync(entityId);
        }

        public Task<gcsSetting[]> GetSettingsForEntityAndGroupAsync(Guid entityId, string group)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSettingsForEntityAndGroupAsync(entityId, group);
        }

        public Task<gcsSetting[]> GetSettingsForEntityGroupAndSubGroupAsync(Guid entityId, string group, string subGroup)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetSettingsForEntityGroupAndSubGroupAsync(entityId, group, subGroup);
        }

        public Task<gcsSetting> SaveSettingAsync(SaveParameters<gcsSetting> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveSettingAsync(parameters);
        }

        public Task<int> DeleteSettingByPkAsync(Guid settingId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSettingByPkAsync(settingId);
        }

        public Task<int> DeleteSettingAsync(gcsSetting setting)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSettingAsync(setting);
        }

        public Task<int> DeleteSettingFromParamsAsync(Guid entityId, string group, string subGroup, string key)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteSettingFromParamsAsync(entityId, group, subGroup, key);
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

        public Country GetCountryByIso(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCountryByIso(parameters);
        }

        public Country GetCountryByIso3(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCountryByIso3(parameters);
        }

        public Country[] GetCountriesByCountryName(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCountriesByCountryName(parameters);
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

        public Task<Country> GetCountryByIsoAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCountryByIsoAsync(parameters);
        }

        public Task<Country> GetCountryByIso3Async(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCountryByIso3Async(parameters);
        }

        public Task<Country[]> GetCountriesByCountryNameAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetCountriesByCountryNameAsync(parameters);
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

        #region Background Job Operations
        #region Sync Operations
        public BackgroundJobInfo[] GetBackgroundJobs(GetParametersWithPhoto parameters, BackgroundJobState state)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetBackgroundJobs(parameters, state);
        }

        public BackgroundJobInfo GetBackgroundJob(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetBackgroundJob(parameters);
        }

        public int DeleteBackgroundJobByPk(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteBackgroundJobByPk(parameters);
        }

        public BackgroundJobInfo SaveBackgroundJobStateChange(Guid backgroundJobId, BackgroundJobState state, string info)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveBackgroundJobStateChange(backgroundJobId, state, info);
        }
        #endregion

        #region Async Operations

        public Task<BackgroundJobInfo[]> GetBackgroundJobsAsync(GetParametersWithPhoto parameters, BackgroundJobState state)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetBackgroundJobsAsync(parameters, state);
        }

        public Task<BackgroundJobInfo> GetBackgroundJobAsync(GetParametersWithPhoto parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetBackgroundJobAsync(parameters);
        }

        public Task<int> DeleteBackgroundJobByPkAsync(DeleteParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DeleteBackgroundJobByPkAsync(parameters);
        }

        public Task<BackgroundJobInfo> SaveBackgroundJobStateChangeAsync(Guid backgroundJobId, BackgroundJobState state, string info)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SaveBackgroundJobStateChangeAsync(backgroundJobId, state, info);
        }
        #endregion

        #endregion
    }
}
