using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
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
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace GalaxySMS.Data
{
    [Export(typeof(IGalaxyHardwareModuleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyHardwareModuleRepository : DataRepositoryBase<GalaxyHardwareModule>,
        IGalaxyHardwareModuleRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import] private IGalaxyInterfaceBoardSectionNodeRepository _galaxyInterfaceBoardSectionNodeRepository;
        [Import] private IAccessPortalRepository _accessPortalRepository;
        [Import] private IInputDeviceRepository _inputDeviceRepository;
        [Import] private IOutputDeviceRepository _outputDeviceRepository;
        [Import] private ILiquidCrystalDisplayRepository _lcdRepository;

        [Import] private IGalaxyInputOutputGroupRepository _ioGroupRepository;
        [Import] private IGalaxyAreaRepository _areaRepository;
        [Import] private IGalaxyAccessGroupRepository _accessGroupRepository;
        [Import] private ITimeScheduleRepository _timeScheduleRepository;
        [Import] private IGalaxyClusterTimeScheduleMapRepository _clusterTimeScheduleMapRepository;
        [Import] IDataRepositoryFactory _dataRepositoryFactory;

        protected override GalaxyHardwareModule AddEntity(GalaxyHardwareModule entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //this.Log().LogTransactionInformation($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                EnsureIsActiveIsProperlySet(ref entity);

                var mgr = new GalaxyHardwareModulePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.GalaxyHardwareModuleUid, entity);
                    var result = GetEntityByGuidId(entity.GalaxyHardwareModuleUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        entity.ClusterGroupId = result.ClusterGroupId;
                        entity.ClusterNumber = result.ClusterNumber;
                        entity.PanelNumber = result.PanelNumber;
                        entity.BoardNumber = result.BoardNumber;
                        entity.SectionNumber = result.SectionNumber;

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::AddEntity", ex);
                throw;
            }
        }

        private void EnsureIsActiveIsProperlySet(ref GalaxyHardwareModule entity)
        {
            if (!entity.IsModuleActive)
                entity.IsModuleActive = entity.GalaxyInterfaceBoardSectionNodes.Any(o => o.IsNodeActive);
        }

        protected override GalaxyHardwareModule UpdateEntity(GalaxyHardwareModule entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                EnsureIsActiveIsProperlySet(ref entity);

                var originalEntity = GetEntityByGuidId(entity.GalaxyHardwareModuleUid, sessionData, null);
                var mgr = new GalaxyHardwareModulePDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.GalaxyHardwareModuleUid) > 0)                // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    entity.GalaxyInterfaceBoardSectionUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.GalaxyInterfaceBoardSectionUid, entity.GalaxyInterfaceBoardSectionUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.GalaxyHardwareModuleUid, entity);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.GalaxyHardwareModuleUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        entity.ClusterGroupId = updatedEntity.ClusterGroupId;
                        entity.ClusterNumber = updatedEntity.ClusterNumber;
                        entity.PanelNumber = updatedEntity.PanelNumber;
                        entity.BoardNumber = updatedEntity.BoardNumber;
                        entity.SectionNumber = updatedEntity.SectionNumber;
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.GalaxyHardwareModuleUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(GalaxyHardwareModule entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyHardwareModulePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyHardwareModuleUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyHardwareModulePDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id);
                // must read the original record from the database so the PDSA object can detect changes
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyHardwareModule> GetIEnumerable(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters, GalaxyHardwareModulePDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (getParameters != null && getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        // GetAllGalaxyHardwareModules for an Entity
        protected override IEnumerable<GalaxyHardwareModule> GetEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyHardwareModulePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyHardwareModulePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<GalaxyHardwareModule> GetAllEntities(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyHardwareModulePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyHardwareModulePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyHardwareModule> GetAllGalaxyHardwareModulesForCluster(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyHardwareModulePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyHardwareModulePDSAData.SelectFilters.ByClusterUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::GetAllGalaxyHardwareModulesForCluster", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyHardwareModule> GetAllGalaxyHardwareModulesForPanel(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyHardwareModulePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyHardwareModulePDSAData.SelectFilters.ByGalaxyPanelUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::GetAllGalaxyHardwareModulesForPanel", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyHardwareModule> GetAllGalaxyHardwareModulesForPanelAddress(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyHardwareModulePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyHardwareModulePDSAData.SelectFilters.ByPanelAddress;
                mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = (short)parameters.ClusterNumber;
                mgr.Entity.PanelNumber = (short)parameters.PanelNumber;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::GetAllGalaxyHardwareModulesForPanel", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyHardwareModule> GetAllGalaxyHardwareModulesForInterfaceBoard(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyHardwareModulePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyHardwareModulePDSAData.SelectFilters.ByGalaxyInterfaceBoardUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::GetAllGalaxyHardwareModulesForInterfaceBoard", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyHardwareModule> GetAllGalaxyHardwareModulesForInterfaceBoardSection(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyHardwareModulePDSAManager();
                mgr.DataObject.SelectFilter =
                    GalaxyHardwareModulePDSAData.SelectFilters.ByGalaxyInterfaceBoardSectionUid;
                mgr.Entity.GalaxyInterfaceBoardSectionUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log()
                    .Error("GalaxyHardwareModuleRepository::GetAllGalaxyHardwareModulesForInterfaceBoardSection", ex);
                throw;
            }
        }

        public Guid GetParentEntityId(Guid parentUid)
        {
            var mgr = new GetEntityIdForGalaxyInterfaceBoardSectionPDSAManager
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
            var mgr = new GetEntityIdForGalaxyHardwareModulePDSAManager
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



        protected override GalaxyHardwareModule GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyHardwareModule GetEntityByGuidId(Guid guid,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyHardwareModulePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyHardwareModule result = new GalaxyHardwareModule();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData,
            GalaxyHardwareModule originalEntity, GalaxyHardwareModule newEntity, string auditXml)
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
                            throw new ArgumentNullException("newEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        List<String> propertiesToIgnore = new List<string>();
                        propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        propertiesToIgnore.Add("GalaxyInterfaceBoardSectionNodes");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "GalaxyHardwareModuleUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyHardwareModuleUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyHardwareModuleUid.ToString();
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;

                        if (string.IsNullOrEmpty(auditXml) == false)
                        {
                            mgr.Entity.AuditXml = auditXml;
                            mgr.Execute();
                        }


                        mgr.Entity.AuditXml = null;

                        SimpleObjectDifferenceDetector.CompareResults differences =
                            SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity, propertiesToIgnore);
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
                            throw new ArgumentNullException("newEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "GalaxyHardwareModuleUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyHardwareModuleUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyHardwareModuleUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "GalaxyHardwareModuleUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyHardwareModuleUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyHardwareModuleUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {
                // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyHardwareModuleRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyHardwareModule entity,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
            //var entityMaps = _entityMapRepository.GetAllGalaxyHardwareModuleEntityMapsForGalaxyHardwareModule(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyHardwareModuleUid });
            //var entityIds = (from e in entityMaps select e.EntityId).ToList();
            //entity.EntityIds.AddRange(entityIds);
            //foreach ( var e in entityMaps)
            //{
            //    if(e.EntityId != entity.EntityId)
            //        entity.EntityIds.Add(e.EntityId);
            //}
            //entity.EntityIds.Add(entity.EntityId);
            if (!getParameters.IsExcluded(nameof(entity.GalaxyInterfaceBoardSectionNodes)))
            {
                entity.GalaxyInterfaceBoardSectionNodes =
                    _galaxyInterfaceBoardSectionNodeRepository
                        .GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModule
                        (sessionData,
                            new GetParametersWithPhoto()
                            {
                                UniqueId = entity.GalaxyHardwareModuleUid,
                                IncludeMemberCollections = true
                            }).ToCollection();

                EnsureIsActiveIsProperlySet(ref entity);
            }

        }

        private void EnsureChildRecordsExist(GalaxyHardwareModule entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.GalaxyInterfaceBoardSectionNodes)))
                SaveGalaxyInterfaceBoardSectionNodes(entity, sessionData, saveParams);
        }

        private void SaveGalaxyInterfaceBoardSectionNodes(GalaxyHardwareModule entity, 
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {

            // Nodes
            var nodes =
                _galaxyInterfaceBoardSectionNodeRepository.GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModule
                    (sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyHardwareModuleUid });

            // Now delete any that are no longer defined in the GalaxyPanel
            foreach (var node in nodes)
            {
                var n = entity.GalaxyInterfaceBoardSectionNodes.FirstOrDefault(o => o.NodeNumber == node.NodeNumber);
                if( n == null )
                    n = entity.GalaxyInterfaceBoardSectionNodes.FirstOrDefault(o=>o.GalaxyInterfaceBoardSectionNodeUid == node.GalaxyInterfaceBoardSectionNodeUid);
                // If the CpuUid does not exist in the entity, then delete the cpu from the database
                if (n == null)
                {
                    _galaxyInterfaceBoardSectionNodeRepository.Remove(node.GalaxyInterfaceBoardSectionNodeUid, sessionData);
                }
                else
                {
                    n.GalaxyInterfaceBoardSectionNodeUid = node.GalaxyInterfaceBoardSectionNodeUid;
                    n.ConcurrencyValue = node.ConcurrencyValue;
                }
            }

            var clusteridMgr = new ClusterUid_GetByGalaxyHardwareModuleUidPDSAManager
            {
                Entity = { galaxyHardwareModuleUid = entity.GalaxyHardwareModuleUid }
            };

            //IEnumerable<Area> areas = null;
            IEnumerable<TimeSchedule> schedules = null;
            IEnumerable<InputOutputGroup> iogroups = null;

            var inputSupervisionTypeRepository = _dataRepositoryFactory.GetDataRepository<IInputDeviceSupervisionTypeRepository>();

            var inputSupervisionTypeUid = GalaxySMS.Common.Constants.InputDeviceSupervisionTypeIds.None;
            var dioInputSupervisionTypeUid = saveParams.OptionValue<Guid>(GalaxySMS.Common.Enums.SaveInputDeviceOption.DioInputSupervisionTypeUid.ToString());
            var rs485InputModuleInputSupervisionTypeUid = saveParams.OptionValue<Guid>(GalaxySMS.Common.Enums.SaveInputDeviceOption.Rs485InputModuleSupervisionTypeUid.ToString());

            if (dioInputSupervisionTypeUid == Guid.Empty)
                dioInputSupervisionTypeUid = inputSupervisionTypeUid;

            if (rs485InputModuleInputSupervisionTypeUid == Guid.Empty)
                rs485InputModuleInputSupervisionTypeUid = inputSupervisionTypeUid;

            var dioInputSupervisionType = inputSupervisionTypeRepository.Get(dioInputSupervisionTypeUid,
                sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false, IncludePhoto = false });

            var rs485InputModuleInputSupervisionType = inputSupervisionTypeRepository.Get(rs485InputModuleInputSupervisionTypeUid,
                sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false, IncludePhoto = false });

            //var roleRepository = _dataRepositoryFactory.GetDataRepository<IGcsRoleRepository>();

            //var roleIds = roleRepository.GetAllPrimaryKeyUids(saveParams.CurrentEntityId).ToCollection();

            //var roleParams = new GetParametersWithPhoto() { CurrentEntityId = saveParams.CurrentEntityId, IncludeMemberCollections = true };
            //roleParams.ExcludeMemberCollectionSettings.Add(nameof(gcsRole.RolePermissions));

            //var roles = roleRepository.GetAllRolesForEntity(roleParams.CurrentEntityId, roleParams);
            var roleClusterRepository = _dataRepositoryFactory.GetDataRepository<IRoleClusterRepository>();

            var roleClusters = roleClusterRepository.GetAllForClusterAddress(sessionData,
                new GetParametersWithPhoto()
                {
                    ClusterGroupId = entity.ClusterGroupId, ClusterNumber = entity.ClusterNumber,
                    IncludeMemberCollections = false,
                    CurrentEntityId = saveParams.CurrentEntityId
                });

            var enumerable = roleClusters as RoleCluster[] ?? roleClusters.ToArray();
            var accessPortalRoleIds = enumerable.Where(o => o.IncludeAllAccessPortals).Select(o => o.RoleId).ToCollection();
            var inputDeviceRoleIds = enumerable.Where(o => o.IncludeAllInputDevices).Select(o => o.RoleId).ToCollection();
            var outputDeviceRoleIds = enumerable.Where(o => o.IncludeAllOutputDevices).Select(o => o.RoleId).ToCollection();

            var ensureAccessPortalExistsParameters = new EnsureAccessPortalExistsParameters()
            {
                GalaxyHardwareModuleTypeUid = entity.GalaxyHardwareModuleTypeUid,
                RoleIds = accessPortalRoleIds
            };

            var data = clusteridMgr.BuildCollection();
            if (data != null && data.Count == 1)
            {
                var getClusterDataParams = new GetParametersWithPhoto() { UniqueId = data[0].ClusterUid };

                ensureAccessPortalExistsParameters.Areas = _areaRepository.GetAllGalaxyAreasForCluster(sessionData, getClusterDataParams).Items;
                ensureAccessPortalExistsParameters.InputOutputGroups = _ioGroupRepository.GetAllGalaxyInputOutputGroupsForCluster(sessionData, getClusterDataParams).Items;
                ensureAccessPortalExistsParameters.Schedules = _timeScheduleRepository.GetAllTimeSchedulesForGalaxyCluster(sessionData, getClusterDataParams).Items;
                schedules = ensureAccessPortalExistsParameters.Schedules;
                iogroups = ensureAccessPortalExistsParameters.InputOutputGroups;

                var clusterAccessPortalDefaultMgr = new Cluster_GetAccessPortalDefaultsPDSAManager();
                clusterAccessPortalDefaultMgr.Entity.ClusterUid = data[0].ClusterUid;
                var apDefaultsData = clusterAccessPortalDefaultMgr.BuildCollection();
                if (apDefaultsData != null && apDefaultsData.Count == 1)
                {
                    ensureAccessPortalExistsParameters.DefaultAccessPortalTypeUid = apDefaultsData[0].AccessPortalTypeUid;
                    ensureAccessPortalExistsParameters.SiteUid = apDefaultsData[0].SiteUid;
                }
            }

            // Now save those that are defined in the GalaxyPanel
            foreach (var node in entity.GalaxyInterfaceBoardSectionNodes)
            {
                node.ClusterNumber = entity.ClusterNumber;
                node.PanelNumber = entity.PanelNumber;

                var existingNode =
                    nodes
                        .FirstOrDefault(o => o.GalaxyInterfaceBoardSectionNodeUid == node.GalaxyInterfaceBoardSectionNodeUid);

                if (node.GalaxyInterfaceBoardSectionNodeUid == Guid.Empty)
                {
                    ////var createDefaultModulesOption = saveParams.OptionValue(SaveGalaxyInterfaceBoardOption.CreateDefaultModulesAndNodes.ToString());
                    //var defaultIsActiveOption = saveParams.OptionValue(SaveGalaxyInterfaceBoardOption.DefaultIsActiveValue.ToString());
                    //var createDefaultModules = false;
                    //var defaultIsActive = false;
                    //if (bool.TryParse(createDefaultModulesOption, out createDefaultModules))
                    //{

                    //}
                    //if (bool.TryParse(defaultIsActiveOption, out defaultIsActive))
                    //{
                    //    node.IsNodeActive = defaultIsActive;
                    //}
                    //else
                        //node.IsNodeActive = entity.IsModuleActive;
                }
   
                node.GalaxyHardwareModuleUid = entity.GalaxyHardwareModuleUid;
                node.GalaxyPanelUid = entity.GalaxyPanelUid;
                
                if (existingNode != null)//&& node.IsAnythingDirty)
                {
                    UpdateTableEntityBaseProperties(node, sessionData);
                    _galaxyInterfaceBoardSectionNodeRepository.Update(node, sessionData, saveParams);
                }

                if (node.GalaxyInterfaceBoardSectionNodeUid == Guid.Empty)
                {
                    node.GalaxyInterfaceBoardSectionNodeUid = GuidUtilities.GenerateComb();
                    UpdateTableEntityBaseProperties(node, sessionData);
                    var newNode = _galaxyInterfaceBoardSectionNodeRepository.Add(node, sessionData, saveParams);
                }

                node.ClusterGroupId = entity.ClusterGroupId;
                node.ClusterNumber = entity.ClusterNumber;
                node.PanelNumber = entity.PanelNumber;
                node.BoardNumber = entity.BoardNumber;
                node.SectionNumber = entity.SectionNumber;
                node.ModuleNumber = entity.ModuleNumber;
                if (data != null)
                    node.ClusterUid = data[0].ClusterUid;

                if (entity.GalaxyHardwareModuleTypeUid ==
                    GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_ReaderPortModule ||
                    entity.GalaxyHardwareModuleTypeUid ==
                    GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RemoteDoorModule ||
                    entity.GalaxyHardwareModuleTypeUid ==
                    GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AllegionPIM ||
                    entity.GalaxyHardwareModuleTypeUid ==
                    GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_SaltoSallisHub ||
                    entity.GalaxyHardwareModuleTypeUid ==
                    GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_AssaAbloyAperioHub)
                {
                    // These all require an Access Portal to be created
                    ensureAccessPortalExistsParameters.TheNode = node;
                    _accessPortalRepository.EnsureAccessPortalExists(sessionData, ensureAccessPortalExistsParameters, saveParams);
                }
                else if (entity.GalaxyHardwareModuleTypeUid ==
                         GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds
                             .GalaxyHardwareModuleType_DigitalInputOutputInputModule)
                {
                    _inputDeviceRepository.EnsureInputDeviceExists(sessionData,
                        new EnsureInputDeviceExistsParameters()
                        {
                            TheNode = node,
                            GalaxyHardwareModuleTypeUid = entity.GalaxyHardwareModuleTypeUid,
                            Schedules = schedules,
                            InputOutputGroups = iogroups,
                            SiteUid = ensureAccessPortalExistsParameters.SiteUid,
                            SupervisionType = dioInputSupervisionType,
                            RoleIds = inputDeviceRoleIds
                        }, saveParams);
                }
                else if (entity.GalaxyHardwareModuleTypeUid == GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_InputModule16)
                {
                    _inputDeviceRepository.EnsureInputDeviceExists(sessionData,
                        new EnsureInputDeviceExistsParameters()
                        {
                            TheNode = node,
                            GalaxyHardwareModuleTypeUid = entity.GalaxyHardwareModuleTypeUid,
                            Schedules = schedules,
                            InputOutputGroups = iogroups,
                            SiteUid = ensureAccessPortalExistsParameters.SiteUid,
                            SupervisionType = rs485InputModuleInputSupervisionType,
                            RoleIds = inputDeviceRoleIds
                        }, saveParams);
                }
                else if (entity.GalaxyHardwareModuleTypeUid ==
                         GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds
                             .GalaxyHardwareModuleType_DigitalInputOutputOutputModule ||
                         entity.GalaxyHardwareModuleTypeUid ==
                         GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_RelayModule8)
                {
                    _outputDeviceRepository.EnsureOutputDeviceExists(sessionData,
                        new EnsureOutputDeviceExistsParameters()
                        {
                            TheNode = node,
                            GalaxyHardwareModuleTypeUid = entity.GalaxyHardwareModuleTypeUid,
                            Schedules = schedules,
                            InputOutputGroups = iogroups,
                            SiteUid = ensureAccessPortalExistsParameters.SiteUid,
                            RoleIds = outputDeviceRoleIds
                        }, saveParams);
                }
                else if (entity.GalaxyHardwareModuleTypeUid ==
                         GalaxySMS.Common.Constants.GalaxyHardwareModuleTypeIds.GalaxyHardwareModuleType_CypressLCD)
                {
                    _lcdRepository.EnsureLiquidCrystalDisplayExists(sessionData,
                        new EnsureLiquidCrystalDisplayExistsParameters()
                        {
                            TheNode = node,
                            GalaxyHardwareModuleTypeUid = entity.GalaxyHardwareModuleTypeUid,
                            SiteUid = ensureAccessPortalExistsParameters.SiteUid

                        }, saveParams);
                }
            }
        }

        //private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity)
        //{
        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingEntityMappings = _entityMapRepository.GetAllGalaxyHardwareModuleEntityMapsForGalaxyHardwareModule(sessionData, getParameters);
        //    var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
        //    var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);
        //    foreach (var existingEntityId in existingEntityIds)
        //    {
        //        if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
        //        {
        //            var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
        //            if (deleteThisExistingEntityMap != null)
        //                _entityMapRepository.Remove(deleteThisExistingEntityMap.GalaxyHardwareModuleEntityMapUid, sessionData, null);
        //        }
        //    }
        //    foreach (var entityId in entity.EntityIds)
        //    {
        //        if (!existingEntityIds.Contains(entityId))
        //        {
        //            var entityMap = new GalaxyHardwareModuleEntityMap();
        //            entityMap.GalaxyHardwareModuleEntityMapUid = GuidUtilities.GenerateComb();
        //            entityMap.GalaxyHardwareModuleUid = uid;
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
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyHardwareModule",
                "GalaxyHardwareModuleUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyHardwareModule",
                "GalaxyHardwareModuleUid", id);
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

        protected override bool IsEntityUnique(GalaxyHardwareModule entity)
        {
            var mgr = new IsGalaxyHardwareModuleUniquePDSAManager();
            mgr.Entity.GalaxyHardwareModuleUid = entity.GalaxyHardwareModuleUid;
            if (entity.GalaxyInterfaceBoardSectionUid.HasValue)
                mgr.Entity.GalaxyInterfaceBoardSectionUid = entity.GalaxyInterfaceBoardSectionUid.Value;
            mgr.Entity.ModuleNumber = entity.ModuleNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyHardwareModule", "GalaxyHardwareModuleUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyHardwareModule", "GalaxyHardwareModuleUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}