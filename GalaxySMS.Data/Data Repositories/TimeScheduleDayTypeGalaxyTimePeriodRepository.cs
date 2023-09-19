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
    [Export(typeof(ITimeScheduleDayTypeGalaxyTimePeriodRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TimeScheduleDayTypeGalaxyTimePeriodRepository : DataRepositoryBase<TimeScheduleDayTypeGalaxyTimePeriod>, ITimeScheduleDayTypeGalaxyTimePeriodRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        protected override TimeScheduleDayTypeGalaxyTimePeriod AddEntity(TimeScheduleDayTypeGalaxyTimePeriod entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {

                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveTimePeriod(sessionData, entity);
                    var result = GetEntityByGuidId(entity.TimeScheduleDayTypeGalaxyTimePeriodUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::AddEntity", ex);
                throw;
            }
        }

        protected override TimeScheduleDayTypeGalaxyTimePeriod UpdateEntity(TimeScheduleDayTypeGalaxyTimePeriod entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.TimeScheduleDayTypeGalaxyTimePeriodUid, sessionData, null);
                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.TimeScheduleDayTypeGalaxyTimePeriodUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    //SaveTimePeriod(sessionData, entity);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.TimeScheduleDayTypeGalaxyTimePeriodUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::UpdateEntity", ex);
                throw;
            }
        }

        //private void SaveTimePeriod(IApplicationUserSessionDataHeader sessionData, TimeScheduleDayTypeGalaxyTimePeriod entity, ISaveParameters saveParams)
        //{// Sometimes this will be called without any TimePeriod object. This could happen when the TimeSchedule repository
        //    if (entity.TimePeriod == null)
        //        return;
        //    var _timePeriodRepository = _dataRepositoryFactory.GetDataRepository<ITimePeriodRepository>();

        //    if( entity.TimePeriod.IsDirty)
        //    {
        //        entity.TimePeriod.UpdateDate = DateTimeOffset.Now;
        //        entity.TimePeriod.UpdateName = sessionData.UserName;

        //        if (entity.TimePeriod.TimePeriodUid == Guid.Empty)
        //        {
        //            entity.TimePeriod.TimePeriodUid = GuidUtilities.GenerateComb();
        //        }
        //        if (_timePeriodRepository.DoesExist(entity.TimePeriod.TimePeriodUid))
        //        {
        //            entity.TimePeriod.InsertDate = DateTimeOffset.Now;
        //            entity.TimePeriod.InsertName = sessionData.UserName;
        //            _timePeriodRepository.Add(entity.TimePeriod, sessionData);
        //        }
        //        else
        //            _timePeriodRepository.Update(entity.TimePeriod, sessionData);

        //    }
        //}


        protected override int DeleteEntity(TimeScheduleDayTypeGalaxyTimePeriod entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.TimeScheduleDayTypeGalaxyTimePeriodUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, TimeScheduleDayTypeGalaxyTimePeriodPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();
                mgr.DataObject.SelectFilter = TimeScheduleDayTypeGalaxyTimePeriodPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();
                mgr.DataObject.SelectFilter = TimeScheduleDayTypeGalaxyTimePeriodPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetAllForTimeSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();
                mgr.DataObject.SelectFilter = TimeScheduleDayTypeGalaxyTimePeriodPDSAData.SelectFilters.ByTimeScheduleUid;
                mgr.Entity.TimeScheduleUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::GetAllForTimeSchedule", ex);
                throw;
            }
        }

        public IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetAllForGalaxyTimePeriod(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();
                mgr.DataObject.SelectFilter = TimeScheduleDayTypeGalaxyTimePeriodPDSAData.SelectFilters.ByGalaxyTimePeriodUid;
                mgr.Entity.GalaxyTimePeriodUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::GetAllForGalaxyTimePeriod", ex);
                throw;
            }
        }

        public IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetAllForDayType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();
                mgr.DataObject.SelectFilter = TimeScheduleDayTypeGalaxyTimePeriodPDSAData.SelectFilters.ByDayTypeUid;
                mgr.Entity.DayTypeUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::GetAllForDayType", ex);
                throw;
            }
        }
        public IEnumerable<TimeScheduleDayTypeGalaxyTimePeriod> GetAllForTimeScheduleAndDayType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters, Guid timeScheduleUid, Guid dayTypeUid)
        {
            try
            {
                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();
                mgr.DataObject.SelectFilter = TimeScheduleDayTypeGalaxyTimePeriodPDSAData.SelectFilters.ByTimeScheduleUidAndDayTypeUid;
                mgr.Entity.TimeScheduleUid = timeScheduleUid;
                mgr.Entity.DayTypeUid = dayTypeUid;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::GetAllForDayType", ex);
                throw;
            }
        }

        protected override TimeScheduleDayTypeGalaxyTimePeriod GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override TimeScheduleDayTypeGalaxyTimePeriod GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new TimeScheduleDayTypeGalaxyTimePeriodPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    TimeScheduleDayTypeGalaxyTimePeriod result = new TimeScheduleDayTypeGalaxyTimePeriod();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, TimeScheduleDayTypeGalaxyTimePeriod originalEntity, TimeScheduleDayTypeGalaxyTimePeriod newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "TimeScheduleDayTypeGalaxyTimePeriodUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.TimeScheduleDayTypeGalaxyTimePeriodUid;
                        mgr.Entity.RecordTag = newEntity.TimeScheduleDayTypeGalaxyTimePeriodUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "TimeScheduleDayTypeGalaxyTimePeriodUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.TimeScheduleDayTypeGalaxyTimePeriodUid;
                        mgr.Entity.RecordTag = newEntity.TimeScheduleDayTypeGalaxyTimePeriodUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "TimeScheduleDayTypeGalaxyTimePeriodUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.TimeScheduleDayTypeGalaxyTimePeriodUid;
                        mgr.Entity.RecordTag = originalEntity.TimeScheduleDayTypeGalaxyTimePeriodUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleDayTypeGalaxyTimePeriodRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(TimeScheduleDayTypeGalaxyTimePeriod entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var _dayTypeRepository = _dataRepositoryFactory.GetDataRepository<IDayTypeRepository>();
            var _galaxyTimePeriodRepository = _dataRepositoryFactory.GetDataRepository<IGalaxyTimePeriodRepository>();

            entity.DayType = _dayTypeRepository.Get(entity.DayTypeUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false });
            entity.GalaxyTimePeriod = _galaxyTimePeriodRepository.Get(entity.GalaxyTimePeriodUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false });
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("TimeScheduleDayTypeGalaxyTimePeriod", "TimeScheduleDayTypeGalaxyTimePeriodUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("TimeScheduleDayTypeGalaxyTimePeriod", "TimeScheduleDayTypeGalaxyTimePeriodUid", id);
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

        protected override bool IsEntityUnique(TimeScheduleDayTypeGalaxyTimePeriod entity)
        {
            var mgr = new IsTimeScheduleDayTypeGalaxyTimePeriodUniquePDSAManager();
            mgr.Entity.TimeScheduleDayTypeGalaxyTimePeriodUid = entity.TimeScheduleDayTypeGalaxyTimePeriodUid;
            mgr.Entity.TimeScheduleUid = entity.TimeScheduleUid;
            mgr.Entity.DayTypeUid = entity.DayTypeUid;
            mgr.Entity.GalaxyTimePeriodUid = entity.GalaxyTimePeriodUid;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("TimeScheduleDayTypeGalaxyTimePeriod", "TimeScheduleDayTypeGalaxyTimePeriodUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("TimeScheduleDayTypeGalaxyTimePeriod", "TimeScheduleDayTypeGalaxyTimePeriodUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
