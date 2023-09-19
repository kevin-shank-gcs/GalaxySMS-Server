using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Config;
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
    [Export(typeof(IGcsUserEntityApplicationRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserEntityApplicationRoleRepository : DataRepositoryBase<gcsUserEntityApplicationRole>, IGcsUserEntityApplicationRoleRepository
    {
        protected override gcsUserEntityApplicationRole AddEntity(gcsUserEntityApplicationRole entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.UserEntityApplicationRoleId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsUserEntityApplicationRole UpdateEntity(gcsUserEntityApplicationRole entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.UserEntityApplicationRoleId, sessionData, null);
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.UserEntityApplicationRoleId); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.UserEntityApplicationRoleId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsUserEntityApplicationRole entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.UserEntityApplicationRoleId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();

                // PDSA Audit Tracking setup phase
                int rowsDeleted = 0;
                int rowsLoaded = mgr.DataObject.LoadByPK(id); // must read the original record from the database so the PDSA object can detect changes
                if (rowsLoaded == 1 && originalEntity != null)
                {
                    rowsDeleted = mgr.DataObject.DeleteByPK(id);
                    if (rowsDeleted > 0)
                    {
                        DataStoreTableName = mgr.DataObject.DBObjectName;
                        SaveAuditData(OperationType.Delete, sessionData, originalEntity, null,
                            mgr.DataObject.AuditRowAsXml);
                    }
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::Remove", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserEntityApplicationRole> GetByUserEntityId(Guid userEntityId)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityApplicationRolePDSAData.SelectFilters.ByUserEntityId;
                mgr.Entity.UserEntityId = userEntityId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::GetByUserEntity", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserEntityApplicationRole> GetByUserEntityIdAndApplicationId(Guid userEntityId, Guid applicationId)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityApplicationRolePDSAData.SelectFilters.ByUserEntityIdApplicationId;
                mgr.Entity.UserEntityId = userEntityId;
                mgr.Entity.ApplicationId = applicationId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::GetByUserEntityIdAndApplicationId", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserEntityApplicationRole> GetByEntityApplicationRoleId(Guid entityApplicationRoleId)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityApplicationRolePDSAData.SelectFilters.ByEntityApplicationRoleId;
                mgr.Entity.EntityApplicationRoleId = entityApplicationRoleId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::GetByEntityApplicationRoleId", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserEntityApplicationRole> GetByUserId(Guid userId)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityApplicationRolePDSAData.SelectFilters.ByUserId;
                mgr.Entity.UserId = userId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::GetByUserId", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserEntityApplicationRole> GetByUserIdAndEntityId(Guid userId, Guid entityId)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityApplicationRolePDSAData.SelectFilters.ByUserIdEntityId;
                mgr.Entity.UserId = userId;
                mgr.Entity.EntityId = entityId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::GetByUserIdAndEntityId", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserEntityApplicationRole> GetByUserIdAndEntityIdAndApplicationId(Guid userId, Guid entityId, Guid applicationId)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityApplicationRolePDSAData.SelectFilters.ByUserIdEntityIdApplicationId;
                mgr.Entity.UserId = userId;
                mgr.Entity.EntityId = entityId;
                mgr.Entity.ApplicationId = applicationId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::GetByUserIdAndEntityIdAndApplicationId", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserEntityApplicationRole> GetByUserEntityIdAndRoleId(Guid userEntityId, Guid roleId)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityApplicationRolePDSAData.SelectFilters.ByUserEntityIdRoleId;
                mgr.Entity.UserEntityId = userEntityId;
                mgr.Entity.RoleId = roleId;
                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::GetByUserEntityIdAndRoleId", ex);
                throw;
            }
        }
        protected override IEnumerable<gcsUserEntityApplicationRole> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsUserEntityApplicationRole> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsUserEntityApplicationRole GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsUserEntityApplicationRole GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserEntityApplicationRolePDSAManager mgr = new gcsUserEntityApplicationRolePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsUserEntityApplicationRole result = new gcsUserEntityApplicationRole();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsUserEntityApplicationRole originalEntity, gcsUserEntityApplicationRole newEntity, string auditXml)
        {
            try
            {
                switch (operationType)
                {
                    case OperationType.Update:
                        if (newEntity == null)
                            throw new ArgumentNullException("newEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        break;

                    case OperationType.Insert:
                        if (newEntity == null)
                            throw new ArgumentNullException("newEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        break;

                    case OperationType.Delete:
                        if (originalEntity == null)
                            throw new ArgumentNullException("originalEntity", ReflectionExtensions.GetFullMethodName(System.Reflection.MethodBase.GetCurrentMethod()));
                        break;
                }
                if (!string.IsNullOrEmpty(auditXml))
                    auditXml = auditXml.EncodeForXml();
                var mgr = new gcsAudit_InsertPDSAManager();
                mgr.Entity.AuditId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                if (sessionData.OperationGuid == Guid.Empty)
                    mgr.Entity.TransactionId = GuidUtilities.GenerateComb(); // Guid.NewGuid();
                else
                    mgr.Entity.TransactionId = sessionData.OperationGuid;
                mgr.Entity.TableName = DataStoreTableName;
                mgr.Entity.OperationType = operationType.ToString();
                mgr.Entity.PrimaryKeyColumn = "UserEntityApplicationRoleId";
                mgr.Entity.InsertName = sessionData.UserName;
                mgr.Entity.InsertDate = DateTimeOffset.Now;
                mgr.Entity.RecordTag = string.Empty;
                if (string.IsNullOrEmpty(auditXml) == false)
                    mgr.Entity.AuditXml = auditXml;

                switch (operationType)
                {
                    case OperationType.Update:
                        List<String> propertiesToIgnore = new List<string>(); propertiesToIgnore.Add("UpdateDate");
                        propertiesToIgnore.Add("UpdateName");
                        propertiesToIgnore.Add("ConcurrencyValue");
                        propertiesToIgnore.Add("gcsEntityApplicationRole");
                        propertiesToIgnore.Add("gcsUserEntity");

                        mgr.Entity.PrimaryKeyValue = newEntity.UserEntityApplicationRoleId;
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
                        mgr.Entity.PrimaryKeyValue = newEntity.UserEntityApplicationRoleId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        mgr.Entity.PrimaryKeyValue = originalEntity.UserEntityApplicationRoleId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityApplicationRoleRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsUserEntityApplicationRole entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {

        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsUserEntityApplicationRole entity)
        {
            gcs_IsUserEntityApplicationRoleUniquePDSAManager mgr = new gcs_IsUserEntityApplicationRoleUniquePDSAManager();
            mgr.Entity.UserEntityApplicationRoleId = entity.UserEntityApplicationRoleId;
            mgr.Entity.EntityApplicationRoleId = entity.EntityApplicationRoleId;
            mgr.Entity.UserEntityId = entity.UserEntityId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsUserEntityApplicationRole", "UserEntityApplicationRoleId", id);
            if (count == 0)
                return false;
            return true;
        }

        protected override bool DoesEntityExist(int id)
        {
            return false;
        }

        protected override bool IsEntityReferenced(Guid id)
        {
            return false;
        }

        protected override bool IsEntityReferenced(int id)
        {
            return false;
        }

        protected override bool CanEntityBeDeleted(Guid id)
        {
            return true;
        }

    }
}
