using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

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
	public enum SystemInputOutputGroup { None = 0 }

	[DataContract]
    public class InputOutputGroupNumber : EntityBase
	{
		private Int32 ioGroupNumber;

		public enum InputOutputGroupNumberLimits { MinimumInputOutputGroupNumber = 0, MaximumInputOutputGroupNumber = 255 }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String UniqueId { get { return string.Format("{0:D3}", GroupNumber); } }
#if NetCoreApi
#else
        [DataMember]
#endif
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
