using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Constants;
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
using GalaxySMS.Data.Support;

namespace GalaxySMS.Data
{
    [Export(typeof(IAccessPortalRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessPortalRepository : PagedDataRepositoryBase<AccessPortal>, IAccessPortalRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import] private IAccessPortalEntityMapRepository _entityMapRepository;
        [Import] private IAccessPortalGalaxyHardwareAddressRepository _accessPortalGalaxyHardwareAddressRepository;
        [Import] private IAccessPortalTypeRepository _accessPortalTypeRepository;
        [Import] private IAccessPortalPropertiesRepository _accessPortalPropertiesRepository;
        [Import] private IAccessPortalAreaRepository _accessPortalAreaRepository;
        [Import] private IAccessPortalTimeScheduleRepository _accessPortalTimeScheduleRepository;
        [Import] private IAccessPortalAlertEventRepository _accessPortalAlertEventRepository;
        [Import] private IAccessPortalAuxiliaryOutputRepository _accessPortalAuxiliaryOutputRepository;
        [Import] private IAccessPortalNoteRepository _accessPortalNoteRepository;
        [Import] private INoteRepository _noteRepository;
        [Import] private IAccessGroupAccessPortalRepository _accessGroupAccessPortalRepository;
        [Import] private IGalaxyAccessGroupRepository _accessGroupRepository;
        [Import] private IAccessPortalCommandRepository _accessPortalCommandRepository;
        [Import] private IGalaxyAreaRepository _galaxyAreaRepository;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private IRoleAccessPortalRepository _roleAccessPortalRepository;
        private InputOutputGroup _noIog;
        private IEnumerable<InputOutputGroup> _allIoGroups;

        protected override AccessPortal AddEntity(AccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.AccessPortalUid,
                            PermissionIds.GalaxySMSDataAccessPermission
                                .AccessPortalCanAddId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to add access portal {entity.AccessPortalUid}");
                    }
                }

                _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new AccessPortalPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.AccessPortalUid, entity, saveParams);
                    SaveRoleMappings(sessionData, entity.AccessPortalUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.AccessPortalUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::AddEntity", ex);
                throw;
            }
        }

        protected override AccessPortal UpdateEntity(AccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.AccessPortalUid,
                            PermissionIds.GalaxySMSDataAccessPermission
                                .AccessPortalCanUpdateId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update access portal {entity.AccessPortalUid}");
                    }
                }

                var originalEntity = GetEntityByGuidId(entity.AccessPortalUid, sessionData, null);

                if (originalEntity != null && originalEntity.EntityId != entity.EntityId)
                {
                    if (!DoesUserHavePermission(sessionData, entity.AccessPortalUid, PermissionIds.GalaxySMSDataAccessPermission.AccessPortalCanUpdateId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to update access portal {entity.AccessPortalUid}");
                    }

                }
                if (saveParams.SavePhoto)
                {
                    if (entity.gcsBinaryResource?.BinaryResource == null && originalEntity.BinaryResourceUid != Guid.Empty)
                    {
                        if (originalEntity.BinaryResourceUid.HasValue)
                            _binaryResourceRepository.Remove(originalEntity.BinaryResourceUid.Value, sessionData);
                        entity.BinaryResourceUid = null;
                        entity.gcsBinaryResource = null;
                    }
                    else
                    {
                        if (entity.gcsBinaryResource?.HasBeenModified == true)
                            _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                    }
                }

                var mgr = new AccessPortalPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.AccessPortalUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;
                    entity.IsEnabled = mgr.Entity.IsEnabled;

                    // if AccessPortalTypeUid is = Guid.Empty or null, then use the value from the original record
                    entity.AccessPortalTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessPortalTypeUid, entity.AccessPortalTypeUid);

                    // if SiteUid is = Guid.Empty or null, then use the value from the original record
                    entity.SiteUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.SiteUid, entity.SiteUid);

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);

                    // if BinaryResourceUid is = Guid.Empty or null, then use the value from the original record
                    entity.BinaryResourceUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.BinaryResourceUid, entity.BinaryResourceUid);

                    // if ClusterUid is = Guid.Empty or null, then use the value from the original record
                    entity.ClusterUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.ClusterUid, entity.ClusterUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.AccessPortalUid, entity, saveParams);
                        SaveRoleMappings(sessionData, entity.AccessPortalUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.AccessPortalUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        var getParams = new GetParametersWithPhoto() { IncludeMemberCollections = true, IncludePhoto = true, IncludeHardwareAddress = true };
                        getParams.ExcludeMemberCollectionSettings.AddRange(saveParams.IgnoreProperties);
                        updatedEntity = GetEntityByGuidId(entity.AccessPortalUid, sessionData, getParams);
                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);

                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.AccessPortalUid} not found");

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(AccessPortal entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.AccessPortalUid);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var entityId = GetEntityId(id);
                if (!DoesUserHavePermission(sessionData, id, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.AccessPermissionCanDeleteId, entityId))
                {
                    throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to delete access portal {id}");
                }
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new AccessPortalPDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id);
                // must read the original record from the database so the PDSA object can detect changes
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<AccessPortal> GetFilteredAccessPortals(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessPortalPDSAManager mgr)
        {
            IEnumerable<AccessPortal> entities = new List<AccessPortal>();
            SetSortColumnAndOrder(getParameters, mgr);
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                this.Log().Info($"AccessPortalRepository.GetFilteredAccessPortals - pdsaEntities {pdsaEntities.Count()} items.");

                //entities = mgr.ConvertPDSACollection(pdsaEntities);
                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a ap, creating RoleAccessPortal records
                //      2) When saving Role, creating RoleAccessPortal records
                // 
                if (sessionData == null || sessionData.UserId == Guid.Empty)
                {
                    entities = mgr.ConvertPDSACollection(pdsaEntities);
                }
                else
                {
                    var filteredAccessPortalUids = GetFilteredAccessPortalUids(sessionData);
                    var pdsaItems = pdsaEntities.Where(p => filteredAccessPortalUids.Any(p2 => p2.AccessPortalUid == p.AccessPortalUid));

                    entities = mgr.ConvertPDSACollection(pdsaItems);
                }
            }
            this.Log().Info($"AccessPortalRepository.GetFilteredAccessPortals - entities {entities.Count()} items.");
            return entities;
        }

        private IEnumerable<AccessPortal> GetFilteredAccessPortals(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters, AccessPortalPDSAManager mgr)
        {
            IEnumerable<AccessPortal> entities = new List<AccessPortal>();
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                entities = mgr.ConvertPDSACollection(pdsaEntities);
                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a ap, creating RoleAccessPortal records
                //      2) When saving Role, creating RoleAccessPortal records
                // 
                //if (sessionData == null || sessionData.UserId == Guid.Empty)
                //{
                //    entities = mgr.ConvertPDSACollection(pdsaEntities);
                //}
                //else
                //{
                //    var filteredAccessPortalUids = GetFilteredAccessPortalUids(sessionData);
                //    var pdsaItems = pdsaEntities.Where(p => filteredAccessPortalUids.Any(p2 => p2.AccessPortalUid == p.AccessPortalUid));

                //    entities = mgr.ConvertPDSACollection(pdsaItems);
                //}
            }
            return entities;
        }
        private IArrayResponse<AccessPortal> GetFilteredAccessPortalsPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters, AccessPortalPDSAManager mgr)
        {
            SetSortColumnAndOrder(getParameters, mgr);
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                var first = pdsaEntities.FirstOrDefault();
                var totalRowCount = 0;
                if (first != null)
                {
                    totalRowCount = first.TotalRowCount;
                }
                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a ap, creating RoleAccessPortal records
                //      2) When saving Role, creating RoleAccessPortal records
                // 
                //if (sessionData == null || sessionData.UserId == Guid.Empty)
                //{
                //    entities = mgr.ConvertPDSACollection(pdsaEntities);
                //}
                //else
                //{
                //    var filteredAccessPortalUids = GetFilteredAccessPortalUids(sessionData);
                //    var pdsaItems = pdsaEntities.Where(p => filteredAccessPortalUids.Any(p2 => p2.AccessPortalUid == p.AccessPortalUid));

                //    entities = mgr.ConvertPDSACollection(pdsaItems);
                //}
                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalRowCount);
            }
            return new ArrayResponse<AccessPortal>();
        }

        private EntityLayer.AccessPortalUids_SelectForUserIdPDSACollection GetFilteredAccessPortalUids(IApplicationUserSessionDataHeader sessionData)
        {
            var filteredMgr = new AccessPortalUids_SelectForUserIdPDSAManager();
            filteredMgr.Entity.UserId = sessionData.UserId;
            var filteredAccessPortalUids = filteredMgr.BuildCollection();
            return filteredAccessPortalUids;
        }

        private IEnumerable<AccessPortal> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessPortalPDSAManager mgr)
        {
            var entities = GetFilteredAccessPortals(sessionData, getParameters, mgr);
            var isNodeActive = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_AccessPortal.IsNodeActive);
            if (isNodeActive.HasValue)
            {
                if (getParameters == null)
                    getParameters = new GetParametersWithPhoto();
                getParameters.IncludeHardwareAddress = true;
            }
            foreach (var entity in entities)
            {
                if (isNodeActive.HasValue)
                {
                    if (entity.IsNodeActive != isNodeActive.Value)
                        continue;
                }

                if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludePhoto || getParameters.IncludeHardwareAddress || getParameters.IncludeCommands)
                    FillMemberCollections(entity, sessionData, getParameters);
            }

            if (isNodeActive.HasValue)
            {
                return entities.Where(o => o.GalaxyHardwareAddress.IsNodeActive == isNodeActive.Value && o.IsNodeActive == isNodeActive.Value).ToCollection();
            }
            return entities;
        }

        private ArrayResponse<AccessPortal> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessPortalPDSAManager mgr)
        {
            var entities = GetFilteredAccessPortals(sessionData, getParameters, mgr);

            this.Log().Info($"AccessPortalRepository.GetIEnumerablePaged - {entities?.Count()} items.");

            var totalCount = 0;
            var isNodeActive = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_AccessPortal.IsNodeActive);
            if (isNodeActive.HasValue)
            {
                if (getParameters == null)
                    getParameters = new GetParametersWithPhoto();
                getParameters.IncludeHardwareAddress = true;
            }

            foreach (var entity in entities)
            {
                if (totalCount == 0)
                    totalCount = entity.TotalRowCount;
                if (isNodeActive.HasValue)
                {
                    if (entity.IsNodeActive != isNodeActive.Value)
                        continue;
                }

                if (getParameters.IncludeMemberCollections || getParameters.IncludePhoto || getParameters.IncludeHardwareAddress || getParameters.IncludeCommands)
                    FillMemberCollections(entity, sessionData, getParameters);
            }

            if (isNodeActive.HasValue)
            {
                var activeEntities = entities.Where(o => o.GalaxyHardwareAddress.IsNodeActive == isNodeActive.Value && o.IsNodeActive == isNodeActive.Value).ToCollection();
                this.Log().Info($"AccessPortalRepository.GetIEnumerablePaged - activeEntities {activeEntities?.Count()} items.");

                return ArrayResponseHelpers.ToArrayResponse(activeEntities, getParameters.PageNumber, getParameters.PageSize, activeEntities.Count);
            }

            this.Log().Info($"AccessPortalRepository.GetIEnumerablePaged - entities {entities?.Count()} items.");
            return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
        }

        private IEnumerable<AccessPortalListItem> GetIEnumerableListItem(IApplicationUserSessionDataHeader sessionData,
            IGetParametersBase getParameters, AccessPortalPDSAManager mgr)
        {
            var accessPortals = GetFilteredAccessPortals(sessionData, getParameters, mgr);

            if (accessPortals != null)
            {
                var entities = new List<AccessPortalListItem>();
                foreach (var e in accessPortals)
                {
                    var apli = new AccessPortalListItem()
                    {
                        EntityId = e.EntityId,
                        UniqueUid = e.AccessPortalUid,
                        Name = e.PortalName,
                        ClusterGroupId = e.ClusterGroupId,
                        ClusterNumber = e.ClusterNumber,
                        PanelNumber = e.PanelNumber,
                        BoardNumber = e.BoardNumber,
                        SectionNumber = e.SectionNumber,
                        ModuleNumber = e.ModuleNumber,
                        NodeNumber = e.NodeNumber,
                        PanelName = e.PanelName
                    };

                    switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)e.InterfaceBoardTypeCode)
                    {
                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                            apli.NodeNumber = 0;
                            break;

                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                            break;
                    }
                    entities.Add(apli);
                }
                return entities;
            }
            return null;
        }

        private IArrayResponse<AccessPortalListItem> GetIEnumerableListItemPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersBase getParameters, AccessPortalPDSAManager mgr)
        {
            var accessPortals = GetFilteredAccessPortalsPaged(sessionData, getParameters, mgr);

            if (accessPortals != null)
            {
                var entities = new List<AccessPortalListItem>();
                var ap = accessPortals.Items.FirstOrDefault();
                foreach (var e in accessPortals.Items)
                {
                    var apli = new AccessPortalListItem()
                    {
                        EntityId = e.EntityId,
                        UniqueUid = e.AccessPortalUid,
                        Name = e.PortalName,
                        ClusterGroupId = e.ClusterGroupId,
                        ClusterNumber = e.ClusterNumber,
                        PanelNumber = e.PanelNumber,
                        BoardNumber = e.BoardNumber,
                        SectionNumber = e.SectionNumber,
                        ModuleNumber = e.ModuleNumber,
                        NodeNumber = e.NodeNumber,
                    };

                    switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)e.InterfaceBoardTypeCode)
                    {
                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                            apli.NodeNumber = 0;
                            break;

                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                            break;
                    }
                    entities.Add(apli);
                }
                if (ap != null)
                    return ArrayResponseHelpers.ToArrayResponse(entities, accessPortals.PageNumber, accessPortals.PageSize, accessPortals.TotalItemCount);
            }
            return new ArrayResponse<AccessPortalListItem>();
        }

        protected override IEnumerable<AccessPortal> GetEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId == Guid.Empty)
                    getParameters.UniqueId = sessionData.CurrentEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<AccessPortal> GetAllEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IArrayResponse<AccessPortal> GetAllAccessPortalsForEntity(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }

        public IArrayResponse<AccessPortal> GetAllAccessPortalsForRegion(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ByRegionUid;
                mgr.Entity.RegionUid = getParameters.UniqueId;
                SetSortColumnAndOrder(getParameters, mgr);
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAllAccessPortalsForRegion", ex);
                throw;
            }
        }

        public IArrayResponse<AccessPortal> GetAllAccessPortalsForSite(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.BySiteUid;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.Entity.SiteUid = getParameters.UniqueId;
                else
                    mgr.Entity.SiteUid = sessionData.CurrentSiteId;
                SetSortColumnAndOrder(getParameters, mgr);
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAllAccessPortalsForSite", ex);
                throw;
            }
        }

        public IEnumerable<AccessPortalSelectionItemBasic> GetAllAccessPortalSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortal_SelectionListForEntityAndClusterPDSAManager();
                mgr.Entity.EntityId = getParameters.CurrentEntityId;
                mgr.Entity.ClusterUid = getParameters.ClusterUid;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<AccessPortalSelectionItemBasic>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new AccessPortalSelectionItemBasic();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        if (getParameters.IncludeMemberCollections || getParameters.IncludePhoto)
                        {
                            FillMemberCollections(newEntity, sessionData, getParameters);
                        }
                        if (getParameters.IncludePhoto == false && newEntity.Photo != null)
                            newEntity.Photo = null;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAllAccessPortalGroupSelectionItemsForEntityAndCluster", ex);
                throw;
            }
        }

        public AccessPortal_GetHardwareInformation GetHardwareInformation(IApplicationUserSessionDataHeader sessionData, Guid accessPortalUid)
        {
            try
            {
                var apHardwareInfoMgr = new AccessPortal_GetHardwareInformationPDSAManager();
                apHardwareInfoMgr.Entity.AccessPortalUid = accessPortalUid;
                var apHardwareInfo = apHardwareInfoMgr.BuildCollection();
                if (apHardwareInfo.Count == 1)
                {
                    var convertedEntity = new AccessPortal_GetHardwareInformation();
                    SimpleMapper.PropertyMap(apHardwareInfo[0], convertedEntity);
                    return convertedEntity;
                }
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetHardwareInformation", ex);
                throw;
            }
            return null;
        }

        public IArrayResponse<AccessPortal> GetAllAccessPortalsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ByClusterUid;
                mgr.Entity.ClusterUid = getParameters.UniqueId;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAllAccessPortalsForCluster", ex);
                throw;
            }
        }

        public IArrayResponse<AccessPortal> GetAllAccessPortalsForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                if (getParameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ByGalaxyPanelUid;
                    mgr.Entity.GalaxyPanelUid = getParameters.UniqueId;
                }
                else
                {
                    mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ByGalaxyPanelAddress;
                    mgr.Entity.ClusterGroupId = getParameters.ClusterGroupId;
                    mgr.Entity.ClusterNumber = getParameters.ClusterNumber;
                    mgr.Entity.PanelNumber = getParameters.PanelNumber;
                }
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAllAccessPortalsForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<AccessPortal> GetByNameOrComments(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                if (getParameters.GetOption(GetOptions_AccessPortal.SearchIncludesComments) == true)
                    mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ByNameOrComments;
                else
                    mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ByName;

                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.PortalName = getParameters.GetString;
                SetSortColumnAndOrder(getParameters, mgr);
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAllAccessPortalsForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<AccessPortalListItem> GetListItemsByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                if (getParameters.GetOption(GetOptions_AccessPortal.SearchIncludesComments) == true)
                    mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ListBoxByNameOrComments;
                else
                    mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ListBoxByName;

                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.PortalName = getParameters.GetString;

                var data = GetIEnumerableListItemPaged(sessionData, getParameters, mgr);
                if (getParameters.IncludeMemberCollections)
                {
                    if (!getParameters.IsExcluded(nameof(AccessPortalListItem.AlertEventAcknowledgeData)))
                    {
                        if (getParameters.UniqueId != Guid.Empty)
                        {
                            var alertEventMgr = new AccessPortal_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.GalaxyPanelUid = getParameters.UniqueId;
                            var pdsaEntities = alertEventMgr.BuildCollection();

                            foreach (var ap in data.Items)
                            {   // Get alarm event data
                                foreach (var e in pdsaEntities.Where(o => o.AccessPortalUid == ap.UniqueUid))
                                    ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                            }
                        }
                        else
                        {
                            foreach (var ap in data.Items)
                            {   // Get alarm event data
                                var alertEventMgr = new AccessPortal_GetAlertEventAcknowledgeDataPDSAManager();
                                alertEventMgr.Entity.AccessPortalUid = ap.UniqueUid;
                                var pdsaEntities = alertEventMgr.BuildCollection();
                                foreach (var e in pdsaEntities.Where(o => o.AccessPortalUid == ap.UniqueUid))
                                    ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                            }

                        }
                    }
                }
                return data;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAccessPortalListForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<AccessPortalListItem> GetAccessPortalListForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                if (parameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ListBoxByGalaxyPanelUid;
                    mgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                }
                else
                {
                    mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ListBoxByGalaxyPanelAddress;
                    mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                    mgr.Entity.ClusterNumber = (short)parameters.ClusterNumber;
                    mgr.Entity.PanelNumber = (short)parameters.PanelNumber;
                }
                var data = GetIEnumerableListItemPaged(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {
                    if (parameters.UniqueId != Guid.Empty)
                    {
                        var alertEventMgr = new AccessPortal_GetAlertEventAcknowledgeDataPDSAManager();
                        alertEventMgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                        var pdsaEntities = alertEventMgr.BuildCollection();

                        foreach (var ap in data.Items)
                        {   // Get alarm event data
                            foreach (var e in pdsaEntities.Where(o => o.AccessPortalUid == ap.UniqueUid))
                                ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                        }
                    }
                    else
                    {
                        foreach (var ap in data.Items)
                        {   // Get alarm event data
                            var alertEventMgr = new AccessPortal_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.AccessPortalUid = ap.UniqueUid;
                            var pdsaEntities = alertEventMgr.BuildCollection();
                            foreach (var e in pdsaEntities.Where(o => o.AccessPortalUid == ap.UniqueUid))
                                ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                        }

                    }
                }
                return data;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAccessPortalListForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<AccessPortalListItem> GetAccessPortalListItemsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ListBoxByClusterUid;
                mgr.Entity.ClusterUid = parameters.ClusterUid;

                var data = GetIEnumerableListItemPaged(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {
                    if (!parameters.IsExcluded(nameof(AccessPortalListItem.AlertEventAcknowledgeData)))
                    {
                        if (parameters.UniqueId != Guid.Empty)
                        {
                            var alertEventMgr = new AccessPortal_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                            var pdsaEntities = alertEventMgr.BuildCollection();

                            foreach (var ap in data.Items)
                            {   // Get alarm event data
                                foreach (var e in pdsaEntities.Where(o => o.AccessPortalUid == ap.UniqueUid))
                                    ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                            }
                        }
                        else
                        {
                            foreach (var ap in data.Items)
                            {   // Get alarm event data
                                var alertEventMgr = new AccessPortal_GetAlertEventAcknowledgeDataPDSAManager();
                                alertEventMgr.Entity.AccessPortalUid = ap.UniqueUid;
                                var pdsaEntities = alertEventMgr.BuildCollection();
                                foreach (var e in pdsaEntities.Where(o => o.AccessPortalUid == ap.UniqueUid))
                                    ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                            }

                        }
                    }
                }
                return data;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAccessPortalListForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<AccessPortalListItem> GetAccessPortalsByNameAndSite(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ListBySiteUidAndName;
                mgr.Entity.SiteUid = parameters.GetGuid;
                mgr.Entity.PortalName = parameters.GetString;

                var data = GetIEnumerableListItemPaged(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {
                    if (!parameters.IsExcluded(nameof(AccessPortalListItem.AlertEventAcknowledgeData)))
                    {
                        if (parameters.UniqueId != Guid.Empty)
                        {
                            var alertEventMgr = new AccessPortal_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                            var pdsaEntities = alertEventMgr.BuildCollection();

                            foreach (var ap in data.Items)
                            {   // Get alarm event data
                                foreach (var e in pdsaEntities.Where(o => o.AccessPortalUid == ap.UniqueUid))
                                    ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                            }
                        }
                        else
                        {
                            foreach (var ap in data.Items)
                            {   // Get alarm event data
                                var alertEventMgr = new AccessPortal_GetAlertEventAcknowledgeDataPDSAManager();
                                alertEventMgr.Entity.AccessPortalUid = ap.UniqueUid;
                                var pdsaEntities = alertEventMgr.BuildCollection();
                                foreach (var e in pdsaEntities.Where(o => o.AccessPortalUid == ap.UniqueUid))
                                    ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                            }

                        }
                    }
                }
                return data;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAccessPortalListForGalaxyPanel", ex);
                throw;
            }
        }

        public AccessPortalListItem GetAccessPortalListItem(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ListBoxByPrimaryKey;
                mgr.Entity.AccessPortalUid = parameters.UniqueId;

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var e = pdsaEntities.FirstOrDefault();
                    if (e != null)
                    {
                        if (!DoesUserHavePermission(sessionData, e.AccessPortalUid, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.AccessPortalCanViewId, e.EntityId))
                        {
                            throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to view access portal {e.PortalName}");
                        }

                        var apli = new AccessPortalListItem()
                        {
                            EntityId = e.EntityId,
                            UniqueUid = e.AccessPortalUid,
                            Name = e.PortalName,
                            ClusterGroupId = e.ClusterGroupId,
                            ClusterNumber = e.ClusterNumber,
                            PanelNumber = e.PanelNumber,
                            BoardNumber = e.BoardNumber,
                            SectionNumber = e.SectionNumber,
                            ModuleNumber = e.ModuleNumber,
                            NodeNumber = e.NodeNumber,
                        };

                        switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)e.InterfaceBoardTypeCode)
                        {
                            case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                            case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                                apli.NodeNumber = 0;
                                break;

                            case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                            case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                                break;
                        }

                        if (parameters.IncludeMemberCollections)
                        {
                            if (apli.UniqueUid != Guid.Empty)
                            {
                                var alertEventMgr = new AccessPortal_GetAlertEventAcknowledgeDataPDSAManager();
                                alertEventMgr.Entity.AccessPortalUid = apli.UniqueUid;
                                var pdsaAlertEntities = alertEventMgr.BuildCollection();
                                foreach (var alert in pdsaAlertEntities.Where(o => o.AccessPortalUid == apli.UniqueUid))
                                    apli.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(alert));
                            }
                        }

                        return apli;
                    }
                    return null;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        public IEnumerable<Guid> GetAccessPortalUidsForInterfaceBoardSection(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalGalaxyHardwareAddressViewPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalGalaxyHardwareAddressViewPDSAData.SelectFilters.AccessPortalUid;
                mgr.DataObject.WhereFilter = AccessPortalGalaxyHardwareAddressViewPDSAData.WhereFilters.GalaxyInterfaceBoardSectionUid;
                mgr.DataObject.OrderByFilter = AccessPortalGalaxyHardwareAddressViewPDSAData.OrderByFilters.PhysicalAddress;
                mgr.Entity.GalaxyInterfaceBoardSectionUid = getParameters.UniqueId;
                var results = mgr.BuildCollection();
                return results.Select(i => i.AccessPortalUid).ToCollection();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAccessPortalUidsForInterfaceBoardSection", ex);
                throw;
            }

        }

        protected override AccessPortal GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override AccessPortal GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    if (!DoesUserHavePermission(sessionData, mgr.Entity.AccessPortalUid, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.AccessPortalCanViewId, mgr.Entity.EntityId))
                    {
                        throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to view access portal {mgr.Entity.PortalName}");
                    }

                    AccessPortal result = new AccessPortal();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (mgr.Entity.LastEventTime > DateTimeOffset.Now.MinSqlDateTime())
                    {
                        result.LastUsageData.Time = mgr.Entity.LastEventTime;
                    }
                    if (mgr.Entity.LastAccessGrantedTime > DateTimeOffset.Now.MinSqlDateTime())
                    {
                        result.LastUsageData.AccessGrantedTime = mgr.Entity.LastAccessGrantedTime;
                    }

                    if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludeHardwareAddress || getParameters.IncludePhoto || getParameters.IncludeCommands)
                        FillMemberCollections(result, sessionData, getParameters);
                    if (getParameters == null || getParameters.IncludeMemberCollections == false)
                    {
                        result.Properties = null;
                    }
                    if (getParameters == null || getParameters.IncludeHardwareAddress == false)
                    {
                        result.GalaxyHardwareAddress = null;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        public AccessPortal_PanelLoadData GetAccessPortalPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortal_GetPanelLoadDataByAccessPortalUidPDSAManager();
                mgr.Entity.AccessPortalUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null && result.Count == 1)
                {
                    var returnData = new AccessPortal_PanelLoadData();
                    SimpleMapper.PropertyMap(result[0], returnData);
                    var agManager = new AccessGroupAccessPortal_GetPanelLoadDataByAccessPortalUidPDSAManager();
                    agManager.Entity.AccessPortalUid = getParameters.UniqueId;

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAccessPortalPanelLoadData", ex);
                throw;
            }
        }

        public IEnumerable<AccessPortal_PanelLoadData> GetAccessPortalsPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortal_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSAManager();
                mgr.Entity.GalaxyInterfaceBoardSectionUid = getParameters.UniqueId;
                //                var result = mgr.BuildCollection();
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<AccessPortal_PanelLoadData>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new AccessPortal_PanelLoadData();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        var agManager = new AccessGroupAccessPortal_GetPanelLoadDataByAccessPortalUidPDSAManager();
                        agManager.Entity.AccessPortalUid = newEntity.AccessPortalUid;

                        var accessGroupData = agManager.BuildCollection();
                        if (accessGroupData != null && accessGroupData.Count > 0)
                        {
                            foreach (var agData in accessGroupData)
                            {
                                var newAgData = new AccessGroupAccessPortal_PanelLoadData();
                                SimpleMapper.PropertyMap(agData, newAgData);
                                newEntity.AccessGroupData.Add(newAgData);
                            }
                        }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAllAccessPortalsForGalaxyPanel", ex);
                throw;
            }
        }

        public IEnumerable<AccessPortal_PanelLoadData> GetModifiedPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var results = new List<AccessPortal_PanelLoadData>();
                var mgr = new AccessPortal_GetPanelLoadDataChangesByCpuUidPDSAManager();
                mgr.Entity.CpuUid = getParameters.UniqueId;
                mgr.Entity.ClusterGroupId = getParameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = getParameters.ClusterNumber;
                mgr.Entity.PanelNumber = getParameters.PanelNumber;
                mgr.Entity.CpuNumber = getParameters.GetInt16;
                mgr.Entity.ServerAddress = getParameters.GetString;
                mgr.Entity.IsConnected = true;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                    {
                        var newEntity = new AccessPortal_PanelLoadData();
                        SimpleMapper.PropertyMap(i, newEntity);

                        results.Add(newEntity);
                    }
                    return results;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetCredentialPanelLoadDataForCluster", ex);
                throw;
            }
        }

        public IArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters)
        {
            try
            {
                var languageRepo = _dataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();
                var lang = languageRepo.Get(parameters.LanguageUid, sessionData, new GetParametersWithPhoto());

                var minSqlDate = DateTimeOffset.Now.MinSqlDateTime();
                var maxSqlDate = DateTimeOffset.Now.MaxSqlDateTime();

                if (parameters.StartDateTime < minSqlDate || parameters.StartDateTime > maxSqlDate)
                    parameters.StartDateTime = minSqlDate;

                if (parameters.EndDateTime < minSqlDate || parameters.EndDateTime > maxSqlDate)
                    parameters.EndDateTime = maxSqlDate;

                var results = new List<ActivityHistoryEvent>();
                var mgr = new select_AccessPortalActivityHistoryPDSAManager
                {
                    Entity =
                    {
                        EntityId = parameters.CurrentEntityId,
                        DeviceUid = parameters.AccessPortalUid,
                        PersonUid = parameters.PersonUid,
                        CredentialUid = parameters.CredentialUid,
                        StartDateTime = parameters.StartDateTime,
                        EndDateTime = parameters.EndDateTime,
                        PageNumber = parameters.PageNumber,
                        PageSize = parameters.PageSize,
                        MaxResults = parameters.MaxResults
                    }
                };

                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;

                mgr.Entity.CultureName = lang != null ? lang.CultureName : GalaxySMS.Common.Constants.LanguageCultures.EnglishUs;

                var result = mgr.BuildCollection();
                if (result != null)
                {
                    var totalCount = 0;
                    foreach (var i in result)
                    {
                        if (totalCount == 0)
                            totalCount = i.TotalRecordCount;
                        var newEntity = new ActivityHistoryEvent();
                        SimpleMapper.PropertyMap(i, newEntity);
                        //newEntity.ForeColorHex = $"#{newEntity.ForeColor & 0xFFFFFF:X6}";
                        results.Add(newEntity);
                    }
                    return ArrayResponseHelpers.ToArrayResponse(results, parameters.PageNumber, parameters.PageSize, totalCount);
                }
                return new ArrayResponse<ActivityHistoryEvent>();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetCredentialPanelLoadDataForCluster", ex);
                throw;
            }
        }

        public void UpdateGalaxyAccessPortalLastLoadedDate(Guid cpuUid, Guid accessPortalUid)
        {
            try
            {
                var mgr = new AccessPortalLoadToCpu_SaveLastLoadedDatePDSAManager
                {
                    Entity =
                    {
                        CpuUid = cpuUid,
                        AccessPortalUid = accessPortalUid
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

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData,
            AccessPortal originalEntity, AccessPortal newEntity, string auditXml)
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
                            throw new ArgumentNullException("newEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        List<String> propertiesToIgnore = new List<string>
                        {
                            "UpdateDate",
                            "ConcurrencyValue"
                        };

                        propertiesToIgnore.Add("EntityIds");
                        propertiesToIgnore.Add("MappedEntitiesPermissionLevels");
                        propertiesToIgnore.Add("Areas");
                        propertiesToIgnore.Add("Schedules");
                        propertiesToIgnore.Add("AlertEvents");
                        propertiesToIgnore.Add("AuxiliaryOutputs");
                        propertiesToIgnore.Add("Notes");
                        propertiesToIgnore.Add("AccessGroupAccessPortals");
                        propertiesToIgnore.Add("Commands");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessPortalUid;
                        mgr.Entity.RecordTag = newEntity.AccessPortalUid.ToString();
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;

                        if (string.IsNullOrEmpty(auditXml) == false)
                        {
                            mgr.Entity.AuditXml = auditXml;
                            mgr.Execute();
                        }


                        mgr.Entity.AuditXml = null;

                        SimpleObjectDifferenceDetector.CompareResults differences =
                            SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity, propertiesToIgnore);
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
                            throw new ArgumentNullException("newEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessPortalUid;
                        mgr.Entity.RecordTag = newEntity.AccessPortalUid.ToString();
                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AccessPortalUid;
                        mgr.Entity.RecordTag = originalEntity.AccessPortalUid.ToString();
                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {
                // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::SaveAuditData", ex);
                                                                                                                        //throw;
            }
        }

        protected override void FillMemberCollections(AccessPortal entity, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                return;

            if (getParameters.IncludePhoto)
            {
                if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
                {
                    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData,
                        null);
                }
            }

            if (getParameters.IncludeHardwareAddress)
            {
                var apHardwareInfoMgr = new AccessPortal_GetHardwareInformationPDSAManager();
                apHardwareInfoMgr.Entity.AccessPortalUid = entity.AccessPortalUid;
                var apHardwareInfo = apHardwareInfoMgr.BuildCollection();
                if (apHardwareInfo.Count == 1)
                {
                    entity.ClusterUid = apHardwareInfo[0].ClusterUid;
                    entity.GalaxyPanelUid = apHardwareInfo[0].GalaxyPanelUid;
                    entity.GalaxyHardwareAddress.IsNodeActive = apHardwareInfo[0].IsNodeActive;
                    entity.GalaxyHardwareAddress = new AccessPortalGalaxyHardwareAddress()
                    {
                        GalaxyInterfaceBoardSectionNodeUid = apHardwareInfo[0].GalaxyInterfaceBoardSectionNodeUid
                    };
                }
            }

            if (getParameters.IncludeCommands)
            {
                var getP = new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid, IncludePhoto = false };
                var cmds = _accessPortalCommandRepository.GetAllAccessPortalCommandsForAccessPortal(sessionData, getP).ToCollection();

                // Now determine if the access portal Relay2 mode is Scheduled. If not, take out the relay2 on / off commands
                var apData = this.GetAccessPortalPanelLoadData(sessionData, getP);
                if (apData != null)
                {
                    if ((GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode)apData.Relay2ModeCode == GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode.Follows ||
                        (GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode)apData.Relay2ModeCode == GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode.Latching ||
                        (GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode)apData.Relay2ModeCode == GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode.Timeout)
                    {
                        var cmd = cmds.FirstOrDefault(o => o.AccessPortalCommandUid == Common.Constants.AccessPortalCommandIds.AuxRelayOn);
                        if (cmd != null)
                            cmds.Remove(cmd);
                    }
                    if ((GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode)apData.Relay2ModeCode == GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode.Timeout)
                    {
                        var cmd = cmds.FirstOrDefault(o => o.AccessPortalCommandUid == Common.Constants.AccessPortalCommandIds.AuxRelayOff);
                        if (cmd != null)
                            cmds.Remove(cmd);
                    }
                }

                // Check role permissions and access portal filters here
                var filterMgr = new AccessPortalFilters_SelectForUserIdPDSAManager();
                filterMgr.Entity.AccessPortalUid = entity.AccessPortalUid;
                filterMgr.Entity.UserId = sessionData.UserId;
                var filters = filterMgr.BuildCollection();

                var deleteTheseCommands = new List<AccessPortalCommand>();
                foreach (var cmd in cmds)
                {
                    var permissionUid = Guid.Empty;
                    if (cmd.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Pulse)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.UnlockMomentarily;
                    }
                    else if (cmd.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Unlock)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.Unlock;
                    }
                    else if (cmd.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Lock)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.Lock;
                    }
                    else if (cmd.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Enable)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.Enable;
                    }
                    else if (cmd.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.Disable)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.Disable;
                    }
                    else if (cmd.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.AuxRelayOff)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.Relay2Off;
                    }
                    else if (cmd.AccessPortalCommandUid == GalaxySMS.Common.Constants.AccessPortalCommandIds.AuxRelayOn)
                    {
                        permissionUid = GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.Relay2On;
                    }
                    var filter = filters.FirstOrDefault(o => o.PermissionId == permissionUid);
                    if (filter == null)
                        deleteTheseCommands.Add(cmd);
                }

                foreach (var cmd in deleteTheseCommands)
                {
                    entity.DisabledCommandIds.Add(cmd.AccessPortalCommandUid);
                    cmds.Remove(cmd);
                }

                entity.Commands = cmds;
            }

            if (getParameters.IncludeMemberCollections)
            {
                var p = new GetParametersWithPhoto(getParameters as GetParametersWithPhoto) { UniqueId = entity.AccessPortalUid };

                if (!p.IsExcluded(nameof(AccessPortal.GalaxyHardwareAddress)))
                    entity.GalaxyHardwareAddress = _accessPortalGalaxyHardwareAddressRepository.GetByAccessPortalUid(sessionData, p);

                if (!p.IsExcluded(nameof(AccessPortal.EntityIds)))
                {
                    var entityMaps = _entityMapRepository.GetAllAccessPortalEntityMapsForAccessPortal(sessionData, p);
                    var entityIds = (from e in entityMaps select e.EntityId).ToList();
                    entity.EntityIds.AddRange(entityIds);

                    entity.EntityIds.Add(entity.EntityId);
                }

                if (!p.IsExcluded(nameof(AccessPortal.RoleIds)))
                {
                    var roleFilters = _roleAccessPortalRepository.GetAllForAccessPortalUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid });
                    var roleIds = (from e in roleFilters select e.RoleId).ToList();
                    entity.RoleIds.AddRange(roleIds);
                }

                if (!p.IsExcluded(nameof(AccessPortal.Properties)))
                    entity.Properties = _accessPortalPropertiesRepository.GetByAccessPortalUid(sessionData, p);

                if (!p.IsExcluded(nameof(AccessPortal.AlertEvents)))
                {
                    var iogMgr = new InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAManager();
                    iogMgr.Entity.accessPortalUid = entity.AccessPortalUid;
                    iogMgr.Entity.ioGroupNumber = GalaxySMS.Common.Constants.InputOutputGroupLimits.None;
                    var iog = iogMgr.BuildCollection();

                    entity.AlertEvents = _accessPortalAlertEventRepository.GetByAccessPortalUid(sessionData, p).ToCollection();
                    if (iog != null && iog.Count == 1)
                    {
                        entity.InitializeAlertEventsCollection(GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
                            GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always,
                            iog[0].InputOutputGroupUid);
                    }
                }

                if (!p.IsExcluded(nameof(AccessPortal.Areas)))
                {
                    var areaMgr = new AreaUid_GetByAccessPortalUidAndAreaNumberPDSAManager();
                    areaMgr.Entity.accessPortalUid = entity.AccessPortalUid;
                    areaMgr.Entity.areaNumber = GalaxySMS.Common.Constants.AreaLimits.NoChange;
                    var area = areaMgr.BuildCollection();

                    entity.Areas = _accessPortalAreaRepository.GetByAccessPortalUid(sessionData, p).ToCollection();
                    if (area != null && area.Count == 1)
                    {
                        entity.InitializeAreaCollection(area[0].AreaUid, area[0].AreaUid);
                    }
                }

                if (!p.IsExcluded(nameof(AccessPortal.Schedules)))
                {
                    entity.Schedules = _accessPortalTimeScheduleRepository.GetByAccessPortalUid(sessionData, p).ToCollection();
                    entity.InitializeSchedulesCollection(GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never, GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always);
                }

                if (!p.IsExcluded(nameof(AccessPortal.AuxiliaryOutputs)))
                {
                    entity.AuxiliaryOutputs = _accessPortalAuxiliaryOutputRepository.GetByAccessPortalUid(sessionData, p).ToCollection();
                    entity.InitializeAuxiliaryOutputsCollection(GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never, GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always);
                }

                if (!p.IsExcluded(nameof(AccessPortal.Notes)))
                {
                    entity.Notes = _noteRepository.GetAllNotesForAccessPortal(sessionData, p).ToCollection();
                }

                if (!p.IsExcluded(nameof(AccessPortal.AccessGroups)))
                {
                    entity.AccessGroups = _accessGroupAccessPortalRepository.GetAllAccessGroupAccessPortalForAccessPortal(sessionData, p).ToCollection();
                    if (entity.ClusterUid != Guid.Empty)
                    {
                        var accessGroups = _accessGroupRepository.GetAllGalaxyAccessGroupsForCluster(sessionData,
                            new GetParametersWithPhoto()
                            { UniqueId = entity.ClusterUid, IncludePhoto = false, IncludeMemberCollections = false });

                        //var systemAccessGroups = _accessGroupRepository.GetAllSystemAccessGroupsForCluster(sessionData,
                        //    new GetParametersWithPhoto()
                        //    { UniqueId = entity.ClusterUid, IncludePhoto = false, IncludeMemberCollections = false });

                        var enumerableAccessGroups = accessGroups.Items as AccessGroup[] ?? accessGroups.Items.ToArray();
                        foreach (var ag in enumerableAccessGroups.Where(i => i.AccessGroupNumber <= GalaxySMS.Common.Constants.AccessGroupLimits.MaximumNumber))
                        {
                            if (entity.AccessGroups.FirstOrDefault(g => g.AccessGroupUid == ag.AccessGroupUid) == null)
                            {
                                var newAgAp = new AccessGroupAccessPortal()
                                {
                                    AccessPortalUid = entity.AccessPortalUid,
                                    AccessGroupUid = ag.AccessGroupUid,
                                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
                                    AccessGroupName = enumerableAccessGroups.Where(i => i.AccessGroupUid == ag.AccessGroupUid).Select(i => i.Display).FirstOrDefault(),
                                    AccessPortalName = entity.PortalName,
                                    AccessGroupNumber = ag.AccessGroupNumber,
                                    ConcurrencyValue = 0
                                };
                                if (ag.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
                                {
                                    newAgAp.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;
                                }
                                entity.AccessGroups.Add(newAgAp);
                            }
                        }

                        //foreach( var ag in entity.AccessGroupAccessPortals)
                        //{
                        //    if (systemAccessGroups.FirstOrDefault(g => g.AccessGroupUid == ag.AccessGroupUid) != null)
                        //        ag.IsSystemAccessGroup = true;
                        //}
                    }
                }
            }

        }

        protected void FillMemberCollections(AccessPortalSelectionItemBasic entity, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            if (entity.Photo != null && entity.Photo.Length > 0 && getParameters.IncludePhoto && getParameters.PhotoPixelWidth > 0)
            {
                var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                    GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.Photo), getParameters.PhotoPixelWidth);
                entity.Photo = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
            }
            if (getParameters.IncludePhoto == false && entity.Photo != null)
                entity.Photo = null;
        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid,
            IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            if (saveParams.Ignore(nameof(entity.EntityIds)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllAccessPortalEntityMapsForAccessPortal(sessionData,
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
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.AccessPortalEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new AccessPortalEntityMap();
                    entityMap.AccessPortalEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.AccessPortalUid = uid;
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
            var existingRoleAccessPortals = _roleAccessPortalRepository.GetAllForAccessPortalUid(sessionData, getParameters);
            var existingRoleIds = new HashSet<Guid>(existingRoleAccessPortals.Select(e => e.RoleId));
            var deleteRoleIds = existingRoleIds.Except(entity.RoleIds);

            foreach (var rid in deleteRoleIds)
            {
                var rc = existingRoleAccessPortals.FirstOrDefault(o => o.RoleId == rid);
                if (rc != null)
                    _roleAccessPortalRepository.Remove(rc.RoleAccessPortalUid, sessionData);
            }

            foreach (var roleId in entity.RoleIds)
            {
                if (!existingRoleIds.Contains(roleId))
                {
                    var roleAccessPortal = new RoleAccessPortal();
                    roleAccessPortal.RoleAccessPortalUid = GuidUtilities.GenerateComb();
                    roleAccessPortal.AccessPortalUid = uid;
                    roleAccessPortal.RoleId = roleId;
                    UpdateTableEntityBaseProperties(roleAccessPortal, sessionData);

                    _roleAccessPortalRepository.Add(roleAccessPortal, sessionData, saveParams);
                }
            }

        }

        private void EnsureChildRecordsExist(AccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            var ioGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();
            _allIoGroups = ioGroupRepository.GetAllGalaxyInputOutputGroupsForAccessPortal(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid, IncludeMemberCollections = false, IncludePhoto = false }).Items.ToCollection();

            _noIog = _allIoGroups.FirstOrDefault(o => o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);
            if (_noIog != null)
            {
                var opts = saveParams.Options.ToList();
                opts.Add(new KeyValuePair<string, string>(SaveAccessPortalAlertEventsOption.NoIoGroupUid.ToString(), _noIog.InputOutputGroupUid.ToString()));
                saveParams.Options = opts;
            }


            if (!saveParams.Ignore(nameof(entity.Properties)) && entity.Properties != null)
                SaveProperties(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.Areas)) && entity.Areas != null && entity.Areas.Any())
                SaveAreas(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.Schedules)) && entity.Schedules != null && entity.Schedules.Any())
                SaveSchedules(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.AlertEvents)) && entity.AlertEvents != null && entity.AlertEvents.Any())
                SaveAlertEvents(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.AuxiliaryOutputs)) && entity.AuxiliaryOutputs != null && entity.AuxiliaryOutputs.Any())
                SaveAuxiliaryOutputs(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.Notes)) && entity.Notes != null && entity.Notes.Any())
                SaveNotes(entity, sessionData, saveParams);

            //if (!saveParams.Ignore(nameof(entity.AccessGroupAccessPortals)) && entity.AccessGroupAccessPortals != null && entity.AccessGroupAccessPortals.Any())
            //    SaveAccessGroupAccessPortals(entity, sessionData, saveParams);

            // Ignore must not be specified
            if (!saveParams.Ignore(nameof(entity.AccessGroups)))
            {
                var kvpSaveAccessGroupAccessPortalsOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessGroupAccessPortalsOption).ToString());

                bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Key) &&
                                           !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Value) &&
                                           kvpSaveAccessGroupAccessPortalsOption.Value == SaveAccessGroupAccessPortalsOption.DeleteMissingItems.ToString();
                bool bCreateMissingItems = !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Key) &&
                                           !string.IsNullOrEmpty(kvpSaveAccessGroupAccessPortalsOption.Value) &&
                                           kvpSaveAccessGroupAccessPortalsOption.Value == SaveAccessGroupAccessPortalsOption.CreateMissingItems.ToString();

                if (bDeleteMissingItems ||
                    bCreateMissingItems ||
                    entity.AccessGroups == null ||
                    entity.AccessGroups.Any())
                    SaveAccessGroupAccessPortals(entity, sessionData, saveParams);
            }
        }

        private void SaveProperties(AccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            // AccessPortalProperties
            var props = _accessPortalPropertiesRepository.GetByAccessPortalUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid });

            var propsToIgnore = new List<string>();
            propsToIgnore.Add(nameof(entity.Properties.AccessPortalPropertiesUid));
            propsToIgnore.Add(nameof(entity.Properties.AccessPortalUid));
            if (props != null && (entity.Properties.IsAnythingDirty == true ||
                //entity.Properties.AreAnyValuesNotSpecified() ||
                ObjectComparer.AreAnyPublicPropertiesDifferent(props, entity.Properties, null, propsToIgnore)))
            {
                entity.Properties.AccessPortalPropertiesUid = props.AccessPortalPropertiesUid;
                entity.Properties.AccessPortalUid = props.AccessPortalUid;

                UpdateTableEntityBaseProperties(entity.Properties, sessionData);
                _accessPortalPropertiesRepository.Update(entity.Properties, sessionData, saveParams);
            }
            if (entity.Properties.AccessPortalUid == Guid.Empty)
            {
                entity.Properties.AccessPortalPropertiesUid = GuidUtilities.GenerateComb();
                entity.Properties.AccessPortalUid = entity.AccessPortalUid;
                UpdateTableEntityBaseProperties(entity.Properties, sessionData);
                _accessPortalPropertiesRepository.Add(entity.Properties, sessionData, saveParams);
            }
        }

        private void SaveAreas(AccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.Areas == null || !entity.Areas.Any())
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessPortalAreasOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveAccessPortalAreasOption.DeleteMissingItems.ToString();

            var areasForCluster = _galaxyAreaRepository.GetAllGalaxyAreasForAccessPortal(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid });

            // Get all items from the database
            var items = _accessPortalAreaRepository.GetByAccessPortalUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid });

            // If any do not have a AccessPortalAreaUid (PrimaryKey value), see if we can determine the value by AccessPortalAreaTypeUid
            foreach (var area in entity.Areas.Where(o => o.AccessPortalAreaUid == Guid.Empty))
            {
                var i = items.FirstOrDefault(o => o.AccessPortalAreaTypeUid == area.AccessPortalAreaTypeUid);
                if (i != null)
                {
                    area.AccessPortalAreaUid = i.AccessPortalAreaUid;
                }
            }

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Portal
                foreach (var i in items)
                {
                    // If the AccessPortalAreaUid does not exist in the entity, then delete the area from the database
                    if (entity.Areas.FirstOrDefault(o => o.AccessPortalAreaUid == i.AccessPortalAreaUid) == null)
                    {
                        _accessPortalAreaRepository.Remove(i.AccessPortalAreaUid, sessionData);
                    }
                }
            }

            var propsToInclude = new List<string>();

            // Now save those that are defined in the Access Portal being saved
            foreach (var i in entity.Areas)
            {
                if (i.AccessPortalUid != entity.AccessPortalUid)
                    i.AccessPortalUid = entity.AccessPortalUid;
                if (i.AreaUid == Guid.Empty)
                {
                    var a = areasForCluster.Items.FirstOrDefault(x => x.AreaNumber == GalaxySMS.Common.Constants.AreaLimits.NoChange);
                    if (a != null)
                        i.AreaUid = a.AreaUid;
                }

                if (!propsToInclude.Any())
                {
                    propsToInclude.Add(nameof(i.AreaUid));
                }
                var existingItem = items.FirstOrDefault(o => o.AccessPortalAreaUid == i.AccessPortalAreaUid);
                if (existingItem != null && (i.IsAnythingDirty ||
                    ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i, propsToInclude)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessPortalAreaRepository.Update(i, sessionData, saveParams);
                }
                if (i.AccessPortalAreaUid == Guid.Empty)
                {
                    i.AccessPortalAreaUid = GuidUtilities.GenerateComb();
                    i.AccessPortalUid = entity.AccessPortalUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessPortalAreaRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        private void SaveSchedules(AccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.Schedules == null || !entity.Schedules.Any())
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessPortalSchedulesOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveAccessPortalSchedulesOption.DeleteMissingItems.ToString();

            // Schedules
            var items = _accessPortalTimeScheduleRepository.GetByAccessPortalUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid });

            // If any do not have a AccessPortalTimeScheduleUid (PrimaryKey value), see if we can determine the value by AccessPortalScheduleTypeUid
            foreach (var sch in entity.Schedules.Where(o => o.AccessPortalTimeScheduleUid == Guid.Empty))
            {
                var i = items.FirstOrDefault(o => o.AccessPortalScheduleTypeUid == sch.AccessPortalScheduleTypeUid);
                if (i != null)
                {
                    sch.AccessPortalTimeScheduleUid = i.AccessPortalTimeScheduleUid;
                }
            }

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Portal
                foreach (var i in items)
                {
                    // If the AccessPortalScheduleType does not exist in the entity, then delete the area from the database
                    if (entity.Schedules.FirstOrDefault(o => o.AccessPortalTimeScheduleUid == i.AccessPortalTimeScheduleUid) == null)
                    {
                        _accessPortalTimeScheduleRepository.Remove(i.AccessPortalTimeScheduleUid, sessionData);
                    }
                }
            }

            var propsToInclude = new List<string>();

            // Now save those that are defined in the Access Portal being saved
            foreach (var i in entity.Schedules)
            {
                if (!propsToInclude.Any())
                {
                    propsToInclude.Add(nameof(i.TimeScheduleUid));
                }

                var existingItem = items.FirstOrDefault(o => o.AccessPortalTimeScheduleUid == i.AccessPortalTimeScheduleUid);
                if (i.AccessPortalUid != entity.AccessPortalUid)
                    i.AccessPortalUid = entity.AccessPortalUid;
                if (i.TimeScheduleUid == Guid.Empty)
                    i.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;

                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i, propsToInclude)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessPortalTimeScheduleRepository.Update(i, sessionData, saveParams);
                }
                if (i.AccessPortalTimeScheduleUid == Guid.Empty)
                {
                    i.AccessPortalTimeScheduleUid = GuidUtilities.GenerateComb();
                    i.AccessPortalUid = entity.AccessPortalUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessPortalTimeScheduleRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        private void SaveAlertEvents(AccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.AlertEvents == null || !entity.AlertEvents.Any())
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessPortalAlertEventsOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveAccessPortalAlertEventsOption.DeleteMissingItems.ToString();

            // Alert Events
            var items = _accessPortalAlertEventRepository.GetByAccessPortalUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid });

            // If any do not have a AccessPortalAlertEventUid (PrimaryKey value), see if we can determine the value by AccessPortalAlertEventTypeUid
            foreach (var sch in entity.AlertEvents.Where(o => o.AccessPortalAlertEventUid == Guid.Empty))
            {
                var i = items.FirstOrDefault(o => o.AccessPortalAlertEventTypeUid == sch.AccessPortalAlertEventTypeUid);
                if (i != null)
                {
                    sch.AccessPortalAlertEventUid = i.AccessPortalAlertEventUid;
                }
            }

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Portal
                foreach (var i in items)
                {
                    // If the AccessPortalAlertEventUid does not exist in the entity, then delete the area from the database
                    if (entity.AlertEvents.FirstOrDefault(o => o.AccessPortalAlertEventUid == i.AccessPortalAlertEventUid) == null)
                    {
                        _accessPortalAlertEventRepository.Remove(i.AccessPortalAlertEventUid, sessionData);
                    }
                }
            }

            var propsToExclude = new List<string>();

            // Now save those that are defined in the Access Portal being saved
            foreach (var i in entity.AlertEvents)
            {
                //if (!propsToExclude.Any())
                //{
                //    propsToExclude.Add(nameof(i.));
                //}

                if (i.AccessPortalUid != entity.AccessPortalUid)
                    i.AccessPortalUid = entity.AccessPortalUid;

                var existingItem = items.FirstOrDefault(o => o.AccessPortalAlertEventUid == i.AccessPortalAlertEventUid);
                if (existingItem != null)
                {
                    if (existingItem.Note != null)
                        i.Note.NoteUid = existingItem.Note.NoteUid;
                    i.ResponseInstructionsUid = i.Note.NoteUid;

                    if (existingItem.Note.Photo == null && i.Note?.Photo?.Length == 0)
                        i.Note.Photo = null;
                    if (existingItem.Note.Document == null && i.Note?.Document?.Length == 0)
                        i.Note.Document = null;
                }
                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    i.EntityId = entity.EntityId;
                    _accessPortalAlertEventRepository.Update(i, sessionData, saveParams);
                }
                if (i.AccessPortalAlertEventUid == Guid.Empty)
                {
                    i.AccessPortalAlertEventUid = GuidUtilities.GenerateComb();
                    i.AccessPortalUid = entity.AccessPortalUid;
                    i.EntityId = entity.EntityId;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessPortalAlertEventRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        private void SaveAuxiliaryOutputs(AccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.AuxiliaryOutputs == null || !entity.AuxiliaryOutputs.Any())
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessPortalAuxiliaryOutputsOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveAccessPortalAuxiliaryOutputsOption.DeleteMissingItems.ToString();

            // Auxiliary Outputs
            var items = _accessPortalAuxiliaryOutputRepository.GetByAccessPortalUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid });

            // If any do not have a AccessPortalAuxiliaryOutputUid (PrimaryKey value), see if we can determine the value by Tag
            foreach (var sch in entity.AuxiliaryOutputs.Where(o => o.AccessPortalAuxiliaryOutputUid == Guid.Empty))
            {
                var i = items.FirstOrDefault(o => o.Tag == sch.Tag);
                if (i != null)
                {
                    sch.AccessPortalAuxiliaryOutputUid = i.AccessPortalAuxiliaryOutputUid;
                }
            }

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Portal
                foreach (var i in items)
                {
                    // If the AccessPortalAuxiliaryOutputUid does not exist in the entity, then delete the area from the database
                    if (entity.AuxiliaryOutputs.FirstOrDefault(o => o.AccessPortalAuxiliaryOutputUid == i.AccessPortalAuxiliaryOutputUid) == null)
                    {
                        _accessPortalAuxiliaryOutputRepository.Remove(i.AccessPortalAuxiliaryOutputUid, sessionData);
                    }
                }
            }

            var propsToInclude = new List<string>();

            // Now save those that are defined in the Access Portal being saved
            foreach (var i in entity.AuxiliaryOutputs)
            {
                if (i.AccessPortalUid != entity.AccessPortalUid)
                    i.AccessPortalUid = entity.AccessPortalUid;

                var existingItem = items.FirstOrDefault(o => o.AccessPortalAuxiliaryOutputUid == i.AccessPortalAuxiliaryOutputUid);
                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessPortalAuxiliaryOutputRepository.Update(i, sessionData, saveParams);
                }
                if (i.AccessPortalAuxiliaryOutputUid == Guid.Empty)
                {
                    i.AccessPortalAuxiliaryOutputUid = GuidUtilities.GenerateComb();
                    i.AccessPortalUid = entity.AccessPortalUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessPortalAuxiliaryOutputRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        private void SaveNotes(AccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.Notes == null || !entity.Notes.Any())
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessPortalNotesOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveAccessPortalNotesOption.DeleteMissingItems.ToString();

            // Notes
            var items = _accessPortalNoteRepository.GetByAccessPortalUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid });

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Portal
                foreach (var i in items)
                {
                    // If the NoteUid does not exist in the entity, then delete the note from the database
                    if (entity.Notes.FirstOrDefault(o => o.NoteUid == i.NoteUid) == null)
                    {
                        // Remove the note itself. Deleting the note should automatically delete the AccessPortalNote record as well due to RI rules
                        _noteRepository.Remove(i.NoteUid, sessionData);
                        //_accessPortalNoteRepository.Remove(i.AccessPortalNoteUid, sessionData, null);
                    }
                }
            }

            var propsToInclude = new List<string>();

            // Now save those that are defined in the Access Portal being saved
            foreach (var i in entity.Notes)
            {
                var existingItem = items.FirstOrDefault(o => o.NoteUid == i.NoteUid);
                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _noteRepository.Update(i, sessionData, saveParams);
                    //_accessPortalNoteRepository.Update(i, sessionData, null);
                }

                if (i.NoteUid == Guid.Empty)
                {   // This is a new note. The note must be created and an AccessPortalNote record must also be created to link the note to the access portal
                    i.NoteUid = GuidUtilities.GenerateComb();
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _noteRepository.Add(i, sessionData, saveParams);
                    var apn = new AccessPortalNote()
                    {
                        AccessPortalNoteUid = GuidUtilities.GenerateComb(),
                        NoteUid = i.NoteUid,
                        AccessPortalUid = entity.AccessPortalUid
                    };
                    UpdateTableEntityBaseProperties(apn, sessionData);
                    _accessPortalNoteRepository.Add(apn, sessionData, saveParams);
                }
            }
        }

        private void SaveAccessGroupAccessPortals(AccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //if (entity.AccessGroupAccessPortals == null || !entity.AccessGroupAccessPortals.Any())
            //    return;
            if (entity.AccessGroups == null)
                entity.AccessGroups = new List<AccessGroupAccessPortal>();

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessGroupAccessPortalsOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveAccessGroupAccessPortalsOption.DeleteMissingItems.ToString();

            entity.AccessGroups = entity.AccessGroups.Where(o => o.AccessGroupUid != Guid.Empty).ToCollection();
            // If any have an Empty guid value assigned for the Time Schedule, default it to never
            foreach (var agap in entity.AccessGroups.Where(o => o.TimeScheduleUid == Guid.Empty))
            {
                agap.TimeScheduleUid = null;//GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
            }

            // Get all items from the database
            var items = _accessGroupAccessPortalRepository.GetAllAccessGroupAccessPortalForAccessPortal(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid });

            // If any do not have a AccessGroupAccessPortalUid (PrimaryKey value), see if we can determine the value by AccessPortalUid
            foreach (var agap in entity.AccessGroups.Where(o => o.AccessGroupAccessPortalUid == Guid.Empty))
            {
                var i = items.FirstOrDefault(o => o.AccessGroupUid == agap.AccessGroupUid);
                if (i != null)
                {
                    agap.AccessGroupAccessPortalUid = i.AccessGroupAccessPortalUid;
                }
            }

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Portal
                foreach (var i in items)
                {
                    // If the AccessGroupAccessPortalUid does not exist in the entity, then delete the record from the database
                    if (entity.AccessGroups.FirstOrDefault(o => o.AccessGroupAccessPortalUid == i.AccessGroupAccessPortalUid) == null)
                    {
                        // Remove the access group access portal itself. 
                        _accessGroupAccessPortalRepository.Remove(i.AccessGroupAccessPortalUid, sessionData);
                    }
                }
            }

            IArrayResponse<AccessGroup> accessGroups = null;

            if (entity.ClusterUid != Guid.Empty)
                accessGroups = _accessGroupRepository.GetAllGalaxyAccessGroupsForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = entity.ClusterUid });
            else
                accessGroups = _accessGroupRepository.GetAllGalaxyAccessGroupsForAccessPortal(sessionData, new GetParametersWithPhoto() { UniqueId = entity.AccessPortalUid });

            var missingAg = accessGroups.Items.Where(i => entity.AccessGroups.All(i2 => i2.AccessGroupUid != i.AccessGroupUid)).ToList();
            foreach (var ag in missingAg.Where(i => i.AccessGroupNumber <= GalaxySMS.Common.Constants.AccessGroupLimits.MaximumNumber))
            {
                var newAgAp = new AccessGroupAccessPortal()
                {
                    AccessPortalUid = entity.AccessPortalUid,
                    AccessGroupUid = ag.AccessGroupUid,
                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
                };
                if (ag.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
                {
                    newAgAp.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;
                }
                entity.AccessGroups.Add(newAgAp);
            }
            //}

            var propsToInclude = new List<string>();
            // Now save those that are defined in the Access Portal being saved
            foreach (var i in entity.AccessGroups)
            {
                if (i.AccessPortalUid != entity.AccessPortalUid)
                    i.AccessPortalUid = entity.AccessPortalUid;
                var existingItem = items.FirstOrDefault(o => o.AccessGroupAccessPortalUid == i.AccessGroupAccessPortalUid);

                if (existingItem != null)
                {
                    // Prevent the caller from overriding the NO ACCESS and UNLIMITED ACCESS groups time schedules
                    if (existingItem.IsSystemAccessGroup)
                    {
                        if (existingItem.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.None)
                            i.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
                        else if (existingItem.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
                            i.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;
                    }
                }

                if (!propsToInclude.Any())
                {
                    propsToInclude.Add(nameof(i.TimeScheduleUid));
                    propsToInclude.Add(nameof(i.AccessPortalUid));
                    propsToInclude.Add(nameof(i.AccessGroupUid));
                }
                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i, propsToInclude)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessGroupAccessPortalRepository.Update(i, sessionData, saveParams);
                }
                if (i.AccessGroupAccessPortalUid == Guid.Empty)
                {
                    i.AccessGroupAccessPortalUid = GuidUtilities.GenerateComb();
                    i.AccessPortalUid = entity.AccessPortalUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _accessGroupAccessPortalRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("AccessPortal", "AccessPortalUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("AccessPortal", "AccessPortalUid", id);
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

        protected override bool IsEntityUnique(AccessPortal entity)
        {
            var mgr = new IsAccessPortalUniquePDSAManager();
            mgr.Entity.AccessPortalUid = entity.AccessPortalUid;
            mgr.Entity.PortalName = entity.PortalName;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("AccessPortal", "AccessPortalUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("AccessPortal", "AccessPortalUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertAccessPortalCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }


        #region Implementation of IAccessPortalRepository

        public AccessPortal EnsureAccessPortalExists(IApplicationUserSessionDataHeader sessionData, EnsureAccessPortalExistsParameters parameters, ISaveParameters saveParams)
        {
            // Start by seeing if one exists for the GalaxyInterfaceBoardSectionNode
            var existingAp =
                _accessPortalGalaxyHardwareAddressRepository.GetByAccessPortalGalaxyHardwareAddressUid(sessionData,
                    new GetParametersWithPhoto() { UniqueId = parameters.TheNode.GalaxyInterfaceBoardSectionNodeUid });
            if (existingAp != null)
                return GetEntityByGuidId(existingAp.AccessPortalUid, sessionData,
                    new GetParametersWithPhoto() { UniqueId = existingAp.AccessPortalUid });

            AccessPortal templateItem = null;
            AccessPortal newItem = null;

            var newName = string.Format(GalaxySMS.Resources.Resources.AccessPortal_DefaultGalaxyName,
                parameters.TheNode.ClusterGroupId,
                parameters.TheNode.ClusterNumber,
                parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber, parameters.TheNode.SectionNumber, parameters.TheNode.NodeNumber);

            var duplicateNamedAccessPortals = GetAccessPortalsByNameAndSite(sessionData, new GetParametersWithPhoto()
            {
                IncludeMemberCollections = false,
                GetString = newName,
                GetGuid = parameters.SiteUid,
                PageNumber = 1,
                PageSize = 0
            });

            if (duplicateNamedAccessPortals.Items.Any())
            {
                for (int x = 1; x < 1000; x++)
                {
                    newName = string.Format(GalaxySMS.Resources.Resources.AccessPortal_DefaultGalaxyName,
                        parameters.TheNode.ClusterGroupId,
                        parameters.TheNode.ClusterNumber,
                        parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber,
                        parameters.TheNode.SectionNumber, parameters.TheNode.NodeNumber);
                    newName += $" ({x})";
                    if (duplicateNamedAccessPortals.Items.FirstOrDefault(o => o.Name.ToLower() == newName.ToLower()) ==
                        null)
                        break;
                }
            }

            // If none exists, create one
            if (parameters.TemplateAccessPortalUid != Guid.Empty)
                templateItem = GetEntityByGuidId(parameters.TemplateAccessPortalUid, sessionData,
                    new GetParametersWithPhoto() { UniqueId = parameters.TemplateAccessPortalUid });
            if (templateItem == null)
            {
                if (parameters.DefaultAccessPortalTypeUid == Guid.Empty)
                    parameters.DefaultAccessPortalTypeUid = GalaxySMS.Common.Constants.AccessPortalTypeIds
                        .AccessPortalType_StandardEntryPoint_StandardWiegand;
                var apType =
                    _accessPortalTypeRepository.Get(parameters.DefaultAccessPortalTypeUid, sessionData,
                        new GetParametersWithPhoto() { }) ??
                    _accessPortalTypeRepository.GetAll(sessionData, new GetParametersWithPhoto()).FirstOrDefault();

                if (apType == null)
                {
                    var ex =
                        new ApplicationException(
                            "Unable to create access portal because there is no AccessPortalType defined");
                    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::EnsureAccessPortalExists", ex);
                    throw ex;
                }
                newItem = new AccessPortal();
                newItem.Initialize(parameters);
                newItem.AccessPortalTypeUid = apType.AccessPortalTypeUid;

                newItem.InsertName = sessionData.UserName;
                newItem.InsertDate = DateTimeOffset.Now;
            }
            else
            {
                newItem = templateItem.Clone(templateItem);
            }


            newItem.AccessPortalUid = GuidUtilities.GenerateComb();
            newItem.EntityId = sessionData.CurrentEntityId;
            //newItem.SiteUid = sessionData.CurrentSiteId;
            newItem.SiteUid = parameters.SiteUid;

            newItem.ClusterUid = parameters.TheNode.ClusterUid;
            newItem.ClusterNumber = parameters.TheNode.ClusterNumber;
            newItem.PanelNumber = parameters.TheNode.PanelNumber;
            newItem.PortalName = newName;
            //newItem.PortalName += $" - {DateTimeOffset.UtcNow.Ticks % 100000}";
            newItem.InsertName = sessionData.UserName;
            newItem.InsertDate = DateTimeOffset.Now;
            newItem.UpdateName = newItem.InsertName;
            newItem.UpdateDate = newItem.InsertDate;
            newItem.RoleIds = parameters.RoleIds;
            newItem.IsEnabled = true;
            if (!newItem.AccessGroups.Any())
            {
                var allAccessGroups = _accessGroupRepository.GetAllSystemAccessGroupsForCluster(sessionData, new GetParametersWithPhoto() { UniqueId = parameters.TheNode.ClusterUid });
                foreach (var ag in allAccessGroups.Items.Where(o => o.AccessGroupNumber < GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup))
                {
                    var agap = new AccessGroupAccessPortal() { AccessGroupUid = ag.AccessGroupUid, TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never };

                    if (ag.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.UnlimitedAccess)
                        agap.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;
                    newItem.AccessGroups.Add(agap);
                }
            }

            var returnItem = Add(newItem, sessionData, saveParams);
            if (returnItem != null)
            {
                var hwAddress = new AccessPortalGalaxyHardwareAddress();
                hwAddress.AccessPortalGalaxyHardwareAddressUid = GuidUtilities.GenerateComb();
                hwAddress.AccessPortalUid = returnItem.AccessPortalUid;
                hwAddress.GalaxyInterfaceBoardSectionNodeUid = parameters.TheNode.GalaxyInterfaceBoardSectionNodeUid;
                hwAddress.InsertName = sessionData.UserName;
                hwAddress.InsertDate = DateTimeOffset.Now;
                hwAddress.UpdateName = newItem.InsertName;
                hwAddress.UpdateDate = newItem.InsertDate;

                _accessPortalGalaxyHardwareAddressRepository.Add(hwAddress, sessionData, saveParams);
            }
            return returnItem;
        }

        #endregion

        public bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid accessPortalUid, Guid permissionId, Guid entityId)
        {
            // If no permission is specified, return true to indicate that permission is granted
            if (permissionId == Guid.Empty)
                return true;

            if (!sessionData.IsPermissionCheckPossible)
                return true;

            var mgr = new AccessPortal_GetUserPermissionPDSAManager();
            mgr.Entity.UserId = sessionData.UserId;
            mgr.Entity.AccessPortalUid = accessPortalUid;
            mgr.Entity.PermissionId = permissionId;
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            if (results?.Count > 0)
                return true;
            return false;
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, AccessPortalPDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<AccessPortalSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }


        protected override IArrayResponse<AccessPortal> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId == Guid.Empty)
                    getParameters.UniqueId = sessionData.CurrentEntityId;
                mgr.Entity.EntityId = getParameters.UniqueId;
                SetSortColumnAndOrder(getParameters, mgr);
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<AccessPortal> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalPDSAData.SelectFilters.All;
                SetSortColumnAndOrder(getParameters, mgr);
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAllEntities", ex);
                throw;
            }
        }


        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new AccessPortal_GetAllUidsFromRoleIdPDSAManager();
            mgr.Entity.RoleId = roleId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.AccessPortalUid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndClusterUid(Guid roleId, Guid clusterUid)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new AccessPortal_GetAllUidsFromRoleIdAndClusterUidPDSAManager();
            mgr.Entity.RoleId = roleId;
            mgr.Entity.ClusterUid = clusterUid;
            var results = mgr.BuildCollection();
            return results.Select(o => o.AccessPortalUid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsForEntityId(Guid entityId)
        {
            var dataList = new List<Guid>();
            if (entityId == Guid.Empty)
                return dataList;
            var mgr = new AccessPortal_GetAllUidsForEntityidPDSAManager();
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.Uid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsForClusterUid(Guid clusterUid)
        {
            var dataList = new List<Guid>();
            if (clusterUid == Guid.Empty)
                return dataList;
            var mgr = new AccessPortal_GetAllUidsForClusterUidPDSAManager();
            mgr.Entity.ClusterUid = clusterUid;
            var results = mgr.BuildCollection();
            return results.Select(o => o.Uid);
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForAccessPortalPDSAManager
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

        public bool IsBoardSectionOnSamePanel(Guid accessPortalUid, Guid boardSectionUid)
        {
            var ibsRepo = _dataRepositoryFactory.GetDataRepository<IGalaxyInterfaceBoardSectionRepository>();
            var ibsPanelUid = ibsRepo.GetGalaxyPanelUid(boardSectionUid);
            var apPanelUid = GetGalaxyPanelUid(accessPortalUid);

            if (ibsPanelUid == Guid.Empty || apPanelUid == Guid.Empty)
                return false;
            return ibsPanelUid == apPanelUid;
        }

        public Guid GetGalaxyPanelUid(Guid uid)
        {
            var mgr = new GetGalaxyPanelUidForAccessPortalPDSAManager()
            {
                Entity =
                {
                    uid = uid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.GalaxyPanelUid;
            return Guid.Empty;
        }

        public Guid GetClusterUid(Guid uid)
        {
            var mgr = new GetClusterUidForAccessPortalPDSAManager()
            {
                Entity =
                {
                    uid = uid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.ClusterUid;
            return Guid.Empty;
        }



        public ValidationProblemDetails Validate(AccessPortal data, ISaveParameters saveParams, IApplicationUserSessionDataHeader sessionData)
        {

            var response = new ValidationProblemDetails();
            var errorsArray = new List<string>();
            data.ClusterUid = GetClusterUid(data.AccessPortalUid);
            if (data.ClusterUid != Guid.Empty)
            {
                // validate the crisis mode and default time schedule are on the same cluster as the access group being saved
                //var elevatorRelayInterfaceBoardSectionUid = Guid.Empty;
                //if (data.Properties.ElevatorRelayInterfaceBoardSectionUid.HasValue && data.Properties.ElevatorRelayInterfaceBoardSectionUid != Guid.Empty)
                //{
                //    elevatorRelayInterfaceBoardSectionUid = GetClusterUidOf(data.Properties.ElevatorRelayInterfaceBoardSectionUid.Value);
                //    if (crisisAccessGroupClusterUid != data.ClusterUid)
                //    {
                //        errorsArray.Clear();
                //        errorsArray.Add($"The {nameof(AccessGroup.CrisisModeAccessGroupUid)} value {data.CrisisModeAccessGroupUid} is not permitted because it is from a different cluster. The crisis mode access group must be on the same cluster as the access group being saved.");
                //        response.Errors.Add($"{nameof(data.CrisisModeAccessGroupUid)}", errorsArray.ToArray());
                //    }
                //}

                var tsMappedRepo = _dataRepositoryFactory.GetDataRepository<IGalaxyClusterTimeScheduleMapRepository>();
                var tsRepo = _dataRepositoryFactory.GetDataRepository<ITimeScheduleRepository>();
                var tsUids = tsRepo.GetUidsForCluster(data.ClusterUid);

                if (!saveParams.Ignore(nameof(AccessPortal.Areas)))
                {
                    var areaResults = ValidateAreas(data.Areas, data.ClusterUid, nameof(data.Areas), sessionData);
                    response.Merge(areaResults);
                }

                if (!saveParams.Ignore(nameof(AccessPortal.Schedules)))
                {
                    var scheduleResults =
                        ValidateSchedules(data.Schedules, data.ClusterUid, nameof(data.Schedules), tsUids, sessionData);
                    response.Merge(scheduleResults);
                }

                if (!saveParams.Ignore(nameof(AccessPortal.AlertEvents)))
                {
                    var alertEventResults = ValidateAlertEvents(data.AlertEvents, data.ClusterUid, nameof(data.AlertEvents), tsUids, sessionData);
                    response.Merge(alertEventResults);
                }

                if (!saveParams.Ignore(nameof(AccessPortal.AuxiliaryOutputs)))
                {
                    var auxOutputResults = ValidateAuxiliaryOutputs(data.AuxiliaryOutputs, data.ClusterUid, nameof(data.AuxiliaryOutputs), tsUids, sessionData);
                    response.Merge(auxOutputResults);
                }

                if (!saveParams.Ignore(nameof(AccessPortal.AccessGroups)))
                {
                    var accessGroupsResults =
                        _accessGroupAccessPortalRepository.ValidateAccessGroupsAndScheduleMatchCluster(
                            data.AccessGroups, data.ClusterUid, nameof(data.AccessGroups));
                    response.Merge(accessGroupsResults);
                }

            }

            return response;
        }

        private ValidationProblemDetails ValidateAuxiliaryOutputs(ICollection<AccessPortalAuxiliaryOutput> items, Guid clusterUid, string propertyName, IEnumerable<Guid> allowedTimeScheduleUids, IApplicationUserSessionDataHeader sessionData)
        {
            var response = new ValidationProblemDetails();
            var errorsArray = new List<string>();

            int x = 0;
            foreach (var a in items.Where(o => o.TimeScheduleUid != Guid.Empty))
            {
                errorsArray.Clear();

                if (!allowedTimeScheduleUids.Contains(a.TimeScheduleUid))
                {
                    errorsArray.Add($"{nameof(TimeSchedule)} with {nameof(a.TimeScheduleUid)}:'{a.TimeScheduleUid}' is not found or is not mapped with the same cluster as the access portal.");
                }
                if (errorsArray.Any())
                    response.Errors.Add($"{propertyName}[{x}]", errorsArray.ToArray());

                x++;
            }

            return response;
        }

        private ValidationProblemDetails ValidateAlertEvents(ICollection<AccessPortalAlertEvent> items, Guid clusterUid, string propertyName, IEnumerable<Guid> allowedTimeScheduleUids, IApplicationUserSessionDataHeader sessionData)
        {
            var iogRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();
            var iogUids = iogRepository.GetUidsForCluster(clusterUid);
            var alertEventTypeRepository = _dataRepositoryFactory.GetDataRepository<IAccessPortalAlertEventTypeRepository>();
            var alertEventTypes = alertEventTypeRepository.GetAll(sessionData, null).ToCollection();
            var response = new ValidationProblemDetails();
            var errorsArray = new List<string>();

            int x = 0;
            foreach (var a in items)
            {
                errorsArray.Clear();
                if (a.AccessPortalAlertEventTypeUid == Guid.Empty)
                {
                    errorsArray.Add($"{nameof(a.AcknowledgeTimeScheduleUid)} is missing or contains an empty value.");
                }
                else
                {
                    var aeType = alertEventTypes.FirstOrDefault(o =>
                        o.AccessPortalAlertEventTypeUid == a.AccessPortalAlertEventTypeUid);
                    if (aeType == null)
                    {
                        errorsArray.Add($"{nameof(a.AccessPortalAlertEventTypeUid)} contains an invalid value.");
                    }
                }
                var aeCount = items.Count(o => o.AccessPortalAlertEventTypeUid == a.AccessPortalAlertEventTypeUid);
                if (aeCount > 1)
                {
                    errorsArray.Add($"There are {aeCount} alert events specified with {nameof(a.AccessPortalAlertEventTypeUid)} {a.AccessPortalAlertEventTypeUid}. {nameof(a.AccessPortalAlertEventTypeUid)} must be unique.");
                }

                if (a.AcknowledgeTimeScheduleUid != Guid.Empty)
                {
                    if (!allowedTimeScheduleUids.Contains(a.AcknowledgeTimeScheduleUid))
                    {
                        errorsArray.Add(
                            $"{nameof(TimeSchedule)} with {nameof(a.AcknowledgeTimeScheduleUid)}:'{a.AcknowledgeTimeScheduleUid}' is not found or is not mapped with the same cluster as the access portal.");
                    }
                }


                if (a.InputOutputGroupAssignmentUid.HasValue && a.InputOutputGroupAssignmentUid.Value != Guid.Empty && a.InputOutputGroupUid == Guid.Empty)
                {
                    a.InputOutputGroupUid =
                        InputOutputGroupHelpers.GetInputOutputUidFromInputOutputGroupAssignmentUid(a.InputOutputGroupAssignmentUid.Value);
                }


                if (a.InputOutputGroupUid != Guid.Empty)
                {
                    if (!iogUids.Contains(a.InputOutputGroupUid))
                    {
                        errorsArray.Add($"{nameof(a.InputOutputGroupUid)} value {a.InputOutputGroupUid} is not valid for {nameof(Cluster.ClusterUid)} {clusterUid}.");
                    }
                }

                if (a.InputOutputGroupAssignmentUid.HasValue && a.InputOutputGroupAssignmentUid.Value != Guid.Empty)
                {
                    if (!InputOutputGroupHelpers.IsInputOutputGroupAssignmentAssociatedWithInputOutputGroup(a.InputOutputGroupAssignmentUid.Value, a.InputOutputGroupUid))
                    {
                        errorsArray.Add($"{nameof(a.InputOutputGroupAssignmentUid)} value {a.InputOutputGroupAssignmentUid} is not valid for {nameof(a.InputOutputGroupUid)} {a.InputOutputGroupUid}.");
                    }
                }

                if (errorsArray.Any())
                    response.Errors.Add($"{propertyName}[{x}]", errorsArray.ToArray());

                x++;
            }

            return response;

        }

        private ValidationProblemDetails ValidateSchedules(ICollection<AccessPortalTimeSchedule> items, Guid clusterUid, string propertyName, IEnumerable<Guid> allowedTimeScheduleUids, IApplicationUserSessionDataHeader sessionData)
        {
            var response = new ValidationProblemDetails();
            var errorsArray = new List<string>();

            var scheduleTypeRepo = _dataRepositoryFactory.GetDataRepository<IAccessPortalScheduleTypeRepository>();
            var scheduleTypes = scheduleTypeRepo.GetAll(sessionData, null);

            int x = 0;
            foreach (var a in items)
            {
                errorsArray.Clear();
                if (a.AccessPortalScheduleTypeUid == Guid.Empty)
                {
                    errorsArray.Add($"{nameof(a.AccessPortalScheduleTypeUid)} is missing or contains an empty value.");
                }
                else
                {
                    var sType = scheduleTypes.FirstOrDefault(o =>
                        o.AccessPortalScheduleTypeUid == a.AccessPortalScheduleTypeUid);
                    if (sType == null)
                    {
                        errorsArray.Add($"{nameof(a.AccessPortalScheduleTypeUid)} contains an invalid value.");
                    }
                }

                var count = items.Count(o => o.AccessPortalScheduleTypeUid == a.AccessPortalScheduleTypeUid);
                if (count > 1)
                {
                    errorsArray.Add($"There are {count} items with {nameof(a.AccessPortalScheduleTypeUid)} value {a.AccessPortalScheduleTypeUid}. Only one (1) item is permitted for each {nameof(a.AccessPortalScheduleTypeUid)} value.");
                }
                else
                {
                    if (a.TimeScheduleUid != Guid.Empty)
                    {
                        if (!allowedTimeScheduleUids.Contains(a.TimeScheduleUid))
                        {
                            errorsArray.Add(
                                $"{nameof(TimeSchedule)} with {nameof(a.TimeScheduleUid)}:'{a.TimeScheduleUid}' is not found or is not mapped with the same cluster as the access portal.");
                        }
                    }
                }
                if (errorsArray.Any())
                    response.Errors.Add($"{propertyName}[{x}]", errorsArray.ToArray());

                x++;
            }

            return response;
        }

        private ValidationProblemDetails ValidateAreas(ICollection<AccessPortalArea> items, Guid clusterUid, string propertyName, IApplicationUserSessionDataHeader sessionData)
        {
            var areaRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyAreaRepository>();
            var areaUids = areaRepository.GetUidsForCluster(clusterUid);
            var areaTypeRepo = _dataRepositoryFactory.GetDataRepository<IAccessPortalAreaTypeRepository>();
            var areaTypes = areaTypeRepo.GetAll(sessionData, null);

            var response = new ValidationProblemDetails();
            var errorsArray = new List<string>();

            int x = 0;
            foreach (var a in items)
            {
                errorsArray.Clear();
                if (a.AccessPortalAreaTypeUid == Guid.Empty)
                {
                    errorsArray.Add($"{nameof(a.AccessPortalAreaTypeUid)} is missing or contains an empty value.");
                }
                else
                {
                    var aeType = areaTypes.FirstOrDefault(o =>
                        o.AccessPortalAreaTypeUid == a.AccessPortalAreaTypeUid);
                    if (aeType == null)
                    {
                        errorsArray.Add($"{nameof(a.AccessPortalAreaTypeUid)} contains an invalid value.");
                    }
                }

                var count = items.Count(o => o.AccessPortalAreaTypeUid == a.AccessPortalAreaTypeUid);
                if (count > 1)
                {
                    errorsArray.Add($"There are {count} items with {nameof(a.AccessPortalAreaTypeUid)} value {a.AccessPortalAreaTypeUid}. Only one (1) item is permitted for each {nameof(a.AccessPortalAreaTypeUid)} value.");
                }
                else
                {
                    if (!areaUids.Contains(a.AreaUid))
                    {
                        errorsArray.Add($"The {nameof(Area.AreaUid)} value {a.AreaUid} is not permitted because it does not exist or is from a different cluster.");
                    }
                }
                if (errorsArray.Any())
                    response.Errors.Add($"{propertyName}[{x}]", errorsArray.ToArray());

                x++;
            }

            return response;
        }
    }
}

