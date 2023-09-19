////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\SearchCriteria.cs
//
// summary:	Implements the search criteria class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{ 
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A search criteria. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class ClusterDataLoadParameters : GalaxyCpuCommandBase
    {

        public ClusterDataLoadParameters()
        {
            DataToLoad = ClusterDataTypesToLoad.All;
            LoadDataSettings = new LoadDataToPanelSettings();
        }

        [DataMember]
        public ClusterDataTypesToLoad DataToLoad { get; set; }

        [DataMember]
        public LoadDataToPanelSettings LoadDataSettings { get; set; }

    }
}
