using GalaxySMS.Api.Models.RequestModels;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace GalaxySMS.Api.Support
{
    public class SaveEntityExamples : IExamplesProvider<SaveParams<EntityReq>>
    {
        SaveParams<EntityReq> IExamplesProvider<SaveParams<EntityReq>>.GetExamples()
        {
            var data = new EntityReq()
            {
                EntityName = "Sample Unique Entity Name",
                EntityDescription = "Sample Entity Description",
                EntityKey = "Sample Unique Value",
                IsActive = true,
                //BinaryResourceUid = Guid.Empty,
                UserRequirements = new UserRequirementReq()
                {
                    DefaultExpirationDays = 90,
                    MaintainPasswordHistoryCount = 5,
                    AllowPasswordChangeAttempt = true,
                    LockoutUserIfInactiveForDays = 30,
                    MaximumPasswordAge = 180,
                    MinimumPasswordAge = 0,
                    PasswordCannotContainName = true,
                    PasswordMinimumLength = 4,
                    PasswordMinimumChangeCharacters = 1,
                    PasswordMaximumLength = 20,
                    RequireLowerCaseLetterCount = 1,
                    RequireNumericDigitCount = 1,
                    RequireUpperCaseLetterCount = 1,
                    RequireSpecialCharacterCount = 1,
                    RequireTwoFactorAuthentication = false,
                },
                Options = new AddEntityOptions()
                {
                    AddToExistingUsers = true,
                    InheritParentEntityRoles = true,
                    IsEntityAdmin = false,
                    AutoMapSchedules = true
                }
                //gcsEntityApplications = new HashSet<EntityApplicationReq>(),
            };
            // with no entity applications defined, the server will automatically associate the entity with all applications and all roles. Most permissive out of the box
            //            var ea = new EntityApplicationReq()
            //            {
            //                ApplicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_DefaultApp_Id,
            //                RoleIds = new HashSet<Guid>(),
            ////                gcsEntityApplicationRoles = new HashSet<EntityApplicationRoleReq>()
            //            };

            //            //ea.gcsEntityApplicationRoles.Add(new EntityApplicationRoleReq()
            //            //{
            //            //    RoleId = GalaxySMS.Common.Constants.ApplicationRoleIds.GalaxySMS_AdministatorId
            //            //});
            //            ea.RoleIds.Add(GalaxySMS.Common.Constants.ApplicationRoleIds.GalaxySMS_AdministatorId);


            //            data.gcsEntityApplications.Add(ea);

            return new SaveParams<EntityReq>()
            {
                Data = data

            };
        }
    }

    public class SaveApiEntitiesGcsEntityExamples : IExamplesProvider<SaveParams<EntityPutReq>>
    {
        SaveParams<EntityPutReq> IExamplesProvider<SaveParams<EntityPutReq>>.GetExamples()
        {
            return new SaveParams<EntityPutReq>()
            {
                Data = new EntityPutReq()
                {
                    EntityName = "Sample Unique Entity Name",
                    EntityDescription = "Sample Entity Description",
                    EntityKey = "Sample Unique Value",
                    IsActive = true,
                    //BinaryResourceUid = Guid.Empty,
                    UserRequirements = new UserRequirementPutReq()
                    {
                        DefaultExpirationDays = 90,
                        MaintainPasswordHistoryCount = 5,
                        AllowPasswordChangeAttempt = true,
                        LockoutUserIfInactiveForDays = 30,
                        MaximumPasswordAge = 180,
                        MinimumPasswordAge = 0,
                        PasswordCannotContainName = true,
                        PasswordMinimumLength = 4,
                        PasswordMinimumChangeCharacters = 1,
                        PasswordMaximumLength = 20,
                        RequireLowerCaseLetterCount = 1,
                        RequireNumericDigitCount = 1,
                        RequireUpperCaseLetterCount = 1,
                        RequireSpecialCharacterCount = 1,
                        RequireTwoFactorAuthentication = false,
                        ConcurrencyValue = 0
                    },
                    //gcsBinaryResource = new ApiEntities.gcsBinaryResource()
                    //{
                    //    BinaryResourceUid = Guid.Empty,
                    //    DataType = "Image",
                    //    Category = "GalaxySMS.Business.Entities.gcsEntity",
                    //    AlertEventType = "Some identifying text"
                    //}
                }
            };
        }
    }

}