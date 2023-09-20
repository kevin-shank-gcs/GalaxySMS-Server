using System;
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
    public class SiteListItem
    {
        public SiteListItem()
        {
            SiteUid = Guid.Empty;
            SiteName = String.Empty;
        }

        public SiteListItem(SiteSelectionItemBasic o)
        {
            SiteUid = Guid.Empty;
            SiteName = String.Empty;
            if (o != null)
            {
                SiteUid = o.SiteUid;
                SiteName = o.SiteName;
                Image = o.Photo;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid SiteUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SiteName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Image { get; set; }
    }
}
