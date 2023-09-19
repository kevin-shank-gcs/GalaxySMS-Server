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
    public class ReaderLcdSettings : EntityBase
	{
		public enum Lcd8by4Format { Normal, LargeClock, TwelveSmallDigitsEightLargeDigits, EightSmallDigitsTwelveLargeDigits}
		public ReaderLcdSettings()
		{
			LcdHardwareAddress = new BoardSectionNodeHardwareAddress();
		}

		[DataMember]
		public BoardSectionNodeHardwareAddress LcdHardwareAddress { get; set; }

		[DataMember]
		public Lcd8by4Format Format { get; set; }
	}
}
