using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public class PanelActivityLogMessage : PanelActivityLogMessageBase
	{
        public PanelActivityLogMessage() : base() { }
        public PanelActivityLogMessage(PanelActivityLogMessageBase b) : base(b) { }
        public PanelActivityLogMessage(PanelActivityLogMessage c)
			: base(c)
		{

		}

	}
}
