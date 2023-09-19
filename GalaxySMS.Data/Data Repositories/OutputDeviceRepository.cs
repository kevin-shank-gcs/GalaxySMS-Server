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

namespace GalaxySMS.Data
{
    [Export(typeof(IOutputDeviceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OutputDeviceRepository : PagedDataRepositoryBase<OutputDevice>, IOutputDeviceRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import] private IOutputDeviceEntityMapRepository _entityMapRepository;
        [Import] private IOutputDeviceGalaxyHardwareAddressRepository _outputDeviceGalaxyHardwareAddressRepository;
        [Import] private IGalaxyOutputDeviceRepository _galaxyOutputDeviceRepository;
        [Import] private IOutputCommandRepository _outputCommandRepository;
        [Import] private IGalaxyOutputDeviceInputSourceRepository _galaxyOutputDeviceInputSourceRepository;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;

        [Import] private IRoleOutputDeviceRepository _roleOutputDeviceRepository;

        protected override OutputDevice AddEntity(OutputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //this.Log().LogTransactionInformation($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.OutputDeviceUid,
                            PermissionIds.GalaxySMSDataAccessPermission
                                .OutputDeviceCanAddId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to add output device {entity.OutputDeviceUid}");
                    }
                }

                _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new OutputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.OutputDeviceUid, entity, saveParams);
                    SaveRoleMappings(sessionData, entity.OutputDeviceUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.OutputDeviceUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        UpdateEntityCount(entity.EntityId);
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::AddEntity", ex);
                throw;
            }
        }

        protected override OutputDevice UpdateEntity(OutputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.OutputDeviceUid,
                            GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission
                                .OutputDeviceCanUpdateId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update output device {entity.OutputDeviceUid}");
                    }
                }
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                // must read the original record from the database so the PDSA object can detect changes
                var originalEntity = GetEntityByGuidId(entity.OutputDeviceUid, sessionData, null);
                if (originalEntity != null && originalEntity.EntityId != entity.EntityId)
                {
                    if (!DoesUserHavePermission(sessionData, entity.ClusterUid, PermissionIds.GalaxySMSDataAccessPermission
                            .SystemHardwareCanUpdateId, originalEntity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update output device {entity.OutputDeviceUid}");
                    }
                }
                if (saveParams.SavePhoto)
                {
                    if (entity.gcsBinaryResource?.BinaryResource == null &&
                        originalEntity.BinaryResourceUid != Guid.Empty)
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

                var mgr = new OutputDevicePDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.OutputDeviceUid) >
                    0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if ClusterTypeUid is = Guid.Empty or null, then use the value from the original record
                    entity.ClusterTypeUid =
                        GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.ClusterTypeUid,
                            entity.ClusterTypeUid);

                    // if BinaryResourceUid is = Guid.Empty or null, then use the value from the original record
                    entity.BinaryResourceUid =
                        GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.BinaryResourceUid,
                            entity.BinaryResourceUid);

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId =
                        GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);

                    // if SiteUid is = Guid.Empty or null, then use the value from the original record
                    entity.SiteUid =
                        GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.SiteUid, entity.SiteUid);

                    // if ClusterUid is = Guid.Empty or null, then use the value from the original record
                    entity.ClusterUid =
                        GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.ClusterUid, entity.ClusterUid);



                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.OutputDeviceUid, entity, saveParams);
                        SaveRoleMappings(sessionData, entity.OutputDeviceUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.OutputDeviceUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);

                        var getParams = new GetParametersWithPhoto()
                            {IncludeMemberCollections = true, IncludePhoto = true, IncludeHardwareAddress = true};
                        getParams.ExcludeMemberCollectionSettings.AddRange(saveParams.IgnoreProperties);
                        updatedEntity = GetEntityByGuidId(entity.OutputDeviceUid, sessionData, getParams);
                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);

                        return updatedEntity;
                    }

                    return entity;
                }

                throw new Exception($"{entity.GetType().Name} {entity.OutputDeviceUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void EnsureChildRecordsExist(OutputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //saveParams.Options.Add(new KeyValuePair<string, string>(SaveInputDeviceAlertEventOption.ClusterUid.ToString(), $"{entity.ClusterUid}"));

            if (!saveParams.Ignore(nameof(entity.GalaxyOutputDevice)) && entity.GalaxyOutputDevice != null)
                SaveGalaxyOutputDevice(entity, sessionData, saveParams);
        }

        private void SaveGalaxyOutputDevice(OutputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            var galaxyOutputDev = _galaxyOutputDeviceRepository.GetByOutputDeviceUid(sessionData,
                new GetParametersWithPhoto() {UniqueId = entity.OutputDeviceUid});

            var propsToIgnore = new List<string>();
            propsToIgnore.Add(nameof(entity.GalaxyOutputDevice.OutputDeviceUid));
            if (galaxyOutputDev != null && (entity.GalaxyOutputDevice.IsAnythingDirty == true ||
                                            //entity.Properties.AreAnyValuesNotSpecified() ||
                                            ObjectComparer.AreAnyPublicPropertiesDifferent(galaxyOutputDev,
                                                entity.GalaxyOutputDevice, null, propsToIgnore)))
            {
                entity.GalaxyOutputDevice.OutputDeviceUid = galaxyOutputDev.OutputDeviceUid;

                UpdateTableEntityBaseProperties(entity.GalaxyOutputDevice, sessionData);
                _galaxyOutputDeviceRepository.Update(entity.GalaxyOutputDevice, sessionData, saveParams);
            }

            if (entity.GalaxyOutputDevice.OutputDeviceUid == Guid.Empty)
            {
                entity.GalaxyOutputDevice.OutputDeviceUid = entity.OutputDeviceUid;
                UpdateTableEntityBaseProperties(entity.GalaxyOutputDevice, sessionData);
                _galaxyOutputDeviceRepository.Add(entity.GalaxyOutputDevice, sessionData, saveParams);
            }
        }

        protected override int DeleteEntity(OutputDevice entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.OutputDeviceUid);
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var entityId = GetEntityId(id);
                if (!DoesUserHavePermission(sessionData, id,
                        GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.OutputDeviceCanDeleteId, entityId))
                {
                    throw new UnauthorizedAccessException(
                        $"UserName '{sessionData.UserName}' does not have permissions to delete output device {id}");
                }

                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new OutputDevicePDSAManager();

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
                        SaveAuditData(OperationType.Delete, sessionData, originalEntity, null,
                            mgr.DataObject.AuditRowAsXml);
                        UpdateEntityCount(originalEntity.EntityId);
                    }
                }

                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<OutputDevice> GetFilteredOutputDevices(IApplicationUserSessionDataHeader sessionData,
            IGetParametersBase getParameters, OutputDevicePDSAManager mgr)
        {
            IEnumerable<OutputDevice> entities = new List<OutputDevice>();
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                entities = mgr.ConvertPDSACollection(pdsaEntities);
                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a ap, creating RoleOutputDevice records
                //      2) When saving Role, creating RoleOutputDevice records
                // 
                //if (sessionData == null || sessionData.UserId == Guid.Empty)
                //{
                //    entities = mgr.ConvertPDSACollection(pdsaEntities);
                //}
                //else
                //{
                //    var filteredOutputDeviceUids = GetFilteredOutputDeviceUids(sessionData);
                //    var pdsaItems = pdsaEntities.Where(p => filteredOutputDeviceUids.Any(p2 => p2.OutputDeviceUid == p.OutputDeviceUid));

                //    entities = mgr.ConvertPDSACollection(pdsaItems);
                //}
            }

            return entities;
        }

        private EntityLayer.OutputDeviceUids_SelectForUserIdPDSACollection GetFilteredOutputDeviceUids(
            IApplicationUserSessionDataHeader sessionData)
        {
            var filteredMgr = new OutputDeviceUids_SelectForUserIdPDSAManager();
            filteredMgr.Entity.UserId = sessionData.UserId;
            var filteredOutputDeviceUids = filteredMgr.BuildCollection();
            return filteredOutputDeviceUids;
        }

        protected override IEnumerable<OutputDevice> GetEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByEntityId;
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<OutputDevice> GetAllEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetAllEntities", ex);
                throw;
            }
        }

        private IEnumerable<OutputDevice> GetIEnumerable(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters, OutputDevicePDSAManager mgr)
        {
            mgr.Entity.IsNodeActive = true;
            var getIsNodeActiveOnlyOption =
                getParameters.GetOption(GalaxySMS.Common.Enums.GetOutputDeviceOption.IsNodeActiveValue.ToString());
            if (getIsNodeActiveOnlyOption.HasValue)
            {
                mgr.Entity.IsNodeActive = getIsNodeActiveOnlyOption.Value;
            }

            var entities = GetFilteredOutputDevices(sessionData, getParameters, mgr);

            var isNodeActive = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_OutputDevice.IsNodeActive);
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

                if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludePhoto ||
                    getParameters.IncludeHardwareAddress || getParameters.IncludeCommands)
                    FillMemberCollections(entity, sessionData, getParameters);
            }

            if (isNodeActive.HasValue)
            {
                return entities.Where(o =>
                    o.GalaxyOutputDevice.GalaxyHardwareAddress.IsNodeActive == isNodeActive.Value &&
                    o.IsNodeActive == isNodeActive.Value).ToCollection();
            }

            return entities;
        }

