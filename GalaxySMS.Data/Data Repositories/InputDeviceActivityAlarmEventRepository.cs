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
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IInputDeviceActivityAlarmEventRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InputDeviceActivityAlarmEventRepository : DataRepositoryBase<InputDeviceActivityAlarmEvent>, IInputDeviceActivityAlarmEventRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        protected override InputDeviceActivityAlarmEvent AddEntity(InputDeviceActivityAlarmEvent entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new InputDeviceActivityAlarmEventPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.InputDeviceActivityEventUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceActivityAlarmEventRepository::AddEntity", ex);
                throw;
            }
        }

        protected override InputDeviceActivityAlarmEvent UpdateEntity(InputDeviceActivityAlarmEvent entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.InputDeviceActivityEventUid, sessionData, null);
                var mgr = new InputDeviceActivityAlarmEventPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.InputDeviceActivityEventUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.InputDeviceActivityEventUid, sessionData, null);
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                    return updatedEntity;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceActivityAlarmEventRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(InputDeviceActivityAlarmEvent entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new InputDeviceActivityAlarmEventPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.InputDeviceActivityEventUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceActivityAlarmEventRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new InputDeviceActivityAlarmEventPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceActivityAlarmEventRepository::Remove", ex);
                throw;
            }
        }

        // GetAllInputDeviceActivityAlarmEvents in a region
        protected override IEnumerable<InputDeviceActivityAlarmEvent> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDeviceActivityAlarmEventPDSAManager();
                mgr.DataObject.SelectFilter = InputDeviceActivityAlarmEventPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceActivityAlarmEventRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<InputDeviceActivityAlarmEvent> GetByInputDeviceUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputDeviceActivityAlarmEventPDSAManager();
                mgr.DataObject.SelectFilter = InputDeviceActivityAlarmEventPDSAData.SelectFilters.ByInputDeviceUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceActivityAlarmEventRepository::GetByInputDeviceUid", ex);
                throw;
            }
        }
        public InputDeviceActivityAlarmEvent GetByInputDeviceActivityEventUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            return GetEntityByGuidId(parameters.UniqueId, sessionData, parameters);
        }

        public PanelActivityLogMessage[] GetUnacknowledgedAlarms(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            var mgr = new UnacknowledgedAlarms_ByDeviceEntityIdPDSAManager();
            if( sessionData.CurrentEntityId != Guid.Empty && parameters.CurrentEntityId != Guid.Empty)
            {
                if( parameters.CurrentEntityId != Guid.Empty)
                    mgr.Entity.DeviceEntityId = parameters.CurrentEntityId;
                else
                    mgr.Entity.DeviceEntityId = sessionData.CurrentEntityId;
            }
            var pdsaEntities = mgr.BuildCollection();
            var results = new List<PanelActivityLogMessage>();
            foreach( var e in pdsaEntities)
            {
                results.Add(mgr.ConvertPDSAEntity(e));
            }
            return results.ToArray();
        }

        private IEnumerable<InputDeviceActivityAlarmEvent> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, InputDeviceActivityAlarmEventPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (InputDeviceActivityAlarmEvent entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<InputDeviceActivityAlarmEvent> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDeviceActivityAlarmEventPDSAManager();
                mgr.DataObject.SelectFilter = InputDeviceActivityAlarmEventPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceActivityAlarmEventRepository::GetEntities", ex);
                throw;
            }
        }

        protected override InputDeviceActivityAlarmEvent GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override InputDeviceActivityAlarmEvent GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDeviceActivityAlarmEventPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    InputDeviceActivityAlarmEvent result = new InputDeviceActivityAlarmEvent();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceActivityAlarmEventRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, InputDeviceActivityAlarmEvent originalEntity, InputDeviceActivityAlarmEvent newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceActivityEventUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InputDeviceActivityEventUid;
                        mgr.Entity.RecordTag = newEntity.InputDeviceActivityEventUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceActivityEventUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InputDeviceActivityEventUid;
                        mgr.Entity.RecordTag = newEntity.InputDeviceActivityEventUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceActivityEventUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.InputDeviceActivityEventUid;
                        mgr.Entity.RecordTag = originalEntity.InputDeviceActivityEventUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceActivityAlarmEventRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(InputDeviceActivityAlarmEvent entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("InputDeviceActivityAlarmEvent", "InputDeviceActivityAlarmEventUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("InputDeviceActivityAlarmEvent", "InputDeviceActivityAlarmEventUid", id);
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

        protected override bool IsEntityUnique(InputDeviceActivityAlarmEvent entity)
        {
            var mgr = new IsInputDeviceActivityAlarmEventUniquePDSAManager();
            mgr.Entity.InputDeviceActivityEventUid = entity.InputDeviceActivityEventUid;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("InputDeviceActivityAlarmEvent", "InputDeviceActivityEventUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("InputDeviceActivityAlarmEvent", "InputDeviceActivityEventUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
