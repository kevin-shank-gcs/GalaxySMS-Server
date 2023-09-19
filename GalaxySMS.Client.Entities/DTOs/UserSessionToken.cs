////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserSessionToken.cs
//
// summary:	Implements the user session token class
////////////////////////////////////////////////////////////////////////////////////////////////////

using FluentValidation;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user session token. </summary>
    /// <remarks>   This class contains important properties that the client application must use when calling server methods and operations. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserSessionToken : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSessionToken()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this UserSessionToken. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Init()
        {
            CreatedDateTime = DateTimeOffset.Now;
            ExpirationDateTime = CreatedDateTime;
            SignedOutDateTime = DateTimeOffset.MaxValue;
            SessionId = Guid.Empty;
        }

        #region Private fields

        /// <summary>   Identifier for the session. </summary>
        private Guid _sessionId;
        /// <summary>   The created date time. </summary>
        private DateTimeOffset _createdDateTime;
        /// <summary>   The expiration date time. </summary>
        private DateTimeOffset _expirationDateTime;
        /// <summary>   Information describing the user. </summary>
        private UserData _userData;
        /// <summary>   Name of the application. </summary>
        private string _applicationName;
        /// <summary>   Identifier for the application. </summary>
        private Guid _applicationId;
        /// <summary>   Type of the authentication. </summary>
        private AuthenticationType _authenticationType;
        /// <summary>   The signed out date time. </summary>
        private DateTimeOffset _signedOutDateTime;
        /// <summary>   Identifier for the current entity. </summary>
        private Guid _currentEntityId;
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   This is the unique identifier of the session.   </summary>
        /// <remarks>   This is the value that must be used for the SessionGuid property of the IApplicationUserSessionDataHeader implementing class. The server uses this value to validate the callers identity and permissions.  </remarks>
        /// <value> The identifier of the session. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid SessionId
        {
            get { return _sessionId; }
            private set
            {
                if (_sessionId != value)
                {
                    _sessionId = value;
                    OnPropertyChanged(() => SessionId, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The date and time when this object was created. </summary>
        ///
        /// <value> The created date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset CreatedDateTime
        {
            get { return _createdDateTime; }
            private set
            {
                if (_createdDateTime != value)
                {
                    _createdDateTime = value;
                    OnPropertyChanged(() => CreatedDateTime, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the expiration date time. </summary>
        /// 
        /// <value> The expiration date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset ExpirationDateTime
        {
            get { return _expirationDateTime; }
            set
            {
                if (_expirationDateTime != value)
                {
                    _expirationDateTime = value;
                    OnPropertyChanged(() => ExpirationDateTime, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the signed out date time. </summary>
        /// <remarks>   This is populated when the SignOut method is called.</remarks>
        /// <value> The signed out date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset SignedOutDateTime
        {
            get { return _signedOutDateTime; }
            private set
            {
                if (_signedOutDateTime != value)
                {
                    _signedOutDateTime = value;
                    OnPropertyChanged(() => SignedOutDateTime, false);
                }
            }
        }

        public bool IsActive
        {
            get
            {
                if (SessionId == Guid.Empty || SignedOutDateTime < DateTimeOffset.Now || ExpirationDateTime < DateTimeOffset.Now)
                    return false;
                return true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains information about the user. </summary>
        /// <remarks>   This is a complex object that contains properties about the user. This includes a collection of entities (UserEntities) that the user is authorized for. This collection is useful for building a selection list in the UI.  </remarks>
        /// <value> Information describing the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UserData UserData
        {
            get { return _userData; }
            private set
            {
                if (_userData != value)
                {
                    _userData = value;
                    OnPropertyChanged(() => UserData, false);
                }
            }
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
            private set
            {
                if (_applicationName != value)
                {
                    _applicationName = value;
                    OnPropertyChanged(() => ApplicationName, false);
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
            private set
            {
                if (_applicationId != value)
                {
                    _applicationId = value;
                    OnPropertyChanged(() => ApplicationId, false);
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
            private set
            {
                if (_authenticationType != value)
                {
                    _authenticationType = value;
                    OnPropertyChanged(() => AuthenticationType, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the unique identifier of the current/active entity. </summary>
        ///
        /// <value> The identifier of the current entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CurrentEntityId
        {
            get { return _currentEntityId; }
            set
            {
                if (_currentEntityId != value)
                {
                    _currentEntityId = value;
                    OnPropertyChanged(() => CurrentEntityId, false);
                }
            }
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the JwtToken value. </summary>
        ///
        /// <value> The JwtToken. </value>
        ///=================================================================================================
        [DataMember]
        public string JwtToken { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the Date/Time when the JwtToken will expire. </summary>
        ///
        /// <value> The jwt token valid till. </value>
        ///=================================================================================================
        [DataMember]
        public DateTimeOffset JwtTokenValidTill { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'entityId' is in role. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityId">         Identifier for the entity. </param>
        /// <param name="applicationId">    Identifier for the application. </param>
        /// <param name="roleName">         Name of the role. </param>
        ///
        /// <returns>   True if in role, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsInRole(Guid entityId, Guid applicationId, string roleName)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.Entities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            var role = (from r in userEntity.Roles where r.RoleName == roleName select r).FirstOrDefault();
            if (role == null)
                return false;

            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'entityId' is in role. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityId">         Identifier for the entity. </param>
        /// <param name="applicationId">    Identifier for the application. </param>
        /// <param name="roleId">           Identifier for the role. </param>
        ///
        /// <returns>   True if in role, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsInRole(Guid entityId, Guid applicationId, Guid roleId)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.Entities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            var role = (from r in userEntity.Roles where r.RoleId == roleId select r).FirstOrDefault();
            if (role == null)
                return false;

            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'permissionId' has permission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityId">         Identifier for the entity. </param>
        /// <param name="applicationId">    Identifier for the application. </param>
        /// <param name="permissionName">   Name of the permission. </param>
        ///
        /// <returns>   True if permission, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool HasPermission(Guid entityId, Guid applicationId, string permissionName)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.Entities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            foreach (var r in userEntity.Roles)
            {
                var permission = (from p in r.Permissions where p.PermissionName == permissionName select p).FirstOrDefault();
                if (permission != null)
                    return true;
            }
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'permissionId' has permission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityId">         Identifier for the entity. </param>
        /// <param name="applicationId">    Identifier for the application. </param>
        /// <param name="permissionId">     Identifier for the permission. </param>
        ///
        /// <returns>   True if permission, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool HasPermission(Guid entityId, Guid applicationId, Guid permissionId)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.Entities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            foreach (var r in userEntity.Roles)
            {
                var permission = (from p in r.Permissions where p.PermissionId == permissionId select p).FirstOrDefault();
                if (permission != null)
                    return true;
            }
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'permissionId' has permission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityId">     Identifier for the entity. </param>
        /// <param name="permissionId"> Identifier for the permission. </param>
        ///
        /// <returns>   True if permission, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool HasPermission(Guid entityId, Guid permissionId)
        {
            if (UserData == null)
                return false;

            if (entityId == Guid.Empty)
                return false;

            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            foreach (var r in userEntity.Roles)
            {
                var permission = (from p in r.Permissions where p.PermissionId == permissionId select p).FirstOrDefault();
                if (permission != null)
                    return true;
            }
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'entityId' has any permission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityId">         Identifier for the entity. </param>
        /// <param name="permissionIds">    List of identifiers for the permissions. </param>
        ///
        /// <returns>   True if any permission, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool HasAnyPermission(Guid entityId, IEnumerable<Guid> permissionIds)
        {
            if (UserData == null)
                return false;

            if (entityId == Guid.Empty)
                return false;

            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            foreach (var permissionId in permissionIds)
            {
                foreach (var r in userEntity.Roles)
                {
                    var permission =
                        (from p in r.Permissions where p.PermissionId == permissionId select p).FirstOrDefault();
                    if (permission != null)
                        return true;
                }
            }
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'permissionId' has permission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permissionsRequired">  The permissions required. </param>
        /// <param name="permissionRule">       The permission rule. </param>
        ///
        /// <returns>   True if permission, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool HasPermission(List<Guid> permissionsRequired, Common.Enums.PermissionsCheck permissionRule)
        {
            if (permissionsRequired?.Count == 1 && permissionsRequired[0] == Guid.Empty)
                return true;

            var entity = (from ue in UserData.UserEntities
                          where ue.EntityId == CurrentEntityId
                          select ue).FirstOrDefault();
            if (entity == null)
                CurrentEntityId = Guid.Empty;

            if (permissionsRequired?.Count > 0)
            {
                int hasPermissionCount = 0;
                foreach (var p in permissionsRequired)
                {
                    if (HasPermission(CurrentEntityId, p))
                    {
                        hasPermissionCount++;
                        if (permissionRule == PermissionsCheck.CanHaveAny)
                            return true;
                    }
                }

                switch (permissionRule)
                {
                    case PermissionsCheck.CanHaveAny:
                        if (hasPermissionCount == 0)
                            return false;
                        break;

                    case PermissionsCheck.MustHaveAll:
                        if (hasPermissionCount != permissionsRequired.Count)
                            return false;
                        break;

                    case PermissionsCheck.CannotHaveAny:
                        if (hasPermissionCount != 0)
                            return false;
                        break;
                }
            }
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'permissionId' has permission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permissionId"> Identifier for the permission. </param>
        ///
        /// <returns>   True if permission, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool HasPermission(Guid permissionId)
        {
            if (UserData == null)
                return false;

            if (CurrentEntityId == Guid.Empty)
                return false;

            var userEntity = (from e in UserData.UserEntities where e.EntityId == CurrentEntityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            foreach (var r in userEntity.Roles)
            {
                var permission = (from p in r.Permissions where p.PermissionId == permissionId select p).FirstOrDefault();
                if (permission != null)
                    return true;
            }
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user entity select collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The user entity select collection. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ICollection<UserEntitySelect> GetUserEntitySelectCollection()
        {
            var list = new List<UserEntitySelect>();
            if (UserData?.UserEntities != null)
            {
                foreach (var ue in UserData.UserEntities)
                {
                    var ues = new UserEntitySelect(ue);
                    list.Add(ues);
                }
            }
            return list.ToCollection();
        }
    }
}
