////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\AccessGroupIds.cs
//
// summary:	Implements the access group identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access group identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessGroupIds
    {
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access group limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessGroupLimits
    {
        /// <summary>   The none. </summary>
        public const int None = 0;
        /// <summary>   The lowest definable number. </summary>
        public const int LowestDefinableNumber = 1;
        /// <summary>   The maximum standard number. </summary>
        public const int MaximumStandardNumber = 254;
        /// <summary>   The unlimited access. </summary>
        public const int UnlimitedAccess = 255;
        /// <summary>   The minimum extended group number. </summary>
        public const int MinimumExtendedGroupNumber = 256;
        /// <summary>   The maximum number. </summary>
        public const int MaximumNumber = 2000;
        /// <summary>   Number of maximums. </summary>
        public const int MaximumCount = 2001;
        /// <summary>   Group the personal access belongs to. </summary>
        public const int PersonalAccessGroup = 2001;
        /// <summary>   The minimum personal access group number. </summary>
        public const int MinimumPersonalAccessGroupNumber = 2001;
        /// <summary>   The maximum personal access group number. </summary>
        public const int MaximumPersonalAccessGroupNumber = 52000;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A personal access group database limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PersonalAccessGroupDatabaseLimits
    {
        /// <summary>   The none. </summary>
        public const int None = 0;
        /// <summary>   The minimum database personal access group number. </summary>
        public const int MinimumDatabasePersonalAccessGroupNumber = 1;
        /// <summary>   The maximum database personal access group number. </summary>
        public const int MaximumDatabasePersonalAccessGroupNumber = 50000;

    }
}
