using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.BusinessClasses;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GCS.Core.Common.Config;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsEntityRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsEntityRepository : DataRepositoryBase<gcsEntity>, IGcsEntityRepository
    {
        protected override gcsEntity AddEntity(GalaxySMSContext dbContext, gcsEntity entity)
        {
            try
            {
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Insert();
                var result = GetEntityByGuidId(dbContext, entity.EntityId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::AddEntity", ex);
                throw;
            }

            //// Use Entity Framework 
            //            return dbContext.GcsEntitySet.Add(entity);
        }

        protected override gcsEntity UpdateEntity(GalaxySMSContext dbContext, gcsEntity entity)
        {
            try
            {
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Update();
                var result = GetEntityByGuidId(dbContext, entity.EntityId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::UpdateEntity", ex);
                throw;
            }

            // Entity Framework 
            //return (from e in dbContext.GcsEntitySet
            //        where e.EntityId == entity.EntityId
            //        select e).FirstOrDefault();
        }
        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsEntity entity)
        {
            try
            {
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.DeleteByPK(entity.EntityId);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::DeleteEntity", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }

        public override void Remove(Guid id)
        {
            try
            {
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                mgr.DataObject.DeleteByPK(id);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::Remove", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }

        protected override IEnumerable<gcsEntity> GetEntities(GalaxySMSContext dbContext)
        {
            try
            {
                // Using Entity Framework
                //var entities = from e in dbContext.GcsEntitySet
                //               select e;

                //foreach (gcsEntity entity in entities)
                //{
                //    FillEntityMemberCollections(entity);
                //}
                //return entities;


                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();

                var pdsaEntities = mgr.BuildCollection();
                if (pdsaEntities != null)
                {
                    var entities = mgr.ConvertPDSACollection(pdsaEntities);
                    GcsUserRequirementsRepository userRequirementsRepository = new GcsUserRequirementsRepository();

                    foreach (gcsEntity entity in entities)
                    {
                        FillEntityMemberCollections(entity);
                    }
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntities", ex);
                throw;
            }
        }

        protected override gcsEntity GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            return null;
        }

        protected override gcsEntity GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            // Using Entity Framework
            //var query = (from e in dbContext.GcsEntitySet
            //             where e.EntityId == guid
            //             select e);

            //var results = query.FirstOrDefault();
            //if (results != null)
            //    FillEntityMemberCollections(results);

            //return results;
            try
            {
                gcsEntityPDSAManager mgr = new gcsEntityPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsEntity result = new gcsEntity();
                    SimpleMapper.PropertyMap(mgr.Entity, result);
                    FillEntityMemberCollections(result);
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntityByGuidId", ex);
                throw;
            }

        }


        public bool IsEntityReferenced(Guid entityId)
        {

            int roleEntityCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("gcsRoleEntity", "EntityId", entityId);
            int userPrimaryEntityCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("gcsUser", "PrimaryEntityId",
                entityId);
            int userEntityCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("gcsUserEntity", "EntityId", entityId);
            int userRequirementsEntityCount = GalaxySMSDatabaseManager.GetRowCountFromTableByColumnValue("gcsUserRequirements",
                "EntityId", entityId);

            if (userRequirementsEntityCount != 0 ||
                userEntityCount != 0 ||
                userPrimaryEntityCount != 0 ||
                roleEntityCount != 0)
                return true;

            int count = GalaxySMSDatabaseManager.GetGuidForeignKeyReferenceCount("gcsEntity", "EntityId", entityId);
            if (count == 0)
                return false;
            return true;

            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    int roleEntityCount = dbContext.GetRowCountFromTableByColumnValue("gcsRoleEntity", "EntityId", entityId);
            //    int userPrimaryEntityCount = dbContext.GetRowCountFromTableByColumnValue("gcsUser", "PrimaryEntityId",
            //        entityId);
            //    int userEntityCount = dbContext.GetRowCountFromTableByColumnValue("gcsUserEntity", "EntityId", entityId);
            //    int userRequirementsEntityCount = dbContext.GetRowCountFromTableByColumnValue("gcsUserRequirements",
            //        "EntityId", entityId);

            //    if (userRequirementsEntityCount != 0 ||
            //        userEntityCount != 0 ||
            //        userPrimaryEntityCount != 0 ||
            //        roleEntityCount != 0)
            //        return true;

            //    int count = dbContext.GetGuidForeignKeyReferenceCount("gcsEntity", "EntityId", entityId);
            //    if (count == 0)
            //        return false;
            //    return true;
            //}
        }


        public bool CanRowBeDeleted(Guid entityId)
        {
            int count = GalaxySMSDatabaseManager.CanRowBeDeleted("gcsEntity", "EntityId", entityId);
            if (count == 0)
                return true;
            return false;

            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    int count = dbContext.CanRowBeDeleted("gcsEntity", "EntityId", entityId);
            //    if (count == 0)
            //        return true;
            //    return false;
            //}
        }

        public RowReferenceResult[] GetReferencingRows(Guid entityId)
        {
            return null;
        }


        public bool IsEntityUnique(gcsEntity entity)
        {
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    var entityIdParam = new SqlParameter
            //    {
            //        ParameterName = "EntityId",
            //        Value = entity.EntityId
            //    };
            //    var entityNameParam = new SqlParameter
            //    {
            //        ParameterName = "EntityName",
            //        Value = entity.EntityName
            //    };
            //    var resultParam = new SqlParameter
            //    {
            //        ParameterName = "Result",
            //        Value = 0,
            //        Direction = System.Data.ParameterDirection.Output
            //    };
            //    var ret =
            //        dbContext.Database.ExecuteSqlCommand(
            //            "exec [GCS].[gcs_IsEntityUnique] @EntityId, @EntityName, @Result OUTPUT",
            //            entityIdParam, entityNameParam, resultParam);

            //    if (Convert.ToInt32(resultParam.Value) == 0)
            //        return true;
            //    return false;
            //}


            gcs_IsEntityUniquePDSAManager mgr = new gcs_IsEntityUniquePDSAManager();
            mgr.Entity.EntityId = entity.EntityId;
            mgr.Entity.EntityName = entity.EntityName;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;

        }

        private void FillEntityMemberCollections(gcsEntity entity)
        {
            GcsUserRequirementsRepository userRequirementsRepository = new GcsUserRequirementsRepository();

            gcsUserRequirement userReqs = userRequirementsRepository.GetByEntityId(entity.EntityId);
            if (userReqs == null)
            {
                userReqs = new gcsUserRequirement()
                {
                    PasswordCannotContainName = ConfigurationUtilities.GetAppSetting(string.Empty, "PasswordCannotContainName", true, true),
                    UseCustomRegEx = ConfigurationUtilities.GetAppSetting(string.Empty, "PasswordUseCustomRegEx", false, true),
                    PasswordCustomRegEx = ConfigurationUtilities.GetAppSetting(string.Empty, "PasswordCustomRegEx", string.Empty, true),
                    PasswordMinimumLength = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "PasswordMinimumLength", 1, true),
                    PasswordMaximumLength = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "PasswordMaximumLength", 15, true),
                    PasswordMinimumChangeCharacters = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "PasswordMinimumChangeCharacters", 1, true),
                    MaintainPasswordHistoryCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "MaintainPasswordHistoryCount", 3, true),
                    AllowPasswordChangeAttempt = ConfigurationUtilities.GetAppSetting(string.Empty, "AllowPasswordChangeAttempt", true, true),
                    MinimumPasswordAge = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "MinimumPasswordAge", 0, true),
                    MaximumPasswordAge = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "MaximumPasswordAge", 0, true),
                    DefaultExpirationDays = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "DefaultExpirationDays", 0, true),
                    LockoutUserIfInactiveForDays = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "LockoutUserIfInactiveForDays", 14, true),
                    RequireLowerCaseLetterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "RequireLowerCaseLetterCount", 0, true),
                    RequireNumericDigitCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "RequireNumericDigitCount", 0, true),
                    RequireSpecialCharacterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "RequireSpecialCharacterCount", 0, true),
                    RequireUpperCaseLetterCount = (short)ConfigurationUtilities.GetAppSetting(string.Empty, "RequireUpperCaseLetterCount", 0, true),
                    RegularExpressionDescription = string.Empty
                };
            }
            entity.UserRequirements = userReqs;

            GcsEntityApplicationRepository entityApplicationRepository = new GcsEntityApplicationRepository();
            entity.EntityApplications = entityApplicationRepository.GetAllForEntity(entity.EntityId);

        }

    }
}
