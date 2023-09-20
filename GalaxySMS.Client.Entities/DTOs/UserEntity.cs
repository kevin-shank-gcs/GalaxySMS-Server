////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserEntity.cs
//
// summary:	Implements the user entity class
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
    /// <summary>   A user entity. </summary>
    ///
    /// <remarks>   Contains Entity information for a user </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserEntity : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserEntity()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The UserEntity to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserEntity(UserEntity o)
        {
            Init(o);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this UserEntity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Init()
        {
//            UserApplications = new HashSet<UserApplication>();
            UserRoles = new HashSet<UserRole>();
            ChildUserEntities = new HashSet<UserEntity>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this UserEntity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The UserEntity to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Init(UserEntity o)
        {
            Init();
            this.EntityId = o.EntityId;
            this.EntityName = o.EntityName;
            this.EntityDescription = o.EntityDescription;
            this.IsActive = o.IsActive;
            this.ParentEntityId = o.ParentEntityId;

            if(o.UserRoles != null)
                this.UserRoles = new HashSet<UserRole>(o.UserRoles);
            if (o.ChildUserEntities != null)
                o.ChildUserEntities = new HashSet<UserEntity>(o.ChildUserEntities);

            //this._applications = o.Applications;
            this.Thumbnail = o.Thumbnail;

        }
        /// <summary>   Identifier for the entity. </summary>
        private Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique identifier of the entity. </summary>
        ///
        /// <value> The unique identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            private set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }

        /// <summary>   Identifier for the parent entity. </summary>
        private Guid? _parentEntityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the parent entity. </summary>
        ///
        /// <value> The identifier of the parent entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid? ParentEntityId
        {
            get { return _parentEntityId; }
            set
            {
                if (_parentEntityId != value)
                {
                    _parentEntityId = value;
                    OnPropertyChanged(() => ParentEntityId, false);
                }
            }
        }

        /// <summary>   Name of the entity. </summary>
        private string _entityName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the entity. </summary>
        ///
        /// <value> The name of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EntityName
        {
            get { return _entityName; }
            private set
            {
                if (_entityName != value)
                {
                    _entityName = value;
                    OnPropertyChanged(() => EntityName, false);
                }
            }
        }

        /// <summary>   Information describing the entity. </summary>
        private string _entityDescription;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the entity. </summary>
        ///
        /// <value> Information describing the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EntityDescription
        {
            get { return _entityDescription; }
            private set
            {
                if (_entityDescription != value)
                { 
                    _entityDescription = value;
                    OnPropertyChanged(() => EntityDescription, false);
                }
            }
        }

        ///// <summary>   The user applications. </summary>
        //private IEnumerable<UserApplication> _userApplications;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the user applications. </summary>
        ///// <remarks>   This is a collection of applications that the user is permitted to use.</remarks>
        ///// <value> The user applications. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public IEnumerable<UserApplication> UserApplications
        //{
        //    get { return null; }
        //    set
        //    {
        //        if (_userApplications != value)
        //        {
        //            _userApplications = value;
        //            _applications = new ReadOnlyCollection<UserApplication>(_userApplications.ToList());
        //            OnPropertyChanged(() => Applications, false);
        //        }
        //    }
        //}

        ///// <summary>   The applications. </summary>
        //private IReadOnlyCollection<UserApplication> _applications;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets the applications. </summary>
        ///// <remarks>   This is a read-only collection of UserApplication objects</remarks>
        ///// <value> The applications. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public IReadOnlyCollection<UserApplication> Applications
        //{
        //    get { return _applications; }
        //}        
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


        /// <summary>   True if this UserEntity is active. </summary>
        private bool _isActive;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this UserEntity is active. </summary>
        ///
        /// <value> True if this UserEntity is active, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
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

        /// <summary>   The thumbnail. </summary>
        private byte[] _thumbnail;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the thumbnail. </summary>
        /// 
        /// <value> The thumbnail image in byte array form. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public byte[] Thumbnail
        {
            get { return _thumbnail; }
            set
            {
                if (_thumbnail != value)
                {
                    _thumbnail = value;
                    OnPropertyChanged(() => Thumbnail, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the thumbnail base 64 string. </summary>
        ///
        /// <value> The thumbnail image in base 64 string format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ThumbnailBase64String
        {
            get
            {
                if (Thumbnail != null)
                    return Convert.ToBase64String(Thumbnail);
                return string.Empty;
            }
        }

        /// <summary>   The child user entities. </summary>
        private ICollection<UserEntity> _childUserEntities;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Keep this list private so the client cannot inject security data. This collection is exposed
        /// as readonly via the EntityApplicationRolesPermissions properties.
        /// </summary>
        ///
        /// <value> The child user entities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<UserEntity> ChildUserEntities
        {
            get
            {
                return _childUserEntities;
            }
            set
            {
                if (_childUserEntities != value)
                {
                    _childUserEntities = value;
                    OnPropertyChanged(() => ChildUserEntities);
                }
            }
        }

    }
}
