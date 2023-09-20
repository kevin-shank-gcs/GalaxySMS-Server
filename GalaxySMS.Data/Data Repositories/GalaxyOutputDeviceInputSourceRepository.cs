using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using System.Data.Entity;
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

namespace GalaxySMS.Data
{
    [Export(typeof(IGalaxyOutputDeviceInputSourceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyOutputDeviceInputSourceRepository : DataRepositoryBase<GalaxyOutputDeviceInputSource>, IGalaxyOutputDeviceInputSourceRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private IGalaxyOutputDeviceInputSourceAssignmentRepository _assignmentRepository;
        [Import]
        private IGalaxyOutputDeviceInputSourceInputOutputGroupRepository _inputSourceInputOutputGroupRepository;

        protected override GalaxyOutputDeviceInputSource AddEntity(GalaxyOutputDeviceInputSource entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourcePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.GalaxyOutputDeviceInputSourceUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyOutputDeviceInputSource UpdateEntity(GalaxyOutputDeviceInputSource entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.GalaxyOutputDeviceInputSourceUid, sessionData, null);
                var mgr = new GalaxyOutputDeviceInputSourcePDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.GalaxyOutputDeviceInputSourceUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if OutputDeviceUid is = Guid.Empty or null, then use the value from the original record
                    entity.OutputDeviceUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.OutputDeviceUid, entity.OutputDeviceUid);

                    // if InputOutputGroupUid is = Guid.Empty or null, then use the value from the original record
                    entity.InputOutputGroupUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InputOutputGroupUid, entity.InputOutputGroupUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.GalaxyOutputDeviceInputSourceUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.GalaxyOutputDeviceInputSourceUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void EnsureChildRecordsExist(GalaxyOutputDeviceInputSource entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //var ioGroupRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyInputOutputGroupRepository>();
            //_allIoGroups = ioGroupRepository.GetAllGalaxyInputOutputGroupsForOutputDevice(sessionData, new GetParametersWithPhoto() { UniqueId = entity.OutputDeviceUid, IncludeMemberCollections = false, IncludePhoto = false });

            //_noIog = _allIoGroups.FirstOrDefault(o => o.IOGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);
            //if (_noIog != null)
            //{
            //    var opts = saveParams.Options.ToList();
            //    opts.Add(new KeyValuePair<string, string>(SaveInputDeviceAlertEventOption.NoIoGroupUid.ToString(), _noIog.InputOutputGroupUid.ToString()));
            //    saveParams.Options = opts;
            //}

            if (!saveParams.Ignore(nameof(entity.GalaxyOutputDeviceInputSourceAssignments)) && entity.GalaxyOutputDeviceInputSourceAssignments != null && entity.GalaxyOutputDeviceInputSourceAssignments.Any())
                SaveAssignments(entity, sessionData, saveParams);

            if (!saveParams.Ignore(nameof(entity.GalaxyOutputDeviceInputSourceInputOutputGroups)) && entity.GalaxyOutputDeviceInputSourceInputOutputGroups != null && entity.GalaxyOutputDeviceInputSourceInputOutputGroups.Any())
                SaveInputOutputGroups(entity, sessionData, saveParams);
        }

        private void SaveAssignments(GalaxyOutputDeviceInputSource entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.GalaxyOutputDeviceInputSourceAssignments == null || !entity.GalaxyOutputDeviceInputSourceAssignments.Any())
                return;

            //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveGalaxyOutputDeviceInputSourceAssignmentsOption).ToString());

            //bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
            //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
            //                           kvpSaveOption.Value == Common.Enums.SaveGalaxyOutputDeviceInputSourceAssignmentsOption.DeleteMissingItems.ToString();

            // Get all existing Items
            var items = _assignmentRepository.GetByGalaxyOutputDeviceInputSource(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyOutputDeviceInputSourceUid });


            foreach (var ass in entity.GalaxyOutputDeviceInputSourceAssignments.Where(o => o.GalaxyOutputDeviceInputSourceUid == Guid.Empty))
            {
                ass.GalaxyOutputDeviceInputSourceUid = entity.GalaxyOutputDeviceInputSourceUid;
            }

            //if (bDeleteMissingItems)
            //{
            // Now delete any assignments that are no longer defined in the GalaxyOutputDeviceInputSourceAssignments collection
            foreach (var i in items)
            {
                // If the InputOutputGroupAssignmentUid does not exist in the entity, then delete from the database
                if (entity.GalaxyOutputDeviceInputSourceAssignments.FirstOrDefault(o => o.InputOutputGroupAssignmentUid == i.InputOutputGroupAssignmentUid) == null)
                {
                    _assignmentRepository.Remove(i.GalaxyOutputDeviceInputSourceAssignmentUid, sessionData);
                }
            }
            //}

            var propsToExclude = new List<string>();

            // Now save those that are defined in the output being saved
            foreach (var i in entity.GalaxyOutputDeviceInputSourceAssignments)
            {
                //if (!propsToExclude.Any())
                //{
                //    propsToExclude.Add(nameof(i.IsAnythingDirty));
                //}

                if (i.GalaxyOutputDeviceInputSourceUid != entity.GalaxyOutputDeviceInputSourceUid)
                    i.GalaxyOutputDeviceInputSourceUid = entity.GalaxyOutputDeviceInputSourceUid;

                var existingItem = items.FirstOrDefault(o => o.InputOutputGroupAssignmentUid == i.InputOutputGroupAssignmentUid);

                if (existingItem != null && i.GalaxyOutputDeviceInputSourceAssignmentUid == Guid.Empty)
                    i.GalaxyOutputDeviceInputSourceAssignmentUid = existingItem.GalaxyOutputDeviceInputSourceAssignmentUid;

                if (existingItem != null && (/*i.IsAnythingDirty || */ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _assignmentRepository.Update(i, sessionData, saveParams);
                }
                if (i.GalaxyOutputDeviceInputSourceAssignmentUid == Guid.Empty)
                {
                    i.GalaxyOutputDeviceInputSourceAssignmentUid = GuidUtilities.GenerateComb();
                    i.GalaxyOutputDeviceInputSourceUid = entity.GalaxyOutputDeviceInputSourceUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _assignmentRepository.Add(i, sessionData, saveParams);
                }
            }

        }

        private void SaveInputOutputGroups(GalaxyOutputDeviceInputSource entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.GalaxyOutputDeviceInputSourceInputOutputGroups == null || !entity.GalaxyOutputDeviceInputSourceInputOutputGroups.Any())
                return;

            //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveGalaxyOutputDeviceInputSourceInputOutputGroupsOption).ToString());

            //bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
            //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
            //                           kvpSaveOption.Value == Common.Enums.SaveGalaxyOutputDeviceInputSourceInputOutputGroupsOption.DeleteMissingItems.ToString();

            // Get all existing Items
            var items = _inputSourceInputOutputGroupRepository.GetByGalaxyOutputDeviceInputSource(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyOutputDeviceInputSourceUid });


            foreach (var ass in entity.GalaxyOutputDeviceInputSourceInputOutputGroups.Where(o => o.GalaxyOutputDeviceInputSourceUid == Guid.Empty))
            {
                ass.GalaxyOutputDeviceInputSourceUid = entity.GalaxyOutputDeviceInputSourceUid;
            }

            //if (bDeleteMissingItems)
            //{
            // Now delete any assignments that are no longer defined in the GalaxyOutputDeviceInputSourceInputOutputGroups collection
            foreach (var i in items)
            {
                // If the InputOutputGroupInputOutputGroupUid does not exist in the entity, then delete from the database
                if (entity.GalaxyOutputDeviceInputSourceInputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == i.InputOutputGroupUid) == null)
                {
                    _inputSourceInputOutputGroupRepository.Remove(i.GalaxyOutputDeviceInputSourceInputOutputGroupUid, sessionData);
                }
            }
            //}

