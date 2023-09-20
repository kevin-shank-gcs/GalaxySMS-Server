using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public partial class ServerConsultationSettings : ObjectBase
	{
		public ServerConsultationSettings()
		{
		    UnknownCredentialLookupTimeout = 0;
		    AccessDecisionTimeout = 0;
		}
		[DataMember]
		public short UnknownCredentialLookupTimeout { get; set; }

		[DataMember]
		public short AccessDecisionTimeout { get; set; }
	}
}
