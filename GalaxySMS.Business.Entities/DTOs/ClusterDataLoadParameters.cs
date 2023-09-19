using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
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
