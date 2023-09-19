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
    [Export(typeof(IInputDeviceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InputDeviceRepository : PagedDataRepositoryBase<InputDevice>, IInputDeviceRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import] private IInputDeviceEntityMapRepository _entityMapRepository;
        [Import] private IInputDeviceAlertEventTypeRepository _inputDeviceAlertEventTypeRepository;
        [Import] private IGalaxyInputDeviceRepository _galaxyInputDeviceRepository;
        [Import] private IInputDeviceEventPropertiesRepository _inputDeviceEventPropertiesRepository;
        [Import] private IInputDeviceGalaxyHardwareAddressRepository _inputDeviceGalaxyHardwareAddressRepository;
        [Import] private IInputDeviceNoteRepository _inputDeviceNoteRepository;
        [Import] private INoteRepository _noteRepository;
        [Import] private IInputCommandRepository _inputCommandRepository;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private IRoleInputDeviceRepository _roleInputDeviceRepository;

        protected override InputDevice AddEntity(InputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.InputDeviceUid,
                            PermissionIds.GalaxySMSDataAccessPermission
                                .InputDeviceCanAddId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to add input device {entity.InputDeviceUid}");
                    }
                }

                _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new InputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.InputDeviceUid, entity, saveParams);
                    SaveRoleMappings(sessionData, entity.InputDeviceUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.InputDeviceUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::AddEntity", ex);
                throw;
            }
        }

        protected override InputDevice UpdateEntity(InputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                if (entity.EntityId != Guid.Empty)
                {
                    if (!DoesUserHavePermission(sessionData, entity.InputDeviceUid,
                            GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission
                                .InputDeviceCanUpdateId, entity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update input device {entity.InputDeviceUid}");
                    }
                }

                var originalEntity = GetEntityByGuidId(entity.InputDeviceUid, sessionData, null);
                if (originalEntity != null && originalEntity.EntityId != entity.EntityId)
                {
                    if (!DoesUserHavePermission(sessionData, entity.ClusterUid, PermissionIds.GalaxySMSDataAccessPermission
                            .SystemHardwareCanUpdateId, originalEntity.EntityId))
                    {
                        throw new UnauthorizedAccessException(
                            $"UserName '{sessionData.UserName}' does not have permissions to update input device {entity.InputDeviceUid}");
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

                var mgr = new InputDevicePDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.InputDeviceUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if BinaryResourceUid is = Guid.Empty or null, then use the value from the original record
                    entity.BinaryResourceUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.BinaryResourceUid, entity.BinaryResourceUid);

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);

                    // if SiteUid is = Guid.Empty or null, then use the value from the original record
                    entity.SiteUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.SiteUid, entity.SiteUid);

                    // if ClusterUid is = Guid.Empty or null, then use the value from the original record
                    entity.ClusterUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.ClusterUid, entity.ClusterUid);

                    // must read the original record from the database so the PDSA object can detect changes

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.InputDeviceUid, entity, saveParams);
                        SaveRoleMappings(sessionData, entity.InputDeviceUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.InputDeviceUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);

                        var getParams = new GetParametersWithPhoto() { IncludeMemberCollections = true, IncludePhoto = true, IncludeHardwareAddress = true };
                        getParams.ExcludeMemberCollectionSettings.AddRange(saveParams.IgnoreProperties);
                        updatedEntity = GetEntityByGuidId(entity.InputDeviceUid, sessionData, getParams);
                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.InputDeviceUid} not found");

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::UpdateEntity", ex);
                throw;
            }
        }
        private void EnsureChildRecordsExist(InputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //saveParams.Options.Add(new KeyValuePair<string, string>(SaveInputDeviceAlertEventOption.ClusterUid.ToString(), $"{entity.ClusterUid}"));

            if (!saveParams.Ignore(nameof(entity.InputDeviceEventProperties)) && entity.InputDeviceEventProperties != null)
                SaveEventProperties(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.GalaxyInputDevice)) && entity.GalaxyInputDevice != null)
                SaveGalaxyInputDevice(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.Notes)) && entity.Notes != null)
                SaveNotes(entity, sessionData, saveParams);
        }
        private void SaveEventProperties(InputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.InputDeviceEventProperties == null || !entity.InputDeviceEventProperties.Any())
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveInputDeviceEventPropertiesOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveInputDeviceEventPropertiesOption.DeleteMissingItems.ToString();

            var eventTypes = _inputDeviceAlertEventTypeRepository.GetAll(sessionData, new GetParametersWithPhoto() { });

            // Get all items from the database
            var items = _inputDeviceEventPropertiesRepository.GetByInputDeviceUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid });

            // If any do not have a InputDeviceEventPropertiesUid (PrimaryKey value), see if we can determine the value by InputDeviceAlertEventTypeUid
            foreach (var p in entity.InputDeviceEventProperties.Where(o => o.InputDeviceEventPropertiesUid == Guid.Empty))
            {
                var i = items.FirstOrDefault(o => o.InputDeviceAlertEventTypeUid == p.InputDeviceAlertEventTypeUid);
                if (i != null)
                {
                    p.InputDeviceEventPropertiesUid = i.InputDeviceEventPropertiesUid;
                }
            }

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Portal
                foreach (var i in items)
                {
                    // If the AccessPortalAreaUid does not exist in the entity, then delete the area from the database
                    if (entity.InputDeviceEventProperties.FirstOrDefault(o => o.InputDeviceEventPropertiesUid == i.InputDeviceEventPropertiesUid) == null)
                    {
                        _inputDeviceEventPropertiesRepository.Remove(i.InputDeviceEventPropertiesUid, sessionData);
                    }
                }
            }

            var propsToInclude = new List<string>();

            // Now save those that are defined in the Access Portal being saved
            foreach (var i in entity.InputDeviceEventProperties)
            {
                if (i.InputDeviceUid != entity.InputDeviceUid)
                    i.InputDeviceUid = entity.InputDeviceUid;

                if (!propsToInclude.Any())
                {
                    propsToInclude.Add(nameof(i.AudioBinaryResourceUid));
                    propsToInclude.Add(nameof(i.ResponseInstructionsUid));
                    propsToInclude.Add(nameof(i.AcknowledgeTimeScheduleUid));
                    propsToInclude.Add(nameof(i.AcknowledgePriority));
                    propsToInclude.Add(nameof(i.ResponseRequired));
                    propsToInclude.Add(nameof(i.IsActive));
                }

                var existingItem = items.FirstOrDefault(o => o.InputDeviceEventPropertiesUid == i.InputDeviceEventPropertiesUid);

                if (existingItem != null)
                {
                    if (existingItem.Note.Photo == null && i.Note?.Photo?.Length == 0)
                        i.Note.Photo = null;
                    if (existingItem.Note.Document == null && i.Note?.Document?.Length == 0)
                        i.Note.Document = null;
                }

                if (existingItem != null && (i.IsAnythingDirty ||
                    ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i, propsToInclude)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _inputDeviceEventPropertiesRepository.Update(i, sessionData, saveParams);
                }
                if (i.InputDeviceEventPropertiesUid == Guid.Empty)
                {
                    i.InputDeviceEventPropertiesUid = GuidUtilities.GenerateComb();
                    i.InputDeviceUid = entity.InputDeviceUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _inputDeviceEventPropertiesRepository.Add(i, sessionData, saveParams);
                }
            }
        }
        private void SaveGalaxyInputDevice(InputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            // AccessPortalProperties
            var props = _galaxyInputDeviceRepository.GetByInputDeviceUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid });

            var propsToIgnore = new List<string>();
            propsToIgnore.Add(nameof(entity.GalaxyInputDevice.InputDeviceUid));
            if (props != null && (entity.GalaxyInputDevice.IsAnythingDirty == true ||
                                  //entity.Properties.AreAnyValuesNotSpecified() ||
                                  ObjectComparer.AreAnyPublicPropertiesDifferent(props, entity.GalaxyInputDevice, null, propsToIgnore)))
            {
                entity.GalaxyInputDevice.InputDeviceUid = props.InputDeviceUid;

                UpdateTableEntityBaseProperties(entity.GalaxyInputDevice, sessionData);
                _galaxyInputDeviceRepository.Update(entity.GalaxyInputDevice, sessionData, saveParams);
            }
            if (entity.GalaxyInputDevice.InputDeviceUid == Guid.Empty)
            {
                entity.GalaxyInputDevice.InputDeviceUid = entity.InputDeviceUid;
                UpdateTableEntityBaseProperties(entity.GalaxyInputDevice, sessionData);
                _galaxyInputDeviceRepository.Add(entity.GalaxyInputDevice, sessionData, saveParams);
            }
        }
        private void SaveNotes(InputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.Notes == null || !entity.Notes.Any())
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveAccessPortalNotesOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveAccessPortalNotesOption.DeleteMissingItems.ToString();

            // Notes
            var items = _inputDeviceNoteRepository.GetByInputDeviceUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid });

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
                    var apn = new InputDeviceNote()
                    {
                        InputDeviceNoteUid = GuidUtilities.GenerateComb(),
                        NoteUid = i.NoteUid,
                        InputDeviceUid = entity.InputDeviceUid
                    };
                    UpdateTableEntityBaseProperties(apn, sessionData);
                    _inputDeviceNoteRepository.Add(apn, sessionData, saveParams);
                }
            }
        }
        protected override int DeleteEntity(InputDevice entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.InputDeviceUid);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var entityId = GetEntityId(id);

                if (!DoesUserHavePermission(sessionData, id, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanDeleteId, entityId))
                {
                    throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to delete input device {id}");
                }

                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new InputDevicePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<InputDevice> GetFilteredInputDevices(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters, InputDevicePDSAManager mgr)
        {
            IEnumerable<InputDevice> entities = new List<InputDevice>();
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                entities = mgr.ConvertPDSACollection(pdsaEntities);

                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a ap, creating RoleInputDevice records
                //      2) When saving Role, creating RoleInputDevice records
                // 

                //if (sessionData == null || sessionData.UserId == Guid.Empty)
                //{
                //    entities = mgr.ConvertPDSACollection(pdsaEntities);
                //}
                //else
                //{
                //    var filteredInputDeviceUids = GetFilteredInputDeviceUids(sessionData);
                //    var pdsaItems = pdsaEntities.Where(p => filteredInputDeviceUids.Any(p2 => p2.InputDeviceUid == p.InputDeviceUid));

                //    entities = mgr.ConvertPDSACollection(pdsaItems);
                //}
            }
            return entities;
        }

        private IArrayResponse<InputDevice> GetFilteredInputDevicesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters, InputDevicePDSAManager mgr)
        {
            IEnumerable<InputDevice> entities = new List<InputDevice>();
            SetSortColumnAndOrder(getParameters, mgr);
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                entities = mgr.ConvertPDSACollection(pdsaEntities);
                var first = pdsaEntities.FirstOrDefault();
                var totalCount = 0;
                if (first != null)
                {
                    totalCount = first.TotalRowCount;
                }

                // Commented this out 2021-12-03 when working with Ukraine team. This area needs work to create the filters properly. Too complicated to present to the UK team
                // until later.
                // Issues that must be addressed are: 
                //      1) When saving a ap, creating RoleInputDevice records
                //      2) When saving Role, creating RoleInputDevice records
                // 

                //if (sessionData == null || sessionData.UserId == Guid.Empty)
                //{
                //    entities = mgr.ConvertPDSACollection(pdsaEntities);
                //}
                //else
                //{
                //    var filteredInputDeviceUids = GetFilteredInputDeviceUids(sessionData);
                //    var pdsaItems = pdsaEntities.Where(p => filteredInputDeviceUids.Any(p2 => p2.InputDeviceUid == p.InputDeviceUid));

                //    entities = mgr.ConvertPDSACollection(pdsaItems);
                //}
                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
            }
            return new ArrayResponse<InputDevice>();
        }

        private EntityLayer.InputDeviceUids_SelectForUserIdPDSACollection GetFilteredInputDeviceUids(IApplicationUserSessionDataHeader sessionData)
        {
            var filteredMgr = new InputDeviceUids_SelectForUserIdPDSAManager();
            filteredMgr.Entity.UserId = sessionData.UserId;
            var filteredInputDeviceUids = filteredMgr.BuildCollection();
            return filteredInputDeviceUids;
        }

        private IEnumerable<InputDevice> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, InputDevicePDSAManager mgr)
        {
            mgr.Entity.IsNodeActive = true;
            var getIsNodeActiveOnlyOption = getParameters.GetOption(GalaxySMS.Common.Enums.GetInputDeviceOption.IsNodeActiveValue.ToString());
            if (getIsNodeActiveOnlyOption.HasValue)
            {
                mgr.Entity.IsNodeActive = getIsNodeActiveOnlyOption.Value;
            }

            var entities = GetFilteredInputDevices(sessionData, getParameters, mgr);

            var isNodeActive = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_InputDevice.IsNodeActive);
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
                return entities.Where(o => o.GalaxyInputDevice.GalaxyHardwareAddress.IsNodeActive == isNodeActive.Value && o.IsNodeActive == isNodeActive.Value).ToCollection();
            }
            return entities;
        }

        protected override IEnumerable<InputDevice> GetEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<InputDevice> GetAllEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllEntities", ex);
                throw;
            }
        }

