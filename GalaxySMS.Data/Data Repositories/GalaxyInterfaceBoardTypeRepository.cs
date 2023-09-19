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
    [Export(typeof(IGalaxyInterfaceBoardTypeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InterfaceBoardTypeRepository : DataRepositoryBase<InterfaceBoardType>, IGalaxyInterfaceBoardTypeRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import]
        private IGalaxyPanelModelInterfaceBoardTypeRepository _galaxyPanelModelInterfaceBoardTypeRepositoryMapRepository;

        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        [Import]
        private IGcsBinaryResourceRepository _binaryResourceRepository;

        protected override InterfaceBoardType AddEntity(InterfaceBoardType entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);


                var mgr = new InterfaceBoardTypePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveGalaxyPanelModelMappings(sessionData, entity.InterfaceBoardTypeUid, entity.GalaxyPanelModelUids, saveParams);
                    var result = GetEntityByGuidId(entity.InterfaceBoardTypeUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardTypeRepository::AddEntity", ex);
                throw;
            }
        }

        protected override InterfaceBoardType UpdateEntity(InterfaceBoardType entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.gcsBinaryResource?.HasBeenModified == true)
                    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.InterfaceBoardTypeUid, sessionData, null);
                var mgr = new InterfaceBoardTypePDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.InterfaceBoardTypeUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    SaveGalaxyPanelModelMappings(sessionData, entity.InterfaceBoardTypeUid, entity.GalaxyPanelModelUids, saveParams);

                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.InterfaceBoardTypeUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardTypeRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void SaveGalaxyPanelModelMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, ICollection<Guid> panelModelIds, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingPanelModelMappings = _galaxyPanelModelInterfaceBoardTypeRepositoryMapRepository.GetAllGalaxyPanelModelInterfaceBoardTypesForType(sessionData, getParameters);
            var existingPanelModelIds = new HashSet<Guid>(existingPanelModelMappings.Select(e => e.GalaxyPanelModelInterfaceBoardTypeUid));
            foreach (var existingPanelModelId in existingPanelModelIds)
            {
                if (!panelModelIds.Contains(existingPanelModelId))
                {
                    var deleteThisExistingPanelModelMap = (from eem in existingPanelModelMappings where eem.GalaxyPanelModelUid == existingPanelModelId select eem).FirstOrDefault();
                    if (deleteThisExistingPanelModelMap != null)
                        _galaxyPanelModelInterfaceBoardTypeRepositoryMapRepository.Remove(deleteThisExistingPanelModelMap.GalaxyPanelModelInterfaceBoardTypeUid, sessionData);
                }
            }
            foreach (var panelModelId in panelModelIds)
            {
                if (!existingPanelModelIds.Contains(panelModelId))
                {
                    var entityMap = new GalaxyPanelModelInterfaceBoardType();
                    entityMap.GalaxyPanelModelInterfaceBoardTypeUid = GuidUtilities.GenerateComb();
                    entityMap.GalaxyPanelModelUid = panelModelId;
                    entityMap.InterfaceBoardTypeUid = uid;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _galaxyPanelModelInterfaceBoardTypeRepositoryMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(InterfaceBoardType entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new InterfaceBoardTypePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.InterfaceBoardTypeUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardTypeRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new InterfaceBoardTypePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardTypeRepository::Remove", ex);
                throw;
            }
        }

        // GetAllInterfaceBoardTypes in a region
        protected override IEnumerable<InterfaceBoardType> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InterfaceBoardTypePDSAManager();
                mgr.DataObject.SelectFilter = InterfaceBoardTypePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardTypeRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<InterfaceBoardType> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, InterfaceBoardTypePDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (InterfaceBoardType entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<InterfaceBoardType> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InterfaceBoardTypePDSAManager();
                mgr.DataObject.SelectFilter = InterfaceBoardTypePDSAData.SelectFilters.AllForCulture;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardTypeRepository::GetEntities", ex);
                throw;
            }
        }
        
        protected override InterfaceBoardType GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override InterfaceBoardType GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InterfaceBoardTypePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    InterfaceBoardType result = new InterfaceBoardType();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardTypeRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, InterfaceBoardType originalEntity, InterfaceBoardType newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "InterfaceBoardTypeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InterfaceBoardTypeUid;
                        mgr.Entity.RecordTag = newEntity.InterfaceBoardTypeUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "InterfaceBoardTypeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InterfaceBoardTypeUid;
                        mgr.Entity.RecordTag = newEntity.InterfaceBoardTypeUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "InterfaceBoardTypeUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.InterfaceBoardTypeUid;
                        mgr.Entity.RecordTag = originalEntity.InterfaceBoardTypeUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InterfaceBoardTypeRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(InterfaceBoardType entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            {
                entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            }

            var panelModelInterfaceBoards = _galaxyPanelModelInterfaceBoardTypeRepositoryMapRepository.GetAllGalaxyPanelModelInterfaceBoardTypesForType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.InterfaceBoardTypeUid }).ToCollection();
            entity.GalaxyPanelModelUids.AddRange(panelModelInterfaceBoards.Select(i => i.GalaxyPanelModelUid).ToArray());

        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("InterfaceBoardType", "InterfaceBoardTypeUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("InterfaceBoardType", "InterfaceBoardTypeUid", id);
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

        protected override bool IsEntityUnique(InterfaceBoardType entity)
        {
            var mgr = new IsInterfaceBoardTypeUniquePDSAManager();
            mgr.Entity.InterfaceBoardTypeUid = entity.InterfaceBoardTypeUid;
            mgr.Entity.Description = entity.Description;
            mgr.Entity.TypeCode = entity.TypeCode;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("InterfaceBoardType", "InterfaceBoardTypeUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("InterfaceBoardType", "InterfaceBoardTypeUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
