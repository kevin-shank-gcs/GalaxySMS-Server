using GalaxySMS.Cdn.Controllers.Api;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GalaxySMS.Cdn.Support
{
    public class ExtractHeadersActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is ControllerBaseEx controller)
            {
                try
                {
                    var authHeader = context.HttpContext.Request.GetAuthHeader();
                    if (authHeader.Count == 1)
                    {
                        try
                        {
                            controller.JwtSecurityToken = context.HttpContext.Request.GetJwtSecurityToken();
                        }
                        catch (ArgumentException ex)
                        {
                            controller.Logger.LogError($"Exception thrown executing {context.ActionDescriptor.DisplayName}: {ex}");
                        }

                        controller.ClientUserSessionData.SessionGuid = controller.JwtSecurityToken.GetClaimGuid(GalaxySMSClaimTypes.SessionId);
                        controller.ClientUserSessionData.ApplicationId = controller.JwtSecurityToken.GetClaimGuid(GalaxySMSClaimTypes.ApplicationId);
                        controller.ClientUserSessionData.ApplicationName = controller.JwtSecurityToken.GetClaimString(GalaxySMSClaimTypes.ApplicationName);
                        controller.ClientUserSessionData.UserName = controller.JwtSecurityToken.Subject;
                    }
                    controller.ClientUserSessionData.CurrentEntityId = context.HttpContext.Request.GetHeaderGuidValue(RequestHeaderNames.CurrentEntityId);
                    controller.ClientUserSessionData.CurrentSiteId = context.HttpContext.Request.GetHeaderGuidValue(RequestHeaderNames.CurrentSiteId);
                    controller.ClientUserSessionData.OperationGuid = context.HttpContext.Request.GetHeaderGuidValue(RequestHeaderNames.OperationGuid);
                    controller.ClientUserSessionData.MachineName = context.HttpContext.Connection.RemoteIpAddress.ToString();

                    //controller.ClientUserSessionData.Culture = context.HttpContext.Request.GetHeaderStringValue(RequestHeaderNames.Culture);
                    //controller.ClientUserSessionData.UiCulture = context.HttpContext.Request.GetHeaderStringValue(RequestHeaderNames.UICulture);
                    //controller.ClientUserSessionData.ClientTimeZoneId = context.HttpContext.Request.GetHeaderStringValue(RequestHeaderNames.TimeZone);

                    var entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
                    var assemblyAttributes = GCS.Framework.Utilities.SystemUtilities.GetAssemblyAttributes(ref entryAssembly);
                    controller.ClientUserSessionData.ApplicationVersion = assemblyAttributes.Version.ToString();
                    controller.ClientUserSessionData.ProductVersionMajor = assemblyAttributes.Version.Major;
                    controller.ClientUserSessionData.ProductVersionMinor = assemblyAttributes.Version.Minor;
                    controller.ClientUserSessionData.ProductVersionBuild = assemblyAttributes.Version.Build;
                    controller.ClientUserSessionData.ProductVersionRevision = assemblyAttributes.Version.Revision;
                }
                catch (Exception ex)
                {
                    controller.Logger.LogError($"Exception thrown executing {context.ActionDescriptor.DisplayName}: {ex}");
                }
            }

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}
