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
using GalaxySMS.Common.Constants;
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
    [Export(typeof(IGalaxyTimePeriodRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyTimePeriodRepository : PagedDataRepositoryBase<GalaxyTimePeriod>, IGalaxyTimePeriodRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private IGalaxyTimePeriodEntityMapRepository _entityMapRepository;

        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        [Import]
        private ITimePeriodRepository _timePeriodRepository;

        protected override GalaxyTimePeriod AddEntity(GalaxyTimePeriod entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {

                var mgr = new GalaxyTimePeriodPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.GalaxyTimePeriodUid, entity, saveParams);
                    SaveTimePeriods(sessionData, entity, saveParams);
                    var result = GetEntityByGuidId(entity.GalaxyTimePeriodUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyTimePeriodRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyTimePeriod UpdateEntity(GalaxyTimePeriod entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.GalaxyTimePeriodUid, sessionData, null);
                var mgr = new GalaxyTimePeriodPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.GalaxyTimePeriodUid) > 0 ) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);
                    if( entity.PanelTimePeriodNumber == 0)
                        entity.PanelTimePeriodNumber = mgr.Entity.PanelTimePeriodNumber;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.GalaxyTimePeriodUid, entity, saveParams);
                        SaveTimePeriods(sessionData, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.GalaxyTimePeriodUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);

                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);

                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.GalaxyTimePeriodUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyTimePeriodRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void SaveTimePeriods(IApplicationUserSessionDataHeader sessionData, GalaxyTimePeriod entity, ISaveParameters saveParams)
        {
            if( saveParams.Ignore(nameof(entity.TimePeriods)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = entity.GalaxyTimePeriodUid, IncludeMemberCollections = false };

            // Get all existing records from the database for the schedule being saved
            var existingGalaxyTimePeriodPeriodsFromDatabase = _timePeriodRepository.GetAllTimePeriodsForGalaxyTimePeriod(sessionData, getParameters).ToList();

            var saveTheseTimePeriods = new List<TimePeriod>();
            var deleteTheseTimePeriods = new List<TimePeriod>();
            foreach (var tp in entity.TimePeriods)
            {
                if (tp.EndTime.Days > 0)
                    tp.EndTime = tp.EndTime.Subtract(new TimeSpan(0, 0, 0, 0, 1));

                var existingTp = existingGalaxyTimePeriodPeriodsFromDatabase.FirstOrDefault(x => x.StartTime == tp.StartTime && x.EndTime == tp.EndTime);
                if (existingTp == null)
                    saveTheseTimePeriods.Add(tp);
                else if( existingTp.Name != tp.Name)
                    saveTheseTimePeriods.Add(tp);
            }

            foreach (var tp in existingGalaxyTimePeriodPeriodsFromDatabase)
            {
                var currentTp = entity.TimePeriods.FirstOrDefault(x => x.StartTime == tp.StartTime && x.EndTime == tp.EndTime);
                if (currentTp == null)
                    deleteTheseTimePeriods.Add(tp);
                else
                {
                    currentTp.TimePeriodUid = tp.TimePeriodUid;
                }
            }

            foreach (var tp in saveTheseTimePeriods)
            {
                TimePeriod updatedTimePeriod = null;
                if (tp.TimePeriodUid == Guid.Empty)
                {
                    tp.TimePeriodUid = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                }
                tp.GalaxyTimePeriodUid = entity.GalaxyTimePeriodUid;
                UpdateTableEntityBaseProperties(tp, sessionData);
                if (_timePeriodRepository.DoesExist(tp.TimePeriodUid) == false)
                {
                    tp.EntityId = entity.EntityId;
                    updatedTimePeriod = _timePeriodRepository.Add(tp, sessionData, saveParams);
                }
                else
                {
                    updatedTimePeriod = _timePeriodRepository.Update(tp, sessionData, saveParams);
                }
            }

            foreach (var tp in deleteTheseTimePeriods)
            {
                _timePeriodRepository.Remove(tp.TimePeriodUid, sessionData);
            }
        }

        protected override int DeleteEntity(GalaxyTimePeriod entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyTimePeriodPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyTimePeriodUid);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyTimePeriodRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyTimePeriodPDSAManager();

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
                        UpdateEntityCount(originalEntity.EntityId);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyTimePeriodRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyTimePeriod> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyTimePeriodPDSAManager mgr)
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

        private IArrayResponse<GalaxyTimePeriod> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyTimePeriodPDSAManager mgr)
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
                        FillMemberCollections(entity, sessionData, getParameters);
                }

                var includeBlankSchedule = getParameters.GetOption(GetOptions_TimeSchedule.IncludeBlankSchedule);
                if (includeBlankSchedule.HasValue && includeBlankSchedule.Value)
                {
                    var entitiesList = entities.ToList();
                    entitiesList.Insert(0, new GalaxyTimePeriod() { });
                    entities = entitiesList;
                }
                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
            }
            return new ArrayResponse<GalaxyTimePeriod>();
        }

        // GetAllGalaxyTimePeriods for an Entity
        protected override IEnumerable<GalaxyTimePeriod> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyTimePeriodPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyTimePeriodPDSAData.SelectFilters.ByEntityId;
                if (getParameters != null && getParameters.UniqueId == EntityIds.GalaxySMS_SystemEntity_Id)
                    mgr.DataObject.Entity.EntityId = getParameters.UniqueId;
                else if(getParameters != null && getParameters.UniqueId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.UniqueId;
                else
                    mgr.DataObject.Entity.EntityId = sessionData.CurrentEntityId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyTimePeriodRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<GalaxyTimePeriod> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyTimePeriodPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyTimePeriodPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyTimePeriodRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IArrayResponse<GalaxyTimePeriod> GetAllGalaxyTimePeriodsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }


        public int GetAvailablePanelTimePeriodNumber(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new ChooseAvailableGalaxyTimePeriodNumberPDSAManager();
                if (parameters.UniqueId != Guid.Empty)
                    mgr.Entity.EntityId = parameters.UniqueId;
                else
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                var pdsaEntities = mgr.BuildCollection();
                if( pdsaEntities.Count == 1)
                    return pdsaEntities[0].PanelTimePeriodNumber;
                return 0;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyTimePeriodRepository::GetAllEntities", ex);
                throw;
            }
        }

        public GalaxyTimePeriod_PanelLoadData GetGalaxyTimePeriodPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<GalaxyTimePeriod_PanelLoadData> parameters)
        {
            try
            {
                var mgr = new GalaxyTimePeriod_GetPanelLoadDataPDSAManager();
                mgr.Entity.GalaxyTimePeriodUid = parameters.Data.GalaxyTimePeriodUid;
                mgr.Entity.ClusterUid = parameters.Data.ClusterUid;
                var loadData = new List<GalaxyTimePeriod_GetPanelLoadData>();
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<GalaxyTimePeriod_GetPanelLoadData>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new GalaxyTimePeriod_GetPanelLoadData();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        loadData.Add(newEntity);

                    }
                    parameters.Data.PanelLoadData = loadData.ToList();
                    return parameters.Data;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyTimePeriodRepository::GetGalaxyTimePeriodPanelLoadData", ex);
                throw;
            }
        }

        protected override GalaxyTimePeriod GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyTimePeriod GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyTimePeriodPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyTimePeriod result = new GalaxyTimePeriod();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyTimePeriodRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyTimePeriod originalEntity, GalaxyTimePeriod newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyTimePeriodUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyTimePeriodUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyTimePeriodUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyTimePeriodUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyTimePeriodUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyTimePeriodUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyTimePeriodUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyTimePeriodUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyTimePeriodUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyTimePeriodRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyTimePeriod entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var entityMaps = _entityMapRepository.GetAllForGalaxyTimePeriod(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyTimePeriodUid });
            var entityIds = (from e in entityMaps select e.EntityId).ToList();
            entity.EntityIds.AddRange(entityIds);
            //foreach ( var e in entityMaps)
            //{
            //    if(e.EntityId != entity.EntityId)
            //        entity.EntityIds.Add(e.EntityId);
            //}
            entity.EntityIds.Add(entity.EntityId);

            entity.TimePeriods = _timePeriodRepository.GetAllTimePeriodsForGalaxyTimePeriod(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyTimePeriodUid }).ToCollection();
        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            if( saveParams.Ignore(nameof(entity.EntityIds)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllForGalaxyTimePeriod(sessionData, getParameters);
            var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
            var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

            foreach (var existingEntityId in existingEntityIds)
            {
                if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
                {
                    var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
                    if (deleteThisExistingEntityMap != null)
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.GalaxyTimePeriodEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new GalaxyTimePeriodEntityMap();
                    entityMap.GalaxyTimePeriodEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.GalaxyTimePeriodUid = uid;
                    entityMap.EntityId = entityId;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }
        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyTimePeriod", "GalaxyTimePeriodUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyTimePeriod", "GalaxyTimePeriodUid", id);
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

        protected override bool IsEntityUnique(GalaxyTimePeriod entity)
        {
            var mgr = new IsGalaxyTimePeriodUniquePDSAManager();
            mgr.Entity.GalaxyTimePeriodUid = entity.GalaxyTimePeriodUid;
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.Display = entity.Display;
            mgr.Entity.PanelTimePeriodNumber = entity.PanelTimePeriodNumber;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyTimePeriod", "GalaxyTimePeriodUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyTimePeriod", "GalaxyTimePeriodUid", id);
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
                var mgr = new gcsEntityCountPDSA_InsertTimePeriodCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, GalaxyTimePeriodPDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<GalaxyTimePeriodSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }
        protected override IArrayResponse<GalaxyTimePeriod> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyTimePeriodPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyTimePeriodPDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.UniqueId;
                else
                    mgr.DataObject.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<GalaxyTimePeriod> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyTimePeriodPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyTimePeriodPDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllEntities", ex);
                throw;
            }
        }
        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForGalaxyTimePeriodPDSAManager()
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
