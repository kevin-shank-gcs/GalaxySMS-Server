////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\CredentialReaderDataFormatIds.cs
//
// summary:	Implements the credential reader data format identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential reader data format identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CredentialReaderDataFormatIds
    {
        /// <summary>   The none. </summary>
        public static readonly Guid None = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The wiegand. </summary>
        public static readonly Guid Wiegand = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The wiegand key. </summary>
        public static readonly Guid WiegandKey = new Guid("00000000-0000-0000-0000-000000000003");
        /// <summary>   The clock data inverted. </summary>
        public static readonly Guid ClockDataInverted = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   Information describing the clock. </summary>
        public static readonly Guid ClockData = new Guid("00000000-0000-0000-0000-000000000005");
        /// <summary>   The fifth RS 232 g. </summary>
        public static readonly Guid RS232G5 = new Guid("00000000-0000-0000-0000-000000000006");
        /// <summary>   The clock data 8 digit fixed. </summary>
        public static readonly Guid ClockData8DigitFixed = new Guid("00000000-0000-0000-0000-000000000007");
        /// <summary>   The cardax wiegand. </summary>
        public static readonly Guid CardaxWiegand = new Guid("00000000-0000-0000-0000-000000000008");
        /// <summary>   The cardax. </summary>
        public static readonly Guid Cardax = new Guid("00000000-0000-0000-0000-000000000009");
        /// <summary>   The xceed identifier piv. </summary>
        public static readonly Guid XceedIdPiv = new Guid("00000000-0000-0000-0000-00000000000A");
        /// <summary>   The xceed identifier piv wiegand. </summary>
        public static readonly Guid XceedIdPivWiegand = new Guid("00000000-0000-0000-0000-00000000000B");
    }
}