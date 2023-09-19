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
    [Export(typeof(IGalaxyInterfaceBoardSectionNodeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyInterfaceBoardSectionNodeRepository : DataRepositoryBase<GalaxyInterfaceBoardSectionNode>, IGalaxyInterfaceBoardSectionNodeRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        protected override GalaxyInterfaceBoardSectionNode AddEntity(GalaxyInterfaceBoardSectionNode entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                //this.Log().LogTransactionInformation($"{this.GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.GalaxyInterfaceBoardSectionNodeUid, entity);
                    var result = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionNodeUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionNodeRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyInterfaceBoardSectionNode UpdateEntity(GalaxyInterfaceBoardSectionNode entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionNodeUid, sessionData, null);
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.GalaxyInterfaceBoardSectionNodeUid) > 0)             // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    entity.GalaxyHardwareModuleUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.GalaxyHardwareModuleUid, entity.GalaxyHardwareModuleUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        //SaveEntityMappings(sessionData, entity.GalaxyInterfaceBoardSectionNodeUid, entity);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionNodeUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.GalaxyInterfaceBoardSectionNodeUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionNodeRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(GalaxyInterfaceBoardSectionNode entity,
            IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyInterfaceBoardSectionNodeUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionNodeRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionNodeRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyInterfaceBoardSectionNode> GetIEnumerable(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters,
            GalaxyInterfaceBoardSectionNodePDSAManager mgr)
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

        // GetAllGalaxyInterfaceBoardSectionNodes for an Entity
        protected override IEnumerable<GalaxyInterfaceBoardSectionNode> GetEntities(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionNodePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionNodeRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllEntities(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionNodePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionNodeRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodesForCluster(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionNodePDSAData.SelectFilters.ByClusterUid;
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
                this.Log()
                    .Error(
                        "GalaxyInterfaceBoardSectionNodeRepository::GetAllGalaxyInterfaceBoardSectionNodesForCluster",
                        ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodesForPanel(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionNodePDSAData.SelectFilters.ByGalaxyPanelUid;
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
                this.Log()
                    .Error("GalaxyInterfaceBoardSectionNodeRepository::GetAllGalaxyInterfaceBoardSectionNodesForPanel",
                        ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodesForPanelAddress(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionNodePDSAData.SelectFilters.ByPanelAddress;
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
                this.Log()
                    .Error("GalaxyInterfaceBoardSectionNodeRepository::GetAllGalaxyInterfaceBoardSectionNodesForPanel",
                        ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoard(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                mgr.DataObject.SelectFilter =
                    GalaxyInterfaceBoardSectionNodePDSAData.SelectFilters.ByGalaxyInterfaceBoardUid;
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
                this.Log()
                    .Error(
                        "GalaxyInterfaceBoardSectionNodeRepository::GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoard",
                        ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSectionNode>
            GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSection(
                IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                mgr.DataObject.SelectFilter =
                    GalaxyInterfaceBoardSectionNodePDSAData.SelectFilters.ByGalaxyInterfaceBoardSectionUid;
                mgr.Entity.GalaxyInterfaceBoardSectionNodeUid = parameters.UniqueId;
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
                    .Error(
                        "GalaxyInterfaceBoardSectionNodeRepository::GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSection",
                        ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSectionNode>
            GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModule(IApplicationUserSessionDataHeader sessionData,
                IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                mgr.DataObject.SelectFilter =
                    GalaxyInterfaceBoardSectionNodePDSAData.SelectFilters.ByGalaxyHardwareModuleUid;
                mgr.Entity.GalaxyHardwareModuleUid = parameters.UniqueId;
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
                    .Error(
                        "GalaxyInterfaceBoardSectionNodeRepository::GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoard",
                        ex);
                throw;
            }
        }

        protected override GalaxyInterfaceBoardSectionNode GetEntityByIntId(int id,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyInterfaceBoardSectionNode GetEntityByGuidId(Guid guid,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionNodePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyInterfaceBoardSectionNode result = new GalaxyInterfaceBoardSectionNode();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionNodeRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData,
            GalaxyInterfaceBoardSectionNode originalEntity, GalaxyInterfaceBoardSectionNode newEntity, string auditXml)
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
                        propertiesToIgnore.Add("InputOutputGroupAssignments");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionNodeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyInterfaceBoardSectionNodeUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyInterfaceBoardSectionNodeUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionNodeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyInterfaceBoardSectionNodeUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyInterfaceBoardSectionNodeUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionNodeUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyInterfaceBoardSectionNodeUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyInterfaceBoardSectionNodeUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionNodeRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyInterfaceBoardSectionNode entity,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
            //var entityMaps = _entityMapRepository.GetAllGalaxyInterfaceBoardSectionNodeEntityMapsForGalaxyInterfaceBoardSectionNode(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyInterfaceBoardSectionNodeUid });
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
        //    var existingEntityMappings = _entityMapRepository.GetAllGalaxyInterfaceBoardSectionNodeEntityMapsForGalaxyInterfaceBoardSectionNode(sessionData, getParameters);
        //    var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
        //    var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);
        //    foreach (var existingEntityId in existingEntityIds)
        //    {
        //        if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
        //        {
        //            var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
        //            if (deleteThisExistingEntityMap != null)
        //                _entityMapRepository.Remove(deleteThisExistingEntityMap.GalaxyInterfaceBoardSectionNodeEntityMapUid, sessionData, null);
        //        }
        //    }
        //    foreach (var entityId in entity.EntityIds)
        //    {
        //        if (!existingEntityIds.Contains(entityId))
        //        {
        //            var entityMap = new GalaxyInterfaceBoardSectionNodeEntityMap();
        //            entityMap.GalaxyInterfaceBoardSectionNodeEntityMapUid = GuidUtilities.GenerateComb();
        //            entityMap.GalaxyInterfaceBoardSectionNodeUid = uid;
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
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyInterfaceBoardSectionNode",
                "GalaxyInterfaceBoardSectionNodeUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyInterfaceBoardSectionNode",
                "GalaxyInterfaceBoardSectionNodeUid", id);
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

        protected override bool IsEntityUnique(GalaxyInterfaceBoardSectionNode entity)
        {
            var mgr = new IsGalaxyInterfaceBoardSectionNodeUniquePDSAManager();
            mgr.Entity.GalaxyInterfaceBoardSectionNodeUid = entity.GalaxyInterfaceBoardSectionNodeUid;
            mgr.Entity.GalaxyHardwareModuleUid = entity.GalaxyHardwareModuleUid;
            mgr.Entity.NodeNumber = entity.NodeNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyInterfaceBoardSectionNode",
                "GalaxyInterfaceBoardSectionNodeUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyInterfaceBoardSectionNode",
                "GalaxyInterfaceBoardSectionNodeUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForGalaxyInterfaceBoardSectionNodePDSAManager
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