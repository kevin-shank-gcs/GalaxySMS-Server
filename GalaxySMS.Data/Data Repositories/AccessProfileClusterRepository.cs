using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Interfaces;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.Data.Support;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
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

namespace GalaxySMS.Data
{
    [Export(typeof(IAccessProfileClusterRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessProfileClusterRepository : DataRepositoryBase<AccessProfileCluster>, IAccessProfileClusterRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IAccessProfileAccessGroupRepository _accessProfileAccessGroupRepository;
        [Import] private IAccessProfileInputOutputGroupRepository _accessProfileInputOutputGroupRepository;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;

        protected override AccessProfileCluster AddEntity(AccessProfileCluster entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new AccessProfileClusterPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.AccessProfileClusterUid, entity);
                    var result = GetEntityByGuidId(entity.AccessProfileClusterUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileClusterRepository::AddEntity", ex);
                throw;
            }
        }

        protected override AccessProfileCluster UpdateEntity(AccessProfileCluster entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.AccessProfileClusterUid, sessionData, null);
                var mgr = new AccessProfileClusterPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.AccessProfileClusterUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if ClusterUid is = Guid.Empty or null, then use the value from the original record
                    entity.ClusterUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.ClusterUid, entity.ClusterUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.AccessProfileClusterUid, entity);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.AccessProfileClusterUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.AccessProfileClusterUid} not found");

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileClusterRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void EnsureChildRecordsExist(AccessProfileCluster entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.AccessProfileAccessGroups)))
                SaveAccessProfileAccessGroups(entity, sessionData, saveParams);

            if (!saveParams.Ignore(nameof(entity.AccessProfileInputOutputGroups)))
                SaveAccessProfileInputOutputGroups(entity, sessionData, saveParams);


        }

        private void SaveAccessProfileAccessGroups(AccessProfileCluster entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.AccessProfileAccessGroups == null || !entity.AccessProfileAccessGroups.Any())
                return;

            // Validate the access groups.
            // Set all that have not been specified (AccessGroupUid = Guid.Empty) to No Access Group
            var accessGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyAccessGroupRepository>();
            var clusterIdParams = new GetParametersWithPhoto() { ClusterUid = entity.ClusterUid, UniqueId = entity.ClusterUid, IncludeMemberCollections = false, IncludePhoto = false };
            var allAccessGroups = (IEnumerable<AccessGroup>)accessGroupRepository.GetAllGalaxyAccessGroupsForCluster(sessionData, clusterIdParams).Items.ToCollection();
            var noAg = allAccessGroups.FirstOrDefault(o => o.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.None);

            //AccessGroup ag1 = null;
            //AccessGroup ag2 = null;
            //AccessGroup ag3 = null;
            //AccessGroup ag4 = null;

            //AccessProfileAccessGroup pag1 = null;
            //AccessProfileAccessGroup pag2 = null;
            //AccessProfileAccessGroup pag3 = null;
            //AccessProfileAccessGroup pag4 = null;

            var accessGroups = new List<AccessGroup>()
            {
            };

            var profileAccessGroups = new List<IAccessGroupAssignment>()//PersonAccessGroup>()
            {

            };

            accessGroups.Add(null);
            accessGroups.Add(null);
            accessGroups.Add(null);
            accessGroups.Add(null);

            profileAccessGroups.Add(null);
            profileAccessGroups.Add(null);
            profileAccessGroups.Add(null);
            profileAccessGroups.Add(null);

            // Add any missing person access group entries. Ensure that all 4 are there.
            var tempAgs = entity.AccessProfileAccessGroups.ToList();
            for (short x = 1; x <= 4; x++)
            {
                var pag = tempAgs.FirstOrDefault(o => o.OrderNumber == x);
                if (pag == null)
                {
                    pag = new AccessProfileAccessGroup()
                    {
                        OrderNumber = x,
                        IsDirty = true
                    };
                    if (noAg != null)
                        pag.AccessGroupUid = noAg.AccessGroupUid;

                    tempAgs.Add(pag);
                }

                var agX = accessGroups[pag.OrderNumber - 1];

                var pagX = tempAgs.FirstOrDefault(o => o.OrderNumber == pag.OrderNumber);
                agX = AccessGroupHelpers.SelectAccessGroupFromValues(ref allAccessGroups, pag);
                if (agX == null)
                    throw new Exception($"{pag.GetType().Name} AccessGroup not found. AccessGroup:{pag.AccessGroupUid}, Number:'{pag.AccessGroupNumber}', Name:'{pag.AccessGroupName}' ");
                if (pagX == null)
                    throw new Exception($"{pagX.GetType().Name} AccessGroup not found. AccessGroup:{pagX.AccessGroupUid}, Number:'{pagX.AccessGroupNumber}', Name:'{pagX.AccessGroupName}' ");

                pagX.AccessGroupUid = agX.AccessGroupUid;
                accessGroups[pag.OrderNumber - 1] = agX;
                profileAccessGroups[pag.OrderNumber - 1] = pagX;
            }

            AccessGroupHelpers.ValidateAccessGroupAssignments(ref accessGroups, ref allAccessGroups, ref profileAccessGroups);

            //foreach (var pag in tempAgs)
            //{
            //    var ag = allAccessGroups.FirstOrDefault(o => o.AccessGroupUid == pag.AccessGroupUid);
            //    switch (pag.OrderNumber)
            //    {
            //        case 1:
            //        case 2:
            //            // Check to see if the access group is an extended group. If so, this is not permitted. Check to see if it can be re-assigned to either position 3 or 4
            //            if (ag != null && ag.AccessGroupNumber > GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
            //                throw new Exception($"{pag.GetType().Name} with OrderNumber:{pag.OrderNumber} cannot be configured as an extended access group");
            //            break;

            //        case 3:
            //            if (ag != null && ag.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup)
            //                throw new Exception($"{pag.GetType().Name} with OrderNumber:{pag.OrderNumber} cannot be configured as the personal access group");
            //            break;

            //        case 4:
            //            break;
            //    }

            //}

            entity.AccessProfileAccessGroups = tempAgs.ToCollection();

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessProfileAccessGroupOption));

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveAccessProfileAccessGroupOption.DeleteMissingItems.ToString();

            var itemsFromDb = _accessProfileAccessGroupRepository.GetAllForAccessProfileCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessProfileClusterUid });

            // If any do not have a AccessProfileClusterUid (PrimaryKey value), see if we can determine the value by ClusterUid
            foreach (var apc in entity.AccessProfileAccessGroups.Where(o => o.AccessProfileAccessGroupUid == Guid.Empty))
            {
                var i = itemsFromDb.FirstOrDefault(o => o.OrderNumber == apc.OrderNumber);
                if (i != null)
                {
                    apc.AccessProfileAccessGroupUid = i.AccessProfileAccessGroupUid;
                }
            }

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Profile cluster
                foreach (var i in itemsFromDb)
                {
                    // If the AccessPortalAlertEventUid does not exist in the entity, then delete the area from the database
                    if (entity.AccessProfileAccessGroups.FirstOrDefault(o => o.AccessProfileAccessGroupUid == i.AccessProfileAccessGroupUid) == null)
                    {
                        _accessProfileAccessGroupRepository.Remove(i.AccessProfileAccessGroupUid, sessionData);
                    }
                }
            }

            // Now save those that are defined in the Access Profile being saved
            foreach (var i in entity.AccessProfileAccessGroups)
            {
                var existingItem = itemsFromDb.FirstOrDefault(o => o.AccessProfileAccessGroupUid == i.AccessProfileAccessGroupUid);
                //                if (existingItem == null)
                //                    continue;
                if (existingItem != null)
                {
                    if (i.AccessProfileClusterUid != existingItem.AccessProfileClusterUid)
                        i.AccessProfileClusterUid = existingItem.AccessProfileClusterUid;
                }
                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessProfileAccessGroupRepository.Update(i, sessionData, saveParams);
                }
                if (i.AccessProfileClusterUid == Guid.Empty)
                {
                    i.AccessProfileAccessGroupUid = GuidUtilities.GenerateComb();
                    i.AccessProfileClusterUid = entity.AccessProfileClusterUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessProfileAccessGroupRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        private void SaveAccessProfileInputOutputGroups(AccessProfileCluster entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.AccessProfileInputOutputGroups == null || !entity.AccessProfileInputOutputGroups.Any())
                return;

            var ioGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();

            var clusterIdParams = new GetParametersWithPhoto() { ClusterUid = entity.ClusterUid, UniqueId = entity.ClusterUid };

            //           var systemIoGroups = ioGroupRepository.GetAllSystemInputOutputGroupsForCluster(sessionData, clusterIdParams);
            var allIoGroups = ioGroupRepository.GetAllGalaxyInputOutputGroupsForCluster(sessionData, clusterIdParams).Items.ToCollection();
            var noIog = allIoGroups.FirstOrDefault(o => o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);

            var tempIogs = entity.AccessProfileInputOutputGroups.ToList();
            for (short x = 1; x <= 4; x++)
            {
                var piog = tempIogs.FirstOrDefault(o => o.OrderNumber == x);
                if (piog == null)
                    tempIogs.Add(new AccessProfileInputOutputGroup()
                    {
                        OrderNumber = x,
                        IsDirty = true
                    });

                var iog = allIoGroups.FirstOrDefault(o => o.InputOutputGroupUid == piog.InputOutputGroupUid);
                if (iog == null && piog.InputOutputGroupNumber >= Common.Constants.InputOutputGroupLimits.None && piog.InputOutputGroupNumber <= Common.Constants.InputOutputGroupLimits.HighestNumber)
                    iog = allIoGroups.FirstOrDefault(o => o.IOGroupNumber == piog.InputOutputGroupNumber);
                if (iog == null && !string.IsNullOrEmpty(piog.InputOutputGroupName))
                    iog = allIoGroups.FirstOrDefault(o => o.Display == piog.InputOutputGroupName);

                if (iog == null)
                {
                    //iog = noIog;
                    throw new Exception($"{piog.GetType().Name} InputOutputGroup not found. InputOutputGroupUid:{piog.InputOutputGroupUid}, Number:'{piog.InputOutputGroupNumber}', Name:'{piog.InputOutputGroupName}' ");
                }

                piog.InputOutputGroupUid = iog.InputOutputGroupUid;
            }
            entity.AccessProfileInputOutputGroups = tempIogs.ToCollection();




            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessProfileInputOutputGroupOption));

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveAccessProfileInputOutputGroupOption.DeleteMissingItems.ToString();

            var itemsFromDb = _accessProfileInputOutputGroupRepository.GetAllForAccessProfileCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessProfileClusterUid });

            // If any do not have a AccessProfileClusterUid (PrimaryKey value), see if we can determine the value by ClusterUid
            foreach (var apc in entity.AccessProfileInputOutputGroups.Where(o => o.AccessProfileInputOutputGroupUid == Guid.Empty))
            {
                var i = itemsFromDb.FirstOrDefault(o => o.OrderNumber == apc.OrderNumber);
                if (i != null)
                {
                    apc.AccessProfileInputOutputGroupUid = i.AccessProfileInputOutputGroupUid;
                }
            }

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Profile cluster
                foreach (var i in itemsFromDb)
                {
                    // If the AccessPortalAlertEventUid does not exist in the entity, then delete the area from the database
                    if (entity.AccessProfileInputOutputGroups.FirstOrDefault(o => o.AccessProfileInputOutputGroupUid == i.AccessProfileInputOutputGroupUid) == null)
                    {
                        _accessProfileInputOutputGroupRepository.Remove(i.AccessProfileInputOutputGroupUid, sessionData);
                    }
                }
            }

            // Now save those that are defined in the Access Portal being saved
            foreach (var i in entity.AccessProfileInputOutputGroups)
            {
                var existingItem = itemsFromDb.FirstOrDefault(o => o.AccessProfileInputOutputGroupUid == i.AccessProfileInputOutputGroupUid);
                //if (existingItem == null)
                //    continue;
                if (existingItem != null)
                {
                    if (i.AccessProfileClusterUid != existingItem.AccessProfileClusterUid)
                        i.AccessProfileClusterUid = existingItem.AccessProfileClusterUid;
                }
                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessProfileInputOutputGroupRepository.Update(i, sessionData, saveParams);
                }
                if (i.AccessProfileClusterUid == Guid.Empty)
                {
                    i.AccessProfileInputOutputGroupUid = GuidUtilities.GenerateComb();
                    i.AccessProfileClusterUid = entity.AccessProfileClusterUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessProfileInputOutputGroupRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(AccessProfileCluster entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new AccessProfileClusterPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.AccessProfileClusterUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileClusterRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new AccessProfileClusterPDSAManager();

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
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileClusterRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<AccessProfileCluster> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessProfileClusterPDSAManager mgr)
        {
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

        // GetAllAccessProfileClusters for an Entity
        protected override IEnumerable<AccessProfileCluster> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfileClusterPDSAManager();
                mgr.DataObject.SelectFilter = AccessProfileClusterPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileClusterRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<AccessProfileCluster> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfileClusterPDSAManager();
                mgr.DataObject.SelectFilter = AccessProfileClusterPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileClusterRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<AccessProfileCluster> GetAllForAccessProfile(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfileClusterPDSAManager();
                mgr.DataObject.SelectFilter = AccessProfileClusterPDSAData.SelectFilters.ByAccessProfileUid;
                mgr.Entity.AccessProfileUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileClusterRepository::GetAllAccessProfileClustersForEntity", ex);
                throw;
            }
        }
        public IEnumerable<AccessProfileCluster> GetAllForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfileClusterPDSAManager();
                mgr.DataObject.SelectFilter = AccessProfileClusterPDSAData.SelectFilters.ByClusterUid;
                mgr.Entity.ClusterUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileClusterRepository::GetAllForCluster", ex);
                throw;
            }
        }

        protected override AccessProfileCluster GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override AccessProfileCluster GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfileClusterPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    AccessProfileCluster result = new AccessProfileCluster();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileClusterRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, AccessProfileCluster originalEntity, AccessProfileCluster newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "AccessProfileClusterUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessProfileClusterUid;
                        mgr.Entity.RecordTag = newEntity.AccessProfileClusterUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "AccessProfileClusterUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessProfileClusterUid;
                        mgr.Entity.RecordTag = newEntity.AccessProfileClusterUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "AccessProfileClusterUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AccessProfileClusterUid;
                        mgr.Entity.RecordTag = originalEntity.AccessProfileClusterUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileClusterRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(AccessProfileCluster entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                return;
            if (getParameters.IncludeMemberCollections)
            {
                if (!getParameters.IsExcluded(nameof(entity.AccessProfileAccessGroups)))
                {
                    entity.AccessProfileAccessGroups = _accessProfileAccessGroupRepository.GetAllForAccessProfileCluster(sessionData,
                    new GetParametersWithPhoto(getParameters) { UniqueId = entity.AccessProfileClusterUid }).ToCollection();

                    for (short orderNumber = 1; orderNumber <= 4; orderNumber++)
                    {
                        var ag = entity.AccessProfileAccessGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
                        if (ag == null)
                        {
                            entity.AccessProfileAccessGroups.Add(new AccessProfileAccessGroup()
                            {
                                OrderNumber = orderNumber,
                                ConcurrencyValue = 0,
                            });
                        }
                    }
                }

                if (!getParameters.IsExcluded(nameof(entity.AccessProfileInputOutputGroups)))
                {
                    entity.AccessProfileInputOutputGroups = _accessProfileInputOutputGroupRepository.GetAllForAccessProfileCluster(sessionData,
                        new GetParametersWithPhoto(getParameters) { UniqueId = entity.AccessProfileClusterUid }).ToCollection();

                    for (short orderNumber = 1; orderNumber <= 4; orderNumber++)
                    {
                        var iog = entity.AccessProfileInputOutputGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
                        if (iog == null)
                        {
                            entity.AccessProfileInputOutputGroups.Add(new AccessProfileInputOutputGroup()
                            {
                                OrderNumber = orderNumber,
                                ConcurrencyValue = 0
                            });
                        }
                    }
                }
            }

        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("AccessProfileCluster", "AccessProfileClusterUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("AccessProfileCluster", "AccessProfileClusterUid", id);
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

        protected override bool IsEntityUnique(AccessProfileCluster entity)
        {
            var mgr = new IsAccessProfileClusterUniquePDSAManager();
            mgr.Entity.AccessProfileClusterUid = entity.AccessProfileClusterUid;
            mgr.Entity.AccessProfileUid = entity.AccessProfileUid;
            mgr.Entity.ClusterUid = entity.ClusterUid;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("AccessProfileCluster", "AccessProfileClusterUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("AccessProfileCluster", "AccessProfileClusterUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }


    }
}
