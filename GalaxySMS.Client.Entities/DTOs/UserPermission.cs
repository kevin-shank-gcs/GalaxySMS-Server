////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserPermission.cs
//
// summary:	Implements the user permission class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Framework.Security;
using FluentValidation;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   User permission. </summary>
    ///
    /// <remarks>   Represents a specific permission within the system. Permissions are used by Roles, which can be thought of as a permission set. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserPermission : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserPermission()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this UserPermission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Init()
        {
        }

        /// <summary>   Identifier for the permission. </summary>
        private Guid _permissionId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the permission. </summary>
        ///
        /// <value> The unique identifier of the permission. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid PermissionId
        {
            get { return _permissionId; }
            private set { _permissionId = value; }
        }


        /// <summary>   Name of the permission. </summary>
        private string _permissionName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the permission. </summary>
        ///
        /// <value> The name of the permission. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string PermissionName
        {
            get { return _permissionName; }
            private set { _permissionName = value; }
        }



    }
}
