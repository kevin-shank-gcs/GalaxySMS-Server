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
    [Export(typeof(IGalaxyInterfaceBoardSectionCommandRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyInterfaceBoardSectionCommandRepository : DataRepositoryBase<GalaxyInterfaceBoardSectionCommand>, IGalaxyInterfaceBoardSectionCommandRepository, IPartImportsSatisfiedNotification
    {
        //[Import]
        //private IGcsBinaryResourceRepository _binaryResourceRepository;

        [Import]
        private IGcsResourceStringRepository _resourceStringRepository;

        [Import]
        private IGalaxyInterfaceBoardSectionModeCommandRepository _galaxyInterfaceBoardSectionModeCommandRepository;
        //[Import]
        //private IGalaxyInterfaceBoardSectionRepository _GalaxyInterfaceBoardSectionRepository;

        protected override GalaxyInterfaceBoardSectionCommand AddEntity(GalaxyInterfaceBoardSectionCommand entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //_binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var mgr = new GalaxyInterfaceBoardSectionCommandPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionCommandUid, sessionData, null);
                    if (result != null)
                    {
                        SaveGalaxyInterfaceBoardSectionModeMappings(sessionData, entity.GalaxyInterfaceBoardSectionCommandUid, entity.InterfaceBoardSectionModeIds, saveParams);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyInterfaceBoardSectionCommand UpdateEntity(GalaxyInterfaceBoardSectionCommand entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                //if (entity.gcsBinaryResource?.HasBeenModified == true)
                //    _binaryResourceRepository.SaveBinaryResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDisplayResource(entity, sessionData, saveParams);
                _resourceStringRepository.SaveDescriptionResource(entity, sessionData, saveParams);

                var originalEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionCommandUid, sessionData, null);
                var mgr = new GalaxyInterfaceBoardSectionCommandPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.GalaxyInterfaceBoardSectionCommandUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    SaveGalaxyInterfaceBoardSectionModeMappings(sessionData, entity.GalaxyInterfaceBoardSectionCommandUid, entity.InterfaceBoardSectionModeIds, saveParams);
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionCommandUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandRepository::UpdateEntity", ex);
                throw;
            }
        }

        private void SaveGalaxyInterfaceBoardSectionModeMappings(IApplicationUserSessionDataHeader sessionData, Guid uid, ICollection<Guid> GalaxyInterfaceBoardSectionModeIds, ISaveParameters saveParams)
        {
            var getParameters = new GetParametersWithPhoto() { UniqueId = uid };
            var existingGalaxyInterfaceBoardSectionModeMappings = _galaxyInterfaceBoardSectionModeCommandRepository.GetAllGalaxyInterfaceBoardSectionModeCommandForMode(sessionData, getParameters);
            var existingGalaxyInterfaceBoardSectionModeIds = new HashSet<Guid>(existingGalaxyInterfaceBoardSectionModeMappings.Select(e => e.InterfaceBoardSectionModeUid));
            foreach (var existingGalaxyInterfaceBoardSectionModeId in existingGalaxyInterfaceBoardSectionModeIds)
            {
                if (!GalaxyInterfaceBoardSectionModeIds.Contains(existingGalaxyInterfaceBoardSectionModeId))
                {
                    var deleteThisExistingGalaxyInterfaceBoardSectionModeMap = (from eem in existingGalaxyInterfaceBoardSectionModeMappings where eem.InterfaceBoardSectionModeUid == existingGalaxyInterfaceBoardSectionModeId select eem).FirstOrDefault();
                    if (deleteThisExistingGalaxyInterfaceBoardSectionModeMap != null)
                        _galaxyInterfaceBoardSectionModeCommandRepository.Remove(deleteThisExistingGalaxyInterfaceBoardSectionModeMap.GalaxyInterfaceBoardSectionModeCommandUid, sessionData);
                }
            }
            foreach (var interfaceBoardSectionModeId in GalaxyInterfaceBoardSectionModeIds)
            {
                if (!existingGalaxyInterfaceBoardSectionModeIds.Contains(interfaceBoardSectionModeId))
                {
                    var entityMap = new GalaxyInterfaceBoardSectionModeCommand();
                    entityMap.GalaxyInterfaceBoardSectionModeCommandUid = GuidUtilities.GenerateComb();
                    entityMap.InterfaceBoardSectionModeUid = interfaceBoardSectionModeId;
                    entityMap.GalaxyInterfaceBoardSectionCommandUid = uid;
                    entityMap.UpdateDate = DateTimeOffset.Now;
                    entityMap.UpdateName = sessionData.UserName;
                    entityMap.InsertDate = DateTimeOffset.Now;
                    entityMap.InsertName = sessionData.UserName;

                    _galaxyInterfaceBoardSectionModeCommandRepository.Add(entityMap, sessionData, saveParams);
                }
            }
        }

        protected override int DeleteEntity(GalaxyInterfaceBoardSectionCommand entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyInterfaceBoardSectionCommandUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyInterfaceBoardSectionCommandPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandRepository::Remove", ex);
                throw;
            }
        }

        // GetAllGalaxyInterfaceBoardSectionCommands in a region
        protected override IEnumerable<GalaxyInterfaceBoardSectionCommand> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionCommandPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyInterfaceBoardSectionCommand> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyInterfaceBoardSectionCommandPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (GalaxyInterfaceBoardSectionCommand entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, sessionData, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<GalaxyInterfaceBoardSectionCommand> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandPDSAManager();
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSectionCommand> GetAllGalaxyInterfaceBoardSectionCommandsForGalaxyInterfaceBoardSectionMode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionCommandPDSAData.SelectFilters.ByGalaxyInterfaceBoardSectionMode;
                mgr.Entity.InterfaceBoardSectionModeUid = parameters.UniqueId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandRepository::GetAllGalaxyInterfaceBoardSectionCommandsForGalaxyInterfaceBoardSectionType", ex);
                throw;
            }
        }


        //public IEnumerable<GalaxyInterfaceBoardSectionCommand> GetAllGalaxyInterfaceBoardSectionCommandsForGalaxyInterfaceBoardSection(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters)
        //{
        //    try
        //    {
        //        var mgr = new GalaxyInterfaceBoardSectionCommandPDSAManager();
        //        mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionCommandPDSAData.SelectFilters.ByGalaxyInterfaceBoardSectionUid;
        //        mgr.Entity.GalaxyInterfaceBoardSectionUid = parameters.UniqueId;
        //        mgr.Entity.CultureName = sessionData.UiCulture;
        //        var cmds = GetIEnumerable(sessionData, parameters, mgr);
        //        return cmds;
        //    }
        //    catch (PDSAValidationException ex)
        //    {
        //        DataValidationException dve = Converters.ConvertToDataValidationException(ex);
        //        throw dve;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandRepository::GetAllGalaxyInterfaceBoardSectionCommandsForGalaxyInterfaceBoardSection", ex);
        //        throw;
        //    }
        //}

        protected override GalaxyInterfaceBoardSectionCommand GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyInterfaceBoardSectionCommand GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyInterfaceBoardSectionCommand result = new GalaxyInterfaceBoardSectionCommand();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyInterfaceBoardSectionCommand originalEntity, GalaxyInterfaceBoardSectionCommand newEntity, string auditXml)
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionCommandUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyInterfaceBoardSectionCommandUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyInterfaceBoardSectionCommandUid.ToString();
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionCommandUid";
                        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyInterfaceBoardSectionCommandUid;
                        mgr.Entity.RecordTag = newEntity.GalaxyInterfaceBoardSectionCommandUid.ToString();                        mgr.Entity.AuditXml = auditXml;
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
                        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionCommandUid";
                        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyInterfaceBoardSectionCommandUid;
                        mgr.Entity.RecordTag = originalEntity.GalaxyInterfaceBoardSectionCommandUid.ToString();                        mgr.Entity.AuditXml = auditXml;
                        mgr.Entity.InsertName = sessionData.UserName;
                        mgr.Entity.InsertDate = DateTimeOffset.Now;
                        mgr.Entity.UserId = sessionData.UserId;
                        mgr.Execute();
break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyInterfaceBoardSectionCommand entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            //if (entity.BinaryResourceUid.HasValue && entity.BinaryResourceUid.Value != Guid.Empty)
            //{
            //    entity.gcsBinaryResource = _binaryResourceRepository.Get(entity.BinaryResourceUid.Value, sessionData, null);
            //}
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyInterfaceBoardSectionCommand", "GalaxyInterfaceBoardSectionCommandUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyInterfaceBoardSectionCommand", "GalaxyInterfaceBoardSectionCommandUid", id);
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

        protected override bool IsEntityUnique(GalaxyInterfaceBoardSectionCommand entity)
        {
            var mgr = new IsGalaxyInterfaceBoardSectionCommandUniquePDSAManager();
            mgr.Entity.GalaxyInterfaceBoardSectionCommandUid = entity.GalaxyInterfaceBoardSectionCommandUid;
            mgr.Entity.Display = entity.Display;
            mgr.BuildCollection();

            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyInterfaceBoardSectionCommand", "GalaxyInterfaceBoardSectionCommandUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyInterfaceBoardSectionCommand", "GalaxyInterfaceBoardSectionCommandUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }

    }
}
