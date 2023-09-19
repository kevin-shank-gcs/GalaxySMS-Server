using GCS.Core.Common.Core;
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

    public class FirmwareVersion //: EntityBase
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 Major { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 Minor { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt16 LetterCode { get; set; }

        public string FriendlyVersion => ToString();

        public override string ToString()
        {
            var subVersion = LetterCode;
            if (LetterCode >= 0x40)
                subVersion = (UInt16)(LetterCode - 0x40);
            return string.Format("{0}.{1}.{2}", Major, Minor, subVersion);
        }

        public void FromString(string s)
        {
            Major = 0;
            Minor = 0;
            LetterCode = 0;
            if (!string.IsNullOrEmpty(s))
            {
                var parts = s.Split('.');
                if (parts.Length == 3)
                {
                    ushort v = 0;
                    if (ushort.TryParse(parts[0], out v))
                        Major = v;
                    if (ushort.TryParse(parts[1], out v))
                        Minor = v;
                    if (ushort.TryParse(parts[2], out v))
                        LetterCode = v;
                }
            }
        }
    }
}
