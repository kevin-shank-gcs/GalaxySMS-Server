using GCS.Core.Common.Core;
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

    public partial class ServerConsultationSettings : ObjectBase
    {
        public ServerConsultationSettings()
        {
            UnknownCredentialLookupTimeout = 0;
            AccessDecisionTimeout = 0;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int UnknownCredentialLookupTimeout { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessDecisionTimeout { get; set; }
    }
}
