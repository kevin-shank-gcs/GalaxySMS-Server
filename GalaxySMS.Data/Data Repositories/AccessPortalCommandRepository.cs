using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
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
using System.Linq;

namespace GalaxySMS.Data
{
    [Export(typeof(IAccessPortalCommandRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessPortalCommandRepository : DataRepositoryBase<AccessPortalCommand>, IAccessPortalCommandRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        [Import]
        private IAccessPortalTypeAccessPortalCommandRepository _AccessPortalTypeAccessPortalCommandRepository;

        [Import] private IAccessPortalCommandChoiceRepository _AccessPortalCommandChoiceRepository;
        //[Import]
        //private IAccessPortalRepository _AccessPortalRepository;

        protected override AccessPortalCommand AddEntity(AccessPortalCommand entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var mgr = new AccessPortalCommandPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.AccessPortalCommandUid, sessionData, null);
                    if (result != null)
                    {
                        SaveAccessPortalTypeMappings(sessionData, entity.AccessPortalCommandUid, entity.AccessPortalTypeIds, saveParams);
                        SaveCommandChoices(sessionData, entity.AccessPortalCommandUid, entity.AccessPortalCommandChoices, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalCommandRepository::AddEntity", ex);
                throw;
            }
        }

        protected override AccessPortalCommand UpdateEntity(AccessPortalCommand entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.AccessPortalCommandUid, sessionData, null);
                var mgr = new AccessPortalCommandPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.AccessPortalCommandUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    SaveAccessPortalTypeMappings(sessionData, entity.AccessPortalCommandUid, entity.AccessPortalTypeIds, saveParams);
                    SaveCommandChoices(sessionData, entity.AccessPortalCommandUid, entity.AccessPortalCommandChoices, saveParams);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.AccessPortalCommandUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalCommandRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void SaveAccessPortalTypeMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, ICollection<Guid> AccessPortalTypeIds, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingAccessPortalTypeMappings = _AccessPortalTypeAccessPortalCommandRepository.GetAllForAccessPortalCommand(sessionData, getParameters);
            var existingAccessPortalTypeIds = new HashSet<Guid>(existingAccessPortalTypeMappings.Select(e => e.AccessPortalTypeUid));
            foreach (var existingAccessPortalTypeId in existingAccessPortalTypeIds)
            {
                if (!AccessPortalTypeIds.Contains(existingAccessPortalTypeId))
                {
                    var deleteThisExistingAccessPortalTypeMap = (from eem in existingAccessPortalTypeMappings where eem.AccessPortalTypeUid == existingAccessPortalTypeId select eem).FirstOrDefault();
                    if (deleteThisExistingAccessPortalTypeMap != null)
                        _AccessPortalTypeAccessPortalCommandRepository.Remove(deleteThisExistingAccessPortalTypeMap.AccessPortalTypeAccessPortalCommandUid, sessionData);
                }
            }
            foreach (var AccessPortalTypeId in AccessPortalTypeIds)
            {
                if (!existingAccessPortalTypeIds.Contains(AccessPortalTypeId))
                {
                    var entityMap = new AccessPortalTypeAccessPortalCommand();
                    entityMap.AccessPortalTypeAccessPortalCommandUid = GuidUtilities.GenerateComb();
                    entityMap.AccessPortalTypeUid = AccessPortalTypeId;
                    entityMap.AccessPortalCommandUid = uid;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _AccessPortalTypeAccessPortalCommandRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        private void SaveCommandChoices(IApplicationUserSessionDataHeader sessionData, Guid uid, ICollection<AccessPortalCommandChoice> choices, ISaveParameters saveParams)
        {
            var kvpSaveOption = saveParams.Options.FirstOrDefault(o => o.Key == nameof(GalaxySMS.Common.Enums.SaveCommandOption).ToString());

            bool bDeleteMissingItems = !string.IsNullOrEmpty(kvpSaveOption.Key) &&
                                       !string.IsNullOrEmpty(kvpSaveOption.Value) &&
                                       kvpSaveOption.Value == SaveCommandOption.DeleteMissingItems.ToString();

            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingChoices = _AccessPortalCommandChoiceRepository.GetAllForCommand(sessionData, getParameters);

            if (bDeleteMissingItems)
            {
                foreach (var existingChoice in existingChoices)
                {
                    // If the item does not exist in the incoming choices collection, then delete it from the database
                    var c = choices.FirstOrDefault(o => o.ChoiceTypeCode == existingChoice.ChoiceTypeCode);
                    if (c == null)
                    {
                        // The existing choice is not in the collection of choices to save, then delete it
                        _AccessPortalCommandChoiceRepository.Remove(existingChoice.AccessPortalCommandChoiceUid,
                            sessionData);
                    }
                }
            }

            foreach (var c in choices)
            {
                var existingItem = existingChoices.FirstOrDefault(o => o.ChoiceTypeCode == c.ChoiceTypeCode);
                if (c.AccessPortalCommandUid != uid)
                    c.AccessPortalCommandUid = uid;
                if (c.AccessPortalCommandChoiceUid == Guid.Empty)
                {
                    if (existingItem != null)
                        c.AccessPortalCommandChoiceUid = existingItem.AccessPortalCommandChoiceUid;
                }

                var propsToInclude = new List<string>();

                if (!propsToInclude.Any())
                {
                    //propsToInclude.Add(nameof(c.AreaUid));
                }

                if (existingItem != null && (c.IsAnythingDirty ||
                                             ObjectComparer.AreAnyPublicPropertiesDifferent(existingItem, c, propsToInclude)))
                {
                    c.InsertDate = existingItem.InsertDate;
                    c.InsertName = existingItem.InsertName;
                    UpdateTableEntityBaseProperties(c, sessionData);
                    _AccessPortalCommandChoiceRepository.Update(c, sessionData, saveParams);
                }
                if (c.AccessPortalCommandChoiceUid == Guid.Empty)
                {
                    c.AccessPortalCommandChoiceUid = GuidUtilities.GenerateComb();
                    c.AccessPortalCommandUid = uid;
                    UpdateTableEntityBaseProperties(c, sessionData);
                    _AccessPortalCommandChoiceRepository.Add(c, sessionData, saveParams);
                }
            }
        }


        protected override int DeleteEntity(AccessPortalCommand entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new AccessPortalCommandPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.AccessPortalCommandUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalCommandRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new AccessPortalCommandPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalCommandRepository::Remove", ex);
                throw;
            }
        }

        // GetAllAccessPortalCommands in a region
        protected override IEnumerable<AccessPortalCommand> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalCommandPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalCommandPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalCommandRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<AccessPortalCommand> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, AccessPortalCommandPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (AccessPortalCommand entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<AccessPortalCommand> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalCommandPDSAManager();
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalCommandRepository::GetEntities", ex);
                throw;
            }
        }


        public IEnumerable<AccessPortalCommand> GetAllAccessPortalCommandsForAccessPortalType(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessPortalCommandPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalCommandPDSAData.SelectFilters.ByAccessPortalTypeUid;
                mgr.Entity.AccessPortalTypeUid = parameters.UniqueId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                return GetIEnumerable(sessionData, parameters, mgr);

            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalCommandRepository::GetAllAccessPortalCommandsForAccessPortalType", ex);
                throw;
            }
        }

        public IEnumerable<AccessPortalCommand> GetAllAccessPortalCommandsForAccessPortal(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new AccessPortalCommandPDSAManager();
                mgr.DataObject.SelectFilter = AccessPortalCommandPDSAData.SelectFilters.ByAccessPortalUid;
                mgr.Entity.AccessPortalUid = parameters.UniqueId;
                mgr.Entity.CultureName = sessionData.UiCulture;
                var cmds = GetIEnumerable(sessionData, parameters, mgr);

                ////  Now determine if the access portal Relay2 mode is Scheduled.If not, take out the relay2 on / off commands
                //var apData = _AccessPortalRepository.GetAccessPortalPanelLoadData(sessionData, new GetParametersWithPhoto()
                //{
                //    IncludePhoto = false,
                //    UniqueId = parameters.UniqueId
                //});
                //  if (apData != null)
                //  {
                //      if ((GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode)apData.Relay2ModeCode != GalaxySMS.Common.Enums.AccessPortalAuxiliaryOutputMode.Scheduled)
                //      {
                //          var cmd = cmds.FirstOrDefault(o => o.AccessPortalCommandUid == Common.Constants.AccessPortalCommandIds.AuxRelayOff);
                //          if (cmd != null)
                //              cmds.Remove(cmd);
                //          cmd = cmds.FirstOrDefault(o => o.AccessPortalCommandUid == Common.Constants.AccessPortalCommandIds.AuxRelayOn);
                //          if (cmd != null)
                //              cmds.Remove(cmd);
                //      }
                //  }
                return cmds;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalCommandRepository::GetAllAccessPortalCommandsForAccessPortal", ex);
                throw;
            }
        }

        protected override AccessPortalCommand GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override AccessPortalCommand GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new AccessPortalCommandPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    AccessPortalCommand result = new AccessPortalCommand();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalCommandRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, AccessPortalCommand originalEntity, AccessPortalCommand newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalCommandUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessPortalCommandUid;
                        mgr.Entity.RecordTag = newEntity.AccessPortalCommandUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalCommandUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.AccessPortalCommandUid;
                        mgr.Entity.RecordTag = newEntity.AccessPortalCommandUid.ToString(); mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "AccessPortalCommandUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.AccessPortalCommandUid;
                        mgr.Entity.RecordTag = originalEntity.AccessPortalCommandUid.ToString(); mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalCommandRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(AccessPortalCommand entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("AccessPortalCommand", "AccessPortalCommandUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("AccessPortalCommand", "AccessPortalCommandUid", id);
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

        protected override bool IsEntityUnique(AccessPortalCommand entity)
        {
            var mgr = new IsAccessPortalCommandUniquePDSAManager();
            mgr.Entity.AccessPortalCommandUid = entity.AccessPortalCommandUid;
            mgr.Entity.Display = entity.Display;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("AccessPortalCommand", "AccessPortalCommandUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("AccessPortalCommand", "AccessPortalCommandUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
