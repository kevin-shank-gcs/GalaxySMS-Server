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

    public class AssaDsrEntityBase : DtoObjectBase
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Id
        {
            get;
            set;
        }

    }
}
