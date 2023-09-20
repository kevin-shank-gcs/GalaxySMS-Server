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
    [Export(typeof(IPersonalAccessGroupDynamicAccessGroupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonalAccessGroupDynamicAccessGroupRepository : DataRepositoryBase<PersonalAccessGroupDynamicAccessGroup>, IPersonalAccessGroupDynamicAccessGroupRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private IGcsBinaryResourceRepository _binaryResourceRepository;
        
        protected override PersonalAccessGroupDynamicAccessGroup AddEntity(PersonalAccessGroupDynamicAccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.PersonalAccessGroupDynamicAccessGroupUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::AddEntity", ex);
                throw;
            }
        }

        protected override PersonalAccessGroupDynamicAccessGroup UpdateEntity(PersonalAccessGroupDynamicAccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.PersonalAccessGroupDynamicAccessGroupUid, sessionData, null);
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.PersonalAccessGroupDynamicAccessGroupUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.PersonalAccessGroupDynamicAccessGroupUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(PersonalAccessGroupDynamicAccessGroup entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.PersonalAccessGroupDynamicAccessGroupUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::Remove", ex);
                throw;
            }
        }

        // GetAllPersonalAccessGroupDynamicAccessGroups in a region
        protected override IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonalAccessGroupDynamicAccessGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, PersonalAccessGroupDynamicAccessGroupPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (PersonalAccessGroupDynamicAccessGroup entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonalAccessGroupDynamicAccessGroupPDSAData.SelectFilters.ByPersonUid;
                if (parameters.PersonUid == Guid.Empty)
                    mgr.Entity.PersonUid = parameters.UniqueId;
                else
                    mgr.Entity.PersonUid = parameters.PersonUid;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::GetAllPersonalAccessGroupDynamicAccessGroupsForPerson", ex);
                throw;
            }
        }
        public IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForPersonAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonalAccessGroupDynamicAccessGroupPDSAData.SelectFilters.ByPersonUidAndClusterUid;
                if (parameters.PersonUid == Guid.Empty)
                    mgr.Entity.PersonUid = parameters.UniqueId;
                else
                    mgr.Entity.PersonUid = parameters.PersonUid;
                mgr.Entity.ClusterUid = parameters.ClusterUid;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::GetAllPersonalAccessGroupDynamicAccessGroupsForPersonAndCluster", ex);
                throw;
            }
        }
        public IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForPersonCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonalAccessGroupDynamicAccessGroupPDSAData.SelectFilters.ByPersonCredentialUid;
                mgr.Entity.PersonCredentialUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::GetAllPersonalAccessGroupDynamicAccessGroupsForPersonCredential", ex);
                throw;
            }
        }
        public IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForPersonCredentialAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonalAccessGroupDynamicAccessGroupPDSAData.SelectFilters.ByPersonCredentialUidAndClusterUid;
                mgr.Entity.PersonCredentialUid = parameters.UniqueId;
                mgr.Entity.ClusterUid = parameters.ClusterUid;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::GetAllPersonalAccessGroupDynamicAccessGroupsForPersonCredentialAndCluster", ex);
                throw;
            }
        }
        public IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForPersonClusterPermission(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonalAccessGroupDynamicAccessGroupPDSAData.SelectFilters.ByPersonClusterPermissionUid;
                mgr.Entity.PersonClusterPermissionUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::GetAllPersonalAccessGroupDynamicAccessGroupsForPersonClusterPermission", ex);
                throw;
            }
        }

        public IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForAccessGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonalAccessGroupDynamicAccessGroupPDSAData.SelectFilters.ByAccessGroupUid;
                mgr.Entity.AccessGroupUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::GetAllPersonalAccessGroupDynamicAccessGroupsForAccessGroup", ex);
                throw;
            }
        }
        
        public IEnumerable<PersonalAccessGroupDynamicAccessGroup> GetAllPersonalAccessGroupDynamicAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonalAccessGroupDynamicAccessGroupPDSAData.SelectFilters.ByClusterUid;
                if( parameters.ClusterUid == Guid.Empty)
                    mgr.Entity.ClusterUid = parameters.UniqueId;
                else
                    mgr.Entity.ClusterUid = parameters.ClusterUid;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::GetAllPersonalAccessGroupDynamicAccessGroupForTimeSchedule", ex);
                throw;
            }
        }
        protected override PersonalAccessGroupDynamicAccessGroup GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override PersonalAccessGroupDynamicAccessGroup GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonalAccessGroupDynamicAccessGroupPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    PersonalAccessGroupDynamicAccessGroup result = new PersonalAccessGroupDynamicAccessGroup();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, PersonalAccessGroupDynamicAccessGroup originalEntity, PersonalAccessGroupDynamicAccessGroup newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyValue = newEntity.PersonalAccessGroupDynamicAccessGroupUid;
                        mgr.Entity.RecordTag = newEntity.PersonalAccessGroupDynamicAccessGroupUid.ToString();
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
                        mgr.Entity.PrimaryKeyValue = newEntity.PersonalAccessGroupDynamicAccessGroupUid;
                        mgr.Entity.RecordTag = newEntity.PersonalAccessGroupDynamicAccessGroupUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyValue = originalEntity.PersonalAccessGroupDynamicAccessGroupUid;
                        mgr.Entity.RecordTag = originalEntity.PersonalAccessGroupDynamicAccessGroupUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonalAccessGroupDynamicAccessGroupRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(PersonalAccessGroupDynamicAccessGroup entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("PersonalAccessGroupDynamicAccessGroup", "ClusterTypeClusterCommandUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("PersonalAccessGroupDynamicAccessGroup", "ClusterTypeClusterCommandUid", id);
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

        protected override bool IsEntityUnique(PersonalAccessGroupDynamicAccessGroup entity)
        {
            var mgr = new IsPersonalAccessGroupDynamicAccessGroupUniquePDSAManager();
            mgr.Entity.PersonalAccessGroupDynamicAccessGroupUid = entity.PersonalAccessGroupDynamicAccessGroupUid;
            mgr.Entity.AccessGroupUid = entity.AccessGroupUid;
            mgr.Entity.PersonClusterPermissionUid = entity.PersonClusterPermissionUid;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("PersonalAccessGroupDynamicAccessGroup", "PersonalAccessGroupDynamicAccessGroupUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("PersonalAccessGroupDynamicAccessGroup", "PersonalAccessGroupDynamicAccessGroupUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
