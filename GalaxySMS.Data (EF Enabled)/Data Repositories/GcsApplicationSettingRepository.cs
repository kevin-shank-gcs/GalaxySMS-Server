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
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsApplicationSettingRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsApplicationSettingRepository : DataRepositoryBase<gcsApplicationSetting>, IGcsApplicationSettingRepository
    {
        protected override gcsApplicationSetting AddEntity(GalaxySMSContext dbContext, gcsApplicationSetting entity)
        {
            try
            {
                gcsApplicationSettingPDSAManager mgr = new gcsApplicationSettingPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Insert();
                var result = GetEntityByGuidId(dbContext, entity.ApplicationSettingId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationSettingRepository::AddEntity", ex);
                throw;
            }

            //// Use Entity Framework 
            //return dbContext.GcsApplicationSettingSet.Add(entity);
        }

        protected override gcsApplicationSetting UpdateEntity(GalaxySMSContext dbContext, gcsApplicationSetting entity)
        {
            try
            {
                gcsApplicationSettingPDSAManager mgr = new gcsApplicationSettingPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Update();
                var result = GetEntityByGuidId(dbContext, entity.ApplicationSettingId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationSettingRepository::UpdateEntity", ex);
                throw;
            }

            // Entity Framework 
            //return (from e in dbContext.GcsApplicationSettingSet
            //        where e.ApplicationSettingId == entity.ApplicationSettingId
            //        select e).FirstOrDefault();
        }

        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsApplicationSetting entity)
        {
            try
            {
                gcsApplicationSettingPDSAManager mgr = new gcsApplicationSettingPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.DeleteByPK(entity.ApplicationSettingId);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationSettingRepository::DeleteEntity", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }

        public override void Remove(Guid id)
        {
            try
            {
                gcsApplicationSettingPDSAManager mgr = new gcsApplicationSettingPDSAManager();
                mgr.DataObject.DeleteByPK(id);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationSettingRepository::Remove", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }
        
        protected override IEnumerable<gcsApplicationSetting> GetEntities(GalaxySMSContext dbContext)
        {
            // Using Entity Framework
            //return from e in dbContext.GcsApplicationSettingSet
            //       select e;
            try
            {
                gcsApplicationSettingPDSAManager mgr = new gcsApplicationSettingPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationSettingRepository::GetEntities", ex);
                throw;
            }
        }

        protected override gcsApplicationSetting GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            //var query = (from e in dbContext.GcsApplicationSettingSet
            //             where e. == id
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            return null;
        }

        protected override gcsApplicationSetting GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            // Using Entity Framework
            //var query = (from e in dbContext.GcsApplicationSettingSet
            //             where e.ApplicationSettingId == guid
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            try
            {
                gcsApplicationSettingPDSAManager mgr = new gcsApplicationSettingPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsApplicationSetting result = new gcsApplicationSetting();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationSettingRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        public void DeleteByUniqueKey(Guid applicationId, string category, string settingKey)
        {
            // Using Entity Framework
            //gcsApplicationSetting applicationSetting = GetByUniqueKey(applicationId, category, settingKey);
            //if( applicationSetting != null)
            //    Remove(applicationSetting.ApplicationSettingId);
            try
            {
                gcsApplicationSettingPDSAManager mgr = new gcsApplicationSettingPDSAManager();
                mgr.DataObject.DeleteFilter = gcsApplicationSettingPDSAData.DeleteFilters.DeleteByApplicationIdCategorySettingKey;
                mgr.DataObject.Entity.ApplicationId = applicationId;
                mgr.DataObject.Entity.Category = category;
                mgr.DataObject.Entity.SettingKey = settingKey;
                var count = mgr.DataObject.Delete();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationSettingRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        public gcsApplicationSetting GetByUniqueKey(Guid applicationId, string category, string settingKey)
        {
            // Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    return (from a in dbContext.GcsApplicationSettingSet
            //            where (a.ApplicationId == applicationId && a.Category == category && a.SettingKey == settingKey)
            //            select a).FirstOrDefault();
            //}
            try
            {
                gcsApplicationSettingPDSAManager mgr = new gcsApplicationSettingPDSAManager();
                mgr.DataObject.SelectFilter =
                    gcsApplicationSettingPDSAData.SelectFilters.ByApplicationIdCategorySettingKey;
                mgr.DataObject.Entity.ApplicationId = applicationId;
                mgr.DataObject.Entity.Category = category;
                mgr.DataObject.Entity.SettingKey = settingKey;
                var results = mgr.BuildCollection();
                if (results != null && results.Count == 1)
                {
                    var entities = mgr.ConvertPDSACollection(results);
                    foreach( var setting in entities)
                        return setting;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationSettingRepository::GetByUniqueKey", ex);
                throw;
            }
        }

        IEnumerable<gcsApplicationSetting> IGcsApplicationSettingRepository.GetAllForApplication(Guid applicationId)
        {
            // Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    return from a in dbContext.GcsApplicationSettingSet
            //           where a.ApplicationId == applicationId
            //           select a;
            //}
            try
            {
                gcsApplicationSettingPDSAManager mgr = new gcsApplicationSettingPDSAManager();
                mgr.DataObject.SelectFilter =
                    gcsApplicationSettingPDSAData.SelectFilters.ByApplicationId;
                mgr.DataObject.Entity.ApplicationId = applicationId;
                var results = mgr.BuildCollection();
                if (results != null && results.Count == 1)
                {
                    return mgr.ConvertPDSACollection(results);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationSettingRepository::GetAllForApplication", ex);
                throw;
            }
        }

        public IEnumerable<gcsApplicationSetting> GetAllForApplicationCategory(Guid applicationId, string category)
        {
            // Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    return from a in dbContext.GcsApplicationSettingSet
            //           where ( a.ApplicationId == applicationId && a.Category == category)
            //           select a;
            //}
            try
            {
                gcsApplicationSettingPDSAManager mgr = new gcsApplicationSettingPDSAManager();
                mgr.DataObject.SelectFilter =
                    gcsApplicationSettingPDSAData.SelectFilters.ByApplicationIdCategory;
                mgr.DataObject.Entity.ApplicationId = applicationId;
                mgr.DataObject.Entity.Category = category;
                var results = mgr.BuildCollection();
                if (results != null && results.Count == 1)
                {
                    return mgr.ConvertPDSACollection(results);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationSettingRepository::GetAllForApplication", ex);
                throw;
            }
        }

        public bool IsApplicationSettingReferenced(Guid applicationSettingId)
        {
            return false;
        }

        public bool IsApplicationSettingUnique(gcsApplicationSetting applicationSetting)
        {
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    var applicationSettingIdParam = new SqlParameter
            //    {
            //        ParameterName = "ApplicationSettingId",
            //        Value = applicationSetting.ApplicationSettingId
            //    };
            //    var applicationIdParam = new SqlParameter
            //    {
            //        ParameterName = "ApplicationId",
            //        Value = applicationSetting.ApplicationId
            //    };
            //    var categoryParam = new SqlParameter
            //    {
            //        ParameterName = "Category",
            //        Value = applicationSetting.Category
            //    };
            //    var settingKeyParam = new SqlParameter
            //    {
            //        ParameterName = "SettingKey",
            //        Value = applicationSetting.SettingKey
            //    };
            //    var resultParam = new SqlParameter
            //    {
            //        ParameterName = "Result",
            //        Value = 0,
            //        Direction = System.Data.ParameterDirection.Output
            //    };

            //    int ret = dbContext.Database.ExecuteSqlCommand("exec [GCS].[gcs_IsApplicationSettingUnique] @ApplicationSettingId, @ApplicationId, @Category, @SettingKey, @Result OUTPUT",
            //        applicationSettingIdParam, applicationIdParam, categoryParam, settingKeyParam, resultParam);

            //    if (Convert.ToInt32(resultParam.Value) == 0)
            //        return true;
            //    return false;
            //}
            gcs_IsApplicationSettingUniquePDSAManager mgr = new gcs_IsApplicationSettingUniquePDSAManager();
            mgr.Entity.ApplicationSettingId = applicationSetting.ApplicationSettingId;
            mgr.Entity.ApplicationId = applicationSetting.ApplicationId;
            mgr.Entity.Category = applicationSetting.Category;
            mgr.Entity.SettingKey = applicationSetting.SettingKey;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }
    }
}
