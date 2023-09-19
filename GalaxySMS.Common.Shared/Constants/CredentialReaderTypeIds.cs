////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\CredentialReaderTypeIds.cs
//
// summary:	Implements the credential reader type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential reader type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CredentialReaderTypeIds
    {
        /// <summary>   The assa abloy IP enabled lock. </summary>
        public static readonly Guid AssaAbloyIPEnabledLock = new Guid("6E6B383E-50C4-4920-8E25-80FB27AD0566");
        /// <summary>   The standard wiegand. </summary>
        public static readonly Guid StandardWiegand = new Guid("90AC4A06-8BCD-4F44-8415-F6FDEB5D1391");
        /// <summary>   The standard data clock. </summary>
        public static readonly Guid StandardDataClock = new Guid("E7CB3877-CB81-43B0-9DEE-9194787AC240");
        /// <summary>   The farpointe pyramid. </summary>
        public static readonly Guid FarpointePyramid = new Guid("F72828C5-46DD-4BDB-B039-F0BA501B3F74");
        /// <summary>   The farpointe delta. </summary>
        public static readonly Guid FarpointeDelta = new Guid("74EC77DD-399E-4231-AC8F-F5BB44CCC83C");
        /// <summary>   The farpointe ranger. </summary>
        public static readonly Guid FarpointeRanger = new Guid("3DFC0853-51F0-468F-BF7B-1B76A290E79F");
        /// <summary>   The HID prox 125 k. </summary>
        public static readonly Guid HIDProx125K = new Guid("F402127A-C979-49C9-9020-F31A7A4E5569");
        /// <summary>   The higher di class se. </summary>
        public static readonly Guid HIDiClassSE = new Guid("6C7CFFC8-7349-441B-A7F2-032464A496CB");
        /// <summary>   The higher di class long range. </summary>
        public static readonly Guid HIDiClassLongRange = new Guid("10ED5A11-46A8-4634-8782-F0AD82A0DAA1");
        /// <summary>   The higher di classi class. </summary>
        public static readonly Guid HIDiClassiClass = new Guid("E5E81972-1DA5-4BFD-A70F-F852DC6A0A1D");

        /// <summary>   The essex keypad. </summary>
        public static readonly Guid EssexKeypad = new Guid("7f32e4c4-3e03-4ccc-8ae0-91424bc5d3eb");

        /// <summary>   The inverted data clock. </summary>
        public static readonly Guid InvertedDataClock = new Guid("be96c365-fccc-42e9-8906-f0e8b2bacdca");

    }
}
