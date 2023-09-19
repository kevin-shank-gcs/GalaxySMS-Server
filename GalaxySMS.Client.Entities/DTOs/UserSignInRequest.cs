////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserSignInRequest.cs
//
// summary:	Implements the user sign in request class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Framework.Security;
using FluentValidation;
using GCS.Framework.Utilities;
using GCS.Core.Common.Swagger;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user sign in request base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserSignInRequestBase : ObjectBaseSimple
    {
        /// <summary>   Amount to sign in by. </summary>
        private SignInUsing _signInBy;
        /// <summary>   The email. </summary>
        private string _email;
        /// <summary>   Name of the user. </summary>
        private string _userName;
        /// <summary>   The password. </summary>
        private string _password;
        /// <summary>   The hashed password. </summary>
        private string _hashedPassword;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent sign in usings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum SignInUsing
        {
            /// <summary>   An enum constant representing the user name option. </summary>
            UserName,
            /// <summary>   An enum constant representing the email option. </summary>
            Email,
            /// <summary>   An enum constant representing the automatic detect option. </summary>
            AutoDetect
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignInRequestBase()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The UserSignInRequestBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignInRequestBase(UserSignInRequestBase o)
        {
            if (o != null)
            {
                this.SignInBy = o.SignInBy;
                this.UserName = o.UserName;
                this.Password = o.Password;
                this.HashedPassword = o.HashedPassword;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the amount to sign in by. </summary>
        ///
        /// <value> Amount to sign in by. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        //[SwaggerDefaultValue("UserName")]
        public SignInUsing SignInBy
        {
            get { return _signInBy; }
            set
            {
                if (_signInBy != value)
                {
                    _signInBy = value;
                    OnPropertyChanged(() => SignInBy);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the user. </summary>
        ///
        /// <value> The name of the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        //[SwaggerDefaultValue("administrator")]
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(() => UserName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the password. </summary>
        ///
        /// <value> The password. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        //[SwaggerDefaultValue("P@ssw0rd")]
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(() => Password);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the hashed password. </summary>
        ///
        /// <value> The hashed password. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string HashedPassword
        {
            get { return _hashedPassword; }
            set
            {
                if (_hashedPassword != value)
                {
                    _hashedPassword = value;
                    OnPropertyChanged(() => HashedPassword);
                }
            }
        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user sign in request. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserSignInRequest : UserSignInRequestBase
    {
        /// <summary>   Values that represent sign in usings. </summary>

        private string _applicationName;
        /// <summary>   Identifier for the application. </summary>
        private Guid _applicationId;
        /// <summary>   The application version. </summary>
        private Version _applicationVersion;
        /// <summary>   Type of the authentication. </summary>
        private AuthenticationType _authenticationType;
        /// <summary>   Information describing the computer. </summary>
        private ComputerInformation _computerInformation = new ComputerInformation();
        /// <summary>   The current windows user identity. </summary>
        private WindowsUserIdentity _currentWindowsUserIdentity;
        /// <summary>   The sign in request date time. </summary>
        private DateTimeOffset _signInRequestDateTime;
        /// <summary>   The minimum execution time. </summary>
        private int _minimumExecutionTime;

        /// <summary>   True to include, false to exclude the entity photos. </summary>
        private bool _IncludeEntityPhotos;
        /// <summary>   Width of the entity photos pixel. </summary>
        private int _EntityPhotosPixelWidth;
        private bool _IncludeUserPhotos;

        private int _UserPhotosPixelWidth;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/19/2016. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignInRequest()
        {
            AssemblyAttributes assemblyAttributes = GCS.Framework.Utilities.SystemUtilities.GetEntryAssemblyAttributes();
            Initialize(assemblyAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The UserSignInRequestBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignInRequest(UserSignInRequestBase o) : base(o)
        {
            AssemblyAttributes assemblyAttributes = GCS.Framework.Utilities.SystemUtilities.GetEntryAssemblyAttributes();
            Initialize(assemblyAttributes);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/19/2016. </remarks>
        ///
        /// <param name="assemblyAttributes">   The assembly attributes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignInRequest(AssemblyAttributes assemblyAttributes)
        {
            Initialize(assemblyAttributes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this object. </summary>
        ///
        /// <remarks>   Kevin, 4/19/2016. </remarks>
        ///
        /// <param name="assemblyAttributes">   The assembly attributes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Initialize(AssemblyAttributes assemblyAttributes)
        {
            _computerInformation = new ComputerInformation();
            _signInRequestDateTime = DateTimeOffset.Now;
            CurrentWindowsUserIdentity = new WindowsUserIdentity();
            ApplicationName = assemblyAttributes.Title;
            ApplicationId = assemblyAttributes.Guid;
            ApplicationVersion = assemblyAttributes.Version;
            PermissionsForApplicationIds = new HashSet<Guid>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the application. </summary>
        ///
        /// <value> The name of the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ApplicationName
        {
            get { return _applicationName; }
            set
            {
                if (_applicationName != value)
                {
                    _applicationName = value;
                    OnPropertyChanged(() => ApplicationName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the application. </summary>
        ///
        /// <value> The identifier of the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ApplicationId
        {
            get { return _applicationId; }
            set
            {
                if (_applicationId != value)
                {
                    _applicationId = value;
                    OnPropertyChanged(() => ApplicationId);
                }
            }
        }

        /// <summary>   List of identifiers for the permissions for applications. </summary>
        private ICollection<Guid> _permissionsForApplicationIds;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the permissions for applications. </summary>
        ///
        /// <value> A list of identifiers of the permissions for applications. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<Guid> PermissionsForApplicationIds
        {
            get { return _permissionsForApplicationIds; }
            private set
            {
                if (_permissionsForApplicationIds != value)
                {
                    _permissionsForApplicationIds = value;
                    OnPropertyChanged(() => PermissionsForApplicationIds);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the application version. </summary>
        ///
        /// <value> The application version. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Version ApplicationVersion
        {
            get { return _applicationVersion; }
            set
            {
                if (_applicationVersion != value)
                {
                    _applicationVersion = value;
                    OnPropertyChanged(() => ApplicationVersion);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the authentication. </summary>
        ///
        /// <value> The type of the authentication. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AuthenticationType AuthenticationType
        {
            get { return _authenticationType; }
            set
            {
                if (_authenticationType != value)
                {
                    _authenticationType = value;
                    OnPropertyChanged(() => AuthenticationType);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the computer. </summary>
        ///
        /// <value> Information describing the computer. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ComputerInformation ComputerInformation
        {
            get { return _computerInformation; }
            set
            {
                if (_computerInformation != value)
                {
                    _computerInformation = value;
                    OnPropertyChanged(() => ComputerInformation);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current windows user identity. </summary>
        ///
        /// <value> The current windows user identity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public WindowsUserIdentity CurrentWindowsUserIdentity
        {
            get { return _currentWindowsUserIdentity; }
            internal set
            {
                if (_currentWindowsUserIdentity != value)
                {
                    _currentWindowsUserIdentity = value;
                    OnPropertyChanged(() => CurrentWindowsUserIdentity);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sign in request date time. </summary>
        ///
        /// <value> The sign in request date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset SignInRequestDateTime
        {
            get { return _signInRequestDateTime; }
            set
            {
                if (_signInRequestDateTime != value)
                {
                    _signInRequestDateTime = value;
                    OnPropertyChanged(() => SignInRequestDateTime);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the minimum execution time. </summary>
        /////
        ///// <value> The minimum execution time. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]

        //public int MinimumExecutionTime
        //{
        //    get { return _minimumExecutionTime; }
        //    set
        //    {
        //        if (_minimumExecutionTime != value)
        //        {
        //            _minimumExecutionTime = value;
        //            OnPropertyChanged(() => MinimumExecutionTime);
        //        }
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the entity photos should be included.
        /// </summary>
        ///
        /// <value> True if include entity photos, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IncludeEntityPhotos
        {
            get { return _IncludeEntityPhotos; }
            set
            {
                if (_IncludeEntityPhotos != value)
                {
                    _IncludeEntityPhotos = value;
                    OnPropertyChanged(() => IncludeEntityPhotos);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the width of the entity photos pixel. </summary>
        ///
        /// <value> The width of the entity photos pixel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int EntityPhotosPixelWidth
        {
            get { return _EntityPhotosPixelWidth; }
            set
            {
                if (_EntityPhotosPixelWidth != value)
                {
                    _EntityPhotosPixelWidth = value;
                    OnPropertyChanged(() => EntityPhotosPixelWidth);
                }
            }
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the user photos should be included.
        /// </summary>
        ///
        /// <value> True if include user photos, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember]
        public bool IncludeUserPhotos
        {
            get { return _IncludeUserPhotos; }
            set
            {
                if (_IncludeUserPhotos != value)
                {
                    _IncludeUserPhotos = value;
                    OnPropertyChanged(() => IncludeUserPhotos);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the width of the user photos pixel. </summary>
        ///
        /// <value> The width of the user photos pixel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int UserPhotosPixelWidth
        {
            get { return _UserPhotosPixelWidth; }
            set
            {
                if (_UserPhotosPixelWidth != value)
                {
                    _UserPhotosPixelWidth = value;
                    OnPropertyChanged(() => UserPhotosPixelWidth);
                }
            }
        }

        private int _sessionTimeout;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the session timeout. </summary>
        ///
        /// <value> The session timeout. </value>
        ///=================================================================================================

        [DataMember]
        public int SessionTimeout
        {
            get { return _sessionTimeout; }
            set
            {
                if (_sessionTimeout != value)
                {
                    _sessionTimeout = value;
                    OnPropertyChanged(() => SessionTimeout);
                }
            }
        }

    }
}
