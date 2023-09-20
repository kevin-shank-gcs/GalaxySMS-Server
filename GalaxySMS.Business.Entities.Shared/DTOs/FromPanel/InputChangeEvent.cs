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

    public class InputChangeEvent : PanelMessageBase
    {
        public InputChangeEvent()
        {
        }

        public InputChangeEvent(PanelMessageBase b)
            : base(b)
        {
        }

        public InputChangeEvent(InputChangeEvent o)
            : base(o)
        {
            if (o != null)
            {
                InputOutputGroupNumber = o.InputOutputGroupNumber;
                Offset = o.Offset;
                NewState = o.NewState;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte InputOutputGroupNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte Offset { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte NewState { get; set; }
    }
}
