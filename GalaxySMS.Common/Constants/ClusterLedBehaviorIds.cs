////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\ClusterLedBehaviorIds.cs
//
// summary:	Implements the cluster LED behavior identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A cluster LED behavior identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ClusterLedBehaviorIds
    {
        /// <summary>   The steady low. </summary>
        public static readonly Guid SteadyLow = new Guid("ec7c4003-0b6e-4452-a138-f9a12515e012");
        /// <summary>   The steady high. </summary>
        public static readonly Guid SteadyHigh = new Guid("e7af7eb9-e51c-4367-bc16-d36758261a2b");
        /// <summary>   The strobe. </summary>
        public static readonly Guid Strobe = new Guid("46bb5afa-315b-45be-ad6c-72f96cc253e8");
        /// <summary>   The strobe rapid. </summary>
        public static readonly Guid StrobeRapid = new Guid("9b444707-d8d1-46e7-967d-d50010021133");
    }
}
