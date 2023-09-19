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
    [Export(typeof(IGcsUserEntityRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserEntityRoleRepository : DataRepositoryBase<gcsUserEntityRole>, IGcsUserEntityRoleRepository
    {
        protected override gcsUserEntityRole AddEntity(gcsUserEntityRole entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
                if (rowCount > 0)
                {
                    var result = GetEntityByGuidId(entity.UserEntityRoleId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::AddEntity", ex);
                throw;
            }
        }

        protected override gcsUserEntityRole UpdateEntity(gcsUserEntityRole entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            try
            {
                var originalEntity = GetEntityByGuidId(entity.UserEntityRoleId, sessionData, null);
                gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();

                // PDSA Audit Tracking setup phase
                mgr.DataObject.LoadByPK(entity.UserEntityRoleId); // must read the original record from the database so the PDSA object can detect changes

                mgr.InitEntityObject(entity);
                int rowsUpdated = mgr.DataObject.Update();
                if (rowsUpdated > 0)
                {
                    // Read the updated record to use for SimpleObjectDifferenceDetector audit purposes and to obtain the new ConcurrencyValue which the client application will need for subsequent operations
                    var updatedEntity = GetEntityByGuidId(entity.UserEntityRoleId, sessionData, null);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::UpdateEntity", ex);
                throw;
            }
        }

        protected override int DeleteEntity(gcsUserEntityRole entity, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();
                mgr.InitEntityObject(entity);
                int rowsDeleted = mgr.DataObject.DeleteByPK(entity.UserEntityRoleId);
                if (rowsDeleted > 0)
                {
                    DataStoreTableName = mgr.DataObject.DBObjectName;
                    SaveAuditData(OperationType.Delete, sessionData, entity, null, mgr.DataObject.AuditRowAsXml);
                }
                return rowsDeleted;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::DeleteEntity", ex);
                throw;
            }
        }

        public override int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            try
            {
                // make a copy of the original user from the database for SimpleObjectDifferenceDetector audit purposes
                var originalEntity = GetEntityByGuidId(id, sessionData, null);
                gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::Remove", ex);
                throw;
            }
        }

        public IEnumerable<gcsUserEntityRole> GetByUserEntityId(Guid userEntityId)
        {
            try
            {
                gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityRolePDSAData.SelectFilters.ByUserEntityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::GetByUserEntity", ex);
                throw;
            }
        }

        //public IEnumerable<gcsUserEntityRole> GetByUserEntityIdAndApplicationId(Guid userEntityId, Guid applicationId)
        //{
        //    try
        //    {
        //        gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();
        //        mgr.DataObject.SelectFilter = gcsUserEntityRolePDSAData.SelectFilters.ByUserEntityIdApplicationId;
        //        mgr.Entity.UserEntityId = userEntityId;
        //        mgr.Entity.ApplicationId = applicationId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //            return entities;
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::GetByUserEntityIdAndApplicationId", ex);
        //        throw;
        //    }
        //}

        //public IEnumerable<gcsUserEntityRole> GetByEntityApplicationRoleId(Guid entityApplicationRoleId)
        //{
        //    try
        //    {
        //        gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();
        //        mgr.DataObject.SelectFilter = gcsUserEntityRolePDSAData.SelectFilters.ByEntityApplicationRoleId;
        //        mgr.Entity.EntityApplicationRoleId = entityApplicationRoleId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //            return entities;
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::GetByEntityApplicationRoleId", ex);
        //        throw;
        //    }
        //}

        public IEnumerable<gcsUserEntityRole> GetByUserId(Guid userId)
        {
            try
            {
                gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();
                mgr.DataObject.SelectFilter = gcsUserEntityRolePDSAData.SelectFilters.ByUserId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::GetByUserId", ex);
                throw;
            }
        }

        //public IEnumerable<gcsUserEntityRole> GetByUserIdAndEntityId(Guid userId, Guid entityId)
        //{
        //    try
        //    {
        //        gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();
        //        mgr.DataObject.SelectFilter = gcsUserEntityRolePDSAData.SelectFilters.ByUserIdEntityId;
        //        mgr.Entity.UserId = userId;
        //        mgr.Entity.EntityId = entityId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //            return entities;
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::GetByUserIdAndEntityId", ex);
        //        throw;
        //    }
        //}

        //public IEnumerable<gcsUserEntityRole> GetByUserIdAndEntityIdAndApplicationId(Guid userId, Guid entityId, Guid applicationId)
        //{
        //    try
        //    {
        //        gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();
        //        mgr.DataObject.SelectFilter = gcsUserEntityRolePDSAData.SelectFilters.ByUserIdEntityIdApplicationId;
        //        mgr.Entity.UserId = userId;
        //        mgr.Entity.EntityId = entityId;
        //        mgr.Entity.ApplicationId = applicationId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //            return entities;
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::GetByUserIdAndEntityIdAndApplicationId", ex);
        //        throw;
        //    }
        //}

        //public IEnumerable<gcsUserEntityRole> GetByUserEntityIdAndRoleId(Guid userEntityId, Guid roleId)
        //{
        //    try
        //    {
        //        gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();
        //        mgr.DataObject.SelectFilter = gcsUserEntityRolePDSAData.SelectFilters.ByUserEntityIdRoleId;
        //        mgr.Entity.UserEntityId = userEntityId;
        //        mgr.Entity.RoleId = roleId;
        //        var pdsaEntities = mgr.BuildCollection();
        //        if (pdsaEntities != null)
        //        {
        //            var entities = mgr.ConvertPDSACollection(pdsaEntities);
        //            return entities;
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::GetByUserEntityIdAndRoleId", ex);
        //        throw;
        //    }
        //}
        protected override IEnumerable<gcsUserEntityRole> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::GetEntities", ex);
                throw;
            }
        }

        protected override IEnumerable<gcsUserEntityRole> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntities(sessionData, getParameters);
        }

        protected override gcsUserEntityRole GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return null;
        }

        protected override gcsUserEntityRole GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            try
            {
                gcsUserEntityRolePDSAManager mgr = new gcsUserEntityRolePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsUserEntityRole result = new gcsUserEntityRole();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        protected override void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, gcsUserEntityRole originalEntity, gcsUserEntityRole newEntity, string auditXml)
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
                mgr.Entity.PrimaryKeyColumn = "UserEntityRoleId";
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

                        mgr.Entity.PrimaryKeyValue = newEntity.UserEntityRoleId;
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
                        mgr.Entity.PrimaryKeyValue = newEntity.UserEntityRoleId;
                        mgr.Execute();
                        break;

                    case OperationType.Delete:
                        mgr.Entity.PrimaryKeyValue = originalEntity.UserEntityRoleId;
                        mgr.Execute();
                        break;
                }
            }
            catch (Exception ex)
            {   // log the exception and swallow the exception. Do not re-throw
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserEntityRoleRepository::SaveAuditData", ex);
                //throw;
            }
        }

        protected override void FillMemberCollections(gcsUserEntityRole entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {

        }

        protected override bool CanEntityBeDeleted(int id)
        {
            return true;
        }

        protected override bool IsEntityUnique(gcsUserEntityRole entity)
        {
            gcs_IsUserEntityRoleUniquePDSAManager mgr = new gcs_IsUserEntityRoleUniquePDSAManager();
            mgr.Entity.UserEntityRoleId = entity.UserEntityRoleId;
            mgr.Entity.RoleId = entity.RoleId;
            mgr.Entity.UserEntityId = entity.UserEntityId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        protected override bool DoesEntityExist(Guid id)
        {
            int count = GalaxySMSDatabaseManager.DoesRowExist("gcsUserEntityRole", "UserEntityRoleId", id);
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
