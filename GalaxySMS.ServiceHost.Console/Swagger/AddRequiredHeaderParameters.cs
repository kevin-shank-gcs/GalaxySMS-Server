using GalaxySMS.Common.Constants;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Utilities;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace GalaxySMS.ServiceHost.Console
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.SessionGuid,
                @in = "header",
                type = "string",
                format = "uuid",
                description = "Session ID Guid value. This value must be obtained by successfully calling the /api/userSession/signInRequest POST method.",
                required = true,
                @default = Guid.Empty
            });

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.CurrentEntityId,
                @in = "header",
                type = "string",
                format = "uuid",
                description = "Current Entity ID Guid value that indicates the active/currently selected entity that the client is using",
                required = true,
                @default = Guid.Empty
            });

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.UserName,
                @in = "header",
                type = "string",
                description = "The name of the user that is making the call. This can be the windows/domain user name. Used for auditing purposes.",
                required = true,
                @default = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
            });

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.UiCulture,
                @in = "header",
                type = "string",
                description = "A language culture code that can be used specify the preferred language for text messages. The system must contain text in the requested language for this to work properly.",
                required = false,
                @default = Thread.CurrentThread.CurrentUICulture,
            });

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.Culture,
                @in = "header",
                type = "string",
                description = "A culture code that can be used specify the preferred culture formatting for culture-dependent data values such as dates, numbers and currency.",
                required = false,
                @default = Thread.CurrentThread.CurrentCulture,
            });


            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.OperationGuid,
                @in = "header",
                type = "string",
                format = "uuid",
                description = "A unique Guid value that can be used to identify a specific call/operation. Used for auditing purposes.",
                required = false,
                @default = Guid.Empty
            });

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.MachineName,
                @in = "header",
                type = "string",
                description = "A value that can be used to specify the machine/device name where the call is being made from. Used for auditing purposes.",
                required = true,
                @default = Environment.MachineName,
            });


            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.ApplicationId,
                @in = "header",
                type = "string",
                format = "uuid",
                description = "The ID (Guid) value of the application that the call is being made from",
                required = true,
                @default = ApplicationIds.GalaxySMS_Admin_Id
            });

            var myAssembly = GetType().Assembly;
            var attributes = SystemUtilities.GetAssemblyAttributes(ref myAssembly);

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.ApplicationName,
                @in = "header",
                type = "string",
                description = "The name of the application that the call is being made from",
                required = true,
                @default = $"{attributes.Title} - Swagger",
            });


            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.ApplicationVersion,
                @in = "header",
                type = "string",
                description = "The version of the application that the call is being made from. IE: 1.2.3.4. Used for auditing purposes.",
                required = true,
                @default = attributes.Version.ToString(),
            });

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.ProductVersionMajor,
                @in = "header",
                type = "number",
                description = "The major version # of the application that the call is being made from. Used for auditing purposes.",
                required = true,
                @default = attributes.Version.Major,
            });

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.ProductVersionMinor,
                @in = "header",
                type = "number",
                description = "The minor version # of the application that the call is being made from. Used for auditing purposes.",
                required = true,
                @default = attributes.Version.Minor,
            });

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.ProductVersionBuild,
                @in = "header",
                type = "number",
                description = "The version build # of the application that the call is being made from. Used for auditing purposes.",
                required = true,
                @default = attributes.Version.Build,
            });

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.ProductVersionRevision,
                @in = "header",
                type = "number",
                description = "The version revision # of the application that the call is being made from. Used for auditing purposes.",
                required = true,
                @default = attributes.Version.Revision,
            });

            operation.parameters.Add(new Parameter
            {
                name = HeaderNames.ClientTimeZoneId,
                @in = "header",
                type = "string",
                description = "A time zone name where the call is being made from. Used for auditing purposes.",
                required = false,
                @default = TimeZone.CurrentTimeZone.StandardName
            });
        }
    }
}

