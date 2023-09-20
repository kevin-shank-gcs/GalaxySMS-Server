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
using GCS.Core.Common.Shared.Utils;
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using GalaxySMS.Common.Constants;

namespace GalaxySMS.Data
{
    [Export(typeof(IAccessProfileRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessProfileRepository : PagedDataRepositoryBase<AccessProfile>, IAccessProfileRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IAccessProfileEntityMapRepository _entityMapRepository;
        [Import] private IAccessProfileClusterRepository _accessProfileClusterRepository;

        protected override AccessProfile AddEntity(AccessProfile entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);


                var mgr = new AccessProfilePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.AccessProfileUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.AccessProfileUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        //UpdatePersons(entity, sessionData, saveParams);
                        UpdateEntityCount(result.EntityId);
                        result = GetEntityByGuidId(entity.AccessProfileUid, sessionData, new GetParametersWithPhoto(saveParams));
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::AddEntity", ex);
                throw;
            }
        }

        protected override AccessProfile UpdateEntity(AccessProfile entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.AccessProfileUid, sessionData, null);
                var mgr = new AccessProfilePDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.AccessProfileUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.AccessProfileUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.AccessProfileUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        //UpdatePersons(entity, sessionData, saveParams);
                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);
                        updatedEntity = GetEntityByGuidId(entity.AccessProfileUid, sessionData, new GetParametersWithPhoto(saveParams));
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.AccessProfileUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::UpdateEntity", ex);
                throw;
            }
        }


        private void EnsureChildRecordsExist(AccessProfile entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.AccessProfileClusters)))
                SaveAccessProfileClusters(entity, sessionData, saveParams);
        }

        //// Update all persons that are associated with this access profile to ensure that their cluster permissions match the profile
        //// This must iterate through all PersonAccessControlProperties that are associated with the specific access profile
        //// Add, Update and/or delete all records that are not consistent with the access profile
        //private void UpdatePersons(AccessProfile entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{

        //}

        private void SaveAccessProfileClusters(AccessProfile entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.AccessProfileClusters == null || !entity.AccessProfileClusters.Any())
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessProfileClusterOption));

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveAccessProfileClusterOption.DeleteMissingItems.ToString();

            // Alert Events
            var existingAccessProfileClusters = _accessProfileClusterRepository.GetAllForAccessProfile(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessProfileUid, IncludeMemberCollections = true });
            var deleteTheseAccessProfileClusters = existingAccessProfileClusters.Where(c => entity.AccessProfileClusters.All(c2 => c2.ClusterUid != c.ClusterUid)).ToList();

            // If any do not have a AccessProfileClusterUid (PrimaryKey value), see if we can determine the value by ClusterUid
            foreach (var apc in entity.AccessProfileClusters.Where(o => o.AccessProfileClusterUid == Guid.Empty))
            {
                var i = existingAccessProfileClusters.FirstOrDefault(o => o.ClusterUid == apc.ClusterUid);
                if (i != null)
                {
                    apc.AccessProfileClusterUid = i.AccessProfileClusterUid;
                }
            }


            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Profile
                foreach (var i in deleteTheseAccessProfileClusters)
                {
                    // If the AccessPortalAlertEventUid does not exist in the entity, then delete the area from the database
                    if (entity.AccessProfileClusters.FirstOrDefault(o => o.AccessProfileClusterUid == i.AccessProfileClusterUid) == null)
                    {
                        _accessProfileClusterRepository.Remove(i.AccessProfileClusterUid, sessionData);
                    }
                }
            }

            //var propsToInclude = new List<string>();
            //propsToInclude.Add(nameof(AccessProfileCluster.AccessProfileAccessGroups));
            //propsToInclude.Add(nameof(AccessProfileCluster.AccessProfileInputOutputGroups));
            // Now save those that are defined in the Access Portal being saved
            foreach (var i in entity.AccessProfileClusters)
            {
                var existingItem = existingAccessProfileClusters.FirstOrDefault(o => o.AccessProfileClusterUid == i.AccessProfileClusterUid);
                //if( existingItem == null)
                //    continue;

                if (existingItem != null)
                {
                    if (i.AccessProfileUid != existingItem.AccessProfileUid)
                        i.AccessProfileUid = existingItem.AccessProfileUid;
                }

                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i)))//,propsToInclude)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessProfileClusterRepository.Update(i, sessionData, saveParams);
                }
                if (i.AccessProfileClusterUid == Guid.Empty)
                {
                    i.AccessProfileClusterUid = GuidUtilities.GenerateComb();
                    i.AccessProfileUid = entity.AccessProfileUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessProfileClusterRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            if (saveParams.Ignore(nameof(entity.EntityIds)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllAccessProfileEntityMapsForAccessProfile(sessionData,
                getParameters);
            var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
            var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

            foreach (var existingEntityId in existingEntityIds)
            {
                if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
                {
                    var deleteThisExistingEntityMap =
                        (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem)
                        .FirstOrDefault();
                    if (deleteThisExistingEntityMap != null)
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.AccessProfileEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new AccessProfileEntityMap();
                    entityMap.AccessProfileEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.AccessProfileUid = uid;
                    entityMap.EntityId = entityId;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(AccessProfile entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new AccessProfilePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.AccessProfileUid);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new AccessProfilePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<AccessProfile> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessProfilePDSAManager mgr)
        {
            var omitNone = getParameters.GetOption(GetOptions_AccessProfile.OmitNone) ?? false;
            mgr.Entity.OmitNone = omitNone;
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

        private IArrayResponse<AccessProfile> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessProfilePDSAManager mgr)
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
                    {
                        var tempGetParams = new GetParametersWithPhoto(getParameters)
                        {
                            UniqueId = entity.AccessProfileUid
                        };
                        FillMemberCollections(entity, null, tempGetParams);
                    }
                }
                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
            }
            return new ArrayResponse<AccessProfile>();
        }

        // GetAllAccessProfiles for an Entity
        protected override IEnumerable<AccessProfile> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfilePDSAManager();
                mgr.DataObject.SelectFilter = AccessProfilePDSAData.SelectFilters.ByEntityId;
                mgr.Entity.EntityId = sessionData.CurrentEntityId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<AccessProfile> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfilePDSAManager();
                mgr.DataObject.SelectFilter = AccessProfilePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::GetAllEntities", ex);
                throw;
            }
        }
