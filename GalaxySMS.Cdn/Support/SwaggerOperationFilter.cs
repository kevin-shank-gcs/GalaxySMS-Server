using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GalaxySMS.Cdn.Support
{
    public class SwaggerOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
            var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);
            if (isAuthorized && !allowAnonymous)
            {
                //var param = new OpenApiParameter();
                //param.Name = "Authorization";
                //param.In = ParameterLocation.Header;
                //param.Description = "Authorization header using the Bearer scheme";
                //param.Required = true;
                //param.Schema = new OpenApiSchema
                //{
                //    Title = "Bearer",
                //    Type = "string",
                //    Format = "jwt-bearer",
                //};
                //if (operation.Parameters == null)
                //    operation.Parameters = new List<OpenApiParameter>();
                //operation.Parameters.Add(param);
            }
        }
    }
}
