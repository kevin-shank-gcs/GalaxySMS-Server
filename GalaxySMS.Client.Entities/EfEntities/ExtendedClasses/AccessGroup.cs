////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AccessGroup.cs
//
// summary:	Implements the access group class
////////////////////////////////////////////////////////////////////////////////////////////////////

using FluentValidation;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access group. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AccessGroup
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessGroup()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessGroup to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessGroup(AccessGroup e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessGroup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            //this.AccessGroupAccessPortals = new HashSet<AccessGroupAccessPortal>();
            this.AccessPortals = new ItemObservableCollection<AccessGroupAccessPortal>();
            AccessPortals.CollectionChanged += AccessGroupAccessPortals_CollectionChanged;
            AccessPortals.ItemPropertyChanged += AccessGroupAccessPortals_ItemPropertyChanged;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by AccessGroupAccessPortals for item property changed events.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        The ItemPropertyChangedEventArgs&lt;AccessGroupAccessPortal&gt; to
        ///                         process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void AccessGroupAccessPortals_ItemPropertyChanged(object sender, GCS.Core.Common.UI.Collections.ItemPropertyChangedEventArgs<AccessGroupAccessPortal> e)
        {
            AccessGroupAccessPortalsAuthorized = AccessPortals.Where(i => i.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Never).ToObservableCollection();
            AccessGroupAccessPortalsNever = AccessPortals.Where(i => i.TimeScheduleUid == TimeScheduleIds.TimeSchedule_Never).ToObservableCollection();
            //OnPropertyChanged(() => AccessGroupAccessPortalsNotNever, false);
            //OnPropertyChanged(() => AccessGroupAccessPortalsNever, false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by AccessGroupAccessPortals for collection changed events.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Notify collection changed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void AccessGroupAccessPortals_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            AccessGroupAccessPortalsAuthorized = AccessPortals.Where(i => i.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Never).ToObservableCollection();
            AccessGroupAccessPortalsNever = AccessPortals.Where(i => i.TimeScheduleUid == TimeScheduleIds.TimeSchedule_Never).ToObservableCollection();
            //OnPropertyChanged(() => AccessGroupAccessPortalsNotNever, false);
            //OnPropertyChanged(() => AccessGroupAccessPortalsNever, false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessGroup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessGroup to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(AccessGroup e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessGroupUid = e.AccessGroupUid;
            this.ClusterUid = e.ClusterUid;
            this.EntityId = e.EntityId;
            this.AccessGroupNumber = e.AccessGroupNumber;
            this.Display = e.Display;
            this.Description = e.Description;
            this.ServiceComment = e.ServiceComment;
            this.Comment = e.Comment;
            this.IsEnabled = e.IsEnabled;
            this.ActivationDate = e.ActivationDate;
            this.ExpirationDate = e.ExpirationDate;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.CrisisModeAccessGroupUid = e.CrisisModeAccessGroupUid;

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            //if (e.AccessGroupAccessPortals != null)
            //    this.AccessGroupAccessPortals = e.AccessGroupAccessPortals.ToCollection();
            this.AccessPortals = e.AccessPortals;
            //if (e.AccessGroupAccessPortalsNever != null)
            //    this.AccessGroupAccessPortalsNever = e.AccessGroupAccessPortalsNever.ToCollection();
            //if (e.AccessGroupAccessPortalsNotNever != null)
            //    this.AccessGroupAccessPortalsNotNever = e.AccessGroupAccessPortalsNotNever.ToCollection();


            AccessPortals.CollectionChanged += AccessGroupAccessPortals_CollectionChanged;
            AccessPortals.ItemPropertyChanged += AccessGroupAccessPortals_ItemPropertyChanged;
            TotalRowCount = e.TotalRowCount;

            this.ClusterName = e.ClusterName;
            this.CrisisModeAccessGroupName = e.CrisisModeAccessGroupName;
            this.CrisisModeAccessGroupNumber = e.CrisisModeAccessGroupNumber;
            this.DefaultTimeScheduleUid = e.DefaultTimeScheduleUid;
            this.DefaultTimeScheduleName = e.DefaultTimeScheduleName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this AccessGroup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessGroup to process. </param>
        ///
        /// <returns>   A copy of this AccessGroup. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessGroup Clone(AccessGroup e)
        {
            return new AccessGroup(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this AccessGroup is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(AccessGroup other)
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

        public bool IsPrimaryKeyEqual(AccessGroup other)
        {
            if (other == null)
                return false;

            if (other.AccessGroupUid != this.AccessGroupUid)
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access group access portals never. </summary>
        ///
        /// <value> The access group access portals never. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<GalaxySMS.Client.Entities.AccessGroupAccessPortal> AccessGroupAccessPortalsNever
        {
            get => AccessPortals.Where(o => o.TimeScheduleUid == TimeScheduleIds.TimeSchedule_Never).ToObservableCollection();
            set
            {
                OnPropertyChanged(() => AccessGroupAccessPortalsNever, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access group access portals authorized. </summary>
        ///
        /// <value> The access group access portals authorized. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<GalaxySMS.Client.Entities.AccessGroupAccessPortal> AccessGroupAccessPortalsAuthorized
        {
            get => AccessPortals.Where(o => o.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Never).ToObservableCollection();
            set
            {
                OnPropertyChanged(() => AccessGroupAccessPortalsAuthorized, false);
            }
        }

        //private ICollection<AccessGroupAccessPortal> _accessGroupAccessPortalsNever;

        //public ICollection<AccessGroupAccessPortal> AccessGroupAccessPortalsNever
        //{
        //    get { return _accessGroupAccessPortalsNever; }
        //    set
        //    {
        //        if (_accessGroupAccessPortalsNever != value)
        //        {
        //            _accessGroupAccessPortalsNever = value;
        //            OnPropertyChanged(() => AccessGroupAccessPortalsNever, false);
        //        }
        //    }
        //}

        //private ICollection<AccessGroupAccessPortal> _accessGroupAccessPortalsNotNever;

        //public ICollection<AccessGroupAccessPortal> AccessGroupAccessPortalsNotNever
        //{
        //    get { return _accessGroupAccessPortalsNotNever; }
        //    set
        //    {
        //        if (_accessGroupAccessPortalsNotNever != value)
        //        {
        //            _accessGroupAccessPortalsNotNever = value;
        //            OnPropertyChanged(() => AccessGroupAccessPortalsNotNever, false);
        //        }
        //    }
        //}

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

        private string _crisisModeAccessGroupName;

        [DataMember]
        public string CrisisModeAccessGroupName
        {
            get { return _crisisModeAccessGroupName; }
            set
            {
                if (_crisisModeAccessGroupName != value)
                {
                    _crisisModeAccessGroupName = value;
                    OnPropertyChanged(() => CrisisModeAccessGroupName, false);
                }
            }
        }

        private int _crisisModeAccessGroupNumber;

        [DataMember]
        public int CrisisModeAccessGroupNumber
        {
            get { return _crisisModeAccessGroupNumber; }
            set
            {
                if (_crisisModeAccessGroupNumber != value)
                {
                    _crisisModeAccessGroupNumber = value;
                    OnPropertyChanged(() => CrisisModeAccessGroupNumber, false);
                }
            }
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

        private string _DefaultTimeScheduleName;

        [DataMember]
        public string DefaultTimeScheduleName
        {
            get { return _DefaultTimeScheduleName; }
            set
            {
                if (_DefaultTimeScheduleName != value)
                {
                    _DefaultTimeScheduleName = value;
                    OnPropertyChanged(() => DefaultTimeScheduleName, false);
                }
            }
        }

    }
}