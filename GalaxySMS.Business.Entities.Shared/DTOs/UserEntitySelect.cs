using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
	public class UserEntitySelect:UserEntity
    {
        public UserEntitySelect() :base()
        {
            Init();
        }

        public UserEntitySelect(gcsEntity e) :base(e)
        {
            Init();
        }

        protected void Init()
        {
            base.Init();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool Selected { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityMapPermissionLevelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsOwner { get; set; }
    }
}
