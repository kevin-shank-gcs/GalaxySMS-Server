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
using GCS.Core.Common.Shared.Utils;
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Cryptography;

namespace GalaxySMS.Data
{
    [Export(typeof(IGalaxyPanelRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyPanelRepository : PagedDataRepositoryBase<GalaxyPanel>, IGalaxyPanelRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import]
        private IGalaxyCpuRepository _galaxyCpuRepository;

        [Import]
        private IGalaxyInterfaceBoardRepository _galaxyInterfaceBoardRepository;

        [Import]
        private IGalaxyPanelAlertEventRepository _galaxyPanelAlertEventRepository;

        [Import]
        private IGalaxyPanelCommandRepository _galaxyPanelCommandRepository;

        [Import] private IDataRepositoryFactory _dataRepositoryFactory;

        [Import] private IGcsUserRepository _userRepository;

        protected override GalaxyPanel AddEntity(GalaxyPanel entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                var entityId = Guid.Empty;
                if (entity.ClusterUid != Guid.Empty)
                {
                    var clusterRepo = new ClusterRepository();
                    var cluster = clusterRepo.Get(entity.ClusterUid, sessionData, new GetParametersWithPhoto()
                    {
                        IncludePhoto = false,
                        IncludeMemberCollections = false,
                        IncludeCommands = false,
                        IncludeHardwareAddress = true
                    });
                    if (cluster != null)
                    {
                        entity.ClusterNumber = cluster.ClusterNumber;
                        entity.ClusterGroupId = cluster.ClusterGroupId;
                        entityId = cluster.EntityId;
                    }
                }

                entity.InitializeAlertEventsCollection(TimeScheduleIds.TimeSchedule_Never, TimeScheduleIds.TimeSchedule_Always, Guid.Empty);
                if (entity.GalaxyPanelModelUid == GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_600)
                    entity.GalaxyPanelModelUid = GalaxyPanelTypeIds.GalaxyPanelType_635;

                var mgr = new GalaxyPanelPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.GalaxyPanelUid, entity);
                    var result = GetEntityByGuidId(entity.GalaxyPanelUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        result.Cpus = entity.Cpus.ToCollection();// include the cpus
                        UpdateEntityCount(entityId);
                        result = GetEntityByGuidId(entity.GalaxyPanelUid, sessionData, new GetParametersWithPhoto(saveParams));
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyPanel UpdateEntity(GalaxyPanel entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                var entityId = Guid.Empty;
                if (entity.ClusterUid != Guid.Empty)
                {
                    var clusterRepo = new ClusterRepository();
                    var cluster = clusterRepo.Get(entity.ClusterUid, sessionData, new GetParametersWithPhoto()
                    {
                        IncludePhoto = false,
                        IncludeMemberCollections = false,
                        IncludeCommands = false,
                        IncludeHardwareAddress = true
                    });
                    if (cluster != null)
                    {
                        entity.ClusterNumber = cluster.ClusterNumber;
                        entity.ClusterGroupId = cluster.ClusterGroupId;
                        entityId = cluster.EntityId;
                    }
                }

                var originalEntity = GetEntityByGuidId(entity.GalaxyPanelUid, sessionData, null);
                var mgr = new GalaxyPanelPDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.GalaxyPanelUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;
                    if (!entity.GalaxyPanelModelUid.HasValue || entity.GalaxyPanelModelUid.Value == Guid.Empty)
                        entity.GalaxyPanelModelUid = mgr.Entity.GalaxyPanelModelUid;
                    if (entity.GalaxyPanelModelUid == GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_600)
                        entity.GalaxyPanelModelUid = GalaxyPanelTypeIds.GalaxyPanelType_635;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.GalaxyPanelUid, entity);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations\
                        var updatedEntity = GetEntityByGuidId(entity.GalaxyPanelUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        updatedEntity.Cpus = entity.Cpus.ToCollection();   // include the cpus
                        UpdateEntityCount(entityId);
                        updatedEntity = GetEntityByGuidId(entity.GalaxyPanelUid, sessionData, new GetParametersWithPhoto(saveParams));
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.GalaxyPanelUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(GalaxyPanel entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var entityId = Guid.Empty;
                var clusterRepo = new ClusterRepository();
                var cluster = clusterRepo.Get(entity.ClusterUid, sessionData, new GetParametersWithPhoto()
                {
                    IncludePhoto = false,
                    IncludeMemberCollections = false,
                    IncludeCommands = false,
                    IncludeHardwareAddress = false
                });

                if (cluster != null)
                {
                    entityId = cluster.EntityId;
                }

                var mgr = new GalaxyPanelPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyPanelUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                    UpdateEntityCount(entityId);

                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var entityId = Guid.Empty;
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                int rowsDeleted = 0;
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                if (originalEntity != null)
                {
                    var clusterRepo = new ClusterRepository();
                    var cluster = clusterRepo.Get(originalEntity.ClusterUid, sessionData, new GetParametersWithPhoto()
                    {
                        IncludePhoto = false,
                        IncludeMemberCollections = false,
                        IncludeCommands = false,
                        IncludeHardwareAddress = false
                    });

                    if (cluster != null)
                    {
                        entityId = cluster.EntityId;
                    }

                    var mgr = new GalaxyPanelPDSAManager();

                    // PDSA Audit Tracking setup phase
                    int rowsLoaded = mgr.DataObject.LoadByPK(id); // must read the original record from the database so the PDSA object can detect changes
                    if (rowsLoaded == 1 && originalEntity != null)
                    {
                        rowsDeleted = mgr.DataObject.DeleteByPK(id);
                        if (rowsDeleted > 0)
                        {
                            DataStoreTableName = mgr.DataObject.DBObjectName;
                            SaveAuditData(OperationType.Delete, sessionData, originalEntity, null, mgr.DataObject.AuditRowAsXml);
                            UpdateEntityCount(entityId);
                        }
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyPanel> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyPanelPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (getParameters != null && (getParameters.IncludeMemberCollections || getParameters.IncludeCommands))
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, GalaxyPanelPDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<GalaxyPanelSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }

        private IArrayResponse<GalaxyPanel> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyPanelPDSAManager mgr)
        {
            SetSortColumnAndOrder(getParameters, mgr);

            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var totalCount = 0;
                var first = pdsaEntities.FirstOrDefault();
                if (first != null)
                {
                    totalCount = first.TotalRowCount;
                }

                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (totalCount == 0)
                        totalCount = entity.TotalRowCount;
                    if (getParameters != null && (getParameters.IncludeMemberCollections || getParameters.IncludeCommands))
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
            }
            return new ArrayResponse<GalaxyPanel>();
        }

        // GetAllGalaxyPanels for an Entity
        protected override IEnumerable<GalaxyPanel> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<GalaxyPanel> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IArrayResponse<GalaxyPanel> GetAllGalaxyPanelsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyPanelPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelPDSAData.SelectFilters.ByClusterUid;
                mgr.Entity.ClusterUid = parameters.UniqueId;
                return GetIEnumerablePaged(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetAllGalaxyPanelsForCluster", ex);
                throw;
            }
        }

        public IArrayResponse<GalaxyPanel> GetAllGalaxyPanelsForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyPanelPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelPDSAData.SelectFilters.BySiteUid;
                mgr.Entity.SiteUid = parameters.UniqueId;
                return GetIEnumerablePaged(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetAllGalaxyPanelsForCluster", ex);
                throw;
            }
        }

        public GalaxyPanel GetByHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyPanelPDSAManager();
                if (parameters.ClusterNumber != 0 && parameters.ClusterUid == Guid.Empty)
                {
                    mgr.DataObject.SelectFilter = GalaxyPanelPDSAData.SelectFilters.ByHardwareAddress;
                    mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                    mgr.Entity.ClusterNumber = parameters.ClusterNumber;
                }
                else
                {
                    mgr.DataObject.SelectFilter = GalaxyPanelPDSAData.SelectFilters.ByClusterUidAndPanelNumber;
                    mgr.Entity.ClusterUid = parameters.ClusterUid;
                }

                mgr.Entity.PanelNumber = parameters.PanelNumber;
                var data = GetIEnumerable(sessionData, parameters, mgr);
                return data?.FirstOrDefault();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetAllGalaxyPanelsForCluster", ex);
                throw;
            }
        }

