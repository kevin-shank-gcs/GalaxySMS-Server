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
using System.Security.Cryptography;
using GalaxySMS.Common.Constants;
using AccessGroupNumber = GalaxySMS.Common.Enums.AccessGroupNumber;
using InputOutputGroupNumber = GalaxySMS.Common.Enums.InputOutputGroupNumber;
using SharedResources = GalaxySMS.Resources.Resources;
using TimeSchedule = GalaxySMS.Business.Entities.TimeSchedule;

namespace GalaxySMS.Data
{
    [Export(typeof(IMercScpGroupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MercScpGroupRepository : PagedDataRepositoryBase<MercScpGroup>, IMercScpGroupRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private IGcsBinaryResourceRepository _binaryResourceRepository;

        //[Import]
        //private IMercScpGroupEntityMapRepository _entityMapRepository;

        //[Import]
        //private IRoleMercScpGroupRepository _roleMercScpGroupRepository;

        //[Import]
        //private IMercScpGroupInputOutputGroupRepository _MercScpGroupInputOutputGroupRepository;

        [Import]
        private IGalaxyPanelRepository _galaxyPanelRepository;

        [Import]
        private IGalaxyInputOutputGroupRepository _ioGroupRepository;

        [Import]
        private IGalaxyAreaRepository _areaRepository;

        [Import]
        private IGalaxyAccessGroupRepository _accessGroupRepository;

        [Import]
        private ITimeScheduleRepository _timeScheduleRepository;

        //[Import]
        //private IGalaxyMercScpGroupTimeScheduleMapRepository _MercScpGroupTimeScheduleMapRepository;

        [Import]
        private IDayTypeRepository _dayTypeRepository;

        //[Import]
        //private IGalaxyMercScpGroupDayTypeMapRepository _MercScpGroupDayTypeMapRepository;

        //[Import]
        //private IMercScpGroupLedBehaviorModeRepository _MercScpGroupLedBehaviorModeRepository;

        //[Import]
        //private IMercScpGroupTypeRepository _MercScpGroupTypeRepository;

        //[Import]
        //private IMercScpGroupCommandRepository _MercScpGroupCommandRepository;

        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        protected override MercScpGroup AddEntity(MercScpGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.MercScpGroupUid, PermissionIds
                            .GalaxySMSDataAccessPermission
                            .SystemHardwareCanAddId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to add MercScpGroup {entity.MercScpGroupUid}");
                    }
                }

                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                //if (entity.AccessPortalTypeUid == null || entity.AccessPortalTypeUid.Value == Guid.Empty)
                //{
                //    entity.AccessPortalTypeUid = GalaxySMS.Common.Constants.AccessPortalTypeIds
                //        .AccessPortalType_StandardEntryPoint_StandardWiegand;
                //}

                var mgr = new MercScpGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.MercScpGroupUid, entity, saveParams);

                    //if (entity.TimeSchedules == null)
                    //    entity.TimeSchedules = new HashSet<TimeScheduleSelect>();
                    //else
                    //    entity.TimeSchedules = entity.TimeSchedules.ToCollection();
                    //// If ignore is specified, delete any specified in the TimeSchedules, then add the Always & Never, then clear the Ignore TimeSchedules so the standard always & never mappings are created
                    //if (saveParams.Ignore(nameof(entity.TimeSchedules)))
                    //    saveParams.IgnoreProperties.Remove(nameof(entity.TimeSchedules));

                    //if (entity.TimeSchedules.FirstOrDefault(o => o.TimeScheduleUid == TimeScheduleIds.TimeSchedule_Never) == null)
                    //{
                    //    var tsm = new TimeScheduleSelect()
                    //    {
                    //        TimeScheduleUid = TimeScheduleIds.TimeSchedule_Never,
                    //        PanelScheduleNumber = TimeScheduleLimits.Never,
                    //        Selected = true
                    //    };
                    //    tsm.MercScpGroupScheduleMap.PanelScheduleNumber = tsm.PanelScheduleNumber;
                    //    entity.TimeSchedules.Add(tsm);
                    //}
                    //if (entity.TimeSchedules.FirstOrDefault(o => o.TimeScheduleUid == TimeScheduleIds.TimeSchedule_Always) == null)
                    //{
                    //    var tsmAlways = new TimeScheduleSelect()
                    //    {
                    //        TimeScheduleUid = TimeScheduleIds.TimeSchedule_Always,
                    //        PanelScheduleNumber = TimeScheduleLimits.Always,
                    //        Selected = true
                    //    };
                    //    tsmAlways.MercScpGroupScheduleMap.PanelScheduleNumber = tsmAlways.PanelScheduleNumber;
                    //    entity.TimeSchedules.Add(tsmAlways);
                    //}


                    //SaveTimeScheduleMappings(sessionData, entity.MercScpGroupUid, entity, saveParams);
                    //SaveDayTypeMappings(sessionData, entity.MercScpGroupUid, entity, saveParams);
                    //SaveRoleMappings(sessionData, entity.MercScpGroupUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.MercScpGroupUid, sessionData, new GetParametersWithPhoto(saveParams) { IncludeMemberCollections = true, IncludePhoto = true });
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        UpdateEntityCount(result.EntityId);
                    }
                    EnsureRequiredChildRecordsExist(entity, sessionData, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::AddEntity", ex);
                throw;
            }
        }

        protected override MercScpGroup UpdateEntity(MercScpGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.MercScpGroupUid, PermissionIds
                            .GalaxySMSDataAccessPermission
                            .SystemHardwareCanUpdateId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update MercScpGroup {entity.MercScpGroupUid}");
                    }
                }

                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.MercScpGroupUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true, IncludePhoto = true });
                if (originalEntity != null && originalEntity.EntityId != entity.EntityId)
                {
                    if (!DoesUserHavePermission(sessionData, entity.MercScpGroupUid, PermissionIds.GalaxySMSDataAccessPermission
                                .SystemHardwareCanUpdateId, originalEntity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update MercScpGroup {entity.MercScpGroupUid}");
                    }
                }

                var mgr = new MercScpGroupPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.MercScpGroupUid) > 0)// must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if SiteUid is = Guid.Empty or null, then use the value from the original record
                    entity.SiteUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.SiteUid, entity.SiteUid);

                    //// if MercScpGroupTypeUid is = Guid.Empty or null, then use the value from the original record
                    //entity.MercScpGroupTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.MercScpGroupTypeUid, entity.MercScpGroupTypeUid);

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);

                    //// if CredentialDataLengthUid is = Guid.Empty or null, then use the value from the original record
                    //entity.CredentialDataLengthUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.CredentialDataLengthUid, entity.CredentialDataLengthUid);

                    //// if TimeScheduleTypeUid is = Guid.Empty or null, then use the value from the original record
                    //entity.TimeScheduleTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.TimeScheduleTypeUid, entity.TimeScheduleTypeUid);

                    //// if BinaryResourceUid is = Guid.Empty or null, then use the value from the original record
                    //entity.BinaryResourceUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.BinaryResourceUid, entity.BinaryResourceUid);

                    //// if CrisisActivateInputOutputGroupUid is = Guid.Empty or null, then use the value from the original record
                    //entity.CrisisActivateInputOutputGroupUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.CrisisActivateInputOutputGroupUid, entity.CrisisActivateInputOutputGroupUid);

                    //// if CrisisResetInputOutputGroupUid is = Guid.Empty or null, then use the value from the original record
                    //entity.CrisisResetInputOutputGroupUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.CrisisResetInputOutputGroupUid, entity.CrisisResetInputOutputGroupUid);

                    //// if AccessPortalLockedLedBehaviorModeUid is = Guid.Empty or null, then use the value from the original record
                    //entity.AccessPortalLockedLedBehaviorModeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessPortalLockedLedBehaviorModeUid, entity.AccessPortalLockedLedBehaviorModeUid);

                    //// if AccessPortalUnlockedLedBehaviorModeUid is = Guid.Empty or null, then use the value from the original record
                    //entity.AccessPortalUnlockedLedBehaviorModeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessPortalUnlockedLedBehaviorModeUid, entity.AccessPortalUnlockedLedBehaviorModeUid);

                    //// if AccessPortalTypeUid is = Guid.Empty or null, then use the value from the original record
                    //entity.AccessPortalTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessPortalTypeUid, entity.AccessPortalTypeUid);

                    //// if TemplateAccessPortalUid is = Guid.Empty or null, then use the value from the original record
                    //entity.TemplateAccessPortalUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.TemplateAccessPortalUid, entity.TemplateAccessPortalUid);

                    //if (entity.CrisisActivateInputOutputGroupUid == Guid.Empty ||
                    //    entity.CrisisResetInputOutputGroupUid == Guid.Empty)
                    //{
                    //    var ioGroups = _ioGroupRepository.GetAllGalaxyInputOutputGroupsForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid });
                    //    var none = ioGroups.Items.FirstOrDefault(g => g.IOGroupNumber == (int)InputOutputGroupNumber.None);
                    //    if (none != null)
                    //    {
                    //        if (entity.CrisisActivateInputOutputGroupUid == Guid.Empty)
                    //            entity.CrisisActivateInputOutputGroupUid = none.InputOutputGroupUid;

                    //        if (entity.CrisisResetInputOutputGroupUid == Guid.Empty)
                    //            entity.CrisisResetInputOutputGroupUid = none.InputOutputGroupUid;
                    //    }
                    //}
                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.MercScpGroupUid, entity, saveParams);
                        //SaveTimeScheduleMappings(sessionData, entity.MercScpGroupUid, entity, saveParams);
                        //SaveDayTypeMappings(sessionData, entity.MercScpGroupUid, entity, saveParams);
                        //SaveRoleMappings(sessionData, entity.MercScpGroupUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        //                        var updatedEntity = GetEntityByGuidId(entity.MercScpGroupUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true, IncludePhoto = true });
                        var updatedEntity = GetEntityByGuidId(entity.MercScpGroupUid, sessionData, new GetParametersWithPhoto(saveParams) { IncludeMemberCollections = true, IncludePhoto = true });
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureRequiredChildRecordsExist(entity, sessionData, saveParams);
                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.MercScpGroupUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(MercScpGroup entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new MercScpGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.MercScpGroupUid);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::DeleteEntity", ex);
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
                    throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to delete MercScpGroup {id}");
                }

                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, new GetParametersWithPhoto());
                var mgr = new MercScpGroupPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::Remove", ex);
                throw;
            }
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, MercScpGroupPDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<MercScpGroupSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }


        private IEnumerable<MercScpGroup> GetFilteredMercScpGroups(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters, MercScpGroupPDSAManager mgr)
        {
            IEnumerable<MercScpGroup> entities = new List<MercScpGroup>();

            SetSortColumnAndOrder(getParameters, mgr);

            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                //entities = mgr.ConvertPDSACollection(pdsaEntities);

                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a MercScpGroup, creating RoleMercScpGroup records
                //      2) When saving Role, creating RoleMercScpGroup records
                // 
                if (sessionData == null || sessionData.UserId == Guid.Empty)
                {
                    entities = mgr.ConvertPDSACollection(pdsaEntities);
                }
                else
                {
                    var filteredMercScpGroupUids = GetFilteredMercScpGroupUids(sessionData);
                    var pdsaItems = pdsaEntities.Where(p => filteredMercScpGroupUids.Any(p2 => p2.MercScpGroupUid == p.MercScpGroupUid)).ToCollection();

                    entities = mgr.ConvertPDSACollection(pdsaItems);
                }
            }
            return entities;
        }

        private EntityLayer.MercScpGroupUids_SelectForUserIdPDSACollection GetFilteredMercScpGroupUids(IApplicationUserSessionDataHeader sessionData)
        {
            var filteredMgr = new MercScpGroupUids_SelectForUserIdPDSAManager();
            filteredMgr.Entity.UserId = sessionData.UserId;
            var filteredMercScpGroupUids = filteredMgr.BuildCollection();
            return filteredMercScpGroupUids;
        }

        private IEnumerable<MercScpGroup> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, MercScpGroupPDSAManager mgr)
        {
            var entities = GetFilteredMercScpGroups(sessionData, getParameters, mgr);

            foreach (var entity in entities)
            {
                if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludePhoto || getParameters.IncludeCommands)
                    FillMemberCollections(entity, sessionData, getParameters);
            }
            return entities;
        }

        private ArrayResponse<MercScpGroup> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, MercScpGroupPDSAManager mgr)
        {
            var includeCounts = false;
            var includeCountsOption = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
            if (includeCountsOption.HasValue)
                includeCounts = includeCountsOption.Value;

            var entities = GetFilteredMercScpGroups(sessionData, getParameters, mgr);
            var totalCount = 0;
            foreach (var entity in entities)
            {
                if (totalCount == 0)
                    totalCount = entity.TotalRowCount;
                if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludePhoto || getParameters.IncludeCommands || includeCounts)
                    FillMemberCollections(entity, sessionData, getParameters);
            }
            return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
        }

        protected override IEnumerable<MercScpGroup> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new MercScpGroupPDSAManager();
                mgr.DataObject.SelectFilter = MercScpGroupPDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.Entity.EntityId = getParameters.UniqueId;
                else if (getParameters.CurrentEntityId != Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<MercScpGroup> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new MercScpGroupPDSAManager();
                mgr.DataObject.SelectFilter = MercScpGroupPDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.Entity.EntityId = getParameters.UniqueId;
                else if (getParameters.CurrentEntityId != Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<MercScpGroup> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new MercScpGroupPDSAManager();
                mgr.DataObject.SelectFilter = MercScpGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetAllEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<MercScpGroup> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new MercScpGroupPDSAManager();
                mgr.DataObject.SelectFilter = MercScpGroupPDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<MercScpGroup> GetAllMercScpGroupsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }
        public IArrayResponse<MercScpGroup> GetAllMercScpGroupsForEntityPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }

        public IEnumerable<MercScpGroup> GetAllMercScpGroupsForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new MercScpGroupPDSAManager();
                mgr.DataObject.SelectFilter = MercScpGroupPDSAData.SelectFilters.BySiteUid;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.Entity.SiteUid = getParameters.UniqueId;
                else if (getParameters.CurrentSiteUid != Guid.Empty)
                    mgr.Entity.SiteUid = getParameters.CurrentSiteUid;
                else
                    mgr.Entity.SiteUid = sessionData.CurrentSiteId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetAllMercScpGroupsForSite", ex);
                throw;
            }
        }
        public IArrayResponse<MercScpGroup> GetAllMercScpGroupsForSitePaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new MercScpGroupPDSAManager();
                mgr.DataObject.SelectFilter = MercScpGroupPDSAData.SelectFilters.BySiteUid;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.Entity.SiteUid = getParameters.UniqueId;
                else if (getParameters.CurrentSiteUid != Guid.Empty)
                    mgr.Entity.SiteUid = getParameters.CurrentSiteUid;
                else
                    mgr.Entity.SiteUid = sessionData.CurrentSiteId;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetAllMercScpGroupsForSite", ex);
                throw;
            }
        }

        public bool VerifyEntityIdMatches(Guid MercScpGroupUid, Guid entityId)
        {
            var mgr = new GetEntityIdForMercScpGroupPDSAManager
            {
                Entity =
                {
                    uid = MercScpGroupUid
                }
            };
            var results = mgr.BuildCollection();
            var result = results.FirstOrDefault();
            if (result != null)
                return result.EntityId == entityId;
            return false;
        }

        public Guid GetEntityId(Guid MercScpGroupUid)
        {
            var mgr = new GetEntityIdForMercScpGroupPDSAManager()
            {
                Entity =
                {
                    uid = MercScpGroupUid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId;
            return Guid.Empty;
        }

        //public IArrayResponse<MercScpGroupSelectionItemBasic> GetAllMercScpGroupSelectionItemsForEntityAndSite(IApplicationUserSessionDataHeader sessionData,
        //    IGetParametersWithPhoto parameters)
        //{
        //    try
        //    {
        //        var mgr = new MercScpGroup_SelectionListForEntityAndSitePDSAManager();
        //        mgr.Entity.EntityId = parameters.CurrentEntityId;
        //        mgr.Entity.SiteUid = parameters.CurrentSiteUid;
        //        mgr.Entity.PageNumber = parameters.PageNumber;
        //        mgr.Entity.PageSize = parameters.PageSize;
        //        if (!string.IsNullOrEmpty(parameters?.SortProperty))
        //        {
        //            var sortProperty = EnumExtensions.GetOne<MercScpGroupSortProperty>(parameters.SortProperty);
        //            mgr.Entity.SortColumn = sortProperty.ToString();
        //        }

        //        mgr.Entity.DescendingOrder = parameters?.DescendingOrder == true;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var totalCount = 0;
        //            var entities = new List<MercScpGroupSelectionItemBasic>();
        //            foreach (var entity in pdsaEntities)
        //            {
        //                if (totalCount == 0)
        //                    totalCount = entity.TotalRowCount;
        //                var newEntity = new MercScpGroupSelectionItemBasic();
        //                SimpleMapper.PropertyMap(entity, newEntity);
        //                if (parameters.IncludeMemberCollections || parameters.IncludePhoto)
        //                    FillMemberCollections(newEntity, sessionData, parameters);
        //                entities.Add(newEntity);
        //            }
        //            return ArrayResponseHelpers.ToArrayResponse(entities, parameters.PageNumber, parameters.PageSize, totalCount);
        //        }
        //        return new ArrayResponse<MercScpGroupSelectionItemBasic>();
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetAllMercScpGroupSelectionItemsForEntityAndSite", ex);
        //        throw;
        //    }
        //}
        //public IArrayResponse<MercScpGroupSelectionItemBasic> GetAllMercScpGroupSelectionItemsForSite(IApplicationUserSessionDataHeader sessionData,
        //    IGetParametersWithPhoto parameters)
        //{
        //    try
        //    {
        //        var mgr = new MercScpGroup_SelectionListForSitePDSAManager();
        //        mgr.Entity.SiteUid = parameters.CurrentSiteUid;
        //        mgr.Entity.PageNumber = parameters.PageNumber;
        //        mgr.Entity.PageSize = parameters.PageSize;
        //        if (!string.IsNullOrEmpty(parameters?.SortProperty))
        //        {
        //            var sortProperty = EnumExtensions.GetOne<MercScpGroupSortProperty>(parameters.SortProperty);
        //            mgr.Entity.SortColumn = sortProperty.ToString();
        //        }

        //        mgr.Entity.DescendingOrder = parameters?.DescendingOrder == true;

        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var totalCount = 0;

        //            var entities = new List<MercScpGroupSelectionItemBasic>();
        //            foreach (var entity in pdsaEntities)
        //            {
        //                if (totalCount == 0)
        //                    totalCount = entity.TotalRowCount;
        //                var newEntity = new MercScpGroupSelectionItemBasic();
        //                SimpleMapper.PropertyMap(entity, newEntity);
        //                if (parameters.IncludeMemberCollections || parameters.IncludePhoto)
        //                    FillMemberCollections(newEntity, sessionData, parameters);
        //                entities.Add(newEntity);
        //            }
        //            return ArrayResponseHelpers.ToArrayResponse(entities, parameters.PageNumber, parameters.PageSize, totalCount);
        //        }
        //        return new ArrayResponse<MercScpGroupSelectionItemBasic>();
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetAllMercScpGroupSelectionItemsForEntityAndSite", ex);
        //        throw;
        //    }
        //}

        //public IEnumerable<MercScpGroup> GetMercScpGroupsByMercScpGroupGroupId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        var mgr = new MercScpGroupPDSAManager();
        //        mgr.DataObject.SelectFilter = MercScpGroupPDSAData.SelectFilters.PrimaryKey;
        //        mgr.Entity.MercScpGroupGroupUid = getParameters.GetGuid;
        //        return GetIEnumerable(sessionData, getParameters, mgr);
        //    }
        //    catch (PDSAValidationException ex)
        //    {
        //        DataValidationException dve = Converters.ConvertToDataValidationException(ex);
        //        throw dve;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetAllMercScpGroupsForSite", ex);
        //        throw;
        //    }
        //}

        //public MercScpGroup GetByHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        var mgr = new MercScpGroupPDSAManager();
        //        mgr.DataObject.SelectFilter = MercScpGroupPDSAData.SelectFilters.ByMercScpGroupGroupIdAndNumber;
        //        mgr.Entity.MercScpGroupGroupId = getParameters.MercScpGroupGroupId;
        //        mgr.Entity.MercScpGroupNumber = getParameters.MercScpGroupNumber;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null && pdsaEntities.Count > 0)
        //        {
        //            MercScpGroup result = new MercScpGroup();
        //            SimpleMapper.PropertyMap(pdsaEntities[0], result);
        //            if (getParameters.IncludeMemberCollections || getParameters.IncludePhoto)
        //                FillMemberCollections(result, sessionData, getParameters);
        //            return result;
        //        }
        //        return null;

        //        var results = GetIEnumerable(sessionData, getParameters, mgr);
        //        return results.FirstOrDefault();
        //    }
        //    catch (PDSAValidationException ex)
        //    {
        //        DataValidationException dve = Converters.ConvertToDataValidationException(ex);
        //        throw dve;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetAllMercScpGroupsForSite", ex);
        //        throw;
        //    }

        //}

        protected override MercScpGroup GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override MercScpGroup GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new MercScpGroupPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    if (!getParameters.DoNotValidateAuthorization)
                    {
                        if (!DoesUserHavePermission(sessionData, mgr.Entity.MercScpGroupUid, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId, mgr.Entity.EntityId))
                        {
                            throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to view MercScpGroup {mgr.Entity.Name}");
                        }
                    }

                    MercScpGroup result = new MercScpGroup();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludePhoto)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        //public MercScpGroup_CommonPanelLoadData GetCommonPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        //{
        //    try
        //    {
        //        var mgr = new MercScpGroup_GetPanelCommonLoadDataPDSAManager();
        //        mgr.Entity.MercScpGroupUid = getParameters.UniqueId;
        //        mgr.Entity.MercScpGroupGroupId = getParameters.MercScpGroupGroupId;
        //        mgr.Entity.MercScpGroupNumber = getParameters.MercScpGroupNumber;
        //        var result = mgr.BuildCollection();
        //        if (result != null && result.Count == 1)
        //            return mgr.ConvertPDSAEntity(result[0]);
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetCommonPanelLoadData", ex);
        //        throw;
        //    }
        //}

        //public MercScpGroup_GetHardwareAddress GetMercScpGroupHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        //{
        //    try
        //    {
        //        var mgr = new MercScpGroup_GetHardwareAddressPDSAManager();
        //        mgr.Entity.MercScpGroupUid = parameters.UniqueId;
        //        var result = mgr.BuildCollection();
        //        if (result != null && result.Count == 1)
        //            return mgr.ConvertPDSAEntity(result[0]);
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::GetMercScpGroupHardwareAddress", ex);
        //        throw;
        //    }
        //}


        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, MercScpGroup originalEntity, MercScpGroup newEntity, string auditXml)
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
                        propertiesToIgnore.Add(nameof(MercScpGroup.UpdateDate));
                        propertiesToIgnore.Add(nameof(MercScpGroup.UpdateName));
                        propertiesToIgnore.Add(nameof(MercScpGroup.ConcurrencyValue));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.MercScpGroupType));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.EntityIds));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.MappedEntitiesPermissionLevels));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.TimeSchedules));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.DayTypes));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.InputOutputGroups));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.AccessGroups));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.Areas));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.MercScpGroupEntityMaps));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.MercScpGroupInputOutputGroups));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.GalaxyPanels));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.MercScpGroupCommands));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.MercScpGroupFlashingCommands));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.DisabledCommandIds));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.RoleIds));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.ScheduleIds));
                        //propertiesToIgnore.Add(nameof(MercScpGroup.MappedSchedules));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "MercScpGroupUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.MercScpGroupUid;
                        mgr.Entity.RecordTag = newEntity.MercScpGroupUid.ToString();
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
                                mgr.Entity.NewValue = property.Value.NewValue?.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "MercScpGroupUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.MercScpGroupUid;
                        mgr.Entity.RecordTag = newEntity.MercScpGroupUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "MercScpGroupUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.MercScpGroupUid;
                        mgr.Entity.RecordTag = originalEntity.MercScpGroupUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//MercScpGroupRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(MercScpGroup entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (getParameters == null)
            //    return;

            //var includeCounts = false;
            //var includeCountsOption = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
            //if (includeCountsOption.HasValue)
            //    includeCounts = includeCountsOption.Value;

            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty && getParameters.IncludePhoto)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, getParameters);
            //}

            //if (getParameters.IncludeMemberCollections)
            //{
            //    if (!getParameters.IsExcluded(nameof(entity.EntityIds)))
            //    {
            //        var entityMaps = _entityMapRepository.GetAllMercScpGroupEntityMapsForMercScpGroup(sessionData,
            //            new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid });
            //        var entityIds = (from e in entityMaps select e.EntityId).ToList();
            //        entity.EntityIds.AddRange(entityIds);

            //        entity.EntityIds.Add(entity.EntityId);
            //    }

            //    if (!getParameters.IsExcluded(nameof(entity.RoleIds)))
            //    {
            //        var roleFilters = _roleMercScpGroupRepository.GetAllForMercScpGroupUid(sessionData,
            //            new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid });
            //        var roleIds = (from e in roleFilters select e.RoleId).ToList();
            //        entity.RoleIds.AddRange(roleIds);
            //    }

            //    if (!getParameters.IsExcluded(nameof(entity.InputOutputGroups)))
            //    {
            //        var includeAssignments = getParameters.GetOption(nameof(InputOutputGroupAssignment));

            //        bool bIncludeMemberCollections = false;
            //        if (includeAssignments.HasValue)
            //            bIncludeMemberCollections = includeAssignments.Value;

            //        entity.InputOutputGroups = _ioGroupRepository.GetAllGalaxyInputOutputGroupsForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid, IncludeMemberCollections = bIncludeMemberCollections }).Items.ToCollection();
            //    }

            //    if (!getParameters.IsExcluded(nameof(entity.Areas)))
            //        entity.Areas = _areaRepository.GetAllGalaxyAreasForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid }).Items.ToCollection();

            //    if (!getParameters.IsExcluded(nameof(entity.AccessGroups)))
            //        entity.AccessGroups = _accessGroupRepository.GetAllGalaxyAccessGroupsForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid }).Items.ToCollection();

            //    if (!getParameters.IsExcluded(nameof(entity.MercScpGroupInputOutputGroups)))
            //        entity.MercScpGroupInputOutputGroups = _MercScpGroupInputOutputGroupRepository.GetMercScpGroupInputOutputGroupsByMercScpGroupUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid }).ToCollection();


            //    if (!getParameters.IsExcluded(nameof(entity.TimeSchedules)) ||
            //        !getParameters.IsExcluded(nameof(entity.ScheduleIds)) ||
            //        !getParameters.IsExcluded(nameof(entity.MappedSchedules)))
            //    {
            //        // Get all the GalaxyMercScpGroupTimeScheduleMap records for this MercScpGroup and build the TimeSchedules collection
            //        var galaxyMercScpGroupTimeScheduleMaps = _MercScpGroupTimeScheduleMapRepository.GetAllGalaxyMercScpGroupTimeScheduleMapForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid }).ToCollection();
            //        if (!getParameters.IsExcluded(nameof(entity.ScheduleIds)))
            //            entity.ScheduleIds.AddRange(galaxyMercScpGroupTimeScheduleMaps.Select(o => o.TimeScheduleUid));

            //        if (!getParameters.IsExcluded(nameof(entity.MappedSchedules)))
            //        {
            //            foreach (var tsm in galaxyMercScpGroupTimeScheduleMaps)
            //            {
            //                entity.MappedSchedules.Add(new MercScpGroupTimeScheduleItem()
            //                {
            //                    Id = tsm.TimeScheduleUid,
            //                    Name = tsm.TimeScheduleName,
            //                    Number = tsm.PanelScheduleNumber
            //                });
            //            }
            //        }

            //        if (!getParameters.IsExcluded(nameof(entity.TimeSchedules)))
            //        {
            //            var ts = _timeScheduleRepository.GetAllTimeSchedulesForMappedEntity(sessionData,
            //                new GetParametersWithPhoto() { UniqueId = entity.EntityId });
            //            foreach (var s in ts.Items)
            //            {
            //                var tss = new TimeScheduleSelect(s);
            //                var temp = galaxyMercScpGroupTimeScheduleMaps.FirstOrDefault(i =>
            //                    i.TimeScheduleUid == s.TimeScheduleUid);
            //                if (temp != null)
            //                {
            //                    tss.Selected = true;
            //                    tss.MercScpGroupScheduleMap = temp;
            //                }

            //                //tss.Selected = galaxyMercScpGroupTimeScheduleMaps.Select(i => i.TimeScheduleUid == s.TimeScheduleUid).FirstOrDefault();
            //                //if (tss.Selected)
            //                //    tss.MercScpGroupScheduleMap = 
            //                entity.TimeSchedules.Add(tss);
            //            }
            //        }
            //    }

            //    if (!getParameters.IsExcluded(nameof(entity.DayTypes)))
            //    {
            //        // Get all the GalaxyMercScpGroupTimeScheduleMap records for this MercScpGroup and build the TimeSchedules collection
            //        var galaxyMercScpGroupDayTypeMaps = _MercScpGroupDayTypeMapRepository.GetAllGalaxyMercScpGroupDayTypeMapForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid }).ToCollection();

            //        var dt = _dayTypeRepository.GetAllDayTypesForMappedEntity(sessionData, new GetParametersWithPhoto() { UniqueId = entity.EntityId });
            //        foreach (var t in dt.Items)
            //        {
            //            var dtss = new DayTypeSelect(t);
            //            var temp = galaxyMercScpGroupDayTypeMaps.FirstOrDefault(i => i.DayTypeUid == t.DayTypeUid);
            //            if (temp != null)
            //            {
            //                dtss.Selected = true;
            //                dtss.MercScpGroupDayTypeMap = temp;
            //            }
            //            //tss.Selected = galaxyMercScpGroupTimeScheduleMaps.Select(i => i.TimeScheduleUid == s.TimeScheduleUid).FirstOrDefault();
            //            //if (tss.Selected)
            //            //    tss.MercScpGroupScheduleMap = 
            //            entity.DayTypes.Add(dtss);
            //        }
            //    }

            //    if (!getParameters.IsExcluded(nameof(entity.GalaxyPanels)))
            //    {
            //        var getPanelParams = new GetParametersWithPhoto(getParameters);
            //        getPanelParams.UniqueId = entity.MercScpGroupUid;
            //        entity.GalaxyPanels = _galaxyPanelRepository.GetAllGalaxyPanelsForMercScpGroup(sessionData, getPanelParams).Items.ToCollection();
            //    }

            //    if (entity.MercScpGroupTypeUid != Guid.Empty && !getParameters.IsExcluded(nameof(entity.MercScpGroupType)))
            //        entity.MercScpGroupType = _MercScpGroupTypeRepository.Get(entity.MercScpGroupTypeUid, sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupTypeUid });

            //    if (!getParameters.IsExcluded(nameof(entity.MercScpGroupCommands)))
            //        entity.MercScpGroupCommands = _MercScpGroupCommandRepository.GetAllMercScpGroupCommandsForMercScpGroupType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupTypeUid }).ToCollection();

            //    if (!getParameters.IsExcluded(nameof(entity.MercScpGroupFlashingCommands)))
            //        entity.MercScpGroupFlashingCommands = _MercScpGroupCommandRepository.GetAllMercScpGroupFlashingCommandsForMercScpGroupType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupTypeUid }).ToCollection();
            //}

            //if (getParameters.IncludeCommands)
            //{
            //    //if (!getParameters.IsExcluded(nameof(entity.MercScpGroupCommands)) && !entity.MercScpGroupCommands.Any())
            //    //    entity.MercScpGroupCommands = _MercScpGroupCommandRepository.GetAllMercScpGroupCommandsForMercScpGroupType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupTypeUid }).ToCollection();

            //    //if (!getParameters.IsExcluded(nameof(entity.MercScpGroupFlashingCommands)) && !entity.MercScpGroupFlashingCommands.Any())
            //    //    entity.MercScpGroupFlashingCommands = _MercScpGroupCommandRepository.GetAllMercScpGroupFlashingCommandsForMercScpGroupType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupTypeUid }).ToCollection();
            //    var getP = new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupTypeUid, IncludePhoto = false };
            //    var cmds = _MercScpGroupCommandRepository.GetAllMercScpGroupCommandsForMercScpGroupType(sessionData, getP).ToCollection();
            //    var flashingCommands = _MercScpGroupCommandRepository
            //        .GetAllMercScpGroupFlashingCommandsForMercScpGroupType(sessionData, getP).ToCollection();

            //    cmds.AddRange(flashingCommands);
            //    // Check role permissions and access portal filters here
            //    var filterMgr = new MercScpGroupFilters_SelectForUserIdPDSAManager();
            //    filterMgr.Entity.MercScpGroupUid = entity.MercScpGroupUid;
            //    filterMgr.Entity.UserId = sessionData.UserId;
            //    var filters = filterMgr.BuildCollection();

            //    var deleteTheseCommands = new List<MercScpGroupCommand>();
            //    foreach (var cmd in cmds)
            //    {
            //        var permissionUid = Guid.Empty;
            //        if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_ActivateCrisisMode)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.ActivateCrisisMode;
            //        }
            //        else if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_ResetCrisisMode)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.ResetCrisisMode;
            //        }
            //        else if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_ClearLoggingBuffer)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.ClearLogBuffer;
            //        }
            //        else if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_DeleteAllCredentials)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.DeleteAllCards;
            //        }
            //        else if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_DisableCredential)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.DisableCredential;
            //        }
            //        else if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_EnableCredential)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.EnableCredential;
            //        }
            //        else if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_ForgiveAllPassback)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.ForgiveAllPassback;
            //        }
            //        else if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_ForgivePassback)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.ForgivePassback;
            //        }
            //        else if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_ResetControllerCold)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.ResetPanelCold;
            //        }
            //        else if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_ResetControllerWarm)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.ResetPanelWarm;
            //        }
            //        else if (cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_BeginFlashLoad ||
            //                 cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_ValidateAndBurnFlash ||
            //                 cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_ValidateFlash ||
            //                 cmd.MercScpGroupCommandUid == GalaxySMS.Common.Constants.GalaxyMercScpGroupCommandIds.GalaxyMercScpGroupCommand_EnableDaughterBoardFlashUpdate)
            //        {
            //            permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSMercScpGroupCommandPermission.LoadPanelFlash;
            //        }

            //        if (permissionUid != Guid.Empty)
            //        {
            //            var filter = filters.FirstOrDefault(o => o.PermissionId == permissionUid);
            //            if (filter == null)
            //                deleteTheseCommands.Add(cmd);
            //        }
            //    }

            //    foreach (var cmd in deleteTheseCommands)
            //    {
            //        entity.DisabledCommandIds.Add(cmd.MercScpGroupCommandUid);
            //        cmds.Remove(cmd);
            //    }

            //    entity.MercScpGroupCommands = cmds.Where(o => o.IsFlashingCommand == false).ToCollection();
            //    entity.MercScpGroupFlashingCommands = cmds.Where(o => o.IsFlashingCommand == true).ToCollection();

            //}

            //if (includeCounts)
            //{
            //    entity.Counts = GetMercScpGroupCounts(entity.MercScpGroupUid);
            //}
        }

        //private MercScpGroupCounts GetMercScpGroupCounts(Guid MercScpGroupUid)
        //{
        //    try
        //    {
        //        var mgr = new MercScpGroup_GetCountsPDSAManager();
        //        mgr.Entity.MercScpGroupUid = MercScpGroupUid;
        //        var results = mgr.BuildCollection();
        //        if (results?.Count > 0)
        //        {
        //            var r = results[0];
        //            var MercScpGroupCounts = new MercScpGroupCounts()
        //            {
        //                PanelsCount = r.PanelsCount,
        //                BoardsCount = r.BoardsCount,
        //                AccessPortalsCount = r.AccessPortalsCount,
        //                InputDevicesCount = r.InputDevicesCount,
        //                OutputDevicesCount = r.OutputDevicesCount
        //            };
        //            return MercScpGroupCounts;
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
        //        throw;
        //    }
        //}

        //protected void FillMemberCollections(MercScpGroupSelectionItemBasic entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        //{
        //    if (getParameters == null)
        //        return;

        //    if (entity.Photo != null && entity.Photo.Length > 0 && getParameters.IncludePhoto && getParameters.PhotoPixelWidth > 0)
        //    {
        //        var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
        //            GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.Photo), getParameters.PhotoPixelWidth);
        //        entity.Photo = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
        //    }

        //    if (getParameters.IncludeMemberCollections)
        //    {
        //        getParameters.MercScpGroupUid = entity.MercScpGroupUid;
        //        if (!getParameters.IsExcluded(nameof(entity.AccessGroups)))
        //        {
        //            var accessGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyAccessGroupRepository>();
        //            entity.AccessGroups = accessGroupRepository.GetAllAccessGroupSelectionItemsForEntityAndMercScpGroup(sessionData, getParameters).ToCollection();
        //        }

        //        if (!getParameters.IsExcluded(nameof(entity.InputOutputGroups)))
        //        {
        //            var inputOutputGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();
        //            entity.InputOutputGroups = inputOutputGroupRepository.GetAllInputOutputGroupSelectionItemsForEntityAndMercScpGroup(sessionData, getParameters).ToCollection();
        //        }

        //        if (!getParameters.IsExcluded(nameof(entity.AccessPortals)))
        //        {
        //            var accessPortalRepository = _dataRepositoryFactory.GetDataRepository<IAccessPortalRepository>();
        //            entity.AccessPortals = accessPortalRepository.GetAllAccessPortalSelectionItemsForEntityAndMercScpGroup(sessionData, getParameters).ToCollection();
        //        }

        //        if (!getParameters.IsExcluded(nameof(entity.TimeSchedules)))
        //        {
        //            var timeScheduleRepository = _dataRepositoryFactory.GetDataRepository<ITimeScheduleRepository>();
        //            entity.TimeSchedules = timeScheduleRepository.GetAllTimeScheduleSelectionItemsForEntityAndMercScpGroup(sessionData, getParameters).ToCollection();
        //        }

        //        if (!getParameters.IsExcluded(nameof(entity.InputDevices)))
        //        {
        //            var inputDeviceRepository = _dataRepositoryFactory.GetDataRepository<IInputDeviceRepository>();
        //            entity.InputDevices = inputDeviceRepository.GetAllInputDeviceSelectionItemsForEntityAndMercScpGroup(sessionData, getParameters).ToCollection();
        //        }

        //        if (!getParameters.IsExcluded(nameof(entity.OutputDevices)))
        //        {
        //            var outputDeviceRepository = _dataRepositoryFactory.GetDataRepository<IOutputDeviceRepository>();
        //            entity.OutputDevices = outputDeviceRepository.GetAllOutputDeviceSelectionItemsForEntityAndMercScpGroup(sessionData, getParameters).ToCollection();
        //        }
        //    }
        //}

        //private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        //{
        //    if (entity.EntityIds == null || !entity.EntityIds.Any() || saveParams.Ignore(nameof(entity.EntityIds)))
        //        return;

        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingEntityMappings = _entityMapRepository.GetAllMercScpGroupEntityMapsForMercScpGroup(sessionData, getParameters);
        //    var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
        //    var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

        //    foreach (var existingEntityId in existingEntityIds)
        //    {
        //        if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
        //        {
        //            var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
        //            if (deleteThisExistingEntityMap != null)
        //                _entityMapRepository.Remove(deleteThisExistingEntityMap.MercScpGroupEntityMapUid, sessionData);
        //        }
        //    }
        //    foreach (var entityId in entity.EntityIds)
        //    {
        //        if (!existingEntityIds.Contains(entityId))
        //        {
        //            var entityMap = new MercScpGroupEntityMap();
        //            entityMap.MercScpGroupEntityMapUid = GuidUtilities.GenerateComb();
        //            entityMap.MercScpGroupUid = uid;
        //            entityMap.EntityId = entityId;
        //            UpdateTableEntityBaseProperties(entityMap, sessionData);
        //            //entityMap.UpdateDate = DateTimeOffset.Now;
        //            //entityMap.UpdateName = sessionData.UserName;
        //            //entityMap.InsertDate = DateTimeOffset.Now;
        //            //entityMap.InsertName = sessionData.UserName;

        //            _entityMapRepository.Add(entityMap, sessionData, saveParams);
        //        }
        //    }
        //}

        //private void SaveTimeScheduleMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, MercScpGroup entity, ISaveParameters saveParams)
        //{
        //    if (entity.TimeSchedules == null || !entity.TimeSchedules.Any() || saveParams.Ignore(nameof(entity.TimeSchedules)))
        //        return;

        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingScheduleMappings = _MercScpGroupTimeScheduleMapRepository.GetAllGalaxyMercScpGroupTimeScheduleMapForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid }).ToCollection();
        //    var existingScheduleUids = new HashSet<Guid>(existingScheduleMappings.Select(e => e.TimeScheduleUid));
        //    var currentScheduleMappingUids = new HashSet<Guid>(entity.TimeSchedules.Where(e => e.Selected == true).Select(e => e.TimeScheduleUid));

        //    // Delete any existing Schedule mappings that are no longer mapped
        //    foreach (var existingScheduleUid in existingScheduleUids)
        //    {
        //        if (existingScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never ||
        //            existingScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
        //            continue;

        //        if (!currentScheduleMappingUids.Contains(existingScheduleUid))
        //        {
        //            var deleteThisExistingScheduleMap = (from esm in existingScheduleMappings where esm.TimeScheduleUid == existingScheduleUid select esm).FirstOrDefault();
        //            if (deleteThisExistingScheduleMap != null)
        //                _MercScpGroupTimeScheduleMapRepository.Remove(deleteThisExistingScheduleMap.GalaxyMercScpGroupTimeScheduleMapUid, sessionData);
        //        }
        //    }

        //    // Now add any mappings that are not already defined
        //    foreach (var ts in entity.TimeSchedules)
        //    {
        //        if (!existingScheduleUids.Contains(ts.TimeScheduleUid))
        //        {
        //            ts.MercScpGroupScheduleMap.GalaxyMercScpGroupTimeScheduleMapUid = GuidUtilities.GenerateComb();
        //            ts.MercScpGroupScheduleMap.MercScpGroupUid = uid;
        //            ts.MercScpGroupScheduleMap.TimeScheduleUid = ts.TimeScheduleUid;
        //            if (ts.TimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never &&
        //                ts.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Always)
        //            {
        //                if (ts.MercScpGroupScheduleMap.PanelScheduleNumber <
        //                    GalaxySMS.Common.Constants.TimeScheduleLimits.LowestDefinableNumber ||
        //                    ts.MercScpGroupScheduleMap.PanelScheduleNumber >
        //                    GalaxySMS.Common.Constants.TimeScheduleLimits.HighestDefinableNumber)
        //                {
        //                    var definedScheduleNumbers = existingScheduleMappings.Select(i => i.PanelScheduleNumber);
        //                    var availableNumbers = Enumerable
        //                        .Range(GalaxySMS.Common.Constants.TimeScheduleLimits.LowestDefinableNumber,
        //                            GalaxySMS.Common.Constants.TimeScheduleLimits.HighestDefinableNumber)
        //                        .Except(definedScheduleNumbers);
        //                    if (!availableNumbers.Any())
        //                    {
        //                        throw new ArgumentOutOfRangeException("PanelScheduleNumber",
        //                            $"Unable to allocate a internal number for the time schedule '{ts.Display}' because there are already {definedScheduleNumbers.Count()} schedules mapped to this MercScpGroup.");
        //                    }

        //                    ts.MercScpGroupScheduleMap.PanelScheduleNumber = availableNumbers.FirstOrDefault();
        //                }
        //            }

        //            UpdateTableEntityBaseProperties(ts.MercScpGroupScheduleMap, sessionData);

        //            var savedItem = _MercScpGroupTimeScheduleMapRepository.Add(ts.MercScpGroupScheduleMap, sessionData, saveParams);
        //            existingScheduleMappings.Add(savedItem);
        //        }
        //        else if (ts.MercScpGroupScheduleMap.IsDirty)
        //        {
        //            ts.UpdateDate = DateTimeOffset.Now;
        //            ts.UpdateName = sessionData.UserName;
        //            var savedItem = _MercScpGroupTimeScheduleMapRepository.Update(ts.MercScpGroupScheduleMap, sessionData, saveParams);

        //        }
        //    }
        //}

        //private void SaveDayTypeMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, MercScpGroup entity, ISaveParameters saveParams)
        //{
        //    if (entity.DayTypes == null || !entity.DayTypes.Any() || saveParams.Ignore(nameof(entity.DayTypes)))
        //        return;

        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingDayTypeMappings = _MercScpGroupDayTypeMapRepository.GetAllGalaxyMercScpGroupDayTypeMapForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid }).ToCollection();
        //    var existingDayTypeUids = new HashSet<Guid>(existingDayTypeMappings.Select(e => e.DayTypeUid));
        //    var currentDayTypeMappingUids = new HashSet<Guid>(entity.DayTypes.Where(e => e.Selected == true).Select(e => e.DayTypeUid));

        //    // Delete any existing Day type mappings that are no longer mapped
        //    foreach (var existingDayTypeid in existingDayTypeUids)
        //    {
        //        //if (existingDayTypeid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never ||
        //        //    existingDayTypeid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
        //        //    continue;

        //        if (!currentDayTypeMappingUids.Contains(existingDayTypeid))
        //        {
        //            var deleteThisExistingDayTypeMap = (from esm in existingDayTypeMappings where esm.DayTypeUid == existingDayTypeid select esm).FirstOrDefault();
        //            if (deleteThisExistingDayTypeMap != null)
        //                _MercScpGroupDayTypeMapRepository.Remove(deleteThisExistingDayTypeMap.GalaxyMercScpGroupDayTypeMapUid, sessionData);
        //        }
        //    }

        //    var newMappedDayTypeUids = currentDayTypeMappingUids.Where(p => !existingDayTypeUids.Any(p2 => p2 == p)).ToList();
        //    var newMappedDayTypes = entity.DayTypes.Where(p => newMappedDayTypeUids.Any(p2 => p2 == p.DayTypeUid)).ToList();
        //    // Delete any existing Day type mappings that are no longer mapped
        //    foreach (var dt in newMappedDayTypes)
        //    {
        //        dt.MercScpGroupDayTypeMap.GalaxyMercScpGroupDayTypeMapUid = GuidUtilities.GenerateComb();
        //        dt.MercScpGroupDayTypeMap.MercScpGroupUid = uid;
        //        dt.MercScpGroupDayTypeMap.DayTypeUid = dt.DayTypeUid;
        //        if (dt.MercScpGroupDayTypeMap.PanelDayTypeNumber < GalaxySMS.Common.Constants.DayTypeLimits.LowestDefinableNumber ||
        //            dt.MercScpGroupDayTypeMap.PanelDayTypeNumber > GalaxySMS.Common.Constants.DayTypeLimits.HighestDefinableNumber)
        //        {
        //            var definedDayTypeNumbers = existingDayTypeMappings.Select(i => i.PanelDayTypeNumber);
        //            var availableNumbers = Enumerable.Range(GalaxySMS.Common.Constants.DayTypeLimits.LowestDefinableNumber, GalaxySMS.Common.Constants.DayTypeLimits.HighestDefinableNumber).Except(definedDayTypeNumbers);
        //            if (availableNumbers.Count() == 0)
        //            {
        //                throw new ArgumentOutOfRangeException("PanelDayTypeNumber", string.Format("Unable to allocate a internal number for the day type '{0}' because there are already {1} day types mapped to this MercScpGroup.",
        //                    dt.Name, definedDayTypeNumbers.Count()));
        //            }
        //            dt.MercScpGroupDayTypeMap.PanelDayTypeNumber = availableNumbers.FirstOrDefault();
        //        }

        //        UpdateTableEntityBaseProperties(dt.MercScpGroupDayTypeMap, sessionData);

        //        var savedItem = _MercScpGroupDayTypeMapRepository.Add(dt.MercScpGroupDayTypeMap, sessionData, saveParams);
        //        existingDayTypeMappings.Add(savedItem);
        //    }


        //    //foreach (var dt in entity.DayTypes)
        //    //{
        //    //    if (!existingDayTypeUids.Contains(dt.DayTypeUid))
        //    //    {
        //    //        dt.MercScpGroupDayTypeMap.GalaxyMercScpGroupDayTypeMapUid = GuidUtilities.GenerateComb();
        //    //        dt.MercScpGroupDayTypeMap.MercScpGroupUid = uid;
        //    //        dt.MercScpGroupDayTypeMap.DayTypeUid = dt.DayTypeUid;    
        //    //        if (dt.MercScpGroupDayTypeMap.PanelDayTypeNumber < GalaxySMS.Common.Constants.DayTypeLimits.LowestDefinableNumber ||
        //    //            dt.MercScpGroupDayTypeMap.PanelDayTypeNumber > GalaxySMS.Common.Constants.DayTypeLimits.HighestDefinableNumber)
        //    //        {
        //    //            var definedDayTypeNumbers = existingDayTypeMappings.Select(i => i.PanelDayTypeNumber);
        //    //            var availableNumbers = Enumerable.Range(GalaxySMS.Common.Constants.DayTypeLimits.LowestDefinableNumber, GalaxySMS.Common.Constants.DayTypeLimits.HighestDefinableNumber).Except(definedDayTypeNumbers);
        //    //            if (availableNumbers.Count() == 0)
        //    //            {
        //    //                throw new ArgumentOutOfRangeException("PanelDayTypeNumber", string.Format("Unable to allocate a internal number for the day type '{0}' because there are already {1} day types mapped to this MercScpGroup.",
        //    //                    dt.Name, definedDayTypeNumbers.Count()));
        //    //            }
        //    //            dt.MercScpGroupDayTypeMap.PanelDayTypeNumber = availableNumbers.FirstOrDefault();
        //    //        }

        //    //        UpdateTableEntityBaseProperties(dt.MercScpGroupDayTypeMap, sessionData);

        //    //        var savedItem = _MercScpGroupDayTypeMapRepository.Add(dt.MercScpGroupDayTypeMap, sessionData, null);
        //    //        existingDayTypeMappings.Add(savedItem);
        //    //    }
        //    //}
        //}

        //private void SaveRoleMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasRoleMappingList entity, ISaveParameters saveParams)
        //{
        //    if (entity.RoleIds == null || !entity.RoleIds.Any() || saveParams.Ignore(nameof(entity.RoleIds)))
        //        return;

        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid, RefreshCache = true };
        //    var existingRoleMercScpGroups = _roleMercScpGroupRepository.GetAllForMercScpGroupUid(sessionData, getParameters);
        //    var existingRoleIds = new HashSet<Guid>(existingRoleMercScpGroups.Select(e => e.RoleId));
        //    var deleteRoleIds = existingRoleIds.Except(entity.RoleIds);

        //    foreach (var rid in deleteRoleIds)
        //    {
        //        var rc = existingRoleMercScpGroups.FirstOrDefault(o => o.RoleId == rid);
        //        if (rc != null)
        //            _roleMercScpGroupRepository.Remove(rc.RoleMercScpGroupUid, sessionData);
        //    }

        //    foreach (var roleId in entity.RoleIds)
        //    {
        //        if (!existingRoleIds.Contains(roleId))
        //        {
        //            var roleMercScpGroup = new RoleMercScpGroup
        //            {
        //                RoleMercScpGroupUid = GuidUtilities.GenerateComb(),
        //                MercScpGroupUid = uid,
        //                RoleId = roleId,
        //                IncludeAllAccessPortals = true,
        //                IncludeAllInputDevices = true,
        //                IncludeAllOutputDevices = true,
        //                IncludeAllInputOutputGroups = true
        //            };
        //            UpdateTableEntityBaseProperties(roleMercScpGroup, sessionData);

        //            _roleMercScpGroupRepository.Add(roleMercScpGroup, sessionData, saveParams);
        //        }
        //        else if (existingRoleMercScpGroups.FirstOrDefault(o => o.RoleId == roleId && o.MercScpGroupUid == uid) == null)
        //        {
        //            var roleMercScpGroup = new RoleMercScpGroup
        //            {
        //                RoleMercScpGroupUid = GuidUtilities.GenerateComb(),
        //                MercScpGroupUid = uid,
        //                RoleId = roleId,
        //                IncludeAllAccessPortals = true,
        //                IncludeAllInputDevices = true,
        //                IncludeAllOutputDevices = true,
        //                IncludeAllInputOutputGroups = true
        //            };
        //            UpdateTableEntityBaseProperties(roleMercScpGroup, sessionData);

        //            _roleMercScpGroupRepository.Add(roleMercScpGroup, sessionData, saveParams);
        //        }
        //    }
        //}

        // Guarantee that required child records exist and create them if necessary
        private void EnsureRequiredChildRecordsExist(MercScpGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //// I/O Groups
            //var ioGroups = _ioGroupRepository.GetAllGalaxyInputOutputGroupsForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid });
            //var none = ioGroups.Items.FirstOrDefault(g => g.IOGroupNumber == (int)InputOutputGroupNumber.None);
            //if (none == null)
            //{
            //    none = new InputOutputGroup();
            //    none.InputOutputGroupUid = GuidUtilities.GenerateComb();
            //    none.MercScpGroupUid = entity.MercScpGroupUid;
            //    none.EntityId = entity.EntityId;
            //    none.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
            //    none.IOGroupNumber = (int)GalaxySMS.Common.Enums.InputOutputGroupNumber.None;
            //    none.LocalIOGroup = false;
            //    none.Display = SharedResources.InputOutputGroupName_None;
            //    none.Description = SharedResources.InputOutputGroupName_None_Description;
            //    none.UniqueResourceName = none.Display;
            //    UpdateTableEntityBaseProperties(none, sessionData);
            //    none.RoleIds = entity.RoleIds;

            //    _ioGroupRepository.Add(none, sessionData, saveParams);

            //}

            //// Areas
            //var areas = _areaRepository.GetAllGalaxyAreasForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid });
            //var nocchange = areas.Items.FirstOrDefault(g => g.AreaNumber == (int)AreaNumber.NoChange);
            //if (nocchange == null)
            //{
            //    nocchange = new Area
            //    {
            //        AreaUid = GuidUtilities.GenerateComb(),
            //        MercScpGroupUid = entity.MercScpGroupUid,
            //        EntityId = entity.EntityId,
            //        AreaNumber = (int)GalaxySMS.Common.Enums.AreaNumber.NoChange,
            //        Display = SharedResources.AreaName_NoChange,
            //        Description = SharedResources.AreaName_NoChange_Description
            //    };
            //    nocchange.UniqueResourceName = nocchange.Display;
            //    UpdateTableEntityBaseProperties(nocchange, sessionData);

            //    _areaRepository.Add(nocchange, sessionData, saveParams);
            //}

            //var inArea = areas.Items.FirstOrDefault(g => g.AreaNumber == (int)AreaNumber.In);
            //if (inArea == null)
            //{
            //    inArea = new Area
            //    {
            //        AreaUid = GuidUtilities.GenerateComb(),
            //        MercScpGroupUid = entity.MercScpGroupUid,
            //        EntityId = entity.EntityId,
            //        AreaNumber = (int)GalaxySMS.Common.Enums.AreaNumber.In,
            //        Display = SharedResources.AreaName_In,
            //        Description = SharedResources.AreaName_In_Description
            //    };
            //    inArea.UniqueResourceName = inArea.Display;
            //    UpdateTableEntityBaseProperties(inArea, sessionData);

            //    _areaRepository.Add(inArea, sessionData, saveParams);
            //}

            //var outArea = areas.Items.FirstOrDefault(g => g.AreaNumber == (int)AreaNumber.Out);
            //if (outArea == null)
            //{
            //    outArea = new Area
            //    {
            //        AreaUid = GuidUtilities.GenerateComb(),
            //        MercScpGroupUid = entity.MercScpGroupUid,
            //        EntityId = entity.EntityId,
            //        AreaNumber = (int)GalaxySMS.Common.Enums.AreaNumber.Out,
            //        Display = SharedResources.AreaName_Out,
            //        Description = SharedResources.AreaName_Out_Description
            //    };
            //    outArea.UniqueResourceName = outArea.Display;
            //    UpdateTableEntityBaseProperties(outArea, sessionData);

            //    _areaRepository.Add(outArea, sessionData, saveParams);
            //}


            //// Access Groups
            //var accessGroups = _accessGroupRepository.GetAllGalaxyAccessGroupsForMercScpGroup(sessionData, new GetParametersWithPhoto() { UniqueId = entity.MercScpGroupUid });
            //var noaccess = accessGroups.Items.FirstOrDefault(g => g.AccessGroupNumber == (int)AccessGroupNumber.NoAccess);
            //if (noaccess == null)
            //{
            //    noaccess = new AccessGroup
            //    {
            //        AccessGroupUid = GuidUtilities.GenerateComb(),
            //        MercScpGroupUid = entity.MercScpGroupUid,
            //        EntityId = entity.EntityId,
            //        AccessGroupNumber = (int)GalaxySMS.Common.Enums.AccessGroupNumber.NoAccess,
            //        Display = SharedResources.AccessGroupName_NoAccess
            //    };
            //    noaccess.UniqueResourceName = noaccess.Display;
            //    noaccess.Description = SharedResources.AccessGroupName_NoAccess_Description;
            //    noaccess.IsEnabled = true;
            //    UpdateTableEntityBaseProperties(noaccess, sessionData);

            //    _accessGroupRepository.Add(noaccess, sessionData, saveParams);
            //}

            //var unlimited = accessGroups.Items.FirstOrDefault(g => g.AccessGroupNumber == (int)AccessGroupNumber.UnlimitedAccess);
            //if (unlimited == null)
            //{
            //    unlimited = new AccessGroup
            //    {
            //        AccessGroupUid = GuidUtilities.GenerateComb(),
            //        MercScpGroupUid = entity.MercScpGroupUid,
            //        EntityId = entity.EntityId,
            //        AccessGroupNumber = (int)GalaxySMS.Common.Enums.AccessGroupNumber.UnlimitedAccess,
            //        Display = SharedResources.AccessGroupName_UnlimitedAccess
            //    };
            //    unlimited.UniqueResourceName = unlimited.Display;
            //    unlimited.Description = SharedResources.AccessGroupName_UnlimitedAccess_Description;
            //    unlimited.IsEnabled = true;
            //    UpdateTableEntityBaseProperties(unlimited, sessionData);

            //    _accessGroupRepository.Add(unlimited, sessionData, saveParams);
            //}

            //var personal = accessGroups.Items.FirstOrDefault(g => g.AccessGroupNumber == (int)AccessGroupNumber.PersonalGroup);
            //if (personal == null)
            //{
            //    personal = new AccessGroup
            //    {
            //        AccessGroupUid = GuidUtilities.GenerateComb(),
            //        MercScpGroupUid = entity.MercScpGroupUid,
            //        EntityId = entity.EntityId,
            //        AccessGroupNumber = (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup,
            //        IsEnabled = true,
            //        Display = SharedResources.AccessGroupName_PersonalDoors
            //    };
            //    personal.UniqueResourceName = personal.Display;
            //    personal.Description = SharedResources.AccessGroupName_PersonalDoors_Description;
            //    UpdateTableEntityBaseProperties(personal, sessionData);

            //    _accessGroupRepository.Add(personal, sessionData, saveParams);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("MercScpGroup", "MercScpGroupUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("MercScpGroup", "MercScpGroupUid", id);
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

        protected override bool IsEntityUnique(MercScpGroup entity)
        {
            var mgr = new IsMercScpGroupUniquePDSAManager();
            mgr.Entity.MercScpGroupUid = entity.MercScpGroupUid;
            mgr.Entity.Name = entity.Name;
            mgr.Entity.EntityId = entity.EntityId;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("MercScpGroup", "MercScpGroupUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("MercScpGroup", "MercScpGroupUid", id);
            if (count == 0)
                return true;
            return false;
        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertMercScpGroupCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        public void OnImportsSatisfied()
        {
        }

        //public int GetAvailableMercScpGroupNumber(int MercScpGroupGroupId)
        //{
        //    var mgr = new ChooseAvailableMercScpGroupNumberPDSAManager { Entity = { MercScpGroupGroupId = MercScpGroupGroupId } };
        //    var results = mgr.BuildCollection();
        //    if (results != null && results.Count > 0)
        //        return results[0].MercScpGroupNumber;
        //    return 0;
        //}

        public bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid MercScpGroupUid, Guid permissionId, Guid entityId)
        {
            // If no permission is specified, return true to indicate that permission is granted
            if (permissionId == Guid.Empty)
                return true;

            if (!sessionData.IsPermissionCheckPossible)
                return true;

            var mgr = new MercScpGroup_GetUserPermissionPDSAManager();
            mgr.Entity.UserId = sessionData.UserId;
            mgr.Entity.MercScpGroupUid = MercScpGroupUid;
            mgr.Entity.PermissionId = permissionId;
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            if (results?.Count > 0)
                return true;

            return false;
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUids()
        {
            return GalaxySMSDatabaseManager.GetAllUidsFromTable("GCS", "MercScpGroup", "MercScpGroupUid");
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new MercScpGroup_GetAllUidsFromRoleIdPDSAManager();
            mgr.Entity.RoleId = roleId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.MercScpGroupUid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndSiteUid(Guid roleId, Guid siteUid)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAManager();
            mgr.Entity.RoleId = roleId;
            mgr.Entity.SiteUid = siteUid;
            var results = mgr.BuildCollection();
            return results.Select(o => o.MercScpGroupUid);
        }


        //public IArrayResponse<MercScpGroupTimeScheduleItem> GetMercScpGroupTimeScheduleItemsBySchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        //{
        //    try
        //    {
        //        var mgr = new MercScpGroupPDSAManager();
        //        mgr.DataObject.SelectFilter = MercScpGroupPDSAData.SelectFilters.InfoByTimeScheduleUid;
        //        mgr.Entity.TimeScheduleUid = parameters.UniqueId;
        //        //mgr.Entity.CultureName = sessionData.UiCulture;
        //        var items = GetIEnumerablePaged(sessionData, parameters, mgr);
        //        var returnData = new ArrayResponse<MercScpGroupTimeScheduleItem>()
        //        {
        //            TotalItemCount = items.TotalItemCount,
        //            TotalPageCount = items.TotalPageCount,
        //            PageItemCount = items.PageItemCount,
        //            PageNumber = items.PageNumber,
        //            PageSize = items.PageSize
        //        };
        //        var dataItems = new List<MercScpGroupTimeScheduleItem>();

        //        foreach (var i in items.Items)
        //        {
        //            dataItems.Add(i.ToMercScpGroupTimeScheduleItem());
        //        }

        //        returnData.Items = dataItems.ToArray();
        //        return returnData;
        //    }
        //    catch (PDSAValidationException ex)
        //    {
        //        DataValidationException dve = Converters.ConvertToDataValidationException(ex);
        //        throw dve;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllTimeSchedulesForRegion", ex);
        //        throw;
        //    }

        //}

        public bool IsMercScpGroupNameUnique(MercScpGroup entity)
        {
            var mgr = new IsMercScpGroupNameUniquePDSAManager();
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.MercScpGroupUid = entity.MercScpGroupUid;
            mgr.Entity.Name = entity.Name;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }


    }
}
