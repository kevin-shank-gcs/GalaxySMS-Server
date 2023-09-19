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
    [Export(typeof(IGcsUserApplicationEntityRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserApplicationEntityRepository : DataRepositoryBase<gcsUserApplicationEntity>, IGcsUserApplicationEntityRepository
    {
        protected override gcsUserApplicationEntity AddEntity(GalaxySMSContext dbContext, gcsUserApplicationEntity entity)
        {
            return dbContext.GcsUserApplicationEntitySet.Add(entity);
        }

        protected override gcsUserApplicationEntity UpdateEntity(GalaxySMSContext dbContext, gcsUserApplicationEntity entity)
        {
            return (from e in dbContext.GcsUserApplicationEntitySet
                    where e.UserApplicationEntityId == entity.UserApplicationEntityId
                    select e).FirstOrDefault();
        }

        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsUserApplicationEntity entity)
        {
            //try
            //{
            //    gcsRolePDSAManager mgr = new gcsRolePDSAManager();
            //    mgr.InitEntityObject(entity);
            //mgr.DataObject.DeleteByPK(id);
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsRoleRepository::DeleteEntity", ex);
            //    throw;
            //}

            //// Entity Framework 
            ////            base.Remove(id);
        }

        protected override IEnumerable<gcsUserApplicationEntity> GetEntities(GalaxySMSContext dbContext)
        {
            return from e in dbContext.GcsUserApplicationEntitySet
                   select e;
        }

        protected override gcsUserApplicationEntity GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            //var query = (from e in dbContext.GcsUserApplicationEntitySet
            //             where e. == id
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            return null;
        }

        protected override gcsUserApplicationEntity GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            var query = (from e in dbContext.GcsUserApplicationEntitySet
                         where e.UserApplicationEntityId == guid
                         select e);

            var results = query.FirstOrDefault();
            return results;
        }


        #region IGcsUserApplicationEntityRepository Members

        public bool IsUserApplicationEntityReferenced(Guid userApplicationEntityId)
        {
            return false;
        }

        public bool IsUserApplicationEntityUnique(gcsUserApplicationEntity userApplicationEntity)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                var userApplicationEntityIdParam = new SqlParameter
                {
                    ParameterName = "UserApplicationEntityId",
                    Value = userApplicationEntity.UserApplicationEntityId
                };

                var applicationIdParam = new SqlParameter()
                {
                    ParameterName = "ApplicationId",
                    Value = userApplicationEntity.ApplicationId
                };

                var entityIdParam = new SqlParameter
                {
                    ParameterName = "EntityId",
                    Value = userApplicationEntity.EntityGuid
                };

                var userIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = userApplicationEntity.UserId
                };

                var resultParam = new SqlParameter
                {
                    ParameterName = "Result",
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };

                int ret = dbContext.Database.ExecuteSqlCommand("exec [GCS].[gcs_IsUserApplicationEntityUnique] @UserRequirementsId, @ApplicationId, @EntityId, @UserId, @Result OUTPUT",
                    userApplicationEntityIdParam, applicationIdParam, entityIdParam, userIdParam, resultParam);

                if (Convert.ToInt32(resultParam.Value) == 0)
                    return true;
                return false;
            }
        }

        #endregion
    }
}
