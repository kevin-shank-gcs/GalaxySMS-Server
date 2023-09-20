using GalaxySMS.Common.Enums;
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

    public class AccessPortalStatusReply : PanelMessageBase
    {
        public AccessPortalStatusReply()
        {
        }

        public AccessPortalStatusReply(PanelMessageBase b)
            : base(b)
        {
        }

        public AccessPortalStatusReply(AccessPortalStatusReply o)
            : base(o)
        {
            if (o != null)
            {
                AccessPortalUid = o.AccessPortalUid;
                AccessPortalStatus = o.AccessPortalStatus;
                ContactStatus = o.ContactStatus;
                LockStatus = o.LockStatus;
                CredentialReaderStatus = o.CredentialReaderStatus;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid AccessPortalUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalStatus AccessPortalStatus { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalContactStatus ContactStatus { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessPortalLockStatus LockStatus { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialReaderStatus CredentialReaderStatus { get; set; }
    }
}
