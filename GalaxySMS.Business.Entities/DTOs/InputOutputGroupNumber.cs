using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	public enum SystemInputOutputGroup { None = 0 }

	[DataContract]
    public class InputOutputGroupNumber : EntityBase
	{
		private Int32 ioGroupNumber;

		public enum InputOutputGroupNumberLimits { MinimumInputOutputGroupNumber = 0, MaximumInputOutputGroupNumber = 255 }

		[DataMember]
		public String UniqueId { get { return string.Format("{0:D3}", GroupNumber); } }

		[DataMember]
		public Int32 GroupNumber
		{
			get { return ioGroupNumber; }
			set
			{
				if (value >= (Int32)InputOutputGroupNumberLimits.MinimumInputOutputGroupNumber && value <= (Int32)InputOutputGroupNumberLimits.MaximumInputOutputGroupNumber)
					ioGroupNumber = value;
				else
					throw new ArgumentOutOfRangeException("GroupNumber", value, string.Format("The GroupNumber value must be between {0} and {1}",
						InputOutputGroupNumberLimits.MinimumInputOutputGroupNumber, InputOutputGroupNumberLimits.MaximumInputOutputGroupNumber));
			}
		}

		public override string ToString()
		{
			return UniqueId;
		}
	}
}
