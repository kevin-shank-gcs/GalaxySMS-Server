using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;


namespace GalaxySMS.Business.Entities
{
    public partial class gcsApplication
    {
        public gcsApplication()
        {
            Initialize();
        }

        public gcsApplication(gcsApplication e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsUserSettings = new HashSet<gcsUserSetting>();
            this.gcsEntityApplications = new HashSet<gcsEntityApplication>();
            this.gcsPermissionCategories = new HashSet<gcsPermissionCategory>();
            this.AllRoles = new HashSet<gcsRole>();
        }

        public void Initialize(gcsApplication e)
        {
            Initialize();
            if (e == null)
                return;
            this.ApplicationId = e.ApplicationId;
            this.LanguageId = e.LanguageId;
            this.SystemRoleId = e.SystemRoleId;
            this.ApplicationName = e.ApplicationName;
            this.ApplicationDescription = e.ApplicationDescription;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsUserSettings = e.gcsUserSettings.ToCollection();
            this.gcsEntityApplications = e.gcsEntityApplications.ToCollection();
            this.gcsPermissionCategories = e.gcsPermissionCategories.ToCollection();

            // Custom properties
            this.IsAuthorized = e.IsAuthorized;
            this.RoleCollectionsMode = e.RoleCollectionsMode;
            this.AllRoles = e.AllRoles.ToCollection();
        }

        public gcsApplication Clone(gcsApplication e)
        {
            return new gcsApplication(e);
        }

        public bool Equals(gcsApplication other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsApplication other)
        {
            if (other == null)
                return false;

            if (other.ApplicationId != this.ApplicationId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //public ICollection<gcsRole> IncludedEntityApplicationRoles;
        //public ICollection<gcsRole> ExcludedEntityApplicationRoles;
        // Custom Properties
        public enum RoleDataCollectionsMode { ForApplication, ForEntity, ForUser }

        private ICollection<gcsRole> _allRoles = new HashSet<gcsRole>();
        //private ICollection<gcsRole> _unauthorizedRoles = new HashSet<gcsRole>();
        //private ICollection<gcsRole> _authorizedRoles = new HashSet<gcsRole>();
        public override string ToString()
        {
            return ApplicationName;
        }
        public bool IsAuthorized { get; set; }
        public RoleDataCollectionsMode RoleCollectionsMode { get; set; }

        public ICollection<gcsRole> AllRoles
        {
            get { return _allRoles; }
            set { _allRoles = value; }
        }

        //public ICollection<gcsRole> AuthorizedRoles
        //{
        //    get { return _authorizedRoles; }
        //    set { _authorizedRoles = value; }
        //}

        //public ICollection<gcsRole> UnauthorizedRoles
        //{
        //    get { return _unauthorizedRoles; }
        //    set { _unauthorizedRoles = value; }
        //}
        // 

    }
}

