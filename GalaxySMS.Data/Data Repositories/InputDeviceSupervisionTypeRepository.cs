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
    [Export(typeof(IInputDeviceSupervisionTypeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InputDeviceSupervisionTypeRepository : DataRepositoryBase<InputDeviceSupervisionType>,
        IInputDeviceSupervisionTypeRepository, IPartImportsSatisfiedNotification
    {
        [Import] private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import] private IGcsResourceStringRepository _resourceStringRepository;

        [Import] private IInputDeviceSupervisionTypeInterfaceBoardSectionModeRepository
            _inputDeviceSupervisionTypeInterfaceBoardSectionModeRepository;

        protected override InputDeviceSupervisionType AddEntity(InputDeviceSupervisionType entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var mgr = new InputDeviceSupervisionTypePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.InputDeviceSupervisionTypeUid, sessionData, null);
                    if (result != null)
                    {
                        SaveBoardSectionModeMappings(sessionData, entity.InputDeviceSupervisionTypeUid,
                            entity.InterfaceBoardSectionModeIds, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceSupervisionTypeRepository::AddEntity", ex);
                throw;
            }
        }

        protected override InputDeviceSupervisionType UpdateEntity(InputDeviceSupervisionType entity,
            IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                if (entity.gcsBinaryResource?.HasBeenModified == true)
                    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);

                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.InputDeviceSupervisionTypeUid, sessionData, null);
                var mgr = new InputDeviceSupervisionTypePDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.InputDeviceSupervisionTypeUid);
                // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    SaveBoardSectionModeMappings(sessionData, entity.InputDeviceSupervisionTypeUid, entity.InterfaceBoardSectionModeIds, saveParams);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.InputDeviceSupervisionTypeUid, sessionData, null);
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity,
                        mgr.DataObject.AuditRowAsXml);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceSupervisionTypeRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void SaveBoardSectionModeMappings(IApplicationUserSessionDataHeader sessionData, Guid uid,
            ICollection<Guid> boardSectionModeIds, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() {UniqueId = uid};
            var existingBoardSectionModeMappings =
                _inputDeviceSupervisionTypeInterfaceBoardSectionModeRepository
                    .GetAllInputDeviceSupervisionTypeInterfaceBoardSectionModesForSupervisionType(sessionData,
                        getParameters);
            var existingBoardSectionModeIds =
                new HashSet<Guid>(existingBoardSectionModeMappings.Select(e => e.InterfaceBoardSectionModeUid));
            foreach (var existingBoardSectionModeId in existingBoardSectionModeIds)
            {
                if (!boardSectionModeIds.Contains(existingBoardSectionModeId))
                {
                    var deleteThisExistingBoardSectionModeMap = (from eem in existingBoardSectionModeMappings
                        where eem.InterfaceBoardSectionModeUid == existingBoardSectionModeId
                        select eem).FirstOrDefault();
                    if (deleteThisExistingBoardSectionModeMap != null)
                        _inputDeviceSupervisionTypeInterfaceBoardSectionModeRepository.Remove(
                            deleteThisExistingBoardSectionModeMap.InputDeviceSupervisionTypeInterfaceBoardSectionModeUid,
                            sessionData);
                }
            }
            foreach (var boardSectionModeId in boardSectionModeIds)
            {
                if (!existingBoardSectionModeIds.Contains(boardSectionModeId))
                {
                    var entityMap = new InputDeviceSupervisionTypeInterfaceBoardSectionMode();
                    entityMap.InputDeviceSupervisionTypeInterfaceBoardSectionModeUid = GuidUtilities.GenerateComb();
                    entityMap.InterfaceBoardSectionModeUid = boardSectionModeId;
                    entityMap.InputDeviceSupervisionTypeUid = uid;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _inputDeviceSupervisionTypeInterfaceBoardSectionModeRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(InputDeviceSupervisionType entity,
            IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new InputDeviceSupervisionTypePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.InputDeviceSupervisionTypeUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceSupervisionTypeRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new InputDeviceSupervisionTypePDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id);
                // must read the original record from the database so the PDSA object can detect changes
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceSupervisionTypeRepository::Remove", ex);
                throw;
            }
        }

        protected override IEnumerable<InputDeviceSupervisionType> GetEntities(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDeviceSupervisionTypePDSAManager();
                mgr.DataObject.SelectFilter = InputDeviceSupervisionTypePDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceSupervisionTypeRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<InputDeviceSupervisionType> GetAllInputDeviceSupervisionTypeForInputDevice(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new InputDeviceSupervisionTypePDSAManager();
                mgr.DataObject.SelectFilter = InputDeviceSupervisionTypePDSAData.SelectFilters.ByInputDeviceUid;
                mgr.Entity.InputDeviceUid = parameters.UniqueId;
                return GetIEnumerable(sessionData, parameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceSupervisionTypeRepository::GetEntities", ex);
                throw;
            }

        }


        private IEnumerable<InputDeviceSupervisionType> GetIEnumerable(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters, InputDeviceSupervisionTypePDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (InputDeviceSupervisionType entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections || getParameters.IncludePhoto)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<InputDeviceSupervisionType> GetAllEntities(
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDeviceSupervisionTypePDSAManager();
                mgr.DataObject.SelectFilter = InputDeviceSupervisionTypePDSAData.SelectFilters.SelectAllForCulture;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceSupervisionTypeRepository::GetEntities", ex);
                throw;
            }
        }

        protected override InputDeviceSupervisionType GetEntityByIntId(int id,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override InputDeviceSupervisionType GetEntityByGuidId(Guid guid,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new InputDeviceSupervisionTypePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    InputDeviceSupervisionType result = new InputDeviceSupervisionType();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if (getParameters == null || getParameters.IncludeMemberCollections|| getParameters.IncludePhoto)
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceSupervisionTypeRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData,
            InputDeviceSupervisionType originalEntity, InputDeviceSupervisionType newEntity, string auditXml)
        {
            try
            {                if( !string.IsNullOrEmpty(auditXml))
                    auditXml = auditXml.EncodeForXml();
                var mgr = new gcsAudit_InsertPDSAManager();

                switch (operationType)
                {
                    case OperationType.Update:
                        if (newEntity == null)
                            throw new ArgumentNullException("newEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

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
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceSupervisionTypeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InputDeviceSupervisionTypeUid;
                        mgr.Entity.RecordTag = newEntity.InputDeviceSupervisionTypeUid.ToString();
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;

                        if (string.IsNullOrEmpty(auditXml) == false)
                        {
                            mgr.Entity.AuditXml = auditXml;
                            mgr.Execute();
                        }


mgr.Entity.AuditXml = null;

                        SimpleObjectDifferenceDetector.CompareResults differences =
                            SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity, propertiesToIgnore);
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
                            throw new ArgumentNullException("newEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceSupervisionTypeUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.InputDeviceSupervisionTypeUid;
                        mgr.Entity.RecordTag = newEntity.InputDeviceSupervisionTypeUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity",
                                ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        if (sessionData.OperationGuid == Guid.Empty)
                            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                        else
                            mgr.Entity.TransactionId = sessionData.OperationGuid;
                        mgr.Entity.TableName = DataStoreTableName;
                        mgr.Entity.OperationType = operationType.ToString();
                        mgr.Entity.PrimaryKeyColumn = "InputDeviceSupervisionTypeUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.InputDeviceSupervisionTypeUid;
                        mgr.Entity.RecordTag = originalEntity.InputDeviceSupervisionTypeUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {
                // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InputDeviceSupervisionTypeRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(InputDeviceSupervisionType entity,
            IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            if (entity.BinaryResourceUid.HasValue && 
                entity.BinaryResourceUid.Value != Guid.Empty && 
                getParameters != null && 
                getParameters.IncludePhoto)
            {
                entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData,
                    null);
            }

            if(getParameters != null && getParameters.IncludeMemberCollections)
            {
                var bsModeIds = _inputDeviceSupervisionTypeInterfaceBoardSectionModeRepository.GetAllInputDeviceSupervisionTypeInterfaceBoardSectionModesForSupervisionType(sessionData,
                    new GetParametersWithPhoto() {UniqueId = entity.InputDeviceSupervisionTypeUid});
                var modeIds = (from e in bsModeIds select e.InterfaceBoardSectionModeUid).ToList();
                entity.InterfaceBoardSectionModeIds.AddRange(modeIds);
            }
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("InputDeviceSupervisionType",
                "InputDeviceSupervisionTypeUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("InputDeviceSupervisionType",
                "InputDeviceSupervisionTypeUid", id);
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

        protected override bool IsEntityUnique(InputDeviceSupervisionType entity)
        {
            return true;
            //var mgr = new IsInputDeviceSupervisionTypeUniquePDSAManager();
            //mgr.Entity.InputDeviceSupervisionTypeUid = entity.InputDeviceSupervisionTypeUid;
            //mgr.Entity.Code = entity.Code;
            //mgr.BuildCollection();

            //if (Convert.ToInt32(mgr.Entity.Result) == 0)
            //    return true;
            //return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("InputDeviceSupervisionType",
                "InputDeviceSupervisionTypeUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("InputDeviceSupervisionType",
                "InputDeviceSupervisionTypeUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}