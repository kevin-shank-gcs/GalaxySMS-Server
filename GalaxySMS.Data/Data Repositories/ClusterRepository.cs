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
    [Export(typeof(IClusterRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ClusterRepository : PagedDataRepositoryBase<Cluster>, IClusterRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import]
        private IClusterEntityMapRepository _entityMapRepository;

        [Import]
        private IRoleClusterRepository _roleClusterRepository;

        [Import]
        private IClusterInputOutputGroupRepository _clusterInputOutputGroupRepository;

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

        [Import]
        private IGalaxyClusterTimeScheduleMapRepository _clusterTimeScheduleMapRepository;

        [Import]
        private IDayTypeRepository _dayTypeRepository;

        [Import]
        private IGalaxyClusterDayTypeMapRepository _clusterDayTypeMapRepository;

        [Import]
        private IClusterLedBehaviorModeRepository _clusterLedBehaviorModeRepository;

        [Import]
        private IClusterTypeRepository _clusterTypeRepository;

        [Import]
        private IClusterCommandRepository _clusterCommandRepository;

        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        protected override Cluster AddEntity(Cluster entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.ClusterUid, PermissionIds
                            .GalaxySMSDataAccessPermission
                            .SystemHardwareCanAddId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to add cluster {entity.ClusterUid}");
                    }
                }

                _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                //var tempEntity = entity.Clone(entity);
                //entity.CrisisActivateInputOutputGroupUid = Guid.Empty;
                //entity.CrisisResetInputOutputGroupUid = Guid.Empty;
                if (entity.AccessPortalTypeUid == null || entity.AccessPortalTypeUid.Value == Guid.Empty)
                {
                    entity.AccessPortalTypeUid = GalaxySMS.Common.Constants.AccessPortalTypeIds
                        .AccessPortalType_StandardEntryPoint_StandardWiegand;
                }

                var mgr = new ClusterPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.ClusterUid, entity, saveParams);

                    if (entity.TimeSchedules == null)
                        entity.TimeSchedules = new HashSet<TimeScheduleSelect>();
                    else
                        entity.TimeSchedules = entity.TimeSchedules.ToCollection();
                    // If ignore is specified, delete any specified in the TimeSchedules, then add the Always & Never, then clear the Ignore TimeSchedules so the standard always & never mappings are created
                    if (saveParams.Ignore(nameof(entity.TimeSchedules)))
                        saveParams.IgnoreProperties.Remove(nameof(entity.TimeSchedules));

                    if (entity.TimeSchedules.FirstOrDefault(o => o.TimeScheduleUid == TimeScheduleIds.TimeSchedule_Never) == null)
                    {
                        var tsm = new TimeScheduleSelect()
                        {
                            TimeScheduleUid = TimeScheduleIds.TimeSchedule_Never,
                            PanelScheduleNumber = TimeScheduleLimits.Never,
                            Selected = true
                        };
                        tsm.ClusterScheduleMap.PanelScheduleNumber = tsm.PanelScheduleNumber;
                        entity.TimeSchedules.Add(tsm);
                    }
                    if (entity.TimeSchedules.FirstOrDefault(o => o.TimeScheduleUid == TimeScheduleIds.TimeSchedule_Always) == null)
                    {
                        var tsmAlways = new TimeScheduleSelect()
                        {
                            TimeScheduleUid = TimeScheduleIds.TimeSchedule_Always,
                            PanelScheduleNumber = TimeScheduleLimits.Always,
                            Selected = true
                        };
                        tsmAlways.ClusterScheduleMap.PanelScheduleNumber = tsmAlways.PanelScheduleNumber;
                        entity.TimeSchedules.Add(tsmAlways);
                    }


                    SaveTimeScheduleMappings(sessionData, entity.ClusterUid, entity, saveParams);
                    //SaveDayTypeMappings(sessionData, entity.ClusterUid, entity, saveParams);
                    SaveRoleMappings(sessionData, entity.ClusterUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.ClusterUid, sessionData, new GetParametersWithPhoto(saveParams) { IncludeMemberCollections = true, IncludePhoto = true });
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::AddEntity", ex);
                throw;
            }
        }

        protected override Cluster UpdateEntity(Cluster entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.ClusterUid, PermissionIds
                            .GalaxySMSDataAccessPermission
                            .SystemHardwareCanUpdateId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update cluster {entity.ClusterUid}");
                    }
                }

                if (entity.gcsBinaryResource?.HasBeenModified == true)
                    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.ClusterUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true, IncludePhoto = true });
                if (originalEntity != null && originalEntity.EntityId != entity.EntityId)
                {
                    if (!DoesUserHavePermission(sessionData, entity.ClusterUid, PermissionIds.GalaxySMSDataAccessPermission
                                .SystemHardwareCanUpdateId, originalEntity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update cluster {entity.ClusterUid}");
                    }
                }

                var mgr = new ClusterPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.ClusterUid) > 0)// must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if SiteUid is = Guid.Empty or null, then use the value from the original record
                    entity.SiteUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.SiteUid, entity.SiteUid);

                    // if ClusterTypeUid is = Guid.Empty or null, then use the value from the original record
                    entity.ClusterTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.ClusterTypeUid, entity.ClusterTypeUid);

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);

                    // if CredentialDataLengthUid is = Guid.Empty or null, then use the value from the original record
                    entity.CredentialDataLengthUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.CredentialDataLengthUid, entity.CredentialDataLengthUid);

                    // if TimeScheduleTypeUid is = Guid.Empty or null, then use the value from the original record
                    entity.TimeScheduleTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.TimeScheduleTypeUid, entity.TimeScheduleTypeUid);

                    // if BinaryResourceUid is = Guid.Empty or null, then use the value from the original record
                    entity.BinaryResourceUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.BinaryResourceUid, entity.BinaryResourceUid);

                    // if CrisisActivateInputOutputGroupUid is = Guid.Empty or null, then use the value from the original record
                    entity.CrisisActivateInputOutputGroupUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.CrisisActivateInputOutputGroupUid, entity.CrisisActivateInputOutputGroupUid);

                    // if CrisisResetInputOutputGroupUid is = Guid.Empty or null, then use the value from the original record
                    entity.CrisisResetInputOutputGroupUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.CrisisResetInputOutputGroupUid, entity.CrisisResetInputOutputGroupUid);

                    // if AccessPortalLockedLedBehaviorModeUid is = Guid.Empty or null, then use the value from the original record
                    entity.AccessPortalLockedLedBehaviorModeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessPortalLockedLedBehaviorModeUid, entity.AccessPortalLockedLedBehaviorModeUid);

                    // if AccessPortalUnlockedLedBehaviorModeUid is = Guid.Empty or null, then use the value from the original record
                    entity.AccessPortalUnlockedLedBehaviorModeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessPortalUnlockedLedBehaviorModeUid, entity.AccessPortalUnlockedLedBehaviorModeUid);

                    // if AccessPortalTypeUid is = Guid.Empty or null, then use the value from the original record
                    entity.AccessPortalTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessPortalTypeUid, entity.AccessPortalTypeUid);

                    // if TemplateAccessPortalUid is = Guid.Empty or null, then use the value from the original record
                    entity.TemplateAccessPortalUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.TemplateAccessPortalUid, entity.TemplateAccessPortalUid);

                    if (entity.CrisisActivateInputOutputGroupUid == Guid.Empty ||
                        entity.CrisisResetInputOutputGroupUid == Guid.Empty)
                    {
                        var ioGroups = _ioGroupRepository.GetAllGalaxyInputOutputGroupsForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid });
                        var none = ioGroups.Items.FirstOrDefault(g => g.IOGroupNumber == (int)InputOutputGroupNumber.None);
                        if (none != null)
                        {
                            if (entity.CrisisActivateInputOutputGroupUid == Guid.Empty)
                                entity.CrisisActivateInputOutputGroupUid = none.InputOutputGroupUid;

                            if (entity.CrisisResetInputOutputGroupUid == Guid.Empty)
                                entity.CrisisResetInputOutputGroupUid = none.InputOutputGroupUid;
                        }
                    }
                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.ClusterUid, entity, saveParams);
                        SaveTimeScheduleMappings(sessionData, entity.ClusterUid, entity, saveParams);
                        //SaveDayTypeMappings(sessionData, entity.ClusterUid, entity, saveParams);
                        SaveRoleMappings(sessionData, entity.ClusterUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        //                        var updatedEntity = GetEntityByGuidId(entity.ClusterUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true, IncludePhoto = true });
                        var updatedEntity = GetEntityByGuidId(entity.ClusterUid, sessionData, new GetParametersWithPhoto(saveParams) { IncludeMemberCollections = true, IncludePhoto = true });
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
                throw new Exception($"{entity.GetType().Name} {entity.ClusterUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(Cluster entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.ClusterUid);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::DeleteEntity", ex);
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
                    throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to delete cluster {id}");
                }

                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, new GetParametersWithPhoto());
                var mgr = new ClusterPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::Remove", ex);
                throw;
            }
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, ClusterPDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<ClusterSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }


        private IEnumerable<Cluster> GetFilteredClusters(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters, ClusterPDSAManager mgr)
        {
            IEnumerable<Cluster> entities = new List<Cluster>();

            SetSortColumnAndOrder(getParameters, mgr);

            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                //entities = mgr.ConvertPDSACollection(pdsaEntities);

                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a cluster, creating RoleCluster records
                //      2) When saving Role, creating RoleCluster records
                // 
                if (sessionData == null || sessionData.UserId == Guid.Empty)
                {
                    entities = mgr.ConvertPDSACollection(pdsaEntities);
                }
                else
                {
                    var filteredClusterUids = GetFilteredClusterUids(sessionData);
                    var pdsaItems = pdsaEntities.Where(p => filteredClusterUids.Any(p2 => p2.ClusterUid == p.ClusterUid)).ToCollection();

                    entities = mgr.ConvertPDSACollection(pdsaItems);
                }
            }
            return entities;
        }

        private EntityLayer.ClusterUids_SelectForUserIdPDSACollection GetFilteredClusterUids(IApplicationUserSessionDataHeader sessionData)
        {
            var filteredMgr = new ClusterUids_SelectForUserIdPDSAManager();
            filteredMgr.Entity.UserId = sessionData.UserId;
            var filteredClusterUids = filteredMgr.BuildCollection();
            return filteredClusterUids;
        }

        private IEnumerable<Cluster> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, ClusterPDSAManager mgr)
        {
            var entities = GetFilteredClusters(sessionData, getParameters, mgr);

            foreach (var entity in entities)
            {
                if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludePhoto || getParameters.IncludeCommands)
                    FillMemberCollections(entity, sessionData, getParameters);
            }
            return entities;
        }

        private ArrayResponse<Cluster> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, ClusterPDSAManager mgr)
        {
            var includeCounts = false;
            var includeCountsOption = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
            if (includeCountsOption.HasValue)
                includeCounts = includeCountsOption.Value;

            var entities = GetFilteredClusters(sessionData, getParameters, mgr);
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

        protected override IEnumerable<Cluster> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.DataObject.SelectFilter = ClusterPDSAData.SelectFilters.ByEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<Cluster> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.DataObject.SelectFilter = ClusterPDSAData.SelectFilters.ByEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<Cluster> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.DataObject.SelectFilter = ClusterPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetAllEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<Cluster> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.DataObject.SelectFilter = ClusterPDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<Cluster> GetAllClustersForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }
        public IArrayResponse<Cluster> GetAllClustersForEntityPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }

        public IEnumerable<Cluster> GetAllClustersForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.DataObject.SelectFilter = ClusterPDSAData.SelectFilters.BySiteUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetAllClustersForSite", ex);
                throw;
            }
        }
        public IArrayResponse<Cluster> GetAllClustersForSitePaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.DataObject.SelectFilter = ClusterPDSAData.SelectFilters.BySiteUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetAllClustersForSite", ex);
                throw;
            }
        }

        public bool VerifyEntityIdMatches(Guid clusterUid, Guid entityId)
        {
            var mgr = new GetEntityIdForClusterPDSAManager
            {
                Entity =
                {
                    uid = clusterUid
                }
            };
            var results = mgr.BuildCollection();
            var result = results.FirstOrDefault();
            if (result != null)
                return result.EntityId == entityId;
            return false;
        }

        public Guid GetEntityId(Guid clusterUid)
        {
            var mgr = new GetEntityIdForClusterPDSAManager()
            {
                Entity =
                {
                    uid = clusterUid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId;
            return Guid.Empty;
        }

        public Guid GetEntityId(int clusterGroupId, int clusterNumber)
        {
            var mgr = new GetEntityIdForCluster_ByHardwareAddressPDSAManager()
            {
                Entity =
                {
                    clusterGroupId = clusterGroupId,
                    clusterNumber = clusterNumber
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId;
            return Guid.Empty;
        }

        public IArrayResponse<ClusterSelectionItemBasic> GetAllClusterSelectionItemsForEntityAndSite(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new Cluster_SelectionListForEntityAndSitePDSAManager();
                mgr.Entity.EntityId = parameters.CurrentEntityId;
                mgr.Entity.SiteUid = parameters.CurrentSiteUid;
                mgr.Entity.PageNumber = parameters.PageNumber;
                mgr.Entity.PageSize = parameters.PageSize;
                if (!string.IsNullOrEmpty(parameters?.SortProperty))
                {
                    var sortProperty = EnumExtensions.GetOne<ClusterSortProperty>(parameters.SortProperty);
                    mgr.Entity.SortColumn = sortProperty.ToString();
                }

                mgr.Entity.DescendingOrder = parameters?.DescendingOrder == true;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var totalCount = 0;
                    var entities = new List<ClusterSelectionItemBasic>();
                    foreach (var entity in pdsaEntities)
                    {
                        if (totalCount == 0)
                            totalCount = entity.TotalRowCount;
                        var newEntity = new ClusterSelectionItemBasic();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        if (parameters.IncludeMemberCollections || parameters.IncludePhoto)
                            FillMemberCollections(newEntity, sessionData, parameters);
                        entities.Add(newEntity);
                    }
                    return ArrayResponseHelpers.ToArrayResponse(entities, parameters.PageNumber, parameters.PageSize, totalCount);
                }
                return new ArrayResponse<ClusterSelectionItemBasic>();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetAllClusterSelectionItemsForEntityAndSite", ex);
                throw;
            }
        }
        public IArrayResponse<ClusterSelectionItemBasic> GetAllClusterSelectionItemsForSite(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new Cluster_SelectionListForSitePDSAManager();
                mgr.Entity.SiteUid = parameters.CurrentSiteUid;
                mgr.Entity.PageNumber = parameters.PageNumber;
                mgr.Entity.PageSize = parameters.PageSize;
                if (!string.IsNullOrEmpty(parameters?.SortProperty))
                {
                    var sortProperty = EnumExtensions.GetOne<ClusterSortProperty>(parameters.SortProperty);
                    mgr.Entity.SortColumn = sortProperty.ToString();
                }

                mgr.Entity.DescendingOrder = parameters?.DescendingOrder == true;

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var totalCount = 0;

                    var entities = new List<ClusterSelectionItemBasic>();
                    foreach (var entity in pdsaEntities)
                    {
                        if (totalCount == 0)
                            totalCount = entity.TotalRowCount;
                        var newEntity = new ClusterSelectionItemBasic();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        if (parameters.IncludeMemberCollections || parameters.IncludePhoto)
                            FillMemberCollections(newEntity, sessionData, parameters);
                        entities.Add(newEntity);
                    }
                    return ArrayResponseHelpers.ToArrayResponse(entities, parameters.PageNumber, parameters.PageSize, totalCount);
                }
                return new ArrayResponse<ClusterSelectionItemBasic>();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetAllClusterSelectionItemsForEntityAndSite", ex);
                throw;
            }
        }

        public IEnumerable<Cluster> GetClustersByClusterNumber(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.DataObject.SelectFilter = ClusterPDSAData.SelectFilters.ByClusterNumber;
                mgr.Entity.ClusterNumber = getParameters.ClusterNumber;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetAllClustersForSite", ex);
                throw;
            }
        }

        public IEnumerable<Cluster> GetClustersByClusterGroupId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.DataObject.SelectFilter = ClusterPDSAData.SelectFilters.ByClusterGroupId;
                mgr.Entity.ClusterGroupId = getParameters.ClusterGroupId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetAllClustersForSite", ex);
                throw;
            }
        }

        public Cluster GetByHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.DataObject.SelectFilter = ClusterPDSAData.SelectFilters.ByClusterGroupIdAndNumber;
                mgr.Entity.ClusterGroupId = getParameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = getParameters.ClusterNumber;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null && pdsaEntities.Count > 0)
                {
                    Cluster result = new Cluster();
                    SimpleMapper.PropertyMap(pdsaEntities[0], result);
                    if (getParameters.IncludeMemberCollections || getParameters.IncludePhoto)
                        FillMemberCollections(result, sessionData, getParameters);
                    return result;
                }
                return null;

                var results = GetIEnumerable(sessionData, getParameters, mgr);
                return results.FirstOrDefault();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetAllClustersForSite", ex);
                throw;
            }

        }

        protected override Cluster GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override Cluster GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    if (!getParameters.DoNotValidateAuthorization)
                    {
                        if (!DoesUserHavePermission(sessionData, mgr.Entity.ClusterUid, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId, mgr.Entity.EntityId))
                        {
                            throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to view cluster {mgr.Entity.ClusterName}");
                        }
                    }

                    Cluster result = new Cluster();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        public Cluster_CommonPanelLoadData GetCommonPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new Cluster_GetPanelCommonLoadDataPDSAManager();
                mgr.Entity.ClusterUid = getParameters.UniqueId;
                mgr.Entity.ClusterGroupId = getParameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = getParameters.ClusterNumber;
                var result = mgr.BuildCollection();
                if (result != null && result.Count == 1)
                    return mgr.ConvertPDSAEntity(result[0]);
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetCommonPanelLoadData", ex);
                throw;
            }
        }

        public Cluster_GetHardwareAddress GetClusterHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new Cluster_GetHardwareAddressPDSAManager();
                mgr.Entity.ClusterUid = parameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null && result.Count == 1)
                    return mgr.ConvertPDSAEntity(result[0]);
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::GetClusterHardwareAddress", ex);
                throw;
            }
        }


        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, Cluster originalEntity, Cluster newEntity, string auditXml)
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
                        propertiesToIgnore.Add(nameof(Cluster.UpdateDate));
                        propertiesToIgnore.Add(nameof(Cluster.UpdateName));
                        propertiesToIgnore.Add(nameof(Cluster.ConcurrencyValue));
                        propertiesToIgnore.Add(nameof(Cluster.ClusterType));
                        propertiesToIgnore.Add(nameof(Cluster.EntityIds));
                        propertiesToIgnore.Add(nameof(Cluster.MappedEntitiesPermissionLevels));
                        propertiesToIgnore.Add(nameof(Cluster.TimeSchedules));
                        //propertiesToIgnore.Add(nameof(Cluster.DayTypes));
                        propertiesToIgnore.Add(nameof(Cluster.InputOutputGroups));
                        propertiesToIgnore.Add(nameof(Cluster.AccessGroups));
                        propertiesToIgnore.Add(nameof(Cluster.Areas));
                        propertiesToIgnore.Add(nameof(Cluster.ClusterEntityMaps));
                        propertiesToIgnore.Add(nameof(Cluster.ClusterInputOutputGroups));
                        propertiesToIgnore.Add(nameof(Cluster.GalaxyPanels));
                        propertiesToIgnore.Add(nameof(Cluster.ClusterCommands));
                        propertiesToIgnore.Add(nameof(Cluster.ClusterFlashingCommands));
                        propertiesToIgnore.Add(nameof(Cluster.DisabledCommandIds));
                        propertiesToIgnore.Add(nameof(Cluster.RoleIds));
                        propertiesToIgnore.Add(nameof(Cluster.ScheduleIds));
                        propertiesToIgnore.Add(nameof(Cluster.MappedSchedules));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "ClusterUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.ClusterUid;
                        mgr.Entity.RecordTag = newEntity.ClusterUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "ClusterUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.ClusterUid;
                        mgr.Entity.RecordTag = newEntity.ClusterUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "ClusterUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.ClusterUid;
                        mgr.Entity.RecordTag = originalEntity.ClusterUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//ClusterRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(Cluster entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                return;

            var includeCounts = false;
            var includeCountsOption = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions.IncludeCounts);
            if (includeCountsOption.HasValue)
                includeCounts = includeCountsOption.Value;

            if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty && getParameters.IncludePhoto)
            {
                entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, getParameters);
            }

            if (getParameters.IncludeMemberCollections)
            {
                if (!getParameters.IsExcluded(nameof(entity.EntityIds)))
                {
                    var entityMaps = _entityMapRepository.GetAllClusterEntityMapsForCluster(sessionData,
                        new GetParametersWithPhoto() { UniqueId = entity.ClusterUid });
                    var entityIds = (from e in entityMaps select e.EntityId).ToList();
                    entity.EntityIds.AddRange(entityIds);

                    entity.EntityIds.Add(entity.EntityId);
                }

                if (!getParameters.IsExcluded(nameof(entity.RoleIds)))
                {
                    var roleFilters = _roleClusterRepository.GetAllForClusterUid(sessionData,
                        new GetParametersWithPhoto() { UniqueId = entity.ClusterUid });
                    var roleIds = (from e in roleFilters select e.RoleId).ToList();
                    entity.RoleIds.AddRange(roleIds);
                }

                if (!getParameters.IsExcluded(nameof(entity.InputOutputGroups)))
                {
                    var includeAssignments = getParameters.GetOption(nameof(InputOutputGroupAssignment));

                    bool bIncludeMemberCollections = false;
                    if (includeAssignments.HasValue)
                        bIncludeMemberCollections = includeAssignments.Value;

                    entity.InputOutputGroups = _ioGroupRepository.GetAllGalaxyInputOutputGroupsForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid, IncludeMemberCollections = bIncludeMemberCollections }).Items.ToCollection();
                }

                if (!getParameters.IsExcluded(nameof(entity.Areas)))
                    entity.Areas = _areaRepository.GetAllGalaxyAreasForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid }).Items.ToCollection();

                if (!getParameters.IsExcluded(nameof(entity.AccessGroups)))
                    entity.AccessGroups = _accessGroupRepository.GetAllGalaxyAccessGroupsForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid }).Items.ToCollection();

                if (!getParameters.IsExcluded(nameof(entity.ClusterInputOutputGroups)))
                    entity.ClusterInputOutputGroups = _clusterInputOutputGroupRepository.GetClusterInputOutputGroupsByClusterUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid }).ToCollection();


                if (!getParameters.IsExcluded(nameof(entity.TimeSchedules)) ||
                    !getParameters.IsExcluded(nameof(entity.ScheduleIds)) ||
                    !getParameters.IsExcluded(nameof(entity.MappedSchedules)))
                {
                    // Get all the GalaxyClusterTimeScheduleMap records for this cluster and build the TimeSchedules collection
                    var galaxyClusterTimeScheduleMaps = _clusterTimeScheduleMapRepository.GetAllGalaxyClusterTimeScheduleMapForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid }).ToCollection();
                    if (!getParameters.IsExcluded(nameof(entity.ScheduleIds)))
                        entity.ScheduleIds.AddRange(galaxyClusterTimeScheduleMaps.Select(o => o.TimeScheduleUid));

                    if (!getParameters.IsExcluded(nameof(entity.MappedSchedules)))
                    {
                        foreach (var tsm in galaxyClusterTimeScheduleMaps)
                        {
                            entity.MappedSchedules.Add(new ClusterTimeScheduleItem()
                            {
                                Id = tsm.TimeScheduleUid,
                                Name = tsm.TimeScheduleName,
                                Number = tsm.PanelScheduleNumber
                            });
                        }
                    }

                    if (!getParameters.IsExcluded(nameof(entity.TimeSchedules)))
                    {
                        var ts = _timeScheduleRepository.GetAllTimeSchedulesForMappedEntity(sessionData,
                            new GetParametersWithPhoto() { UniqueId = entity.EntityId });
                        foreach (var s in ts.Items)
                        {
                            var tss = new TimeScheduleSelect(s);
                            var temp = galaxyClusterTimeScheduleMaps.FirstOrDefault(i =>
                                i.TimeScheduleUid == s.TimeScheduleUid);
                            if (temp != null)
                            {
                                tss.Selected = true;
                                tss.ClusterScheduleMap = temp;
                            }

                            //tss.Selected = galaxyClusterTimeScheduleMaps.Select(i => i.TimeScheduleUid == s.TimeScheduleUid).FirstOrDefault();
                            //if (tss.Selected)
                            //    tss.ClusterScheduleMap = 
                            entity.TimeSchedules.Add(tss);
                        }
                    }
                }

                //if (!getParameters.IsExcluded(nameof(entity.DayTypes)))
                //{
                //    // Get all the GalaxyClusterTimeScheduleMap records for this cluster and build the TimeSchedules collection
                //    var galaxyClusterDayTypeMaps = _clusterDayTypeMapRepository.GetAllGalaxyClusterDayTypeMapForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid }).ToCollection();

                //    var dt = _dayTypeRepository.GetAllDayTypesForMappedEntity(sessionData, new GetParametersWithPhoto() { UniqueId = entity.EntityId });
                //    foreach (var t in dt.Items)
                //    {
                //        var dtss = new DayTypeSelect(t);
                //        var temp = galaxyClusterDayTypeMaps.FirstOrDefault(i => i.DayTypeUid == t.DayTypeUid);
                //        if (temp != null)
                //        {
                //            dtss.Selected = true;
                //            dtss.ClusterDayTypeMap = temp;
                //        }
                //        //tss.Selected = galaxyClusterTimeScheduleMaps.Select(i => i.TimeScheduleUid == s.TimeScheduleUid).FirstOrDefault();
                //        //if (tss.Selected)
                //        //    tss.ClusterScheduleMap = 
                //        entity.DayTypes.Add(dtss);
                //    }
                //}

                if (!getParameters.IsExcluded(nameof(entity.GalaxyPanels)))
                {
                    var getPanelParams = new GetParametersWithPhoto(getParameters);
                    getPanelParams.UniqueId = entity.ClusterUid;
                    entity.GalaxyPanels = _galaxyPanelRepository.GetAllGalaxyPanelsForCluster(sessionData, getPanelParams).Items.ToCollection();
                }
                //if (entity.CrisisActivateInputOutputGroupUid != null && entity.CrisisActivateInputOutputGroupUid != Guid.Empty)
                //    entity.CrisisActivateInputOutputGroup = _ioGroupRepository.Get(sessionData, new GetParametersWithPhoto() { UniqueId = entity.CrisisActivateInputOutputGroupUid.Value }).FirstOrDefault();

                //if (entity.CrisisResetInputOutputGroupUid != null && entity.CrisisResetInputOutputGroupUid != Guid.Empty)
                //    entity.CrisisResetInputOutputGroup = _ioGroupRepository.Get(sessionData, new GetParametersWithPhoto() { UniqueId = entity.CrisisResetInputOutputGroupUid.Value }).FirstOrDefault();

                //if( entity.AccessPortalLockedLedBehaviorModeUid != Guid.Empty)
                //    entity.AccessPortalLockedLedBehaviorMode = _clusterLedBehaviorModeRepository.Get(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalLockedLedBehaviorModeUid }).FirstOrDefault();

                //if (entity.AccessPortalUnlockedLedBehaviorModeUid != Guid.Empty)
                //    entity.AccessPortalUnlockedLedBehaviorMode = _clusterLedBehaviorModeRepository.Get(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUnlockedLedBehaviorModeUid }).FirstOrDefault();

                if (entity.ClusterTypeUid != Guid.Empty && !getParameters.IsExcluded(nameof(entity.ClusterType)))
                    entity.ClusterType = _clusterTypeRepository.Get(entity.ClusterTypeUid, sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterTypeUid });

                if (!getParameters.IsExcluded(nameof(entity.ClusterCommands)))
                    entity.ClusterCommands = _clusterCommandRepository.GetAllClusterCommandsForClusterType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterTypeUid }).ToCollection();

                if (!getParameters.IsExcluded(nameof(entity.ClusterFlashingCommands)))
                    entity.ClusterFlashingCommands = _clusterCommandRepository.GetAllClusterFlashingCommandsForClusterType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterTypeUid }).ToCollection();
            }

            if (getParameters.IncludeCommands)
            {
                //if (!getParameters.IsExcluded(nameof(entity.ClusterCommands)) && !entity.ClusterCommands.Any())
                //    entity.ClusterCommands = _clusterCommandRepository.GetAllClusterCommandsForClusterType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterTypeUid }).ToCollection();

                //if (!getParameters.IsExcluded(nameof(entity.ClusterFlashingCommands)) && !entity.ClusterFlashingCommands.Any())
                //    entity.ClusterFlashingCommands = _clusterCommandRepository.GetAllClusterFlashingCommandsForClusterType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterTypeUid }).ToCollection();
                var getP = new GetParametersWithPhoto() { UniqueId = entity.ClusterTypeUid, IncludePhoto = false };
                var cmds = _clusterCommandRepository.GetAllClusterCommandsForClusterType(sessionData, getP).ToCollection();
                var flashingCommands = _clusterCommandRepository
                    .GetAllClusterFlashingCommandsForClusterType(sessionData, getP).ToCollection();

                cmds.AddRange(flashingCommands);
                // Check role permissions and access portal filters here
                var filterMgr = new ClusterFilters_SelectForUserIdPDSAManager();
                filterMgr.Entity.ClusterUid = entity.ClusterUid;
                filterMgr.Entity.UserId = sessionData.UserId;
                var filters = filterMgr.BuildCollection();

                var deleteTheseCommands = new List<ClusterCommand>();
                foreach (var cmd in cmds)
                {
                    var permissionUid = Guid.Empty;
                    if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ActivateCrisisMode)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ActivateCrisisMode;
                    }
                    else if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ResetCrisisMode)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ResetCrisisMode;
                    }
                    else if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ClearLoggingBuffer)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ClearLogBuffer;
                    }
                    else if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_DeleteAllCredentials)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.DeleteAllCards;
                    }
                    else if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_DisableCredential)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.DisableCredential;
                    }
                    else if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_EnableCredential)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.EnableCredential;
                    }
                    else if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ForgiveAllPassback)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ForgiveAllPassback;
                    }
                    else if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ForgivePassback)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ForgivePassback;
                    }
                    else if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ResetControllerCold)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ResetPanelCold;
                    }
                    else if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ResetControllerWarm)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ResetPanelWarm;
                    }
                    else if (cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_BeginFlashLoad ||
                             cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ValidateAndBurnFlash ||
                             cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ValidateFlash ||
                             cmd.ClusterCommandUid == GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_EnableDaughterBoardFlashUpdate)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.LoadPanelFlash;
                    }

                    if (permissionUid != Guid.Empty)
                    {
                        var filter = filters.FirstOrDefault(o => o.PermissionId == permissionUid);
                        if (filter == null)
                            deleteTheseCommands.Add(cmd);
                    }
                }

                foreach (var cmd in deleteTheseCommands)
                {
                    entity.DisabledCommandIds.Add(cmd.ClusterCommandUid);
                    cmds.Remove(cmd);
                }

                entity.ClusterCommands = cmds.Where(o => o.IsFlashingCommand == false).ToCollection();
                entity.ClusterFlashingCommands = cmds.Where(o => o.IsFlashingCommand == true).ToCollection();

            }

            if (includeCounts)
            {
                entity.Counts = GetClusterCounts(entity.ClusterUid);
            }
        }

        private ClusterCounts GetClusterCounts(Guid clusterUid)
        {
            try
            {
                var mgr = new Cluster_GetCountsPDSAManager();
                mgr.Entity.ClusterUid = clusterUid;
                var results = mgr.BuildCollection();
                if (results?.Count > 0)
                {
                    var r = results[0];
                    var clusterCounts = new ClusterCounts()
                    {
                        PanelsCount = r.PanelsCount,
                        BoardsCount = r.BoardsCount,
                        AccessPortalsCount = r.AccessPortalsCount,
                        InputDevicesCount = r.InputDevicesCount,
                        OutputDevicesCount = r.OutputDevicesCount
                    };
                    return clusterCounts;
                }

                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        protected void FillMemberCollections(ClusterSelectionItemBasic entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                return;

            if (entity.Photo != null && entity.Photo.Length > 0 && getParameters.IncludePhoto && getParameters.PhotoPixelWidth > 0)
            {
                var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                    GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.Photo), getParameters.PhotoPixelWidth);
                entity.Photo = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
            }

            if (getParameters.IncludeMemberCollections)
            {
                getParameters.ClusterUid = entity.ClusterUid;
                if (!getParameters.IsExcluded(nameof(entity.AccessGroups)))
                {
                    var accessGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyAccessGroupRepository>();
                    entity.AccessGroups = accessGroupRepository.GetAllAccessGroupSelectionItemsForEntityAndCluster(sessionData, getParameters).ToCollection();
                }

                if (!getParameters.IsExcluded(nameof(entity.InputOutputGroups)))
                {
                    var inputOutputGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();
                    entity.InputOutputGroups = inputOutputGroupRepository.GetAllInputOutputGroupSelectionItemsForEntityAndCluster(sessionData, getParameters).ToCollection();
                }

                if (!getParameters.IsExcluded(nameof(entity.AccessPortals)))
                {
                    var accessPortalRepository = _dataRepositoryFactory.GetDataRepository<IAccessPortalRepository>();
                    entity.AccessPortals = accessPortalRepository.GetAllAccessPortalSelectionItemsForEntityAndCluster(sessionData, getParameters).ToCollection();
                }

                if (!getParameters.IsExcluded(nameof(entity.TimeSchedules)))
                {
                    var timeScheduleRepository = _dataRepositoryFactory.GetDataRepository<ITimeScheduleRepository>();
                    entity.TimeSchedules = timeScheduleRepository.GetAllTimeScheduleSelectionItemsForEntityAndCluster(sessionData, getParameters).ToCollection();
                }

                if (!getParameters.IsExcluded(nameof(entity.InputDevices)))
                {
                    var inputDeviceRepository = _dataRepositoryFactory.GetDataRepository<IInputDeviceRepository>();
                    entity.InputDevices = inputDeviceRepository.GetAllInputDeviceSelectionItemsForEntityAndCluster(sessionData, getParameters).ToCollection();
                }

                if (!getParameters.IsExcluded(nameof(entity.OutputDevices)))
                {
                    var outputDeviceRepository = _dataRepositoryFactory.GetDataRepository<IOutputDeviceRepository>();
                    entity.OutputDevices = outputDeviceRepository.GetAllOutputDeviceSelectionItemsForEntityAndCluster(sessionData, getParameters).ToCollection();
                }
            }
        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            if (entity.EntityIds == null || !entity.EntityIds.Any() || saveParams.Ignore(nameof(entity.EntityIds)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllClusterEntityMapsForCluster(sessionData, getParameters);
            var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
            var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

            foreach (var existingEntityId in existingEntityIds)
            {
                if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
                {
                    var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
                    if (deleteThisExistingEntityMap != null)
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.ClusterEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new ClusterEntityMap();
                    entityMap.ClusterEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.ClusterUid = uid;
                    entityMap.EntityId = entityId;
                    UpdateTableEntityBaseProperties(entityMap, sessionData);
                    //entityMap.UpdateDate = DateTimeOffset.Now;
                    //entityMap.UpdateName = sessionData.UserName;
                    //entityMap.InsertDate = DateTimeOffset.Now;
                    //entityMap.InsertName = sessionData.UserName;

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        //private void SaveTimeScheduleMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, Cluster entity)
        //{
        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingScheduleMappings = _clusterTimeScheduleMapRepository.GetAllGalaxyClusterTimeScheduleMapForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid }).ToCollection();
        //    var existingScheduleUids = new HashSet<Guid>(existingScheduleMappings.Select(e => e.TimeScheduleUid));
        //    var currentScheduleMappingUids = new HashSet<Guid>(entity.GalaxyClusterTimeScheduleMaps.Select(e => e.TimeScheduleUid));

        //    // Delete any existing Schedule mappings that are no longer mapped
        //    foreach (var existingScheduleUid in existingScheduleUids)
        //    {
        //        if (!currentScheduleMappingUids.Contains(existingScheduleUid))
        //        {
        //            var deleteThisExistingScheduleMap = (from esm in existingScheduleMappings where esm.TimeScheduleUid == existingScheduleUid select esm).FirstOrDefault();
        //            if (deleteThisExistingScheduleMap != null)
        //                _clusterTimeScheduleMapRepository.Remove(deleteThisExistingScheduleMap.GalaxyClusterTimeScheduleMapUid, sessionData, null);
        //        }
        //    }

        //    // Now add any mappings that are not already defined
        //    foreach (var scheduleMap in entity.GalaxyClusterTimeScheduleMaps)
        //    {
        //        if (!existingScheduleUids.Contains(scheduleMap.TimeScheduleUid))
        //        {
        //            scheduleMap.GalaxyClusterTimeScheduleMapUid = GuidUtilities.GenerateComb();
        //            scheduleMap.ClusterUid = uid;

        //            var definedScheduleNumbers = entity.GalaxyClusterTimeScheduleMaps.Select(i => i.PanelScheduleNumber);
        //            var availableNumbers = Enumerable.Range(GalaxySMS.Common.Constants.TimeScheduleLimits.LowestDefinableNumber, GalaxySMS.Common.Constants.TimeScheduleLimits.HighestDefinableNumber).Except(definedScheduleNumbers);
        //            if (availableNumbers.Count() == 0)
        //                return;

        //            scheduleMap.PanelScheduleNumber = availableNumbers.FirstOrDefault();

        //            UpdateTableEntityBaseProperties(scheduleMap, sessionData);

        //            _clusterTimeScheduleMapRepository.Add(scheduleMap, sessionData, null);
        //        }
        //    }
        //}

        private void SaveTimeScheduleMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, Cluster entity, ISaveParameters saveParams)
        {
            if (entity.TimeSchedules == null || !entity.TimeSchedules.Any() || saveParams.Ignore(nameof(entity.TimeSchedules)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingScheduleMappings = _clusterTimeScheduleMapRepository.GetAllGalaxyClusterTimeScheduleMapForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid }).ToCollection();
            var existingScheduleUids = new HashSet<Guid>(existingScheduleMappings.Select(e => e.TimeScheduleUid));
            var currentScheduleMappingUids = new HashSet<Guid>(entity.TimeSchedules.Where(e => e.Selected == true).Select(e => e.TimeScheduleUid));

            // Delete any existing Schedule mappings that are no longer mapped
            foreach (var existingScheduleUid in existingScheduleUids)
            {
                if (existingScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never ||
                    existingScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                    continue;

                if (!currentScheduleMappingUids.Contains(existingScheduleUid))
                {
                    var deleteThisExistingScheduleMap = (from esm in existingScheduleMappings where esm.TimeScheduleUid == existingScheduleUid select esm).FirstOrDefault();
                    if (deleteThisExistingScheduleMap != null)
                        _clusterTimeScheduleMapRepository.Remove(deleteThisExistingScheduleMap.GalaxyClusterTimeScheduleMapUid, sessionData);
                }
            }

            // Now add any mappings that are not already defined
            foreach (var ts in entity.TimeSchedules)
            {
                if (!existingScheduleUids.Contains(ts.TimeScheduleUid))
                {
                    ts.ClusterScheduleMap.GalaxyClusterTimeScheduleMapUid = GuidUtilities.GenerateComb();
                    ts.ClusterScheduleMap.ClusterUid = uid;
                    ts.ClusterScheduleMap.TimeScheduleUid = ts.TimeScheduleUid;
                    if (ts.TimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never &&
                        ts.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Always)
                    {
                        if (ts.ClusterScheduleMap.PanelScheduleNumber <
                            GalaxySMS.Common.Constants.TimeScheduleLimits.LowestDefinableNumber ||
                            ts.ClusterScheduleMap.PanelScheduleNumber >
                            GalaxySMS.Common.Constants.TimeScheduleLimits.HighestDefinableNumber)
                        {
                            var definedScheduleNumbers = existingScheduleMappings.Select(i => i.PanelScheduleNumber);
                            var availableNumbers = Enumerable
                                .Range(GalaxySMS.Common.Constants.TimeScheduleLimits.LowestDefinableNumber,
                                    GalaxySMS.Common.Constants.TimeScheduleLimits.HighestDefinableNumber)
                                .Except(definedScheduleNumbers);
                            if (!availableNumbers.Any())
                            {
                                throw new ArgumentOutOfRangeException("PanelScheduleNumber",
                                    $"Unable to allocate a internal number for the time schedule '{ts.Display}' because there are already {definedScheduleNumbers.Count()} schedules mapped to this cluster.");
                            }

                            ts.ClusterScheduleMap.PanelScheduleNumber = availableNumbers.FirstOrDefault();
                        }
                    }

                    UpdateTableEntityBaseProperties(ts.ClusterScheduleMap, sessionData);

                    var savedItem = _clusterTimeScheduleMapRepository.Add(ts.ClusterScheduleMap, sessionData, saveParams);
                    existingScheduleMappings.Add(savedItem);
                }
                else if (ts.ClusterScheduleMap.IsDirty)
                {
                    ts.UpdateDate = DateTimeOffset.Now;
                    ts.UpdateName = sessionData.UserName;
                    var savedItem = _clusterTimeScheduleMapRepository.Update(ts.ClusterScheduleMap, sessionData, saveParams);

                }
            }
        }

        //private void SaveDayTypeMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, Cluster entity, ISaveParameters saveParams)
        //{
        //    if (entity.DayTypes == null || !entity.DayTypes.Any() || saveParams.Ignore(nameof(entity.DayTypes)))
        //        return;

        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingDayTypeMappings = _clusterDayTypeMapRepository.GetAllGalaxyClusterDayTypeMapForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid }).ToCollection();
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
        //                _clusterDayTypeMapRepository.Remove(deleteThisExistingDayTypeMap.GalaxyClusterDayTypeMapUid, sessionData);
        //        }
        //    }

        //    var newMappedDayTypeUids = currentDayTypeMappingUids.Where(p => !existingDayTypeUids.Any(p2 => p2 == p)).ToList();
        //    var newMappedDayTypes = entity.DayTypes.Where(p => newMappedDayTypeUids.Any(p2 => p2 == p.DayTypeUid)).ToList();
        //    // Delete any existing Day type mappings that are no longer mapped
        //    foreach (var dt in newMappedDayTypes)
        //    {
        //        dt.ClusterDayTypeMap.GalaxyClusterDayTypeMapUid = GuidUtilities.GenerateComb();
        //        dt.ClusterDayTypeMap.ClusterUid = uid;
        //        dt.ClusterDayTypeMap.DayTypeUid = dt.DayTypeUid;
        //        if (dt.ClusterDayTypeMap.PanelDayTypeNumber < GalaxySMS.Common.Constants.DayTypeLimits.LowestDefinableNumber ||
        //            dt.ClusterDayTypeMap.PanelDayTypeNumber > GalaxySMS.Common.Constants.DayTypeLimits.HighestDefinableNumber)
        //        {
        //            var definedDayTypeNumbers = existingDayTypeMappings.Select(i => i.PanelDayTypeNumber);
        //            var availableNumbers = Enumerable.Range(GalaxySMS.Common.Constants.DayTypeLimits.LowestDefinableNumber, GalaxySMS.Common.Constants.DayTypeLimits.HighestDefinableNumber).Except(definedDayTypeNumbers);
        //            if (availableNumbers.Count() == 0)
        //            {
        //                throw new ArgumentOutOfRangeException("PanelDayTypeNumber", string.Format("Unable to allocate a internal number for the day type '{0}' because there are already {1} day types mapped to this cluster.",
        //                    dt.Name, definedDayTypeNumbers.Count()));
        //            }
        //            dt.ClusterDayTypeMap.PanelDayTypeNumber = availableNumbers.FirstOrDefault();
        //        }

        //        UpdateTableEntityBaseProperties(dt.ClusterDayTypeMap, sessionData);

        //        var savedItem = _clusterDayTypeMapRepository.Add(dt.ClusterDayTypeMap, sessionData, saveParams);
        //        existingDayTypeMappings.Add(savedItem);
        //    }


        //    //foreach (var dt in entity.DayTypes)
        //    //{
        //    //    if (!existingDayTypeUids.Contains(dt.DayTypeUid))
        //    //    {
        //    //        dt.ClusterDayTypeMap.GalaxyClusterDayTypeMapUid = GuidUtilities.GenerateComb();
        //    //        dt.ClusterDayTypeMap.ClusterUid = uid;
        //    //        dt.ClusterDayTypeMap.DayTypeUid = dt.DayTypeUid;    
        //    //        if (dt.ClusterDayTypeMap.PanelDayTypeNumber < GalaxySMS.Common.Constants.DayTypeLimits.LowestDefinableNumber ||
        //    //            dt.ClusterDayTypeMap.PanelDayTypeNumber > GalaxySMS.Common.Constants.DayTypeLimits.HighestDefinableNumber)
        //    //        {
        //    //            var definedDayTypeNumbers = existingDayTypeMappings.Select(i => i.PanelDayTypeNumber);
        //    //            var availableNumbers = Enumerable.Range(GalaxySMS.Common.Constants.DayTypeLimits.LowestDefinableNumber, GalaxySMS.Common.Constants.DayTypeLimits.HighestDefinableNumber).Except(definedDayTypeNumbers);
        //    //            if (availableNumbers.Count() == 0)
        //    //            {
        //    //                throw new ArgumentOutOfRangeException("PanelDayTypeNumber", string.Format("Unable to allocate a internal number for the day type '{0}' because there are already {1} day types mapped to this cluster.",
        //    //                    dt.Name, definedDayTypeNumbers.Count()));
        //    //            }
        //    //            dt.ClusterDayTypeMap.PanelDayTypeNumber = availableNumbers.FirstOrDefault();
        //    //        }

        //    //        UpdateTableEntityBaseProperties(dt.ClusterDayTypeMap, sessionData);

        //    //        var savedItem = _clusterDayTypeMapRepository.Add(dt.ClusterDayTypeMap, sessionData, null);
        //    //        existingDayTypeMappings.Add(savedItem);
        //    //    }
        //    //}
        //}


        private void SaveRoleMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasRoleMappingList entity, ISaveParameters saveParams)
        {
            if (entity.RoleIds == null || !entity.RoleIds.Any() || saveParams.Ignore(nameof(entity.RoleIds)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid, RefreshCache = true };
            var existingRoleClusters = _roleClusterRepository.GetAllForClusterUid(sessionData, getParameters);
            var existingRoleIds = new HashSet<Guid>(existingRoleClusters.Select(e => e.RoleId));
            var deleteRoleIds = existingRoleIds.Except(entity.RoleIds);

            foreach (var rid in deleteRoleIds)
            {
                var rc = existingRoleClusters.FirstOrDefault(o => o.RoleId == rid);
                if (rc != null)
                    _roleClusterRepository.Remove(rc.RoleClusterUid, sessionData);
            }

            foreach (var roleId in entity.RoleIds)
            {
                if (!existingRoleIds.Contains(roleId))
                {
                    var roleCluster = new RoleCluster
                    {
                        RoleClusterUid = GuidUtilities.GenerateComb(),
                        ClusterUid = uid,
                        RoleId = roleId,
                        IncludeAllAccessPortals = true,
                        IncludeAllInputDevices = true,
                        IncludeAllOutputDevices = true,
                        IncludeAllInputOutputGroups = true
                    };
                    UpdateTableEntityBaseProperties(roleCluster, sessionData);

                    _roleClusterRepository.Add(roleCluster, sessionData, saveParams);
                }
                else if (existingRoleClusters.FirstOrDefault(o => o.RoleId == roleId && o.ClusterUid == uid) == null)
                {
                    var roleCluster = new RoleCluster
                    {
                        RoleClusterUid = GuidUtilities.GenerateComb(),
                        ClusterUid = uid,
                        RoleId = roleId,
                        IncludeAllAccessPortals = true,
                        IncludeAllInputDevices = true,
                        IncludeAllOutputDevices = true,
                        IncludeAllInputOutputGroups = true
                    };
                    UpdateTableEntityBaseProperties(roleCluster, sessionData);

                    _roleClusterRepository.Add(roleCluster, sessionData, saveParams);
                }
            }
        }


        // Guarantee that required child records exist and create them if necessary
        private void EnsureRequiredChildRecordsExist(Cluster entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            // I/O Groups
            var ioGroups = _ioGroupRepository.GetAllGalaxyInputOutputGroupsForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid });
            var none = ioGroups.Items.FirstOrDefault(g => g.IOGroupNumber == (int)InputOutputGroupNumber.None);
            if (none == null)
            {
                none = new InputOutputGroup();
                none.InputOutputGroupUid = GuidUtilities.GenerateComb();
                none.ClusterUid = entity.ClusterUid;
                none.EntityId = entity.EntityId;
                none.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
                none.IOGroupNumber = (int)GalaxySMS.Common.Enums.InputOutputGroupNumber.None;
                none.LocalIOGroup = false;
                none.Display = SharedResources.InputOutputGroupName_None;
                none.Description = SharedResources.InputOutputGroupName_None_Description;
                none.UniqueResourceName = none.Display;
                UpdateTableEntityBaseProperties(none, sessionData);
                none.RoleIds = entity.RoleIds;

                _ioGroupRepository.Add(none, sessionData, saveParams);

            }

            // Areas
            var areas = _areaRepository.GetAllGalaxyAreasForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid });
            var nocchange = areas.Items.FirstOrDefault(g => g.AreaNumber == (int)AreaNumber.NoChange);
            if (nocchange == null)
            {
                nocchange = new Area
                {
                    AreaUid = GuidUtilities.GenerateComb(),
                    ClusterUid = entity.ClusterUid,
                    EntityId = entity.EntityId,
                    AreaNumber = (int)GalaxySMS.Common.Enums.AreaNumber.NoChange,
                    Display = SharedResources.AreaName_NoChange,
                    Description = SharedResources.AreaName_NoChange_Description
                };
                nocchange.UniqueResourceName = nocchange.Display;
                UpdateTableEntityBaseProperties(nocchange, sessionData);

                _areaRepository.Add(nocchange, sessionData, saveParams);
            }

            var inArea = areas.Items.FirstOrDefault(g => g.AreaNumber == (int)AreaNumber.In);
            if (inArea == null)
            {
                inArea = new Area
                {
                    AreaUid = GuidUtilities.GenerateComb(),
                    ClusterUid = entity.ClusterUid,
                    EntityId = entity.EntityId,
                    AreaNumber = (int)GalaxySMS.Common.Enums.AreaNumber.In,
                    Display = SharedResources.AreaName_In,
                    Description = SharedResources.AreaName_In_Description
                };
                inArea.UniqueResourceName = inArea.Display;
                UpdateTableEntityBaseProperties(inArea, sessionData);

                _areaRepository.Add(inArea, sessionData, saveParams);
            }

            var outArea = areas.Items.FirstOrDefault(g => g.AreaNumber == (int)AreaNumber.Out);
            if (outArea == null)
            {
                outArea = new Area
                {
                    AreaUid = GuidUtilities.GenerateComb(),
                    ClusterUid = entity.ClusterUid,
                    EntityId = entity.EntityId,
                    AreaNumber = (int)GalaxySMS.Common.Enums.AreaNumber.Out,
                    Display = SharedResources.AreaName_Out,
                    Description = SharedResources.AreaName_Out_Description
                };
                outArea.UniqueResourceName = outArea.Display;
                UpdateTableEntityBaseProperties(outArea, sessionData);

                _areaRepository.Add(outArea, sessionData, saveParams);
            }


            // Access Groups
            var accessGroups = _accessGroupRepository.GetAllGalaxyAccessGroupsForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid });
            var noaccess = accessGroups.Items.FirstOrDefault(g => g.AccessGroupNumber == (int)AccessGroupNumber.NoAccess);
            if (noaccess == null)
            {
                noaccess = new AccessGroup
                {
                    AccessGroupUid = GuidUtilities.GenerateComb(),
                    ClusterUid = entity.ClusterUid,
                    EntityId = entity.EntityId,
                    AccessGroupNumber = (int)GalaxySMS.Common.Enums.AccessGroupNumber.NoAccess,
                    Display = SharedResources.AccessGroupName_NoAccess
                };
                noaccess.UniqueResourceName = noaccess.Display;
                noaccess.Description = SharedResources.AccessGroupName_NoAccess_Description;
                noaccess.IsEnabled = true;
                UpdateTableEntityBaseProperties(noaccess, sessionData);

                _accessGroupRepository.Add(noaccess, sessionData, saveParams);
            }

            var unlimited = accessGroups.Items.FirstOrDefault(g => g.AccessGroupNumber == (int)AccessGroupNumber.UnlimitedAccess);
            if (unlimited == null)
            {
                unlimited = new AccessGroup
                {
                    AccessGroupUid = GuidUtilities.GenerateComb(),
                    ClusterUid = entity.ClusterUid,
                    EntityId = entity.EntityId,
                    AccessGroupNumber = (int)GalaxySMS.Common.Enums.AccessGroupNumber.UnlimitedAccess,
                    Display = SharedResources.AccessGroupName_UnlimitedAccess
                };
                unlimited.UniqueResourceName = unlimited.Display;
                unlimited.Description = SharedResources.AccessGroupName_UnlimitedAccess_Description;
                unlimited.IsEnabled = true;
                UpdateTableEntityBaseProperties(unlimited, sessionData);

                _accessGroupRepository.Add(unlimited, sessionData, saveParams);
            }

            var personal = accessGroups.Items.FirstOrDefault(g => g.AccessGroupNumber == (int)AccessGroupNumber.PersonalGroup);
            if (personal == null)
            {
                personal = new AccessGroup
                {
                    AccessGroupUid = GuidUtilities.GenerateComb(),
                    ClusterUid = entity.ClusterUid,
                    EntityId = entity.EntityId,
                    AccessGroupNumber = (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup,
                    IsEnabled = true,
                    Display = SharedResources.AccessGroupName_PersonalDoors
                };
                personal.UniqueResourceName = personal.Display;
                personal.Description = SharedResources.AccessGroupName_PersonalDoors_Description;
                UpdateTableEntityBaseProperties(personal, sessionData);

                _accessGroupRepository.Add(personal, sessionData, saveParams);
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("Cluster", "ClusterUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("Cluster", "ClusterUid", id);
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

        protected override bool IsEntityUnique(Cluster entity)
        {
            var mgr = new IsClusterUniquePDSAManager();
            mgr.Entity.ClusterUid = entity.ClusterUid;
            mgr.Entity.ClusterName = entity.ClusterName;
            mgr.Entity.ClusterNumber = entity.ClusterNumber;
            mgr.Entity.EntityId = entity.EntityId;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("Cluster", "ClusterUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("Cluster", "ClusterUid", id);
            if (count == 0)
                return true;
            return false;
        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertClusterCountPDSAManager();
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

        public int GetAvailableClusterNumber(int clusterGroupId)
        {
            var mgr = new ChooseAvailableClusterNumberPDSAManager { Entity = { ClusterGroupId = clusterGroupId } };
            var results = mgr.BuildCollection();
            if (results != null && results.Count > 0)
                return results[0].ClusterNumber;
            return 0;
        }

        public bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid clusterUid, Guid permissionId, Guid entityId)
        {
            // If no permission is specified, return true to indicate that permission is granted
            if (permissionId == Guid.Empty)
                return true;

            if (!sessionData.IsPermissionCheckPossible)
                return true;

            var mgr = new Cluster_GetUserPermissionPDSAManager();
            mgr.Entity.UserId = sessionData.UserId;
            mgr.Entity.ClusterUid = clusterUid;
            mgr.Entity.PermissionId = permissionId;
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            if (results?.Count > 0)
                return true;

            return false;
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUids()
        {
            return GalaxySMSDatabaseManager.GetAllUidsFromTable("GCS", "Cluster", "ClusterUid");
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new Cluster_GetAllUidsFromRoleIdPDSAManager();
            mgr.Entity.RoleId = roleId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.ClusterUid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndSiteUid(Guid roleId, Guid siteUid)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new Cluster_GetAllUidsFromRoleIdAndSiteUidPDSAManager();
            mgr.Entity.RoleId = roleId;
            mgr.Entity.SiteUid = siteUid;
            var results = mgr.BuildCollection();
            return results.Select(o => o.ClusterUid);
        }


        public IArrayResponse<ClusterTimeScheduleItem> GetClusterTimeScheduleItemsBySchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new ClusterPDSAManager();
                mgr.DataObject.SelectFilter = ClusterPDSAData.SelectFilters.InfoByTimeScheduleUid;
                mgr.Entity.TimeScheduleUid = parameters.UniqueId;
                //mgr.Entity.CultureName = sessionData.UiCulture;
                var items = GetIEnumerablePaged(sessionData, parameters, mgr);
                var returnData = new ArrayResponse<ClusterTimeScheduleItem>()
                {
                    TotalItemCount = items.TotalItemCount,
                    TotalPageCount = items.TotalPageCount,
                    PageItemCount = items.PageItemCount,
                    PageNumber = items.PageNumber,
                    PageSize = items.PageSize
                };
                var dataItems = new List<ClusterTimeScheduleItem>();

                foreach (var i in items.Items)
                {
                    dataItems.Add(i.ToClusterTimeScheduleItem());
                }

                returnData.Items = dataItems.ToArray();
                return returnData;
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
        public bool IsClusterAddressUnique(Cluster entity)
        {
            var mgr = new IsClusterAddressUniquePDSAManager();
            mgr.Entity.ClusterNumber = entity.ClusterNumber;
            mgr.Entity.ClusterUid = entity.ClusterUid;
            mgr.Entity.ClusterGroupId = entity.ClusterGroupId;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        public bool IsClusterNameUnique(Cluster entity)
        {
            var mgr = new IsClusterNameUniquePDSAManager();
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.ClusterUid = entity.ClusterUid;
            mgr.Entity.ClusterName = entity.ClusterName;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }


    }
}
