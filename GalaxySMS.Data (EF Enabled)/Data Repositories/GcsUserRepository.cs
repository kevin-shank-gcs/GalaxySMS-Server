using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Extensions;
using GCS.Framework.Security;

namespace GalaxySMS.Data
{
    [Export(typeof(IGcsUserRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GcsUserRepository : DataRepositoryBase<gcsUser>, IGcsUserRepository
    {
        protected override gcsUser AddEntity(GalaxySMSContext dbContext, gcsUser entity)
        {
            PrepareChildrenForSaving(ref dbContext, ref entity, true);
            var user = dbContext.GcsUserSet.Add(entity);
            if (user.Equals(entity))
                System.Diagnostics.Trace.WriteLine("entity and return value are the same object");

            if (user != null)
            {
                gcsUser newUser = new gcsUser(user);
                newUser.UserPassword = string.Empty;
                return newUser;
                // Don't need to get old passwords because this is a new user. There are no old passwords
            }
            return user;
        }

        private void PrepareChildrenForSaving(ref GalaxySMSContext dbContext, ref gcsUser user, bool bAddingNewParent)
        {
            if (user != null)
            {
                if (user.gcsUserEntities != null)
                {
                    foreach (var userEntity in user.gcsUserEntities)
                    {
                        if (userEntity.UserEntityId == Guid.Empty)
                        {
                            userEntity.UserEntityId = Guid.NewGuid();
                            if (bAddingNewParent == true)
                            {
                                userEntity.InsertName = user.InsertName;
                                userEntity.InsertDate = user.InsertDate;
                            }
                            else
                            {
                                userEntity.InsertName = user.UpdateName;
                                if (user.UpdateDate.HasValue == true)
                                    userEntity.InsertDate = user.UpdateDate.Value;
                                else
                                    userEntity.InsertDate = DateTimeOffset.Now;
                            }
                        }
                        else
                        {   // this is not a new insert, the update name and date must be assigned
                            userEntity.UpdateName = user.UpdateName;
                            userEntity.UpdateDate = user.UpdateDate;
                        }
                        userEntity.UserId = user.UserId;
                    }
                }
            }
        }

        protected override gcsUser UpdateEntity(GalaxySMSContext dbContext, gcsUser entity)
        {
            PrepareChildrenForSaving(ref dbContext, ref entity, true);

            if (string.IsNullOrEmpty(entity.UserPassword))
            {
                entity.UserPassword = GetPasswordForUser(entity.UserId);
            }

            var result = (from e in dbContext.GcsUserSet
                          where e.UserId == entity.UserId
                          select e).FirstOrDefault();

            return result;
        }
        protected override void DeleteEntity(GalaxySMSContext dbContext, gcsUser entity)
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
        public override void Remove(gcsUser entity)
        {
            base.Remove(entity);
        }
        public override void Remove(Guid id)
        {
            //// PDSA approach
            //gcsUserManager userManager = new gcsUserManager();
            //EntityLayer.gcsUser u = new EntityLayer.gcsUser();
            //u.UserId = id;
            //userManager.Delete(u);

            ////EF approach using GalaxySMSContext
            //using (GalaxySMSContext entityContext = new GalaxySMSContext())
            //{
            //    gcsUser entity = GetEntityByGuidId(entityContext, id);
            //    if (entity != null)
            //    {
            //        // Explicitly delete each child record. Otherwise, EF generates the following exception:
            //        // "The relationship could not be changed because one or more of the foreign-key properties is non-nullable"
            //        GcsUserOldPasswordRepository oldPasswordRepository = new GcsUserOldPasswordRepository();
            //        foreach (var gcsUserOldPassword in entity.gcsUserOldPasswords)
            //        {
            //            oldPasswordRepository.Remove(gcsUserOldPassword.UserOldPasswordId);
            //        }

            //        GcsUserSettingRepository userSettingRepository = new GcsUserSettingRepository();
            //        foreach (var gcsUserSetting in entity.gcsUserSettings)
            //        {
            //            userSettingRepository.Remove(gcsUserSetting.UserSettingId);
            //        }

            //        entityContext.Entry<gcsUser>(entity).Entity.gcsUserSettings.Clear();
            //    }
            //}
            //base.Remove(id);

            // EF approach using GalaxySMSDBContextBase class to execute sql command directly without DBSet overhead
            using (GalaxySMSDBContextBase dbContext = new GalaxySMSDBContextBase())
            {

                var userIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = id
                };
                var concurrencyValueParam = new SqlParameter
                {
                    ParameterName = "ConcurrencyValue",
                    Value = DBNull.Value
                };
                var ret =
                    dbContext.Database.ExecuteSqlCommand(
                        "exec GCS.[gcsUser_DeleteByPK] @UserId, @ConcurrencyValue",
                        userIdParam, concurrencyValueParam);
            }
        }
        protected override IEnumerable<gcsUser> GetEntities(GalaxySMSContext dbContext)
        {
            IEnumerable<gcsUser> entities = from e in dbContext.GcsUserSet
                                            select e;
            // Blank out the password so it does not get returned to the client.
            IList<gcsUser> results = new List<gcsUser>();
            foreach (gcsUser entity in entities)
            {
                entity.gcsUserOldPasswords = GetOldPasswordsForUser(entity, -1).ToCollection();
                entity.UserPassword = string.Empty;
                entity.gcsUserEntities = GetEntitiesForUserId(entity.UserId).ToCollection();
                results.Add(entity);
            }
            return results;

            return from e in dbContext.GcsUserSet
                   select e;
        }

        protected override gcsUser GetEntityByIntId(GalaxySMSContext dbContext, int id)
        {
            //var query = (from e in dbContext.GcsUserSet
            //             where e. == id
            //             select e);

            //var results = query.FirstOrDefault();

            //return results;
            return null;
        }

        protected override gcsUser GetEntityByGuidId(GalaxySMSContext dbContext, Guid guid)
        {
            var query = (from e in dbContext.GcsUserSet
                         where e.UserId == guid
                         select e);

            var results = query.FirstOrDefault();

            if (results != null)
            {
                results.UserPassword = string.Empty;
                results.gcsUserOldPasswords = GetOldPasswordsForUser(results, -1).ToCollection();
            }

            return results;
        }

        public gcsUser GetByLoginName(string login)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                var user = (from a in dbContext.GcsUserSet
                            where a.LoginName == login
                            select a).FirstOrDefault();
                if (user != null)
                {
                    user.UserPassword = string.Empty;
                    user.gcsUserOldPasswords = GetOldPasswordsForUser(user, -1).ToCollection();
                }
                return user;
            }
        }


        public bool IsUserUnique(gcsUser user)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                var userIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = user.UserId
                };
                var loginNameParam = new SqlParameter
                {
                    ParameterName = "LoginName",
                    Value = user.LoginName
                };
                var emailAddressParam = new SqlParameter
                {
                    ParameterName = "EmailAddress",
                    Value = user.EmailAddress
                };
                var resultParam = new SqlParameter
                {
                    ParameterName = "Result",
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };

