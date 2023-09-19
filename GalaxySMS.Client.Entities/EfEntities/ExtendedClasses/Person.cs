////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\Person.cs
//
// summary:	Implements the person class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Person
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Person() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The Person to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Person(Person e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this Person. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.PersonAddresses = new HashSet<PersonAddress>();
            this.PersonEmailAddresses = new HashSet<PersonEmailAddress>();
            this.PersonLcdMessages = new HashSet<PersonLcdMessage>();
            this.PersonNotes = new HashSet<PersonNote>();
            this.PersonPhoneNumbers = new HashSet<PersonPhoneNumber>();
            this.PersonPhotos = new ObservableCollection<PersonPhoto>();
            this.Photos = new ObservableCollection<PhotoLinks>();
            this.PersonPropertyBags = new HashSet<PersonPropertyBag>();
            this.Notes = new HashSet<Note>();
            this.PersonCredentials = new ObservableCollection<PersonCredential>();
            this.PersonClusterPermissions = new ObservableCollection<PersonClusterPermission>();
            this.PersonAccessControlProperty = new PersonAccessControlProperty();
            EntityIds = new HashSet<Guid>();
            MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this Person. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The Person to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(Person e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.PersonUid = e.PersonUid;
            this.CountryOfBirthUid = e.CountryOfBirthUid;
            this.PersonActiveStatusTypeUid = e.PersonActiveStatusTypeUid;
            this.GenderUid = e.GenderUid;
            this.DepartmentUid = e.DepartmentUid;
            this.PersonRecordTypeUid = e.PersonRecordTypeUid;
            this.EntityId = e.EntityId;
            this.RowOrigin = e.RowOrigin;
            this.OriginId = e.OriginId;
            this.PersonId = e.PersonId;
            this.FirstName = e.FirstName;
            this.MiddleName = e.MiddleName;
            this.LastName = e.LastName;
            this.Initials = e.Initials;
            this.NickName = e.NickName;
            this.LegalName = e.LegalName;
            this.FullName = e.FullName;
            this.PreferredName = e.PreferredName;
            this.Company = e.Company;
            this.HomeOfficeLocation = e.HomeOfficeLocation;
            this.JobTitle = e.JobTitle;
            this.Race = e.Race;
            this.Nationality = e.Nationality;
            this.Ethnicity = e.Ethnicity;
            this.PrimaryLanguage = e.PrimaryLanguage;
            this.SecondaryLanguage = e.SecondaryLanguage;
            this.NationalIdentificationNumber = e.NationalIdentificationNumber;
            this.DateOfBirth = e.DateOfBirth;
            this.EmploymentDate = e.EmploymentDate;
            this.TerminationDate = e.TerminationDate;
            this.ActivationDateTime = e.ActivationDateTime;
            this.ExpirationDateTime = e.ExpirationDateTime;
            this.Trace = e.Trace;
            this.TextData1 = e.TextData1;
            this.TextData2 = e.TextData2;
            this.TextData3 = e.TextData3;
            this.TextData4 = e.TextData4;
            this.TextData5 = e.TextData5;
            this.TextData6 = e.TextData6;
            this.TextData7 = e.TextData7;
            this.TextData8 = e.TextData8;
            this.TextData9 = e.TextData9;
            this.TextData10 = e.TextData10;
            this.TextData11 = e.TextData11;
            this.TextData12 = e.TextData12;
            this.TextData13 = e.TextData13;
            this.TextData14 = e.TextData14;
            this.TextData15 = e.TextData15;
            this.TextData16 = e.TextData16;
            this.TextData17 = e.TextData17;
            this.TextData18 = e.TextData18;
            this.TextData19 = e.TextData19;
            this.TextData20 = e.TextData20;
            this.TextData22 = e.TextData22;
            this.TextData23 = e.TextData23;
            this.TextData24 = e.TextData24;
            this.TextData25 = e.TextData25;
            this.TextData26 = e.TextData26;
            this.TextData27 = e.TextData27;
            this.TextData28 = e.TextData28;
            this.TextData29 = e.TextData29;
            this.TextData21 = e.TextData21;
            this.TextData30 = e.TextData30;
            this.TextData31 = e.TextData31;
            this.TextData32 = e.TextData32;
            this.TextData33 = e.TextData33;
            this.TextData34 = e.TextData34;
            this.TextData35 = e.TextData35;
            this.TextData36 = e.TextData36;
            this.TextData37 = e.TextData37;
            this.TextData38 = e.TextData38;
            this.TextData39 = e.TextData39;
            this.TextData40 = e.TextData40;
            this.TextData41 = e.TextData41;
            this.TextData42 = e.TextData42;
            this.TextData43 = e.TextData43;
            this.TextData44 = e.TextData44;
            this.TextData45 = e.TextData45;
            this.TextData46 = e.TextData46;
            this.TextData47 = e.TextData47;
            this.TextData48 = e.TextData48;
            this.TextData49 = e.TextData49;
            this.TextData50 = e.TextData50;
            this.SysGalEmployeeId = e.SysGalEmployeeId;
            this.VeryImportantPerson = e.VeryImportantPerson;
            this.HasPhysicalDisability = e.HasPhysicalDisability;
            this.HasVertigo = e.HasVertigo;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            this.PersonAccessControlProperty = e.PersonAccessControlProperty;
            this.PersonOtisElevator = e.PersonOtisElevator;
            //this.gcsEntity = e.gcsEntity;

            this.PersonAddresses = e.PersonAddresses.ToCollection();
            this.PersonEmailAddresses = e.PersonEmailAddresses.ToCollection();
            this.PersonLcdMessages = e.PersonLcdMessages.ToCollection();
            this.PersonNotes = e.PersonNotes.ToCollection();
            this.PersonPhoneNumbers = e.PersonPhoneNumbers.ToCollection();
            this.PersonPhotos = e.PersonPhotos.ToObservableCollection();
            this.Photos = e.Photos.ToObservableCollection();
            this.PersonPropertyBags = e.PersonPropertyBags.ToCollection();

            if (e.Notes != null)
                this.Notes = e.Notes.ToCollection();

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();

            if (e.PersonCredentials != null)
                this.PersonCredentials = e.PersonCredentials.ToObservableCollection();

            if (e.PersonClusterPermissions != null)
                this.PersonClusterPermissions = e.PersonClusterPermissions.ToObservableCollection();

            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this Person. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The Person to process. </param>
        ///
        /// <returns>   A copy of this Person. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Person Clone(Person e)
        {
            return new Person(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this Person is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(Person other)
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

        public bool IsPrimaryKeyEqual(Person other)
        {
            if (other == null)
                return false;

            if (other.PersonUid != this.PersonUid)
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
            if (string.IsNullOrEmpty(FullName) == false)
                return FullName;

            return $"{FirstName} {LastName}";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets person summary. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The person summary. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonSummary GetPersonSummary()
        {
            return new PersonSummary(this);

        }


        private ObservableCollection<PhotoLinks> _photos;

        [DataMember]
        public ObservableCollection<PhotoLinks> Photos
        {
            get { return _photos; }
            set
            {
                if (_photos != value)
                {
                    _photos = value;
                    OnPropertyChanged(() => Photos, false);
                }
            }
        }

        public PhotoLinks DefaultPhoto
        {
            get => Photos?.FirstOrDefault(o => o.IsDefault);
        }

    }
}
