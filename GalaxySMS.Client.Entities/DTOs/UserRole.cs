////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserRole.cs
//
// summary:	Implements the user role class
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
    /// <summary>   A user role. </summary>
    ///
    /// <remarks>   Represents a role that a user is associated with. Roles contain a collection of permissions. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserRole : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserRole()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this UserRole. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Init()
        {
            UserPermissions = new HashSet<UserPermission>();
        }

        /// <summary>   Identifier for the role. </summary>
        private Guid _roleId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the role. </summary>
        ///
        /// <value> The unique identifier of the role. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid RoleId
        {
            get { return _roleId; }
            private set
            {
                if (_roleId != value)
                {
                    _roleId = value;
                    OnPropertyChanged(() => RoleId, false);
                }
            }
        }


        /// <summary>   Name of the role. </summary>
        private string _roleName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the role. </summary>
        ///
        /// <value> The name of the role. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string RoleName
        {
            get { return _roleName; }
            private set
            {
                if (_roleName != value)
                {
                    _roleName = value;
                    OnPropertyChanged(() => RoleName, false);
                }
            }
        }

        /// <summary>   The user permissions. </summary>
        private IEnumerable<UserPermission> _userPermissions;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user permissions. </summary>
        ///
        /// <value> The permissions that are assigned to the role. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        private IEnumerable<UserPermission> UserPermissions
        {
            get { return _userPermissions; }
            set
            {
                if (_userPermissions != value)
                {
                    _userPermissions = value;
                    _permissions = new ReadOnlyCollection<UserPermission>(_userPermissions.ToList());
                    OnPropertyChanged(() => Permissions, false);
                }
            }
        }



        /// <summary>   The permissions. </summary>
        private IReadOnlyCollection<UserPermission> _permissions;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the permissions. </summary>
        ///
        /// <value> Read-only collection of the permissions that are assigned to the role. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IReadOnlyCollection<UserPermission> Permissions
        {
            get { return _permissions; }
        }                
        
        /// <summary>   True if this UserRole is active. </summary>
        private bool _isActive;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this UserRole is active. </summary>
        ///
        /// <value> True if this UserRole is active, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsActive
        {
            get { return _isActive; }
            private set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged(() => IsActive, false);
                }
            }
        }
        
    }
}
