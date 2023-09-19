using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Config;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsUserRoleRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserRoleRepository : DataRepositoryBase<gcsUserRole>, IGcsUserRoleRepository
    {
        protected override gcsUserRole AddEntity(GalaxySMSContext dbContext, gcsUserRole entity)
        {
            return dbContext.GcsUserRoleSet.Add(entity);
        }

        protected override gcsUserRole UpdateEntity(GalaxySMSContext dbContext, gcsUserRole entity)
        {
            return (from e in dbContext.GcsUserRoleSet
                    where e.UserRoleId == entity.UserRoleId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<gcsUserRole> GetEntities(GalaxySMSContext dbContext)
        {
            return from e in dbContext.GcsUserRoleSet
                   select e;
        }

        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsUserRole entity)
        {
            //try
            //{
            //    gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
            //    mgr.InitEntityObject(entity);
            //    mgr.DataObject.DeleteByPK(id);
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRoleRepository::DeleteEntity", ex);
            //    throw;
            //}

            // Entity Framework 
            //            base.Remove(id);
        }
        protected override gcsUserRole GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            //var query = (from e in dbContext.GcsUserRoleSet
            //             where e. == id
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            return null;
        }

        protected override gcsUserRole GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            var query = (from e in dbContext.GcsUserRoleSet
                         where e.UserRoleId == guid
                         select e);

            var results = query.FirstOrDefault();
            return results;
        }


        #region IGcsUserRoleRepository Members

        public bool IsUserRoleUnique(gcsUserRole userRole)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                var userRoleIdParam = new SqlParameter
                {
                    ParameterName = "UserRoleId",
                    Value = userRole.UserRoleId
                };

                var userApplicationEntityIdParam = new SqlParameter
                {
                    ParameterName = "UserApplicationEntityId",
                    Value = userRole.UserApplicationEntityId
                };

                var roleIdParam = new SqlParameter
                {
                    ParameterName = "RoleId",
                    Value = userRole.RoleId
                };

                var resultParam = new SqlParameter
                {
                    ParameterName = "Result",
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };

                int ret = dbContext.Database.ExecuteSqlCommand("exec [GCS].[gcs_IsUserRoleUnique] @UserRoleId, @UserApplicationEntityId, @RoleId, @Result OUTPUT",
                    userRoleIdParam, userApplicationEntityIdParam, roleIdParam, resultParam);

                if (Convert.ToInt32(resultParam.Value) == 0)
                    return true;
                return false;
            }
        }

         #endregion
    }
}
