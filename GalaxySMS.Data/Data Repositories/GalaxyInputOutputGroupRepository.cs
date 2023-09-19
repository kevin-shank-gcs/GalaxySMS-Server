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

namespace GalaxySMS.Data
{
    [Export(typeof(IGalaxyInputOutputGroupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InputOutputGroupRepository : PagedDataRepositoryBase<InputOutputGroup>, IGalaxyInputOutputGroupRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import]
        private IGalaxyInputOutputGroupEntityMapRepository _entityMapRepository;

        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        [Import]
        private IInputOutputGroupAssignmentRepository _iogroupAssignmentRepository;

        [Import]
        private IInputOutputGroupCommandRepository _iogroupCommandRepository;
        [Import]
        private IRoleInputOutputGroupRepository _roleInputOutputGroupRepository;

        protected override InputOutputGroup AddEntity(InputOutputGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.InputOutputGroupUid,
                            PermissionIds.GalaxySMSDataAccessPermission
                                .SystemHardwareCanAddId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to add galaxy input output group {entity.InputOutputGroupUid}");
                    }
                }

                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                if (entity.IOGroupNumber == (int)GalaxySMS.Common.Enums.InputOutputGroupNumber.None)
                {
                    _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                    _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);
                }

                if (entity.TimeScheduleUid == Guid.Empty)
                    entity.TimeScheduleUid = Common.Constants.TimeScheduleIds.TimeSchedule_Never;

