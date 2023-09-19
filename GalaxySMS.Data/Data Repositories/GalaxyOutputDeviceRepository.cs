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
    [Export(typeof(IGalaxyOutputDeviceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyOutputDeviceRepository : DataRepositoryBase<GalaxyOutputDevice>, IGalaxyOutputDeviceRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import] private IOutputDeviceGalaxyHardwareAddressRepository _outputDeviceGalaxyHardwareAddressRepository;
        [Import] private IGalaxyOutputDeviceInputSourceRepository _galaxyOutputDeviceInputSourceRepository;
        //[Import] private IOutputDeviceAlertEventRepository _inputDeviceAlertEventRepository;
        //[Import] private IGalaxyOutputArmingInputOutputGroupRepository _galaxyOutputArmingInputOutputGroupRepository;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        private InputOutputGroup _noIog;
        private IEnumerable<InputOutputGroup> _allIoGroups;

        protected override GalaxyOutputDevice AddEntity(GalaxyOutputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new GalaxyOutputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.OutputDeviceUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyOutputDevice UpdateEntity(GalaxyOutputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.OutputDeviceUid, sessionData, null);
                var mgr = new GalaxyOutputDevicePDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.OutputDeviceUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if TimeScheduleUid is = Guid.Empty or null, then use the value from the original record
                    entity.TimeScheduleUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.TimeScheduleUid, entity.TimeScheduleUid);

                    // if GalaxyOutputModeUid is = Guid.Empty or null, then use the value from the original record
                    entity.GalaxyOutputModeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.GalaxyOutputModeUid, entity.GalaxyOutputModeUid);

                    // if GalaxyOutputInputSourceRelationshipUid is = Guid.Empty or null, then use the value from the original record
                    entity.GalaxyOutputInputSourceRelationshipUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.GalaxyOutputInputSourceRelationshipUid, entity.GalaxyOutputInputSourceRelationshipUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.OutputDeviceUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceRepository::UpdateEntity", ex);
                throw;
            }
        }


        private void EnsureChildRecordsExist(GalaxyOutputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            var ioGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();
            _allIoGroups = ioGroupRepository.GetAllGalaxyInputOutputGroupsForOutputDevice(sessionData, new GetParametersWithPhoto() { UniqueId = entity.OutputDeviceUid, IncludeMemberCollections = false, IncludePhoto = false }).Items;

            _noIog = _allIoGroups.FirstOrDefault(o => o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);
            if (_noIog != null)
            {
                var opts = saveParams.Options.ToList();
                opts.Add(new KeyValuePair<string, string>(SaveInputDeviceAlertEventOption.NoIoGroupUid.ToString(), _noIog.InputOutputGroupUid.ToString()));
                saveParams.Options = opts;
            }

            if (!saveParams.Ignore(nameof(entity.GalaxyOutputDeviceInputSources)) && entity.GalaxyOutputDeviceInputSources != null && entity.GalaxyOutputDeviceInputSources.Any())
                SaveGalaxyOutputDeviceInputSources(entity, sessionData, saveParams);
        }


        private void SaveGalaxyOutputDeviceInputSources(GalaxyOutputDevice entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.GalaxyOutputDeviceInputSources == null || !entity.GalaxyOutputDeviceInputSources.Any())
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveOutputDeviceInputSourcesOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveOutputDeviceInputSourcesOption.DeleteMissingItems.ToString();

            // Existing Items
            var items = _galaxyOutputDeviceInputSourceRepository.GetByOutputDeviceUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.OutputDeviceUid });

            foreach (var sources in entity.GalaxyOutputDeviceInputSources.Where(o => o.GalaxyOutputDeviceInputSourceUid == Guid.Empty))
            {
                var i = items.FirstOrDefault(o => o.SourceNumber == sources.SourceNumber);
                if (i != null)
                {
                    sources.GalaxyOutputDeviceInputSourceUid = i.GalaxyOutputDeviceInputSourceUid;
                }
            }

            if (bDeleteMissingItems)
            {
                // Now delete any that are no longer defined in the output
                foreach (var i in items)
                {
                    // If the GalaxyOutputDeviceInputSourceUid does not exist in the entity, then delete the area from the database
                    if (entity.GalaxyOutputDeviceInputSources.FirstOrDefault(o => o.GalaxyOutputDeviceInputSourceUid == i.GalaxyOutputDeviceInputSourceUid) == null)
                    {
                        _galaxyOutputDeviceInputSourceRepository.Remove(i.GalaxyOutputDeviceInputSourceUid, sessionData);
                    }
                }
            }

            var propsToExclude = new List<string>();

            // Now save those that are defined in the output being saved
            foreach (var i in entity.GalaxyOutputDeviceInputSources)
            {
                if (!propsToExclude.Any())
                {
                    //propsToExclude.Add(nameof(i.GalaxyOutputDeviceInputSourceAssignments));
                    //propsToExclude.Add(nameof(i.GalaxyOutputDeviceInputSourceInputOutputGroups));
                }

                if (i.OutputDeviceUid != entity.OutputDeviceUid)
                    i.OutputDeviceUid = entity.OutputDeviceUid;

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

                var existingItem = items.FirstOrDefault(o => o.GalaxyOutputDeviceInputSourceUid == i.GalaxyOutputDeviceInputSourceUid);

                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _galaxyOutputDeviceInputSourceRepository.Update(i, sessionData, saveParams);
                }
                if (i.GalaxyOutputDeviceInputSourceUid == Guid.Empty)
                {
                    i.GalaxyOutputDeviceInputSourceUid = GuidUtilities.GenerateComb();
                    i.OutputDeviceUid = entity.OutputDeviceUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _galaxyOutputDeviceInputSourceRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(GalaxyOutputDevice entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyOutputDevicePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.OutputDeviceUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyOutputDevicePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceRepository::Remove", ex);
                throw;
            }
        }

        // GetAllGalaxyOutputDevices
        protected override IEnumerable<GalaxyOutputDevice> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyOutputDevicePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyOutputDevice> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyOutputDevicePDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (GalaxyOutputDevice entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludeHardwareAddress)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<GalaxyOutputDevice> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyOutputDevicePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyOutputDevice> GetAllGalaxyOutputDevicesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDevicePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyOutputDevicePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceRepository::GetEntities", ex);
                throw;
            }
        }

        protected override GalaxyOutputDevice GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyOutputDevice GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDevicePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyOutputDevice result = new GalaxyOutputDevice();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        public GalaxyOutputDevice GetByOutputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                try
                {
                    var mgr = new GalaxyOutputDevicePDSAManager
                    {
                        DataObject = { SelectFilter = GalaxyOutputDevicePDSAData.SelectFilters.ByOutputDeviceUid },
                        Entity = { OutputDeviceUid = parameters.UniqueId }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceRepository::GetEntityByGuidId", ex);
                throw;
            }

        }
        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyOutputDevice originalEntity, GalaxyOutputDevice newEntity, string auditXml)
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
                        propertiesToIgnore.Add("GalaxyOutputDeviceInputSources");
                        propertiesToIgnore.Add("GalaxyHardwareAddress");

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
                        mgr.Entity.PrimaryKeyColumn = "OutputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.OutputDeviceUid;
                        mgr.Entity.RecordTag = newEntity.OutputDeviceUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "OutputDeviceUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.OutputDeviceUid;
                        mgr.Entity.RecordTag = originalEntity.OutputDeviceUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyOutputDevice entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                return;

            var p = new GetParametersWithPhoto() { UniqueId = entity.OutputDeviceUid, IncludeMemberCollections = getParameters.IncludeMemberCollections };
            if (getParameters.IncludeHardwareAddress)
            {
                entity.GalaxyHardwareAddress = _outputDeviceGalaxyHardwareAddressRepository.GetByOutputDeviceUid(sessionData, p);
                if (entity.GalaxyHardwareAddress != null)
                {
                    var idHardwareInfoMgr = new OutputDevice_GetHardwareInformationPDSAManager
                    {
                        Entity = { OutputDeviceUid = entity.OutputDeviceUid }
                    };
                    var idHardwareInfo = idHardwareInfoMgr.BuildCollection();
                    if (idHardwareInfo.Count == 1)
                    {
                        entity.GalaxyHardwareAddress.IsNodeActive = idHardwareInfo[0].IsNodeActive;
                        entity.GalaxyHardwareAddress.OutputDeviceHardwareInformation = new OutputDevice_GetHardwareInformation();
                        SimpleMapper.PropertyMap(idHardwareInfo[0], entity.GalaxyHardwareAddress.OutputDeviceHardwareInformation);
                        //entity.HardwareInformation = new OutputDevice_GetHardwareInformation();
                        //SimpleMapper.PropertyMap(idHardwareInfo[0], entity.HardwareInformation);
                    }

                }

            }

            if (getParameters.IncludeMemberCollections)
            {
                if (!getParameters.IsExcluded(nameof(entity.GalaxyOutputDeviceInputSources)))
                    entity.GalaxyOutputDeviceInputSources = _galaxyOutputDeviceInputSourceRepository.GetByOutputDeviceUid(sessionData, p).ToCollection();
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyOutputDevice", "OutputDeviceUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyOutputDevice", "OutputDeviceUid", id);
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

        protected override bool IsEntityUnique(GalaxyOutputDevice entity)
        {
            //var mgr = new IsGalaxyOutputDeviceUniquePDSAManager();
            //mgr.Entity.OutputDeviceUid = entity.OutputDeviceUid;
            //mgr.Entity.GalaxyOutputDeviceName = entity.GalaxyOutputDeviceName;
            //mgr.BuildCollection();

            //if (Convert.ToInt32(mgr.Entity.Result) == 0)
            return true;
            //return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyOutputDevice", "OutputDeviceUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyOutputDevice", "OutputDeviceUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
