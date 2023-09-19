using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GCS.PanelProtocols.Series5xx.Messages
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Heatbeat
	{
		public Byte Cmd;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SignOnRequest
	{
		public Byte Cmd;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct AuthenticateSignOnRequestWithChallenge
	{
		public Byte Cmd;
		public UInt32 Crc;
	}


	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SetPanelDateTime
	{
		public Byte Cmd;		// 0 - 23
		public Byte hour;		// 0 - 23
		public Byte minute;		// 0 - 59
		public Byte second;		// 0 - 59
		public Byte month;		// 1 - 12
		public Byte day;		// 1 - 31
		public Byte year;		// years since 1900 (98, 99, 100)
		public Byte century;	// 20 - 99
		public UInt32 seconds_from_universal_time;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SetLoggingState
	{
		public Byte Cmd;
		public Byte State;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SingleByteCommand
	{
		public Byte Cmd;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct CpuVersionInfo
	{
		public Byte Minor;
		public Byte Major;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PanelInformationReply
	{
		public Byte Code;
		public Byte RunMode;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public Byte[] SerialNumber;
		public CpuVersionInfo VersionEprom;
		public CpuVersionInfo VersionFlashLo;
		public CpuVersionInfo VersionFlashHi;
		public Byte LastRestartColdOrWarm;
		public Byte OptionSwitches;
		public Byte ZLinkConnected;
		public Byte CrisisModeActive;
		public UInt16 UnacknowledgedActivityLogCount;
		public Byte ActivityLoggingEnabled;

		//		public CpuInformationReply(ref Byte[] data)
		public PanelInformationReply(ref DataPacket5xx pkt)
		{
			Code = 0;
			RunMode = 0;
			SerialNumber = new Byte[8];
			VersionEprom = new CpuVersionInfo();
			VersionFlashLo = new CpuVersionInfo();
			VersionFlashHi = new CpuVersionInfo();
			LastRestartColdOrWarm = 0;
			OptionSwitches = 0;
			ZLinkConnected = 0;
			CrisisModeActive = 0;
			UnacknowledgedActivityLogCount = 0;
			ActivityLoggingEnabled = 0;

			if (pkt.Length == 23)
			{
				if (pkt.Data != null)
				{
					int x = 0;
					Code = pkt.Data[x++];
					RunMode = pkt.Data[x++];
					for (int y = 0; y < SerialNumber.Length; y++)
						SerialNumber[y] = pkt.Data[x++];

					VersionEprom.Minor = pkt.Data[x++];
					VersionEprom.Major = pkt.Data[x++];
					VersionFlashLo.Minor = pkt.Data[x++];
					VersionFlashLo.Major = pkt.Data[x++];
					VersionFlashHi.Minor = pkt.Data[x++];
					VersionFlashHi.Major = pkt.Data[x++];


					LastRestartColdOrWarm = pkt.Data[x++];
					OptionSwitches = pkt.Data[x++];
					ZLinkConnected = pkt.Data[x++];
					CrisisModeActive = pkt.Data[x++];
					UnacknowledgedActivityLogCount = BitConverter.ToUInt16(pkt.Data, x);
					x += 2;
					ActivityLoggingEnabled = pkt.Data[x++];
				}
			}
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct CpuActivityLoggingInformationReply
	{
		public Byte Code;
		public Byte ActivityLoggingEnabled;
		public UInt16 UnacknowledgedActivityLogCount;
		public UInt16 BufferedActivityLogCount;

//		public CpuActivityLoggingInformationReply(ref Byte[] data)
		public CpuActivityLoggingInformationReply(ref DataPacket5xx pkt)
		{
			Code = 0;
			ActivityLoggingEnabled = 0;
			UnacknowledgedActivityLogCount = 0;
			BufferedActivityLogCount = 0;

			if (pkt.Length >= 5)
			{
				if (pkt.Data != null)
				{
					int x = 0;
					Code = pkt.Data[x++];
					ActivityLoggingEnabled = pkt.Data[x++];
					UnacknowledgedActivityLogCount = BitConverter.ToUInt16(pkt.Data, x);
					x += 2;
					BufferedActivityLogCount = BitConverter.ToUInt16(pkt.Data, x);
					x += 2;
				}
			}
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct CpuTotalCardCountReply
	{
		public Byte Code;
		public UInt32 TotalCardCount;

		public CpuTotalCardCountReply(ref DataPacket5xx pkt)
		{
			Code = 0;
			TotalCardCount = 0;
			if (pkt.Length >= 6)
			{
				if (pkt.Data != null)
				{
					int x = 0;
					Code = pkt.Data[x++];
					TotalCardCount = BitConverter.ToUInt32(pkt.Data, x);
					x += sizeof(UInt32);
				}
			}
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SetAbaSettings
	{
		[Flags]
		public enum FoldingFlags { Off = 0, On = 1 }
		[Flags]
		public enum ClippingFlags { Off = 0, On = 2 }

		public Byte Cmd;
		public Byte Start;
		public Byte End;
		public Byte Flags;
		// .... ...x - 0 = folding off, 1 = folding on (always folds at the 48 bit boundry)
		// .... ..x. - 0 = clip data to 48 bits, 1 = don't clip, send all bits read
		// 0x00 = clip to 48 bits and do not fold
		// 0x01 = clip to 48 bits and fold
		// 0x02 = send all bits and do not fold	- not supported with PIM ABA - treated as 00
		// 0x03 = invalid setting - would be send all bits and fold
	};

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SetWiegandSettings
	{
		public Byte Cmd;
		public Byte Start;
		public Byte End;
	};

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SetCardaxSettings
	{
		public Byte Cmd;
		public Byte Start;
		public Byte End;
	};

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SetReaderLockoutSettings
	{
		public Byte Cmd;
		public Byte MaximumInvalidAttempts;
		public UInt16 LockoutTimeInHundredthsOfSeconds;
		public Byte CardTourManagerControllerNumber;
	};

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PanelDateTime
	{
		public PanelDateTime(DateTimeOffset dt)
		{
			Hour = (Byte)dt.Hour;
			Minute = (Byte)dt.Minute;
			Second = (Byte)dt.Second;
			Month = (Byte)dt.Month;
			Day = (Byte)dt.Day;
			Year = (Byte)(dt.Year % 100);
			Century = (Byte)(dt.Year / 100);
			SecondsFromUniversalTime = 0;
		}
		public Byte Hour;		// 0 - 23
		public Byte Minute;	// 0 - 59
		public Byte Second;	// 0 - 59
		public Byte Month;	// 1 - 12
		public Byte Day;		// 1 - 31
		public Byte Year;		// years since 1900 (98, 99, 100)
		public Byte Century;	// 20 - 99
		public UInt32 SecondsFromUniversalTime;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SetTimeAdjustment
	{
		public SetTimeAdjustment(DateTimeOffset when, DateTimeOffset newTime)
		{
			Cmd = (Byte)Enums.PacketDataCodeTo6xx.CommandLoadTimeAdjustment;
			WhenMonth = (Byte)when.Month;
			WhenDay = (Byte)when.Day;
			WhenHour = (Byte)when.Hour;
			WhenMinute = (Byte)when.Minute;
			NewTime = new PanelDateTime(newTime);
			Spare = new Byte[4];
		}

		public Byte Cmd;
		// when to make the adjustment 
		public Byte WhenMonth;		// 1 - 12
		public Byte WhenDay;			// 1 - 31
		public Byte WhenHour;		// 0 - 23
		public Byte WhenMinute;		// 0 - 59

		// what the new date/time should be set to
		public PanelDateTime NewTime;
		public Byte[] Spare;			// 4 bytes
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SetLedModes
	{
		public enum LedMode : byte
		{
			AllOff = 0,
			GreenOnlySolid = 1,
			RedOnlySolid = 2,
			BothSolid = 3,
			GreenBlink6TimesPerSecond = 4,
			GreenBlink12TimesPerSecond = 5,
			BothBlink12TimesPerSecond = 6,
			RedBlink2TimesPerSecond = 7
		}

		public Byte Cmd;
		public Byte NoLeds;
		public Byte GreenSolid;
		public Byte RedSolid;
		public Byte BothSolid;
		public Byte GreeBlink6TimesPerSecond;
		public Byte GreenBlink12TimesPerSecond;
		public Byte BothBlink12TimesPerSecond;
		public Byte RedBlink2TimesPerSecond;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct CentralStationDialerHeader
	{
		public UInt32 AccountNumber;
		public Byte IOGroupNumber;
		public UInt16 Zone;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SetCrisisModeSettings
	{
		public Byte Cmd;	// 0x7C
		public Byte IoGroupNumber;	// 0 -ff
		// stuff for central station dialer, it is not supported 
		public CentralStationDialerHeader CsdHeader;
		public UInt16 CsdCrisisCode;
		public Byte Flags;	// 0 = do not auto reset
		// 1 = auto reset crisis mode when io group returns safe
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct InitializePort
	{
		public Byte Cmd;				// 0xA3
		public Byte Unused;			// the sub-section within the board
		public Byte PortType;		// the port type
		public Byte DsiRelayCount;	// 1 based, 1 - xxx; 0 = out of service (x40 & x42 types)
	};

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct IoGroupAssignment
	{
		public Byte Offset;			// low byte=index within the partition(0 - 31)
		public Byte IoGroupNumber;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SetControllerAlarmSettings
	{
		public Byte Cmd;				// 0x70
		public IoGroupAssignment Tamper;
		public IoGroupAssignment EmergencyUnlock;
		public IoGroupAssignment AcFailure;
		public IoGroupAssignment LowBattery;
		// added for CSD - header information is loaded via the x7C, crisis config command
		public UInt16 CsdTamperCode;
		public UInt16 CsdEmergencyUnlockCode;
		public UInt16 CsdAcFailurecode;
		public UInt16 CsdLowBatteryCode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct DsiLcdChannel
	{
		public Byte Cmd;				// 0x0C
		public Byte ChannelType;
		public Byte Format;			// 0 = default (normal) mode; 
		// 1 = clock (12 hour clock)
		// 2 = 12 character text on left, 2 digit large number on the right (fill header trailing 8 with 0x20)
		// 3 = 8 character text on left, large digit number on right  (fill header trailing 12 with 0x20)
		public Byte[] HeaderLine1;// 20 bytes = new Byte[4,20];	//[4][20]	// if unused, put 0 in first byte, if used, put something (non-zero) in all 20 bytes (fill all unused characters with 0x20)
		public Byte[] HeaderLine2;// 20 bytes = new Byte[4,20];	//[4][20]	// if unused, put 0 in first byte, if used, put something (non-zero) in all 20 bytes (fill all unused characters with 0x20)
		public Byte[] HeaderLine3;// 20 bytes = new Byte[4,20];	//[4][20]	// if unused, put 0 in first byte, if used, put something (non-zero) in all 20 bytes (fill all unused characters with 0x20)
		public Byte[] HeaderLine4;// 20 bytes = new Byte[4,20];	//[4][20]	// if unused, put 0 in first byte, if used, put something (non-zero) in all 20 bytes (fill all unused characters with 0x20)
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct OtisElevatorFloorBits
	{
		//public OtisElevatorFloorBits(Byte[] mainDoors, Byte[] rearDoors)
		//{
		//	MainCabDoors = new Byte[32];
		//	RearCabDoors = new Byte[32];
		//}

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public Byte[] MainCabDoors;// = new Byte[32];	// 32 bytes
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public Byte[] RearCabDoors;// = new Byte[32];	// 32 bytes
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct InitializeBoardSection
	{
		public Byte Cmd;				// 0xA3
		public Byte Unused;
		public Byte Type;
		public Byte RelayCount;// 1 based, 1 - xxx; 0 = out of service (x40 & x42 types)
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BoardInformationWithBoot
	{
		public Byte Status;	// 0 = no status
		// 1 = ???
		// 2 = ???
		// 3 = normal
		// 4 = flash load in progress
		public Byte FlashResult;	// 0 = no response
		// 1 = auto-update refused
		public UInt16 FlashPackage;// 4 = Reader DPI
		public UInt16 MajorVersion;
		public UInt16 MinorVersion;
		public Byte VersionLetter;
		public Byte SelectedCpuNumber;
		public Byte HeartbeatAge;
		public Byte BootMajorVersion;
		public Byte BootMinorVersion;
		public Byte BootLetterVersion;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BoardInformationWithBootResponse
	{
		public Byte Code;		// 0x68
		public BoardInformationWithBoot[] Boards;

		public BoardInformationWithBootResponse(ref Byte[] data)
		{
			Code = 0;
			Boards = new BoardInformationWithBoot[34];

			if (data != null)
			{
				if (data.Length >= 6)
				{
					int x = 0;
					Code = data[x++];
				}
			}
		}		
	}
}
