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
    [Export(typeof(IAccessPortalAuxiliaryOutputModeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessPortalAuxiliaryOutputModeRepository : DataRepositoryBase<AccessPortalAuxiliaryOutputMode>, IAccessPortalAuxiliaryOutputModeRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        protected override AccessPortalAuxiliaryOutputMode AddEntity(AccessPortalAuxiliaryOutputMode entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var mgr = new AccessPortalAuxiliaryOutputModePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.AccessPortalAuxiliaryOutputModeUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAuxiliaryOutputModeRepository::AddEntity", ex);
                throw;
            }
        }

        protected override AccessPortalAuxiliaryOutputMode UpdateEntity(AccessPortalAuxiliaryOutputMode entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.AccessPortalAuxiliaryOutputModeUid, sessionData, null);
                var mgr = new AccessPortalAuxiliaryOutputModePDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.AccessPortalAuxiliaryOutputModeUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.AccessPortalAuxiliaryOutputModeUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAuxiliaryOutputModeRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(AccessPortalAuxiliaryOutputMode entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new AccessPortalAuxiliaryOutputModePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.AccessPortalAuxiliaryOutputModeUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAuxiliaryOutputModeRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new AccessPortalAuxiliaryOutputModePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAuxiliaryOutputModeRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<AccessPortalAuxiliaryOutputMode> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalAuxiliaryOutputModePDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalAuxiliaryOutputModePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAuxiliaryOutputModeRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<AccessPortalAuxiliaryOutputMode> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessPortalAuxiliaryOutputModePDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (AccessPortalAuxiliaryOutputMode entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<AccessPortalAuxiliaryOutputMode> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalAuxiliaryOutputModePDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalAuxiliaryOutputModePDSAData.SelectFilters.AllForCulture;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAuxiliaryOutputModeRepository::GetEntities", ex);
                throw;
            }
        }

        protected override AccessPortalAuxiliaryOutputMode GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override AccessPortalAuxiliaryOutputMode GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalAuxiliaryOutputModePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    AccessPortalAuxiliaryOutputMode result = new AccessPortalAuxiliaryOutputMode();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAuxiliaryOutputModeRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, AccessPortalAuxiliaryOutputMode originalEntity, AccessPortalAuxiliaryOutputMode newEntity, string auditXml)
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

                        List<String> propertiesToIgnore = new List<string>
                        {
                            "UpdateDate",
                            "ConcurrencyValue"
                        };

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalAuxiliaryOutputModeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessPortalAuxiliaryOutputModeUid;
                        mgr.Entity.RecordTag = newEntity.AccessPortalAuxiliaryOutputModeUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalAuxiliaryOutputModeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessPortalAuxiliaryOutputModeUid;
                        mgr.Entity.RecordTag = newEntity.AccessPortalAuxiliaryOutputModeUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalAuxiliaryOutputModeUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AccessPortalAuxiliaryOutputModeUid;
                        mgr.Entity.RecordTag = originalEntity.AccessPortalAuxiliaryOutputModeUid.ToString();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalAuxiliaryOutputModeRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(AccessPortalAuxiliaryOutputMode entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            var modeNormalApEditorData = new AccessPortalAuxiliaryOutputModeEditorData()
            {
                //InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_AccessPortal,
                InterfaceBoardSectionModeCode = (short)GalaxySMS.Common.Enums.ReaderInterfaceSectionMode.AccessPortal,
                //DescriptionAllowed = true,
                ModeIsAllowed = true
            };

            if(entity.AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Follows)
            {
                modeNormalApEditorData.IllegalOpenVisible = true;
                modeNormalApEditorData.OpenTooLongVisible = true;
            }
            else if(entity.AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Timeout)
            {
                modeNormalApEditorData.IllegalOpenVisible = true;
                modeNormalApEditorData.OpenTooLongVisible = true;
                modeNormalApEditorData.InvalidAttemptVisible = true;
                modeNormalApEditorData.AccessGrantedVisible = true;
                modeNormalApEditorData.DuressVisible = true;
                modeNormalApEditorData.PassbackViolationVisible = true;
                modeNormalApEditorData.ActivationDelayVisible = true;
                modeNormalApEditorData.ActivationDurationVisible = true;
            }
            else if (entity.AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Scheduled)
            {
                modeNormalApEditorData.TimeScheduleSelectorVisible = true;
            }
            else if (entity.AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Latching)
            {
                modeNormalApEditorData.IllegalOpenVisible = true;
                modeNormalApEditorData.OpenTooLongVisible = true;
                modeNormalApEditorData.InvalidAttemptVisible = true;
                modeNormalApEditorData.AccessGrantedVisible = true;
                modeNormalApEditorData.DuressVisible = true;
                modeNormalApEditorData.PassbackViolationVisible = true;
            }

            entity.AccessPortalAuxiliaryOutputModeEditorData.Add(modeNormalApEditorData);

            var modeCredentailReaderOnlyApEditorData = new AccessPortalAuxiliaryOutputModeEditorData()
            {
                //InterfaceBoardSectionModeUid = GalaxySMS.Common.Constants.DualReaderInterface635ModeIds.ReaderInterfaceMode_CredentialReaderOnly,
                InterfaceBoardSectionModeCode = (short)GalaxySMS.Common.Enums.ReaderInterfaceSectionMode.CredentialReaderOnly,
                //DescriptionAllowed = true
            };
            if (entity.AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Follows)
            {
                modeCredentailReaderOnlyApEditorData.ModeIsAllowed = false;
            }
            else if (entity.AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Timeout)
            {
                modeCredentailReaderOnlyApEditorData.IllegalOpenVisible = false;
                modeCredentailReaderOnlyApEditorData.OpenTooLongVisible = false;
                modeCredentailReaderOnlyApEditorData.InvalidAttemptVisible = true;
                modeCredentailReaderOnlyApEditorData.AccessGrantedVisible = true;
                modeCredentailReaderOnlyApEditorData.DuressVisible = true;
                modeCredentailReaderOnlyApEditorData.PassbackViolationVisible = true;
                modeCredentailReaderOnlyApEditorData.ActivationDelayVisible = true;
                modeCredentailReaderOnlyApEditorData.ActivationDurationVisible = true;
            }
            else if (entity.AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Scheduled)
            {
                modeCredentailReaderOnlyApEditorData.TimeScheduleSelectorVisible = true;
            }
            else if (entity.AccessPortalAuxiliaryOutputModeUid == GalaxySMS.Common.Constants.AccessPortalAuxiliaryOutputModeIds.Latching)
            {
                modeCredentailReaderOnlyApEditorData.IllegalOpenVisible = false;
                modeCredentailReaderOnlyApEditorData.OpenTooLongVisible = false;
                modeCredentailReaderOnlyApEditorData.InvalidAttemptVisible = true;
                modeCredentailReaderOnlyApEditorData.AccessGrantedVisible = true;
                modeCredentailReaderOnlyApEditorData.DuressVisible = true;
                modeCredentailReaderOnlyApEditorData.PassbackViolationVisible = true;
            }

            entity.AccessPortalAuxiliaryOutputModeEditorData.Add(modeCredentailReaderOnlyApEditorData);

            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("AccessPortalAuxiliaryOutputMode", "AccessPortalAuxiliaryOutputModeUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("AccessPortalAuxiliaryOutputMode", "AccessPortalAuxiliaryOutputModeUid", id);
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

        protected override bool IsEntityUnique(AccessPortalAuxiliaryOutputMode entity)
        {
            var mgr = new IsAccessPortalAuxiliaryOutputModeUniquePDSAManager();
            mgr.Entity.AccessPortalAuxiliaryOutputModeUid = entity.AccessPortalAuxiliaryOutputModeUid;
            mgr.Entity.Display = entity.Display;
            mgr.Entity.Code = entity.Code;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("AccessPortalAuxiliaryOutputMode", "AccessPortalAuxiliaryOutputModeUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("AccessPortalAuxiliaryOutputMode", "AccessPortalAuxiliaryOutputModeUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
