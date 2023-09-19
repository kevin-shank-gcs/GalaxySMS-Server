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

    public class PanelCredentialActivityLogMessage : PanelActivityLogMessage
    {
        private const Int32 CredentialSize = 32;
        public PanelCredentialActivityLogMessage()
            : base()
        {
            CredentialBytes = new Byte[CredentialSize];
        }

        public PanelCredentialActivityLogMessage(PanelActivityLogMessage l)
            : base(l)
        {
            CredentialBytes = new Byte[CredentialSize];
        }
        public PanelCredentialActivityLogMessage(PanelCredentialActivityLogMessage c)
            : base(c)
        {
            CredentialBytes = new Byte[c.CredentialBytes.Length];
            Array.Copy(c.CredentialBytes, CredentialBytes, c.CredentialBytes.Length);
            Pin = c.Pin;
            BitCount = c.BitCount;
            AlarmPanelZone = c.AlarmPanelZone;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte[] CredentialBytes { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialNumberHex { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 Pin { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 BitCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 AlarmPanelZone { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CredentialUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string PersonDescription { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LastName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool Trace { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonCredentialUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonExpirationModeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short UsageCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }
    }
}
