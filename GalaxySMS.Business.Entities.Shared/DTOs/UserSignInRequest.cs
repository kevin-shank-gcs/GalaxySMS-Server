////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserSignInRequest.cs
//
// summary:	Implements the user sign in request class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Framework.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;



#if NetCoreApi
[assembly: ContractNamespace("http://www.galaxysys.com/GalaxySMS", ClrNamespace = "GalaxySMS.Business.Entities.Api.NetCore")]
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
[assembly: ContractNamespace("http://www.galaxysys.com/GalaxySMS", ClrNamespace = "GalaxySMS.Business.Entities.NetStd2")]
namespace GalaxySMS.Business.Entities.NetStd2
#else
[assembly: ContractNamespace("http://www.galaxysys.com/GalaxySMS",
    ClrNamespace = "GalaxySMS.Business.Entities")]

namespace GalaxySMS.Business.Entities
#endif
{
    /// <summary>   Values that represent which property to use when signing in. </summary>
    public enum SignInUsing
    {
        UserName,
        Email,
        AutoDetect
    }

    /// <summary>   A user sign in request base. </summary>

#if NetCoreApi
#else
    [DataContract]
#endif

    public class UserSignInRequestBase : EntityBaseSimple
    {


        public UserSignInRequestBase()
        {

        }

        public UserSignInRequestBase(UserSignInRequestBase o)
        {
            if (o != null)
            {
                SignInBy = o.SignInBy;
                UserName = o.UserName;
                Password = o.Password;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the property to sign in by. </summary>
        ///
        /// <value> Property to sign in by. </value>
        ///=================================================================================================

#if NetCoreApi
        [Required]
#else
        [DataMember]
#endif

        public SignInUsing SignInBy { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the user. </summary>
        ///
        /// <value> The name of the user. </value>
        ///=================================================================================================

#if NetCoreApi
        [Required]
#else
        [DataMember]
#endif


        public string UserName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the password. </summary>
        ///
        /// <value> The password. </value>
        ///=================================================================================================

#if NetCoreApi
        [Required]
#else
        [DataMember]
#endif
        public string Password { get; set; }

    }

    /// <summary>   A user sign in request. </summary>

#if NetCoreApi
#else
    [DataContract]
#endif

    public class UserSignInRequest : UserSignInRequestBase
    {
        public UserSignInRequest()
        {
            PermissionsForApplicationIds = new HashSet<Guid>();
        }

        public UserSignInRequest(UserSignInRequestBase o) : base(o)
        {
            PermissionsForApplicationIds = new HashSet<Guid>();
        }

        public UserSignInRequest(UserSignInRequest o) : base(o)
        {
            PermissionsForApplicationIds = new HashSet<Guid>();
            if (o != null)
            {
                if (o.PermissionsForApplicationIds != null)
                    PermissionsForApplicationIds = o.PermissionsForApplicationIds.ToCollection();
                this.ApplicationId = o.ApplicationId;
                this.AuthenticationType = o.AuthenticationType;
                this.EntityPhotosPixelWidth = o.EntityPhotosPixelWidth;
                this.IncludeEntityPhotos = o.IncludeEntityPhotos;
                this.IncludeUserPhotos = o.IncludeUserPhotos;
                this.Password = o.Password;
                this.SignInBy = o.SignInBy;
                this.UserName = o.UserName;
                this.UserPhotosPixelWidth = o.UserPhotosPixelWidth;
                this.SessionTimeout = o.SessionTimeout;

#if NetCoreApi
#else
                ApplicationName = o.ApplicationName;
                this.ApplicationVersion = o.ApplicationVersion;
                this.SignInRequestDateTime = o.SignInRequestDateTime;
                this.ComputerInformation = new ComputerInformation(o.ComputerInformation);
                this.CurrentWindowsUserIdentity = new WindowsUserIdentity(o.CurrentWindowsUserIdentity);
#endif
            }
        }
#if NetCoreApi
#else
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the application. </summary>
        /// <remarks>   Specifies the name of the application being signed in to</remarks>
        /// <value> The name of the application. </value>
        ///=================================================================================================

        [DataMember]
        public string ApplicationName { get; set; }
#endif

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the application. </summary>
        /// <remarks>   Specifies the Guid value of the application being signed in to.</remarks>
        /// <value> The identifier of the application. </value>
        ///=================================================================================================

#if NetCoreApi
        [Required]
#else
        [DataMember]
#endif
        public Guid ApplicationId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a list of Application Id values that should have roles/permissions included in the response.
        /// </summary>
        /// <remarks>   This is an array of Guid values that specifies the Application Ids that for which
        ///             permissions should be included in the response. A list of valid applications can be
        ///             obtained via the /api/Application/list operation. </remarks>
        ///
        /// <value> A list of identifiers of the permissions for applications. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> PermissionsForApplicationIds { get; set; }

#if NetCoreApi
#else

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the application version. </summary>
        /// <remarks>   Specifies the application version that is being signed in to.</remarks>
        /// <value> The application version. </value>
        ///=================================================================================================
        [DataMember]
        public Version ApplicationVersion { get; set; }
#endif

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the authentication. </summary>
        /// <remarks>   Specifies the type of authentication being requested. </remarks>
        /// <value> The type of the authentication. </value>
        ///=================================================================================================

#if NetCoreApi
        [Required]
#else
        [DataMember]
#endif
        public AuthenticationType AuthenticationType { get; set; }

#if NetCoreApi
#else

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the computer. </summary>
        ///
        /// <value> Information describing the computer. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif
        public ComputerInformation ComputerInformation { get; set; }
#endif


#if NetCoreApi
#else

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current windows user identity. </summary>
        ///
        /// <value> The current windows user identity. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif
        public WindowsUserIdentity CurrentWindowsUserIdentity { get; set; }
#endif

#if NetCoreApi
#else

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sign in request date time. </summary>
        /// <remarks>   The client can set this if they wish to determine how long the request takes to complete. </remarks>
        /// <value> The sign in request date time. </value>
        ///=================================================================================================
        [DataMember]
        public DateTimeOffset SignInRequestDateTime { get; set; }
#endif

        ////#if NetCoreApi
        ////#else
        ////        [DataMember]
        ////#endif
        //public int MinimumExecutionTime { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the entity photos should be included.
        /// </summary>
        /// <remarks> If True, entity photos/images will be included in the response</remarks>
        /// <value> True if include entity photos, false if not. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IncludeEntityPhotos { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the width of the entity photos pixel. </summary>
        /// <remarks>   If 0, the image will be returned in its original size. If > 0, the image will be sized
        ///             down to the requested pixel width. If the value specified is greater than the stored image width,
        ///             the image will be returned in its stored size. The server will not up-size images. </remarks>
        /// <value> The width of the entity photos pixel. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif

        public int EntityPhotosPixelWidth { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the user photos should be included.
        /// </summary>
        /// <remarks> If True, user photos/images will be included in the response</remarks>
        /// <value> True if include user photos, false if not. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IncludeUserPhotos { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the width of the user photos pixel. </summary>
        /// <remarks>   If 0, the image will be returned in its original size. If > 0, the image will be sized
        ///             down to the requested pixel width. If the value specified is greater than the stored image width,
        ///             the image will be returned in its stored size. The server will not up-size images. </remarks>
        /// <value> The width of the user photos pixel. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public int UserPhotosPixelWidth { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the session timeout in minutes. </summary>
        ///
        /// <value> The length of the session. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif
        public int SessionTimeout { get; set; }
    }
}
