////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Data Contracts\ApplicationUserSessionHeader.cs
//
// summary:	Implements the application user session header class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Utils;
using GCS.Framework.Utilities;

namespace GCS.Core.Common.ServiceModel
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An application user session header. This class implements the IApplicationUserSessionDataHeader interface</summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class ApplicationUserSessionHeader : IApplicationUserSessionDataHeader
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ApplicationUserSessionHeader()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ApplicationUserSessionHeader(IApplicationUserSessionDataHeader data)
        {
            Init();
            if( data != null )
            {
                SessionGuid = data.SessionGuid;
                CurrentEntityId = data.CurrentEntityId;
                CurrentSiteId = data.CurrentSiteId;
                //ClientDateTime = data.ClientDateTime;
                //UserId = data.UserId;

                OperationGuid = data.OperationGuid;
                ApplicationId = data.ApplicationId;
                ApplicationName = data.ApplicationName;
                UserName = data.UserName;
                Culture = data.Culture;
                UiCulture = data.UiCulture;
                ClientTimeZoneId = data.ClientTimeZoneId;

                ApplicationId = data.ApplicationId;
                ApplicationName = data.ApplicationName;
                ApplicationVersion = data.ApplicationVersion;
                ProductVersionMajor = data.ProductVersionMajor;
                ProductVersionMinor = data.ProductVersionMinor;
                ProductVersionBuild = data.ProductVersionBuild;
                ProductVersionRevision = data.ProductVersionRevision;
                MachineName = data.MachineName;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="assemblyAttributes">   The assembly attributes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ApplicationUserSessionHeader(AssemblyAttributes assemblyAttributes)
        {
            Init(assemblyAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this ApplicationUserSessionHeader. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Init()
        {
            SessionGuid = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            CurrentSiteId = Guid.Empty;
            //ClientDateTime = DateTimeOffset.Now;
            //            UserId = Guid.Empty;
            OperationGuid = Guid.Empty;
            ApplicationId = Guid.Empty;
            ApplicationName = string.Empty;
            UserName = PrincipalIdentity.CurrentWindowsUserName;
            Culture = CultureInfo.CurrentCulture.ToString();
            UiCulture = CultureInfo.CurrentUICulture.ToString();
            ClientTimeZoneId = TimeZoneInfo.Local.Id;

            var entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
            var assemblyAttributes = GCS.Framework.Utilities.SystemUtilities.GetAssemblyAttributes(ref entryAssembly);
            ApplicationId = assemblyAttributes.Guid;
            ApplicationName = assemblyAttributes.Product;
            ApplicationVersion = assemblyAttributes.Version.ToString();
            ProductVersionMajor = assemblyAttributes.Version.Major;
            ProductVersionMinor = assemblyAttributes.Version.Minor;
            ProductVersionBuild = assemblyAttributes.Version.Build;
            ProductVersionRevision = assemblyAttributes.Version.Revision;
            MachineName = Environment.MachineName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this ApplicationUserSessionHeader. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="assemblyAttributes">   The assembly attributes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init(AssemblyAttributes assemblyAttributes)
        {
            SessionGuid = Guid.Empty;
            CurrentEntityId = Guid.Empty;
            CurrentSiteId = Guid.Empty;
            //ClientDateTime = DateTimeOffset.Now;
            //            UserId = Guid.Empty;
            OperationGuid = Guid.Empty;
            ApplicationId = Guid.Empty;
            ApplicationName = string.Empty;
            UserName = PrincipalIdentity.CurrentWindowsUserName;
            Culture = CultureInfo.CurrentCulture.ToString();
            UiCulture = CultureInfo.CurrentUICulture.ToString();
            ClientTimeZoneId = TimeZoneInfo.Local.Id;

            ApplicationId = assemblyAttributes.Guid;
            ApplicationName = assemblyAttributes.Product;
            ApplicationVersion = assemblyAttributes.Version.ToString();
            ProductVersionMajor = assemblyAttributes.Version.Major;
            ProductVersionMinor = assemblyAttributes.Version.Minor;
            ProductVersionBuild = assemblyAttributes.Version.Build;
            ProductVersionRevision = assemblyAttributes.Version.Revision;
            MachineName = Environment.MachineName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the session. </summary>
        ///
        /// <value> Unique identifier of the session. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid SessionGuid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current entity identifier. </summary>
        ///
        /// <value> The identifier of the current entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CurrentEntityId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current site identifier. </summary>
        ///
        /// <value> The identifier of the current site. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CurrentSiteId { get; set; }
        //[DataMember]
        //public DateTimeOffset ClientDateTime { get; set; }

        //[DataMember]
        //public Guid UserId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the user. </summary>
        ///
        /// <value> The name of the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UserName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the application. </summary>
        ///
        /// <value> The name of the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ApplicationName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the operation. </summary>
        ///
        /// <value> Unique identifier of the operation. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid OperationGuid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the culture. </summary>
        ///
        /// <value> The culture. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Culture { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the culture. </summary>
        ///
        /// <value> The user interface culture. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UiCulture { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the client time zone. </summary>
        ///
        /// <value> The identifier of the client time zone. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ClientTimeZoneId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the application. </summary>
        ///
        /// <value> The identifier of the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ApplicationId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the application version. </summary>
        ///
        /// <value> The application version. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ApplicationVersion { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the product version major. </summary>
        ///
        /// <value> The product version major. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ProductVersionMajor { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the product version minor. </summary>
        ///
        /// <value> The product version minor. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ProductVersionMinor { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the product version build. </summary>
        ///
        /// <value> The product version build. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ProductVersionBuild { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the product version revision. </summary>
        ///
        /// <value> The product version revision. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ProductVersionRevision { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the machine. </summary>
        ///
        /// <value> The name of the machine. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string MachineName { get; set; }

    }
}