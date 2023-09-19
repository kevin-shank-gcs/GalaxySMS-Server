using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
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
    [Export(typeof(IGalaxyInputDeviceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyInputDeviceRepository : DataRepositoryBase<GalaxyInputDevice>, IGalaxyInputDeviceRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import] private IInputDeviceGalaxyHardwareAddressRepository _inputDeviceGalaxyHardwareAddressRepository;
        [Import] private IGalaxyInputDeviceTimeScheduleRepository _galaxyInputDeviceTimeScheduleRepository;
        [Import] private IInputDeviceAlertEventRepository _inputDeviceAlertEventRepository;
        [Import] private IGalaxyInputArmingInputOutputGroupRepository _galaxyInputArmingInputOutputGroupRepository;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        private InputOutputGroup _noIog;
        private IEnumerable<InputOutputGroup> _allIoGroups;

        protected override GalaxyInputDevice AddEntity(GalaxyInputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new GalaxyInputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.InputDeviceUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInputDeviceRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyInputDevice UpdateEntity(GalaxyInputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.InputDeviceUid, sessionData, null);
                var mgr = new GalaxyInputDevicePDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.InputDeviceUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if GalaxyInputDelayTypeUid is = Guid.Empty or null, then use the value from the original record
                    entity.GalaxyInputDelayTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.GalaxyInputDelayTypeUid, entity.GalaxyInputDelayTypeUid);

                    // if GalaxyInputModeUid is = Guid.Empty or null, then use the value from the original record
                    entity.GalaxyInputModeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.GalaxyInputModeUid, entity.GalaxyInputModeUid);

                    // if InputDeviceSupervisionTypeUid is = Guid.Empty or null, then use the value from the original record
                    entity.InputDeviceSupervisionTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InputDeviceSupervisionTypeUid, entity.InputDeviceSupervisionTypeUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.InputDeviceUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInputDeviceRepository::UpdateEntity", ex);
                throw;
            }
        }


        private void EnsureChildRecordsExist(GalaxyInputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            var ioGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();
            _allIoGroups = ioGroupRepository.GetAllGalaxyInputOutputGroupsForInputDevice(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid, IncludeMemberCollections = false, IncludePhoto = false }).Items;

            _noIog = _allIoGroups.FirstOrDefault(o => o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);
            if (_noIog != null)
            {
                var opts = saveParams.Options.ToList();
                opts.Add(new KeyValuePair<string, string>(SaveInputDeviceAlertEventOption.NoIoGroupUid.ToString(), _noIog.InputOutputGroupUid.ToString()));
                saveParams.Options = opts;
            }
            if (!saveParams.Ignore(nameof(entity.AlertEvents)) && entity.AlertEvents != null && entity.AlertEvents.Any())
                SaveAlertEvents(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.ArmingInputOutputGroups)) && entity.ArmingInputOutputGroups != null && entity.ArmingInputOutputGroups.Any())
                SaveArmingInputOutputGroups(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.TimeSchedule)) && entity.TimeSchedule != null)
                SaveTimeSchedule(entity, sessionData, saveParams);
        }


        private void SaveAlertEvents(GalaxyInputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.AlertEvents == null || !entity.AlertEvents.Any())
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveInputDeviceAlertEventOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveInputDeviceAlertEventOption.DeleteMissingItems.ToString();

            // Alert Events
            var items = _inputDeviceAlertEventRepository.GetByInputDeviceUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid });

            // If any do not have a InputDeviceAlertEventUid (PrimaryKey value), see if we can determine the value by InputDeviceAlertEventTypeUid
            foreach (var alertEvent in entity.AlertEvents.Where(o => o.InputDeviceAlertEventUid == Guid.Empty))
            {
                var i = items.FirstOrDefault(o => o.InputDeviceAlertEventTypeUid == alertEvent.InputDeviceAlertEventTypeUid);
                if (i != null)
                {
                    alertEvent.InputDeviceAlertEventUid = i.InputDeviceAlertEventUid;
                }
            }

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the Access Portal
                foreach (var i in items)
                {
                    // If the AccessPortalAlertEventUid does not exist in the entity, then delete the area from the database
                    if (entity.AlertEvents.FirstOrDefault(o => o.InputDeviceAlertEventUid == i.InputDeviceAlertEventUid) == null)
                    {
                        _inputDeviceAlertEventRepository.Remove(i.InputDeviceAlertEventUid, sessionData);
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

                if (i.InputDeviceUid != entity.InputDeviceUid)
                    i.InputDeviceUid = entity.InputDeviceUid;

                if (i.InputOutputGroupUid == Guid.Empty)
                {
                    var iog = _allIoGroups.FirstOrDefault(o => o.InputOutputGroupUid == i.InputOutputGroupUid);
                    if (iog == null && i.InputOutputGroupNumber >= InputOutputGroupLimits.None && i.InputOutputGroupNumber <= InputOutputGroupLimits.HighestNumber)
                        iog = _allIoGroups.FirstOrDefault(o => o.IOGroupNumber == i.InputOutputGroupNumber);
                    if (iog == null && !string.IsNullOrEmpty(i.InputOutputGroupName))
                        iog = _allIoGroups.FirstOrDefault(o => o.Display == i.InputOutputGroupName);

                    if (iog == null)
                    {
                        //                    iog = noIog;
                        throw new Exception($"{i.GetType().Name} InputOutputGroup not found. InputOutputGroupUid:{i.InputOutputGroupUid}, Number:'{i.InputOutputGroupNumber}', Name:'{i.InputOutputGroupName}' ");
                    }
                    i.InputOutputGroupUid = iog.InputOutputGroupUid;
                }

                // May want to select an IOGroupAssignment here if the IOGroup is not NONE and there is not assignment specified

                var existingItem = items.FirstOrDefault(o => o.InputDeviceAlertEventUid == i.InputDeviceAlertEventUid);

                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _inputDeviceAlertEventRepository.Update(i, sessionData, saveParams);
                }
                if (i.InputDeviceAlertEventUid == Guid.Empty)
                {
                    i.InputDeviceAlertEventUid = GuidUtilities.GenerateComb();
                    i.InputDeviceUid = entity.InputDeviceUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _inputDeviceAlertEventRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        private void SaveArmingInputOutputGroups(GalaxyInputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            var tempIogs = entity.ArmingInputOutputGroups.ToList();
            for (short x = 1; x <= 4; x++)
            {
                var tempIog = tempIogs.FirstOrDefault(o => o.OrderNumber == x);
                if (tempIog == null)
                {
                    tempIog = new GalaxyInputArmingInputOutputGroup()
                    {
                        OrderNumber = x,
                        IsDirty = true
                    };
                    tempIogs.Add(tempIog);
                }

                if (tempIog.InputOutputGroupUid == Guid.Empty)
                {
                    var iog = _allIoGroups.FirstOrDefault(o => o.InputOutputGroupUid == tempIog.InputOutputGroupUid);
                    if (iog == null && tempIog.InputOutputGroupNumber >= InputOutputGroupLimits.None && tempIog.InputOutputGroupNumber <= InputOutputGroupLimits.HighestNumber)
                        iog = _allIoGroups.FirstOrDefault(o => o.IOGroupNumber == tempIog.InputOutputGroupNumber);
                    if (iog == null && !string.IsNullOrEmpty(tempIog.InputOutputGroupName))
                        iog = _allIoGroups.FirstOrDefault(o => o.Display == tempIog.InputOutputGroupName);

                    if (iog == null)
                    {
                        //                    iog = noIog;
                        throw new Exception($"{tempIog.GetType().Name} InputOutputGroup not found. InputOutputGroupUid:{tempIog.InputOutputGroupUid}, Number:'{tempIog.InputOutputGroupNumber}', Name:'{tempIog.InputOutputGroupName}' ");
                    }

                    tempIog.InputOutputGroupUid = iog.InputOutputGroupUid;
                }
            }
            entity.ArmingInputOutputGroups = tempIogs.ToCollection();

            var existingInputOutputGroups = _galaxyInputArmingInputOutputGroupRepository.GetByInputDeviceUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid }).ToList();
            var deleteTheseArmingInputOutputGroups = existingInputOutputGroups.Where(c => entity.ArmingInputOutputGroups.All(c2 => c2.GalaxyInputArmingInputOutputGroupUid != c.GalaxyInputArmingInputOutputGroupUid)).ToList();
            //var dirtyPersonInputOutputGroups = entity.PersonInputOutputGroups.Where(o => o.IsAnythingDirty).ToCollection();

            var propsToInclude = new List<string>();
            var propsToIgnore = new List<string>
            {
                nameof(GalaxyInputArmingInputOutputGroup.IsDirty),
                nameof(GalaxyInputArmingInputOutputGroup.IsAnythingDirty),
                nameof(GalaxyInputArmingInputOutputGroup.IsPanelDataDirty)
            };

            var dirtyArmingInputOutputGroups = new List<GalaxyInputArmingInputOutputGroup>();
            foreach (var pag in entity.ArmingInputOutputGroups)
            {
                var existingItem = existingInputOutputGroups.FirstOrDefault(o => o.OrderNumber == pag.OrderNumber);

                if (pag.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(pag, existingItem, propsToInclude, propsToIgnore))
                {
                    dirtyArmingInputOutputGroups.Add(pag);
                }
            }

            if (dirtyArmingInputOutputGroups.Any())
            {

                // spin through all the dirty person cluster permissions
                foreach (var piog in dirtyArmingInputOutputGroups)
                {
                    piog.InputDeviceUid = entity.InputDeviceUid;

                    if (piog.InputOutputGroupUid == Guid.Empty && _noIog != null)
                        piog.InputOutputGroupUid = _noIog.InputOutputGroupUid;

                    UpdateTableEntityBaseProperties(piog, sessionData);
                    if (piog.GalaxyInputArmingInputOutputGroupUid == Guid.Empty)
                    {
                        piog.GalaxyInputArmingInputOutputGroupUid = GuidUtilities.GenerateComb();
                        _galaxyInputArmingInputOutputGroupRepository.Add(piog, sessionData, saveParams);
                    }
                    else
                        _galaxyInputArmingInputOutputGroupRepository.Update(piog, sessionData, saveParams);
                }
            }

            foreach (var piog in deleteTheseArmingInputOutputGroups)
            {
                // must explicitly delete the credential first
                _galaxyInputArmingInputOutputGroupRepository.Remove(piog.GalaxyInputArmingInputOutputGroupUid, sessionData);
            }
        }

        private void SaveTimeSchedule(GalaxyInputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            // AccessPortalProperties
            var props = _galaxyInputDeviceTimeScheduleRepository.GetByInputDeviceUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid });
            var propsToIgnore = new List<string>();
            propsToIgnore.Add(nameof(entity.TimeSchedule.GalaxyInputDeviceScheduleUid));
            propsToIgnore.Add(nameof(entity.TimeSchedule.InputDeviceUid));
            if (props != null && (entity.TimeSchedule.IsAnythingDirty == true ||
                                  //entity.Properties.AreAnyValuesNotSpecified() ||
                                  ObjectComparer.AreAnyPublicPropertiesDifferent(props, entity.TimeSchedule, null, propsToIgnore)))
            {
                entity.TimeSchedule.GalaxyInputDeviceScheduleUid = props.GalaxyInputDeviceScheduleUid;
                entity.TimeSchedule.InputDeviceUid = props.InputDeviceUid;

                UpdateTableEntityBaseProperties(entity.TimeSchedule, sessionData);
                _galaxyInputDeviceTimeScheduleRepository.Update(entity.TimeSchedule, sessionData, saveParams);
            }
            if (entity.TimeSchedule.InputDeviceUid == Guid.Empty)
            {
                entity.TimeSchedule.GalaxyInputDeviceScheduleUid = GuidUtilities.GenerateComb();
                entity.TimeSchedule.InputDeviceUid = entity.InputDeviceUid;
                UpdateTableEntityBaseProperties(entity.TimeSchedule, sessionData);
                _galaxyInputDeviceTimeScheduleRepository.Add(entity.TimeSchedule, sessionData, saveParams);
            }
        }

        protected override int DeleteEntity(GalaxyInputDevice entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyInputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.InputDeviceUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInputDeviceRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyInputDevicePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInputDeviceRepository::Remove", ex);
                throw;
            }
        }

        // GetAllGalaxyInputDevices
        protected override IEnumerable<GalaxyInputDevice> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInputDevicePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInputDevicePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInputDeviceRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyInputDevice> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyInputDevicePDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (GalaxyInputDevice entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludeHardwareAddress)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<GalaxyInputDevice> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInputDevicePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInputDevicePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInputDeviceRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInputDevice> GetAllGalaxyInputDevicesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInputDevicePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInputDevicePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInputDeviceRepository::GetEntities", ex);
                throw;
            }
        }

        protected override GalaxyInputDevice GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyInputDevice GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInputDevicePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyInputDevice result = new GalaxyInputDevice();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInputDeviceRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        public GalaxyInputDevice GetByInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                try
                {
                    var mgr = new GalaxyInputDevicePDSAManager
                    {
                        DataObject = { SelectFilter = GalaxyInputDevicePDSAData.SelectFilters.ByInputDeviceUid },
                        Entity = { InputDeviceUid = parameters.UniqueId }
                    };
                    return GetIEnumerable(sessionData, parameters, mgr).FirstOrDefault();
                }
                catch (PDSAValidationException ex)
                {
                    DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                    throw dve;
                }
                catch (Exception ex)
                {
                    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalPropertiesRepository::GetByAccessPortalUid", ex);
                    throw;
                }

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInputDeviceRepository::GetEntityByGuidId", ex);
                throw;
            }

        }
        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyInputDevice originalEntity, GalaxyInputDevice newEntity, string auditXml)
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
                        propertiesToIgnore.Add("ArmingInputOutputGroups");
                        propertiesToIgnore.Add("GalaxyHardwareAddress");
                        propertiesToIgnore.Add("TimeSchedule");
                        propertiesToIgnore.Add("AlertEvents");

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
                            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

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
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInputDeviceRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyInputDevice entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                return;

            var p = new GetParametersWithPhoto() { UniqueId = entity.InputDeviceUid };
            if (getParameters.IncludeHardwareAddress)
            {
                entity.GalaxyHardwareAddress = _inputDeviceGalaxyHardwareAddressRepository.GetByInputDeviceUid(sessionData, p);
                if (entity.GalaxyHardwareAddress != null)
                {
                    var idHardwareInfoMgr = new InputDevice_GetHardwareInformationPDSAManager
                    {
                        Entity = { InputDeviceUid = entity.InputDeviceUid }
                    };
                    var idHardwareInfo = idHardwareInfoMgr.BuildCollection();
                    if (idHardwareInfo.Count == 1)
                    {
                        entity.GalaxyHardwareAddress.IsNodeActive = idHardwareInfo[0].IsNodeActive;
                        //entity.HardwareInformation = new InputDevice_GetHardwareInformation();
                        //SimpleMapper.PropertyMap(idHardwareInfo[0], entity.HardwareInformation);
                    }

                }

            }

            if (getParameters.IncludeMemberCollections)
            {
                entity.TimeSchedule = _galaxyInputDeviceTimeScheduleRepository.GetByInputDeviceUid(sessionData, p);
                entity.AlertEvents = _inputDeviceAlertEventRepository.GetByInputDeviceUid(sessionData, p).ToCollection();
                entity.ArmingInputOutputGroups = _galaxyInputArmingInputOutputGroupRepository.GetByInputDeviceUid(sessionData, p).ToCollection();
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyInputDevice", "InputDeviceUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyInputDevice", "InputDeviceUid", id);
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

        protected override bool IsEntityUnique(GalaxyInputDevice entity)
        {
            //var mgr = new IsGalaxyInputDeviceUniquePDSAManager();
            //mgr.Entity.InputDeviceUid = entity.InputDeviceUid;
            //mgr.Entity.GalaxyInputDeviceName = entity.GalaxyInputDeviceName;
            //mgr.BuildCollection();

            //if (Convert.ToInt32(mgr.Entity.Result) == 0)
            return true;
            //return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyInputDevice", "InputDeviceUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyInputDevice", "InputDeviceUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
