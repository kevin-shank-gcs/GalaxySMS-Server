using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public class CredentialCountReply : PanelMessageBase
	{
		public CredentialCountReply()
		{
		}

        public CredentialCountReply(PanelMessageBase b)
            : base(b)
        {
        }

        public CredentialCountReply(CredentialCountReply o)
			: base(o)
		{
			if (o != null)
			{
				Value = o.Value;
			}
		}
		
		[DataMember]
		public UInt32 Value { get; set; }
	}
}
