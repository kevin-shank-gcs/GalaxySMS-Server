////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Entities\ClusterType.cs
//
// summary:	Implements the cluster type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelCommunicationServerAsync.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent cluster types. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum ClusterType
	{
        /// <summary>   An enum constant representing the unknown option. </summary>
		Unknown = 0,
        /// <summary>   An enum constant representing the series 5xx option. </summary>
		Series5xx,
        /// <summary>   An enum constant representing the series 6xx option. </summary>
		Series6xx,
	}
}
