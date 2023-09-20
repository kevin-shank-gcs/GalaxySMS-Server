////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserApplication.cs
//
// summary:	Implements the user application class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Framework.Security;
using FluentValidation;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user application. </summary>
    ///
    /// <remarks>   Contains information about applications that a user is authorized to use . </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserApplication : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserApplication()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this UserApplication. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Init()
        {
            UserRoles = new HashSet<UserRole>();
        }

        /// <summary>   Identifier for the application. </summary>
        private Guid _applicationId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the application. </summary>
        ///
        /// <value> The unique identifier of the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ApplicationId
        {
            get { return _applicationId; }
            private set
            {
                if (_applicationId != value)
                {
                    _applicationId = value;
                    OnPropertyChanged(() => ApplicationId, false);
                }
            }
        }


        /// <summary>   Name of the application. </summary>
        private string _applicationName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the application. </summary>
        ///
        /// <value> The name of the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ApplicationName
        {
            get { return _applicationName; }
            private set
            {
                if (_applicationName != value)
                {
                    _applicationName = value;
                    OnPropertyChanged(() => ApplicationName, false);
                }
            }
        }

        /// <summary>   The user roles. </summary>
        private IEnumerable<UserRole> _userRoles;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user roles. </summary>
        ///
        /// <value> The roles that the user is assigned to. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember] 
        private IEnumerable<UserRole> UserRoles
        {
            get { return _userRoles; }
            set
            {
                if (_userRoles != value)
                {
                    _userRoles = value;
                    _roles = new ReadOnlyCollection<UserRole>(_userRoles.ToList());
                    OnPropertyChanged(() => Roles, false);
                }
            }
        }


        /// <summary>   The roles. </summary>
        private IReadOnlyCollection<UserRole> _roles;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the roles. </summary>
        ///
        /// <value> Real-only collection of the roles that the user is assigned to. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IReadOnlyCollection<UserRole> Roles
        {
            get { return _roles; }
        }        

    }
}
