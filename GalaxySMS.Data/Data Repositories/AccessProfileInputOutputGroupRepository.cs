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
    [Export(typeof(IAccessProfileInputOutputGroupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessProfileInputOutputGroupRepository : DataRepositoryBase<AccessProfileInputOutputGroup>, IAccessProfileInputOutputGroupRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private IGcsBinaryResourceRepository _binaryResourceRepository;
        
        protected override AccessProfileInputOutputGroup AddEntity(AccessProfileInputOutputGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new AccessProfileInputOutputGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.AccessProfileInputOutputGroupUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::AddEntity", ex);
                throw;
            }
        }

        protected override AccessProfileInputOutputGroup UpdateEntity(AccessProfileInputOutputGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.AccessProfileInputOutputGroupUid, sessionData, null);
                var mgr = new AccessProfileInputOutputGroupPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.AccessProfileInputOutputGroupUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if AccessProfileClusterUid is = Guid.Empty or null, then use the value from the original record
                    entity.AccessProfileClusterUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.AccessProfileClusterUid, entity.AccessProfileClusterUid);

                    // if InputOutputGroupUid is = Guid.Empty or null, then use the value from the original record
                    entity.InputOutputGroupUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.InputOutputGroupUid, entity.InputOutputGroupUid);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.AccessProfileInputOutputGroupUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.AccessProfileInputOutputGroupUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(AccessProfileInputOutputGroup entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new AccessProfileInputOutputGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.AccessProfileInputOutputGroupUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new AccessProfileInputOutputGroupPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::Remove", ex);
                throw;
            }
        }

        // GetAllAccessProfileInputOutputGroups in a region
        protected override IEnumerable<AccessProfileInputOutputGroup> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfileInputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessProfileInputOutputGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<AccessProfileInputOutputGroup> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessProfileInputOutputGroupPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (AccessProfileInputOutputGroup entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<AccessProfileInputOutputGroup> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfileInputOutputGroupPDSAManager();
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<AccessProfileInputOutputGroup> GetAllForAccessProfile(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessProfileInputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessProfileInputOutputGroupPDSAData.SelectFilters.ByAccessProfileUid;
                mgr.Entity.InputOutputGroupUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::GetAllForAccessProfile", ex);
                throw;
            }
        }

        public IEnumerable<AccessProfileInputOutputGroup> GetAllForAccessProfileCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessProfileInputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessProfileInputOutputGroupPDSAData.SelectFilters.ByAccessProfileClusterUid;
                mgr.Entity.AccessProfileClusterUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::GetAllForAccessProfileAndCluster", ex);
                throw;
            }
        }
        
        public IEnumerable<AccessProfileInputOutputGroup> GetAllForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessProfileInputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessProfileInputOutputGroupPDSAData.SelectFilters.ByClusterUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::GetAllForCluster", ex);
                throw;
            }
        }
        public IEnumerable<AccessProfileInputOutputGroup> GetAllForInputOutputGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessProfileInputOutputGroupPDSAManager();
                mgr.DataObject.SelectFilter = AccessProfileInputOutputGroupPDSAData.SelectFilters.ByInputOutputGroupUid;
                mgr.Entity.InputOutputGroupUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::GetAllForInputOutputGroup", ex);
                throw;
            }
        }
        protected override AccessProfileInputOutputGroup GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override AccessProfileInputOutputGroup GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessProfileInputOutputGroupPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    AccessProfileInputOutputGroup result = new AccessProfileInputOutputGroup();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, AccessProfileInputOutputGroup originalEntity, AccessProfileInputOutputGroup newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "ClusterTypeClusterCommandUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessProfileInputOutputGroupUid;
                        mgr.Entity.RecordTag = newEntity.AccessProfileInputOutputGroupUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "ClusterTypeClusterCommandUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessProfileInputOutputGroupUid;
                        mgr.Entity.RecordTag = newEntity.AccessProfileInputOutputGroupUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "ClusterTypeClusterCommandUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AccessProfileInputOutputGroupUid;
                        mgr.Entity.RecordTag = originalEntity.AccessProfileInputOutputGroupUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessProfileInputOutputGroupRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(AccessProfileInputOutputGroup entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("AccessProfileInputOutputGroup", "ClusterTypeClusterCommandUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("AccessProfileInputOutputGroup", "ClusterTypeClusterCommandUid", id);
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

        protected override bool IsEntityUnique(AccessProfileInputOutputGroup entity)
        {
            var mgr = new IsAccessProfileInputOutputGroupUniquePDSAManager();
            mgr.Entity.AccessProfileInputOutputGroupUid = entity.AccessProfileInputOutputGroupUid;
            mgr.Entity.AccessProfileClusterUid= entity.AccessProfileClusterUid;
            mgr.Entity.OrderNumber = entity.OrderNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("AccessProfileInputOutputGroup", "AccessProfileInputOutputGroupUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("AccessProfileInputOutputGroup", "AccessProfileInputOutputGroupUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
