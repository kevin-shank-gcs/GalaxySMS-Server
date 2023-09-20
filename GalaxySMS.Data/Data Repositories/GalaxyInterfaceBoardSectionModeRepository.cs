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
    [Export(typeof(IGalaxyInterfaceBoardSectionModeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InterfaceBoardSectionModeRepository : DataRepositoryBase<InterfaceBoardSectionMode>, IGalaxyInterfaceBoardSectionModeRepository, IPartImportsSatisfiedNotification
    {
        [Import]
  //      private IGalaxyCpuModelInterfaceBoardSectionModeRepository _galaxyCpuModelInterfaceBoardSectionModeRepositoryMapRepository;
        private IGalaxyPanelModelInterfaceBoardSectionModeRepository _galaxyPanelModelInterfaceBoardSectionModeRepositoryMapRepository;

        [Import]
        private IGcsBinaryResourceRepository _binaryResourceRepository;

        protected override InterfaceBoardSectionMode AddEntity(InterfaceBoardSectionMode entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new InterfaceBoardSectionModePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.InterfaceBoardSectionModeUid, sessionData, null);
                    if (result != null)
                    {
                        SaveGalaxyPanelModelMappings(sessionData, result.InterfaceBoardSectionModeUid, entity.GalaxyPanelModelUids, saveParams);

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardSectionModeRepository::AddEntity", ex);
                throw;
            }
        }

        protected override InterfaceBoardSectionMode UpdateEntity(InterfaceBoardSectionMode entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.gcsBinaryResource?.HasBeenModified == true)
                    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.InterfaceBoardSectionModeUid, sessionData, null);
                var mgr = new InterfaceBoardSectionModePDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.InterfaceBoardSectionModeUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    SaveGalaxyPanelModelMappings(sessionData, entity.InterfaceBoardSectionModeUid, entity.GalaxyPanelModelUids, saveParams);

                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.InterfaceBoardSectionModeUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardSectionModeRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void SaveGalaxyPanelModelMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, ICollection<Guid> panelModelIds, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingPanelModelMappings = _galaxyPanelModelInterfaceBoardSectionModeRepositoryMapRepository.GetAllGalaxyPanelModelInterfaceBoardSectionModesForMode(sessionData, getParameters);
            var existingPanelModelIds = new HashSet<Guid>(existingPanelModelMappings.Select(e => e.GalaxyPanelModelInterfaceBoardSectionModeUid));
            foreach (var existingPanelModelId in existingPanelModelIds)
            {
                if (!panelModelIds.Contains(existingPanelModelId))
                {
                    var deleteThisExistingPanelModelMap = (from eem in existingPanelModelMappings where eem.GalaxyPanelModelUid == existingPanelModelId select eem).FirstOrDefault();
                    if (deleteThisExistingPanelModelMap != null)
                        _galaxyPanelModelInterfaceBoardSectionModeRepositoryMapRepository.Remove(deleteThisExistingPanelModelMap.GalaxyPanelModelInterfaceBoardSectionModeUid, sessionData);
                }
            }
            foreach (var panelModelId in panelModelIds)
            {
                if (!existingPanelModelIds.Contains(panelModelId))
                {
                    var entityMap = new GalaxyPanelModelInterfaceBoardSectionMode();
                    entityMap.GalaxyPanelModelInterfaceBoardSectionModeUid = GuidUtilities.GenerateComb();
                    entityMap.GalaxyPanelModelUid = panelModelId;
                    entityMap.InterfaceBoardSectionModeUid = uid;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _galaxyPanelModelInterfaceBoardSectionModeRepositoryMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(InterfaceBoardSectionMode entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new InterfaceBoardSectionModePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.InterfaceBoardSectionModeUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardSectionModeRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new InterfaceBoardSectionModePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardSectionModeRepository::Remove", ex);
                throw;
            }
        }

        // GetAllInterfaceBoardSectionModes in a region
        protected override IEnumerable<InterfaceBoardSectionMode> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InterfaceBoardSectionModePDSAManager();
                mgr.DataObject.SelectFilter = InterfaceBoardSectionModePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardSectionModeRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<InterfaceBoardSectionMode> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, InterfaceBoardSectionModePDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (InterfaceBoardSectionMode entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<InterfaceBoardSectionMode> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InterfaceBoardSectionModePDSAManager();
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardSectionModeRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<InterfaceBoardSectionMode> GetAllGalaxyInterfaceBoardSectionModesForType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InterfaceBoardSectionModePDSAManager();
                mgr.DataObject.SelectFilter = InterfaceBoardSectionModePDSAData.SelectFilters.ByInterfaceBoardType;
                mgr.Entity.InterfaceBoardTypeUid = parameters.UniqueId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardRepository::GetAllGalaxyInterfaceBoardsForCluster", ex);
                throw;
            }
        }

        protected override InterfaceBoardSectionMode GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override InterfaceBoardSectionMode GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InterfaceBoardSectionModePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    InterfaceBoardSectionMode result = new InterfaceBoardSectionMode();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardSectionModeRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, InterfaceBoardSectionMode originalEntity, InterfaceBoardSectionMode newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "InterfaceBoardSectionModeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InterfaceBoardSectionModeUid;
                        mgr.Entity.RecordTag = newEntity.InterfaceBoardSectionModeUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "InterfaceBoardSectionModeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InterfaceBoardSectionModeUid;
                        mgr.Entity.RecordTag = newEntity.InterfaceBoardSectionModeUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "InterfaceBoardSectionModeUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.InterfaceBoardSectionModeUid;
                        mgr.Entity.RecordTag = originalEntity.InterfaceBoardSectionModeUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardSectionModeRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(InterfaceBoardSectionMode entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            {
                entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            }

            var cpuModelMaps = _galaxyPanelModelInterfaceBoardSectionModeRepositoryMapRepository.GetAllGalaxyPanelModelInterfaceBoardSectionModesForMode(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InterfaceBoardSectionModeUid });
            var cpuModelIds = (from e in cpuModelMaps select e.GalaxyPanelModelUid).ToList();
            entity.GalaxyPanelModelUids.AddRange(cpuModelIds);

        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("InterfaceBoardSectionMode", "InterfaceBoardSectionModeUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("InterfaceBoardSectionMode", "InterfaceBoardSectionModeUid", id);
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

        protected override bool IsEntityUnique(InterfaceBoardSectionMode entity)
        {
            var mgr = new IsInterfaceBoardSectionModeUniquePDSAManager();
            mgr.Entity.InterfaceBoardSectionModeUid = entity.InterfaceBoardSectionModeUid;
            mgr.Entity.InterfaceBoardTypeUid = entity.InterfaceBoardTypeUid;
            mgr.Entity.Description = entity.Description;
            mgr.Entity.ModeCode = entity.ModeCode;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("InterfaceBoardSectionMode", "InterfaceBoardSectionModeUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("InterfaceBoardSectionMode", "InterfaceBoardSectionModeUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
