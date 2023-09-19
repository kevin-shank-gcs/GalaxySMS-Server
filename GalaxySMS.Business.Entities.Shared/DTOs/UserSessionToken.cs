////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserSessionToken.cs
//
// summary:	Implements the user session token class
///=================================================================================================

using GCS.Framework.Security;
using System;
using System.Linq;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class UserSessionToken //: EntityBase
    {
        private TimeSpan _timeout;

        public UserSessionToken()
        {
            Init();
        }

        public UserSessionToken(UserSessionToken o)
        {
            Init();
            if (o != null)
            {
                this.CreatedDateTime = o.CreatedDateTime;
                this.ExpirationDateTime = o.ExpirationDateTime;
                this.SessionId = o.SessionId;
                this.SignedOutDateTime = o.SignedOutDateTime;
                this.Timeout = o.Timeout;
                this.ApplicationId = o.ApplicationId;
                this.ApplicationName = o.ApplicationName;
                this.AuthenticationType = o.AuthenticationType;
#if NetCoreApi
#else
                this.CurrentEntityId = o.CurrentEntityId;
#endif
                this.UserData = new UserData(o.UserData);

                //#if NetCoreApi
                this.JwtToken = o.JwtToken;
                this.JwtTokenValidTill = o.JwtTokenValidTill;
                //#endif
            }
        }
        private void Init()
        {
            CreatedDateTime = DateTimeOffset.Now;
            ExpirationDateTime = DateTimeOffset.MaxValue;
            SessionId = Guid.Empty;
            UserData = new UserData();
            SignedOutDateTime = DateTimeOffset.MaxValue;
            Timeout = new TimeSpan();
            //IsSessionValid = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the unique identifier of the session. </summary>
        ///
        /// <value> The identifier of the session. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid SessionId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset CreatedDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset SignedOutDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset ExpirationDateTime { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the application ID that the session was created for. </summary>
        ///
        /// <value> The identifier of the application. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif

        public Guid ApplicationId { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the current entityID for the session. </summary>
        ///
        /// <value> The identifier of the current entity. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
        public Guid CurrentEntityId { get; set; }

#endif
        //public Guid CurrentEntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ApplicationName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AuthenticationType AuthenticationType { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains information relevant to the user. </summary>
        ///
        /// <value> Information describing the user. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserData UserData { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string Jwt { get; set; }

        public bool IsInRole(Guid entityId, string roleName)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            var role = (from r in userEntity.UserRoles where r.RoleName == roleName && r.IsActive == true select r).FirstOrDefault();
            if (role == null)
                return false;

            return true;
        }

        public bool IsInRole(Guid entityId, Guid roleId)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            var role = (from r in userEntity.UserRoles where r.RoleId == roleId && r.IsActive == true select r).FirstOrDefault();
            if (role == null)
                return false;

            return true;
        }

        public bool IsInAdminRole(Guid entityId)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            var role = (from r in userEntity.UserRoles where r.IsAdministratorRole == true && r.IsActive == true select r).FirstOrDefault();
            if (role == null)
                return false;

            return true;
        }

        public bool HasPermission(Guid entityId, string permissionName)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            foreach (var r in userEntity.UserRoles.Where(o => o.IsActive))
            {
                if (r.IsAdministratorRole)
                    return true;

                var permission =
                    (from p in r.UserPermissions where p.PermissionName == permissionName select p).FirstOrDefault();
                if (permission != null)
                    return true;
            }
            return false;
        }
        public bool HasPermission(Guid entityId, Guid permissionId)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            foreach (var r in userEntity.UserRoles)
            {
                if (r.IsAdministratorRole)
                    return true;

                var permission =
                    (from p in r.UserPermissions where p.PermissionId == permissionId select p).FirstOrDefault();
                if (permission != null)
                    return true;
            }
            return false;
        }

        public bool HasPermission(Guid permissionId)
        {
            if (UserData == null)
                return false;

            if (permissionId == Guid.Empty)
                return false;

            foreach (var ue in UserData.UserEntities)
            {
                foreach (var r in ue.UserRoles)
                {
                    var p = r.UserPermissions.FirstOrDefault(o => o.PermissionId == permissionId);
                    if (p != null)
                        return true;
                }
            }

            return false;
        }
        public bool HasEntityAccess(Guid entityId)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            return userEntity != null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Indicates the length of time this session is valid for. </summary>
        ///
        /// <value> The timeout. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public TimeSpan Timeout
        {
            get { return _timeout; }
            set
            {
                if (_timeout != value)
                {
                    _timeout = value;
                    ExpirationDateTime = DateTimeOffset.Now + Timeout;
                }
            }
        }

        public bool IsSessionExpired
        {
            get
            {
                if (ExpirationDateTime < DateTimeOffset.Now)
                    return true;
                return false;
            }
        }


        public void KeepAlive()
        {
            if (IsSessionExpired == false)
            {
                if (Timeout.Ticks > 0)
                    ExpirationDateTime = DateTimeOffset.Now + Timeout;
                else
                    ExpirationDateTime = DateTimeOffset.MaxValue;
            }
        }

        public UserSignInRequest RequestData { get; set; }

        //#if NetCoreApi

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the JwtToken value. </summary>
        ///
        /// <value> The JwtToken. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif

        public string JwtToken { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the Date/Time when the JwtToken will expire. </summary>
        ///
        /// <value> The jwt token valid till. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset JwtTokenValidTill { get; set; }
        //#endif
    }
}