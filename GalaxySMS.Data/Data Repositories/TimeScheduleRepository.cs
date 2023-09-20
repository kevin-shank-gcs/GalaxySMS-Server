using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Data;
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
using System.Linq;
using System.Security.Cryptography;
using TimeScheduleClusterItem = GalaxySMS.Business.Entities.TimeScheduleClusterItem;
using TimeScheduleType = GalaxySMS.Common.Enums.TimeScheduleType;

namespace GalaxySMS.Data
{
    [Export(typeof(ITimeScheduleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TimeScheduleRepository : PagedDataRepositoryBase<TimeSchedule>, ITimeScheduleRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private ITimeScheduleEntityMapRepository _entityMapRepository;

        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;


        protected override TimeSchedule AddEntity(TimeSchedule entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.TimeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never ||
                    entity.TimeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                {
                    _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                    _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);
                }

                var mgr = new TimeSchedulePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.TimeScheduleUid, entity, saveParams);
                    if (entity.TimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always &&
                        entity.TimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never)
                        SaveDayTypeTimePeriods(sessionData, entity, saveParams);
                    var result = GetEntityByGuidId(entity.TimeScheduleUid, sessionData, new GetParametersWithPhoto(saveParams));
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        UpdateEntityCount(result.EntityId);
                        DisableAutoMapTimeSchedulesIfNeeded(result.EntityId);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::AddEntity", ex);
                throw;
            }
        }

        protected override TimeSchedule UpdateEntity(TimeSchedule entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.TimeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never ||
                    entity.TimeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                {
                    _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                    _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);
                }

                var originalEntity = GetEntityByGuidId(entity.TimeScheduleUid, sessionData, new GetParametersWithPhoto());
                var mgr = new TimeSchedulePDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.TimeScheduleUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;
                    if (!entity.DisplayResourceKey.HasValue || entity.DisplayResourceKey.Value == Guid.Empty)
                        entity.DisplayResourceKey = mgr.Entity.DisplayResourceKey;

                    if (!entity.DescriptionResourceKey.HasValue || entity.DescriptionResourceKey.Value == Guid.Empty)
                        entity.DescriptionResourceKey = mgr.Entity.DescriptionResourceKey;

                    //if( string.IsNullOrEmpty(entity.ResourceClassName))
                    //    entity.ResourceClassName = mgr.Entity.ResourceClassName;

                    //if( string.IsNullOrEmpty(entity.DisplayResourceName))
                    //    entity.DisplayResourceName = mgr.Entity.DisplayResourceName;

                    //if( string.IsNullOrEmpty(entity.DescriptionResourceName))
                    //    entity.DescriptionResourceName = mgr.Entity.DescriptionResourceName;

