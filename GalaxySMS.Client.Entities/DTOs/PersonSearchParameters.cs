﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\PersonSearchParameters.cs
//
// summary:	Implements the person search parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A search property. </summary>
    ///
    /// <remarks>   Kevin, 10/28/2022. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SearchProperty
    {

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person summary search parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class PersonSummarySearchParameters : GetParametersWithPhoto
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonSummarySearchParameters()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The PersonSummarySearchParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonSummarySearchParameters(PersonSummarySearchParameters o) : base(o)
        {
            Init();
            if (o != null)
            {
                SearchType = o.SearchType;
                SearchCredential = o.SearchCredential;
                SearchDateTimeValue = o.SearchDateTimeValue;
                SearchBoolValue = o.SearchBoolValue;
                SearchUInt64Value = o.SearchUInt64Value;
                PropertyName = o.PropertyName;
                FirstName = o.FirstName;
                LastName = o.LastName;
                DateComparisonOperator = o.DateComparisonOperator;
                TextSearchType = o.TextSearchType;
                MultipleFieldSearchRelationship = o.MultipleFieldSearchRelationship;
                IncludeLastUsageData = o.IncludeLastUsageData;
                SortBy = o.SortBy;
                //if( o.SearchProperties != null)
                //    SearchProperties = o.SearchProperties.ToList();
                this.AccessProfileUids = o.AccessProfileUids;
                this.ClusterUids = o.ClusterUids;
                this.DepartmentUids = o.DepartmentUids;
                this.PersonUids = o.PersonUids;
                this.Emails = o.Emails;
                this.Phones = o.Phones;
                this.PersonIds = o.PersonIds;

                this.QueryText = o.QueryText;
                this.IsActive = o.IsActive;
                this.ActivationStart = o.ActivationStart;
                this.ActivationEnd = o.ActivationEnd;
                this.ExpirationStart = o.ExpirationStart;
                this.ExpirationEnd = o.ExpirationEnd;
                this.CanToggleLock = o.CanToggleLock;
                this.HaveCredentials = o.HaveCredentials;
                this.HasPhones = o.HasPhones;
                this.HasEmail = o.HasEmail;
                this.GenderUid = o.GenderUid;
                this.DateOfBirth = o.DateOfBirth;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonSummarySearchParameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            base.Init();
            SearchType = PersonSearchType.ByLastFirstName;
            this.AccessProfileUids = new ObservableCollection<Guid>();
            this.ClusterUids = new ObservableCollection<Guid>();
            this.DepartmentUids = new ObservableCollection<Guid>();
            this.PersonUids = new ObservableCollection<Guid>();
            this.Emails = new ObservableCollection<string>();
            this.PersonIds = new ObservableCollection<string>();
            this.Phones = new ObservableCollection<string>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the search. </summary>
        ///
        /// <value> The type of the search. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PersonSearchType SearchType { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the search person. </summary>
        /////
        ///// <value> The search person. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public Person SearchPerson { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the search credential. </summary>
        ///
        /// <value> The search credential. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Credential SearchCredential { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the search date time value. </summary>
        ///
        /// <value> The search date time value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset SearchDateTimeValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the search bool value. </summary>
        ///
        /// <value> True if search bool value, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool SearchBoolValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the search unsigned int 64 bit value. </summary>
        ///
        /// <value> The search unsigned int 64 bit value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt64 SearchUInt64Value { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the property. </summary>
        ///
        /// <value> The name of the property. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string PropertyName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's last name. </summary>
        ///
        /// <value> The name of the last. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string LastName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's first name. </summary>
        ///
        /// <value> The name of the first. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string FirstName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the date comparison operator. </summary>
        ///
        /// <value> The date comparison operator. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string DateComparisonOperator { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the text search. </summary>
        ///
        /// <value> The type of the text search. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public TextSearchType TextSearchType { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the multiple field search relationship. </summary>
        ///
        /// <value> The multiple field search relationship. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AndOr MultipleFieldSearchRelationship { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the last usage data should be included.
        /// </summary>
        ///
        /// <value> True if include last usage data, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IncludeLastUsageData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the amount to sort by. </summary>
        ///
        /// <value> Amount to sort by. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PersonSortOrder SortBy { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the query text. </summary>
        ///
        /// <value> The query text. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string QueryText { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the department uids. </summary>
        ///
        /// <value> The department uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<Guid> DepartmentUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access profiles uids. </summary>
        ///
        /// <value> The access profiles uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<Guid> AccessProfileUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster uids. </summary>
        ///
        /// <value> The cluster uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<Guid> ClusterUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gender UID. </summary>
        ///
        /// <value> The gender UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid? GenderUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the is active. </summary>
        ///
        /// <value> The is active. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool? IsActive { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the has credentials. </summary>
        ///
        /// <value> The has credentials. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool? HaveCredentials { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the can toggle lock. </summary>
        ///
        /// <value> The can toggle lock. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool? CanToggleLock { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the activation start. </summary>
        ///
        /// <value> The activation start. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset? ActivationStart { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the activation end. </summary>
        ///
        /// <value> The activation end. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset? ActivationEnd { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the expiration start. </summary>
        ///
        /// <value> The expiration start. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset? ExpirationStart { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the expiration end. </summary>
        ///
        /// <value> The expiration end. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset? ExpirationEnd { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the persons. </summary>
        ///
        /// <value> A list of identifiers of the persons. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<string> PersonIds { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the emails. </summary>
        ///
        /// <value> The emails. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<string> Emails { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the phones. </summary>
        ///
        /// <value> The phones. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<string> Phones { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this object has phones. </summary>
        ///
        /// <value> True if this object has phones, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool? HasPhones { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the has email. </summary>
        ///
        /// <value> The has email. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember]
        public bool? HasEmail { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person uids. </summary>
        ///
        /// <value> The person uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember]

        public ICollection<Guid> PersonUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the date of birth. </summary>
        ///
        /// <value> The date of birth. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember] 
        public DateTime? DateOfBirth { get; set; }
    }
}
