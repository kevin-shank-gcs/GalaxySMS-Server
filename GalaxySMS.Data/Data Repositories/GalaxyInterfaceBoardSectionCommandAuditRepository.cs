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
    [Export(typeof(IGalaxyInterfaceBoardSectionCommandAuditRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyInterfaceBoardSectionCommandAuditRepository : DataRepositoryBase<GalaxyInterfaceBoardSectionCommandAudit>, IGalaxyInterfaceBoardSectionCommandAuditRepository, IPartImportsSatisfiedNotification
    {
        
        protected override GalaxyInterfaceBoardSectionCommandAudit AddEntity(GalaxyInterfaceBoardSectionCommandAudit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandAuditPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionCommandAuditUid, sessionData, null);
                    //if (result != null)
                    //{
                    //    DataStoreTableName = mgr.DataObject.DBObjectName;
                    //    SaveAuditData(OperationType.Insert, sessionData, null, result, mgr.DataObject.AuditRowAsXml);
                    //}
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandAuditRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyInterfaceBoardSectionCommandAudit UpdateEntity(GalaxyInterfaceBoardSectionCommandAudit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionCommandAuditUid, sessionData, null);
                var mgr = new GalaxyInterfaceBoardSectionCommandAuditPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.GalaxyInterfaceBoardSectionCommandAuditUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.GalaxyInterfaceBoardSectionCommandAuditUid, sessionData, null);
                    //DataStoreTableName = mgr.DataObject.DBObjectName;
                    //SaveAuditData(OperationType.Update, sessionData, originalEntity, updatedEntity, mgr.DataObject.AuditRowAsXml);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandAuditRepository::UpdateEntity", ex);
                throw;
            }
        }

        public bool Insert(GalaxyInterfaceBoardSectionCommandAudit entity)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandAuditPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                return rowCount == 1;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandAuditRepository::Insert", ex);
                throw;
            }
        }

        protected override int DeleteEntity(GalaxyInterfaceBoardSectionCommandAudit entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandAuditPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyInterfaceBoardSectionCommandAuditUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandAuditRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyInterfaceBoardSectionCommandAuditPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandAuditRepository::Remove", ex);
                throw;
            }
        }

        // GetAllGalaxyInterfaceBoardSectionCommandAudits
        protected override IEnumerable<GalaxyInterfaceBoardSectionCommandAudit> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandAuditPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionCommandAuditPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandAuditRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyInterfaceBoardSectionCommandAudit> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyInterfaceBoardSectionCommandAuditPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (GalaxyInterfaceBoardSectionCommandAudit entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<GalaxyInterfaceBoardSectionCommandAudit> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandAuditPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionCommandAuditPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandAuditRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyInterfaceBoardSectionCommandAudit> GetAllGalaxyInterfaceBoardSectionCommandAuditsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandAuditPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyInterfaceBoardSectionCommandAuditPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandAuditRepository::GetEntities", ex);
                throw;
            }
        }
        
        protected override GalaxyInterfaceBoardSectionCommandAudit GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyInterfaceBoardSectionCommandAudit GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyInterfaceBoardSectionCommandAuditPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyInterfaceBoardSectionCommandAudit result = new GalaxyInterfaceBoardSectionCommandAudit();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    if(getParameters == null || getParameters.IncludeMemberCollections )
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandAuditRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyInterfaceBoardSectionCommandAudit originalEntity, GalaxyInterfaceBoardSectionCommandAudit newEntity, string auditXml)
        {
            return;
            try
            {
                //var mgr = new gcsAudit_InsertPDSAManager();
                //switch (operationType)
                //{
                //    case OperationType.Update:
                //        if (newEntity == null)
                //            throw new ArgumentNullException("newEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                //        if (originalEntity == null)
                //            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                //        List<String> propertiesToIgnore = new List<string>();
                //        propertiesToIgnore.Add("UpdateDate");
                //        propertiesToIgnore.Add("ConcurrencyValue");

                //        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                //        if (sessionData.OperationGuid == Guid.Empty)
                //            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                //        else
                //            mgr.Entity.TransactionId = sessionData.OperationGuid;
                //        mgr.Entity.TableName = DataStoreTableName;
                //        mgr.Entity.OperationType = operationType.ToString();
                //        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionCommandAuditUid";
                //        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyInterfaceBoardSectionCommandAuditUid;
                //        mgr.Entity.RecordTag = newEntity.;
                //        mgr.Entity.InsertName = sessionData.UserName;
                //        mgr.Entity.InsertDate = DateTimeOffset.Now;
                //        if (string.IsNullOrEmpty(auditXml) == false)
                //        {
                //            mgr.Entity.AuditXml = auditXml;
                //            mgr.Execute();
                //        }

                //        mgr.Entity.AuditXml = null;

                //        SimpleObjectDifferenceDetector.CompareResults differences = SimpleObjectDifferenceDetector.CompareObjects(originalEntity, newEntity, propertiesToIgnore);
                //        foreach (var property in differences.PropertyChanges)
                //        {
                //            //System.Diagnostics.Trace.WriteLine(property.ToString());
                //            mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                //            mgr.Entity.ColumnName = property.Value.PropertyName;
                //            if (property.Value.PropertyType == typeof(System.Byte[]))
                //            {
                //                mgr.Entity.OriginalValue = null;
                //                mgr.Entity.NewValue = null;
                //                mgr.Entity.OriginalBinaryValue = property.Value.OriginalValue as byte[];
                //                mgr.Entity.NewBinaryValue = property.Value.NewValue as byte[];
                //            }
                //            else
                //            {
                //                mgr.Entity.OriginalValue = property.Value.OriginalValue?.ToString();
                //                mgr.Entity.NewValue = property.Value.NewValue.ToString();
                //                mgr.Entity.OriginalBinaryValue = null;
                //                mgr.Entity.NewBinaryValue = null;
                //            }
                //            mgr.Execute();
                //        }
                //        break;

                //    case OperationType.Insert:
                //        if (newEntity == null)
                //            throw new ArgumentNullException("newEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                //        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                //        if (sessionData.OperationGuid == Guid.Empty)
                //            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                //        else
                //            mgr.Entity.TransactionId = sessionData.OperationGuid;
                //        mgr.Entity.TableName = DataStoreTableName;
                //        mgr.Entity.OperationType = operationType.ToString();
                //        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionCommandAuditUid";
                //        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyInterfaceBoardSectionCommandAuditUid;
                //        mgr.Entity.RecordTag = newEntity.GalaxyInterfaceBoardSectionCommandAuditName;
                //        mgr.Entity.AuditXml = auditXml;
                //        mgr.Entity.InsertName = sessionData.UserName;
                //        mgr.Entity.InsertDate = DateTimeOffset.Now;
                //        mgr.Execute();
                //        break;

                //    case OperationType.Delete:
                //        if (originalEntity == null)
                //            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));

                //        mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                //        if (sessionData.OperationGuid == Guid.Empty)
                //            mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                //        else
                //            mgr.Entity.TransactionId = sessionData.OperationGuid;
                //        mgr.Entity.TableName = DataStoreTableName;
                //        mgr.Entity.OperationType = operationType.ToString();
                //        mgr.Entity.PrimaryKeyColumn = "GalaxyInterfaceBoardSectionCommandAuditUid";
                //        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyInterfaceBoardSectionCommandAuditUid;
                //        mgr.Entity.RecordTag = originalEntity.GalaxyInterfaceBoardSectionCommandAuditName;
                //        mgr.Entity.AuditXml = auditXml;
                //        mgr.Entity.InsertName = sessionData.UserName;
                //        mgr.Entity.InsertDate = DateTimeOffset.Now;
                //        mgr.Execute();
                //        break;
                //}
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyInterfaceBoardSectionCommandAuditRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyInterfaceBoardSectionCommandAudit entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyInterfaceBoardSectionCommandAudit", "GalaxyInterfaceBoardSectionCommandAuditUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyInterfaceBoardSectionCommandAudit", "GalaxyInterfaceBoardSectionCommandAuditUid", id);
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

        protected override bool IsEntityUnique(GalaxyInterfaceBoardSectionCommandAudit entity)
        {
            return true;
            //var mgr = new IsGalaxyInterfaceBoardSectionCommandAuditUniquePDSAManager();
            //mgr.Entity.GalaxyInterfaceBoardSectionCommandAuditUid = entity.GalaxyInterfaceBoardSectionCommandAuditUid;
            //mgr.Entity.GalaxyInterfaceBoardSectionCommandAuditName = entity.GalaxyInterfaceBoardSectionCommandAuditName;
            //mgr.BuildCollection();

            //if (Convert.ToInt32(mgr.Entity.Result) == 0)
            //    return true;
            //return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyInterfaceBoardSectionCommandAudit", "GalaxyInterfaceBoardSectionCommandAuditUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyInterfaceBoardSectionCommandAudit", "GalaxyInterfaceBoardSectionCommandAuditUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
