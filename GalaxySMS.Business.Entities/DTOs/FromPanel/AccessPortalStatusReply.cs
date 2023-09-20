using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
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

        [DataMember]
        public Guid AccessPortalUid { get; set; }

        [DataMember]
        public AccessPortalStatus AccessPortalStatus { get; set; }

        [DataMember]
        public AccessPortalContactStatus ContactStatus {get;set;}
        
        [DataMember]
        public AccessPortalLockStatus LockStatus {get;set;}

        [DataMember]
        public CredentialReaderStatus CredentialReaderStatus {get;set;}
	}
}
