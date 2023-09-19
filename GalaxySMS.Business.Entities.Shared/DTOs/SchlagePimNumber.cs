using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public class SchlagePimNumber : EntityBase
	{
		public enum SchlagePimNumberLimits { MinimumPimNumber = 1, MaximumPimNumber = 16 }

		private Int32 pimNumber = 1;
#if NetCoreApi
#else
        [DataMember]
#endif
        public String UniqueId { get { return string.Format("{0:D3}", PimNumber); } }
#if NetCoreApi
#else
        [DataMember]
#endif
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
