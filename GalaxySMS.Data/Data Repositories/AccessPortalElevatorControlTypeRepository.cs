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
    [Export(typeof(IAccessPortalElevatorControlTypeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessPortalElevatorControlTypeRepository : DataRepositoryBase<AccessPortalElevatorControlType>,
        IAccessPortalElevatorControlTypeRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import] private IGcsResourceStringRepository _resourceStringRepository;

        [Import] private IAccessPortalElevatorControlTypePanelModelRepository _accessPortalElevatorControlTypePanelModelRepository; 

        protected override AccessPortalElevatorControlType AddEntity(AccessPortalElevatorControlType entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var mgr = new AccessPortalElevatorControlTypePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.AccessPortalElevatorControlTypeUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true, IncludePhoto = true });
                    if (result != null)
                    {
                        AccessPortalElevatorControlTypePanelModelMappings(sessionData,
                            entity.AccessPortalElevatorControlTypeUid,
                            entity.GalaxyPanelModelUids, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalElevatorControlTypeRepository::AddEntity", ex);
                throw;
            }
        }

        protected override AccessPortalElevatorControlType UpdateEntity(AccessPortalElevatorControlType entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.gcsBinaryResource?.HasBeenModified == true)
                    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.AccessPortalElevatorControlTypeUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false, IncludePhoto = true });
                var mgr = new AccessPortalElevatorControlTypePDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.AccessPortalElevatorControlTypeUid);
                    // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    AccessPortalElevatorControlTypePanelModelMappings(sessionData,
                        entity.AccessPortalElevatorControlTypeUid,
                        entity.GalaxyPanelModelUids, saveParams);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.AccessPortalElevatorControlTypeUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true, IncludePhoto = true });
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalElevatorControlTypeRepository::UpdateEntity", ex);
                throw;
            }
        }


        private void AccessPortalElevatorControlTypePanelModelMappings(IApplicationUserSessionDataHeader sessionData,
            Guid uid,
            ICollection<Guid> panelModelIds, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() {UniqueId = uid};
            var existingPanelModelMappings =
                _accessPortalElevatorControlTypePanelModelRepository
                    .GetAllAccessPortalElevatorControlTypePanelModelsForElevatorControlType(sessionData, getParameters);
            var existingPanelModelUids =
                new HashSet<Guid>(existingPanelModelMappings.Select(e => e.GalaxyPanelModelUid));
            foreach (var existingPanelModelUid in existingPanelModelUids)
            {
                if (!panelModelIds.Contains(existingPanelModelUid))
                {
                    var deleteThisExistingPanelModelMap = (from eem in existingPanelModelMappings
                        where eem.GalaxyPanelModelUid == existingPanelModelUid
                        select eem).FirstOrDefault();
                    if (deleteThisExistingPanelModelMap != null)
                        _accessPortalElevatorControlTypePanelModelRepository.Remove(
                            deleteThisExistingPanelModelMap.AccessPortalElevatorControlTypePanelModelUid,
                            sessionData);
                }
            }
            foreach (var panelModelUid in panelModelIds)
            {
                if (!existingPanelModelUids.Contains(panelModelUid))
                {
                    var modelMap = new AccessPortalElevatorControlTypePanelModel();
                    modelMap.AccessPortalElevatorControlTypePanelModelUid = GuidUtilities.GenerateComb();
                    modelMap.GalaxyPanelModelUid = panelModelUid;
                    modelMap.AccessPortalElevatorControlTypeUid = uid;
                    modelMap.UpdateDate = DateTimeOffset.Now;
                    modelMap.UpdateName = sessionData.UserName;
                    modelMap.InsertDate = DateTimeOffset.Now;
                    modelMap.InsertName = sessionData.UserName;

                    _accessPortalElevatorControlTypePanelModelRepository.Add(modelMap, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(AccessPortalElevatorControlType entity,
            IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new AccessPortalElevatorControlTypePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.AccessPortalElevatorControlTypeUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalElevatorControlTypeRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false, IncludePhoto = false });
                var mgr = new AccessPortalElevatorControlTypePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalElevatorControlTypeRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<AccessPortalElevatorControlType> GetEntities(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalElevatorControlTypePDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalElevatorControlTypePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalElevatorControlTypeRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<AccessPortalElevatorControlType> GetIEnumerable(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters,
            AccessPortalElevatorControlTypePDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (AccessPortalElevatorControlType entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludePhoto)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<AccessPortalElevatorControlType> GetAllEntities(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalElevatorControlTypePDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalElevatorControlTypePDSAData.SelectFilters.AllForCulture;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalElevatorControlTypeRepository::GetEntities", ex);
                throw;
            }
        }


        public IEnumerable<AccessPortalElevatorControlType> GetByAccessPortalUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessPortalElevatorControlTypePDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalElevatorControlTypePDSAData.SelectFilters.AllForAccessPortalUid;
                mgr.Entity.AccessPortalUid = parameters.UniqueId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalElevatorControlTypeRepository::GetByAccessPortalUid", ex);
                throw;
            }

        }

        public IEnumerable<AccessPortalElevatorControlType> GetByGalaxyPanelModelUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessPortalElevatorControlTypePDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalElevatorControlTypePDSAData.SelectFilters.AllForGalaxyPanelModelUid;
                mgr.Entity.GalaxyPanelModelUid = parameters.UniqueId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalElevatorControlTypeRepository::GetByGalaxyPanelModelUid", ex);
                throw;
            }
        }

        protected override AccessPortalElevatorControlType GetEntityByIntId(int id,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override AccessPortalElevatorControlType GetEntityByGuidId(Guid guid,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalElevatorControlTypePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    AccessPortalElevatorControlType result = new AccessPortalElevatorControlType();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludePhoto)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalElevatorControlTypeRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData,
            AccessPortalElevatorControlType originalEntity, AccessPortalElevatorControlType newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalElevatorControlTypeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessPortalElevatorControlTypeUid;
                        mgr.Entity.RecordTag = newEntity.AccessPortalElevatorControlTypeUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalElevatorControlTypeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessPortalElevatorControlTypeUid;
                        mgr.Entity.RecordTag = newEntity.AccessPortalElevatorControlTypeUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalElevatorControlTypeUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AccessPortalElevatorControlTypeUid;
                        mgr.Entity.RecordTag = originalEntity.AccessPortalElevatorControlTypeUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalElevatorControlTypeRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(AccessPortalElevatorControlType entity,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (getParameters.IncludePhoto && (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty))
            {
                entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData,
                    null);
            }

            if (getParameters.IncludeMemberCollections)
            {
                var modelUids = _accessPortalElevatorControlTypePanelModelRepository.GetAllAccessPortalElevatorControlTypePanelModelsForElevatorControlType(sessionData,
                new GetParametersWithPhoto() { UniqueId = entity.AccessPortalElevatorControlTypeUid });
                var ids = (from e in modelUids select e.GalaxyPanelModelUid).ToList();
                entity.GalaxyPanelModelUids.AddRange(ids);
            }
       }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("AccessPortalElevatorControlType",
                "AccessPortalElevatorControlTypeUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("AccessPortalElevatorControlType",
                "AccessPortalElevatorControlTypeUid", id);
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

        protected override bool IsEntityUnique(AccessPortalElevatorControlType entity)
        {
            var mgr = new IsAccessPortalElevatorControlTypeUniquePDSAManager();
            mgr.Entity.AccessPortalElevatorControlTypeUid = entity.AccessPortalElevatorControlTypeUid;
            mgr.Entity.Display = entity.Display;
            mgr.Entity.Code = entity.Code;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("AccessPortalElevatorControlType",
                "AccessPortalElevatorControlTypeUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("AccessPortalElevatorControlType",
                "AccessPortalElevatorControlTypeUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}