                int ret = dbContext.Database.ExecuteSqlCommand("exec [GCS].[gcs_IsUserUnique] @UserId, @LoginName, @EmailAddress, @Result OUTPUT",
                    userIdParam, loginNameParam, emailAddressParam, resultParam);

                if (Convert.ToInt32(resultParam.Value) == 0)
                    return true;
                return false;
            }
        }

        public IEnumerable<PasswordValidationResult> IsPasswordValid(gcsUser user)
        {
            List<PasswordValidationResult> validationResults = new List<PasswordValidationResult>();
            if (user == null)
            {
                validationResults.Add(PasswordValidationResult.InvalidParameter);
                return validationResults;
            }
            if (user.PrimaryEntityId == Guid.Empty)
            {
                validationResults.Add(PasswordValidationResult.InvalidParameter);
                return validationResults;
            }
            if (user.PrimaryEntityId == Guid.Empty)
                validationResults.Add(PasswordValidationResult.InvalidParameter);

            if (validationResults.Count != 0)
                return validationResults;

            // Retrieve the UserRequirements for the users' primary entity and validate the password accordingly
            // The password is encrypted coming into this method, so it must be decrypted to test for minimum character types
            String newPwd = Crypto.DecryptString(user.UserPassword, user.UserId.ToString());//user.LoginName);

            if (newPwd == string.Empty && user.UserId != Guid.Empty)
            {   // this means that the current password is not being changed, so don't bother validating anything
                validationResults.Add(PasswordValidationResult.Valid);
                return validationResults;
            }

            var userRequirementsRepository = new GcsUserRequirementsRepository();
            var userReqs = userRequirementsRepository.GetByEntityId(user.PrimaryEntityId);
            var validator = new PasswordGeneratorValidator();
            var validationParameters = new ValidatePasswordParameters()
            {
                CustomRegularExpression = userReqs.PasswordCustomRegEx,
                MaximumLength = userReqs.PasswordMaximumLength,
                MinimumLength = userReqs.PasswordMinimumLength,
                RequiredLowerCaseCharacterCount = userReqs.RequireLowerCaseLetterCount,
                RequiredNumericDigitCount = userReqs.RequireNumericDigitCount,
                RequiredSpecialCharacterCount = userReqs.RequireSpecialCharacterCount,
                RequiredUpperCaseCharacterCount = userReqs.RequireUpperCaseLetterCount,
                UseCustomRegularExpression = userReqs.UseCustomRegEx
            };

            if (userReqs.PasswordCannotContainName)
            {
                validationParameters.AddIllegalContent(user.LastName);
                validationParameters.AddIllegalContent(user.FirstName);
                validationParameters.AddIllegalContent(user.DisplayName);
                validationParameters.AddIllegalContent(user.LoginName);
                validationParameters.AddIllegalContent(user.UserInitials);
                validationParameters.AddIllegalContent(user.EmailAddress);
            }

            validationResults = validator.ValidatePassword(newPwd, validationParameters).ToList();

            if (validationResults.Count > 0)
            {
                if (user.UserId == Guid.Empty)
                {
                    // New Users will have UserId value of Guid.Empty. There are no previous passwords to look at, so return the results
                    return validationResults;
                }

                var userOldPasswordRepository = new GcsUserOldPasswordRepository();
                IEnumerable<gcsUserOldPassword> oldPasswords = userOldPasswordRepository.GetByUserId(user.UserId,
                    userReqs.MaintainPasswordHistoryCount);
                int x = 0;
                foreach (gcsUserOldPassword oldPassword in oldPasswords)
                {
                    String oldPwd = Crypto.DecryptString(oldPassword.Password, user.UserId.ToString());//user.LoginName);
                    if (newPwd == oldPwd)
                    {
                        validationResults.Add(PasswordValidationResult.InvalidMatchesPreviousPassword);
                        return validationResults;
                    }

                    if (x == 0)
                    {
                        int differentCharacterCount = 0;
                        int pwdLen = newPwd.Length;
                        if (newPwd.Length > oldPwd.Length)
                            pwdLen = oldPwd.Length;

                        for (int c = 0; c < pwdLen; c++)
                        {
                            if (newPwd[c] != oldPwd[c])
                                differentCharacterCount++;
                        }

                        if (newPwd.Length > oldPwd.Length)
                        {
                            differentCharacterCount += newPwd.Length - oldPwd.Length;
                        }
                        else if (oldPwd.Length > newPwd.Length)
                        {
                            differentCharacterCount += oldPwd.Length - newPwd.Length;
                        }
                        if (differentCharacterCount < userReqs.PasswordMinimumChangeCharacters)
                            validationResults.Add(PasswordValidationResult.InsufficientNumberOfCharactersChanged);

                    }
                    x++;
                }

                if (validationResults.Count == 0)
                    validationResults.Add(PasswordValidationResult.Valid);
            }
            return validationResults;
        }

        public IEnumerable<PasswordValidationResult> IsPasswordValidForEntityGuid(gcsUser user, Guid entityGuid)
        {
            if (user != null)
            {
                user.PrimaryEntityId = entityGuid;
            }
            return IsPasswordValid(user);
        }

        public bool IsUserReferenced(Guid userId)
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

        public String GetPasswordForUser(Guid userId)
        {
            using (GalaxySMSContext dbContext = new GalaxySMSContext())
            {
                return (from a in dbContext.GcsUserSet
                        where a.UserId == userId
                        select a.UserPassword).FirstOrDefault();
            }
            return string.Empty;
        }

        public IEnumerable<gcsUserOldPassword> GetOldPasswordsForUser(gcsUser user, int howMany)
        {
            if (howMany < 0)
            {
                var userRequirementsRepository = new GcsUserRequirementsRepository();
                var userReqs = userRequirementsRepository.GetByEntityId(user.PrimaryEntityId);
                if (userReqs != null)
                    howMany = userReqs.MaintainPasswordHistoryCount;
                else
                    howMany = 0;
            }

            GcsUserOldPasswordRepository userOldPasswordRepository = new GcsUserOldPasswordRepository();
            var oldPasswords = userOldPasswordRepository.GetByUserId(user.UserId, howMany).ToCollection();
            oldPasswords.Add(new gcsUserOldPassword() { Password = GetPasswordForUser(user.UserId) });

            return oldPasswords;
        }

        public IEnumerable<gcsUserEntity> GetEntitiesForUserId(Guid userId)
        {

            GcsUserEntityRepository userEntityRepository = new GcsUserEntityRepository();
            var results = userEntityRepository.GetByUserId(userId).ToCollection();

            return results;
        }
    }
}
