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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person summary. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PersonLastUsageData : DbObjectBase
    {

        private DateTimeOffset _time;

        [DataMember]
        public DateTimeOffset Time
        {
            get { return _time; }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    OnPropertyChanged(() => Time, false);
                }
            }
        }



        private string _siteName;

        [DataMember]

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


        private string _ClusterName;

        [DataMember]
        public string ClusterName
        {
            get { return _ClusterName; }
            set
            {
                if (_ClusterName != value)
                {
                    _ClusterName = value;
                    OnPropertyChanged(() => ClusterName, false);
                }
            }
        }


        private string _AccessPortalName;

        [DataMember]
        public string AccessPortalName
        {
            get { return _AccessPortalName; }
            set
            {
                if (_AccessPortalName != value)
                {
                    _AccessPortalName = value;
                    OnPropertyChanged(() => AccessPortalName, false);
                }
            }
        }




        private string _CredentialName;

        [DataMember]
        public string CredentialName
        {
            get { return _CredentialName; }
            set
            {
                if (_CredentialName != value)
                {
                    _CredentialName = value;
                    OnPropertyChanged(() => CredentialName, false);
                }
            }
        }

    }

    public class PersonSummary : DbObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonSummary()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The Person to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonSummary(Person p)
        {
            Initialize(p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonSummary. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The Person to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(Person p)
        {
            if (p != null)
            {
                PersonUid = p.PersonUid;
                PersonId = p.PersonId;
                FirstName = p.FirstName;
                MiddleName = p.MiddleName;
                LastName = p.LastName;
                NickName = p.NickName;
                LegalName = p.LegalName;
                FullName = p.FullName;
                PreferredName = p.PreferredName;
                Company = p.Company;
                Trace = p.Trace;
                VeryImportantPerson = p.VeryImportantPerson;
                HasPhysicalDisability = p.HasPhysicalDisability;
                //EntityName = p.EntityName;
                EntityId = p.EntityId;
                //DepartmentName = p.DepartmentName;
                //ActiveStatus = p.ActiveStatus;
                //RecordType = p.RecordType;
                ActivationDateTime = p.ActivationDateTime;
                ExpirationDateTime = p.ExpirationDateTime;
                SysGalEmployeeId = p.SysGalEmployeeId;
                InsertName = p.InsertName;
                InsertDate = p.InsertDate;
                UpdateName = p.UpdateName;
                UpdateDate = p.UpdateDate;

                if (p.PersonPhotos != null)
                    Photo = p.PersonPhotos.FirstOrDefault();
                if (p.Photos != null)
                {
                    this.PhotoUrls = p.Photos.FirstOrDefault();
                    if (this.PhotoUrls != null)
                        this.SmallPhotoURL = PhotoUrls.Small;

                }
            }
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
            if (string.IsNullOrEmpty(FullName) == false)
                return FullName;

            return $"{FirstName} {LastName}";
        }

        /// <summary>   The person UID. </summary>
        private Guid _PersonUid;
        [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person UID. </summary>
        ///
        /// <value> The person UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person UID. </summary>
        ///
        /// <value> The person UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person UID. </summary>
        ///
        /// <value> The person UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person UID. </summary>
        ///
        /// <value> The person UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid PersonUid
        {
            get { return _PersonUid; }
            set
            {
                if (_PersonUid != value)
                {
                    _PersonUid = value;
                    OnPropertyChanged(() => PersonUid, false);
                }
            }
        }

        /// <summary>   Identifier for the person. </summary>
        private string _PersonId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the person. </summary>
        ///
        /// <value> The identifier of the person. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string PersonId
        {
            get { return _PersonId; }
            set
            {
                if (_PersonId != value)
                {
                    _PersonId = value;
                    OnPropertyChanged(() => PersonId, false);
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

        /// <summary>   The person's middle name. </summary>
        private string _MiddleName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's middle name. </summary>
        ///
        /// <value> The name of the middle. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (_MiddleName != value)
                {
                    _MiddleName = value;
                    OnPropertyChanged(() => MiddleName, false);
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

        /// <summary>   Name of the nick. </summary>
        private string _NickName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the nick. </summary>
        ///
        /// <value> The name of the nick. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string NickName
        {
            get { return _NickName; }
            set
            {
                if (_NickName != value)
                {
                    _NickName = value;
                    OnPropertyChanged(() => NickName, false);
                }
            }
        }

        /// <summary>   Name of the legal. </summary>
        private string _LegalName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the legal. </summary>
        ///
        /// <value> The name of the legal. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string LegalName
        {
            get { return _LegalName; }
            set
            {
                if (_LegalName != value)
                {
                    _LegalName = value;
                    OnPropertyChanged(() => LegalName, false);
                }
            }
        }

        /// <summary>   Name of the full. </summary>
        private string _FullName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the full. </summary>
        ///
        /// <value> The name of the full. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string FullName
        {
            get { return _FullName; }
            set
            {
                if (_FullName != value)
                {
                    _FullName = value;
                    OnPropertyChanged(() => FullName, false);
                }
            }
        }

        /// <summary>   Name of the preferred. </summary>
        private string _PreferredName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the preferred. </summary>
        ///
        /// <value> The name of the preferred. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string PreferredName
        {
            get { return _PreferredName; }
            set
            {
                if (_PreferredName != value)
                {
                    _PreferredName = value;
                    OnPropertyChanged(() => PreferredName, false);
                }
            }
        }

        /// <summary>   The company. </summary>
        private string _Company;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the company. </summary>
        ///
        /// <value> The company. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Company
        {
            get { return _Company; }
            set
            {
                if (_Company != value)
                {
                    _Company = value;
                    OnPropertyChanged(() => Company, false);
                }
            }
        }

        /// <summary>   True to trace. </summary>
        private bool _Trace;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the trace. </summary>
        ///
        /// <value> True if trace, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool Trace
        {
            get { return _Trace; }
            set
            {
                if (_Trace != value)
                {
                    _Trace = value;
                    OnPropertyChanged(() => Trace, false);
                }
            }
        }


        /// <summary>   True to very important person. </summary>
        private bool _VeryImportantPerson;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the very important person. </summary>
        ///
        /// <value> True if very important person, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool VeryImportantPerson
        {
            get { return _VeryImportantPerson; }
            set
            {
                if (_VeryImportantPerson != value)
                {
                    _VeryImportantPerson = value;
                    OnPropertyChanged(() => VeryImportantPerson, false);
                }
            }
        }

        /// <summary>   True if this PersonSummary has physical disability. </summary>
        private bool _HasPhysicalDisability;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this PersonSummary has physical disability.
        /// </summary>
        ///
        /// <value> True if this PersonSummary has physical disability, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool HasPhysicalDisability
        {
            get { return _HasPhysicalDisability; }
            set
            {
                if (_HasPhysicalDisability != value)
                {
                    _HasPhysicalDisability = value;
                    OnPropertyChanged(() => HasPhysicalDisability, false);
                }
            }
        }

        /// <summary>   Name of the entity. </summary>
        private string _EntityName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the entity. </summary>
        ///
        /// <value> The name of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EntityName
        {
            get { return _EntityName; }
            set
            {
                if (_EntityName != value)
                {
                    _EntityName = value;
                    OnPropertyChanged(() => EntityName, false);
                }
            }
        }

        /// <summary>   Identifier for the entity. </summary>
        private Guid _EntityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _EntityId; }
            set
            {
                if (_EntityId != value)
                {
                    _EntityId = value;
                    OnPropertyChanged(() => EntityId, false);
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

        /// <summary>   The active status. </summary>
        private string _ActiveStatus;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the active status. </summary>
        ///
        /// <value> The active status. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ActiveStatus
        {
            get { return _ActiveStatus; }
            set
            {
                if (_ActiveStatus != value)
                {
                    _ActiveStatus = value;
                    OnPropertyChanged(() => ActiveStatus, false);
                }
            }
        }

        /// <summary>   Type of the record. </summary>
        private string _RecordType;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the record. </summary>
        ///
        /// <value> The type of the record. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string RecordType
        {
            get { return _RecordType; }
            set
            {
                if (_RecordType != value)
                {
                    _RecordType = value;
                    OnPropertyChanged(() => RecordType, false);
                }
            }
        }

        /// <summary>   The activation date time. </summary>
        private Nullable<DateTimeOffset> _ActivationDateTime;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the activation date time. </summary>
        ///
        /// <value> The activation date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<DateTimeOffset> ActivationDateTime
        {
            get { return _ActivationDateTime; }
            set
            {
                if (_ActivationDateTime != value)
                {
                    _ActivationDateTime = value;
                    OnPropertyChanged(() => ActivationDateTime, false);
                }
            }
        }

        /// <summary>   The expiration date time. </summary>
        private Nullable<DateTimeOffset> _ExpirationDateTime;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the expiration date time. </summary>
        ///
        /// <value> The expiration date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<DateTimeOffset> ExpirationDateTime
        {
            get { return _ExpirationDateTime; }
            set
            {
                if (_ExpirationDateTime != value)
                {
                    _ExpirationDateTime = value;
                    OnPropertyChanged(() => ExpirationDateTime, false);
                }
            }
        }


        [DataMember]
        public Nullable<int> SysGalEmployeeId
        {
            get { return _sysGalEmployeeId; }
            set
            {
                if (_sysGalEmployeeId != value)
                {
                    _sysGalEmployeeId = value;
                    OnPropertyChanged(() => SysGalEmployeeId);
                }
            }
        }

        /// <summary>   Name of the insert. </summary>
        private string _InsertName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the insert. </summary>
        ///
        /// <value> The name of the insert. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string InsertName
        {
            get { return _InsertName; }
            set
            {
                if (_InsertName != value)
                {
                    _InsertName = value;
                    OnPropertyChanged(() => InsertName, false);
                }
            }
        }


        /// <summary>   The insert date. </summary>
        private DateTimeOffset _InsertDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the insert date. </summary>
        ///
        /// <value> The insert date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset InsertDate
        {
            get { return _InsertDate; }
            set
            {
                if (_InsertDate != value)
                {
                    _InsertDate = value;
                    OnPropertyChanged(() => InsertDate, false);
                }
            }
        }

        /// <summary>   Name of the update. </summary>
        private string _UpdateName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the update. </summary>
        ///
        /// <value> The name of the update. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UpdateName
        {
            get { return _UpdateName; }
            set
            {
                if (_UpdateName != value)
                {
                    _UpdateName = value;
                    OnPropertyChanged(() => UpdateName, false);
                }
            }
        }

        /// <summary>   The update. </summary>
        private Nullable<DateTimeOffset> _UpdateDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the update. </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<DateTimeOffset> UpdateDate
        {
            get { return _UpdateDate; }
            set
            {
                if (_UpdateDate != value)
                {
                    _UpdateDate = value;
                    OnPropertyChanged(() => UpdateDate, false);
                }
            }
        }

        /// <summary>   The photo. </summary>
        private PersonPhoto _Photo;

        private int? _sysGalEmployeeId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the photo. </summary>
        ///
        /// <value> The photo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public PersonPhoto Photo
        {
            get { return _Photo; }
            set
            {
                if (_Photo != value)
                {
                    _Photo = value;
                    OnPropertyChanged(() => Photo, false);
                }
            }
        }

        private PhotoLinks _photoUrls;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the photo urls. </summary>
        ///
        /// <value> The photo urls. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember]

        public PhotoLinks PhotoUrls
        {
            get { return _photoUrls; }
            set
            {
                if (_photoUrls != value)
                {
                    _photoUrls = value;
                    OnPropertyChanged(() => PhotoUrls, false);
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



        //private bool _isPersonActive;

        //[DataMember]
        //public bool IsPersonActive
        //{
        //    get { return _isPersonActive; }
        //    set
        //    {
        //        if (_isPersonActive != value)
        //        {
        //            _isPersonActive = value;
        //            OnPropertyChanged(() => IsPersonActive);
        //        }
        //    }
        //}

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

        private PersonActiveStatusSummaryCodes _activeStatusCode;

        [DataMember]
        public PersonActiveStatusSummaryCodes ActiveStatusCode
        {
            get { return _activeStatusCode; }
            set
            {
                if (_activeStatusCode != value)
                {
                    _activeStatusCode = value;
                    OnPropertyChanged(() => ActiveStatusCode, false);
                }
            }
        }

    }

}
