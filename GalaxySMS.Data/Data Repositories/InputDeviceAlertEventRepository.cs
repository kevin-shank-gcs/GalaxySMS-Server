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
    [Export(typeof(IInputDeviceAlertEventRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InputDeviceAlertEventRepository : DataRepositoryBase<InputDeviceAlertEvent>, IInputDeviceAlertEventRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import] IInputDeviceAlertEventTypeRepository _inputDeviceAlertEventTypeRepository;
        protected override InputDeviceAlertEvent AddEntity(InputDeviceAlertEvent entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var noIoGroupUid = saveParams.OptionValue<Guid>(SaveInputDeviceAlertEventOption.NoIoGroupUid.ToString());

                if (entity.InputOutputGroupAssignmentUid.HasValue && 
                    entity.InputOutputGroupAssignmentUid.Value != Guid.Empty && 
                    entity.InputOutputGroupUid != Guid.Empty )
                {   // Verify that the assignment is associated with the input output group
                    if (InputOutputGroupHelpers.IsInputOutputGroupAssignmentAssociatedWithInputOutputGroup(entity.InputOutputGroupAssignmentUid.Value, entity.InputOutputGroupUid) == false)
                        entity.InputOutputGroupAssignmentUid = Guid.Empty;
                }

                if( entity.InputOutputGroupUid == noIoGroupUid)
                    entity.InputOutputGroupAssignmentUid = Guid.Empty;

                var inputDeviceAlertEventType = _inputDeviceAlertEventTypeRepository.Get(entity.InputDeviceAlertEventTypeUid, sessionData, new GetParametersWithPhoto());
                if (inputDeviceAlertEventType?.CanHaveInputOutputGroupOffset == false)
                    entity.InputOutputGroupAssignmentUid = null;
                else
                {
                    if (inputDeviceAlertEventType?.CanHaveInputOutputGroupOffset == true &&
                        entity.InputOutputGroupAssignmentUid != null && 
                        entity.InputOutputGroupUid != GetInputOutputGroupUid(entity.InputDeviceUid, GalaxySMS.Common.Constants.InputOutputGroupLimits.None))
                    {
                        entity.InputOutputGroupAssignmentUid = InputOutputGroupHelpers.GetAvailableInputOutputGroupAssignmentUid(entity.InputOutputGroupUid);
                        // if the Input Output Group is full, meaning that all 32 assignments are already allocated, the return value will be Guid.Empty
                        if (entity.InputOutputGroupAssignmentUid == Guid.Empty)
                        {
                            throw new Exception(string.Format(GalaxySMS.Resources.Resources.InputOutputGroup_UnableToAssignEventToGroup_Full, inputDeviceAlertEventType?.Display));
                        }
                    }
                }
                var mgr = new InputDeviceAlertEventPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.InputDeviceAlertEventUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceAlertEventRepository::AddEntity", ex);
                throw;
            }
        }

        protected override InputDeviceAlertEvent UpdateEntity(InputDeviceAlertEvent entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var noIoGroupUid = saveParams.OptionValue<Guid>(SaveInputDeviceAlertEventOption.NoIoGroupUid.ToString());

                if (entity.InputOutputGroupAssignmentUid.HasValue && entity.InputOutputGroupAssignmentUid.Value != Guid.Empty && entity.InputOutputGroupUid != Guid.Empty)
                {   // Verify that the assignment is associated with the input output group
                    if (InputOutputGroupHelpers.IsInputOutputGroupAssignmentAssociatedWithInputOutputGroup(entity.InputOutputGroupAssignmentUid.Value, entity.InputOutputGroupUid) == false)
                        entity.InputOutputGroupAssignmentUid = Guid.Empty;
                }

                if( entity.InputOutputGroupUid == noIoGroupUid)
                    entity.InputOutputGroupAssignmentUid = Guid.Empty;

                var inputDeviceAlertEventType = _inputDeviceAlertEventTypeRepository.Get(entity.InputDeviceAlertEventTypeUid, sessionData, new GetParametersWithPhoto());
                if (inputDeviceAlertEventType?.CanHaveInputOutputGroupOffset == false)
                    entity.InputOutputGroupAssignmentUid = null;
                else
                {
                    if (inputDeviceAlertEventType?.CanHaveInputOutputGroupOffset == true &&
                        (entity.InputOutputGroupAssignmentUid == null || entity.InputOutputGroupAssignmentUid == Guid.Empty) && entity.InputOutputGroupUid != GetInputOutputGroupUid(entity.InputDeviceUid, GalaxySMS.Common.Constants.InputOutputGroupLimits.None))
                    {
                        entity.InputOutputGroupAssignmentUid = InputOutputGroupHelpers.GetAvailableInputOutputGroupAssignmentUid(entity.InputOutputGroupUid);
                        if (entity.InputOutputGroupAssignmentUid == Guid.Empty)
                        {
                            throw new Exception(string.Format(GalaxySMS.Resources.Resources.InputOutputGroup_UnableToAssignEventToGroup_Full, inputDeviceAlertEventType?.Display));
                        }
                    }
                }

                var originalEntity = GetEntityByGuidId(entity.InputDeviceAlertEventUid, sessionData, null);
                var mgr = new InputDeviceAlertEventPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.InputDeviceAlertEventUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;
                    
                    // if InputDeviceUid is = Guid.Empty or null, then use the value from the original record
                    entity.InputDeviceUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InputDeviceUid, entity.InputDeviceUid);

                    // if InputOutputGroupUid is = Guid.Empty or null, then use the value from the original record
                    entity.InputOutputGroupUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InputOutputGroupUid, entity.InputOutputGroupUid);

                    //// if InputOutputGroupAssignmentUid is = Guid.Empty or null, then use the value from the original record
                    //entity.InputOutputGroupAssignmentUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InputOutputGroupAssignmentUid, entity.InputOutputGroupAssignmentUid);
                    
                    // if InputDeviceAlertEventTypeUid is = Guid.Empty or null, then use the value from the original record
                    entity.InputDeviceAlertEventTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InputDeviceAlertEventTypeUid, entity.InputDeviceAlertEventTypeUid);

                    if( string.IsNullOrEmpty(entity.Tag))
                        entity.Tag = mgr.Entity.Tag;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.InputDeviceAlertEventUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.InputDeviceAlertEventUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceAlertEventRepository::UpdateEntity", ex);
                throw;
            }
        }

        
        private Guid GetInputOutputGroupUid(Guid inputDeviceUid, int inputOutputGroupNumber)
        {
            var iogMgr = new InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAManager();
            iogMgr.Entity.inputDeviceUid = inputDeviceUid;
            iogMgr.Entity.ioGroupNumber = GalaxySMS.Common.Constants.InputOutputGroupLimits.None;
            var iog = iogMgr.BuildCollection();
            if (iog != null && iog.Count == 1)
                return iog[0].InputOutputGroupUid;
            return Guid.Empty;

        }
        protected override int DeleteEntity(InputDeviceAlertEvent entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new InputDeviceAlertEventPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.InputDeviceAlertEventUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceAlertEventRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new InputDeviceAlertEventPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceAlertEventRepository::Remove", ex);
                throw;
            }
        }

        // GetAllInputDeviceAlertEvents in a region
        protected override IEnumerable<InputDeviceAlertEvent> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDeviceAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = InputDeviceAlertEventPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceAlertEventRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<InputDeviceAlertEvent> GetByInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputDeviceAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = InputDeviceAlertEventPDSAData.SelectFilters.ByInputDeviceUid;
                mgr.Entity.InputDeviceUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceAlertEventRepository::GetByAccessPortalUid", ex);
                throw;
            }
        }

        private IEnumerable<InputDeviceAlertEvent> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, InputDeviceAlertEventPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (InputDeviceAlertEvent entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<InputDeviceAlertEvent> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDeviceAlertEventPDSAManager();
                mgr.DataObject.SelectFilter = InputDeviceAlertEventPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceAlertEventRepository::GetEntities", ex);
                throw;
            }
        }

        protected override InputDeviceAlertEvent GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override InputDeviceAlertEvent GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDeviceAlertEventPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    InputDeviceAlertEvent result = new InputDeviceAlertEvent();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceAlertEventRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, InputDeviceAlertEvent originalEntity, InputDeviceAlertEvent newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceAlertEventUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InputDeviceAlertEventUid;
                        mgr.Entity.RecordTag = newEntity.InputDeviceAlertEventUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceAlertEventUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InputDeviceAlertEventUid;
                        mgr.Entity.RecordTag = newEntity.InputDeviceAlertEventUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceAlertEventUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.InputDeviceAlertEventUid;
                        mgr.Entity.RecordTag = originalEntity.InputDeviceAlertEventUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceAlertEventRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(InputDeviceAlertEvent entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("InputDeviceAlertEvent", "InputDeviceAlertEventUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("InputDeviceAlertEvent", "InputDeviceAlertEventUid", id);
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

        protected override bool IsEntityUnique(InputDeviceAlertEvent entity)
        {
            var mgr = new IsInputDeviceAlertEventUniquePDSAManager();
            mgr.Entity.InputDeviceAlertEventUid = entity.InputDeviceAlertEventUid;
            mgr.Entity.InputDeviceUid = entity.InputDeviceUid;
            mgr.Entity.InputDeviceAlertEventTypeUid = entity.InputDeviceAlertEventTypeUid;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("InputDeviceAlertEvent", "InputDeviceAlertEventUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("InputDeviceAlertEvent", "InputDeviceAlertEventUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