        protected override GalaxyPanel GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyPanel GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyPanel result = new GalaxyPanel();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters != null && getParameters.IncludeMemberCollections)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetEntityByGuidId", ex);
                throw;
            }
        }



        public IEnumerable<GalaxyPanelAlarmSettings_PanelLoadData> GetAlarmEventSettingsByGalaxyPanelUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var msg = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName;
                var mgr = new GalaxyPanelAlarmSettings_PanelLoadDataByGalaxyPanelUidPDSAManager();
                mgr.Entity.GalaxyPanelUid = parameters.UniqueId;
                //                var result = mgr.BuildCollection();
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<GalaxyPanelAlarmSettings_PanelLoadData>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new GalaxyPanelAlarmSettings_PanelLoadData();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        entities.Add(newEntity);
                    }
                    return entities;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetAlarmEventSettingsByGalaxyPanelUid", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyPanelAlarmSettings_PanelLoadData> GetAlarmEventSettingsByClusterUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyPanelAlarmSettings_PanelLoadDataByClusterUidPDSAManager();
                mgr.Entity.ClusterUid = parameters.UniqueId;
                //                var result = mgr.BuildCollection();
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<GalaxyPanelAlarmSettings_PanelLoadData>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new GalaxyPanelAlarmSettings_PanelLoadData();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        entities.Add(newEntity);
                    }
                    return entities;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetAlarmEventSettingsByClusterUid", ex);
                throw;
            }
        }

        public IArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters)
        {
            try
            {
                var languageRepo = _dataRepositoryFactory.GetDataRepository<IGcsLanguageRepository>();
                var lang = languageRepo.Get(parameters.LanguageUid, sessionData, new GetParametersWithPhoto());

                var minSqlDate = DateTimeOffset.Now.MinSqlDateTime();
                var maxSqlDate = DateTimeOffset.Now.MaxSqlDateTime();

                if (parameters.StartDateTime < minSqlDate || parameters.StartDateTime > maxSqlDate)
                    parameters.StartDateTime = minSqlDate;

                if (parameters.EndDateTime < minSqlDate || parameters.EndDateTime > maxSqlDate)
                    parameters.EndDateTime = maxSqlDate;

                var results = new List<ActivityHistoryEvent>();
                var mgr = new select_GalaxyPanelActivityHistoryPDSAManager
                {
                    Entity =
                    {
                        EntityId = parameters.CurrentEntityId,
                        DeviceUid = parameters.GalaxyPanelUid,
                        IncludeLoggingOnOffEvents = parameters.IncludeLoggingOnOffEvents,
                        StartDateTime = parameters.StartDateTime,
                        EndDateTime = parameters.EndDateTime,
                        PageNumber = parameters.PageNumber,
                        PageSize = parameters.PageSize,
                        MaxResults = parameters.MaxResults,
                    }
                };

                if (mgr.Entity.EntityId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;

                mgr.Entity.CultureName = lang != null ? lang.CultureName : GalaxySMS.Common.Constants.LanguageCultures.EnglishUs;

                var result = mgr.BuildCollection();
                if (result != null)
                {
                    var totalCount = 0;
                    foreach (var i in result)
                    {
                        if (totalCount == 0)
                            totalCount = i.TotalRecordCount;
                        var newEntity = new ActivityHistoryEvent();
                        SimpleMapper.PropertyMap(i, newEntity);
                        //newEntity.ForeColorHex = $"#{newEntity.ForeColor & 0xFFFFFF:X6}";
                        results.Add(newEntity);
                    }
                    return ArrayResponseHelpers.ToArrayResponse(results, parameters.PageNumber, parameters.PageSize, totalCount);
                }
                return new ArrayResponse<ActivityHistoryEvent>();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetCredentialPanelLoadDataForCluster", ex);
                throw;
            }
        }

        public bool VerifyEntityIdMatches(Guid galaxyPanelUid, Guid entityId)
        {
            var mgr = new GetEntityIdForGalaxyPanelPDSAManager
            {
                Entity =
                {
                    uid = galaxyPanelUid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId == entityId;
            return false;
        }

        public Guid GetParentEntityId(Guid parentUid)
        {
            var mgr = new GetEntityIdForClusterPDSAManager
            {
                Entity =
                {
                    uid = parentUid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId;
            return Guid.Empty;
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForGalaxyPanelPDSAManager
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

        public Guid GetEntityId(int clusterGroupId, int clusterNumber, int panelNumber)
        {
            var mgr = new GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAManager()
            {
                Entity =
                {
                    clusterGroupId = clusterGroupId,
                    clusterNumber = clusterNumber,
                    panelNumber = panelNumber
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.EntityId;
            return Guid.Empty;

        }
        public IEnumerable<Guid> GetAllPrimaryKeyUidsForEntityId(Guid entityId)
        {
            var dataList = new List<Guid>();
            if (entityId == Guid.Empty)
                return dataList;
            var mgr = new GalaxyPanel_GetAllUidsForEntityIdPDSAManager();
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            return results.Select(o => o.Uid);
        }

        public IEnumerable<Guid> GetAllPrimaryKeyUidsForClusterUid(Guid clusterUid)
        {
            var dataList = new List<Guid>();
            if (clusterUid == Guid.Empty)
                return dataList;
            var mgr = new GalaxyPanel_GetAllUidsForClusterUidPDSAManager();
            mgr.Entity.ClusterUid = clusterUid;
            var results = mgr.BuildCollection();
            return results.Select(o => o.Uid);
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyPanel originalEntity, GalaxyPanel newEntity, string auditXml)
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
                        propertiesToIgnore.Add("InterfaceBoards");
                        propertiesToIgnore.Add("Cpus");
                        propertiesToIgnore.Add("GalaxyPanelSites");
                        propertiesToIgnore.Add(nameof(GalaxyPanel.AlertEvents));
                        propertiesToIgnore.Add(nameof(GalaxyPanel.DisabledCommandIds));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "GalaxyPanelUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyPanelUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyPanelUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyPanelUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyPanelUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyPanelUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyPanelUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyPanelUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyPanelUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyPanel entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
            //var entityMaps = _entityMapRepository.GetAllGalaxyPanelEntityMapsForGalaxyPanel(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyPanelUid });
            //var entityIds = (from e in entityMaps select e.EntityId).ToList();
            //entity.EntityIds.AddRange(entityIds);
            //foreach (var e in entityMaps)
            //{
            //    if (e.EntityId != entity.EntityId)
            //        entity.EntityIds.Add(e.EntityId);
            //}
            //entity.EntityIds.Add(entity.EntityId);

            if (getParameters.IncludeMemberCollections)
            {
                if (!getParameters.IsExcluded(nameof(entity.Cpus)))
                    entity.Cpus = _galaxyCpuRepository.GetAllGalaxyCpusForPanel(sessionData, new GetParametersWithPhoto(getParameters) { UniqueId = entity.GalaxyPanelUid, IncludeMemberCollections = getParameters.IncludeMemberCollections }).ToCollection();
                if (!getParameters.IsExcluded(nameof(entity.InterfaceBoards)))
                    entity.InterfaceBoards = _galaxyInterfaceBoardRepository.GetAllGalaxyInterfaceBoardsForPanel(sessionData, new GetParametersWithPhoto(getParameters) { UniqueId = entity.GalaxyPanelUid, IncludeMemberCollections = getParameters.IncludeMemberCollections, }).ToCollection();

                if (!getParameters.IsExcluded(nameof(entity.AlertEvents)))
                {
                    var iogMgr = new InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAManager();
                    iogMgr.Entity.galaxyPanelUid = entity.GalaxyPanelUid;
                    iogMgr.Entity.ioGroupNumber = GalaxySMS.Common.Constants.InputOutputGroupLimits.None;
                    var iog = iogMgr.BuildCollection();


                    entity.AlertEvents = _galaxyPanelAlertEventRepository.GetByGalaxyPanelUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyPanelUid, IncludeMemberCollections = getParameters.IncludeMemberCollections }).ToCollection();
                    if (iog != null && iog.Count == 1)
                    {
                        entity.InitializeAlertEventsCollection(GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
                            GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always,
                            iog[0].InputOutputGroupUid);
                    }
                }
            }

            if (getParameters.IncludeCommands)
            {
                if (!getParameters.IsExcluded(nameof(entity.DisabledCommandIds)) && entity.GalaxyPanelModelUid != null)
                {
                    // Get permissions for user and add missing permissions to the DisableCommandIds
                    var userPermissions =
                        _userRepository.GetPermissionIdsForUserEntityPermissionCategory(sessionData.UserId,
                            entity.EntityId, GalaxySMS.Common.Constants.PermissionCategoryIds.ClusterCommandCategoryId);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ActivateCrisisMode))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ActivateCrisisMode);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ResetCrisisMode))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ResetCrisisMode);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ResetPanelCold))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ResetControllerCold);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ResetPanelWarm))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ResetControllerWarm);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ForgiveAllPassback))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ForgiveAllPassback);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ForgivePassback))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ForgivePassback);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.ClearLogBuffer))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_ClearLoggingBuffer);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.LoadPanelFlash))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_BeginFlashLoad);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.EnableCredential))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_EnableCredential);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.DisableCredential))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_DisableCredential);
                    if (!userPermissions.Contains(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSClusterCommandPermission.DeleteAllCards))
                        entity.DisabledCommandIds.Add(GalaxySMS.Common.Constants.GalaxyClusterCommandIds.GalaxyClusterCommand_DeleteAllCredentials);
                    //var commands = _galaxyPanelCommandRepository.GetAllGalaxyPanelCommandForPanelModel(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyPanelModelUid.Value }).ToCollection();
                    //foreach (var c in commands)
                    //{

                    //}
                    //entity.DisabledCommandIds = 
                }

                //if (!getParameters.IsExcluded(nameof(entity.GalaxyPanelCommands)) && entity.GalaxyPanelModelUid != null)
                //    entity.GalaxyPanelCommands = _galaxyPanelCommandRepository.GetAllGalaxyPanelCommandForPanelModel(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyPanelModelUid.Value }).ToCollection();
            }
        }

        //private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity)
        //{
        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingEntityMappings = _entityMapRepository.GetAllGalaxyPanelEntityMapsForGalaxyPanel(sessionData, getParameters);
        //    var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
        //    var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);
        //    foreach (var existingEntityId in existingEntityIds)
        //    {
        //        if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
        //        {
        //            var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
        //            if (deleteThisExistingEntityMap != null)
        //                _entityMapRepository.Remove(deleteThisExistingEntityMap.GalaxyPanelEntityMapUid, sessionData, null);
        //        }
        //    }
        //    foreach (var entityId in entity.EntityIds)
        //    {
        //        if (!existingEntityIds.Contains(entityId))
        //        {
        //            var entityMap = new GalaxyPanelEntityMap();
        //            entityMap.GalaxyPanelEntityMapUid = GuidUtilities.GenerateComb();
        //            entityMap.GalaxyPanelUid = uid;
        //            entityMap.EntityId = entityId;
        //            entityMap.UpdateDate = DateTimeOffset.Now;
        //            entityMap.UpdateName = sessionData.UserName;
        //            entityMap.InsertDate = DateTimeOffset.Now;
        //            entityMap.InsertName = sessionData.UserName;

        //            _entityMapRepository.Add(entityMap, sessionData, null);
        //        }
        //    }
        //}
        // Guarantee that required child records exist and create them if necessary
        private void EnsureChildRecordsExist(GalaxyPanel entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.Cpus)))
                SaveCpus(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.InterfaceBoards)))
                SaveInterfaceBoards(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.AlertEvents)))
                SaveAlertEvents(entity, sessionData, saveParams);
        }

        private void SaveCpus(GalaxyPanel entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            // GalaxyCpus
            var cpus = _galaxyCpuRepository.GetAllGalaxyCpusForPanel(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyPanelUid });

            // Now delete any that are no longer defined in the GalaxyPanel
            foreach (var cpu in cpus)
            {
                // If the CpuUid does not exist in the entity, then delete the cpu from the database
                if (entity.Cpus.FirstOrDefault(c => c.CpuUid == cpu.CpuUid) == null)
                {
                    _galaxyCpuRepository.Remove(cpu.CpuUid, sessionData);
                }
            }

            // Add one CPU if none is defined
            if (!entity.Cpus.Any())
            {
                entity.Cpus = entity.Cpus.ToCollection();
                entity.Cpus.Add(new GalaxyCpu()
                {
                    CpuNumber = 1,
                    IsActive = true,
                });
            }

            // Now save those that are defined in the GalaxyPanel
            // Force the CPU types to match the PanelType
            foreach (var cpu in entity.Cpus)
            {
                if (entity.GalaxyPanelModelUid.HasValue)
                {
                    if (entity.GalaxyPanelModelUid.Value == GalaxyPanelTypeIds.GalaxyPanelType_600)
                        cpu.GalaxyCpuModelUid = GalaxyCpuTypeIds.GalaxyCpuType_635;
                    if (entity.GalaxyPanelModelUid.Value == GalaxyPanelTypeIds.GalaxyPanelType_635)
                        cpu.GalaxyCpuModelUid = GalaxyCpuTypeIds.GalaxyCpuType_635;
                    else if (entity.GalaxyPanelModelUid.Value == GalaxyPanelTypeIds.GalaxyPanelType_708)
                        cpu.GalaxyCpuModelUid = GalaxyCpuTypeIds.GalaxyCpuType_708;
                }

                var existingCpu = entity.Cpus.FirstOrDefault(c => c.CpuUid == cpu.CpuUid);
                if (existingCpu != null && cpu.IsAnythingDirty == true && existingCpu.CpuUid != Guid.Empty)
                {
                    UpdateTableEntityBaseProperties(cpu, sessionData);
                    _galaxyCpuRepository.Update(cpu, sessionData, saveParams);
                }
                if (cpu.CpuUid == Guid.Empty)
                {
                    cpu.CpuUid = GuidUtilities.GenerateComb();
                    cpu.GalaxyPanelUid = entity.GalaxyPanelUid;
                    cpu.ClusterGroupId = entity.ClusterGroupId;
                    cpu.ClusterNumber = entity.ClusterNumber;
                    cpu.PanelNumber = entity.PanelNumber;
                    UpdateTableEntityBaseProperties(cpu, sessionData);
                    _galaxyCpuRepository.Add(cpu, sessionData, saveParams);
                }
            }
        }

        private void SaveInterfaceBoards(GalaxyPanel entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            // Interface Boards
            var boards = _galaxyInterfaceBoardRepository.GetAllGalaxyInterfaceBoardsForPanel(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyPanelUid });

            // Now delete any that are no longer defined in the GalaxyPanel
            foreach (var board in boards)
            {
                // If the GalaxyInterfaceBoardUid does not exist in the entity, then delete the board from the database
                if (entity.InterfaceBoards.FirstOrDefault(o => o.GalaxyInterfaceBoardUid == board.GalaxyInterfaceBoardUid) == null)
                {
                    _galaxyInterfaceBoardRepository.Remove(board.GalaxyInterfaceBoardUid, sessionData);
                }
            }

            // Now save those that are defined in the GalaxyPanel being saved
            foreach (var board in entity.InterfaceBoards)
            {
                board.ClusterNumber = entity.ClusterNumber;
                board.PanelNumber = entity.PanelNumber;
                var existingBoard = boards.FirstOrDefault(o => o.GalaxyInterfaceBoardUid == board.GalaxyInterfaceBoardUid);
                if (existingBoard != null)//&& board.IsAnythingDirty)
                {
                    UpdateTableEntityBaseProperties(board, sessionData);
                    _galaxyInterfaceBoardRepository.Update(board, sessionData, saveParams);
                }
                if (board.GalaxyInterfaceBoardUid == Guid.Empty)
                {
                    board.GalaxyInterfaceBoardUid = GuidUtilities.GenerateComb();
                    board.GalaxyPanelUid = entity.GalaxyPanelUid;
                    UpdateTableEntityBaseProperties(board, sessionData);
                    _galaxyInterfaceBoardRepository.Add(board, sessionData, saveParams);
                }
            }
        }

        //private void SaveAlertEvents(GalaxyPanel entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    // grab the None IOGroup so that i can fix any that are set to Guid.Empty;
        //    var iogMgr = new InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAManager();
        //    iogMgr.Entity.galaxyPanelUid = entity.GalaxyPanelUid;
        //    iogMgr.Entity.ioGroupNumber = GalaxySMS.Common.Constants.InputOutputGroupLimits.None;
        //    var iog = iogMgr.BuildCollection();
        //    var iogNone = iog.FirstOrDefault();

        //    // Alert Events
        //    var items = _galaxyPanelAlertEventRepository.GetByGalaxyPanelUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyPanelUid });

        //// Now delete any that are no longer defined in the AlertEvents
        //foreach (var i in items)
        //{
        //    // If the GalaxyPanelAlertEventUid does not exist in the entity, then delete the item from the database
        //    if (entity.AlertEvents.FirstOrDefault(o => o.GalaxyPanelAlertEventUid == i.GalaxyPanelAlertEventUid) == null)
        //    {
        //        _galaxyPanelAlertEventRepository.Remove(i.GalaxyPanelAlertEventUid, sessionData, null);
        //    }
        //}

        //    // Now save those that are defined in the Access Portal being saved
        //    foreach (var i in entity.AlertEvents)
        //    {
        //        var existingItem = items.FirstOrDefault(o => o.GalaxyPanelAlertEventUid == i.GalaxyPanelAlertEventUid);
        //        if (i.InputOutputGroupUid == Guid.Empty && iogNone != null)
        //            i.InputOutputGroupUid = iogNone.InputOutputGroupUid;


        //        var propsToIgnore = new List<string>();
        //        //                propsToIgnore.Add(nameof(i.InputDeviceUid));
        //        var isdirty = ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i, null, propsToIgnore);
        //        if (existingItem != null && i.IsAnythingDirty)
        //        {
        //            UpdateTableEntityBaseProperties(i, sessionData);
        //            _galaxyPanelAlertEventRepository.Update(i, sessionData, saveParams);
        //        }
        //        if (i.GalaxyPanelAlertEventUid == Guid.Empty)
        //        {
        //            i.GalaxyPanelAlertEventUid = GuidUtilities.GenerateComb();
        //            i.GalaxyPanelUid = entity.GalaxyPanelUid;
        //            UpdateTableEntityBaseProperties(i, sessionData);
        //            _galaxyPanelAlertEventRepository.Add(i, sessionData, saveParams);
        //        }
        //    }
        //}
        private void SaveAlertEvents(GalaxyPanel entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            // grab the None IOGroup so that i can fix any that are set to Guid.Empty;
            var iogMgr = new InputOutputGroupUid_GetByGalaxyPanelUidAndIOGroupNumberPDSAManager();
            iogMgr.Entity.galaxyPanelUid = entity.GalaxyPanelUid;
            iogMgr.Entity.ioGroupNumber = GalaxySMS.Common.Constants.InputOutputGroupLimits.None;
            var iog = iogMgr.BuildCollection();
            var iogNone = iog.FirstOrDefault();

            // Alert Events
            var items = _galaxyPanelAlertEventRepository.GetByGalaxyPanelUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyPanelUid });

            // This was removed 2022-02-28 because the database should always have items for each of the 4 possible panel level alerts
            //// Now delete any that are no longer defined in the AlertEvents
            //foreach (var i in items)
            //{
            //    // If the GalaxyPanelAlertEventUid does not exist in the entity, then delete the item from the database
            //    if (entity.AlertEvents.FirstOrDefault(o => o.GalaxyPanelAlertEventUid == i.GalaxyPanelAlertEventUid) == null)
            //    {
            //        _galaxyPanelAlertEventRepository.Remove(i.GalaxyPanelAlertEventUid, sessionData, null);
            //    }
            //}

            // Now save those that are defined in the AlertEvents being saved
            foreach (var i in entity.AlertEvents)
            {
                // Pick the item out by GalaxyPanelAlertEventTypeUid
                var existingItem = items.FirstOrDefault(o => o.GalaxyPanelAlertEventTypeUid == i.GalaxyPanelAlertEventTypeUid);
                if (i.InputOutputGroupUid == Guid.Empty && (!i.InputOutputGroupAssignmentUid.HasValue || i.InputOutputGroupAssignmentUid == Guid.Empty) && iogNone != null)
                    i.InputOutputGroupUid = iogNone.InputOutputGroupUid;

                if (existingItem != null)
                    i.GalaxyPanelAlertEventUid = existingItem.GalaxyPanelAlertEventUid;

                var propsToIgnore = new List<string>();
                propsToIgnore.Add(nameof(i.GalaxyPanelAlertEventUid));
                propsToIgnore.Add(nameof(i.GalaxyPanelUid));
                propsToIgnore.Add(nameof(i.GalaxyPanelAlertEventTypeUid));
                propsToIgnore.Add(nameof(i.GalaxyPanelAlertEventType));
                if( GuidUtilities.DoSourceAndDestRepresentNull(i.AudioBinaryResourceUid, existingItem?.AudioBinaryResourceUid, Guid.Empty))
                    propsToIgnore.Add(nameof(i.AudioBinaryResourceUid));
                if (GuidUtilities.DoSourceAndDestRepresentNull(i.InputOutputGroupAssignmentUid, existingItem?.InputOutputGroupAssignmentUid, Guid.Empty))
                    propsToIgnore.Add(nameof(i.InputOutputGroupAssignmentUid));
                if (GuidUtilities.DoSourceAndDestRepresentNull(i.UserInstructionsNoteUid, existingItem?.UserInstructionsNoteUid, Guid.Empty))
                    propsToIgnore.Add(nameof(i.UserInstructionsNoteUid));


                var isdirty = ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, i, null, propsToIgnore);
                if (existingItem != null && isdirty )//i.IsAnythingDirty)
                {
                    i.GalaxyPanelUid = existingItem.GalaxyPanelUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _galaxyPanelAlertEventRepository.Update(i, sessionData, saveParams);
                }
                if (i.GalaxyPanelAlertEventUid == Guid.Empty)
                {
                    i.GalaxyPanelAlertEventUid = GuidUtilities.GenerateComb();
                    i.GalaxyPanelUid = entity.GalaxyPanelUid;
                    UpdateTableEntityBaseProperties(i, sessionData);
                    _galaxyPanelAlertEventRepository.Add(i, sessionData, saveParams);
                }
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyPanel", "GalaxyPanelUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyPanel", "GalaxyPanelUid", id);
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

        protected override bool IsEntityUnique(GalaxyPanel entity)
        {
            var mgr = new IsGalaxyPanelUniquePDSAManager();
            mgr.Entity.GalaxyPanelUid = entity.GalaxyPanelUid;
            mgr.Entity.ClusterUid = entity.ClusterUid;
            mgr.Entity.PanelNumber = entity.PanelNumber;
            mgr.Entity.PanelName = entity.PanelName;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        public bool IsPanelNumberUnique(GalaxyPanel entity)
        {
            var mgr = new IsGalaxyPanelNumberUniquePDSAManager();
            mgr.Entity.GalaxyPanelUid = entity.GalaxyPanelUid;
            mgr.Entity.ClusterUid = entity.ClusterUid;
            mgr.Entity.PanelNumber = entity.PanelNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        public bool IsPanelNameUnique(GalaxyPanel entity)
        {
            var mgr = new IsGalaxyPanelNameUniquePDSAManager();
            mgr.Entity.GalaxyPanelUid = entity.GalaxyPanelUid;
            mgr.Entity.ClusterUid = entity.ClusterUid;
            mgr.Entity.PanelName = entity.PanelName;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        public bool IsPanelConnected(Guid galaxyPanelUid)
        {
            var mgr = new IsGalaxyPanelConnectedPDSAManager();
            mgr.Entity.galaxyPanelUid = galaxyPanelUid;
            var results = mgr.BuildCollection();

            var r = results.FirstOrDefault();
            if (r != null)
                return r.CountConnected != 0;
            return false;
        }

        public LoadDataCounts GetLoadDataCounts(Guid galaxyPanelUid, LoadDataToPanelSettings loadSettings)
        {
            try
            {
                var mgr = new GetLoadDataCountsForGalaxyPanelUidPDSAManager();
                mgr.Entity.galaxyPanelUid = galaxyPanelUid;
                mgr.Entity.includeBoardSectionCount = loadSettings.AccessPortalsInputsOutputs; 
                mgr.Entity.includeAccessPortalCount = loadSettings.AccessPortalsInputsOutputs;
                mgr.Entity.includeInputDeviceCount = loadSettings.AccessPortalsInputsOutputs;
                mgr.Entity.includeOutputDeviceCount = loadSettings.AccessPortalsInputsOutputs;
                mgr.Entity.includeAccessRuleCount = loadSettings.AccessRules;
                mgr.Entity.includeCredentialCount = loadSettings.AllCardData;
                mgr.Entity.includePersonalAccessGroupCount = loadSettings.AllCardData;
                mgr.Entity.includeIoGroupCount = loadSettings.InputOutputGroups;
                mgr.Entity.includeTimeScheduleCount = loadSettings.TimeSchedules;

                var data = mgr.BuildCollection();

                if (data.Count == 1)
                {
                    var counts = data.FirstOrDefault();
                    if (counts != null)
                    {
                        var result = new LoadDataCounts()
                        {
                            AccessPortalsInputsOutputsCount = counts.AccessPortalsInputsOutputsCount,
                            AllCardDataCount = counts.AllCardDataCount,
                            InterfaceBoardSectionCount = counts.InterfaceBoardSectionCount,
                            AccessPortalCount = counts.AccessPortalCount,
                            InputDeviceCount = counts.InputDeviceCount,
                            OutputDeviceCount = counts.OutputDeviceCount,
                            AccessRulesCount = counts.AccessRulesCount,
                            CredentialCount = counts.CredentialCount,
                            PersonalAccessGroupCount = counts.PersonalAccessGroupCount,
                            DayTypeCount = counts.DayTypeCount,
                            InputOutputGroupCount = counts.InputOutputGroupCount,
                            TimeSchedulesCount = counts.TimeSchedulesCount,
                            TimePeriodCount = counts.TimePeriodCount,
                            TimePeriodDayTypeMapCount = counts.TimePeriodDayTypeMapCount,
                            AccessPortalAccessRulesCount = counts.AccessPortalAccessRulesCount
                        };
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetEntityByGuidId", ex);
                throw;
            }


        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyPanel", "GalaxyPanelUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyPanel", "GalaxyPanelUid", id);
            if (count == 0)
                return true;
            return false;
        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertPanelCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();

                var ibmgr = new gcsEntityCountPDSA_InsertInterfaceBoardCountPDSAManager();
                ibmgr.Entity.EntityId = entityId;
                ibmgr.Execute();
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

        protected override IArrayResponse<GalaxyPanel> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelPDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<GalaxyPanel> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelPDSAData.SelectFilters.All;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelRepository::GetAllEntities", ex);
                throw;
            }
        }
    }
}
