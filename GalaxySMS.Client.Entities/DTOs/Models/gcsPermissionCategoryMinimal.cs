using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class gcsPermissionCategoryMinimal: DbObjectBase
    {
        private Guid _permissionCategoryId;
        private Guid _applicationId;

        [DataMember]
        public System.Guid PermissionCategoryId
        {
            get { return _permissionCategoryId; }
            set
            {
                if (_permissionCategoryId != value)
                {
                    _permissionCategoryId = value;
                    //OnPropertyChanged(() => PermissionCategoryId);
                }
            }
        }

        [DataMember]
        public System.Guid ApplicationId
        {
            get { return _applicationId; }
            set
            {
                if (_applicationId != value)
                {
                    _applicationId = value;
                    //OnPropertyChanged(() => PermissionCategoryId);
                }
            }
        }

        private string _categoryName;
        
        [DataMember(Name="Name")]

        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                if (_categoryName != value)
                {
                    _categoryName = value;
                    //OnPropertyChanged(() => CategoryName, true);
                }
            }
        }


        private string _PermissionCategoryDescription;

        [DataMember (Name = "Description")]
        public string PermissionCategoryDescription
        {
            get { return _PermissionCategoryDescription; }
            set
            {
                if (_PermissionCategoryDescription != value)
                {
                    _PermissionCategoryDescription = value;
                    //OnPropertyChanged(() => PermissionCategoryDescription, true);
                }
            }
        }

        private bool _IsSystemCategory;
        [DataMember]

        public bool IsSystemCategory
        {
            get { return _IsSystemCategory; }
            set
            {
                if (_IsSystemCategory != value)
                {
                    _IsSystemCategory = value;
                    //OnPropertyChanged(() => IsSystemCategory, true);
                }
            }
        }

        private bool _IsEntityCategory;

        [DataMember]
        public bool IsEntityCategory
        {
            get { return _IsEntityCategory; }
            set
            {
                if (_IsEntityCategory != value)
                {
                    _IsEntityCategory = value;
                    //OnPropertyChanged(() => IsEntityCategory, true);
                }
            }
        }


        private ObservableCollection<gcsPermissionMinimal> _gcsPermissions;
        [DataMember]

        public ObservableCollection<gcsPermissionMinimal> Permissions
        {
            get { return _gcsPermissions; }
            set
            {
                if (_gcsPermissions != value)
                {
                    _gcsPermissions = value;
                    //OnPropertyChanged(() => gcsPermissions, true);
                }
            }
        }

    }
}
