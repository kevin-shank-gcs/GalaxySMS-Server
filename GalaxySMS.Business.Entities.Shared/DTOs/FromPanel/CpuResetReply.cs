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

    public class CpuResetReply : PanelMessageBase
    {
        public CpuResetReply()
        {
        }

        public CpuResetReply(PanelMessageBase b)
            : base(b)
        {
        }

        public CpuResetReply(CpuResetReply o)
            : base(o)
        {
            if (o != null)
            {
            }
        }
    }
}
