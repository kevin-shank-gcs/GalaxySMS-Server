using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
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
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace GalaxySMS.Data
{
    [Export(typeof(IGalaxyPanelAlertEventRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyPanelAlertEventRepository : DataRepositoryBase<GalaxyPanelAlertEvent>, IGalaxyPanelAlertEventRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import]
        private INoteRepository _noteRepository;
        [Import]
        private IGalaxyPanelAlertEventTypeRepository _alertEventTypeRepository;

        protected override GalaxyPanelAlertEvent AddEntity(GalaxyPanelAlertEvent entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.Note != null && entity.Note.IsAnythingDirty)
                {
                    SaveNote(entity, sessionData, saveParams);
                }

                if (entity.AcknowledgeTimeScheduleUid == Guid.Empty)
                    entity.AcknowledgeTimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;

                ValidateIOGroupAndAssignmentValues(entity, sessionData);

                var mgr = new GalaxyPanelAlertEventPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.GalaxyPanelAlertEventUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelAlertEventRepository::AddEntity", ex);
                throw;
            }
        }

        private void ValidateIOGroupAndAssignmentValues(GalaxyPanelAlertEvent entity, IApplicationUserSessionDataHeader sessionData)
        {
            if (entity.InputOutputGroupUid == Guid.Empty && (!entity.InputOutputGroupAssignmentUid.HasValue || entity.InputOutputGroupAssignmentUid.Value == Guid.Empty))
                return;

            entity.GalaxyPanelAlertEventType = _alertEventTypeRepository.Get(entity.GalaxyPanelAlertEventTypeUid, sessionData, null);

            if (entity.InputOutputGroupUid != Guid.Empty)
            {
                if (!InputOutputGroupHelpers.IsInputOutputGroupAssociatedWithGalaxyPanel(entity.InputOutputGroupUid,
                        entity.GalaxyPanelUid))
                {
                    throw new DataValidationException(string.Format(
                        GalaxySMS.Resources.Resources.InputOutputGroup_UnableToAssignEventToGroup_WrongCluster,
                        entity.GalaxyPanelAlertEventType.Display));
                }
            }

            // If an assignment is not allowed, then null it out
            if (entity.GalaxyPanelAlertEventType?.CanHaveInputOutputGroupOffset == false)
                entity.InputOutputGroupAssignmentUid = null;
            else
            {
                // Validate the InputOutputGroupUid and InputOutputGroupAssignmentUid values

                // If InputOutputGroupAssignmentUid and InputOutputGroupUid are both not equal to Guid.Empty, then verify that the AssignmentUid is from the same IOgroup as InputOutputGroupUid
                if (entity.InputOutputGroupAssignmentUid.HasValue && entity.InputOutputGroupAssignmentUid.Value != Guid.Empty &&
                    entity.InputOutputGroupUid != Guid.Empty)
                {
                    // Verify that the assignment is associated with the input output group
                    if (InputOutputGroupHelpers.IsInputOutputGroupAssignmentAssociatedWithInputOutputGroup(
                            entity.InputOutputGroupAssignmentUid.Value, entity.InputOutputGroupUid) == false)
                        entity.InputOutputGroupAssignmentUid = Guid.Empty;
                }
                else if (entity.InputOutputGroupAssignmentUid.HasValue &&
                         entity.InputOutputGroupAssignmentUid.Value != Guid.Empty &&
                         entity.InputOutputGroupUid == Guid.Empty)
                {
                    // If only an IOGroupAssignment is specified AND no IOGroup is specified, then determine the IOGroup from the Assignment
                    entity.InputOutputGroupUid =
                        InputOutputGroupHelpers.GetInputOutputUidFromInputOutputGroupAssignmentUid(
                            entity.InputOutputGroupAssignmentUid.Value);

                    if (entity.InputOutputGroupUid != Guid.Empty)
                    {
                        if (!InputOutputGroupHelpers.IsInputOutputGroupAssociatedWithGalaxyPanel(entity.InputOutputGroupUid,
                                entity.GalaxyPanelUid))
                        {
                            throw new DataValidationException(string.Format(
                                GalaxySMS.Resources.Resources.InputOutputGroup_UnableToAssignEventToGroup_WrongCluster,
                                entity.GalaxyPanelAlertEventType.Display));
                        }
                    }
                }

                var noIogUid =
                    GetInputOutputGroupUid(entity.GalaxyPanelUid, GalaxySMS.Common.Constants.InputOutputGroupLimits.None);

                // If alert type can have an assignment (which really means that it must have an assignment), AND
                // it does not have an assignment specified AND 
                // the IOGroup is not None, then select an assignment value for it
                // 
                if (entity.GalaxyPanelAlertEventType?.CanHaveInputOutputGroupOffset == true &&
                    entity.InputOutputGroupUid != noIogUid &&
                    (!entity.InputOutputGroupAssignmentUid.HasValue ||
                     entity.InputOutputGroupAssignmentUid.Value == Guid.Empty))
                {
                    entity.InputOutputGroupAssignmentUid =
                        InputOutputGroupHelpers.GetAvailableInputOutputGroupAssignmentUid(entity.InputOutputGroupUid);
                    // if the Input Output Group is full, meaning that all 32 assignments are already allocated, the return value will be Guid.Empty
                    if (entity.InputOutputGroupAssignmentUid == Guid.Empty)
                    {
                        throw new Exception(string.Format(
                            GalaxySMS.Resources.Resources.InputOutputGroup_UnableToAssignEventToGroup_Full,
                            entity.GalaxyPanelAlertEventType.Display));
                    }
                }
            }
        }


        private void SaveNote(GalaxyPanelAlertEvent entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.Note.NoteUid == Guid.Empty)
                entity.Note.NoteUid = GuidUtilities.GenerateComb();
            entity.UserInstructionsNoteUid = entity.Note.NoteUid;

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

        protected override GalaxyPanelAlertEvent UpdateEntity(GalaxyPanelAlertEvent entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.Note != null && entity.Note.IsAnythingDirty)
                {
                    SaveNote(entity, sessionData, saveParams);
                }

                ValidateIOGroupAndAssignmentValues(entity, sessionData);

                var originalEntity = GetEntityByGuidId(entity.GalaxyPanelAlertEventUid, sessionData, null);
                var mgr = new GalaxyPanelAlertEventPDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.GalaxyPanelAlertEventUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    if (entity.AcknowledgeTimeScheduleUid == Guid.Empty)
                        entity.AcknowledgeTimeScheduleUid = mgr.Entity.AcknowledgeTimeScheduleUid;

                    if (entity.InputOutputGroupUid == Guid.Empty)
                        entity.InputOutputGroupUid = mgr.Entity.InputOutputGroupUid;

                    if (!entity.InputOutputGroupAssignmentUid.HasValue || entity.InputOutputGroupAssignmentUid.Value == Guid.Empty)
                        entity.InputOutputGroupAssignmentUid = mgr.Entity.InputOutputGroupAssignmentUid;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.GalaxyPanelAlertEventUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }

                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.GalaxyPanelAlertEventUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelAlertEventRepository::UpdateEntity", ex);
                throw;
            }
        }

        //private Guid GetAvailableInputOutputGroupAssignmentUid(Guid inputOutputGroupUid, Guid GalaxyPanelUid)
        //{
        //    var mgr = new InputOutputGroupAssignment_GetAvailableOffsetIndexPDSAManager();
        //    mgr.Entity.InputOutputGroupUid = inputOutputGroupUid;
        //    var data = mgr.BuildCollection();
        //    if (data != null && data.Count == 1)
        //        return data[0].InputOutputGroupAssignmentUid;
        //    return Guid.Empty;
        //}

        //private bool IsInputOutputGroupAssignmentAssociatedWithInputOutputGroup(Guid inputOutputGroupAssignmentUid, Guid inputOutputGroupUid)
        //{
        //    var mgr = new InputOutputGroupAssignment_IsAssociatedWithInputOutputGroupPDSAManager();
        //    mgr.Entity.InputOutputGroupAssignmentUid = inputOutputGroupAssignmentUid;
        //    mgr.Entity.InputOutputGroupUid = inputOutputGroupUid;
        //    var result = mgr.BuildCollection();
        //    if (result != null && result.Count == 1)
        //        return result[0].Result == 1;
        //    return false;
        //}

        private Guid GetInputOutputGroupUid(Guid GalaxyPanelUid, int inputOutputGroupNumber)
        {
            var iogMgr = new InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAManager();
            iogMgr.Entity.galaxyPanelUid = GalaxyPanelUid;
            iogMgr.Entity.ioGroupNumber = GalaxySMS.Common.Constants.InputOutputGroupLimits.None;
            var iog = iogMgr.BuildCollection();
            if (iog != null && iog.Count == 1)
                return iog[0].InputOutputGroupUid;
            return Guid.Empty;

        }
        protected override int DeleteEntity(GalaxyPanelAlertEvent entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyPanelAlertEventPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyPanelAlertEventUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelAlertEventRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyPanelAlertEventPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelAlertEventRepository::Remove", ex);
                throw;
            }
        }

        // GetAllGalaxyPanelAlertEvents in a region
        protected override IEnumerable<GalaxyPanelAlertEvent> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelAlertEventPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelAlertEventRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyPanelAlertEvent> GetByGalaxyPanelUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyPanelAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelAlertEventPDSAData.SelectFilters.ByGalaxyPanelUid;
                mgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelAlertEventRepository::GetByGalaxyPanelUid", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyPanelAlertEvent> GetByEntityId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyPanelAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelAlertEventPDSAData.SelectFilters.ByEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelAlertEventRepository::GetByGalaxyPanelUid", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyPanelAlertEvent> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyPanelAlertEventPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (GalaxyPanelAlertEvent entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<GalaxyPanelAlertEvent> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelAlertEventPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelAlertEventRepository::GetEntities", ex);
                throw;
            }
        }

        protected override GalaxyPanelAlertEvent GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyPanelAlertEvent GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelAlertEventPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyPanelAlertEvent result = new GalaxyPanelAlertEvent();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelAlertEventRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyPanelAlertEvent originalEntity, GalaxyPanelAlertEvent newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyPanelAlertEventUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyPanelAlertEventUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyPanelAlertEventUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyPanelAlertEventUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyPanelAlertEventUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyPanelAlertEventUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyPanelAlertEventUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyPanelAlertEventUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyPanelAlertEventUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelAlertEventRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyPanelAlertEvent entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (entity.UserInstructionsNoteUid.HasValue && entity.UserInstructionsNoteUid.Value != Guid.Empty)
            {
                entity.Note = _noteRepository.Get(entity.UserInstructionsNoteUid.Value, sessionData, getParameters);
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyPanelAlertEvent", "GalaxyPanelAlertEventUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyPanelAlertEvent", "GalaxyPanelAlertEventUid", id);
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

        protected override bool IsEntityUnique(GalaxyPanelAlertEvent entity)
        {
            var mgr = new IsGalaxyPanelAlertEventUniquePDSAManager();
            mgr.Entity.GalaxyPanelAlertEventUid = entity.GalaxyPanelAlertEventUid;
            mgr.Entity.GalaxyPanelUid = entity.GalaxyPanelUid;
            mgr.Entity.GalaxyPanelAlertEventTypeUid = entity.GalaxyPanelAlertEventTypeUid;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyPanelAlertEvent", "GalaxyPanelAlertEventUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyPanelAlertEvent", "GalaxyPanelAlertEventUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
