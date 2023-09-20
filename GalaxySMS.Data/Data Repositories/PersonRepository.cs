using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Reflection;
using GCS.Core.Common.Shared.Utils;
using GCS.Core.Common.Utils;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using PersonClusterPermission = GalaxySMS.Business.Entities.PersonClusterPermission;

namespace GalaxySMS.Data
{
    [Export(typeof(IPersonRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonRepository : DataRepositoryBase<Person>, IPersonRepository, IPartImportsSatisfiedNotification
    {
        private int _thumbnailPixelWidth = 200;
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private IPersonEntityMapRepository _entityMapRepository;

        protected override Person AddEntity(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                //if (entity.PersonActiveStatusTypeUid == null)
                //    entity.PersonActiveStatusTypeUid = GalaxySMS.Common.Constants.PersonActiveStatusTypeIds.Active;
                if (entity.PersonRecordTypeUid.HasValue && entity.PersonRecordTypeUid == Guid.Empty)
                {
                    var gcsSettingsRepository = _dataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();

                    var defaultRecordTypeUid = gcsSettingsRepository.GetByUniqueKey(entity.EntityId,
                        gcsSettingGroup.gcsEntity, gcsSettingSubGroup.Person, gcsSettingKey.DefaultPersonRecordTypeUid,
                        Guid.Empty, false, sessionData);
                    if (defaultRecordTypeUid != Guid.Empty)
                    {
                        entity.PersonRecordTypeUid = defaultRecordTypeUid;
                    }
                }
                var mgr = new PersonPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.PersonUid, entity, saveParams);
                    var result = GetEntityByGuidId(entity.PersonUid, sessionData, new GetParametersWithPhoto()
                    {
                        IncludePhoto = true,
                        PhotoPixelWidth = _thumbnailPixelWidth,
                    });

                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                        if (entity.PersonAccessControlProperty != null) // Force this one properties IsDirty property to true to ensure that it gets saved/created 
                            entity.PersonAccessControlProperty.IsDirty = true;

                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        result = GetEntityByGuidId(entity.PersonUid, sessionData, new GetParametersWithPhoto()
                        {
                            IncludePhoto = true,
                            PhotoPixelWidth = 0,//_thumbnailPixelWidth,
                            IncludeMemberCollections = true,
                            OmitPhotoBinaryData = true
                        });
                        UpdateEntityCount(result.EntityId);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::AddEntity", ex);
                throw;
            }
        }

        protected override Person UpdateEntity(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                var p = new GetParametersWithPhoto();
                p.IncludePhoto = true;
                p.PhotoPixelWidth = _thumbnailPixelWidth;
                var originalEntity = GetEntityByGuidId(entity.PersonUid, sessionData, p);
                var mgr = new PersonPDSAManager();

                // PDSA Audit Tracking setup phase
                if (mgr.DataObject.LoadByPK(entity.PersonUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    entity.InsertDate = mgr.Entity.InsertDate;
                    entity.InsertName = mgr.Entity.InsertName;

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId =
                        GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);

                    if (entity.PersonRecordTypeUid.HasValue && entity.PersonRecordTypeUid.Value == Guid.Empty)
                    {
                       entity.PersonRecordTypeUid = originalEntity.PersonRecordTypeUid;
                    }

                    //// if PersonActiveStatusTypeUid is = Guid.Empty or null, then use the value from the original record
                    //entity.PersonActiveStatusTypeUid = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.PersonActiveStatusTypeUid, entity.PersonActiveStatusTypeUid);

                    //if (string.IsNullOrEmpty(entity.PersonId))
                    //    entity.PersonId = mgr.Entity.PersonId;

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = 0;
                    rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.PersonUid, entity, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.PersonUid, sessionData, p);
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                            mgr.DataObject.AuditRowAsXml);
                        EnsureChildRecordsExist(entity, sessionData, saveParams);
                        updatedEntity = GetEntityByGuidId(entity.PersonUid, sessionData, new GetParametersWithPhoto()
                        {
                            IncludePhoto = true,
                            PhotoPixelWidth = 0, //_thumbnailPixelWidth,
                            IncludeMemberCollections = true,
                            OmitPhotoBinaryData = true
                        });
                        UpdateEntityCount(entity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);

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
            catch (DataValidationException dve)
            {
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(Person entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                EnsureChildRecordsAreDeleted(entity, sessionData);
                var mgr = new PersonPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.PersonUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                    UpdateEntityCount(entity.EntityId);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, new GetParametersWithPhoto());
                EnsureChildRecordsAreDeleted(originalEntity, sessionData);
                var mgr = new PersonPDSAManager();

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
                        UpdateEntityCount(originalEntity.EntityId);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<Person> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, PersonPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (getParameters == null || getParameters.IncludePhoto || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        // GetAllPersons for an Entity
        protected override IEnumerable<Person> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPDSAManager();
                mgr.DataObject.SelectFilter = PersonPDSAData.SelectFilters.ByEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<Person> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPDSAManager();
                mgr.DataObject.SelectFilter = PersonPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetAllEntities", ex);
                throw;
            }
        }

        public IEnumerable<Person> GetAllPersonsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPDSAManager();
                mgr.DataObject.SelectFilter = PersonPDSAData.SelectFilters.ByEntityId;
                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                else
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetAllPersonsForEntity", ex);
                throw;
            }
        }

        public IEnumerable<PersonSummary> SearchForPersonSummary(IApplicationUserSessionDataHeader sessionData, PersonSummarySearchParameters parameters)
        {
            var data = SearchForPersonSummaryPaged(sessionData, parameters);
            if (data != null)
                return data.Items;
            return null;
        }

