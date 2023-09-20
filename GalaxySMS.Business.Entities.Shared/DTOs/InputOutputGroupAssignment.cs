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

	public class PanelInputOutputGroupAssignment : InputOutputGroupNumber
	{
		private Int32 ioOffsetNumber;

		public enum InputOutputGroupOffsetLimits { MinimumOffset = 0, MaximumOffset = 31 }
#if NetCoreApi
#else
        [DataMember]
#endif
        public new String UniqueId { get { return string.Format("{0:D3}:{1:D2}", GroupNumber, OffsetNumber); } }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 OffsetNumber
		{
			get { return ioOffsetNumber; }
			set
			{
				if (value >= (Int32)InputOutputGroupOffsetLimits.MinimumOffset && value <= (Int32)InputOutputGroupOffsetLimits.MaximumOffset)
					ioOffsetNumber = value;
				else
					throw new ArgumentOutOfRangeException("OffsetNumber", value, string.Format("The OffsetNumber value must be between {0} and {1}",
						InputOutputGroupOffsetLimits.MinimumOffset, InputOutputGroupOffsetLimits.MaximumOffset));
			}
		}

		public override string ToString()
		{
			return UniqueId;
		}
	}
}