                    //if( string.IsNullOrEmpty(entity.UniqueResourceName))
                    //    entity.UniqueResourceName = mgr.Entity.UniqueResourceName;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.TimeScheduleUid, entity, saveParams);
                        if (entity.TimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always &&
                            entity.TimeScheduleUid != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never)
                            SaveDayTypeTimePeriods(sessionData, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.TimeScheduleUid, sessionData, new GetParametersWithPhoto(saveParams));
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);

                        return updatedEntity;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(TimeSchedule entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new TimeSchedulePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.TimeScheduleUid);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new TimeSchedulePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<TimeSchedule> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, TimeSchedulePDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        private IArrayResponse<TimeSchedule> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, TimeSchedulePDSAManager mgr)
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
                    entitiesList.Insert(0, new TimeSchedule() { });
                    entities = entitiesList;
                }
                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
            }
            return new ArrayResponse<TimeSchedule>();
        }


        // GetAllTimeSchedules for an Entity
        protected override IEnumerable<TimeSchedule> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new TimeSchedulePDSAManager();
                mgr.DataObject.SelectFilter = TimeSchedulePDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.UniqueId;
                else
                    mgr.DataObject.Entity.EntityId = sessionData.CurrentEntityId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerable(sessionData, getParameters, mgr);
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

        protected override IEnumerable<TimeSchedule> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new TimeSchedulePDSAManager();
                mgr.DataObject.SelectFilter = TimeSchedulePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
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

        public IArrayResponse<TimeSchedule> GetAllTimeSchedulesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }

        public IArrayResponse<TimeSchedule> GetAllTimeSchedulesForMappedEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new TimeSchedulePDSAManager();
                mgr.DataObject.SelectFilter = TimeSchedulePDSAData.SelectFilters.ByMappedEntityId;
                mgr.Entity.EntityId = getParameters.UniqueId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllTimeSchedulesForRegion", ex);
                throw;
            }
        }

        public IArrayResponse<TimeSchedule> GetAllTimeSchedulesForGalaxyCluster(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new TimeSchedulePDSAManager();
                mgr.DataObject.SelectFilter = TimeSchedulePDSAData.SelectFilters.ByGalaxyClusterUid;
                mgr.Entity.GalaxyClusterUid = getParameters.UniqueId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllTimeSchedulesForRegion", ex);
                throw;
            }
        }

        public IArrayResponse<TimeScheduleClusterItem> GetTimeScheduleClusterItems(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new TimeSchedulePDSAManager();
                mgr.DataObject.SelectFilter = TimeSchedulePDSAData.SelectFilters.ScheduleInfoForGalaxyClusterUid;
                mgr.Entity.GalaxyClusterUid = parameters.UniqueId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                var items = GetIEnumerablePaged(sessionData, parameters, mgr);
                var returnData = new ArrayResponse<TimeScheduleClusterItem>()
                {
                    TotalItemCount = items.TotalItemCount,
                    TotalPageCount = items.TotalPageCount,
                    PageItemCount = items.PageItemCount,
                    PageNumber = items.PageNumber,
                    PageSize = items.PageSize
                };
                var dataItems = new List<TimeScheduleClusterItem>();

                foreach (var i in items.Items)
                {
                    dataItems.Add(i.ToTimeScheduleClusterItem());
                }

                returnData.Items = dataItems.ToArray();
                return returnData;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllTimeSchedulesForRegion", ex);
                throw;
            }

        }

        public IArrayResponse<TimeSchedule> GetAllTimeSchedulesForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterUid_GetByAccessPortalUidPDSAManager();
                mgr.Entity.accessPortalUid = getParameters.UniqueId;
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(getParameters as GetParametersWithPhoto);
                    newParams.UniqueId = data[0].ClusterUid;
                    return GetAllTimeSchedulesForGalaxyCluster(sessionData, newParams);
                }
                return new ArrayResponse<TimeSchedule>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllTimeSchedulesForAccessPortal", ex);
                throw;
            }
        }

        public IArrayResponse<TimeSchedule> GetAllTimeSchedulesForInputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterUid_GetByInputDeviceUidPDSAManager();
                mgr.Entity.inputDeviceUid = getParameters.UniqueId;
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(getParameters as GetParametersWithPhoto);
                    newParams.UniqueId = data[0].ClusterUid;
                    return GetAllTimeSchedulesForGalaxyCluster(sessionData, newParams);
                }
                return new ArrayResponse<TimeSchedule>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllTimeSchedulesForAccessPortal", ex);
                throw;
            }
        }

        public IArrayResponse<TimeSchedule> GetAllTimeSchedulesForOutputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterUid_GetByOutputDeviceUidPDSAManager
                {
                    Entity = { outputDeviceUid = getParameters.UniqueId }
                };
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(getParameters as GetParametersWithPhoto);
                    newParams.UniqueId = data[0].ClusterUid;
                    return GetAllTimeSchedulesForGalaxyCluster(sessionData, newParams);
                }
                return new ArrayResponse<TimeSchedule>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllTimeSchedulesForAccessPortal", ex);
                throw;
            }
        }

        public TimeSchedule_PanelLoadData GetTimeSchedulePanelLoadData(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto<TimeSchedule_PanelLoadData> parameters)
        {
            try
            {
                var mgr = new TimeSchedule15MinuteFormat_GetPanelLoadDataPDSAManager();
                mgr.Entity.TimeScheduleUid = parameters.Data.TimeScheduleUid;
                mgr.Entity.ClusterUid = parameters.Data.ClusterUid;
                var fifteenMinuteLoadData = new List<TimeSchedule15MinuteFormat_GetPanelLoadData>();
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<TimeSchedule15MinuteFormat_GetPanelLoadData>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new TimeSchedule15MinuteFormat_GetPanelLoadData();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        fifteenMinuteLoadData.Add(newEntity);

                    }
                    parameters.Data.TimeSchedule15MinuteFormatGetPanelLoadData = fifteenMinuteLoadData.ToList();
                }


                var mgr1 = new TimeScheduleOneMinuteFormat_GetPanelLoadDataPDSAManager();
                mgr1.Entity.TimeScheduleUid = parameters.Data.TimeScheduleUid;
                mgr1.Entity.ClusterUid = parameters.Data.ClusterUid;
                var oneMinuteLoadData = new List<TimeScheduleOneMinuteFormat_GetPanelLoadData>();
                var pdsaEntities1 = mgr1.BuildCollection();
                if (pdsaEntities1 != null)
                {
                    var entities = new List<TimeScheduleOneMinuteFormat_GetPanelLoadData>();
                    foreach (var entity in pdsaEntities1)
                    {
                        var newEntity = new TimeScheduleOneMinuteFormat_GetPanelLoadData();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        oneMinuteLoadData.Add(newEntity);
                    }
                    parameters.Data.TimeScheduleOneMinuteFormatGetPanelLoadData = oneMinuteLoadData.ToList();
                }
                return parameters.Data;
                return null;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetTimeSchedulePanelLoadData", ex);
                throw;
            }
        }

        public IEnumerable<TimeScheduleSelectionItemBasic> GetAllTimeScheduleSelectionItemsForEntityAndCluster(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new TimeSchedule_SelectionListForEntityAndClusterPDSAManager();
                mgr.Entity.EntityId = parameters.CurrentEntityId;
                mgr.Entity.GalaxyClusterUid = parameters.ClusterUid;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<TimeScheduleSelectionItemBasic>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new TimeScheduleSelectionItemBasic();
                        SimpleMapper.PropertyMap(entity, newEntity);

                        entities.Add(newEntity);
                    }
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllAccessGroupSelectionItemsForEntityAndCluster", ex);
                throw;
            }
        }


        public IArrayResponse<TimeSchedule> GetAllTimeSchedulesForAssaAbloyDsr(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new TimeSchedulePDSAManager();
                mgr.DataObject.SelectFilter = TimeSchedulePDSAData.SelectFilters.ByAssaDsrUid;
                mgr.Entity.AssaDsrUid = parameters.GetString;
                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerablePaged(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetAllTimeSchedulesForRegion", ex);
                throw;
            }
        }

        public bool IsTimeScheduleActive(Guid timeScheduleUid, TimeScheduleType scheduleTypeCode, Guid clusterId,
            DateTimeOffset dateTime)
        {
            var mgr = new TimeSchedule_IsScheduleActivePDSAManager
            {
                Entity =
                {
                    TimeScheduleUid = timeScheduleUid,
                    ScheduleTypeCode = (short) scheduleTypeCode,
                    ClusterUid = clusterId,
                    dt = dateTime
                }
            };

            mgr.BuildCollection();
            return mgr.Entity.result;
        }

        protected override TimeSchedule GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override TimeSchedule GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new TimeSchedulePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    TimeSchedule result = new TimeSchedule();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(result, sessionData, getParameters);
                    return result;
                }
                else if (guid == Guid.Empty)
                    return CreateNew(sessionData, getParameters);

                return null;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        private TimeSchedule CreateNew(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            var newItem = new TimeSchedule()
            {
                EntityId = sessionData.CurrentEntityId,
            };
            if (parameters.IncludeMemberCollections)
                FillMemberCollections(newItem, sessionData, parameters);
            return newItem;
        }
        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, TimeSchedule originalEntity, TimeSchedule newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "TimeScheduleUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.TimeScheduleUid;
                        mgr.Entity.RecordTag = newEntity.TimeScheduleUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "TimeScheduleUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.TimeScheduleUid;
                        mgr.Entity.RecordTag = newEntity.TimeScheduleUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "TimeScheduleUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.TimeScheduleUid;
                        mgr.Entity.RecordTag = originalEntity.TimeScheduleUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//TimeScheduleRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(TimeSchedule entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters == null)
                return;

            if (!getParameters.IsExcluded(nameof(entity.EntityIds)))
            {
                var entityMaps = _entityMapRepository.GetAllForTimeSchedule(sessionData, new GetParametersWithPhoto() { UniqueId = entity.TimeScheduleUid });
                var entityIds = (from e in entityMaps select e.EntityId).ToList();
                entity.EntityIds.AddRange(entityIds);
                entity.EntityIds.Add(entity.EntityId);
            }

            if (!getParameters.IsExcluded(nameof(entity.TimeScheduleDayTypesTimePeriods)))
            {
                // Fifteen minute type mappings
                var _timescheduleDayTypeTimePeriodRepository = _dataRepositoryFactory.GetDataRepository<ITimeScheduleDayTypeTimePeriodRepository>();
                entity.TimeScheduleDayTypesTimePeriods = _timescheduleDayTypeTimePeriodRepository.GetAllForTimeSchedule(sessionData, new GetParametersWithPhoto()
                {
                    UniqueId = entity.TimeScheduleUid,
                    IncludeMemberCollections = true
                }).ToCollection();
            }

            if (!getParameters.IsExcluded(nameof(entity.TimeScheduleDayTypesGalaxyTimePeriods)))
            {
                // Minute based mappings
                var _timescheduleDayTypeGalaxyTimePeriodRepository = _dataRepositoryFactory.GetDataRepository<ITimeScheduleDayTypeGalaxyTimePeriodRepository>();
                entity.TimeScheduleDayTypesGalaxyTimePeriods = _timescheduleDayTypeGalaxyTimePeriodRepository.GetAllForTimeSchedule(sessionData, new GetParametersWithPhoto()
                {
                    UniqueId = entity.TimeScheduleUid,
                    IncludeMemberCollections = true
                }).ToCollection();
            }

            if (!getParameters.IsExcluded(nameof(entity.DayTypesTimePeriods)))
            {
                var _dayTypeRepository = _dataRepositoryFactory.GetDataRepository<IDayTypeRepository>();
                var dayTypes = _dayTypeRepository.GetAllDayTypesForEntity(sessionData, new GetParametersWithPhoto() { UniqueId = entity.EntityId });
                foreach (var dt in dayTypes.Items)
                {
                    var dayTypeTimePeriods = new DayTypeTimePeriods(dt);
                    dt.DayTypeFifteenMinuteTimePeriods = entity.TimeScheduleDayTypesTimePeriods.Where(i => i.DayTypeUid == dt.DayTypeUid).ToList();
                    foreach (var tp in dt.DayTypeFifteenMinuteTimePeriods)
                    {
                        dayTypeTimePeriods.FifteenMinuteTimePeriods.Add(tp.TimePeriod);
                    }

                    var timeScheduleDayTypesGalaxyTimePeriod = entity.TimeScheduleDayTypesGalaxyTimePeriods.FirstOrDefault(i => i.DayTypeUid == dt.DayTypeUid);
                    if (timeScheduleDayTypesGalaxyTimePeriod != null)
                        dayTypeTimePeriods.GalaxyTimePeriodUid = timeScheduleDayTypesGalaxyTimePeriod.GalaxyTimePeriodUid;
                    else
                    {
                        dayTypeTimePeriods.GalaxyTimePeriodUid = GalaxyTimePeriodIds.TimePeriod_Never;
                    }

                    entity.DayTypesTimePeriods.Add(dayTypeTimePeriods);
                }
            }

            if (!getParameters.IsExcluded(nameof(entity.Clusters)))
            {
                var clusterRepo = _dataRepositoryFactory.GetDataRepository<IClusterRepository>();
                var clusterInfo = clusterRepo.GetClusterTimeScheduleItemsBySchedule(sessionData, new GetParametersWithPhoto() { UniqueId = entity.TimeScheduleUid });
                if (clusterInfo != null)
                    entity.Clusters = clusterInfo.Items.ToCollection();
            }

        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllForTimeSchedule(sessionData, getParameters);
            var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
            var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

            foreach (var existingEntityId in existingEntityIds)
            {
                if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
                {
                    var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
                    if (deleteThisExistingEntityMap != null)
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.TimeScheduleEntityMapUid, sessionData);
                }
            }

            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new TimeScheduleEntityMap
                    {
                        TimeScheduleEntityMapUid = GuidUtilities.GenerateComb(),
                        TimeScheduleUid = uid,
                        EntityId = entityId
                    };
                    UpdateTableEntityBaseProperties(entityMap, sessionData);

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        // The entity.DayTypeTimePeriods collection contains the data to be saved.
        private void SaveDayTypeTimePeriods(IApplicationUserSessionDataHeader sessionData, TimeSchedule entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = entity.TimeScheduleUid };//, IncludeMemberCollections = true };

            // get the repositories needed 
            var _timescheduleDayTypeTimePeriodRepository = _dataRepositoryFactory.GetDataRepository<ITimeScheduleDayTypeTimePeriodRepository>();
            var _timescheduleDayTypeGalaxyTimePeriodRepository = _dataRepositoryFactory.GetDataRepository<ITimeScheduleDayTypeGalaxyTimePeriodRepository>();
            var _timePeriodRepository = _dataRepositoryFactory.GetDataRepository<ITimePeriodRepository>();
            var _dayTypeRepository = _dataRepositoryFactory.GetDataRepository<IDayTypeRepository>();

            // Get all existing records from the database for the schedule being saved
            var existingTimeScheduleDayTypeTimePeriodsFromDatabase = _timescheduleDayTypeTimePeriodRepository.GetAllForTimeSchedule(sessionData, getParameters).ToList();
            var existingTimeScheduleDayTypeGalaxyTimePeriodsFromDatabase = _timescheduleDayTypeGalaxyTimePeriodRepository.GetAllForTimeSchedule(sessionData, getParameters).ToList();
            var existingDayTypesFromDatabase = _dayTypeRepository.GetAllDayTypesForEntity(sessionData, new GetParametersWithPhoto() { });

            foreach (var dttp in entity.DayTypesTimePeriods.Where(o => o.DayTypeCode == DayTypeCode.DayType0 && o.DayTypeUid != Guid.Empty))
            {
                var dt = existingDayTypesFromDatabase.Items.FirstOrDefault(o => o.DayTypeUid == dttp.DayTypeUid);
                if (dt != null)
                {
                    dttp.DayTypeCode = dt.DayTypeCode;
                }
            }

            var tempDayTypeTimePeriods = entity.DayTypesTimePeriods.ToList();
            // Verify that all day types are properly represented in the entity.DayTypesTimePeriods collection
            foreach (var dtc in (DayTypeCode[])Enum.GetValues(typeof(DayTypeCode)))
            {
                
   //             var dttp = tempDayTypeTimePeriods.FirstOrDefault(o => o.DayTypeCode == dtc);
                var dttp = tempDayTypeTimePeriods.FirstOrDefault(o => o.DayTypeCode == dtc);
                if (dttp == null)
                {
                    dttp = new DayTypeTimePeriods()
                    {
                        DayTypeCode = dtc,
                        GalaxyTimePeriodUid = GalaxyTimePeriodIds.TimePeriod_Never,
                    };
                    tempDayTypeTimePeriods.Add(dttp);
                }

                if (dttp.DayTypeUid == Guid.Empty)
                {
                    var dt = existingDayTypesFromDatabase.Items.FirstOrDefault(o => o.DayTypeCode == dttp.DayTypeCode);
                    if (dt != null)
                        dttp.DayTypeUid = dt.DayTypeUid;
                }
            }
            entity.DayTypesTimePeriods = tempDayTypeTimePeriods.ToCollection();

            // Spin through all DayTypesTimePeriods for the schedule and insert, update or delete TimePeriod and TimeScheduleDayTypeTimePeriod records
            foreach (var dt in entity.DayTypesTimePeriods)
            {
                // Do the fifteen minute data first
                // Get all the TimeScheduleDayTypeTimePeriod records from the database for this current DayType
                var existingTimeScheduleDayTypeTimePeriodsForDayType = existingTimeScheduleDayTypeTimePeriodsFromDatabase.Where(i => i.DayTypeUid == dt.DayTypeUid).ToList();
                var TimeScheduleDayTypeTimePeriodUidsToKeep = new List<Guid>();
                TimeScheduleDayTypeTimePeriod timeScheduleDayTypeTimePeriodToSave = null;

                foreach (var tp in dt.FifteenMinuteTimePeriods)
                {
                    TimePeriod updatedTimePeriod = null;
                    if (tp.TimePeriodUid == Guid.Empty)
                    {
                        tp.TimePeriodUid = GuidUtilities.GenerateComb(); //Guid.NewGuid();
                    }
                    bool isTPDirty = tp.IsDirty;

                    if (tp.EndTime.Days > 0)
                        tp.EndTime = tp.EndTime.Subtract(new TimeSpan(0, 0, 0, 0, 1));
                    UpdateTableEntityBaseProperties(tp, sessionData);

                    if (_timePeriodRepository.DoesExist(tp.TimePeriodUid) == false)
                    {
                        tp.EntityId = entity.EntityId;
                        updatedTimePeriod = _timePeriodRepository.Add(tp, sessionData, saveParams);
                    }
                    else
                    {
                        if (isTPDirty)
                        {
                            updatedTimePeriod = _timePeriodRepository.Get(tp.TimePeriodUid, sessionData, new GetParametersWithPhoto() { UniqueId = tp.TimePeriodUid });
                            updatedTimePeriod.StartTime = tp.StartTime;
                            updatedTimePeriod.EndTime = tp.EndTime;
                            UpdateTableEntityBaseProperties(updatedTimePeriod, sessionData);
                            updatedTimePeriod = _timePeriodRepository.Update(updatedTimePeriod, sessionData, saveParams);
                        }
                        else
                        {
                            updatedTimePeriod = tp;
                        }
                    }

                    if (updatedTimePeriod != null)
                    {
                        TimeScheduleDayTypeTimePeriod updatedTimeScheduleDayTypeTimePeriod = null;
                        timeScheduleDayTypeTimePeriodToSave = existingTimeScheduleDayTypeTimePeriodsForDayType.FirstOrDefault(i => i.DayTypeUid == dt.DayTypeUid && i.TimePeriodUid == updatedTimePeriod.TimePeriodUid);
                        if (timeScheduleDayTypeTimePeriodToSave == null)
                        {
                            timeScheduleDayTypeTimePeriodToSave = new TimeScheduleDayTypeTimePeriod()
                            {
                                TimeScheduleUid = entity.TimeScheduleUid,
                                DayTypeUid = dt.DayTypeUid,
                                TimePeriodUid = updatedTimePeriod.TimePeriodUid,
                            };
                        }
                        if (timeScheduleDayTypeTimePeriodToSave.TimeScheduleDayTypeTimePeriodUid == Guid.Empty)
                            timeScheduleDayTypeTimePeriodToSave.TimeScheduleDayTypeTimePeriodUid = GuidUtilities.GenerateComb();

                        UpdateTableEntityBaseProperties(timeScheduleDayTypeTimePeriodToSave, sessionData);

                        if (_timescheduleDayTypeTimePeriodRepository.DoesExist(timeScheduleDayTypeTimePeriodToSave.TimeScheduleDayTypeTimePeriodUid) == false)
                        {
                            updatedTimeScheduleDayTypeTimePeriod = _timescheduleDayTypeTimePeriodRepository.Add(timeScheduleDayTypeTimePeriodToSave, sessionData, saveParams);
                            TimeScheduleDayTypeTimePeriodUidsToKeep.Add(updatedTimeScheduleDayTypeTimePeriod.TimeScheduleDayTypeTimePeriodUid);
                        }
                        else
                        {
                            //updatedTimeScheduleDayTypeTimePeriod = _timescheduleDayTypeTimePeriodRepository.Update(timeScheduleDayTypeTimePeriodToSave, sessionData);
                            TimeScheduleDayTypeTimePeriodUidsToKeep.Add(timeScheduleDayTypeTimePeriodToSave.TimeScheduleDayTypeTimePeriodUid);
                        }
                    }
                }

                var timeScheduleDayTypeTimePeriodsToDelete = existingTimeScheduleDayTypeTimePeriodsForDayType.Where(i => TimeScheduleDayTypeTimePeriodUidsToKeep.All(i2 => i2 != i.TimeScheduleDayTypeTimePeriodUid));

                foreach (var i in timeScheduleDayTypeTimePeriodsToDelete)
                {
                    // now delete all of the ones that are no longer needed
                    // Explicitly delete the time period so that an audit record gets generated
                    _timePeriodRepository.Remove(i.TimePeriodUid, sessionData);
                    // Now delete the TimeScheduleDayTypeTimePeriod record that ties the schedule, day type and time period together
                    _timescheduleDayTypeTimePeriodRepository.Remove(i.TimeScheduleDayTypeTimePeriodUid, sessionData);
                }

                // Now do the minute based data
                var timeScheduleDayTypeGalaxyTimePeriodsForDayType = existingTimeScheduleDayTypeGalaxyTimePeriodsFromDatabase.FirstOrDefault(i => i.DayTypeUid == dt.DayTypeUid);
                TimeScheduleDayTypeGalaxyTimePeriod savedTimeScheduleDayTypeGalaxyTimePeriod = null;
                if (timeScheduleDayTypeGalaxyTimePeriodsForDayType == null)
                {
                    timeScheduleDayTypeGalaxyTimePeriodsForDayType = new TimeScheduleDayTypeGalaxyTimePeriod
                    {
                        TimeScheduleDayTypeGalaxyTimePeriodUid = GuidUtilities.GenerateComb(),
                        DayTypeUid = dt.DayTypeUid,
                        TimeScheduleUid = entity.TimeScheduleUid,
                        GalaxyTimePeriodUid = dt.GalaxyTimePeriodUid,
                        IsPanelDataDirty = true,
                        IsDirty = true,
                    };
                }
                if (dt.GalaxyTimePeriodUid == Guid.Empty)
                    dt.GalaxyTimePeriodUid = GalaxyTimePeriodIds.TimePeriod_Never;

                if (dt.IsDirty || timeScheduleDayTypeGalaxyTimePeriodsForDayType.GalaxyTimePeriodUid != dt.GalaxyTimePeriodUid)
                {
                    timeScheduleDayTypeGalaxyTimePeriodsForDayType.GalaxyTimePeriodUid = dt.GalaxyTimePeriodUid;
                    timeScheduleDayTypeGalaxyTimePeriodsForDayType.IsDirty = true;
                    UpdateTableEntityBaseProperties(timeScheduleDayTypeGalaxyTimePeriodsForDayType, sessionData);
                }
                if (_timescheduleDayTypeGalaxyTimePeriodRepository.DoesExist(timeScheduleDayTypeGalaxyTimePeriodsForDayType.TimeScheduleDayTypeGalaxyTimePeriodUid) == false)
                {
                    UpdateTableEntityBaseProperties(timeScheduleDayTypeGalaxyTimePeriodsForDayType, sessionData);
                    savedTimeScheduleDayTypeGalaxyTimePeriod = _timescheduleDayTypeGalaxyTimePeriodRepository.Add(timeScheduleDayTypeGalaxyTimePeriodsForDayType, sessionData, saveParams);
                }
                else
                {
                    if (timeScheduleDayTypeGalaxyTimePeriodsForDayType.IsDirty)
                        savedTimeScheduleDayTypeGalaxyTimePeriod = _timescheduleDayTypeGalaxyTimePeriodRepository.Update(timeScheduleDayTypeGalaxyTimePeriodsForDayType, sessionData, saveParams);
                }
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("TimeSchedule", "TimeScheduleUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("TimeSchedule", "TimeScheduleUid", id);
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

        protected override bool IsEntityUnique(TimeSchedule entity)
        {
            var mgr = new IsTimeScheduleUniquePDSAManager();
            mgr.Entity.TimeScheduleUid = entity.TimeScheduleUid;
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.Display = entity.Display;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("TimeSchedule", "TimeScheduleUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("TimeSchedule", "TimeScheduleUid", id);
            if (count == 0)
                return true;
            return false;
        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertTimeScheduleCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        public bool GetAutoMapTimeSchedulesForEntity(Guid entityId)
        {
            var mgr = new gcsEntity_GetAutoMapTimeSchedulesPDSAManager();
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            if (results.Count > 0 && results[0].AutoMapTimeSchedules)
                return results[0].AutoMapTimeSchedules;
            return false;
        }

        public bool IsTimeScheduleMappedToCluster(Guid timeScheduleUid, Guid clusterUid)
        {
            var mgr = new IsTimeScheduleMappedToClusterPDSAManager();
            mgr.Entity.timeScheduleUid = timeScheduleUid;
            mgr.Entity.clusterUid = clusterUid;
            var results = mgr.BuildCollection();
            var result = results.FirstOrDefault();
            if (result != null)
                return result.IsMapped != 0;
            return false;
        }

        private bool DisableAutoMapTimeSchedulesIfNeeded(Guid entityId)
        {
            try
            {
                var autoMap = GetAutoMapTimeSchedulesForEntity(entityId);
                if (autoMap)
                {
                    var countMgr = new gcsEntity_GetTimeScheduleCountPDSAManager();
                    countMgr.Entity.EntityId = entityId;
                    var count = countMgr.BuildCollection();
                    if (count.Count > 0 && count[0].TimeScheduleCount >= 254)
                    {
                        var mgr1 = new gcsEntity_SetAutoMapTimeSchedulesPDSAManager();
                        mgr1.Entity.EntityId = entityId;
                        mgr1.Entity.AutoMapTimeSchedules = false;
                        mgr1.Execute();
                        autoMap = false;
                    }
                }

                return autoMap;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        public void OnImportsSatisfied()
        {
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, TimeSchedulePDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<TimeScheduleSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }
        protected override IArrayResponse<TimeSchedule> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new TimeSchedulePDSAManager();
                mgr.DataObject.SelectFilter = TimeSchedulePDSAData.SelectFilters.ByEntityId;
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

        protected override IArrayResponse<TimeSchedule> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new TimeSchedulePDSAManager();
                mgr.DataObject.SelectFilter = TimeSchedulePDSAData.SelectFilters.All;
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
            var mgr = new GetEntityIdForTimeSchedulePDSAManager
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

        public IEnumerable<Guid> GetUidsForCluster(Guid clusterUid)
        {
            var mgr = new GetTimeScheduleUidsForClusterPDSAManager()
            {
                Entity =
                {
                    uid = clusterUid
                }
            };
            var results = mgr.BuildCollection();
            var data = results.Select(o => o.TimeScheduleUid);
            return data;
        }

        public TimeScheduleUsageCounts GetTimeScheduleUsageCounts(Guid timeScheduleUid, Guid clusterUid)
        {
            var mgr = new TimeSchedule_GetTimeScheduleUsageCountsForClusterPDSAManager()
            {
                Entity =
                {
                    timeScheduleUid = timeScheduleUid,
                    clusterUid = clusterUid
                }
            };
            var results = mgr.BuildCollection();
            var data = results.FirstOrDefault();
            var returnData = new TimeScheduleUsageCounts();

            SimpleMapper.PropertyMap(data, returnData);

            return returnData;

        }


        public bool CanTimeScheduleBeDeleted(Guid timeScheduledUid)
        {
            var mgr = new TimeSchedule_CanBeDeletedPDSAManager
            {
                Entity =
                {
                    timeScheduleUid = timeScheduledUid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.Count == 0;

            return false;
        }

        public TimeScheduleUsageData GetTimeScheduleUsageData(Guid timeScheduledUid)
        {
            var data = new TimeScheduleUsageData();

            var mgr = new TimeSchedule_GetTimeScheduleUsageDataForClusterPDSAManager()
            {
                Entity =
                        {
                            timeScheduleUid = timeScheduledUid,
                            clusterUid = Guid.Empty
                        }
            };
            var results = mgr.BuildCollection();
            foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.AccessGroup.ToString() && string.IsNullOrEmpty(o.DeviceName)))
            {
                data.Mappings.AccessGroups.Add(new TimeScheduleUsageItem()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type_x,
                    ClusterUid = i.clusterUid
                });
            }

            foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.AccessGroup.ToString()))
            {
                data.Mappings.AccessGroupAccessPortals.Add(new TimeScheduleUsageItemAccessGroupAccessPortal()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type_x,
                    AccessPortalName = i.DeviceName,
                    AccessPortalUid = i.DeviceUid,
                    ClusterUid = i.clusterUid
                });
            }
            foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.AccessPortal.ToString()))
            {
                data.Mappings.AccessPortals.Add(new TimeScheduleUsageItem()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type_x,
                    ClusterUid = i.clusterUid
                });
            }

            foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.GalaxyPanel.ToString()))
            {
                data.Mappings.GalaxyPanels.Add(new TimeScheduleUsageItem()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type_x,
                    ClusterUid = i.clusterUid
                });
            }

            foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.InputOutputGroup.ToString()))
            {
                data.Mappings.InputOutputGroups.Add(new TimeScheduleUsageItem()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type_x,
                    ClusterUid = i.clusterUid
                });

            }

            foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.InputDevice.ToString()))
            {
                data.Mappings.InputDevices.Add(new TimeScheduleUsageItem()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type_x,
                    ClusterUid = i.clusterUid
                });

            }

            foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.OutputDevice.ToString()))
            {
                data.Mappings.OutputDevices.Add(new TimeScheduleUsageItem()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type_x,
                    ClusterUid = i.clusterUid
                });

            }

            foreach (var i in results.Where(o => o.DataType == TimeScheduleUsageTypeDataType.PersonalAccessGroup.ToString()))
            {
                data.Mappings.People.Add(new TimeScheduleUsageItemPersonalAccessGroup()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type_x,
                    ClusterName = i.DeviceName,
                    ClusterUid = i.DeviceUid
                });
            }

            if (data.IsUsed)
            {
                data.Message =
                    "You should un-map the schedule from children data items before deleting it.";
            }

            return data;
        }

    }
}
