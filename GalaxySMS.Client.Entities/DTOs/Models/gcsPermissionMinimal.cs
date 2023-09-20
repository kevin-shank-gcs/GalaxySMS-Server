using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class gcsPermissionMinimal : ObjectBase
    {
        [DataMember(Name="Id")]
        public System.Guid PermissionId { get; set; }

        //[DataMember]
        //public System.Guid PermissionCategoryId { get; set; }

        [DataMember(Name="TypeId")]
        public System.Guid PermissionTypeId { get; set; }

        [DataMember(Name="Name")]

        public string PermissionName { get; set; }

        [DataMember(Name="Description")]
        public string PermissionDescription { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string Code { get; set; }

        #region Custom properties added just for client side usage

        /// <summary>   True if role has permission. </summary>
        private bool _roleHasPermission;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the role has permission. </summary>
        ///
        /// <value> True if role has permission, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RoleHasPermission
        {
            get { return _roleHasPermission; }
            set
            {
                if (_roleHasPermission != value)
                {
                    _roleHasPermission = value;
                    OnPropertyChanged(() => RoleHasPermission);
                }
            }
        }
        #endregion

    }
}
