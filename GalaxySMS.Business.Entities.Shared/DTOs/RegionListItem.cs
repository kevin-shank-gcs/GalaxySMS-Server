using System;
using System.Collections.Generic;
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
    public class RegionListItem
    {

        public RegionListItem()
        {
            RegionUid = Guid.Empty;
            RegionName = string.Empty;
            Sites = new HashSet<SiteListItem>();

        }

        public RegionListItem(RegionSelectionItemBasic o)
        {
            RegionUid = Guid.Empty;
            RegionName = string.Empty;
            Sites = new HashSet<SiteListItem>();
            if (o != null)
            {
                RegionUid = o.RegionUid;
                RegionName = o.RegionName;
                Image = o.Photo;
                if (o.Sites != null)
                {
                    foreach (var s in o.Sites)
                    {
                        Sites.Add(new SiteListItem(s));
                    }
                }
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid RegionUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RegionName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Image { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif

        public ICollection<SiteListItem> Sites { get; set; }
    }
}
