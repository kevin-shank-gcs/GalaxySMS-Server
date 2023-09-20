using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public class PanelDoorNumber : EntityBase
	{
		public enum PanelDoorNumberLimits { MinimumPanelDoorNumber = 0, MaximumPanelDoorNumber = 64 }

		private Int32 doorNumber;

		[DataMember]
		public Int32 Number
		{
			get { return doorNumber; }
			set
			{
				if (value >= (Int32)PanelDoorNumberLimits.MinimumPanelDoorNumber && value <= (Int32)PanelDoorNumberLimits.MaximumPanelDoorNumber)
					doorNumber = value;
				else
					throw new ArgumentOutOfRangeException("PanelDoorNumber.Number", value, string.Format("The Number value must be between {0} and {1}",
						PanelDoorNumberLimits.MinimumPanelDoorNumber, PanelDoorNumberLimits.MaximumPanelDoorNumber));
			}
		}

		public override string ToString()
		{
			return Number.ToString();
		}
	}

}