#if UsePaging
        private IArrayResponse<InputDevice> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, InputDevicePDSAManager mgr)
        {
            mgr.Entity.IsNodeActive = true;
            var getIsNodeActiveOnlyOption = getParameters.GetOption(GalaxySMS.Common.Enums.GetInputDeviceOption.IsNodeActiveValue.ToString());
            if (getIsNodeActiveOnlyOption.HasValue)
            {
                mgr.Entity.IsNodeActive = getIsNodeActiveOnlyOption.Value;
            }

            var entities = GetFilteredInputDevicesPaged(sessionData, getParameters, mgr);

            var isNodeActive = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_InputDevice.IsNodeActive);
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
                if (getParameters.IncludeMemberCollections || getParameters.IncludePhoto || getParameters.IncludeHardwareAddress || getParameters.IncludeCommands)
                    FillMemberCollections(entity, sessionData, getParameters);
            }

            if (isNodeActive.HasValue)
            {
                var activeEntities = entities.Items.Where(o => isNodeActive != null && o.GalaxyInputDevice.GalaxyHardwareAddress.IsNodeActive == isNodeActive.Value && o.IsNodeActive == isNodeActive.Value).ToCollection();
                return ArrayResponseHelpers.ToArrayResponse(activeEntities, entities.PageNumber, entities.PageSize,
                    entities.TotalItemCount);
            }
            return entities;
        }
        private IArrayResponse<InputDeviceListItem> GetIEnumerableListItemPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersBase getParameters, InputDevicePDSAManager mgr)
        {
            var inputDevices = GetFilteredInputDevicesPaged(sessionData, getParameters, mgr);

            if (inputDevices != null)
            {
                var entities = new List<InputDeviceListItem>();
                foreach (var e in inputDevices.Items)
                {
                    var idli = new InputDeviceListItem()
                    {
                        EntityId = e.EntityId,
                        UniqueUid = e.InputDeviceUid,
                        Name = e.InputName,
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
                return ArrayResponseHelpers.ToArrayResponse(entities, inputDevices.PageNumber, inputDevices.PageSize, inputDevices.TotalItemCount);
            }
            return new ArrayResponse<InputDeviceListItem>();
        }

        public IArrayResponse<InputDevice> GetAllInputDevicesForEntity(IApplicationUserSessionDataHeader sessionData,
        IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }

        public IArrayResponse<InputDevice> GetAllInputDevicesForRegion(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByRegionUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForRegion", ex);
                throw;
            }
        }

        public IArrayResponse<InputDevice> GetAllInputDevicesForSite(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.BySiteUid;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.Entity.SiteUid = getParameters.UniqueId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForSite", ex);
                throw;
            }
        }

        public IArrayResponse<InputDevice> GetAllInputDevicesForCluster(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByClusterUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForCluster", ex);
                throw;
            }
        }

        public IArrayResponse<InputDevice> GetAllInputDevicesForGalaxyPanel(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                if (getParameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByGalaxyPanelUid;
                    mgr.Entity.GalaxyPanelUid = getParameters.UniqueId;
                }
                else
                {
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByGalaxyPanelAddress;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<InputDeviceListItem> GetInputDeviceListForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {

                var mgr = new InputDevicePDSAManager();

                mgr.Entity.IsNodeActive = true;
                var getIsNodeActiveOnlyOption = parameters.GetOption(GalaxySMS.Common.Enums.GetInputDeviceOption.IsNodeActiveValue.ToString());
                if (getIsNodeActiveOnlyOption.HasValue)
                {
                    mgr.Entity.IsNodeActive = getIsNodeActiveOnlyOption.Value;
                }

                if (parameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ListBoxByGalaxyPanelUid;
                    mgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                }
                else
                {
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ListBoxByGalaxyPanelAddress;
                    mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                    mgr.Entity.ClusterNumber = (short)parameters.ClusterNumber;
                    mgr.Entity.PanelNumber = (short)parameters.PanelNumber;
                }
                var data = GetIEnumerableListItemPaged(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {
                    if (parameters.UniqueId != Guid.Empty)
                    {
                        var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                        alertEventMgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                        var pdsaEntities = alertEventMgr.BuildCollection();

                        foreach (var idli in data.Items)
                        {   // Get alarm event data
                            foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == idli.UniqueUid))
                                idli.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                        }
                    }
                    else
                    {
                        foreach (var ap in data.Items)
                        {   // Get alarm event data
                            var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.InputDeviceUid = ap.UniqueUid;
                            var pdsaEntities = alertEventMgr.BuildCollection();
                            foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == ap.UniqueUid))
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetInputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<InputDevice> GetByNameOrComments(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                if (getParameters.GetOption(GetOptions_InputDevice.SearchIncludesComments) == true)
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByNameOrComments;
                else
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByName;

                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.InputName = getParameters.GetString;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<InputDeviceListItem> GetListItemsByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters)
        {
            try
            {

                var mgr = new InputDevicePDSAManager();

                if (getParameters.GetOption(GetOptions_InputDevice.SearchIncludesComments) == true)
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByNameOrComments;
                else
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByName;

                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.InputName = getParameters.GetString;

                var data = GetIEnumerableListItemPaged(sessionData, getParameters, mgr);
                if (getParameters.IncludeMemberCollections)
                {
                    if (getParameters.UniqueId != Guid.Empty)
                    {
                        var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                        alertEventMgr.Entity.GalaxyPanelUid = getParameters.UniqueId;
                        var pdsaEntities = alertEventMgr.BuildCollection();

                        foreach (var idli in data.Items)
                        {   // Get alarm event data
                            foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == idli.UniqueUid))
                                idli.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                        }
                    }
                    else
                    {
                        foreach (var ap in data.Items)
                        {   // Get alarm event data
                            var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.InputDeviceUid = ap.UniqueUid;
                            var pdsaEntities = alertEventMgr.BuildCollection();
                            foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == ap.UniqueUid))
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetInputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }

        public IArrayResponse<InputDeviceListItem> GetInputDeviceListItemsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ListBoxByClusterUid;
                mgr.Entity.ClusterUid = parameters.ClusterUid;

                var data = GetIEnumerableListItemPaged(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {
                    if (!parameters.IsExcluded(nameof(InputDeviceListItem.AlertEventAcknowledgeData)))
                    {
                        if (parameters.UniqueId != Guid.Empty)
                        {
                            var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                            var pdsaEntities = alertEventMgr.BuildCollection();

                            foreach (var ap in data.Items)
                            {   // Get alarm event data
                                foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == ap.UniqueUid))
                                    ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                            }
                        }
                        else
                        {
                            foreach (var ap in data.Items)
                            {   // Get alarm event data
                                var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                                alertEventMgr.Entity.InputDeviceUid = ap.UniqueUid;
                                var pdsaEntities = alertEventMgr.BuildCollection();
                                foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == ap.UniqueUid))
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetInputDeviceListForGalaxyPanel", ex);
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
                var mgr = new select_InputDeviceActivityHistoryPDSAManager
                {
                    Entity =
                    {
                        EntityId = parameters.CurrentEntityId,
                        DeviceUid = parameters.InputDeviceUid,
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

#else
        private IEnumerable<InputDeviceListItem> GetIEnumerableListItem(IApplicationUserSessionDataHeader sessionData,
            IGetParametersBase getParameters, InputDevicePDSAManager mgr)
        {
            var inputDevices = GetFilteredInputDevices(sessionData, getParameters, mgr);

            if (inputDevices != null)
            {
                var entities = new List<InputDeviceListItem>();
                foreach (var e in inputDevices)
                {
                    var idli = new InputDeviceListItem()
                    {
                        EntityId = e.EntityId,
                        UniqueUid = e.InputDeviceUid,
                        Name = e.InputName,
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

        public IEnumerable<InputDevice> GetAllInputDevicesForEntity(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }
        public IEnumerable<InputDevice> GetAllInputDevicesForRegion(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByRegionUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForRegion", ex);
                throw;
            }
        }

        public IEnumerable<InputDevice> GetAllInputDevicesForSite(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.BySiteUid;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.Entity.SiteUid = getParameters.UniqueId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForSite", ex);
                throw;
            }
        }

        public IEnumerable<InputDevice> GetAllInputDevicesForCluster(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByClusterUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForCluster", ex);
                throw;
            }
        }

        public IEnumerable<InputDevice> GetAllInputDevicesForGalaxyPanel(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                if (getParameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByGalaxyPanelUid;
                    mgr.Entity.GalaxyPanelUid = getParameters.UniqueId;
                }
                else
                {
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByGalaxyPanelAddress;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForGalaxyPanel", ex);
                throw;
            }
        }

        public IEnumerable<InputDeviceListItem> GetInputDeviceListForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {

                var mgr = new InputDevicePDSAManager();


                mgr.Entity.IsNodeActive = true;
                var getIsNodeActiveOnlyOption = parameters.GetOption(GalaxySMS.Common.Enums.GetInputDeviceOption.IsNodeActiveValue.ToString());
                if (getIsNodeActiveOnlyOption.HasValue)
                {
                    mgr.Entity.IsNodeActive = getIsNodeActiveOnlyOption.Value;
                }

                if (parameters.UniqueId != Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ListBoxByGalaxyPanelUid;
                    mgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                }
                else
                {
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ListBoxByGalaxyPanelAddress;
                    mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                    mgr.Entity.ClusterNumber = (short)parameters.ClusterNumber;
                    mgr.Entity.PanelNumber = (short)parameters.PanelNumber;
                }
                var data = GetIEnumerableListItem(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {
                    if (parameters.UniqueId != Guid.Empty)
                    {
                        var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                        alertEventMgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                        var pdsaEntities = alertEventMgr.BuildCollection();

                        foreach (var idli in data)
                        {   // Get alarm event data
                            foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == idli.UniqueUid))
                                idli.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                        }
                    }
                    else
                    {
                        foreach (var ap in data)
                        {   // Get alarm event data
                            var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.InputDeviceUid = ap.UniqueUid;
                            var pdsaEntities = alertEventMgr.BuildCollection();
                            foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == ap.UniqueUid))
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetInputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }

        public IEnumerable<InputDevice> GetByNameOrComments(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                if (getParameters.GetOption(GetOptions_InputDevice.SearchIncludesComments) == true)
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByNameOrComments;
                else
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByName;

                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.InputName = getParameters.GetString;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForGalaxyPanel", ex);
                throw;
            }
        }

        public IEnumerable<InputDeviceListItem> GetListItemsByNameOrComments(IApplicationUserSessionDataHeader sessionData, IGetParametersBase getParameters)
        {
            try
            {

                var mgr = new InputDevicePDSAManager();

                if (getParameters.GetOption(GetOptions_InputDevice.SearchIncludesComments) == true)
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByNameOrComments;
                else
                    mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByName;

                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = getParameters.CurrentEntityId;
                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.InputName = getParameters.GetString;

                var data = GetIEnumerableListItem(sessionData, getParameters, mgr);
                if (getParameters.IncludeMemberCollections)
                {
                    if (getParameters.UniqueId != Guid.Empty)
                    {
                        var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                        alertEventMgr.Entity.GalaxyPanelUid = getParameters.UniqueId;
                        var pdsaEntities = alertEventMgr.BuildCollection();

                        foreach (var idli in data)
                        {   // Get alarm event data
                            foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == idli.UniqueUid))
                                idli.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                        }
                    }
                    else
                    {
                        foreach (var ap in data)
                        {   // Get alarm event data
                            var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.InputDeviceUid = ap.UniqueUid;
                            var pdsaEntities = alertEventMgr.BuildCollection();
                            foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == ap.UniqueUid))
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetInputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }

        public IEnumerable<InputDeviceListItem> GetInputDeviceListItemsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ListBoxByClusterUid;
                mgr.Entity.ClusterUid = parameters.ClusterUid;

                var data = GetIEnumerableListItem(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {
                    if (!parameters.IsExcluded(nameof(InputDeviceListItem.AlertEventAcknowledgeData)))
                    {
                        if (parameters.UniqueId != Guid.Empty)
                        {
                            var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                            var pdsaEntities = alertEventMgr.BuildCollection();

                            foreach (var ap in data)
                            {   // Get alarm event data
                                foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == ap.UniqueUid))
                                    ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                            }
                        }
                        else
                        {
                            foreach (var ap in data)
                            {   // Get alarm event data
                                var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                                alertEventMgr.Entity.InputDeviceUid = ap.UniqueUid;
                                var pdsaEntities = alertEventMgr.BuildCollection();
                                foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == ap.UniqueUid))
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetInputDeviceListForGalaxyPanel", ex);
                throw;
            }
        }

        
        public IEnumerable<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters)
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
                var mgr = new select_InputDeviceActivityHistoryPDSAManager
                {
                    Entity =
                    {
                        EntityId = parameters.CurrentEntityId,
                        DeviceUid = parameters.InputDeviceUid,
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
                    foreach (var i in result)
                    {
                        var newEntity = new ActivityHistoryEvent();
                        SimpleMapper.PropertyMap(i, newEntity);
                        newEntity.ForeColorHex = $"#{newEntity.ForeColor & 0xFFFFFF:X6}";
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

#endif


        public InputDeviceListItem GetInputDeviceListItem(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ListBoxByPrimaryKey;
                mgr.Entity.InputDeviceUid = parameters.UniqueId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var e = pdsaEntities.FirstOrDefault();
                    if (e != null)
                    {
                        if (!DoesUserHavePermission(sessionData, e.InputDeviceUid, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanViewId, e.EntityId))
                        {
                            throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to view input device {e.InputName}");
                        }

                        var li = new InputDeviceListItem()
                        {
                            EntityId = e.EntityId,
                            UniqueUid = e.InputDeviceUid,
                            Name = e.InputName,
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
                                li.NodeNumber = 0;
                                break;

                            case GalaxyInterfaceBoardType.DualSerialInterfaceBoard600:
                            case GalaxyInterfaceBoardType.DualSerialInterfaceBoard635:
                                break;
                        }

                        if (parameters.IncludeMemberCollections)
                        {
                            if (li.UniqueUid != Guid.Empty)
                            {
                                var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                                alertEventMgr.Entity.InputDeviceUid = li.UniqueUid;
                                var pdsaAlertEntities = alertEventMgr.BuildCollection();
                                foreach (var alert in pdsaAlertEntities.Where(o => o.InputDeviceUid == li.UniqueUid))
                                    li.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(alert));
                            }
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

        public IEnumerable<Guid> GetInputDeviceUidsForInterfaceBoardSection(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDeviceGalaxyHardwareAddressViewPDSAManager();
                mgr.DataObject.SelectFilter = InputDeviceGalaxyHardwareAddressViewPDSAData.SelectFilters.InputDeviceUid;
                mgr.DataObject.WhereFilter = InputDeviceGalaxyHardwareAddressViewPDSAData.WhereFilters.GalaxyInterfaceBoardSectionUid;
                mgr.DataObject.OrderByFilter = InputDeviceGalaxyHardwareAddressViewPDSAData.OrderByFilters.PhysicalAddress;
                mgr.Entity.GalaxyInterfaceBoardSectionUid = getParameters.UniqueId;
                var results = mgr.BuildCollection();
                return results.Select(i => i.InputDeviceUid).ToCollection();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetInputDeviceUidsForInterfaceBoardSection", ex);
                throw;
            }

        }
        public IEnumerable<InputDeviceSelectionItemBasic> GetAllInputDeviceSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputDevice_SelectionListForEntityAndClusterPDSAManager();
                mgr.Entity.EntityId = parameters.CurrentEntityId;
                mgr.Entity.ClusterUid = parameters.ClusterUid;
                //                var result = mgr.BuildCollection();
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<InputDeviceSelectionItemBasic>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new InputDeviceSelectionItemBasic();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDeviceGroupSelectionItemsForEntityAndCluster", ex);
                throw;
            }
        }

        public InputDevice_GetHardwareInformation GetHardwareInformation(IApplicationUserSessionDataHeader sessionData,
            Guid inputDeviceUid)
        {
            try
            {
                var apHardwareInfoMgr = new InputDevice_GetHardwareInformationPDSAManager
                {
                    Entity = { InputDeviceUid = inputDeviceUid }
                };
                var apHardwareInfo = apHardwareInfoMgr.BuildCollection();
                if (apHardwareInfo.Count == 1)
                {
                    var convertedEntity = new InputDevice_GetHardwareInformation();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetHardwareInformation", ex);
                throw;
            }
            return null;
        }

        protected override InputDevice GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override InputDevice GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    if (!DoesUserHavePermission(sessionData, mgr.Entity.InputDeviceUid, GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.InputDeviceCanViewId, mgr.Entity.EntityId))
                    {
                        throw new UnauthorizedAccessException($"UserName '{sessionData.UserName}' does not have permissions to view input device {mgr.Entity.InputName}");
                    }

                    InputDevice result = new InputDevice();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludeHardwareAddress || getParameters.IncludeCommands)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        public InputDevice_PanelLoadData GetInputDevicePanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevice_GetPanelLoadDataByInputDeviceUidPDSAManager();
                mgr.Entity.InputDeviceUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null && result.Count == 1)
                {
                    var returnData = new InputDevice_PanelLoadData();
                    SimpleMapper.PropertyMap(result[0], returnData);
                    //var agManager = new AccessGroupInputDevice_GetPanelLoadDataByInputDeviceUidPDSAManager();
                    //agManager.Entity.InputDeviceUid = getParameters.UniqueId;

                    //var accessGroupData = agManager.BuildCollection();
                    //if (accessGroupData != null && accessGroupData.Count > 0)
                    //{
                    //    foreach (var agData in accessGroupData)
                    //    {
                    //        var newAgData = new AccessGroupInputDevice_PanelLoadData();
                    //        SimpleMapper.PropertyMap(agData, newAgData);
                    //        returnData.AccessGroupData.Add(newAgData);
                    //    }

                    //}
                    return returnData;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetInputDevicePanelLoadData", ex);
                throw;
            }
        }


        public IEnumerable<InputDevice_PanelLoadData> GetInputDevicesPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevice_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSAManager();
                mgr.Entity.GalaxyInterfaceBoardSectionUid = getParameters.UniqueId;
                //                var result = mgr.BuildCollection();
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<InputDevice_PanelLoadData>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new InputDevice_PanelLoadData();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllInputDevicesForGalaxyPanel", ex);
                throw;
            }
        }


        public IEnumerable<InputDevice_PanelLoadData> GetModifiedPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var results = new List<InputDevice_PanelLoadData>();
                var mgr = new InputDevice_GetPanelLoadDataChangesByCpuUidPDSAManager();
                mgr.Entity.CpuUid = parameters.UniqueId;
                mgr.Entity.ServerAddress = parameters.GetString;
                mgr.Entity.IsConnected = true;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                    {
                        var newEntity = new InputDevice_PanelLoadData();
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


        public void UpdateGalaxyInputDeviceLastLoadedDate(Guid cpuUid, Guid inputDeviceUid)
        {
            try
            {
                var mgr = new InputDeviceLoadToCpu_SaveLastLoadedDatePDSAManager
                {
                    Entity =
                    {
                        CpuUid = cpuUid,
                        InputDeviceUid = inputDeviceUid
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
            InputDevice originalEntity, InputDevice newEntity, string auditXml)
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

                        List<String> propertiesToIgnore = new List<string>();
                        propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        propertiesToIgnore.Add("GalaxyInputDevice");
                        propertiesToIgnore.Add("InputDeviceEventProperties");
                        propertiesToIgnore.Add("Notes");
                        propertiesToIgnore.Add("Commands");
                        propertiesToIgnore.Add("EntityIds");
                        propertiesToIgnore.Add("MappedEntitiesPermissionLevels");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InputDeviceUid;
                        mgr.Entity.RecordTag = newEntity.InputDeviceUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InputDeviceUid;
                        mgr.Entity.RecordTag = newEntity.InputDeviceUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.InputDeviceUid;
                        mgr.Entity.RecordTag = originalEntity.InputDeviceUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(InputDevice entity, IApplicationUserSessionDataHeader sessionData,
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

            var p = new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid, IncludeMemberCollections = true, IncludeHardwareAddress = getParameters.IncludeHardwareAddress };
            if (!getParameters.IsExcluded(nameof(entity.GalaxyInputDevice)) || getParameters.IncludeHardwareAddress)
            {
                entity.GalaxyInputDevice = _galaxyInputDeviceRepository.GetByInputDeviceUid(sessionData, p);
            }

            if (!getParameters.IsExcluded(nameof(entity.InputDeviceEventProperties)))
                entity.InputDeviceEventProperties = _inputDeviceEventPropertiesRepository.GetByInputDeviceUid(sessionData, p).ToCollection();

            if (getParameters.IncludeCommands && entity.IsNodeActive)
            {
                var getP = new GetParametersWithPhoto() { UniqueId = entity.GalaxyPanelModelUid, IncludePhoto = false };
                var cmds = _inputCommandRepository.GetAllInputCommandsForGalaxyPanelModel(sessionData, getP).ToCollection();

                entity.Commands = cmds;
            }

            var entityMaps = _entityMapRepository.GetAllInputDeviceEntityMapsForInputDevice(sessionData,
                new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid });
            var entityIds = (from e in entityMaps select e.EntityId).ToList();
            entity.EntityIds.AddRange(entityIds);
            //foreach ( var e in entityMaps)
            //{
            //    if(e.EntityId != entity.EntityId)
            //        entity.EntityIds.Add(e.EntityId);
            //}
            entity.EntityIds.Add(entity.EntityId);

            if (!p.IsExcluded(nameof(InputDevice.RoleIds)))
            {
                var roleFilters = _roleInputDeviceRepository.GetAllForInputDeviceUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid });
                var roleIds = (from e in roleFilters select e.RoleId).ToList();
                entity.RoleIds.AddRange(roleIds);
            }

        }

        protected void FillMemberCollections(InputDeviceSelectionItemBasic entity, IApplicationUserSessionDataHeader sessionData,
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

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllInputDeviceEntityMapsForInputDevice(sessionData,
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
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.InputDeviceEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new InputDeviceEntityMap();
                    entityMap.InputDeviceEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.InputDeviceUid = uid;
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
            var existingRoleInputDevice = _roleInputDeviceRepository.GetAllForInputDeviceUid(sessionData, getParameters);
            var existingRoleIds = new HashSet<Guid>(existingRoleInputDevice.Select(e => e.RoleId));
            var deleteRoleIds = existingRoleIds.Except(entity.RoleIds);

            foreach (var rid in deleteRoleIds)
            {
                var rc = existingRoleInputDevice.FirstOrDefault(o => o.RoleId == rid);
                if (rc != null)
                    _roleInputDeviceRepository.Remove(rc.RoleInputDeviceUid, sessionData);
            }

            foreach (var roleId in entity.RoleIds)
            {
                if (!existingRoleIds.Contains(roleId))
                {
                    var roleInputDevice = new RoleInputDevice();
                    roleInputDevice.RoleInputDeviceUid = GuidUtilities.GenerateComb();
                    roleInputDevice.InputDeviceUid = uid;
                    roleInputDevice.RoleId = roleId;
                    UpdateTableEntityBaseProperties(roleInputDevice, sessionData);

                    _roleInputDeviceRepository.Add(roleInputDevice, sessionData, saveParams);
                }
            }

        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("InputDevice", "InputDeviceUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("InputDevice", "InputDeviceUid", id);
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

        protected override bool IsEntityUnique(InputDevice entity)
        {
            var mgr = new IsInputDeviceUniquePDSAManager();
            mgr.Entity.InputDeviceUid = entity.InputDeviceUid;
            mgr.Entity.InputName = entity.InputName;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("InputDevice", "InputDeviceUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("InputDevice", "InputDeviceUid", id);
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
                var mgr = new gcsEntityCountPDSA_InsertInputDeviceCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        public IArrayResponse<InputDeviceListItem> GetInputDevicesByNameAndSite(IApplicationUserSessionDataHeader sessionData, IGetParametersBase parameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ListBySiteUidAndName;
                mgr.Entity.SiteUid = parameters.GetGuid;
                mgr.Entity.InputName = parameters.GetString;

                var data = GetIEnumerableListItemPaged(sessionData, parameters, mgr);
                if (parameters.IncludeMemberCollections)
                {
                    if (!parameters.IsExcluded(nameof(InputDeviceListItem.AlertEventAcknowledgeData)))
                    {
                        if (parameters.UniqueId != Guid.Empty)
                        {
                            var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                            alertEventMgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                            var pdsaEntities = alertEventMgr.BuildCollection();

                            foreach (var ap in data.Items)
                            {   // Get alarm event data
                                foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == ap.UniqueUid))
                                    ap.AlertEventAcknowledgeData.Add(alertEventMgr.ConvertPDSAEntity(e));
                            }
                        }
                        else
                        {
                            foreach (var ap in data.Items)
                            {   // Get alarm event data
                                var alertEventMgr = new InputDevice_GetAlertEventAcknowledgeDataPDSAManager();
                                alertEventMgr.Entity.InputDeviceUid = ap.UniqueUid;
                                var pdsaEntities = alertEventMgr.BuildCollection();
                                foreach (var e in pdsaEntities.Where(o => o.InputDeviceUid == ap.UniqueUid))
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



        #region Implementation of IInputDeviceRepository

        public InputDevice EnsureInputDeviceExists(IApplicationUserSessionDataHeader sessionData, EnsureInputDeviceExistsParameters parameters, ISaveParameters saveParams)
        {
            // Start by seeing if one exists for the GalaxyInterfaceBoardSectionNode
            var existing =
                _inputDeviceGalaxyHardwareAddressRepository.GetByInputDeviceGalaxyHardwareAddressUid(sessionData,
                    new GetParametersWithPhoto() { UniqueId = parameters.TheNode.GalaxyInterfaceBoardSectionNodeUid });
            if (existing != null)
                return GetEntityByGuidId(existing.InputDeviceUid, sessionData,
                    new GetParametersWithPhoto() { UniqueId = existing.InputDeviceUid });

            InputDevice templateItem = null;
            InputDevice newItem = null;

            var newName = string.Format(GalaxySMS.Resources.Resources.InputDevice_DefaultGalaxyName,
                parameters.TheNode.ClusterGroupId, parameters.TheNode.ClusterNumber,
                parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber, parameters.TheNode.SectionNumber,
                parameters.TheNode.ModuleNumber, parameters.TheNode.NodeNumber);
            if (parameters.TheNode.NodeNumber == GalaxyInputDeviceNumbers.InputModuleLowPowerInputNumber)    // Low Power
            {
                newName = string.Format(GalaxySMS.Resources.Resources.InputDevice_DefaultGalaxyName,
                    parameters.TheNode.ClusterGroupId, parameters.TheNode.ClusterNumber,
                    parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber, parameters.TheNode.SectionNumber,
                    parameters.TheNode.ModuleNumber, GalaxySMS.Resources.Resources.InputDevice_LowPower);

            }
            else if (parameters.TheNode.NodeNumber == GalaxyInputDeviceNumbers.InputModuleTamperInputNumber)   // Tamper
            {
                newName = string.Format(GalaxySMS.Resources.Resources.InputDevice_DefaultGalaxyName,
                    parameters.TheNode.ClusterGroupId, parameters.TheNode.ClusterNumber,
                    parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber, parameters.TheNode.SectionNumber,
                    parameters.TheNode.ModuleNumber, GalaxySMS.Resources.Resources.InputDevice_Tamper);
            }

            var duplicateNamedInputDevices = GetInputDevicesByNameAndSite(sessionData, new GetParametersWithPhoto()
            {
                IncludeMemberCollections = false,
                GetString = newName,
                GetGuid = parameters.SiteUid,
                PageNumber = 1,
                PageSize = 0
            });

            if (duplicateNamedInputDevices.Items.Any())
            {
                for (int x = 1; x < 1000; x++)
                {
                    newName = string.Format(GalaxySMS.Resources.Resources.InputDevice_DefaultGalaxyName,
                        parameters.TheNode.ClusterGroupId, parameters.TheNode.ClusterNumber,
                        parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber, parameters.TheNode.SectionNumber,
                        parameters.TheNode.ModuleNumber, parameters.TheNode.NodeNumber);
                    if (parameters.TheNode.NodeNumber == GalaxyInputDeviceNumbers.InputModuleLowPowerInputNumber)    // Low Power
                    {
                        newName = string.Format(GalaxySMS.Resources.Resources.InputDevice_DefaultGalaxyName,
                            parameters.TheNode.ClusterGroupId, parameters.TheNode.ClusterNumber,
                            parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber, parameters.TheNode.SectionNumber,
                            parameters.TheNode.ModuleNumber, GalaxySMS.Resources.Resources.InputDevice_LowPower);

                    }
                    else if (parameters.TheNode.NodeNumber == GalaxyInputDeviceNumbers.InputModuleTamperInputNumber)   // Tamper
                    {
                        newName = string.Format(GalaxySMS.Resources.Resources.InputDevice_DefaultGalaxyName,
                            parameters.TheNode.ClusterGroupId, parameters.TheNode.ClusterNumber,
                            parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber, parameters.TheNode.SectionNumber,
                            parameters.TheNode.ModuleNumber, GalaxySMS.Resources.Resources.InputDevice_Tamper);
                    }
                    newName += $" ({x})";
                    if (duplicateNamedInputDevices.Items.FirstOrDefault(o => o.Name.ToLower() == newName.ToLower()) ==
                        null)
                        break;
                }
            }

            // If none exists, create one
            if (parameters.TemplateInputDeviceUid != Guid.Empty)
                templateItem = GetEntityByGuidId(parameters.TemplateInputDeviceUid, sessionData,
                    new GetParametersWithPhoto() { UniqueId = parameters.TemplateInputDeviceUid });
            if (templateItem == null)
            {
                newItem = new InputDevice { InsertName = sessionData.UserName, InsertDate = DateTimeOffset.Now };
                newItem.InputDeviceEventProperties.Add(new InputDeviceEventProperty()
                {
                    AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
                    Tag = GalaxySMS.Common.Enums.InputDeviceAlertEventType.StateChange.ToString(),
                    InputDeviceAlertEventTypeUid = GalaxySMS.Common.Constants.InputDeviceAlertEventTypeIds.StateChange
                });

                if (parameters.SupervisionType == null)
                    newItem.GalaxyInputDevice.InputDeviceSupervisionTypeUid = GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.None;
                else
                {
                    newItem.GalaxyInputDevice.InputDeviceSupervisionTypeUid = parameters.SupervisionType.InputDeviceSupervisionTypeUid;
                    newItem.GalaxyInputDevice.IsNormalOpen = parameters.SupervisionType.IsNormalOpen;
                    newItem.GalaxyInputDevice.NormalChangeThreshold = parameters.SupervisionType.NormalChangeThreshold;
                    newItem.GalaxyInputDevice.TroubleOpenThreshold = parameters.SupervisionType.TroubleOpenThreshold;
                    newItem.GalaxyInputDevice.TroubleShortThreshold = parameters.SupervisionType.TroubleShortThreshold;
                    newItem.GalaxyInputDevice.AlternateVoltagesEnabled = parameters.SupervisionType.AlternateVoltagesEnabled;
                    newItem.GalaxyInputDevice.AlternateNormalChangeThreshold = parameters.SupervisionType.AlternateNormalChangeThreshold;
                    newItem.GalaxyInputDevice.AlternateTroubleOpenThreshold = parameters.SupervisionType.AlternateTroubleOpenThreshold;
                    newItem.GalaxyInputDevice.AlternateTroubleShortThreshold = parameters.SupervisionType.AlternateTroubleShortThreshold;
                }
                newItem.GalaxyInputDevice.GalaxyInputModeUid = GalaxySMS.Common.Constants.GalaxyInputModeIds.Standard;
                newItem.GalaxyInputDevice.GalaxyInputDelayTypeUid = GalaxySMS.Common.Constants.GalaxyInputDelayTypeIds.Entry;
                // Arming schedule
                newItem.GalaxyInputDevice.TimeSchedule.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;
                newItem.GalaxyInputDevice.TimeSchedule.Tag = GalaxyInputDeviceTimeScheduleTag.ArmingTimeSchedule.ToString();


                var noIog = parameters.InputOutputGroups.FirstOrDefault(o => o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);
                if (noIog == null)
                    noIog = new InputOutputGroup();
                newItem.GalaxyInputDevice.AlertEvents.Add(new InputDeviceAlertEvent()
                {
                    InputOutputGroupUid = noIog.InputOutputGroupUid,
                    InputDeviceAlertEventTypeUid = GalaxySMS.Common.Constants.InputDeviceAlertEventTypeIds.StateChange,
                    Tag = GalaxySMS.Common.Enums.InputDeviceAlertEventType.StateChange.ToString(),
                });
                for (short orderNumber = 1; orderNumber <= 4; orderNumber++)
                {
                    newItem.GalaxyInputDevice.ArmingInputOutputGroups.Add(new GalaxyInputArmingInputOutputGroup()
                    {
                        OrderNumber = orderNumber,
                        InputOutputGroupUid = noIog.InputOutputGroupUid,
                    });
                }
            }
            else
            {
                newItem = templateItem.Clone(templateItem);
            }
            newItem.InputDeviceUid = GuidUtilities.GenerateComb();
            newItem.EntityId = sessionData.CurrentEntityId;
            //            newItem.SiteUid = sessionData.CurrentSiteId;
            newItem.SiteUid = parameters.SiteUid;

            newItem.InputName = newName;

            newItem.InsertName = sessionData.UserName;
            newItem.InsertDate = DateTimeOffset.Now;
            newItem.UpdateName = newItem.InsertName;
            newItem.UpdateDate = newItem.InsertDate;
            newItem.RoleIds = parameters.RoleIds;

            var returnItem = Add(newItem, sessionData, saveParams);
            if (returnItem != null)
            {
                var hwAddress = new InputDeviceGalaxyHardwareAddress
                {
                    InputDeviceGalaxyHardwareAddressUid = GuidUtilities.GenerateComb(),
                    InputDeviceUid = returnItem.InputDeviceUid,

                    GalaxyInterfaceBoardSectionNodeUid = parameters.TheNode.GalaxyInterfaceBoardSectionNodeUid,
                    InsertName = sessionData.UserName,
                    InsertDate = DateTimeOffset.Now,
                    UpdateName = newItem.InsertName,
                    UpdateDate = newItem.InsertDate
                };

                _inputDeviceGalaxyHardwareAddressRepository.Add(hwAddress, sessionData,  saveParams);
            }
            return returnItem;
        }

        #endregion

        public bool DoesUserHavePermission(IApplicationUserSessionDataHeader sessionData, Guid inputDeviceUid, Guid permissionId, Guid entityId)
        {
            // If no permission is specified, return true to indicate that permission is granted
            if (permissionId == Guid.Empty)
                return true;

            if (!sessionData.IsPermissionCheckPossible)
                return true;

            var mgr = new InputDevice_GetUserPermissionPDSAManager();
            mgr.Entity.UserId = sessionData.UserId;
            mgr.Entity.InputDeviceUid = inputDeviceUid;
            mgr.Entity.PermissionId = permissionId;
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            if (results?.Count > 0)
                return true;
            return false;
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, InputDevicePDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<InputDeviceSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }
        protected override IArrayResponse<InputDevice> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.ByEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<InputDevice> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDevicePDSAManager();
                mgr.DataObject.SelectFilter = InputDevicePDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceRepository::GetAllEntities", ex);
                throw;
            }
        }


        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleId(Guid roleId)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new InputDevice_GetAllUidsFromRoleIdPDSAManager();
            mgr.Entity.RoleId = roleId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.InputDeviceUid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsForEntityId(Guid entityId)
        {
            var dataList = new List<Guid>();
            if (entityId == Guid.Empty)
                return dataList;
            var mgr = new InputDevice_GetAllUidsForEntityIdPDSAManager();
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.Uid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsForClusterUid(Guid clusterUid)
        {
            var dataList = new List<Guid>();
            if (clusterUid == Guid.Empty)
                return dataList;
            var mgr = new InputDevice_GetAllUidsForClusterUidPDSAManager();
            mgr.Entity.ClusterUid = clusterUid;
            var results = mgr.BuildCollection();
            return results.Select(o => o.Uid);
        }


        public IEnumerable<Guid> GetAllPrimaryKeyUidsFromRoleIdAndClusterUid(Guid roleId, Guid clusterUid)
        {
            var dataList = new List<Guid>();
            if (roleId == Guid.Empty)
                return dataList;
            var mgr = new InputDevice_GetAllUidsFromRoleIdAndClusterUidPDSAManager();
            mgr.Entity.RoleId = roleId;
            mgr.Entity.ClusterUid = clusterUid;
            var results = mgr.BuildCollection();
            return results.Select(o => o.InputDeviceUid);
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForInputDevicePDSAManager
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

    }
}