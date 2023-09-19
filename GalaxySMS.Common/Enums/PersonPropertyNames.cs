////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\PersonPropertyNames.cs
//
// summary:	Implements the person property names class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent person standard property names. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PersonStandardPropertyNames
    {
        /// <summary>   An enum constant representing the person UID option. </summary>
        PersonUid,
        /// <summary>   An enum constant representing the country of birth UID option. </summary>
        CountryOfBirthUid,
        /// <summary>   An enum constant representing the person active status type UID option. </summary>
        PersonActiveStatusTypeUid,
        /// <summary>   An enum constant representing the gender UID option. </summary>
        GenderUid,
        /// <summary>   An enum constant representing the department UID option. </summary>
        DepartmentUid,
        /// <summary>   An enum constant representing the person record type UID option. </summary>
        PersonRecordTypeUid,
        /// <summary>   An enum constant representing the entity Identifier option. </summary>
        EntityId,
        /// <summary>   An enum constant representing the row origin option. </summary>
        RowOrigin,
        /// <summary>   An enum constant representing the origin Identifier option. </summary>
        OriginId,
        /// <summary>   An enum constant representing the person Identifier option. </summary>
        PersonId,
        /// <summary>   An enum constant representing the last name option. </summary>
        LastName,
        /// <summary>   An enum constant representing the first name option. </summary>
        FirstName,
        /// <summary>   An enum constant representing the middle name option. </summary>
        MiddleName,
        /// <summary>   An enum constant representing the initials option. </summary>
        Initials,
        /// <summary>   An enum constant representing the nick name option. </summary>
        NickName,
        /// <summary>   An enum constant representing the legal name option. </summary>
        LegalName,
        /// <summary>   An enum constant representing the full name option. </summary>
        FullName,
        /// <summary>   An enum constant representing the preferred name option. </summary>
        PreferredName,
        /// <summary>   An enum constant representing the company option. </summary>
        Company,
        /// <summary>   An enum constant representing the home office location option. </summary>
        HomeOfficeLocation,
        /// <summary>   An enum constant representing the job title option. </summary>
        JobTitle,
        /// <summary>   An enum constant representing the race option. </summary>
        Race,
        /// <summary>   An enum constant representing the nationality option. </summary>
        Nationality,
        /// <summary>   An enum constant representing the ethnicity option. </summary>
        Ethnicity,
        /// <summary>   An enum constant representing the primary language option. </summary>
        PrimaryLanguage,
        /// <summary>   An enum constant representing the secondary language option. </summary>
        SecondaryLanguage,
        /// <summary>   An enum constant representing the national identification number option. </summary>
        NationalIdentificationNumber,
        /// <summary>   An enum constant representing the date of birth option. </summary>
        DateOfBirth,
        /// <summary>   An enum constant representing the employment date option. </summary>
        EmploymentDate,
        /// <summary>   An enum constant representing the termination date option. </summary>
        TerminationDate,
        /// <summary>   An enum constant representing the activation date time option. </summary>
        ActivationDateTime,
        /// <summary>   An enum constant representing the expiration date time option. </summary>
        ExpirationDateTime,
        /// <summary>   An enum constant representing the trace option. </summary>
        Trace,
        /// <summary>   An enum constant representing the text data 1 option. </summary>
        TextData1,
        /// <summary>   An enum constant representing the text data 2 option. </summary>
        TextData2,
        /// <summary>   An enum constant representing the text data 3 option. </summary>
        TextData3,
        /// <summary>   An enum constant representing the text data 4 option. </summary>
        TextData4,
        /// <summary>   An enum constant representing the text data 5 option. </summary>
        TextData5,
        /// <summary>   An enum constant representing the text data 6 option. </summary>
        TextData6,
        /// <summary>   An enum constant representing the text data 7 option. </summary>
        TextData7,
        /// <summary>   An enum constant representing the text data 8 option. </summary>
        TextData8,
        /// <summary>   An enum constant representing the text data 9 option. </summary>
        TextData9,
        /// <summary>   An enum constant representing the text data 10 option. </summary>
        TextData10,
        /// <summary>   An enum constant representing the text data 11 option. </summary>
        TextData11,
        /// <summary>   An enum constant representing the text data 12 option. </summary>
        TextData12,
        /// <summary>   An enum constant representing the text data 13 option. </summary>
        TextData13,
        /// <summary>   An enum constant representing the text data 14 option. </summary>
        TextData14,
        /// <summary>   An enum constant representing the text data 15 option. </summary>
        TextData15,
        /// <summary>   An enum constant representing the text data 16 option. </summary>
        TextData16,
        /// <summary>   An enum constant representing the text data 17 option. </summary>
        TextData17,
        /// <summary>   An enum constant representing the text data 18 option. </summary>
        TextData18,
        /// <summary>   An enum constant representing the text data 19 option. </summary>
        TextData19,
        /// <summary>   An enum constant representing the text data 20 option. </summary>
        TextData20,
        /// <summary>   An enum constant representing the text data 22 option. </summary>
        TextData22,
        /// <summary>   An enum constant representing the text data 23 option. </summary>
        TextData23,
        /// <summary>   An enum constant representing the text data 24 option. </summary>
        TextData24,
        /// <summary>   An enum constant representing the text data 25 option. </summary>
        TextData25,
        /// <summary>   An enum constant representing the text data 26 option. </summary>
        TextData26,
        /// <summary>   An enum constant representing the text data 27 option. </summary>
        TextData27,
        /// <summary>   An enum constant representing the text data 28 option. </summary>
        TextData28,
        /// <summary>   An enum constant representing the text data 29 option. </summary>
        TextData29,
        /// <summary>   An enum constant representing the text data 21 option. </summary>
        TextData21,
        /// <summary>   An enum constant representing the text data 30 option. </summary>
        TextData30,
        /// <summary>   An enum constant representing the text data 31 option. </summary>
        TextData31,
        /// <summary>   An enum constant representing the text data 32 option. </summary>
        TextData32,
        /// <summary>   An enum constant representing the text data 33 option. </summary>
        TextData33,
        /// <summary>   An enum constant representing the text data 34 option. </summary>
        TextData34,
        /// <summary>   An enum constant representing the text data 35 option. </summary>
        TextData35,
        /// <summary>   An enum constant representing the text data 36 option. </summary>
        TextData36,
        /// <summary>   An enum constant representing the text data 37 option. </summary>
        TextData37,
        /// <summary>   An enum constant representing the text data 38 option. </summary>
        TextData38,
        /// <summary>   An enum constant representing the text data 39 option. </summary>
        TextData39,
        /// <summary>   An enum constant representing the text data 40 option. </summary>
        TextData40,
        /// <summary>   An enum constant representing the text data 41 option. </summary>
        TextData41,
        /// <summary>   An enum constant representing the text data 42 option. </summary>
        TextData42,
        /// <summary>   An enum constant representing the text data 43 option. </summary>
        TextData43,
        /// <summary>   An enum constant representing the text data 44 option. </summary>
        TextData44,
        /// <summary>   An enum constant representing the text data 45 option. </summary>
        TextData45,
        /// <summary>   An enum constant representing the text data 46 option. </summary>
        TextData46,
        /// <summary>   An enum constant representing the text data 47 option. </summary>
        TextData47,
        /// <summary>   An enum constant representing the text data 48 option. </summary>
        TextData48,
        /// <summary>   An enum constant representing the text data 49 option. </summary>
        TextData49,
        /// <summary>   An enum constant representing the text data 50 option. </summary>
        TextData50,
        /// <summary>   An enum constant representing the System gal employee Identifier option. </summary>
        SysGalEmployeeId,
        /// <summary>   An enum constant representing the very important person option. </summary>
        VeryImportantPerson,
        /// <summary>   An enum constant representing the has physical disability option. </summary>
        HasPhysicalDisability,
        /// <summary>   An enum constant representing the has vertigo option. </summary>
        HasVertigo,
        /// <summary>   An enum constant representing the insert name option. </summary>
        InsertName,
        /// <summary>   An enum constant representing the insert date option. </summary>
        InsertDate,
        /// <summary>   An enum constant representing the update name option. </summary>
        UpdateName,
        /// <summary>   An enum constant representing the update option. </summary>
        UpdateDate,
        /// <summary>   An enum constant representing the concurrency value option. </summary>
        ConcurrencyValue
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent person related property names. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PersonRelatedPropertyNames
    {
        /// <summary>   An enum constant representing the select item 1 option. </summary>
        SelectItem1,
        /// <summary>   An enum constant representing the select item 2 option. </summary>
        SelectItem2,
        /// <summary>   An enum constant representing the select item 3 option. </summary>
        SelectItem3,
        /// <summary>   An enum constant representing the select item 4 option. </summary>
        SelectItem4,
        /// <summary>   An enum constant representing the select item 5 option. </summary>
        SelectItem5,
        /// <summary>   An enum constant representing the select item 6 option. </summary>
        SelectItem6,
        /// <summary>   An enum constant representing the select item 7 option. </summary>
        SelectItem7,
        /// <summary>   An enum constant representing the select item 8 option. </summary>
        SelectItem8,
        /// <summary>   An enum constant representing the select item 9 option. </summary>
        SelectItem9,
        /// <summary>   An enum constant representing the select item 10 option. </summary>
        SelectItem10,
        /// <summary>   An enum constant representing the date 1 option. </summary>
        Date1,
        /// <summary>   An enum constant representing the date 2 option. </summary>
        Date2
    }
}
