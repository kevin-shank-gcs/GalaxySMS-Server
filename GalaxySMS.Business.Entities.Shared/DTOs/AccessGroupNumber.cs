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
	public enum SystemAccessGroup { None = 0, Unlimited = 255 }

	[DataContract]
	public class AccessGroupNumber : EntityBase
	{
		private Int32 accessGroupNumber;

		public enum AccessGroupNumberLimits { MinimumAccessGroupNumber = 0, MaximumAccessGroupNumber = 2000 }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String UniqueId { get { return string.Format("{0:D3}", Number); } }
#if NetCoreApi
#else
        [DataMember]
#endif
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
#if NetCoreApi
#else
        [DataMember]
#endif
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
