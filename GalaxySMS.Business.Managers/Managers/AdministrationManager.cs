using GalaxySMS.Business.Contracts;
using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Constants;
using GalaxySMS.Data;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.ServiceModel.Extensions;
using GCS.Core.Common.Utils;
using GCS.Framework.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Threading.Tasks;
using System.Transactions;
using GalaxySMS.Business.Common;
using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Shared.Enums;
using GCS.Framework.Caching;
using GCS.PanelDataProcessors.Interfaces;
using GCS.PanelOutputDataHandlers;
using Newtonsoft.Json;
using BadgeSystemType = GalaxySMS.Business.Entities.BadgeSystemType;
using BiometricSystemType = GalaxySMS.Business.Entities.BiometricSystemType;
using RoleCluster = GalaxySMS.Business.Entities.RoleCluster;
using SharedResources = GalaxySMS.Resources;
using StackExchange.Redis;
using System.Security.Cryptography;

namespace GalaxySMS.Business.Managers
{
    [Export(typeof(IAdministrationService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                    ConcurrencyMode = ConcurrencyMode.Multiple,
                    ReleaseServiceInstanceOnTransactionComplete = false,
                    TransactionTimeout = "00:10:00",
                    TransactionIsolationLevel = IsolationLevel.ReadUncommitted)]// - Defaults to 00:00:00 (no timeout)
    [ApplicationUserSessionHeaderInspectorBehavior]
    public class AdministrationManager : ManagerBase, IAdministrationService
    {
        public AdministrationManager()
        {
        }

        public AdministrationManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        public AdministrationManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _BusinessEngineFactory = businessEngineFactory;
        }

        public AdministrationManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory, IGalaxySMSEngine galaxySmsEngine)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _BusinessEngineFactory = businessEngineFactory;
            _GalaxySmsEngine = galaxySmsEngine;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _BusinessEngineFactory;

        [Import]
        IGalaxySMSEngine _GalaxySmsEngine;

        //[Import]
        //ICacheManager _CacheManager;


        public gcsSystem[] GetAllSystems()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSystemRepository>();

