////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\PersonClusterPermission.cs
//
// summary:	Implements the person cluster permission class
////////////////////////////////////////////////////////////////////////////////////////////////////

using FluentValidation;
using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Person cluster permission descriptor. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class PersonClusterPermission
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonClusterPermission() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonClusterPermission to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonClusterPermission(PersonClusterPermission e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonClusterPermission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();

            CreatePersonAccessGroupRecords();
            CreatePersonInputOutputGroupRecords();
            if (PersonPersonalAccessGroup == null)
                this.PersonPersonalAccessGroup = new PersonPersonalAccessGroup();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates person access group records. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CreatePersonAccessGroupRecords()
        {
            if (PersonAccessGroups == null)
                this.PersonAccessGroups = new HashSet<PersonAccessGroup>();
            for (short g = 1; g <= 4; g++)
            {
                if (PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == g) == null)
                    this.PersonAccessGroups.Add(new PersonAccessGroup() { OrderNumber = g, });
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates person input output group records. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CreatePersonInputOutputGroupRecords()
        {
            if (PersonInputOutputGroups == null)
                this.PersonInputOutputGroups = new HashSet<PersonInputOutputGroup>();
            for (short g = 1; g <= 4; g++)
            {
                if (PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == g) == null)
                    this.PersonInputOutputGroups.Add(new PersonInputOutputGroup() { OrderNumber = g, });
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonClusterPermission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonClusterPermission to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(PersonClusterPermission e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.PersonClusterPermissionUid = e.PersonClusterPermissionUid;
            this.PersonUid = e.PersonUid;
            this.ClusterUid = e.ClusterUid;
            this.PersonCredentialUid = e.PersonCredentialUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.CredentialClusterTourUid = e.CredentialClusterTourUid;
            this.CredentialBits = e.CredentialBits;
            this.PersonAccessGroups = e.PersonAccessGroups.ToCollection();
            this.PersonInputOutputGroups = e.PersonInputOutputGroups.ToCollection();
            this.PersonPersonalAccessGroup = e.PersonPersonalAccessGroup;

            EnsureGroupsExist();

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
                var ag = PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == g);
                if (ag == null)
                {
                    ag = new PersonAccessGroup() { OrderNumber = g };
                    if (noAccess != null)
                        ag.AccessGroupUid = noAccess.AccessGroupUid;
                    PersonAccessGroups.Add(ag);
                }
                else if (ag.AccessGroupUid == Guid.Empty && noAccess != null)
                {
                    ag.AccessGroupUid = noAccess.AccessGroupUid;
                }

                var iog = PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == g);
                if (iog == null)
                {
                    iog = new PersonInputOutputGroup() { OrderNumber = g };
                    if (noIOG != null)
                        iog.InputOutputGroupUid = noIOG.InputOutputGroupUid;
                    PersonInputOutputGroups.Add(iog);
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonClusterPermission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="clusterSelectionItem"> The cluster selection item. </param>
        /// <param name="siteSelectionItem">    The site selection item. </param>
        /// <param name="regionSelectionItem">  The region selection item. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

            //this.AccessPortalsNotAuthorized = ClusterSelectionItem.AccessPortals.Where(o => !this.PersonPersonalAccessGroup.AccessPortalUids.Contains(o.AccessPortalUid)).ToObservableCollection();
            //this.AccessPortalsAuthorized = ClusterSelectionItem.AccessPortals.Where(o => this.PersonPersonalAccessGroup.AccessPortalUids.Contains(o.AccessPortalUid)).ToObservableCollection();
            //this.AccessGroupsNotAuthorized = ClusterSelectionItem.AccessGroupWithExtendedSelectionItems.Where(o => !this.PersonPersonalAccessGroup.DynamicAccessGroupUids.Contains(o.AccessGroupUid)).ToObservableCollection();
            //this.AccessGroupsAuthorized = ClusterSelectionItem.AccessGroupWithExtendedSelectionItems.Where(o => this.PersonPersonalAccessGroup.DynamicAccessGroupUids.Contains(o.AccessGroupUid)).ToObservableCollection();

            this.AccessPortalsNotAuthorized =
                ClusterSelectionItem.AccessPortals.Where(o => !this.PersonPersonalAccessGroup.AccessPortals.Select(x=>x.AccessPortalUid).Contains(o.AccessPortalUid)).ToObservableCollection();
            this.AccessPortalsAuthorized = ClusterSelectionItem.AccessPortals.Where(o => this.PersonPersonalAccessGroup.AccessPortals.Select(x => x.AccessPortalUid).Contains(o.AccessPortalUid)).ToObservableCollection();
            this.AccessGroupsNotAuthorized = ClusterSelectionItem.AccessGroupWithExtendedSelectionItems.Where(o => !this.PersonPersonalAccessGroup.DynamicAccessGroups.Select(x => x.AccessGroupUid).Contains(o.AccessGroupUid)).ToObservableCollection();
            this.AccessGroupsAuthorized = ClusterSelectionItem.AccessGroupWithExtendedSelectionItems.Where(o => this.PersonPersonalAccessGroup.DynamicAccessGroups.Select(x => x.AccessGroupUid).Contains(o.AccessGroupUid)).ToObservableCollection();

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this PersonClusterPermission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonClusterPermission to process. </param>
        ///
        /// <returns>   A copy of this PersonClusterPermission. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonClusterPermission Clone(PersonClusterPermission e)
        {
            return new PersonClusterPermission(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this PersonClusterPermission is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(PersonClusterPermission other)
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

        public bool IsPrimaryKeyEqual(PersonClusterPermission other)
        {
            if (other == null)
                return false;

            if (other.PersonClusterPermissionUid != this.PersonClusterPermissionUid)
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

        //private ObservableCollection<AccessGroupSelectionItem> _accessGroupNonExtendedSelectionItems;

        //public ObservableCollection<AccessGroupSelectionItem> AccessGroupNonExtendedSelectionItems
        //{
        //    get { return _accessGroupNonExtendedSelectionItems; }
        //    set
        //    {
        //        if (_accessGroupNonExtendedSelectionItems != value)
        //        {
        //            _accessGroupNonExtendedSelectionItems = value;
        //            OnPropertyChanged(() => AccessGroupNonExtendedSelectionItems, false);
        //        }
        //    }
        //}

        //private ObservableCollection<AccessGroupSelectionItem> _accessGroupWithAccessGroupSelectionItems;

        //public ObservableCollection<AccessGroupSelectionItem> AccessGroupWithExtendedSelectionItems
        //{
        //    get { return _accessGroupWithAccessGroupSelectionItems; }
        //    set
        //    {
        //        if (_accessGroupWithAccessGroupSelectionItems != value)
        //        {
        //            _accessGroupWithAccessGroupSelectionItems = value;
        //            OnPropertyChanged(() => AccessGroupWithExtendedSelectionItems, false);
        //        }
        //    }
        //}

        //private ObservableCollection<AccessGroupSelectionItem> _accessGroupWithPersonalAccessGroupSelectionItems;

        //public ObservableCollection<AccessGroupSelectionItem> AccessGroupWithPersonalAccessGroupSelectionItems
        //{
        //    get { return _accessGroupWithPersonalAccessGroupSelectionItems; }
        //    set
        //    {
        //        if (_accessGroupWithPersonalAccessGroupSelectionItems != value)
        //        {
        //            _accessGroupWithPersonalAccessGroupSelectionItems = value;
        //            OnPropertyChanged(() => AccessGroupWithPersonalAccessGroupSelectionItems, false);
        //        }
        //    }
        //}

        //private ObservableCollection<InputOutputGroupSelectionItem> _inputOutputGroupSelectionItems;

        //public ObservableCollection<InputOutputGroupSelectionItem> InputOutputGroupSelectionItems
        //{
        //    get { return _inputOutputGroupSelectionItems; }
        //    set
        //    {
        //        if (_inputOutputGroupSelectionItems != value)
        //        {
        //            _inputOutputGroupSelectionItems = value;
        //            OnPropertyChanged(() => InputOutputGroupSelectionItems, false);
        //        }
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 1. </summary>
        ///
        /// <value> The access group 1. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonAccessGroup AccessGroup1
        {
            get { return PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == 1); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 2. </summary>
        ///
        /// <value> The access group 2. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonAccessGroup AccessGroup2
        {
            get { return PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == 2); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 3. </summary>
        ///
        /// <value> The access group 3. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonAccessGroup AccessGroup3
        {
            get { return PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == 3); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access group 4. </summary>
        ///
        /// <value> The access group 4. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonAccessGroup AccessGroup4
        {
            get { return PersonAccessGroups.FirstOrDefault(o => o.OrderNumber == 4); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the input output group 1. </summary>
        ///
        /// <value> The input output group 1. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonInputOutputGroup InputOutputGroup1
        {
            get { return PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == 1); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the input output group 2. </summary>
        ///
        /// <value> The input output group 2. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonInputOutputGroup InputOutputGroup2
        {
            get { return PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == 2); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the input output group 3. </summary>
        ///
        /// <value> The input output group 3. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonInputOutputGroup InputOutputGroup3
        {
            get { return PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == 3); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the input output group 4. </summary>
        ///
        /// <value> The input output group 4. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonInputOutputGroup InputOutputGroup4
        {
            get { return PersonInputOutputGroups.FirstOrDefault(o => o.OrderNumber == 4); }
        }

        /// <summary>   The access portals not authorized. </summary>
        private ObservableCollection<AccessPortalSelectionItemBasic> _accessPortalsNotAuthorized;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portals not authorized. </summary>
        ///
        /// <value> The access portals not authorized. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessPortalSelectionItemBasic> AccessPortalsNotAuthorized
        {
            get { return _accessPortalsNotAuthorized; }// => ClusterSelectionItem.AccessPortals.Where(o => o.Selected == false).ToObservableCollection();
            set
            {
                if (_accessPortalsNotAuthorized != value)
                {
                    _accessPortalsNotAuthorized = value;
                    OnPropertyChanged(() => AccessPortalsNotAuthorized, false);
                }
            }
        }

        /// <summary>   The selected personal access portals not authorized. </summary>
        private ObservableCollection<AccessPortalSelectionItemBasic> _selectedPersonalAccessPortalsNotAuthorized;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the selected personal access portals not authorized. </summary>
        ///
        /// <value> The selected personal access portals not authorized. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessPortalSelectionItemBasic> SelectedPersonalAccessPortalsNotAuthorized
        {
            get { return _selectedPersonalAccessPortalsNotAuthorized; }
            set
            {
                if (_selectedPersonalAccessPortalsNotAuthorized != value)
                {
                    _selectedPersonalAccessPortalsNotAuthorized = value;
                    OnPropertyChanged(() => SelectedPersonalAccessPortalsNotAuthorized, false);
                }
            }
        }

        /// <summary>   The selected personal access portals authorized. </summary>
        private ObservableCollection<AccessPortalSelectionItem> _selectedPersonalAccessPortalsAuthorized;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the selected personal access portals authorized. </summary>
        ///
        /// <value> The selected personal access portals authorized. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessPortalSelectionItem> SelectedPersonalAccessPortalsAuthorized
        {
            get { return _selectedPersonalAccessPortalsAuthorized; }
            set
            {
                if (_selectedPersonalAccessPortalsAuthorized != value)
                {
                    _selectedPersonalAccessPortalsAuthorized = value;
                    OnPropertyChanged(() => SelectedPersonalAccessPortalsAuthorized, false);
                }
            }
        }

        /// <summary>   The access portals authorized. </summary>
        private ObservableCollection<AccessPortalSelectionItemBasic> _accessPortalsAuthorized;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portals authorized. </summary>
        ///
        /// <value> The access portals authorized. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessPortalSelectionItemBasic> AccessPortalsAuthorized
        {
            get { return _accessPortalsAuthorized; } // => ClusterSelectionItem.AccessPortals.Where(o => o.Selected == true).ToObservableCollection();
            set
            {
                if (_accessPortalsAuthorized != value)
                {
                    _accessPortalsAuthorized = value;
                    OnPropertyChanged(() => AccessPortalsAuthorized, false);
                }
            }
        }




        /// <summary>   The selected personal access groups not authorized. </summary>
        private ObservableCollection<AccessGroupSelectionItem> _selectedPersonalAccessGroupsNotAuthorized;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the selected personal access groups not authorized. </summary>
        ///
        /// <value> The selected personal access groups not authorized. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessGroupSelectionItem> SelectedPersonalAccessGroupsNotAuthorized
        {
            get { return _selectedPersonalAccessGroupsNotAuthorized; }
            set
            {
                if (_selectedPersonalAccessGroupsNotAuthorized != value)
                {
                    _selectedPersonalAccessGroupsNotAuthorized = value;
                    OnPropertyChanged(() => SelectedPersonalAccessGroupsNotAuthorized, false);
                }
            }
        }

        /// <summary>   The selected personal access groups authorized. </summary>
        private ObservableCollection<AccessGroupSelectionItem> _selectedPersonalAccessGroupsAuthorized;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the selected personal access groups authorized. </summary>
        ///
        /// <value> The selected personal access groups authorized. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessGroupSelectionItem> SelectedPersonalAccessGroupsAuthorized
        {
            get { return _selectedPersonalAccessGroupsAuthorized; }
            set
            {
                if (_selectedPersonalAccessGroupsAuthorized != value)
                {
                    _selectedPersonalAccessGroupsAuthorized = value;
                    OnPropertyChanged(() => SelectedPersonalAccessGroupsAuthorized, false);
                }
            }
        }





        /// <summary>   The access groups not authorized. </summary>
        private ObservableCollection<AccessGroupSelectionItemBasic> _accessGroupsNotAuthorized;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access groups not authorized. </summary>
        ///
        /// <value> The access groups not authorized. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessGroupSelectionItemBasic> AccessGroupsNotAuthorized
        {
            get { return _accessGroupsNotAuthorized; } // => ClusterSelectionItem.AccessGroups.Where(o => o.Selected == false).ToObservableCollection();
            set
            {
                if (_accessGroupsNotAuthorized != value)
                {
                    _accessGroupsNotAuthorized = value;
                    OnPropertyChanged(() => AccessGroupsNotAuthorized, false);
                }
            }
        }

        /// <summary>   The access groups authorized. </summary>
        private ObservableCollection<AccessGroupSelectionItemBasic> _accessGroupsAuthorized;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access groups authorized. </summary>
        ///
        /// <value> The access groups authorized. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<AccessGroupSelectionItemBasic> AccessGroupsAuthorized
        {
            get { return _accessGroupsAuthorized; } // => ClusterSelectionItem.AccessGroups.Where(o => o.Selected == true).ToObservableCollection();
            set
            {
                if (_accessGroupsAuthorized != value)
                {
                    _accessGroupsAuthorized = value;
                    OnPropertyChanged(() => AccessGroupsAuthorized, false);
                }
            }
        }
    }
}
