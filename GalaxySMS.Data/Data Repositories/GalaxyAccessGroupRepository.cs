using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
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
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using GalaxySMS.Common.Constants;
using System.Security.Cryptography;
using StackExchange.Redis;
using System.Net;

namespace GalaxySMS.Data
{
    [Export(typeof(IGalaxyAccessGroupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessGroupRepository : PagedDataRepositoryBase<AccessGroup>, IGalaxyAccessGroupRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import]
        private IGalaxyAccessGroupEntityMapRepository _entityMapRepository;

        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        [Import]
        private IAccessGroupAccessPortalRepository _accessGroupAccessPortalRepository;

        //[Import]
        //private IAccessPortalRepository _accessPortalRepository;  // By leaving this in, the code would lock up due to circular imports
        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        protected override AccessGroup AddEntity(AccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //ValidateReferences(entity);
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                if (entity.AccessGroupNumber == (int)GalaxySMS.Common.Enums.AccessGroupNumber.NoAccess ||
                    entity.AccessGroupNumber == (int)GalaxySMS.Common.Enums.AccessGroupNumber.UnlimitedAccess ||
                    entity.AccessGroupNumber == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup)
                {
                    _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                    _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);
                }

                if (entity.CrisisModeAccessGroupUid == null || entity.CrisisModeAccessGroupUid.Value == Guid.Empty)
                    entity.CrisisModeAccessGroupUid = entity.AccessGroupUid;

                if (entity.DefaultTimeScheduleUid == Guid.Empty)
                    entity.DefaultTimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                var mgr = new AccessGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.AccessGroupUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.AccessGroupUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        UpdateEntityCount(result.EntityId);
                    }
                    result = GetEntityByGuidId(entity.AccessGroupUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::AddEntity", ex);
                throw;
            }
        }

