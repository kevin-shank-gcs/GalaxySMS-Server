using GCS.Core.Common.Core;
using System.Runtime.Serialization;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.AssaAbloyDsr
#else
namespace GalaxySMS.Business.Entities.AssaAbloyDsr
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class AccessPointType : DtoObjectBase
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public string id
        {
            get; set;

        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string displayName
        {
            get;
            set;
        }

    }

}
