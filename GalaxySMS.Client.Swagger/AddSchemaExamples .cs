using GalaxySMS.Client.Entities;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Swagger
{
    public class AddSchemaExamples : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (type == typeof(UserSignInRequest))
            {
                var requestData = new UserSignInRequest
                {
                    SignInBy = UserSignInRequest.SignInUsing.AutoDetect,
                    UserName = "administrator",
                    Password = "P@$$word",
                    AuthenticationType = GCS.Framework.Security.AuthenticationType.Application,
                    ApplicationId = Common.Constants.ApplicationIds.GalaxySMS_Admin_Id,
                };
                requestData.PermissionsForApplicationIds.Add(Common.Constants.ApplicationIds.GalaxySMS_Admin_Id);

                schema.example = requestData;
            }
            //else if( type != typeof(object))
            //{
            //    schema.example = Activator.CreateInstance(type);
            //}
            else if (type == typeof(DeleteParameters))
            {
                var requestData = new DeleteParameters
                {
                };

                schema.example = requestData;
            }
            else if (type == typeof(SaveParameters))
            {
                var requestData = new SaveParameters
                {
                };

                schema.example = requestData;
            }
            else if (type == typeof(SaveParameters<StateProvince>))
            {
                var requestData = new SaveParameters<StateProvince>
                {
                };

                schema.example = requestData;
            }
            else if (type == typeof(DeleteParameters<StateProvince>))
            {
                var requestData = new DeleteParameters<StateProvince>
                {
                };

                schema.example = requestData;
            }
            else if (type == typeof(StateProvince))
            {
                var requestData = new StateProvince
                {
                };

                schema.example = requestData;
            }
            else if (type == typeof(Address))
            {
                var requestData = new Address
                {
                };

                schema.example = requestData;
            }    
            else if (type == typeof(SaveParameters<Region>))
            {
                var requestData = new SaveParameters<Region>
                {
                };

                schema.example = requestData;
            }
            else if (type == typeof(DeleteParameters<Region>))
            {
                var requestData = new DeleteParameters<Region>
                {
                };

                schema.example = requestData;
            }
            else if (type == typeof(Region))
            {
                var requestData = new Region
                {
                };

                schema.example = requestData;
            }
            else if (type == typeof(SaveParameters<gcsEntity>))
            {
                var requestData = new SaveParameters<gcsEntity>
                {
                };

                schema.example = requestData;
            }
            else if (type == typeof(DeleteParameters<gcsEntity>))
            {
                var requestData = new DeleteParameters<gcsEntity>
                {
                };

                schema.example = requestData;
            }
            else if (type == typeof(gcsEntity))
            {
                var requestData = new gcsEntity
                {
                };

                schema.example = requestData;
            }
            else
                System.Diagnostics.Trace.WriteLine($"GalaxySMS.Client.Swagger.AddSchemaExamples type: {type}");
        }
    }
}
