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
    public class FirmwareVersion : EntityBase
	{
		[DataMember]
		public UInt16 Major { get; set; }

		[DataMember]
		public UInt16 Minor { get; set; }

	    [DataMember]
	    public UInt16 LetterCode { get; set; }

		public override string ToString()
		{
            var subVersion = LetterCode;
            if( LetterCode >= 0x40)
                subVersion = (UInt16)(LetterCode - 0x40);
			return string.Format("{0}.{1}.{2}", Major, Minor, subVersion);
		}
	}
}
