using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Person
    {
        public Person()
        {
            Initialize();
        }

        public Person(Person e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.PersonAddresses = new HashSet<PersonAddress>();
            this.PersonEmailAddresses = new HashSet<PersonEmailAddress>();
            this.PersonLcdMessages = new HashSet<PersonLcdMessage>();
            this.PersonNotes = new HashSet<PersonNote>();
            this.PersonPhoneNumbers = new HashSet<PersonPhoneNumber>();
            this.PersonPhotos = new HashSet<PersonPhoto>();
            this.PersonPropertyBags = new HashSet<PersonPropertyBag>();
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.Notes = new HashSet<Note>();
            this.PersonCredentials = new HashSet<PersonCredential>();
            this.PersonAccessControlProperty = new PersonAccessControlProperty();
            this.PersonClusterPermissions = new HashSet<PersonClusterPermission>();
        }

        public void Initialize(Person e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
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
            this.gcsEntity = e.gcsEntity;

            this.PersonAddresses = e.PersonAddresses.ToCollection();
            this.PersonEmailAddresses = e.PersonEmailAddresses.ToCollection();
            this.PersonLcdMessages = e.PersonLcdMessages.ToCollection();
            this.PersonNotes = e.PersonNotes.ToCollection();
            this.PersonPhoneNumbers = e.PersonPhoneNumbers.ToCollection();
            this.PersonPhotos = e.PersonPhotos.ToCollection();
            this.PersonPropertyBags = e.PersonPropertyBags.ToCollection();
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            if (e.PersonCredentials != null)
                this.PersonCredentials = e.PersonCredentials.ToCollection();
            if( e.PersonClusterPermissions != null)
                this.PersonClusterPermissions = e.PersonClusterPermissions.ToCollection();
        }

        public bool IsAnythingDirty
        {
            get
            {
                if( IsDirty)
                    return IsDirty;

                foreach( var o in PersonCredentials)
                {
                    if( o.IsAnythingDirty)
                        return true;
                }

                foreach (var o in PersonAddresses)
                {
                    if (o.IsAnythingDirty)
                        return true;
                }

                foreach (var o in PersonLcdMessages)
                {
                    if (o.IsAnythingDirty)
                        return true;
                }

                foreach (var o in PersonNotes)
                {
                    if (o.IsAnythingDirty)
                        return true;
                }

                foreach (var o in PersonPhoneNumbers)
                {
                    if (o.IsAnythingDirty)
                        return true;
                }
                foreach (var o in PersonPhotos)
                {
                    if (o.IsAnythingDirty)
                        return true;
                }
                foreach (var o in PersonPropertyBags)
                {
                    if (o.IsAnythingDirty)
                        return true;
                }
                
                return IsDirty;
            }
        }

        public Person Clone(Person e)
        {
            return new Person(e);
        }

        public bool Equals(Person other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Person other)
        {
            if (other == null)
                return false;

            if (other.PersonUid != this.PersonUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the person. </summary>
        ///
        /// <value> The name of the person. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PersonName => $"{FirstName} {MiddleName} {LastName}";
    }
}
