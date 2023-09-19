////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AccessProfile.cs
//
// summary:	Implements the access profile class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access profile. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AccessProfile
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfile() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessProfile to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfile(AccessProfile e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessProfile. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.AccessProfileClusters = new ObservableCollection<AccessProfileCluster>();
            EntityIds = new HashSet<Guid>();
            MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessProfile. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessProfile to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(AccessProfile e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AccessProfileUid = e.AccessProfileUid;
            this.EntityId = e.EntityId;
            this.AccessProfileName = e.AccessProfileName;
            this.Comments = e.Comments;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.AccessProfileClusters != null)
                this.AccessProfileClusters = e.AccessProfileClusters.ToObservableCollection();
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();

            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

            this.TotalRowCount = e.TotalRowCount;
            //this.PersonCount = e.PersonCount;
            this.Counts = e.Counts;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this AccessProfile. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessProfile to process. </param>
        ///
        /// <returns>   A copy of this AccessProfile. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfile Clone(AccessProfile e)
        {
            return new AccessProfile(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this AccessProfile is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(AccessProfile other)
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

        public bool IsPrimaryKeyEqual(AccessProfile other)
        {
            if (other == null)
                return false;

            if (other.AccessProfileUid != this.AccessProfileUid)
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


        //private int _PersonCount;

        ////[DataMember]
        //public int PersonCount
        //{
        //    get { return _PersonCount; }
        //    set
        //    {
        //        if (_PersonCount != value)
        //        {
        //            _PersonCount = value;
        //            OnPropertyChanged(() => PersonCount, false);
        //        }
        //    }
        //}

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessProfileCounts Counts { get; set; }

    }
}