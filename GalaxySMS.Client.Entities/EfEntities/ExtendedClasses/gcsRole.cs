////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\gcsRole.cs
//
// summary:	Implements the gcs role class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs role. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsRole
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsRole()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsRole to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsRole(gcsRole e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsRole. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            //this.gcsEntityApplicationRoles = new HashSet<gcsEntityApplicationRole>();
            this.RolePermissions = new HashSet<gcsRolePermission>();
            this.DeviceFilters = new RoleFilters();
            //this.AccessPortals = new HashSet<RoleAccessPortal>();
            //this.InputOutputGroups = new HashSet<RoleInputOutputGroup>();
            //this.Clusters = new HashSet<RoleCluster>();
            //this.InputDevices = new HashSet<RoleInputDevice>();
            //this.OutputDevices = new HashSet<RoleOutputDevice>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsRole. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsRole to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(gcsRole e)
        {
            Initialize();
            if (e == null)
                return;
            this.RoleId = e.RoleId;
            this.EntityId = e.EntityId;
            this.RoleName = e.RoleName;
            this.RoleDescription = e.RoleDescription;
            this.IsActive = e.IsActive;
            this.IsDefault = e.IsDefault;
            this.IsAdministratorRole = e.IsAdministratorRole;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.gcsEntityApplicationRoles = e.gcsEntityApplicationRoles.ToCollection();
            if (e.RolePermissions != null)
                this.RolePermissions = e.RolePermissions.ToCollection();
            this.DeviceFilters = e.DeviceFilters;
            //if (e.AccessPortals != null)
            //    this.AccessPortals = e.AccessPortals.ToCollection();
            //if (e.InputOutputGroups != null)
            //    this.InputOutputGroups = e.InputOutputGroups.ToCollection();
            //if (e.Clusters != null)
            //    this.Clusters = e.Clusters.ToCollection();
            //if (e.InputDevices != null)
            //    this.InputDevices = e.InputDevices.ToCollection();
            //if (e.OutputDevices != null)
            //    this.OutputDevices = e.OutputDevices.ToCollection();

            // Custom properties
            this.IsAuthorized = e.IsAuthorized;
            this.TotalRowCount = e.TotalRowCount;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this gcsRole. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsRole to process. </param>
        ///
        /// <returns>   A copy of this gcsRole. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsRole Clone(gcsRole e)
        {
            return new gcsRole(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this gcsRole is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(gcsRole other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(gcsRole other)
        {
            if (other == null)
                return false;

            if (other.RoleId != this.RoleId)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return this.RoleName;
        }

        /// <summary>   Custom properties. </summary>
        private bool _isAuthorized;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsRole is authorized. </summary>
        ///
        /// <value> True if this gcsRole is authorized, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsAuthorized
        {
            get { return _isAuthorized; }
            set
            {
                if (_isAuthorized != value)
                {
                    _isAuthorized = value;
                    OnPropertyChanged(() => IsAuthorized);
                }
            }
        }


        private int _TotalRowCount;

        [DataMember]
        public int TotalRowCount
        {
            get => _TotalRowCount;
            set
            {
                if (_TotalRowCount != value)
                {
                    _TotalRowCount = value;
                    OnPropertyChanged(() => TotalRowCount, false);
                }
            }
        }

    }
}