                var mgr = new InputOutputGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.InputOutputGroupUid, entity, saveParams);
                    SaveRoleMappings(sessionData, entity.InputOutputGroupUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.InputOutputGroupUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        UpdateEntityCount(result.EntityId);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::AddEntity", ex);
                throw;
            }
        }

        private void EnsureChildRecordsExist(InputOutputGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.IOGroupNumber != GalaxySMS.Common.Constants.InputOutputGroupLimits.None)
            {
                // Create InputOutputGroupAssignment records
                var assignments = _iogroupAssignmentRepository.GetAllForInputOutputGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputOutputGroupUid });
                for (var o = GalaxySMS.Common.Constants.InputOutputGroupOffsetLimits.Minimum; o <= GalaxySMS.Common.Constants.InputOutputGroupOffsetLimits.Maximum; o++)
                {
                    if (assignments.FirstOrDefault(i => i.OffsetIndex == o) == null)
                    {
                        var assignment = new InputOutputGroupAssignment()
                        {
                            InputOutputGroupAssignmentUid = GuidUtilities.GenerateComb(),
                            InputOutputGroupUid = entity.InputOutputGroupUid,
                            OffsetIndex = o,
                            Tag = GalaxySMS.Common.Constants.InputOutputGroupOffsetLimits.DefaultTag
                        };
                        UpdateTableEntityBaseProperties(assignment, sessionData);
                        _iogroupAssignmentRepository.Add(assignment, sessionData, saveParams);
                    }
                }
            }
        }

        protected override InputOutputGroup UpdateEntity(InputOutputGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.InputOutputGroupUid,
                            GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission
                                .SystemHardwareCanUpdateId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update input-output group {entity.InputOutputGroupUid}");
                    }
                }

                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                if (entity.IOGroupNumber == (int)GalaxySMS.Common.Enums.InputOutputGroupNumber.None)
                {
                    _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                    _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);
                }

                var originalEntity = GetEntityByGuidId(entity.InputOutputGroupUid, sessionData, null);
                if (originalEntity != null && originalEntity.EntityId != entity.EntityId)
                {
                    if (!DoesUserHavePermission(sessionData, entity.ClusterUid, PermissionIds.GalaxySMSDataAccessPermission
                            .SystemHardwareCanUpdateId, originalEntity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update input-output group {entity.InputOutputGroupUid}");
                    }
                }
                var mgr = new InputOutputGroupPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.InputOutputGroupUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);

                    // if ClusterUid is = Guid.Empty or null, then use the value from the original record
                    entity.ClusterUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.ClusterUid, entity.ClusterUid);

                    // if TimeScheduleUid is = Guid.Empty or null, then use the value from the original record
                    entity.TimeScheduleUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.TimeScheduleUid, entity.TimeScheduleUid);

                    mgr.InitEntityObject(entity);
                    //                mgr.Entity = entity;
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.InputOutputGroupUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.InputOutputGroupUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);

                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);

                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.InputOutputGroupUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(InputOutputGroup entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.InputOutputGroupUid);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var entityId = GetEntityId(id);
                if (!DoesUserHavePermission(sessionData, id, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId, entityId))
                {
                    throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to delete input-output group {id}");
                }

                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new InputOutputGroupPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<InputOutputGroup> GetFilteredInputOutputGroups(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters, InputOutputGroupPDSAManager mgr)
        {
            IEnumerable<InputOutputGroup> entities = new List<InputOutputGroup>();
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                entities = mgr.ConvertPDSACollection(pdsaEntities);
                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a ap, creating RoleInputOutputGroup records
                //      2) When saving Role, creating RoleInputOutputGroup records
                // 
                //if (sessionData == null || sessionData.UserId == Guid.Empty)
                //{
                //    entities = mgr.ConvertPDSACollection(pdsaEntities);
                //}
                //else
                //{
                //    var filteredInputOutputGroupUids = GetFilteredInputOutputGroupUids(sessionData);
                //    var pdsaItems = pdsaEntities.Where(p => filteredInputOutputGroupUids.Any(p2 => p2.InputOutputGroupUid == p.InputOutputGroupUid));

                //    entities = mgr.ConvertPDSACollection(pdsaItems);
                //}
            }
            return entities;
        }
        private IArrayResponse<InputOutputGroup> GetFilteredInputOutputGroupsPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters, InputOutputGroupPDSAManager mgr)
        {
            IEnumerable<InputOutputGroup> entities = new List<InputOutputGroup>();
            SetSortColumnAndOrder(getParameters, mgr);
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                entities = mgr.ConvertPDSACollection(pdsaEntities);
                var totalCount = 0;
                var first = entities.FirstOrDefault();
                if (first != null)
                {
                    totalCount = first.TotalRowCount;
                }
                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a ap, creating RoleInputOutputGroup records
                //      2) When saving Role, creating RoleInputOutputGroup records
                // 
                //if (sessionData == null || sessionData.UserId == Guid.Empty)
                //{
                //    entities = mgr.ConvertPDSACollection(pdsaEntities);
                //}
                //else
                //{
                //    var filteredInputOutputGroupUids = GetFilteredInputOutputGroupUids(sessionData);
                //    var pdsaItems = pdsaEntities.Where(p => filteredInputOutputGroupUids.Any(p2 => p2.InputOutputGroupUid == p.InputOutputGroupUid));

                //    entities = mgr.ConvertPDSACollection(pdsaItems);
                //}
                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
            }
            return new ArrayResponse<InputOutputGroup>();
        }

        private EntityLayer.InputOutputGroupUids_SelectForUserIdPDSACollection GetFilteredInputOutputGroupUids(IApplicationUserSessionDataHeader sessionData)
        {
            var filteredMgr = new InputOutputGroupUids_SelectForUserIdPDSAManager();
            filteredMgr.Entity.UserId = sessionData.UserId;
            var filteredInputOutputGroupUids = filteredMgr.BuildCollection();
            return filteredInputOutputGroupUids;
        }
        private IEnumerable<InputOutputGroup> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, InputOutputGroupPDSAManager mgr)
        {
            var entities = GetFilteredInputOutputGroups(sessionData, getParameters, mgr);
            foreach (var entity in entities)
            {
                if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludeCommands)
                    FillMemberCollections(entity, null, getParameters);
            }
            return entities;
        }
        private IArrayResponse<InputOutputGroup> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, InputOutputGroupPDSAManager mgr)
        {
            var entities = GetFilteredInputOutputGroupsPaged(sessionData, getParameters, mgr);
            foreach (var entity in entities.Items)
            {
                if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludeCommands)
                    FillMemberCollections(entity, null, getParameters);
            }
            return entities;
        }


        //private IEnumerable<InputOutputGroup> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, InputOutputGroupPDSAManager mgr)
        //{
        //    var pdsaEntities = mgr.BuildCollection();
        //    if (pdsaEntities != null)
        //    {
        //        var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //        foreach (var entity in entities)
        //        {
        //            if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludeCommands)
        //                FillMemberCollections(entity, null, getParameters);
        //        }
        //        return entities;
        //    }
        //    return null;
        //}

        // GetAllInputOutputGroups for an Entity
        protected override IEnumerable<InputOutputGroup> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<InputOutputGroup> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllEntities", ex);
                throw;
            }
        }

