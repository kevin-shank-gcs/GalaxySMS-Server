////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\PersonSearchType.cs
//
// summary:	Implements the person search type class
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent person search types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PersonSearchType
    {
        /// <summary>   An enum constant representing all records option. </summary>
        AllRecords,
        /// <summary>   An enum constant representing the by person UID option. </summary>
        ByPersonUid,
        /// <summary>   An enum constant representing the by person Identifier option. </summary>
        ByPersonId,
        /// <summary>   An enum constant representing the by person active status type UID option. </summary>
        ByPersonActiveStatusTypeUid,
        /// <summary>   An enum constant representing the by department UID option. </summary>
        ByDepartmentUid,
        /// <summary>   An enum constant representing the by person record type UID option. </summary>
        ByPersonRecordTypeUid,
        /// <summary>   An enum constant representing the by last first name option. </summary>
        ByLastFirstName,
        /// <summary>   An enum constant representing the by fields option. </summary>
        ByFields,
        /// <summary>   An enum constant representing the by credential number option. </summary>
        ByCredentialNumber,
        /// <summary>   An enum constant representing the by credential field values option. </summary>
        ByCredentialFieldValues,
        /// <summary>   An enum constant representing the by credential field value option. </summary>
        ByCredentialFieldValue,
        /// <summary>   An enum constant representing the by origin Identifier option. </summary>
        ByOriginId,
        /// <summary>   An enum constant representing the by last updated date option. </summary>
        ByLastUpdatedDate,
        /// <summary>   An enum constant representing the by access profile UID option. </summary>
        ByAccessProfileUid,
        /// <summary>   An enum constant representing the by any name field option. </summary>
        ByAnyNameField,
        /// <summary>   An enum constant representing the advanced search option. </summary>
        AdvancedSearch,
    }

    public enum PersonSortOrder
    {
        LastNameFirstName = 0,
        InsertDate = 1,
        UpdateDate = 2
    }
}
