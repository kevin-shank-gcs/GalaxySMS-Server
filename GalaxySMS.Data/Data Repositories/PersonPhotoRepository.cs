using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
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
    [Export(typeof(IPersonPhotoRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonPhotoRepository : DataRepositoryBase<PersonPhoto>, IPersonPhotoRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;
        [Import] private IPersonPhotoScaledRepository _personPhotoScaledRepository;

        protected override PersonPhoto AddEntity(PersonPhoto entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.PersonPhotoUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::AddEntity", ex);
                throw;
            }
        }

        protected override PersonPhoto UpdateEntity(PersonPhoto entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.PersonPhotoUid, sessionData, null);
                var mgr = new PersonPhotoPDSAManager();


                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.PersonPhotoUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.PersonPhotoUid, sessionData, null);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.PersonUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::UpdateEntity", ex);
                throw;
            }
        }

        public PersonPhoto UpdatePublicUrl(IApplicationUserSessionDataHeader sessionData, PersonPhoto entity)
        {
            try
            {
                var mgr = new PersonPhotoPDSA_UpdatePublicUrlByPkPDSAManager();
                mgr.DataObject.Entity.PersonPhotoUid = entity.PersonPhotoUid;
                mgr.DataObject.Entity.ConcurrencyValue = entity.ConcurrencyValue.Value;
                mgr.DataObject.Entity.PublicUrl = entity.PublicUrl;
                mgr.Execute();
                return GetEntityByGuidId(entity.PersonPhotoUid, sessionData, null);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoScaledRepository::UpdateEntity", ex);
                throw;
            }
        }

        public PersonPhoto UpdateIsDefault(IApplicationUserSessionDataHeader sessionData, PersonPhoto entity)
        {
            try
            {
                var mgr = new PersonPhotoPDSA_UpdateIsDefaultByPkPDSAManager();
                mgr.DataObject.Entity.PersonPhotoUid = entity.PersonPhotoUid;
                mgr.DataObject.Entity.ConcurrencyValue = entity.ConcurrencyValue.Value;
                mgr.DataObject.Entity.IsDefault = entity.IsDefault;
                mgr.DataObject.Entity.UpdateDate = entity.UpdateDate.Value;
                mgr.DataObject.Entity.UpdateName = entity.UpdateName;
                mgr.Execute();
                return GetEntityByGuidId(entity.PersonPhotoUid, sessionData, null);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoScaledRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(PersonPhoto entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.PersonUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new PersonPhotoPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::Remove", ex);
                throw;
            }
        }

        // GetAllPersonPhotos in a region
        protected override IEnumerable<PersonPhoto> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<PersonPhoto> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, PersonPhotoPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (PersonPhoto entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludePhoto || getParameters.IncludeScaledPhotos)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<PersonPhoto> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<PersonPhoto> GetAllPersonPhotosForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                if (getParameters.OmitPhotoBinaryData)
                    mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.ByPersonUidOmitImage;
                else
                    mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.ByPersonUid;

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::GetAllPersonPhotosForPerson", ex);
                throw;
            }

        }

        public IEnumerable<PersonPhoto> GetAllPersonPhotoTagsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.ListForPerson;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::GetAllPersonPhotosForPerson", ex);
                throw;
            }

        }

        public PersonPhoto GetMostRecentPersonPhotoForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                if (getParameters.OmitPhotoBinaryData)
                    mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.ByPersonUidLastUpdatedOmitImage;
                else
                    mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.ByPersonUidLastUpdated;
                mgr.Entity.PersonUid = getParameters.PersonUid;
                var photos = GetIEnumerable(sessionData, getParameters, mgr);
                return photos.FirstOrDefault();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::GetMostRecentPersonPhotoForPerson", ex);
                throw;
            }

        }

        public PersonPhoto GetDefaultPersonPhotoForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                if (getParameters.OmitPhotoBinaryData)
                    mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.ByPersonUidIsDefaultOmitImage;
                else
                    mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.ByPersonUidIsDefault;
                mgr.Entity.PersonUid = getParameters.PersonUid;
                mgr.Entity.IsDefault = true;

                var photos = GetIEnumerable(sessionData, getParameters, mgr);
                return photos.FirstOrDefault();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::GetMostRecentPersonPhotoForPerson", ex);
                throw;
            }

        }


        public IEnumerable<PersonPhoto> GetAllPersonPhotosForTag(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.ByTag;
                mgr.Entity.Tag = getParameters.GetString;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::GetAllPersonPhotosForTag", ex);
                throw;
            }
        }


        public IEnumerable<PersonPhoto> GetAllPersonPhotosForPersonAndTag(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                mgr.DataObject.SelectFilter = PersonPhotoPDSAData.SelectFilters.ByPersonUidAndTag;
                mgr.Entity.PersonUid = getParameters.PersonUid;
                mgr.Entity.Tag = getParameters.GetString;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::GetAllPersonPhotosForPersonAndTag", ex);
                throw;
            }
        }

        protected override PersonPhoto GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override PersonPhoto GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPhotoPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    PersonPhoto result = new PersonPhoto();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, PersonPhoto originalEntity, PersonPhoto newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "PersonUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.PersonUid;
                        mgr.Entity.RecordTag = newEntity.PersonUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "PersonUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.PersonUid;
                        mgr.Entity.RecordTag = newEntity.PersonUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "PersonUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.PersonUid;
                        mgr.Entity.RecordTag = originalEntity.PersonUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonPhotoRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(PersonPhoto entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {

            if (getParameters != null && (getParameters.IncludePhoto || getParameters.IncludeScaledPhotos))
            {
                if (!getParameters.IncludeScaledPhotos)
                    getParameters.GetString = nameof(PhotoLinks.Small).ToLower();
                IEnumerable<PersonPhotoScaled> scaledPhotos = _personPhotoScaledRepository.GetAllForPersonPhoto(sessionData,
                    new GetParametersWithPhoto(getParameters) { UniqueId = entity.PersonPhotoUid });
                if (scaledPhotos != null)
                    entity.ScaledPhotos = scaledPhotos.ToCollection();
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("PersonPhoto", "PersonUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("PersonPhoto", "PersonUid", id);
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

        protected override bool IsEntityUnique(PersonPhoto entity)
        {
            return true;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("PersonPhoto", "PersonUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("PersonPhoto", "PersonUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForPersonPhotoPDSAManager
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

    }
}