#if UsePaging
        public IArrayResponse<AccessProfile> GetAllAccessProfilesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfilePDSAManager();
                mgr.DataObject.SelectFilter = AccessProfilePDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.Entity.EntityId = getParameters.UniqueId;
                else
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::GetAllAccessProfilesForEntity", ex);
                throw;
            }
        }

        public IArrayResponse<AccessProfile> GetAllAccessProfilesForMappedEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfilePDSAManager();
                mgr.DataObject.SelectFilter = AccessProfilePDSAData.SelectFilters.ByMappedEntityId;
                mgr.Entity.EntityId = getParameters.UniqueId;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllTimeSchedulesForRegion", ex);
                throw;
            }
        }
#else
        public IEnumerable<AccessProfile> GetAllAccessProfilesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfilePDSAManager();
                mgr.DataObject.SelectFilter = AccessProfilePDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.Entity.EntityId = getParameters.UniqueId;
                else
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::GetAllAccessProfilesForEntity", ex);
                throw;
            }
        }

        public IEnumerable<AccessProfile> GetAllAccessProfilesForMappedEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfilePDSAManager();
                mgr.DataObject.SelectFilter = AccessProfilePDSAData.SelectFilters.ByMappedEntityId;
                mgr.Entity.EntityId = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllTimeSchedulesForRegion", ex);
                throw;
            }
        }
#endif


        protected override AccessProfile GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override AccessProfile GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfilePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    AccessProfile result = new AccessProfile();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, AccessProfile originalEntity, AccessProfile newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "AccessProfileUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessProfileUid;
                        mgr.Entity.RecordTag = newEntity.AccessProfileUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "AccessProfileUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessProfileUid;
                        mgr.Entity.RecordTag = newEntity.AccessProfileUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "AccessProfileUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AccessProfileUid;
                        mgr.Entity.RecordTag = originalEntity.AccessProfileUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(AccessProfile entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                return;
            if (getParameters.IncludeMemberCollections)
            {
                getParameters.UniqueId = entity.AccessProfileUid;
                if (!getParameters.IsExcluded(nameof(entity.EntityIds)))
                {
                    var entityMaps = _entityMapRepository.GetAllAccessProfileEntityMapsForAccessProfile(sessionData, getParameters);
                    var entityIds = (from e in entityMaps select e.EntityId).ToList();
                    entity.EntityIds.AddRange(entityIds);

                    entity.EntityIds.Add(entity.EntityId);
                }

                if (!getParameters.IsExcluded(nameof(entity.AccessProfileClusters)))
                {
                    entity.AccessProfileClusters = _accessProfileClusterRepository.GetAllForAccessProfile(sessionData, getParameters).ToCollection();
                }
            }

        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("AccessProfile", "AccessProfileUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("AccessProfile", "AccessProfileUid", id);
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

        protected override bool IsEntityUnique(AccessProfile entity)
        {
            var mgr = new IsAccessProfileUniquePDSAManager();
            mgr.Entity.AccessProfileUid = entity.AccessProfileUid;
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.AccessProfileName = entity.AccessProfileName;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("AccessProfile", "AccessProfileUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("AccessProfile", "AccessProfileUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, AccessProfilePDSAManager mgr)
        {
            var omitNone = getParameters.GetOption(GetOptions_AccessProfile.OmitNone) ?? false;
            mgr.Entity.OmitNone = omitNone;

            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<AccessProfileSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }

        protected override IArrayResponse<AccessProfile> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfilePDSAManager();
                mgr.DataObject.SelectFilter = AccessProfilePDSAData.SelectFilters.ByEntityId;
                mgr.Entity.EntityId = sessionData.CurrentEntityId;

                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<AccessProfile> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfilePDSAManager();
                mgr.DataObject.SelectFilter = AccessProfilePDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileRepository::GetAllEntities", ex);
                throw;
            }
        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertAccessProfileCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        public Guid GetEntityId(Guid uid)
        {
            try
            {
                var mgr = new GetEntityIdForAccessProfilePDSAManager();
                mgr.Entity.uid = uid;
                var results = mgr.BuildCollection();
                if( results.Count > 0)
                    return results[0].EntityId;
                return Guid.Empty;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }

        }
    }
}
