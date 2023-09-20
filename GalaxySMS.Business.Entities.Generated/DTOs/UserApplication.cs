using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public class UserApplication : EntityBase
    {
        public UserApplication()
        {
            Init();
        }

        public UserApplication(gcsApplication application)
        {
            Init();
            if( application != null )
            {
                ApplicationId = application.ApplicationId;
                ApplicationName = application.ApplicationName;
            }
        }


        private void Init()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public Guid ApplicationId { get; set; }

        public string ApplicationName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        
    }
}
