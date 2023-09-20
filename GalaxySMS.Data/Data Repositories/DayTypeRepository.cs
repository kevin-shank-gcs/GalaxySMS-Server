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
using System.Globalization;
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
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Data;

namespace GalaxySMS.Data
{
    [Export(typeof(IDayTypeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DayTypeRepository : PagedDataRepositoryBase<DayType>, IDayTypeRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private IDayTypeEntityMapRepository _entityMapRepository;
        [Import]
        private IDateTypeRepository _dateTypeRepository;

        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        protected override DayType AddEntity(DayType entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.DayTypeUid == GalaxySMS.Common.Constants.DayTypeIds.DayType_Never || 
                //    entity.DayTypeUid == GalaxySMS.Common.Constants.DayTypeIds.DayType_Always)
                //{
                //    _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                //    _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);
                //}
                var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveDayTypeOption.SaveDates).ToString());
                bool bSaveDates = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                  !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                  kvpSaveOption.Value == SaveDayTypeOption.SaveDates.ToString();

                if (!entity.IsActive)
                {
                    bSaveDates = true;
                    entity.Dates = new HashSet<DateType>();
                }

                if (bSaveDates && (entity.Dates == null || !entity.Dates.Any()))
                {
                    entity.IsActive = false;
                    entity.Name = GetDefaultDayTypeName(entity.DayTypeCode);
                    entity.HighlightColor = 0;
                }

                var mgr = new DayTypePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    SaveEntityMappings(sessionData, entity.DayTypeUid, entity, saveParams);
                    if (bSaveDates)
                        SaveDates(entity, sessionData, saveParams);
                    var result = GetEntityByGuidId(entity.DayTypeUid, sessionData, new GetParametersWithPhoto(saveParams)
                    {
                    });
                    if (result != null)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::AddEntity", ex);
                throw;
            }
        }

