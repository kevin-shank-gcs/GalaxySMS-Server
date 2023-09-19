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
    public partial class gcsApplicationPermissionsMinimal : DbObjectBase
    {
        public gcsApplicationPermissionsMinimal()
        {
            PermissionCategories = new ObservableCollection<gcsPermissionCategoryMinimal>();
        }


        private Guid _applicationIdGuid;
        [DataMember]

        public Guid ApplicationId
        {
            get { return _applicationIdGuid; }
            set
            {
                if (_applicationIdGuid != value)
                {
                    _applicationIdGuid = value;
                    //OnPropertyChanged(() => ApplicationId, true);
                }
            }
        }

        private string _ApplicationName;

        [DataMember]
        public string ApplicationName
        {
            get { return _ApplicationName; }
            set
            {
                if (_ApplicationName != value)
                {
                    _ApplicationName = value;
 //                   OnPropertyChanged(() => ApplicationName, true);
                }
            }
        }

        private string _ApplicationDescription;
        [DataMember]

        public string ApplicationDescription
        {
            get { return _ApplicationDescription; }
            set
            {
                if (_ApplicationDescription != value)
                {
                    _ApplicationDescription = value;
                    //OnPropertyChanged(() => ApplicationDescription, true);
                }
            }
        }

        private ObservableCollection<gcsPermissionCategoryMinimal> _PermissionCategories;
        [DataMember]

        public ObservableCollection<gcsPermissionCategoryMinimal> PermissionCategories
    {
            get { return _PermissionCategories; }
            set
            {
                if (_PermissionCategories != value)
                {
                    _PermissionCategories = value;
                    //OnPropertyChanged(() => PermissionCategories, true);
                }
            }
        }
    }
}
