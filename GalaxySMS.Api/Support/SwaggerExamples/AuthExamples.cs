using GCS.Framework.Security;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Support
{
    public class AuthSignInRequestExamples : IExamplesProvider<ApiEntities.UserSignInRequest>
    {
        ApiEntities.UserSignInRequest IExamplesProvider<ApiEntities.UserSignInRequest>.GetExamples()
        {
            return new ApiEntities.UserSignInRequest()
            {
                SignInBy = ApiEntities.SignInUsing.AutoDetect,
                UserName = "administrator",
                Password = "P@$$word",
                //ApplicationName = string.Empty,
                ApplicationId = Guid.Empty,//new Guid("49DAB866-CCEF-40B5-8CA7-AA32BC79B53A"),
                PermissionsForApplicationIds = new List<Guid>()
                {
                    Guid.Empty,
                    //new Guid("49DAB866-CCEF-40B5-8CA7-AA32BC79B53A"),
                    //new Guid("FB5E8579-2F9B-4421-89BD-496F1EF93C64")
                },
                AuthenticationType = AuthenticationType.Application,
                IncludeEntityPhotos = true,
                EntityPhotosPixelWidth = 200,
                IncludeUserPhotos = true,
                UserPhotosPixelWidth = 200,
            };
        }
    }

}