#if UsePaging
        public IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.ByEntityId;
                if (parameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                else
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupsForCluster", ex);
                throw;
            }
        }

        public IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.ByClusterUid;
                mgr.Entity.ClusterUid = parameters.UniqueId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupsForCluster", ex);
                throw;
            }
        }


        public IArrayResponse<InputOutputGroup> GetAllInputOutputGroupSelectionItemsForClusterAddress(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.ListBoxByClusterAddress;
                mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = parameters.ClusterNumber;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupsForCluster", ex);
                throw;
            }
        }


        public IArrayResponse<InputOutputGroup> GetAllSystemInputOutputGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager
                {
                    DataObject =
                    {
                        SelectFilter = InputOutputGroupPDSAData.SelectFilters.GetSpecialGroupsByClusterUid
                    },
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllSystemInputOutputGroupsForCluster", ex);
                throw;
            }
        }

        public IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
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
                    return GetAllGalaxyInputOutputGroupsForCluster(sessionData, newParams);
                }

                return new ArrayResponse<InputOutputGroup>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllGalaxyInputOutputGroupsForAccessPortal", ex);
                throw;
            }
        }

        public IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForInputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new ClusterUid_GetByInputDeviceUidPDSAManager
                {
                    Entity = { inputDeviceUid = parameters.UniqueId }
                };
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(parameters as GetParametersWithPhoto)
                    {
                        UniqueId = data[0].ClusterUid
                    };
                    return GetAllGalaxyInputOutputGroupsForCluster(sessionData, newParams);
                }
                return new ArrayResponse<InputOutputGroup>();
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

        public IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForOutputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new ClusterUid_GetByOutputDeviceUidPDSAManager
                {
                    Entity = { outputDeviceUid = parameters.UniqueId }
                };
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(parameters as GetParametersWithPhoto)
                    {
                        UniqueId = data[0].ClusterUid
                    };
                    return GetAllGalaxyInputOutputGroupsForCluster(sessionData, newParams);
                }
                return new ArrayResponse<InputOutputGroup>();
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

        public IArrayResponse<InputOutputGroup> GetAllGalaxyInputOutputGroupsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.ByClusterUidEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupsForCluster", ex);
                throw;
            }
        }
#else
        public IEnumerable<InputOutputGroup> GetAllGalaxyInputOutputGroupsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.ByEntityId;
                if (parameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                else
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupsForCluster", ex);
                throw;
            }
        }

        public IEnumerable<InputOutputGroup> GetAllGalaxyInputOutputGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.ByClusterUid;
                mgr.Entity.ClusterUid = parameters.UniqueId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupsForCluster", ex);
                throw;
            }
        }


        public IEnumerable<InputOutputGroup> GetAllInputOutputGroupSelectionItemsForClusterAddress(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.ListBoxByClusterAddress;
                mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = parameters.ClusterNumber;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupsForCluster", ex);
                throw;
            }
        }


        public IEnumerable<InputOutputGroup> GetAllSystemInputOutputGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager
                {
                    DataObject =
                    {
                        SelectFilter = InputOutputGroupPDSAData.SelectFilters.GetSpecialGroupsByClusterUid
                    },
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllSystemInputOutputGroupsForCluster", ex);
                throw;
            }
        }

        public IEnumerable<InputOutputGroup> GetAllGalaxyInputOutputGroupsForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
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
                    return GetAllGalaxyInputOutputGroupsForCluster(sessionData, newParams);
                }
                return new List<InputOutputGroup>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllGalaxyInputOutputGroupsForAccessPortal", ex);
                throw;
            }
        }

        public IEnumerable<InputOutputGroup> GetAllGalaxyInputOutputGroupsForInputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new ClusterUid_GetByInputDeviceUidPDSAManager
                {
                    Entity = { inputDeviceUid = parameters.UniqueId }
                };
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(parameters as GetParametersWithPhoto)
                    {
                        UniqueId = data[0].ClusterUid
                    };
                    return GetAllGalaxyInputOutputGroupsForCluster(sessionData, newParams);
                }
                return new List<InputOutputGroup>();
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

        public IEnumerable<InputOutputGroup> GetAllGalaxyInputOutputGroupsForOutputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new ClusterUid_GetByOutputDeviceUidPDSAManager
                {
                    Entity = { outputDeviceUid = parameters.UniqueId }
                };
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(parameters as GetParametersWithPhoto)
                    {
                        UniqueId = data[0].ClusterUid
                    };
                    return GetAllGalaxyInputOutputGroupsForCluster(sessionData, newParams);
                }
                return new List<InputOutputGroup>();
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


        public IEnumerable<InputOutputGroup> GetAllGalaxyInputOutputGroupsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.ByClusterUidEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupsForCluster", ex);
                throw;
            }
        }
