////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\LanguageIds.cs
//
// summary:	Implements the language identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A language identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class LanguageIds
    {
        /// <summary>   Identifier for the galaxy SMS en us language. </summary>
        public static readonly Guid GalaxySMS_EN_US_Language_Id = new Guid("AD7E7002-E6EC-4E0C-AB4F-FA3D1C8E0F9F");
    }

    public class LanguageCultures
    {
        public const string EnglishUs = "en-US";
    }
}
