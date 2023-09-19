////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\CredentialFormat.cs
//
// summary:	Implements the credential format class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent credential format codes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum CredentialFormatCodes : short
    {
        NumericCardCode = 0,
        MagneticStripeBarcodeAba = 1,
        Standard26Bit = 3,
        /// <summary>   An enum constant representing the galaxy keypad option. </summary>
        GalaxyKeypad = 5,
        /// <summary>   An enum constant representing the HID corp 1 k 35 bit option. </summary>
        Corporate1K35Bit = 6,
        /// <summary>   An enum constant representing the piv 75 bit option. </summary>
        PIV75Bit = 7,
        /// <summary>   An enum constant representing the bqt 36 bit option. </summary>
        Bqt36Bit = 8,
        /// <summary>   An enum constant representing the xceed Identifier 40 bit option. </summary>
        XceedId40Bit = 9,
        /// <summary>   An enum constant representing the government Identifier option. </summary>
        USGovernmentID = 10,
        /// <summary>   An enum constant representing the HID corp 1 k 48 bit option. </summary>
        Corporate1K48Bit = 11,
        /// <summary>   An enum constant representing the cypress 37 bit option. </summary>
        Cypress37Bit = 12,
        /// <summary>   An enum constant representing the HID 1030437 bit option. </summary>
        H1030437Bit = 13,
        /// <summary>   An enum constant representing the HID 1030237 bit option. </summary>
        H1030237Bit = 14,
        /// <summary>   An enum constant representing the software house 37 bit option. </summary>
        SoftwareHouse37Bit = 15,
        /// <summary>   An enum constant representing the bluetooth Farpointe Conekt Mobile option. </summary>
        BtFarpointeConektMobile = 16,
        /// <summary>   An enum constant representing the bluetooth HID Mobile access option. </summary>
        BtHidMobileAccess = 17,
        /// <summary>   An enum constant representing the bluetooth StID Mobile Id option. </summary>
        BtStidMobileId = 18,
        BtAllegion = 19,
        BtBasIp = 20,
        BasIpQr = 21,
        /// <summary>   An enum constant representing the none option. </summary>
        None = Int16.MaxValue,
    }
}
