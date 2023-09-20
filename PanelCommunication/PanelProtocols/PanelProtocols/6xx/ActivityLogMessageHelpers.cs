using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.PanelProtocols.Series6xx.Messages;

namespace GCS.PanelProtocols.Series6xx
{
	public class ActivityLogMessageCardHelper
	{
		ExtendedCardDataActivityLogMessageFromCpu highBytes;
		ExtendedCardDataActivityLogMessageFromCpu middleBytes;
		StandardCardDataActivityLogMessageFromCpu baseRecord;
		IDataPacket6xx basePacket;
		public ActivityLogMessageCardHelper(IDataPacket6xx pkt, StandardCardDataActivityLogMessageFromCpu baseData)
		{
			basePacket = pkt;
			highBytes = new ExtendedCardDataActivityLogMessageFromCpu(0);
			middleBytes = new ExtendedCardDataActivityLogMessageFromCpu(0);
			baseRecord = baseData;
		}

		public void Initialize(IDataPacket6xx pkt, StandardCardDataActivityLogMessageFromCpu baseData)
		{
			basePacket = pkt;
			highBytes = new ExtendedCardDataActivityLogMessageFromCpu(0);
			middleBytes = new ExtendedCardDataActivityLogMessageFromCpu(0);
			baseRecord = baseData;

		}

		public void Update(ExtendedCardDataActivityLogMessageFromCpu extendedData)
		{
			switch((PanelActivityLogMessageCode)extendedData.LogType)
			{
				case PanelActivityLogMessageCode.ExtendedCardCodeHighestBytes:
					highBytes = extendedData;
					break;

				case PanelActivityLogMessageCode.ExtendedCardCodeMiddleBytes:
					middleBytes = extendedData;
					break;
			}
		}

		public StandardCardDataActivityLogMessageFromCpu BaseRecord
		{ get { return baseRecord; } }

		public ExtendedCardDataActivityLogMessageFromCpu MiddleRecord
		{ get { return middleBytes; } }

		public ExtendedCardDataActivityLogMessageFromCpu HighRecord
		{ get { return highBytes; } }

		public Byte[] CardData
		{
			get{
				Byte[] data = new byte[ActivityLogCardMessageConstants.FullCardCodeMessageSize];

				Array.Copy(highBytes.Data, 0, data, 0, highBytes.Data.Length);
				Array.Copy(middleBytes.Data, 0, data, highBytes.Data.Length, middleBytes.Data.Length);
				Array.Copy(baseRecord.CardCode, 0, data, highBytes.Data.Length + highBytes.Data.Length, baseRecord.CardCode.Length);
				return data;
			}
		}

		public UInt16 BufferIndex
		{
			get 
			{
				if (MiddleRecord.LogType == (Byte)PanelActivityLogMessageCode.ExtendedCardCodeMiddleBytes)
					return MiddleRecord.BufferIndex;

				if (HighRecord.LogType == (Byte)PanelActivityLogMessageCode.ExtendedCardCodeHighestBytes)
					return HighRecord.BufferIndex;

				return BaseRecord.BufferIndex;
			}
		}

		public IDataPacket6xx BasePacket { get { return basePacket; } }

		public Byte LogType
		{
			get {return BaseRecord.LogType;}
		}

		public Byte Month
		{
			get { return BaseRecord.Month; }
		}
		public Byte Day
		{
			get { return BaseRecord.Day; }
		}
		public Byte Hour
		{
			get { return BaseRecord.Hour; }
		}
		public Byte Minute
		{
			get { return BaseRecord.Minute; }
		}
		public Byte Second
		{
			get { return BaseRecord.Second; }
		}

		public Byte BoardNumber
		{
			get { return BaseRecord.BoardNumber; }
		}

		public Byte SectionNumber
		{
			get { return (Byte)BaseRecord.SectionNumber; }
		}

		public Byte NodeNumber
		{
			get { return (Byte)BaseRecord.NodeNumber; }
		}

        //public DateTimeOffset DateTimeOffset
        //{
        //	get
        //	{
        //		return BaseRecord.DateTimeOffset;
        //	}
        //}
        public DateTimeOffset DateTime
        {
            get
            {
                return BaseRecord.DateTime;
            }
        }

    }

}
