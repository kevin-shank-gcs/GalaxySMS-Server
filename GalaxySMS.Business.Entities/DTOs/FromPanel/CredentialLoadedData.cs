using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public class CredentialLoadedData
	{
		public CredentialLoadedData()
		{
		}


        public CredentialLoadedData(CredentialLoadedData o)
		{
			if (o != null)
			{
                CardData = o.CardData;
			}
		}
		
        [DataMember]
        public byte[] CardData{get;set;}
	}
}
