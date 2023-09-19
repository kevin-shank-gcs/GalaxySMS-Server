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
    [Export(typeof(IGcsUserOldPasswordRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserOldPasswordRepository : DataRepositoryBase<gcsUserOldPassword>, IGcsUserOldPasswordRepository
    {
        protected override gcsUserOldPassword AddEntity(GalaxySMSContext dbContext, gcsUserOldPassword entity)
        {
            return dbContext.GcsUserOldPasswordSet.Add(entity);
        }

        protected override gcsUserOldPassword UpdateEntity(GalaxySMSContext dbContext, gcsUserOldPassword entity)
        {
            return (from e in dbContext.GcsUserOldPasswordSet
                    where e.UserOldPasswordId == entity.UserOldPasswordId
                    select e).FirstOrDefault();
        }
        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsUserOldPassword entity)
        {
            //try
            //{
            //    gcsRolePDSAManager mgr = new gcsRolePDSAManager();
            //    mgr.InitEntityObject(entity);
            //mgr.DataObject.DeleteByPK(id);
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserOldPasswordRepository::DeleteEntity", ex);
            //    throw;
            //}

            //// Entity Framework 
            ////            base.Remove(id);
        }
        protected override IEnumerable<gcsUserOldPassword> GetEntities(GalaxySMSContext dbContext)
        {
            return from e in dbContext.GcsUserOldPasswordSet
                   select e;
        }

        protected override gcsUserOldPassword GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            //var query = (from e in dbContext.GcsUserRequirementsSet
            //             where e. == id
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            return null;
        }

        protected override gcsUserOldPassword GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            var query = (from e in dbContext.GcsUserOldPasswordSet
                         where e.UserOldPasswordId == guid
                         select e);

            var results = query.FirstOrDefault();
            return results;
        }




        #region IGcsUserOldPasswordRepository Members

        public IEnumerable<gcsUserOldPassword> GetByUserId(Guid userId, int howMany)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                if (howMany > 0)
                {
                    return (from e in dbContext.GcsUserOldPasswordSet
                        where e.UserId == userId
                        orderby e.InsertDate descending
                        select e).Take(howMany).ToList();
                }
                else
                {   
                    return (from e in dbContext.GcsUserOldPasswordSet
                        where e.UserId == userId
                        orderby e.InsertDate descending
                        select e).ToList();
                }
            }
        }

        #endregion
    }
}
