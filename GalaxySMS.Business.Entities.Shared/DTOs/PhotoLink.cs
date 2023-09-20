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
    public class PhotoLink
    {
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid Uid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Tag { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Url { get; set; }

    }
}
