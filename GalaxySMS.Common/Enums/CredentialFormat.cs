////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\CredentialFormat.cs
//
// summary:	Implements the credential format class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent credential format codes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum CredentialFormatCodes : short
    {
/// <summary>   . </summary>
        NumericCardCode = 0,
/// <summary>   . </summary>
        MagneticStripeBarcodeAba = 1,
/// <summary>   . </summary>
        Wiegand26Bit = 3,
        /// <summary>   An enum constant representing the galaxy keypad option. </summary>
        GalaxyKeypad = 5,
        /// <summary>   An enum constant representing the HID corp 1 k 35 bit option. </summary>
        HIDCorp1K35Bit = 6,
        /// <summary>   An enum constant representing the piv 75 bit option. </summary>
        PIV75Bit = 7,
        /// <summary>   An enum constant representing the bqt 36 bit option. </summary>
        BQT36Bit = 8,
        /// <summary>   An enum constant representing the xceed Identifier 40 bit option. </summary>
        XceedID40Bit = 9,
        /// <summary>   An enum constant representing the government Identifier option. </summary>
        USGovernmentID = 10,
        /// <summary>   An enum constant representing the HID corp 1 k 48 bit option. </summary>
        HIDCorp1K48Bit = 11,
        /// <summary>   An enum constant representing the cypress 37 bit option. </summary>
        Cypress37Bit = 12,
        /// <summary>   An enum constant representing the hidh 1030437 bit option. </summary>
        HIDH1030437Bit = 13,
        /// <summary>   An enum constant representing the none option. </summary>
        None = Int16.MaxValue, 
    }
}
