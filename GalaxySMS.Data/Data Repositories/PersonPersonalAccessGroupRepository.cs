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
    [Export(typeof(IPersonPersonalAccessGroupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonPersonalAccessGroupRepository : DataRepositoryBase<PersonPersonalAccessGroup>, IPersonPersonalAccessGroupRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;

        protected override PersonPersonalAccessGroup AddEntity(PersonPersonalAccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.PersonClusterPermissionUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::AddEntity", ex);
                throw;
            }
        }

        protected override PersonPersonalAccessGroup UpdateEntity(PersonPersonalAccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.PersonClusterPermissionUid, sessionData, null);
                var mgr = new PersonPersonalAccessGroupPDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.PersonClusterPermissionUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.PersonClusterPermissionUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.PersonClusterPermissionUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::UpdateEntity", ex);
                throw;
            }
        }
        private void EnsureChildRecordsExist(PersonPersonalAccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            SaveAccessPortals(entity, sessionData, saveParams);
            SaveDynamicAccessGroups(entity, sessionData, saveParams);
        }

        private void SaveAccessPortals(PersonPersonalAccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            var personalAccessGroupAccessPortalRepository = _dataRepositoryFactory.GetDataRepository<IPersonalAccessGroupAccessPortalRepository>();
            //var personalAccessGroupDynamicAccessGroupRepository = _dataRepositoryFactory.GetDataRepository<IPersonalAccessGroupDynamicAccessGroupRepository>();

            var getParameters = new GetParametersWithPhoto()
            {
                UniqueId = entity.PersonClusterPermissionUid
            };

            var existingPersonalAccessGroupAccessPortals = personalAccessGroupAccessPortalRepository.GetAllPersonalAccessGroupAccessPortalsForPersonClusterPermission(sessionData, getParameters);

            //var deleteThesePersonalAccessGroupAccessPortals = existingPersonalAccessGroupAccessPortals.Where(p => entity.AccessPortalUids.All(p2 => p2 != p.AccessPortalUid)).ToList();
            //var addThesePersonalAccessGroupAccessPortals = entity.AccessPortalUids.Where(p => existingPersonalAccessGroupAccessPortals.All(p2 => p2.AccessPortalUid != p)).ToList();
            
            var deleteThesePersonalAccessGroupAccessPortals = existingPersonalAccessGroupAccessPortals.Where(p => entity.AccessPortals.All(p2 => p2.AccessPortalUid != p.AccessPortalUid)).ToList();
            var addThesePersonalAccessGroupAccessPortals = entity.AccessPortals.Where(p => existingPersonalAccessGroupAccessPortals.All(p2 => p2.AccessPortalUid != p.AccessPortalUid)).ToList();

            foreach (var addThisPersonalAccessGroupAccessPortal in addThesePersonalAccessGroupAccessPortals)
            {
                var pagAp = new PersonalAccessGroupAccessPortal();
                pagAp.AccessPortalUid = addThisPersonalAccessGroupAccessPortal.AccessPortalUid;
                pagAp.PersonClusterPermissionUid = entity.PersonClusterPermissionUid;
                pagAp.PersonalAccessGroupAccessPortalUid = GuidUtilities.GenerateComb();

                UpdateTableEntityBaseProperties(pagAp, sessionData);
                personalAccessGroupAccessPortalRepository.Add(pagAp, sessionData, saveParams);
            }

            foreach (var deleteThisPersonalAccessGroupAccessPortal in deleteThesePersonalAccessGroupAccessPortals)
            {
                personalAccessGroupAccessPortalRepository.Remove(deleteThisPersonalAccessGroupAccessPortal.PersonalAccessGroupAccessPortalUid, sessionData);
            }
        }

        private void SaveDynamicAccessGroups(PersonPersonalAccessGroup entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            var personalAccessGroupDynamicAccessGroupRepository = _dataRepositoryFactory.GetDataRepository<IPersonalAccessGroupDynamicAccessGroupRepository>();

            var getParameters = new GetParametersWithPhoto()
            {
                UniqueId = entity.PersonClusterPermissionUid
            };

            var existingPersonalAccessGroupDynamicAccessGroups = personalAccessGroupDynamicAccessGroupRepository.GetAllPersonalAccessGroupDynamicAccessGroupsForPersonClusterPermission(sessionData, getParameters);

            //var deleteThesePersonalAccessGroupDynamicAccessGroups = existingPersonalAccessGroupDynamicAccessGroups.Where(p => entity.DynamicAccessGroupUids.All(p2 => p2 != p.AccessGroupUid)).ToList();
            //var addThesePersonalAccessGroupDynamicAccessGroups = entity.DynamicAccessGroupUids.Where(p => existingPersonalAccessGroupDynamicAccessGroups.All(p2 => p2.AccessGroupUid != p)).ToList();
            var deleteThesePersonalAccessGroupDynamicAccessGroups = existingPersonalAccessGroupDynamicAccessGroups.Where(p => entity.DynamicAccessGroups.All(p2 => p2.AccessGroupUid != p.AccessGroupUid)).ToList();
            var addThesePersonalAccessGroupDynamicAccessGroups = entity.DynamicAccessGroups.Where(p => existingPersonalAccessGroupDynamicAccessGroups.All(p2 => p2.AccessGroupUid != p.AccessGroupUid)).ToList();

            foreach (var addThisPersonalAccessGroupAccessGroup in addThesePersonalAccessGroupDynamicAccessGroups)
            {
                var pagAg = new PersonalAccessGroupDynamicAccessGroup();
                pagAg.AccessGroupUid = addThisPersonalAccessGroupAccessGroup.AccessGroupUid;
                pagAg.PersonClusterPermissionUid = entity.PersonClusterPermissionUid;
                pagAg.PersonalAccessGroupDynamicAccessGroupUid = GuidUtilities.GenerateComb();

                UpdateTableEntityBaseProperties(pagAg, sessionData);
                personalAccessGroupDynamicAccessGroupRepository.Add(pagAg, sessionData, saveParams);
            }

            foreach (var deleteThisPersonalAccessGroupDynamicAccessGroup in deleteThesePersonalAccessGroupDynamicAccessGroups)
            {
                personalAccessGroupDynamicAccessGroupRepository.Remove(deleteThisPersonalAccessGroupDynamicAccessGroup.PersonalAccessGroupDynamicAccessGroupUid, sessionData);
            }
        }

        protected override int DeleteEntity(PersonPersonalAccessGroup entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.PersonClusterPermissionUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new PersonPersonalAccessGroupPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<PersonPersonalAccessGroup> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonPersonalAccessGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<PersonPersonalAccessGroup> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, PersonPersonalAccessGroupPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (PersonPersonalAccessGroup entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<PersonPersonalAccessGroup> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonPersonalAccessGroupPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonPersonalAccessGroupPDSAData.SelectFilters.ByPersonUid;
                mgr.Entity.PersonUid = getParameters.PersonUid;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetAllPersonPersonalAccessGroupsForPerson", ex);
                throw;
            }
        }

        public IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForPersonAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonPersonalAccessGroupPDSAData.SelectFilters.ByPersonUidAndClusterUid;
                mgr.Entity.ClusterUid = getParameters.ClusterUid;
                mgr.Entity.PersonUid = getParameters.PersonUid;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetAllPersonPersonalAccessGroupsForPerson", ex);
                throw;
            }
        }

        public IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForPersonClusterPermission(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonPersonalAccessGroupPDSAData.SelectFilters.ByPersonClusterPermissionUid;
                mgr.Entity.PersonClusterPermissionUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetAllPersonPersonalAccessGroupsForPersonClusterPermission", ex);
                throw;
            }

        }
        public IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonPersonalAccessGroupPDSAData.SelectFilters.ByClusterUid;
                mgr.Entity.ClusterUid = getParameters.ClusterUid;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetAllPersonPersonalAccessGroupsForCluster", ex);
                throw;
            }

        }
        public IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForPersonCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonPersonalAccessGroupPDSAData.SelectFilters.ByPersonCredentialUid;
                mgr.Entity.PersonCredentialUid = getParameters.UniqueId;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetAllPersonPersonalAccessGroupsForPersonCredential", ex);
                throw;
            }
        }

        public IEnumerable<PersonPersonalAccessGroup> GetAllPersonPersonalAccessGroupsForPersonCredentialAndCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                mgr.DataObject.SelectFilter = PersonPersonalAccessGroupPDSAData.SelectFilters.ByPersonCredentialUidAndClusterUid;
                mgr.Entity.PersonCredentialUid = getParameters.UniqueId;
                mgr.Entity.ClusterUid = getParameters.ClusterUid;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetAllPersonPersonalAccessGroupsForPersonCredentialAndCluster", ex);
                throw;
            }
        }

        public int GetAvailablePersonalAccessGroupNumber(Guid clusterUid)
        {
            try
            {
                var mgr = new ChooseAvailablePersonalAccessGroupNumberPDSAManager();
                mgr.Entity.ClusterUid = clusterUid;
                var results = mgr.BuildCollection();
                if (results != null && results.Count == 1)
                    return results[0].PersonalAccessGroupNumber;
                return GalaxySMS.Common.Constants.PersonalAccessGroupDatabaseLimits.None;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetAvailablePersonalAccessGroupNumber", ex);
                throw;
            }

        }
        protected override PersonPersonalAccessGroup GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override PersonPersonalAccessGroup GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPersonalAccessGroupPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    PersonPersonalAccessGroup result = new PersonPersonalAccessGroup();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, PersonPersonalAccessGroup originalEntity, PersonPersonalAccessGroup newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "PersonClusterPermissionUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.PersonClusterPermissionUid;
                        mgr.Entity.RecordTag = newEntity.PersonClusterPermissionUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "PersonClusterPermissionUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.PersonClusterPermissionUid;
                        mgr.Entity.RecordTag = newEntity.PersonClusterPermissionUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "PersonClusterPermissionUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.PersonClusterPermissionUid;
                        mgr.Entity.RecordTag = originalEntity.PersonClusterPermissionUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPersonalAccessGroupRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(PersonPersonalAccessGroup entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var personalAccessGroupAccessPortalRepository = _dataRepositoryFactory.GetDataRepository<IPersonalAccessGroupAccessPortalRepository>();
            var personalAccessGroupDynamicAccessGroupRepository = _dataRepositoryFactory.GetDataRepository<IPersonalAccessGroupDynamicAccessGroupRepository>();

            if (getParameters == null)
                getParameters = new GetParametersWithPhoto();
            getParameters.UniqueId = entity.PersonClusterPermissionUid;
            var personalAccessGroupAccessPortals = personalAccessGroupAccessPortalRepository.GetAllPersonalAccessGroupAccessPortalsForPersonClusterPermission(sessionData, getParameters);
            var personalAccessGroupDynamicAccessGroups = personalAccessGroupDynamicAccessGroupRepository.GetAllPersonalAccessGroupDynamicAccessGroupsForPersonClusterPermission(sessionData, getParameters);

            //entity.AccessPortalUids = personalAccessGroupAccessPortals.Select(o => o.AccessPortalUid).ToCollection();
            //entity.DynamicAccessGroupUids = personalAccessGroupDynamicAccessGroups.Select(o => o.AccessGroupUid).ToCollection();

            foreach (var ap in personalAccessGroupAccessPortals)
            {
                entity.AccessPortals.Add(ap.ToAccessPortalUidItem());
            }

            foreach (var ag in personalAccessGroupDynamicAccessGroups)
            {
                entity.DynamicAccessGroups.Add(ag.ToAccessGroupUidItem());
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("PersonPersonalAccessGroup", "PersonUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("PersonPersonalAccessGroup", "PersonUid", id);
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

        protected override bool IsEntityUnique(PersonPersonalAccessGroup entity)
        {
            var mgr = new IsPersonPersonalAccessGroupUniquePDSAManager();
            mgr.Entity.PersonClusterPermissionUid = entity.PersonClusterPermissionUid;
            mgr.Entity.ClusterUid = entity.ClusterUid;
            mgr.Entity.PersonalAccessGroupNumber = entity.PersonalAccessGroupNumber;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("PersonPersonalAccessGroup", "PersonUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("PersonPersonalAccessGroup", "PersonUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
