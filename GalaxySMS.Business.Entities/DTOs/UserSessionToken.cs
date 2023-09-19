using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Framework.Security;


namespace GalaxySMS.Business.Entities
{
    public class UserSessionToken : EntityBase
    {
        private TimeSpan _timeout;

        public UserSessionToken()
        {
            Init();
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

        public Guid SessionId { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; }

        public DateTimeOffset SignedOutDateTime { get; set; }

        public DateTimeOffset ExpirationDateTime { get; set; }

        public Guid ApplicationId { get; set; }

        public Guid CurrentEntityId { get; set; }

        public string ApplicationName { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public UserData UserData { get; set; }

        public bool IsInRole(Guid entityId, Guid applicationId, string roleName)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            var application =
                (from a in userEntity.UserApplications where a.ApplicationId == applicationId select a).FirstOrDefault();
            if (application == null)
                return false;

            var role = (from r in application.UserRoles where r.RoleName == roleName && r.IsActive == true select r).FirstOrDefault();
            if (role == null)
                return false;

            return true;
        }

        public bool IsInRole(Guid entityId, Guid applicationId, Guid roleId)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            var application =
                (from a in userEntity.UserApplications where a.ApplicationId == applicationId select a).FirstOrDefault();
            if (application == null)
                return false;

            var role = (from r in application.UserRoles where r.RoleId == roleId && r.IsActive == true select r).FirstOrDefault();
            if (role == null)
                return false;

            return true;
        }
        public bool IsInAdminRole(Guid entityId, Guid applicationId)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            var application =
                (from a in userEntity.UserApplications where a.ApplicationId == applicationId select a).FirstOrDefault();
            if (application == null)
                return false;

            var role = (from r in application.UserRoles where r.IsAdministratorRole == true && r.IsActive == true select r).FirstOrDefault();
            if (role == null)
                return false;

            return true;
        }

        public bool HasPermission(Guid entityId, Guid applicationId, string permissionName)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            var application =
                (from a in userEntity.UserApplications where a.ApplicationId == applicationId select a).FirstOrDefault();
            if (application == null)
                return false;

            foreach (var r in application.UserRoles.Where(o=>o.IsActive))
            {
                if( r.IsAdministratorRole )
                    return true;

                var permission =
                    (from p in r.UserPermissions where p.PermissionName == permissionName select p).FirstOrDefault();
                if (permission != null)
                    return true;
            }
            return false;
        }

        public bool HasPermission(Guid entityId, Guid applicationId, Guid permissionId)
        {
            if (UserData == null)
                return false;
            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            var application =
                (from a in userEntity.UserApplications where a.ApplicationId == applicationId select a).FirstOrDefault();
            if (application == null)
                return false;

            foreach (var r in application.UserRoles)
            {
                if( r.IsAdministratorRole )
                    return true;

                var permission =
                    (from p in r.UserPermissions where p.PermissionId == permissionId select p).FirstOrDefault();
                if (permission != null)
                    return true;
            }
            return false;
        }

        public bool HasPermission(Guid entityId, Guid permissionId)
        {
            if (UserData == null)
                return false;

            if (entityId == Guid.Empty)
                return false;

            var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            if (userEntity == null)
                return false;

            foreach (var application in userEntity.UserApplications)
            {
                foreach (var r in application.UserRoles)
                {
                    if( r.IsAdministratorRole )
                        return true;

                    var permission =
                        (from p in r.UserPermissions where p.PermissionId == permissionId select p).FirstOrDefault();
                    if (permission != null)
                        return true;
                }
            }
            return false;
        }

        public bool HasPermission(Guid permissionId)
        {
            if (UserData == null)
                return false;

            if (permissionId == Guid.Empty)
                return false;

            //var userEntity = (from e in UserData.UserEntities where e.EntityId == entityId select e).FirstOrDefault();
            //if (userEntity == null)
            //    return false;

            //foreach (var application in userEntity.UserApplications)
            //{
            //    foreach (var r in application.UserRoles)
            //    {
            //        var permission =
            //            (from p in r.UserPermissions where p.PermissionId == permissionId select p).FirstOrDefault();
            //        if (permission != null)
            //            return true;
            //    }
            //}
            return false;
        }

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

        //public bool IsSessionValid { get; internal set; }

        public bool IsSessionExpired
        {
            get
            {
                if (ExpirationDateTime < DateTimeOffset.Now)
                    return true;
                return false;
            }
        }

        //public void KeepAlive()
        //{
        //    if (IsSessionValid == true)
        //    {
        //        if (ExpirationDateTime < DateTimeOffset.Now)
        //        {
        //            IsSessionValid = false;
        //        }
        //        else
        //        {
        //            if (Timeout.Ticks > 0)
        //                ExpirationDateTime = DateTimeOffset.Now + Timeout;
        //            else
        //                ExpirationDateTime = DateTimeOffset.MaxValue;
        //        }
        //    }
        //}
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
    }
}