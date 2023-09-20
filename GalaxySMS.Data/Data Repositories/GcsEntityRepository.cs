using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Config;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Data;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using GCS.Framework.Licensing.Generator;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using GCS.Framework.Caching;
using System.Security.Cryptography;
using StackExchange.Redis;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsEntityRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsEntityRepository : PagedDataRepositoryBase<gcsEntity>, IGcsEntityRepository
    {
        public GcsEntityRepository()
        {
            _binaryResourceRepository = new GcsBinaryResourceRepository();
        }

        private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private ICacheManager _cacheManager;

        protected override gcsEntity AddEntity(gcsEntity entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                EnsureLicenseExists(entity);

                ValidateLicense(entity?.PublicKey, entity?.License);

                if (!IsTimeZoneIdValid(entity.TimeZoneId))
                    entity.TimeZoneId = TimeZoneInfo.Local.Id;

                if (saveParams.SavePhoto)
                    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                // Force the EntityType for the built-in entities
                if (entity.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id)
                    entity.EntityType = EntityTypes.Administrator;
                else if (entity.EntityId == EntityIds.GalaxySMS_SystemEntity_Id)
                    entity.EntityType = EntityTypes.Reserved;

                entity.AutoMapTimeSchedules = true; // hardcode this on for all new entities

                if( string.IsNullOrEmpty(entity.TimeZoneId))
                    entity.TimeZoneId = TimeZoneInfo.Local.Id;

                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //var excludeCollections = new List<KeyValuePair<string, bool>>();
                    //excludeCollections.Add(new KeyValuePair<string, bool>(nameof(gcsRolePermission), true));
                    //excludeCollections.Add(new KeyValuePair<string, bool>(nameof(gcsPermissionCategory), true));
                    var excludeCollections = new List<string>();
                    excludeCollections.Add(nameof(gcsRolePermission));
                    excludeCollections.Add(nameof(gcsPermissionCategory));
                    var result = GetEntityByGuidId(entity.EntityId, sessionData, new GetParametersWithPhoto()
                    {
                        RefreshCache = true,
                        IncludeMemberCollections = true,
                        ExcludeMemberCollectionSettings = excludeCollections.ToCollection()
                    });
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::AddEntity", ex);
                throw;
            }
        }

        private bool IsTimeZoneIdValid(string tzId)
        {
            var tzRepo = _dataRepositoryFactory.GetDataRepository<ITimeZoneRepository>();
            return tzRepo.DoesTimeZoneIdExist(tzId);
        }

        protected override gcsEntity UpdateEntity(gcsEntity entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.EntityId, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false });

                if (string.IsNullOrEmpty(entity.PublicKey))
                    entity.PublicKey = originalEntity.PublicKey;

                if (string.IsNullOrEmpty(entity.License))
                    entity.License = originalEntity.License;

                if (string.IsNullOrEmpty(entity.InsertName))
                    entity.InsertName = originalEntity.InsertName;

                if (entity.InsertDate < DateTimeOffset.Now.MinSqlDateTime())
                    entity.InsertDate = originalEntity.InsertDate;

                if (entity.ConcurrencyValue == 0)
                    entity.ConcurrencyValue = originalEntity.ConcurrencyValue;

                entity.EntityType = originalEntity.EntityType;
                entity.ClusterGroupId = originalEntity.ClusterGroupId;

                if (string.IsNullOrEmpty(entity.TimeZoneId))
                    entity.TimeZoneId = originalEntity.TimeZoneId;

                if (!IsTimeZoneIdValid(entity.TimeZoneId))
                    entity.TimeZoneId = TimeZoneInfo.Local.Id;

                EnsureLicenseExists(entity);

                ValidateLicense(entity?.PublicKey, entity?.License);

                if (saveParams.SavePhoto && entity.gcsBinaryResource?.HasBeenModified == true)
                    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.EntityId) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    if (entity.BinaryResourceUid == null || entity.BinaryResourceUid == Guid.Empty)
                        entity.BinaryResourceUid = mgr.Entity.BinaryResourceUid;

                    // Force the EntityType for the built-in entities
                    if (entity.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id)
                        entity.EntityType = EntityTypes.Administrator;
                    else if (entity.EntityId == EntityIds.GalaxySMS_SystemEntity_Id)
                        entity.EntityType = EntityTypes.Reserved;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        //var excludeCollections = new List<KeyValuePair<string, bool>>();
                        //excludeCollections.Add(new KeyValuePair<string, bool>(nameof(gcsRolePermission), true));
                        //excludeCollections.Add(new KeyValuePair<string, bool>(nameof(gcsPermissionCategory), true));
                        var excludeCollections = new List<string>
                        {
                            nameof(gcsRolePermission),
                            nameof(gcsPermissionCategory)
                        };

                        var updatedEntity = GetEntityByGuidId(entity.EntityId, sessionData, new GetParametersWithPhoto()
                        {
                            RefreshCache = true,
                            IncludeMemberCollections = saveParams.IncludeMemberCollections,
                            ExcludeMemberCollectionSettings = excludeCollections.ToCollection()
                        });
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.EntityId} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::UpdateEntity", ex);
                throw;
            }
        }

        private static void EnsureLicenseExists(gcsEntity entity)
        {
            if (string.IsNullOrEmpty(entity?.License))
            {
                var entityLicenseRequest = new GenerateLicenseRequestData()
                {
                    CustomerName = entity.EntityName,
                    //EmailAddress = entity.,
                    LicenseType = Portable.Licensing.Prime.LicenseType.Standard,
                    //ExpiresAt = DateTimeOffset.Now.AddDays(DefaultTrialLicenseValues.ValidForDays),
                    //MaximumUtilizations = 5,
                };
                entityLicenseRequest.Features.Add(EntityLicenseFeatureKey.BadgingSystemType.ToString(), GalaxySMS.Common.Enums.BadgeSystemType.None.ToString());
                entityLicenseRequest.Features.Add(EntityLicenseFeatureKey.BiometricSystemType.ToString(), GalaxySMS.Common.Enums.BiometricSystemType.None.ToString());

                //trialLicenseRequest.Features.Add(LicensedFeatureKey.ProductLevel.ToString(), ProductLevel.Enterprise.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.Version.ToString(), GCS.Framework.Utilities.SystemUtilities.ExecutingAssembly.GetName().Version.Major.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.MaximumClients.ToString(), DefaultTrialLicenseValues.MaximumClients.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.MaximumAccessPortals.ToString(), DefaultTrialLicenseValues.MaximumAccessPortals.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.MaximumDsiAccessPortals.ToString(), DefaultTrialLicenseValues.MaximumDsiAccessPortals.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.MaximumInputDevices.ToString(), DefaultTrialLicenseValues.MaximumInputDevices.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.CanUpgradeVersions.ToString(), DefaultTrialLicenseValues.CanUpgradeVersions.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.GalaxyVms.ToString(), DefaultTrialLicenseValues.GalaxyVms.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.VmsApi.ToString(), DefaultTrialLicenseValues.VmsApi.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.VmsSystemLimit.ToString(), DefaultTrialLicenseValues.VmsSystemLimit.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.TimeAttendance.ToString(), DefaultTrialLicenseValues.TimeAttendance.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.ImportExport.ToString(), DefaultTrialLicenseValues.ImportExport.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.EventLogDistribution.ToString(), DefaultTrialLicenseValues.EventLogDistribution.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.UserStatus.ToString(), DefaultTrialLicenseValues.UserStatus.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.GuardTour.ToString(), DefaultTrialLicenseValues.GuardTour.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.AlarmPanelIntegration.ToString(), DefaultTrialLicenseValues.AlarmPanelIntegration.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.PassbackDoorGroups.ToString(), DefaultTrialLicenseValues.PassbackDoorGroups.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.GraphicDeviceStatus.ToString(), DefaultTrialLicenseValues.GraphicDeviceStatus.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.UnlimitedCredentialCapability.ToString(), DefaultTrialLicenseValues.UnlimitedCredentialCapability.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.AccessRuleOverride.ToString(), DefaultTrialLicenseValues.AccessRuleOverride.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.ApiAccess.ToString(), DefaultTrialLicenseValues.ApiAccess.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.ApiCanGetPersonData.ToString(), DefaultTrialLicenseValues.ApiCanGetPersonData.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.ApiCanPostPersonData.ToString(), DefaultTrialLicenseValues.ApiCanPostPersonData.ToString());
                //trialLicenseRequest.Features.Add(LicensedFeatureKey.ApiCanDeletePersonData.ToString(), DefaultTrialLicenseValues.ApiCanDeletePersonData.ToString());
                entityLicenseRequest.Attributes.Add(EntityLicenseAttributeKey.Attribute1.ToString(), false.ToString());
                var l = LicenseGenerator.GenerateLicense(entityLicenseRequest);

                entity.License = l.ToString();
                entity.PublicKey = l.PublicKey;
            }
        }

        private void ValidateLicense(string publicKey, string license)
        {
            LicenseGenerator.ValidateLicense(publicKey, license, Properties.Resources.ExceptionMessage_LicenseKeyInvalid, Properties.Resources.ExceptionMessage_LicenseInvalid);
            //if (string.IsNullOrEmpty(license) == false)
            //{
            //    if (string.IsNullOrEmpty(publicKey))
            //        throw new ApplicationException(Properties.Resources.ExceptionMessage_LicenseKeyInvalid);
            //    var licenseData = new LicenseData();
            //    if (licenseData.InitializeFromXmlString(publicKey, license) == false)
            //    {
            //        var validationMessages = new StringBuilder();
            //        foreach (var validationError in licenseData.LicenseValidationFailures)
            //        {
            //            validationMessages.Append(validationError.Message);
            //            validationMessages.Append(validationError.HowToResolve);
            //        }
            //        var innerEx = new ApplicationException(validationMessages.ToString());
            //        var ex = new ApplicationException(Properties.Resources.ExceptionMessage_LicenseInvalid, innerEx);
            //        throw ex;
            //    }
            //}
        }

        protected override int DeleteEntity(gcsEntity entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.EntityId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);

                    if (_cacheManager?.IsInitialized == true)
                    {
                        var cacheKey = GetItemCacheKey(entity.EntityId);
                        var deleted = _cacheManager.DeleteCachedItem(cacheKey);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false });
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();

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

                        if (_cacheManager?.IsInitialized == true)
                        {
                            var cacheKey = GetItemCacheKey(id);
                            var deleted = _cacheManager.DeleteCachedItem(cacheKey);
                        }
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::Remove", ex);
                throw;
            }
        }

        public int DeleteEntity(Guid entityId, IApplicationUserSessionDataHeader sessionData, IDeleteParameters deleteParams)
        {
            try
            {
                var autoDeleteRegions = deleteParams.OptionValue<bool>(DeleteOptions_Entity.AutoDeleteRegions);
                var autoDeleteSites = deleteParams.OptionValue<bool>(DeleteOptions_Entity.AutoDeleteSites);

                if (autoDeleteSites)
                {
                    var mgr = new gcsEntity_DeleteSitesPDSAManager
                    {
                        Entity =
                        {
                            EntityId = entityId
                        }
                    };
                    mgr.Execute();
                }

                if (autoDeleteRegions)
                {
                    var mgr = new gcsEntity_DeleteRegionsPDSAManager
                    {
                        Entity =
                        {
                            EntityId = entityId
                        }
                    };
                    mgr.Execute();
                }

                return Remove(entityId, sessionData);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::Remove", ex);
                throw;
            }
        }

        public string GetEntityName(Guid entityId)
        {
            try
            {
                try
                {
                    var mgr = new gcsEntityPDSA_SelectNameByPKPDSAManager();
                    mgr.Entity.EntityId = entityId;
                    var results = mgr.BuildCollection();
                    if (results != null && results.Count == 1)
                    {
                        return results[0].EntityName;
                    }

                    return string.Empty;
                }
                catch (Exception ex)
                {
                    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::Remove", ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsEntity> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();


                if (getParameters?.Options?.Count > 0)
                {
                    var buildAsTree = getParameters.Options.FirstOrDefault(o => o.Key == GetOptions.BuildTreeStructure);
                    if (buildAsTree.Value == true)
                    {
                        mgr.DataObject.SelectFilter = DataLayer.gcsEntityPDSAData.SelectFilters.AllTopLevelEntities;
                    }
                }

                SetSortColumnAndOrder(getParameters, mgr);

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    bool activeOnly = false;

                    if (getParameters != null)
                    {
                        if (getParameters.Options != null)
                        {
                            var kvp = getParameters.Options.FirstOrDefault(o => o.Key == GetOptions.IncludeActiveOnly);
                            activeOnly = kvp.Value;
                        }
                    }

                    var temp = mgr.ConvertPDSACollection(pdsaEntities);
                    var entities = new List<gcsEntity>();
                    foreach (gcsEntity entity in temp)
                    {
                        if (activeOnly && !entity.IsActive)
                            continue;
                        entities.Add(entity);
                        FillMemberCollections(entity, sessionData, getParameters);
                    }
                    if (getParameters != null && getParameters.DescendingOrder)
                        return entities.OrderByDescending(o => o.EntityName).ToList();
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntities", ex);
                throw;
            }
        }

        private void SetSortColumnAndOrder(IGetParametersWithPhoto getParameters, gcsEntityPDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<EntitySortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }

        protected override IEnumerable<gcsEntity> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override IArrayResponse<gcsEntity> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                bool activeOnly = false;

                if (getParameters?.Options?.Count > 0)
                {
                    var buildAsTree = getParameters.Options.FirstOrDefault(o => o.Key == GetOptions.BuildTreeStructure);
                    if (buildAsTree.Value)
                    {
                        mgr.DataObject.SelectFilter = DataLayer.gcsEntityPDSAData.SelectFilters.AllTopLevelEntities;
                    }
                    var kvp = getParameters.Options.FirstOrDefault(o => o.Key == GetOptions.IncludeActiveOnly);
                    activeOnly = kvp.Value;

                }

                mgr.Entity.ActiveOnly = activeOnly;

                SetSortColumnAndOrder(getParameters, mgr);

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null && getParameters?.Options != null)
                {

                    var temp = mgr.ConvertPDSACollection(pdsaEntities);
                    var entities = new List<gcsEntity>();
                    var totalRowCount = 0;
                    foreach (gcsEntity entity in temp)
                    {
                        if (totalRowCount == 0)
                            totalRowCount = entity.TotalRowCount;
                        //if (activeOnly && !entity.IsActive)
                        //{
                        //    continue;
                        //}
                        entities.Add(entity);
                        FillMemberCollections(entity, sessionData, getParameters);
                    }

                    //if (getParameters.DescendingOrder)
                    //    return ArrayResponseHelpers.ToArrayResponse(entities.OrderByDescending(o => o.EntityName),
                    //        getParameters.PageNumber, getParameters.PageSize, totalRowCount);

                    return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalRowCount);
                    ;
                }
                return new ArrayResponse<gcsEntity>();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<gcsEntity> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }


        protected override gcsEntity GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        private string GetItemCacheKey(Guid uid)
        {
            return CacheHelpers.GetCacheKey(typeof(gcsEntity), uid, false);
        }

        protected override gcsEntity GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                if (guid == Guid.Empty)
                    guid = sessionData.CurrentEntityId;

                gcsEntity result = null;
                var cacheKey = GetItemCacheKey(guid);
                if (CacheHelpers.ShouldReadFromCache(_cacheManager, getParameters))
                {
                    result = _cacheManager.GetCachedItem<gcsEntity>(cacheKey);
                }

                if (result == null)
                {
                    gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                    var count = mgr.DataObject.LoadByPK(guid);
                    if (count == 1)
                    {
                        result = new gcsEntity();
                        SimpleMapper.PropertyMap(mgr.Entity, result);

                        if (CacheHelpers.ShouldCacheBeUpdated(_cacheManager, getParameters))
                        {
                            var bCached = _cacheManager.SetCachedItem(cacheKey, result);
                        }
                    }
                }

                if (result != null && result.EntityId == guid)
                {
                    FillMemberCollections(result, sessionData, getParameters);
                    result.IsAuthorized = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsEntity originalEntity, gcsEntity newEntity, string auditXml)
        {
            try
            {
                if (!string.IsNullOrEmpty(auditXml))
                    auditXml = auditXml.EncodeForXml(); if (!string.IsNullOrEmpty(auditXml))
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
                        propertiesToIgnore.Add("AllApplications");
                        propertiesToIgnore.Add("ChildEntities");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        propertiesToIgnore.Add("EntityApplications");
                        propertiesToIgnore.Add("UserRequirements");
                        propertiesToIgnore.Add("UserEntities");
                        propertiesToIgnore.Add("EntityApplications");
                        propertiesToIgnore.Add("gcsBinaryResource");
                        propertiesToIgnore.Add("ParentEntity");
                        propertiesToIgnore.Add("ParentEntityName");
                        propertiesToIgnore.Add("TheLicense");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "EntityId";
                        mgr.Entity.PrimaryKeyValue = newEntity.EntityId;
                        mgr.Entity.RecordTag = newEntity.EntityName;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        if (string.IsNullOrEmpty(auditXml) == false)
                        {// This must be commented out because the License xml data is not clean XML. An exception will be thrown when trying to insert auditXml that contains license data
                            //mgr.Entity.AuditXml = auditXml;
                            //mgr.Execute();
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
                        mgr.Entity.PrimaryKeyColumn = "EntityId";
                        mgr.Entity.PrimaryKeyValue = newEntity.EntityId;
                        mgr.Entity.RecordTag = newEntity.EntityName;
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
                        mgr.Entity.PrimaryKeyColumn = "EntityId";
                        mgr.Entity.PrimaryKeyValue = originalEntity.EntityId;
                        mgr.Entity.RecordTag = originalEntity.EntityName;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsEntity entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (!string.IsNullOrEmpty(entity.License))
            {
                if (getParameters == null || !getParameters.IsExcluded(nameof(entity.TheLicense)))
                    entity.TheLicense = GCS.Core.Common.Utils.XmlUtilities.ConvertXmlStringtoObject<License>(entity.License);
            }

            if (getParameters == null)
                return;

            if (getParameters.IncludePhoto == true && entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            {
                entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, getParameters);
            }

            if (getParameters.IsExcluded(nameof(entity.TheLicense)))
            {
                entity.License = string.Empty;
                entity.TheLicense = null;
                entity.PublicKey = String.Empty;
            }

            var includeRegionSiteHierachy = false;
            var includeRegionSiteHierachyOption = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeRegionSiteHierachy);
            if (includeRegionSiteHierachyOption.HasValue)
                includeRegionSiteHierachy = includeRegionSiteHierachyOption.Value;

            if (includeRegionSiteHierachy)
            {
                var regionRepository = _dataRepositoryFactory.GetDataRepository<IRegionRepository>();

                var regions = regionRepository.GetAllRegionSelectionItemsForEntity(sessionData, new GetParametersWithPhoto(getParameters)
                {
                    IncludeMemberCollections = true,// Required for sites to be included
                    UniqueId = entity.EntityId,
                    CurrentEntityId = entity.EntityId,
                });

                foreach (var r in regions)
                {
                    entity.Regions.Add(new RegionListItem(r));
                }
            }

            if (getParameters.IncludeMemberCollections == false)
            {
                entity.UserRequirements = null;
                return;
            }

            //var excludeAllApplications = getParameters.IsExcluded(nameof(entity.AllApplications));
            var excludeUserRequirements = getParameters.IsExcluded(nameof(entity.UserRequirements));
            //var excludegcsEntityApplications = getParameters.IsExcluded(nameof(entity.gcsEntityApplications));
            var excludeParentEntity = getParameters.IsExcluded(nameof(entity.ParentEntity));
            var excludeChildEntities = getParameters.IsExcluded(nameof(entity.ChildEntities));
            var excludeSettings = getParameters.IsExcluded(nameof(entity.Settings));
            var excludeRoles = getParameters.IsExcluded(nameof(entity.AllRoles));

            var excludeNotAuthorizedRoles = getParameters.GetOption(GetOptions_UserEditorData.ExcludeNotAuthorizedRoles);
            var excludeNotAuthorizedApplications = getParameters.GetOption(GetOptions_UserEditorData.ExcludeNotAuthorizedApplications);

            //if (excludeUserRequirements.Value == false)
            if (excludeUserRequirements == false)
            {
                var userRequirementsRepository = new GcsUserRequirementsRepository();

                var userReqs = userRequirementsRepository.GetByEntityId(entity.EntityId);
                if (userReqs == null)
                {
                    userReqs = new gcsUserRequirement()
                    {
                        PasswordCannotContainName = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordCannotContainName", true, true),
                        UseCustomRegEx = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordUseCustomRegEx", false, true),
                        PasswordCustomRegEx = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordCustomRegEx", string.Empty, true),
                        PasswordMinimumLength = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordMinimumLength", 1, true),
                        PasswordMaximumLength = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordMaximumLength", 15, true),
                        PasswordMinimumChangeCharacters = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "PasswordMinimumChangeCharacters", 1, true),
                        MaintainPasswordHistoryCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "MaintainPasswordHistoryCount", 3, true),
                        AllowPasswordChangeAttempt = ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "AllowPasswordChangeAttempt", true, true),
                        MinimumPasswordAge = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "MinimumPasswordAge", 0, true),
                        MaximumPasswordAge = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "MaximumPasswordAge", 0, true),
                        DefaultExpirationDays = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "DefaultExpirationDays", 0, true),
                        LockoutUserIfInactiveForDays = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "LockoutUserIfInactiveForDays", 14, true),
                        RequireLowerCaseLetterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireLowerCaseLetterCount", 0, true),
                        RequireNumericDigitCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireNumericDigitCount", 0, true),
                        RequireSpecialCharacterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireSpecialCharacterCount", 0, true),
                        RequireUpperCaseLetterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "RequireUpperCaseLetterCount", 0, true),
                        RegularExpressionDescription = string.Empty
                    };
                }
                entity.UserRequirements = userReqs;
            }
            else
            {
                entity.UserRequirements = null;
            }

            if (!excludeRoles)
            {
                var roleRepository = _dataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

                entity.AllRoles = roleRepository.GetAllRolesForEntity(entity.EntityId, getParameters).ToCollection();
            }

            if (entity.ParentEntityId != null && entity.ParentEntityId != Guid.Empty && !getParameters.IsExcluded(nameof(entity.ParentEntity)))
            {
                entity.ParentEntity = GetEntityByGuidId(entity.ParentEntityId.Value, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false });
            }

            //if (excludeChildEntities.Value == false)
            if (excludeChildEntities == false)
            {
                entity.ChildEntities = GetChildEntitiesForParent(entity.EntityId, sessionData, getParameters).ToCollection();
            }

            if (excludeSettings == false)
            {
                var settingsRepo = new GcsSettingRepository();
                entity.Settings = settingsRepo.GetAllForEntity(entity.EntityId).ToCollection();
            }
        }

        protected override bool IsEntityReferenced(Guid entityId)
        {

            int roleEntityCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("gcsRoleEntity", "EntityId", entityId);
            int userPrimaryEntityCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("gcsUser", "PrimaryEntityId",
                entityId);
            int userEntityCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("gcsUserEntity", "EntityId", entityId);
            int userRequirementsEntityCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("gcsUserRequirements",
                "EntityId", entityId);

            if (userRequirementsEntityCount != 0 ||
                userEntityCount != 0 ||
                userPrimaryEntityCount != 0 ||
                roleEntityCount != 0)
                return true;

            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsEntity", "EntityId", entityId);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid entityId)
        {
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsEntity", "EntityId", entityId);
            if (count != 0)
                return false;

            var mgr = new gcsEntity_CanBeDeletedPDSAManager();
            mgr.Entity.EntityId = entityId;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 1)
                return true;
            return false;

        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsEntity entity)
        {
            gcs_IsEntityUniquePDSAManager mgr = new gcs_IsEntityUniquePDSAManager();
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.EntityName = entity.EntityName;
            if (entity.ParentEntityId.HasValue)
                mgr.Entity.ParentEntityId = entity.ParentEntityId.Value;
            else
                mgr.Entity.ParentEntityId = Guid.Empty;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsEntity", "EntityId", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }

        public RowReferenceResult[] GetReferencingRows(Guid entityId)
        {
            return null;
        }

        public IEnumerable<gcsEntity> GetEntitiesForUser(Guid userId, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var entities = new List<gcsEntity>();
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                mgr.DataObject.SelectFilter = gcsEntityPDSAData.SelectFilters.AllForUser;
                mgr.Entity.UserId = userId;
                mgr.Entity.SearchText = getParameters.GetString;

                //var selectMgr = new gcs_SelectEntitiesByUserIdPDSAManager();
                //selectMgr.Entity.UserId = userId;
                var data = mgr.BuildCollection();
                foreach (var e in data)
                {
                    var entity = this.Get(e.EntityId, sessionData, getParameters);
                    if (entity != null && entity.gcsBinaryResource != null)
                    {
                        if (entity.gcsBinaryResource.BinaryResource != null)
                        {
                            var img = GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.gcsBinaryResource.BinaryResource);
                            var scaledImg = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageWithAspectRatio(img, 200, 0);
                            entity.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImg);
                        }
                    }
                    entities.Add(entity);
                }

                if (getParameters?.Options?.Count > 0)
                {
                    var buildAsTree = getParameters.Options.Where(o => o.Key == GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure).FirstOrDefault();
                    if (buildAsTree.Value == true)
                    {
                        var tempEntities = entities.ToList();
                        // Get all the top level items
                        entities = tempEntities.Where(o => o.ParentEntityId.Value == Guid.Empty).ToList();
                        // Remove them from the temp collection
                        foreach (var e in entities)
                        {
                            e.ChildEntities = FillRecursive(tempEntities, e.EntityId);
                        }

                    }
                }

                if (getParameters.DescendingOrder)
                    return entities.OrderByDescending(o => o.EntityName).ToList();

                return entities;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntitiesForUser", ex);
                throw;
            }
        }

        public IArrayResponse<gcsEntity> GetEntitiesForUserPaged(Guid userId, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var entities = new List<gcsEntity>();
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager
                {
                    DataObject =
                    {
                        SelectFilter = gcsEntityPDSAData.SelectFilters.AllForUser
                    },
                    Entity =
                    {
                        UserId = userId,
                        ParentEntityId = getParameters.GetGuid,
                        SearchText = getParameters.GetString
                    }
                };

                SetSortColumnAndOrder(getParameters, mgr);

                var ignoreCurrent = getParameters.GetOption(GetOptions_Entity.IgnoreCurrentEntity);
                if (ignoreCurrent.HasValue && ignoreCurrent.Value == true)
                {
                    mgr.Entity.IgnoreEntityId = sessionData.CurrentEntityId;
                }

                var data = mgr.BuildCollection();
                var totalItemCount = 0;
                foreach (var e in data)
                {
                    if (totalItemCount == 0)
                        totalItemCount = e.TotalRowCount;
                    var entity = this.Get(e.EntityId, sessionData, getParameters);
                    if (entity != null && entity.gcsBinaryResource != null)
                    {
                        if (entity.gcsBinaryResource.BinaryResource != null)
                        {
                            var img = GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.gcsBinaryResource.BinaryResource);
                            var scaledImg = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageWithAspectRatio(img, 200, 0);
                            entity.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImg);
                        }
                    }


                    entities.Add(entity);
                }

                if (getParameters?.Options?.Count > 0)
                {
                    var buildAsTree = getParameters.Options.Where(o => o.Key == GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure).FirstOrDefault();
                    if (buildAsTree.Value)
                    {
                        var tempEntities = entities.ToList();
                        if (getParameters.GetGuid == Guid.Empty)
                        {
                            // Get all the top level items
                            entities = tempEntities.Where(o => o.ParentEntityId.Value == Guid.Empty).ToList();
                            // Remove them from the temp collection
                            foreach (var e in entities)
                            {
                                e.ChildEntities = FillRecursive(tempEntities, e.EntityId);
                            }
                        }
                        else
                        {
                            // Get all the top level items
                            entities = tempEntities.Where(o => o.ParentEntityId.Value == getParameters.GetGuid).ToList();
                            // Remove them from the temp collection
                            foreach (var e in entities)
                            {
                                var childEntities = GetEntitiesForUser(userId, sessionData, new GetParametersWithPhoto()
                                {
                                    GetGuid = e.EntityId
                                });
                                e.ChildEntities = FillRecursive(childEntities.ToList(), e.EntityId);
                            }
                        }
                    }
                }

                //if (getParameters.DescendingOrder)
                //    return ArrayResponseHelpers.ToArrayResponse(entities.OrderByDescending(o => o.EntityName), getParameters.PageNumber, getParameters.PageNumber, totalItemCount);

                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalItemCount);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntitiesForUser", ex);
                throw;
            }

        }

        public IEnumerable<gcsEntity> GetByName(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var entities = new List<gcsEntity>();
                var mgr = new gcsEntityPDSAManager();
                mgr.DataObject.SelectFilter = gcsEntityPDSAData.SelectFilters.Search;
                mgr.Entity.EntityName = getParameters.GetString;

                SetSortColumnAndOrder(getParameters, mgr);

                var data = mgr.BuildCollection();
                foreach (var e in data)
                {
                    var entity = this.Get(e.EntityId, sessionData, getParameters);
                    if (entity != null && entity.gcsBinaryResource != null)
                    {
                        if (entity.gcsBinaryResource.BinaryResource != null)
                        {
                            var img = GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.gcsBinaryResource.BinaryResource);
                            var scaledImg = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageWithAspectRatio(img, 200, 0);
                            entity.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImg);
                        }
                    }
                    entities.Add(entity);
                }

                if (getParameters?.Options?.Count > 0)
                {
                    var buildAsTree = getParameters.Options.Where(o => o.Key == GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure).FirstOrDefault();
                    if (buildAsTree.Value == true)
                    {
                        var tempEntities = entities.ToList();
                        // Get all the top level items
                        entities = tempEntities.Where(o => o.ParentEntityId.Value == Guid.Empty).ToList();
                        // Remove them from the temp collection
                        foreach (var e in entities)
                        {
                            e.ChildEntities = FillRecursive(tempEntities, e.EntityId);
                        }

                    }
                }

                if (getParameters.DescendingOrder)
                    return entities.OrderByDescending(o => o.EntityName).ToList();
                return entities;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntitiesForUser", ex);
                throw;
            }
        }

        public IArrayResponse<gcsEntity> GetByNamePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var data = GetByName(sessionData, getParameters);
            return ArrayResponseHelpers.ToArrayResponse(data, getParameters.PageNumber, getParameters.PageSize,
                data.Count());
        }

        public IEnumerable<gcsEntity> GetByDescription(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var entities = new List<gcsEntity>();
                var mgr = new gcsEntityPDSAManager();
                mgr.DataObject.SelectFilter = gcsEntityPDSAData.SelectFilters.ByDescription;
                mgr.Entity.EntityDescription = getParameters.GetString;

                SetSortColumnAndOrder(getParameters, mgr);

                var data = mgr.BuildCollection();
                foreach (var e in data)
                {
                    var entity = this.Get(e.EntityId, sessionData, getParameters);
                    if (entity != null && entity.gcsBinaryResource != null)
                    {
                        if (entity.gcsBinaryResource.BinaryResource != null)
                        {
                            var img = GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.gcsBinaryResource.BinaryResource);
                            var scaledImg = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageWithAspectRatio(img, 200, 0);
                            entity.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImg);
                        }
                    }
                    entities.Add(entity);
                }

                if (getParameters?.Options?.Count > 0)
                {
                    var buildAsTree = getParameters.Options.Where(o => o.Key == GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure).FirstOrDefault();
                    if (buildAsTree.Value == true)
                    {
                        var tempEntities = entities.ToList();
                        // Get all the top level items
                        entities = tempEntities.Where(o => o.ParentEntityId.Value == Guid.Empty).ToList();
                        // Remove them from the temp collection
                        foreach (var e in entities)
                        {
                            e.ChildEntities = FillRecursive(tempEntities, e.EntityId);
                        }

                    }
                }

                if (getParameters.DescendingOrder)
                    return entities.OrderByDescending(o => o.EntityName).ToList();
                return entities;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntitiesForUser", ex);
                throw;
            }
        }

        public IArrayResponse<gcsEntity> GetByDescriptionPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var data = GetByDescription(sessionData, getParameters);
            return ArrayResponseHelpers.ToArrayResponse(data, getParameters.PageNumber, getParameters.PageSize,
                data.Count());

        }

        public IEnumerable<gcsEntity> GetByNameOrDescription(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var entities = new List<gcsEntity>();
                var mgr = new gcsEntityPDSAManager();
                mgr.DataObject.SelectFilter = gcsEntityPDSAData.SelectFilters.SearchNameDesc;
                mgr.Entity.SearchText = getParameters.GetString;

                var data = mgr.BuildCollection();
                foreach (var e in data)
                {
                    var entity = this.Get(e.EntityId, sessionData, getParameters);
                    if (entity != null && entity.gcsBinaryResource != null)
                    {
                        if (entity.gcsBinaryResource.BinaryResource != null)
                        {
                            var img = GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.gcsBinaryResource.BinaryResource);
                            var scaledImg = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageWithAspectRatio(img, 200, 0);
                            entity.gcsBinaryResource.BinaryResource = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImg);
                        }
                    }
                    entities.Add(entity);
                }

                if (getParameters?.Options?.Count > 0)
                {
                    var buildAsTree = getParameters.Options.Where(o => o.Key == GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure).FirstOrDefault();
                    if (buildAsTree.Value == true)
                    {
                        var tempEntities = entities.ToList();
                        // Get all the top level items
                        entities = tempEntities.Where(o => o.ParentEntityId.Value == Guid.Empty).ToList();
                        // Remove them from the temp collection
                        foreach (var e in entities)
                        {
                            e.ChildEntities = FillRecursive(tempEntities, e.EntityId);
                        }
                    }
                }

                if (getParameters.DescendingOrder)
                    return entities.OrderByDescending(o => o.EntityName).ToList();
                return entities;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntitiesForUser", ex);
                throw;
            }
        }

        public IArrayResponse<gcsEntity> GetByNameOrDescriptionPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            var data = GetByNameOrDescription(sessionData, getParameters);
            return ArrayResponseHelpers.ToArrayResponse(data, getParameters.PageNumber, getParameters.PageSize, data.Count());
        }

        private static List<gcsEntity> FillRecursive(List<gcsEntity> flatCollection, Guid? parentId)
        {
            List<gcsEntity> recursiveObjects = new List<gcsEntity>();

            foreach (var item in flatCollection.Where(x => x.ParentEntityId.Equals(parentId)))
            {
                item.ChildEntities = FillRecursive(flatCollection, item.EntityId);
                recursiveObjects.Add(item);
            }

            return recursiveObjects;
        }

        public IEnumerable<gcsEntity> GetChildEntitiesForParent(Guid parentId, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                mgr.DataObject.SelectFilter = DataLayer.gcsEntityPDSAData.SelectFilters.ByParentEntityId;

                SetSortColumnAndOrder(getParameters, mgr);
                mgr.Entity.ParentEntityId = parentId;

                bool activeOnly = false;
                var kvp = getParameters.Options.FirstOrDefault(o => o.Key == GetOptions.IncludeActiveOnly);
                activeOnly = kvp.Value;
                mgr.Entity.ActiveOnly = activeOnly;

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var temp = mgr.ConvertPDSACollection(pdsaEntities);

                    var entities = new List<gcsEntity>();
                    foreach (gcsEntity entity in temp)
                    {
                        if (activeOnly && !entity.IsActive)
                            continue;

                        entities.Add(entity);
                        FillMemberCollections(entity, sessionData, getParameters);
                    }
                    if (getParameters.DescendingOrder)
                        return entities.OrderByDescending(o => o.EntityName).ToList();
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetChildEntitiesForParent", ex);
                throw;
            }
        }

        public IEnumerable<gcsEntity> GetEntityHierarchy(Guid toplevelEntityId, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new gcsEntity_GetEntityWithChildrenPDSAManager();
                mgr.Entity.EntityId = toplevelEntityId;

                //bool activeOnly = false;
                //var kvp = getParameters.Options.FirstOrDefault(o => o.Key == GetOptions.IncludeActiveOnly);
                //activeOnly = kvp.Value;
                //mgr.Entity.ActiveOnly = activeOnly;

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var results = new List<gcsEntity>();
                    foreach (var pdsaEntity in pdsaEntities)
                    {
                        var convertedEntity = new gcsEntity();
                        SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                        results.Add(convertedEntity);
                    }
                    return results;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetChildEntitiesForParent", ex);
                throw;
            }

        }

        public gcsEntityCounts GetNewestCountsForEntity(Guid entityId)
        {
            var mgr = new gcsEntityCountPDSA_GetLatestCountsPDSAManager();
            var resp = new gcsEntityCounts();
            if (entityId == Guid.Empty)
                return resp;
            mgr.Entity.EntityId = entityId;
            var counts = mgr.BuildCollection();
            foreach (var c in counts)
            {
                switch (c.CountType.ToLower())
                {
                    case "accessportal":
                        resp.AccessPortalCount = c.CountValue;
                        break;

                    case "accessportalactivityevent":
                        resp.AccessPortalEventCount = c.CountValue;
                        break;

                    case "cluster":
                        resp.ClusterCount = c.CountValue;
                        break;

                    case "entityuser":
                        resp.EntityUserCount = c.CountValue;
                        break;

                    case "galaxypanelactivityevent":
                        resp.GalaxyPanelEventCount = c.CountValue;
                        break;

                    case "inputdevice":
                        resp.InputDeviceCount = c.CountValue;
                        break;

                    case "inputdeviceactivityevent":
                        resp.InputDeviceEventCount = c.CountValue;
                        break;

                    case "interfaceboard":
                        resp.InterfaceBoardCount = c.CountValue;
                        break;

                    case "outputdevice":
                        resp.OutputDeviceCount = c.CountValue;
                        break;

                    case "outputdeviceactivityevent":
                        resp.OutputDeviceEventCount = c.CountValue;
                        break;

                    case "panel":
                        resp.PanelCount = c.CountValue;
                        break;

                    case "person":
                        resp.PersonCount = c.CountValue;
                        break;

                    case "primaryuser":
                        resp.PrimaryUserCount = c.CountValue;
                        break;

                    case "timeschedule":
                        resp.TimeScheduleCount = c.CountValue;
                        break;

                    case "site":
                        resp.SiteCount = c.CountValue;
                        break;

                    case "accessgroup":
                        resp.AccessGroupCount = c.CountValue;
                        break;

                    case "accessprofile":
                        resp.AccessProfileCount = c.CountValue;
                        break;

                    case "inputoutputgroup":
                        resp.InputOutputGroupCount = c.CountValue;
                        break;

                    case "accessportalgroup":
                        resp.DoorGroupCount = c.CountValue;
                        break;

                    case "region":
                        resp.RegionCount = c.CountValue;
                        break;

                    case "daytype":
                        resp.DayTypeCount = c.CountValue;
                        break;

                    case "timeperiod":
                        resp.TimePeriodCount = c.CountValue;
                        break;
                }
            }
            return resp;
        }

        public gcsEntityCounts UpdateCountsForEntity(Guid entityId)
        {
            var mgr = new gcsEntityCountPDSA_GenerateAllCountsPDSAManager();
            mgr.Entity.EntityId = entityId;
            mgr.Execute();
            return GetNewestCountsForEntity(entityId);
        }
    }
}