                IEnumerable<gcsSystem> systems = repository.Get(ApplicationUserSessionHeader, null);
                var myAtts = SystemUtilities.MyAssemblyAttributes();
                foreach (var s in systems)
                    s.SystemVersion = myAtts.Version;
                return systems.ToArray();
            });
        }

        public gcsSystem GetSystem(Guid systemId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSystemRepository>();

                var system = repository.Get(systemId, ApplicationUserSessionHeader, null);
                if (system == null)
                {
                    NotFoundException ex =
                        new NotFoundException(string.Format("gcsSystem with ID of {0} not found", systemId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                var myAtts = SystemUtilities.MyAssemblyAttributes();
                system.SystemVersion = myAtts.Version;
                if (system.TheLicense != null)
                {
                    bool isIdProducerLicensed = false;
                    if (Globals.Instance.SystemData != null)
                        isIdProducerLicensed = Globals.Instance.SystemData.GetLicenseFeatureValue<bool>(LicenseFeatureKey.BadgingSystemIdProducer);
                    else
                        isIdProducerLicensed = system.GetLicenseFeatureValue<bool>(LicenseFeatureKey.BadgingSystemIdProducer);
                    if (isIdProducerLicensed)
                    {
                        int maxBadgePrinters = 0;
                        if (Globals.Instance.SystemData != null)
                            maxBadgePrinters = Globals.Instance.SystemData.GetLicenseFeatureValue<int>(LicenseFeatureKey.MaximumBadgePrinters);
                        else
                            maxBadgePrinters = system.GetLicenseFeatureValue<int>(LicenseFeatureKey.MaximumBadgePrinters);
                        //var maxBadgePrintersFeature = system.TheLicense.ProductFeatures.FirstOrDefault(o => o.name == LicenseFeatureKey.MaximumBadgePrinters.ToString());
                        //int maxBadgePrinters = 10;
                        //if (!string.IsNullOrEmpty(maxBadgePrintersFeature?.Value))
                        //{
                        //    int.TryParse(maxBadgePrintersFeature.Value, out maxBadgePrinters);
                        //}
                        var sysMgr = new SystemManagement(this._DataRepositoryFactory);
                        system.IdProducerRootData = sysMgr.IdProducerEnsureIsLicensedWithoutValidateAuth(new SaveParameters<IdProducerSaveMasterLicenseParameters>()
                        {
                            CurrentEntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id,
                            Data = new IdProducerSaveMasterLicenseParameters()
                            {
                                CompanyName = system.CompanyName,
                                IsLicensePeriodUnlimited = true,
                                IsTrialPeriod = false,
                                LicensedMaxPrinterCount = maxBadgePrinters,
                                //MaxCustomerCount = 0,
                                SupportsMultiplePrinters = true,
                                DefaultTimeZone = string.Empty,
                                IsInactive = false,
                                IsReseller = false,
                                MasterUserName = "galaxyApi@idProducer.com",
                                //                                MasterPassword = "g@1axyAp!"
                                MasterPassword = "galaxy"
                            }
                        });
                    }
                }
                Globals.Instance.SystemData = system;
                return system;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsSystem SaveSystem(SaveParameters<gcsSystem> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSystemRepository>();

                gcsSystem updatedSystem = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("gcsSystem with '{0}' cannot be saved because it is a duplicate.", parameters.Data.SystemId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.SystemId == Guid.Empty)
                {
                    parameters.Data.SystemId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.SystemId) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding System - {parameters.Data.CompanyName}.");
                    updatedSystem = repository.Add(parameters.Data, ApplicationUserSessionHeader, null);
                }
                else
                {
                    var existingSystem = repository.Get(parameters.Data.SystemId, this.ApplicationUserSessionHeader, new GetParametersWithPhoto());
                    updatedSystem = repository.Update(parameters.Data, ApplicationUserSessionHeader, null);

                    if (existingSystem != null && existingSystem.CompanyName != parameters.Data.CompanyName)
                    {
                        var isIdProducerLicensed = Globals.Instance.SystemData.GetLicenseFeatureValue<bool>(LicenseFeatureKey.BadgingSystemIdProducer);
                        if (isIdProducerLicensed)
                        {
                            var maxPrinters = Globals.Instance.SystemData.GetLicenseFeatureValue<int>(LicenseFeatureKey.MaximumBadgePrinters);
                            if (maxPrinters == 0)
                                maxPrinters = 10;

                            var sysMgr = new SystemManagement(this._DataRepositoryFactory);

                            sysMgr.IdProducerUpdateRootSubscriptionCompanyName(new SaveParameters<IdProducerUpdateRootCustomerNameParameters>(parameters)
                            {
                                Data = new IdProducerUpdateRootCustomerNameParameters()
                                {
                                    CompanyName = updatedSystem.CompanyName,
                                    LicensedMaxPrinterCount = Convert.ToInt32(maxPrinters),
                                    SupportsMultiplePrinters = Convert.ToInt32(maxPrinters)
                                }
                            });
                        }
                    }
                    var myAtts = SystemUtilities.MyAssemblyAttributes();
                    updatedSystem.SystemVersion = myAtts.Version;

                }
                return GetSystem(updatedSystem.SystemId);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteSystem(gcsSystem system)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSystemRepository>();

                //if (repository.IsReferenced(language.LanguageId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsLanguage '{0}' cannot be deleted because it is referenced.", language.LanguageName));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}

                if (repository.CanDelete(system.SystemId) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsSystem '{0}' cannot be deleted because it is referenced.", system.SystemId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    return repository.Remove(system, ApplicationUserSessionHeader);
                }

            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsSystem SaveSystemLicense(Guid systemId, string publicKey, string license)
        {
            return ExecuteFaultHandledOperation(() =>
            {

                ValidateAdminAuthorizationAndSetupOperation(null);

                gcsSystem updatedSystem = null;

                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSystemRepository>();

                var system = repository.Get(systemId, ApplicationUserSessionHeader, null);
                if (system == null)
                {
                    NotFoundException ex =
                        new NotFoundException(string.Format("gcsSystem with ID of {0} not found", systemId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                //return system;

                system.License = license;
                system.PublicKey = publicKey;
                system.UpdateDate = DateTimeOffset.Now;
                system.UpdateName = LoginName;
                var saveParams = new SaveParameters()
                {
                    SavePhoto = false
                };

                if (system.SystemId == Guid.Empty)
                {
                    system.SystemId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(system.SystemId) == false)
                {
                    system.InsertDate = DateTimeOffset.Now;
                    system.InsertName = LoginName;
                    this.Log().Info($"Adding System License.");
                    updatedSystem = repository.Add(system, ApplicationUserSessionHeader, saveParams);
                }
                else
                {
                    updatedSystem = repository.Update(system, ApplicationUserSessionHeader, saveParams);
                }

                var myAtts = SystemUtilities.MyAssemblyAttributes();
                updatedSystem.SystemVersion = myAtts.Version;
                var sys = GetSystem(updatedSystem.SystemId);
                Globals.Instance.LoadSystem();

                //Globals.Instance.SystemData = Globals.Load GetSystem(updatedSystem.SystemId);
                return Globals.Instance.SystemData;
            });
        }


        #region Entity Operations
        public gcsEntityEx[] GetAllEntitiesRaw(GetParametersWithPhoto parameters)
        {
            var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

            var enforceEntityPermissions = parameters.Options.Where(o => o.Key == GalaxySMS.Common.Constants.GetOptions.EnforcePermissions).FirstOrDefault();
            if (enforceEntityPermissions.Value == true)
            {
                parameters.AllowedEntityIds = this.UserSessionToken.UserData.UserEntities.Where(o => o.IsActive).Select(o => o.EntityId).ToList();
            }

            var entities = repository.Get(ApplicationUserSessionHeader, parameters);
            var result = new List<gcsEntityEx>();
            var includeCounts = false;
            var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
            if (includeCountsOption.HasValue)
                includeCounts = includeCountsOption.Value;

            foreach (var e in entities)
            {
                var ent = new gcsEntityEx(e);
                if (includeCounts)
                    ent.Counts = repository.GetNewestCountsForEntity(e.EntityId);

                result.Add(ent);
            }
            return result.ToArray();
        }

        public ArrayResponse<gcsEntityEx> GetAllEntities(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var enforceEntityPermissions = parameters.Options.Where(o => o.Key == GalaxySMS.Common.Constants.GetOptions.EnforcePermissions).FirstOrDefault();
                if (enforceEntityPermissions.Value == true)
                {
                    parameters.AllowedEntityIds = this.UserSessionToken.UserData.UserEntities.Where(o => o.IsActive).Select(o => o.EntityId).ToList();
                }

                var entities = repository.GetPaged(ApplicationUserSessionHeader, parameters);
                var items = new List<gcsEntityEx>();

                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;

                foreach (var e in entities.Items)
                {
                    var ent = new gcsEntityEx(e);
                    if (includeCounts)
                        ent.Counts = repository.GetNewestCountsForEntity(e.EntityId);

                    items.Add(ent);
                }

                var result = new ArrayResponse<gcsEntityEx>()
                {
                    Items = items.ToArray(),
                    PageItemCount = entities.PageItemCount,
                    PageNumber = entities.PageNumber,
                    PageSize = entities.PageSize,
                    TotalItemCount = entities.TotalItemCount,
                    TotalPageCount = entities.TotalPageCount
                };
                return result;
            });
        }

        public ArrayResponse<gcsEntityEx> GetAllEntitiesForUser(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var entities = repository.GetEntitiesForUserPaged(parameters.UniqueId, ApplicationUserSessionHeader, parameters);
                var items = new List<gcsEntityEx>();
                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;

                foreach (var e in entities.Items)
                {
                    var r = new gcsEntityEx(e);
                    if (includeCounts)
                        r.Counts = repository.GetNewestCountsForEntity(e.EntityId);
                    items.Add(r);
                }

                var result = new ArrayResponse<gcsEntityEx>()
                {
                    Items = items.ToArray(),
                    PageItemCount = entities.PageItemCount,
                    PageNumber = entities.PageNumber,
                    PageSize = entities.PageSize,
                    TotalItemCount = entities.TotalItemCount,
                    TotalPageCount = entities.TotalPageCount
                };
                return result;
            });
        }

        public gcsEntityEx GetEntity(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();
                if (!repository.DoesExist(parameters.UniqueId))
                {
                    var ex = new NotFoundException(string.Format("gcsEntity with ID of {0} not found", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                bool enforcePermissions = false;
                var kvp = parameters.Options.Where(o => o.Key == GalaxySMS.Common.Constants.GetOptions.EnforcePermissions).FirstOrDefault();
                enforcePermissions = kvp.Value;
                if (enforcePermissions)
                {
                    if (!UserSessionToken.HasPermission(parameters.UniqueId, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId))
                    {
                        var ex1 = new UnauthorizedAccessException($"{UserSessionToken.UserData.UserName} does not have permissions to access the requested item.");
                        var detail1 = new ExceptionDetailEx(ex1);
                        throw new FaultException<ExceptionDetailEx>(detail1, ex1.Message);
                    }
                }

                parameters.CurrentEntityId = parameters.UniqueId;
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId);

                //var cacheKey = $"gcsEntityEx[{parameters.UniqueId}]";
                //if (CacheHelpers.ShouldReadFromCache(_CacheManager, parameters) )
                //{
                //    var returnItem = _CacheManager.GetCachedItem<gcsEntityEx>(cacheKey);
                //    if (returnItem != null && returnItem.EntityId == parameters.UniqueId)
                //    {
                //        return returnItem;
                //    }
                //}


                var entity = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, parameters);
                if (entity == null)
                {
                    var ex = new NotFoundException(string.Format("gcsEntity with ID of {0} not found", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;

                var result = new gcsEntityEx(entity);
                if (includeCounts)
                    result.Counts = repository.GetNewestCountsForEntity(result.EntityId);

                //if (/*CacheHelpers.ShouldCacheBeUpdated(_CacheManager, parameters) && */!string.IsNullOrEmpty(cacheKey))
                //{
                //    var bCached = _CacheManager.SetCachedItem(cacheKey, result);
                //}


                return result;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsEntityEx SaveEntity(SaveParameters<gcsEntity> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                //var ambientTransaction = Transaction.Current;
                //LogTransactionInformation($"{ System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

                if (parameters.RequestDateTime != MagicStuff.MagicDate)
                {
                    if (parameters.Data.EntityId == Guid.Empty)
                        ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.EntityCanAddId);
                    else
                        ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.EntityCanUpdateId);
                }

                if (parameters.Data.ParentEntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id)
                {
                    var ex = new InvalidDataException($"The Parent Entity cannot be set to the System Entity.");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                if (parameters.Data.ParentEntityId != Guid.Empty && parameters.Data.ParentEntityId == parameters.Data.EntityId)
                {
                    var ex = new InvalidDataException($"The Parent Entity cannot be the same as the Entity itself.");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                gcsEntity updatedEntity = null;
                var entity = parameters.Data;

                if (parameters.BackgroundJobId != Guid.Empty)
                {
                    SaveBackgroundJobState(parameters.BackgroundJobId, entity.EntityId, BackgroundJobState.InProgress, string.Empty, _DataRepositoryFactory);
                }
                if (repository.IsUnique(entity) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("gcsEntity with Name of '{0}' cannot be saved because it is a duplicate.", entity.EntityName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                var bAddEntityToUser = false;
                var bAdding = false;
                entity.UpdateDate = DateTimeOffset.Now;
                entity.UpdateName = LoginName;

                if (entity.EntityId == Guid.Empty)
                {
                    if (parameters.BackgroundJobId != Guid.Empty)
                        entity.EntityId = parameters.BackgroundJobId;
                    else
                        entity.EntityId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                    bAddEntityToUser = true;
                }

                if (repository.DoesExist(entity.EntityId) == false)
                {
                    bAdding = true;
                    entity.InsertDate = DateTimeOffset.Now;
                    entity.InsertName = LoginName;
                    this.Log().Info($"Adding Entity - {parameters.Data.EntityName}.");
                    updatedEntity = repository.Add(entity, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedEntity = repository.Update(entity, ApplicationUserSessionHeader, parameters);
                }

                if (entity.UserRequirements != null && !parameters.Ignore(nameof(entity.UserRequirements)))
                {
                    entity.UserRequirements.EntityId = updatedEntity.EntityId;
                    var p = new SaveParameters<gcsUserRequirement>(entity.UserRequirements, parameters);
                    updatedEntity.UserRequirements = SaveUserRequirement(p);
                }

                if (entity.Settings == null)
                    entity.Settings = new HashSet<gcsSetting>();

                if (entity.Settings != null && !parameters.Ignore(nameof(entity.Settings)))
                {
                    //var missingSettings = entity.Settings.ToList();

                    //var settingAG1 = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                    //s.SettingKey == gcsSettingKey.ControlsAccessGroup1);
                    //if (settingAG1 == null)
                    //{
                    //    settingAG1 = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                    //        SettingKey = gcsSettingKey.ControlsAccessGroup1,
                    //        Value = true.ToString(),
                    //    };
                    //    missingSettings.Add(settingAG1);
                    //}

                    //var settingAG2 = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                    //s.SettingKey == gcsSettingKey.ControlsAccessGroup2);
                    //if (settingAG2 == null)
                    //{
                    //    settingAG2 = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                    //        SettingKey = gcsSettingKey.ControlsAccessGroup2,
                    //        Value = true.ToString(),
                    //    };
                    //    missingSettings.Add(settingAG2);
                    //}

                    //var settingAG3 = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                    //s.SettingKey == gcsSettingKey.ControlsAccessGroup3);
                    //if (settingAG3 == null)
                    //{
                    //    settingAG3 = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                    //        SettingKey = gcsSettingKey.ControlsAccessGroup3,
                    //        Value = false.ToString(),
                    //    };
                    //    missingSettings.Add(settingAG3);
                    //}


                    //var settingAG4 = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                    //s.SettingKey == gcsSettingKey.ControlsAccessGroup4);
                    //if (settingAG4 == null)
                    //{
                    //    settingAG4 = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                    //        SettingKey = gcsSettingKey.ControlsAccessGroup4,
                    //        Value = false.ToString(),
                    //    };
                    //    missingSettings.Add(settingAG4);
                    //}

                    //var settingIO1 = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                    //s.SettingKey == gcsSettingKey.ControlsIOGroup1);
                    //if (settingIO1 == null)
                    //{
                    //    settingIO1 = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                    //        SettingKey = gcsSettingKey.ControlsIOGroup1,
                    //        Value = true.ToString(),
                    //    };
                    //    missingSettings.Add(settingIO1);
                    //}

                    //var settingIO2 = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                    //s.SettingKey == gcsSettingKey.ControlsIOGroup2);
                    //if (settingIO2 == null)
                    //{
                    //    settingIO2 = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                    //        SettingKey = gcsSettingKey.ControlsIOGroup2,
                    //        Value = true.ToString(),
                    //    };
                    //    missingSettings.Add(settingIO2);
                    //}

                    //var settingIO3 = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                    //s.SettingKey == gcsSettingKey.ControlsIOGroup3);
                    //if (settingIO3 == null)
                    //{
                    //    settingIO3 = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                    //        SettingKey = gcsSettingKey.ControlsIOGroup3,
                    //        Value = false.ToString(),
                    //    };
                    //    missingSettings.Add(settingIO3);
                    //}

                    //var settingIO4 = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                    //s.SettingKey == gcsSettingKey.ControlsIOGroup4);
                    //if (settingIO4 == null)
                    //{
                    //    settingIO4 = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                    //        SettingKey = gcsSettingKey.ControlsIOGroup4,
                    //        Value = false.ToString(),
                    //    };
                    //    missingSettings.Add(settingIO4);
                    //}


                    //var settingPersonIdPrefix = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //                                                     s.SettingSubGroup == gcsSettingSubGroup.PersonId &&
                    //                                                     s.SettingKey == gcsSettingKey.Prefix);
                    //if (settingPersonIdPrefix == null)
                    //{
                    //    settingPersonIdPrefix = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.Person,
                    //        SettingKey = gcsSettingKey.Prefix,
                    //        Value = string.Empty,
                    //    };
                    //    missingSettings.Add(settingPersonIdPrefix);
                    //}

                    //var settingPersonIdSuffix = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //    s.SettingSubGroup == gcsSettingSubGroup.PersonId &&
                    //    s.SettingKey == gcsSettingKey.Suffix);
                    //if (settingPersonIdSuffix == null)
                    //{
                    //    settingPersonIdSuffix = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.Person,
                    //        SettingKey = gcsSettingKey.Suffix,
                    //        Value = string.Empty,
                    //    };
                    //    missingSettings.Add(settingPersonIdSuffix);
                    //}

                    //var settingPersonIdUniquePartLen = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //    s.SettingSubGroup == gcsSettingSubGroup.PersonId &&
                    //    s.SettingKey == gcsSettingKey.UniquePartLength);
                    //if (settingPersonIdUniquePartLen == null)
                    //{
                    //    settingPersonIdUniquePartLen = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.Person,
                    //        SettingKey = gcsSettingKey.UniquePartLength,
                    //        Value = DefaultSettingValues.PersonIdDefaultUniquePartLength.ToString(),
                    //    };
                    //    missingSettings.Add(settingPersonIdUniquePartLen);
                    //}

                    //var settingPersonIdUnsRandomizedString = missingSettings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                    //    s.SettingSubGroup == gcsSettingSubGroup.PersonId &&
                    //    s.SettingKey == gcsSettingKey.UseRandomizedString);
                    //if (settingPersonIdUnsRandomizedString == null)
                    //{
                    //    settingPersonIdUnsRandomizedString = new gcsSetting()
                    //    {
                    //        SettingGroup = gcsSettingGroup.gcsEntity,
                    //        SettingSubGroup = gcsSettingSubGroup.Person,
                    //        SettingKey = gcsSettingKey.UseRandomizedString,
                    //        Value = DefaultSettingValues.PersonIdUseRandomizedString.ToString(),
                    //    };
                    //    missingSettings.Add(settingPersonIdUnsRandomizedString);
                    //}


                    //entity.Settings = missingSettings.ToCollection();

                    var gcsSettingsRepo = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                    foreach (var s in entity.Settings.Where(o => o.IsDirty))
                    {
                        s.EntityId = updatedEntity.EntityId;
                        UpdateProperties(s);
                        if (s.SettingId == Guid.Empty)
                        {
                            s.SettingId = GuidUtilities.GenerateComb();
                            gcsSettingsRepo.Add(s, ApplicationUserSessionHeader, parameters);
                        }
                        else
                            gcsSettingsRepo.Update(s, ApplicationUserSessionHeader, parameters);
                    }
                }

                if (updatedEntity.EntityId != GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id)
                {
                    var dontEnsureDefaultsExist =
                        parameters.OptionValue<bool>(SaveEntityOption.DontEnsureDefaultsExist.ToString());
                    if (!dontEnsureDefaultsExist)
                    {
                        EnsureEntityDefaultsExist(updatedEntity, false);
                    }
                }

                if (bAddEntityToUser == true)
                {
                    var userEntityRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserEntityRepository>();
                    var userEntityRoleRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserEntityRoleRepository>();
                    var roleRepository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

                    var userId = ApplicationUserSessionHeader.UserId;
                    if (this.UserSessionToken != null)
                        userId = this.UserSessionToken.UserData.UserId;

                    #region Add any gcsUserEntity and gcsUserEntityRole records 
                    var newUserEntity = new gcsUserEntity();
                    newUserEntity.UserEntityId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                    newUserEntity.EntityId = entity.EntityId;
                    newUserEntity.UserId = userId;
                    newUserEntity.IsAdministrator = true;
                    newUserEntity.InheritParentRoles = false;
                    newUserEntity.InsertDate = DateTimeOffset.Now;
                    newUserEntity.InsertName = this.ApplicationUserSessionHeader.UserName;
                    newUserEntity.UpdateDate = newUserEntity.InsertDate;
                    newUserEntity.UpdateName = newUserEntity.InsertName;
                    this.Log().Info($"Adding UserEntity - UserId:{newUserEntity.UserId}, EntityId:{newUserEntity.EntityId}");

                    var userEntity = userEntityRepository.Add(newUserEntity, ApplicationUserSessionHeader, parameters);

                    if (userEntity != null)
                    {
                        // Now add admin role for the user
                        var roles = roleRepository.GetAllRolesForEntity(entity.EntityId,
                            new GetParametersWithPhoto() { IncludeMemberCollections = false });
                        var adminRole = roles.FirstOrDefault(o => o.IsAdministratorRole == true);
                        if (adminRole != null)
                        {
                            var uer = new gcsUserEntityRole()
                            {
                                UserEntityRoleId = GuidUtilities.GenerateComb(),
                                UserEntityId = userEntity.UserEntityId,
                                RoleId = adminRole.RoleId
                            };
                            UpdateProperties(uer);
                            var savedUer = userEntityRoleRepository.Add(uer, ApplicationUserSessionHeader, parameters);
                        }
                    }
                    else
                    {
                        this.Log().DebugFormat("GcsUserRepository::SaveUserEntities userEntity is null");
                    }

                    var addToExistingUsers = parameters.OptionValue<bool>(SaveEntityOption.AddToExistingUsersWithParentEntityAccess.ToString());
                    if (addToExistingUsers)
                    {
                        var inheritParentRoles =
                            parameters.OptionValue<bool>(SaveEntityOption.InheritParentEntityRoles.ToString());

                        var isEntityAdmin =
                            parameters.OptionValue<bool>(SaveEntityOption.IsEntityAdministrator.ToString());

                        // Now add to all users that have access to the new entities parent entity
                        if (entity.ParentEntityId.HasValue && entity.ParentEntityId.Value != Guid.Empty)
                        {
                            // Get Default roles of the new entity
                            var defaultRoleIds = roleRepository.GetAllDefaultUids(entity.EntityId);
                            // Get all users who have access to the parent entity
                            var uids = GalaxySMSDatabaseManager.GetAllUidsFromTable("GCS", "gcsUserEntity", "UserId",
                                $"EntityId = '{entity.ParentEntityId.Value}'");
                            var existingUids = GalaxySMSDatabaseManager.GetAllUidsFromTable("GCS", "gcsUserEntity", "UserId",
                                $"EntityId = '{entity.EntityId}'");
                            var addTheseUids = uids.Where(p => existingUids.All(p2 => p2 != p)).ToList();
                            // Create user entity for each user that currently has access to the parent entity
                            foreach (var uid in addTheseUids)
                            {
                                newUserEntity = new gcsUserEntity();
                                newUserEntity.UserEntityId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                                newUserEntity.EntityId = entity.EntityId;
                                newUserEntity.UserId = uid;
                                newUserEntity.IsAdministrator = isEntityAdmin;
                                newUserEntity.InheritParentRoles = inheritParentRoles;
                                newUserEntity.InsertDate = DateTimeOffset.Now;
                                newUserEntity.InsertName = this.ApplicationUserSessionHeader.UserName;
                                newUserEntity.UpdateDate = newUserEntity.InsertDate;
                                newUserEntity.UpdateName = newUserEntity.InsertName;
                                this.Log().Info($"Adding UserEntity - UserId:{newUserEntity.UserId}, EntityId:{newUserEntity.EntityId}");
                                userEntity = userEntityRepository.Add(newUserEntity, ApplicationUserSessionHeader, parameters);
                                if (userEntity != null)
                                {
                                    foreach (var rid in defaultRoleIds)
                                    {
                                        var uer = new gcsUserEntityRole()
                                        {
                                            UserEntityRoleId = GuidUtilities.GenerateComb(),
                                            UserEntityId = userEntity.UserEntityId,
                                            RoleId = rid
                                        };
                                        UpdateProperties(uer);
                                        var savedUer = userEntityRoleRepository.Add(uer, ApplicationUserSessionHeader, parameters);
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }

                // Check if idProducer is licensed and if it is, create subscription 
                if (Globals.Instance.SystemData != null)
                {
                    var isIdProducerLicensed = Globals.Instance.SystemData.GetLicenseFeatureValue<bool>(LicenseFeatureKey.BadgingSystemIdProducer);
                    if (isIdProducerLicensed)
                    {
                        var sysMgr = new SystemManagement(this._DataRepositoryFactory);
                        //try
                        //{
                            var rootLicense = sysMgr.IdProducerGetRootSubscription(new GetParametersWithPhoto());
                            if (rootLicense != null && rootLicense.FriendlyLicenseDetails != null &&
                                rootLicense?.FriendlyLicenseDetails?.MaxCustomerCount != 0)
                                //if (Globals.Instance.SystemData?.IdProducerRootData?.FriendlyLicenseDetails?.MaxCustomerCount != 0)
                            {
                                var subscription = sysMgr.IdProducerSyncSubscriptionAndEntity(
                                    new SaveParameters<IdProducerSyncSubscriptionAndEntityParameters>()
                                    {
                                        Data = new IdProducerSyncSubscriptionAndEntityParameters()
                                        {
                                            EntityId = updatedEntity.EntityId,
                                            SupportsMultiplePrinters = rootLicense.FriendlyLicenseDetails
                                                .SupportsMultiplePrinters,
                                        }
                                    });
                            }
                        //}
                        //catch (Exception ex)
                        //{
                        //    throw ex;
                        //}
                    }
                }

                if (this.UserSessionToken != null && bAdding)
                {
                    var userRepo = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                    //this.UserSessionToken = userRepo.GetUserSessionTokenForApplications(UserSessionToken.UserData.UserId, UserSessionToken.RequestData.ApplicationId, UserSessionToken.RequestData.PermissionsForApplicationIds, UserSessionToken.RequestData.IncludeEntityPhotos, UserSessionToken.RequestData.EntityPhotosPixelWidth, UserSessionToken.RequestData.IncludeUserPhotos, UserSessionToken.RequestData.UserPhotosPixelWidth);
                    this.UserSessionToken = userRepo.GetUserSessionTokenForApplications(UserSessionToken.UserData.UserId, ApplicationUserSessionHeader.ApplicationId, UserSessionToken.RequestData);
                    if (Globals.Instance.CurrentUserSessions.ContainsKey(ApplicationUserSessionHeader.SessionGuid))
                        Globals.Instance.CurrentUserSessions.Remove(ApplicationUserSessionHeader.SessionGuid);
                    Globals.Instance.CurrentUserSessions.Add(ApplicationUserSessionHeader.SessionGuid, UserSessionToken);
                }
                //else
                //    this.UserSessionToken = userRepo.GetUserSessionTokenForApplications(ApplicationUserSessionHeader.UserId, ApplicationUserSessionHeader.ApplicationId, new List<Guid>(), false, 0, false, 0);

                if (parameters.BackgroundJobId != Guid.Empty)
                {
                    SaveBackgroundJobState(parameters.BackgroundJobId, updatedEntity.EntityId, BackgroundJobState.Finished, string.Empty, _DataRepositoryFactory);
                }

                // Update the cache

                return new gcsEntityEx(updatedEntity);
            });
        }


        [OperationBehavior(TransactionScopeRequired = true)]
        public BackgroundJobInfo SaveEntityJob(SaveParameters<gcsEntity> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (parameters.RequestDateTime != MagicStuff.MagicDate)
                {
                    if (parameters.Data.EntityId == Guid.Empty)
                        ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.EntityCanAddId);
                    else
                        ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.EntityCanUpdateId);
                }

                if (parameters.Data.ParentEntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id)
                {
                    var ex = new InvalidDataException($"The Parent Entity cannot be set to the System Entity.");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                if (parameters.Data.ParentEntityId != Guid.Empty && parameters.Data.ParentEntityId == parameters.Data.EntityId)
                {
                    var ex = new InvalidDataException($"The Parent Entity cannot be the same as the Entity itself.");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var entity = parameters.Data;
                if (repository.IsUnique(entity) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("gcsEntity with Name of '{0}' cannot be saved because it is a duplicate.", entity.EntityName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                // Assign a jobId and fill the SaveParameters.BackgroundJobId property. This will be used by the SaveEntity method to update the 
                // BackgroundJob tables.
                parameters.BackgroundJobId = GuidUtilities.GenerateComb();
                var jobParameters = new SaveJobParameters<gcsEntity>()
                {
                    JobId = parameters.BackgroundJobId,
                    SaveParameters = parameters,
                    UserSessionData = ApplicationUserSessionHeader as ApplicationUserSessionHeader
                };

                var isNew = parameters.Data.EntityId == Guid.Empty;

                var responseInfo = new BackgroundJobInfo()
                {
                    JobId = jobParameters.JobId,
                    DataType = nameof(gcsEntity),
                    JobType = BackgroundJobOperationType.Create,
                    State = BackgroundJobState.Queued,
                    ItemName = entity.EntityName
                };

                if (!isNew && repository.DoesExist(entity.EntityId) == true)
                {
                    responseInfo.JobType = BackgroundJobOperationType.Update;
                }

                if (isNew)
                {
                    responseInfo.DataItemUid = parameters.BackgroundJobId;
                    responseInfo.EntityId = parameters.BackgroundJobId;
                }

                var bgJob = new BackgroundJob()
                {
                    BackgroundJobUid = jobParameters.JobId,
                    UserId = UserSessionToken.UserData.UserId,
                    State = responseInfo.State.ToString(),
                    JobType = responseInfo.JobType.ToString(),
                    DataType = responseInfo.DataType,
                    ItemName = entity.EntityName,
                    InsertDate = DateTimeOffset.Now,
                    InsertName = LoginName,
                    UpdateDate = DateTimeOffset.Now,
                    UpdateName = LoginName,
                    ConcurrencyValue = 0
                };

                if (isNew)
                {
                    bgJob.DataItemUid = responseInfo.EntityId;
                    bgJob.EntityId = responseInfo.EntityId;
                }
                else
                {
                    bgJob.DataItemUid = entity.EntityId;
                    bgJob.EntityId = entity.EntityId;
                }

                //// If EntityId is empty, most likely this is a new insert. If this is the case AND there is a parent entity id specified
                //// then use the parent entity id. This will allow the signalR hub to notify listeners who have joined the parent entity id group to 
                //// recieve job completion notifications
                //if (bgJob.EntityId == Guid.Empty && entity.ParentEntityId.HasValue)
                //    bgJob.EntityId = entity.ParentEntityId.Value;

                SaveBackgroundJob(bgJob, string.Empty, _DataRepositoryFactory);

                IJobMessageHandler recorder = new JobMessageHandler();
                recorder.HandleMessage(jobParameters);

                return responseInfo;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public bool EnsureEntityDefaultsExist(gcsEntity parameters, bool addDefaultNonAdminRole)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                this.Log().Info($"Creating Entity Defaults...");
                //GalaxySMSDatabaseManager.SetIsolationLevel(SqlTransactionIsolationLevels.ReadUncommitted);
                //var ambientTransaction = Transaction.Current;
                //LogTransactionInformation($"{ System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

                var userDefinedPropertyRepository =
                    _DataRepositoryFactory.GetDataRepository<IUserDefinedPropertyRepository>();
                var gcsSettingsRepository = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                var personUserDefinedPropertiesFromDB = userDefinedPropertyRepository.Get(ApplicationUserSessionHeader,
                    new GetParametersWithPhoto() { IncludeMemberCollections = true, UniqueId = parameters.EntityId });
                var personTableColumns = GalaxySMSDatabaseManager
                    .GetTableColumnInformation("GCS", "Person", string.Empty).ToList();

                var personUserDefinedProperties = new List<UserDefinedProperty>();

                for (int x = 1; x <= 10; x++)
                {
                    try
                    {
                        var e = (GalaxySMS.Common.Enums.PersonRelatedPropertyNames)Enum.Parse(
                            typeof(GalaxySMS.Common.Enums.PersonRelatedPropertyNames),
                            $"SelectItem{x}");

                        var personUserDefinedProperty = new UserDefinedProperty()
                        {
                            UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                            EntityId = parameters.EntityId,
                            PropertyName = e.ToString(),
                            Display =
                                string.Format(SharedResources.Resources.PersonPropertyNames_SelectItem_Display, x),
                            Description =
                                string.Format(SharedResources.Resources.PersonPropertyNames_SelectItem_Description, x),
                            UniqueResourceName = e.ToString(),
                            UniquePropertyName = string.Format("{0}:{1}:{2}:{3}", SchemaNames.GCS,
                                TableNames.PersonListPropertyItem, e.ToString(), e.ToString()),
                            PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.List,
                            PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                            SchemaName = GalaxySMS.Common.Constants.SchemaNames.GCS,
                            TableName = GalaxySMS.Common.Constants.TableNames.PersonListPropertyItem,
                            IsDirty = true,
                            IsActive = true,
                            UserDefinedListPropertyRules = new UserDefinedListPropertyRule()
                            {
                                AllowMultipleSelections = false,
                                IsDirty = true,
                            },
                        };


                        if (x < 5)
                        {
                            for (int y = 1; y <= 3; y++)
                            {
                                personUserDefinedProperty.UserDefinedListPropertyItems.Add(
                                    new UserDefinedListPropertyItem()
                                    {
                                        Display = $"Item {x}, Choice {y}",
                                        Description = $"Item {x}, Choice {y} Description",
                                        ItemValue = $"Item {x}, Choice {y} Value",
                                        IsDirty = true,
                                    });
                            }
                        }

                        personUserDefinedProperties.Add(personUserDefinedProperty);
                    }
                    catch (Exception exception)
                    {
                        this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                            exception);
                    }
                }

                for (int x = 1; x <= 2; x++)
                {
                    try
                    {
                        var e = (GalaxySMS.Common.Enums.PersonRelatedPropertyNames)Enum.Parse(
                            typeof(GalaxySMS.Common.Enums.PersonRelatedPropertyNames),
                            $"Date{x}");

                        var personUserDefinedProperty = new UserDefinedProperty()
                        {
                            UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                            EntityId = parameters.EntityId,
                            PropertyName = e.ToString(),
                            Display = string.Format(SharedResources.Resources.PersonPropertyNames_DateX_Display, x),
                            Description = string.Format(SharedResources.Resources.PersonPropertyNames_DateX_Description,
                                x),
                            UniqueResourceName = e.ToString(),
                            PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Date,
                            PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                            SchemaName = GalaxySMS.Common.Constants.SchemaNames.GCS,
                            TableName = GalaxySMS.Common.Constants.TableNames.PersonDateProperty,
                            UniquePropertyName =
                                $"{SchemaNames.GCS}:{TableNames.PersonListPropertyItem}:{e.ToString()}:{e.ToString()}",
                            IsDirty = true,
                            IsActive = true,
                            UserDefinedDatePropertyRules = new UserDefinedDatePropertyRule()
                            {
                                AllowNull = true,
                                IsDirty = true,
                            }
                        };

                        personUserDefinedProperties.Add(personUserDefinedProperty);
                    }
                    catch (Exception exception)
                    {
                        this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                            exception);
                    }
                }

                // Photos
                //try
                //{
                //var e = GalaxySMS.Common.Enums.PersonRelatedPropertyNames.MainPhoto;

                //var personUserDefinedProperty = new UserDefinedProperty()
                //{
                //    UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                //    EntityId = parameters.EntityId,
                //    PropertyName = e.ToString(),
                //    Display = string.Format(SharedResources.Resources.PersonPropertyNames_MainPhoto_Display),
                //    Description = string.Format(SharedResources.Resources.PersonPropertyNames_MainPhoto_Description),
                //    UniqueResourceName = e.ToString(),
                //    PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Photo,
                //    PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                //    SchemaName = GalaxySMS.Common.Constants.SchemaNames.GCS,
                //    TableName = GalaxySMS.Common.Constants.TableNames.PersonPhoto,
                //    UniquePropertyName = string.Format("{0}:{1}:{2}:{3}", SchemaNames.GCS, TableNames.PersonPhoto, e.ToString(), e.ToString()),
                //    IsDirty = true,
                //    IsActive = true,
                //    //UserDefinedDatePropertyRules = new UserDefinedDatePropertyRule()
                //    //{
                //    //    AllowNull = true,
                //    //    IsDirty = true,
                //    //}
                //};

                //personUserDefinedProperties.Add(personUserDefinedProperty);
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.PersonRelatedPropertyNames.MainPhoto.ToString(),
                        string.Format(SharedResources.Resources.PersonPropertyNames_MainPhoto_Display),
                        string.Format(SharedResources.Resources.PersonPropertyNames_MainPhoto_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Photo,
                        GalaxySMS.Common.Constants.TableNames.PersonPhoto);

                    personUserDefinedProperties.Add(personUserDefinedProperty);

                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //}
                //catch (Exception exception)
                //{
                //    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, exception);
                //}
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.PersonRelatedPropertyNames.AlternatePhoto.ToString(),
                        string.Format(SharedResources.Resources.PersonPropertyNames_AlternatePhoto_Display),
                        string.Format(SharedResources.Resources.PersonPropertyNames_AlternatePhoto_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Photo,
                        GalaxySMS.Common.Constants.TableNames.PersonPhoto);

                    personUserDefinedProperties.Add(personUserDefinedProperty);

                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                // Access Profile
                try
                {
                    var e = GalaxySMS.Common.Enums.PersonStandardPropertyNames.AccessProfileUid;

                    var personUserDefinedProperty = new UserDefinedProperty()
                    {
                        UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                        ColumnName = e.ToString(),
                        EntityId = parameters.EntityId,
                        PropertyName = e.ToString(),
                        Display = string.Format(SharedResources.Resources
                            .PersonEditor_AccessControlProperties_AccessProfile_Title),
                        Description = string.Format(SharedResources.Resources
                            .PersonEditor_AccessControlProperties_AccessProfile_ToolTip),
                        UniqueResourceName = e.ToString(),
                        PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Guid,
                        PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                        SchemaName = GalaxySMS.Common.Constants.SchemaNames.GCS,
                        TableName = GalaxySMS.Common.Constants.TableNames.PersonAccessControlProperties,
                        UniquePropertyName = string.Format("{0}:{1}:{2}:{3}", SchemaNames.GCS,
                            TableNames.PersonAccessControlProperties, e.ToString(), e.ToString()),
                        IsDirty = true,
                        IsActive = true,
                        UserDefinedDatePropertyRules = new UserDefinedDatePropertyRule()
                        {
                            AllowNull = false,
                            IsDirty = true,
                        }
                    };

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                // Credentials
                try
                {
                    var e = GalaxySMS.Common.Enums.PersonRelatedPropertyNames.CredentialDescription;

                    var personUserDefinedProperty = new UserDefinedProperty()
                    {
                        UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                        EntityId = parameters.EntityId,
                        PropertyName = e.ToString(),
                        Display = string.Format(SharedResources.Resources
                            .PersonPropertyNames_CredentialDescription_Display),
                        Description = string.Format(SharedResources.Resources
                            .PersonPropertyNames_CredentialDescription_Description),
                        UniqueResourceName = e.ToString(),
                        PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Text,
                        PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                        SchemaName = GalaxySMS.Common.Constants.SchemaNames.GCS,
                        TableName = GalaxySMS.Common.Constants.TableNames.PersonCredential,
                        UniquePropertyName = string.Format("{0}:{1}:{2}:{3}", SchemaNames.GCS,
                            TableNames.PersonCredential, e.ToString(), e.ToString()),
                        IsDirty = true,
                        IsActive = true,
                        UserDefinedTextPropertyRules = new UserDefinedTextPropertyRule()
                        {
                            IsDirty = true,
                            MaximumLength = 65
                        }
                    };

                    personUserDefinedProperties.Add(personUserDefinedProperty);

                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                // CredentialActivationDate
                try
                {

                    var e = GalaxySMS.Common.Enums.PersonRelatedPropertyNames.CredentialActivationDate;

                    var personUserDefinedProperty = new UserDefinedProperty()
                    {
                        UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                        EntityId = parameters.EntityId,
                        PropertyName = e.ToString(),
                        Display = string.Format(SharedResources.Resources.PersonCredentialEditor_ActivationDate_Title),
                        Description =
                            string.Format(SharedResources.Resources.PersonCredentialEditor_ActivationDate_ToolTip),
                        UniqueResourceName = e.ToString(),
                        PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Date,
                        PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                        SchemaName = GalaxySMS.Common.Constants.SchemaNames.GCS,
                        TableName = GalaxySMS.Common.Constants.TableNames.PersonCredential,
                        UniquePropertyName = string.Format("{0}:{1}:{2}:{3}", SchemaNames.GCS,
                            TableNames.PersonCredential, e.ToString(), e.ToString()),
                        IsDirty = true,
                        IsActive = true,
                        //UserDefinedDatePropertyRules = new UserDefinedDatePropertyRule()
                        //{
                        //    AllowNull = true,
                        //    IsDirty = true,
                        //}
                    };

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }


                //CredentialExpirationDateTime,
                try
                {
                    var e = GalaxySMS.Common.Enums.PersonRelatedPropertyNames.CredentialExpirationDateTime;

                    var personUserDefinedProperty = new UserDefinedProperty()
                    {
                        UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                        EntityId = parameters.EntityId,
                        PropertyName = e.ToString(),
                        Display = string.Format(SharedResources.Resources
                            .PersonCredentialEditor_ExpirationDateTime_Title),
                        Description = string.Format(SharedResources.Resources
                            .PersonCredentialEditor_ExpirationDateTime_ToolTip),
                        UniqueResourceName = e.ToString(),
                        PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Date,
                        PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                        SchemaName = GalaxySMS.Common.Constants.SchemaNames.GCS,
                        TableName = GalaxySMS.Common.Constants.TableNames.PersonCredential,
                        UniquePropertyName = string.Format("{0}:{1}:{2}:{3}", SchemaNames.GCS,
                            TableNames.PersonCredential, e.ToString(), e.ToString()),
                        IsDirty = true,
                        IsActive = true,
                        //UserDefinedDatePropertyRules = new UserDefinedDatePropertyRule()
                        //{
                        //    AllowNull = true,
                        //    IsDirty = true,
                        //}
                    };

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialExpirationDateTime,
                try
                {
                    var e = GalaxySMS.Common.Enums.PersonRelatedPropertyNames.CredentialUsageCount;

                    var personUserDefinedProperty = new UserDefinedProperty()
                    {
                        UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                        EntityId = parameters.EntityId,
                        PropertyName = e.ToString(),
                        Display = string.Format(SharedResources.Resources
                            .PersonCredentialEditor_ExpirationUsageCount_Title),
                        Description = string.Format(SharedResources.Resources
                            .PersonCredentialEditor_ExpirationUsageCount_ToolTip),
                        UniqueResourceName = e.ToString(),
                        PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                        SchemaName = GalaxySMS.Common.Constants.SchemaNames.GCS,
                        TableName = GalaxySMS.Common.Constants.TableNames.PersonCredential,
                        UniquePropertyName = string.Format("{0}:{1}:{2}:{3}", SchemaNames.GCS,
                            TableNames.PersonCredential, e.ToString(), e.ToString()),
                        IsDirty = true,
                        IsActive = true,
                        //UserDefinedDatePropertyRules = new UserDefinedDatePropertyRule()
                        //{
                        //    AllowNull = true,
                        //    IsDirty = true,
                        //}
                    };

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialCardNumber,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.CardNumber.ToString(),
                        string.Format(SharedResources.Resources.CredentialNumericEditor_CardNumber_Title),
                        string.Format(SharedResources.Resources.CredentialNumericEditor_CardNumber_ToolTip),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.Credential);

                    personUserDefinedProperties.Add(personUserDefinedProperty);

                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //Credential26BitFacilityCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.FacilityCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_HID_26Bit_Standard_FacilityCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_26_Bit_Standard_Wiegand_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_HID_26Bit_Standard_FacilityCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.Credential26BitStandard);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //Credential26BitIdCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.IdCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_HID_26Bit_Standard_IdCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_26_Bit_Standard_Wiegand_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_HID_26Bit_Standard_IdCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.Credential26BitStandard);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialHIDCorp1K35BitCompanyCode,        
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.CompanyCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_HID_Corporate1000_35Bit_CompanyCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_HID_Corporate1000_35Bit_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_HID_Corporate1000_35Bit_CompanyCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialCorporate1K35Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialHIDCorp1K35BitIdCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.IdCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_HID_Corporate1000_35Bit_IdCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_HID_Corporate1000_35Bit_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_HID_Corporate1000_35Bit_IdCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialCorporate1K35Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialHIDCorp1K48BitCompanyCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.CompanyCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_HID_Corporate1000_48Bit_CompanyCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_HID_Corporate1000_48Bit_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_HID_Corporate1000_48Bit_CompanyCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialCorporate1K48Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialHIDCorp1K48BitIdCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.IdCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_HID_Corporate1000_48Bit_IdCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_HID_Corporate1000_48Bit_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_HID_Corporate1000_48Bit_IdCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialCorporate1K48Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialHIDH1030237BitIdCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.IdCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_HID_37Bit_H10302_IdCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_HID_37Bit_H10302_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_HID_37Bit_H10302_IdCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialH1030237Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialHIDH1030437BitFacilityCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.FacilityCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_HID_37Bit_H10304_FacilityCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_HID_37Bit_H10304_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_HID_37Bit_H10304_FacilityCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialH1030437Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialHIDH1030437BitIdCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.IdCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_HID_37Bit_H10304_IdCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_HID_37Bit_H10304_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_HID_37Bit_H10304_IdCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialH1030437Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialSWH37BitFacilityCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.FacilityCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_SoftwareHouse_37Bit_FacilityCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_SoftwareHouse_37Bit_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_SoftwareHouse_37Bit_FacilityCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialSoftwareHouse37Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialSWH37BitSiteCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.SiteCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_SoftwareHouse_37Bit_SiteCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_SoftwareHouse_37Bit_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_SoftwareHouse_37Bit_SiteCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialSoftwareHouse37Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialSWH37BitIdCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.IdCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_SoftwareHouse_37Bit_IdCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_SoftwareHouse_37Bit_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_SoftwareHouse_37Bit_IdCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialSoftwareHouse37Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialCypress37BitFacilityCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.FacilityCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_Cypress_37Bit_FacilityCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_Cypress_37Bit_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_Cypress_37Bit_FacilityCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialCypress37Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialCypress37BitIdCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.IdCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_Cypress_37Bit_IdCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_Cypress_37Bit_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_Cypress_37Bit_IdCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialCypress37Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialXceed40BitSiteCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.SiteCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_XceedId_40_Bit_SiteCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_XceedId_40_Bit_Display})",
                        string.Format(SharedResources.Resources
                            .GalaxyCredentialFormat_XceedId_40_Bit_SiteCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialXceedId40Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                //CredentialXceed40BitIdCode,
                try
                {
                    var personUserDefinedProperty = CreateUserDefinedProperty(parameters,
                        GalaxySMS.Common.Enums.CredentialPropertyNames.IdCode.ToString(),
                        $"{SharedResources.Resources.GalaxyCredentialFormat_XceedId_40_Bit_IdCode_Display} - ({SharedResources.Resources.GalaxyCredentialFormat_XceedId_40_Bit_Display})",
                        string.Format(
                            SharedResources.Resources.GalaxyCredentialFormat_XceedId_40_Bit_IdCode_Description),
                        GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                        GalaxySMS.Common.Constants.TableNames.CredentialXceedId40Bit);

                    personUserDefinedProperties.Add(personUserDefinedProperty);
                }
                catch (Exception exception)
                {
                    this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName,
                        exception);
                }

                foreach (var o in personUserDefinedProperties)
                {
                    var existingRecord = personUserDefinedPropertiesFromDB.FirstOrDefault(p =>
                        p.EntityId == o.EntityId && p.PropertyName == o.PropertyName);

                    if (existingRecord == null &&
                        userDefinedPropertyRepository.IsUnique(o))
                    {
                        this.Log().Info($"Adding entity person property {o.Display}");

                        UpdateProperties(o);
                        userDefinedPropertyRepository.Add(o, ApplicationUserSessionHeader, null);
                    }
                }

                foreach (var pc in personTableColumns.Where(o => o.IsComputed == 0))
                {
                    var existingRecord = personUserDefinedPropertiesFromDB.FirstOrDefault(p =>
                        p.EntityId == parameters.EntityId &&
                        p.SchemaName == pc.TableSchema &&
                        p.TableName == pc.TableName &&
                        p.ColumnName == pc.ColumnName);

                    if (existingRecord == null)
                    {
                        var columnName = pc.ColumnName;
                        if (columnName.EndsWith("Uid"))
                            columnName = columnName.Truncate(columnName.Length - 3);

                        var splitColumnName = columnName.SplitAtUpperCaseCharacters();
                        var udf = new UserDefinedProperty()
                        {
                            UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                            SchemaName = pc.TableSchema,
                            TableName = pc.TableName,
                            ColumnName = pc.ColumnName,
                            EntityId = parameters.EntityId,
                            PropertyName = pc.ColumnName,
                            Display = splitColumnName,
                            Description = splitColumnName,
                            UniquePropertyName = string.Format("{0}:{1}:{2}:{3}", pc.TableSchema, pc.TableSchema,
                                pc.ColumnName, pc.ColumnName),
                            UniqueResourceName = string.Format("{0}:{1}:{2}:{3}", pc.TableSchema, pc.TableSchema,
                                pc.ColumnName, pc.ColumnName),
                            PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                            IsActive = true,
                        };


                        if (string.Compare(pc.DataType.ToLower(), "nvarchar") == 0 ||
                            string.Compare(pc.DataType.ToLower(), "varchar") == 0)
                        {
                            udf.PropertyTypeUid = UserDefinedPropertyTypeIds.Text;
                            udf.UserDefinedTextPropertyRules = new UserDefinedTextPropertyRule()
                            {
                                UserDefinedPropertyUid = udf.UserDefinedPropertyUid,
                                MaximumLength = (short)pc.CharacterMaximumLength,
                                MaximumLengthLimit = (short)pc.CharacterMaximumLength,
                                EmptyContent = "~",
                                IsDirty = true,
                            };
                            if (string.Compare(pc.IsNullable.ToLower(), "no") == 0)
                            {
                                udf.UserDefinedTextPropertyRules.IsRequired = true;
                                udf.UserDefinedTextPropertyRules.MinimumLength = 1;
                            }

                            if (udf.PropertyName == "LastName")
                            {
                                udf.UserDefinedTextPropertyRules.IsRequired = true;
                            }

                            UpdateProperties(udf.UserDefinedTextPropertyRules);
                        }
                        else if (string.Compare(pc.DataType.ToLower(), "datetime") == 0 ||
                                 string.Compare(pc.DataType.ToLower(), "date") == 0)
                        {
                            udf.PropertyTypeUid = UserDefinedPropertyTypeIds.Date;
                            udf.UserDefinedDatePropertyRules = new UserDefinedDatePropertyRule()
                            {
                                UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                                DefaultOffsetFromNow = DateTimeOffset.MinValue,
                                EmptyContent = "~",
                                IsDirty = true,
                            };

                            if (string.Compare(pc.IsNullable.ToLower(), "yes") == 0)
                            {
                                udf.UserDefinedDatePropertyRules.AllowNull = true;
                            }

                            UpdateProperties(udf.UserDefinedDatePropertyRules);
                        }
                        else if (string.Compare(pc.DataType.ToLower(), "bit") == 0)
                        {
                            udf.PropertyTypeUid = UserDefinedPropertyTypeIds.Boolean;
                            udf.UserDefinedBooleanPropertyRules = new UserDefinedBooleanPropertyRule()
                            {
                                UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                                TrueDisplay = Boolean.TrueString,
                                TrueDescription = Boolean.TrueString,
                                FalseDisplay = Boolean.FalseString,
                                FalseDescription = Boolean.FalseString,
                                IndeterminateDisplay = SharedResources.Resources.Boolean_Indeterminate_Display,
                                IndeterminateDescription = SharedResources.Resources.Boolean_Indeterminate_Description,
                                IsDirty = true,
                            };

                            if (string.Compare(pc.IsNullable.ToLower(), "yes") == 0)
                            {
                                udf.UserDefinedBooleanPropertyRules.CanBeIndeterminate = true;
                            }

                            UpdateProperties(udf.UserDefinedBooleanPropertyRules);
                        }
                        else if (string.Compare(pc.DataType.ToLower(), "int") == 0 ||
                                 string.Compare(pc.DataType.ToLower(), "smallint") == 0 ||
                                 string.Compare(pc.DataType.ToLower(), "tinyint") == 0 ||
                                 string.Compare(pc.DataType.ToLower(), "bigint") == 0)
                        {
                            udf.PropertyTypeUid = UserDefinedPropertyTypeIds.Number;
                            udf.UserDefinedNumberPropertyRules = new UserDefinedNumberPropertyRule()
                            {
                                UserDefinedPropertyUid = udf.UserDefinedPropertyUid,
                                DefaultValue = 0,
                                EmptyContent = "~",
                                IsDirty = true,
                            };

                            if (string.Compare(pc.DataType.ToLower(), "int") == 0)
                            {
                                udf.UserDefinedNumberPropertyRules.MinimumValue = int.MinValue;
                                udf.UserDefinedNumberPropertyRules.MaximumValue = int.MaxValue;
                            }
                            else if (string.Compare(pc.DataType.ToLower(), "smallint") == 0)
                            {
                                udf.UserDefinedNumberPropertyRules.MinimumValue = short.MinValue;
                                udf.UserDefinedNumberPropertyRules.MaximumValue = short.MaxValue;
                            }
                            else if (string.Compare(pc.DataType.ToLower(), "tinyint") == 0)
                            {
                                udf.UserDefinedNumberPropertyRules.MinimumValue = byte.MinValue;
                                udf.UserDefinedNumberPropertyRules.MaximumValue = byte.MaxValue;
                            }
                            else if (string.Compare(pc.DataType.ToLower(), "bigint") == 0)
                            {
                                udf.UserDefinedNumberPropertyRules.MinimumValue = long.MinValue;
                                udf.UserDefinedNumberPropertyRules.MaximumValue = long.MaxValue;
                            }

                            if (string.Compare(pc.IsNullable.ToLower(), "no") == 0)
                            {
                                udf.UserDefinedNumberPropertyRules.IsRequired = true;
                            }

                            UpdateProperties(udf.UserDefinedNumberPropertyRules);
                        }
                        else if (string.Compare(pc.DataType.ToLower(), "uniqueidentifier") == 0)
                        {
                            udf.PropertyTypeUid = UserDefinedPropertyTypeIds.Guid;
                            udf.UserDefinedGuidPropertyRules = new UserDefinedGuidPropertyRule()
                            {
                                UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                                IsDirty = true,
                            };

                            if (string.Compare(pc.IsNullable.ToLower(), "no") == 0)
                            {
                                udf.UserDefinedGuidPropertyRules.IsRequired = true;
                            }

                            UpdateProperties(udf.UserDefinedGuidPropertyRules);
                        }

                        else
                        {
                            // Default to Text
                            udf.PropertyTypeUid = UserDefinedPropertyTypeIds.Text;
                            udf.UserDefinedTextPropertyRules = new UserDefinedTextPropertyRule()
                            {
                                UserDefinedPropertyUid = udf.UserDefinedPropertyUid,
                                MaximumLength = (short)pc.CharacterMaximumLength,
                                MaximumLengthLimit = (short)pc.CharacterMaximumLength,
                                IsDirty = true,
                            };
                            if (string.Compare(pc.IsNullable.ToLower(), "no") == 0)
                            {
                                udf.UserDefinedTextPropertyRules.IsRequired = true;
                                udf.UserDefinedTextPropertyRules.MinimumLength = 1;
                            }

                            UpdateProperties(udf.UserDefinedTextPropertyRules);

                        }

                        this.Log().Info($"Adding entity person property {udf.Display}");

                        UpdateProperties(udf);
                        userDefinedPropertyRepository.Add(udf, ApplicationUserSessionHeader, null);
                    }
                }

                // Create Region and Site
                var regionRepository = _DataRepositoryFactory.GetDataRepository<IRegionRepository>();
                var siteRepository = _DataRepositoryFactory.GetDataRepository<ISiteRepository>();
                var originalCurrentEntityId = ApplicationUserSessionHeader.CurrentEntityId;

                // Must temporarily override the ApplicationUserSessionHeader.CurrentEntityId value so that the subsequent calls
                // reference the EntityId  of the newly created gcsEntity. Must be sure to restore the original value
                // at the end of this sequence
                ApplicationUserSessionHeader.CurrentEntityId = parameters.EntityId;


                // Create Default roles
                var roleRepository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();
                var roles = roleRepository.GetAllRolesForEntity(parameters.EntityId,
                    new GetParametersWithPhoto() { IncludeMemberCollections = false });

                // Default admin role
                var adminRole = roles.FirstOrDefault(o => o.IsAdministratorRole == true);
                if (adminRole == null)
                {
                    adminRole = new gcsRole()
                    {
                        EntityId = parameters.EntityId,
                        RoleId = GuidUtilities.GenerateComb(),
                        RoleName = GalaxySMS.Resources.Resources.SystemRole_RoleName,
                        RoleDescription = GalaxySMS.Resources.Resources.SystemRole_RoleDescription,
                        IsActive = true,
                        IsDefault = false,
                        IsAuthorized = true,
                        IsAdministratorRole = true,
                        DeviceFilters = new RoleFilters()
                        {
                            IncludeAllRegions = true,
                            IncludeAllSites = true,
                            IncludeAllClusters = true
                        }
                    };

                    if (adminRole.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id)
                        adminRole.RoleId = GalaxySMS.Common.Constants.RoleIds.GalaxySMS_AdministatorId;


                    var permissionsRepository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();
                    var perms = permissionsRepository.GetAll(ApplicationUserSessionHeader,
                        new GetParametersWithPhoto() { IncludeMemberCollections = false });
                    foreach (var p in perms)
                        adminRole.RolePermissions.Add(new gcsRolePermission() { PermissionId = p.PermissionId });
                    UpdateProperties(adminRole);
                    var saveRoleParms = new SaveParameters<gcsRole>() { Data = adminRole };
                    saveRoleParms.Options.Add(new KeyValuePair<string, string>(
                        nameof(GalaxySMS.Common.Enums.InitializingSystemOption.DontValidateAuthorization).ToString(),
                        true.ToString()));
                    adminRole = SaveRole(saveRoleParms);
                    //var savedRole = roleRepository.Add(adminRole, ApplicationUserSessionHeader, null, new SaveParameters());
                }

                if (addDefaultNonAdminRole)
                {
                    var nonAdminRole = roles.FirstOrDefault(o => o.IsAdministratorRole == false);

                    if (nonAdminRole == null)
                    {
                        nonAdminRole = new gcsRole()
                        {
                            EntityId = parameters.EntityId,
                            RoleId = GuidUtilities.GenerateComb(),
                            RoleName = GalaxySMS.Resources.Resources.SystemRole_DefaultRoleName,
                            RoleDescription = GalaxySMS.Resources.Resources.SystemRole_DefaultRoleDescription,
                            IsActive = true,
                            IsDefault = true,
                            IsAuthorized = true,
                            IsAdministratorRole = false,
                            DeviceFilters = new RoleFilters()
                            {
                                IncludeAllRegions = true,
                                IncludeAllSites = true,
                                IncludeAllClusters = true
                            }
                        };

                        if (nonAdminRole.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id)
                            nonAdminRole.RoleId = GalaxySMS.Common.Constants.RoleIds.GalaxySMS_NonAdministatorId;

                        var permissionsRepository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();
                        var perms = permissionsRepository.GetAll(ApplicationUserSessionHeader,
                            new GetParametersWithPhoto() { IncludeMemberCollections = false });
                        foreach (var p in perms)
                            nonAdminRole.RolePermissions.Add(new gcsRolePermission() { PermissionId = p.PermissionId });
                        UpdateProperties(nonAdminRole);
                        var saveRoleParms = new SaveParameters<gcsRole>() { Data = nonAdminRole };
                        saveRoleParms.Options.Add(new KeyValuePair<string, string>(
                            nameof(GalaxySMS.Common.Enums.InitializingSystemOption.DontValidateAuthorization).ToString(),
                            true.ToString()));
                        nonAdminRole = SaveRole(saveRoleParms);
                    }
                }

                var getParams = new GetParametersWithPhoto() { UniqueId = parameters.EntityId, IncludePhoto = false };
                var sites = siteRepository.GetAllSitesForEntity(ApplicationUserSessionHeader, getParams);
                var regions = regionRepository.GetAllRegionsForEntity(this.ApplicationUserSessionHeader, getParams);

                var s = sites.FirstOrDefault();
                var r = regions.FirstOrDefault();

                if (s == null)
                {   // There are no sites
                    if (r == null)
                    {   // If there is no region, create one
                        // Create default Region
                        var rUid = GuidUtilities.GenerateComb();
                        if (parameters.EntityId == EntityIds.GalaxySMS_DefaultEntity_Id)
                            rUid = RegionIds.Default;

                        r = new Region()
                        {
                            RegionUid = rUid,
                            EntityId = parameters.EntityId,
                            RegionName = SharedResources.Resources.Region_DefaultName,
                            RegionId = SharedResources.Resources.Region_DefaultKey
                        };
                        if (adminRole != null)
                            r.RoleIds.Add(adminRole.RoleId);

                        this.Log().Info($"Creating region {r.RegionName}...");

                        UpdateProperties(r);
                        regionRepository.Add(r, this.ApplicationUserSessionHeader, new SaveParameters() { });
                    }

                    var countryRepository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                    var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.Name);
                    var c = countryRepository.GetByIso(this.ApplicationUserSessionHeader, new GetParametersWithPhoto()
                    {
                        GetString = regionInfo.TwoLetterISORegionName,
                        IncludePhoto = false,
                        IncludeMemberCollections = false
                    });
                    if (c != null)
                    {
                        var stateProvinceRepository = _DataRepositoryFactory.GetDataRepository<IStateProvinceRepository>();
                        var stateProvinces = stateProvinceRepository.GetAllForCountry(this.ApplicationUserSessionHeader, new GetParametersWithPhoto()
                        {
                            UniqueId = c.CountryUid,
                            IncludePhoto = false,
                            IncludeMemberCollections = false
                        });

                        var stateProvince = stateProvinces.FirstOrDefault();
                        if (stateProvince != null)
                        {
                            var sUid = GuidUtilities.GenerateComb();
                            if (r.RegionUid == RegionIds.Default)
                                sUid = SiteIds.Default;
                            // Create a site using the region
                            s = new Site()
                            {
                                SiteUid = sUid,
                                EntityId = parameters.EntityId,
                                RegionUid = r.RegionUid,
                                SiteName = SharedResources.Resources.Site_DefaultName,
                                SiteId = SharedResources.Resources.Site_DefaultKey,
                                Address = new Address()
                                {
                                    AddressUid = GuidUtilities.GenerateComb(),
                                    StreetAddress = SharedResources.Resources.SiteAddress_DefaultStreet,
                                    PostalCode = SharedResources.Resources.SiteAddress_DefaultPostalCode,
                                    City = SharedResources.Resources.SiteAddress_DefaultCity,
                                    StateProvinceUid = stateProvince.StateProvinceUid
                                }
                            };
                            if (adminRole != null)
                                s.RoleIds.Add(adminRole.RoleId);

                            UpdateProperties(s);
                            this.Log().Info($"Creating site {s.SiteName}...");

                            siteRepository.Add(s, this.ApplicationUserSessionHeader, new SaveParameters() { });
                        }
                    }
                }

                // Create default credential format entity maps
                var credentialFormatRepository = _DataRepositoryFactory.GetDataRepository<ICredentialFormatRepository>();
                var credentialFormatsForEntity = credentialFormatRepository.GetAllCredentialFormatsForEntity(ApplicationUserSessionHeader, getParams);
                if (!credentialFormatsForEntity.Any())
                {   // if there are no credential formats mapped to the entity, create mappings for all of them
                    var credentialFormats = credentialFormatRepository.GetAll(ApplicationUserSessionHeader, getParams);
                    var credentialFormatsEntityMapRepository = _DataRepositoryFactory.GetDataRepository<ICredentialFormatEntityMapRepository>();
                    foreach (var cf in credentialFormats)
                    {
                        var cfEntityMap = new CredentialFormatEntityMap()
                        {
                            CredentialFormatEntityMapUid = GuidUtilities.GenerateComb(),
                            EntityId = parameters.EntityId,
                            CredentialFormatUid = cf.CredentialFormatUid,
                            IsAllowed = true,
                        };
                        UpdateProperties(cfEntityMap);
                        var updatedCfEntityMap = credentialFormatsEntityMapRepository.Add(cfEntityMap, ApplicationUserSessionHeader, null);
                    }

                }

                // Create default person record types
                var personRecordTypeRepository = _DataRepositoryFactory.GetDataRepository<IPersonRecordTypeRepository>();
                var personRecordTypesForEntity = personRecordTypeRepository.GetAllPersonRecordTypesForEntity(ApplicationUserSessionHeader, getParams);
                var defaultRecordTypeUid = Guid.Empty;

                if (!personRecordTypesForEntity.Any())
                {   // if there are no record types for the entity, create a few reasonable defaults
                    var prt = new PersonRecordType()
                    {
                        PersonRecordTypeUid = GuidUtilities.GenerateComb(),
                        EntityId = parameters.EntityId,
                        Display = GalaxySMS.Resources.Resources.PersonRecordType_Employee_Display,
                        Description = GalaxySMS.Resources.Resources.PersonRecordType_Employee_Description

                    };
                    UpdateProperties(prt);
                    // use employee as default type
                    defaultRecordTypeUid = prt.PersonRecordTypeUid;
                    var updatedPrt = personRecordTypeRepository.Add(prt, ApplicationUserSessionHeader, null);

                    prt = new PersonRecordType()
                    {
                        PersonRecordTypeUid = GuidUtilities.GenerateComb(),
                        EntityId = parameters.EntityId,
                        Display = GalaxySMS.Resources.Resources.PersonRecordType_Visitor_Display,
                        Description = GalaxySMS.Resources.Resources.PersonRecordType_Visitor_Description

                    };
                    UpdateProperties(prt);
                    updatedPrt = personRecordTypeRepository.Add(prt, ApplicationUserSessionHeader, null);


                    prt = new PersonRecordType()
                    {
                        PersonRecordTypeUid = GuidUtilities.GenerateComb(),
                        EntityId = parameters.EntityId,
                        Display = GalaxySMS.Resources.Resources.PersonRecordType_Contractor_Display,
                        Description = GalaxySMS.Resources.Resources.PersonRecordType_Contractor_Description

                    };
                    UpdateProperties(prt);
                    updatedPrt = personRecordTypeRepository.Add(prt, ApplicationUserSessionHeader, null);


                    prt = new PersonRecordType()
                    {
                        PersonRecordTypeUid = GuidUtilities.GenerateComb(),
                        EntityId = parameters.EntityId,
                        Display = GalaxySMS.Resources.Resources.PersonRecordType_Vendor_Display,
                        Description = GalaxySMS.Resources.Resources.PersonRecordType_Vendor_Description

                    };
                    UpdateProperties(prt);
                    updatedPrt = personRecordTypeRepository.Add(prt, ApplicationUserSessionHeader, null);
                }
                else
                {
                    var empType = personRecordTypesForEntity.FirstOrDefault(o =>
                        o.Display == GalaxySMS.Resources.Resources.PersonRecordType_Employee_Display);
                    if (empType != null)
                        defaultRecordTypeUid = empType.PersonRecordTypeUid;
                }

                if (defaultRecordTypeUid != Guid.Empty)
                {
                    // Now make sure there is a default PersonRecordType setting defined
                    var defaultRecordType = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                        gcsSettingGroup.gcsEntity, gcsSettingSubGroup.Person, gcsSettingKey.DefaultPersonRecordTypeUid,
                        defaultRecordTypeUid, true, ApplicationUserSessionHeader);
                }

                var settingAG1 = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.AccessProfile, gcsSettingKey.ControlsAccessGroup1,
                    true, true, ApplicationUserSessionHeader);

                var settingAG2 = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.AccessProfile, gcsSettingKey.ControlsAccessGroup2,
                    true, true, ApplicationUserSessionHeader);

                var settingAG3 = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.AccessProfile, gcsSettingKey.ControlsAccessGroup3,
                    false, true, ApplicationUserSessionHeader);

                var settingAG4 = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.AccessProfile, gcsSettingKey.ControlsAccessGroup4,
                    false, true, ApplicationUserSessionHeader);

                var settingIOG1 = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.AccessProfile, gcsSettingKey.ControlsIOGroup1,
                    true, true, ApplicationUserSessionHeader);

                var settingIOG2 = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.AccessProfile, gcsSettingKey.ControlsIOGroup2,
                    true, true, ApplicationUserSessionHeader);

                var settingIOG3 = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.AccessProfile, gcsSettingKey.ControlsIOGroup3,
                    false, true, ApplicationUserSessionHeader);

                var settingIOG4 = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.AccessProfile, gcsSettingKey.ControlsIOGroup4,
                    false, true, ApplicationUserSessionHeader);

                var settingPidPrefix = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.PersonId, gcsSettingKey.Prefix,
                    DefaultSettingValues.PersonIdPrefix, true, ApplicationUserSessionHeader);

                var settingPidSuffix = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.PersonId, gcsSettingKey.Suffix,
                    DefaultSettingValues.PersonIdSuffix, true, ApplicationUserSessionHeader);

                var settingPidUniquePartLength = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.PersonId, gcsSettingKey.UniquePartLength,
                    DefaultSettingValues.PersonIdDefaultUniquePartLength, true, ApplicationUserSessionHeader);

                var settingPidUseRandomizedString = gcsSettingsRepository.GetByUniqueKey(parameters.EntityId,
                    gcsSettingGroup.gcsEntity, gcsSettingSubGroup.PersonId, gcsSettingKey.UseRandomizedString,
                    DefaultSettingValues.PersonIdUseRandomizedString, true, ApplicationUserSessionHeader);


                // Now see about Day Types
                var dayTypeRepository = _DataRepositoryFactory.GetDataRepository<IDayTypeRepository>();

                var dayTypes = dayTypeRepository.GetAllDayTypesForEntity(ApplicationUserSessionHeader, getParams);
                if (!dayTypes.Items.Any())
                {
                    var systemManager = new SystemManagement(this._DataRepositoryFactory, _BusinessEngineFactory);
                    systemManager.ApplicationUserSessionHeader.CurrentEntityId = parameters.EntityId;
                    var saveParameters = new SaveParameters<DayType>()
                    { CurrentEntityId = parameters.EntityId };
                    saveParameters.DoNotValidateAuthorization = true;
                    systemManager.EnsureDefaultDayTypesExistForEntity(saveParameters);
                }

                // Restore the original CurrentEntityId value
                ApplicationUserSessionHeader.CurrentEntityId = originalCurrentEntityId;

                this.Log().Info($"Creating Entity Defaults completed...");

                return true;
            });

        }

        private static UserDefinedProperty CreateUserDefinedProperty(gcsEntity parameters, string propertyName, string display, string description, Guid propertyTypeUid, string tableName)
        {
            var personUserDefinedProperty = new UserDefinedProperty()
            {
                UserDefinedPropertyUid = GuidUtilities.GenerateComb(),
                EntityId = parameters.EntityId,
                PropertyName = $"{tableName}.{propertyName}",
                Display = display,
                Description = description,
                UniqueResourceName = $"{tableName}.{propertyName}",
                PropertyTypeUid = propertyTypeUid,
                PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                SchemaName = GalaxySMS.Common.Constants.SchemaNames.GCS,
                TableName = tableName,
                UniquePropertyName = $"{SchemaNames.GCS}:{tableName}:{propertyName}:{propertyName}",
                IsDirty = true,
                IsActive = true,
                //UserDefinedDatePropertyRules = new UserDefinedDatePropertyRule()
                //{
                //    AllowNull = true,
                //    IsDirty = true,
                //}
            };
            return personUserDefinedProperty;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteEntityByPk(DeleteParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (parameters.UniqueId == Guid.Empty ||
                parameters.UniqueId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id ||
                parameters.UniqueId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id)
                    throw new UnauthorizedAccessException();

                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.EntityCanDeleteId);

                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                //if (repository.IsReferenced(entityId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsEntity with EntityId of '{0}' cannot be deleted because it is referenced.", entityId));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}
                if (repository.CanDelete(parameters.UniqueId) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsEntity with EntityId of '{0}' cannot be deleted because it is referenced.", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return repository.DeleteEntity(parameters.UniqueId, ApplicationUserSessionHeader, parameters);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteEntity(DeleteParameters<gcsEntity> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (parameters.UniqueId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id ||
                    parameters.Data.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id ||
                    parameters.UniqueId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id ||
                    parameters.Data.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id)
                    throw new UnauthorizedAccessException();

                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.EntityCanDeleteId);

                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                //if (repository.IsReferenced(entityId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsEntity with EntityId of '{0}' cannot be deleted because it is referenced.", entityId));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}
                if (repository.CanDelete(parameters.Data.EntityId) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsEntity '{0}' cannot be deleted because it is referenced.", parameters.Data.EntityName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                return repository.Remove((gcsEntity)parameters.Data, ApplicationUserSessionHeader);
            });
        }

        public bool IsEntityReferenced(Guid entityId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                bReturn = repository.IsReferenced(entityId);
                return bReturn;
            });
        }

        public bool IsEntityUnique(gcsEntity entity)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                bReturn = repository.IsUnique(entity);
                return bReturn;
            });
        }

        public EntityEditingData GetEntityEditingData(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var editingData = new EntityEditingData();
                ValidateAuthorizationAndSetupOperation(parameters,
                    PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId);

                if (!parameters.IsExcluded(nameof(EntityEditingData.TimeZones)))
                {
                    var timeZoneRepository = _DataRepositoryFactory.GetDataRepository<ITimeZoneRepository>();
                    var timeZones = timeZoneRepository.GetAll(ApplicationUserSessionHeader, parameters).ToCollection();
                    foreach (var tz in timeZones)
                    {
                        editingData.TimeZones.Add(new TimeZoneListItem()
                        {
                            Id = tz.Id,
                            DisplayName = tz.DisplayName
                        });
                    }
                }

                return editingData;
            });
        }

        public EntityMapPermissionLevel[] GetEntityMapPermissionLevels(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IEntityMapPermissionLevelRepository>();

                var entities = repository.Get(ApplicationUserSessionHeader, parameters);

                return entities.ToArray();
            });

        }

        public ArrayResponse<gcsEntityExBasic> GetEntityList(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var items = new List<gcsEntityExBasic>();
                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;

                var entities = repository.GetPaged(ApplicationUserSessionHeader, parameters);
                foreach (var e in entities.Items)
                {
                    var r = new gcsEntityExBasic(e);
                    if (includeCounts)
                        r.Counts = repository.GetNewestCountsForEntity(r.EntityId);
                    items.Add(r);
                }

                var result = new ArrayResponse<gcsEntityExBasic>()
                {
                    Items = items.ToArray(),
                    PageItemCount = entities.PageItemCount,
                    PageNumber = entities.PageNumber,
                    PageSize = entities.PageSize,
                    TotalItemCount = entities.TotalItemCount,
                    TotalPageCount = entities.TotalPageCount
                };
                return result;
            });
        }

        public ArrayResponse<gcsEntityExBasic> GetEntityListForUser(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                if (parameters.GetGuid != Guid.Empty)
                {
                    parameters.CurrentEntityId = parameters.GetGuid;
                    ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId);
                }

                var items = new List<gcsEntityExBasic>();
                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;
                var entities = repository.GetEntitiesForUserPaged(parameters.UniqueId, ApplicationUserSessionHeader, parameters);

                foreach (var e in entities.Items)
                {
                    var r = new gcsEntityExBasic(e);
                    if (includeCounts)
                        r.Counts = repository.GetNewestCountsForEntity(r.EntityId);
                    items.Add(r);
                }

                var result = new ArrayResponse<gcsEntityExBasic>()
                {
                    Items = items.ToArray(),
                    PageItemCount = entities.PageItemCount,
                    PageNumber = entities.PageNumber,
                    PageSize = entities.PageSize,
                    TotalItemCount = entities.TotalItemCount,
                    TotalPageCount = entities.TotalPageCount
                };
                return result;
            });
        }

        public ArrayResponse<gcsEntityExBasic> GetEntityListByName(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var items = new List<gcsEntityExBasic>();
                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;
                var entities = repository.GetByNamePaged(ApplicationUserSessionHeader, parameters);

                foreach (var e in entities.Items)
                {
                    var r = new gcsEntityExBasic(e);
                    if (includeCounts)
                        r.Counts = repository.GetNewestCountsForEntity(r.EntityId);
                    items.Add(r);
                }

                var result = new ArrayResponse<gcsEntityExBasic>()
                {
                    Items = items.ToArray(),
                    PageItemCount = entities.PageItemCount,
                    PageNumber = entities.PageNumber,
                    PageSize = entities.PageSize,
                    TotalItemCount = entities.TotalItemCount,
                    TotalPageCount = entities.TotalPageCount
                };
                return result;
            });
        }

        public ArrayResponse<gcsEntityEx> GetEntitiesByName(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var entities = repository.GetByNamePaged(ApplicationUserSessionHeader, parameters);
                var items = new List<gcsEntityEx>();
                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;

                foreach (var e in entities.Items)
                {
                    var r = new gcsEntityEx(e);
                    if (includeCounts)
                        r.Counts = repository.GetNewestCountsForEntity(e.EntityId);
                    items.Add(r);
                }

                var result = new ArrayResponse<gcsEntityEx>()
                {
                    Items = items.ToArray(),
                    PageItemCount = entities.PageItemCount,
                    PageNumber = entities.PageNumber,
                    PageSize = entities.PageSize,
                    TotalItemCount = entities.TotalItemCount,
                    TotalPageCount = entities.TotalPageCount
                };
                return result;
            });

        }

        public ArrayResponse<gcsEntityExBasic> GetEntityListByDescription(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var items = new List<gcsEntityExBasic>();
                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;
                var entities = repository.GetByDescriptionPaged(ApplicationUserSessionHeader, parameters);

                foreach (var e in entities.Items)
                {
                    var r = new gcsEntityExBasic(e);
                    if (includeCounts)
                        r.Counts = repository.GetNewestCountsForEntity(r.EntityId);
                    items.Add(r);
                }

                var result = new ArrayResponse<gcsEntityExBasic>()
                {
                    Items = items.ToArray(),
                    PageItemCount = entities.PageItemCount,
                    PageNumber = entities.PageNumber,
                    PageSize = entities.PageSize,
                    TotalItemCount = entities.TotalItemCount,
                    TotalPageCount = entities.TotalPageCount
                };
                return result;
            });

        }

        public ArrayResponse<gcsEntityEx> GetEntitiesByDescription(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var entities = repository.GetByDescriptionPaged(ApplicationUserSessionHeader, parameters);
                var items = new List<gcsEntityEx>();
                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;

                foreach (var e in entities.Items)
                {
                    var r = new gcsEntityEx(e);
                    if (includeCounts)
                        r.Counts = repository.GetNewestCountsForEntity(e.EntityId);
                    items.Add(r);
                }

                var result = new ArrayResponse<gcsEntityEx>()
                {
                    Items = items.ToArray(),
                    PageItemCount = entities.PageItemCount,
                    PageNumber = entities.PageNumber,
                    PageSize = entities.PageSize,
                    TotalItemCount = entities.TotalItemCount,
                    TotalPageCount = entities.TotalPageCount
                };
                return result;
            });

        }

        public ArrayResponse<gcsEntityExBasic> GetEntityListByNameOrDescription(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var items = new List<gcsEntityExBasic>();
                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;
                //var entities = repository.GetByNameOrDescriptionPaged(ApplicationUserSessionHeader, parameters);
                var entities = repository.GetEntitiesForUserPaged(UserSessionToken.UserData.UserId,
                    ApplicationUserSessionHeader, parameters);
                foreach (var e in entities.Items)
                {
                    var r = new gcsEntityExBasic(e);
                    if (includeCounts)
                        r.Counts = repository.GetNewestCountsForEntity(r.EntityId);
                    items.Add(r);
                }
                var result = new ArrayResponse<gcsEntityExBasic>()
                {
                    Items = items.ToArray(),
                    PageItemCount = entities.PageItemCount,
                    PageNumber = entities.PageNumber,
                    PageSize = entities.PageSize,
                    TotalItemCount = entities.TotalItemCount,
                    TotalPageCount = entities.TotalPageCount
                };
                return result;
            });

        }

        public ArrayResponse<gcsEntityEx> GetEntitiesByNameOrDescription(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                //var entities = repository.GetByNameOrDescriptionPaged(ApplicationUserSessionHeader, parameters);
                var entities = repository.GetEntitiesForUserPaged(UserSessionToken.UserData.UserId,
                    ApplicationUserSessionHeader, parameters);
                var items = new List<gcsEntityEx>();
                var includeCounts = false;
                var includeCountsOption = parameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
                if (includeCountsOption.HasValue)
                    includeCounts = includeCountsOption.Value;

                foreach (var e in entities.Items)
                {
                    var r = new gcsEntityEx(e);
                    if (includeCounts)
                        r.Counts = repository.GetNewestCountsForEntity(e.EntityId);
                    items.Add(r);
                }

                var result = new ArrayResponse<gcsEntityEx>()
                {
                    Items = items.ToArray(),
                    PageItemCount = entities.PageItemCount,
                    PageNumber = entities.PageNumber,
                    PageSize = entities.PageSize,
                    TotalItemCount = entities.TotalItemCount,
                    TotalPageCount = entities.TotalPageCount
                };
                return result;
            });

        }
        public gcsEntityCounts UpdateCountsForEntity(Guid entityId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var counts = repository.UpdateCountsForEntity(entityId);

                return counts;
            });

        }

        #endregion

        #region Language Operations
        public gcsLanguage[] GetAllLanguages()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();

                var languages = repository.Get(ApplicationUserSessionHeader, null);

                return languages.ToArray();
            });
        }

        public gcsLanguage[] GetAllLanguagesForBase(string baseLanguageCode)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();

                IEnumerable<gcsLanguage> entities = repository.GetAllLanguagesForBase(baseLanguageCode);

                return entities.ToArray();
            });
        }

        public gcsLanguage GetLanguage(Guid languageId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();

                var entity = repository.Get(languageId, ApplicationUserSessionHeader, null);
                if (entity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsLanguage with ID of {0} not found", languageId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return entity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsLanguage SaveLanguage(SaveParameters<gcsLanguage> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();

                gcsLanguage updatedLanguage = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("gcsLanguage with '{0} ({1})' cannot be saved because it is a duplicate.", parameters.Data.LanguageName, parameters.Data.CultureName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.LanguageId == Guid.Empty)
                {
                    parameters.Data.LanguageId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.LanguageId) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding Language - {parameters.Data.LanguageName}.");
                    updatedLanguage = repository.Add(parameters.Data, ApplicationUserSessionHeader, null);
                }
                else
                {
                    updatedLanguage = repository.Update(parameters.Data, ApplicationUserSessionHeader, null);
                }

                return updatedLanguage;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsPermissionType SavePermissionType(SaveParameters<gcsPermissionType> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionTypeRepository>();

                gcsPermissionType updatedEntity = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("gcsPermissionType with '{0} ({1})' cannot be saved because it is a duplicate.", parameters.Data.Display, parameters.Data.PermissionTypeCode));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.PermissionTypeId == Guid.Empty)
                {
                    parameters.Data.PermissionTypeId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.PermissionTypeId) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding PermissionType - {parameters.Data.Display}.");
                    updatedEntity = repository.Add(parameters.Data, ApplicationUserSessionHeader, null);
                }
                else
                {
                    updatedEntity = repository.Update(parameters.Data, ApplicationUserSessionHeader, null);
                }

                return updatedEntity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteLanguageByPk(Guid languageId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();

                //if (repository.IsReferenced(languageId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsLanguage with LanguageId of '{0}' cannot be deleted because it is referenced.", languageId));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}
                if (repository.CanDelete(languageId) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsLanguage with LanguageId of '{0}' cannot be deleted because it is referenced.", languageId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    return repository.Remove(languageId, ApplicationUserSessionHeader);
                }

            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteLanguage(gcsLanguage language)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();

                //if (repository.IsReferenced(language.LanguageId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsLanguage '{0}' cannot be deleted because it is referenced.", language.LanguageName));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}

                if (repository.CanDelete(language.LanguageId) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsLanguage '{0}' cannot be deleted because it is referenced.", language.LanguageName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    return repository.Remove(language, ApplicationUserSessionHeader);
                }

            });
        }
        public bool IsLanguageReferenced(Guid languageId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();

                bReturn = repository.IsReferenced(languageId);
                return bReturn;
            });
        }

        public bool IsLanguageUnique(gcsLanguage language)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();

                bReturn = repository.IsUnique(language);
                return bReturn;
            });
        }
        #endregion

        #region Application Operations

        public gcsApplication[] GetAllApplications()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();

                IEnumerable<gcsApplication> applications = repository.Get(ApplicationUserSessionHeader, null);
                var results = applications.ToArray();
                return results;
            });
        }

        public gcsApplicationBasic[] GetAllApplicationBasic(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();

                IEnumerable<gcsApplicationBasic> applications = repository.GetAllApplicationsBasic(parameters, ApplicationUserSessionHeader);
                var results = applications.ToArray();
                return results;
            });
        }

        public gcsApplication[] GetAllApplicationsForEntity(Guid entityId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();

                IEnumerable<gcsApplication> applications = repository.GetAllApplicationsForEntity(entityId, null);

                return applications.ToArray();
            });
        }

        public gcsApplication GetApplication(Guid applicationId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();

                gcsApplication entity = repository.Get(applicationId, ApplicationUserSessionHeader, null);
                if (entity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsApplication with ID of {0} not found", applicationId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return entity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsApplication SaveApplication(SaveParameters<gcsApplication> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();

                gcsApplication updatedObject = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    var ex = new DuplicateIndexException(string.Format(
                                "gcsApplication with Name of '{0}' cannot be saved because it is a duplicate.",
                                parameters.Data.ApplicationName));
                    var detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                bool bAdding = false;

                //var systemRoleId = parameters.Data.SystemRoleId;
                var languageId = parameters.Data.LanguageId;

                if (parameters.Data.ApplicationId == Guid.Empty)
                {
                    bAdding = true;
                    parameters.Data.ApplicationId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                else
                {
                    bool bExists = repository.DoesExist(parameters.Data.ApplicationId);
                    if (bExists == false)
                        bAdding = true;
                }

                if (bAdding == true)
                {
                    //parameters.Data.SystemRoleId = null;
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding Application - {parameters.Data.ApplicationName}.");
                    updatedObject = repository.Add(parameters.Data, ApplicationUserSessionHeader, null);
                }
                else
                {
                    updatedObject = repository.Update(parameters.Data, ApplicationUserSessionHeader, null);
                }

                if (!parameters.Ignore(nameof(parameters.Data.PermissionCategories)))
                {
                    var permissionCategoryRepository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();
                    foreach (var permissionCategory in parameters.Data.PermissionCategories)
                    {
                        if (permissionCategoryRepository.DoesExist(permissionCategory.PermissionCategoryId) == false)
                        {
                            permissionCategory.ApplicationId = updatedObject.ApplicationId;
                            SavePermissionCategory(new SaveParameters<gcsPermissionCategory>(permissionCategory, parameters));
                        }
                    }
                }

                //if (!parameters.Ignore(nameof(parameters.Data.AllRoles)))
                //{
                //    var roleRepository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();
                //    foreach (gcsRole role in parameters.Data.AllRoles)
                //    {
                //        if (roleRepository.DoesExist(role.RoleId) == false)
                //        {
                //            role.EntityId = updatedObject.ApplicationId;
                //            SaveRole(new SaveParameters<gcsRole>(role, parameters));
                //        }
                //    }
                //}

                //if (updatedObject.SystemRoleId != systemRoleId && systemRoleId != null)
                //{
                //    updatedObject.SystemRoleId = systemRoleId;
                //    updatedObject.LanguageId = languageId;
                //    updatedObject = repository.Update(updatedObject, ApplicationUserSessionHeader, null, null);
                //}
                return updatedObject;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteApplicationByPk(Guid applicationId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();

                //if (repository.IsReferenced(applicationId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsApplication with ApplicationId of '{0}' cannot be deleted because it is referenced.", applicationId));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}
                if (repository.CanDelete(applicationId) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsApplication with ApplicationId of '{0}' cannot be deleted because it is referenced.", applicationId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    return repository.Remove(applicationId, ApplicationUserSessionHeader);
                }
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteApplication(gcsApplication application)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();

                //if (repository.IsReferenced(application.ApplicationId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsApplication '{0}' cannot be deleted because it is referenced.", application.ApplicationName));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}
                if (repository.CanDelete(application.ApplicationId) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsApplication '{0}' cannot be deleted because it is referenced.", application.ApplicationName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    return repository.Remove(application, ApplicationUserSessionHeader);
                }
            });
        }

        public bool IsApplicationReferenced(Guid applicationId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                IGcsApplicationRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();

                bReturn = repository.IsReferenced(applicationId);
                return bReturn;
            });
        }

        public bool IsApplicationUnique(gcsApplication application)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                IGcsApplicationRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();

                bReturn = repository.IsUnique(application);
                return bReturn;
            });
        }

        public bool IsApplicationInDatabase(Guid applicationId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                IGcsApplicationRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();

                bReturn = repository.DoesExist(applicationId);
                return bReturn;
            });
        }

        public void SaveApplicationAuditData(SaveParameters<gcsApplicationAudit> parameters)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationAuditRepository>();
                repository.InsertEntity(parameters.Data, ApplicationUserSessionHeader);
            });
        }
        #endregion

        #region Role Operations

        public ArrayResponse<gcsRole> GetAllRoles(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsRoleRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

                var roles = repository.GetPaged(ApplicationUserSessionHeader, parameters);

                return (ArrayResponse<gcsRole>)roles;
            });
        }

        public ArrayResponse<gcsRole> GetAllRolesForEntity(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                parameters.CurrentEntityId = parameters.UniqueId;

                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.RoleCanViewId);

                IGcsRoleRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

                var roles = repository.GetAllRolesForEntityPaged(parameters.UniqueId, parameters, ApplicationUserSessionHeader.UserId);

                return (ArrayResponse<gcsRole>)roles;
            });
        }

        public gcsRole GetRole(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsRoleRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();
                var entityId = repository.GetEntityId(parameters.UniqueId);
                if (entityId == Guid.Empty)
                {
                    NotFoundException ex =
                        new NotFoundException($"{nameof(gcsRole)} with {nameof(gcsRole.RoleId)} of {parameters.UniqueId} not found");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                parameters.CurrentEntityId = entityId;
                if (!parameters.DoNotValidateAuthorization)
                    ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.RoleCanViewId);

                gcsRole role = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, parameters);
                if (role == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsRole with ID of {0} not found", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return role;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsRole SaveRole(SaveParameters<gcsRole> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsRoleRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

                if (parameters.Data.EntityId == Guid.Empty)
                    parameters.Data.EntityId = ApplicationUserSessionHeader.CurrentEntityId;

                parameters.CurrentEntityId = parameters.Data.EntityId;
                gcsRole existingRole = null;

                if (parameters.Data.RoleId != Guid.Empty)
                    existingRole = repository.Get(parameters.Data.RoleId, ApplicationUserSessionHeader, new GetParametersWithPhoto());

                var dontValidateAuthorization = parameters.OptionValue<bool>(GalaxySMS.Common.Enums.InitializingSystemOption.DontValidateAuthorization.ToString());
                if (dontValidateAuthorization == false)
                {
                    if (parameters.Data.RoleId == Guid.Empty)
                        ValidateAuthorizationAndSetupOperation(parameters, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.RoleCanAddId);
                    else
                    {
                        existingRole = repository.Get(parameters.Data.RoleId, ApplicationUserSessionHeader,
                            new GetParametersWithPhoto());
                        if (existingRole != null)
                            ValidateAuthorizationAndSetupOperation(parameters, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.RoleCanUpdateId);
                        else
                        {
                            ValidateAuthorizationAndSetupOperation(parameters, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.RoleCanAddId);
                        }
                    }
                }

                gcsRole updatedRole = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            string.Format("gcsRole with Name of '{0}' cannot be saved because it is a duplicate.",
                                parameters.Data.RoleName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                // If user does not have administrator privs to the entity, they cannot save (add or update) a role that has IsAdministratorRole=true, 
                // unless the role exists already and already has IsAdministrator = true
                if (!dontValidateAuthorization)
                {
                    if (existingRole == null)
                    {
                        if (parameters.Data.IsAdministratorRole &&
                            !DoesUserHaveAdminAuthorizationToEntity(ApplicationUserSessionHeader.UserId,
                                parameters.Data.EntityId))
                        {
                            throw new UnauthorizedAccessException(
                                $"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAdminPermissionsToEntity} {parameters.Data.EntityId}");
                        }
                    }
                    else
                    {
                        if (parameters.Data.IsAdministratorRole && !existingRole.IsAdministratorRole &&
                            !DoesUserHaveAdminAuthorizationToEntity(ApplicationUserSessionHeader.UserId,
                                parameters.Data.EntityId))
                        {
                            throw new UnauthorizedAccessException(
                                $"{MagicExceptionStrings.forbidden}. {Resources.Resources.ExceptionMessage_UserDoesNotHaveAdminPermissionsToEntity} '{parameters.Data.EntityId}'");
                        }
                    }
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.RoleId == Guid.Empty)
                {
                    parameters.Data.RoleId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.RoleId) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding Role - {parameters.Data.RoleName}.");
                    updatedRole = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedRole = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                if (!parameters.Ignore(nameof(parameters.Data.RolePermissions)))
                {
                    var rolePermissionRepository = _DataRepositoryFactory.GetDataRepository<IGcsRolePermissionRepository>();
                    var permissionRepository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                    var existingRolePermissions = rolePermissionRepository.GetAllForRole(updatedRole.RoleId);
                    var deleteTheseRolePermissions = existingRolePermissions.Where(rp => parameters.Data.RolePermissions.All(rp2 => rp2.PermissionId != rp.PermissionId));
                    foreach (var rolePermission in deleteTheseRolePermissions)
                    {
                        if (!dontValidateAuthorization && !DoesUserHavePermission(parameters, rolePermission.PermissionId))
                        {
                            var permission = permissionRepository.Get(rolePermission.PermissionId, ApplicationUserSessionHeader, null);
                            throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {string.Format(Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissionsToDeleteRolePermissions, permission?.PermissionName, rolePermission.PermissionId)}");
                        }
                        rolePermissionRepository.Remove(rolePermission, ApplicationUserSessionHeader);
                    }

                    if (parameters.Data.IsAdministratorRole)
                    {
                        var tempPerms = parameters.Data.RolePermissions.ToList();
                        var perms = permissionRepository.GetAll(ApplicationUserSessionHeader,
                            new GetParametersWithPhoto());
                        foreach (var p in perms)
                        {
                            var rp = parameters.Data.RolePermissions.FirstOrDefault(o =>
                                o.PermissionId == p.PermissionId);
                            if (rp == null)
                                tempPerms.Add(new gcsRolePermission() { PermissionId = p.PermissionId });
                        }

                        parameters.Data.RolePermissions = tempPerms.ToCollection();
                    }

                    var x = 0;
                    foreach (var rolePermission in parameters.Data.RolePermissions)
                    {
                        var existingRolePermission =
                            existingRolePermissions.FirstOrDefault(o => o.PermissionId == rolePermission.PermissionId);
                        if (existingRolePermission == null)
                        {
                            if (rolePermission.RolePermissionId == Guid.Empty)
                                rolePermission.RolePermissionId = GuidUtilities.GenerateComb(); //Guid.NewGuid();

                            if (!dontValidateAuthorization && !DoesUserHavePermission(parameters, rolePermission.PermissionId))
                            {
                                var permission = permissionRepository.Get(rolePermission.PermissionId, ApplicationUserSessionHeader, null);
                                throw new UnauthorizedAccessException($"{MagicExceptionStrings.forbidden}. {string.Format(Resources.Resources.ExceptionMessage_UserDoesNotHaveAppropriatePermissionsToSaveRolePermissions, permission?.PermissionName, rolePermission.PermissionId)}");
                            }

                            if (rolePermissionRepository.DoesExist(rolePermission.RolePermissionId) == false)
                            {
                                rolePermission.RoleId = updatedRole.RoleId;
                                rolePermission.UpdateDate = DateTimeOffset.Now;
                                rolePermission.UpdateName = LoginName;
                                rolePermission.InsertDate = DateTimeOffset.Now;
                                rolePermission.InsertName = LoginName;
                                var savedrolePermission = rolePermissionRepository.Add(rolePermission,
                                    ApplicationUserSessionHeader, null);
                            }
                            else
                            {
                                // There is no need to update anything because there is no properties that would ever be modified on this table
                                //var savedrolePermission = rolePermissionRepository.Update(rolePermission, ApplicationUserSessionHeader, null);
                            }
                        }

                        x++;
                    }
                }


                var addToExistingUsers = parameters.OptionValue<bool>(SaveRoleOption.AddToExistingUsers.ToString());
                if (addToExistingUsers)
                {
                    var userEntityRoleRepository =
                        _DataRepositoryFactory.GetDataRepository<IGcsUserEntityRoleRepository>();
                    var userEntityIds = GalaxySMSDatabaseManager.GetAllUidsFromTable("GCS", "gcsUserEntity", "UserEntityId",
                        $"EntityId = '{updatedRole.EntityId}'");
                    foreach (var userEntityId in userEntityIds)
                    {
                        var uer = new gcsUserEntityRole()
                        {
                            UserEntityRoleId = GuidUtilities.GenerateComb(),
                            UserEntityId = userEntityId,
                            RoleId = updatedRole.RoleId,
                            ConcurrencyValue = 0
                        };
                        UpdateProperties(uer);
                        var updatedUer = userEntityRoleRepository.Add(uer, ApplicationUserSessionHeader, null);
                    }
                }

                var getNewRoleParams = new GetParametersWithPhoto(parameters)
                { UniqueId = updatedRole.RoleId, IncludeMemberCollections = true, DoNotValidateAuthorization = true };

                var returnRole = GetRole(getNewRoleParams);
                return returnRole;

                //return updatedRole;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteRoleByPk(Guid roleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsRoleRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

                return repository.Remove(roleId, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteRole(gcsRole role)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsRoleRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

                return repository.Remove(role, ApplicationUserSessionHeader);
            });
        }

        public bool IsRoleReferenced(Guid roleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                IGcsRoleRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

                bReturn = repository.IsReferenced(roleId);
                return bReturn;
            });
        }

        public bool IsRoleUnique(gcsRole role)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                IGcsRoleRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

                bReturn = repository.IsUnique(role);
                return bReturn;
            });
        }

        public EntityRoleEditingData GetRoleEditingData(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.RoleCanAddId);

                //                ValidateAdminAuthorizationAndSetupOperation(parameters);

                var result = new EntityRoleEditingData() { EntityId = parameters.UniqueId };

                if (!parameters.IsExcluded(nameof(EntityRoleEditingData.ApplicationPermissions)))
                {
                    var permissionCategoryRepository =
                        _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();
                    var applicationRepository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();
                    var apps = applicationRepository
                        .GetAllApplicationsBasic(new GetParametersWithPhoto(), ApplicationUserSessionHeader)
                        .OrderBy(o => o.ApplicationName);
                    var applications = new List<gcsApplicationBasic>();

                    if (parameters.AllowedApplicationIds.Any())
                    {
                        foreach (var g in parameters.AllowedApplicationIds)
                        {
                            var app = apps.FirstOrDefault(o => o.ApplicationId == g);
                            if (app != null)
                                applications.Add(app);
                        }
                    }
                    else
                    {
                        applications.AddRange(apps);
                    }

                    var permissionCategories = permissionCategoryRepository
                        .GetAll(ApplicationUserSessionHeader, parameters).OrderBy(o => o.CategoryName);

                    foreach (var app in applications)
                    {
                        var appPerms = new gcsApplicationPermissionsMinimal()
                        {
                            ApplicationName = app.ApplicationName,
                            ApplicationDescription = app.ApplicationDescription,
                            ApplicationId = app.ApplicationId,
                        };

                        foreach (var pc in permissionCategories.Where(o => o.ApplicationId == app.ApplicationId))
                        {
                            appPerms.PermissionCategories.Add(new gcsPermissionCategoryMinimal(pc));
                        }

                        result.ApplicationPermissions.Add(appPerms);
                    }
                }

                if (!parameters.IsExcluded(nameof(result.FilterData)))
                {
                    var entityRepository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                    var regionRepository = _DataRepositoryFactory.GetDataRepository<IRegionRepository>();
                    var ent = entityRepository.Get(parameters.UniqueId, ApplicationUserSessionHeader, parameters);
                    if (ent != null)
                    {
                        var entityFilterData = new gcsEntityFilterData(ent);

                        entityFilterData.Regions = regionRepository
                            .GetAllRegionSelectionItemsForEntity(this.ApplicationUserSessionHeader,
                                new GetParametersWithPhoto(parameters)
                                { CurrentEntityId = ent.EntityId, IncludeMemberCollections = true }).ToCollection();

                        result.FilterData = entityFilterData;
                    }
                }

                return result;
            });

        }

        #endregion

        #region Permission Category Operations

        public gcsPermissionCategory[] GetAllPermissionCategories()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();

                IEnumerable<gcsPermissionCategory> permissionCategories = repository.Get(ApplicationUserSessionHeader, null);

                return permissionCategories.ToArray();
            });
        }

        public gcsPermissionCategory[] GetAllPermissionCategoriesForApplication(Guid applicationId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();

                IEnumerable<gcsPermissionCategory> permissionCategories = repository.GetAllPermissionCategoriesForApplication(applicationId, null);

                return permissionCategories.ToArray();
            });
        }

        public gcsPermissionCategory GetPermissionCategory(Guid permissionCategoryId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();

                var permissionCategory = repository.Get(permissionCategoryId, ApplicationUserSessionHeader, null);
                if (permissionCategory == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsPermissionCategory with ID of {0} not found", permissionCategoryId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return permissionCategory;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsPermissionCategory SavePermissionCategory(SaveParameters<gcsPermissionCategory> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();

                var applicationRepo = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();
                var appExists = applicationRepo.DoesExist(parameters.Data.ApplicationId);

                gcsPermissionCategory updatedPermissionCategory = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            string.Format("gcsPermissionCategory with Name of '{0}' cannot be saved because it is a duplicate.",
                                parameters.Data.CategoryName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.PermissionCategoryId == Guid.Empty)
                {
                    parameters.Data.PermissionCategoryId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.PermissionCategoryId) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding Permission Category - {parameters.Data.CategoryName}.");
                    updatedPermissionCategory = repository.Add(parameters.Data, ApplicationUserSessionHeader, null);
                }
                else
                {
                    updatedPermissionCategory = repository.Update(parameters.Data, ApplicationUserSessionHeader, null);
                }

                if (!parameters.Ignore(nameof(parameters.Data.Permissions)))
                {
                    var permissionRepository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();
                    foreach (var permission in parameters.Data.Permissions)
                    {
                        if (permissionRepository.DoesExist(permission.PermissionId) == false)
                        {
                            permission.PermissionCategoryId = updatedPermissionCategory.PermissionCategoryId;
                            SavePermission(new SaveParameters<gcsPermission>(permission, parameters));
                        }
                    }
                }
                return updatedPermissionCategory;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeletePermissionCategoryByPk(Guid permissionCategoryId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();

                return repository.Remove(permissionCategoryId, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeletePermissionCategory(gcsPermissionCategory permissionCategory)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();

                return repository.Remove(permissionCategory, ApplicationUserSessionHeader);
            });
        }

        public bool IsPermissionCategoryReferenced(Guid permissionCategoryId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();

                bReturn = repository.IsReferenced(permissionCategoryId);
                return bReturn;
            });
        }

        public bool IsPermissionCategoryUnique(gcsPermissionCategory permissionCategory)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();

                bReturn = repository.IsUnique(permissionCategory);
                return bReturn;
            });
        }
        #endregion

        #region Permission Operations

        public gcsPermission[] GetAllPermissions()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                var permissions = repository.Get(ApplicationUserSessionHeader, null);

                return permissions.ToArray();
            });
        }

        public gcsPermission[] GetAllPermissionsForApplication(Guid applicationId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                IEnumerable<gcsPermission> permissions = repository.GetAllPermissionsForApplication(applicationId, null);

                return permissions.ToArray();
            });
        }

        public gcsPermission[] GetAllPermissionsForPermissionCategory(Guid permissionCategoryId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                IEnumerable<gcsPermission> permissions = repository.GetAllPermissionsForPermissionCategory(permissionCategoryId, null);

                return permissions.ToArray();
            });
        }

        public gcsPermission[] GetAllPermissionsForRole(Guid roleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                IEnumerable<gcsPermission> permissions = repository.GetAllPermissionsForRole(roleId, null);

                return permissions.ToArray();
            });
        }

        public gcsPermission GetPermission(Guid permissionId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                var permission = repository.Get(permissionId, ApplicationUserSessionHeader, null);
                if (permission == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsPermission with ID of {0} not found", permissionId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return permission;
            });
        }

        public gcsPermission SavePermission(SaveParameters<gcsPermission> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                gcsPermission updatedPermission = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            string.Format("gcsPermission with Name of '{0}' cannot be saved because it is a duplicate.",
                                parameters.Data.PermissionName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.PermissionId == Guid.Empty)
                {
                    parameters.Data.PermissionId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.PermissionId) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding Permission - {parameters.Data.PermissionName}.");
                    updatedPermission = repository.Add(parameters.Data, ApplicationUserSessionHeader, null);
                }
                else
                {
                    updatedPermission = repository.Update(parameters.Data, ApplicationUserSessionHeader, null);
                }

                return updatedPermission;
            });
        }

        public int DeletePermissionByPk(Guid permissionId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                return repository.Remove(permissionId, ApplicationUserSessionHeader);
            });
        }

        public int DeletePermission(gcsPermission permission)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                return repository.Remove(permission, ApplicationUserSessionHeader);
            });
        }

        public bool IsPermissionReferenced(Guid permissionId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                bReturn = repository.IsReferenced(permissionId);
                return bReturn;
            });
        }

        public bool IsPermissionUnique(gcsPermission permissiony)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();

                bReturn = repository.IsUnique(permissiony);
                return bReturn;
            });
        }

        #endregion

        #region Property Sensitivity Level Operations

        public PropertySensitivityLevel[] GetAllPropertySensitivityLevels(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelRepository>();

                var data = repository.Get(ApplicationUserSessionHeader, null);

                return data.ToArray();
            });
        }

        public PropertySensitivityLevel GetPropertySensitivityLevel(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelRepository>();

                var permission = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, null);
                if (permission == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("PropertySensitivityLevel with ID of {0} not found", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return permission;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public PropertySensitivityLevel SavePropertySensitivityLevel(SaveParameters<PropertySensitivityLevel> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelRepository>();

                PropertySensitivityLevel updatedEntity = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("PropertySensitivityLevel with '{0} ({1})' cannot be saved because it is a duplicate.", parameters.Data.Display, parameters.Data.SensitivityLevel));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.PropertySensitivityLevelUid == Guid.Empty)
                {
                    parameters.Data.PropertySensitivityLevelUid = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.PropertySensitivityLevelUid) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding Property Sensitivity Level - {parameters.Data.Display}.");
                    updatedEntity = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedEntity = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                return updatedEntity;
            });
        }

        public int DeletePropertySensitivityLevelByPk(DeleteParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelRepository>();

                return repository.Remove(parameters.UniqueId, ApplicationUserSessionHeader);
            });
        }

        public int DeletePropertySensitivityLevel(DeleteParameters<PropertySensitivityLevel> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelRepository>();

                return repository.Remove(parameters.Data, ApplicationUserSessionHeader);
            });
        }

        public bool IsPropertySensitivityLevelReferenced(Guid propertySensitivityLevelUid)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelRepository>();

                bReturn = repository.IsReferenced(propertySensitivityLevelUid);
                return bReturn;
            });
        }

        public bool IsPropertySensitivityLevelUnique(PropertySensitivityLevel propertySensitivityLevel)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                var repository = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelRepository>();

                bReturn = repository.IsUnique(propertySensitivityLevel);
                return bReturn;
            });
        }

        #endregion

        #region User Operations

        public ArrayResponse<gcsUser> GetAllUsers()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                var users = repository.GetAllPaged(ApplicationUserSessionHeader, null);

                return (ArrayResponse<gcsUser>)users;
            });
        }

        public ArrayResponse<gcsUserBasic> GetAllUsersList(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                parameters.CurrentEntityId = parameters.UniqueId;
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.UserCanViewId);

                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();


                var users = repository.GetUserListPaged(ApplicationUserSessionHeader, parameters);

                return (ArrayResponse<gcsUserBasic>)users;
            });
        }

        public ArrayResponse<gcsUser> GetAllUsersForApplication(Guid applicationId)
        {
            // TODO: Must filter users by application
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                var users = repository.GetPaged(ApplicationUserSessionHeader, null);

                return (ArrayResponse<gcsUser>)users;
            });
        }

        public ArrayResponse<gcsUser> GetAllUsersForRole(Guid roleId)
        {
            // TODO: Must filter users by Role
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                var users = repository.GetPaged(ApplicationUserSessionHeader, null);

                return (ArrayResponse<gcsUser>)users;
            });
        }

        public ArrayResponse<gcsUser> GetAllUsersForEntity(GetParametersWithPhoto parameters)
        {
            // TODO: Must filter users by Entity
            return ExecuteFaultHandledOperation(() =>
            {
                parameters.CurrentEntityId = parameters.UniqueId;
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.UserCanViewId);

                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                var users = repository.GetByPrimaryEntityId(ApplicationUserSessionHeader, parameters);

                return (ArrayResponse<gcsUser>)users;
            });
        }

        public gcsUser GetUser(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                var entityId = repository.GetPrimaryEntityId(parameters.UniqueId);
                if (entityId == Guid.Empty)
                {
                    NotFoundException ex =
                        new NotFoundException($"{nameof(gcsUser)} with {nameof(gcsUser.UserId)} of {parameters.UniqueId} not found");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.CurrentEntityId = entityId;
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.UserCanViewId);

                gcsUser user = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, parameters);
                if (user == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsUser with ID of {0} not found", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return user;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsUser SaveUser(SaveParameters<gcsUser> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var dontValidateAuthorization = parameters.OptionValue<bool>(GalaxySMS.Common.Enums.InitializingSystemOption.DontValidateAuthorization.ToString());

                if (dontValidateAuthorization == false)
                {
                    if (parameters.Data.PrimaryEntityId == Guid.Empty)
                        parameters.Data.PrimaryEntityId = ApplicationUserSessionHeader.CurrentEntityId;

                    parameters.CurrentEntityId = parameters.Data.PrimaryEntityId;

                    if (parameters.Data.UserId == Guid.Empty)
                        ValidateAuthorizationAndSetupOperation(parameters, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.UserCanAddId);
                    else
                        ValidateAuthorizationAndSetupOperation(parameters, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.UserCanUpdateId);
                }

                var repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                repository.PasswordResetParameters = new PasswordResetParameters()
                {
                    TokenLifespan = Globals.Instance.PasswordResetSettings.TokenLifespan,
                    TokenEmailTemplate = $"{Globals.Instance.TemplateFolder}{Globals.Instance.PasswordResetSettings.TokenEmailTemplate}",
                    TokenEmailSubject = Globals.Instance.PasswordResetSettings.TokenEmailSubject,
                    TokenSmsTemplate = $"{Globals.Instance.TemplateFolder}{Globals.Instance.PasswordResetSettings.TokenSmsTemplate}"
                };

                gcsUser updatedUser = null;
                var propertyName = string.Empty;
                if (repository.IsUniqueProperty(parameters.Data, ref propertyName) == false)
                {
                    var propValue = parameters.Data.DisplayName;
                    if (propertyName == "Email")
                        propValue = parameters.Data.Email;
                    else if (propertyName == "UserName")
                        propValue = parameters.Data.UserName;

                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            $"User with {propertyName} of '{propValue}' cannot be saved because it is a duplicate.");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.UserId == Guid.Empty)
                {
                    string sPassword = Crypto.DecryptString(parameters.Data.UserPassword, parameters.Data.UserId.ToString());
                    parameters.Data.UserId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                    parameters.Data.UserPassword = Crypto.EncryptString(sPassword, parameters.Data.UserId.ToString());
                }


                var validationResults = new PasswordValidationInfo();

                if (parameters.Data.UserId == Guid.Empty || !string.IsNullOrEmpty(parameters.Data.UserPassword))
                    validationResults = repository.IsPasswordValid(parameters.Data, true);

                if (validationResults.Result != PasswordValidationResult.Valid)
                {
                    PasswordValidationException ex =
                        new PasswordValidationException(validationResults.ResultMessage);

                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                if (repository.DoesExist(parameters.Data.UserId) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;

                    this.Log().Info($"Adding User - {parameters.Data.DisplayName}.");
                    updatedUser = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedUser = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                    updatedUser.UserOldPasswords = repository.GetOldPasswordsForUser(updatedUser, -1, this.ApplicationUserSessionHeader).ToCollection();
                }
                // purposely clear the password so it is not revealed to the client
                updatedUser.UserPassword = string.Empty;

                // Now save all the UserEntities and UserApplicationEntities

                return updatedUser;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsUser SaveUserSave(SaveParameters<gcsUserSave> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (parameters.Data.UserId == Guid.Empty)
                    ValidateAuthorizationAndSetupOperation(parameters, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.UserCanAddId);
                else
                    ValidateAuthorizationAndSetupOperation(parameters, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.UserCanUpdateId);

                var repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                var propertyName = string.Empty;
                if (repository.IsUniqueProperty(parameters.Data, ref propertyName) == false)
                {
                    var propValue = parameters.Data.DisplayName;
                    if (propertyName == "Email")
                        propValue = parameters.Data.Email;
                    else if (propertyName == "UserName")
                        propValue = parameters.Data.UserName;

                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            $"User with {propertyName} of '{propValue}' cannot be saved because it is a duplicate.");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                if (parameters.Data.UserId == Guid.Empty)
                {
                    string sPassword = Crypto.DecryptString(parameters.Data.UserPassword, parameters.Data.UserId.ToString());
                    parameters.Data.UserId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                    parameters.Data.UserPassword = Crypto.EncryptString(sPassword, parameters.Data.UserId.ToString());
                }

                PasswordValidationInfo passwordValidationResults = repository.IsPasswordValid(parameters.Data);

                if (passwordValidationResults.Result != PasswordValidationResult.Valid)
                {
                    PasswordValidationException ex =
                        new PasswordValidationException(passwordValidationResults.ResultMessage);

                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                var userExists = repository.DoesExist(parameters.Data.UserId);
                var addDescendantEntities = parameters.OptionValue<bool>(SaveUserOption.AddDescendantEntities.ToString());
                // Only if this is a new user being inserted AND if there are no userEntities specified, then implement auto-assignment of
                // ParentEntityId and all child entities with default roles
                if (!userExists && addDescendantEntities)
                {
                    var inheritParentRoles =
                        parameters.OptionValue<bool>(SaveUserOption.InheritParentEntityRoles.ToString());

                    var isEntityAdmin =
                        parameters.OptionValue<bool>(SaveUserOption.IsEntityAdministrator.ToString());

                    var doNotAddDefaultRolesToUser = parameters.OptionValue<bool>(SaveUserOption.DoNotAddDefaultRolesToUser.ToString());

                    if (addDescendantEntities)
                    {
                        // create userentities for PrimaryEntityId and all descendant entities
                        var entityRepo = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();
                        var roleRepo = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();
                        // start with the primary entity
                        var entities = entityRepo.GetEntityHierarchy(parameters.Data.PrimaryEntityId, ApplicationUserSessionHeader, null);
                        if (entities != null)
                        {
                            var primaryEntity = entities.FirstOrDefault(o => o.EntityId == parameters.Data.PrimaryEntityId);
                            if (primaryEntity != null)
                            {
                                parameters.Data.UserEntities = parameters.Data.UserEntities.ToList();
                                foreach (var e in entities)
                                {
                                    var ue = parameters.Data.UserEntities.FirstOrDefault(o => o.EntityId == e.EntityId);
                                    if (ue == null)
                                    {
                                        ue = new gcsUserEntitySave()
                                        { EntityId = e.EntityId, InheritParentRoles = inheritParentRoles, IsAdministrator = isEntityAdmin };
                                        parameters.Data.UserEntities.Add(ue);
                                    }
                                    else
                                    {
                                        //                                        ue.InheritParentRoles = inheritParentRoles;
                                        //ue.IsAdministrator = isEntityAdmin;
                                    }

                                    if (!doNotAddDefaultRolesToUser)
                                    {
                                        ue.UserEntityRoles = ue.UserEntityRoles.ToList();
                                        var defaultRoleUids = roleRepo.GetAllDefaultUids(e.EntityId);
                                        foreach (var uid in defaultRoleUids)
                                        {
                                            var uer = ue.UserEntityRoles.FirstOrDefault(o => o.RoleId == uid);
                                            if (uer == null)
                                            {
                                                uer = new gcsUserEntityRoleSave() { RoleId = uid };
                                                ue.UserEntityRoles.Add(uer);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                var primaryUserEntity = parameters.Data.UserEntities.FirstOrDefault(o => o.EntityId == parameters.Data.PrimaryEntityId);
                if (primaryUserEntity == null)
                {
                    var ex = new ApplicationException($"Missing UserEntity entry for the PrimaryEntityId: {parameters.Data.PrimaryEntityId}");
                    var detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                var userEntityrepository = _DataRepositoryFactory.GetDataRepository<IGcsUserEntityRepository>();

                var currentUsersPrimaryEntity = userEntityrepository.GetByUserIdAndEntityId(
                    this.UserSessionToken.UserData.UserId, this.UserSessionToken.UserData.PrimaryEntityId,
                    new GetParametersWithPhoto() { IncludeMemberCollections = false });

                // Verify that the user making the call is permitted to assign entities, applications and roles that are specified in the incoming parameter
                foreach (var e in parameters.Data.UserEntities)
                {
                    var currentUsersUserEntity =
                        userEntityrepository.GetByUserIdAndEntityId(this.UserSessionToken.UserData.UserId, e.EntityId, new GetParametersWithPhoto() { IncludeMemberCollections = false });

                    if (!addDescendantEntities)
                    {   // Only validate that the calling user also has access to the entity and roles that are specified for the new user IF addDescendantEntitiesWithDefaultRoles == false
                        // If calling user has IsAdministrator= true for their primary entity, then allow
                        if (currentUsersUserEntity == null && !currentUsersPrimaryEntity.IsAdministrator)
                        //if (!Globals.Instance.DoesUserHaveEntity(this.UserSessionToken.UserData.UserId, e.EntityId))
                        {
                            var ex = new ApplicationException(
                                $"The current user is not permitted to assign EntityId: {e.EntityId} to the user being saved because the current user is not a member of that entity.");
                            var detail = new ExceptionDetailEx(ex);
                            throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                        }

                        var entityRoleIds = e.UserEntityRoles.Select(o => o.RoleId).ToList();

                        var userHasAdmin = DoesUserHaveAdminAuthorizationToEntity(this.UserSessionToken.UserData.UserId, e.EntityId);

                        if (!userHasAdmin || currentUsersUserEntity.IsAdministrator)
                        {
                            var bRolesPermitted =
                                repository.IsUserInAllRoles(this.UserSessionToken.UserData.UserId, entityRoleIds);
                            if (bRolesPermitted == false && currentUsersUserEntity.IsAdministrator == false && currentUsersPrimaryEntity.IsAdministrator == false)
                            {
                                var ex = new ApplicationException(
                                    $"The current user is not permitted to assign one or more roles to the user being saved because the current user is not a member of that role.");
                                var detail = new ExceptionDetailEx(ex);
                                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                            }
                        }
                    }
                }


                //var updatedUser = repository.GetByUserName(parameters.Data.UserName, this.ApplicationUserSessionHeader);
                var updatedUser = repository.GetByEmail(parameters.Data.Email, this.ApplicationUserSessionHeader, true);
                if (updatedUser == null)
                {
                    updatedUser = new gcsUser();
                    updatedUser.UserId = parameters.Data.UserId;
                    updatedUser.Email = parameters.Data.Email;
                    updatedUser.UserName = parameters.Data.UserName;
                }

                updatedUser.PrimaryEntityId = parameters.Data.PrimaryEntityId;
                updatedUser.DisplayName = parameters.Data.DisplayName;
                updatedUser.AccessFailedCount = parameters.Data.AccessFailedCount;
                updatedUser.ActiveDirectoryObjectGuid = parameters.Data.ActiveDirectoryObjectGuid;
                updatedUser.ConcurrencyStamp = parameters.Data.ConcurrencyStamp;

                updatedUser.LanguageId = parameters.Data.LanguageId;
                updatedUser.FirstName = parameters.Data.FirstName;
                updatedUser.LastName = parameters.Data.LastName;
                updatedUser.UserInitials = parameters.Data.UserInitials;
                updatedUser.UserPassword = parameters.Data.UserPassword;
                updatedUser.LastLoginDate = parameters.Data.LastLoginDate;
                updatedUser.UserTheme = parameters.Data.UserTheme;
                updatedUser.IsLockedOut = parameters.Data.IsLockedOut;
                updatedUser.IsActive = parameters.Data.IsActive;
                updatedUser.ResetPasswordFlag = parameters.Data.ResetPasswordFlag;
                updatedUser.LastPasswordResetDate = parameters.Data.LastPasswordResetDate;
                updatedUser.UserActivationDate = parameters.Data.UserActivationDate;
                updatedUser.UserExpirationDate = parameters.Data.UserExpirationDate;
                updatedUser.ImportedFromActiveDirectory = parameters.Data.ImportedFromActiveDirectory;
                updatedUser.SecurityImage = parameters.Data.SecurityImage;
                updatedUser.UserImage = parameters.Data.UserImage;
                updatedUser.Email = parameters.Data.Email;
                updatedUser.EmailConfirmed = parameters.Data.EmailConfirmed;
                updatedUser.LockoutEnabled = parameters.Data.LockoutEnabled;
                updatedUser.LockoutEnd = parameters.Data.LockoutEnd;
                updatedUser.PhoneNumber = parameters.Data.PhoneNumber;
                updatedUser.PhoneNumberConfirmed = parameters.Data.PhoneNumberConfirmed;
                updatedUser.SecurityStamp = parameters.Data.SecurityStamp;
                updatedUser.TwoFactorEnabled = parameters.Data.TwoFactorEnabled;
                updatedUser.PasswordHash = parameters.Data.PasswordHash;
                updatedUser.ConcurrencyValue = parameters.Data.ConcurrencyValue;

                // spin through all userEntities in the incoming gcsUserSave user, and convert to gcsUser userEntity format
                foreach (var ue in parameters.Data.UserEntities)
                {
                    var existingUserEntity = updatedUser.UserEntities.FirstOrDefault(o => o.EntityId == ue.EntityId);
                    if (existingUserEntity == null)
                    {
                        existingUserEntity = new gcsUserEntity()
                        {
                            EntityId = ue.EntityId,
                            InheritParentRoles = ue.InheritParentRoles,
                            IsAdministrator = ue.IsAdministrator,
                        };
                        if (ue.UserEntityRoles != null && ue.UserEntityRoles.Any())
                        {
                            foreach (var uer in ue.UserEntityRoles)
                            {
                                existingUserEntity.UserEntityRoles.Add(new gcsUserEntityRole() { RoleId = uer.RoleId });
                            }
                        }
                        updatedUser.UserEntities.Add(existingUserEntity);
                    }

                    // For each role in the incoming data, make sure an entry exists in the UpdatedUser record.
                    foreach (var uer in ue.UserEntityRoles.Where(o => o.RoleId != Guid.Empty))
                    {
                        var existingUer = existingUserEntity.UserEntityRoles.FirstOrDefault(o => o.RoleId == uer.RoleId);
                        if (existingUer == null)
                        {
                            existingUer = new gcsUserEntityRole()
                            {
                                RoleId = uer.RoleId
                            };
                            existingUserEntity.UserEntityRoles.Add(existingUer);
                        }
                    }
                }

                //this.gcsUserSettings = e.gcsUserSettings.ToCollection();
                //this.gcsUserOldPasswords = e.gcsUserOldPasswords.ToCollection();


                updatedUser.UpdateDate = DateTimeOffset.Now;
                updatedUser.UpdateName = LoginName;
                if (updatedUser.UserId == Guid.Empty)
                {
                    string sPassword = Crypto.DecryptString(updatedUser.UserPassword, updatedUser.UserId.ToString());
                    updatedUser.UserId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                    updatedUser.UserPassword = Crypto.EncryptString(sPassword, updatedUser.UserId.ToString());
                }
                if (repository.DoesExist(updatedUser.UserId) == false)
                {
                    updatedUser.InsertDate = DateTimeOffset.Now;
                    updatedUser.InsertName = LoginName;

                    this.Log().Info($"Adding User - {updatedUser.DisplayName}.");
                    updatedUser = repository.Add(updatedUser, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedUser = repository.Update(updatedUser, ApplicationUserSessionHeader, parameters);
                    updatedUser.UserOldPasswords = repository.GetOldPasswordsForUser(updatedUser, -1, this.ApplicationUserSessionHeader).ToCollection();
                }
                // purposely clear the password so it is not revealed to the client
                updatedUser.UserPassword = string.Empty;

                // Now save all the UserEntities and UserApplicationEntities

                return updatedUser;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsUser SaveUserAccountRequest(gcsUser user)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                gcsUser updatedUser = null;

                if (repository.IsUnique(user) == false)
                {
                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            string.Format("gcsUser with Name of '{0}' cannot be saved because it is a duplicate.",
                                user.DisplayName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                user.UpdateDate = DateTimeOffset.Now;
                user.UpdateName = LoginName;
                if (user.UserId == Guid.Empty)
                {
                    string sPassword = Crypto.DecryptString(user.UserPassword, user.UserId.ToString());
                    user.UserId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                    user.UserPassword = Crypto.EncryptString(sPassword, user.UserId.ToString());
                }
                if (repository.DoesExist(user.UserId) == false)
                {
                    user.InsertDate = DateTimeOffset.Now;
                    user.InsertName = LoginName;
                    updatedUser = repository.Add(user, ApplicationUserSessionHeader, null);
                }
                else
                {
                    updatedUser = repository.Update(user, ApplicationUserSessionHeader, null);
                    updatedUser.UserOldPasswords = repository.GetOldPasswordsForUser(updatedUser, -1, this.ApplicationUserSessionHeader).ToCollection();
                }
                // purposely clear the password so it is not revealed to the client
                updatedUser.UserPassword = string.Empty;

                // Now save all the UserEntities and UserApplicationEntities

                return updatedUser;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteUserByPk(Guid userId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(new GetParametersWithPhoto() { CurrentEntityId = ApplicationUserSessionHeader.CurrentEntityId }, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.UserCanDeleteId);

                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                return repository.Remove(userId, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteUser(gcsUser user)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(new GetParametersWithPhoto() { CurrentEntityId = ApplicationUserSessionHeader.CurrentEntityId }, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.UserCanDeleteId);

                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                return repository.Remove(user, ApplicationUserSessionHeader);
            });
        }

        public void ResetPassword(Guid userId, string newPassword)
        {
            ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                var user = repository.Get(userId, ApplicationUserSessionHeader, null);
                if (user == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsUser with ID of {0} not found", userId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                user.UserPassword = newPassword;
                var passwordValidationResults = repository.IsPasswordValid(user, true);

                if (passwordValidationResults.Result != PasswordValidationResult.Valid)
                {
                    PasswordValidationException ex =
                        new PasswordValidationException(passwordValidationResults.ResultMessage);

                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                repository.Update(user, ApplicationUserSessionHeader, null);
            });
        }

        public string ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                var user = repository.Get(userId, ApplicationUserSessionHeader, null);
                if (user == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsUser with ID of {0} not found", userId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                user.UserPassword = repository.GetPasswordForUser(userId, this.ApplicationUserSessionHeader);
                if (user.UserPassword != currentPassword)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsUser with current password not found"));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                user.UserPassword = newPassword;
                var passwordValidationResults = repository.IsPasswordValid(user, true);

                if (passwordValidationResults.Result != PasswordValidationResult.Valid)
                {
                    PasswordValidationException ex =
                        new PasswordValidationException(passwordValidationResults.ResultMessage);

                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                repository.Update(user, ApplicationUserSessionHeader, null);
                return user.UserPassword;
            });
        }

        public bool IsUserReferenced(Guid userId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                bReturn = repository.IsReferenced(userId);
                return bReturn;
            });
        }

        public bool IsUserUnique(gcsUser user)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                bool bReturn = false;
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                bReturn = repository.IsUnique(user);
                return bReturn;
            });
        }

        public gcsUser GetByUserName(string userName)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                gcsUser user = repository.GetByUserName(userName, this.ApplicationUserSessionHeader, true);
                if (user == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsUser with UserName of {0} not found", userName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return user;
            });
        }

        public gcsUser GetByEmail(string email)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                gcsUser user = repository.GetByEmail(email, this.ApplicationUserSessionHeader, true);
                if (user == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsUser with Email of {0} not found", email));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return user;
            });
        }

        public gcsUser GetByPassword(string password)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                gcsUser user = repository.GetByPassword(password, this.ApplicationUserSessionHeader);
                if (user == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsUser with Password of {0} not found", password));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return user;
            });
        }


        public string GeneratePasswordResetToken(Guid userId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                return repository.GeneratePasswordResetToken(userId, ApplicationUserSessionHeader);
            });
        }

        public PasswordValidationInfo ValidatePassword(gcsUser user, bool isEncrypted)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                var passwordValidationResult = repository.IsPasswordValid(user, isEncrypted);
                return passwordValidationResult;

            });
        }

        public PasswordValidationInfo ValidatePasswordForEntity(gcsUser user, Guid entityGuid)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                var passwordValidationResult = repository.IsPasswordValidForEntityGuid(user, entityGuid);
                return passwordValidationResult;

            });
        }

        public gcsUserOldPassword[] GetOldPasswordsForUser(gcsUser user, int howMany)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                var oldPasswords = repository.GetOldPasswordsForUser(user, howMany, this.ApplicationUserSessionHeader);
                return oldPasswords.ToArray();

            });
        }

        public gcsUserEditingData GetUserEditingData(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.UserCanAddId);

                ValidateAdminAuthorizationAndSetupOperation(parameters);
                var sessionHeader = this.ApplicationUserSessionHeader;
                var userSessionToken = this.UserSessionToken;
                var getParams = new GetParametersWithPhoto(parameters)
                { IncludeMemberCollections = true, UniqueId = UserId };
                getParams.ExcludeMemberCollectionSettings.Add(nameof(gcsRole.RolePermissions));
                getParams.ExcludeMemberCollectionSettings.Add(nameof(gcsRole.DeviceFilters));
                //getParams.ExcludeMemberCollectionSettings.Add(nameof(gcsRole.InputDevices));
                //getParams.ExcludeMemberCollectionSettings.Add(nameof(gcsRole.OutputDevices));
                //getParams.ExcludeMemberCollectionSettings.Add(nameof(gcsRole.Clusters));
                //getParams.ExcludeMemberCollectionSettings.Add(nameof(gcsRole.InputOutputGroups));

                var entities = GetAllEntitiesForUser(getParams);
                var result = new gcsUserEditingData();
                foreach (var e in entities.Items)
                {
                    // purposely skip the SystemEntity. Do not include this 
                    if (e.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id)
                        continue;

                    var entityData = new gcsUserEditingEntityData(e);
                    result.AllowedEntities.Add(entityData);
                }
                var languageRepository = _DataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();
                var languages = languageRepository.GetAll(this.ApplicationUserSessionHeader, parameters);
                foreach (var l in languages)
                    result.Languages.Add(new gcsLanguageBasic(l));
                //var oldPasswords = repository.GetOldPasswordsForUser(user, howMany);
                //return oldPasswords.ToArray();
                return result;
            });
        }

        public gcsRole[] GetUserRolesForEntityApplication(Guid userId, Guid applicationId, Guid entityId)
        {
            return new List<gcsRole>().ToArray();
        }

        public UserRequestPasswordChangeTokenResponse RequestUserPasswordChangeToken(UserRequestPasswordChangeToken parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                repository.PasswordResetParameters = new PasswordResetParameters()
                {
                    TokenLifespan = Globals.Instance.PasswordResetSettings.TokenLifespan,
                    TokenEmailTemplate = $"{Globals.Instance.TemplateFolder}{Globals.Instance.PasswordResetSettings.TokenEmailTemplate}",
                    TokenEmailSubject = Globals.Instance.PasswordResetSettings.TokenEmailSubject,
                    TokenSmsTemplate = $"{Globals.Instance.TemplateFolder}{Globals.Instance.PasswordResetSettings.TokenSmsTemplate}"
                };

                return repository.RequestUserPasswordChangeToken(parameters, this.ApplicationUserSessionHeader, null);
            });

        }

        public UpdateUserPasswordResult UpdateUserPassword(UpdateUserPasswordParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                var results = new UpdateUserPasswordResult();

                var currentUser = repository.GetByPassword(parameters.CurrentPassword, ApplicationUserSessionHeader);
                if (currentUser == null)
                {
                    results.Result = UpdateUserPasswordResult.UpdateUserPasswordResultCodes.UserNotFound;
                    return results;
                }

                var data = repository.GetPasswordResetInformation(currentUser.UserId, ApplicationUserSessionHeader);
                if (data == null)
                {
                    results.Result = UpdateUserPasswordResult.UpdateUserPasswordResultCodes.UserNotFound;
                    return results;
                }

                if (data.PasswordResetToken != parameters.Token)
                {
                    results.Result = UpdateUserPasswordResult.UpdateUserPasswordResultCodes.TokenInvalid;
                    return results;
                }

                if (data.PasswordResetTokenExpiration.HasValue &&
                    data.PasswordResetTokenExpiration.Value < DateTimeOffset.Now)
                {
                    results.Result = UpdateUserPasswordResult.UpdateUserPasswordResultCodes.TokenHasExpired;
                    return results;
                }

                if (currentUser != null)
                {
                    var decryptedPassword = Crypto.DecryptString(parameters.NewPassword, parameters.UserId.ToString());
                    currentUser.UserPassword = decryptedPassword;
                    results.ValidationInfo = ValidatePassword(currentUser, false);
                    if (results.ValidationInfo.Result == PasswordValidationResult.Valid)
                    {
                        parameters.UserId = currentUser.UserId;
                        parameters.NewPassword =
                            Crypto.EncryptString(currentUser.UserPassword, currentUser.UserId.ToString());
                        var r = repository.UpdateUserPassword(parameters, this.ApplicationUserSessionHeader);
                        r.ValidationInfo = results.ValidationInfo;
                        r.Result = UpdateUserPasswordResult.UpdateUserPasswordResultCodes.Success;
                        return r;
                    }
                    else
                    {
                        results.Result = UpdateUserPasswordResult.UpdateUserPasswordResultCodes.NewPasswordInvalid;
                    }
                }
                return results;
            });

        }

        public UserEntityPermissions GetUserPermissions(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.UserCanAddId);

                var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                var result = userRepository.GetUserPermissions(parameters);
                return result;
            });

        }
        #endregion

        #region Application Setting operations
        public gcsApplicationSetting GetApplicationSetting(gcsApplicationSetting applicationSetting, bool bCreateIfNotFound)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationSettingRepository>();

                gcsApplicationSetting entity = null;
                if (applicationSetting.ApplicationSettingId != Guid.Empty)
                    entity = repository.Get(applicationSetting.ApplicationSettingId, ApplicationUserSessionHeader, null);
                else
                {
                    entity = repository.GetByUniqueKey(applicationSetting.ApplicationId, applicationSetting.Category,
                        applicationSetting.SettingKey);
                }
                if (entity == null)
                {   // if no setting is found, return the same object that was passed in, but set the PK to Guid.Empty. This way, the caller can pass 
                    // desired default values in the parameter and they will be returned if there is not a record already.
                    if (bCreateIfNotFound == true)
                    {
                        applicationSetting.ApplicationSettingId = Guid.Empty;
                        return SaveApplicationSetting(new SaveParameters<gcsApplicationSetting>() { Data = applicationSetting });
                    }
                    //entity = applicationSetting;
                    //entity.ApplicationSettingId = Guid.Empty;
                    NotFoundException ex = new NotFoundException($"gcsApplicationSetting with ApplicationId of {applicationSetting.ApplicationSettingId} not found");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return entity;
            });
        }

        public gcsApplicationSetting GetApplicationSettingFromParams(Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            IGcsApplicationSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationSettingRepository>();

            gcsApplicationSetting entity = repository.GetByUniqueKey(applicationId, category, settingKey);
            if (entity == null)
            {   // if no setting is found, return the same object that was passed in, but set the PK to Guid.Empty. This way, the caller can pass 
                // desired default values in the parameter and they will be returned if there is not a record already.
                entity = new gcsApplicationSetting()
                {
                    ApplicationSettingId = Guid.Empty,
                    ApplicationId = applicationId,
                    Category = category,
                    SettingKey = settingKey,
                    SettingValue = defaultValue,
                    SettingDescription = defaultDescription
                };
                if (bCreateIfNotFound == true)
                {
                    return SaveApplicationSetting(new SaveParameters<gcsApplicationSetting>() { Data = entity });
                }
                NotFoundException ex = new NotFoundException($"gcsApplicationSetting with ApplicationId of {applicationId}, Category:{category}, Key:{settingKey} not found");
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }

            return entity;

        }

        public gcsApplicationSetting[] GetAllApplicationSettingsForApplication(Guid applicationId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationSettingRepository>();

                IEnumerable<gcsApplicationSetting> settings = repository.GetAllForApplication(applicationId);

                return settings.ToArray();
            });
        }

        public gcsApplicationSetting[] GetAllApplicationSettingsForApplicationCategory(Guid applicationId, string category)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationSettingRepository repository =
                    _DataRepositoryFactory.GetDataRepository<IGcsApplicationSettingRepository>();

                IEnumerable<gcsApplicationSetting> settings = repository.GetAllForApplicationCategory(applicationId,
                    category);

                return settings?.ToArray();
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsApplicationSetting SaveApplicationSetting(SaveParameters<gcsApplicationSetting> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationSettingRepository>();

                gcsApplicationSetting updatedApplicationSetting = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            string.Format("gcsApplicationSetting with Category of '{0}', SettingKey of '{1}' cannot be saved because it is a duplicate for the application {2}.",
                                parameters.Data.Category, parameters.Data.SettingKey, parameters.Data.ApplicationId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.ApplicationSettingId == Guid.Empty)
                {
                    parameters.Data.ApplicationSettingId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    updatedApplicationSetting = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedApplicationSetting = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                return updatedApplicationSetting;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteApplicationSettingByPk(Guid applicationSettingId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationSettingRepository>();

                return repository.Remove(applicationSettingId, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteApplicationSetting(gcsApplicationSetting applicationSetting)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationSettingRepository>();

                return repository.Remove(applicationSetting, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteApplicationSettingFromParams(Guid applicationId, string category, string settingKey)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsApplicationSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationSettingRepository>();

                return repository.DeleteByUniqueKey(applicationId, category, settingKey);
            });
        }
        #endregion

        #region User Requirements Operations
        public gcsUserRequirement GetUserRequirementForEntity(Guid entityId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRequirementsRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRequirementsRepository>();

                gcsUserRequirement userRequirement = repository.GetByEntityId(entityId);
                if (userRequirement == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsUserRequirement for Entity ID of {0} not found", entityId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return userRequirement;
            });
        }

        public gcsUserRequirement[] GetAllUserRequirements()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRequirementsRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRequirementsRepository>();

                IEnumerable<gcsUserRequirement> users = repository.Get(ApplicationUserSessionHeader, null);

                return users.ToArray();
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsUserRequirement SaveUserRequirement(SaveParameters<gcsUserRequirement> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRequirementsRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRequirementsRepository>();

                var existingUserReqs = repository.GetByEntityId(parameters.Data.EntityId);
                if (existingUserReqs != null)
                    parameters.Data.UserRequirementsId = existingUserReqs.UserRequirementsId;

                gcsUserRequirement updatedUserRequirement = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            string.Format("gcsUserRequirement for Entity of '{0}' cannot be saved because it is a duplicate.",
                                parameters.Data.EntityGuid));

                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                this.Log().Info($"Saving Entity User Requirements.");

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.UserRequirementsId == Guid.Empty)
                {
                    parameters.Data.UserRequirementsId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    updatedUserRequirement = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedUserRequirement = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                return updatedUserRequirement;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteUserRequirementByPk(Guid userRequirementId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRequirementsRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRequirementsRepository>();

                return repository.Remove(userRequirementId, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteUserRequirement(gcsUserRequirement userRequirement)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserRequirementsRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserRequirementsRepository>();

                return repository.Remove(userRequirement, ApplicationUserSessionHeader);
            });
        }
        #endregion

        #region User Setting Operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsUserSetting GetUserSetting(gcsUserSetting userSetting, bool bCreateIfNotFound)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();

                gcsUserSetting entity = null;
                if (userSetting.UserSettingId != Guid.Empty)
                {
                    ValidateUserAuthorization(userSetting.UserSettingId);
                    entity = repository.Get(userSetting.UserSettingId, ApplicationUserSessionHeader, null);
                }
                else
                {
                    Guid applicationGuid = Guid.Empty;
                    if (userSetting.ApplicationId.HasValue)
                        applicationGuid = userSetting.ApplicationId.Value;

                    entity = repository.GetByUniqueKey(userSetting.UserId, applicationGuid, userSetting.Category, userSetting.SettingKey);
                }
                if (entity == null)
                {   // if no setting is found, return the same object that was passed in, but set the PK to Guid.Empty. This way, the caller can pass 
                    // desired default values in the parameter and they will be returned if there is not a record already.
                    if (bCreateIfNotFound == true)
                    {
                        userSetting.UserSettingId = Guid.Empty;
                        return SaveUserSetting(new SaveParameters<gcsUserSetting>(userSetting));
                    }
                    entity = userSetting;
                    entity.UserSettingId = Guid.Empty;
                    //NotFoundException ex = new NotFoundException(string.Format("gcsApplicationSetting with ID of {0} not found", entityId));
                    //ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return entity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsUserSetting GetUserSettingFromParams(Guid userId, Guid? applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            IGcsUserSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();
            
            ValidateUserAuthorization(userId);

            gcsUserSetting entity = repository.GetByUniqueKey(userId, applicationId, category, settingKey);
            if (entity == null)
            {   // if no setting is found, return the same object that was passed in, but set the PK to Guid.Empty. This way, the caller can pass 
                // desired default values in the parameter and they will be returned if there is not a record already.
                entity = new gcsUserSetting()
                {
                    UserSettingId = Guid.Empty,
                    UserId = userId,
                    ApplicationId = applicationId,
                    Category = category,
                    SettingKey = settingKey,
                    SettingValue = defaultValue,
                    SettingDescription = defaultDescription
                };
                if (bCreateIfNotFound == true)
                {
                    return SaveUserSetting(new SaveParameters<gcsUserSetting>(entity));
                }
                //NotFoundException ex = new NotFoundException(string.Format("gcsApplicationSetting with ID of {0} not found", entityId));
                //ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }

            return entity;
        }

        public gcsUserSetting[] GetAllUserSettingsForUser(Guid userId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateUserAuthorization(userId);
                IGcsUserSettingRepository repository =
                    _DataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();

                IEnumerable<gcsUserSetting> settings = repository.GetAllForUser(userId);

                return settings.ToArray();
            });
        }

        public gcsUserSetting[] GetAllUserSettingsForUserApplication(Guid userId, Guid? applicationId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateUserAuthorization(userId);
                IGcsUserSettingRepository repository =
                    _DataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();

                IEnumerable<gcsUserSetting> settings = repository.GetAllForUserApplication(userId, applicationId);

                return settings.ToArray();
            });
        }

        public gcsUserSetting[] GetAllUserSettingsForUserApplicationCategory(Guid userId, Guid? applicationId, string category)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateUserAuthorization(userId);
                IGcsUserSettingRepository repository =
                    _DataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();

                IEnumerable<gcsUserSetting> settings = repository.GetAllForUserApplicationCategory(userId, applicationId, category);

                return settings.ToArray();
            });
        }

        public gcsUserSetting[] GetAllUserSettingsForApplication(Guid? applicationId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserSettingRepository repository =
                    _DataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();

                IEnumerable<gcsUserSetting> settings = repository.GetAllForApplication(applicationId);

                return settings.Where(o=>o.UserId == ApplicationUserSessionHeader.UserId).ToArray();
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsUserSetting SaveUserSetting(SaveParameters<gcsUserSetting> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateUserAuthorization(parameters.Data.UserId);
                IGcsUserSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();

                gcsUserSetting updatedUserSetting = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            string.Format("gcsUserSetting with Category of '{0}', SettingKey of '{1}' cannot be saved because it is a duplicate for the application {2}.",
                                parameters.Data.Category, parameters.Data.SettingKey, parameters.Data.ApplicationId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.UserSettingId == Guid.Empty)
                {
                    parameters.Data.UserSettingId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    updatedUserSetting = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedUserSetting = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                return updatedUserSetting;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteUserSettingByPk(Guid userSettingId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IGcsUserSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();

                var setting = repository.Get(userSettingId, this.ApplicationUserSessionHeader, new GetParametersWithPhoto());
                if (setting != null)
                {
                    ValidateUserAuthorization(setting.UserId);
                }
                return repository.Remove(userSettingId, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteUserSetting(gcsUserSetting userSetting)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateUserAuthorization(userSetting.UserId);
                IGcsUserSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();

                return repository.Remove(userSetting, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteUserSettingFromParams(Guid userId, Guid? applicationId, string category, string settingKey)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateUserAuthorization(userId);
                IGcsUserSettingRepository repository = _DataRepositoryFactory.GetDataRepository<IGcsUserSettingRepository>();

                return repository.DeleteByUniqueKey(userId, applicationId, category, settingKey, ApplicationUserSessionHeader);
            });
        }

        #endregion

        #region gcsSetting Operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsSetting GetSetting(gcsSetting setting, bool bCreateIfNotFound)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                gcsSetting entity = null;
                if (setting.SettingId != Guid.Empty)
                {
                    ValidateEntityAuthorizationAndSetupOperation(setting.EntityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId);
                    entity = repository.Get(setting.SettingId, ApplicationUserSessionHeader, null);
                }
                else
                {
                    if (setting.EntityId == Guid.Empty)
                        setting.EntityId = ApplicationUserSessionHeader.CurrentEntityId;

                    entity = repository.GetByUniqueKey(setting.EntityId, setting.SettingGroup, setting.SettingSubGroup, setting.SettingKey);
                }
                if (entity == null)
                {   // if no setting is found, return the same object that was passed in, but set the PK to Guid.Empty. This way, the caller can pass 
                    // desired default values in the parameter and they will be returned if there is not a record already.
                    if (bCreateIfNotFound == true)
                    {
                        setting.SettingId = Guid.Empty;
                        return SaveSetting(new SaveParameters<gcsSetting>(setting));
                    }
                    entity = setting;
                    entity.SettingId = Guid.Empty;
                    //NotFoundException ex = new NotFoundException(string.Format("gcsApplicationSetting with ID of {0} not found", entityId));
                    //ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                ValidateEntityAuthorizationAndSetupOperation(entity.EntityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId);

                return entity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsSetting GetSettingFromParams(Guid entityId, string group, string subGroup, string key, string defaultValue, bool bCreateIfNotFound)
        {
            ValidateEntityAuthorizationAndSetupOperation(entityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId);
            var repository = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

            var entity = repository.GetByUniqueKey(entityId, group, subGroup, key);
            if (entity == null)
            {   // if no setting is found, return the same object that was passed in, but set the PK to Guid.Empty. This way, the caller can pass 
                // desired default values in the parameter and they will be returned if there is not a record already.
                entity = new gcsSetting()
                {
                    SettingId = Guid.Empty,
                    EntityId = entityId,
                    SettingGroup = group,
                    SettingSubGroup = subGroup,
                    SettingKey = key,
                    Value = defaultValue
                };
                if (bCreateIfNotFound == true)
                {
                    return SaveSetting(new SaveParameters<gcsSetting>(entity));
                }
                //NotFoundException ex = new NotFoundException(string.Format("gcsApplicationSetting with ID of {0} not found", entityId));
                //ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
            }

            return entity;
        }

        public gcsSetting[] GetSettingsForEntity(Guid entityId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateEntityAuthorizationAndSetupOperation(entityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                var settings = repository.GetAllForEntity(entityId);

                return settings.ToArray();
            });
        }

        public gcsSetting[] GetSettingsForEntityAndGroup(Guid entityId, string group)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateEntityAuthorizationAndSetupOperation(entityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                var settings = repository.GetSettingsForEntityAndGroup(entityId, group);

                return settings.ToArray();
            });
        }

        public gcsSetting[] GetSettingsForEntityGroupAndSubGroup(Guid entityId, string group, string subGroup)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateEntityAuthorizationAndSetupOperation(entityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                var settings = repository.GetSettingsForEntityGroupAndSubGroup(entityId, group, subGroup);

                return settings.ToArray();
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public gcsSetting SaveSetting(SaveParameters<gcsSetting> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateEntityAuthorizationAndSetupOperation(parameters.Data.EntityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanUpdateId);
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                gcsSetting updatedSetting = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex =
                        new DuplicateIndexException($"gcsSetting with SettingGroup of '{parameters.Data.SettingGroup}', SettingSubGroup of {parameters.Data.SettingSubGroup} and Key of {parameters.Data.SettingKey} cannot be saved because it is a duplicate for EntityId '{parameters.Data.EntityId}");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                UpdateProperties(parameters.Data);
                if (parameters.Data.SettingId == Guid.Empty)
                {
                    ValidateEntityAuthorizationAndSetupOperation(parameters.Data.EntityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanAddId);
                    parameters.Data.SettingId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                    updatedSetting = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    ValidateEntityAuthorizationAndSetupOperation(parameters.Data.EntityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanUpdateId);
                    updatedSetting = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                return updatedSetting;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteSettingByPk(Guid settingId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();
                var data = repository.Get(settingId,this.ApplicationUserSessionHeader, new GetParametersWithPhoto());
                if( data != null)
                    ValidateEntityAuthorizationAndSetupOperation(data.EntityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanDeleteId);

                return repository.Remove(settingId, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteSetting(gcsSetting setting)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateEntityAuthorizationAndSetupOperation(setting.EntityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanDeleteId);
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                return repository.Remove(setting, ApplicationUserSessionHeader);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteSettingFromParams(Guid entityId, string group, string subGroup, string key)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateEntityAuthorizationAndSetupOperation(entityId, PermissionIds.GalaxySMSDataAccessPermission.EntityCanDeleteId);
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                return repository.DeleteByUniqueKey(entityId, group, subGroup, key, ApplicationUserSessionHeader);
            });
        }

        #endregion

        #region gcsSerializedObject operations

        public gcsSerializedObject GetSerializedObject(Guid serializedObjectId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSerializedObjectRepository>();

                var item = repository.Get(serializedObjectId, ApplicationUserSessionHeader, null);
                if (item == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("gcsSerializedObject with ID of {0} not found", serializedObjectId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return item;
            });
        }

        public gcsSerializedObject GetSerializedObjectByApplicationIdAndKey(Guid applicationId, string key)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSerializedObjectRepository>();

                var item = repository.GetForApplicationAndKey(applicationId, key, ApplicationUserSessionHeader);
                if (item == null)
                {
                    NotFoundException ex = new NotFoundException($"gcsSerializedObject with ApplicationId:{applicationId} and Key:{key} not found");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return item;
            });
        }

        public gcsSerializedObject SaveSerializedObject(SaveParameters<gcsSerializedObject> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSerializedObjectRepository>();

                gcsSerializedObject updatedItem = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            $"gcsSerializedObject with ApplicationId:{parameters.Data.ApplicationId} and Key:{parameters.Data.Key} cannot be saved because it is a duplicate.");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.SerializedObjectId == Guid.Empty)
                {
                    parameters.Data.SerializedObjectId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.SerializedObjectId) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding Serialized Object - {parameters.Data.ApplicationId}:{parameters.Data.Key}.");
                    updatedItem = repository.Add(parameters.Data, ApplicationUserSessionHeader, null);
                }
                else
                {
                    updatedItem = repository.Update(parameters.Data, ApplicationUserSessionHeader, null);
                }

                return updatedItem;
            });
        }

        public int DeleteSerializedObjectByPk(Guid serializedObjectId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsSerializedObjectRepository>();

                return repository.Remove(serializedObjectId, ApplicationUserSessionHeader);
            });
        }
        #endregion

        #region gcsLargeObjectStorage operations

        public gcsLargeObjectStorage GetLargeObject(Guid uid)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLargeObjectStorageRepository>();

                var item = repository.Get(uid, ApplicationUserSessionHeader, null);
                if (item == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("IGcsLargeObjectStorage with ID of {0} not found", uid));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return item;
            });
        }

        public gcsLargeObjectStorage GetLargeObjectByEntityIdAndUniqueTag(Guid entityId, string uniqueTag)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLargeObjectStorageRepository>();

                var item = repository.GetForEntityAndUniqueTag(entityId, uniqueTag, ApplicationUserSessionHeader);
                if (item == null)
                {
                    NotFoundException ex = new NotFoundException($"gcsSerializedObject with EntityId:{entityId} and UniqueTag:{uniqueTag} not found");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return item;
            });
        }

        public gcsLargeObjectStorage SaveLargeObject(SaveParameters<gcsLargeObjectStorage> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLargeObjectStorageRepository>();

                gcsLargeObjectStorage updatedItem = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex =
                        new DuplicateIndexException(
                            $"gcsLargeObjectStorage with EntityId:{parameters.Data.EntityId} and UniqueTag:{parameters.Data.UniqueTag} cannot be saved because it is a duplicate.");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.Uid == Guid.Empty)
                {
                    parameters.Data.Uid = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.Uid) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding Large Object Storage Object - {parameters.Data.EntityId}:{parameters.Data.UniqueTag}.");
                    updatedItem = repository.Add(parameters.Data, ApplicationUserSessionHeader, null);
                }
                else
                {
                    updatedItem = repository.Update(parameters.Data, ApplicationUserSessionHeader, null);
                }

                return updatedItem;
            });
        }

        public int DeleteLargeObjectByPk(Guid uid)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsLargeObjectStorageRepository>();

                return repository.Remove(uid, ApplicationUserSessionHeader);
            });
        }
        #endregion



        #region InitializeSystemDatabase
        [OperationBehavior(TransactionScopeRequired = true)]
        public bool InitializeSystemDatabase(InitializeSystemDatabaseRequest requestData)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                if (!requestData.InitializeSystemTables)
                    return true;
                var systemRepository = _DataRepositoryFactory.GetDataRepository<IGcsSystemRepository>();
                var permissionTypeRepository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionTypeRepository>();
                var propertySensitivityLevelRepository = _DataRepositoryFactory.GetDataRepository<IPropertySensitivityLevelRepository>();
                var applicationAuditTypeRepository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationAuditTypeRepository>();
                var languageRepository = _DataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();
                var entityRepository = _DataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();
                var roleRepository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();
                var applicationRepository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationRepository>();
                var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                //var entityApplicationRepository = _DataRepositoryFactory.GetDataRepository<IGcsEntityApplicationRepository>();
                //var entityApplicationRoleRepository = _DataRepositoryFactory.GetDataRepository<IGcsEntityApplicationRoleRepository>();

                var badgeSystemTypeRepository = _DataRepositoryFactory.GetDataRepository<IBadgeSystemTypeRepository>();
                var biometricSystemTypeRepository = _DataRepositoryFactory.GetDataRepository<IBiometricSystemTypeRepository>();

                //var userEntityApplicationRoleRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserEntityApplicationRoleRepository>();

                if (requestData.SystemData.SystemId != Guid.Empty)
                {
                    if (systemRepository.DoesExist(requestData.SystemData.SystemId) == false)
                    {
                        Globals.Instance.SystemData = SaveSystem(new SaveParameters<gcsSystem>(requestData.SystemData));
                    }
                }


                foreach (var lang in requestData.Languages)
                {
                    if (languageRepository.DoesExist(lang.LanguageId) == false)
                        SaveLanguage(new SaveParameters<gcsLanguage>() { Data = lang });
                }

                foreach (var at in requestData.ApplicationAuditTypes)
                {
                    if (applicationAuditTypeRepository.DoesExist(at.ApplicationAuditTypeId) == false)
                    {
                        SaveApplicationAuditType(new SaveParameters<gcsApplicationAuditType>(at));
                    }
                }

                #region Audit Types
                var auditTypes = new List<gcsApplicationAuditType>();

                var auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_ApplicationLaunched;
                auditType.Display = Resources.Resources.ApplicationAudit_ApplicationLaunched_Display;
                auditType.Description = Resources.Resources.ApplicationAudit_ApplicationLaunched_Display;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_ApplicationLaunched;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_ApplicationLaunched.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_ApplicationShutdown;
                auditType.Display = Resources.Resources.ApplicationAudit_ApplicationShutdown_Display;
                auditType.Description = Resources.Resources.ApplicationAudit_ApplicationShutdown_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_ApplicationShutdown;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_ApplicationShutdown.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInRequest;
                auditType.Display = Resources.Resources.ApplicationAudit_UserSignInRequest_Display;
                auditType.Description = Resources.Resources.ApplicationAudit_UserSignInRequest_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInRequest;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInRequest.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignOut;
                auditType.Display = Resources.Resources.ApplicationAudit_UserSignOut_Display;
                auditType.Description = Resources.Resources.ApplicationAudit_UserSignOut_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignOut;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignOut.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultSuccess;
                auditType.Display = Resources.Resources.ApplicationAudit_UserSignInResultSuccess_Display;
                auditType.Description = Resources.Resources.ApplicationAudit_UserSignInResultSuccess_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultSuccess;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultSuccess.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInSuccessInfoNone;
                auditType.Display = Resources.Resources.ApplicationAudit_UserSignInSuccessInfoNone_Display;
                auditType.Description = Resources.Resources.ApplicationAudit_UserSignInSuccessInfoNone_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInSuccessInfoNone;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInSuccessInfoNone.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId =
                    ApplicationAuditTypeIds.GalaxySMS_UserSignInSuccessInfoUserAccountSoonToExpire;
                auditType.Display =
                    Resources.Resources.ApplicationAudit_UserSignInSuccessInfoUserAccountSoonToExpire_Display;
                auditType.Description =
                    Resources.Resources.ApplicationAudit_UserSignInSuccessInfoUserAccountSoonToExpire_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInSuccessInfoUserAccountSoonToExpire;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInSuccessInfoUserAccountSoonToExpire.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId =
                    ApplicationAuditTypeIds.GalaxySMS_UserSignInSuccessInfoPasswordMustBeChanged;
                auditType.Display =
                    Resources.Resources.ApplicationAudit_UserSignInSuccessInfoPasswordMustBeChanged_Display;
                auditType.Description =
                    Resources.Resources.ApplicationAudit_UserSignInSuccessInfoPasswordMustBeChanged_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInSuccessInfoPasswordMustBeChanged;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInSuccessInfoPasswordMustBeChanged.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultInvalidUserName;
                auditType.Display = Resources.Resources.ApplicationAudit_UserSignInResultInvalidUserName_Display;
                auditType.Description = Resources.Resources.ApplicationAudit_UserSignInResultInvalidUserName_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultInvalidUserName;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultInvalidUserName.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultInvalidPassword;
                auditType.Display = Resources.Resources.ApplicationAudit_UserSignInResultInvalidPassword_Display;
                auditType.Description = Resources.Resources.ApplicationAudit_UserSignInResultInvalidPassword_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultInvalidPassword;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultInvalidPassword.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultUserAccountIsNotActive;
                auditType.Display = Resources.Resources.ApplicationAudit_UserSignInResultUserAccountIsNotActive_Display;
                auditType.Description = Resources.Resources.ApplicationAudit_UserSignInResultUserAccountIsNotActive_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultUserAccountIsNotActive;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultUserAccountIsNotActive.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultUserAccountIsLockedOut;
                auditType.Display = Resources.Resources.ApplicationAudit_UserSignInResultUserAccountIsLockedOut_Display;
                auditType.Description = Resources.Resources.ApplicationAudit_UserSignInResultUserAccountIsLockedOut_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultUserAccountIsLockedOut;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultUserAccountIsLockedOut.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType();
                auditType.ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultApplicationNotPermitted;
                auditType.Description = Resources.Resources.ApplicationAudit_UserSignInResultApplicationNotPermitted_Display;
                auditType.Display = Resources.Resources.ApplicationAudit_UserSignInResultApplicationNotPermitted_Description;
                auditType.TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultApplicationNotPermitted;
                auditType.UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultApplicationNotPermitted.ToString();
                auditTypes.Add(auditType);

                auditType = new gcsApplicationAuditType()
                {
                    ApplicationAuditTypeId = ApplicationAuditTypeIds.GalaxySMS_UserSignInResultApplicationNotPermitted,
                    Display = Resources.Resources.ApplicationAudit_UserSignInResultApplicationNotPermitted_Display,
                    Description = Resources.Resources.ApplicationAudit_UserSignInResultApplicationNotPermitted_Description,
                    TypeCode = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultApplicationNotPermitted,
                    UniqueResourceName = ApplicationAuditTypeCodes.GalaxySMS_UserSignInResultApplicationNotPermitted.ToString()
                };
                auditTypes.Add(auditType);
                #endregion

                foreach (var at in auditTypes)
                {
                    if (applicationAuditTypeRepository.DoesExist(at.ApplicationAuditTypeId) == false)
                    {
                        SaveApplicationAuditType(new SaveParameters<gcsApplicationAuditType>() { Data = at });
                    }
                }

                #region Badge System Types
                var badgeSystemTypes = new List<BadgeSystemType>();
                var badgeSystemType = new BadgeSystemType()
                {
                    BadgeSystemTypeUid = GalaxySMS.Common.Constants.BadgeSystemTypeIds.None,
                    TypeCode = GalaxySMS.Common.Enums.BadgeSystemType.None.ToString(),
                    Name = Resources.Resources.BadgeSystemType_None
                };
                badgeSystemTypes.Add(badgeSystemType);

                badgeSystemType = new BadgeSystemType()
                {
                    BadgeSystemTypeUid = GalaxySMS.Common.Constants.BadgeSystemTypeIds.IdProducer,
                    TypeCode = GalaxySMS.Common.Enums.BadgeSystemType.IdProducer.ToString(),
                    Name = Resources.Resources.BadgeSystemType_IdProducer
                };
                badgeSystemTypes.Add(badgeSystemType);

                foreach (var bt in badgeSystemTypes)
                {
                    if (badgeSystemTypeRepository.DoesExist(bt.BadgeSystemTypeUid) == false)
                    {
                        SaveBadgeSystemType(bt);
                    }
                }
                #endregion

                #region Biometric System Types
                var biometricSystemTypes = new List<BiometricSystemType>();
                var biometricSystemType = new BiometricSystemType()
                {
                    BiometricSystemTypeUid = GalaxySMS.Common.Constants.BiometricSystemTypeIds.None,
                    TypeCode = GalaxySMS.Common.Enums.BiometricSystemType.None.ToString(),
                    Name = Resources.Resources.BiometricSystemType_None
                };
                biometricSystemTypes.Add(biometricSystemType);

                biometricSystemType = new BiometricSystemType()
                {
                    BiometricSystemTypeUid = GalaxySMS.Common.Constants.BiometricSystemTypeIds.MorphoManagerBioBridge,
                    TypeCode = GalaxySMS.Common.Enums.BiometricSystemType.MorphoManagerBioBridge.ToString(),
                    Name = Resources.Resources.BiometricSystemType_MorphoManagerBioBridge
                };
                biometricSystemTypes.Add(biometricSystemType);


                biometricSystemType = new BiometricSystemType()
                {
                    BiometricSystemTypeUid = GalaxySMS.Common.Constants.BiometricSystemTypeIds.InvixiumIxmWeb,
                    TypeCode = GalaxySMS.Common.Enums.BiometricSystemType.InvixiumIxmWeb.ToString(),
                    Name = Resources.Resources.BiometricSystemType_InvixiumIxmWeb
                };
                biometricSystemTypes.Add(biometricSystemType);

                foreach (var bt in biometricSystemTypes)
                {
                    if (biometricSystemTypeRepository.DoesExist(bt.BiometricSystemTypeUid) == false)
                    {
                        SaveBiometricSystemType(bt);
                    }
                }
                #endregion

                #region Permission Types
                var permissionTypes = new List<gcsPermissionType>();

                permissionTypes.Add(new gcsPermissionType()
                {
                    PermissionTypeId = GalaxySMS.Common.Constants.PermissionTypeIds.ExecuteId,
                    PermissionTypeCode = GalaxySMS.Common.Enums.PermissionType.Execute,
                    Display = SharedResources.Resources.PermissionType_Execute_Display,
                    Description = SharedResources.Resources.PermissionType_Execute_Description,
                    UniqueResourceName = string.Format("{0}:{1}", typeof(GalaxySMS.Common.Enums.PermissionType).ToString(), GalaxySMS.Common.Enums.PermissionType.Execute.ToString())
                });

                permissionTypes.Add(new gcsPermissionType()
                {
                    PermissionTypeId = GalaxySMS.Common.Constants.PermissionTypeIds.ViewId,
                    PermissionTypeCode = GalaxySMS.Common.Enums.PermissionType.Read,
                    Display = SharedResources.Resources.PermissionType_Read_Display,
                    Description = SharedResources.Resources.PermissionType_Read_Description,
                    UniqueResourceName = string.Format("{0}:{1}", typeof(GalaxySMS.Common.Enums.PermissionType).ToString(), GalaxySMS.Common.Enums.PermissionType.Read.ToString())
                });

                permissionTypes.Add(new gcsPermissionType()
                {
                    PermissionTypeId = GalaxySMS.Common.Constants.PermissionTypeIds.EditUpdateId,
                    PermissionTypeCode = GalaxySMS.Common.Enums.PermissionType.Edit,
                    Display = SharedResources.Resources.PermissionType_Edit_Display,
                    Description = SharedResources.Resources.PermissionType_Edit_Description,
                    UniqueResourceName = string.Format("{0}:{1}", typeof(GalaxySMS.Common.Enums.PermissionType).ToString(), GalaxySMS.Common.Enums.PermissionType.Edit.ToString())
                });

                permissionTypes.Add(new gcsPermissionType()
                {
                    PermissionTypeId = GalaxySMS.Common.Constants.PermissionTypeIds.AddId,
                    PermissionTypeCode = GalaxySMS.Common.Enums.PermissionType.Add,
                    Display = SharedResources.Resources.PermissionType_Add_Display,
                    Description = SharedResources.Resources.PermissionType_Add_Description,
                    UniqueResourceName = string.Format("{0}:{1}", typeof(GalaxySMS.Common.Enums.PermissionType).ToString(), GalaxySMS.Common.Enums.PermissionType.Add.ToString())
                });

                permissionTypes.Add(new gcsPermissionType()
                {
                    PermissionTypeId = GalaxySMS.Common.Constants.PermissionTypeIds.DeleteId,
                    PermissionTypeCode = GalaxySMS.Common.Enums.PermissionType.Delete,
                    Display = SharedResources.Resources.PermissionType_Delete_Display,
                    Description = SharedResources.Resources.PermissionType_Delete_Description,
                    UniqueResourceName = string.Format("{0}:{1}", typeof(GalaxySMS.Common.Enums.PermissionType).ToString(), GalaxySMS.Common.Enums.PermissionType.Delete.ToString())
                });

                permissionTypes.Add(new gcsPermissionType()
                {
                    PermissionTypeId = GalaxySMS.Common.Constants.PermissionTypeIds.ViewPropertyId,
                    PermissionTypeCode = GalaxySMS.Common.Enums.PermissionType.ViewProperty,
                    Display = SharedResources.Resources.PermissionType_ViewProperty_Display,
                    Description = SharedResources.Resources.PermissionType_ViewProperty_Description,
                    UniqueResourceName = string.Format("{0}:{1}", typeof(GalaxySMS.Common.Enums.PermissionType).ToString(), GalaxySMS.Common.Enums.PermissionType.ViewProperty.ToString())
                });

                permissionTypes.Add(new gcsPermissionType()
                {
                    PermissionTypeId = GalaxySMS.Common.Constants.PermissionTypeIds.EditPropertyId,
                    PermissionTypeCode = GalaxySMS.Common.Enums.PermissionType.EditProperty,
                    Display = SharedResources.Resources.PermissionType_EditProperty_Display,
                    Description = SharedResources.Resources.PermissionType_EditProperty_Description,
                    UniqueResourceName = string.Format("{0}:{1}", typeof(GalaxySMS.Common.Enums.PermissionType).ToString(), GalaxySMS.Common.Enums.PermissionType.EditProperty.ToString())
                });


                foreach (var pt in permissionTypes)
                {
                    if (permissionTypeRepository.DoesExist(pt.PermissionTypeId) == false)
                    {
                        SavePermissionType(new SaveParameters<gcsPermissionType>() { Data = pt });
                    }
                }

                #endregion

                #region User Defined Property Type

                var userDefinedPropertyTypes = new List<UserDefinedPropertyType>();

                var userDefinedPropertyType = new UserDefinedPropertyType()
                {
                    PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Text,
                    PropertyType = "Text"
                };
                userDefinedPropertyTypes.Add(userDefinedPropertyType);

                userDefinedPropertyType = new UserDefinedPropertyType()
                {
                    PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Number,
                    PropertyType = "Number"
                };
                userDefinedPropertyTypes.Add(userDefinedPropertyType);

                userDefinedPropertyType = new UserDefinedPropertyType()
                {
                    PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Boolean,
                    PropertyType = "Boolean"
                };
                userDefinedPropertyTypes.Add(userDefinedPropertyType);

                userDefinedPropertyType = new UserDefinedPropertyType()
                {
                    PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Date,
                    PropertyType = "Date"
                };
                userDefinedPropertyTypes.Add(userDefinedPropertyType);

                userDefinedPropertyType = new UserDefinedPropertyType()
                {
                    PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.List,
                    PropertyType = "List"
                };
                userDefinedPropertyTypes.Add(userDefinedPropertyType);

                userDefinedPropertyType = new UserDefinedPropertyType()
                {
                    PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Guid,
                    PropertyType = "GUID"
                };
                userDefinedPropertyTypes.Add(userDefinedPropertyType);

                userDefinedPropertyType = new UserDefinedPropertyType()
                {
                    PropertyTypeUid = GalaxySMS.Common.Constants.UserDefinedPropertyTypeIds.Photo,
                    PropertyType = "Photo"
                };
                userDefinedPropertyTypes.Add(userDefinedPropertyType);

                var userDefinedPropertyTypeRepository =
                    _DataRepositoryFactory.GetDataRepository<IUserDefinedPropertyTypeRepository>();

                foreach (var o in userDefinedPropertyTypes)
                {
                    if (userDefinedPropertyTypeRepository.DoesExist(o.PropertyTypeUid) == false &&
                        userDefinedPropertyTypeRepository.IsUnique(o))
                    {
                        UpdateProperties(o);
                        this.Log().Info($"Adding UserDefinedPropertyType - {o.PropertyType}.");
                        userDefinedPropertyTypeRepository.Add(o, ApplicationUserSessionHeader, new SaveParameters());
                    }
                }
                #endregion

                #region Property Sensitivity Levels
                var propertySensitivityLevels = new List<PropertySensitivityLevel>();
                var savedPropertySensitivityLevels = new List<PropertySensitivityLevel>();

                var propertySensitivityLevel = new PropertySensitivityLevel()
                {
                    PropertySensitivityLevelUid = PropertySensitivityLevelIds.Public,
                    SensitivityLevel = GalaxySMS.Common.Enums.SensitivityLevel.Public,
                    Display = SharedResources.Resources.Property_SensitivityLevel_Public_Display,
                    Description = SharedResources.Resources.Property_SensitivityLevel_Public_Description,
                    UniqueResourceName = string.Format("{0}:{1}", typeof(GalaxySMS.Common.Enums.SensitivityLevel).ToString(), GalaxySMS.Common.Enums.SensitivityLevel.Public.ToString())
                };
                propertySensitivityLevel.PropertySensitivityLevelPermissions.Add(new PropertySensitivityLevelPermission()
                {
                    PermissionId = PermissionIds.GalaxySMSPropertyAccessPermission.PersonnelPublicPropertyAccessCanEditId,
                    IsDirty = true
                });
                propertySensitivityLevel.PropertySensitivityLevelPermissions.Add(new PropertySensitivityLevelPermission()
                {
                    PermissionId = PermissionIds.GalaxySMSPropertyAccessPermission.PersonnelPublicPropertyAccessCanViewId,
                    IsDirty = true
                });
                propertySensitivityLevels.Add(propertySensitivityLevel);

                propertySensitivityLevel = new PropertySensitivityLevel()
                {
                    PropertySensitivityLevelUid = PropertySensitivityLevelIds.Confidential,
                    SensitivityLevel = GalaxySMS.Common.Enums.SensitivityLevel.Confidential,
                    Display = SharedResources.Resources.Property_SensitivityLevel_Confidential_Display,
                    Description = SharedResources.Resources.Property_SensitivityLevel_Confidential_Description,
                    UniqueResourceName = string.Format("{0}:{1}", typeof(GalaxySMS.Common.Enums.SensitivityLevel).ToString(), GalaxySMS.Common.Enums.SensitivityLevel.Confidential.ToString())
                };
                propertySensitivityLevel.PropertySensitivityLevelPermissions.Add(new PropertySensitivityLevelPermission()
                {
                    PermissionId = PermissionIds.GalaxySMSPropertyAccessPermission.PersonnelConfidentialPropertyAccessCanViewId,
                    IsDirty = true
                });
                propertySensitivityLevel.PropertySensitivityLevelPermissions.Add(new PropertySensitivityLevelPermission()
                {
                    PermissionId = PermissionIds.GalaxySMSPropertyAccessPermission.PersonnelConfidentialPropertyAccessCanEditId,
                    IsDirty = true
                });
                propertySensitivityLevels.Add(propertySensitivityLevel);

                foreach (var sensitivityLevel in propertySensitivityLevels)
                {
                    if (propertySensitivityLevelRepository.DoesExist(sensitivityLevel.PropertySensitivityLevelUid) == false)
                    {
                        var saveParams = new SaveParameters<PropertySensitivityLevel>() { Data = sensitivityLevel };
                        // Must ignore the child collection at this time because the Permissions don't yet exist. They will be created by the saveApplication step.

                        saveParams.IgnoreProperties.Add(nameof(sensitivityLevel.PropertySensitivityLevelPermissions));

                        var o = SavePropertySensitivityLevel(saveParams);
                        savedPropertySensitivityLevels.Add(o);
                    }
                }
                #endregion

                foreach (var app in requestData.Applications)
                {
                    gcsApplication savedApp = app;
                    if (applicationRepository.DoesExist(app.ApplicationId) == false)
                    {
                        savedApp = SaveApplication(new SaveParameters<gcsApplication>() { Data = app });

                        //foreach (var ea in app.gcsEntityApplications)
                        //{
                        //    ea.ApplicationId = savedApp.ApplicationId;
                        //    if (ea.EntityApplicationId == Guid.Empty)
                        //        ea.EntityApplicationId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                        //    ea.InsertDate = DateTimeOffset.Now;
                        //    ea.InsertName = LoginName;
                        //    ea.UpdateDate = ea.InsertDate;
                        //    ea.UpdateName = LoginName;
                        //    var savedEntityApplication = entityApplicationRepository.Add(ea,
                        //        ApplicationUserSessionHeader, null, null);

                        //    foreach (var role in savedApp.AllRoles)
                        //    {
                        //        var entityApplicationRole = new gcsEntityApplicationRole();
                        //        if (entityApplicationRole.EntityApplicationRoleId == Guid.Empty)
                        //            entityApplicationRole.EntityApplicationRoleId = GuidUtilities.GenerateComb();
                        //        //Guid.NewGuid();
                        //        entityApplicationRole.EntityApplicationId = savedEntityApplication.EntityApplicationId;
                        //        entityApplicationRole.RoleId = role.RoleId;
                        //        entityApplicationRole.InsertDate = DateTimeOffset.Now;
                        //        entityApplicationRole.InsertName = LoginName;
                        //        entityApplicationRole.UpdateDate = DateTimeOffset.Now;
                        //        entityApplicationRole.UpdateName = LoginName;
                        //        entityApplicationRoleRepository.Add(entityApplicationRole, ApplicationUserSessionHeader,
                        //            null, null);
                        //    }
                        //}

                        var b = applicationRepository.EnsureDefaultUserEntityApplicationRolesExist(savedApp, ApplicationUserSessionHeader);

                    }
                    // Uncomment this block to re-insert default values
                    else
                    {   // the application exists, but perhaps there are new permissions and/or roles
                        var permissionCategoryRepository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();
                        foreach (var permissionCategory in app.PermissionCategories)
                        {
                            if (permissionCategoryRepository.DoesExist(permissionCategory.PermissionCategoryId) == false)
                            {
                                permissionCategory.ApplicationId = app.ApplicationId;
                                this.Log().Info($"Adding PermissionCategory - {permissionCategory.CategoryName}.");
                                SavePermissionCategory(new SaveParameters<gcsPermissionCategory>() { Data = permissionCategory });
                            }
                            else
                            {
                                var permissionRepository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();
                                foreach (var permission in permissionCategory.Permissions)
                                {
                                    if (permissionRepository.DoesExist(permission.PermissionId) == false)
                                    {
                                        permission.PermissionCategoryId = permissionCategory.PermissionCategoryId;
                                        this.Log().Info($"Adding Permission - {permission.PermissionName}.");
                                        SavePermission(new SaveParameters<gcsPermission>() { Data = permission });
                                    }
                                }
                            }
                        }

                        //var roleRepository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();
                        //foreach (gcsRole role in app.AllRoles)
                        //{
                        //    if (roleRepository.DoesExist(role.RoleId) == false)
                        //    {
                        //        role.EntityId = app.ApplicationId;
                        //        this.Log().Info($"Adding Role - {role.RoleName}.");
                        //        SaveRole(new SaveParameters<gcsRole>() { Data = role });
                        //    }
                        //    else
                        //    {
                        //        var rolePermissionRepository = _DataRepositoryFactory.GetDataRepository<IGcsRolePermissionRepository>();

                        //        var existingRolePermissions = rolePermissionRepository.GetAllForRole(role.RoleId);
                        //        var deleteTheseRolePermissions = existingRolePermissions.Where(rp => !role.RolePermissions.Any(rp2 => rp2.PermissionId == rp.PermissionId));
                        //        foreach (var rolePermission in deleteTheseRolePermissions)
                        //        {
                        //            rolePermissionRepository.Remove(rolePermission, ApplicationUserSessionHeader, null);
                        //        }

                        //        foreach (var rolePermission in role.RolePermissions)
                        //        {
                        //            var existingRolePermission = existingRolePermissions.FirstOrDefault(o => o.RoleId == rolePermission.RoleId && o.PermissionId == rolePermission.PermissionId);
                        //            if (existingRolePermission == null)
                        //            {
                        //                if (rolePermission.RolePermissionId == Guid.Empty)
                        //                    rolePermission.RolePermissionId = GuidUtilities.GenerateComb(); //Guid.NewGuid();

                        //                if (rolePermissionRepository.DoesExist(rolePermission.RolePermissionId) == false)
                        //                {
                        //                    rolePermission.RoleId = role.RoleId;
                        //                    rolePermission.UpdateDate = DateTimeOffset.Now;
                        //                    rolePermission.UpdateName = LoginName;
                        //                    rolePermission.InsertDate = DateTimeOffset.Now;
                        //                    rolePermission.InsertName = LoginName;
                        //                    var savedrolePermission = rolePermissionRepository.Add(rolePermission, ApplicationUserSessionHeader, null, null);
                        //                }
                        //            }
                        //        }

                        //    }
                        //}
                    }

                }

                foreach (var ent in requestData.Entities)
                {
                    if (entityRepository.DoesExist(ent.EntityId) == false)
                    {
                        var saveParams = new SaveParameters<gcsEntity>()
                        {
                            Data = ent,
                            RequestDateTime = GalaxySMS.Common.Constants.MagicStuff.MagicDate
                        };
                        //saveParams.IgnoreProperties.Add(nameof(ent.gcsEntityApplications));
                        var savedEntity = SaveEntity(saveParams);
                    }
                }

                //foreach (var app in requestData.Applications)
                //{
                //    gcsApplication savedApp = app;
                //    if (applicationRepository.DoesExist(app.ApplicationId) == false)
                //    {
                //        savedApp = SaveApplication(new SaveParameters<gcsApplication>() { Data = app });

                //        //foreach (var ea in app.gcsEntityApplications)
                //        //{
                //        //    ea.ApplicationId = savedApp.ApplicationId;
                //        //    if (ea.EntityApplicationId == Guid.Empty)
                //        //        ea.EntityApplicationId = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                //        //    ea.InsertDate = DateTimeOffset.Now;
                //        //    ea.InsertName = LoginName;
                //        //    ea.UpdateDate = ea.InsertDate;
                //        //    ea.UpdateName = LoginName;
                //        //    var savedEntityApplication = entityApplicationRepository.Add(ea,
                //        //        ApplicationUserSessionHeader, null, null);

                //        //    foreach (var role in savedApp.AllRoles)
                //        //    {
                //        //        var entityApplicationRole = new gcsEntityApplicationRole();
                //        //        if (entityApplicationRole.EntityApplicationRoleId == Guid.Empty)
                //        //            entityApplicationRole.EntityApplicationRoleId = GuidUtilities.GenerateComb();
                //        //        //Guid.NewGuid();
                //        //        entityApplicationRole.EntityApplicationId = savedEntityApplication.EntityApplicationId;
                //        //        entityApplicationRole.RoleId = role.RoleId;
                //        //        entityApplicationRole.InsertDate = DateTimeOffset.Now;
                //        //        entityApplicationRole.InsertName = LoginName;
                //        //        entityApplicationRole.UpdateDate = DateTimeOffset.Now;
                //        //        entityApplicationRole.UpdateName = LoginName;
                //        //        entityApplicationRoleRepository.Add(entityApplicationRole, ApplicationUserSessionHeader,
                //        //            null, null);
                //        //    }
                //        //}

                //        var b = applicationRepository.EnsureDefaultUserEntityApplicationRolesExist(savedApp, ApplicationUserSessionHeader);

                //    }
                //    // Uncomment this block to re-insert default values
                //    else
                //    {   // the application exists, but perhaps there are new permissions and/or roles
                //        var permissionCategoryRepository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionCategoryRepository>();
                //        foreach (var permissionCategory in app.gcsPermissionCategories)
                //        {
                //            if (permissionCategoryRepository.DoesExist(permissionCategory.PermissionCategoryId) == false)
                //            {
                //                permissionCategory.ApplicationId = app.ApplicationId;
                //                this.Log().Info($"Adding PermissionCategory - {permissionCategory.CategoryName}.");
                //                SavePermissionCategory(new SaveParameters<gcsPermissionCategory>() { Data = permissionCategory });
                //            }
                //            else
                //            {
                //                var permissionRepository = _DataRepositoryFactory.GetDataRepository<IGcsPermissionRepository>();
                //                foreach (var permission in permissionCategory.gcsPermissions)
                //                {
                //                    if (permissionRepository.DoesExist(permission.PermissionId) == false)
                //                    {
                //                        permission.PermissionCategoryId = permissionCategory.PermissionCategoryId;
                //                        this.Log().Info($"Adding Permission - {permission.PermissionName}.");
                //                        SavePermission(new SaveParameters<gcsPermission>() { Data = permission });
                //                    }
                //                }
                //            }
                //        }

                //        //var roleRepository = _DataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();
                //        //foreach (gcsRole role in app.AllRoles)
                //        //{
                //        //    if (roleRepository.DoesExist(role.RoleId) == false)
                //        //    {
                //        //        role.EntityId = app.ApplicationId;
                //        //        this.Log().Info($"Adding Role - {role.RoleName}.");
                //        //        SaveRole(new SaveParameters<gcsRole>() { Data = role });
                //        //    }
                //        //    else
                //        //    {
                //        //        var rolePermissionRepository = _DataRepositoryFactory.GetDataRepository<IGcsRolePermissionRepository>();

                //        //        var existingRolePermissions = rolePermissionRepository.GetAllForRole(role.RoleId);
                //        //        var deleteTheseRolePermissions = existingRolePermissions.Where(rp => !role.RolePermissions.Any(rp2 => rp2.PermissionId == rp.PermissionId));
                //        //        foreach (var rolePermission in deleteTheseRolePermissions)
                //        //        {
                //        //            rolePermissionRepository.Remove(rolePermission, ApplicationUserSessionHeader, null);
                //        //        }

                //        //        foreach (var rolePermission in role.RolePermissions)
                //        //        {
                //        //            var existingRolePermission = existingRolePermissions.FirstOrDefault(o => o.RoleId == rolePermission.RoleId && o.PermissionId == rolePermission.PermissionId);
                //        //            if (existingRolePermission == null)
                //        //            {
                //        //                if (rolePermission.RolePermissionId == Guid.Empty)
                //        //                    rolePermission.RolePermissionId = GuidUtilities.GenerateComb(); //Guid.NewGuid();

                //        //                if (rolePermissionRepository.DoesExist(rolePermission.RolePermissionId) == false)
                //        //                {
                //        //                    rolePermission.RoleId = role.RoleId;
                //        //                    rolePermission.UpdateDate = DateTimeOffset.Now;
                //        //                    rolePermission.UpdateName = LoginName;
                //        //                    rolePermission.InsertDate = DateTimeOffset.Now;
                //        //                    rolePermission.InsertName = LoginName;
                //        //                    var savedrolePermission = rolePermissionRepository.Add(rolePermission, ApplicationUserSessionHeader, null, null);
                //        //                }
                //        //            }
                //        //        }

                //        //    }
                //        //}
                //    }

                //}

                foreach (var ent in requestData.Entities)
                {
                    foreach (var role in ent.AllRoles)
                    {
                        if (roleRepository.DoesExist(role.RoleId) == false)
                        {
                            //this.Log().Info($"Adding Role - {role.RoleName}.");
                            SaveRole(new SaveParameters<gcsRole>() { Data = role });
                        }
                        //else
                        //{
                        //    var rolePermissionRepository = _DataRepositoryFactory.GetDataRepository<IGcsRolePermissionRepository>();

                        //    var existingRolePermissions = rolePermissionRepository.GetAllForRole(role.RoleId);
                        //    var deleteTheseRolePermissions = existingRolePermissions.Where(rp => !role.RolePermissions.Any(rp2 => rp2.PermissionId == rp.PermissionId));
                        //    foreach (var rolePermission in deleteTheseRolePermissions)
                        //    {
                        //        rolePermissionRepository.Remove(rolePermission, ApplicationUserSessionHeader, null);
                        //    }

                        //    foreach (var rolePermission in role.RolePermissions)
                        //    {
                        //        var existingRolePermission = existingRolePermissions.FirstOrDefault(o => o.RoleId == rolePermission.RoleId && o.PermissionId == rolePermission.PermissionId);
                        //        if (existingRolePermission == null)
                        //        {
                        //            if (rolePermission.RolePermissionId == Guid.Empty)
                        //                rolePermission.RolePermissionId = GuidUtilities.GenerateComb(); //Guid.NewGuid();

                        //            if (rolePermissionRepository.DoesExist(rolePermission.RolePermissionId) == false)
                        //            {
                        //                rolePermission.RoleId = role.RoleId;
                        //                rolePermission.UpdateDate = DateTimeOffset.Now;
                        //                rolePermission.UpdateName = LoginName;
                        //                rolePermission.InsertDate = DateTimeOffset.Now;
                        //                rolePermission.InsertName = LoginName;
                        //                var savedrolePermission = rolePermissionRepository.Add(rolePermission, ApplicationUserSessionHeader, null, null);
                        //            }
                        //        }
                        //    }

                        //}
                    }
                }

                foreach (var sensitivityLevel in savedPropertySensitivityLevels)
                {
                    var saveParams = new SaveParameters<PropertySensitivityLevel>() { Data = sensitivityLevel };
                    // Must call this again to get the child items to be saved.
                    SavePropertySensitivityLevel(saveParams);
                }

                foreach (var u in requestData.Users)
                {
                    if (userRepository.DoesExist(u.UserId) == false)
                    {
                        var saveUserParameters = new SaveParameters<gcsUser>(u);
                        saveUserParameters.Options.Add(new KeyValuePair<string, string>(nameof(GalaxySMS.Common.Enums.InitializingSystemOption.DontValidateAuthorization).ToString(), true.ToString()));

                        SaveUser(saveUserParameters);
                    }
                }


                return true;
            });
        }

        #endregion

        #region Country operations
        public Country[] GetAllCountries(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.CountryCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                var countries = repository.Get(ApplicationUserSessionHeader, parameters);

                return countries.ToArray();
            });
        }

        public Country GetCountry(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.CountryCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                var country = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, parameters);

                if (country == null)
                {
                    NotFoundException ex = new NotFoundException($"Country with CountryUid of {parameters.UniqueId} not found");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return country;
            });
        }

        public Country GetCountryByIso(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.CountryCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                var country = repository.GetByIso(ApplicationUserSessionHeader, parameters);
                if (country == null)
                {
                    NotFoundException ex = new NotFoundException($"Country with ISO of {parameters.GetString} not found");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return country;
            });
        }

        public Country GetCountryByIso3(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.CountryCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                var country = repository.GetByIso3(ApplicationUserSessionHeader, parameters);

                if (country == null)
                {
                    NotFoundException ex = new NotFoundException($"Country with ISO of {parameters.GetString} not found");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return country;
            });
        }

        public Country[] GetCountriesByCountryName(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.CountryCanViewId);
                var repository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                var data = repository.GetByCountryName(ApplicationUserSessionHeader, parameters);

                return data.ToArray();
            });
        }


        [OperationBehavior(TransactionScopeRequired = true)]
        public Country SaveCountry(SaveParameters<Country> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.CountryCanUpdateId);
                var repository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                Country updatedCountry = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("Country with '{0} ({1})' cannot be saved because it is a duplicate.", parameters.Data.CountryName, parameters.Data.CountryIso));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.CountryUid == Guid.Empty)
                {
                    parameters.Data.CountryUid = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.CountryUid) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding Country - {parameters.Data.CountryName}.");
                    updatedCountry = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedCountry = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                return updatedCountry;
            });
        }

        public int DeleteCountryByPk(DeleteParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, PermissionIds.GalaxySMSDataAccessPermission.CountryCanDeleteId);
                var repository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                //if (repository.IsReferenced(languageId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsLanguage with LanguageId of '{0}' cannot be deleted because it is referenced.", languageId));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}
                if (repository.CanDelete(parameters.UniqueId) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("Country with CountryUid of '{0}' cannot be deleted because it is referenced.", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    return repository.Remove(parameters.UniqueId, ApplicationUserSessionHeader);
                }

            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteCountry(DeleteParameters<Country> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<ICountryRepository>();

                //if (repository.IsReferenced(language.LanguageId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsLanguage '{0}' cannot be deleted because it is referenced.", language.LanguageName));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}

                if (repository.CanDelete(parameters.Data.CountryUid) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("Country '{0}' cannot be deleted because it is referenced.", parameters.Data.CountryName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    return repository.Remove(parameters.Data, ApplicationUserSessionHeader);
                }

            });
        }

        public StateProvince[] GetAllStatesProvinces(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ValidateAuthorizationAndSetupOperation(parameters, Guid.Empty);

                var repository = _DataRepositoryFactory.GetDataRepository<IStateProvinceRepository>();
                var statesProvinces = repository.Get(ApplicationUserSessionHeader, parameters);

                return statesProvinces.ToArray();
            });
        }

        public StateProvince[] GetAllStatesProvincesForCountry(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IStateProvinceRepository>();

                var statesProvinces = repository.GetAllForCountry(ApplicationUserSessionHeader, parameters);

                return statesProvinces.ToArray();
            });
        }

        public StateProvince GetStateProvince(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IStateProvinceRepository>();

                var entity = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, null);
                if (entity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("StateProvince with ID of {0} not found", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return entity;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public StateProvince SaveStateProvince(SaveParameters<StateProvince> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IStateProvinceRepository>();

                StateProvince updatedStateProvince = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("StateProvince with '{0} ({1})' cannot be saved because it is a duplicate.", parameters.Data.StateProvinceName, parameters.Data.StateProvinceCode));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (parameters.Data.StateProvinceUid == Guid.Empty)
                {
                    parameters.Data.StateProvinceUid = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                if (repository.DoesExist(parameters.Data.StateProvinceUid) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding State/Province - {parameters.Data.StateProvinceName}.");
                    updatedStateProvince = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedStateProvince = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                return updatedStateProvince;
            });
        }

        public int DeleteStateProvinceByPk(DeleteParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IStateProvinceRepository>();

                //if (repository.IsReferenced(languageId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsLanguage with LanguageId of '{0}' cannot be deleted because it is referenced.", languageId));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}
                if (repository.CanDelete(parameters.UniqueId) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("StateProvince with StateProvinceUid of '{0}' cannot be deleted because it is referenced.", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    return repository.Remove(parameters.UniqueId, ApplicationUserSessionHeader);
                }
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteStateProvince(DeleteParameters<StateProvince> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IStateProvinceRepository>();

                //if (repository.IsReferenced(language.LanguageId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsLanguage '{0}' cannot be deleted because it is referenced.", language.LanguageName));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}

                if (repository.CanDelete(parameters.Data.StateProvinceUid) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("StateProvince '{0}' cannot be deleted because it is referenced.", parameters.Data.StateProvinceName));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    return repository.Remove(parameters.Data, ApplicationUserSessionHeader);
                }

            });
        }
        #endregion

        #region Background Job Operations

        [OperationBehavior(TransactionScopeRequired = true)]
        public BackgroundJobInfo[] GetBackgroundJobs(GetParametersWithPhoto parameters, BackgroundJobState state)
        {
            return ExecuteFaultHandledOperation(() =>
                {
                    var repository = _DataRepositoryFactory.GetDataRepository<IBackgroundJobRepository>();
                    var data = repository.GetAllBackgroundJobsByState(ApplicationUserSessionHeader, parameters, state);
                    var results = new List<BackgroundJobInfo>();
                    foreach (var bgj in data)
                    {
                        results.Add(bgj.ToBackgroundJobInfo());
                    }
                    return results.ToArray();
                });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public BackgroundJobInfo GetBackgroundJob(GetParametersWithPhoto parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                //LogTransactionInformation($"{ System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

                var repository = _DataRepositoryFactory.GetDataRepository<IBackgroundJobRepository>();

                var entity = repository.Get(parameters.UniqueId, ApplicationUserSessionHeader, parameters);
                if (entity == null)
                {
                    NotFoundException ex = new NotFoundException(string.Format("BackgroundJob with ID of {0} not found", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                return entity.ToBackgroundJobInfo();
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int DeleteBackgroundJobByPk(DeleteParameters parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IBackgroundJobRepository>();

                //if (repository.IsReferenced(languageId) == true)
                //{
                //    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("gcsLanguage with LanguageId of '{0}' cannot be deleted because it is referenced.", languageId));
                //    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                //    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //}
                if (repository.CanDelete(parameters.UniqueId) == false)
                {
                    CannotDeleteReferenceException ex = new CannotDeleteReferenceException(string.Format("BackgroundJob with BackgroundJobUid of '{0}' cannot be deleted because it is referenced.", parameters.UniqueId));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
                else
                {
                    return repository.Remove(parameters.UniqueId, ApplicationUserSessionHeader);
                }
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public BackgroundJobInfo SaveBackgroundJobStateChange(Guid backgroundJobId, BackgroundJobState state, string info)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                SaveBackgroundJobState(backgroundJobId, Guid.Empty, state, info, _DataRepositoryFactory);
                return GetBackgroundJob(new GetParametersWithPhoto() { UniqueId = backgroundJobId, IncludeMemberCollections = false });
            });
        }

        #endregion

        #region Application Audit Type operations
        public gcsApplicationAuditType SaveApplicationAuditType(SaveParameters<gcsApplicationAuditType> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IGcsApplicationAuditTypeRepository>();

                gcsApplicationAuditType updatedAuditType = null;

                if (repository.IsUnique(parameters.Data) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("gcsApplicationAuditType with '{0} ({1})' cannot be saved because it is a duplicate.", parameters.Data.ApplicationAuditTypeId, parameters.Data.TypeCode));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                parameters.Data.UpdateDate = DateTimeOffset.Now;
                parameters.Data.UpdateName = LoginName;
                if (repository.DoesExist(parameters.Data.ApplicationAuditTypeId) == false)
                {
                    parameters.Data.InsertDate = DateTimeOffset.Now;
                    parameters.Data.InsertName = LoginName;
                    this.Log().Info($"Adding Application Audit Type - {parameters.Data.Display}.");
                    updatedAuditType = repository.Add(parameters.Data, ApplicationUserSessionHeader, parameters);
                }
                else
                {
                    updatedAuditType = repository.Update(parameters.Data, ApplicationUserSessionHeader, parameters);
                }

                return updatedAuditType;
            });
        }
        #endregion

        #region Badge System Type operations
        public BadgeSystemType SaveBadgeSystemType(BadgeSystemType type)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IBadgeSystemTypeRepository>();

                BadgeSystemType updatedType = null;

                if (repository.IsUnique(type) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("BadgeSystemType with '{0} ({1}, {2})' cannot be saved because it is a duplicate.", type.BadgeSystemTypeUid, type.Name, type.TypeCode));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                type.UpdateDate = DateTimeOffset.Now;
                type.UpdateName = LoginName;
                if (repository.DoesExist(type.BadgeSystemTypeUid) == false)
                {
                    type.InsertDate = DateTimeOffset.Now;
                    type.InsertName = LoginName;
                    this.Log().Info($"Adding Badging System Type - {type.Name}.");
                    updatedType = repository.Add(type, ApplicationUserSessionHeader, null);
                }
                else
                {
                    updatedType = repository.Update(type, ApplicationUserSessionHeader, null);
                }

                return updatedType;
            });
        }
        #endregion

        #region Biometric System Type operations
        public BiometricSystemType SaveBiometricSystemType(BiometricSystemType type)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var repository = _DataRepositoryFactory.GetDataRepository<IBiometricSystemTypeRepository>();

                BiometricSystemType updatedType = null;

                if (repository.IsUnique(type) == false)
                {
                    DuplicateIndexException ex = new DuplicateIndexException(string.Format("BiometricSystemType with '{0} ({1}, {2})' cannot be saved because it is a duplicate.", type.BiometricSystemTypeUid, type.Name, type.TypeCode));
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }

                type.UpdateDate = DateTimeOffset.Now;
                type.UpdateName = LoginName;
                if (repository.DoesExist(type.BiometricSystemTypeUid) == false)
                {
                    type.InsertDate = DateTimeOffset.Now;
                    type.InsertName = LoginName;
                    this.Log().Info($"Adding Biometric System Type - {type.Name}.");
                    updatedType = repository.Add(type, ApplicationUserSessionHeader, null);
                }
                else
                {
                    updatedType = repository.Update(type, ApplicationUserSessionHeader, null);
                }

                return updatedType;
            });
        }
        #endregion
    }
}
