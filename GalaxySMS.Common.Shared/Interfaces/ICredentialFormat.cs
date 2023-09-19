////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Interfaces\ICredentialFormat.cs
//
// summary:	Declares the ICredentialFormat interface
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Common.Interfaces
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for credential format definition. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface ICredentialFormatDefinition : ITableEntityBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the display. </summary>
        ///
        /// <value> The display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        string Display { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        string Description { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential format code. </summary>
        ///
        /// <value> The credential format code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        CredentialFormatCodes CredentialFormatCode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the length of the bit. </summary>
        ///
        /// <value> The length of the bit. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        short BitLength { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ICredentialFormatDefinition is enabled.
        /// </summary>
        ///
        /// <value> True if this ICredentialFormatDefinition is enabled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsEnabled { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the biometric enrollment supported.
        /// </summary>
        ///
        /// <value> True if biometric enrollment supported, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool BiometricEnrollmentSupported { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the biometric identifier field. </summary>
        ///
        /// <value> The biometric identifier field. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        short BiometricIdField { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ICredentialFormatDefinition use full card
        /// code.
        /// </summary>
        ///
        /// <value> True if use full card code, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool UseCardNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the batch load supported. </summary>
        ///
        /// <value> True if batch load supported, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool BatchLoadSupported { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the batch load increment field. </summary>
        ///
        /// <value> The batch load increment field. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        short BatchLoadIncrementField { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential format data fields. </summary>
        ///
        /// <value> The credential format data fields. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ICollection<ICredentialFormatDataField> CredentialFormatDataFields { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential format parities. </summary>
        ///
        /// <value> The credential format parities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ICollection<ICredentialFormatParity> CredentialFormatParities { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for credential format instance. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface ICredentialFormatInstance : ICredentialFormatDefinition
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this ICredentialFormatInstance. </summary>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="fields">   The fields. </param>
        /// <param name="parities"> The parities. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void Initialize(ICredentialFormatDefinition format, IEnumerable<ICredentialFormatDataFieldInstance> fields, IEnumerable<ICredentialFormatParityInstance> parities);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets field value. </summary>
        ///
        /// <param name="fieldNumber">  The field number. </param>
        /// <param name="value">        The value. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool SetFieldValue(int fieldNumber, ulong value);
        bool SetFieldValue(int fieldNumber, long value);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets field value. </summary>
        ///
        /// <param name="fieldNumber">  The field number. </param>
        ///
        /// <returns>   The field value. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ulong GetFieldValue(int fieldNumber);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets field title. </summary>
        ///
        /// <param name="fieldNumber">  The field number. </param>
        ///
        /// <returns>   The field title. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        string GetFieldTitle(int fieldNumber);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets maximum digits. </summary>
        ///
        /// <param name="fieldNumber">  The field number. </param>
        ///
        /// <returns>   The maximum digits. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        short GetMaxDigits(int fieldNumber);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'fieldNumber' is field visible. </summary>
        ///
        /// <param name="fieldNumber">  The field number. </param>
        ///
        /// <returns>   True if field visible, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsFieldVisible(int fieldNumber);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'fieldNumber' is field read only. </summary>
        ///
        /// <param name="fieldNumber">  The field number. </param>
        ///
        /// <returns>   True if field read only, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsFieldReadOnly(int fieldNumber);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets minimum value. </summary>
        ///
        /// <param name="fieldNumber">  The field number. </param>
        ///
        /// <returns>   The minimum value. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ulong GetMinimumValue(int fieldNumber);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets maximum value. </summary>
        ///
        /// <param name="fieldNumber">  The field number. </param>
        ///
        /// <returns>   The maximum value. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ulong GetMaximumValue(int fieldNumber);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we are all values valid. </summary>
        ///
        /// <returns>   True if all values valid, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool AreAllValuesValid();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Calculates the code. </summary>
        ///
        /// <returns>   The calculated code. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ulong CalculateCode();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 's' is valid card code. </summary>
        ///
        /// <param name="s">            The string. </param>
        /// <param name="DataParts">    The data parts. </param>
        /// <param name="BitCount">     [in,out] Number of bits. </param>
        ///
        /// <returns>   True if valid card code, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsValidCardCode(string s, List<string> DataParts, ref uint BitCount);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'fieldNumber' is value valid. </summary>
        ///
        /// <param name="fieldNumber">  The field number. </param>
        ///
        /// <returns>   True if value valid, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsValueValid(int fieldNumber);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the first invalid field number. </summary>
        ///
        /// <returns>   The first invalid field number. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        int GetFirstInvalidFieldNumber();
        /// <summary>   Resets the values. </summary>
        void ResetValues();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether the initialized. </summary>
        ///
        /// <value> True if initialized, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool Initialized { get; }

    }
}