        protected override AccessGroup UpdateEntity(AccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                if (entity.AccessGroupNumber == (int)GalaxySMS.Common.Enums.AccessGroupNumber.NoAccess ||
                    entity.AccessGroupNumber == (int)GalaxySMS.Common.Enums.AccessGroupNumber.UnlimitedAccess ||
                    entity.AccessGroupNumber == (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup)
                {
                    _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                    _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);
                }

                if (entity.CrisisModeAccessGroupUid == null || entity.CrisisModeAccessGroupUid.Value == Guid.Empty)
                    entity.CrisisModeAccessGroupUid = entity.AccessGroupUid;

                var originalEntity = GetEntityByGuidId(entity.AccessGroupUid, sessionData, null);
                var mgr = new AccessGroupPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.AccessGroupUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if ClusterUid is = Guid.Empty or null, then use the value from the original record
                    if (entity.ClusterUid == Guid.Empty)
                        entity.ClusterUid = mgr.Entity.ClusterUid;
                    else if (entity.ClusterUid != mgr.Entity.ClusterUid)
                    {
                        var ex = new ApplicationException("AccessGroup.ClusterUid cannot be changed, it does not match the existing ClusterUid.");
                        throw ex;
                    }
                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    if (entity.EntityId == Guid.Empty)
                        entity.EntityId = mgr.Entity.EntityId;

                    // if CrisisModeAccessGroupUid is = Guid.Empty or null, then use the value from the original record
                    if (entity.CrisisModeAccessGroupUid == null || entity.CrisisModeAccessGroupUid == Guid.Empty)
                        entity.CrisisModeAccessGroupUid = mgr.Entity.CrisisModeAccessGroupUid;

                    if (entity.DefaultTimeScheduleUid == Guid.Empty)
                        entity.DefaultTimeScheduleUid = mgr.Entity.DefaultTimeScheduleUid;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.AccessGroupUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.AccessGroupUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        updatedEntity = GetEntityByGuidId(entity.AccessGroupUid, sessionData, null);

                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);

                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.AccessGroupUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::UpdateEntity", ex);
                throw;
            }
        }

        // This will check a collection of PersonCredential objects to see if any of the credentials are duplicates. Exception will be thrown if so.
        private void ValidateReferences(AccessGroup validateThis)
        {
            //if (person.PersonRecordTypeUid.HasValue && person.PersonRecordTypeUid != Guid.Empty)
            //{
            //    var personRecordTypeRepository = _DataRepositoryFactory.GetDataRepository<IPersonRecordTypeRepository>();
            //    var prt = personRecordTypeRepository.Get(person.PersonRecordTypeUid.Value, ApplicationUserSessionHeader, null);
            //    if (prt == null || prt.EntityId != person.EntityId)
            //    {
            var ex = new DataValidationException($"AccessGroup validation error.");
            throw ex;
            //    }
            //}
        }

        public bool DoesClusterUidMatch(AccessGroup entity)
        {
            var mgr = new AccessGroup_DoesClusterMatchPDSAManager
            {
                Entity =
                {
                    uid = entity.AccessGroupUid,
                    clusterUid = entity.ClusterUid
                }
            };
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return false;

            return true;
        }

        public AccessGroupCounts GetNewestCountsForAccessGroup(Guid accessGroupUid)
        {
            var mgr = new AccessGroupCount_GetLatestCountsPDSAManager
            {
                Entity =
                {
                    AccessGroupUid = accessGroupUid
                }
            };
            var data = mgr.BuildCollection();
            var counts = data.FirstOrDefault();
            if (counts != null)
            {
                var results = new AccessGroupCounts()
                {
                    AccessPortalCount = counts.AccessPortalCount,
                    PersonCount = counts.PersonCount
                };
                return results;
            }

            return default;
        }

        public IArrayResponse<AccessGroupPersonInfo> GetPersonInfoForAccessGroup(IApplicationUserSessionDataHeader sessionData,
            GetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroup_GetPersonInfoPDSAManager()
                {
                    Entity =
                    {
                        AccessGroupUid = parameters.UniqueId,
                        PageNumber = parameters.PageNumber,
                        PageSize = parameters.PageSize
                    }
                };
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var totalCount = 0;
                    var includeLastAccessInfo =
                        parameters.GetOption(GetOptions_AccessGroup.IncludePersonLastAccessInfo);
                    var entities = new List<AccessGroupPersonInfo>();
                    foreach (var pdsaEntity in pdsaEntities)
                    {
                        if (totalCount == 0)
                            totalCount = pdsaEntity.TotalRowCount;
                        var convertedEntity = new AccessGroupPersonInfo();
                        SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                        convertedEntity.ActiveStatusCodeString =
                            EnumExtensions.GetOne<PersonActiveStatusSummaryCodes>(pdsaEntity.ActiveStatusCode).ToString();

                        if (includeLastAccessInfo.HasValue && includeLastAccessInfo.Value/* && !string.IsNullOrEmpty(pdsaEntity.LastUsageAccessPortal)*/)
                        {
                            convertedEntity.LastUsageData = new PersonLastUsageData()
                            {
                                Time = pdsaEntity.LastUsageActivityDateTime,
                                SiteName = pdsaEntity.LastUsageSiteName,
                                ClusterName = pdsaEntity.LastUsageClusterName,
                                AccessPortalName = pdsaEntity.LastUsageAccessPortal,
                                CredentialName = pdsaEntity.LastCredentialName,
                            };
                            if (!convertedEntity.LastUsageData.Time.HasValue || convertedEntity.LastUsageData.Time.Value == DateTimeOffset.MinValue)
                            {
                                convertedEntity.LastUsageData.Time = null;
                                convertedEntity.LastUsageData.SiteName = null;
                                convertedEntity.LastUsageData.ClusterName = null;
                                convertedEntity.LastUsageData.AccessPortalName = null;
                                convertedEntity.LastUsageData.CredentialName = null;
                            }
                        }


                        entities.Add(convertedEntity);
                    }

                    return ArrayResponseHelpers.ToArrayResponse(entities, parameters.PageNumber, parameters.PageSize, totalCount);
                }

                return new ArrayResponse<AccessGroupPersonInfo>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllAccessGroupsForCluster", ex);
                throw;
            }
        }

        //public AccessGroupCounts UpdateCountsForAccessGroup(Guid accessGroupUid)
        //{
        //    //var mgr = new gcsEntityCountPDSA_GenerateAllCountsPDSAManager();
        //    //mgr.Entity.EntityId = entityId;
        //    //mgr.Execute();
        //    return GetNewestCountsForAccessGroup(accessGroupUid);
        //}



        public void UpdateLastLoadedDate(Guid cpuUid, int accessGroupNumber)
        {
            try
            {
                var mgr = new AccessGroupLoadToCpu_SaveLastLoadedDatePDSAManager
                {
                    Entity =
                    {
                        CpuUid = cpuUid,
                        AccessGroupNumber = accessGroupNumber
                    }
                };
                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }

        }

        public void UpdateAccessPortalLastLoadedDate(Guid cpuUid, int accessGroupNumber, int boardNumber, int sectionNumber, int nodeNumber)
        {
            try
            {
                var mgr = new AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAManager
                {
                    Entity =
                    {
                        CpuUid = cpuUid,
                        AccessGroupNumber = accessGroupNumber,
                        BoardNumber = boardNumber,
                        SectionNumber = sectionNumber,
                        NodeNumber = nodeNumber
                    }
                };
                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }
        public int GetAvailableAccessGroupNumber(Guid clusterUid, ChooseAvailableAccessGroupNumberRange rangeOption)
        {
            try
            {
                int availableAgNumber = GalaxySMS.Common.Constants.AccessGroupLimits.None;

                var mgr = new ChooseAvailableAccessGroupNumberPDSAManager();
                mgr.Entity.ClusterUid = clusterUid;

                if (rangeOption == ChooseAvailableAccessGroupNumberRange.RequireStandardGroup ||
                    rangeOption == ChooseAvailableAccessGroupNumberRange.PreferStandardGroup)
                {
                    mgr.Entity.Extended = false;
                    var results = mgr.BuildCollection();
                    if (results != null && results.Count == 1)
                        availableAgNumber = results[0].AccessGroupNumber;
                    if (rangeOption == ChooseAvailableAccessGroupNumberRange.RequireStandardGroup ||
                        availableAgNumber != GalaxySMS.Common.Constants.AccessGroupLimits.None)
                        return availableAgNumber;
                }

                if (rangeOption == ChooseAvailableAccessGroupNumberRange.RequireExtendedGroup ||
                    rangeOption == ChooseAvailableAccessGroupNumberRange.PreferExtendedGroup)
                {
                    mgr.Entity.Extended = true;
                    var results = mgr.BuildCollection();
                    if (results != null && results.Count == 1)
                        availableAgNumber = results[0].AccessGroupNumber;
                }

                return availableAgNumber;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetAvailablePersonalAccessGroupNumber", ex);
                throw;
            }
        }

        public AccessGroupClusterPermissionValidationResult GetAccessGroupClusterPermissionValidationResult(Guid clusterUid, Guid accessGroupUid, short orderNumber)
        {
            try
            {
                var mgr = new IsAccessGroupClusterPermissionValidPDSAManager();
                mgr.Entity.ClusterUid = clusterUid;
                mgr.Entity.AccessGroupUid = accessGroupUid;
                mgr.Entity.OrderNumber = orderNumber;

                var results = mgr.BuildCollection();
                switch (mgr.Entity.Result)
                {
                    case 0:
                        return AccessGroupClusterPermissionValidationResult.Ok;
                    case 1:
                        return AccessGroupClusterPermissionValidationResult.InvalidOrderNumber;
                    case 2:
                        return AccessGroupClusterPermissionValidationResult.AccessGroupNotInCluster;
                    case 3:
                        return AccessGroupClusterPermissionValidationResult.AccessGroupNumberNotPermittedForOrderNumber1or2;
                    case 4:
                        return AccessGroupClusterPermissionValidationResult.AccessGroupNotPermittedForOrderNumber3;
                    default:
                        return AccessGroupClusterPermissionValidationResult.UnknownResult;
                }
                return (AccessGroupClusterPermissionValidationResult)mgr.Entity.Result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetAvailablePersonalAccessGroupNumber", ex);
                throw;
            }

        }

        public DateTimeOffset GetCurrentTimeForCluster(Guid clusterUid)
        {
            try
            {
                var mgr = new Cluster_GetCurrentTimePDSAManager();
                mgr.Entity.ClusterUid = clusterUid;

                var result = mgr.BuildCollection();
                if (result.Count == 1)
                    return result[0].CurrentTimeForCluster;
                return DateTimeOffset.Now;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        private void EnsureChildRecordsExist(AccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //if (saveParams.Ignore(nameof(entity.AccessGroupAccessPortals)) ||
            //    entity.AccessGroupAccessPortals == null ||
            //    !entity.AccessGroupAccessPortals.Any())
            //    return;
            if (saveParams.Ignore(nameof(entity.AccessPortals)))
                return;

            var kvpSaveAccessGroupAccessPortalsOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessGroupAccessPortalsOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Value) &&
                                       kvpSaveAccessGroupAccessPortalsOption.Value == SaveAccessGroupAccessPortalsOption.DeleteMissingItems.ToString();
            bool bCreateMissingItems = !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Value) &&
                                       kvpSaveAccessGroupAccessPortalsOption.Value == SaveAccessGroupAccessPortalsOption.CreateMissingItems.ToString();
            bool bSetMissingItemsToNever = !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Key) &&
                                           !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Value) &&
                                           kvpSaveAccessGroupAccessPortalsOption.Value == SaveAccessGroupAccessPortalsOption.SetMissingItemsToNever.ToString();

            if (bDeleteMissingItems ||
                bCreateMissingItems ||
                bSetMissingItemsToNever ||
                entity.AccessPortals == null ||
                entity.AccessPortals.Any())
                SaveAccessGroupAccessPortals(entity, sessionData, saveParams);
        }

        private void SaveAccessGroupAccessPortals(AccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.AccessPortals == null)
                entity.AccessPortals = new List<AccessGroupAccessPortal>();

            var kvpSaveAccessGroupAccessPortalsOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessGroupAccessPortalsOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Value) &&
                                       kvpSaveAccessGroupAccessPortalsOption.Value == SaveAccessGroupAccessPortalsOption.DeleteMissingItems.ToString();
            bool bSetMissingItemsToNever = !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Key) &&
                                           !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Value) &&
                                           kvpSaveAccessGroupAccessPortalsOption.Value == SaveAccessGroupAccessPortalsOption.SetMissingItemsToNever.ToString();

            entity.AccessPortals = entity.AccessPortals.Where(o => o.AccessPortalUid != Guid.Empty).ToCollection();
            // If any have an Empty guid value assigned for the Time Schedule, default it to never
            foreach (var agap in entity.AccessPortals.Where(o => o.TimeScheduleUid == Guid.Empty))
            {
                agap.TimeScheduleUid = null;//GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
            }

            // Get all items from the database
            var itemsFromDb = _accessGroupAccessPortalRepository.GetAllAccessGroupAccessPortalForAccessGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessGroupUid });

            // If any do not have a AccessGroupAccessPortalUid (PrimaryKey value), see if we can determine the value by AccessPortalUid
            foreach (var agap in entity.AccessPortals.Where(o => o.AccessGroupAccessPortalUid == Guid.Empty))
            {
                var i = itemsFromDb.FirstOrDefault(o => o.AccessPortalUid == agap.AccessPortalUid);
                if (i != null)
                {
                    agap.AccessGroupAccessPortalUid = i.AccessGroupAccessPortalUid;
                }
            }


            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Portal
                foreach (var i in itemsFromDb)
                {
                    // If the AccessGroupAccessPortalUid does not exist in the entity, then delete the record from the database
                    if (entity.AccessPortals.FirstOrDefault(o => o.AccessGroupAccessPortalUid == i.AccessGroupAccessPortalUid) == null)
                    {
                        // Remove the access group access portal itself. 
                        _accessGroupAccessPortalRepository.Remove(i.AccessGroupAccessPortalUid, sessionData);
                    }
                }
            }

            //if (bAddMissingAccessGroupAccessPortals == true)
            //{
            var _accessPortalRepository = _dataRepositoryFactory.GetDataRepository<IAccessPortalRepository>();
            // Determine if there are any missing AccessGroupAccessPortals and if there are, create entries for them
            var accessPortalsFromDb = _accessPortalRepository.GetAllAccessPortalsForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid });
            var missingAp = accessPortalsFromDb.Items.Where(i => entity.AccessPortals.All(i2 => i2.AccessPortalUid != i.AccessPortalUid)).ToList();
            var agaps = entity.AccessPortals.ToCollection();
            foreach (var ap in missingAp)
            {
                // see if there is a database record already. If not, then create one
                var agapFromDb = itemsFromDb.FirstOrDefault(o => o.AccessPortalUid == ap.AccessPortalUid);
                // only create a record IF there isn't one already in the database
                if (agapFromDb == null)
                {
                    var newAgAp = new AccessGroupAccessPortal()
                    {
                        AccessGroupUid = entity.AccessGroupUid,
                        AccessPortalUid = ap.AccessPortalUid,
                        TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
                    };
                    if (entity.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
                    {
                        newAgAp.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;
                    }
                    agaps.Add(newAgAp);// entity.AccessGroupAccessPortals.Add(newAgAp);
                }
                else if( bSetMissingItemsToNever)
                {
                    if (agapFromDb.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Never)
                    {
                        agapFromDb.TimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                        agapFromDb.IsDirty = true;
                        agaps.Add(agapFromDb);
                    }
                }
            }
            entity.AccessPortals = agaps.ToCollection();
            //}
            var x = 0;
            // Now save those that are defined in the Access Group being saved
            foreach (var i in entity.AccessPortals)
            {
                i.IndexValue = x++;
                var existingItem = itemsFromDb.FirstOrDefault(o => o.AccessGroupAccessPortalUid == i.AccessGroupAccessPortalUid);
                if (existingItem != null && (i.IsAnythingDirty || existingItem.TimeScheduleUid != i.TimeScheduleUid))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    if (i.AccessGroupUid != entity.AccessGroupUid)
                        i.AccessGroupUid = entity.AccessGroupUid;
                    i.ConcurrencyValue = existingItem.ConcurrencyValue;
                    var updated = _accessGroupAccessPortalRepository.Update(i, sessionData, saveParams);
                }
                if (i.AccessGroupAccessPortalUid == Guid.Empty)
                {
                    i.AccessGroupAccessPortalUid = GuidUtilities.GenerateComb();
                    i.AccessGroupUid = entity.AccessGroupUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessGroupAccessPortalRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(AccessGroup entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.AccessGroupUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                    UpdateEntityCount(entity.EntityId);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new AccessGroupPDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id); // must read the original record from the database so the PDSA object can detect changes
                if (rowsLoaded == 1 && originalEntity != null)
                {
                    rowsDeleted = mgr.DataObject.DeleteByPK(id);
                    if (rowsDeleted > 0)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Delete, sessionData, originalEntity, null, mgr.DataObject.AuditRowAsXml);
                        UpdateEntityCount(originalEntity.EntityId);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<AccessGroup> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessGroupPDSAManager mgr)
        {
            var includeSystemAgsOption = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_AccessGroup.IncludeSystemAccessGroups);
            mgr.Entity.IncludeSystemGroups = true;
            if (includeSystemAgsOption.HasValue)
            {
                mgr.Entity.IncludeSystemGroups = includeSystemAgsOption.Value;
            }

            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        private IArrayResponse<AccessGroup> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessGroupPDSAManager mgr)
        {
            SetSortColumnAndOrder(getParameters, mgr);

            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var totalCount = 0;
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (totalCount == 0)
                        totalCount = entity.TotalRowCount;
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }

                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
            }

            return new ArrayResponse<AccessGroup>();
        }

        // GetAllAccessGroups for an Entity
        protected override IEnumerable<AccessGroup> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<AccessGroup> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllEntities", ex);
                throw;
            }
        }
