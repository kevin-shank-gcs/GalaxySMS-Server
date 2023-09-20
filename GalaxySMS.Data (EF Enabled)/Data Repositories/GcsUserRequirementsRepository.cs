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
using GCS.Core.Common.Config;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;
using PDSA.Validation;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsUserRequirementsRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserRequirementsRepository : DataRepositoryBase<gcsUserRequirement>, IGcsUserRequirementsRepository
    {
        protected override gcsUserRequirement AddEntity(GalaxySMSContext dbContext, gcsUserRequirement entity)
        {
            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Insert();
                var result = GetEntityByGuidId(dbContext, entity.UserRequirementsId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::AddEntity", ex);
                throw;
            }

            //// Use Entity Framework 
            //return dbContext.GcsUserRequirementsSet.Add(entity);
        }

        protected override gcsUserRequirement UpdateEntity(GalaxySMSContext dbContext, gcsUserRequirement entity)
        {
            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.Update();
                var result = GetEntityByGuidId(dbContext, entity.UserRequirementsId);
                return result;
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::UpdateEntity", ex);
                throw;
            }

            // Entity Framework 
            //return (from e in dbContext.GcsUserRequirementsSet
            //        where e.UserRequirementsId == entity.UserRequirementsId
            //        select e).FirstOrDefault();
        }

        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsUserRequirement entity)
        {
            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
                mgr.InitEntityObject(entity);
                mgr.DataObject.DeleteByPK(entity.UserRequirementsId);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::DeleteEntity", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }

        public override void Remove(Guid id)
        {
            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
                mgr.DataObject.DeleteByPK(id);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::Remove", ex);
                throw;
            }

            // Entity Framework 
            //            base.Remove(id);
        }
        
        protected override IEnumerable<gcsUserRequirement> GetEntities(GalaxySMSContext dbContext)
        {
            try
            {
                // Using Entity Framework
                //return from e in dbContext.GcsUserRequirementsSet
                //       select e;

                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();

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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsEntityRepository::GetEntities", ex);
                throw;
            }
        }

        protected override gcsUserRequirement GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            return null;
        }

        protected override gcsUserRequirement GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            //var query = (from e in dbContext.GcsUserRequirementsSet
            //             where e.UserRequirementsId == guid
            //             select e);

            //var results = query.FirstOrDefault();
            //if (results == null)
            //    results = GetDefaultValue();
            //return results;
            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
                var count = mgr.DataObject.LoadByPK(guid);

                if (count == 1)
                {
                    gcsUserRequirement result = new gcsUserRequirement();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::GetEntityByGuidId", ex);
                throw;
            }
        }


        #region IGcsUserRequirementsRepository Members

        public gcsUserRequirement GetByEntityId(Guid entityId)
        {
            // Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    var ret = (from a in dbContext.GcsUserRequirementsSet
            //            where a.EntityId == entityId
            //            select a).FirstOrDefault();
            //    if (ret == null )
            //        ret = GetDefaultValue();
            //    return ret;
            //}

            try
            {
                gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
                mgr.DataObject.SelectFilter = gcsUserRequirementsPDSAData.SelectFilters.ByEntityId;
                mgr.Entity.EntityId = entityId;
                var count = mgr.DataObject.Load();
                if (count == 1)
                {
                    gcsUserRequirement result = new gcsUserRequirement();
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
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserRequirementsRepository::GetByEntityId", ex);
                throw;
            }

        }

        public bool IsUserRequirementReferenced(Guid userRequirementId)
        {
            return false;
        }

        public bool IsUserRequirementUnique(gcsUserRequirement userRequirement)
        {
            gcs_IsUserRequirementUniquePDSAManager mgr = new gcs_IsUserRequirementUniquePDSAManager();
            mgr.Entity.UserRequirementsId = userRequirement.UserRequirementsId;
            mgr.Entity.EntityId = userRequirement.EntityId;
            mgr.BuildCollection();


            if (Convert.ToInt32(mgr.Entity.Result) == 0)
                return true;
            return false;

            // Using Entity Framework
            //using (GalaxySMSContext dbContext = new GalaxySMSContext())
            //{
            //    var userRequirementIdParam = new SqlParameter
            //    {
            //        ParameterName = "UserRequirementsId",
            //        Value = userRequirement.UserRequirementsId
            //    };

            //    var entityIdParam = new SqlParameter
            //    {
            //        ParameterName = "EntityId",
            //        Value = userRequirement.EntityGuid
            //    };
            //    var resultParam = new SqlParameter
            //    {
            //        ParameterName = "Result",
            //        Value = 0,
            //        Direction = System.Data.ParameterDirection.Output
            //    };

            //    int ret = dbContext.Database.ExecuteSqlCommand("exec [GCS].[gcs_IsUserRequirementUnique] @UserRequirementsId, @EntityId, @Result OUTPUT",
            //        userRequirementIdParam, entityIdParam, resultParam);

            //    if (Convert.ToInt32(resultParam.Value) == 0)
            //        return true;
            //    return false;
            //}
        }

        public gcsUserRequirement GetDefaultValue()
        {
            return new gcsUserRequirement()
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
        #endregion
    }
}