            var propsToExclude = new List<string>();

            // Now save those that are defined in the output being saved
            foreach (var i in entity.GalaxyOutputDeviceInputSourceInputOutputGroups)
            {
                //if (!propsToExclude.Any())
                //{
                //    propsToExclude.Add(nameof(i.));
                //}


                var existingItem = items.FirstOrDefault(o => o.InputOutputGroupUid == i.InputOutputGroupUid);

                if (existingItem != null && i.GalaxyOutputDeviceInputSourceInputOutputGroupUid != existingItem.GalaxyOutputDeviceInputSourceInputOutputGroupUid)
                    i.GalaxyOutputDeviceInputSourceInputOutputGroupUid = existingItem.GalaxyOutputDeviceInputSourceInputOutputGroupUid;

                if (existingItem != null && (i.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i)))
                {
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _inputSourceInputOutputGroupRepository.Update(i, sessionData, saveParams);
                }
                if (i.GalaxyOutputDeviceInputSourceInputOutputGroupUid == Guid.Empty)
                {
                    i.GalaxyOutputDeviceInputSourceInputOutputGroupUid = GuidUtilities.GenerateComb();
                    i.GalaxyOutputDeviceInputSourceUid = entity.GalaxyOutputDeviceInputSourceUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _inputSourceInputOutputGroupRepository.Add(i, sessionData, saveParams);
                }
            }

        }

        protected override int DeleteEntity(GalaxyOutputDeviceInputSource entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourcePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyOutputDeviceInputSourceUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyOutputDeviceInputSourcePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceRepository::Remove", ex);
                throw;
            }
        }

        // GetAllGalaxyOutputDeviceInputSources in a region
        protected override IEnumerable<GalaxyOutputDeviceInputSource> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourcePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyOutputDeviceInputSourcePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyOutputDeviceInputSource> GetByOutputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourcePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyOutputDeviceInputSourcePDSAData.SelectFilters.ByOutputDeviceUid;
                mgr.Entity.OutputDeviceUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceRepository::GetByAccessPortalUid", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyOutputDeviceInputSource> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyOutputDeviceInputSourcePDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (GalaxyOutputDeviceInputSource entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<GalaxyOutputDeviceInputSource> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourcePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyOutputDeviceInputSourcePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceRepository::GetEntities", ex);
                throw;
            }
        }

        protected override GalaxyOutputDeviceInputSource GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyOutputDeviceInputSource GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourcePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyOutputDeviceInputSource result = new GalaxyOutputDeviceInputSource();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        public IEnumerable<GalaxyOutputDevice_InputSource_Main_PanelLoadData> GetPanelLoadDataForOutputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDevice_GetInputSource_Main_PanelLoadDataByOutputDeviceUidPDSAManager
                {
                    Entity = { OutputDeviceUid = getParameters.UniqueId }
                };
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<GalaxyOutputDevice_InputSource_Main_PanelLoadData>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new GalaxyOutputDevice_InputSource_Main_PanelLoadData();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        var getParams = new GetParametersWithPhoto() { UniqueId = newEntity.GalaxyOutputDeviceInputSourceUid };
                        if (!newEntity.InputOutputGroupMode)
                        {
                            newEntity.Assignments = _assignmentRepository.GetPanelLoadDataForInputSourceUid(sessionData, getParams).ToCollection();
                        }
                        else
                        {
                            newEntity.InputOutputGroups = _inputSourceInputOutputGroupRepository.GetPanelLoadDataForInputSourceUid(sessionData, getParams).ToCollection();
                        }
                        entities.Add(newEntity);
                    }
                    return entities;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //InputDeviceRepository::GetInputDevicePanelLoadData", ex);
                throw;
            }
            return null;
        }


        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyOutputDeviceInputSource originalEntity, GalaxyOutputDeviceInputSource newEntity, string auditXml)
        {
            try
            {                if( !string.IsNullOrEmpty(auditXml))
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyOutputDeviceInputSourceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyOutputDeviceInputSourceUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyOutputDeviceInputSourceUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyOutputDeviceInputSourceUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyOutputDeviceInputSourceUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyOutputDeviceInputSourceUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyOutputDeviceInputSourceUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyOutputDeviceInputSourceUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyOutputDeviceInputSourceUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyOutputDeviceInputSource entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            entity.GalaxyOutputDeviceInputSourceAssignments = _assignmentRepository.GetByGalaxyOutputDeviceInputSource(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyOutputDeviceInputSourceUid }).ToCollection();
            entity.GalaxyOutputDeviceInputSourceInputOutputGroups = _inputSourceInputOutputGroupRepository.GetByGalaxyOutputDeviceInputSource(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyOutputDeviceInputSourceUid }).ToCollection();
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyOutputDeviceInputSource", "GalaxyOutputDeviceInputSourceUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyOutputDeviceInputSource", "GalaxyOutputDeviceInputSourceUid", id);
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

        protected override bool IsEntityUnique(GalaxyOutputDeviceInputSource entity)
        {
            var mgr = new IsGalaxyOutputDeviceInputSourceUniquePDSAManager();
            mgr.Entity.GalaxyOutputDeviceInputSourceUid = entity.GalaxyOutputDeviceInputSourceUid;
            mgr.Entity.OutputDeviceUid = entity.OutputDeviceUid;
            mgr.Entity.SourceNumber = entity.SourceNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyOutputDeviceInputSource", "GalaxyOutputDeviceInputSourceUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyOutputDeviceInputSource", "GalaxyOutputDeviceInputSourceUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
