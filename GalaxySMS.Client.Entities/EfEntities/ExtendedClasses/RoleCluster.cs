////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\RoleCluster.cs
//
// summary:	Implements the role cluster class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A role cluster. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class RoleCluster
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RoleCluster() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The RoleCluster to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RoleCluster(RoleCluster e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this RoleCluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.RoleClusterPermissions = new HashSet<RoleClusterPermission>();
            this.AccessPortals = new HashSet<RoleAccessPortal>();
            this.InputOutputGroups = new HashSet<RoleInputOutputGroup>();
            this.InputDevices = new HashSet<RoleInputDevice>();
            this.OutputDevices = new HashSet<RoleOutputDevice>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this RoleCluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The RoleCluster to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(RoleCluster e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.RoleClusterUid = e.RoleClusterUid;
            this.RoleId = e.RoleId;
            this.ClusterUid = e.ClusterUid;
            this.IncludeAllOutputDevices = e.IncludeAllOutputDevices;
            this.IncludeAllAccessPortals = e.IncludeAllAccessPortals;
            this.IncludeAllInputDevices = e.IncludeAllInputDevices;
            this.IncludeAllInputOutputGroups = e.IncludeAllInputOutputGroups;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleClusterPermissions = e.RoleClusterPermissions.ToCollection();
            this.ClusterName = e.ClusterName;
            if (e.AccessPortals != null)
                this.AccessPortals = e.AccessPortals.ToCollection();
            if (e.InputOutputGroups != null)
                this.InputOutputGroups = e.InputOutputGroups.ToCollection();
            if (e.InputDevices != null)
                this.InputDevices = e.InputDevices.ToCollection();
            if (e.OutputDevices != null)
                this.OutputDevices = e.OutputDevices.ToCollection();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this RoleCluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The RoleCluster to process. </param>
        ///
        /// <returns>   A copy of this RoleCluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RoleCluster Clone(RoleCluster e)
        {
            return new RoleCluster(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this RoleCluster is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(RoleCluster other)
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

        public bool IsPrimaryKeyEqual(RoleCluster other)
        {
            if (other == null)
                return false;

            if (other.RoleClusterUid != this.RoleClusterUid)
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
            return base.ToString();
        }

        private string _clusterName;

        [DataMember]
        public string ClusterName
        {
            get { return _clusterName; }
            set
            {
                if (_clusterName != value)
                {
                    _clusterName = value;
                    OnPropertyChanged(() => ClusterName, false);
                }
            }
        }

    }
}
