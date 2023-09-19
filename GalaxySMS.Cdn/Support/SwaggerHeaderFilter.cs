using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GalaxySMS.Cdn.Support
{
    public class SwaggerHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //if (operation.Parameters == null)
            //    operation.Parameters = new List<OpenApiParameter>();

            //var param = new OpenApiParameter
            //{
            //    Name = RequestHeaderNames.CurrentEntityId,
            //    In = ParameterLocation.Header,
            //    Description = "Header that specifies the Guid value of the Current Entity",
            //    Required = false,
            //    Schema = new OpenApiSchema {Title = RequestHeaderNames.CurrentEntityId, Type = "string", Format = "guid"}
            //};
            //operation.Parameters.Add(param);

            //param = new OpenApiParameter
            //{
            //    Name = RequestHeaderNames.CurrentSiteId,
            //    In = ParameterLocation.Header,
            //    Description = "Header that specifies the Guid value of the Current Site",
            //    Required = false,
            //    Schema = new OpenApiSchema {Title = RequestHeaderNames.CurrentSiteId, Type = "string", Format = "guid"}
            //};
            //operation.Parameters.Add(param);

            //param = new OpenApiParameter
            //{
            //    Name = RequestHeaderNames.OperationGuid,
            //    In = ParameterLocation.Header,
            //    Description = "Header that specifies the Guid value of the operation",
            //    Required = false,
            //    Schema = new OpenApiSchema {Title = RequestHeaderNames.OperationGuid, Type = "string", Format = "guid"}
            //};
            //operation.Parameters.Add(param);
        }
    }
}
