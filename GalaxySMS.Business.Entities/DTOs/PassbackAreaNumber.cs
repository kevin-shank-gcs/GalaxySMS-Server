using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	public enum SystemArea { None = 0, NoChange = 255}

	[DataContract]
    public class PassbackAreaNumber : EntityBase
	{
		private Int32 areaNumber;

		public enum PassbackAreaNumberLimits { MinimumAreaNumber = 0, MaximumAreaNumber = 255 }

		[DataMember]
		public String UniqueId { get { return string.Format("{0:D3}", AreaNumber); } }

		[DataMember]
		public Int32 AreaNumber
		{
			get { return areaNumber; }
			set
			{
				if (value >= (Int32)PassbackAreaNumberLimits.MinimumAreaNumber && value <= (Int32)PassbackAreaNumberLimits.MaximumAreaNumber)
					areaNumber = value;
				else
					throw new ArgumentOutOfRangeException("PassbackAreaNumber.AreaNumber", value, string.Format("The AreaNumber value must be between {0} and {1}",
						PassbackAreaNumberLimits.MinimumAreaNumber, PassbackAreaNumberLimits.MaximumAreaNumber));
			}
		}
		
		public override string ToString()
		{
			return UniqueId;
		}
	}
}
