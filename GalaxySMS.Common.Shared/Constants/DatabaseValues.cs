////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\DatabaseValues.cs
//
// summary:	Implements the database values class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A schema names. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SchemaNames
    {
        /// <summary>   The gcs. </summary>
        public const string GCS = "GCS";
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A database names. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DatabaseNames
    {
        /// <summary>   The galaxy SMS. </summary>
        public const string GalaxySMS = "GalaxySMS";
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A table names. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TableNames
    {
        /// <summary>   The person list property item. </summary>
        public const string PersonListPropertyItem = "PersonListPropertyItem";
        /// <summary>   The person date property. </summary>
        public const string PersonDateProperty = "PersonDateProperty";

        /// <summary>   The person access control properties. </summary>
        public const string PersonAccessControlProperties = "PersonAccessControlProperties";

        /// <summary>   The person photo. </summary>
        public const string PersonPhoto = "PersonPhoto";
        public const string PersonCredential = "PersonCredential";
        public const string Credential = "Credential";
        public const string Credential26BitStandard = "Credential26BitStandard";
        public const string CredentialCorporate1K35Bit = "CredentialCorporate1K35Bit";
        public const string CredentialCorporate1K48Bit = "CredentialCorporate1K48Bit";
        public const string CredentialH1030237Bit = "CredentialH1030237Bit";
        public const string CredentialSoftwareHouse37Bit = "CredentialSoftwareHouse37Bit";
        public const string CredentialH1030437Bit = "CredentialH1030437Bit";
        public const string CredentialCypress37Bit = "CredentialCypress37Bit";
        public const string CredentialXceedId40Bit = "CredentialXceedId40Bit";
    }

    public class MagicStuff
    {

        /// <summary>   The magic date. </summary>
        public static DateTime MagicDate = new DateTime(1776, 7, 4);
    }
}
