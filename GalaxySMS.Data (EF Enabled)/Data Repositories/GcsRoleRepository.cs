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
using System.Data.Entity;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsRoleRepository : DataRepositoryBase<gcsRole>, IGcsRoleRepository
    {
        protected override gcsRole AddEntity(GalaxySMSContext dbContext, gcsRole entity)
        {
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Insert();
                var result = GetEntityByGuidId(dbContext, entity.RoleId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::AddEntity", ex);
                throw;
            }

            //// Use Entity Framework 
//           return dbContext.GcsRoleSet.Add(entity);
        }

        protected override gcsRole UpdateEntity(GalaxySMSContext dbContext, gcsRole entity)
        {
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Update();
                var result = GetEntityByGuidId(dbContext, entity.RoleId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::UpdateEntity", ex);
                throw;
            }

            // Entity Framework 
            //return (from e in dbContext.GcsRoleSet
            //        where e.RoleId == entity.RoleId
            //        select e).FirstOrDefault();
        }
        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsRole entity)
        {
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.DeleteByPK(entity.RoleId);
                //mgr.DataObject.DeleteByPK(id);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::DeleteEntity", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }

        public override void Remove(Guid id)
        {
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();
                mgr.DataObject.DeleteByPK(id);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::Remove", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }
        protected override IEnumerable<gcsRole> GetEntities(GalaxySMSContext dbContext)
        {
            //// Using Entity Framework
            //return from e in dbContext.GcsRoleSet
            //       select e;
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetEntities", ex);
                throw;
            }
        }

        protected override gcsRole GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            //var query = (from e in dbContext.GcsRoleSet
            //             where e. == id
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            return null;
        }

        protected override gcsRole GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            //// Using Entity Framework
            //var query = (from e in dbContext.GcsRoleSet
            //             where e.RoleId == guid
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsRole result = new gcsRole();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        public IEnumerable<gcsRole> GetAllRolesForApplication(Guid applicationId)
        {
            try
            {
                gcsRolePDSAManager mgr = new gcsRolePDSAManager();
                mgr.DataObject.SelectFilter = gcsRolePDSAData.SelectFilters.ByApplicationId;
                mgr.DataObject.Entity.ApplicationId = applicationId;
                var pdsaEntities = mgr.BuildCollection();
                //mgr.Entity.EntityId = entityId;
                //var pdsaEntities = mgr.GetgcsEntityApplicationPDSAsByEntityId();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    return entities;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::GetAllRolesForApplication", ex);
                throw;
            }
            //// Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    return (from e in dbContext.GcsRoleSet
            //               where e.ApplicationId == applicationId
            //               select e).ToList();
            //}
        }

        public bool IsRoleReferenced(Guid roleId)
        {
            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsRole", "RoleId", roleId);
            if (count == 0)
                return false;
            return true;
        }

        public bool IsRoleUnique(gcsRole role)
        {
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    var roleIdParam = new SqlParameter
            //    {
            //        ParameterName = "RoleId",
            //        Value = role.RoleId
            //    };
            //    var roleNameParam = new SqlParameter
            //    {
            //        ParameterName = "RoleName",
            //        Value = role.RoleName
            //    };
            //    var applicationIdParam = new SqlParameter
            //    {
            //        ParameterName = "ApplicationId",
            //        Value = role.ApplicationId
            //    };

            //    var resultParam = new SqlParameter
            //    {
            //        ParameterName = "Result",
            //        Value = 0,
            //        Direction = System.Data.ParameterDirection.Output
            //    };

            //    var ret =
            //        dbContext.Database.ExecuteSqlCommand(
            //            "exec [GCS].[gcs_IsRoleUnique] @RoleId, @RoleName, @ApplicationId, @Result OUTPUT",
            //            roleIdParam, roleNameParam, applicationIdParam, resultParam);

            //    if (Convert.ToInt32(resultParam.Value) == 0)
            //        return true;
            //    return false;
            //}
            gcs_IsRoleUniquePDSAManager mgr = new gcs_IsRoleUniquePDSAManager();
            mgr.Entity.RoleId = role.RoleId;
            mgr.Entity.RoleName = role.RoleName;
            mgr.Entity.ApplicationId = role.ApplicationId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }
    }
}
