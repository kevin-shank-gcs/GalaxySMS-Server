﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\PersonSearchParameters.cs
//
// summary:	Implements the person search parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Shared.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A search property. </summary>
    ///
    /// <remarks>   Kevin, 4/10/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SearchPropertyReq
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the table. </summary>
        ///
        /// <value> The name of the table. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string TableName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the column. </summary>
        ///
        /// <value> The name of the column. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ColumnName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string value. </summary>
        ///
        /// <value> The string value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string StringValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the int value. </summary>
        ///
        /// <value> The int value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int IntValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the date time value. </summary>
        ///
        /// <value> The date time value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset DateTimeValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the value. </summary>
        ///
        /// <value> True if value, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean BoolValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique identifier value. </summary>
        ///
        /// <value> The unique identifier value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid GuidValue { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person summary search parameters. </summary>
    ///
    /// <remarks>   Kevin, 4/10/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////


    public class PersonSummarySearchParametersReq //: GetParametersWithPhoto
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/10/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonSummarySearchParametersReq()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/10/2019. </remarks>
        ///
        /// <param name="o">    The PersonSummarySearchParameters to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonSummarySearchParametersReq(PersonSummarySearchParametersReq o)// : base(o)
        {
            Init();
            if (o != null)
            {
                SearchType = o.SearchType;
                SearchTextValue = o.SearchTextValue;
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
                PropertyNames = o.PropertyNames;
                SearchTextValues = o.SearchTextValues;
                IncludeLastUsageData = o.IncludeLastUsageData;
             //   OmitPhotoBinaryData = o.OmitPhotoBinaryData;
                IncludeScaledPhotos = o.IncludeScaledPhotos;
                IncludePhoto = o.IncludePhoto;
                //if( o.SearchProperties != null)
                //    SearchProperties = o.SearchProperties.ToList();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this PersonSummarySearchParameters. </summary>
        ///
        /// <remarks>   Kevin, 4/10/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            //          base.Init();
            SearchType = PersonSearchType.ByLastFirstName;
            PropertyNames = new List<string>();
            SearchTextValues = new List<string>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the search. </summary>
        ///
        /// <value> The type of the search. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //[EnumDataType(typeof(PersonSearchType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public PersonSearchType SearchType { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string/text value to search for. </summary>
        ///
        /// <value> The search text value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string SearchTextValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the search date time value. </summary>
        ///
        /// <value> The search date time value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset SearchDateTimeValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the search bool value. </summary>
        ///
        /// <value> True if search bool value, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


        public bool SearchBoolValue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the search u int 64 value. </summary>
        ///
        /// <value> The search u int 64 value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


        public UInt64 SearchUInt64Value { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the UID. </summary>
        ///
        /// <value> The UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid Uid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the property. </summary>
        ///
        /// <value> The name of the property. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PropertyName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's last name. </summary>
        ///
        /// <value> The name of the last. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////


        public string LastName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's first name. </summary>
        ///
        /// <value> The name of the first. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string FirstName { get; set; }
        //public List<SearchProperty> SearchProperties { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the date comparison operator. </summary>
        ///
        /// <value> The date comparison operator. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DateComparisonOperator { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the search credential. </summary>
        ///
        /// <value> The search credential. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialReq SearchCredential { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Specifies if the photo should be included in the response. </summary>
        ///
        /// <value> True = include photo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool IncludePhoto { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Specifies the width, in pixels, that the photo should be. 0 = original, full size. </summary>
        /////
        ///// <value> 0 = full size. Any other value will scale the image down to the requested width. The image will not be up-scaled from its original size.</value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //public int PhotoPixelWidth { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the include photo links. </summary>
        /////
        ///// <value> The include photo links. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public bool OmitPhotoBinaryData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the scaled photos should be included.
        /// </summary>
        ///
        /// <value> True if include scaled photos, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IncludeScaledPhotos { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the text search comparision requirement. </summary>
        ///
        /// <value> ExactMatch (0), StartsWith (1), Contains (2)
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public TextSearchType TextSearchType { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the multiple field search relationship. </summary>
        ///
        /// <value> AND (0), OR (1). AND means that all fields must be satisfied; OR means that at least one field must be satsified
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AndOr MultipleFieldSearchRelationship { get; set; }


        public List<string> PropertyNames { get; set; }

        public List<string> SearchTextValues { get; set; }
        public bool IncludeLastUsageData { get; set; }


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Specifies the Page number to return. 0 = the first page </summary>
        /////
        ///// <value> 0 = the first page.</value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //public int PageNumber { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Specifies the number of records per page. 0 = no paging, return all records </summary>
        /////
        ///// <value> 0 = no paging, Greater than 0 specifies how many records per page.</value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //public int PageSize { get; set; }

        //public bool OrNotAnd { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the query text. </summary>
        ///
        /// <value> The query text. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember] 
        public string QueryText { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the department uids. </summary>
        ///
        /// <value> The department uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember] 
        public ICollection<Guid> DepartmentUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access profiles uids. </summary>
        ///
        /// <value> The access profiles uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public ICollection<Guid> AccessProfileUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster uids. </summary>
        ///
        /// <value> The cluster uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public ICollection<Guid> ClusterUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gender UID. </summary>
        ///
        /// <value> The gender UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public Guid? GenderUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the is active. </summary>
        ///
        /// <value> The is active. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public bool? IsActive { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the has credentials. </summary>
        ///
        /// <value> The has credentials. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public bool? HaveCredentials { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the can toggle lock. </summary>
        ///
        /// <value> The can toggle lock. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public bool? CanToggleLock { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the activation start. </summary>
        ///
        /// <value> The activation start. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public DateTimeOffset? ActivationStart { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the activation end. </summary>
        ///
        /// <value> The activation end. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public DateTimeOffset? ActivationEnd { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the expiration start. </summary>
        ///
        /// <value> The expiration start. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public DateTimeOffset? ExpirationStart { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the expiration end. </summary>
        ///
        /// <value> The expiration end. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public DateTimeOffset? ExpirationEnd { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the persons. </summary>
        ///
        /// <value> A list of identifiers of the persons. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public ICollection<string> PersonIds { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the emails. </summary>
        ///
        /// <value> The emails. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public ICollection<string> Emails { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the phones. </summary>
        ///
        /// <value> The phones. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public ICollection<string> Phones { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this object has phones. </summary>
        ///
        /// <value> True if this object has phones, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public bool? HasPhones { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the has email. </summary>
        ///
        /// <value> The has email. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public bool? HasEmail { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person uids. </summary>
        ///
        /// <value> The person uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public ICollection<Guid> PersonUids { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the date of birth. </summary>
        ///
        /// <value> The date of birth. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [IgnoreDataMember]
        public DateTime? DateOfBirth { get; set; }
    }
}
