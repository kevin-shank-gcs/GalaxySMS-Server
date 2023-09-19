////////////////////////////////////////////////////////////////////////////////////////////////////
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

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A search property. </summary>
    ///
    /// <remarks>   Kevin, 4/10/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif
    public class SearchProperty
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the table. </summary>
        ///
        /// <value> The name of the table. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TableName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the column. </summary>
        ///
        /// <value> The name of the column. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ColumnName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string value. </summary>
        ///
        /// <value> The string value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public string StringValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the int value. </summary>
        ///
        /// <value> The int value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public int IntValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the date time value. </summary>
        ///
        /// <value> The date time value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset DateTimeValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the value. </summary>
        ///
        /// <value> True if value, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public Boolean BoolValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique identifier value. </summary>
        ///
        /// <value> The unique identifier value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid GuidValue { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person summary search parameters. </summary>
    ///
    /// <remarks>   Kevin, 4/10/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif
    public class PersonSummarySearchParameters : GetParametersWithPhoto
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/10/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonSummarySearchParameters()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/10/2019. </remarks>
        ///
        /// <param name="o">    The PersonSummarySearchParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonSummarySearchParameters(PersonSummarySearchParameters o) : base(o)
        {
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
                //if( o.SearchProperties != null)
                //    SearchProperties = o.SearchProperties.ToList();
                this.AccessProfileUids = o.AccessProfileUids;
                this.ClusterUids = o.ClusterUids;
                this.DepartmentUids = o.DepartmentUids;
                this.PersonUids = o.PersonUids;
                this.PersonTypeUids = o.PersonTypeUids;
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
        /// <remarks>   Kevin, 4/10/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            base.Init();
            SearchType = PersonSearchType.ByLastFirstName;
            this.AccessProfileUids = new HashSet<Guid>();
            this.ClusterUids = new HashSet<Guid>();
            this.DepartmentUids = new HashSet<Guid>();
            this.PersonUids = new HashSet<Guid>();
            this.Emails = new HashSet<string>();
            this.PersonIds = new HashSet<string>();
            this.Phones = new HashSet<string>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the search. </summary>
        ///
        /// <value> The type of the search. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public PersonSearchType SearchType { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the search date time value. </summary>
        ///
        /// <value> The search date time value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset SearchDateTimeValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the search bool value. </summary>
        ///
        /// <value> True if search bool value, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool SearchBoolValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the search u int 64 value. </summary>
        ///
        /// <value> The search u int 64 value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt64 SearchUInt64Value { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the property. </summary>
        ///
        /// <value> The name of the property. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public string PropertyName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's last name. </summary>
        ///
        /// <value> The name of the last. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public string LastName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's first name. </summary>
        ///
        /// <value> The name of the first. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public string FirstName { get; set; }
        //public List<SearchProperty> SearchProperties { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the date comparison operator. </summary>
        ///
        /// <value> The date comparison operator. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public string DateComparisonOperator { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the search credential. </summary>
        ///
        /// <value> The search credential. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public Credential SearchCredential { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public TextSearchType TextSearchType { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public AndOr MultipleFieldSearchRelationship { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public List<string> PropertyNames { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public List<string> SearchTextValues { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public bool IncludeLastUsageData { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public PersonSortOrder SortBy { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public string QueryText { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public ICollection<Guid> DepartmentUids { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public ICollection<Guid> AccessProfileUids { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public ICollection<Guid> ClusterUids { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public Guid? GenderUid { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public string Gender { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public bool? IsActive { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public bool? HaveCredentials { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public bool? CanToggleLock { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public DateTimeOffset? ActivationStart { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public DateTimeOffset? ActivationEnd { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public DateTimeOffset? ExpirationStart { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public DateTimeOffset? ExpirationEnd { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public ICollection<string> PersonIds { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public ICollection<string> Emails { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public ICollection<string> Phones { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public bool? HasPhones { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public bool? HasEmail { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public ICollection<Guid> PersonUids { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public ICollection<Guid> PersonTypeUids { get; set; }

#if NetCoreApi
#else
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
#endif
        public DateTime? DateOfBirth { get; set; }
    }
}
