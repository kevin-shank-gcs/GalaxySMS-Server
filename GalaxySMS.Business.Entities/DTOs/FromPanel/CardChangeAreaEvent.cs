using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public class CardChangeAreaEvent : PanelMessageBase
	{
		public CardChangeAreaEvent()
		{
		}

        public CardChangeAreaEvent(PanelMessageBase b)
            : base(b)
        {
        }

        public CardChangeAreaEvent(CardChangeAreaEvent o)
			: base(o)
		{
			if (o != null)
			{
			    Area = o.Area;
                ForgiveCode = o.ForgiveCode;
                CardData = o.CardData;
			}
		}
		
		[DataMember]
		public UInt16 Area { get; set; }
	    
	    [DataMember]
	    public UInt16 ForgiveCode { get; set; }

        [DataMember]
        public byte[] CardData{get;set;}
	}
}
