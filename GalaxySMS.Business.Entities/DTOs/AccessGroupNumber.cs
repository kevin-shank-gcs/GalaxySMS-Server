using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
	public enum SystemAccessGroup { None = 0, Unlimited = 255 }

	[DataContract]
	public class AccessGroupNumber : EntityBase
	{
		private Int32 accessGroupNumber;

		public enum AccessGroupNumberLimits { MinimumAccessGroupNumber = 0, MaximumAccessGroupNumber = 2000 }

		[DataMember]
		public String UniqueId { get { return string.Format("{0:D3}", Number); } }

		[DataMember]
		public Int32 Number
		{
			get { return accessGroupNumber; }
			set
			{
				if (value >= (Int32)AccessGroupNumberLimits.MinimumAccessGroupNumber && value <= (Int32)AccessGroupNumberLimits.MaximumAccessGroupNumber)
					accessGroupNumber = value;
				else
					throw new ArgumentOutOfRangeException("AccessGroupNumber.Number", value, string.Format("The Number value must be between {0} and {1}",
						AccessGroupNumberLimits.MinimumAccessGroupNumber, AccessGroupNumberLimits.MaximumAccessGroupNumber));
			}
		}

		
		[DataMember]
		public Boolean IsExtended
		{
			get
			{
				if (Number > (Int32)SystemAccessGroup.Unlimited)
					return true;
				return false;
			}
		}

		public override string ToString()
		{
			return UniqueId;
		}
	}

}
