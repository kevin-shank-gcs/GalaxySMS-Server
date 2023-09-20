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
    public class CdnConnectionInfo
    {
        public enum CdnType
        {
            FileSystem,
            //AwsS3
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CdnType StorageType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FileSystemPath { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PublicUrl { get; set; }

    }
}
