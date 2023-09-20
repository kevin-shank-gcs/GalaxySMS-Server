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
    [Export(typeof(IGalaxyPanelCommandAuditRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyPanelCommandAuditRepository : DataRepositoryBase<GalaxyPanelCommandAudit>, IGalaxyPanelCommandAuditRepository, IPartImportsSatisfiedNotification
    {
        
        protected override GalaxyPanelCommandAudit AddEntity(GalaxyPanelCommandAudit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {

                var mgr = new GalaxyPanelCommandAuditPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.GalaxyPanelCommandAuditUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelCommandAuditRepository::AddEntity", ex);
                throw;
            }
        }

        protected override GalaxyPanelCommandAudit UpdateEntity(GalaxyPanelCommandAudit entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.GalaxyPanelCommandAuditUid, sessionData, null);
                var mgr = new GalaxyPanelCommandAuditPDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.GalaxyPanelCommandAuditUid); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.GalaxyPanelCommandAuditUid, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelCommandAuditRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(GalaxyPanelCommandAudit entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                var mgr = new GalaxyPanelCommandAuditPDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.GalaxyPanelCommandAuditUid);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelCommandAuditRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                var mgr = new GalaxyPanelCommandAuditPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelCommandAuditRepository::Remove", ex);
                throw;
            }
        }

        // GetAllGalaxyPanelCommandAudits
        protected override IEnumerable<GalaxyPanelCommandAudit> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelCommandAuditPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelCommandAuditRepository::GetEntities", ex);
                throw;
            }
        }

        private IEnumerable<GalaxyPanelCommandAudit> GetIEnumerable(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters, GalaxyPanelCommandAuditPDSAManager mgr)
        {
            var pdsaEntities = mgr.BuildCollection();
            if (pdsaEntities != null)
            {
                var entities = mgr.ConvertPDSACollection(pdsaEntities);
                foreach (GalaxyPanelCommandAudit entity in entities)
                {
                    if (getParameters == null || getParameters.IncludeMemberCollections)
                        FillMemberCollections(entity, null, getParameters);
                }
                return entities;
            }
            return null;
        }

        protected override IEnumerable<GalaxyPanelCommandAudit> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelCommandAuditPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelCommandAuditRepository::GetEntities", ex);
                throw;
            }
        }

        public IEnumerable<GalaxyPanelCommandAudit> GetAllGalaxyPanelCommandAuditsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelCommandAuditPDSAManager();
                mgr.DataObject.SelectFilter = GalaxyPanelCommandAuditPDSAData.SelectFilters.All;
                return GetIEnumerable(sessionData, getParameters, mgr);
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelCommandAuditRepository::GetEntities", ex);
                throw;
            }
        }
        
        protected override GalaxyPanelCommandAudit GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override GalaxyPanelCommandAudit GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                var mgr = new GalaxyPanelCommandAuditPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    GalaxyPanelCommandAudit result = new GalaxyPanelCommandAudit();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelCommandAuditRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, GalaxyPanelCommandAudit originalEntity, GalaxyPanelCommandAudit newEntity, string auditXml)
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
                //        mgr.Entity.PrimaryKeyColumn = "GalaxyPanelCommandAuditUid";
                //        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyPanelCommandAuditUid;
                //        mgr.Entity.RecordTag = newEntity.GalaxyPanelCommandAuditName;
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
                //        mgr.Entity.PrimaryKeyColumn = "GalaxyPanelCommandAuditUid";
                //        mgr.Entity.PrimaryKeyValue = newEntity.GalaxyPanelCommandAuditUid;
                //        mgr.Entity.RecordTag = newEntity.GalaxyPanelCommandAuditName;
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
                //        mgr.Entity.PrimaryKeyColumn = "GalaxyPanelCommandAuditUid";
                //        mgr.Entity.PrimaryKeyValue = originalEntity.GalaxyPanelCommandAuditUid;
                //        mgr.Entity.RecordTag = originalEntity.GalaxyPanelCommandAuditName;
                //        mgr.Entity.AuditXml = auditXml;
                //        mgr.Entity.InsertName = sessionData.UserName;
                //        mgr.Entity.InsertDate = DateTimeOffset.Now;
                //        mgr.Execute();
                //        break;
                //}
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GalaxyPanelCommandAuditRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(GalaxyPanelCommandAudit entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            var count = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("GalaxyPanelCommandAudit", "GalaxyPanelCommandAuditUid", id);

            if (count != 0)
                return true;

            count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("GalaxyPanelCommandAudit", "GalaxyPanelCommandAuditUid", id);
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

        protected override bool IsEntityUnique(GalaxyPanelCommandAudit entity)
        {
            return true;
            //var mgr = new IsGalaxyPanelCommandAuditUniquePDSAManager();
            //mgr.Entity.GalaxyPanelCommandAuditUid = entity.GalaxyPanelCommandAuditUid;
            //mgr.Entity.GalaxyPanelCommandAuditName = entity.GalaxyPanelCommandAuditName;
            //mgr.BuildCollection();

            //if (Convert.ToInt32(mgr.Entity.Result) == 0)
            //    return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("GalaxyPanelCommandAudit", "GalaxyPanelCommandAuditUid", id);
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
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("GalaxyPanelCommandAudit", "GalaxyPanelCommandAuditUid", id);
            if (count == 0)
                return true;
            return false;
        }

        public void OnImportsSatisfied()
        {
        }
    }
}