#endif
        public IEnumerable<InputOutputGroupSelectionItemBasic> GetAllInputOutputGroupSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroup_SelectionListForEntityAndClusterPDSAManager();
                mgr.Entity.EntityId = parameters.CurrentEntityId;
                mgr.Entity.ClusterUid = parameters.ClusterUid;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<InputOutputGroupSelectionItemBasic>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new InputOutputGroupSelectionItemBasic();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        entities.Add(newEntity);
                    }
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupSelectionItemBasicsForEntityAndCluster", ex);
                throw;
            }
        }


        public InputOutputGroup GetInputOutputGroupSelectionItemsForClusterAddressAndInputOutputGroupNumber(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.ByClusterAndInputOuputGroupNumber;
                mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = parameters.ClusterNumber;
                mgr.Entity.IOGroupNumber = parameters.GetInt32;
                mgr.Entity.CultureName = sessionData.UiCulture;

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (var entity in entities)
                    {
                        if (parameters == null || parameters.IncludeMemberCollections || parameters.IncludeCommands)
                            FillMemberCollections(entity, null, parameters);

                        return entity;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupsForCluster", ex);
                throw;
            }
        }

        public IEnumerable<InputOutputGroupAssignmentSource> GetInputOutputGroupAssignmentSourcesForInputOutputGroupUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroupAssignmentSources_ByInputOuputGroupUidPDSAManager();
                mgr.Entity.InputOutputGroupUid = parameters.UniqueId;
                mgr.Entity.GalaxyPanelUid = parameters.GetGuid;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<InputOutputGroupAssignmentSource>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new InputOutputGroupAssignmentSource();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        entities.Add(newEntity);
                    }
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupSelectionItemBasicsForEntityAndCluster", ex);
                throw;
            }
        }

        protected override InputOutputGroup GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override InputOutputGroup GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    if (!DoesUserHavePermission(sessionData, mgr.Entity.InputOutputGroupUid, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId, mgr.Entity.EntityId))
                    {
                        throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to view input-output group {mgr.Entity.Display}");
                    }

                    InputOutputGroup result = new InputOutputGroup();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludeCommands)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        public InputOutputGroup_PanelLoadData GetInputOutputGroupPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroup_GetPanelLoadDataByInputOutputGroupUidPDSAManager();
                mgr.Entity.InputOutputGroupUid = parameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null && result.Count == 1)
                {
                    var returnData = new InputOutputGroup_PanelLoadData();
                    SimpleMapper.PropertyMap(result[0], returnData);
                    return returnData;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetInputOutputGroupPanelLoadData", ex);
                throw;
            }
        }


        public IEnumerable<InputOutputGroup_PanelLoadData> GetAllInputOutputGroupPanelLoadDataForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputOutputGroup_GetPanelLoadDataByClusterUidPDSAManager();
                mgr.Entity.ClusterUid = parameters.UniqueId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<InputOutputGroup_PanelLoadData>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new InputOutputGroup_PanelLoadData();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        entities.Add(newEntity);
                    }
                    return entities;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllInputOutputGroupPanelLoadDataForCluster", ex);
                throw;
            }

        }

        public int GetAvailableInputOutputGroupNumber(Guid clusterUid)
        {
            try
            {
                int availableIogNumber = GalaxySMS.Common.Constants.InputOutputGroupLimits.None;

                var mgr = new ChooseAvailableInputOutputGroupNumberPDSAManager { Entity = { ClusterUid = clusterUid } };
                var results = mgr.BuildCollection();
                if (results != null && results.Count == 1)
                    availableIogNumber = results[0].IOGroupNumber;

                return availableIogNumber;
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

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, InputOutputGroup originalEntity, InputOutputGroup newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "InputOutputGroupUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InputOutputGroupUid;
                        mgr.Entity.RecordTag = newEntity.InputOutputGroupUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "InputOutputGroupUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InputOutputGroupUid;
                        mgr.Entity.RecordTag = newEntity.InputOutputGroupUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "InputOutputGroupUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.InputOutputGroupUid;
                        mgr.Entity.RecordTag = originalEntity.InputOutputGroupUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(InputOutputGroup entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                getParameters = new GetParametersWithPhoto();

            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
            if (getParameters.IncludeMemberCollections)
            {
                var entityMaps = _entityMapRepository.GetAllInputOutputGroupEntityMapsForInputOutputGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputOutputGroupUid });
                var entityIds = (from e in entityMaps select e.EntityId).ToList();
                entity.EntityIds.AddRange(entityIds);
                foreach (var e in entityMaps)
                {
                    if (e.EntityId != entity.EntityId)
                        entity.EntityIds.Add(e.EntityId);
                }
                entity.EntityIds.Add(entity.EntityId);

                var roleFilters = _roleInputOutputGroupRepository.GetAllForInputOutputGroupUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputOutputGroupUid });
                var roleIds = (from e in roleFilters select e.RoleId).ToList();
                entity.RoleIds.AddRange(roleIds);

                entity.InputOutputGroupAssignments = _iogroupAssignmentRepository.GetAllForInputOutputGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputOutputGroupUid }).ToCollection();
            }

            if (getParameters.IncludeCommands && entity.IOGroupNumber > GalaxySMS.Common.Constants.InputOutputGroupLimits.None)
            {
                var getP = new GetParametersWithPhoto() { UniqueId = entity.InputOutputGroupUid, IncludePhoto = false };
                var cmds = _iogroupCommandRepository.Get(sessionData, getP).ToCollection();

                //// Now determine if the access portal Relay2 mode is Scheduled. If not, take out the relay2 on / off commands
                //var apData = this.GetAccessPortalPanelLoadData(sessionData, getP);
                //if (apData != null)
                //{
                //    if ((GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode)apData.Relay2ModeCode == GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode.Follows ||
                //        (GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode)apData.Relay2ModeCode == GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode.Latching ||
                //        (GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode)apData.Relay2ModeCode == GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode.Timeout)
                //    {
                //        var cmd = cmds.FirstOrDefault(o => o.AccessPortalCommandUid == Common.Constants.AccessPortalCommandIds.AuxRelayOn);
                //        if (cmd != null)
                //            cmds.Remove(cmd);
                //    }
                //    if ((GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode)apData.Relay2ModeCode == GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode.Timeout)
                //    {
                //        var cmd = cmds.FirstOrDefault(o => o.AccessPortalCommandUid == Common.Constants.AccessPortalCommandIds.AuxRelayOff);
                //        if (cmd != null)
                //            cmds.Remove(cmd);
                //    }
                //}
                entity.Commands = cmds;
            }
        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllInputOutputGroupEntityMapsForInputOutputGroup(sessionData, getParameters);
            var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
            var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

            foreach (var existingEntityId in existingEntityIds)
            {
                if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
                {
                    var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
                    if (deleteThisExistingEntityMap != null)
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.InputOutputGroupEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new InputOutputGroupEntityMap();
                    entityMap.InputOutputGroupEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.InputOutputGroupUid = uid;
                    entityMap.EntityId = entityId;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        private void SaveRoleMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasRoleMappingList entity, ISaveParameters saveParams)
        {
            if (entity.RoleIds == null || !entity.RoleIds.Any() || saveParams.Ignore(nameof(entity.RoleIds)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingRoleInputOutputGroups = _roleInputOutputGroupRepository.GetAllForInputOutputGroupUid(sessionData, getParameters);
            var existingRoleIds = new HashSet<Guid>(existingRoleInputOutputGroups.Select(e => e.RoleId));
            var deleteRoleIds = existingRoleIds.Except(entity.RoleIds);

            foreach (var rid in deleteRoleIds)
            {
                var rc = existingRoleInputOutputGroups.FirstOrDefault(o => o.RoleId == rid);
                if (rc != null)
                    _roleInputOutputGroupRepository.Remove(rc.InputOutputGroupUid, sessionData);
            }

            foreach (var roleId in entity.RoleIds)
            {
                if (!existingRoleIds.Contains(roleId))
                {
                    var roleIog = new RoleInputOutputGroup();
                    roleIog.RoleInputOutputGroupUid = GuidUtilities.GenerateComb();
                    roleIog.InputOutputGroupUid = uid;
                    roleIog.RoleId = roleId;
                    UpdateTableEntityBaseProperties(roleIog, sessionData);

                    _roleInputOutputGroupRepository.Add(roleIog, sessionData, saveParams);
                }
            }
        }

        public InputOutputGroupClusterPermissionValidationResult GetInputOutputGroupClusterPermissionValidationResult(Guid clusterUid, Guid inputOutputGroupUid, short orderNumber)
        {
            try
            {
                var mgr = new IsInputOutputGroupClusterPermissionValidPDSAManager();
                mgr.Entity.ClusterUid = clusterUid;
                mgr.Entity.InputOutputGroupUid = inputOutputGroupUid;
                mgr.Entity.OrderNumber = orderNumber;

                var results = mgr.BuildCollection();
                switch (mgr.Entity.Result)
                {
                    case 0:
                        return InputOutputGroupClusterPermissionValidationResult.Ok;
                    case 1:
                        return InputOutputGroupClusterPermissionValidationResult.InvalidOrderNumber;
                    case 2:
                        return InputOutputGroupClusterPermissionValidationResult.InputOutputGroupNotInCluster;
                    default:
                        return InputOutputGroupClusterPermissionValidationResult.UnknownResult;
                }
                return (InputOutputGroupClusterPermissionValidationResult)mgr.Entity.Result;
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



        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("InputOutputGroup", "InputOutputGroupUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("InputOutputGroup", "InputOutputGroupUid", id);
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

        protected override bool IsEntityUnique(InputOutputGroup entity)
        {
            var mgr = new IsInputOutputGroupUniquePDSAManager();
            mgr.Entity.InputOutputGroupUid = entity.InputOutputGroupUid;
            mgr.Entity.ClusterUid = entity.ClusterUid;
            mgr.Entity.IOGroupNumber = entity.IOGroupNumber;
            mgr.Entity.Display = entity.Display;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("InputOutputGroup", "InputOutputGroupUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("InputOutputGroup", "InputOutputGroupUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        public bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid inputOutputGroupUid, Guid permissionId, Guid entityId)
        {
            // If no permission is specified, return true to indicate that permission is granted
            if (permissionId == Guid.Empty)
                return true;

            if (!sessionData.IsPermissionCheckPossible)
                return true;

            var mgr = new InputOutputGroup_GetUserPermissionPDSAManager();
            mgr.Entity.UserId = sessionData.UserId;
            mgr.Entity.InputOutputGroupUid = inputOutputGroupUid;
            mgr.Entity.PermissionId = permissionId;
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            if (results?.Count > 0)
                return true;
            return false;
        }
        private void SetSortColumnAndOrder(IGetParametersBase getParameters, InputOutputGroupPDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<InputOutputGroupSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }

        protected override IArrayResponse<InputOutputGroup> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<InputOutputGroup> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = InputOutputGroupPDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputOutputGroupRepository::GetAllEntities", ex);
                throw;
            }
        }


        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new InputOutputGroup_GetAllUidsFromRoleIdPDSAManager();
            mgr.Entity.RoleId = roleId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.InputOutputGroupUid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndClusterUid(Guid roleId, Guid clusterUid)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new InputOutputGroup_GetAllUidsFromRoleIdAndClusterUidPDSAManager();
            mgr.Entity.RoleId = roleId;
            mgr.Entity.ClusterUid = clusterUid;
            var results = mgr.BuildCollection();
            return results.Select(o => o.InputOutputGroupUid);
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

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForGalaxyInputOutputGroupPDSAManager()
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

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertInputOutputGroupCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();

                var mgr1 = new gcsEntityCountPDSA_InsertAccessPortalGroupCountPDSAManager();
                mgr1.Entity.EntityId = entityId;
                mgr1.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }


        public IEnumerable<Guid> GetUidsForCluster(Guid clusterUid)
        {
            var mgr = new GetInputOutputGroupUidsForClusterPDSAManager()
            {
                Entity =
                {
                    uid = clusterUid
                }
            };
            var results = mgr.BuildCollection();
            var data = results.Select(o => o.InputOutputGroupUid);
            return data;
        }

    }
}
