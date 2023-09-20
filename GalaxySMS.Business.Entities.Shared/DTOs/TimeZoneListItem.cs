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
    public class TimeZoneListItem
    {

        public TimeZoneListItem()
        {
            Id = string.Empty;
            DisplayName = string.Empty;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Id { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DisplayName { get; set; }

    }
}
