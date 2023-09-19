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

    public class CardChangeAreaEvent : PanelMessageBase
    {
        public CardChangeAreaEvent()
        {
        }

        public CardChangeAreaEvent(PanelMessageBase b)
            : base(b)
        {
        }

        public CardChangeAreaEvent(CardChangeAreaEvent o)
            : base(o)
        {
            if (o != null)
            {
                Area = o.Area;
                ForgiveCode = o.ForgiveCode;
                CardData = o.CardData;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 Area { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 ForgiveCode { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] CardData { get; set; }
    }
}
