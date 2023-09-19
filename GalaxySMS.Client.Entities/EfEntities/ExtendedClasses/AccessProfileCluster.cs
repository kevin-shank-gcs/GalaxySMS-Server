////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AccessProfileCluster.cs
//
// summary:	Implements the access profile cluster class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access profile cluster. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AccessProfileCluster
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileCluster() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessProfileCluster to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileCluster(AccessProfileCluster e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessProfileCluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            if (this.AccessProfileAccessGroups == null)
                this.AccessProfileAccessGroups = new HashSet<AccessProfileAccessGroup>();
            if (this.AccessProfileInputOutputGroups == null)
                this.AccessProfileInputOutputGroups = new HashSet<AccessProfileInputOutputGroup>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AccessProfileCluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessProfileCluster to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(AccessProfileCluster e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AccessProfileClusterUid = e.AccessProfileClusterUid;
            this.AccessProfileUid = e.AccessProfileUid;
            this.ClusterUid = e.ClusterUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.AccessProfileAccessGroups != null)
                this.AccessProfileAccessGroups = e.AccessProfileAccessGroups.ToCollection();
            if (e.AccessProfileInputOutputGroups != null)
                this.AccessProfileInputOutputGroups = e.AccessProfileInputOutputGroups.ToCollection();

            this.ClusterName = e.ClusterName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this AccessProfileCluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessProfileCluster to process. </param>
        ///
        /// <returns>   A copy of this AccessProfileCluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileCluster Clone(AccessProfileCluster e)
        {
            return new AccessProfileCluster(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this AccessProfileCluster is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(AccessProfileCluster other)
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

        public bool IsPrimaryKeyEqual(AccessProfileCluster other)
        {
            if (other == null)
                return false;

            if (other.AccessProfileClusterUid != this.AccessProfileClusterUid)
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

        /// <summary>   The cluster selection item. </summary>
        private ClusterSelectionItemBasic _clusterSelectionItem;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster selection item. </summary>
        ///
        /// <value> The cluster selection item. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterSelectionItemBasic ClusterSelectionItem
        {
            get { return _clusterSelectionItem; }
            set
            {
                if (_clusterSelectionItem != value)
                {
                    _clusterSelectionItem = value;
                    OnPropertyChanged(() => ClusterSelectionItem, false);
                }
            }
        }


        /// <summary>   Name of the cluster. </summary>
        private string _clusterName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the cluster. </summary>
        ///
        /// <value> The name of the cluster. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
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


        /// <summary>   Name of the site. </summary>
        private string _siteName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the site. </summary>
        ///
        /// <value> The name of the site. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string SiteName
        {
            get { return _siteName; }
            set
            {
                if (_siteName != value)
                {
                    _siteName = value;
                    OnPropertyChanged(() => SiteName, false);
                }
            }
        }

        /// <summary>   Name of the region. </summary>
        private string _regionName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the region. </summary>
        ///
        /// <value> The name of the region. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RegionName
        {
            get { return _regionName; }
            set
            {
                if (_regionName != value)
                {
                    _regionName = value;
                    OnPropertyChanged(() => RegionName, false);
                }
            }
        }

        /// <summary>   The region image. </summary>
        private byte[] _regionImage;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the region image. </summary>
        ///
        /// <value> The region image. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public byte[] RegionImage
        {
            get { return _regionImage; }
            set
            {
                if (_regionImage != value)
                {
                    _regionImage = value;
                    OnPropertyChanged(() => RegionImage, false);
                }
            }
        }

        /// <summary>   The site image. </summary>
        private byte[] _siteImage;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the site image. </summary>
        ///
        /// <value> The site image. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public byte[] SiteImage
        {
            get { return _siteImage; }
            set
            {
                if (_siteImage != value)
                {
                    _siteImage = value;
                    OnPropertyChanged(() => SiteImage, false);
                }
            }
        }

        /// <summary>   The cluster image. </summary>
        private byte[] _clusterImage;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster image. </summary>
        ///
        /// <value> The cluster image. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public byte[] ClusterImage
        {
            get { return _clusterImage; }
            set
            {
                if (_clusterImage != value)
                {
                    _clusterImage = value;
                    OnPropertyChanged(() => ClusterImage, false);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 1. </summary>
        ///
        /// <value> The access group 1. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileAccessGroup AccessGroup1
        {
            get { return AccessProfileAccessGroups.FirstOrDefault(o => o.OrderNumber == 1); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 2. </summary>
        ///
        /// <value> The access group 2. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileAccessGroup AccessGroup2
        {
            get { return AccessProfileAccessGroups.FirstOrDefault(o => o.OrderNumber == 2); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 3. </summary>
        ///
        /// <value> The access group 3. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileAccessGroup AccessGroup3
        {
            get { return AccessProfileAccessGroups.FirstOrDefault(o => o.OrderNumber == 3); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 4. </summary>
        ///
        /// <value> The access group 4. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileAccessGroup AccessGroup4
        {
            get { return AccessProfileAccessGroups.FirstOrDefault(o => o.OrderNumber == 4); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the InputOutput group 1. </summary>
        ///
        /// <value> The access group 1. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileInputOutputGroup InputOutputGroup1
        {
            get { return AccessProfileInputOutputGroups.FirstOrDefault(o => o.OrderNumber == 1); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 2. </summary>
        ///
        /// <value> The access group 2. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileInputOutputGroup InputOutputGroup2
        {
            get { return AccessProfileInputOutputGroups.FirstOrDefault(o => o.OrderNumber == 2); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 3. </summary>
        ///
        /// <value> The access group 3. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileInputOutputGroup InputOutputGroup3
        {
            get { return AccessProfileInputOutputGroups.FirstOrDefault(o => o.OrderNumber == 3); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 4. </summary>
        ///
        /// <value> The access group 4. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileInputOutputGroup InputOutputGroup4
        {
            get { return AccessProfileInputOutputGroups.FirstOrDefault(o => o.OrderNumber == 4); }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Ensures that groups exist. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void EnsureGroupsExist()
        {
            AccessGroupSelectionItemBasic noAccess = null;
            InputOutputGroupSelectionItemBasic noIOG = null;

            if (ClusterSelectionItem.AccessGroups != null)
                noAccess = ClusterSelectionItem.AccessGroups.FirstOrDefault(o => o.AccessGroupNumber == GalaxySMS.Common.Constants.AccessGroupLimits.None);
            if (ClusterSelectionItem.InputOutputGroups != null)
                noIOG = ClusterSelectionItem.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupNumber == GalaxySMS.Common.Constants.InputOutputGroupLimits.None);

            // Ensure that there are 4 access groups and input output groups in each collection
            for (short g = 1; g <= 4; g++)
            {
                var ag = AccessProfileAccessGroups.FirstOrDefault(o => o.OrderNumber == g);
                if (ag == null)
                {
                    ag = new AccessProfileAccessGroup() { OrderNumber = g };
                    if (noAccess != null)
                        ag.AccessGroupUid = noAccess.AccessGroupUid;
                    AccessProfileAccessGroups.Add(ag);
                }
                else if (ag.AccessGroupUid == Guid.Empty && noAccess != null)
                {
                    ag.AccessGroupUid = noAccess.AccessGroupUid;
                }

                var iog = AccessProfileInputOutputGroups.FirstOrDefault(o => o.OrderNumber == g);
                if (iog == null)
                {
                    iog = new AccessProfileInputOutputGroup() { OrderNumber = g };
                    if (noIOG != null)
                        iog.InputOutputGroupUid = noIOG.InputOutputGroupUid;
                    AccessProfileInputOutputGroups.Add(iog);
                }
                else if (iog.InputOutputGroupUid == Guid.Empty && noIOG != null)
                {
                    iog.InputOutputGroupUid = noIOG.InputOutputGroupUid;
                }



            }

            OnPropertyChanged(() => AccessGroup1, false);
            OnPropertyChanged(() => AccessGroup2, false);
            OnPropertyChanged(() => AccessGroup3, false);
            OnPropertyChanged(() => AccessGroup4, false);
            OnPropertyChanged(() => InputOutputGroup1, false);
            OnPropertyChanged(() => InputOutputGroup2, false);
            OnPropertyChanged(() => InputOutputGroup3, false);
            OnPropertyChanged(() => InputOutputGroup4, false);

        }

        //        public void Initialize(ClusterSelectionItem clusterSelectionItem, SiteSelectionItem siteSelectionItem, RegionSelectionItem regionSelectionItem)
        public void Initialize(ClusterSelectionItemBasic clusterSelectionItem, SiteSelectionItemBasic siteSelectionItem, RegionSelectionItemBasic regionSelectionItem)
        {
            Initialize();

            if (clusterSelectionItem == null)
                return;

            this.ClusterSelectionItem = clusterSelectionItem;

            this.ClusterUid = clusterSelectionItem.ClusterUid;
            this.ClusterName = clusterSelectionItem.ClusterName;
            this.ClusterImage = clusterSelectionItem.Photo;
            //this.AccessGroupNonExtendedSelectionItems = clusterSelectionItem.AccessGroups.Where(i => i.IsExtendedAccessGroup == false && i.AccessGroupNumber < GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup).ToObservableCollection();
            //this.AccessGroupWithExtendedSelectionItems = clusterSelectionItem.AccessGroups.Where(i => i.AccessGroupNumber < GalaxySMS.Common.Constants.AccessGroupLimits.PersonalAccessGroup).ToObservableCollection();
            //this.AccessGroupWithPersonalAccessGroupSelectionItems = clusterSelectionItem.AccessGroups.ToObservableCollection();
            //this.InputOutputGroupSelectionItems = clusterSelectionItem.InputOutputGroups.ToObservableCollection();

            if (siteSelectionItem != null)
            {
                this.SiteName = siteSelectionItem.SiteName;
                this.SiteImage = siteSelectionItem.BinaryResource;
            }

            if (regionSelectionItem != null)
            {
                this.RegionName = regionSelectionItem.RegionName;
                this.RegionImage = regionSelectionItem.BinaryResource;
            }


            EnsureGroupsExist();

            //this.PersonClusterPermissionUid = Guid.Empty;
            //this.PersonUid = Guid.Empty;
            //this.PersonCredentialUid = Guid.Empty;
            //this.InsertName = e.InsertName;
            //this.InsertDate = e.InsertDate;
            //this.UpdateName = e.UpdateName;
            //this.UpdateDate = e.UpdateDate;
            //this.ConcurrencyValue = e.ConcurrencyValue;
            //this.CredentialClusterTourUid = e.CredentialClusterTourUid;
            //this.CredentialBits = e.CredentialBits;
            //this.PersonAccessGroups = e.PersonAccessGroups.ToCollection();
            //this.PersonInputOutputGroups = e.PersonInputOutputGroups.ToCollection();

        }

    }
}
