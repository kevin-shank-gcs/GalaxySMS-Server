//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using GCS.Core.Common.Core;
    using GCS.Core.Common.Contracts;
    using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person personal access group. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class PersonPersonalAccessGroup : DbObjectBase, ITableEntityBase
    {
        /// <summary>   The person cluster permission UID. </summary>
        private System.Guid _personClusterPermissionUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person cluster permission UID. </summary>
        ///
        /// <value> The person cluster permission UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.Guid PersonClusterPermissionUid
        {
            get { return _personClusterPermissionUid; }
            set
            {
                if (_personClusterPermissionUid != value)
                {
                    _personClusterPermissionUid = value;
                    OnPropertyChanged(() => PersonClusterPermissionUid);
                }
            }
        }

        /// <summary>   The time schedule UID. </summary>
        private System.Guid _timeScheduleUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time schedule UID. </summary>
        ///
        /// <value> The time schedule UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.Guid TimeScheduleUid
        {
            get { return _timeScheduleUid; }
            set
            {
                if (_timeScheduleUid != value)
                {
                    _timeScheduleUid = value;
                    OnPropertyChanged(() => TimeScheduleUid);
                }
            }
        }

        /// <summary>   The cluster UID. </summary>
        private System.Guid _clusterUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.Guid ClusterUid
        {
            get { return _clusterUid; }
            set
            {
                if (_clusterUid != value)
                {
                    _clusterUid = value;
                    OnPropertyChanged(() => ClusterUid);
                }
            }
        }

        /// <summary>   The personal access group number. </summary>
        private short _personalAccessGroupNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the personal access group number. </summary>
        ///
        /// <value> The personal access group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short PersonalAccessGroupNumber
        {
            get { return _personalAccessGroupNumber; }
            set
            {
                if (_personalAccessGroupNumber != value)
                {
                    _personalAccessGroupNumber = value;
                    OnPropertyChanged(() => PersonalAccessGroupNumber);
                }
            }
        }

        /// <summary>   Name of the insert. </summary>
        private string _insertName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the insert. </summary>
        ///
        /// <value> The name of the insert. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string InsertName
        {
            get { return _insertName; }
            set
            {
                if (_insertName != value)
                {
                    _insertName = value;
                    OnPropertyChanged(() => InsertName);
                }
            }
        }

        /// <summary>   The insert date. </summary>
        private System.DateTimeOffset _insertDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the insert date. </summary>
        ///
        /// <value> The insert date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.DateTimeOffset InsertDate
        {
            get { return _insertDate; }
            set
            {
                if (_insertDate != value)
                {
                    _insertDate = value;
                    OnPropertyChanged(() => InsertDate);
                }
            }
        }

        /// <summary>   Name of the update. </summary>
        private string _updateName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the update. </summary>
        ///
        /// <value> The name of the update. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UpdateName
        {
            get { return _updateName; }
            set
            {
                if (_updateName != value)
                {
                    _updateName = value;
                    OnPropertyChanged(() => UpdateName);
                }
            }
        }

        /// <summary>   The update. </summary>
        private Nullable<System.DateTimeOffset> _updateDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the update. </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.DateTimeOffset> UpdateDate
        {
            get { return _updateDate; }
            set
            {
                if (_updateDate != value)
                {
                    _updateDate = value;
                    OnPropertyChanged(() => UpdateDate);
                }
            }
        }

        /// <summary>   The concurrency value. </summary>
        private Nullable<short> _concurrencyValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the concurrency value. </summary>
        ///
        /// <value> The concurrency value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<short> ConcurrencyValue
        {
            get { return _concurrencyValue; }
            set
            {
                if (_concurrencyValue != value)
                {
                    _concurrencyValue = value;
                    OnPropertyChanged(() => ConcurrencyValue);
                }
            }
        }


        ///// <summary>   The person cluster permission. </summary>
        //private PersonClusterPermission _personClusterPermission;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the person cluster permission. </summary>
        /////
        ///// <value> The person cluster permission. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public virtual PersonClusterPermission PersonClusterPermission
        //{
        //    get { return _personClusterPermission; }
        //    set
        //    {
        //        if (_personClusterPermission != value)
        //        {
        //            _personClusterPermission = value;
        //            OnPropertyChanged(() => PersonClusterPermission);
        //        }
        //    }
        //}

        ///// <summary>   The access portal uids. </summary>
        //private ICollection<Guid> _accessPortalUids;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the access portal uids. </summary>
        /////
        ///// <value> The access portal uids. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public virtual ICollection<Guid> AccessPortalUids
        //{
        //    get { return _accessPortalUids; }
        //    set
        //    {
        //        if (_accessPortalUids != value)
        //        {
        //            _accessPortalUids = value;
        //            OnPropertyChanged(() => AccessPortalUids);
        //        }
        //    }
        //}


        private ICollection<AccessPortalUidItem> _accessPortals;

        [DataMember]
        public ICollection<AccessPortalUidItem> AccessPortals
        {
            get { return _accessPortals; }
            set
            {
                if (_accessPortals != value)
                {
                    _accessPortals = value;
                    OnPropertyChanged(() => AccessPortals, true);
                }
            }
        }

        ///// <summary>   The dynamic access group uids. </summary>
        //private ICollection<Guid> _dynamicAccessGroupUids;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the dynamic access group uids. </summary>
        /////
        ///// <value> The dynamic access group uids. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public virtual ICollection<Guid> DynamicAccessGroupUids
        //{
        //    get { return _dynamicAccessGroupUids; }
        //    set
        //    {
        //        if (_dynamicAccessGroupUids != value)
        //        {
        //            _dynamicAccessGroupUids = value;
        //            OnPropertyChanged(() => DynamicAccessGroupUids);
        //        }
        //    }
        //}


        private ICollection<AccessGroupUidItem> _dynamicAccessGroups;

        [DataMember]
        public ICollection<AccessGroupUidItem> DynamicAccessGroups
        {
            get { return _dynamicAccessGroups; }
            set
            {
                if (_dynamicAccessGroups != value)
                {
                    _dynamicAccessGroups = value;
                    OnPropertyChanged(() => DynamicAccessGroups, true);
                }
            }
        }

    }

}
