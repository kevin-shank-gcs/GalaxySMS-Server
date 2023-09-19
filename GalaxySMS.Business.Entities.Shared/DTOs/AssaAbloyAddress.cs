using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

    public class AssaAbloyAddress : EntityBase
	{
		public enum HubNumberLimits {MinimumHubNumber = 1, MaximumHubNumber = 15}
		public enum ReaderNumberLimits {MinimumReaderNumber = 1, MaximumReaderNumber = 8}	// must be converted to 0 - 7 for panel

		private Int32 hubNumber;
		private Int32 readerNumber;
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 HubNumber
		{
			get { return hubNumber; }
			set
			{
				if (value >= (Int32)HubNumberLimits.MinimumHubNumber && value <= (Int32)HubNumberLimits.MaximumHubNumber)
					hubNumber = value;
				else
					throw new ArgumentOutOfRangeException("AssaAbloyAddress.HubNumber", value, string.Format("The HubNumber value must be between {0} and {1}",
						HubNumberLimits.MinimumHubNumber, HubNumberLimits.MaximumHubNumber));
			}
		}
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 ReaderNumber
		{
			get { return readerNumber; }
			set
			{
				if (value >= (Int32)ReaderNumberLimits.MinimumReaderNumber && value <= (Int32)ReaderNumberLimits.MaximumReaderNumber)
					readerNumber = value;
				else
					throw new ArgumentOutOfRangeException("AssaAbloyAddress.ReaderNumber", value, string.Format("The ReaderNumber value must be between {0} and {1}",
						ReaderNumberLimits.MinimumReaderNumber, ReaderNumberLimits.MaximumReaderNumber));
			}
		}
	}
}
