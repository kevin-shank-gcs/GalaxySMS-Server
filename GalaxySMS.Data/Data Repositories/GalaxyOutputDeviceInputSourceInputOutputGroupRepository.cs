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
    [Export(typeof(IGalaxyOutputDeviceInputSourceInputOutputGroupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyOutputDeviceInputSourceInputOutputGroupRepository : DataRepositoryBase<GalaxyOutputDeviceInputSourceInputOutputGroup>, IGalaxyOutputDeviceInputSourceInputOutputGroupRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        protected override GalaxyOutputDeviceInputSourceInputOutputGroup AddEntity(GalaxyOutputDeviceInputSourceInputOutputGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceInputOutputGroupRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyOutputDeviceInputSourceInputOutputGroup UpdateEntity(GalaxyOutputDeviceInputSourceInputOutputGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid, sessionData, null);
                var mgr = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;
                    
                    // if GalaxyOutputDeviceInputSourceUid is = Guid.Empty or null, then use the value from the original record
                    entity.GalaxyOutputDeviceInputSourceUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.GalaxyOutputDeviceInputSourceUid, entity.GalaxyOutputDeviceInputSourceUid);

                    // if InputOutputGroupAssignmentUid is = Guid.Empty or null, then use the value from the original record
                    entity.InputOutputGroupUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InputOutputGroupUid, entity.InputOutputGroupUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceInputOutputGroupRepository::UpdateEntity", ex);
                throw;
            }
        }


        protected override int DeleteEntity(GalaxyOutputDeviceInputSourceInputOutputGroup entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceInputOutputGroupRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceInputOutputGroupRepository::Remove", ex);
                throw;
            }
        }

        // GetAllGalaxyOutputDeviceInputSourceInputOutputGroups in a region
        protected override IEnumerable<GalaxyOutputDeviceInputSourceInputOutputGroup> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyOutputDeviceInputSourceInputOutputGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceInputOutputGroupRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyOutputDeviceInputSourceInputOutputGroup> GetByGalaxyOutputDeviceInputSource(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyOutputDeviceInputSourceInputOutputGroupPDSAData.SelectFilters.ByGalaxyOutputDeviceInputSourceUid;
                mgr.Entity.GalaxyOutputDeviceInputSourceUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceInputOutputGroupRepository::GetByAccessPortalUid", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData> GetPanelLoadDataForInputSourceUid(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDevice_GetInputSource_InputOutputGroupMode_PanelLoadDataByGalaxyOutputDeviceInputSourceUidPDSAManager
                {
                    Entity = { GalaxyOutputDeviceInputSourceUid = getParameters.UniqueId }
                };
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = new List<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData>();
                    foreach (var entity in pdsaEntities)
                    {
                        var newEntity = new GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData();
                        SimpleMapper.PropertyMap(entity, newEntity);
                        entities.Add(newEntity);
                    }
                    return entities;
                }
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}"); //InputDeviceRepository::GetInputDevicePanelLoadData", ex);
                throw;
            }
            return null;        }

        private IEnumerable<GalaxyOutputDeviceInputSourceInputOutputGroup> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (GalaxyOutputDeviceInputSourceInputOutputGroup entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<GalaxyOutputDeviceInputSourceInputOutputGroup> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyOutputDeviceInputSourceInputOutputGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceInputOutputGroupRepository::GetEntities", ex);
                throw;
            }
        }

        protected override GalaxyOutputDeviceInputSourceInputOutputGroup GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyOutputDeviceInputSourceInputOutputGroup GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyOutputDeviceInputSourceInputOutputGroup result = new GalaxyOutputDeviceInputSourceInputOutputGroup();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceInputOutputGroupRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyOutputDeviceInputSourceInputOutputGroup originalEntity, GalaxyOutputDeviceInputSourceInputOutputGroup newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyOutputDeviceInputSourceInputOutputGroupUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyOutputDeviceInputSourceInputOutputGroupUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyOutputDeviceInputSourceInputOutputGroupUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyOutputDeviceInputSourceInputOutputGroupUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyOutputDeviceInputSourceInputOutputGroupUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyOutputDeviceInputSourceInputOutputGroupUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyOutputDeviceInputSourceInputOutputGroupRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyOutputDeviceInputSourceInputOutputGroup entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyOutputDeviceInputSourceInputOutputGroup", "GalaxyOutputDeviceInputSourceInputOutputGroupUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyOutputDeviceInputSourceInputOutputGroup", "GalaxyOutputDeviceInputSourceInputOutputGroupUid", id);
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

        protected override bool IsEntityUnique(GalaxyOutputDeviceInputSourceInputOutputGroup entity)
        {
            var mgr = new IsGalaxyOutputDeviceInputSourceInputOutputGroupUniquePDSAManager();
            mgr.Entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid = entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
            mgr.Entity.GalaxyOutputDeviceInputSourceUid = entity.GalaxyOutputDeviceInputSourceUid;
            mgr.Entity.InputOutputGroupUid = entity.InputOutputGroupUid;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyOutputDeviceInputSourceInputOutputGroup", "GalaxyOutputDeviceInputSourceInputOutputGroupUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyOutputDeviceInputSourceInputOutputGroup", "GalaxyOutputDeviceInputSourceInputOutputGroupUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
