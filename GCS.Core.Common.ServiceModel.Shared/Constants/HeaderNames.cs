////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\HeaderNames.cs
//
// summary:	Implements the header names class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.ServiceModel
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A header names. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class HeaderNames
    {
        /// <summary>   Name of the application user session header. </summary>
        public const string ApplicationUserSessionHeaderName = "ApplicationUserSessionHeader";
        /// <summary>   The header namespace. </summary>
        public const string HeaderNamespace = "GCS";

        /// <summary>   Identifier for the application. </summary>
        public const string ApplicationId = "ApplicationId";
        /// <summary>   Name of the application. </summary>
        public const string ApplicationName = "ApplicationName";
        /// <summary>   The application version. </summary>
        public const string ApplicationVersion = "ApplicationVersion";
        /// <summary>   The client date time. </summary>
        public const string ClientDateTime = "ClientDateTime";
        /// <summary>   Identifier for the client time zone. </summary>
        public const string ClientTimeZoneId = "ClientTimeZoneId";
        /// <summary>   The culture. </summary>
        public const string Culture = "Culture";
        /// <summary>   The culture. </summary>
        public const string UiCulture = "UiCulture";
        /// <summary>   Name of the machine. </summary>
        public const string MachineName = "MachineName";
        /// <summary>   Unique identifier for the operation. </summary>
        public const string OperationGuid = "OperationGuid";
        /// <summary>   The product version build. </summary>
        public const string ProductVersionBuild = "ProductVersionBuild";
        /// <summary>   The product version major. </summary>
        public const string ProductVersionMajor = "ProductVersionMajor";
        /// <summary>   The product version minor. </summary>
        public const string ProductVersionMinor = "ProductVersionMinor";
        /// <summary>   The product version revision. </summary>
        public const string ProductVersionRevision = "ProductVersionRevision";
        /// <summary>   Unique identifier for the session. </summary>
        public const string SessionGuid = "SessionGuid";
        /// <summary>   Name of the user. </summary>
        public const string UserName = "UserName";
        /// <summary>   Identifier for the current entity. </summary>
        public const string CurrentEntityId = "CurrentEntityId";
    }
}
