using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public class InputChangeEvent : PanelMessageBase
	{
		public InputChangeEvent()
		{
		}

        public InputChangeEvent(PanelMessageBase b)
            : base(b)
        {
        }

        public InputChangeEvent(InputChangeEvent o)
			: base(o)
		{
			if (o != null)
			{
			    InputOutputGroupNumber = o.InputOutputGroupNumber;
			    Offset = o.Offset;
			    NewState = o.NewState;
			}
		}
		
		[DataMember]
		public byte InputOutputGroupNumber { get; set; }
	    
	    [DataMember]
	    public byte Offset { get; set; }

	    [DataMember]
	    public byte NewState{get;set;}
	}
}
