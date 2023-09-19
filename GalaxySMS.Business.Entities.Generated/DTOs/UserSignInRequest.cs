using System;
using System.Collections.Generic;
using System.Security.Principal;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Framework.Security;

namespace GalaxySMS.Business.Entities
{
    public class UserSignInRequest : EntityBase
    {
        public enum SignInUsing
        {
            UserName,
            Email,
            AutoDetect
        }

        public UserSignInRequest()
        {
            PermissionsForApplicationIds = new HashSet<Guid>();
        }

        public SignInUsing SignInBy { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ApplicationName { get; set; }

        public Guid ApplicationId { get; set; }

        public ICollection<Guid> PermissionsForApplicationIds { get; set; }

        public Version ApplicationVersion { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public ComputerInformation ComputerInformation { get; set; }

        public WindowsUserIdentity CurrentWindowsUserIdentity { get; set; }

        public DateTimeOffset SignInRequestDateTime { get; set; }

        public int MinimumExecutionTime { get; set; }
    }
}