        protected override DayType UpdateEntity(DayType entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.DayTypeUid == GalaxySMS.Common.Constants.DayTypeIds.DayType_Never ||
                //    entity.DayTypeUid == GalaxySMS.Common.Constants.DayTypeIds.DayType_Always)
                //{ 
                //    _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                //    _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);
                //}
                var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveDayTypeOption.SaveDates).ToString());
                bool bSaveDates = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                  !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                  kvpSaveOption.Value == SaveDayTypeOption.SaveDates.ToString();

                if (!entity.IsActive)
                {
                    bSaveDates = true;
                    entity.Dates = new HashSet<DateType>();
                }

                if (bSaveDates && (entity.Dates == null || !entity.Dates.Any()))
                {
                    var opt = saveParams.OptionValue(SaveDayTypeOption.SetIsActiveFalseIfNoDates.ToString());
                    if (!string.IsNullOrEmpty(opt))
                    {
                        entity.IsActive = false;
                        entity.Name = GetDefaultDayTypeName(entity.DayTypeCode);
                        entity.HighlightColor = 0;
                    }
                }

                var originalEntity = GetEntityByGuidId(entity.DayTypeUid, sessionData, null);
                var mgr = new DayTypePDSAManager();

                // PDSA Audit Tracking setup phase. Also, merge in properties that may not have been provided or that should not be changed by the caller for update operations
                if (mgr.DataObject.LoadByPK(entity.DayTypeUid) > 0) // must read the original record from the database so the PDSA object can detect changes
                {
                    if (string.IsNullOrEmpty(entity.InsertName))
                    {
                        entity.InsertDate = mgr.Entity.InsertDate;
                        entity.InsertName = mgr.Entity.InsertName;
                    }

                    // if EntityId is = Guid.Empty or null, then use the value from the original record
                    entity.EntityId = GuidUtilities.SyncDestAndSourceIfDestNullOrEmpty(mgr.Entity.EntityId, entity.EntityId);

                    mgr.InitEntityObject(entity);
                    int rowsUpdated = mgr.DataObject.Update();
                    if (rowsUpdated > 0)
                    {
                        SaveEntityMappings(sessionData, entity.DayTypeUid, entity, saveParams);
                        if (bSaveDates)
                            SaveDates(entity, sessionData, saveParams);
                        // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                        var updatedEntity = GetEntityByGuidId(entity.DayTypeUid, sessionData, new GetParametersWithPhoto(saveParams));
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);

                        var kvpResetConcurrencyValue = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveDayTypeOption.ResetConcurrencyValue).ToString());
                        bool bResetConcurrencyValue = !string.IsNullOrEmpty(kvpResetConcurrencyValue.Key) &&
                                          !string.IsNullOrEmpty(kvpResetConcurrencyValue.Value) &&
                                          kvpResetConcurrencyValue.Value == true.ToString();
                        if (bResetConcurrencyValue)
                        {
                            var x = GalaxySMSDatabaseManager.ResetConcurrencyValue("DayType", nameof(DayType.DayTypeUid), entity.DayTypeUid);
                        }

                        UpdateEntityCount(updatedEntity.EntityId);
                        if (updatedEntity.EntityId != originalEntity.EntityId)
                            UpdateEntityCount(originalEntity.EntityId);

                        return updatedEntity;
                    }
                    return entity;
                }
                throw new Exception($"{entity.GetType().Name} {entity.DayTypeUid} not found");
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::UpdateEntity", ex);
                throw;
            }
        }

        private string GetDefaultDayTypeName(DayTypeCode dtc)
        {
            switch (dtc)
            {
                case DayTypeCode.Sunday:
                    return Resources.Resources.DayType_Name_Sunday;
                case DayTypeCode.Monday:
                    return Resources.Resources.DayType_Name_Monday;
                case DayTypeCode.Tuesday:
                    return Resources.Resources.DayType_Name_Tuesday;
                case DayTypeCode.Wednesday:
                    return Resources.Resources.DayType_Name_Wednesday;
                case DayTypeCode.Thursday:
                    return Resources.Resources.DayType_Name_Thursday;
                case DayTypeCode.Friday:
                    return Resources.Resources.DayType_Name_Friday;
                case DayTypeCode.Saturday:
                    return Resources.Resources.DayType_Name_Saturday;
                case DayTypeCode.Weekday:
                    return Resources.Resources.DayType_Name_Weekday;
                case DayTypeCode.Weekend:
                    return Resources.Resources.DayType_Name_Weekend;

                default:
                    return string.Format(Resources.Resources.DayType_Name_x, (int)dtc);
            }
        }
        //private void SaveDates(DayType entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        //{
        //    if (entity.Dates == null || !entity.Dates.Any())
        //        return;

        //    var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveDayTypeOption.DeleteMissingDates).ToString());

        //    bool bDeleteMissingDates = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
        //                               !string.IsNullOrEmpty(kvpSaveOption.Value) &&
        //                               kvpSaveOption.Value == SaveDayTypeOption.DeleteMissingDates.ToString();

        //    var existingDatesForDayType = _dateTypeRepository.GetAllDateTypesForDayType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.DayTypeUid });
        //    var datesToAdd = entity.Dates.Where(p => existingDatesForDayType.All(p2 => p2.Date != p.Date)).ToList();
        //    foreach (var i in entity.Dates)
        //    {
        //        var existingDate = _dateTypeRepository.GetDateTypeForEntity(entity.EntityId, i.Date);
        //        if (existingDate != null && existingDate.DayTypeUid == entity.DayTypeUid && String.Compare(existingDate.Title, i.Title, false, CultureInfo.CurrentCulture) == 0)
        //        {   // The date already exists with the same day type and title,there is nothing to do in this case
        //            continue;
        //        }
        //        if(existingDate != null)
        //            i.DateTypeUid= existingDate.DateTypeUid;
        //        i.EntityId = entity.EntityId;
        //        i.DayTypeUid = entity.DayTypeUid;
        //        i.UpdateDate = DateTimeOffset.Now;
        //        i.UpdateName = sessionData.UserName;
        //        DateType savedItem;
        //        if (existingDate == null)
        //        {
        //            i.DateTypeUid = GuidUtilities.GenerateComb();
        //            i.InsertDate = DateTimeOffset.Now;
        //            i.InsertName = sessionData.UserName;
        //            i.ConcurrencyValue = 0;
        //            savedItem = _dateTypeRepository.Add(i, sessionData, saveParams);
        //        }
        //        else
        //        {
        //            savedItem = _dateTypeRepository.Update(i, sessionData, saveParams);
        //        }
        //    }

        //    if (bDeleteMissingDates)
        //    {
        //        var deleteTheseDates = existingDatesForDayType.Where(p => entity.Dates.All(p2 => p2.EntityId != p.EntityId)).ToList();
        //        // Now delete any that are no longer defined in the Access Portal
        //        foreach (var i in deleteTheseDates)
        //        {
        //            _dateTypeRepository.Remove(i.DateTypeUid, sessionData, null);
        //        }
        //    }

        //}
        private void SaveDates(DayType entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            //var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveDayTypeOption.SaveDates).ToString());
            //bool bSaveDates = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
            //                           !string.IsNullOrEmpty(kvpSaveOption.Value) &&
            //                           kvpSaveOption.Value == SaveDayTypeOption.SaveDates.ToString();
            //if (!bSaveDates)
            //    return;

            var kvpSaveDeleteMissingDatesOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveDayTypeOption.DeleteMissingDates).ToString());

            bool bDeleteMissingDates = !string.IsNullOrEmpty(kvpSaveDeleteMissingDatesOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveDeleteMissingDatesOption.Value) &&
                                       kvpSaveDeleteMissingDatesOption.Value == SaveDayTypeOption.DeleteMissingDates.ToString();

            // entity.Dates must contain all dates associated with the DayType
            // If there are no dates, then this DayType is supposed to be treated as not active
            if (entity.Dates == null || !entity.Dates.Any())
            {
                if (entity.Dates == null)
                    entity.Dates = new List<DateType>();
                bDeleteMissingDates = true;
            }

            foreach (var d in entity.Dates)
                d.Date = d.Date.DateOnly();

            var existingDatesForDayType = _dateTypeRepository.GetAllDateTypesForDayType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.DayTypeUid });
            var datesToAdd = entity.Dates.Where(p => existingDatesForDayType.Items.All(p2 => p2.Date != p.Date)).ToList();
            foreach (var i in entity.Dates)
            {
                var existingDate = _dateTypeRepository.GetDateTypeForEntityAndDate(entity.EntityId, i.Date);
                if (existingDate != null && existingDate.DayTypeUid == entity.DayTypeUid && String.Compare(existingDate.Title, i.Title, false, CultureInfo.CurrentCulture) == 0)
                {   // The date already exists with the same day type and title,there is nothing to do in this case
                    continue;
                }
                if (existingDate != null)
                    i.DateTypeUid = existingDate.DateTypeUid;
                i.EntityId = entity.EntityId;
                i.DayTypeUid = entity.DayTypeUid;
                i.UpdateDate = DateTimeOffset.Now;
                i.UpdateName = sessionData.UserName;
                DateType savedItem;
                if (existingDate == null)
                {
                    i.DateTypeUid = GuidUtilities.GenerateComb();
                    i.InsertDate = DateTimeOffset.Now;
                    i.InsertName = sessionData.UserName;
                    i.ConcurrencyValue = 0;
                    savedItem = _dateTypeRepository.Add(i, sessionData, saveParams);
                }
                else
                {
                    savedItem = _dateTypeRepository.Update(i, sessionData, saveParams);
                }
            }

            if (bDeleteMissingDates)
            {
                var deleteTheseDates = existingDatesForDayType.Items.Where(p => entity.Dates.All(p2 => p2.Date != p.Date)).ToList();
                // Now delete any that are no longer defined in the Access Portal
                foreach (var i in deleteTheseDates)
                {
                    _dateTypeRepository.Remove(i.DateTypeUid, sessionData);
                }
            }

        }


        protected override int DeleteEntity(DayType entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new DayTypePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.DayTypeUid);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new DayTypePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::Remove", ex);
                throw;
            }
        }

        private IEnumerable<DayType> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, DayTypePDSAManager mgr)
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

        private void SetSortColumnAndOrder(IGetParametersBase getParameters, DayTypePDSAManager mgr)
        {
            mgr.Entity.PageNumber = getParameters.PageNumber;
            mgr.Entity.PageSize = getParameters.PageSize;
            if (!string.IsNullOrEmpty(getParameters?.SortProperty))
            {
                var sortProperty = EnumExtensions.GetOne<DayTypeSortProperty>(getParameters.SortProperty);
                mgr.Entity.SortColumn = sortProperty.ToString();
            }

            mgr.Entity.DescendingOrder = getParameters?.DescendingOrder == true;
        }

        private IArrayResponse<DayType> GetIEnumerablePaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, DayTypePDSAManager mgr)
        {
            SetSortColumnAndOrder(getParameters, mgr);
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var totalCount = 0;
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (var entity in entities)
                {
                    if (totalCount == 0)
                        totalCount = entity.TotalRowCount;
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                    {
                        var tempGetParams = new GetParametersWithPhoto(getParameters)
                        {
                            UniqueId = entity.DayTypeUid
                        };
                        FillMemberCollections(entity, null, tempGetParams);
                    }
                }
                return ArrayResponseHelpers.ToArrayResponse(entities, getParameters.PageNumber, getParameters.PageSize, totalCount);
            }
            return new ArrayResponse<DayType>();
        }
        // GetAllDayTypes for an Entity
        protected override IEnumerable<DayType> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DayTypePDSAManager();
                var isActiveOption = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_DayType.IsActive);
                mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.ByEntityId;
                if (isActiveOption.HasValue)
                {
                    mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.ByEntityIdAndIsActive;
                    mgr.DataObject.Entity.IsActive = isActiveOption.Value;
                }
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.UniqueId;
                else if (getParameters.CurrentEntityId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.CurrentEntityId;
                else
                    mgr.DataObject.Entity.EntityId = sessionData.CurrentEntityId;
                //mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<DayType> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DayTypePDSAManager();
                mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::GetAllEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<DayType> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DayTypePDSAManager();
                var isActiveOption = getParameters.GetOption(GalaxySMS.Common.Constants.GetOptions_DayType.IsActive);
                mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.ByEntityId;
                if (isActiveOption.HasValue)
                {
                    mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.ByEntityIdAndIsActive;
                    mgr.DataObject.Entity.IsActive = isActiveOption.Value;
                }
                if (getParameters.UniqueId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.UniqueId;
                else if (getParameters.CurrentEntityId != Guid.Empty)
                    mgr.DataObject.Entity.EntityId = getParameters.CurrentEntityId;
                else
                    mgr.DataObject.Entity.EntityId = sessionData.CurrentEntityId;
                SetSortColumnAndOrder(getParameters, mgr);
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IArrayResponse<DayType> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DayTypePDSAManager();
                mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.All;
                SetSortColumnAndOrder(getParameters, mgr);
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetAllEntities", ex);
                throw;
            }
        }

        public DayType GetByEntityIdAndDayTypeCode(Guid entityId, DayTypeCode code, bool includeMemberCollections)
        {
            try
            {
                var mgr = new DayTypePDSAManager();
                mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.ByEntityIdAndDayTypeCode;
                mgr.DataObject.Entity.EntityId = entityId;
                mgr.DataObject.Entity.DayTypeCode = (short)code;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (var entity in entities)
                    {
                        if (includeMemberCollections)
                        {
                            var tempGetParams = new GetParametersWithPhoto()
                            {
                                UniqueId = entity.DayTypeUid,
                                IncludeMemberCollections = includeMemberCollections
                            };
                            FillMemberCollections(entity, null, tempGetParams);
                        }

                        return entity;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetEntities", ex);
                throw;
            }

        }

        public DayType GetLowestInActiveByEntityId(Guid entityId, bool includeMemberCollections)
        {
            try
            {
                var mgr = new DayTypePDSAManager();
                mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.GetLowestInActiveByEntityId;
                mgr.DataObject.Entity.EntityId = entityId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    foreach (var entity in entities)
                    {
                        if (includeMemberCollections)
                        {
                            var tempGetParams = new GetParametersWithPhoto()
                            {
                                UniqueId = entity.DayTypeUid,
                                IncludeMemberCollections = includeMemberCollections
                            };
                            FillMemberCollections(entity, null, tempGetParams);
                        }

                        return entity;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetEntities", ex);
                throw;
            }
        }


        public IArrayResponse<DayType> GetAllDayTypesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }

        public IArrayResponse<DayType> GetAllDayTypesForMappedEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DayTypePDSAManager();
                mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.ByMappedEntityId;
                mgr.Entity.EntityId = getParameters.UniqueId;
                //mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::GetAllDayTypesForRegion", ex);
                throw;
            }
        }

        public IArrayResponse<DayType> GetAllDayTypesForGalaxyCluster(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DayTypePDSAManager();
                mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.ByGalaxyClusterUid;
                mgr.Entity.GalaxyClusterUid = getParameters.UniqueId;
                //mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerablePaged(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::GetAllDayTypesForRegion", ex);
                throw;
            }
        }

        public IArrayResponse<DayType> GetAllDayTypesForTimeSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new ClusterUid_GetByAccessPortalUidPDSAManager();
                mgr.Entity.accessPortalUid = getParameters.UniqueId;
                var data = mgr.BuildCollection();
                if (data != null && data.Count == 1)
                {
                    var newParams = new GetParametersWithPhoto(getParameters as GetParametersWithPhoto);
                    newParams.UniqueId = data[0].ClusterUid;
                    return GetAllDayTypesForGalaxyCluster(sessionData, newParams);
                }
                return new ArrayResponse<DayType>();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::GetAllDayTypesForAccessPortal", ex);
                throw;
            }
        }

        public IArrayResponse<DayType> GetAllDayTypesForAssaAbloyDsr(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            return new ArrayResponse<DayType>();
            //try
            //{
            //    var mgr = new DayTypePDSAManager();
            //    mgr.DataObject.SelectFilter = DayTypePDSAData.SelectFilters.ByAssaDsrUid;
            //    mgr.Entity.AssaDsrUid = parameters.GetString;
            //    mgr.Entity.CultureName = sessionData.UiCulture;
            //    return GetIEnumerable(sessionData, parameters, mgr);
            //}
            //catch (PDSAValidationException ex)
            //{
            //    DataValidationException dve = Converters.ConvertToDataValidationException(ex);
            //    throw dve;
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::GetAllDayTypesForAssaAbloyDsr", ex);
            //    throw;
            //}
        }

        protected override DayType GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override DayType GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new DayTypePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    DayType result = new DayType();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, DayType originalEntity, DayType newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "DayTypeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.DayTypeUid;
                        mgr.Entity.RecordTag = newEntity.DayTypeUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "DayTypeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.DayTypeUid;
                        mgr.Entity.RecordTag = newEntity.DayTypeUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "DayTypeUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.DayTypeUid;
                        mgr.Entity.RecordTag = originalEntity.DayTypeUid.ToString();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//DayTypeRepository::SaveAuditData", ex);
                                                                                                                        //throw;
            }
        }

        protected override void FillMemberCollections(DayType entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var entityMaps = _entityMapRepository.GetAllForDayType(sessionData, new GetParametersWithPhoto() { UniqueId = entity.DayTypeUid });
            var entityIds = (from e in entityMaps select e.EntityId).ToList();
            entity.EntityIds.AddRange(entityIds);
            //foreach ( var e in entityMaps)
            //{
            //    if(e.EntityId != entity.EntityId)
            //        entity.EntityIds.Add(e.EntityId);
            //}
            entity.EntityIds.Add(entity.EntityId);


            if (getParameters == null)
                return;

            if (!getParameters.IsExcluded(nameof(entity.Dates)))
            {
                entity.Dates = _dateTypeRepository.GetAllDateTypesForDayType(sessionData,
                    new GetParametersWithPhoto() { UniqueId = entity.DayTypeUid, SortProperty = nameof(DateType.Date), DescendingOrder = false}).Items.ToCollection();
            }

        }

        private void SaveEntityMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, IHasEntityMappingList entity, ISaveParameters saveParams)
        {
            if (entity.EntityIds == null || !entity.EntityIds.Any() || saveParams.Ignore(nameof(entity.EntityIds)))
                return;

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingEntityMappings = _entityMapRepository.GetAllForDayType(sessionData, getParameters);
            var existingEntityIds = new HashSet<Guid>(existingEntityMappings.Select(e => e.EntityId));
            var userPermittedEntities = GcsUserSessionRepository.GetUserEntitiesForSession(sessionData.SessionGuid);

            foreach (var existingEntityId in existingEntityIds)
            {
                if (!entity.EntityIds.Contains(existingEntityId) && userPermittedEntities.Contains(existingEntityId))
                {
                    var deleteThisExistingEntityMap = (from eem in existingEntityMappings where eem.EntityId == existingEntityId select eem).FirstOrDefault();
                    if (deleteThisExistingEntityMap != null)
                        _entityMapRepository.Remove(deleteThisExistingEntityMap.DayTypeEntityMapUid, sessionData);
                }
            }
            foreach (var entityId in entity.EntityIds)
            {
                if (!existingEntityIds.Contains(entityId))
                {
                    var entityMap = new DayTypeEntityMap();
                    entityMap.DayTypeEntityMapUid = GuidUtilities.GenerateComb();
                    entityMap.DayTypeUid = uid;
                    entityMap.EntityId = entityId;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _entityMapRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("DayType", "DayTypeUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("DayType", "DayTypeUid", id);
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

        protected override bool IsEntityUnique(DayType entity)
        {
            var mgr = new IsDayTypeUniquePDSAManager();
            mgr.Entity.DayTypeUid = entity.DayTypeUid;
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.Name = entity.Name;

            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("DayType", "DayTypeUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("DayType", "DayTypeUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

        private void UpdateEntityCount(Guid entityId)
        {
            try
            {
                var mgr = new gcsEntityCountPDSA_InsertDayTypeCountPDSAManager();
                mgr.Entity.EntityId = entityId;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//PersonRepository::DeleteEntity", ex);
                throw;
            }
        }

        public Guid GetEntityId(Guid uid)
        {
            var mgr = new GetEntityIdForGalaxyDayTypePDSAManager()
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
