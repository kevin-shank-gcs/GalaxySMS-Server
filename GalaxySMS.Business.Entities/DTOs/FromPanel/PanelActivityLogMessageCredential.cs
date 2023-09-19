using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
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

		[DataMember]
		public Byte[] CredentialBytes { get; set; }

        [DataMember]
        public string CredentialNumber { get; set; }

        [DataMember]
		public UInt32 Pin { get; set; }

		[DataMember]
		public UInt32 BitCount { get; set; }

		[DataMember]
		public UInt32 AlarmPanelZone { get; set; }	

        [DataMember]
        public Guid PersonUid {get;set; }
        
        [DataMember]
        public Guid CredentialUid {get;set; }

        [DataMember]
        public string PersonDescription {get;set;}

        [DataMember]
        public string CredentialDescription {get;set;}

        [DataMember]
        public bool Trace { get; set; }

    }
}