#if UsePaging
        public IArrayResponse<AccessGroup> GetAllGalaxyAccessGroupsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.ByEntityId;
                if (parameters.UniqueId == Guid.Empty)
                    parameters.UniqueId = sessionData.CurrentEntityId;
                mgr.Entity.EntityId = parameters.UniqueId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerablePaged(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllAccessGroupsForCluster", ex);
                throw;
            }
        }

        public IArrayResponse<AccessGroup> GetAllGalaxyAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager
                {
                    DataObject = { SelectFilter = AccessGroupPDSAData.SelectFilters.ByClusterUid },
                    Entity =
                    {
                        ClusterUid =
                            parameters.ClusterUid != Guid.Empty ? parameters.ClusterUid : parameters.UniqueId,
                        CultureName = sessionData.UiCulture
                    }
                };
                return GetIEnumerablePaged(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllAccessGroupsForCluster", ex);
                throw;
            }
        }

        public IArrayResponse<AccessGroup> GetAllSystemAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager
                {
                    DataObject = { SelectFilter = AccessGroupPDSAData.SelectFilters.GetSpecialGroupsByClusterUid },
                    Entity =
                    {
                        ClusterUid =
                            parameters.ClusterUid != Guid.Empty ? parameters.ClusterUid : parameters.UniqueId,
                        CultureName = sessionData.UiCulture
                    }
                };
                return GetIEnumerablePaged(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllSpecialGalaxyAccessGroupsForCluster", ex);
                throw;
            }
        }

        public IArrayResponse<AccessGroup> GetAllGalaxyAccessGroupsForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new ClusterUid_GetByAccessPortalUidPDSAManager();
                mgr.Entity.accessPortalUid = parameters.UniqueId;
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(parameters as GetParametersWithPhoto);
                    newParams.UniqueId = data[0].ClusterUid;
                    return GetAllGalaxyAccessGroupsForCluster(sessionData, newParams);
                }
                return new ArrayResponse<AccessGroup>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllGalaxyAccessGroupsForAccessPortal", ex);
                throw;
            }
        }

        public IArrayResponse<AccessGroup> GetAllGalaxyAccessGroupsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.ByClusterUidEntityId;
                mgr.Entity.ClusterUid = parameters.UniqueId;
                mgr.Entity.EntityId = parameters.CurrentEntityId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerablePaged(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllAccessGroupsForCluster", ex);
                throw;
            }
        }
