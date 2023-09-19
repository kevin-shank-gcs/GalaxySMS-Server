using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Interfaces;
using GalaxySMS.Data.Contracts;
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
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace GalaxySMS.Data
{
    [Export(typeof(ICredentialFormatRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CredentialFormatRepository : DataRepositoryBase<CredentialFormat>, ICredentialFormatRepository, IPartImportsSatisfiedNotification
    {
        [Import] private ICredentialFormatEntityMapRepository _entityMapRepository;
        [Import] private ICredentialFormatDataFieldRepository _credentialFormatDataFieldRepository;
        [Import] private ICredentialFormatParityRepository _credentialFormatParityRepository;

        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        protected override CredentialFormat AddEntity(CredentialFormat entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var mgr = new CredentialFormatPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveFieldAndParityData(entity, sessionData, saveParams);
                    SaveEntityMappings(sessionData, entity.CredentialFormatUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.CredentialFormatUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialFormatRepository::AddEntity", ex);
                throw;
            }
        }

        protected override CredentialFormat UpdateEntity(CredentialFormat entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.CredentialFormatUid, sessionData, null);
                var mgr = new CredentialFormatPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.CredentialFormatUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    SaveFieldAndParityData(entity, sessionData, saveParams);
                    SaveEntityMappings(sessionData, entity.CredentialFormatUid, entity, saveParams);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.CredentialFormatUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialFormatRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(CredentialFormat entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new CredentialFormatPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.CredentialFormatUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialFormatRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new CredentialFormatPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialFormatRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<CredentialFormat> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, CredentialFormatPDSAManager mgr)
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

        // GetAllCredentialFormats for an Entity
        protected override IEnumerable<CredentialFormat> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new CredentialFormatPDSAManager();
                mgr.DataObject.SelectFilter = CredentialFormatPDSAData.SelectFilters.ByEntityId;
                mgr.Entity.EntityId = sessionData.CurrentEntityId;

                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialFormatRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<CredentialFormat> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new CredentialFormatPDSAManager();
                mgr.DataObject.SelectFilter = CredentialFormatPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialFormatRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<CredentialFormat> GetAllCredentialFormatsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new CredentialFormatPDSAManager();
                mgr.DataObject.SelectFilter = CredentialFormatPDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.Entity.EntityId = getParameters.UniqueId;
                else
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;

                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialFormatRepository::GetAllCredentialFormatsForEntity", ex);
                throw;
            }
        }

        protected override CredentialFormat GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override CredentialFormat GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new CredentialFormatPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    CredentialFormat result = new CredentialFormat();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialFormatRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        private void SaveFieldAndParityData(CredentialFormat entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = entity.CredentialFormatUid };
            var existingDataFields = _credentialFormatDataFieldRepository.GetAllCredentialFormatDataFieldsForCredentialFormat(sessionData, getParameters);
            var existingParities = _credentialFormatParityRepository.GetAllCredentialFormatParitiesForCredentialFormat(sessionData, getParameters);
            foreach (var df in entity.CredentialFormatDataFields)
            {
                if (df.IsDirty)
                {
                    UpdateTableEntityBaseProperties(df, sessionData);
                    if (df.CredentialFormatDataFieldUid == Guid.Empty)
                    {
                        df.CredentialFormatDataFieldUid = GuidUtilities.GenerateComb();
                        df.CredentialFormatUid = entity.CredentialFormatUid;
                        _credentialFormatDataFieldRepository.Add(df as CredentialFormatDataField, sessionData, saveParams);
                    }
                    else
                        _credentialFormatDataFieldRepository.Update(df as CredentialFormatDataField, sessionData, saveParams);

                }
            }

            foreach (var parity in entity.CredentialFormatParities)
            {
                if (parity.IsDirty)
                {
                    UpdateTableEntityBaseProperties(parity, sessionData);
                    if (parity.CredentialFormatParityUid == Guid.Empty)
                    {
                        parity.CredentialFormatParityUid = GuidUtilities.GenerateComb();
                        parity.CredentialFormatUid = entity.CredentialFormatUid;
                        _credentialFormatParityRepository.Add(parity as CredentialFormatParity, sessionData, saveParams);
                    }
                    else
                        _credentialFormatParityRepository.Update(parity as CredentialFormatParity, sessionData, saveParams);
                }
            }

            var deleteTheseDataFields = existingDataFields.Where(p => !entity.CredentialFormatDataFields.Any(p2 => p2.CredentialFormatDataFieldUid == p.CredentialFormatDataFieldUid));
            var deleteTheseParities = existingParities.Where(p => !entity.CredentialFormatParities.Any(p2 => p2.CredentialFormatParityUid == p.CredentialFormatParityUid));

            foreach (var df in deleteTheseDataFields)
                _credentialFormatDataFieldRepository.Remove(df.CredentialFormatDataFieldUid, sessionData);

            foreach (var parity in deleteTheseParities)
                _credentialFormatParityRepository.Remove(parity.CredentialFormatParityUid, sessionData);
        }
        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid,
            IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllCredentialFormatEntityMapsForCredentialFormat(sessionData,
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
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.CredentialFormatEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new CredentialFormatEntityMap();
                    entityMap.CredentialFormatEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.CredentialFormatUid = uid;
                    entityMap.EntityId = entityId;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;
                    entityMap.IsAllowed = true;
                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, CredentialFormat originalEntity, CredentialFormat newEntity, string auditXml)
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
                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "CredentialFormatUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.CredentialFormatUid;
                        mgr.Entity.RecordTag = newEntity.CredentialFormatUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "CredentialFormatUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.CredentialFormatUid;
                        mgr.Entity.RecordTag = newEntity.CredentialFormatUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "CredentialFormatUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.CredentialFormatUid;
                        mgr.Entity.RecordTag = originalEntity.CredentialFormatUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//CredentialFormatRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(CredentialFormat entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var p = new GetParametersWithPhoto() { UniqueId = entity.CredentialFormatUid };

            if( getParameters == null)
                return;
            if (!getParameters.IsExcluded(nameof(entity.EntityIds)))
            {
                var entityMaps =
                    _entityMapRepository.GetAllCredentialFormatEntityMapsForCredentialFormat(sessionData, p);
                var entityIds = (from e in entityMaps select e.EntityId).ToList();
                entity.EntityIds.AddRange(entityIds);
            }

            if (!getParameters.IsExcluded(nameof(entity.CredentialFormatDataFields)))
                entity.CredentialFormatDataFields = _credentialFormatDataFieldRepository.GetAllCredentialFormatDataFieldsForCredentialFormat(sessionData, p).ToCollection<ICredentialFormatDataField>();
            if (!getParameters.IsExcluded(nameof(entity.CredentialFormatParities)))
                entity.CredentialFormatParities = _credentialFormatParityRepository.GetAllCredentialFormatParitiesForCredentialFormat(sessionData, p).ToCollection<ICredentialFormatParity>();
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("CredentialFormat", "CredentialFormatUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("CredentialFormat", "CredentialFormatUid", id);
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

        protected override bool IsEntityUnique(CredentialFormat entity)
        {
            var mgr = new IsCredentialFormatUniquePDSAManager();
            mgr.Entity.CredentialFormatUid = entity.CredentialFormatUid;
            mgr.Entity.CredentialFormatCode = (short)entity.CredentialFormatCode;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("CredentialFormat", "CredentialFormatUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("CredentialFormat", "CredentialFormatUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }


    }
}
