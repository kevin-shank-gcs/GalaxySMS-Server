////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\ReaderInterfaceSectionModeIds.cs
//
// summary:	Implements the reader interface section mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A dual reader interface 600 mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DualReaderInterface600ModeIds
    {
        /// <summary>   The reader interface mode unused. </summary>
        public static readonly Guid ReaderInterfaceMode_Unused = new Guid("b6b02454-5a52-44ac-952a-1e9518cc54af");
        /// <summary>   The reader interface mode access portal. </summary>
        public static readonly Guid ReaderInterfaceMode_AccessPortal = new Guid("abe53a18-4fa5-4445-9221-68efc0efaa3f");
        /// <summary>   The reader interface mode credential reader only. </summary>
        public static readonly Guid ReaderInterfaceMode_CredentialReaderOnly = new Guid("9e6a73f5-2630-444e-bc3c-f61a452bf5fb");

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the values. </summary>
        ///
        /// <value> The values. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<Guid> Values
        {
            get
            {
                var r = new List<Guid>();
                r.Add(ReaderInterfaceMode_Unused);
                r.Add(ReaderInterfaceMode_AccessPortal);
                r.Add(ReaderInterfaceMode_CredentialReaderOnly);
                return r;
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A dual reader interface 635 mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DualReaderInterface635ModeIds
    {
        /// <summary>   The reader interface mode unused. </summary>
        public static readonly Guid ReaderInterfaceMode_Unused = new Guid("73ef0d4f-bcd5-49fa-a8b7-a11cc1a7fb67");
        /// <summary>   The reader interface mode access portal. </summary>
        public static readonly Guid ReaderInterfaceMode_AccessPortal = new Guid("49e17d01-50c6-4c4f-8362-9bdf69a58b61");
        /// <summary>   The reader interface mode credential reader only. </summary>
        public static readonly Guid ReaderInterfaceMode_CredentialReaderOnly = new Guid("2d382f80-f2e0-4336-9492-ac1ccaaa67ff");

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the values. </summary>
        ///
        /// <value> The values. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<Guid> Values
        {
            get
            {
                var r = new List<Guid>();
                r.Add(ReaderInterfaceMode_Unused);
                r.Add(ReaderInterfaceMode_AccessPortal);
                r.Add(ReaderInterfaceMode_CredentialReaderOnly);
                return r;
            }
        }
    }
}
