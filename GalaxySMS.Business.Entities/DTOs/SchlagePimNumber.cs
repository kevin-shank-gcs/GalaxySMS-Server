using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Business.Entities
{

	[DataContract]
    public class SchlagePimNumber : EntityBase
	{
		public enum SchlagePimNumberLimits { MinimumPimNumber = 1, MaximumPimNumber = 16 }

		private Int32 pimNumber = 1;

		[DataMember]
		public String UniqueId { get { return string.Format("{0:D3}", PimNumber); } }

		[DataMember]
		public Int32 PimNumber
		{
			get { return pimNumber; }
			set
			{
				if (value >= (Int32)SchlagePimNumberLimits.MinimumPimNumber && value <= (Int32)SchlagePimNumberLimits.MaximumPimNumber)
					pimNumber = value;
				else
					throw new ArgumentOutOfRangeException("SchlagePimNumber.PimNumber", value, string.Format("The PimNumber value must be between {0} and {1}",
						SchlagePimNumberLimits.MinimumPimNumber, SchlagePimNumberLimits.MaximumPimNumber));
			}
		}

		public override string ToString()
		{
			return PimNumber.ToString();
		}
	}

}
