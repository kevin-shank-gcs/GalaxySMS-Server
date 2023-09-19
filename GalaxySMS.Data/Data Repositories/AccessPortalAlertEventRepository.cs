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
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.Data.Support;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IAccessPortalAlertEventRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessPortalAlertEventRepository : DataRepositoryBase<AccessPortalAlertEvent>, IAccessPortalAlertEventRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import]
        private INoteRepository _noteRepository;

        protected override AccessPortalAlertEvent AddEntity(AccessPortalAlertEvent entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.Note != null && entity.Note.IsAnythingDirty)
                {
                    SaveNote(entity, sessionData, saveParams);
                }

                if (entity.InputOutputGroupAssignmentUid.HasValue && entity.InputOutputGroupAssignmentUid.Value != Guid.Empty && entity.InputOutputGroupUid != Guid.Empty)
                {   // Verify that the assignment is associated with the input output group
                    if (InputOutputGroupHelpers.IsInputOutputGroupAssignmentAssociatedWithInputOutputGroup(entity.InputOutputGroupAssignmentUid.Value, entity.InputOutputGroupUid) == false)
                        entity.InputOutputGroupAssignmentUid = Guid.Empty;
                }

                var noIoGroupUid = saveParams.OptionValue<Guid>(SaveAccessPortalAlertEventsOption.NoIoGroupUid.ToString());

                if( entity.InputOutputGroupUid == noIoGroupUid)
                    entity.InputOutputGroupAssignmentUid = Guid.Empty;


                if (entity?.AccessPortalAlertEventType?.CanHaveInputOutputGroupOffset == false)
                    entity.InputOutputGroupAssignmentUid = null;
                else
                {
                    if (entity?.AccessPortalAlertEventType?.CanHaveInputOutputGroupOffset == true &&
                        entity.InputOutputGroupAssignmentUid != null && entity.InputOutputGroupUid != GetInputOutputGroupUid(entity.AccessPortalUid, GalaxySMS.Common.Constants.InputOutputGroupLimits.None))
                    {
                        entity.InputOutputGroupAssignmentUid = InputOutputGroupHelpers.GetAvailableInputOutputGroupAssignmentUid(entity.InputOutputGroupUid);
                        // if the Input Output Group is full, meaning that all 32 assignments are already allocated, the return value will be Guid.Empty
                        if (entity.InputOutputGroupAssignmentUid == Guid.Empty)
                        {
                            throw new Exception(string.Format(GalaxySMS.Resources.Resources.InputOutputGroup_UnableToAssignEventToGroup_Full, entity.AccessPortalAlertEventType.Display));
                        }
                    }
                }


                var mgr = new AccessPortalAlertEventPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.AccessPortalAlertEventUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        if (entity.AccessPortalAlertEventTypeUid ==
                            GalaxySMS.Common.Constants.AccessPortalAlertEventTypeIds.DoorGroup)
                        {
                            UpdateEntityAccessPortalGroupCount(entity.EntityId);
                        }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAlertEventRepository::AddEntity", ex);
                throw;
            }
        }


        private void SaveNote(AccessPortalAlertEvent entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.Note.NoteUid == Guid.Empty)
                entity.Note.NoteUid = GuidUtilities.GenerateComb();
            entity.ResponseInstructionsUid = entity.Note.NoteUid;

            // Note
            var existingNote = _noteRepository.Get(entity.Note.NoteUid, sessionData, new GetParametersWithPhoto() { UniqueId = entity.Note.NoteUid });

            if (existingNote != null)
            {
                if (entity.Note.IsAnythingDirty == true)
                {
                    UpdateTableEntityBaseProperties(entity.Note, sessionData);
                    _noteRepository.Update(entity.Note, sessionData, saveParams);
                }
            }
            else
            {
                UpdateTableEntityBaseProperties(entity.Note, sessionData);
                _noteRepository.Add(entity.Note, sessionData, saveParams);
            }
        }

        protected override AccessPortalAlertEvent UpdateEntity(AccessPortalAlertEvent entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.Note != null && entity.Note.IsAnythingDirty )
                {
                    SaveNote(entity, sessionData, saveParams);
                }

                if (entity.InputOutputGroupAssignmentUid.HasValue && entity.InputOutputGroupAssignmentUid.Value != Guid.Empty && entity.InputOutputGroupUid != Guid.Empty)
                {   // Verify that the assignment is associated with the input output group
                    if (InputOutputGroupHelpers.IsInputOutputGroupAssignmentAssociatedWithInputOutputGroup(entity.InputOutputGroupAssignmentUid.Value, entity.InputOutputGroupUid) == false)
                        entity.InputOutputGroupAssignmentUid = Guid.Empty;
                }

                var noIoGroupUid = saveParams.OptionValue<Guid>(SaveAccessPortalAlertEventsOption.NoIoGroupUid.ToString());

                if( entity.InputOutputGroupUid == noIoGroupUid)
                    entity.InputOutputGroupAssignmentUid = Guid.Empty;

                if (entity?.AccessPortalAlertEventType?.CanHaveInputOutputGroupOffset == false)
                    entity.InputOutputGroupAssignmentUid = null;
                else
                {
                    if (entity?.AccessPortalAlertEventType?.CanHaveInputOutputGroupOffset == true &&
                        (entity.InputOutputGroupAssignmentUid == null || entity.InputOutputGroupAssignmentUid == Guid.Empty) && entity.InputOutputGroupUid != GetInputOutputGroupUid(entity.AccessPortalUid, GalaxySMS.Common.Constants.InputOutputGroupLimits.None))
                    {
                        entity.InputOutputGroupAssignmentUid = InputOutputGroupHelpers.GetAvailableInputOutputGroupAssignmentUid(entity.InputOutputGroupUid);
                        if (entity.InputOutputGroupAssignmentUid == Guid.Empty)
                        {
                            throw new Exception(string.Format(GalaxySMS.Resources.Resources.InputOutputGroup_UnableToAssignEventToGroup_Full, entity.AccessPortalAlertEventType.Display));
                        }
                    }
                }

                var originalEntity = GetEntityByGuidId(entity.AccessPortalAlertEventUid, sessionData, null);
                var mgr = new AccessPortalAlertEventPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.AccessPortalAlertEventUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if InputOutputGroupUid is = Guid.Empty or null, then use the value from the original record
                    entity.InputOutputGroupUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InputOutputGroupUid, entity.InputOutputGroupUid);

                    // if AcknowledgeTimeScheduleUid is = Guid.Empty or null, then use the value from the original record
                    entity.AcknowledgeTimeScheduleUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AcknowledgeTimeScheduleUid, entity.AcknowledgeTimeScheduleUid);

                    // if AudioBinaryResourceUid is = Guid.Empty or null, then use the value from the original record
                    entity.AudioBinaryResourceUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AudioBinaryResourceUid, entity.AudioBinaryResourceUid);

                    // if ResponseInstructionsUid is = Guid.Empty or null, then use the value from the original record
                    entity.ResponseInstructionsUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.ResponseInstructionsUid, entity.ResponseInstructionsUid);

                    // if AccessPortalAlertEventTypeUid is = Guid.Empty or null, then use the value from the original record
                    entity.AccessPortalAlertEventTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessPortalAlertEventTypeUid, entity.AccessPortalAlertEventTypeUid);

                    //// if InputOutputGroupAssignmentUid is = Guid.Empty or null, then use the value from the original record
                    //entity.InputOutputGroupAssignmentUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InputOutputGroupAssignmentUid, entity.InputOutputGroupAssignmentUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.AccessPortalAlertEventUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        UpdateEntityAccessPortalGroupCount(updatedEntity.EntityId);
                        if( updatedEntity.EntityId != originalEntity.EntityId )
                            UpdateEntityAccessPortalGroupCount(originalEntity.EntityId);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.AccessPortalAlertEventUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAlertEventRepository::UpdateEntity", ex);
                throw;
            }
        }

        private Guid GetInputOutputGroupUid(Guid accessPortalUid, int inputOutputGroupNumber)
        {
            var iogMgr = new InputOutputGroupUid_GetByAccessPortalUidAndIOGroupNumberPDSAManager();
            iogMgr.Entity.accessPortalUid = accessPortalUid;
            iogMgr.Entity.ioGroupNumber = GalaxySMS.Common.Constants.InputOutputGroupLimits.None;
            var iog = iogMgr.BuildCollection();
            if (iog != null && iog.Count == 1)
                return iog[0].InputOutputGroupUid;
            return Guid.Empty;

        }
        protected override int DeleteEntity(AccessPortalAlertEvent entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new AccessPortalAlertEventPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.AccessPortalAlertEventUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAlertEventRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new AccessPortalAlertEventPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAlertEventRepository::Remove", ex);
                throw;
            }
        }

        // GetAllAccessPortalAlertEvents in a region
        protected override IEnumerable<AccessPortalAlertEvent> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalAlertEventPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAlertEventRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<AccessPortalAlertEvent> GetByAccessPortalUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessPortalAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalAlertEventPDSAData.SelectFilters.ByAccessPortalUid;
                mgr.Entity.AccessPortalUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAlertEventRepository::GetByAccessPortalUid", ex);
                throw;
            }
        }

        public IEnumerable<AccessPortalAlertEvent> GetByEntityId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessPortalAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalAlertEventPDSAData.SelectFilters.ByEntityId;
                mgr.Entity.EntityId = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAlertEventRepository::GetByAccessPortalUid", ex);
                throw;
            }
        }

        private IEnumerable<AccessPortalAlertEvent> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessPortalAlertEventPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (AccessPortalAlertEvent entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<AccessPortalAlertEvent> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalAlertEventPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAlertEventRepository::GetEntities", ex);
                throw;
            }
        }

        protected override AccessPortalAlertEvent GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override AccessPortalAlertEvent GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalAlertEventPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    AccessPortalAlertEvent result = new AccessPortalAlertEvent();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAlertEventRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, AccessPortalAlertEvent originalEntity, AccessPortalAlertEvent newEntity, string auditXml)
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
propertiesToIgnore.Add("Note");
                        propertiesToIgnore.Add("gcsBinaryResource");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalAlertEventUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessPortalAlertEventUid;
                        mgr.Entity.RecordTag = newEntity.AccessPortalAlertEventUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalAlertEventUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessPortalAlertEventUid;
                        mgr.Entity.RecordTag = newEntity.AccessPortalAlertEventUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalAlertEventUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AccessPortalAlertEventUid;
                        mgr.Entity.RecordTag = originalEntity.AccessPortalAlertEventUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAlertEventRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(AccessPortalAlertEvent entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (entity.ResponseInstructionsUid.HasValue && entity.ResponseInstructionsUid.Value != Guid.Empty)
            {
                entity.Note = _noteRepository.Get(entity.ResponseInstructionsUid.Value, sessionData, getParameters);
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("AccessPortalAlertEvent", "AccessPortalAlertEventUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("AccessPortalAlertEvent", "AccessPortalAlertEventUid", id);
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

        protected override bool IsEntityUnique(AccessPortalAlertEvent entity)
        {
            var mgr = new IsAccessPortalAlertEventUniquePDSAManager();
            mgr.Entity.AccessPortalAlertEventUid = entity.AccessPortalAlertEventUid;
            mgr.Entity.AccessPortalUid = entity.AccessPortalUid;
            mgr.Entity.AccessPortalAlertEventTypeUid = entity.AccessPortalAlertEventTypeUid;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("AccessPortalAlertEvent", "AccessPortalAlertEventUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("AccessPortalAlertEvent", "AccessPortalAlertEventUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        private void UpdateEntityAccessPortalGroupCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertAccessPortalGroupCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

    }
}
