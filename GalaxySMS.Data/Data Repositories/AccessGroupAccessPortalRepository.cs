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
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Data
{
    [Export(typeof(IAccessGroupAccessPortalRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessGroupAccessPortalRepository : DataRepositoryBase<AccessGroupAccessPortal>, IAccessGroupAccessPortalRepository, IPartImportsSatisfiedNotification
    {
        [Import]
        private IGcsBinaryResourceRepository _binaryResourceRepository;

        protected override AccessGroupAccessPortal AddEntity(AccessGroupAccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                if (entity.TimeScheduleUid.HasValue && entity.TimeScheduleUid.Value == Guid.Empty)
                    entity.TimeScheduleUid = null;

                var mgr = new AccessGroupAccessPortalPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.AccessGroupAccessPortalUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::AddEntity", ex);
                throw;
            }
        }

        protected override AccessGroupAccessPortal UpdateEntity(AccessGroupAccessPortal entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                if (entity.TimeScheduleUid.HasValue && entity.TimeScheduleUid.Value == Guid.Empty)
                    entity.TimeScheduleUid = null;


                var originalEntity = GetEntityByGuidId(entity.AccessGroupAccessPortalUid, sessionData, null);
                var mgr = new AccessGroupAccessPortalPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.AccessGroupAccessPortalUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.AccessGroupAccessPortalUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(AccessGroupAccessPortal entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new AccessGroupAccessPortalPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.AccessGroupAccessPortalUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new AccessGroupAccessPortalPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::Remove", ex);
                throw;
            }
        }

        // GetAllAccessGroupAccessPortals in a region
        protected override IEnumerable<AccessGroupAccessPortal> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessGroupAccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupAccessPortalPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<AccessGroupAccessPortal> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessGroupAccessPortalPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (AccessGroupAccessPortal entity in entities)
                {
                    if (entity.TimeScheduleUid.HasValue && entity.TimeScheduleUid.Value == Guid.Empty)
                    {
                        entity.TimeScheduleUid = null;
                        entity.TimeScheduleName = null;
                    }

                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<AccessGroupAccessPortal> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessGroupAccessPortalPDSAManager();
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<AccessGroupAccessPortal> GetAllAccessGroupAccessPortalForAccessGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupAccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupAccessPortalPDSAData.SelectFilters.ByAccessGroupUid;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::GetAllAccessGroupAccessPortalForPanelModel", ex);
                throw;
            }
        }

        public IEnumerable<AccessGroupAccessPortal> GetAllAccessGroupAccessPortalForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupAccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupAccessPortalPDSAData.SelectFilters.ByAccessPortalUid;
                mgr.Entity.AccessPortalUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::GetAllAccessGroupAccessPortalForAccessPortal", ex);
                throw;
            }
        }

        public IEnumerable<AccessGroupAccessPortal> GetAllAccessGroupAccessPortalForTimeSchedule(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessGroupAccessPortalPDSAManager();
                mgr.DataObject.SelectFilter = AccessGroupAccessPortalPDSAData.SelectFilters.ByTimeScheduleUid;
                mgr.Entity.TimeScheduleUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::GetAllAccessGroupAccessPortalForTimeSchedule", ex);
                throw;
            }
        }

        public ValidationProblemDetails Validate(AccessGroupAccessPortal data, string propertyName, int index)
        {
            try
            {
                var response = new ValidationProblemDetails();
                var errors = new List<string>();
                var mgr = new IsGalaxyAccessGroupAccessPortalMappingValidPDSAManager();
                mgr.Entity.AccessGroupUid = data.AccessGroupUid;
                mgr.Entity.AccessPortalUid = data.AccessPortalUid;
                if (!data.TimeScheduleUid.HasValue ||
                    data.TimeScheduleUid == Guid.Empty)
                    data.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
                mgr.Entity.TimeScheduleUid = data.TimeScheduleUid.Value;
                var results = mgr.BuildCollection();
                if (results != null && results.Count > 0)
                {
                    var r = results.FirstOrDefault();
                    if (r != null)
                    {
                        var s = string.Empty;
                        var validationResult = EnumExtensions.GetOne<AccessGroupAccessPortalValidationResult>(r.Result);
                        switch (validationResult)
                        {
                            case AccessGroupAccessPortalValidationResult.Valid:
                                break;
                            case AccessGroupAccessPortalValidationResult.Unknown:
                                s = $"{nameof(data)} is not valid. Reason: {validationResult}";
                                break;
                            case AccessGroupAccessPortalValidationResult.AccessGroupNotFound:
                                s = $"{nameof(AccessGroup)} with {nameof(data.AccessGroupUid)}:'{data.AccessGroupUid}' is not found. Reason: {validationResult}";
                                break;
                            case AccessGroupAccessPortalValidationResult.AccessPortalNotFoundOrOnCluster:
                                s = $"{nameof(AccessPortal)} with {nameof(data.AccessPortalUid)}:'{data.AccessPortalUid}' is not found or is not associated with the same cluster as the access group. Reason: {validationResult}";
                                break;
                            case AccessGroupAccessPortalValidationResult.TimeScheduleNotFoundOrMappedToCluster:
                                s = $"{nameof(TimeSchedule)} with {nameof(data.TimeScheduleUid)}:'{data.TimeScheduleUid}' is not found or is not mapped with the same cluster as the access group. Reason: {validationResult}";
                                break;
                            case AccessGroupAccessPortalValidationResult.AccessGroupAndAccessPortalOnDifferentClusters:
                                s = $"{nameof(AccessGroup)} with {nameof(data.AccessGroupUid)}:'{data.AccessGroupUid}' and {nameof(AccessPortal)} with {nameof(data.AccessPortalUid)}:'{data.AccessPortalUid}' are not on the same cluster. Reason: {validationResult}";
                                break;
                            case AccessGroupAccessPortalValidationResult.AccessGroupAndTimeScheduleOnDifferentClusters:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        errors.Add(s);
                        response.Errors.Add($"{propertyName}[{index}]", errors.ToArray());
                    }
                }


                return response;
            }
            catch (Exception e)
            {
                throw;
            }


        }
        public ValidationProblemDetails Validate(IEnumerable<AccessGroupAccessPortal> data, string propertyName)
        {
            try
            {
                var response = new ValidationProblemDetails();
                int index = 0;
                foreach (var agap in data)
                {
                    var errorsArray = new List<string>();

                    var mgr = new IsGalaxyAccessGroupAccessPortalMappingValidPDSAManager();
                    mgr.Entity.AccessGroupUid = agap.AccessGroupUid;
                    mgr.Entity.AccessPortalUid = agap.AccessPortalUid;
                    if (!agap.TimeScheduleUid.HasValue ||
                        agap.TimeScheduleUid == Guid.Empty)
                        agap.TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
                    mgr.Entity.TimeScheduleUid = agap.TimeScheduleUid.Value;
                    var results = mgr.BuildCollection();
                    if (results != null && results.Count > 0)
                    {
                        var r = results.FirstOrDefault();
                        if (r != null)
                        {
                            var s = string.Empty;
                            var validationResult = EnumExtensions.GetOne<AccessGroupAccessPortalValidationResult>(r.Result);
                            switch (validationResult)
                            {
                                case AccessGroupAccessPortalValidationResult.Valid:
                                    break;
                                case AccessGroupAccessPortalValidationResult.Unknown:
                                    s = $"{nameof(data)} is not valid. Reason: {validationResult}";
                                    break;
                                case AccessGroupAccessPortalValidationResult.AccessGroupNotFound:
                                    s =
                                        $"{nameof(AccessGroup)} with {nameof(agap.AccessGroupUid)}:'{agap.AccessGroupUid}' is not found. Reason: {validationResult}";
                                    break;
                                case AccessGroupAccessPortalValidationResult.AccessPortalNotFoundOrOnCluster:
                                    s =
                                        $"{nameof(AccessPortal)} with {nameof(agap.AccessPortalUid)}:'{agap.AccessPortalUid}' is not found or is not associated with the same cluster as the access group. Reason: {validationResult}";
                                    break;
                                case AccessGroupAccessPortalValidationResult.TimeScheduleNotFoundOrMappedToCluster:
                                    s =
                                        $"{nameof(TimeSchedule)} with {nameof(agap.TimeScheduleUid)}:'{agap.TimeScheduleUid}' is not found or is not mapped with the same cluster as the access group. Reason: {validationResult}";
                                    break;
                                case AccessGroupAccessPortalValidationResult.AccessGroupAndAccessPortalOnDifferentClusters:
                                    s =
                                        $"{nameof(AccessGroup)} with {nameof(agap.AccessGroupUid)}:'{agap.AccessGroupUid}' and {nameof(AccessPortal)} with {nameof(agap.AccessPortalUid)}:'{agap.AccessPortalUid}' are not on the same cluster. Reason: {validationResult}";
                                    break;
                                case AccessGroupAccessPortalValidationResult.AccessGroupAndTimeScheduleOnDifferentClusters:
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            errorsArray.Add(s);
                            if (errorsArray.Any())
                                response.Errors.Add($"{propertyName}[{index}]", errorsArray.ToArray());
                            index++;
                        }

                    }
                }


                return response;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ValidationProblemDetails ValidateAccessPortalsAndScheduleMatchCluster(IEnumerable<AccessGroupAccessPortal> data,
            Guid clusterUid, string propertyName)
        {
            try
            {
                var apmgr = new AccessPortalUids_SelectForClusterUidPDSAManager();
                apmgr.Entity.ClusterUid = clusterUid;
                var apUids = apmgr.BuildCollection();

                var tsmgr = new TimeScheduleUids_SelectForClusterUidPDSAManager();
                tsmgr.Entity.ClusterUid = clusterUid;
                var tsUids = tsmgr.BuildCollection();
                var response = new ValidationProblemDetails();
                int index = 0;
                foreach (var agap in data)
                {
                    var errorsArray = new List<string>();
                    var ap = apUids.FirstOrDefault(o => o.AccessPortalUid == agap.AccessPortalUid);
                    if( ap == null)
                    {
                        var s = $"{nameof(AccessPortal)} with {nameof(agap.AccessPortalUid)}:'{agap.AccessPortalUid}' does not exist or is not associated with the same cluster as the access group.";

                        errorsArray.Add(s);
                    }

                    if (agap.TimeScheduleUid == Guid.Empty)
                        agap.TimeScheduleUid = null;
                    if (agap.TimeScheduleUid.HasValue &&
                        agap.TimeScheduleUid.Value != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never &&
                        agap.TimeScheduleUid.Value != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                    {
                        var ts = tsUids.FirstOrDefault(o => o.TimeScheduleUid == agap.TimeScheduleUid);
                        if (ts == null)
                        {
                            var s =
                                $"{nameof(TimeSchedule)} with {nameof(agap.TimeScheduleUid)}:'{agap.TimeScheduleUid}' does not exist is not mapped to the same cluster as the access group.";

                            errorsArray.Add(s);
                        }
                    }
                    if (errorsArray.Any())
                        response.Errors.Add($"{propertyName}[{index}]", errorsArray.ToArray());
                    index++;
                }


                return response;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public ValidationProblemDetails ValidateAccessGroupsAndScheduleMatchCluster(IEnumerable<AccessGroupAccessPortal> data,
            Guid clusterUid, string propertyName)
        {
            try
            {
                var agmgr = new AccessGroupUids_SelectForClusterUidPDSAManager();
                agmgr.Entity.ClusterUid = clusterUid;
                var agUids = agmgr.BuildCollection();

                var tsmgr = new TimeScheduleUids_SelectForClusterUidPDSAManager();
                tsmgr.Entity.ClusterUid = clusterUid;
                var tsUids = tsmgr.BuildCollection();
                var response = new ValidationProblemDetails();
                int index = 0;
                foreach (var agap in data)
                {
                    var errorsArray = new List<string>();
                    var ap = agUids.FirstOrDefault(o => o.AccessGroupUid == agap.AccessGroupUid);
                    if (ap == null)
                    {
                        var s = $"{nameof(AccessGroup)} with {nameof(agap.AccessGroupUid)}:'{agap.AccessGroupUid}' does not exist or is not associated with the same cluster as the access portal.";

                        errorsArray.Add(s);
                    }

                    if (agap.TimeScheduleUid.HasValue &&
                        agap.TimeScheduleUid.Value != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never &&
                        agap.TimeScheduleUid.Value != GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                    {
                        var ts = tsUids.FirstOrDefault(o => o.TimeScheduleUid == agap.TimeScheduleUid);
                        if (ts == null)
                        {
                            var s =
                                $"{nameof(TimeSchedule)} with {nameof(agap.TimeScheduleUid)}:'{agap.TimeScheduleUid}' does not exist or is not mapped to the same cluster as the access group.";

                            errorsArray.Add(s);
                        }
                    }
                    if (errorsArray.Any())
                        response.Errors.Add($"{propertyName}[{index}]", errorsArray.ToArray());
                    index++;
                }


                return response;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        protected override AccessGroupAccessPortal GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override AccessGroupAccessPortal GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessGroupAccessPortalPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    AccessGroupAccessPortal result = new AccessGroupAccessPortal();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(result, sessionData, getParameters);
                    if (result.TimeScheduleUid.HasValue && result.TimeScheduleUid.Value == Guid.Empty)
                    {
                        result.TimeScheduleUid = null;
                        result.TimeScheduleName = null;
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, AccessGroupAccessPortal originalEntity, AccessGroupAccessPortal newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "ClusterTypeClusterCommandUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessGroupAccessPortalUid;
                        mgr.Entity.RecordTag = newEntity.AccessGroupAccessPortalUid.ToString();
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
                                if (property.Value?.NewValue == null)
                                    mgr.Entity.NewValue = string.Empty;
                                else
                                    mgr.Entity.NewValue = property.Value?.NewValue?.ToString();
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
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessGroupAccessPortalUid;
                        mgr.Entity.RecordTag = newEntity.AccessGroupAccessPortalUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "ClusterTypeClusterCommandUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AccessGroupAccessPortalUid;
                        mgr.Entity.RecordTag = originalEntity.AccessGroupAccessPortalUid.ToString();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessGroupAccessPortalRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(AccessGroupAccessPortal entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("AccessGroupAccessPortal", "ClusterTypeClusterCommandUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("AccessGroupAccessPortal", "ClusterTypeClusterCommandUid", id);
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

        protected override bool IsEntityUnique(AccessGroupAccessPortal entity)
        {
            var mgr = new IsAccessGroupAccessPortalUniquePDSAManager();
            mgr.Entity.AccessGroupAccessPortalUid = entity.AccessGroupAccessPortalUid;
            mgr.Entity.AccessPortalUid = entity.AccessPortalUid;
            mgr.Entity.AccessGroupUid = entity.AccessGroupUid;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("AccessGroupAccessPortal", "AccessGroupAccessPortalUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("AccessGroupAccessPortal", "AccessGroupAccessPortalUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