#else
        public IEnumerable<AccessGroup> GetAllGalaxyAccessGroupsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.ByEntityId;
                if (parameters.UniqueId == Guid.Empty)
                    parameters.UniqueId = sessionData.CurrentEntityId;
                mgr.Entity.EntityId = parameters.UniqueId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllAccessGroupsForCluster", ex);
                throw;
            }
        }

        public IEnumerable<AccessGroup> GetAllGalaxyAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager
                {
                    DataObject = { SelectFilter = AccessGroupPDSAData.SelectFilters.ByClusterUid },
                    Entity =
                    {
                        ClusterUid =
                            parameters.ClusterUid != Guid.Empty ? parameters.ClusterUid : parameters.UniqueId,
                        CultureName = sessionData.UiCulture
                    }
                };
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllAccessGroupsForCluster", ex);
                throw;
            }
        }

        public IEnumerable<AccessGroup> GetAllSystemAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager
                {
                    DataObject = { SelectFilter = AccessGroupPDSAData.SelectFilters.GetSpecialGroupsByClusterUid },
                    Entity =
                    {
                        ClusterUid =
                            parameters.ClusterUid != Guid.Empty ? parameters.ClusterUid : parameters.UniqueId,
                        CultureName = sessionData.UiCulture
                    }
                };
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllSpecialGalaxyAccessGroupsForCluster", ex);
                throw;
            }
        }

        public IEnumerable<AccessGroup> GetAllGalaxyAccessGroupsForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new ClusterUid_GetByAccessPortalUidPDSAManager();
                mgr.Entity.accessPortalUid = parameters.UniqueId;
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(parameters as GetParametersWithPhoto);
                    newParams.UniqueId = data[0].ClusterUid;
                    return GetAllGalaxyAccessGroupsForCluster(sessionData, newParams);
                }
                return new List<AccessGroup>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllGalaxyAccessGroupsForAccessPortal", ex);
                throw;
            }
        }

        public IEnumerable<AccessGroup> GetAllGalaxyAccessGroupsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.ByClusterUidEntityId;
                mgr.Entity.ClusterUid = parameters.UniqueId;
                mgr.Entity.EntityId = parameters.CurrentEntityId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllAccessGroupsForCluster", ex);
                throw;
            }
        }

