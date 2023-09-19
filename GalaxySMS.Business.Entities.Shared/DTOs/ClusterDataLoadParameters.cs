using GalaxySMS.Common.Enums;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public partial class ClusterDataLoadParameters : GalaxyCpuCommandBase
    {


        public ClusterDataLoadParameters()
        {
            DataToLoad = ClusterDataTypesToLoad.All;
            LoadDataSettings = new LoadDataToPanelSettings();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ClusterDataTypesToLoad DataToLoad { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public LoadDataToPanelSettings LoadDataSettings { get; set; }

    }
}
