//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Common.Enums;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class PersonBasic : EntityBaseSimple
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PersonUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> CountryOfBirthUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> PersonActiveStatusTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> GenderUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> DepartmentUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DepartmentName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> PersonRecordTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RowOrigin { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string OriginId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PersonId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MiddleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LastName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Initials { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string NickName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LegalName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FullName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PreferredName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Company { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string HomeOfficeLocation { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string JobTitle { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Race { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Nationality { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Ethnicity { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PrimaryLanguage { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SecondaryLanguage { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string NationalIdentificationNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTime> DateOfBirth { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTime> EmploymentDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTime> TerminationDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> ActivationDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> ExpirationDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool Trace { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData1 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData2 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData3 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData4 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData5 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData6 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData7 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData8 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData9 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData10 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData11 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData12 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData13 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData14 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData15 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData16 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData17 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData18 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData19 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData20 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData22 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData23 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData24 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData25 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData26 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData27 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData28 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData29 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData21 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData30 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData31 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData32 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData33 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData34 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData35 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData36 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData37 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData38 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData39 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData40 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData41 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData42 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData43 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData44 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData45 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData46 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData47 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData48 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData49 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TextData50 { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<int> SysGalEmployeeId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool VeryImportantPerson { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool HasPhysicalDisability { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool HasVertigo { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public gcsEntity gcsEntity { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PersonAccessControlPropertyBasic PersonAccessControlProperty { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PersonOtisElevatorBasic PersonOtisElevator { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Guid> EntityIds { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonAddressBasic> PersonAddresses { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonEmailAddressBasic> PersonEmailAddresses { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonLcdMessageBasic> PersonLcdMessages { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonNoteBasic> PersonNotes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonPhoneNumberBasic> PersonPhoneNumbers { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonPhotoBasic> PersonPhotos { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonPropertyBagBasic> PersonPropertyBags { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<NoteBasic> Notes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonCredentialBasic> PersonCredentials { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonClusterPermissionBasic> PersonClusterPermissions { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif        
        public PersonActiveStatusSummaryCodes ActiveStatusCode { get; set; }

    }
}
