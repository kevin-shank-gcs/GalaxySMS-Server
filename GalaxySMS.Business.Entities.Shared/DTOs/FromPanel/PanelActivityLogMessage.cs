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

    public class PanelActivityLogMessage : PanelActivityLogMessageBase
    {
        public PanelActivityLogMessage() : base() { }
        public PanelActivityLogMessage(PanelActivityLogMessageBase b) : base(b) { }
        public PanelActivityLogMessage(PanelActivityLogMessage c)
            : base(c)
        {

        }

    }
}