#if UsePaging


        private IArrayResponse<OutputDevice> GetFilteredOutputDevicesPaged(
            IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters,
            OutputDevicePDSAManager mgr)
        {
            IEnumerable<OutputDevice> entities = new List<OutputDevice>();
            SetSortColumnAndOrder(getParameters, mgr);
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                entities = mgr.ConvertPDSACollection(pdsaEntities);
                var totalCount = 0;
                var first = entities.FirstOrDefault();
                if (first != null)
                    totalCount = first.TotalRowCount;
                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a ap, creating RoleOutputDevice records
                //      2) When saving Role, creating RoleOutputDevice records
                // 
                //if (sessionData == null || sessionData.UserId == Guid.Empty)
                //{
                //    entities = mgr.ConvertPDSACollection(pdsaEntities);
                //}
                //else
                //{
                //    var filteredOutputDeviceUids = GetFilteredOutputDeviceUids(sessionData);
                //    var pdsaItems = pdsaEntities.Where(p => filteredOutputDeviceUids.Any(p2 => p2.OutputDeviceUid == p.OutputDeviceUid));

                //    entities = mgr.ConvertPDSACollection(pdsaItems);
                //}
                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize,
                    totalCount);
            }

            return new ArrayResponse<OutputDevice>();
        }


        private IArrayResponse<OutputDevice> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters, OutputDevicePDSAManager mgr)
        {
            mgr.Entity.IsNodeActive = true;
            var getIsNodeActiveOnlyOption =
                getParameters.GetOption(GalaxySMS.Common.Enums.GetOutputDeviceOption.IsNodeActiveValue.ToString());
            if (getIsNodeActiveOnlyOption.HasValue)
            {
                mgr.Entity.IsNodeActive = getIsNodeActiveOnlyOption.Value;
            }

            var entities = GetFilteredOutputDevicesPaged(sessionData, getParameters, mgr);

            var isNodeActive = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_OutputDevice.IsNodeActive);
            if (isNodeActive.HasValue)
            {
                getParameters.IncludeHardwareAddress = true;
            }

            foreach (var entity in entities.Items)
            {
                if (isNodeActive.HasValue)
                {
                    if (entity.IsNodeActive != isNodeActive.Value)
                        continue;
                }

                if (getParameters.IncludeMemberCollections || getParameters.IncludePhoto ||
                    getParameters.IncludeHardwareAddress || getParameters.IncludeCommands)
                    FillMemberCollections(entity, sessionData, getParameters);
            }

            if (isNodeActive.HasValue)
            {
                var activeEntities = entities.Items.Where(o =>
                    isNodeActive != null &&
                    o.GalaxyOutputDevice.GalaxyHardwareAddress.IsNodeActive == isNodeActive.Value &&
                    o.IsNodeActive == isNodeActive.Value).ToCollection();
                return ArrayResponseHelpers.ToArrayResponse(activeEntities, entities.PageNumber, entities.PageSize,
                    entities.TotalItemCount);
            }

            return entities;
        }

        private IArrayResponse<OutputDeviceListItem> GetIEnumerableListItemPaged(
            IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters,
            OutputDevicePDSAManager mgr)
        {
            var outputDevices = GetFilteredOutputDevicesPaged(sessionData, getParameters, mgr);

            if (outputDevices != null)
            {
                var entities = new List<OutputDeviceListItem>();
                foreach (var e in outputDevices.Items)
                {
                    var idli = new OutputDeviceListItem()
                    {
                        EntityId = e.EntityId,
                        UniqueUid = e.OutputDeviceUid,
                        Name = e.OutputName,
                        ClusterGroupId = e.ClusterGroupId,
                        ClusterNumber = e.ClusterNumber,
                        PanelNumber = e.PanelNumber,
                        BoardNumber = e.BoardNumber,
                        SectionNumber = e.SectionNumber,
                        ModuleNumber = e.ModuleNumber,
                        NodeNumber = e.NodeNumber,
                    };

                    switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType) e.InterfaceBoardTypeCode)
                    {
                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                        case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                            idli.NodeNumber = 0;
                            break;

                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                            break;
                    }

                    entities.Add(idli);
                }

                return ArrayResponseHelpers.ToArrayResponse(entities, outputDevices.PageNumber, outputDevices.PageSize,
                    outputDevices.TotalItemCount);
            }

            return new ArrayResponse<OutputDeviceListItem>();
        }

        public IArrayResponse<OutputDevice> GetAllOutputDevicesForEntity(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }

        public IArrayResponse<OutputDevice> GetAllOutputDevicesForRegion(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByRegionUid;
                mgr.Entity.RegionUid = getParameters.UniqueId;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetAllOutputDevicesForRegion", ex);
                throw;
            }
        }

        public IArrayResponse<OutputDevice> GetAllOutputDevicesForSite(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.BySiteUid;
                mgr.Entity.SiteUid = getParameters.UniqueId;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetAllOutputDevicesForSite", ex);
                throw;
            }
        }

        public IArrayResponse<OutputDevice> GetAllOutputDevicesForCluster(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByClusterUid;
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetAllOutputDevicesForCluster", ex);
                throw;
            }
        }

        public IArrayResponse<OutputDevice> GetAllOutputDevicesForGalaxyPanel(
            IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                if (getParameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByGalaxyPanelUid;
                    mgr.Entity.GalaxyPanelUid = getParameters.UniqueId;
                }
                else
                {
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByGalaxyPanelAddress;
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetAllOutputDevicesForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<OutputDeviceListItem> GetOutputDeviceListForGalaxyPanel(
            IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {

                var mgr = new OutputDevicePDSAManager();

                mgr.Entity.IsNodeActive = true;
                var getIsNodeActiveOnlyOption =
                    parameters.GetOption(GalaxySMS.Common.Enums.GetOutputDeviceOption.IsNodeActiveValue.ToString());
                if (getIsNodeActiveOnlyOption.HasValue)
                {
                    mgr.Entity.IsNodeActive = getIsNodeActiveOnlyOption.Value;
                }

                if (parameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ListBoxByGalaxyPanelUid;
                    mgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                }
                else
                {
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ListBoxByGalaxyPanelAddress;
                    mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                    mgr.Entity.ClusterNumber = (short) parameters.ClusterNumber;
                    mgr.Entity.PanelNumber = (short) parameters.PanelNumber;
                }

                var data = GetIEnumerableListItemPaged(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {

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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetOutputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<OutputDevice> GetByNameOrComments(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                if (getParameters.GetOption(GetOptions_OutputDevice.SearchIncludesComments) == true)
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByNameAndComments;
                else
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByName;

                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.OutputName = getParameters.GetString;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetAllOutputDevicesForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<OutputDeviceListItem> GetListItemsByNameOrComments(
            IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters)
        {
            try
            {

                var mgr = new OutputDevicePDSAManager();

                if (getParameters.GetOption(GetOptions_OutputDevice.SearchIncludesComments) == true)
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByNameAndComments;
                else
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByName;

                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.OutputName = getParameters.GetString;
                var data = GetIEnumerableListItemPaged(sessionData, getParameters, mgr);
                if (getParameters.IncludeMemberCollections)
                {

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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetOutputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<OutputDeviceListItem> GetOutputDeviceListItemsForCluster(
            IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ListBoxByClusterUid;
                mgr.Entity.ClusterUid = parameters.ClusterUid;

                var data = GetIEnumerableListItemPaged(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {

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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetOutputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }
#else

        private IEnumerable<OutputDeviceListItem> GetIEnumerableListItem(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters, OutputDevicePDSAManager mgr)
        {
            var outputDevices = GetFilteredOutputDevices(sessionData, getParameters, mgr);

            if (outputDevices != null)
            {
                var entities = new List<OutputDeviceListItem>();
                foreach (var e in outputDevices)
                {
                    var idli = new OutputDeviceListItem()
                    {
                        EntityId = e.EntityId,
                        UniqueUid = e.OutputDeviceUid,
                        Name = e.OutputName,
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
                            idli.NodeNumber = 0;
                            break;

                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                        case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                            break;
                    }
                    entities.Add(idli);
                }
                return entities;
            }
            return null;
        }
        public IEnumerable<OutputDevice> GetAllOutputDevicesForEntity(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        public IEnumerable<OutputDevice> GetAllOutputDevicesForRegion(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByRegionUid;
                mgr.Entity.RegionUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//OutputDeviceRepository::GetAllOutputDevicesForRegion", ex);
                throw;
            }
        }

        public IEnumerable<OutputDevice> GetAllOutputDevicesForSite(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.BySiteUid;
                mgr.Entity.SiteUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//OutputDeviceRepository::GetAllOutputDevicesForSite", ex);
                throw;
            }
        }

        public IEnumerable<OutputDevice> GetAllOutputDevicesForCluster(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByClusterUid;
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetAllOutputDevicesForCluster", ex);
                throw;
            }
        }

        public IEnumerable<OutputDevice> GetAllOutputDevicesForGalaxyPanel(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                if (getParameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByGalaxyPanelUid;
                    mgr.Entity.GalaxyPanelUid = getParameters.UniqueId;
                }
                else
                {
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByGalaxyPanelAddress;
                    mgr.Entity.ClusterGroupId = getParameters.ClusterGroupId;
                    mgr.Entity.ClusterNumber = getParameters.ClusterNumber;
                    mgr.Entity.PanelNumber = getParameters.PanelNumber;
                }
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//OutputDeviceRepository::GetAllOutputDevicesForGalaxyPanel", ex);
                throw;
            }
        }

        public IEnumerable<OutputDeviceListItem> GetOutputDeviceListForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {

                var mgr = new OutputDevicePDSAManager();


                mgr.Entity.IsNodeActive = true;
                var getIsNodeActiveOnlyOption =
 parameters.GetOption(GalaxySMS.Common.Enums.GetOutputDeviceOption.IsNodeActiveValue.ToString());
                if (getIsNodeActiveOnlyOption.HasValue)
                {
                    mgr.Entity.IsNodeActive = getIsNodeActiveOnlyOption.Value;
                }

                if (parameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ListBoxByGalaxyPanelUid;
                    mgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                }
                else
                {
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ListBoxByGalaxyPanelAddress;
                    mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                    mgr.Entity.ClusterNumber = (short)parameters.ClusterNumber;
                    mgr.Entity.PanelNumber = (short)parameters.PanelNumber;
                }
                var data = GetIEnumerableListItem(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//OutputDeviceRepository::GetOutputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }

        public IEnumerable<OutputDevice> GetByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                if (getParameters.GetOption(GetOptions_OutputDevice.SearchIncludesComments) == true)
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByNameAndComments;
                else
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByName;

                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.OutputName = getParameters.GetString;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//OutputDeviceRepository::GetAllOutputDevicesForGalaxyPanel", ex);
                throw;
            }
        }

        public IEnumerable<OutputDeviceListItem> GetListItemsByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters)
        {
            try
            {

                var mgr = new OutputDevicePDSAManager();

                if (getParameters.GetOption(GetOptions_OutputDevice.SearchIncludesComments) == true)
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByNameAndComments;
                else
                    mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByName;

                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.OutputName = getParameters.GetString;
                var data = GetIEnumerableListItem(sessionData, getParameters, mgr);
                if (getParameters.IncludeMemberCollections)
                {

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//OutputDeviceRepository::GetOutputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }

        public IEnumerable<OutputDeviceListItem> GetOutputDeviceListItemsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ListBoxByClusterUid;
                mgr.Entity.ClusterUid = parameters.ClusterUid;

                var data = GetIEnumerableListItem(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//OutputDeviceRepository::GetOutputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }
#endif
        public OutputDeviceListItem GetOutputDeviceListItem(IApplicationUserSessionDataHeader sessionData,
            IGetParametersBase parameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ListBoxByPrimaryKey;
                mgr.Entity.OutputDeviceUid = parameters.UniqueId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var e = pdsaEntities.FirstOrDefault();
                    if (e != null)
                    {
                        if (!DoesUserHavePermission(sessionData, e.OutputDeviceUid,
                                GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission
                                    .OutputDeviceCanViewId, e.EntityId))
                        {
                            throw new UnauthorizedAccessException(
                                $"UserName '{sessionData.UserName}' does not have permissions to view output device {e.OutputName}");
                        }

                        var li = new OutputDeviceListItem()
                        {
                            EntityId = e.EntityId,
                            UniqueUid = e.OutputDeviceUid,
                            Name = e.OutputName,
                            ClusterGroupId = e.ClusterGroupId,
                            ClusterNumber = e.ClusterNumber,
                            PanelNumber = e.PanelNumber,
                            BoardNumber = e.BoardNumber,
                            SectionNumber = e.SectionNumber,
                            ModuleNumber = e.ModuleNumber,
                            NodeNumber = e.NodeNumber,
                        };

                        switch ((GalaxySMS.Common.Enums.GalaxyInterfaceBoardType) e.InterfaceBoardTypeCode)
                        {
                            case GalaxyInterfaceBoardType.DualReaderInterfaceBoard635:
                            case GalaxyInterfaceBoardType.DualReaderInterfaceBoard600:
                                li.NodeNumber = 0;
                                break;

                            case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                            case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                                break;
                        }

                        if (parameters.IncludeMemberCollections)
                        {
                        }

                        return li;
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

        public IEnumerable<Guid> GetOutputDeviceUidsForInterfaceBoardSection(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDeviceGalaxyHardwareAddressViewPDSAManager();
                mgr.DataObject.SelectFilter =
                    OutputDeviceGalaxyHardwareAddressViewPDSAData.SelectFilters.OutputDeviceUid;
                mgr.DataObject.WhereFilter = OutputDeviceGalaxyHardwareAddressViewPDSAData.WhereFilters
                    .GalaxyInterfaceBoardSectionUid;
                mgr.DataObject.OrderByFilter =
                    OutputDeviceGalaxyHardwareAddressViewPDSAData.OrderByFilters.PhysicalAddress;
                mgr.Entity.GalaxyInterfaceBoardSectionUid = getParameters.UniqueId;
                var results = mgr.BuildCollection();
                return results.Select(i => i.OutputDeviceUid).ToCollection();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetOutputDeviceUidsForInterfaceBoardSection", ex);
                throw;
            }

        }

        public IEnumerable<OutputDeviceSelectionItemBasic> GetAllOutputDeviceSelectionItemsForEntityAndCluster(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new OutputDevice_SelectionListForEntityAndClusterPDSAManager();
                mgr.Entity.EntityId = parameters.CurrentEntityId;
                mgr.Entity.ClusterUid = parameters.ClusterUid;

                //                var result = mgr.BuildCollection();
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<OutputDeviceSelectionItemBasic>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new OutputDeviceSelectionItemBasic();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        if (parameters.IncludeMemberCollections || parameters.IncludePhoto)
                        {
                            FillMemberCollections(newEntity, sessionData, parameters);
                        }

                        if (parameters.IncludePhoto == false && newEntity.Photo != null)
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetAllOutputDeviceGroupSelectionItemsForEntityAndCluster", ex);
                throw;
            }
        }

        public OutputDevice_GetHardwareInformation GetHardwareInformation(IApplicationUserSessionDataHeader sessionData,
            Guid inputDeviceUid)
        {
            try
            {
                var apHardwareInfoMgr = new OutputDevice_GetHardwareInformationPDSAManager
                {
                    Entity = {OutputDeviceUid = inputDeviceUid}
                };
                var apHardwareInfo = apHardwareInfoMgr.BuildCollection();
                if (apHardwareInfo.Count == 1)
                {
                    var convertedEntity = new OutputDevice_GetHardwareInformation();
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetHardwareInformation", ex);
                throw;
            }

            return null;
        }


        protected override OutputDevice GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override OutputDevice GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    if (!DoesUserHavePermission(sessionData, mgr.Entity.OutputDeviceUid,
                            GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission
                                .OutputDeviceCanViewId, mgr.Entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to view output device {mgr.Entity.OutputName}");
                    }

                    OutputDevice result = new OutputDevice();
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        public OutputDevice_PanelLoadData GetOutputDevicePanelLoadData(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevice_GetPanelLoadDataByOutputDeviceUidPDSAManager();
                mgr.Entity.OutputDeviceUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null && result.Count == 1)
                {
                    var returnData = new OutputDevice_PanelLoadData();
                    SimpleMapper.PropertyMap(result[0], returnData);
                    returnData.InputSources = _galaxyOutputDeviceInputSourceRepository
                        .GetPanelLoadDataForOutputDeviceUid(sessionData,
                            new GetParametersWithPhoto() {UniqueId = returnData.OutputDeviceUid}).ToCollection();

                    return returnData;
                }

                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //InputDeviceRepository::GetInputDevicePanelLoadData", ex);
                throw;
            }
        }


        public IEnumerable<OutputDevice_PanelLoadData> GetOutputDevicesPanelLoadData(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSAManager
                {
                    Entity = {GalaxyInterfaceBoardSectionUid = getParameters.UniqueId}
                };

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<OutputDevice_PanelLoadData>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new OutputDevice_PanelLoadData();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        newEntity.InputSources = _galaxyOutputDeviceInputSourceRepository
                            .GetPanelLoadDataForOutputDeviceUid(sessionData,
                                new GetParametersWithPhoto() {UniqueId = newEntity.OutputDeviceUid}).ToCollection();
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //InputDeviceRepository::GetAllInputDevicesForGalaxyPanel", ex);
                throw;
            }
        }


        public IEnumerable<OutputDevice_PanelLoadData> GetModifiedPanelLoadDataForCpu(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var results = new List<OutputDevice_PanelLoadData>();
                var mgr = new OutputDevice_GetPanelLoadDataChangesByCpuUidPDSAManager();
                mgr.Entity.CpuUid = parameters.UniqueId;
                mgr.Entity.ServerAddress = parameters.GetString;
                mgr.Entity.IsConnected = true;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                    {
                        var newEntity = new OutputDevice_PanelLoadData();
                        SimpleMapper.PropertyMap(i, newEntity);
                        newEntity.InputSources = _galaxyOutputDeviceInputSourceRepository
                            .GetPanelLoadDataForOutputDeviceUid(sessionData,
                                new GetParametersWithPhoto() {UniqueId = newEntity.OutputDeviceUid}).ToCollection();
                        results.Add(newEntity);
                    }

                    return results;
                }

                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //PersonRepository::GetCredentialPanelLoadDataForCluster", ex);
                throw;
            }
        }


        public void UpdateGalaxyOutputDeviceLastLoadedDate(Guid cpuUid, Guid outputDeviceUid)
        {
            try
            {
                var mgr = new OutputDeviceLoadToCpu_SaveLastLoadedDatePDSAManager
                {
                    Entity =
                    {
                        CpuUid = cpuUid,
                        OutputDeviceUid = outputDeviceUid
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


        public IArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(
            IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters)
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
                var mgr = new select_OutputDeviceActivityHistoryPDSAManager()
                {
                    Entity =
                    {
                        EntityId = parameters.CurrentEntityId,
                        DeviceUid = parameters.OutputDeviceUid,
                        StartDateTime = parameters.StartDateTime,
                        EndDateTime = parameters.EndDateTime,
                        PageNumber = parameters.PageNumber,
                        PageSize = parameters.PageSize,
                        MaxResults = parameters.MaxResults
                    }
                };

                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;

                mgr.Entity.CultureName =
                    lang != null ? lang.CultureName : GalaxySMS.Common.Constants.LanguageCultures.EnglishUs;

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

                    return ArrayResponseHelpers.ToArrayResponse(results, parameters.PageNumber, parameters.PageSize,
                        totalCount);
                }

                return new ArrayResponse<ActivityHistoryEvent>();
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //PersonRepository::GetCredentialPanelLoadDataForCluster", ex);
                throw;
            }
        }



        protected override void SaveAuditData(OperationType operationType,
            IApplicationUserSessionDataHeader sessionData,
            OutputDevice originalEntity, OutputDevice newEntity, string auditXml)
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
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase
                                    .GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase
                                    .GetCurrentMethod()));

                        List<String> propertiesToIgnore = new List<string>();
                        propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        propertiesToIgnore.Add("GalaxyOutputDevice");
                        propertiesToIgnore.Add("EntityIds");
                        propertiesToIgnore.Add("MappedEntitiesPermissionLevels");
                        propertiesToIgnore.Add("Notes");
                        propertiesToIgnore.Add("Commands");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "OutputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.OutputDeviceUid;
                        mgr.Entity.RecordTag = newEntity.OutputDeviceUid.ToString();
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
                            SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity,
                                propertiesToIgnore);
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
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase
                                    .GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "OutputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.OutputDeviceUid;
                        mgr.Entity.RecordTag = newEntity.OutputDeviceUid.ToString();
                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase
                                    .GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "OutputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.OutputDeviceUid;
                        mgr.Entity.RecordTag = originalEntity.OutputDeviceUid.ToString();
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(OutputDevice entity,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                return;

            if (getParameters.IncludePhoto)
            {
                if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
                {
                    entity.gcsBinaryResource =
                        _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
                }
            }

            var p = new GetParametersWithPhoto(getParameters)
            {
                UniqueId = entity.OutputDeviceUid, IncludeMemberCollections = true,
                IncludeHardwareAddress = getParameters.IncludeHardwareAddress
            };

            if (!getParameters.IsExcluded(nameof(entity.GalaxyOutputDevice)) || getParameters.IncludeHardwareAddress ||
                getParameters.IncludeCommands)
            {
                entity.GalaxyOutputDevice = _galaxyOutputDeviceRepository.GetByOutputDeviceUid(sessionData, p);
                if (entity.GalaxyOutputDevice?.GalaxyHardwareAddress?.OutputDeviceHardwareInformation != null)
                {
                    entity.ClusterUid = entity.GalaxyOutputDevice.GalaxyHardwareAddress.OutputDeviceHardwareInformation
                        .ClusterUid;
                    entity.GalaxyPanelUid = entity.GalaxyOutputDevice.GalaxyHardwareAddress
                        .OutputDeviceHardwareInformation.GalaxyPanelUid;
                }
            }

            if (getParameters.IncludeCommands && entity.IsNodeActive)
            {
                var getP = new GetParametersWithPhoto()
                    {UniqueId = entity.GalaxyOutputDevice.GalaxyOutputModeUid, IncludePhoto = false};
                var cmds = _outputCommandRepository.GetAllOutputCommandsForOutputMode(sessionData, getP).ToCollection();

                entity.Commands = cmds;
            }


            var entityMaps = _entityMapRepository.GetAllOutputDeviceEntityMapsForOutputDevice(sessionData,
                new GetParametersWithPhoto() {UniqueId = entity.OutputDeviceUid});
            var entityIds = (from e in entityMaps select e.EntityId).ToList();
            entity.EntityIds.AddRange(entityIds);
            //foreach ( var e in entityMaps)
            //{
            //    if(e.EntityId != entity.EntityId)
            //        entity.EntityIds.Add(e.EntityId);
            //}
            entity.EntityIds.Add(entity.EntityId);

            if (!p.IsExcluded(nameof(OutputDevice.RoleIds)))
            {
                var roleFilters = _roleOutputDeviceRepository.GetAllForOutputDeviceUid(sessionData,
                    new GetParametersWithPhoto() {UniqueId = entity.OutputDeviceUid});
                var roleIds = (from e in roleFilters select e.RoleId).ToList();
                entity.RoleIds.AddRange(roleIds);
            }
        }

        protected void FillMemberCollections(OutputDeviceSelectionItemBasic entity,
            IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            if (entity.Photo != null && entity.Photo.Length > 0 && getParameters.IncludePhoto &&
                getParameters.PhotoPixelWidth > 0)
            {
                var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(
                    GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.Photo),
                    getParameters.PhotoPixelWidth);
                entity.Photo = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
            }

            if (getParameters.IncludePhoto == false && entity.Photo != null)
                entity.Photo = null;
        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid,
            IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() {UniqueId = uid};
            var existingEntityMappings = _entityMapRepository.GetAllOutputDeviceEntityMapsForOutputDevice(sessionData,
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
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.OutputDeviceEntityMapUid, sessionData);
                }
            }

            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new OutputDeviceEntityMap();
                    entityMap.OutputDeviceEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.OutputDeviceUid = uid;
                    entityMap.EntityId = entityId;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }


        private void SaveRoleMappings(IApplicationUserSessionDataHeader sessionData, Guid uid,
            IHasRoleMappingList entity, ISaveParameters saveParams)
        {
            if (entity.RoleIds == null || !entity.RoleIds.Any() || saveParams.Ignore(nameof(entity.RoleIds)))
                return;

            var getParameters = new GetParametersWithPhoto() {UniqueId = uid};
            var existingRoleOutputDevices =
                _roleOutputDeviceRepository.GetAllForOutputDeviceUid(sessionData, getParameters);
            var existingRoleIds = new HashSet<Guid>(existingRoleOutputDevices.Select(e => e.RoleId));
            var deleteRoleIds = existingRoleIds.Except(entity.RoleIds);

            foreach (var rid in deleteRoleIds)
            {
                var rc = existingRoleOutputDevices.FirstOrDefault(o => o.RoleId == rid);
                if (rc != null)
                    _roleOutputDeviceRepository.Remove(rc.RoleOutputDeviceUid, sessionData);
            }

            foreach (var roleId in entity.RoleIds)
            {
                if (!existingRoleIds.Contains(roleId))
                {
                    var roleOutputDevice = new RoleOutputDevice();
                    roleOutputDevice.RoleOutputDeviceUid = GuidUtilities.GenerateComb();
                    roleOutputDevice.OutputDeviceUid = uid;
                    roleOutputDevice.RoleId = roleId;
                    UpdateTableEntityBaseProperties(roleOutputDevice, sessionData);

                    _roleOutputDeviceRepository.Add(roleOutputDevice, sessionData, saveParams);
                }
            }

        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("OutputDevice", "OutputDeviceUid",
                id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("OutputDevice", "OutputDeviceUid", id);
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

        protected override bool IsEntityUnique(OutputDevice entity)
        {
            var mgr = new IsOutputDeviceUniquePDSAManager();
            mgr.Entity.OutputDeviceUid = entity.OutputDeviceUid;
            mgr.Entity.OutputName = entity.OutputName;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("OutputDevice", "OutputDeviceUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("OutputDevice", "OutputDeviceUid", id);
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
                var mgr = new gcsEntityCountPDSA_InsertOutputDeviceCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        #region Implementation of IOutputDeviceRepository

        public OutputDevice EnsureOutputDeviceExists(IApplicationUserSessionDataHeader sessionData,
            EnsureOutputDeviceExistsParameters parameters, ISaveParameters saveParams)
        {
            // Start by seeing if one exists for the GalaxyInterfaceBoardSectionNode
            var existing =
                _outputDeviceGalaxyHardwareAddressRepository.GetByOutputDeviceGalaxyHardwareAddressUid(sessionData,
                    new GetParametersWithPhoto() {UniqueId = parameters.TheNode.GalaxyInterfaceBoardSectionNodeUid});
            if (existing != null)
                return GetEntityByGuidId(existing.OutputDeviceUid, sessionData,
                    new GetParametersWithPhoto() {UniqueId = existing.OutputDeviceUid});

            OutputDevice templateItem = null;
            OutputDevice newItem = null;

            var outputOffset = (parameters.TheNode.ModuleNumber - 1) * 8;

            var newName = string.Format(GalaxySMS.Resources.Resources.OutputDevice_DefaultGalaxyName,
                parameters.TheNode.ClusterGroupId, parameters.TheNode.ClusterNumber,
                parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber, parameters.TheNode.SectionNumber,
                parameters.TheNode.NodeNumber + outputOffset);

            // This call had to be replaced with storedProc instead of using the OutputDevicePDSAManager. For some reason
            // using OutputDevicePDSAManager killed the current transaction and lead to errors with subsequent insert operations
            var duplicateNamedOutputDevices = GetOutputDevicesByNameAndSite(sessionData, new GetParametersWithPhoto()
            {
                IncludeMemberCollections = false,
                GetString = newName,
                GetGuid = parameters.SiteUid
            });

            if (duplicateNamedOutputDevices.Any())
            {
                for (int x = 1; x < 1000; x++)
                {
                    newName = string.Format(GalaxySMS.Resources.Resources.OutputDevice_DefaultGalaxyName,
                        parameters.TheNode.ClusterGroupId, parameters.TheNode.ClusterNumber,
                        parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber,
                        parameters.TheNode.SectionNumber,
                        parameters.TheNode.NodeNumber + outputOffset);
                    newName += $" ({x})";
                    if (duplicateNamedOutputDevices.FirstOrDefault(o => o.ToLower() == newName.ToLower()) == null)
                        break;
                }
            }

            // If none exists, create one
            if (parameters.TemplateOutputDeviceUid != Guid.Empty)
                templateItem = GetEntityByGuidId(parameters.TemplateOutputDeviceUid, sessionData,
                    new GetParametersWithPhoto() {UniqueId = parameters.TemplateOutputDeviceUid});
            if (templateItem == null)
            {

                var noIog = parameters.InputOutputGroups.FirstOrDefault(o =>
                    o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);
                if (noIog == null)
                    noIog = new InputOutputGroup();

                newItem = new OutputDevice();
                newItem.InsertName = sessionData.UserName;
                newItem.InsertDate = DateTimeOffset.Now;

                //newItem.EMailEventsEnabled = true;
                //newItem.TransmitEventsEnabled = true;
                //newItem.FileOutputEnabled = true;
                newItem.GalaxyOutputDevice.TimeScheduleUid =
                    GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
                newItem.GalaxyOutputDevice.GalaxyOutputModeUid = GalaxySMS.Common.Constants.GalaxyOutputModeIds.Follows;
                newItem.GalaxyOutputDevice.GalaxyOutputInputSourceRelationshipUid =
                    GalaxySMS.Common.Constants.GalaxyOutputInputSourceRelationshipIds.OR;
                newItem.GalaxyOutputDevice.Limit = 1;

                // Create the four input sources
                for (short x = 1; x <= 4; x++)
                {
                    var inputSource = new GalaxyOutputDeviceInputSource()
                    {
                        SourceNumber = x,
                        GalaxyOutputInputSourceTriggerConditionUid = GalaxySMS.Common.Constants
                            .GalaxyOutputInputSourceTriggerConditionIds.Nothing,
                        GalaxyOutputInputSourceModeUid = GalaxySMS.Common.Constants.GalaxyOutputInputSourceModeIds.OR,
                        InputOutputGroupUid = noIog.InputOutputGroupUid,
                        InputOutputGroupMode = false
                    };

                    // 32 offsets
                    for (short offset = 0; offset < 32; offset++)
                    {
                        //inputSource.GalaxyOutputDeviceInputSourceAssignments.Add(new GalaxyOutputDeviceInputSourceAssignment()
                        //{
                        //});

                    }

                    newItem.GalaxyOutputDevice.GalaxyOutputDeviceInputSources.Add(inputSource);
                }
            }
            else
            {
                newItem = templateItem.Clone(templateItem);
            }

            newItem.OutputDeviceUid = GuidUtilities.GenerateComb();
            newItem.EntityId = sessionData.CurrentEntityId;
            //            newItem.SiteUid = sessionData.CurrentSiteId;
            newItem.SiteUid = parameters.SiteUid;
            newItem.OutputName = newName;

            newItem.InsertName = sessionData.UserName;
            newItem.InsertDate = DateTimeOffset.Now;
            newItem.UpdateName = newItem.InsertName;
            newItem.UpdateDate = newItem.InsertDate;
            newItem.RoleIds = parameters.RoleIds;

            var returnItem = AddEntity(newItem, sessionData, saveParams);
            if (returnItem != null)
            {
                var hwAddress = new OutputDeviceGalaxyHardwareAddress
                {
                    OutputDeviceGalaxyHardwareAddressUid = GuidUtilities.GenerateComb(),
                    OutputDeviceUid = returnItem.OutputDeviceUid,
                    GalaxyInterfaceBoardSectionNodeUid = parameters.TheNode.GalaxyInterfaceBoardSectionNodeUid,
                    InsertName = sessionData.UserName,
                    InsertDate = DateTimeOffset.Now,
                    UpdateName = newItem.InsertName,
                    UpdateDate = newItem.InsertDate,
                    GalaxyPanelUid = parameters.TheNode.GalaxyPanelUid
                };
                _outputDeviceGalaxyHardwareAddressRepository.Add(hwAddress, sessionData, saveParams);
            }

            return returnItem;
        }

        #endregion

        public bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid outputDeviceUid,
            Guid permissionId, Guid entityId)
        {
            // If no permission is specified, return true to indicate that permission is granted
            if (permissionId == Guid.Empty)
                return true;

            if (!sessionData.IsPermissionCheckPossible)
                return true;

            var mgr = new OutputDevice_GetUserPermissionPDSAManager();
            mgr.Entity.UserId = sessionData.UserId;
            mgr.Entity.OutputDeviceUid = outputDeviceUid;
            mgr.Entity.PermissionId = permissionId;
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            if (results?.Count > 0)
                return true;
            return false;
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, OutputDevicePDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<OutputDeviceSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }

        protected override IArrayResponse<OutputDevice> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId == Guid.Empty)
                    getParameters.UniqueId = sessionData.CurrentEntityId;
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
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<OutputDevice> GetAllEntitiesPaged(
            IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new OutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = OutputDevicePDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new OutputDevice_GetAllUidsFromRoleIdPDSAManager();
            mgr.Entity.RoleId = roleId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.OutputDeviceUid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndClusterUid(Guid roleId, Guid clusterUid)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new OutputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAManager();
            mgr.Entity.RoleId = roleId;
            mgr.Entity.ClusterUid = clusterUid;
            var results = mgr.BuildCollection();
            return results.Select(o => o.OutputDeviceUid);
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForOutputDevicePDSAManager
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


        public IEnumerable<string> GetOutputDevicesByNameAndSite(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new OutputDevicePDSA_GetNamesForSiteUidPDSAManager();
                mgr.Entity.SiteUid = parameters.GetGuid;
                mgr.Entity.OutputName = parameters.GetString;

                var data = mgr.BuildCollection();

                return data.Select(o=>o.OutputName);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //OutputDeviceRepository::GetOutputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }
    }
}