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
    [Export(typeof(IGcsApplicationRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsApplicationRepository : DataRepositoryBase<gcsApplication>, IGcsApplicationRepository
    {
        protected override gcsApplication AddEntity(GalaxySMSContext dbContext, gcsApplication entity)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Insert();
                var result = GetEntityByGuidId(dbContext, entity.ApplicationId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::AddEntity", ex);
                throw;
            }

            //// Use Entity Framework 
            //return dbContext.GcsApplicationSet.Add(entity);
        }

        protected override gcsApplication UpdateEntity(GalaxySMSContext dbContext, gcsApplication entity)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Update();
                var result = GetEntityByGuidId(dbContext, entity.ApplicationId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::UpdateEntity", ex);
                throw;
            }

            // Entity Framework 
            //return (from e in dbContext.GcsApplicationSet
            //        where e.ApplicationId == entity.ApplicationId
            //        select e).FirstOrDefault();
        }

        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsApplication entity)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.DeleteByPK(entity.ApplicationId);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::DeleteEntity", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }

        public override void Remove(Guid id)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                mgr.DataObject.DeleteByPK(id);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::Remove", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }
        
        protected override IEnumerable<gcsApplication> GetEntities(GalaxySMSContext dbContext)
        {
            //// Using Entity Framework
            //return from e in dbContext.GcsApplicationSet
            //       select e;

            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::GetEntities", ex);
                throw;
            }
        }

        protected override gcsApplication GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            //var query = (from e in dbContext.GcsApplicationSet
            //             where e. == id
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            return null;
        }

        protected override gcsApplication GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            //// Using Entity Framework
            //var query = (from e in dbContext.GcsApplicationSet
            //             where e.ApplicationId == guid
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsApplication result = new gcsApplication();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::GetEntityByGuidId", ex);
                throw;
            }
        }

        public IEnumerable<gcsApplication> GetAllApplicationsForEntity(Guid entityId)
        {
            try
            {
                gcsApplicationPDSAManager mgr = new gcsApplicationPDSAManager();
                mgr.DataObject.WhereFilter = gcsApplicationPDSAData.WhereFilters.EntityId;
                mgr.DataObject.EntityId = entityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsApplicationRepository::GetAllForEntity", ex);
                throw;
            }
            //// Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    return (from a in dbContext.GcsApplicationSet
            //            where a.EntityGuid == entityId
            //            select a);
            //}
        }

        public bool IsApplicationReferenced(Guid applicationId)
        {
            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsApplication", "ApplicationId", applicationId);
            if (count == 0)
                return false;
            return true;
        }

        public bool CanRowBeDeleted(Guid applicationId)
        {
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsApplication", "ApplicationId", applicationId);
            if (count == 0)
                return true;
            return false;
        }
        
        public bool IsApplicationUnique(gcsApplication application)
        {
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    var appIdParam = new SqlParameter
            //    {
            //        ParameterName = "ApplicationId",
            //        Value = application.ApplicationId
            //    };
            //    var appNameParam = new SqlParameter
            //    {
            //        ParameterName = "ApplicationName",
            //        Value = application.ApplicationName
            //    };
            //    var resultParam = new SqlParameter
            //    {
            //        ParameterName = "Result",
            //        Value = 0,
            //        Direction = System.Data.ParameterDirection.Output
            //    };
            //    var ret =
            //        dbContext.Database.ExecuteSqlCommand(
            //            "exec [GCS].[gcs_IsApplicationUnique] @ApplicationId, @ApplicationName, @Result OUTPUT",
            //            appIdParam, appNameParam, resultParam);

            //    if (Convert.ToInt32(resultParam.Value) == 0)
            //        return true;
            //    return false;
            //}
            gcs_IsApplicationUniquePDSAManager mgr = new gcs_IsApplicationUniquePDSAManager();
            mgr.Entity.ApplicationId = application.ApplicationId;
            mgr.Entity.ApplicationName = application.ApplicationName;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }
    }
}
