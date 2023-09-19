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
	public class InputDeviceStatusReply : PanelMessageBase
	{
		public InputDeviceStatusReply()
		{
		}

        public InputDeviceStatusReply(PanelMessageBase b)
            : base(b)
        {
        }

        public InputDeviceStatusReply(InputDeviceStatusReply o)
			: base(o)
		{
			if (o != null)
			{
				//AccessPortalStatus = o.AccessPortalStatus;
                ContactStatus = o.ContactStatus;
                ArmedStatus = o.ArmedStatus;
                MonitoringStatus = o.MonitoringStatus;
			}
		}
		
		//[DataMember]
		//public AccessPortalStatus AccessPortalStatus { get; set; }

        [DataMember]
        public InputDeviceContactStatus ContactStatus {get;set;}
        
        [DataMember]
        public InputDeviceArmedStatus ArmedStatus {get;set;}

        [DataMember]
        public InputDeviceMonitoringStatus MonitoringStatus {get;set;}
	}
}
