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
    [Export(typeof(IGcsLanguageRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsLanguageRepository : DataRepositoryBase<gcsLanguage>, IGcsLanguageRepository
    {
        protected override gcsLanguage AddEntity(GalaxySMSContext dbContext, gcsLanguage entity)
        {
            try
            {
                gcsLanguagePDSAManager mgr = new gcsLanguagePDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Insert();
                var result = GetEntityByGuidId(dbContext, entity.LanguageId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::AddEntity", ex);
                throw;
            }

            //// Use Entity Framework 
            //  return dbContext.GcsLanguageSet.Add(entity);
        }

        protected override gcsLanguage UpdateEntity(GalaxySMSContext dbContext, gcsLanguage entity)
        {
            try
            {
                gcsLanguagePDSAManager mgr = new gcsLanguagePDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Update();
                var result = GetEntityByGuidId(dbContext, entity.LanguageId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::UpdateEntity", ex);
                throw;
            }

            // Entity Framework 
            //return (from e in dbContext.GcsLanguageSet
            //        where e.LanguageId == entity.LanguageId
            //        select e).FirstOrDefault();
        }
        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsLanguage entity)
        {
            try
            {
                gcsLanguagePDSAManager mgr = new gcsLanguagePDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.DeleteByPK(entity.LanguageId);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::DeleteEntity", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }

        public override void Remove(Guid id)
        {
            try
            {
                gcsLanguagePDSAManager mgr = new gcsLanguagePDSAManager();
                mgr.DataObject.DeleteByPK(id);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::Remove", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }
        
        protected override IEnumerable<gcsLanguage> GetEntities(GalaxySMSContext dbContext)
        {
            //// Using Entity Framework
            //return from e in dbContext.GcsLanguageSet
            //       select e;
            try
            {
                gcsLanguagePDSAManager mgr = new gcsLanguagePDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::GetEntities", ex);
                throw;
            }
        }

        protected override gcsLanguage GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            //var query = (from e in dbContext.gcsLanguageSet
            //             where e. == id
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            return null;
        }

        protected override gcsLanguage GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            //// Using Entity Framework
            //var query = (from e in dbContext.GcsLanguageSet
            //             where e.LanguageId == guid
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            try
            {
                gcsLanguagePDSAManager mgr = new gcsLanguagePDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsLanguage result = new gcsLanguage();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        IEnumerable<gcsLanguage> IGcsLanguageRepository.GetAllLanguagesForBase(string baseLanguageCode)
        {
            try
            {
                gcsLanguagePDSAManager mgr = new gcsLanguagePDSAManager();
                mgr.DataObject.SelectFilter = gcsLanguagePDSAData.SelectFilters.Search;
                mgr.DataObject.Entity.CultureName = baseLanguageCode;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsLanguageRepository::GetAllLanguagesForBase", ex);
                throw;
            }
            //// Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    return (from e in dbContext.GcsLanguageSet
            //                 where e.CultureName.StartsWith(baseLanguageCode)
            //                 select e);
               
            //}
        }

        bool IGcsLanguageRepository.IsLanguageReferenced(Guid languageId)
        {
            //// Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    int roleEntityCount = dbContext.GetRowCountFromTableByColumnValue("gcsApplication", "LanguageId",
            //        languageGuid);

            //    int count = dbContext.GetGuidForeignKeyReferenceCount("gcsLanguage", "LanguageId", languageGuid);
            //    if (count == 0)
            //        return false;
            //    return true;
            //}
            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsLanguage", "LanguageId", languageId);
            if (count == 0)
                return false;
            return true;
        }
        public bool CanRowBeDeleted(Guid languageId)
        {
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsLanguage", "LanguageId", languageId);
            if (count == 0)
                return true;
            return false;

            //// Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    int count = dbContext.CanRowBeDeleted("gcsLanguage", "LanguageId", languageId);
            //    if (count == 0)
            //        return true;
            //    return false;
            //}
        }
        bool IGcsLanguageRepository.IsLanguageUnique(gcsLanguage language)
        {
            //// Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    var languageIdParam = new SqlParameter
            //    {
            //        ParameterName = "LanguageId",
            //        Value = language.LanguageId
            //    };
            //    var languageNameParam = new SqlParameter
            //    {
            //        ParameterName = "LanguageName",
            //        Value = language.LanguageName
            //    };
            //    var cultureNameParam = new SqlParameter
            //    {
            //        ParameterName = "CultureName",
            //        Value = language.CultureName
            //    };
            //    var resultParam = new SqlParameter
            //    {
            //        ParameterName = "Result",
            //        Value = 0,
            //        Direction = System.Data.ParameterDirection.Output
            //    };
   
            //    var ret =
            //        dbContext.Database.ExecuteSqlCommand(
            //            "exec [GCS].[gcs_IsLanguageUnique] @LanguageId, @LanguageName, @CultureName, @Result OUTPUT",
            //            languageIdParam, languageNameParam, cultureNameParam, resultParam);

            //    if (Convert.ToInt32(resultParam.Value) == 0)
            //        return true;
            //    return false;
            //}
            
            gcs_IsLanguageUniquePDSAManager mgr = new gcs_IsLanguageUniquePDSAManager();
            mgr.Entity.LanguageId = language.LanguageId;
            mgr.Entity.LanguageName = language.LanguageName;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

    }
}
