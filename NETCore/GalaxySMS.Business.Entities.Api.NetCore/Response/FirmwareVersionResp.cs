using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public class FirmwareVersionResp
	{
        public UInt16 Major { get; set; }
        public UInt16 Minor { get; set; }
        public UInt16 LetterCode { get; set; }

        public string FriendlyVersion => ToString();

        public override string ToString()
		{
            var subVersion = LetterCode;
            if( LetterCode >= 0x40)
                subVersion = (UInt16)(LetterCode - 0x40);
			return $"{Major}.{Minor}.{subVersion}";
		}
	}
}
