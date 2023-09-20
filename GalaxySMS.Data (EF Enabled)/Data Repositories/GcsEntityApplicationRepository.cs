using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GalaxySMS.DataLayer;
using GalaxySMS.EntityLayer;
using GCS.Core.Common.Config;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsEntityApplicationRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsEntityApplicationRepository : DataRepositoryBase<gcsEntityApplication>, IGcsEntityApplicationRepository
    {
        protected override gcsEntityApplication AddEntity(GalaxySMSContext dbContext, gcsEntityApplication entityApplication)
        {
            try
            {
                gcsEntityApplicationPDSAManager mgr = new gcsEntityApplicationPDSAManager();
                mgr.InitEntityObject(entityApplication);
                mgr.DataObject.Insert();
                var result = GetEntityByGuidId(dbContext, entityApplication.EntityApplicationId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityApplicationRepository::AddEntity", ex);
                throw;
            }

            //// Use Entity Framework 
            //return dbContext.GcsEntityApplicationSet.Add(entityApplication);
        }

        protected override gcsEntityApplication UpdateEntity(GalaxySMSContext dbContext, gcsEntityApplication entityApplication)
        {
            try
            {
                gcsEntityApplicationPDSAManager mgr = new gcsEntityApplicationPDSAManager();
                mgr.InitEntityObject(entityApplication);
                mgr.DataObject.Update();
                var result = GetEntityByGuidId(dbContext, entityApplication.EntityApplicationId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityApplicationRepository::UpdateEntity", ex);
                throw;
            }

            // Entity Framework 
            //return (from e in dbContext.GcsEntityApplicationSet
            //        where e.EntityApplicationId == entityApplication.EntityApplicationId
            //        select e).FirstOrDefault();
        }
        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsEntityApplication entity)
        {
            try
            {
                gcsEntityApplicationPDSAManager mgr = new gcsEntityApplicationPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.DeleteByPK(entity.EntityApplicationId);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityApplicationRepository::DeleteEntity", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }


        public override void Remove(Guid id)
        {
            try
            {
                gcsEntityApplicationPDSAManager mgr = new gcsEntityApplicationPDSAManager();
                mgr.DataObject.DeleteByPK(id);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityApplicationRepository::Remove", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }
        
        protected override IEnumerable<gcsEntityApplication> GetEntities(GalaxySMSContext dbContext)
        {
            // Using Entity Framework
            //return from e in dbContext.GcsEntityApplicationSet
            //       select e;
            try
            {
                gcsEntityApplicationPDSAManager mgr = new gcsEntityApplicationPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityApplicationRepository::GetEntities", ex);
                throw;
            }
        }

        protected override gcsEntityApplication GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            return null;
        }

        protected override gcsEntityApplication GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            // Using Entity Framework
            //var query = (from e in dbContext.GcsEntityApplicationSet
            //             where e.EntityApplicationId == guid
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            try
            {
                gcsEntityApplicationPDSAManager mgr = new gcsEntityApplicationPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsEntityApplication result = new gcsEntityApplication();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityApplicationRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        public bool IsEntityApplicationReferenced(Guid entityId)
        {
            return false;
        }


        public bool IsEntityApplicationUnique(gcsEntityApplication entityApplication)
        {
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    var entityApplicationIdParam = new SqlParameter
            //    {
            //        ParameterName = "EntityApplicationId",
            //        Value = entityApplication.EntityApplicationId
            //    };
            //    var entityIdParam = new SqlParameter
            //    {
            //        ParameterName = "EntityId",
            //        Value = entityApplication.EntityId
            //    };
            //    var applicationIdParam = new SqlParameter
            //    {
            //        ParameterName = "ApplicationId",
            //        Value = entityApplication.ApplicationId
            //    };
            //    var resultParam = new SqlParameter
            //    {
            //        ParameterName = "Result",
            //        Value = 0,
            //        Direction = System.Data.ParameterDirection.Output
            //    };
            //    var ret =
            //        dbContext.Database.ExecuteSqlCommand(
            //            "exec [GCS].[gcs_IsEntityApplicationUnique] @EntityId, @ApplicationId, @Result OUTPUT",
            //            entityIdParam, applicationIdParam, resultParam);

            //    if (Convert.ToInt32(resultParam.Value) == 0)
            //        return true;
            //    return false;
            //}
            gcs_IsEntityApplicationUniquePDSAManager mgr = new gcs_IsEntityApplicationUniquePDSAManager();
            mgr.Entity.EntityApplicationId = entityApplication.EntityApplicationId;
            mgr.Entity.EntityId = entityApplication.EntityId;
            mgr.Entity.ApplicationId = entityApplication.ApplicationId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;
        }

        public IEnumerable<gcsEntityApplication> GetAllForEntity(Guid entityId)
        {
            try
            {
                gcsEntityApplicationPDSAManager mgr = new gcsEntityApplicationPDSAManager();
                mgr.DataObject.SelectFilter = gcsEntityApplicationPDSAData.SelectFilters.AllForEntity;
                mgr.DataObject.Entity.EntityId = entityId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityApplicationRepository::GetAllForEntity", ex);
                throw;
            }
            //// Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    return (from e in dbContext.GcsEntityApplicationSet
            //            where e.EntityId == entityId
            //            select e).ToList();
            //}
        }

        public IEnumerable<gcsEntityApplication> GetAllForApplication(Guid applicationId)
        {
            try
            {
                gcsEntityApplicationPDSAManager mgr = new gcsEntityApplicationPDSAManager();

                mgr.DataObject.SelectFilter = gcsEntityApplicationPDSAData.SelectFilters.AllForApplication;
                mgr.DataObject.Entity.ApplicationId = applicationId;
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityApplicationRepository::GetAllForApplication", ex);
                throw;
            }
            //// Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    return (from e in dbContext.GcsEntityApplicationSet
            //            where e.ApplicationId == applicationId
            //            select e).ToList();
            //}
        }

    }
}
