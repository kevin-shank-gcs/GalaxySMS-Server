using GalaxySMS.Api.Models.RequestModels;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace GalaxySMS.Api.Support
{
    public class SaveUserExamples : IExamplesProvider<SaveParams<UserPostReq>>
    {
        SaveParams<UserPostReq> IExamplesProvider<SaveParams<UserPostReq>>.GetExamples()
        {
            var data = new SaveParams<UserPostReq>()
            {
                Data = new UserPostReq()
                {
                    PrimaryEntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id,
                    FirstName = "Sample User",
                    LastName = "1",
                    UserPassword = "P@$$word",
                }
            };

            data.Data.DisplayName = $"{data.Data.FirstName}.{data.Data.LastName}";
            data.Data.UserName = data.Data.DisplayName;
            var cleanUserName = data.Data.UserName.Replace(" ", string.Empty);
            data.Data.Email = $"{cleanUserName}@test.com";
            data.Data.UserEntities = new HashSet<UserEntityPostReq>();
            var uepr = new UserEntityPostReq()
            {
                EntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id
            };
            //uepr.gcsUserEntityRoles = new HashSet<UserEntityApplicationRolePostReq>();
            //uepr.gcsUserEntityRoles.Add(new UserEntityApplicationRolePostReq()
            //{
            //});

            //uepr.gcsUserEntityRoles.Add(new UserEntityApplicationRolePostReq()
            //{
            //});
            //uepr.gcsUserEntityApplicationRoles = new HashSet<Guid>();
            //uepr.gcsUserEntityApplicationRoles.Add(Guid.Empty);
            //uepr.gcsUserEntityApplicationRoles.Add(Guid.Empty);

            data.Data.UserEntities.Add(uepr);

            data.Data.DefaultUserEntityOptions.InheritParentEntityRoles = true;
            data.Data.DefaultUserEntityOptions.AddDescendantEntities = true;
            data.Data.DefaultUserEntityOptions.IsEntityAdmin = false;
            data.Data.DefaultUserEntityOptions.DoNotAddDefaultRolesToUser = false;
            return data;
        }
    }

    public class SaveApiEntitiesUserExamples : IExamplesProvider<SaveParams<UserPutReq>>
    {
        SaveParams<UserPutReq> IExamplesProvider<SaveParams<UserPutReq>>.GetExamples()
        {
            var data = new SaveParams<UserPutReq>()
            {
                Data = new UserPutReq()
                {
                    PrimaryEntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id,
                    FirstName = "Sample User",
                    LastName = "1",
                    UserPassword = "P@$$word",
                    ConcurrencyValue = 0,
                }

            };

            data.Data.DisplayName = $"{data.Data.FirstName}.{data.Data.LastName}";
            data.Data.UserName = data.Data.DisplayName;
            data.Data.Email = $"{data.Data.UserName}@.test.com";
            data.Data.UserEntities = new HashSet<UserEntityPutReq>();
            var uepr = new UserEntityPutReq()
            {
                EntityId = GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id
            };
            //uepr.gcsUserEntityRoles = new HashSet<UserEntityApplicationRolePutReq>();
            //uepr.gcsUserEntityRoles.Add(new UserEntityApplicationRolePutReq()
            //{
            //});

            //uepr.gcsUserEntityRoles.Add(new UserEntityApplicationRolePutReq()
            //{
            //});
            

            data.Data.UserEntities.Add(uepr);



            return data;
        }
    }

}