#endif
        protected override AccessGroup GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override AccessGroup GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    AccessGroup result = new AccessGroup();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        public AccessGroup_PanelLoadData GetAccessGroupPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessGroup_GetPanelLoadDataByAccessGroupUidPDSAManager();
                mgr.Entity.AccessGroupUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null && result.Count == 1)
                {
                    var returnData = new AccessGroup_PanelLoadData();
                    SimpleMapper.PropertyMap(result[0], returnData);
                    var agManager = new AccessGroupAccessPortal_GetPanelLoadDataByAccessGroupUidPDSAManager();
                    agManager.Entity.AccessGroupUid = getParameters.UniqueId;

                    var accessGroupData = agManager.BuildCollection();
                    if (accessGroupData != null && accessGroupData.Count > 0)
                    {
                        foreach (var agData in accessGroupData)
                        {
                            var newAgData = new AccessGroupAccessPortal_PanelLoadData();
                            SimpleMapper.PropertyMap(agData, newAgData);
                            returnData.AccessGroupData.Add(newAgData);
                        }
                    }
                    return returnData;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAccessGroupPanelLoadData", ex);
                throw;
            }
        }

        public IEnumerable<AccessGroup_PanelLoadData> GetAccessGroupPanelLoadDataForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                // Get all the Access Groups for the cluster
                var returnData = new List<AccessGroup_PanelLoadData>();
                var mgr = new AccessGroup_GetPanelLoadDataByClusterUidPDSAManager();
                mgr.Entity.ClusterUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var ag in result)
                    {
                        var newAg = new AccessGroup_PanelLoadData();
                        SimpleMapper.PropertyMap(ag, newAg);
                        var agManager = new AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAManager();
                        agManager.Entity.ClusterUid = getParameters.ClusterUid;

                        var accessGroupData = agManager.BuildCollection();
                        if (accessGroupData != null && accessGroupData.Count > 0)
                        {
                            foreach (var agData in accessGroupData)
                            {
                                var newAgData = new AccessGroupAccessPortal_PanelLoadData();
                                SimpleMapper.PropertyMap(agData, newAgData);
                                newAg.AccessGroupData.Add(newAgData);
                            }
                        }
                        returnData.Add(newAg);
                    }
                    return returnData;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAccessGroupPanelLoadData", ex);
                throw;
            }
        }

        public IEnumerable<AccessGroup_PanelLoadData> GetAccessGroupPanelLoadDataForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                // Get all the Access Groups for the cluster
                var returnData = new List<AccessGroup_PanelLoadData>();

                // get all the access group access portal data for the requested panel
                var agApManager = new AccessGroupAccessPortal_GetPanelLoadDataByGalaxyPanelUidPDSAManager();
                agApManager.Entity.GalaxyPanelUid = getParameters.GetGuid;

                var accessGroupData = agApManager.BuildCollection();
                if (accessGroupData != null)
                {
                }

                var mgr = new AccessGroup_GetPanelLoadDataByClusterUidPDSAManager();
                mgr.Entity.ClusterUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var ag in result)
                    {
                        var newAg = new AccessGroup_PanelLoadData();
                        SimpleMapper.PropertyMap(ag, newAg);

                        foreach (var agData in accessGroupData.Where(o => o.AccessGroupUid == ag.AccessGroupUid))
                        {
                            var newAgData = new AccessGroupAccessPortal_PanelLoadData();
                            SimpleMapper.PropertyMap(agData, newAgData);
                            newAg.AccessGroupData.Add(newAgData);
                        }

                        returnData.Add(newAg);
                    }
                    return returnData;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAccessGroupPanelLoadData", ex);
                throw;
            }
        }
        public IEnumerable<AccessGroup_PanelLoadDataChanges> GetModifiedAccessGroupPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                // Get all the Access Groups for the cluster
                var returnData = new List<AccessGroup_PanelLoadDataChanges>();
                var mgr = new AccessGroup_GetPanelLoadDataChangesForCpuPDSAManager();
                mgr.Entity.CpuUid = getParameters.UniqueId;
                mgr.Entity.ServerAddress = getParameters.GetString;
                mgr.Entity.IsConnected = true;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var ag in result)
                    {
                        var newAg = new AccessGroup_PanelLoadDataChanges();
                        SimpleMapper.PropertyMap(ag, newAg);
                        var agManager = new AccessGroupAccessPortal_GetPanelLoadDataByClusterUidPDSAManager();
                        agManager.Entity.ClusterUid = getParameters.ClusterUid;

                        var accessGroupData = agManager.BuildCollection();
                        if (accessGroupData != null && accessGroupData.Count > 0)
                        {
                            foreach (var agData in accessGroupData)
                            {
                                var newAgData = new AccessGroupAccessPortal_PanelLoadData();
                                SimpleMapper.PropertyMap(agData, newAgData);
                                newAg.AccessGroupData.Add(newAgData);
                            }
                        }
                        returnData.Add(newAg);
                    }
                    return returnData;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAccessGroupPanelLoadData", ex);
                throw;
            }
        }
        public IEnumerable<AccessGroup_PanelLoadDataChanges> GetModifiedAccessGroupPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                // Get all the Access Groups for the cluster
                var returnData = new List<AccessGroup_PanelLoadDataChanges>();
                var mgr = new AccessGroup_GetPanelLoadDataChangesPDSAManager();
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var ag in result)
                    {
                        var newAg = new AccessGroup_PanelLoadDataChanges();
                        SimpleMapper.PropertyMap(ag, newAg);
                        var agManager = new AccessGroupAccessPortal_GetPanelLoadDataByAccessGroupUidGalaxyPanelUidPDSAManager();
                        agManager.Entity.GalaxyPanelUid = newAg.GalaxyPanelUid;
                        agManager.Entity.AccessGroupUid = newAg.AccessGroupUid;
                        var accessGroupData = agManager.BuildCollection();
                        if (accessGroupData != null && accessGroupData.Count > 0)
                        {
                            foreach (var agData in accessGroupData)
                            {
                                var newAgData = new AccessGroupAccessPortal_PanelLoadData();
                                SimpleMapper.PropertyMap(agData, newAgData);
                                newAg.AccessGroupData.Add(newAgData);
                            }
                        }
                        returnData.Add(newAg);
                    }
                    return returnData;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAccessGroupPanelLoadData", ex);
                throw;
            }
        }

        public IEnumerable<AccessGroupSelectionItemBasic> GetAllAccessGroupSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroup_SelectionListForEntityAndClusterPDSAManager();
                mgr.Entity.EntityId = parameters.CurrentEntityId;
                mgr.Entity.ClusterUid = parameters.ClusterUid;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<AccessGroupSelectionItemBasic>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new AccessGroupSelectionItemBasic();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        entities.Add(newEntity);
                    }
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllAccessGroupSelectionItemBasicsForEntityAndCluster", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, AccessGroup originalEntity, AccessGroup newEntity, string auditXml)
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

                        List<String> propertiesToIgnore = new List<string>();
                        propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "AccessGroupUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessGroupUid;
                        mgr.Entity.RecordTag = newEntity.AccessGroupUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "AccessGroupUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessGroupUid;
                        mgr.Entity.RecordTag = newEntity.AccessGroupUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "AccessGroupUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AccessGroupUid;
                        mgr.Entity.RecordTag = originalEntity.AccessGroupUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::SaveAuditData", ex);
                                                                                                                        //throw;
            }
        }

        protected override void FillMemberCollections(AccessGroup entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
            var aps = _accessGroupAccessPortalRepository.GetAllAccessGroupAccessPortalForAccessGroup(sessionData,
                new GetParametersWithPhoto() { UniqueId = entity.AccessGroupUid }).ToCollection();

            bool? includeAllAccessPortals = false;
            if( getParameters != null )
                includeAllAccessPortals = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_AccessGroup.IncludeAllAccessPortals);
            if (includeAllAccessPortals.HasValue && includeAllAccessPortals.Value)
            {
                entity.AccessPortals = aps;
            }
            else
            {
                if (entity.DefaultTimeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never)
                {
                    entity.AccessPortals = aps.Where(o => o.TimeScheduleUid.HasValue &&
                                                          o.TimeScheduleUid != GalaxySMS.Common.Constants
                                                              .TimeScheduleIds.TimeSchedule_Never).ToCollection();
                }
                else
                {
                    entity.AccessPortals = aps.Where(o => !o.TimeScheduleUid.HasValue ||
                                                          o.TimeScheduleUid != GalaxySMS.Common.Constants
                                                              .TimeScheduleIds.TimeSchedule_Never).ToCollection();
                }
            }


            var entityMaps = _entityMapRepository.GetAllAccessGroupEntityMapsForAccessGroup(sessionData,
                new GetParametersWithPhoto() { UniqueId = entity.AccessGroupUid });
            var entityIds = (from e in entityMaps select e.EntityId).ToList();
            entity.EntityIds.AddRange(entityIds);
            foreach (var e in entityMaps)
            {
                if (e.EntityId != entity.EntityId)
                    entity.EntityIds.Add(e.EntityId);
            }
            entity.EntityIds.Add(entity.EntityId);
        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllAccessGroupEntityMapsForAccessGroup(sessionData, getParameters);
            var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
            var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

            foreach (var existingEntityId in existingEntityIds)
            {
                if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
                {
                    var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
                    if (deleteThisExistingEntityMap != null)
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.AccessGroupEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new AccessGroupEntityMap();
                    entityMap.AccessGroupEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.AccessGroupUid = uid;
                    entityMap.EntityId = entityId;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("AccessGroup", "AccessGroupUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("AccessGroup", "AccessGroupUid", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(AccessGroup entity)
        {
            var mgr = new IsAccessGroupUniquePDSAManager();
            mgr.Entity.AccessGroupUid = entity.AccessGroupUid;
            mgr.Entity.ClusterUid = entity.ClusterUid;
            mgr.Entity.AccessGroupNumber = entity.AccessGroupNumber;
            mgr.Entity.Display = entity.Display;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("AccessGroup", "AccessGroupUid", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid id)
        {
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("AccessGroup", "AccessGroupUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public Guid GetParentEntityId(Guid parentUid)
        {
            var mgr = new GetEntityIdForClusterPDSAManager
            {
                Entity =
                {
                    uid = parentUid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId;
            return Guid.Empty;
        }

        public Guid GetClusterUidOf(Guid accessGroupUid)
        {
            var mgr = new GetClusterUidOfForGalaxyAccessGroupPDSAManager
            {
                Entity =
                {
                    uid = accessGroupUid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.ClusterUid;
            return Guid.Empty;
        }

        public ValidationProblemDetails Validate(AccessGroup data)
        {
            var response = new ValidationProblemDetails();
            var errorsArray = new List<string>();           // validate the crisis mode and default time schedule are on the same cluster as the access group being saved
            var crisisAccessGroupClusterUid = Guid.Empty;
            var defaultTimeScheduleEntityId = Guid.Empty;
            if (data.CrisisModeAccessGroupUid.HasValue && data.CrisisModeAccessGroupUid != Guid.Empty)
            {
                crisisAccessGroupClusterUid = GetClusterUidOf(data.CrisisModeAccessGroupUid.Value);
                if (crisisAccessGroupClusterUid != data.ClusterUid)
                {
                    errorsArray.Clear();
                    errorsArray.Add($"The {nameof(AccessGroup.CrisisModeAccessGroupUid)} value {data.CrisisModeAccessGroupUid} is not permitted because it is from a different cluster. The crisis mode access group must be on the same cluster as the access group being saved.");
                    response.Errors.Add($"{nameof(data.CrisisModeAccessGroupUid)}", errorsArray.ToArray());
                }
            }

            errorsArray.Clear();
            var tsRepo = _dataRepositoryFactory.GetDataRepository<ITimeScheduleRepository>();
            if (data.DefaultTimeScheduleUid != Guid.Empty &&
                data.DefaultTimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never &&
                data.DefaultTimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
            {
                defaultTimeScheduleEntityId = tsRepo.GetEntityId(data.DefaultTimeScheduleUid);
                if (defaultTimeScheduleEntityId != data.EntityId)
                {
                    errorsArray.Add(
                        $"The {nameof(AccessGroup.DefaultTimeScheduleUid)} value {data.DefaultTimeScheduleUid} is not permitted because it either does not exist or is from a different entity. The default time schedule must be on the same entity as the access group being saved.");
                }
                else
                {

                    // Make sure the time schedule is mapped to the cluster as well.
                    var isTimeScheduleMappedToCluster =
                        tsRepo.IsTimeScheduleMappedToCluster(data.DefaultTimeScheduleUid, data.ClusterUid);
                    if (!isTimeScheduleMappedToCluster)
                    {
                        errorsArray.Add(
                            $"The {nameof(TimeSchedule)} value {data.DefaultTimeScheduleUid} is not permitted because it is not mapped to the cluster of the access group being saved.");
                    }
                }
            }

            if (errorsArray.Any())
                response.Errors.Add($"{nameof(data.DefaultTimeScheduleUid)}", errorsArray.ToArray());

            var results = _accessGroupAccessPortalRepository.ValidateAccessPortalsAndScheduleMatchCluster(data.AccessPortals, data.ClusterUid, nameof(data.AccessPortals));
            response.Merge(results);
            return response;
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForGalaxyAccessGroupPDSAManager
            {
                Entity =
                {
                    uid = uid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId;
            return Guid.Empty;
        }

        public void OnImportsSatisfied()
        {
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, AccessGroupPDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<AccessGroupSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;

            var includeSystemAgsOption = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_AccessGroup.IncludeSystemAccessGroups);
            mgr.Entity.IncludeSystemGroups = true;
            if (includeSystemAgsOption.HasValue)
            {
                mgr.Entity.IncludeSystemGroups = includeSystemAgsOption.Value;
            }
        }

        protected override IArrayResponse<AccessGroup> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetEntities", ex);
                throw;
            }

        }

        protected override IArrayResponse<AccessGroup> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupPDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupRepository::GetAllEntities", ex);
                throw;
            }

        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertAccessGroupCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        public IEnumerable<Guid> GetUidsForCluster(Guid clusterUid)
        {
            var mgr = new GetAccessGroupUidsForClusterPDSAManager()
            {
                Entity =
                {
                    uid = clusterUid
                }
            };
            var results = mgr.BuildCollection();
            var data = results.Select(o => o.AccessGroupUid);
            return data;
        }

    }
}
