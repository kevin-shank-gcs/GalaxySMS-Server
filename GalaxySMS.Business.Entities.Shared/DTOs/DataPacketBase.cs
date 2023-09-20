using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

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

    public class DataPacketBase : EntityBase
    {
        public DataPacketBase() :base()
        {
            DateTimeCreated = DateTimeOffset.Now;
            WhichDirection = DataDirection.Unknown;
        }

        public DataPacketBase(DataPacketBase p) : base(p)
        {
            if (p != null)
            {
                DateTimeCreated = p.DateTimeCreated;
                WhichDirection = p.WhichDirection;
            }
            else
            {
                DateTimeCreated = DateTimeOffset.Now;
                WhichDirection = DataDirection.Unknown;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset DateTimeCreated { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DataDirection WhichDirection { get; set; }

    }
}
