using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
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
    [Export(typeof(IGalaxyCpuRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyCpuRepository : DataRepositoryBase<GalaxyCpu>, IGalaxyCpuRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        protected override GalaxyCpu AddEntity(GalaxyCpu entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                //var panelModelUid = GalaxySMSDatabaseManager.GetScalar<Guid>($"select GalaxyPanelModelUid from GCS.GalaxyPanel where GalaxyPanelUid = '{entity.GalaxyPanelUid}'");

                if (entity.GalaxyCpuModelUid == Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_635)
                    entity.Model = (int)Common.Enums.CpuModel.Cpu635;
                //else if (entity.GalaxyCpuModelUid == Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_600)
                //    entity.Model = (int)Common.Enums.CpuModel.Cpu600;
                else if (entity.GalaxyCpuModelUid == Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_708)
                    entity.Model = (int)Common.Enums.CpuModel.Cpu708;
                //else if (entity.GalaxyCpuModelUid == Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_500)
                //    entity.Model = (int)Common.Enums.CpuModel.Cpu5xx;
                else if (entity.GalaxyCpuModelUid == Guid.Empty)
                {
                    entity.GalaxyCpuModelUid = Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_635;
                    entity.Model = (int)Common.Enums.CpuModel.Cpu635;
                }

                var mgr = new GalaxyCpuPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.CpuUid, entity);
                    var result = GetEntityByGuidId(entity.CpuUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyCpu UpdateEntity(GalaxyCpu entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.CpuUid, sessionData, null);
                var mgr = new GalaxyCpuPDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.CpuUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;
                    
                    entity.GalaxyCpuModelUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.GalaxyCpuModelUid, entity.GalaxyCpuModelUid);
                    entity.Model = mgr.Entity.Model;

                    if (string.IsNullOrEmpty(entity.IpAddress))
                        entity.IpAddress = mgr.Entity.IpAddress;

                    if (string.IsNullOrEmpty(entity.Version))
                        entity.Version = mgr.Entity.Version;

                    if (string.IsNullOrEmpty(entity.SerialNumber))
                        entity.SerialNumber = mgr.Entity.SerialNumber;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.CpuUid, entity);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.CpuUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }

                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.CpuUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(GalaxyCpu entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyCpuPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.CpuUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyCpuPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyCpu> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyCpuPDSAManager mgr)
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

        // GetAllGalaxyCpus for an Entity
        protected override IEnumerable<GalaxyCpu> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyCpuPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyCpuPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<GalaxyCpu> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyCpuPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyCpuPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::GetAllEntities", ex);
                throw;
            }
        }

        //public IEnumerable<GalaxyCpu> GetAllGalaxyCpusForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        //{
        //    return GetEntities(sessionData, getParameters);
        //}

        public IEnumerable<GalaxyCpu> GetAllGalaxyCpusForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyCpuPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyCpuPDSAData.SelectFilters.ByClusterUid;
                mgr.Entity.ClusterUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::GetAllGalaxyCpusForCluster", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyCpu> GetAllGalaxyCpusForPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyCpuPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyCpuPDSAData.SelectFilters.ByGalaxyPanelUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::GetAllGalaxyCpusForPanel", ex);
                throw;
            }
        }

        public GalaxyCpu GetByHardwareAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyCpuPDSAManager
                {
                    DataObject = { SelectFilter = GalaxyCpuPDSAData.SelectFilters.ByHardwareAddress },
                    Entity =
                    {
                        ClusterGroupId = parameters.ClusterGroupId,
                        ClusterNumber = parameters.ClusterNumber,
                        PanelNumber = parameters.PanelNumber,
                        CpuNumber = parameters.GetInt16
                    }
                };
                return GetIEnumerable(sessionData, parameters, mgr)?.FirstOrDefault();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::GetAllGalaxyCpusForPanel", ex);
                throw;
            }
        }

        public void SaveCpuLoggingControl(IApplicationUserSessionDataHeader sessionData, ISaveParameters<GalaxyCpuLoggingControl> entity)
        {
            try
            {
                var mgr = new GalaxyCpuLoggingControl_SavePDSAManager();
                mgr.Entity.CpuUid = entity.Data.CpuUid;
                mgr.Entity.LastLogIndex = entity.Data.LastLogIndex;
                //if (entity.Data.UpdateDate.HasValue)
                //    mgr.Entity.UpdateDate = entity.Data.UpdateDate.Value;
                //else
                //    mgr.Entity.UpdateDate = DateTimeOffset.Now;

                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::GetAllGalaxyCpusForPanel", ex);
                throw;
            }
        }

        public void UpdateCpuInformation(GalaxyCpuSaveInformationData parameters)
        {
            try
            {
                var mgr = new GalaxyCpu_UpdateInformationPDSAManager();
                mgr.Entity.CpuUid = parameters.CpuUid;
                mgr.Entity.SerialNumber = parameters.SerialNumber;
                mgr.Entity.IpAddress = parameters.IpAddress;
                mgr.Entity.Model = parameters.Model;
                mgr.Entity.Version = parameters.Version;
                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::GetAllGalaxyCpusForPanel", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyCpuDatabaseInformation> GetGalaxyCpuInformation(IApplicationUserSessionDataHeader sessionData, GetHardwareAddressParameters parameters)
        {
            try
            {
                var mgr = new GalaxyCpu_GetCpuPanelClusterInformationPDSAManager();
                mgr.Entity.ClusterUid = parameters.ClusterUid;
                mgr.Entity.GalaxyPanelUid = parameters.GalaxyPanelUid;
                mgr.Entity.CpuUid = parameters.CpuUid;
                mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = parameters.ClusterNumber;
                mgr.Entity.PanelNumber = parameters.PanelNumber;
                mgr.Entity.CpuNumber = parameters.CpuNumber;

                var data = mgr.BuildCollection();
                var entities = new List<GalaxyCpuDatabaseInformation>();
                foreach (var o in data)
                {
                    entities.Add(mgr.ConvertPDSAEntity(o));
                }
                return entities;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuLoggingControlRepository::GetGalaxyCpuDatabaseInformation", ex);
                throw;
            }

        }

        public IEnumerable<GalaxyCpuDatabaseInformation> GetGalaxyClusterPanelInformation(IApplicationUserSessionDataHeader sessionData, GetHardwareAddressParameters parameters)
        {
            try
            {
                var mgr = new GalaxyClusterPanelInformation_GetForCpuPDSAManager();
                mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = parameters.ClusterNumber;
                mgr.Entity.PanelNumber = parameters.PanelNumber;
                mgr.Entity.CpuNumber = parameters.CpuNumber;

                var data = mgr.BuildCollection();
                var entities = new List<GalaxyCpuDatabaseInformation>();
                foreach (var o in data)
                {
                    entities.Add(mgr.ConvertPDSAEntity(o));
                }
                return entities;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuLoggingControlRepository::GetGalaxyCpuDatabaseInformation", ex);
                throw;
            }
        }


        public void SetGalaxyCpuConnection(GalaxyCpuConnection cpuConnection)
        {
            try
            {
                var mgr = new GalaxyCpuConnection_SavePDSAManager();
                mgr.Entity.CpuUid = cpuConnection.CpuUid;
                mgr.Entity.IsConnected = cpuConnection.IsConnected;
                mgr.Entity.ServerAddress = cpuConnection.ServerAddress;
                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::GetAllGalaxyCpusForPanel", ex);
                throw;
            }

        }

        protected override GalaxyCpu GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyCpu GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyCpuPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyCpu result = new GalaxyCpu();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyCpu originalEntity, GalaxyCpu newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "CpuUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.CpuUid;
                        mgr.Entity.RecordTag = newEntity.CpuUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "CpuUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.CpuUid;
                        mgr.Entity.RecordTag = newEntity.CpuUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "CpuUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.CpuUid;
                        mgr.Entity.RecordTag = originalEntity.CpuUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyCpuRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyCpu entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
            //var entityMaps = _entityMapRepository.GetAllGalaxyCpuEntityMapsForGalaxyCpu(sessionData, new GetParametersWithPhoto() { UniqueId = entity.CpuUid });
            //var entityIds = (from e in entityMaps select e.EntityId).ToList();
            //entity.EntityIds.AddRange(entityIds);
            //foreach ( var e in entityMaps)
            //{
            //    if(e.EntityId != entity.EntityId)
            //        entity.EntityIds.Add(e.EntityId);
            //}
            //entity.EntityIds.Add(entity.EntityId);
        }

        //private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity)
        //{
        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingEntityMappings = _entityMapRepository.GetAllGalaxyCpuEntityMapsForGalaxyCpu(sessionData, getParameters);
        //    var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
        //    var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);
        //    foreach (var existingEntityId in existingEntityIds)
        //    {
        //        if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
        //        {
        //            var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
        //            if (deleteThisExistingEntityMap != null)
        //                _entityMapRepository.Remove(deleteThisExistingEntityMap.GalaxyCpuEntityMapUid, sessionData, null);
        //        }
        //    }
        //    foreach (var entityId in entity.EntityIds)
        //    {
        //        if (!existingEntityIds.Contains(entityId))
        //        {
        //            var entityMap = new GalaxyCpuEntityMap();
        //            entityMap.GalaxyCpuEntityMapUid = GuidUtilities.GenerateComb();
        //            entityMap.CpuUid = uid;
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
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyCpu", "CpuUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyCpu", "CpuUid", id);
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

        protected override bool IsEntityUnique(GalaxyCpu entity)
        {
            var mgr = new IsGalaxyCpuUniquePDSAManager();
            mgr.Entity.CpuUid = entity.CpuUid;
            mgr.Entity.GalaxyPanelUid = entity.GalaxyPanelUid;
            mgr.Entity.CpuNumber = entity.CpuNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyCpu", "CpuUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyCpu", "CpuUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForGalaxyCpuPDSAManager
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

        public bool IsCpuConnected(Guid cpuUid)
        {
            var mgr = new IsGalaxyCpuConnectedPDSAManager();
            mgr.Entity.cpuUid = cpuUid;
            var results = mgr.BuildCollection();

            var r = results.FirstOrDefault();
            if (r != null)
                return r.IsConnected != 0;
            return false;
        }
    }
}
