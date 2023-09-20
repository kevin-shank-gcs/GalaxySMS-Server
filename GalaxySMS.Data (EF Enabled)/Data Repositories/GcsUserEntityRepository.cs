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
    [Export(typeof(IGcsUserEntityRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserEntityRepository : DataRepositoryBase<gcsUserEntity>, IGcsUserEntityRepository
    {
        protected override gcsUserEntity AddEntity(GalaxySMSContext dbContext, gcsUserEntity entity)
        {
            return dbContext.GcsUserEntitySet.Add(entity);
        }

        protected override gcsUserEntity UpdateEntity(GalaxySMSContext dbContext, gcsUserEntity entity)
        {
            return (from e in dbContext.GcsUserEntitySet
                    where e.UserEntityId == entity.UserEntityId
                    select e).FirstOrDefault();
        }
        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsUserEntity entity)
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
        protected override IEnumerable<gcsUserEntity> GetEntities(GalaxySMSContext dbContext)
        {
            return (from e in dbContext.GcsUserEntitySet
                    select e).ToList();
        }

        protected override gcsUserEntity GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            //var query = (from e in dbContext.GcsUserEntitySet
            //             where e. == id
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            return null;
        }

        protected override gcsUserEntity GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            var query = (from e in dbContext.GcsUserEntitySet
                         where e.UserEntityId == guid
                         select e);

            var results = query.FirstOrDefault();
            return results;
        }


        #region IGcsUserEntityRepository Members

        public bool IsUserEntityUnique(gcsUserEntity userEntity)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                var userEntityIdParam = new SqlParameter
                {
                    ParameterName = "UserEntityId",
                    Value = userEntity.UserEntityId
                };

                var userIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = userEntity.UserId
                };

                var entityIdParam = new SqlParameter
                {
                    ParameterName = "EntityId",
                    Value = userEntity.EntityId
                };

                var resultParam = new SqlParameter
                {
                    ParameterName = "Result",
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };

                int ret = dbContext.Database.ExecuteSqlCommand("exec [GCS].[gcs_IsUserEntityUnique] @UserEntityId, @UserId, @EntityId, @Result OUTPUT",
                    userEntityIdParam, userIdParam, entityIdParam, resultParam);

                if (Convert.ToInt32(resultParam.Value) == 0)
                    return true;
                return false;
            }
        }

        public IEnumerable<gcsUserEntity> GetByUserId(Guid userId)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                return (from e in dbContext.GcsUserEntitySet
                        where e.UserId == userId
                        select e).ToList();
            }
        }
        #endregion


    }
}
