using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Data.Contracts;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsUserSettingRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserSettingRepository : DataRepositoryBase<gcsUserSetting>, IGcsUserSettingRepository
    {
        protected override gcsUserSetting AddEntity(GalaxySMSContext dbContext, gcsUserSetting entity)
        {
            return dbContext.GcsUserSettingSet.Add(entity);
        }

        protected override gcsUserSetting UpdateEntity(GalaxySMSContext dbContext, gcsUserSetting entity)
        {
            return (from e in dbContext.GcsUserSettingSet
                    where e.UserSettingId == entity.UserSettingId
                    select e).FirstOrDefault();
        }

        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsUserSetting entity)
        {
            //try
            //{
            //    gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
            //    mgr.InitEntityObject(entity);
            //    mgr.DataObject.DeleteByPK(id);
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::DeleteEntity", ex);
            //    throw;
            //}

            // Entity Framework 
            //            base.Remove(id);
        }
        protected override IEnumerable<gcsUserSetting> GetEntities(GalaxySMSContext dbContext)
        {
            return from e in dbContext.GcsUserSettingSet
                   select e;
        }

        protected override gcsUserSetting GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            //var query = (from e in dbContext.GcsUserSettingSet
            //             where e. == id
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            return null;
        }
        public void DeleteByUniqueKey(Guid userId,Guid applicationId, string category, string settingKey)
        {
            gcsUserSetting userSetting = GetByUniqueKey(userId, applicationId, category, settingKey);
            if (userSetting != null)
                Remove(userSetting.UserSettingId);
        }

        protected override gcsUserSetting GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            var query = (from e in dbContext.GcsUserSettingSet
                         where e.UserSettingId == guid
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public bool IsUserSettingUnique(gcsUserSetting userSetting)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                var userSettingIdParam = new SqlParameter
                {
                    ParameterName = "UserSettingId",
                    Value = userSetting.UserSettingId
                };
                var userIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = userSetting.UserId
                };
                var applicationIdParam = new SqlParameter
                {
                    ParameterName = "ApplicationId",
                    Value = userSetting.ApplicationId
                };
                var categoryParam = new SqlParameter
                {
                    ParameterName = "Category",
                    Value = userSetting.Category
                };
                var settingKeyParam = new SqlParameter
                {
                    ParameterName = "SettingKey",
                    Value = userSetting.SettingKey
                };
                var resultParam = new SqlParameter
                {
                    ParameterName = "Result",
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };

                int ret = dbContext.Database.ExecuteSqlCommand("exec [GCS].[gcs_IsUserSettingUnique] @UserSettingId, @UserId, @ApplicationId, @Category, @SettingKey, @Result OUTPUT",
                    userSettingIdParam, userIdParam, applicationIdParam, categoryParam, settingKeyParam, resultParam);

                if (Convert.ToInt32(resultParam.Value) == 0)
                    return true;
                return false;
            }
        }

        public bool IsUserSettingReferenced(Guid userId)
        {
            return false;
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    int roleEntityCount = dbContext.GetRowCountFromTableByColumnValue("gcsApplication", "LanguageId",
            //        languageGuid);

            //    int count = dbContext.GetGuidForeignKeyReferenceCount("gcsLanguage", "LanguageId", languageGuid);
            //    if (count == 0)
            //        return false;
            //    return true;
            //}
        }

        #region IGcsUserSettingRepository Members

        public gcsUserSetting GetByUniqueKey(Guid userId, Guid applicationId, string category, string settingKey)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                return (from a in dbContext.GcsUserSettingSet
                        where (a.UserId == userId && a.ApplicationId == applicationId && a.Category == category && a.SettingKey == settingKey)
                        select a).FirstOrDefault();
            }
        }

        public IEnumerable<gcsUserSetting> GetAllForUser(Guid userId)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                return from a in dbContext.GcsUserSettingSet
                        where a.UserId == userId 
                        select a;
            }
        }

        public IEnumerable<gcsUserSetting> GetAllForUserApplication(Guid userId, Guid applicationId)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                return from a in dbContext.GcsUserSettingSet
                        where (a.UserId == userId && a.ApplicationId == applicationId )
                        select a;
            }
        }

        public IEnumerable<gcsUserSetting> GetAllForUserApplicationCategory(Guid userId, Guid applicationId, string category)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                return from a in dbContext.GcsUserSettingSet
                       where (a.UserId == userId && a.ApplicationId == applicationId && a.Category == category)
                       select a;
            }
        }

        public IEnumerable<gcsUserSetting> GetAllForApplication(Guid applicationId)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                return from a in dbContext.GcsUserSettingSet
                       where a.ApplicationId == applicationId
                       select a;
            }
        }

        #endregion
    }
}
