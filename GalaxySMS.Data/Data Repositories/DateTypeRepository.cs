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
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using GCS.Core.Common.Data;

namespace GalaxySMS.Data
{
    [Export(typeof(IDateTypeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DateTypeRepository : PagedDataRepositoryBase<DateType>, IDateTypeRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IDateTypeEntityMapRepository _entityMapRepository;

        protected override DateType AddEntity(DateType entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new DateTypePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.DateTypeUid, entity);
                    var result = GetEntityByGuidId(entity.DateTypeUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::AddEntity", ex);
                throw;
            }
        }

        protected override DateType UpdateEntity(DateType entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.DateTypeUid == GalaxySMS.Common.Constants.DateTypeIds.DateType_Never ||
                //    entity.DateTypeUid == GalaxySMS.Common.Constants.DateTypeIds.DateType_Always)
                //{ 
                //    _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                //    _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);
                //}

                var originalEntity = GetEntityByGuidId(entity.DateTypeUid, sessionData, null);
                var mgr = new DateTypePDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.DateTypeUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);

                    // if DayTypeUid is = Guid.Empty or null, then use the value from the original record
                    entity.DayTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.DayTypeUid, entity.DayTypeUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.DateTypeUid, entity);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.DateTypeUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.DateTypeUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(DateType entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new DateTypePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.DateTypeUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new DateTypePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<DateType> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, DateTypePDSAManager mgr)
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

        // GetAllDateTypes for an Entity
        protected override IEnumerable<DateType> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DateTypePDSAManager();
                if (getParameters.GetDate > DateTimeOffset.MinValue)
                {   // Some range of dates is being specified
                    mgr.DataObject.SelectFilter = DateTypePDSAData.SelectFilters.ByEntityAndDateRange;
                    mgr.DataObject.Entity.StartDate = getParameters.GetDate.Date;
                    mgr.DataObject.Entity.EndDate = getParameters.GetDate2.Date;
                }
                else
                {
                    mgr.DataObject.SelectFilter = DateTypePDSAData.SelectFilters.ByEntityId;
                }

                if (getParameters.UniqueId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.UniqueId;
                else
                    mgr.DataObject.Entity.EntityId = sessionData.CurrentEntityId;
                //mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<DateType> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DateTypePDSAManager();
                mgr.DataObject.SelectFilter = DateTypePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IArrayResponse<DateType> GetAllDateTypesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }

        public IArrayResponse<DateType> GetAllDateTypesForMappedEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DateTypePDSAManager();
                mgr.DataObject.SelectFilter = DateTypePDSAData.SelectFilters.ByEntityId;
                mgr.Entity.EntityId = getParameters.UniqueId;
                //mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetAllDateTypesForMappedEntity", ex);
                throw;
            }
        }

        public IArrayResponse<DateType> GetAllDateTypesForDayType(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DateTypePDSAManager();
                mgr.DataObject.SelectFilter = DateTypePDSAData.SelectFilters.ByDayTypeUid;
                mgr.Entity.DayTypeUid = getParameters.UniqueId;
                //mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetAllDateTypesForDayTypeEntity", ex);
                throw;
            }
        }

        public IEnumerable<DateType_PanelLoadData> GetPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxySMS.Common.Enums.TimeScheduleType scheduleType)
        {
            try
            {
                var results = new List<DateType_PanelLoadData>();
                var mgr = new DateType_PanelLoadData_GetForDateScheduleTypePDSAManager();
                mgr.Entity.DateTypeUid = getParameters.UniqueId;
                mgr.Entity.ScheduleTypeCode = (short)scheduleType;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                        results.Add(mgr.ConvertPDSAEntity(i));
                    return results;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetPanelLoadData", ex);
                throw;
            }
        }

        public IEnumerable<DateType_PanelLoadData> GetPanelLoadDataForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var results = new List<DateType_PanelLoadData>();
                var mgr = new DateType_PanelLoadData_GetForClusterPDSAManager();
                mgr.Entity.ClusterUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                        results.Add(mgr.ConvertPDSAEntity(i));
                    return results;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetPanelLoadDataForCluster", ex);
                throw;
            }
        }

        public DateTypeDefaultBehavior_PanelLoadData GetDefaultBehaviorPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DateTypeDefaultBehavior_GetPanelLoadDataPDSAManager();
                mgr.Entity.EntityId = getParameters.UniqueId;
                var results = mgr.BuildCollection();
                if (results != null)
                {
                    var r = results.FirstOrDefault();
                    if (r != null)
                    {
                        DateTypeDefaultBehavior_PanelLoadData result = mgr.ConvertPDSAEntity(results.FirstOrDefault());
                        return result;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetDefaultBehaviorPanelLoadData", ex);
                throw;
            }
        }

        public DateDayTypeInfo GetDateDayTypeInfo(Guid entityId, DateTimeOffset date)
        {
            try
            {
                var mgr = new DateType_GetDayTypeInfoPDSAManager
                {
                    Entity =
                    {
                        EntityId = entityId,
                        Date = date
                    }
                };
                var result = mgr.BuildCollection();
                if (result != null && result.Count == 1)
                {
                    return new DateDayTypeInfo()
                    {
                        DayTypeUid = result[0].DayTypeUid,
                        Name = result[0].Name
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetClustersThatUseDateType", ex);
                throw;
            }
        }

        public IEnumerable<DateType_GetClustersThatUseDateType> GetClustersThatUseDateType(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var results = new List<DateType_GetClustersThatUseDateType>();
                var mgr = new DateType_GetClustersThatUseDateTypePDSAManager();
                mgr.Entity.DateTypeUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                        results.Add(mgr.ConvertPDSAEntity(i));
                    return results;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetClustersThatUseDateType", ex);
                throw;
            }
        }

        protected override DateType GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        public DateType GetDateTypeForEntityAndDate(Guid entityId, DateTimeOffset date)
        {
            try
            {
                var mgr = new DateTypePDSAManager
                {
                    DataObject =
                    {
                        SelectFilter = DateTypePDSAData.SelectFilters.ByEntityIdAndDate
                    },
                    Entity =
                    {
                        EntityId = entityId,
                        Date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0)
                    }
                };
                var results = mgr.BuildCollection();
                if (results.Any())
                {
                    var pdsaResult = results.FirstOrDefault();
                    if (pdsaResult != null)
                    {
                        DateType result = new DateType();
                        SimpleMapper.PropertyMap(pdsaResult, result);
                        return result;
                    }
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
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //DateTypeRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override DateType GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DateTypePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    DateType result = new DateType();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, DateType originalEntity, DateType newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "DateTypeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.DateTypeUid;
                        mgr.Entity.RecordTag = newEntity.DateTypeUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "DateTypeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.DateTypeUid;
                        mgr.Entity.RecordTag = newEntity.DateTypeUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "DateTypeUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.DateTypeUid;
                        mgr.Entity.RecordTag = originalEntity.DateTypeUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(DateType entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //var entityMaps = _entityMapRepository.GetAllForDateType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.DateTypeUid });
            //var entityIds = (from e in entityMaps select e.EntityId).ToList();
            //entity.EntityIds.AddRange(entityIds);
            //entity.EntityIds.Add(entity.EntityId);

        }

        //private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity)
        //{
        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingEntityMappings = _entityMapRepository.GetAllForDateType(sessionData, getParameters);
        //    var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
        //    var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

        //    foreach (var existingEntityId in existingEntityIds)
        //    {
        //        if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
        //        {
        //            var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
        //            if (deleteThisExistingEntityMap != null)
        //                _entityMapRepository.Remove(deleteThisExistingEntityMap.DateTypeEntityMapUid, sessionData, null);
        //        }
        //    }
        //    foreach (var entityId in entity.EntityIds)
        //    {
        //        if (!existingEntityIds.Contains(entityId))
        //        {
        //            var entityMap = new DateTypeEntityMap();
        //            entityMap.DateTypeEntityMapUid = GuidUtilities.GenerateComb();
        //            entityMap.DateTypeUid = uid;
        //            entityMap.EntityId = entityId;
        //            entityMap.UpdateDate = DateTimeOffset.Now;
        //            entityMap.UpdateName = sessionData.UserName;
        //            entityMap.InsertDate = DateTimeOffset.Now;
        //            entityMap.InsertName = sessionData.UserName;

        //            _entityMapRepository.Add(entityMap, sessionData, null);
        //        }
        //    }
        //}

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("DateType", "DateTypeUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("DateType", "DateTypeUid", id);
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

        protected override bool IsEntityUnique(DateType entity)
        {
            var mgr = new IsDateTypeUniquePDSAManager();
            mgr.Entity.DateTypeUid = entity.DateTypeUid;
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.Date = entity.Date;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("DateType", "DateTypeUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("DateType", "DateTypeUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, DateTypePDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<DateTypeSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }

        private IArrayResponse<DateType> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, DateTypePDSAManager mgr)
        {
            SetSortColumnAndOrder(getParameters, mgr);
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var totalCount = 0;
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (totalCount == 0)
                        totalCount = entity.TotalRowCount;
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                    {
                        FillMemberCollections(entity, null, getParameters);
                    }
                }
                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
            }
            return new ArrayResponse<DateType>();
        }

        protected override IArrayResponse<DateType> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DateTypePDSAManager();
                if (getParameters.GetDate > DateTimeOffset.MinValue)
                {   // Some range of dates is being specified
                    mgr.DataObject.SelectFilter = DateTypePDSAData.SelectFilters.ByEntityAndDateRange;
                    mgr.DataObject.Entity.StartDate = getParameters.GetDate.Date;
                    mgr.DataObject.Entity.EndDate = getParameters.GetDate2.Date;
                }
                else
                {
                    mgr.DataObject.SelectFilter = DateTypePDSAData.SelectFilters.ByEntityId;
                }

                if (getParameters.UniqueId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.UniqueId;
                else
                    mgr.DataObject.Entity.EntityId = sessionData.CurrentEntityId;
                //mgr.Entity.CultureName = sessionData.UiCulture;
                SetSortColumnAndOrder(getParameters, mgr);
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<DateType> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DateTypePDSAManager();
                mgr.DataObject.SelectFilter = DateTypePDSAData.SelectFilters.All;
                SetSortColumnAndOrder(getParameters, mgr);
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DateTypeRepository::GetAllEntities", ex);
                throw;
            }
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForGalaxyDateTypePDSAManager()
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
