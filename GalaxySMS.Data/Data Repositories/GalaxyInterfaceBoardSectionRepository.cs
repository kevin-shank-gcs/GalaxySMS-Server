using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Constants;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GalaxySMS.EntityLayer;
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
    [Export(typeof(IGalaxyInterfaceBoardSectionRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyInterfaceBoardSectionRepository : DataRepositoryBase<GalaxyInterfaceBoardSection>, IGalaxyInterfaceBoardSectionRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import]
        private IGalaxyHardwareModuleRepository _galaxyHardwareModuleRepository;

        [Import]
        private IAccessPortalRepository _accessPortalRepository;

        protected override GalaxyInterfaceBoardSection AddEntity(GalaxyInterfaceBoardSection entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    //SaveEntityMappings(sessionData, entity.GalaxyInterfaceBoardSectionUid, entity);
                    var result = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionUid, sessionData, null);
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyInterfaceBoardSection UpdateEntity(GalaxyInterfaceBoardSection entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionUid, sessionData, null);
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.GalaxyInterfaceBoardSectionUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    //SaveEntityMappings(sessionData, entity.GalaxyInterfaceBoardSectionUid, entity);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionUid, sessionData, null);
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                    EnsureChildRecordsExist(entity, sessionData, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(GalaxyInterfaceBoardSection entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyInterfaceBoardSectionUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyInterfaceBoardSection> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyInterfaceBoardSectionPDSAManager mgr)
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

        // GetAllGalaxyInterfaceBoardSections for an Entity
        protected override IEnumerable<GalaxyInterfaceBoardSection> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<GalaxyInterfaceBoardSection> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSectionsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionPDSAData.SelectFilters.ByClusterUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::GetAllGalaxyInterfaceBoardSectionsForCluster", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSectionsForInterfaceBoard(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionPDSAData.SelectFilters.ByGalaxyInterfaceBoardUid;
                mgr.Entity.GalaxyInterfaceBoardUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::GetAllGalaxyInterfaceBoardSectionsForInterfaceBoard", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSectionsForPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionPDSAData.SelectFilters.ByGalaxyPanelUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::GetAllGalaxyInterfaceBoardSectionsForPanel", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSectionsForPanelAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionPDSAData.SelectFilters.ByPanelAddress;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::GetAllGalaxyInterfaceBoardSectionsForPanel", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSectionsForAccessPortalUidModeCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionPDSAData.SelectFilters.ByAccessPortalUidInterfaceBoardSectionModeCode;
                mgr.Entity.AccessPortalUid = parameters.UniqueId;
                mgr.Entity.ModeCode = parameters.GetInt16;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::GetAllGalaxyInterfaceBoardSectionsForAccessPortalUidModeCode", ex);
                throw;
            }
        }

        protected override GalaxyInterfaceBoardSection GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyInterfaceBoardSection GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyInterfaceBoardSection result = new GalaxyInterfaceBoardSection();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        public GalaxyInterfaceBoardSection_PanelLoadData GetGalaxyInterfaceBoardSectionPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyInterfaceBoardSectionUidPDSAManager();
                mgr.Entity.GalaxyInterfaceBoardSectionUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                if (result != null && result.Count == 1)
                {
                    var returnData = new GalaxyInterfaceBoardSection_PanelLoadData();
                    SimpleMapper.PropertyMap(result[0], returnData);
                    return returnData;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::GetGalaxyInterfaceBoardSectionPanelLoadData", ex);
                throw;
            }
        }


        private IEnumerable<GalaxyInterfaceBoardSection_PanelLoadData> ConvertPDSACollection(GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyPanelUidPDSACollection pdsaCollection)
        {
            var results = new List<GalaxyInterfaceBoardSection_PanelLoadData>();
            foreach (var pdsaEntity in pdsaCollection)
            {
                var convertedEntity = new GalaxyInterfaceBoardSection_PanelLoadData();
                SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                results.Add(convertedEntity);
            }
            return results;
        }

        private IEnumerable<GalaxyInterfaceBoardSection_PanelLoadData> ConvertPDSACollection(GalaxyInterfaceBoardSection_GetPanelLoadDataByClusterUidPDSACollection pdsaCollection)
        {
            var results = new List<GalaxyInterfaceBoardSection_PanelLoadData>();
            foreach (var pdsaEntity in pdsaCollection)
            {
                var convertedEntity = new GalaxyInterfaceBoardSection_PanelLoadData();
                SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                results.Add(convertedEntity);
            }
            return results;
        }

        public IEnumerable<GalaxyInterfaceBoardSection_PanelLoadData> GetGalaxyInterfaceBoardSectionPanelLoadDataForPanelUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSection_GetPanelLoadDataByGalaxyPanelUidPDSAManager();
                mgr.Entity.GalaxyPanelUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                return ConvertPDSACollection(result);
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSection_PanelLoadData> GetGalaxyInterfaceBoardSectionPanelLoadDataForClusterUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSection_GetPanelLoadDataByClusterUidPDSAManager();
                mgr.Entity.GalaxyPanelUid = getParameters.UniqueId;
                var result = mgr.BuildCollection();
                return ConvertPDSACollection(result);
            }
            catch (Exception ex)
            {
                this.Log().Error(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName, ex);
                throw;
            }

        }

        public Guid GetParentEntityId(Guid parentUid)
        {
            var mgr = new GetEntityIdForGalaxyInterfaceBoardPDSAManager
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
            var mgr = new GetEntityIdForGalaxyInterfaceBoardSectionPDSAManager
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

        public Guid GetGalaxyPanelUid(Guid uid)
        {
            var mgr = new GetGalaxyPanelUidForGalaxyInterfaceBoardSectionPDSAManager()
            {
                Entity =
                {
                    uid = uid
                }
            };
            var results = mgr.BuildCollection();
            var r = results.FirstOrDefault();
            if (r != null)
                return r.GalaxyPanelUid;
            return Guid.Empty;
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyInterfaceBoardSection originalEntity, GalaxyInterfaceBoardSection newEntity, string auditXml)
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
                        propertiesToIgnore.Add("GalaxyHardwareModules");

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyInterfaceBoardSectionUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyInterfaceBoardSectionUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyInterfaceBoardSectionUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyInterfaceBoardSectionUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyInterfaceBoardSectionUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyInterfaceBoardSectionUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyInterfaceBoardSection entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
            //var entityMaps = _entityMapRepository.GetAllGalaxyInterfaceBoardSectionEntityMapsForGalaxyInterfaceBoardSection(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyInterfaceBoardSectionUid });
            //var entityIds = (from e in entityMaps select e.EntityId).ToList();
            //entity.EntityIds.AddRange(entityIds);
            //foreach ( var e in entityMaps)
            //{
            //    if(e.EntityId != entity.EntityId)
            //        entity.EntityIds.Add(e.EntityId);
            //}
            //entity.EntityIds.Add(entity.EntityId);
            if (!getParameters.IsExcluded(nameof(entity.GalaxyHardwareModules)))
            {
                entity.GalaxyHardwareModules = _galaxyHardwareModuleRepository
                    .GetAllGalaxyHardwareModulesForInterfaceBoardSection(sessionData,
                        new GetParametersWithPhoto()
                        {
                            UniqueId = entity.GalaxyInterfaceBoardSectionUid,
                            IncludeMemberCollections = getParameters.IncludeMemberCollections
                        }).ToCollection();

                var includeDeviceName =
                    getParameters.Options.FirstOrDefault(o => o.Key == GetOptions.IncludeDeviceName);

                if (includeDeviceName.Value == true)
                {
                    if (entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants
                            .DualSerialInterface635ChannelModeIds.DualSerialChannelMode_RS485DoorModule ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants
                            .DualSerialInterface635ChannelModeIds.DualSerialChannelMode_SaltoSallis ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants
                            .DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants
                            .DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimAba ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants
                            .DualSerialInterface635ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants
                            .DualSerialInterface600ChannelModeIds.DualSerialChannelMode_SaltoSallis ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants
                            .DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AssaAbloyAperio ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants
                            .DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimAba ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants
                            .DualSerialInterface600ChannelModeIds.DualSerialChannelMode_AllegionPimWiegand ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface635ModeIds
                            .ReaderInterfaceMode_AccessPortal ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface635ModeIds
                            .ReaderInterfaceMode_CredentialReaderOnly ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface600ModeIds
                            .ReaderInterfaceMode_AccessPortal ||
                        entity.InterfaceBoardSectionModeUid == GalaxySMS.Common.Constants.DualReaderInterface600ModeIds
                            .ReaderInterfaceMode_CredentialReaderOnly)
                    {
                        var aps = _accessPortalRepository.GetAccessPortalsPanelLoadData(sessionData,
                            new GetParametersWithPhoto()
                            { UniqueId = entity.GalaxyInterfaceBoardSectionUid, IncludeMemberCollections = false });
                        foreach (var ap in aps)
                        {
                            foreach (var m in entity.GalaxyHardwareModules)
                            {
                                var node = m.GalaxyInterfaceBoardSectionNodes.FirstOrDefault(o =>
                                    o.NodeNumber == ap.NodeNumber);
                                if (node != null)
                                {
                                    node.DeviceName = ap.PortalName;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void EnsureChildRecordsExist(GalaxyInterfaceBoardSection entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.GalaxyHardwareModules)))
                SaveGalaxyHardwareModules(entity, sessionData, saveParams);
        }

        private void SaveGalaxyHardwareModules(GalaxyInterfaceBoardSection entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.IsModeUnused && entity.GalaxyHardwareModules.Any())
                entity.GalaxyHardwareModules = new List<GalaxyHardwareModule>();//.Clear();

            // Hardware Modules
            var modules = _galaxyHardwareModuleRepository.GetAllGalaxyHardwareModulesForInterfaceBoardSection(sessionData, new GetParametersWithPhoto() { UniqueId = entity.GalaxyInterfaceBoardSectionUid });

            // Now delete any that are no longer defined in the GalaxyPanel
            foreach (var module in modules)
            {
                // If the GalaxyHardwareModuleUid does not exist in the entity, then delete the module from the database
                if (entity.GalaxyHardwareModules.FirstOrDefault(o => o.GalaxyHardwareModuleUid == module.GalaxyHardwareModuleUid) == null)
                {
                    _galaxyHardwareModuleRepository.Remove(module.GalaxyHardwareModuleUid, sessionData);
                }
            }

            // Now save those that are defined in the GalaxyPanel
            foreach (var module in entity.GalaxyHardwareModules)
            {
                module.ClusterNumber = entity.ClusterNumber;
                module.PanelNumber = entity.PanelNumber;
                module.GalaxyInterfaceBoardSectionUid = entity.GalaxyInterfaceBoardSectionUid;
                module.GalaxyPanelUid = entity.GalaxyPanelUid;
                
                var existingModule = modules.FirstOrDefault(o => o.GalaxyHardwareModuleUid == module.GalaxyHardwareModuleUid);
                if (existingModule != null)//&& module.IsAnythingDirty)
                {
                    UpdateTableEntityBaseProperties(module, sessionData);
                    _galaxyHardwareModuleRepository.Update(module, sessionData, saveParams);
                }
                if (module.GalaxyHardwareModuleUid == Guid.Empty)
                {
                    module.GalaxyHardwareModuleUid = GuidUtilities.GenerateComb();
                    UpdateTableEntityBaseProperties(module, sessionData);
                    _galaxyHardwareModuleRepository.Add(module, sessionData, saveParams);
                }
            }
        }


        //private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity)
        //{
        //    var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
        //    var existingEntityMappings = _entityMapRepository.GetAllGalaxyInterfaceBoardSectionEntityMapsForGalaxyInterfaceBoardSection(sessionData, getParameters);
        //    var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
        //    var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);
        //    foreach (var existingEntityId in existingEntityIds)
        //    {
        //        if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
        //        {
        //            var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
        //            if (deleteThisExistingEntityMap != null)
        //                _entityMapRepository.Remove(deleteThisExistingEntityMap.GalaxyInterfaceBoardSectionEntityMapUid, sessionData, null);
        //        }
        //    }
        //    foreach (var entityId in entity.EntityIds)
        //    {
        //        if (!existingEntityIds.Contains(entityId))
        //        {
        //            var entityMap = new GalaxyInterfaceBoardSectionEntityMap();
        //            entityMap.GalaxyInterfaceBoardSectionEntityMapUid = GuidUtilities.GenerateComb();
        //            entityMap.GalaxyInterfaceBoardSectionUid = uid;
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
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyInterfaceBoardSection", "GalaxyInterfaceBoardSectionUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyInterfaceBoardSection", "GalaxyInterfaceBoardSectionUid", id);
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

        protected override bool IsEntityUnique(GalaxyInterfaceBoardSection entity)
        {
            var mgr = new IsGalaxyInterfaceBoardSectionUniquePDSAManager();
            mgr.Entity.GalaxyInterfaceBoardSectionUid = entity.GalaxyInterfaceBoardSectionUid;
            mgr.Entity.GalaxyInterfaceBoardUid = entity.GalaxyInterfaceBoardUid;
            mgr.Entity.SectionNumber = entity.SectionNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyInterfaceBoardSection", "GalaxyInterfaceBoardSectionUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyInterfaceBoardSection", "GalaxyInterfaceBoardSectionUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
