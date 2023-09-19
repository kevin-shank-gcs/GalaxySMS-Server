using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
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
            this.UserSettings = new HashSet<gcsUserSetting>();
            //this.gcsEntityApplications = new HashSet<gcsEntityApplication>();
            this.PermissionCategories = new HashSet<gcsPermissionCategory>();
            //this.AllRoles = new HashSet<gcsRole>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsApplication e)
        {
            Initialize();
            if (e == null)
                return;
            this.ApplicationId = e.ApplicationId;
            this.LanguageId = e.LanguageId;
            //this.SystemRoleId = e.SystemRoleId;
            this.ApplicationName = e.ApplicationName;
            this.ApplicationDescription = e.ApplicationDescription;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.UserSettings = e.UserSettings.ToCollection();
            //this.gcsEntityApplications = e.gcsEntityApplications.ToCollection();
            this.PermissionCategories = e.PermissionCategories.ToCollection();

            // Custom properties
            this.IsAuthorized = e.IsAuthorized;
            //this.RoleCollectionsMode = e.RoleCollectionsMode;
            //this.AllRoles = e.AllRoles.ToCollection();
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAuthorized { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public RoleDataCollectionsMode RoleCollectionsMode { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<gcsRole> AllRoles
//        {
//            get { return _allRoles; }
//            set { _allRoles = value; }
//        }

    }
}

