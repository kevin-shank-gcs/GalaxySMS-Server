////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\CredentialDataLengthIds.cs
//
// summary:	Implements the credential data length identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential data length identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CredentialFormatIds
    {
        public static readonly Guid NumericCardCode = new Guid("00000000-0000-0000-0001-000000000000");
        public static readonly Guid MagneticStripeBarcodeAba = new Guid("00000000-0000-0000-0001-000000000001");
        public static readonly Guid Standard26Bit = new Guid("00000000-0000-0000-0001-000000000003");
        public static readonly Guid GalaxyKeypad = new Guid("00000000-0000-0000-0001-000000000005");
        public static readonly Guid Corporate1K35Bit = new Guid("00000000-0000-0000-0001-000000000006");
        public static readonly Guid PIV75Bit = new Guid("00000000-0000-0000-0001-000000000007");
        public static readonly Guid Bqt36Bit = new Guid("00000000-0000-0000-0001-000000000008");
        public static readonly Guid XceedId40Bit = new Guid("00000000-0000-0000-0001-000000000009");
        public static readonly Guid USGovernmentID = new Guid("00000000-0000-0000-0001-00000000000a");
        public static readonly Guid Corporate1K48Bit = new Guid("00000000-0000-0000-0001-00000000000b");
        public static readonly Guid Cypress37Bit = new Guid("00000000-0000-0000-0001-00000000000c");
        public static readonly Guid H1030437Bit = new Guid("00000000-0000-0000-0001-00000000000d");
        public static readonly Guid H1030237Bit = new Guid("00000000-0000-0000-0001-00000000000e");
        public static readonly Guid SoftwareHouse37Bit = new Guid("00000000-0000-0000-0001-00000000000f");
        public static readonly Guid BtFarpointeConektMobile = new Guid("00000000-0000-0000-0001-000000000010");
        public static readonly Guid BtHidMobileAccess = new Guid("00000000-0000-0000-0001-000000000011");
        public static readonly Guid BtStidMobileId = new Guid("00000000-0000-0000-0001-000000000012");
        public static readonly Guid BtAllegion = new Guid("00000000-0000-0000-0001-000000000013");
        public static readonly Guid BtBasIp = new Guid("00000000-0000-0000-0001-000000000014");
        public static readonly Guid BasIpQr = new Guid("00000000-0000-0000-0001-000000000015");
    }

}
