using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{

	public class CredentialCountReplyResp : PanelMessageBaseResp
	{
		public CredentialCountReplyResp()
		{
		}

        public CredentialCountReplyResp(PanelMessageBaseResp b)
            : base(b)
        {
        }

        public CredentialCountReplyResp(CredentialCountReplyResp o)
			: base(o)
		{
			if (o != null)
			{
				Value = o.Value;
			}
		}

        public UInt32 Value { get; set; }
	}
	
    public class CredentialCountReplyBasicResp
    {
        public CredentialCountReplyBasicResp()
        {
        }

        public CredentialCountReplyBasicResp(CredentialCountReplyResp o)
        {
            if (o != null)
            {
                Value = o.Value;
            }
        }

        public CredentialCountReplyBasicResp(CredentialCountReplyBasicResp o)
        {
            if (o != null)
            {
                Value = o.Value;
            }
        }

        public UInt32 Value { get; set; }
    }

}
