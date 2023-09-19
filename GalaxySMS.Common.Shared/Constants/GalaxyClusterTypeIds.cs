////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyClusterTypeIds.cs
//
// summary:	Implements the galaxy cluster type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy cluster type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyClusterTypeIds
    {
        ///// <summary>   The galaxy cluster type only 600. </summary>
        //public static readonly Guid GalaxyClusterType_Only600 = new Guid("D42A3A9A-9374-4F65-9A67-39E4EE867D56");
        /// <summary>   The fifth galaxy cluster type only 635. </summary>
        public static readonly Guid GalaxyClusterType_Only635 = new Guid("80C28BC8-1601-4F3E-9698-832C7874B841");
        ///// <summary>   The galaxy cluster type hybrid 6xx. </summary>
        //public static readonly Guid GalaxyClusterType_Hybrid6xx = new Guid("fb675377-9e73-4ba4-ae90-209c02918405");
        /// <summary>   The fifth galaxy cluster type only 7xx. </summary>
        public static readonly Guid GalaxyClusterType_Only7xx = new Guid("034BA5D9-F233-49E7-86CE-46AD9EF58184");
        /// <summary>   The galaxy cluster type hybrid 7xx. </summary>
        public static readonly Guid GalaxyClusterType_Hybrid7xx = new Guid("C0771096-F46D-4756-8B75-BA637964C509");
    }
}
