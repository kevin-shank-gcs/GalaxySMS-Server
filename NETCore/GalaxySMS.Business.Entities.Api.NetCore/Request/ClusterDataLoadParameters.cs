using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class ClusterDataLoadParametersReq : GalaxyPanelLoadDataBaseReq//GalaxyCpuCommandSingleBaseReq//GalaxyCpuCommandBaseReq
    {

        public ClusterDataLoadParametersReq()
        {
            DataToLoad = ClusterDataTypesToLoad.All;
            LoadDataSettings = new LoadDataToPanelSettings();
        }private ClusterDataTypesToLoad DataToLoad { get; set; }public LoadDataToPanelSettings LoadDataSettings { get; set; }


    }
}
