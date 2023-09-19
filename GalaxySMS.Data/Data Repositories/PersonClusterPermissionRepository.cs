using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
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
    [Export(typeof(IPersonClusterPermissionRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonClusterPermissionRepository : DataRepositoryBase<PersonClusterPermission>, IPersonClusterPermissionRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;

        protected override PersonClusterPermission AddEntity(PersonClusterPermission entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new PersonClusterPermissionPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.PersonClusterPermissionUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::AddEntity", ex);
                throw;
            }
        }

        protected override PersonClusterPermission UpdateEntity(PersonClusterPermission entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.PersonClusterPermissionUid, sessionData, null);
                var mgr = new PersonClusterPermissionPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.PersonClusterPermissionUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.PersonClusterPermissionUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.PersonClusterPermissionUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void EnsureChildRecordsExist(PersonClusterPermission entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.PersonAccessGroups)) && entity.PersonAccessGroups != null && entity.PersonAccessGroups.Any())
                SavePersonAccessGroups(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonInputOutputGroups)) && entity.PersonInputOutputGroups != null && entity.PersonInputOutputGroups.Any())
                SavePersonInputOutputGroups(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonPersonalAccessGroup)) && entity.PersonPersonalAccessGroup != null)
                SavePersonPersonalAccessGroups(entity, sessionData, saveParams);
        }

        private void SavePersonAccessGroups(PersonClusterPermission entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {

            var personAccessGroupRepository = _dataRepositoryFactory.GetDataRepository<IPersonAccessGroupRepository>();

            // Set all that have not been specified (AccessGroupUid = Guid.Empty) to No Access Group
            var accessGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyAccessGroupRepository>();
            var clusterIdParams = new GetParametersWithPhoto() { ClusterUid = entity.ClusterUid, UniqueId = entity.ClusterUid };

            //var systemAccessGroups = accessGroupRepository.GetAllSystemAccessGroupsForCluster(sessionData, clusterIdParams);
            var allAccessGroups = (IEnumerable<AccessGroup>)accessGroupRepository.GetAllGalaxyAccessGroupsForCluster(sessionData, clusterIdParams).Items.ToCollection();
            var noAg = allAccessGroups.FirstOrDefault(o => o.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.None);
            var personalAg = allAccessGroups.FirstOrDefault(o => o.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup);

            var accessGroups = new List<AccessGroup>()
            {
            };

            //            var personAccessGroups = new List<PersonAccessGroup>()
            var personAccessGroups = new List<IAccessGroupAssignment>()
            {

            };

            accessGroups.Add(null);
            accessGroups.Add(null);
            accessGroups.Add(null);
            accessGroups.Add(null);

            personAccessGroups.Add(null);
            personAccessGroups.Add(null);
            personAccessGroups.Add(null);
            personAccessGroups.Add(null);

            var existingAccessGroups = personAccessGroupRepository.GetAllPersonAccessGroupsForPersonClusterPermission(sessionData, new GetParametersWithPhoto() { UniqueId = entity.PersonClusterPermissionUid }).ToList();

            // Add any missing person access group entries. Ensure that all 4 are there.
            var tempAgs = entity.PersonAccessGroups.ToList();
            for (short orderNumber = 1; orderNumber <= 4; orderNumber++)
            {
                var pag = tempAgs.FirstOrDefault(o => o.OrderNumber == orderNumber);
                if (pag == null)
                {
                    pag = existingAccessGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
                    if (pag == null)
                    {
                        pag = new PersonAccessGroup()
                        {
                            OrderNumber = orderNumber,
                            IsDirty = true
                        };
                        if (noAg != null)
                            pag.AccessGroupUid = noAg.AccessGroupUid;
                    }
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
                personAccessGroups[pag.OrderNumber - 1] = pagX;
            }

            AccessGroupHelpers.ValidateAccessGroupAssignments(ref accessGroups, ref allAccessGroups, ref personAccessGroups);

//            entity.PersonAccessGroups = tempAgs.ToCollection();
            entity.PersonAccessGroups = tempAgs.ToList();

            //var existingAccessGroups = personAccessGroupRepository.GetAllPersonAccessGroupsForPersonClusterPermission(sessionData, new GetParametersWithPhoto() { UniqueId = entity.PersonClusterPermissionUid }).ToList();
            var deleteThesePersonAccessGroups = existingAccessGroups.Where(c => entity.PersonAccessGroups.All(c2 => c2.PersonAccessGroupUid != c.PersonAccessGroupUid)).ToList();

            var propsToInclude = new List<string>();

            var propsToIgnore = new List<string>();
            //propsToIgnore.Add(nameof(PersonClusterPermission.IsDirty));
            //propsToIgnore.Add(nameof(PersonClusterPermission.IsAnythingDirty));
            //propsToIgnore.Add(nameof(PersonClusterPermission.IsPanelDataDirty));

            var dirtyPersonAccessGroups = new List<PersonAccessGroup>();
            int x = 0;
            //int y = 0;
            foreach (var pag in entity.PersonAccessGroups)
            {
                var existingItem = existingAccessGroups.FirstOrDefault(o => o.OrderNumber == pag.OrderNumber);
                pag.IndexValue = x++;
                pag.OwnerPropertyName = nameof(entity.PersonAccessGroups);
                //pcp.MyPropertyName = nameof(PersonClusterPermission);


                if (pag.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(pag, existingItem, propsToInclude, propsToIgnore))
                {
                    dirtyPersonAccessGroups.Add(pag);
                }
            }

            //var dirtyPersonAccessGroups = entity.PersonAccessGroups.Where(o => o.IsAnythingDirty).ToCollection();
            if (dirtyPersonAccessGroups.Any())
            {
                // spin through all the dirty person cluster permissions
                foreach (var pag in dirtyPersonAccessGroups)
                {
                    pag.PersonClusterPermissionUid = entity.PersonClusterPermissionUid;
                    if (pag.AccessGroupUid == Guid.Empty && noAg != null)
                        pag.AccessGroupUid = noAg.AccessGroupUid;

                    UpdateTableEntityBaseProperties(pag, sessionData);
                    if (pag.PersonAccessGroupUid == Guid.Empty)
                    {
                        pag.PersonAccessGroupUid = GuidUtilities.GenerateComb();
                        personAccessGroupRepository.Add(pag, sessionData, saveParams);
                    }
                    else
                        personAccessGroupRepository.Update(pag, sessionData, saveParams);
                }
            }

            foreach (var pag in deleteThesePersonAccessGroups)
            {
                // must explicitly delete the credential first
                personAccessGroupRepository.Remove(pag.PersonAccessGroupUid, sessionData);
            }
        }

        private void SavePersonInputOutputGroups(PersonClusterPermission entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            var personInputOutputGroupRepository = _dataRepositoryFactory.GetDataRepository<IPersonInputOutputGroupRepository>();

            var ioGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();

            var clusterIdParams = new GetParametersWithPhoto() { ClusterUid = entity.ClusterUid, UniqueId = entity.ClusterUid };

            //           var systemIoGroups = ioGroupRepository.GetAllSystemInputOutputGroupsForCluster(sessionData, clusterIdParams);
            var allIoGroups = ioGroupRepository.GetAllGalaxyInputOutputGroupsForCluster(sessionData, clusterIdParams);
            var noIog = allIoGroups.Items.FirstOrDefault(o => o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);
   
            var existingInputOutputGroups = personInputOutputGroupRepository.GetAllPersonInputOutputGroupsForPersonClusterPermission(sessionData, new GetParametersWithPhoto() { UniqueId = entity.PersonClusterPermissionUid }).ToList();

            var tempIogs = entity.PersonInputOutputGroups.ToList();
            for (short x = 1; x <= 4; x++)
            {
                var piog = tempIogs.FirstOrDefault(o => o.OrderNumber == x);
                if (piog == null)
                {
                    piog = existingInputOutputGroups.FirstOrDefault(o => o.OrderNumber == x);
                    if (piog == null)
                    {
                        piog = new PersonInputOutputGroup()
                        {
                            OrderNumber = x,
                            IsDirty = true
                        };
                    }

                    tempIogs.Add(piog);
                }

                
                var iog = allIoGroups.Items.FirstOrDefault(o => o.InputOutputGroupUid == piog.InputOutputGroupUid);
                if (iog == null && piog.InputOutputGroupNumber >= Common.Constants.InputOutputGroupLimits.None && piog.InputOutputGroupNumber <= Common.Constants.InputOutputGroupLimits.HighestNumber)
                    iog = allIoGroups.Items.FirstOrDefault(o => o.IOGroupNumber == piog.InputOutputGroupNumber);
                if (iog == null && !string.IsNullOrEmpty(piog.InputOutputGroupName))
                    iog = allIoGroups.Items.FirstOrDefault(o => o.Display == piog.InputOutputGroupName);

                if (iog == null)
                {
                    //                    iog = noIog;
                    throw new Exception($"{piog.GetType().Name} InputOutputGroup not found. InputOutputGroupUid:{piog.InputOutputGroupUid}, Number:'{piog.InputOutputGroupNumber}', Name:'{piog.InputOutputGroupName}' ");
                }

                piog.InputOutputGroupUid = iog.InputOutputGroupUid;
            }
 //           entity.PersonInputOutputGroups = tempIogs.ToCollection();
            entity.PersonInputOutputGroups = tempIogs.ToList();

            //var existingInputOutputGroups = personInputOutputGroupRepository.GetAllPersonInputOutputGroupsForPersonClusterPermission(sessionData, new GetParametersWithPhoto() { UniqueId = entity.PersonClusterPermissionUid }).ToList();
            var deleteThesePersonInputOutputGroups = existingInputOutputGroups.Where(c => entity.PersonInputOutputGroups.All(c2 => c2.PersonInputOutputGroupUid != c.PersonInputOutputGroupUid)).ToList();
            //var dirtyPersonInputOutputGroups = entity.PersonInputOutputGroups.Where(o => o.IsAnythingDirty).ToCollection();

            var propsToInclude = new List<string>();
            var propsToIgnore = new List<string>
            {
                //nameof(PersonClusterPermission.IsDirty),
                //nameof(PersonClusterPermission.IsAnythingDirty),
                //nameof(PersonClusterPermission.IsPanelDataDirty),
            };

            var dirtyPersonInputOutputGroups = new List<PersonInputOutputGroup>();
            int y = 0;
            foreach (var pag in entity.PersonInputOutputGroups)
            {
                var existingItem = existingInputOutputGroups.FirstOrDefault(o => o.OrderNumber == pag.OrderNumber);
                pag.IndexValue = y++;
                pag.OwnerPropertyName = nameof(entity.PersonInputOutputGroups);

                if (pag.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(pag, existingItem, propsToInclude, propsToIgnore))
                {
                    dirtyPersonInputOutputGroups.Add(pag);
                }
            }

            if (dirtyPersonInputOutputGroups.Any())
            {

                // spin through all the dirty person cluster permissions
                foreach (var piog in dirtyPersonInputOutputGroups)
                {
                    piog.PersonClusterPermissionUid = entity.PersonClusterPermissionUid;

                    if (piog.InputOutputGroupUid == Guid.Empty && noIog != null)
                        piog.InputOutputGroupUid = noIog.InputOutputGroupUid;

                    UpdateTableEntityBaseProperties(piog, sessionData);
                    if (piog.PersonInputOutputGroupUid == Guid.Empty)
                    {
                        piog.PersonInputOutputGroupUid = GuidUtilities.GenerateComb();
                        personInputOutputGroupRepository.Add(piog, sessionData, saveParams);
                    }
                    else
                        personInputOutputGroupRepository.Update(piog, sessionData, saveParams);
                }
            }

            foreach (var piog in deleteThesePersonInputOutputGroups)
            {
                // must explicitly delete the credential first
                personInputOutputGroupRepository.Remove(piog.PersonInputOutputGroupUid, sessionData);
            }
        }

        private void SavePersonPersonalAccessGroups(PersonClusterPermission entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            var personPersonalAccessGroupRepository = _dataRepositoryFactory.GetDataRepository<IPersonPersonalAccessGroupRepository>();
            var existingPersonPersonalAccessGroups = personPersonalAccessGroupRepository.GetAllPersonPersonalAccessGroupsForPersonClusterPermission(sessionData, new GetParametersWithPhoto() { UniqueId = entity.PersonClusterPermissionUid }).ToList();
            var existingPag = existingPersonPersonalAccessGroups.FirstOrDefault();
            if (entity.PersonPersonalAccessGroup == null && existingPag != null)
            {
                personPersonalAccessGroupRepository.Remove(existingPag.PersonClusterPermissionUid, sessionData);
            }
            else if (entity.PersonPersonalAccessGroup != null)
            {
                if (existingPag != null)
                {
                    UpdateTableEntityBasePropertiesFromExisting(entity.PersonPersonalAccessGroup, existingPag);
                    if (existingPag.PersonalAccessGroupNumber != entity.PersonPersonalAccessGroup.PersonalAccessGroupNumber)
                    {
                        entity.PersonPersonalAccessGroup.PersonalAccessGroupNumber = existingPag.PersonalAccessGroupNumber;
                    }
                }

                //if (entity.PersonPersonalAccessGroup.AccessPortals != null && entity.PersonPersonalAccessGroup.AccessPortals.Count > 0)
                //{
                //    if (entity.PersonPersonalAccessGroup.AccessPortalUids == null)
                //        entity.PersonPersonalAccessGroup.AccessPortalUids = new HashSet<Guid>();
                //    else
                //        entity.PersonPersonalAccessGroup.AccessPortalUids = entity.PersonPersonalAccessGroup.AccessPortalUids.ToCollection();
                //    foreach (var ap in entity.PersonPersonalAccessGroup.AccessPortals.Where(o => o.AccessPortalUid != Guid.Empty))
                //    {
                //        if (!entity.PersonPersonalAccessGroup.AccessPortalUids.Contains(ap.AccessPortalUid))
                //            entity.PersonPersonalAccessGroup.AccessPortalUids.Add(ap.AccessPortalUid);
                //    }
                //}
                //else
                //{
                //    if( entity.PersonPersonalAccessGroup.AccessPortalUids != null)
                //        entity.PersonPersonalAccessGroup.AccessPortalUids.Clear();
                //    else
                //    {
                //        entity.PersonPersonalAccessGroup.AccessPortalUids = new HashSet<Guid>();
                //    }
                //}

                //if (entity.PersonPersonalAccessGroup.DynamicAccessGroups != null && entity.PersonPersonalAccessGroup.DynamicAccessGroups.Count > 0)
                //{
                //    if (entity.PersonPersonalAccessGroup.DynamicAccessGroupUids == null)
                //        entity.PersonPersonalAccessGroup.DynamicAccessGroupUids = new HashSet<Guid>();
                //    else
                //        entity.PersonPersonalAccessGroup.DynamicAccessGroupUids = entity.PersonPersonalAccessGroup.DynamicAccessGroupUids.ToCollection();

                //    foreach (var ag in entity.PersonPersonalAccessGroup.DynamicAccessGroups.Where(o => o.AccessGroupUid != Guid.Empty))
                //    {
                //        if (!entity.PersonPersonalAccessGroup.DynamicAccessGroupUids.Contains(ag.AccessGroupUid))
                //            entity.PersonPersonalAccessGroup.DynamicAccessGroupUids.Add(ag.AccessGroupUid);
                //    }
                //}

                if (entity.PersonPersonalAccessGroup.IsAnythingDirty || entity.PersonPersonalAccessGroup.PersonClusterPermissionUid == Guid.Empty)
                {

                    entity.PersonPersonalAccessGroup.PersonClusterPermissionUid = entity.PersonClusterPermissionUid;
                    entity.PersonPersonalAccessGroup.ClusterUid = entity.ClusterUid;
                    if (entity.PersonPersonalAccessGroup.TimeScheduleUid == Guid.Empty)
                        entity.PersonPersonalAccessGroup.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;

                    UpdateTableEntityBaseProperties(entity.PersonPersonalAccessGroup, sessionData);
                    if (existingPersonPersonalAccessGroups.Count == 0)
                    {
                        if (entity.PersonPersonalAccessGroup.PersonalAccessGroupNumber == GalaxySMS.Common.Constants.PersonalAccessGroupDatabaseLimits.None)
                            entity.PersonPersonalAccessGroup.PersonalAccessGroupNumber = personPersonalAccessGroupRepository.GetAvailablePersonalAccessGroupNumber(entity.PersonPersonalAccessGroup.ClusterUid);
                        personPersonalAccessGroupRepository.Add(entity.PersonPersonalAccessGroup, sessionData, saveParams);
                    }
                    else
                        personPersonalAccessGroupRepository.Update(entity.PersonPersonalAccessGroup, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(PersonClusterPermission entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new PersonClusterPermissionPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.PersonClusterPermissionUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new PersonClusterPermissionPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<PersonClusterPermission> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonClusterPermissionPDSAManager();
                mgr.DataObject.SelectFilter = PersonClusterPermissionPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<PersonClusterPermission> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, PersonClusterPermissionPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (PersonClusterPermission entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<PersonClusterPermission> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonClusterPermissionPDSAManager();
                mgr.DataObject.SelectFilter = PersonClusterPermissionPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<PersonClusterPermission> GetAllPersonClusterPermissionsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonClusterPermissionPDSAManager();
                mgr.DataObject.SelectFilter = PersonClusterPermissionPDSAData.SelectFilters.ByPersonUid;
                mgr.Entity.PersonUid = getParameters.PersonUid;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::GetAllPersonClusterPermissionsForPerson", ex);
                throw;
            }
        }

        public IEnumerable<PersonClusterPermission> GetAllPersonClusterPermissionsForPersonAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonClusterPermissionPDSAManager();
                mgr.DataObject.SelectFilter = PersonClusterPermissionPDSAData.SelectFilters.ByPersonCredentialUid;
                mgr.Entity.ClusterUid = getParameters.ClusterUid;
                mgr.Entity.PersonUid = getParameters.PersonUid;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::GetAllPersonClusterPermissionsForPerson", ex);
                throw;
            }
        }

        public IEnumerable<PersonClusterPermission> GetAllPersonClusterPermissionsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonClusterPermissionPDSAManager();
                mgr.DataObject.SelectFilter = PersonClusterPermissionPDSAData.SelectFilters.ByClusterUid;
                mgr.Entity.ClusterUid = getParameters.ClusterUid;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::GetAllPersonClusterPermissionsForCluster", ex);
                throw;
            }

        }
        public IEnumerable<PersonClusterPermission> GetAllPersonClusterPermissionsForPersonCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonClusterPermissionPDSAManager();
                mgr.DataObject.SelectFilter = PersonClusterPermissionPDSAData.SelectFilters.ByPersonCredentialUid;
                mgr.Entity.PersonCredentialUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::GetAllPersonClusterPermissionsForPersonCredential", ex);
                throw;
            }
        }

        public IEnumerable<PersonClusterPermission> GetAllPersonClusterPermissionsForPersonCredentialAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonClusterPermissionPDSAManager();
                mgr.DataObject.SelectFilter = PersonClusterPermissionPDSAData.SelectFilters.ByPersonCredentialUidAndClusterUid;
                mgr.Entity.PersonCredentialUid = getParameters.UniqueId;
                mgr.Entity.ClusterUid = getParameters.ClusterUid;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::GetAllPersonClusterPermissionsForPersonCredentialAndCluster", ex);
                throw;
            }
        }

        protected override PersonClusterPermission GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override PersonClusterPermission GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonClusterPermissionPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    PersonClusterPermission result = new PersonClusterPermission();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, PersonClusterPermission originalEntity, PersonClusterPermission newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "PersonClusterPermissionUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.PersonClusterPermissionUid;
                        mgr.Entity.RecordTag = newEntity.PersonClusterPermissionUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "PersonClusterPermissionUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.PersonClusterPermissionUid;
                        mgr.Entity.RecordTag = newEntity.PersonClusterPermissionUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "PersonClusterPermissionUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.PersonClusterPermissionUid;
                        mgr.Entity.RecordTag = originalEntity.PersonClusterPermissionUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonClusterPermissionRepository::SaveAuditData", ex);
                                                                                                                        //throw;
            }
        }

        protected override void FillMemberCollections(PersonClusterPermission entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters != null && getParameters.IncludeMemberCollections)
            {
                var personAccessGroupRepository = _dataRepositoryFactory.GetDataRepository<IPersonAccessGroupRepository>();
                var personInputOutputGroupRepository = _dataRepositoryFactory.GetDataRepository<IPersonInputOutputGroupRepository>();
                var personPersonalAccessGroupRepository = _dataRepositoryFactory.GetDataRepository<IPersonPersonalAccessGroupRepository>();

                var accessGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyAccessGroupRepository>();
                var inputOutputGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();

                getParameters.PersonUid = entity.PersonUid;
                getParameters.ClusterUid = entity.ClusterUid;
 //               entity.PersonAccessGroups = personAccessGroupRepository.GetAllPersonAccessGroupsForPersonAndCluster(sessionData, getParameters).ToCollection();
                entity.PersonAccessGroups = personAccessGroupRepository.GetAllPersonAccessGroupsForPersonAndCluster(sessionData, getParameters).ToList();
 //               entity.PersonInputOutputGroups = personInputOutputGroupRepository.GetAllPersonInputOutputGroupsForPersonAndCluster(sessionData, getParameters).ToCollection();
                entity.PersonInputOutputGroups = personInputOutputGroupRepository.GetAllPersonInputOutputGroupsForPersonAndCluster(sessionData, getParameters).ToList();
                entity.PersonPersonalAccessGroup = personPersonalAccessGroupRepository.GetAllPersonPersonalAccessGroupsForPersonAndCluster(sessionData, getParameters).FirstOrDefault();
                if (entity.PersonPersonalAccessGroup == null)
                {
                    entity.PersonPersonalAccessGroup = new PersonPersonalAccessGroup()
                    {
                        TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always,
                        ClusterUid = entity.ClusterUid,
                        ConcurrencyValue = 0
                    };
                }

                var clusterIdParams = new GetParametersWithPhoto() { ClusterUid = entity.ClusterUid, UniqueId = entity.ClusterUid };

                var systemAccessGroups = accessGroupRepository.GetAllSystemAccessGroupsForCluster(sessionData, clusterIdParams);
                var systemInputOutputGroups = inputOutputGroupRepository.GetAllSystemInputOutputGroupsForCluster(sessionData, clusterIdParams);

                var noAccessGroup = systemAccessGroups.Items.FirstOrDefault(o => o.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.None);
                var noIoGroup = systemInputOutputGroups.Items.FirstOrDefault(o => o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);
                if (noAccessGroup == null)
                    noAccessGroup = new AccessGroup();
                if (noIoGroup == null)
                    noIoGroup = new InputOutputGroup();

                for (short g = 1; g <= 4; g++)
                {
                    if (entity.PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == g) == null)
                        entity.PersonAccessGroups.Add(new PersonAccessGroup() { OrderNumber = g, AccessGroupUid = noAccessGroup.AccessGroupUid, AccessGroupName = noAccessGroup.Display, ConcurrencyValue = 0});
                    if (entity.PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == g) == null)
                        entity.PersonInputOutputGroups.Add(new PersonInputOutputGroup() { OrderNumber = g, InputOutputGroupUid = noIoGroup.InputOutputGroupUid, InputOutputGroupName = noIoGroup.Display, ConcurrencyValue = 0});
                }
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("PersonClusterPermission", "PersonUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("PersonClusterPermission", "PersonUid", id);
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

        protected override bool IsEntityUnique(PersonClusterPermission entity)
        {
            var mgr = new IsPersonClusterPermissionUniquePDSAManager
            {
                Entity =
                {
                    PersonClusterPermissionUid = entity.PersonClusterPermissionUid,
                    PersonUid = entity.PersonUid,
                    ClusterUid = entity.ClusterUid
                }
            };
            if (entity.PersonCredentialUid.HasValue)
                mgr.Entity.PersonCredentialUid = entity.PersonCredentialUid.Value;
            else
                mgr.Entity.PersonCredentialUid = Guid.Empty;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("PersonClusterPermission", "PersonUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("PersonClusterPermission", "PersonUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
