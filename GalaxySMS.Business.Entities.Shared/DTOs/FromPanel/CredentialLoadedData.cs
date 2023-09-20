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

    public class CredentialLoadedData
    {
        public CredentialLoadedData()
        {
        }


        public CredentialLoadedData(CredentialLoadedData o)
        {
            if (o != null)
            {
                CardData = o.CardData;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] CardData { get; set; }
    }
}
