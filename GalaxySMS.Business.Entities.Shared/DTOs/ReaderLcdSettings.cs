using GCS.Core.Common.Core;
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

    public class ReaderLcdSettings : EntityBase
    {
        public enum Lcd8by4Format { Normal, LargeClock, TwelveSmallDigitsEightLargeDigits, EightSmallDigitsTwelveLargeDigits }
        public ReaderLcdSettings()
        {
            LcdHardwareAddress = new BoardSectionNodeHardwareAddress();
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public BoardSectionNodeHardwareAddress LcdHardwareAddress { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Lcd8by4Format Format { get; set; }
    }
}
