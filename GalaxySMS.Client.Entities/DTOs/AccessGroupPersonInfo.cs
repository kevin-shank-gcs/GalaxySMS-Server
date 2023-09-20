////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\PersonSummary.cs
//
// summary:	Implements the person summary class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    public class AccessGroupPersonInfo : DbObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessGroupPersonInfo()
        {

        }

        /// <summary>   The person UID. </summary>
        private Guid _id;
        [DataMember]


        public Guid Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(() => Id, false);
                }
            }
        }

        /// <summary>   The person's first name. </summary>
        private string _FirstName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's first name. </summary>
        ///
        /// <value> The name of the first. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged(() => FirstName, false);
                }
            }
        }


        /// <summary>   The person's last name. </summary>
        private string _LastName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's last name. </summary>
        ///
        /// <value> The name of the last. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged(() => LastName, false);
                }
            }
        }

        /// <summary>   Name of the department. </summary>
        private string _DepartmentName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the department. </summary>
        ///
        /// <value> The name of the department. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string DepartmentName
        {
            get { return _DepartmentName; }
            set
            {
                if (_DepartmentName != value)
                {
                    _DepartmentName = value;
                    OnPropertyChanged(() => DepartmentName, false);
                }
            }
        }

        private Guid _departmentUid;

        [DataMember]
        public Guid DepartmentUid
        {
            get { return _departmentUid; }
            set
            {
                if (_departmentUid != value)
                {
                    _departmentUid = value;
                    OnPropertyChanged(() => DepartmentUid, false);
                }
            }
        }


        private string _smallPhotoURL;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the default photo small. </summary>
        ///
        /// <value> The default photo small. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string SmallPhotoURL
        {
            get { return _smallPhotoURL; }
            set
            {
                if (_smallPhotoURL != value)
                {
                    _smallPhotoURL = value;
                    OnPropertyChanged(() => SmallPhotoURL, false);
                }
            }
        }


        private PersonActiveStatusSummaryCodes _activeStatusCode;

        [DataMember]
        public PersonActiveStatusSummaryCodes ActiveStatusCodeString
        {
            get { return _activeStatusCode; }
            set
            {
                if (_activeStatusCode != value)
                {
                    _activeStatusCode = value;
                    OnPropertyChanged(() => ActiveStatusCodeString, false);
                }
            }
        }

        private PersonLastUsageData personLastUsageData;

        [DataMember]
        public PersonLastUsageData LastUsageData
        {
            get { return personLastUsageData; }
            set
            {
                if (personLastUsageData != value)
                {
                    personLastUsageData = value;
                    OnPropertyChanged(() => LastUsageData, false);
                }
            }
        }
    }

}
