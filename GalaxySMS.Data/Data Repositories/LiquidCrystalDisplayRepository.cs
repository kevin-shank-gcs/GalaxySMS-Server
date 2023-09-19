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
    [Export(typeof(ILiquidCrystalDisplayRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LiquidCrystalDisplayRepository : DataRepositoryBase<LiquidCrystalDisplay>, ILiquidCrystalDisplayRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import] private ILiquidCrystalDisplayEntityMapRepository _entityMapRepository;
        [Import] private ILiquidCrystalDisplayGalaxyHardwareAddressRepository _LiquidCrystalDisplayGalaxyHardwareAddressRepository;

        protected override LiquidCrystalDisplay AddEntity(LiquidCrystalDisplay entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new LiquidCrystalDisplayPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.LiquidCrystalDisplayUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.LiquidCrystalDisplayUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::AddEntity", ex);
                throw;
            }
        }

        protected override LiquidCrystalDisplay UpdateEntity(LiquidCrystalDisplay entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.LiquidCrystalDisplayUid, sessionData, null);
                var mgr = new LiquidCrystalDisplayPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.LiquidCrystalDisplayUid);
                // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    SaveEntityMappings(sessionData, entity.LiquidCrystalDisplayUid, entity, saveParams);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.LiquidCrystalDisplayUid, sessionData, null);
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                        mgr.DataObject.AuditRowAsXml);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(LiquidCrystalDisplay entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new LiquidCrystalDisplayPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.LiquidCrystalDisplayUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new LiquidCrystalDisplayPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<LiquidCrystalDisplay> GetIEnumerable(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters, LiquidCrystalDisplayPDSAManager mgr)
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

        // GetAllLiquidCrystalDisplays for an Entity
        protected override IEnumerable<LiquidCrystalDisplay> GetEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new LiquidCrystalDisplayPDSAManager();
                mgr.DataObject.SelectFilter = LiquidCrystalDisplayPDSAData.SelectFilters.ByEntityId;
                mgr.Entity.EntityId = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<LiquidCrystalDisplay> GetAllEntities(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new LiquidCrystalDisplayPDSAManager();
                mgr.DataObject.SelectFilter = LiquidCrystalDisplayPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<LiquidCrystalDisplay> GetAllLiquidCrystalDisplaysForEntity(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        public IEnumerable<LiquidCrystalDisplay> GetAllLiquidCrystalDisplaysForRegion(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new LiquidCrystalDisplayPDSAManager();
                mgr.DataObject.SelectFilter = LiquidCrystalDisplayPDSAData.SelectFilters.ByRegionUid;
                mgr.Entity.RegionUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::GetAllLiquidCrystalDisplaysForRegion", ex);
                throw;
            }
        }

        public IEnumerable<LiquidCrystalDisplay> GetAllLiquidCrystalDisplaysForSite(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new LiquidCrystalDisplayPDSAManager();
                mgr.DataObject.SelectFilter = LiquidCrystalDisplayPDSAData.SelectFilters.BySiteUid;
                mgr.Entity.SiteUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::GetAllLiquidCrystalDisplaysForSite", ex);
                throw;
            }
        }

        public IEnumerable<LiquidCrystalDisplay> GetAllLiquidCrystalDisplaysForGalaxyPanel(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new LiquidCrystalDisplayPDSAManager();
                mgr.DataObject.SelectFilter = LiquidCrystalDisplayPDSAData.SelectFilters.ByGalaxyPanelUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::GetAllLiquidCrystalDisplaysForGalaxyPanel", ex);
                throw;
            }
        }


        public IEnumerable<LiquidCrystalDisplay> GetAllLiquidCrystalDisplaysForAccessPoint(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyPanelUid_GetByAccessPortalUidPDSAManager();
                mgr.Entity.accessPortalUid = parameters.UniqueId;
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(parameters as GetParametersWithPhoto);
                    newParams.UniqueId = data[0].GalaxyPanelUid;
                    return GetAllLiquidCrystalDisplaysForGalaxyPanel(sessionData, newParams);
                }
                return new List<LiquidCrystalDisplay>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::GetAllLiquidCrystalDisplaysForGalaxyPanel", ex);
                throw;
            }
        }

        public LiquidCrystalDisplay GetLiquidCrystalDisplayForAccessPoint(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new LiquidCrystalDisplayPDSAManager();
                mgr.DataObject.SelectFilter = LiquidCrystalDisplayPDSAData.SelectFilters.ByAccessPortalUid;
                mgr.Entity.AccessPortalUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr).FirstOrDefault();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::GetAllLiquidCrystalDisplayForAccessPoint", ex);
                throw;
            }
        }
        protected override LiquidCrystalDisplay GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override LiquidCrystalDisplay GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new LiquidCrystalDisplayPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    LiquidCrystalDisplay result = new LiquidCrystalDisplay();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData,
            LiquidCrystalDisplay originalEntity, LiquidCrystalDisplay newEntity, string auditXml)
        {
            try
            {                if( !string.IsNullOrEmpty(auditXml))
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
mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "LiquidCrystalDisplayUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.LiquidCrystalDisplayUid;
                        mgr.Entity.RecordTag = newEntity.LiquidCrystalDisplayUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "LiquidCrystalDisplayUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.LiquidCrystalDisplayUid;
                        mgr.Entity.RecordTag = newEntity.LiquidCrystalDisplayUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "LiquidCrystalDisplayUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.LiquidCrystalDisplayUid;
                        mgr.Entity.RecordTag = originalEntity.LiquidCrystalDisplayUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(LiquidCrystalDisplay entity, IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData,
            //        null);
            //}

            entity.GalaxyHardwareAddress = _LiquidCrystalDisplayGalaxyHardwareAddressRepository.GetByLiquidCrystalDisplayUid(sessionData, new GetParametersWithPhoto() { UniqueId = entity.LiquidCrystalDisplayUid });

            var entityMaps = _entityMapRepository.GetAllLiquidCrystalDisplayEntityMapsForLiquidCrystalDisplay(sessionData,
                new GetParametersWithPhoto() { UniqueId = entity.LiquidCrystalDisplayUid });
            var entityIds = (from e in entityMaps select e.EntityId).ToList();
            entity.EntityIds.AddRange(entityIds);
            //foreach ( var e in entityMaps)
            //{
            //    if(e.EntityId != entity.EntityId)
            //        entity.EntityIds.Add(e.EntityId);
            //}
            entity.EntityIds.Add(entity.EntityId);
        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllLiquidCrystalDisplayEntityMapsForLiquidCrystalDisplay(sessionData,
                getParameters);
            var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
            var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

            foreach (var existingEntityId in existingEntityIds)
            {
                if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
                {
                    var deleteThisExistingEntityMap =
                        (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem)
                        .FirstOrDefault();
                    if (deleteThisExistingEntityMap != null)
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.LiquidCrystalDisplayEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new LiquidCrystalDisplayEntityMap();
                    entityMap.LiquidCrystalDisplayEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.LiquidCrystalDisplayUid = uid;
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
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("LiquidCrystalDisplay", "LiquidCrystalDisplayUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("LiquidCrystalDisplay", "LiquidCrystalDisplayUid", id);
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

        protected override bool IsEntityUnique(LiquidCrystalDisplay entity)
        {
            var mgr = new IsLiquidCrystalDisplayUniquePDSAManager();
            mgr.Entity.LiquidCrystalDisplayUid = entity.LiquidCrystalDisplayUid;
            mgr.Entity.LcdName = entity.LcdName;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("LiquidCrystalDisplay", "LiquidCrystalDisplayUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("LiquidCrystalDisplay", "LiquidCrystalDisplayUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        #region Implementation of ILiquidCrystalDisplayRepository

        public LiquidCrystalDisplay EnsureLiquidCrystalDisplayExists(IApplicationUserSessionDataHeader sessionData, EnsureLiquidCrystalDisplayExistsParameters parameters, ISaveParameters saveParams)
        {
            // Start by seeing if one exists for the GalaxyInterfaceBoardSectionNode
            var existingAp =
                _LiquidCrystalDisplayGalaxyHardwareAddressRepository.GetByLiquidCrystalDisplayGalaxyHardwareAddressUid(sessionData,
                    new GetParametersWithPhoto() { UniqueId = parameters.TheNode.GalaxyInterfaceBoardSectionNodeUid });
            if (existingAp != null)
                return GetEntityByGuidId(existingAp.LiquidCrystalDisplayUid, sessionData,
                    new GetParametersWithPhoto() { UniqueId = existingAp.LiquidCrystalDisplayUid });

            LiquidCrystalDisplay templateItem = null;
            LiquidCrystalDisplay newItem = null;

            // If none exists, create one
            if (parameters.TemplateLcdDeviceUid != Guid.Empty)
                templateItem = GetEntityByGuidId(parameters.TemplateLcdDeviceUid, sessionData,
                    new GetParametersWithPhoto() { UniqueId = parameters.TemplateLcdDeviceUid });
            if (templateItem == null)
            {
                //var apType =
                //    _LiquidCrystalDisplayTypeRepository.Get(parameters.DefaultLiquidCrystalDisplayTypeUid, sessionData,
                //        new GetParametersWithPhoto() { }) ??
                //    _LiquidCrystalDisplayTypeRepository.GetAll(sessionData, new GetParametersWithPhoto()).FirstOrDefault();

                //if (apType == null)
                //{
                //    var ex =
                //        new ApplicationException(
                //            "Unable to create access portal because there is no LiquidCrystalDisplayType defined");
                //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//LiquidCrystalDisplayRepository::EnsureLiquidCrystalDisplayExists", ex);
                //    throw ex;
                //}
                newItem = new LiquidCrystalDisplay();
                newItem.InsertName = sessionData.UserName;
                newItem.InsertDate = DateTimeOffset.Now;
            }
            else
            {
                newItem = templateItem.Clone(templateItem);
            }
            newItem.LiquidCrystalDisplayUid = GuidUtilities.GenerateComb();
            newItem.EntityId = sessionData.CurrentEntityId;
//            newItem.SiteUid = sessionData.CurrentSiteId;
            newItem.SiteUid = parameters.SiteUid;

            newItem.LcdName = string.Format(GalaxySMS.Resources.Resources.LiquidCrystalDisplay_DefaultGalaxyName,
                parameters.TheNode.ClusterGroupId,
                parameters.TheNode.ClusterNumber,
                parameters.TheNode.PanelNumber, parameters.TheNode.BoardNumber, parameters.TheNode.SectionNumber, parameters.TheNode.NodeNumber);
            newItem.InsertName = sessionData.UserName;
            newItem.InsertDate = DateTimeOffset.Now;
            newItem.UpdateName = newItem.InsertName;
            newItem.UpdateDate = newItem.InsertDate;
            var returnItem = Add(newItem, sessionData, saveParams);
            if (returnItem != null)
            {
                var hwAddress = new LiquidCrystalDisplayGalaxyHardwareAddress();
                hwAddress.LiquidCrystalDisplayGalaxyHardwareAddressUid = GuidUtilities.GenerateComb();
                hwAddress.LiquidCrystalDisplayUid = returnItem.LiquidCrystalDisplayUid;
                hwAddress.GalaxyInterfaceBoardSectionNodeUid = parameters.TheNode.GalaxyInterfaceBoardSectionNodeUid;
                hwAddress.InsertName = sessionData.UserName;
                hwAddress.InsertDate = DateTimeOffset.Now;
                hwAddress.UpdateName = newItem.InsertName;
                hwAddress.UpdateDate = newItem.InsertDate;

                _LiquidCrystalDisplayGalaxyHardwareAddressRepository.Add(hwAddress, sessionData, saveParams);
            }
            return returnItem;
        }

        #endregion
    }
}