        public ArrayResponse<PersonSummary> SearchForPersonSummaryPaged(IApplicationUserSessionDataHeader sessionData, PersonSummarySearchParameters getParameters)
        {
            try
            {
                if (getParameters.SearchType == PersonSearchType.AdvancedSearch)
                {
                    return AdvancedSearchForPersonSummaryPaged(sessionData, getParameters);
                }
                var mgr = new PersonSummary_SearchWithParamsPDSAManager();
                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                else
                    mgr.Entity.EntityId = getParameters.UniqueId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                mgr.Entity.PageNumber = getParameters.PageNumber;
                mgr.Entity.PageSize = getParameters.PageSize;
                switch (getParameters.TextSearchType)
                {
                    case TextSearchType.Equals:
                        mgr.Entity.ExactMatch = 1;
                        break;

                    case TextSearchType.StartsWith:
                        break;

                    case TextSearchType.Contains:
                        mgr.Entity.AnywhereWithin = 1;
                        break;
                }

                switch (getParameters.MultipleFieldSearchRelationship)
                {
                    case Common.Shared.Enums.AndOr.AND:
                        break;

                    case Common.Shared.Enums.AndOr.OR:
                        mgr.Entity.OrNotAnd = 1;
                        break;
                }

                switch (getParameters.SearchType)
                {
                    case Common.Enums.PersonSearchType.AllRecords:
                        break;
                    case Common.Enums.PersonSearchType.ByPersonUid:
                        mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.PersonUid.ToString()}";
                        mgr.Entity.SearchData1 = getParameters.PersonUid.ToString();
                        break;
                    case Common.Enums.PersonSearchType.ByPersonId:
                        mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.PersonId.ToString();
                        mgr.Entity.SearchData1 = getParameters.GetString;
                        break;
                    case Common.Enums.PersonSearchType.ByPersonActiveStatusTypeUid:
                        mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.PersonActiveStatusTypeUid.ToString()}";
                        mgr.Entity.SearchData1 = getParameters.GetGuid.ToString();
                        break;
                    case Common.Enums.PersonSearchType.ByDepartmentUid:
                        mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.DepartmentUid.ToString()}";
                        mgr.Entity.SearchData1 = getParameters.GetGuid.ToString();
                        break;
                    case Common.Enums.PersonSearchType.ByPersonRecordTypeUid:
                        mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.PersonRecordTypeUid.ToString()}";
                        mgr.Entity.SearchData1 = getParameters.GetGuid.ToString();
                        break;
                    case Common.Enums.PersonSearchType.ByLastFirstName:
                        if (!string.IsNullOrEmpty(getParameters.LastName))
                        {
                            mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.LastName.ToString();
                            mgr.Entity.SearchData1 = getParameters.LastName;
                            if (!string.IsNullOrEmpty(getParameters.FirstName))
                            {
                                mgr.Entity.SearchByColumnName2 = PersonStandardPropertyNames.FirstName.ToString();
                                mgr.Entity.SearchData2 = getParameters.FirstName;
                            }
                        }
                        else if (!string.IsNullOrEmpty(getParameters.FirstName))
                        {
                            mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.FirstName.ToString();
                            mgr.Entity.SearchData1 = getParameters.FirstName;
                        }
                        break;

                    case PersonSearchType.ByAnyNameField:
                        mgr.Entity.OrNotAnd = 1;
                        if (string.IsNullOrEmpty(getParameters.GetString))
                            getParameters.GetString = getParameters.LastName;
                        if (string.IsNullOrEmpty(getParameters.GetString))
                            getParameters.GetString = getParameters.FirstName;

                        mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.LastName.ToString();
                        mgr.Entity.SearchByColumnName2 = PersonStandardPropertyNames.FirstName.ToString();
                        mgr.Entity.SearchByColumnName3 = PersonStandardPropertyNames.MiddleName.ToString();
                        mgr.Entity.SearchByColumnName4 = PersonStandardPropertyNames.FullName.ToString();
                        mgr.Entity.SearchByColumnName5 = PersonStandardPropertyNames.LegalName.ToString();
                        mgr.Entity.SearchByColumnName6 = PersonStandardPropertyNames.PreferredName.ToString();
                        mgr.Entity.SearchByColumnName7 = PersonStandardPropertyNames.NickName.ToString();
                        mgr.Entity.SearchData1 = getParameters.GetString;
                        mgr.Entity.SearchData2 = getParameters.GetString;
                        mgr.Entity.SearchData3 = getParameters.GetString;
                        mgr.Entity.SearchData4 = getParameters.GetString;
                        mgr.Entity.SearchData5 = getParameters.GetString;
                        mgr.Entity.SearchData6 = getParameters.GetString;
                        mgr.Entity.SearchData7 = getParameters.GetString;
                        break;

                    case Common.Enums.PersonSearchType.ByFields:
                        mgr.Entity.SearchByColumnName1 = getParameters.PropertyName;
                        mgr.Entity.SearchData1 = getParameters.GetString;

                        if (getParameters.SearchTextValues?.Count > 0 && getParameters.PropertyNames?.Count == getParameters.SearchTextValues?.Count)
                        {
                            for (int x = 0; x < getParameters.PropertyNames.Count; x++)
                            {
                                switch (x)
                                {
                                    case 0:
                                        mgr.Entity.SearchByColumnName2 = getParameters.PropertyNames[x];
                                        mgr.Entity.SearchData2 = getParameters.SearchTextValues[x];
                                        break;

                                    case 1:
                                        mgr.Entity.SearchByColumnName3 = getParameters.PropertyNames[x];
                                        mgr.Entity.SearchData3 = getParameters.SearchTextValues[x];
                                        break;
                                    case 2:
                                        mgr.Entity.SearchByColumnName4 = getParameters.PropertyNames[x];
                                        mgr.Entity.SearchData4 = getParameters.SearchTextValues[x];
                                        break;
                                    case 3:
                                        mgr.Entity.SearchByColumnName5 = getParameters.PropertyNames[x];
                                        mgr.Entity.SearchData5 = getParameters.SearchTextValues[x];
                                        break;
                                    case 4:
                                        mgr.Entity.SearchByColumnName6 = getParameters.PropertyNames[x];
                                        mgr.Entity.SearchData6 = getParameters.SearchTextValues[x];
                                        break;
                                    case 5:
                                        mgr.Entity.SearchByColumnName7 = getParameters.PropertyNames[x];
                                        mgr.Entity.SearchData7 = getParameters.SearchTextValues[x];
                                        break;
                                    case 6:
                                        mgr.Entity.SearchByColumnName8 = getParameters.PropertyNames[x];
                                        mgr.Entity.SearchData8 = getParameters.SearchTextValues[x];
                                        break;
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(getParameters.DateComparisonOperator))
                            getParameters.DateComparisonOperator = GalaxySMS.Common.Constants.ComparisonOperatorsSql.GreaterOrEqual;
                        mgr.Entity.DateComparisonType = getParameters.DateComparisonOperator;
                        break;
                    case Common.Enums.PersonSearchType.ByCredentialNumber:
                        mgr.Entity.SearchByColumnName1 = "ByCredentialNumber";
                        mgr.Entity.SearchData1 = getParameters.SearchCredential.CardNumber;
                        break;
                    case Common.Enums.PersonSearchType.ByCredentialFieldValues:
                        switch (getParameters.SearchCredential.CredentialFormat.CredentialFormatCode)
                        {
                            case CredentialFormatCodes.Standard26Bit:
                            case CredentialFormatCodes.Corporate1K35Bit:
                            case CredentialFormatCodes.PIV75Bit:
                            case CredentialFormatCodes.Bqt36Bit:
                            case CredentialFormatCodes.XceedId40Bit:
                            case CredentialFormatCodes.Corporate1K48Bit:
                            case CredentialFormatCodes.Cypress37Bit:
                            case CredentialFormatCodes.H1030437Bit:
                            case CredentialFormatCodes.SoftwareHouse37Bit:
                            case CredentialFormatCodes.H1030237Bit:
                                mgr.Entity.SearchByColumnName1 = "ByCredentialFieldValues";
                                mgr.Entity.SearchData1 = getParameters.SearchCredential.CredentialFormatCodeAndPartsString;
                                break;

                            case CredentialFormatCodes.NumericCardCode:
                            case CredentialFormatCodes.MagneticStripeBarcodeAba:
                            case CredentialFormatCodes.GalaxyKeypad:
                            case CredentialFormatCodes.USGovernmentID:
                            case CredentialFormatCodes.BasIpQr:
                            case CredentialFormatCodes.BtFarpointeConektMobile:
                            case CredentialFormatCodes.BtHidMobileAccess:
                            case CredentialFormatCodes.BtStidMobileId:
                            case CredentialFormatCodes.BtAllegion:
                            case CredentialFormatCodes.BtBasIp:
                            case CredentialFormatCodes.None:
                            default:
                                mgr.Entity.SearchByColumnName1 = "ByCredentialNumber";
                                mgr.Entity.SearchData1 = getParameters.SearchCredential.CardNumber;
                                break;
                        }
                        break;
                    case Common.Enums.PersonSearchType.ByCredentialFieldValue:
                        mgr.Entity.SearchByColumnName1 = "ByCredentialFieldValue";
                        mgr.Entity.CredentialPartNumber = (long)getParameters.SearchUInt64Value;
                        break;

                    case Common.Enums.PersonSearchType.ByOriginId:
                        mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.OriginId.ToString();
                        mgr.Entity.SearchData1 = getParameters.GetString;
                        break;
                    case Common.Enums.PersonSearchType.ByLastUpdatedDate:
                        mgr.Entity.SearchByColumnName1 = "RecentlyAddedOrModified";
                        mgr.Entity.SearchData1 = getParameters.SearchDateTimeValue.ToString("yyyy-MM-dd HH:mm:ss");
                        if (string.IsNullOrEmpty(getParameters.DateComparisonOperator))
                            getParameters.DateComparisonOperator = GalaxySMS.Common.Constants.ComparisonOperatorsSql.GreaterOrEqual;
                        mgr.Entity.DateComparisonType = getParameters.DateComparisonOperator;
                        break;
                    case PersonSearchType.ByAccessProfileUid:
                        mgr.Entity.SearchByColumnName1 = "ByAccessProfileUid";
                        mgr.Entity.UidValue = getParameters.GetGuid;
                        break;
                    case PersonSearchType.AdvancedSearch:
                        break;
                }
                mgr.Entity.IncludeLastUsageData = getParameters.IncludeLastUsageData;

                switch (getParameters.SortBy)
                {
                    case PersonSortOrder.InsertDate:
                    case PersonSortOrder.UpdateDate:
                        mgr.Entity.OrderBy = getParameters.SortBy.ToString();
                        if (getParameters.DescendingOrder)
                            mgr.Entity.OrderBy += " desc";
                        break;

                    case PersonSortOrder.LastNameFirstName:
                    default:
                        if (getParameters.DescendingOrder)
                            mgr.Entity.OrderBy = $"LastName desc, FirstName desc";
                        else
                            mgr.Entity.OrderBy = $"LastName,FirstName";
                        break;
                }


                var results = new ArrayResponse<PersonSummary>();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var firstEntity = pdsaEntities.FirstOrDefault();
                    var entities = mgr.ConvertPDSACollection(pdsaEntities, getParameters.IncludeLastUsageData);
                    foreach (var entity in entities)
                    {
                        if (getParameters.IncludePhoto || getParameters.IncludeMemberCollections)
                            FillMemberCollections(entity, null, getParameters);
                    }
                    results.Items = entities.ToArray();
                    if (firstEntity != null)
                    {
                        results.TotalItemCount = firstEntity.TotalPersonCount;
                        results.PageItemCount = results.Items.Length;
                        if (mgr.Entity.PageSize > 0)
                        {
                            results.PageNumber = mgr.Entity.PageNumber;
                            results.PageSize = mgr.Entity.PageSize;
                            results.TotalPageCount = GCS.Framework.Utilities.UtilityFunctions.GetTotalPageCount(firstEntity.TotalPersonCount, results.PageSize);
                        }
                        else
                        {
                            results.PageNumber = 1;
                            results.PageSize = firstEntity.TotalPersonCount;
                            results.TotalPageCount = 1;
                        }
                    }
                }
                return results;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetAllPersonsForEntity", ex);
                throw;
            }
        }

        public ArrayResponse<PersonSummary> AdvancedSearchForPersonSummaryPaged(IApplicationUserSessionDataHeader sessionData, PersonSummarySearchParameters getParameters)
        {
            try
            {

                var mgr = new PersonSummary_SearchWithParamsExPDSAManager();
                if (getParameters.UniqueId == Guid.Empty)
                    mgr.Entity.EntityId = sessionData.CurrentEntityId;
                else
                    mgr.Entity.EntityId = getParameters.UniqueId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                mgr.Entity.PageNumber = getParameters.PageNumber;
                mgr.Entity.PageSize = getParameters.PageSize;
                //switch (getParameters.TextSearchType)
                //{
                //    case TextSearchType.Equals:
                //        mgr.Entity.ExactMatch = 1;
                //        break;

                //    case TextSearchType.StartsWith:
                //        break;

                //    case TextSearchType.Contains:
                //        mgr.Entity.AnywhereWithin = 1;
                //        break;
                //}

                //switch (getParameters.MultipleFieldSearchRelationship)
                //{
                //    case Common.Shared.Enums.AndOr.AND:
                //        break;

                //    case Common.Shared.Enums.AndOr.OR:
                //        mgr.Entity.OrNotAnd = 1;
                //        break;
                //}

                //switch (getParameters.SearchType)
                //{
                //    case Common.Enums.PersonSearchType.AllRecords:
                //        break;
                //    case Common.Enums.PersonSearchType.ByPersonUid:
                //        mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.PersonUid.ToString()}";
                //        mgr.Entity.SearchData1 = getParameters.PersonUid.ToString();
                //        break;
                //    case Common.Enums.PersonSearchType.ByPersonId:
                //        mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.PersonId.ToString();
                //        mgr.Entity.SearchData1 = getParameters.GetString;
                //        break;
                //    case Common.Enums.PersonSearchType.ByPersonActiveStatusTypeUid:
                //        mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.PersonActiveStatusTypeUid.ToString()}";
                //        mgr.Entity.SearchData1 = getParameters.GetGuid.ToString();
                //        break;
                //    case Common.Enums.PersonSearchType.ByDepartmentUid:
                //        mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.DepartmentUid.ToString()}";
                //        mgr.Entity.SearchData1 = getParameters.GetGuid.ToString();
                //        break;
                //    case Common.Enums.PersonSearchType.ByPersonRecordTypeUid:
                //        mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.PersonRecordTypeUid.ToString()}";
                //        mgr.Entity.SearchData1 = getParameters.GetGuid.ToString();
                //        break;
                //    case Common.Enums.PersonSearchType.ByLastFirstName:
                //        if (!string.IsNullOrEmpty(getParameters.LastName))
                //        {
                //            mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.LastName.ToString();
                //            mgr.Entity.SearchData1 = getParameters.LastName;
                //            if (!string.IsNullOrEmpty(getParameters.FirstName))
                //            {
                //                mgr.Entity.SearchByColumnName2 = PersonStandardPropertyNames.FirstName.ToString();
                //                mgr.Entity.SearchData2 = getParameters.FirstName;
                //            }
                //        }
                //        else if (!string.IsNullOrEmpty(getParameters.FirstName))
                //        {
                //            mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.FirstName.ToString();
                //            mgr.Entity.SearchData1 = getParameters.FirstName;
                //        }
                //        break;

                //    case PersonSearchType.ByAnyNameField:
                //        mgr.Entity.OrNotAnd = 1;
                //        if (string.IsNullOrEmpty(getParameters.GetString))
                //            getParameters.GetString = getParameters.LastName;
                //        if (string.IsNullOrEmpty(getParameters.GetString))
                //            getParameters.GetString = getParameters.FirstName;

                //        mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.LastName.ToString();
                //        mgr.Entity.SearchByColumnName2 = PersonStandardPropertyNames.FirstName.ToString();
                //        mgr.Entity.SearchByColumnName3 = PersonStandardPropertyNames.MiddleName.ToString();
                //        mgr.Entity.SearchByColumnName4 = PersonStandardPropertyNames.FullName.ToString();
                //        mgr.Entity.SearchByColumnName5 = PersonStandardPropertyNames.LegalName.ToString();
                //        mgr.Entity.SearchByColumnName6 = PersonStandardPropertyNames.PreferredName.ToString();
                //        mgr.Entity.SearchByColumnName7 = PersonStandardPropertyNames.NickName.ToString();
                //        mgr.Entity.SearchData1 = getParameters.GetString;
                //        mgr.Entity.SearchData2 = getParameters.GetString;
                //        mgr.Entity.SearchData3 = getParameters.GetString;
                //        mgr.Entity.SearchData4 = getParameters.GetString;
                //        mgr.Entity.SearchData5 = getParameters.GetString;
                //        mgr.Entity.SearchData6 = getParameters.GetString;
                //        mgr.Entity.SearchData7 = getParameters.GetString;
                //        break;

                //    case Common.Enums.PersonSearchType.ByFields:
                //        mgr.Entity.SearchByColumnName1 = getParameters.PropertyName;
                //        mgr.Entity.SearchData1 = getParameters.GetString;

                //        if (getParameters.SearchTextValues?.Count > 0 && getParameters.PropertyNames?.Count == getParameters.SearchTextValues?.Count)
                //        {
                //            for (int x = 0; x < getParameters.PropertyNames.Count; x++)
                //            {
                //                switch (x)
                //                {
                //                    case 0:
                //                        mgr.Entity.SearchByColumnName2 = getParameters.PropertyNames[x];
                //                        mgr.Entity.SearchData2 = getParameters.SearchTextValues[x];
                //                        break;

                //                    case 1:
                //                        mgr.Entity.SearchByColumnName3 = getParameters.PropertyNames[x];
                //                        mgr.Entity.SearchData3 = getParameters.SearchTextValues[x];
                //                        break;
                //                    case 2:
                //                        mgr.Entity.SearchByColumnName4 = getParameters.PropertyNames[x];
                //                        mgr.Entity.SearchData4 = getParameters.SearchTextValues[x];
                //                        break;
                //                    case 3:
                //                        mgr.Entity.SearchByColumnName5 = getParameters.PropertyNames[x];
                //                        mgr.Entity.SearchData5 = getParameters.SearchTextValues[x];
                //                        break;
                //                    case 4:
                //                        mgr.Entity.SearchByColumnName6 = getParameters.PropertyNames[x];
                //                        mgr.Entity.SearchData6 = getParameters.SearchTextValues[x];
                //                        break;
                //                    case 5:
                //                        mgr.Entity.SearchByColumnName7 = getParameters.PropertyNames[x];
                //                        mgr.Entity.SearchData7 = getParameters.SearchTextValues[x];
                //                        break;
                //                    case 6:
                //                        mgr.Entity.SearchByColumnName8 = getParameters.PropertyNames[x];
                //                        mgr.Entity.SearchData8 = getParameters.SearchTextValues[x];
                //                        break;
                //                }
                //            }
                //        }

                //        if (string.IsNullOrEmpty(getParameters.DateComparisonOperator))
                //            getParameters.DateComparisonOperator = GalaxySMS.Common.Constants.ComparisonOperatorsSql.GreaterOrEqual;
                //        mgr.Entity.DateComparisonType = getParameters.DateComparisonOperator;
                //        break;
                //    case Common.Enums.PersonSearchType.ByCredentialNumber:
                //        mgr.Entity.SearchByColumnName1 = "ByCredentialNumber";
                //        mgr.Entity.SearchData1 = getParameters.SearchCredential.CardNumber;
                //        break;
                //    case Common.Enums.PersonSearchType.ByCredentialFieldValues:
                //        switch (getParameters.SearchCredential.CredentialFormat.CredentialFormatCode)
                //        {
                //            case CredentialFormatCodes.Standard26Bit:
                //            case CredentialFormatCodes.Corporate1K35Bit:
                //            case CredentialFormatCodes.PIV75Bit:
                //            case CredentialFormatCodes.Bqt36Bit:
                //            case CredentialFormatCodes.XceedId40Bit:
                //            case CredentialFormatCodes.Corporate1K48Bit:
                //            case CredentialFormatCodes.Cypress37Bit:
                //            case CredentialFormatCodes.H1030437Bit:
                //            case CredentialFormatCodes.SoftwareHouse37Bit:
                //            case CredentialFormatCodes.H1030237Bit:
                //                mgr.Entity.SearchByColumnName1 = "ByCredentialFieldValues";
                //                mgr.Entity.SearchData1 = getParameters.SearchCredential.CredentialFormatCodeAndPartsString;
                //                break;

                //            case CredentialFormatCodes.NumericCardCode:
                //            case CredentialFormatCodes.MagneticStripeBarcodeAba:
                //            case CredentialFormatCodes.GalaxyKeypad:
                //            case CredentialFormatCodes.USGovernmentID:
                //            case CredentialFormatCodes.BasIpQr:
                //            case CredentialFormatCodes.BtFarpointeConektMobile:
                //            case CredentialFormatCodes.BtHidMobileAccess:
                //            case CredentialFormatCodes.BtStidMobileId:
                //            case CredentialFormatCodes.BtAllegion:
                //            case CredentialFormatCodes.BtBasIp:
                //            case CredentialFormatCodes.None:
                //            default:
                //                mgr.Entity.SearchByColumnName1 = "ByCredentialNumber";
                //                mgr.Entity.SearchData1 = getParameters.SearchCredential.CardNumber;
                //                break;
                //        }
                //        break;
                //    case Common.Enums.PersonSearchType.ByCredentialFieldValue:
                //        mgr.Entity.SearchByColumnName1 = "ByCredentialFieldValue";
                //        mgr.Entity.CredentialPartNumber = (long)getParameters.SearchUInt64Value;
                //        break;

                //    case Common.Enums.PersonSearchType.ByOriginId:
                //        mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.OriginId.ToString();
                //        mgr.Entity.SearchData1 = getParameters.GetString;
                //        break;
                //    case Common.Enums.PersonSearchType.ByLastUpdatedDate:
                //        mgr.Entity.SearchByColumnName1 = "RecentlyAddedOrModified";
                //        mgr.Entity.SearchData1 = getParameters.SearchDateTimeValue.ToString("yyyy-MM-dd HH:mm:ss");
                //        if (string.IsNullOrEmpty(getParameters.DateComparisonOperator))
                //            getParameters.DateComparisonOperator = GalaxySMS.Common.Constants.ComparisonOperatorsSql.GreaterOrEqual;
                //        mgr.Entity.DateComparisonType = getParameters.DateComparisonOperator;
                //        break;
                //    case PersonSearchType.ByAccessProfileUid:
                //        mgr.Entity.SearchByColumnName1 = "ByAccessProfileUid";
                //        mgr.Entity.UidValue = getParameters.GetGuid;
                //        break;
                //    case PersonSearchType.AdvancedSearch:
                //        break;
                //}
                mgr.Entity.EntityId = getParameters.CurrentEntityId;
                mgr.Entity.QueryText = getParameters.QueryText;
                mgr.Entity.DepartmentUids = getParameters.DepartmentUids.ToSeparatedString(',', false);
                mgr.Entity.AccessProfileUids = getParameters.AccessProfileUids.ToSeparatedString(',', false);
                mgr.Entity.ClusterUids = getParameters.ClusterUids.ToSeparatedString(',', false);
                mgr.Entity.PersonRecordTypeUids = getParameters.PersonTypeUids.ToSeparatedString(',', false);
                mgr.Entity.PersonIds = getParameters.PersonIds.ToSeparatedString(',', true);
                mgr.Entity.Gender = getParameters.Gender;
                mgr.Entity.DateOfBirth = getParameters.DateOfBirth;
                mgr.Entity.IsActive = getParameters.IsActive;
                mgr.Entity.ActivationStart = getParameters.ActivationStart;
                mgr.Entity.ActivationEnd = getParameters.ActivationEnd;
                mgr.Entity.ExpirationStart = getParameters.ExpirationStart;
                mgr.Entity.ExpirationEnd = getParameters.ExpirationEnd;
                mgr.Entity.WithCredentials = getParameters.HaveCredentials;
                mgr.Entity.CanToggleLock = getParameters.CanToggleLock;
                mgr.Entity.CredentialNumbers = getParameters.SearchCredential?.CredentialPartsString;
                mgr.Entity.IncludeLastUsageData = getParameters.IncludeLastUsageData;

                switch (getParameters.SortBy)
                {
                    case PersonSortOrder.InsertDate:
                    case PersonSortOrder.UpdateDate:
                        mgr.Entity.OrderBy = getParameters.SortBy.ToString();
                        if (getParameters.DescendingOrder)
                            mgr.Entity.OrderBy += " desc";
                        break;

                    case PersonSortOrder.LastNameFirstName:
                    default:
                        if (getParameters.DescendingOrder)
                            mgr.Entity.OrderBy = $"LastName desc, FirstName desc";
                        else
                            mgr.Entity.OrderBy = $"LastName,FirstName";
                        break;
                }


                var results = new ArrayResponse<PersonSummary>();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var firstEntity = pdsaEntities.FirstOrDefault();
                    var entities = mgr.ConvertPDSACollection(pdsaEntities, getParameters.IncludeLastUsageData);
                    foreach (var entity in entities)
                    {
                        if (getParameters.IncludePhoto || getParameters.IncludeMemberCollections)
                            FillMemberCollections(entity, null, getParameters);
                    }
                    results.Items = entities.ToArray();
                    if (firstEntity != null)
                    {
                        results.TotalItemCount = firstEntity.TotalPersonCount;
                        results.PageItemCount = results.Items.Length;
                        if (mgr.Entity.PageSize > 0)
                        {
                            results.PageNumber = mgr.Entity.PageNumber;
                            results.PageSize = mgr.Entity.PageSize;
                            results.TotalPageCount = GCS.Framework.Utilities.UtilityFunctions.GetTotalPageCount(firstEntity.TotalPersonCount, results.PageSize);
                        }
                        else
                        {
                            results.PageNumber = 1;
                            results.PageSize = firstEntity.TotalPersonCount;
                            results.TotalPageCount = 1;
                        }
                    }
                }
                return results;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetAllPersonsForEntity", ex);
                throw;
            }
        }

        //public ArrayResponse<PersonSummary> SearchForPersonSummaryPagedEx(IApplicationUserSessionDataHeader sessionData, PersonSummarySearchParameters getParameters)
        //{
        //    try
        //    {
        //        var mgr = new PersonSummary_SearchWithParamsPDSAManager();
        //        if (getParameters.UniqueId == Guid.Empty)
        //            mgr.Entity.EntityId = sessionData.CurrentEntityId;
        //        else
        //            mgr.Entity.EntityId = getParameters.UniqueId;
        //        mgr.Entity.CultureName = sessionData.UiCulture;
        //        mgr.Entity.PageNumber = getParameters.PageNumber;
        //        mgr.Entity.PageSize = getParameters.PageSize;
        //        switch (getParameters.TextSearchType)
        //        {
        //            case TextSearchType.Equals:
        //                mgr.Entity.ExactMatch = 1;
        //                break;

        //            case TextSearchType.StartsWith:
        //                break;

        //            case TextSearchType.Contains:
        //                mgr.Entity.AnywhereWithin = 1;
        //                break;
        //        }

        //        switch (getParameters.MultipleFieldSearchRelationship)
        //        {
        //            case Common.Shared.Enums.AndOr.AND:
        //                break;

        //            case Common.Shared.Enums.AndOr.OR:
        //                mgr.Entity.OrNotAnd = 1;
        //                break;
        //        }

        //        switch (getParameters.SearchType)
        //        {
        //            case Common.Enums.PersonSearchType.AllRecords:
        //                break;
        //            case Common.Enums.PersonSearchType.ByPersonUid:
        //                mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.PersonUid.ToString()}";
        //                mgr.Entity.SearchData1 = getParameters.PersonUid.ToString();
        //                break;
        //            case Common.Enums.PersonSearchType.ByPersonId:
        //                mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.PersonId.ToString();
        //                mgr.Entity.SearchData1 = getParameters.GetString;
        //                break;
        //            case Common.Enums.PersonSearchType.ByPersonActiveStatusTypeUid:
        //                mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.PersonActiveStatusTypeUid.ToString()}";
        //                mgr.Entity.SearchData1 = getParameters.GetGuid.ToString();
        //                break;
        //            case Common.Enums.PersonSearchType.ByDepartmentUid:
        //                mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.DepartmentUid.ToString()}";
        //                mgr.Entity.SearchData1 = getParameters.GetGuid.ToString();
        //                break;
        //            case Common.Enums.PersonSearchType.ByPersonRecordTypeUid:
        //                mgr.Entity.SearchByColumnName1 = $"GCS.Person.{PersonStandardPropertyNames.PersonRecordTypeUid.ToString()}";
        //                mgr.Entity.SearchData1 = getParameters.GetGuid.ToString();
        //                break;
        //            case Common.Enums.PersonSearchType.ByLastFirstName:
        //                if (!string.IsNullOrEmpty(getParameters.LastName))
        //                {
        //                    mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.LastName.ToString();
        //                    mgr.Entity.SearchData1 = getParameters.LastName;
        //                    if (!string.IsNullOrEmpty(getParameters.FirstName))
        //                    {
        //                        mgr.Entity.SearchByColumnName2 = PersonStandardPropertyNames.FirstName.ToString();
        //                        mgr.Entity.SearchData2 = getParameters.FirstName;
        //                    }
        //                }
        //                else if (!string.IsNullOrEmpty(getParameters.FirstName))
        //                {
        //                    mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.FirstName.ToString();
        //                    mgr.Entity.SearchData1 = getParameters.FirstName;
        //                }
        //                break;

        //            case PersonSearchType.ByAnyNameField:
        //                mgr.Entity.OrNotAnd = 1;
        //                if (string.IsNullOrEmpty(getParameters.GetString))
        //                    getParameters.GetString = getParameters.LastName;
        //                if (string.IsNullOrEmpty(getParameters.GetString))
        //                    getParameters.GetString = getParameters.FirstName;

        //                mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.LastName.ToString();
        //                mgr.Entity.SearchByColumnName2 = PersonStandardPropertyNames.FirstName.ToString();
        //                mgr.Entity.SearchByColumnName3 = PersonStandardPropertyNames.MiddleName.ToString();
        //                mgr.Entity.SearchByColumnName4 = PersonStandardPropertyNames.FullName.ToString();
        //                mgr.Entity.SearchByColumnName5 = PersonStandardPropertyNames.LegalName.ToString();
        //                mgr.Entity.SearchByColumnName6 = PersonStandardPropertyNames.PreferredName.ToString();
        //                mgr.Entity.SearchByColumnName7 = PersonStandardPropertyNames.NickName.ToString();
        //                mgr.Entity.SearchData1 = getParameters.GetString;
        //                mgr.Entity.SearchData2 = getParameters.GetString;
        //                mgr.Entity.SearchData3 = getParameters.GetString;
        //                mgr.Entity.SearchData4 = getParameters.GetString;
        //                mgr.Entity.SearchData5 = getParameters.GetString;
        //                mgr.Entity.SearchData6 = getParameters.GetString;
        //                mgr.Entity.SearchData7 = getParameters.GetString;
        //                break;

        //            case Common.Enums.PersonSearchType.ByFields:
        //                mgr.Entity.SearchByColumnName1 = getParameters.PropertyName;
        //                mgr.Entity.SearchData1 = getParameters.GetString;

        //                if (getParameters.SearchTextValues?.Count > 0 && getParameters.PropertyNames?.Count == getParameters.SearchTextValues?.Count)
        //                {
        //                    for (int x = 0; x < getParameters.PropertyNames.Count; x++)
        //                    {
        //                        switch (x)
        //                        {
        //                            case 0:
        //                                mgr.Entity.SearchByColumnName2 = getParameters.PropertyNames[x];
        //                                mgr.Entity.SearchData2 = getParameters.SearchTextValues[x];
        //                                break;

        //                            case 1:
        //                                mgr.Entity.SearchByColumnName3 = getParameters.PropertyNames[x];
        //                                mgr.Entity.SearchData3 = getParameters.SearchTextValues[x];
        //                                break;
        //                            case 2:
        //                                mgr.Entity.SearchByColumnName4 = getParameters.PropertyNames[x];
        //                                mgr.Entity.SearchData4 = getParameters.SearchTextValues[x];
        //                                break;
        //                            case 3:
        //                                mgr.Entity.SearchByColumnName5 = getParameters.PropertyNames[x];
        //                                mgr.Entity.SearchData5 = getParameters.SearchTextValues[x];
        //                                break;
        //                            case 4:
        //                                mgr.Entity.SearchByColumnName6 = getParameters.PropertyNames[x];
        //                                mgr.Entity.SearchData6 = getParameters.SearchTextValues[x];
        //                                break;
        //                            case 5:
        //                                mgr.Entity.SearchByColumnName7 = getParameters.PropertyNames[x];
        //                                mgr.Entity.SearchData7 = getParameters.SearchTextValues[x];
        //                                break;
        //                            case 6:
        //                                mgr.Entity.SearchByColumnName8 = getParameters.PropertyNames[x];
        //                                mgr.Entity.SearchData8 = getParameters.SearchTextValues[x];
        //                                break;
        //                        }
        //                    }
        //                }

        //                if (string.IsNullOrEmpty(getParameters.DateComparisonOperator))
        //                    getParameters.DateComparisonOperator = GalaxySMS.Common.Constants.ComparisonOperatorsSql.GreaterOrEqual;
        //                mgr.Entity.DateComparisonType = getParameters.DateComparisonOperator;
        //                break;
        //            case Common.Enums.PersonSearchType.ByCredentialNumber:
        //                mgr.Entity.SearchByColumnName1 = "ByCredentialNumber";
        //                mgr.Entity.SearchData1 = getParameters.SearchCredential.CardNumber;
        //                break;
        //            case Common.Enums.PersonSearchType.ByCredentialFieldValues:
        //                switch (getParameters.SearchCredential.CredentialFormat.CredentialFormatCode)
        //                {
        //                    case CredentialFormatCodes.Standard26Bit:
        //                    case CredentialFormatCodes.Corporate1K35Bit:
        //                    case CredentialFormatCodes.PIV75Bit:
        //                    case CredentialFormatCodes.Bqt36Bit:
        //                    case CredentialFormatCodes.XceedId40Bit:
        //                    case CredentialFormatCodes.Corporate1K48Bit:
        //                    case CredentialFormatCodes.Cypress37Bit:
        //                    case CredentialFormatCodes.H1030437Bit:
        //                    case CredentialFormatCodes.SoftwareHouse37Bit:
        //                    case CredentialFormatCodes.H1030237Bit:
        //                        mgr.Entity.SearchByColumnName1 = "ByCredentialFieldValues";
        //                        mgr.Entity.SearchData1 = getParameters.SearchCredential.CredentialFormatCodeAndPartsString;
        //                        break;

        //                    case CredentialFormatCodes.NumericCardCode:
        //                    case CredentialFormatCodes.MagneticStripeBarcodeAba:
        //                    case CredentialFormatCodes.GalaxyKeypad:
        //                    case CredentialFormatCodes.USGovernmentID:
        //                    case CredentialFormatCodes.BasIpQr:
        //                    case CredentialFormatCodes.BtFarpointeConektMobile:
        //                    case CredentialFormatCodes.BtHidMobileAccess:
        //                    case CredentialFormatCodes.BtStidMobileId:
        //                    case CredentialFormatCodes.BtAllegion:
        //                    case CredentialFormatCodes.BtBasIp:
        //                    case CredentialFormatCodes.None:
        //                    default:
        //                        mgr.Entity.SearchByColumnName1 = "ByCredentialNumber";
        //                        mgr.Entity.SearchData1 = getParameters.SearchCredential.CardNumber;
        //                        break;
        //                }
        //                break;
        //            case Common.Enums.PersonSearchType.ByCredentialFieldValue:
        //                mgr.Entity.SearchByColumnName1 = "ByCredentialFieldValue";
        //                mgr.Entity.CredentialPartNumber = (long)getParameters.SearchUInt64Value;
        //                break;

        //            case Common.Enums.PersonSearchType.ByOriginId:
        //                mgr.Entity.SearchByColumnName1 = PersonStandardPropertyNames.OriginId.ToString();
        //                mgr.Entity.SearchData1 = getParameters.GetString;
        //                break;
        //            case Common.Enums.PersonSearchType.ByLastUpdatedDate:
        //                mgr.Entity.SearchByColumnName1 = "RecentlyAddedOrModified";
        //                mgr.Entity.SearchData1 = getParameters.SearchDateTimeValue.ToString("yyyy-MM-dd HH:mm:ss");
        //                if (string.IsNullOrEmpty(getParameters.DateComparisonOperator))
        //                    getParameters.DateComparisonOperator = GalaxySMS.Common.Constants.ComparisonOperatorsSql.GreaterOrEqual;
        //                mgr.Entity.DateComparisonType = getParameters.DateComparisonOperator;
        //                break;
        //            case PersonSearchType.ByAccessProfileUid:
        //                mgr.Entity.SearchByColumnName1 = "ByAccessProfileUid";
        //                mgr.Entity.UidValue = getParameters.GetGuid;
        //                break;
        //            case PersonSearchType.AdvancedSearch:
        //                break;
        //        }
        //        mgr.Entity.IncludeLastUsageData = getParameters.IncludeLastUsageData;

        //        switch (getParameters.SortBy)
        //        {
        //            case PersonSortOrder.InsertDate:
        //            case PersonSortOrder.UpdateDate:
        //                mgr.Entity.OrderBy = getParameters.SortBy.ToString();
        //                if (getParameters.DescendingOrder)
        //                    mgr.Entity.OrderBy += " desc";
        //                break;

        //            case PersonSortOrder.LastNameFirstName:
        //            default:
        //                if (getParameters.DescendingOrder)
        //                    mgr.Entity.OrderBy = $"LastName desc, FirstName desc";
        //                else
        //                    mgr.Entity.OrderBy = $"LastName,FirstName";
        //                break;
        //        }


        //        var results = new ArrayResponse<PersonSummary>();

        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var firstEntity = pdsaEntities.FirstOrDefault();
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities, getParameters.IncludeLastUsageData);
        //            foreach (var entity in entities)
        //            {
        //                if (getParameters.IncludePhoto || getParameters.IncludeMemberCollections)
        //                    FillMemberCollections(entity, null, getParameters);
        //            }
        //            results.Items = entities.ToArray();
        //            if (firstEntity != null)
        //            {
        //                results.TotalItemCount = firstEntity.TotalPersonCount;
        //                results.PageItemCount = results.Items.Length;
        //                if (mgr.Entity.PageSize > 0)
        //                {
        //                    results.PageNumber = mgr.Entity.PageNumber;
        //                    results.PageSize = mgr.Entity.PageSize;
        //                    results.TotalPageCount = GCS.Framework.Utilities.UtilityFunctions.GetTotalPageCount(firstEntity.TotalPersonCount, results.PageSize);
        //                }
        //                else
        //                {
        //                    results.PageNumber = 1;
        //                    results.PageSize = firstEntity.TotalPersonCount;
        //                    results.TotalPageCount = 1;
        //                }
        //            }
        //        }
        //        return results;
        //    }
        //    catch (PDSAValidationException ex)
        //    {
        //        DataValidationException dve = Converters.ConvertToDataValidationException(ex);
        //        throw dve;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetAllPersonsForEntity", ex);
        //        throw;
        //    }
        //}

        public IEnumerable<Credential_PanelLoadData> GetCredentialPanelLoadDataForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<Credential_PanelLoadData> parameters)
        {
            try
            {
                var results = new List<Credential_PanelLoadData>();
                var mgr = new Credential_GetPanelLoadDataByPersonUidPDSAManager();
                mgr.Entity.PersonUid = parameters.PersonUid;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                    {
                        var newEntity = new Credential_PanelLoadData();
                        SimpleMapper.PropertyMap(i, newEntity);

                        results.Add(newEntity);
                    }
                    return results;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetCredentialPanelLoadData", ex);
                throw;
            }
        }

        public IEnumerable<Credential_PanelLoadData> GetCredentialPanelLoadDataForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<Credential_PanelLoadData> parameters)
        {
            try
            {
                var results = new List<Credential_PanelLoadData>();
                var mgr = new Credential_GetPanelLoadDataByClusterUidPDSAManager();
                mgr.Entity.ClusterUid = parameters.ClusterUid;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                    {
                        var newEntity = new Credential_PanelLoadData();
                        SimpleMapper.PropertyMap(i, newEntity);

                        results.Add(newEntity);
                    }
                    return results;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetCredentialPanelLoadDataForCluster", ex);
                throw;
            }
        }

        public IEnumerable<Credential_PanelLoadData> GetCredentialPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var results = new List<Credential_PanelLoadData>();
                var mgr = new Credential_PanelLoadDataPDSAManager();
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                    {
                        var newEntity = new Credential_PanelLoadData();
                        SimpleMapper.PropertyMap(i, newEntity);

                        results.Add(newEntity);
                    }
                    return results;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetCredentialPanelLoadData", ex);
                throw;
            }
        }

        public IEnumerable<Credential_PanelLoadData> GetModifiedCredentialPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var results = new List<Credential_PanelLoadData>();
                var mgr = new Credential_GetPanelLoadDataChangesByCpuUidPDSAManager();
                mgr.Entity.CpuUid = parameters.UniqueId;
                mgr.Entity.ClusterGroupId = parameters.ClusterGroupId;
                mgr.Entity.ClusterNumber = parameters.ClusterNumber;
                mgr.Entity.PanelNumber = parameters.PanelNumber;
                mgr.Entity.CpuNumber = parameters.GetInt16;
                mgr.Entity.ServerAddress = parameters.GetString;
                mgr.Entity.IsConnected = true;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                    {
                        var newEntity = new Credential_PanelLoadData();
                        SimpleMapper.PropertyMap(i, newEntity);

                        results.Add(newEntity);
                    }
                    return results;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetCredentialPanelLoadDataForCluster", ex);
                throw;
            }
        }

        public IEnumerable<PersonalAccessGroup_PanelLoadData> GetPersonalAccessGroupPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<PersonalAccessGroup_PanelLoadData> parameters)
        {
            try
            {
                var results = new List<PersonalAccessGroup_PanelLoadData>();
                var mgr = new PersonalAccessGroup_PanelLoadDataByPersonUidPDSAManager();
                mgr.Entity.PersonUid = parameters.PersonUid;
                var result = mgr.BuildCollection();
                if (result != null)
                {
                    foreach (var i in result)
                    {
                        var newEntity = new PersonalAccessGroup_PanelLoadData();
                        SimpleMapper.PropertyMap(i, newEntity);

                        results.Add(newEntity);
                    }
                    return results;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetPersonalAccessGroupPanelLoadData", ex);
                throw;
            }
        }

        protected override Person GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override Person GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new PersonPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    Person result = new Person();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, Person originalEntity, Person newEntity, string auditXml)
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
                        propertiesToIgnore.Add("PersonCredentials");
                        propertiesToIgnore.Add("Notes");
                        propertiesToIgnore.Add("PersonPropertyBags");
                        propertiesToIgnore.Add("PersonPhotos");
                        propertiesToIgnore.Add("PersonPhoneNumbers");
                        propertiesToIgnore.Add("PersonNotes");
                        propertiesToIgnore.Add("PersonLcdMessages");
                        propertiesToIgnore.Add("PersonEmailAddresses");
                        propertiesToIgnore.Add("PersonAddresses");
                        propertiesToIgnore.Add("MappedEntitiesPermissionLevels");
                        propertiesToIgnore.Add("EntityIds");

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
                                mgr.Entity.NewValue = property.Value.NewValue?.ToString();
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
                        mgr.Entity.RecordTag = newEntity.PersonUid.ToString();
                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.RecordTag = originalEntity.PersonUid.ToString();
                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(Person entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
            var p = new GetParametersWithPhoto()
            {
                UniqueId = entity.PersonUid,
                PersonUid = entity.PersonUid,
                IncludeMemberCollections = getParameters.IncludeMemberCollections,
                IncludePhoto = getParameters.IncludePhoto,
                PhotoPixelWidth = getParameters.PhotoPixelWidth,
                OmitPhotoBinaryData = getParameters.OmitPhotoBinaryData,
                IncludeScaledPhotos = getParameters.IncludeScaledPhotos
            };
            var entityMaps = _entityMapRepository.GetAllPersonEntityMapsForPerson(sessionData, p);
            var entityIds = (from e in entityMaps select e.EntityId).ToList();
            entity.EntityIds.AddRange(entityIds);

            entity.EntityIds.Add(entity.EntityId);

            if (getParameters != null && getParameters.IncludePhoto)
            {
                var photoRepository = _dataRepositoryFactory.GetDataRepository<IPersonPhotoRepository>();
                entity.PersonPhotos = photoRepository.GetAllPersonPhotosForPerson(sessionData, p).ToCollection();
                if (entity.PersonPhotos.Count == 0 && !getParameters.OmitPhotoBinaryData)
                {
                    var defaultImage = GalaxySMS.Resources.Resources.Photo_Placeholder;
                    Image scaledImage = null;
                    if (getParameters.PhotoPixelWidth > 0 && defaultImage.Width > getParameters.PhotoPixelWidth)
                    {
                        scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(defaultImage, getParameters.PhotoPixelWidth);
                    }
                    else
                        scaledImage = defaultImage;

                    var imageBytes = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
                    entity.PersonPhotos.Add(new PersonPhoto()
                    {
                        PhotoImage = imageBytes,
                        ConcurrencyValue = 0,
                    });
                }
                else
                {
                    if (entity.PersonPhotos.Any())
                    {
                        entity.Photos = new HashSet<PhotoLinks>();
                        foreach (var pp in entity.PersonPhotos)
                        {
                            var photoLinks = new PhotoLinks()
                            {
                                Tag = pp.Tag,
                                Original = pp.PublicUrl,
                                IsDefault = pp.IsDefault,
                                UniqueFilename = pp.UniqueFilename.Split('.')[0]
                            };

                            foreach (var sp in pp.ScaledPhotos)
                            {
                                if (sp.Tag.ToLower() == nameof(photoLinks.Original).ToLower())
                                    photoLinks.Original = sp.PublicUrl;
                                else if (sp.Tag.ToLower() == nameof(photoLinks.Default).ToLower())
                                    photoLinks.Default = sp.PublicUrl;
                                else if (sp.Tag.ToLower() == nameof(photoLinks.Small).ToLower())
                                    photoLinks.Small = sp.PublicUrl;
                                else
                                {
                                    photoLinks.Others.Add(new PhotoLink()
                                    {
                                        Tag = sp.Tag,
                                        Url = sp.PublicUrl
                                    });
                                }
                            }
                            entity.Photos.Add(photoLinks);
                        }
                    }

                    if (getParameters.PhotoPixelWidth > 0)
                    {
                        foreach (var i in entity.PersonPhotos)
                        {
                            if (i.PhotoImage.Length > 0)
                            {
                                var img = GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(i.PhotoImage);

                                if (img.Width > getParameters.PhotoPixelWidth)
                                {
                                    var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(img, getParameters.PhotoPixelWidth);
                                    i.PhotoImage = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
                                }
                            }
                        }
                    }
                }

                if (getParameters.OmitPhotoBinaryData)
                {
                    entity.PersonPhotos.Clear();
                }
            }


            if (getParameters != null && getParameters.IncludeMemberCollections)
            {
                var personAccessControlPropertyRepository = _dataRepositoryFactory.GetDataRepository<IPersonAccessControlPropertiesRepository>();
                var addressRepository = _dataRepositoryFactory.GetDataRepository<IPersonAddressRepository>();
                var emailAddressRepository = _dataRepositoryFactory.GetDataRepository<IPersonEmailAddressRepository>();
                var phoneNumberRepository = _dataRepositoryFactory.GetDataRepository<IPersonPhoneNumberRepository>();
                var lcdMessageRepository = _dataRepositoryFactory.GetDataRepository<IPersonLcdMessageRepository>();
                var propertyBagRepository = _dataRepositoryFactory.GetDataRepository<IPersonPropertyBagRepository>();
                var personNoteRepository = _dataRepositoryFactory.GetDataRepository<IPersonNoteRepository>();
                var noteRepository = _dataRepositoryFactory.GetDataRepository<INoteRepository>();
                var personCredentialRepository = _dataRepositoryFactory.GetDataRepository<IPersonCredentialRepository>();
                var personClusterPermissionRepository = _dataRepositoryFactory.GetDataRepository<IPersonClusterPermissionRepository>();

                if (!p.IsExcluded(nameof(entity.PersonAccessControlProperty)))
                {
                    entity.PersonAccessControlProperty = personAccessControlPropertyRepository.Get(entity.PersonUid, sessionData, p);
                    if (entity.PersonAccessControlProperty == null)
                        entity.PersonAccessControlProperty = new PersonAccessControlProperty() { PersonUid = entity.PersonUid, IsActive = true, AccessProfileUid = GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None, ConcurrencyValue = 0 };
                }

                if (!p.IsExcluded(nameof(entity.PersonAddresses)))
                {
                    entity.PersonAddresses = addressRepository.GetAllPersonAddresssForPerson(sessionData, p).ToCollection();
                }

                if (!p.IsExcluded(nameof(entity.PersonEmailAddresses)))
                {
                    entity.PersonEmailAddresses = emailAddressRepository.GetAllPersonEmailAddressesForPerson(sessionData, p).ToCollection();
                }

                if (!p.IsExcluded(nameof(entity.PersonPhoneNumbers)))
                {
                    entity.PersonPhoneNumbers = phoneNumberRepository.GetAllPersonPhoneNumbersForPerson(sessionData, p).ToCollection();
                }

                if (!p.IsExcluded(nameof(entity.PersonLcdMessages)))
                {
                    entity.PersonLcdMessages = lcdMessageRepository.GetAllPersonLcdMessagesForPerson(sessionData, p).ToCollection();
                }

                if (!p.IsExcluded(nameof(entity.PersonPropertyBags)))
                {
                    entity.PersonPropertyBags = propertyBagRepository.GetAllPersonPropertyBagsForPerson(sessionData, p).ToCollection();
                }

                if (!p.IsExcluded(nameof(entity.PersonNotes)))
                {
                    entity.PersonNotes = personNoteRepository.GetAllPersonNotesForPerson(sessionData, p).ToCollection();
                }

                if (!p.IsExcluded(nameof(entity.Notes)))
                {
                    entity.Notes = noteRepository.GetAllNotesForPerson(sessionData, p).ToCollection();
                }

                if (!p.IsExcluded(nameof(entity.PersonCredentials)))
                {
                    entity.PersonCredentials = personCredentialRepository.GetAllPersonCredentialsForPerson(sessionData, p).ToCollection();
                }

                if (!p.IsExcluded(nameof(entity.PersonClusterPermissions)))
                {
//                    entity.PersonClusterPermissions = personClusterPermissionRepository.GetAllPersonClusterPermissionsForPerson(sessionData, p).ToCollection();
                    entity.PersonClusterPermissions = personClusterPermissionRepository.GetAllPersonClusterPermissionsForPerson(sessionData, p).ToList();
                }
            }
        }

        protected void FillMemberCollections(PersonSummary entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var p = new GetParametersWithPhoto(getParameters);
            p.UniqueId = entity.PersonUid;
            p.PersonUid = entity.PersonUid;

            if (getParameters != null && getParameters.IncludePhoto)
            {
                var photoRepository = _dataRepositoryFactory.GetDataRepository<IPersonPhotoRepository>();
                if (!p.IncludeScaledPhotos)
                    p.GetString = nameof(PhotoLinks.Small).ToLower();
                entity.Photo = photoRepository.GetDefaultPersonPhotoForPerson(sessionData, p);
                if (entity.Photo == null && !getParameters.OmitPhotoBinaryData)
                {
                    var defaultImage = GalaxySMS.Resources.Resources.Photo_Placeholder;
                    Image scaledImage = null;
                    if (getParameters.PhotoPixelWidth > 0 && defaultImage.Width > getParameters.PhotoPixelWidth)
                    {
                        scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(defaultImage, getParameters.PhotoPixelWidth);
                    }
                    else
                        scaledImage = defaultImage;

                    var imageBytes = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
                    entity.Photo = new PersonPhoto()
                    {
                        PhotoImage = imageBytes
                    };
                }
                else if (entity.Photo != null)
                {
                    entity.PhotoUrls = new PhotoLinks()
                    {
                        Tag = entity.Photo.Tag,
                        Original = entity.Photo.PublicUrl,
                        IsDefault = entity.Photo.IsDefault,
                        UniqueFilename = entity.Photo.UniqueFilename.Split('.')[0]
                    };

                    foreach (var sp in entity.Photo.ScaledPhotos)
                    {
                        if (sp.Tag.ToLower() == nameof(PhotoLinks.Original).ToLower())
                            entity.PhotoUrls.Original = sp.PublicUrl;
                        else if (sp.Tag.ToLower() == nameof(PhotoLinks.Default).ToLower())
                            entity.PhotoUrls.Default = sp.PublicUrl;
                        else if (sp.Tag.ToLower() == nameof(PhotoLinks.Small).ToLower())
                        {
                            entity.PhotoUrls.Small = sp.PublicUrl;
                            entity.SmallPhotoURL = sp.PublicUrl;
                        }
                        else
                        {
                            entity.PhotoUrls.Others.Add(new PhotoLink()
                            {
                                Tag = sp.Tag,
                                Url = sp.PublicUrl
                            });
                        }
                    }


                    if (getParameters.PhotoPixelWidth > 0)
                    {
                        if (entity.Photo.PhotoImage.Length > 0)
                        {
                            var img = GCS.Framework.Imaging.ByteArrayToFromImage.ByteArrayToImage(entity.Photo.PhotoImage);

                            if (img.Width > getParameters.PhotoPixelWidth)
                            {
                                var scaledImage = GCS.Framework.Imaging.Helpers.ImageUtilities.ResizeImageToWidth(img, getParameters.PhotoPixelWidth);
                                entity.Photo.PhotoImage = GCS.Framework.Imaging.ByteArrayToFromImage.ImageToByteArray(scaledImage);
                            }
                        }
                    }
                }

                if (getParameters.OmitPhotoBinaryData)
                    entity.Photo = null;    // Nix this object completely if OmitPhotoBinaryData = true

                if (!getParameters.IncludeScaledPhotos)
                    entity.PhotoUrls = null;
            }

        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllPersonEntityMapsForPerson(sessionData, getParameters);
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
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.PersonEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new PersonEntityMap();
                    entityMap.PersonEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.PersonUid = uid;
                    entityMap.EntityId = entityId;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        //private void EnsureChildRecordsExist(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    if (entity.PersonAccessControlProperty != null)
        //        SavePersonAccessControlProperty(entity, sessionData, saveParams);
        //    if (!saveParams.Ignore(nameof(entity.PersonPhotos)) && entity.PersonPhotos != null && entity.PersonPhotos.Any())
        //        SavePhotos(entity, sessionData, saveParams);
        //    if (!saveParams.Ignore(nameof(entity.PersonAddresses)) && entity.PersonAddresses != null && entity.PersonAddresses.Any())
        //        SaveAddresses(entity, sessionData, saveParams);
        //    if (!saveParams.Ignore(nameof(entity.PersonEmailAddresses)) && entity.PersonEmailAddresses != null && entity.PersonEmailAddresses.Any())
        //        SaveEmailAddresses(entity, sessionData, saveParams);
        //    if (!saveParams.Ignore(nameof(entity.PersonPhoneNumbers)) && entity.PersonPhoneNumbers != null && entity.PersonPhoneNumbers.Any())
        //        SavePhoneNumbers(entity, sessionData, saveParams);
        //    if (!saveParams.Ignore(nameof(entity.PersonLcdMessages)) && entity.PersonLcdMessages != null && entity.PersonLcdMessages.Any())
        //        SaveLcdMessages(entity, sessionData, saveParams);
        //    if (!saveParams.Ignore(nameof(entity.PersonPropertyBags)) && entity.PersonPropertyBags != null && entity.PersonPropertyBags.Any())
        //        SavePropertyBags(entity, sessionData, saveParams);
        //    if (!saveParams.Ignore(nameof(entity.Notes)) && entity.Notes != null && entity.Notes.Any())
        //        SaveNotes(entity, sessionData, saveParams);
        //    if (!saveParams.Ignore(nameof(entity.PersonNotes)) && entity.PersonNotes != null && entity.PersonNotes.Any())
        //        SavePersonNotes(entity, sessionData, saveParams);
        //    if (!saveParams.Ignore(nameof(entity.PersonCredentials)) && entity.PersonCredentials != null && entity.PersonCredentials.Any())
        //        SavePersonCredentials(entity, sessionData, saveParams);
        //    if (!saveParams.Ignore(nameof(entity.PersonClusterPermissions)) && entity.PersonClusterPermissions != null && entity.PersonClusterPermissions.Any())
        //        SavePersonClusterPermissions(entity, sessionData, saveParams);
        //}
        private void EnsureChildRecordsExist(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (!saveParams.Ignore(nameof(entity.PersonAccessControlProperty)) && entity.PersonAccessControlProperty != null)
                SavePersonAccessControlProperty(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonPhotos)) && entity.PersonPhotos != null)// && entity.PersonPhotos.Any())
                SavePhotos(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonAddresses)) && entity.PersonAddresses != null)// && entity.PersonAddresses.Any())
                SaveAddresses(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonEmailAddresses)) && entity.PersonEmailAddresses != null)// && entity.PersonEmailAddresses.Any())
                SaveEmailAddresses(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonPhoneNumbers)) && entity.PersonPhoneNumbers != null)// && entity.PersonPhoneNumbers.Any())
                SavePhoneNumbers(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonLcdMessages)) && entity.PersonLcdMessages != null)// && entity.PersonLcdMessages.Any())
                SaveLcdMessages(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonPropertyBags)) && entity.PersonPropertyBags != null)// && entity.PersonPropertyBags.Any())
                SavePropertyBags(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.Notes)) && entity.Notes != null)// && entity.Notes.Any())
                SaveNotes(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonNotes)) && entity.PersonNotes != null)// && entity.PersonNotes.Any())
                SavePersonNotes(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonCredentials)) && entity.PersonCredentials != null)// && entity.PersonCredentials.Any())
                SavePersonCredentials(entity, sessionData, saveParams);
            if (!saveParams.Ignore(nameof(entity.PersonClusterPermissions)) && entity.PersonClusterPermissions != null)// && entity.PersonClusterPermissions.Any())
                SavePersonClusterPermissions(entity, sessionData, saveParams);
        }


        private void EnsureChildRecordsAreDeleted(Person entity, IApplicationUserSessionDataHeader sessionData)
        {
            DeletePersonCredentials(entity, sessionData);
            //if (entity.PersonAccessControlProperty != null)
            //    SavePersonAccessControlProperty(entity, sessionData);
            //SavePhotos(entity, sessionData);
            //SaveAddresses(entity, sessionData);
            //SaveEmailAddresses(entity, sessionData);
            //SavePhoneNumbers(entity, sessionData);
            //SaveLcdMessages(entity, sessionData);
            //SavePropertyBags(entity, sessionData);
            //SaveNotes(entity, sessionData);
            //SavePersonNotes(entity, sessionData);
            //SavePersonCredentials(entity, sessionData);
            //SavePersonClusterPermissions(entity, sessionData);
        }

        private void SavePersonAccessControlProperty(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (entity.PersonAccessControlProperty == null || saveParams.Ignore(nameof(entity.PersonAccessControlProperty)))
                return;

            var personAccessControlPropertyRepository = _dataRepositoryFactory.GetDataRepository<IPersonAccessControlPropertiesRepository>();
            entity.PersonAccessControlProperty.PersonUid = entity.PersonUid;

            UpdateTableEntityBaseProperties(entity.PersonAccessControlProperty, sessionData);
            if (personAccessControlPropertyRepository.DoesExist(entity.PersonUid))
            {
                entity.PersonAccessControlProperty = personAccessControlPropertyRepository.Update(entity.PersonAccessControlProperty, sessionData, saveParams);
            }
            else
            {
                entity.PersonAccessControlProperty = personAccessControlPropertyRepository.Add(entity.PersonAccessControlProperty, sessionData, saveParams);
            }
        }

        private void SavePersonNotes(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (saveParams.Ignore(nameof(entity.PersonNotes)))
                return;
        }

        private void SavePropertyBags(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (saveParams.Ignore(nameof(entity.PersonPropertyBags)))
                return;
        }

        private void SaveNotes(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (saveParams.Ignore(nameof(entity.Notes)))
                return;
        }

        private void SaveLcdMessages(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (saveParams.Ignore(nameof(entity.PersonLcdMessages)))
                return;

        }

        private void SavePhoneNumbers(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //            if (entity.PersonPhoneNumbers == null || !entity.PersonPhoneNumbers.Any() || saveParams.Ignore(nameof(entity.PersonPhoneNumbers)))
            if (entity.PersonPhoneNumbers == null || saveParams.Ignore(nameof(entity.PersonPhoneNumbers)))
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SavePersonPhoneNumberOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SavePersonPhoneNumberOption.DeleteMissingItems.ToString();

            var personPhoneNumberRepository = _dataRepositoryFactory.GetDataRepository<IPersonPhoneNumberRepository>();

            var existingPhoneNumbers = personPhoneNumberRepository.GetAllPersonPhoneNumbersForPerson(sessionData, new GetParametersWithPhoto() { PersonUid = entity.PersonUid, IncludeMemberCollections = false }).ToList();

            // Verify that if multiple phone #s are provided, that they have valid Uid values
            // If a single phone is provided and no Uid valid is provided, select the existing Uid if one exists
            if (entity.PersonPhoneNumbers.Any())
            {
                if (entity.PersonPhoneNumbers.Count > 1)
                {
                    var missingUidItems = entity.PersonPhoneNumbers.Where(o => o.PersonPhoneNumberUid == Guid.Empty);
                    if (missingUidItems.Any())
                    {
                        //throw new ApplicationException($"PersonPhoneNumber items are missing PersonPhoneNumberUid values");
                    }
                }
                else
                {   // if only one is provided, check to see if a Uid is provided. If not, see if a phone # exists for the person already and use that Uid for the PK
                    // This will result in the existing phone # being updated
                    var o = entity.PersonPhoneNumbers.FirstOrDefault();
                    if (o != null && o.PersonPhoneNumberUid == Guid.Empty)
                    {
                        var existingItem = existingPhoneNumbers.FirstOrDefault();
                        if (existingItem != null)
                            o.PersonPhoneNumberUid = existingItem.PersonPhoneNumberUid;
                    }
                }
            }

            var deleteThesePhoneNumbers = existingPhoneNumbers.Where(c => entity.PersonPhoneNumbers.All(c2 => c2.PersonPhoneNumberUid != c.PersonPhoneNumberUid)).ToList();

            foreach (var pc in entity.PersonPhoneNumbers)
            {
                if (pc.PersonPhoneNumberUid == Guid.Empty)
                    pc.IsDirty = true;
            }

            var propsToInclude = new List<string>();
            var propsToIgnore = new List<string>();
            propsToIgnore.Add(nameof(PersonPhoneNumber.IsDirty));
            propsToIgnore.Add(nameof(PersonPhoneNumber.IsAnythingDirty));
            propsToIgnore.Add(nameof(PersonPhoneNumber.IsPanelDataDirty));
            propsToIgnore.Add(nameof(PersonPhoneNumber.PersonUid));

            var dirtyPersonPhoneNumbers = new List<PersonPhoneNumber>();
            foreach (var pc in entity.PersonPhoneNumbers)
            {
                var existingItem = existingPhoneNumbers.FirstOrDefault(o => o.PersonPhoneNumberUid == pc.PersonPhoneNumberUid);
                if (existingItem == null)
                {
                    dirtyPersonPhoneNumbers.Add(pc);
                    continue;
                }
                if (pc.PersonUid != existingItem.PersonUid)
                    pc.PersonUid = existingItem.PersonUid;
                if (pc.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(pc, existingItem, propsToInclude, propsToIgnore))
                {
                    dirtyPersonPhoneNumbers.Add(pc);
                }
            }

            if (dirtyPersonPhoneNumbers != null && dirtyPersonPhoneNumbers.Any())
            {
                // spin through all the dirty person credentials
                foreach (var pc in dirtyPersonPhoneNumbers)
                {
                    pc.PersonUid = entity.PersonUid;

                    UpdateTableEntityBaseProperties(pc, sessionData);
                    if (pc.PersonPhoneNumberUid == Guid.Empty)
                    {
                        pc.PersonPhoneNumberUid = GuidUtilities.GenerateComb();
                        personPhoneNumberRepository.Add(pc, sessionData, saveParams);
                    }
                    else
                        personPhoneNumberRepository.Update(pc, sessionData, saveParams);
                }
            }

            if (bDeleteMissingItems)
            {
                foreach (var pc in deleteThesePhoneNumbers)
                {
                    // must explicitly delete the credential first
                    personPhoneNumberRepository.Remove(pc.PersonPhoneNumberUid, sessionData);
                }
            }
        }

        private void SaveEmailAddresses(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //if (entity.PersonEmailAddresses == null || !entity.PersonEmailAddresses.Any() || saveParams.Ignore(nameof(entity.PersonEmailAddresses)))
            if (entity.PersonEmailAddresses == null || saveParams.Ignore(nameof(entity.PersonEmailAddresses)))
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SavePersonEmailAddressOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SavePersonEmailAddressOption.DeleteMissingItems.ToString();


            var personEmailAddressRepository = _dataRepositoryFactory.GetDataRepository<IPersonEmailAddressRepository>();

            var existingEmailAddresses = personEmailAddressRepository.GetAllPersonEmailAddressesForPerson(sessionData, new GetParametersWithPhoto() { PersonUid = entity.PersonUid, IncludeMemberCollections = false }).ToList();

            // Verify that if multiple email addresses are provided, that they have valid Uid values
            // If a single email address is provided and no Uid valid is provided, select the existing Uid if one exists
            if (entity.PersonEmailAddresses.Any())
            {
                if (entity.PersonEmailAddresses.Count > 1)
                {
                    var missingUidItems = entity.PersonEmailAddresses.Where(o => o.PersonEmailAddressUid == Guid.Empty);
                    if (missingUidItems.Any())
                    {
                        //throw new ApplicationException($"PersonEmailAddress items are missing PersonEmailAddressUid values");
                    }
                }
                else
                {   // if only one is provided, check to see if a Uid is provided. If not, see if a email exists for the person already and use that Uid for the PK
                    // This will result in the existing email being updated
                    var o = entity.PersonEmailAddresses.FirstOrDefault();
                    if (o != null && o.PersonEmailAddressUid == Guid.Empty)
                    {
                        var existingEmail = existingEmailAddresses.FirstOrDefault();
                        if (existingEmail != null)
                            o.PersonEmailAddressUid = existingEmail.PersonEmailAddressUid;
                    }
                }
            }


            var deleteTheseEmailAddresses = existingEmailAddresses.Where(c => entity.PersonEmailAddresses.All(c2 => c2.PersonEmailAddressUid != c.PersonEmailAddressUid)).ToList();

            foreach (var pc in entity.PersonEmailAddresses)
            {
                if (pc.PersonEmailAddressUid == Guid.Empty)
                    pc.IsDirty = true;
            }

            var propsToInclude = new List<string>();
            var propsToIgnore = new List<string>();
            propsToIgnore.Add(nameof(PersonEmailAddress.IsDirty));
            propsToIgnore.Add(nameof(PersonEmailAddress.IsAnythingDirty));
            propsToIgnore.Add(nameof(PersonEmailAddress.IsPanelDataDirty));
            propsToIgnore.Add(nameof(PersonEmailAddress.PersonUid));

            var dirtyPersonEmailAddresses = new List<PersonEmailAddress>();
            foreach (var pc in entity.PersonEmailAddresses)
            {
                var existingItem = existingEmailAddresses.FirstOrDefault(o => o.PersonEmailAddressUid == pc.PersonEmailAddressUid);
                if (existingItem == null)
                {
                    dirtyPersonEmailAddresses.Add(pc);
                    continue;
                }
                if (pc.PersonUid != existingItem.PersonUid)
                    pc.PersonUid = existingItem.PersonUid;
                if (pc.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(pc, existingItem, propsToInclude, propsToIgnore))
                {
                    dirtyPersonEmailAddresses.Add(pc);
                }
            }

            if (dirtyPersonEmailAddresses != null && dirtyPersonEmailAddresses.Any())
            {
                // spin through all the dirty person credentials
                foreach (var pc in dirtyPersonEmailAddresses)
                {
                    pc.PersonUid = entity.PersonUid;

                    UpdateTableEntityBaseProperties(pc, sessionData);
                    if (pc.PersonEmailAddressUid == Guid.Empty)
                    {
                        pc.PersonEmailAddressUid = GuidUtilities.GenerateComb();
                        personEmailAddressRepository.Add(pc, sessionData, saveParams);
                    }
                    else
                        personEmailAddressRepository.Update(pc, sessionData, saveParams);
                }
            }

            if (bDeleteMissingItems)
            {
                foreach (var pc in deleteTheseEmailAddresses)
                {
                    // must explicitly delete the credential first
                    personEmailAddressRepository.Remove(pc.PersonEmailAddressUid, sessionData);
                }
            }
        }

        private void SaveAddresses(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            if (saveParams.Ignore(nameof(entity.PersonAddresses)))
                return;
        }

        private void SavePhotos(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            return;
            if (saveParams.SavePhoto == false || saveParams.Ignore(nameof(entity.PersonPhotos)) || entity.PersonPhotos == null)
                return;

            var photoRepository = _dataRepositoryFactory.GetDataRepository<IPersonPhotoRepository>();
            var existingPhotos = photoRepository.GetAllPersonPhotosForPerson(sessionData, new GetParametersWithPhoto()
            {
                PersonUid = entity.PersonUid,
            });


            //var dirtyPhotos = entity.PersonPhotos.Where(o => o.IsDirty == true).ToList();
            var dirtyPhotos = new List<PersonPhoto>();
            if (!existingPhotos.Any())
                dirtyPhotos.AddRange(entity.PersonPhotos);
            else
            {
                foreach (var photo in entity.PersonPhotos)
                {
                    if (string.IsNullOrEmpty(photo.Tag))
                        photo.Tag = "*";
                    PersonPhoto existingPhoto = null;
                    if (photo.PersonPhotoUid != Guid.Empty)
                        existingPhoto = existingPhotos.FirstOrDefault(o => o.PersonPhotoUid == photo.PersonPhotoUid);
                    if (existingPhoto == null)
                        existingPhoto = existingPhotos.FirstOrDefault(o => o.Tag == photo.Tag);
                    if (existingPhoto == null)
                        dirtyPhotos.Add(photo);
                    else if (existingPhoto.PhotoImage.Length != photo.PhotoImage.Length)
                        dirtyPhotos.Add(photo);
                    else if (existingPhoto.PhotoImage.Length == photo.PhotoImage.Length)
                    {
                        for (int x = 0; x < photo.PhotoImage.Length; x++)
                        {
                            if (photo.PhotoImage[x] != existingPhoto.PhotoImage[x])
                            {
                                dirtyPhotos.Add(photo);
                                break;
                            }
                        }
                    }

                }
            }
            if (dirtyPhotos.Count > 0)
            {
                foreach (var photo in dirtyPhotos)
                {
                    if (string.IsNullOrEmpty(photo.Tag))
                        photo.Tag = "*";
                    photo.PersonUid = entity.PersonUid;
                    UpdateTableEntityBaseProperties(photo, sessionData);
                    if (photo.PersonPhotoUid == Guid.Empty)
                    {
                        photo.PersonPhotoUid = GuidUtilities.GenerateComb();
                        photoRepository.Add(photo, sessionData, saveParams);
                    }
                    else
                        photoRepository.Update(photo, sessionData, saveParams);
                }
            }
        }

        private void SavePersonCredentials(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //            if (entity.PersonCredentials == null || !entity.PersonCredentials.Any() || saveParams.Ignore(nameof(entity.PersonCredentials)))
            if (entity.PersonCredentials == null || saveParams.Ignore(nameof(entity.PersonCredentials)))
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SavePersonCredentialOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SavePersonCredentialOption.DeleteMissingItems.ToString();

            var credentialRepository = _dataRepositoryFactory.GetDataRepository<ICredentialRepository>();
            var personCredentialRepository = _dataRepositoryFactory.GetDataRepository<IPersonCredentialRepository>();

            var existingCredentials = personCredentialRepository.GetAllPersonCredentialsForPerson(sessionData, new GetParametersWithPhoto() { PersonUid = entity.PersonUid, IncludeMemberCollections = true }).ToList();
            var deleteTheseCredentials = existingCredentials.Where(c => entity.PersonCredentials.All(c2 => c2.PersonCredentialUid != c.PersonCredentialUid)).ToList();

            foreach (var pc in entity.PersonCredentials)
            {
                if (pc.PersonCredentialUid == Guid.Empty)
                    pc.IsDirty = true;
                if (pc.PersonExpirationModeUid == GalaxySMS.Common.Constants.PersonExpirationModeIds.ExpireByDate)
                {
                    if (pc.ExpirationDateTime.HasValue)
                    {
                        if (pc.ExpirationDateTime.Value.Hour != 23 || pc.ExpirationDateTime.Value.Minute != 59 ||
                            pc.ExpirationDateTime.Value.Second != 59)
                        {
                            pc.ExpirationDateTime = new DateTimeOffset(pc.ExpirationDateTime.Value.Year,
                                pc.ExpirationDateTime.Value.Month, pc.ExpirationDateTime.Value.Day,
                                23, 59, 59, TimeSpan.Zero);
                            pc.IsDirty = true;
                        }
                    }
                }

                if (pc.PersonExpirationModeUid == GalaxySMS.Common.Constants.PersonExpirationModeIds.ExpireByDate ||
                    pc.PersonExpirationModeUid == GalaxySMS.Common.Constants.PersonExpirationModeIds.ExpireByDateAndTime ||
                    pc.PersonExpirationModeUid == GalaxySMS.Common.Constants.PersonExpirationModeIds.ExpireByDateAndTimeAndUsageCount)
                {
                    if (!pc.ExpirationDateTime.HasValue)
                    {
                        pc.ExpirationDateTime = DateTimeOffset.Now.MaxSqlDateTime();
                        pc.IsDirty = true;
                    }
                }

                if (pc.PersonActivationModeUid == GalaxySMS.Common.Constants.PersonActivationModeIds.ActivateByDate ||
                    pc.PersonActivationModeUid == GalaxySMS.Common.Constants.PersonActivationModeIds.ActivateByDateAndTime)
                {
                    if (!pc.ActivationDateTime.HasValue)
                    {
                        pc.ActivationDateTime = DateTimeOffset.Now.MinSqlDateTime().AddMinutes(1);
                        pc.IsDirty = true;
                    }
                }
            }

            var propsToInclude = new List<string>();
            var propsToIgnore = new List<string>();
            propsToIgnore.Add(nameof(PersonCredential.IsDirty));
            propsToIgnore.Add(nameof(PersonCredential.IsAnythingDirty));
            propsToIgnore.Add(nameof(PersonCredential.IsPanelDataDirty));
            propsToIgnore.Add(nameof(PersonCredential.PersonUid));
            propsToIgnore.Add(nameof(PersonCredential.CredentialUid));
            propsToIgnore.Add(nameof(Credential.CredentialFormat));
            propsToIgnore.Add(nameof(Credential.CardBinaryData));
            propsToIgnore.Add(nameof(Credential.CredentialFormatDescription));
            propsToIgnore.Add(nameof(Credential.CredentialValueDescription));
            propsToIgnore.Add(nameof(Credential.CredentialPartsString));
            propsToIgnore.Add(nameof(Credential.CredentialFormatCodeAndPartsString));


            var dirtyPersonCredentials = new List<PersonCredential>();
            var x = 0;
            var y = 0;
            foreach (var pc in entity.PersonCredentials)
            {
                pc.IndexValue = x++;
                pc.OwnerPropertyName = nameof(entity.PersonCredentials);
                var existingItem = existingCredentials.FirstOrDefault(o => o.PersonCredentialUid == pc.PersonCredentialUid);
                if (existingItem == null)
                {
                    dirtyPersonCredentials.Add(pc);
                    continue;
                }
                if (pc.PersonUid != existingItem.PersonUid)
                    pc.PersonUid = existingItem.PersonUid;
                if (pc.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(pc, existingItem, propsToInclude, propsToIgnore))
                {
                    dirtyPersonCredentials.Add(pc);
                }
            }

            if (bDeleteMissingItems)
            {
                foreach (var pc in deleteTheseCredentials)
                {
                    // must explicitly delete the credential first
                    personCredentialRepository.Remove(pc.PersonCredentialUid, sessionData);
                    credentialRepository.Remove(pc.CredentialUid, sessionData);
                }
            }

            //var dirtyPersonCredentials = entity.PersonCredentials.Where(o => o.IsAnythingDirty).ToCollection();
            if (dirtyPersonCredentials != null && dirtyPersonCredentials.Any())
            {
                // spin through all the dirty person credentials
                foreach (var pc in dirtyPersonCredentials)
                {
                    // Step 1: Add or Update the Credential
                    pc.Credential.IndexValue = y++;
                    pc.Credential.OwnerPropertyName = nameof(entity.PersonCredentials);
                    pc.Credential.MyPropertyName = nameof(pc.Credential);
                    pc.Credential = credentialRepository.SaveCredential(pc.Credential, sessionData, saveParams);

                    // Step 2, add or update the PersonCredential
                    pc.PersonUid = entity.PersonUid;
                    pc.CredentialUid = pc.Credential.CredentialUid;

                    UpdateTableEntityBaseProperties(pc, sessionData);
                    if (pc.PersonCredentialUid == Guid.Empty)
                    {
                        pc.PersonCredentialUid = GuidUtilities.GenerateComb();
                        personCredentialRepository.Add(pc, sessionData, saveParams);
                    }
                    else
                        personCredentialRepository.Update(pc, sessionData, saveParams);
                }
            }

            //if (bDeleteMissingItems)
            //{
            //    foreach (var pc in deleteTheseCredentials)
            //    {
            //        // must explicitly delete the credential first
            //        personCredentialRepository.Remove(pc.PersonCredentialUid, sessionData);
            //        credentialRepository.Remove(pc.CredentialUid, sessionData);
            //    }
            //}
        }

        private void DeletePersonCredentials(Person entity, IApplicationUserSessionDataHeader sessionData)
        {
            var credentialRepository = _dataRepositoryFactory.GetDataRepository<ICredentialRepository>();
            var personCredentialRepository = _dataRepositoryFactory.GetDataRepository<IPersonCredentialRepository>();

            var existingCredentials = personCredentialRepository.GetAllPersonCredentialsForPerson(sessionData, new GetParametersWithPhoto() { PersonUid = entity.PersonUid }).ToList();

            foreach (var pc in existingCredentials)
            {
                // must explicitly delete the credential first
                personCredentialRepository.Remove(pc.PersonCredentialUid, sessionData);
                credentialRepository.Remove(pc.CredentialUid, sessionData);
            }
        }

        //private void SavePersonClusterPermissions(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    if (entity.PersonClusterPermissions == null || !entity.PersonClusterPermissions.Any() || saveParams.Ignore(nameof(entity.PersonClusterPermissions)))
        //        return;

        //    var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SavePersonClusterPermissionOption).ToString());

        //    bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
        //                               !string.IsNullOrEmpty(kvpSaveOption.Value) &&
        //                               kvpSaveOption.Value == SavePersonClusterPermissionOption.DeleteMissingItems.ToString();

        //    var personClusterPermissionRepository = _dataRepositoryFactory.GetDataRepository<IPersonClusterPermissionRepository>();

        //    var existingClusterPermissions = personClusterPermissionRepository.GetAllPersonClusterPermissionsForPerson(sessionData, new GetParametersWithPhoto() { PersonUid = entity.PersonUid, IncludeMemberCollections = true }).ToList();
        //    var deleteTheseClusterPermissions = existingClusterPermissions.Where(c => entity.PersonClusterPermissions.All(c2 => c2.PersonClusterPermissionUid != c.PersonClusterPermissionUid)).ToList();

        //    foreach (var pcp in entity.PersonClusterPermissions)
        //    {
        //        if (pcp.PersonClusterPermissionUid == Guid.Empty)
        //            pcp.IsDirty = true;
        //    }

        //    var dirtyClusterPermissions = entity.PersonClusterPermissions.Where(o => o.IsAnythingDirty).ToCollection();

        //    var propsToInclude = new List<string>();

        //    if (dirtyClusterPermissions != null && dirtyClusterPermissions.Any())
        //    {
        //        // spin through all the dirty person cluster permissions
        //        foreach (var cp in dirtyClusterPermissions)
        //        {
        //            cp.PersonUid = entity.PersonUid;

        //            var existingClusterPerm = existingClusterPermissions.FirstOrDefault(o => o.ClusterUid == cp.ClusterUid);
        //            if (existingClusterPerm != null)
        //            {
        //                cp.PersonClusterPermissionUid = existingClusterPerm.PersonClusterPermissionUid;

        //                foreach (var pag in existingClusterPerm.PersonAccessGroups)
        //                {
        //                    var newpag = cp.PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == pag.OrderNumber);
        //                    if (newpag != null)
        //                    {
        //                        newpag.PersonAccessGroupUid = pag.PersonAccessGroupUid;
        //                        newpag.PersonClusterPermissionUid = pag.PersonClusterPermissionUid;
        //                        UpdateTableEntityBasePropertiesFromExisting(newpag, pag);
        //                    }
        //                }

        //                foreach (var piog in existingClusterPerm.PersonInputOutputGroups)
        //                {
        //                    var newpiog = cp.PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == piog.OrderNumber);
        //                    if (newpiog != null)
        //                    {
        //                        newpiog.PersonInputOutputGroupUid = piog.PersonInputOutputGroupUid;
        //                        newpiog.PersonClusterPermissionUid = piog.PersonClusterPermissionUid;
        //                        UpdateTableEntityBasePropertiesFromExisting(newpiog, piog);
        //                    }
        //                }

        //                UpdateTableEntityBasePropertiesFromExisting(cp, existingClusterPerm);
        //                var deleteClusterPerm = deleteTheseClusterPermissions.FirstOrDefault(o => o.PersonClusterPermissionUid == cp.PersonClusterPermissionUid);
        //                if (deleteClusterPerm != null)
        //                    deleteTheseClusterPermissions.Remove(deleteClusterPerm);
        //            }
        //            UpdateTableEntityBaseProperties(cp, sessionData);
        //            if (cp.PersonClusterPermissionUid == Guid.Empty)
        //            {
        //                cp.PersonClusterPermissionUid = GuidUtilities.GenerateComb();
        //                personClusterPermissionRepository.Add(cp, sessionData, null, saveParams);
        //            }
        //            else
        //                personClusterPermissionRepository.Update(cp, sessionData, null, saveParams);
        //        }
        //    }

        //    if (bDeleteMissingItems)
        //    {
        //        foreach (var cp in deleteTheseClusterPermissions)
        //        {
        //            // must explicitly delete the credential first
        //            personClusterPermissionRepository.Remove(cp.PersonClusterPermissionUid, sessionData);
        //        }
        //    }
        //}
        private void SavePersonClusterPermissions(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //            if (entity.PersonClusterPermissions == null || !entity.PersonClusterPermissions.Any() || saveParams.Ignore(nameof(entity.PersonClusterPermissions)))
            if (entity.PersonClusterPermissions == null || saveParams.Ignore(nameof(entity.PersonClusterPermissions)))
                return;

            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SavePersonClusterPermissionOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SavePersonClusterPermissionOption.DeleteMissingItems.ToString();

            var personClusterPermissionRepository = _dataRepositoryFactory.GetDataRepository<IPersonClusterPermissionRepository>();

            var existingClusterPermissions = personClusterPermissionRepository.GetAllPersonClusterPermissionsForPerson(sessionData, new GetParametersWithPhoto() { PersonUid = entity.PersonUid, IncludeMemberCollections = true }).ToList();

            if (entity?.PersonAccessControlProperty?.AccessProfileUid != null && entity?.PersonAccessControlProperty?.AccessProfileUid != Guid.Empty)
            {
                // If an access profile is specified, enforce the access profile settings BEFORE saving the record
                var accessProfileRepository = _dataRepositoryFactory.GetDataRepository<IAccessProfileRepository>();

                // retrieve the access profile definition
                var ap = accessProfileRepository.Get(entity.PersonAccessControlProperty.AccessProfileUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true, UniqueId = entity.PersonAccessControlProperty.AccessProfileUid });

                // Retrieve the entity to get access to the settings that determine which access groups and i-o groups the access profile controls
                var entityRepository = _dataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();

                var getEntityParameters = new GetParametersWithPhoto()
                {
                    IncludeMemberCollections = true,
                    IncludePhoto = false,
                };
                getEntityParameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.AllRoles));
                getEntityParameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.UserRequirements));
                getEntityParameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.TheLicense));
                getEntityParameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.ParentEntity));
                getEntityParameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.ChildEntities));
                var theEntity = entityRepository.Get(entity.EntityId, sessionData, getEntityParameters);

                var tempPersonClusterPermissions = entity.PersonClusterPermissions.ToList();
                // if the access profile and the entity were successfully retrieved, proceed with comparison and validation
                if (ap != null && theEntity != null)
                {
                    // iterate though all clusters that are assigned to the access profile
                    foreach (var accessProfileCluster in ap.AccessProfileClusters)
                    {
                        // Get the incoming cluster permissions from the client
                        var personClusterPermission = tempPersonClusterPermissions.FirstOrDefault(o => o.ClusterUid == accessProfileCluster.ClusterUid);

                        // Get the current cluster permissions from the database. If the client caller omitted the cluster, it may need to be preserved
                        var existingClusterPermission = existingClusterPermissions.FirstOrDefault(o => o.ClusterUid == accessProfileCluster.ClusterUid);

                        if (personClusterPermission == null && existingClusterPermission != null)
                        {// the client omitted this cluster, so add it back into the collection
                            tempPersonClusterPermissions.Add(existingClusterPermission);
                        }
                        else if (personClusterPermission == null)
                        {   // if the cluster was omitted AND the database has none either, add a new PersonClusterPermission to the collection to match the access profile
                            personClusterPermission = new PersonClusterPermission()
                            {
                                ClusterUid = accessProfileCluster.ClusterUid,
                                IsDirty = true,
                            };
                            tempPersonClusterPermissions.Add(personClusterPermission);
                        }

                        if (theEntity.AccessProfileControlsAG1)
                        {
                            SetAccessGroupFromProfile(accessProfileCluster, personClusterPermission, 1);
                        }

                        if (theEntity.AccessProfileControlsAG2)
                        {
                            SetAccessGroupFromProfile(accessProfileCluster, personClusterPermission, 2);
                        }

                        if (theEntity.AccessProfileControlsAG3)
                        {
                            SetAccessGroupFromProfile(accessProfileCluster, personClusterPermission, 3);
                        }

                        if (theEntity.AccessProfileControlsAG4)
                        {
                            SetAccessGroupFromProfile(accessProfileCluster, personClusterPermission, 4);
                        }

                        if (theEntity.AccessProfileControlsIO1)
                        {
                            SetInputOutputGroupFromProfile(accessProfileCluster, personClusterPermission, 1);
                        }

                        if (theEntity.AccessProfileControlsIO2)
                        {
                            SetInputOutputGroupFromProfile(accessProfileCluster, personClusterPermission, 2);
                        }

                        if (theEntity.AccessProfileControlsIO3)
                        {
                            SetInputOutputGroupFromProfile(accessProfileCluster, personClusterPermission, 3);
                        }

                        if (theEntity.AccessProfileControlsIO4)
                        {
                            SetInputOutputGroupFromProfile(accessProfileCluster, personClusterPermission, 4);
                        }
                    }

 //                   entity.PersonClusterPermissions = tempPersonClusterPermissions.ToCollection();
                    entity.PersonClusterPermissions = tempPersonClusterPermissions.ToList();
                }
            }

            var deleteTheseClusterPermissions = existingClusterPermissions.Where(c => entity.PersonClusterPermissions.All(c2 => c2.PersonClusterPermissionUid != c.PersonClusterPermissionUid)).ToList();

            foreach (var pcp in entity.PersonClusterPermissions)
            {
                if (pcp.PersonClusterPermissionUid == Guid.Empty)
                    pcp.IsDirty = true;
            }

            var propsToInclude = new List<string>();

            var propsToIgnore = new List<string>();
            propsToIgnore.Add(nameof(PersonClusterPermission.IsDirty));
            propsToIgnore.Add(nameof(PersonClusterPermission.IsAnythingDirty));
            propsToIgnore.Add(nameof(PersonClusterPermission.IsPanelDataDirty));
            propsToIgnore.Add(nameof(PersonClusterPermission.PersonUid));
            propsToIgnore.Add(nameof(PersonClusterPermission.CredentialBits));

            var dirtyClusterPermissions = new List<PersonClusterPermission>();
            var x = 0;
            var y = 0;
            foreach (var pcp in entity.PersonClusterPermissions)
            {
                pcp.IndexValue = x++;
                pcp.OwnerPropertyName = nameof(entity.PersonClusterPermissions);
                //pcp.MyPropertyName = nameof(PersonClusterPermission);

                var existingItem = existingClusterPermissions.FirstOrDefault(o => o.ClusterUid == pcp.ClusterUid);
                if (existingItem == null)
                    existingItem = new PersonClusterPermission();

                // Now account for PersonAccessGroupUid values that may be Guid.Empty. Match up by OrderNumber
                var syncTheseAccessGroups = pcp.PersonAccessGroups.Where(o => o.PersonAccessGroupUid == Guid.Empty).ToList();
                foreach (var ag in syncTheseAccessGroups)
                {
                    var existingAg = existingItem.PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == ag.OrderNumber);
                    if (existingAg != null)
                        ag.PersonAccessGroupUid = existingAg.PersonAccessGroupUid;
                }

                // Now account for PersonInputOutputGroupUid values that may be Guid.Empty. Match up by OrderNumber
                var syncTheseIoGroups = pcp.PersonInputOutputGroups.Where(o => o.PersonInputOutputGroupUid == Guid.Empty).ToList();
                foreach (var iog in syncTheseIoGroups)
                {
                    var existingIog = existingItem.PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == iog.OrderNumber);
                    if (existingIog != null)
                        iog.PersonInputOutputGroupUid = existingIog.PersonInputOutputGroupUid;
                }

                if (pcp.IsAnythingDirty || ObjectComparer.AreAnyPublicPropertiesDifferent(pcp, existingItem, propsToInclude, propsToIgnore))
                {
                    dirtyClusterPermissions.Add(pcp);
                }
            }

            // spin through all the dirty person cluster permissions
            foreach (var cp in dirtyClusterPermissions)
            {
                cp.PersonUid = entity.PersonUid;

                var existingClusterPerm = existingClusterPermissions.FirstOrDefault(o => o.ClusterUid == cp.ClusterUid);
                if (existingClusterPerm != null)
                {
                    cp.PersonClusterPermissionUid = existingClusterPerm.PersonClusterPermissionUid;

                    foreach (var pag in existingClusterPerm.PersonAccessGroups)
                    {
                        var newpag = cp.PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == pag.OrderNumber);
                        if (newpag != null)
                        {
                            newpag.PersonAccessGroupUid = pag.PersonAccessGroupUid;
                            newpag.PersonClusterPermissionUid = pag.PersonClusterPermissionUid;
                            UpdateTableEntityBasePropertiesFromExisting(newpag, pag);
                        }
                    }

                    foreach (var piog in existingClusterPerm.PersonInputOutputGroups)
                    {
                        var newpiog = cp.PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == piog.OrderNumber);
                        if (newpiog != null)
                        {
                            newpiog.PersonInputOutputGroupUid = piog.PersonInputOutputGroupUid;
                            newpiog.PersonClusterPermissionUid = piog.PersonClusterPermissionUid;
                            UpdateTableEntityBasePropertiesFromExisting(newpiog, piog);
                        }
                    }

                    UpdateTableEntityBasePropertiesFromExisting(cp, existingClusterPerm);
                    var deleteClusterPerm = deleteTheseClusterPermissions.FirstOrDefault(o => o.PersonClusterPermissionUid == cp.PersonClusterPermissionUid);
                    if (deleteClusterPerm != null)
                        deleteTheseClusterPermissions.Remove(deleteClusterPerm);
                }
                UpdateTableEntityBaseProperties(cp, sessionData);
                if (cp.PersonClusterPermissionUid == Guid.Empty)
                {
                    cp.PersonClusterPermissionUid = GuidUtilities.GenerateComb();
                    personClusterPermissionRepository.Add(cp, sessionData, saveParams);
                }
                else
                    personClusterPermissionRepository.Update(cp, sessionData, saveParams);
            }

            if (bDeleteMissingItems)
            {
                foreach (var cp in deleteTheseClusterPermissions)
                {
                    // must explicitly delete the credential first
                    personClusterPermissionRepository.Remove(cp.PersonClusterPermissionUid, sessionData);
                }
            }
        }

        private static void SetAccessGroupFromProfile(AccessProfileCluster accessProfileCluster, PersonClusterPermission personClusterPermission, short orderNumber)
        {
            var apag = accessProfileCluster.AccessProfileAccessGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
            var pag = personClusterPermission.PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (pag == null)
            {
                pag = new PersonAccessGroup()
                {
                    OrderNumber = orderNumber,
                };
                personClusterPermission.PersonAccessGroups.Add(pag);
            }
            if (apag != null)
                pag.AccessGroupUid = apag.AccessGroupUid;
        }

        private static void SetInputOutputGroupFromProfile(AccessProfileCluster accessProfileCluster, PersonClusterPermission personClusterPermission, short orderNumber)
        {
            var apiog = accessProfileCluster.AccessProfileInputOutputGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
            var poig = personClusterPermission.PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (poig == null)
            {
                poig = new PersonInputOutputGroup()
                {
                    OrderNumber = orderNumber,
                };
                personClusterPermission.PersonInputOutputGroups.Add(poig);
            }
            if (apiog != null)
                poig.InputOutputGroupUid = apiog.InputOutputGroupUid;
        }

        public Person SyncPersonWithAccessProfile(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var p = new GetParametersWithPhoto()
            {
                PersonUid = getParameters.PersonUid,
                IncludeMemberCollections = true,
                IncludePhoto = false,
            };

            p.ExcludeMemberCollectionSettings.Add(nameof(Person.PersonAddresses));
            p.ExcludeMemberCollectionSettings.Add(nameof(Person.PersonEmailAddresses));
            p.ExcludeMemberCollectionSettings.Add(nameof(Person.PersonPhoneNumbers));
            p.ExcludeMemberCollectionSettings.Add(nameof(Person.PersonLcdMessages));
            p.ExcludeMemberCollectionSettings.Add(nameof(Person.PersonPropertyBags));
            p.ExcludeMemberCollectionSettings.Add(nameof(Person.PersonNotes));
            p.ExcludeMemberCollectionSettings.Add(nameof(Person.Notes));
            p.ExcludeMemberCollectionSettings.Add(nameof(Person.PersonCredentials));

            var person = GetEntityByGuidId(p.PersonUid, sessionData, p);
            if (person == null || person.PersonAccessControlProperty == null || person.PersonAccessControlProperty.AccessProfileUid == GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None)
                return GetEntityByGuidId(getParameters.PersonUid, sessionData, getParameters);

            var accessProfileRepository = _dataRepositoryFactory.GetDataRepository<IAccessProfileRepository>();


            // Grabbing all the access profile permissions
            var ap = accessProfileRepository.Get(person.PersonAccessControlProperty.AccessProfileUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = true, });
            if (ap == null)
                return GetEntityByGuidId(getParameters.PersonUid, sessionData, getParameters);

            // Grab the gcsEntity for the person, so that i can determine which access and io groups the access profile controls
            var getEntityParams = new GetParametersWithPhoto()
            {
                IncludePhoto = false,
                IncludeMemberCollections = true,
            };

            getEntityParams.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.AllRoles));
            getEntityParams.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.UserRequirements));
            getEntityParams.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.TheLicense));
            getEntityParams.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.ParentEntity));
            getEntityParams.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.ChildEntities));

            var entityRepository = _dataRepositoryFactory.GetDataRepository<IGcsEntityRepository>();
            var theEntity = entityRepository.Get(person.EntityId, sessionData, getEntityParams);
            if (theEntity == null)
                return GetEntityByGuidId(getParameters.PersonUid, sessionData, getParameters);

            // Add any missing clusters
            var missingPersonClusterPermissions = ap.AccessProfileClusters.Where(o => person.PersonClusterPermissions.All(p2 => p2.ClusterUid != o.ClusterUid));

            // Now add any clusters to the person that are not already assigned to the person
            foreach (var apcp in missingPersonClusterPermissions)
            {
                var pcp = new PersonClusterPermission()
                {
                    ClusterUid = apcp.ClusterUid
                };
            }

            var deleteThesePersonClusterPermissions = new List<PersonClusterPermission>();

            // Now that I have the existing permissions for the person and the profile, start comparing, adding, deleting and updating the person permissions
            foreach (var pcp in person.PersonClusterPermissions)
            {
                // see if the cluster is included in the profile. If not, delete it from the person, if it is, then ensure that all access groups and IO groups match the profile definition
                var apcp = ap.AccessProfileClusters.FirstOrDefault(o => o.ClusterUid == pcp.ClusterUid);
                if (apcp == null)
                    deleteThesePersonClusterPermissions.Add(pcp);
                else
                {   // compare each of the four access groups and io groups, and update if they don't match
                    short orderNumber = 1;
                    if (theEntity.AccessProfileControlsAG1)
                    {
                        SyncPersonAccessGroupWithProfile(pcp, apcp, orderNumber);
                    }
                    if (theEntity.AccessProfileControlsIO1)
                    {
                        SyncPersonIoGroupWithProfile(pcp, apcp, orderNumber);
                    }

                    orderNumber++;
                    if (theEntity.AccessProfileControlsAG2)
                    {
                        SyncPersonAccessGroupWithProfile(pcp, apcp, orderNumber);
                    }
                    if (theEntity.AccessProfileControlsIO2)
                    {
                        SyncPersonIoGroupWithProfile(pcp, apcp, orderNumber);
                    }

                    orderNumber++;
                    if (theEntity.AccessProfileControlsAG3)
                    {
                        SyncPersonAccessGroupWithProfile(pcp, apcp, orderNumber);
                    }
                    if (theEntity.AccessProfileControlsIO3)
                    {
                        SyncPersonIoGroupWithProfile(pcp, apcp, orderNumber);
                    }

                    orderNumber++;
                    if (theEntity.AccessProfileControlsAG4)
                    {
                        SyncPersonAccessGroupWithProfile(pcp, apcp, orderNumber);
                    }
                    if (theEntity.AccessProfileControlsIO4)
                    {
                        SyncPersonIoGroupWithProfile(pcp, apcp, orderNumber);
                    }
                }
            }

            foreach (var pcp in deleteThesePersonClusterPermissions)
            {
                person.PersonClusterPermissions.Remove(pcp);
            }

            SavePersonClusterPermissions(person, sessionData, new SaveParameters());

            return GetEntityByGuidId(getParameters.PersonUid, sessionData, getParameters);

        }
        public Guid GetEntityId(Guid personUid)
        {
            var mgr = new GetEntityIdForPersonPDSAManager();
            mgr.Entity.personUid = personUid;
            var results = mgr.BuildCollection();

            if (results.Count > 0)
                return results[0].EntityId;
            return Guid.Empty;
        }

        public IEnumerable<PersonInfoWithMissingPhotoUrl> GetAllPersonsWithMissingPhotoUrl(Guid entityId)
        {
            var mgr = new SelectPersonsWithPhotosMissingPublicUrlPDSAManager();
            mgr.Entity.EntityId = entityId;
            var results = mgr.BuildCollection();
            var returnData = new List<PersonInfoWithMissingPhotoUrl>();
            foreach (var r in results)
            {
                returnData.Add(new PersonInfoWithMissingPhotoUrl()
                {
                    PersonUid = r.PersonUid,
                    EntityId = r.EntityId,
                    LastName = r.LastName,
                    FirstName = r.FirstName
                });
            }

            return returnData;
        }

        public string GetPersonIdForPerson(Guid personUid)
        {
            var mgr = new GetPersonIdForPersonPDSAManager();
            mgr.Entity.personUid = personUid;
            var results = mgr.BuildCollection();

            if (results.Count > 0)
                return results[0].PersonId;
            return string.Empty;
        }

        public string GenerateUniquePersonId(Guid entityId, IApplicationUserSessionDataHeader sessionData)
        {
            var settingsRepo = _dataRepositoryFactory.GetDataRepository<IGcsSettingRepository>();
            var prefix = settingsRepo.GetByUniqueKey(entityId, gcsSettingGroup.gcsEntity, gcsSettingSubGroup.PersonId, gcsSettingKey.Prefix, DefaultSettingValues.PersonIdPrefix, true, sessionData);
            var suffix = settingsRepo.GetByUniqueKey(entityId, gcsSettingGroup.gcsEntity, gcsSettingSubGroup.PersonId, gcsSettingKey.Suffix, DefaultSettingValues.PersonIdSuffix, true, sessionData);
            var uniquePartLength = settingsRepo.GetByUniqueKey(entityId, gcsSettingGroup.gcsEntity, gcsSettingSubGroup.PersonId, gcsSettingKey.UniquePartLength, DefaultSettingValues.PersonIdDefaultUniquePartLength, true, sessionData);
            var useRandomizedString = settingsRepo.GetByUniqueKey(entityId, gcsSettingGroup.gcsEntity, gcsSettingSubGroup.PersonId, gcsSettingKey.UseRandomizedString, DefaultSettingValues.PersonIdUseRandomizedString, true, sessionData);
            if (prefix == "`")
                prefix = string.Empty;
            if (suffix == "`")
                suffix = string.Empty;

            var exists = false;
            var personId = string.Empty;
            while (true)
            {
                var uniquePart = MakeUniquePersonIdPart(useRandomizedString, uniquePartLength);
                personId = $"{prefix}{uniquePart}{suffix}";
                if (personId.Length > 65)
                    personId = personId.Remove(65);
                var personUid = GetPersonUidFromPersonId(entityId, personId);
                if (personUid == Guid.Empty)
                    break;
            }

            return personId;

        }

        private string MakeUniquePersonIdPart(bool useRandomizedString, int uniquePartLength)
        {
            var uniquePart = string.Empty;
            if (useRandomizedString)
            {
                uniquePart = GCS.Core.Common.Extensions.StringExtensions.GenerateRandomString(uniquePartLength, false).ToUpper();
            }
            else
            {
                var now = DateTimeOffset.UtcNow;
                uniquePart =
                    $"{now.Year:D4}{now.Month:D2}{now.Day:D2}{now.Hour:D2}{now.Minute:D2}{now.Second:D2}{now.Millisecond:D3}";
            }

            if (uniquePart.Length < uniquePartLength)
                uniquePart = uniquePart.PadLeft(uniquePartLength, '0');
            return uniquePart;
        }

        private Guid GetPersonUidFromPersonId(Guid entityId, string personId)
        {
            var mgr = new GetPersonUidFromPersonIdPDSAManager();
            mgr.Entity.entityId = entityId;
            mgr.Entity.personId = personId;
            var results = mgr.BuildCollection();

            if (results.Count > 0)
                return results[0].PersonUid;
            return Guid.Empty;
        }

        private static void SyncPersonIoGroupWithProfile(PersonClusterPermission pcp, AccessProfileCluster apcp, short orderNumber)
        {
            var apiog = apcp.AccessProfileInputOutputGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
            var personIog = pcp.PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (apiog != null && personIog == null)
            {
                personIog = new PersonInputOutputGroup() { OrderNumber = orderNumber };
                pcp.PersonInputOutputGroups.Add(personIog);
            }

            if (apiog != null && personIog != null && apiog.InputOutputGroupUid != personIog.InputOutputGroupUid)
                personIog.InputOutputGroupUid = apiog.InputOutputGroupUid;
        }

        private static void SyncPersonAccessGroupWithProfile(PersonClusterPermission pcp, AccessProfileCluster apcp, short orderNumber)
        {
            var apag = apcp.AccessProfileAccessGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
            var personAg = pcp.PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (apag != null && personAg == null)
            {
                personAg = new PersonAccessGroup() { OrderNumber = orderNumber };
                pcp.PersonAccessGroups.Add(personAg);
            }

            if (apag != null && personAg != null && apag.AccessGroupUid != personAg.AccessGroupUid)
                personAg.AccessGroupUid = apag.AccessGroupUid;
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("Person", "PersonUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("Person", "PersonUid", id);
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

        protected override bool IsEntityUnique(Person entity)
        {
            var mgr = new IsPersonUniquePDSAManager();
            mgr.Entity.PersonUid = entity.PersonUid;
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.PersonId = entity.PersonId;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("Person", "PersonUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("Person", "PersonUid", id);
            if (count == 0)
                return true;
            return false;
        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertPersonCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        public void OnImportsSatisfied()
        {
        }


    }
}
