
using GalaxySMS.Common.Constants;
using GCS.PanelProtocols.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;

namespace GCS.PanelProtocols.Series6xx.Messages
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Heartbeat
    {
        public Byte Cmd;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SignOnChallenge
    {
        public Byte Cmd;
        public UInt16 Year;
        public UInt16 Month;
        public UInt16 Day;
        public UInt16 Hour;
        public UInt16 Minute;
        public UInt16 Second;
        public UInt16 Random;
        public Byte Sum;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SignOnChallengeWithOemCode
    {
        public SignOnChallengeWithOemCode(object o)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandSignOnChallenge;
            Year = 0;
            Month = 0;
            Day = 0;
            Hour = 0;
            Minute = 0;
            Second = 0;
            Random = 0;
            Sum = 0;
            OemCode = new byte[50];
        }

        public Byte Cmd;
        public UInt16 Year;
        public UInt16 Month;
        public UInt16 Day;
        public UInt16 Hour;
        public UInt16 Minute;
        public UInt16 Second;
        public UInt16 Random;
        public Byte Sum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public byte[] OemCode;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SignOnResponse
    {
        public Byte Cmd;
        public UInt16 Year;
        public UInt16 Month;
        public UInt16 Day;
        public UInt16 Hour;
        public UInt16 Minute;
        public UInt16 Second;
        public UInt16 Random;
        public Byte Sum;
        public UInt16 ClusterGroupId;

        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        //public Byte[] Account;

        public SignOnResponse(Byte[] data)
        {
            Cmd = 0;
            Year = 0;
            Month = 0;
            Day = 0;
            Hour = 0;
            Minute = 0;
            Second = 0;
            Random = 0;
            Sum = 0;
            ClusterGroupId = 0;
            //            Account = new Byte[16];

            if (data != null)
            {
                int x = 0;
                Cmd = data[x++];
                Year = BitConverter.ToUInt16(data, x);
                x += 2;

                Month = BitConverter.ToUInt16(data, x);
                x += 2;
                Day = BitConverter.ToUInt16(data, x);
                x += 2;
                Hour = BitConverter.ToUInt16(data, x);
                x += 2;
                Minute = BitConverter.ToUInt16(data, x);
                x += 2;
                Second = BitConverter.ToUInt16(data, x);
                x += 2;
                Random = BitConverter.ToUInt16(data, x);
                x += 2;
                Sum = data[x++];
                ClusterGroupId = BitConverter.ToUInt16(data, x);
                x += 2;

                //if (data.Length == 36)
                //{
                //    for (int y = 0; y < Account.Length; y++)
                //        Account[y] = data[x++];
                //}
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SetPanelDateTime
    {
        public Byte Cmd;        // 0 - 23
        public Byte hour;       // 0 - 23
        public Byte minute;     // 0 - 59
        public Byte second;     // 0 - 59
        public Byte month;      // 1 - 12
        public Byte day;        // 1 - 31
        public Byte year;       // years since 1900 (98, 99, 100)
        public Byte century;    // 20 - 99
        public UInt32 seconds_from_universal_time;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SetLoggingState
    {
        public Byte Cmd;
        public Byte State;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SetLoggingIndex
    {
        public Byte Cmd;    // 0x63 
        public ushort Index;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SetLoggingParam
    {
        public Byte Cmd;
        public Byte Param;
        public uint OpId;
    }


    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    //public struct SingleByteCommand
    //{
    //    public Byte Cmd;
    //}

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SingleByteCommand
    {
        public Byte Cmd;
        public uint OpId;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InputDeviceCommand
    {
        public Byte Cmd;
        public Byte InputNumber;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OutputDeviceCommand
    {
        public Byte Cmd;
        public Byte OutputNumber;
    }

    /********************************************************************
	 * 
	 * Data structures that are sent from the server to the panel
	 * 
	 * ******************************************************************/

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ResetCpuCommand
    {
        public enum ResetTypeValue : byte { SimulateResetButtonPress = 0, ForceColdReset = 2 }

        public Byte Cmd;
        public ResetTypeValue ResetType;
        //       public Byte ResetType;
    };

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
        public PanelDateTime(DateTime dt)
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
        public Byte Hour;       // 0 - 23
        public Byte Minute; // 0 - 59
        public Byte Second; // 0 - 59
        public Byte Month;  // 1 - 12
        public Byte Day;        // 1 - 31
        public Byte Year;       // years since 1900 (98, 99, 100)
        public Byte Century;    // 20 - 99
        public UInt32 SecondsFromUniversalTime;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TimeAdjustment
    {
        public TimeAdjustment(DateTime when, DateTime newTime)
        {
            WhenMonth = (Byte)when.Month;
            WhenDay = (Byte)when.Day;
            WhenHour = (Byte)when.Hour;
            WhenMinute = (Byte)when.Minute;
            NewTime = new PanelDateTime(newTime);
            Spare = new Byte[4];
        }

        // when to make the adjustment 
        public Byte WhenMonth;      // 1 - 12
        public Byte WhenDay;            // 1 - 31
        public Byte WhenHour;       // 0 - 23
        public Byte WhenMinute;     // 0 - 59

        // what the new date/time should be set to
        public PanelDateTime NewTime;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Byte[] Spare;            // 4 bytes
    }

    public struct SetTimeAdjustment
    {
        //public SetTimeAdjustment()
        //{
        //    Cmd = (Byte)Enums.PacketDataCode6xx.CommandLoadTimeAdjustment;
        //    Adjustments = new TimeAdjustment[2];
        //}

        public Byte Cmd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public TimeAdjustment[] Adjustments;

        // when to make the adjustment 
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
        public Byte GreenBlink6TimesPerSecond;
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
        public Byte Cmd;    // 0x7C
        public Byte ActivateIoGroupNumber;  // 0 -ff
        public Byte ResetIoGroupNumber;  // 0 -ff
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SetServerConsultationSettings
    {
        public Byte Cmd;
        public UInt16 UnlimitedCredentialTimeout;         // 0 = feature disabled, 1 - 0xFFFF = hundredths of seconds (100 = 1 second)
        public UInt16 AccessDecisionOverrideTimeout;// 0 = feature disabled, 1 - 0xFFFF = hundredths of seconds (100 = 1 second)
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IoGroupAssignment
    {
        public Byte Offset;         // low byte=index within the partition(0 - 31)
        public Byte IoGroupNumber;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InputOutputGroupData
    {
        public Byte Cmd;         // 0xA1
        public Byte IoGroupNumber;
        public Byte ArmSchedule;
        public Byte LocalOnly;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SetControllerAlarmSettings
    {
        public Byte Cmd;                // 0x70
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
    public struct EchoNackData
    {
        public Byte Cmd;                // 0xFF
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        public byte[] Data;

        public EchoNackData(string sData)
        {
            Cmd = (byte)PacketDataCodeTo6xx.EchoNack;
            Data = new byte[15];
            if (!string.IsNullOrEmpty(sData))
            {
                var sBytes = Encoding.ASCII.GetBytes(sData);
                var len = Data.Length;
                if (sBytes.Length < len)
                    len = sBytes.Length;
                Array.Copy(sBytes, Data, len);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DsiLcdChannel
    {
        public Byte Cmd;                // 0x0C
        public Byte ChannelType;
        public Byte Format;         // 0 = default (normal) mode; 
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
        public Byte Cmd;                // 0xA3
        public Byte Unused;
        public Byte Type;
        public Byte RelayCount;// 1 based, 1 - xxx; 0 = out of service (x40 & x42 types)

        public InitializeBoardSection(int x)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandInitializeBoardSection;
            Unused = 0;
            Type = 0;
            RelayCount = 0;
        }

        public InitializeBoardSection(byte[] data, int startingOffset)
        {
            Cmd = data[startingOffset++];
            Unused = data[startingOffset++];
            Type = data[startingOffset++];
            RelayCount = data[startingOffset++];
        }

        public GalaxySMS.Common.Enums.PanelInterfaceBoardSectionType GetDecodedSectionType()
        {
            if ((Type & 0xF0) == (byte)PanelInterfaceBoardSectionType.DrmSection)
                return PanelInterfaceBoardSectionType.DrmSection;
            try
            {
                return (PanelInterfaceBoardSectionType)Type;
            }
            catch (Exception ex)
            {

            }
            return PanelInterfaceBoardSectionType.Unused;
        }

        public GalaxySMS.Common.Enums.CredentialReaderDataFormat GetDecodedReaderDataFormat()
        {
            if ((this.Type & 0xF0) == (byte)PanelInterfaceBoardSectionType.DrmSection)
            {
                var df = Type & 0x0F;
                return (GalaxySMS.Common.Enums.CredentialReaderDataFormat)df;
            }

            return GalaxySMS.Common.Enums.CredentialReaderDataFormat.Unknown;
        }

    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BoardInformationWithBoot
    {

        public Byte Status; // 0 = no status
                            // 1 = ???
                            // 2 = ???
                            // 3 = normal
                            // 4 = flash load in progress
        public Byte FlashResult;    // 0 = no response
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

        public BoardInformationWithBoot(Byte[] data)
        {
            int x = 0;
            Status = data[x++];
            FlashResult = data[x++];
            FlashPackage = BitConverter.ToUInt16(data, x);
            x += 2;
            MajorVersion = BitConverter.ToUInt16(data, x);
            x += 2;
            MinorVersion = BitConverter.ToUInt16(data, x);
            x += 2;
            VersionLetter = data[x++];
            SelectedCpuNumber = data[x++];
            HeartbeatAge = data[x++];
            BootMajorVersion = data[x++];
            BootMinorVersion = data[x++];
            BootLetterVersion = data[x++];
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BoardInformationWithBootResponse
    {
        public Byte Code;       // 0x68
        public BoardInformationWithBoot[] Boards;

        public BoardInformationWithBootResponse(Byte[] data, int length)
        {
            Code = 0;
            Boards = new BoardInformationWithBoot[34];

            if (data != null)
            {
                Code = data[0];
                int max_boards = 34;
                if (length == 464)
                    max_boards = 32;

                int sizeofBoardInformationWithBoot = Marshal.SizeOf(typeof(BoardInformationWithBoot));
                for (int b = 0; b < max_boards; b++)
                {
                    byte[] boardInfo = new byte[sizeofBoardInformationWithBoot];

                    Array.Copy(data, (b * sizeofBoardInformationWithBoot) + 1, boardInfo, 0, sizeofBoardInformationWithBoot);
                    //var newBoard = new BoardInformationWithBoot(boardInfo);
                    Boards[b] = new BoardInformationWithBoot(boardInfo);
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RS485ChannelGalaxyDoorModuleData
    {
        public byte RemoteDrmSectionNumber; // 1 or 2
        public ushort VersionMajor;
        public ushort VersionMinor;
        public byte VersionLetter;
        public uint SerialNumber;
        public byte BootVersionMajor;
        public byte BootVersionMinor;
        public byte BootVersionLetter;

        public RS485ChannelGalaxyDoorModuleData(Byte[] data)
        {
            SerialNumber = 0;
            int x = 0;
            RemoteDrmSectionNumber = data[x++];
            VersionMajor = BitConverter.ToUInt16(data, x);
            x += 2;
            VersionMinor = BitConverter.ToUInt16(data, x);
            x += 2;
            VersionLetter = data[x++];

            SerialNumber = BitConverter.ToUInt32(data, x);
            x += 4;

            BootVersionMajor = data[x++];
            BootVersionMinor = data[x++];
            BootVersionLetter = data[x++];
        }

    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RS485ChannelGalaxyDoorModuleStatusResponse
    {
        public const UInt16 NumberOfModules = 16;

        public Byte Code;       // 0x1F
        public Byte ChannelMode;    // 0x46 = reader modules, 0x49 = input modules
        public RS485ChannelGalaxyDoorModuleData[] Modules;

        public RS485ChannelGalaxyDoorModuleStatusResponse(Byte[] data)
        {
            Code = 0;
            ChannelMode = 0;
            Modules = new RS485ChannelGalaxyDoorModuleData[NumberOfModules];

            if (data != null)
            {
                int x = 0;
                Code = data[x++];
                ChannelMode = data[x++];

                int sizeofModuleInfo = Marshal.SizeOf(typeof(RS485ChannelGalaxyDoorModuleData));
                for (UInt16 b = 0; b < NumberOfModules; b++)
                {
                    byte[] moduleInfo = new byte[sizeofModuleInfo];

                    Array.Copy(data, (b * sizeofModuleInfo) + x, moduleInfo, 0, sizeofModuleInfo);
                    var newModule = new RS485ChannelGalaxyDoorModuleData(moduleInfo);
                    Modules[b] = newModule;
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RS485ChannelGalaxyInputModuleData
    {
        public byte ModulePresent; // .... ...x  1 = module is there, 0 = module is not present

        public RS485ChannelGalaxyInputModuleData(Byte[] data)
        {
            int x = 0;
            ModulePresent = data[x++];
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RS485ChannelGalaxyInputModuleStatusResponse
    {
        public const UInt16 NumberOfModules = 16;

        public Byte Code;       // 0x1F
        public Byte ChannelMode;    // 0x46 = reader modules, 0x49 = input modules
        // position 0 = module 16, index 1 = 15 = modules 1-15
        public RS485ChannelGalaxyInputModuleData[] Modules;

        public RS485ChannelGalaxyInputModuleStatusResponse(Byte[] data)
        {
            Code = 0;
            ChannelMode = 0;
            Modules = new RS485ChannelGalaxyInputModuleData[NumberOfModules];

            if (data != null)
            {
                int x = 0;
                Code = data[x++];
                ChannelMode = data[x++];

                int sizeofModuleInfo = Marshal.SizeOf(typeof(RS485ChannelGalaxyInputModuleData));
                // now do module 16, which is in position 0
                var moduleInfo = new byte[sizeofModuleInfo];

                Array.Copy(data, x, moduleInfo, 0, sizeofModuleInfo);
                var newModule = new RS485ChannelGalaxyInputModuleData(moduleInfo);
                Modules[NumberOfModules - 1] = newModule;

                for (UInt16 b = 1; b < NumberOfModules; b++)
                {
                    moduleInfo = new byte[sizeofModuleInfo];

                    Array.Copy(data, (b * sizeofModuleInfo) + x, moduleInfo, 0, sizeofModuleInfo);
                    newModule = new RS485ChannelGalaxyInputModuleData(moduleInfo);
                    Modules[b - 1] = newModule;
                }

            }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ReaderNodeTypeUnion
    {
        [FieldOffset(0)] public Byte Node;
        [FieldOffset(0)] public Byte Type;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OtisReaderDecData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public Byte[] OtisDECIPAddress;     // the lower 2 bytes of the IP address for the associated DEC (Keypad or Touch Screen)// All addresses start with 192.168.xxx.xxx
                                            // this data is the xxx.xxx (lower 2 bytes of the IP address)
        public UInt16 OtisDECGroupBits;     // xxxx xxxx xxx. .... Bitmask of the OTIS_DEC_CONTROL BLOCK 1... .... .... .... = BLOCK 0 
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct KoneReaderDopData
    {
        public Byte KoneDOPId;     // Kone DOP Id
        public UInt16 KoneFloorId;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct KoneReaderCopData
    {
        public Byte KoneElevatorId;        // Kone Elevator Id
        public Byte KoneGroupId;	// 
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ReaderOtisKoneElevatorDataUnion
    {
        [FieldOffset(0)] public OtisReaderDecData Otis;
        [FieldOffset(0)] public KoneReaderDopData KoneDop;
        [FieldOffset(0)] public KoneReaderCopData KoneCop;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CentralStationDialerConfigurationData
    {
        public CentralStationDialerHeader Header;
        public UInt16 DoorForcedOpen;
        public UInt16 DoorContactTrouble;
        public UInt16 Duress;
        public UInt16 HeartbeatFailure;
        public UInt16 OpenTooLong;
        public UInt16 AccessDenied;	// access denied
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ReaderPort6xx
    {
        [Flags]
        public enum ForgivePassbackAfterFlags : byte
        {
            DontDecrementLimitedSwipeExpireCount = 0x80
        }

        [Flags]
        public enum Relay2TriggerFlags : byte
        {
            DeniedForKeys = 0x2,
            Duress = 0x4,
            AccessGranted = 0x8,
            PassbackViolation = 0x10,
            InvalidAccessAttempt = 0x20,
            OpenTooLong = 0x40,
            IllegalOpen = 0x80
        }

        [Flags]
        public enum Options1Flags : byte
        {
            EnergizeRelay1DuringArmDelay = 0x1,
            DisableWhenDoorGroupIsActive = 0x2,
            ActivateDoorGroupWhenUnsecure = 0x4,
            DuressEnabled = 0x8,
            DisableREXMessage = 0x10,
            UnlockOnREX = 0x20,
            RequireTwoValidCredentials = 0x40,
            AllowPassbackAccess = 0x80
        }


        [Flags]
        public enum Options2Flags : byte
        {
            ReaderSendsHeartbeats = 0x1,
            DoorContactHasParallelResistor = 0x2,
            DoorContactHasSeriesResistor = 0x4,
            RequireDoorToOpenForAccessGranted = 0x8,
            DenyAccessIfUserHasKeys = 0x10,
            PinSpecifiesRecloseTime = 0x20,
            Relay2LatchingMode = 0x40,
            RequireValidAccessForAutoUnlock = 0x80
        }

        [Flags]
        public enum Options3Flags : byte
        {
            DeEnergizeRelay1WhenContactOpens = 0x1,
            GenerateDoorContactChangeLogMessages = 0x8,
            PinInformationOnly = 0x10,
            SuppressDoorClosedLogMessage = 0x20,
            SuppressOpenTooLongLogMessage = 0x40,
            SuppressIllegalOpenLogMessage = 0x80
        }

        [Flags]
        public enum Options4Flags : byte
        {
            ReaderIsMemberOfCardTour = 0x40,
            IgnoreNotInSystemEvents = 0x80
        }

        [Flags]
        public enum UserAuthorityFlags : byte
        {
            NoServerResponseGrantAccess = 0x4,
            NoServerResponseDenyAccess = 0x8,
            DeferToServerForAccessDenied = 0x40,
            DeferToServerForAccessGranted = 0x80
        }

        [Flags]
        public enum ReaderNodeTypeFlags : byte
        {
            None = 0,
            DrmReader = 0x10,
            Dsi485DoorModuleReader = 0x50
        }

        public Byte Cmd;                        // 0x0C
        public ReaderNodeTypeUnion NodeType;    // for PIM readers, this value is the reader # (subsection/node) for DSI devices
                                                // for DSI 485 Door module readers, this must be the 0x50 - x5B (reader type), instead of the reader #/Sub_section #. 
                                                // for DSI 485 The sub_section must be in the header with the (upper 5 bits of the section #)
                                                // For ASSA-Abloy 1 - 16, not related to hardware address at all
        public IoGroupAssignment IllegalOpenAssignment;
        public IoGroupAssignment InvalidAttemptAssignment;
        public IoGroupAssignment PassbackViolationAssignment;
        public IoGroupAssignment OpenTooLongAssignment;
        public IoGroupAssignment DuressAssignment;
        public IoGroupAssignment DoorGroupAssignment;
        public Byte LockIoGroup;    // re-lock when the io group goes from off to on (unarmed ) ( 0 - feature not used, 1 - 255 - io group that triggers it )
                                    // takes the same action as if the PC Lock command was issued
        public Byte UnlockIoGroup;  // unlock when the io group goes from off to on (unarmed ) ( 0 - feature not used, 1 - 255 - io group that triggers it )
                                    // takes the same action as if the PC Unlock command was issued
        public IoGroupAssignment AccessGrantedAssignment;
        public Byte IntoPassbackArea;   // Passback area you enter when access thru this reader
        public Byte FromPassbackArea;   // 0 - ignore, 1 - 255 valid area number
        public Byte ForgivePassbackAfter;// 0=never  
                                         // 1= 1/day 00:00  
                                         // 2= 2/day 00:00 12:00
                                         // 3= 4/day 00:00 06:00 12:00 18:00
                                         // 4= 12/day every 2 hours
                                         // 5= 24/day every hour
                                         // 6= 48/day every 30 minutes 
                                         // 1... .xxx - MSB indicates don't decriment limited swipe expire value, lowest 3 bits = passback forgive interval
        public Byte FreeAccessSchedule;         // time schedule when unlocked: relay 1
        public Byte PinRequiredSchedule;            // time schedule when pin is required (not used for PIM)

        public UInt16 UnlockDurationHundredths;        // seconds * 100: relay 1 (not used for PIM)
        public UInt16 RecloseTimeHundredths;       // seconds * 100: relay 1 
        public UInt16 UnlockDelayHundredths;       // in seconds * 100	how long to delay R1 energize after valid card (not used for PIM)
        public Byte DisableIllegalOpenSchedule;  // 0 - 255 time schedule ID when Forced Open is ignored
        public Byte DisableStillOpenSchedule;   // 0 - 255 time schedule ID when Still Open is ignored                              


        public UInt16 Relay2Delay;           // in seconds * 100 (not used for PIM)
        public Byte Relay2Schedule;             // 0 - 255 time schedule ID when Forced Open is ignored (not used for PIM)
        public UInt16 Relay2Duration;        // in seconds (not used for PIM) (prior to 4.23, this was in hundredths of seconds)

        public Byte Relay2Triggers;    // (not used for PIM)
                                       //  1... ....  R2illegal  relay 2 comes on if illegal opening
                                       //  .1.. ....  R2tooLong  relay 2 comes on if open too long
                                       //  ..1. ....  R2invalid  relay 2 comes on if invalid access
                                       //  ...1 ....  R2passback relay 2 comes on if passback violation
                                       //  .... 1...  R2valid    relay 2 comes on if valid unlock
                                       //  .... .1..  R2duress   relay 2 comes on if duress   
                                       //  .... ..1.  R2DeniedForKeys	- relay 2 on if the user is denied access because he possesses keys

        public Byte Options1;
        //  1... ....  softPB        allow soft passback access
        //  .1.. ....  two_man_rule  on if two cards are needed (not used for PIM)
        //  ..1. ....  REXunlock     unlock on REX (not used for PIM)
        //  ...1 ....  REXmsgOFF     disable REX msg 
        //  .... 1...  duress        enable duress (not used for PIM)
        //  .... .1..  activate      activate group Partition on unlock (not used for PIM)
        //  .... ..1.  disable       disable reader when group is active (not used for PIM)
        //  .... ...1  R1 = arm delay energize relay 1 during arm delay (not used for PIM)

        public Byte Options2;          // more options (not used for PIM)
                                       // 1... ....	Snow Day feature (valid card must be used before auto unlock happens ) (not used for PIM)
                                       // .1.. ....    Relay 2 latching mode. Other relay 2 options should be cleared (timing and sch) (not used for PIM)
                                       // ..1. ....	Second PIN dictates RECLOSE TIME (eliminates PIN Reqd and 2 man rule options ) (not used for PIM)
                                       // ...1 ....	on = no access if the user possess keys (not used for PIM)
                                       //// .... 1...	on = REX indicates which reader on a PA was swiped (not used for PIM)
                                       // .... 1...	on = Valid Access requires the door contact to be opened
                                       // .... .1..	1 = using series resistor - trouble short enabled (not used for PIM)
                                       // .... ..1.	1 = using parallel resistor - trouble open enabled (not used for PIM)
                                       // .... ...1	1 = enable reader heartbeat function (not used for PIM)


        public Byte Options3;
        //  1... ....  suppress door forced open message
        //  .1.. ....  suppress door still open message
        //  ..1. ....  suppress door closed message
        //  ...1 ....  REQUIRE PIN FOR INFO PURPOSES - Flash V1.12 supports (not used for PIM)
        //  .... ...1  lock relay 1 when DC closes rather than when it opens (not used for PIM)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Byte[] IoGroupsToDisarmOnValidAccess;    // Will disarm these io groups when a valid access occurs 
        public IoGroupAssignment HeartbeatAssignment;

        public Byte Options4;// DoorFlags;     // more options for future growth (not used for PIM)
                             // 1... ....	Ignore Not In Systems, if it looks the card up and not found, it will not do the red state, will not trigger relay 2, no log message, no LCD message
                             //				does 20 ms delay then goes back reading
                             // .1.. ....	1 = that reader is a member of a card tour

        public Byte ElevatorOutputsBoard;  // (not used for PIM), specifies the DSI board # for Galaxy elevator relay boards, for OTIS & Kone it specifies the OTIS/Kone CPU board #
        public Byte ElevatorOutputsSection;    // (not used for PIM), DSI Section # for Galaxy elevator relay boards, 0x11 for OTIS, Kone - 0x21 = DOP, 0x22 = COP

        public CentralStationDialerConfigurationData CentralStationDialerData;
        public Byte PimHubNumber;        // 1-16 - which PIM is the reader on
                                         // for ASSA Abloy, this is the physical address (Upper nibble 0-7, lower nibble 1 - F)

        public Byte LCDBoardNumber;      // 1 - 16 (board # in the can)
        public Byte LCDSectionNumber;   // 1 or 2 (dsi section1 number)
        public Byte LCDDisplayNumber;  // 1 - 16
        public UInt16 LCDOptions;            // bit options
                                             // xxxx xxxx xxxx xxxx
                                             // 

        public Byte UserAuthority;     // looks up user first, then depending on the bits set in this byte, it will give the event server the opportunity to override the panel decision
                                       // if both x80 & x40 are set, then the panel will aways ask the event server for authority
                                       // (0x80) 1... .... = if access is valid, then check with event server before granting access to allow event server to override access
                                       // (0x40) .1.. .... = if access is denied, then check with the event server to see if event server wants to override
                                       // (0x20) ..1. .... unused
                                       // (0x10) ...1 .... unused
                                       // (0x08) .... 1... deny access if the event server fails to respond in timely fashion
                                       // (0x04) .... .1.. grant access unconditionally if event servers fails to respond
                                       //					if neither 0x08 or 0x04 are set OR if both are set, then use local rules if event server fails to respond
                                       // (0x02) .... ..1. unused
                                       // (0x01) .... ...1 unused
        public Byte DoorNumber;            // 1 - 64. Used by the exception/personalized access rules/group feature
                                           //BYTE	OtisDECIPAddress[2];	// the lower 2 bytes of the IP address for the associated DEC (Keypad or Touch Screen)// All addresses start with 192.168.xxx.xxx
                                           //							// this data is the xxx.xxx (lower 2 bytes of the IP address)
                                           //WORD	OtisDECGroupBits;	// xxxx xxxx xxx. .... Bit-mask of the OTIS_DEC_CONTROL BLOCK 1... .... .... .... = BLOCK 0 
                                           //							//															 .... .... ..1. .... = BLOCK 10 														  
                                           //        
                                           //public ReaderOtisKoneElevatorDataUnion OtisKoneElevatorData;  // This is a problem, trying to simulate a C++ union of non-primitive objects. For now, i simply plugged in a 4 byte array until i can get back to this
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Byte[] OtisKoneElevatorData;

        // new Schlage IPB button values
        public Byte PrivacyOfficeMultiFactorMode;
        public Byte CrisisModeUnlockSchedule;

        public ReaderPort6xx(object o)
        {
            this.Cmd = (byte)PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData;
            NodeType = new ReaderNodeTypeUnion();
            IllegalOpenAssignment = new IoGroupAssignment();
            InvalidAttemptAssignment = new IoGroupAssignment();
            PassbackViolationAssignment = new IoGroupAssignment();
            OpenTooLongAssignment = new IoGroupAssignment();
            DuressAssignment = new IoGroupAssignment();
            DoorGroupAssignment = new IoGroupAssignment();
            HeartbeatAssignment = new IoGroupAssignment();
            AccessGrantedAssignment = new IoGroupAssignment();
            LockIoGroup = 0;
            UnlockIoGroup = 0;
            IntoPassbackArea = 0;
            FromPassbackArea = 0;
            ForgivePassbackAfter = 0;
            FreeAccessSchedule = 0;
            PinRequiredSchedule = 0;
            UnlockDurationHundredths = 0;
            RecloseTimeHundredths = 0;
            UnlockDelayHundredths = 0;
            DisableIllegalOpenSchedule = 0;
            DisableStillOpenSchedule = 0;
            Relay2Delay = 0;
            Relay2Schedule = 0;
            Relay2Duration = 0;
            Relay2Triggers = 0;
            Options1 = 0;
            Options2 = 0;
            Options3 = 0;

            IoGroupsToDisarmOnValidAccess = new byte[4];
            Options4 = 0;
            ElevatorOutputsBoard = 0;
            ElevatorOutputsSection = 0;

            CentralStationDialerData = new CentralStationDialerConfigurationData();
            PimHubNumber = 0;
            LCDBoardNumber = 0;
            LCDSectionNumber = 0;
            LCDDisplayNumber = 0;
            LCDOptions = 0;
            UserAuthority = 0;
            DoorNumber = 0;
            OtisKoneElevatorData = new byte[4];

            PrivacyOfficeMultiFactorMode = 0;
            CrisisModeUnlockSchedule = 0;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AccessGroupSchedule
    {
        public Byte Cmd;                // 0x12
        public Byte Unused;
        public UInt16 AccessGroupNumber;
        public Byte ScheduleNumber;

        public AccessGroupSchedule(object o)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadAccessGroupSchedule;
            Unused = 0;
            AccessGroupNumber = 0;
            ScheduleNumber = 0;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AccessGroupSchedules
    {
        public const UInt16 NumberOfSchedules = 100;

        public Byte Cmd;                // 0x0D
        public Byte SectionNumber;
        public UInt16 StartingAccessGroupNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfSchedules)]
        public Byte[] ScheduleNumbers;

        public AccessGroupSchedules(UInt16 startingAccessGroupNumber)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadAccessGroupSchedulesForDoor;
            SectionNumber = 0;
            StartingAccessGroupNumber = startingAccessGroupNumber;
            ScheduleNumbers = new byte[NumberOfSchedules];
        }

        public AccessGroupSchedules(byte[] data, int startingIndex)
        {
            Cmd = data[startingIndex++];
            SectionNumber = data[startingIndex++];
            StartingAccessGroupNumber = BitConverter.ToUInt16(data, startingIndex);
            startingIndex += 2;
            ScheduleNumbers = new byte[NumberOfSchedules];
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AccessGroupClearRange
    {
        public Byte Cmd;                // 0x15
        public Byte SectionNumber;
        public UInt16 StartingAccessGroupNumber;
        public UInt16 EndingAccessGroupNumber;

        public AccessGroupClearRange(UInt16 startingAccessGroupNumber, UInt16 endingAccessGroupNumber)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandClearAccessGroupRange;
            SectionNumber = 0;
            StartingAccessGroupNumber = startingAccessGroupNumber;
            EndingAccessGroupNumber = endingAccessGroupNumber;
        }

        public AccessGroupClearRange(byte[] data, int startingIndex)
        {
            Cmd = data[startingIndex++];
            SectionNumber = data[startingIndex++];
            StartingAccessGroupNumber = BitConverter.ToUInt16(data, startingIndex);
            startingIndex += 2;
            EndingAccessGroupNumber = BitConverter.ToUInt16(data, startingIndex);
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SetAccessGroupCrisisGroup
    {
        public Byte Cmd;    // 0xAB
        public UInt16 AccessGroupNumber;  // 0 -2000
        public UInt16 CrisisGroupNumber;  // 0 -2000
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SetAccessGroupsCrisisGroups
    {
        public const UInt16 NumberOfAccessGroups = 100;

        public Byte Cmd;    // 0x16
        public UInt16 StartingAccessGroupNumber;  // 0 -2000
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfAccessGroups)]
        public UInt16[] CrisisGroupNumbers;  // 0 -2000

        public SetAccessGroupsCrisisGroups(UInt16 startingAccessGroupNumber)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadAccessGroupsCrisisGroups;
            StartingAccessGroupNumber = startingAccessGroupNumber;
            CrisisGroupNumbers = new UInt16[NumberOfAccessGroups];
        }
    }


    /********************************************************************
	 * 
	 * Data structures that are sent from the panel to the server
	 * 
	 * ******************************************************************/

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CpuVersionInfo
    {
        public Byte Minor;
        public Byte Major;
        public Byte LetterCode;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CpuInformationReply
    {
        public Byte Code;
        public Byte Unused1;
        public Byte[] SerialNumber;// 8 = new Byte[8];
        public UInt16 ModelNumber;
        public CpuVersionInfo Version;
        public Byte Unused2;
        public Byte LastRestartColdOrWarm;
        public Byte Unused3;
        public Byte Unused4;
        public Byte CrisisModeActive;
        public UInt16 UnacknowledgedActivityLogCount;
        public Byte ActivityLoggingEnabled;
        public Byte CardCodeFormat;

        public CpuInformationReply(Byte[] data)
        {
            Code = 0;
            Unused1 = 0;
            SerialNumber = new Byte[8];
            ModelNumber = 0;
            Version.Minor = 0;
            Version.Major = 0;
            Version.LetterCode = 0;
            Unused2 = 0;
            LastRestartColdOrWarm = 0;
            Unused3 = 0;
            Unused4 = 0;
            CrisisModeActive = 0;
            UnacknowledgedActivityLogCount = 0;
            ActivityLoggingEnabled = 0;
            CardCodeFormat = 0;

            if (data != null)
            {
                if (data.Length >= 23)
                {
                    int x = 0;
                    Code = data[x++];
                    Unused1 = data[x++];
                    for (int y = 0; y < SerialNumber.Length; y++)
                        SerialNumber[y] = data[x++];
                    ModelNumber = BitConverter.ToUInt16(data, x);
                    x += 2;
                    Version.Minor = data[x++];
                    Version.Major = data[x++];
                    Version.LetterCode = data[x++];
                    Unused2 = data[x++];
                    LastRestartColdOrWarm = data[x++];
                    Unused3 = data[x++];
                    Unused4 = data[x++];
                    CrisisModeActive = data[x++];
                    UnacknowledgedActivityLogCount = BitConverter.ToUInt16(data, x);
                    x += 2;
                    ActivityLoggingEnabled = data[x++];
                    CardCodeFormat = data[x++];
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

        public CpuActivityLoggingInformationReply(Byte[] data)
        {
            Code = 0;
            ActivityLoggingEnabled = 0;
            UnacknowledgedActivityLogCount = 0;
            BufferedActivityLogCount = 0;

            if (data != null)
            {
                if (data.Length >= 6)
                {
                    int x = 0;
                    Code = data[x++];
                    ActivityLoggingEnabled = data[x++];
                    UnacknowledgedActivityLogCount = BitConverter.ToUInt16(data, x);
                    x += 2;
                    BufferedActivityLogCount = BitConverter.ToUInt16(data, x);
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

        public CpuTotalCardCountReply(Byte[] data)
        {
            Code = 0;
            TotalCardCount = 0;
            if (data != null)
            {
                if (data.Length >= 6)
                {
                    int x = 0;
                    Code = data[x++];
                    TotalCardCount = BitConverter.ToUInt32(data, x);
                    x += sizeof(UInt32);
                }
            }
        }
    }


    [StructLayout(LayoutKind.Explicit)]
    public struct KeyPinBitCount
    {
        [FieldOffset(0)] public ushort KeyNumber;
        [FieldOffset(0)] public ushort Pin;
        [FieldOffset(0)] public ushort AlarmPanelZone;
        [FieldOffset(0)] public byte BitCount;
    }

    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    //public struct CardEventLogData
    //{
    //    public const UInt16 NumberOfCardBytes = 6;
    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfCardBytes)]
    //    public byte[] Data;
    //    public KeyPinBitCount KeyPinBitCount;
    //    public CardEventLogData(Byte[] data)
    //    {
    //        Data = new byte[NumberOfCardBytes];
    //        KeyPinBitCount = new KeyPinBitCount();
    //        if (data != null)
    //        {
    //            UInt16 x = 0;
    //            for (; x < NumberOfCardBytes; x++)
    //                Data[x] = data[x];
    //            KeyPinBitCount.KeyNumber = BitConverter.ToUInt16(data, x);
    //        }
    //    }
    //}

    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    //public struct CommandEventLogData
    //{
    //    public const UInt16 NumberOfBytes = 7;

    //    public Byte Code;
    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfBytes)]
    //    public byte[] Data;

    //    public CommandEventLogData(Byte[] data)
    //    {
    //        Code = 0;
    //        Data = new byte[NumberOfBytes];

    //        if (data != null)
    //        {
    //            if (data.Length >= 7)
    //            {
    //                int x = 0;
    //                Code = data[x++];

    //                data.CopyTo(Data, 1);
    //            }
    //        }
    //    }
    //}

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct CardEventLogData
    {
        public const UInt16 NumberOfCardBytes = 6;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfCardBytes)]
        [FieldOffset(0)] public byte[] Data;
        [FieldOffset(6)] public KeyPinBitCount KeyPinBitCount;
        public CardEventLogData(Byte[] data)
        {
            Data = new byte[NumberOfCardBytes];
            KeyPinBitCount = new KeyPinBitCount();
            if (data != null)
            {
                UInt16 x = 0;
                for (; x < NumberOfCardBytes; x++)
                    Data[x] = data[x];
                KeyPinBitCount.KeyNumber = BitConverter.ToUInt16(data, x);
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct CommandEventLogData
    {
        public const UInt16 NumberOfBytes = 7;

        [FieldOffset(0)] public Byte Code;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfBytes)]
        [FieldOffset(1)] public byte[] Data;

        public CommandEventLogData(Byte[] data)
        {
            Code = 0;
            Data = new byte[NumberOfBytes];

            if (data != null)
            {
                if (data.Length >= 7)
                {
                    int x = 0;
                    Code = data[x++];

                    data.CopyTo(Data, 1);
                }
            }
        }
    }

    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    //public struct CardTourLogData
    //{
    //    public const UInt16 NumberOfCardBytes = 6;

    //    public byte LastStopNumber;

    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfCardBytes)]
    //    public byte[] Data;

    //    public CardTourLogData(Byte[] data)
    //    {
    //        LastStopNumber = 0;
    //        Data = new byte[NumberOfCardBytes];
    //        if (data != null && data.Length >= 7)
    //        {
    //            int x = 0;
    //            LastStopNumber = data[x++];
    //            for (int y = 0; y < NumberOfCardBytes; y++)
    //                Data[y] = data[x++];
    //        }
    //    }
    //}

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct LogDataUnion
    {
        public const UInt16 NumberOfBytes = 8;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfBytes)]
        [FieldOffset(0)] public byte[] RawBytes;
        //[FieldOffset(0)] public CardEventLogData CardEventData;
        //[FieldOffset(0)] public CommandEventLogData CommandEventData;
        //[FieldOffset(0)] public CardTourLogData CardTourLogData;
        [FieldOffset(0)] public byte InputOutputPointNumber;
        [FieldOffset(0)] public byte AssaData;
        [FieldOffset(0)] public byte Rs485LockNumber;
        [FieldOffset(0)] public byte DoorContactStatus;
        [FieldOffset(0)] public byte VeridtMultiFactorMode;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ActivityLogMessageFromCpu
    {
        public Byte Code;           // 0x60
        public UInt16 BufferIndex;
        public Byte LogType;
        public Byte Month;      // 1 - 12
        public Byte Day;            // 1 - 31
        public Byte Hour;           // 0 - 23
        public Byte Minute;     // 0 - 59
        public Byte Second;     // 0 - 59
        public Byte BoardNumber;// 1 - 32
        public Byte SectionEncoded;
        public Byte[] Data;
        public ActivityLogMessageFromCpu(Byte[] data)
        {
            Code = 0;
            BufferIndex = 0;
            LogType = 0;
            Month = 0;
            Day = 0;
            Hour = 0;
            Minute = 0;
            Second = 0;
            BoardNumber = 0;
            SectionEncoded = 0;
            Data = new Byte[8];

            int x = 0;
            Code = data[x++];
            BufferIndex = BitConverter.ToUInt16(data, x);
            x += sizeof(UInt16);
            LogType = data[x++];
            Month = data[x++];
            Day = data[x++];
            Hour = data[x++];
            Minute = data[x++];
            Second = data[x++];
            BoardNumber = data[x++];
            SectionEncoded = data[x++];
            Array.Copy(data, x, Data, 0, Data.Length);
        }
        
        public DateTime DateTime
        {
            get
            {
                int year = DateTime.Now.Year;
                if (Month > (byte)DateTime.Now.Month)
                    year -= 1;  // if the panel reports a month that is greater than the current month, assume it was last year 
                try
                {
                    return new DateTime(year, Month, Day, Hour, Minute, Second);
                }
                catch (Exception)
                {
                    return System.DateTime.MinValue;
                }
            }
        }

        public UInt16 SectionNumber
        {
            get
            {
                try
                {
                    return Utilities.ExtractSection(this.SectionEncoded);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public UInt16 NodeNumber
        {
            get
            {
                try
                {
                    return Utilities.ExtractSubSection(this.SectionEncoded);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OtisElevatorActivityLogMessageFromCpu
    {
        public Byte Code;           // 0x60
        public UInt16 BufferIndex;
        public Byte LogType;
        public Byte Month;      // 1 - 12
        public Byte Day;            // 1 - 31
        public Byte Hour;           // 0 - 23
        public Byte Minute;     // 0 - 59
        public Byte Second;     // 0 - 59
        public Byte BoardNumber;// 1 - 32
        public Byte GroupCar;
        public Byte[] Data;
        public Byte RequestedFloorNumber;
        public Byte CarBitFaultCode;

        public OtisElevatorActivityLogMessageFromCpu(Byte[] data)
        {
            Code = 0;
            BufferIndex = 0;
            LogType = 0;
            Month = 0;
            Day = 0;
            Hour = 0;
            Minute = 0;
            Second = 0;
            BoardNumber = 0;
            GroupCar = 0;
            Data = new Byte[6];

            int x = 0;
            Code = data[x++];
            BufferIndex = BitConverter.ToUInt16(data, x);
            x += sizeof(UInt16);
            LogType = data[x++];
            Month = data[x++];
            Day = data[x++];
            Hour = data[x++];
            Minute = data[x++];
            Second = data[x++];
            BoardNumber = data[x++];
            GroupCar = data[x++];
            Array.Copy(data, x, Data, 0, Data.Length);
            x += Data.Length;
            RequestedFloorNumber = data[x++];
            CarBitFaultCode = data[x++];
        }

        public DateTime DateTime
        {
            get
            {
                int year = DateTime.Now.Year;
                if (Month > (byte)DateTime.Now.Month)
                    year -= 1;  // if the panel reports a month that is greater than the current month, assume it was last year 
                try
                {
                    return new DateTime(year, Month, Day, Hour, Minute, Second);
                }
                catch (Exception)
                {
                    return System.DateTime.MinValue;
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CardTourActivityLogMessageFromCpu
    {
        public Byte Code;           // 0x60
        public UInt16 BufferIndex;
        public Byte LogType;
        public Byte Month;      // 1 - 12
        public Byte Day;            // 1 - 31
        public Byte Hour;           // 0 - 23
        public Byte Minute;     // 0 - 59
        public Byte Second;     // 0 - 59
        public Byte[] Data;     // 3 bytes that have multiple meanings depending on which event it is
        public Byte[] CardData;
        public Byte Spare;

        public CardTourActivityLogMessageFromCpu(Byte[] data)
        {
            Code = 0;
            BufferIndex = 0;
            LogType = 0;
            Month = 0;
            Day = 0;
            Hour = 0;
            Minute = 0;
            Second = 0;
            Data = new Byte[3];
            CardData = new Byte[6];
            Spare = 0;

            int x = 0;
            Code = data[x++];
            BufferIndex = BitConverter.ToUInt16(data, x);
            x += sizeof(UInt16);
            LogType = data[x++];
            Month = data[x++];
            Day = data[x++];
            Hour = data[x++];
            Minute = data[x++];
            Second = data[x++];
            Array.Copy(data, x, Data, 0, Data.Length);
            x += Data.Length;
            Array.Copy(data, x, CardData, 0, CardData.Length);
            x += CardData.Length;
            Spare = data[x++];
        }

        public DateTime DateTime
        {
            get
            {
                int year = DateTime.Now.Year;
                if (Month > (byte)DateTime.Now.Month)
                    year -= 1;  // if the panel reports a month that is greater than the current month, assume it was last year 
                try
                {
                    return new DateTime(year, Month, Day, Hour, Minute, Second);
                }
                catch (Exception)
                {
                    return System.DateTime.MinValue;
                }
            }
        }
    }

    public class ActivityLogCardMessageConstants
    {
        public const UInt16 ExtendedCardCodeMessageSize = 13;
        public const UInt16 StandardCardCodeMessageSize = 6;
        public const UInt16 FullCardCodeMessageSize = (ExtendedCardCodeMessageSize * 2) + StandardCardCodeMessageSize;
    };


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct StandardCardDataActivityLogMessageFromCpu
    {
        public Byte Code;           // 0x60
        public UInt16 BufferIndex;
        public Byte LogType;
        public Byte Month;      // 1 - 12
        public Byte Day;            // 1 - 31
        public Byte Hour;           // 0 - 23
        public Byte Minute;     // 0 - 59
        public Byte Second;     // 0 - 59
        public Byte BoardNumber;// 1 - 32
        public Byte SectionEncodedNumber;
        public Byte[] CardCode;
        public Byte BitCount;
        public UInt16 PinNumberEntered;
        public UInt16 CardCommand;

        public StandardCardDataActivityLogMessageFromCpu(Byte[] data)
        {
            Code = 0;
            BufferIndex = 0;
            LogType = 0;
            Month = 0;
            Day = 0;
            Hour = 0;
            Minute = 0;
            Second = 0;
            BoardNumber = 0;
            SectionEncodedNumber = 0;
            CardCode = new Byte[ActivityLogCardMessageConstants.StandardCardCodeMessageSize];
            PinNumberEntered = 0;
            BitCount = 0;
            CardCommand = 0;

            int x = 0;
            Code = data[x++];
            BufferIndex = BitConverter.ToUInt16(data, x);
            x += sizeof(UInt16);
            LogType = data[x++];
            Month = data[x++];
            Day = data[x++];
            Hour = data[x++];
            Minute = data[x++];
            Second = data[x++];
            BoardNumber = data[x++];
            SectionEncodedNumber = data[x++];
            switch (LogType)
            {
                case (byte)PanelActivityLogMessageCode.CardCommand:
                    CardCommand = data[x++];
                    Array.Copy(data, x, CardCode, 0, CardCode.Length);
                    break;

                case (byte)PanelActivityLogMessageCode.AccessGrantedWithPinData:
                    PinNumberEntered = BitConverter.ToUInt16(data, x);
                    x += sizeof(UInt16);
                    break;
                default:
                    Array.Copy(data, x, CardCode, 0, CardCode.Length);
                    x += CardCode.Length;
                    BitCount = data[x++];
                    break;
            }
        }

        public UInt16 SectionNumber => Utilities.ExtractSection(SectionEncodedNumber);

        public UInt16 NodeNumber => Utilities.ExtractSubSection(SectionEncodedNumber);

        //public DateTime DateTime
        //{
        //    get
        //    {
        //        int year = DateTime.Now.Year;
        //        if (Month > (byte)DateTime.Now.Month)
        //            year -= 1;  // if the panel reports a month that is greater than the current month, assume it was last year 
        //        return new DateTime(year, Month, Day, Hour, Minute, Second);
        //    }
        //}
        public DateTime DateTime
        {
            get
            {
                int year = DateTime.Now.Year;
                if (Month > (byte)DateTime.Now.Month)
                    year -= 1;  // if the panel reports a month that is greater than the current month, assume it was last year 
                try
                {
                    return new DateTime(year, Month, Day, Hour, Minute, Second);
                }
                catch (Exception e)
                {
                    Trace.WriteLine($"Structures6xx.DateTime exception:{e}");
                    return DateTime.MinValue;
                    //                    throw;
                }
            }
        }

    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ExtendedCardDataActivityLogMessageFromCpu
    {
        public Byte Code;           // 0x60
        public UInt16 BufferIndex;
        public Byte LogType;
        public Byte[] Data;
        public Byte[] BlankBytes;

        public ExtendedCardDataActivityLogMessageFromCpu(int x = 0)
        {
            Code = 0;
            BufferIndex = 0;
            LogType = 0;
            Data = new Byte[ActivityLogCardMessageConstants.ExtendedCardCodeMessageSize];
            BlankBytes = new Byte[2];
        }
        public ExtendedCardDataActivityLogMessageFromCpu(Byte[] data)
        {
            Code = 0;
            BufferIndex = 0;
            LogType = 0;
            Data = new Byte[ActivityLogCardMessageConstants.ExtendedCardCodeMessageSize];
            BlankBytes = new Byte[2];
            int x = 0;
            Code = data[x++];
            BufferIndex = BitConverter.ToUInt16(data, x);
            x += sizeof(UInt16);
            LogType = data[x++];
            Array.Copy(data, x, Data, 0, Data.Length);
            x += Data.Length;
            Array.Copy(data, x, BlankBytes, 0, BlankBytes.Length);
            x += BlankBytes.Length;
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FifteenMinuteScheduleMonthHolidayTypes
    {
        public const UInt16 NumberOfDays = 32;

        public Byte Cmd;                // 0x19
        public Byte MonthNumber;        // 0 - 11
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfDays)]
        public Byte[] DayTypes;

        public FifteenMinuteScheduleMonthHolidayTypes(byte monthNumber)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoad15MinuteScheduleHolidayTable;
            MonthNumber = monthNumber;
            DayTypes = new byte[NumberOfDays];  // 1 byte per day of the month, [0] = 1st, [30] = 31st
                                                // 0 - 9 0 = not a holiday, 1 - 9 = holiday type code
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MonthOfDayTypesArray
    {
        public const UInt16 NumberOfDays = 32;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfDays)]
        public Byte[] DayTypes;

        public static implicit operator MonthOfDayTypesArray(byte nothing)
        {
            return new MonthOfDayTypesArray { DayTypes = new byte[NumberOfDays] };
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MinuteScheduleDayTypes
    {
        public const UInt16 NumberOfMonths = 12;
        public const UInt16 NumberOfDays = 32;
        public Byte Cmd;                // 0xb1
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfMonths * NumberOfDays)]
        public byte[,] DayTypes;

        public MinuteScheduleDayTypes(byte nothing)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadMinuteScheduleDayTypes;
            DayTypes = new byte[NumberOfMonths, NumberOfDays];
            for (int m = 0; m < NumberOfMonths; m++)
            {
                for (int d = 0; d < NumberOfDays; d++)
                    DayTypes[m, d] = Byte.MaxValue;
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FifteenMinuteScheduleData
    {
        [Flags]
        public enum FlagBits : byte
        {
            None = 0,
            UsesHolidays = 1
        }
        public const UInt16 DailyScheduleLength = 16;

        public Byte Cmd;                // 0x0e
        public Byte ScheduleNumber;        // 0 - 255
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] Sunday;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] Monday;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] Tuesday;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] Wednesday;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] Thursday;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] Friday;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] Saturday;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        public Byte[] HolidayType1;

        public FlagBits Flags;

        public FifteenMinuteScheduleData(byte scheduleNumber)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadTimeSchedule15MinuteFormat;
            ScheduleNumber = scheduleNumber;
            Sunday = new byte[DailyScheduleLength];
            Monday = new byte[DailyScheduleLength];
            Tuesday = new byte[DailyScheduleLength];
            Wednesday = new byte[DailyScheduleLength];
            Thursday = new byte[DailyScheduleLength];
            Friday = new byte[DailyScheduleLength];
            Saturday = new byte[DailyScheduleLength];
            HolidayType1 = new byte[DailyScheduleLength];
            Flags = FlagBits.None;
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FifteenMinuteScheduleHolidayData
    {
        public const UInt16 DailyScheduleLength = 16;

        public Byte Cmd;                // 0x8e
        public Byte ScheduleNumber;        // 0 - 255
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] HolidayType2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] HolidayType3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] HolidayType4;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] HolidayType5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] HolidayType6;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] HolidayType7;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] HolidayType8;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DailyScheduleLength)]
        public Byte[] HolidayType9;


        public FifteenMinuteScheduleHolidayData(byte scheduleNumber)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoad15MinuteScheduleHolidays;
            ScheduleNumber = scheduleNumber;
            HolidayType2 = new byte[DailyScheduleLength];
            HolidayType3 = new byte[DailyScheduleLength];
            HolidayType4 = new byte[DailyScheduleLength];
            HolidayType5 = new byte[DailyScheduleLength];
            HolidayType6 = new byte[DailyScheduleLength];
            HolidayType7 = new byte[DailyScheduleLength];
            HolidayType8 = new byte[DailyScheduleLength];
            HolidayType9 = new byte[DailyScheduleLength];
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MinuteScheduleDayTypeData
    {
        public const UInt16 NumberOfDayTypes = 100;

        public Byte Cmd;                // 0xB3
        public Byte ScheduleNumber;        // 0 - 255
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfDayTypes)]
        public Byte[] DayTypeTimePeriods;

        public MinuteScheduleDayTypeData(byte scheduleNumber)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadMinuteScheduleTimePeriodsForDayType;
            ScheduleNumber = scheduleNumber;
            DayTypeTimePeriods = new byte[NumberOfDayTypes];
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MinuteScheduleTimePeriodData
    {
        public const UInt16 NumberOfMinuteBytes = 180;

        public Byte Cmd;                // 0xB2
        public Byte TimePeriodNumber;        // 0 - 255
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfMinuteBytes)]
        public Byte[] MinuteBits;


        public MinuteScheduleTimePeriodData(byte timePeriodNumber)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadMinuteScheduleTimePeriod;
            TimePeriodNumber = timePeriodNumber;
            MinuteBits = new byte[NumberOfMinuteBytes];
        }
    }



    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CredentialAccessGroups600
    {
        public CredentialAccessGroups600(byte group1, byte group2, ushort group3, ushort group4)
        {
            Groups = new byte[2];
            ExtendedGroups = new UInt16[2];
            Groups[0] = group1;
            Groups[1] = group2;
            ExtendedGroups[0] = group3;
            ExtendedGroups[1] = group4;
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public Byte[] Groups;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public UInt16[] ExtendedGroups;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CredentialInputOutputGroups600
    {
        public CredentialInputOutputGroups600(byte group1, byte group2, ushort group3, ushort group4)
        {
            Groups = new byte[2];
            ExtendedGroups = new UInt16[2];
            Groups[0] = group1;
            Groups[1] = group2;
            ExtendedGroups[0] = group3;
            ExtendedGroups[1] = group4;
        }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public Byte[] Groups;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public UInt16[] ExtendedGroups;
    }

    [Flags]
    public enum AccessCredentialFlags1 : byte
    {
        None = 0,
        AccessType = 0x80,
        CredentialDataReversed = 0x40,
        CardIsEnabled = 0x20,
        // Bits 0x1F are 5 bits that specify # days until the credential becomes active (0-31)
        DaysTillActivex10 = 0x10,
        DaysTillActivex08 = 0x8,
        DaysTillActivex04 = 0x4,
        DaysTillActivex02 = 0x2,
        DaysTillActivex01 = 0x1,
    }

    [Flags]
    public enum AccessCredentialFlags2 : byte
    {
        None = 0,
        PassbackExempt = 0x80,
        DuressEnabled = 0x40,
        ExpireByDays = 0x20,
        PinRequiredExempt = 0x10,
        Unused1 = 0x8,
        // Bits 0x7 (lowest 3 bits represent the forgive passback code  
        //			0 = never
        //			1 = 1/day  00:00
        //			2 = 2/day  00:00 12:00
        //			3 = 4/day  00:00 06:00 12:00 18:00
        //			4 = 12/day every 2 hours
        //			5 = 24/day every hour
        //			6 = 48/day every 30 minutes     
    }

    [Flags]
    public enum AccessCredentialFlags3 : byte
    {
        None = 0,
        CanDoublePresent = 0x80,
        OtisSplitGroupOperation = 0x10,
        OtisElevatorHasVertigo = 0x8,
        OtisElevatorVeryImportantPerson = 0x4,
        OtisElevatorHasPhysicalDisability = 0x2,
    }

    public enum CredentialForgivePassbackIntervals : byte
    {
        Never = 0,
        Midnight = 1,
        Every12Hours = 2,   // Midnight and Noon (2 times/day)
        Every6Hours = 3,    // Midnight, 6 am, Noon, 6 pm (4 times/day)
        Every2Hours = 4,    // 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22 hours (12 times/day)
        EveryHour = 5,      // 24 times/day
        Every30Minutes = 6  // 48 times/day
    }

    [Flags]
    public enum ServerOverrideBehaviorFlags : byte
    {
        None = 0,
        DeferToServerIfAccessGranted = 0x80,
        DeferToServerIfAccessDenied = 0x40,
        DeferAlways = DeferToServerIfAccessGranted | DeferToServerIfAccessDenied,
        DenyAccessIfServerFailsToRespond = 0x8,
        GrantAccessIfServerFailsToRespond = 0x4
    }

    [Flags]
    public enum AlarmCredentialFlags1 : byte
    {
        None = 0,
        CredentialDataReversed = 0x40,
        CardIsEnabled = 0x20,
        // Bits 0x1F are 5 bits that specify # days until the credential becomes active (0-31)
        DaysTillActivex10 = 0x10,
        DaysTillActivex08 = 0x8,
        DaysTillActivex04 = 0x6,
        DaysTillActivex02 = 0x2,
        DaysTillActivex01 = 0x1,
    }

    [Flags]
    public enum AlarmCredentialFlags2 : byte
    {
        None = 0,
        PinRequired = 0x80,
        ExpireByDays = 0x20,
        // Bits 0x1F are 5 bits that specify # days until the credential becomes active (0-31)
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AccessControlCredentialData48Bit : IAccessControlCredentialData
    {
        //        public const UInt16 SpareBytesCount = 4;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CredentialDataByteArrayLength.Standard48Bit)]
        public Byte[] CredentialBits;
        public UInt16 PIN { get; set; }
        //        public CredentialAccessGroups600 AccessGroups;
        public byte AccessGroup1 { get; set; }
        public byte AccessGroup2 { get; set; }
        public UInt16 AccessGroup3 { get; set; }
        public UInt16 AccessGroup4 { get; set; }
        public AccessCredentialFlags1 Flags1 { get; set; }
        //public byte Flags1 { get; set; }
        public AccessCredentialFlags2 Flags2 { get; set; }  // Flags2Flags and ForgivePassbackIntervals
        //public byte Flags2 { get; set; }
        public Byte ExpireCount { get; set; }    // Contains the # of days or swipes till the credential expires, based on the Flag2 ExpireByUsageCount flag
        public Byte CurrentArea { get; set; }
        public ServerOverrideBehaviorFlags ServerOverrideBehavior { get; set; }
        //public byte ServerOverrideBehavior { get; set; }
        public AccessCredentialFlags3 Flags3 { get; set; }
        //public byte Flags3 { get; set; }
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = SpareBytesCount)]
        //public Byte[] SpareBytes;
        public byte Spare1 { get; set; }
        public byte Spare2 { get; set; }
        public byte Spare3 { get; set; }
        public byte Spare4 { get; set; }
        public AccessControlCredentialData48Bit(byte[] credentialBits)
        {
            if (credentialBits != null)
            {
                if (credentialBits.Length < CredentialDataByteArrayLength.Standard48Bit)
                    credentialBits = GCS.Core.Common.Utils.HexEncoding.PadByteArray(credentialBits, CredentialDataByteArrayLength.Standard48Bit, false);
                else if (credentialBits.Length > CredentialDataByteArrayLength.Standard48Bit)
                    credentialBits = GCS.Core.Common.Utils.HexEncoding.Right(credentialBits, CredentialDataByteArrayLength.Standard48Bit);
            }
            CredentialBits = new byte[CredentialDataByteArrayLength.Standard48Bit];
            if (credentialBits != null)
                CredentialBits = credentialBits;
            PIN = 0;
            //AccessGroups = new CredentialAccessGroups600(0, 0, 0, 0);
            AccessGroup1 = 0;
            AccessGroup2 = 0;
            AccessGroup3 = 0;
            AccessGroup4 = 0;

            Flags1 = AccessCredentialFlags1.AccessType;
            Flags2 = AccessCredentialFlags2.None;
            ExpireCount = 0;
            CurrentArea = 0;
            ServerOverrideBehavior = ServerOverrideBehaviorFlags.None;
            Flags3 = AccessCredentialFlags3.None;
            //SpareBytes = null;//new byte[SpareBytesCount];  // if these bytes are newed up, the FillData method fails when Marshal.StructureToPtr(o, ptr, true) is called. 
            //// "Type could not be marshaled because the length of an embedded array instance does not match the declared length in the layout"
            Spare1 = 0;
            Spare2 = 0;
            Spare3 = 0;
            Spare4 = 0;
        }
        public AccessControlCredentialData48Bit(byte[] data, ref int startingOffset)
        {
            CredentialBits = new byte[CredentialDataByteArrayLength.Standard48Bit];
            Array.ConstrainedCopy(data, startingOffset, CredentialBits, 0, CredentialBits.Length);
            startingOffset += CredentialBits.Length;
            PIN = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            //AccessGroups = new CredentialAccessGroups600(0, 0, 0, 0);
            AccessGroup1 = data[startingOffset++];
            AccessGroup2 = data[startingOffset++];
            AccessGroup3 = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            AccessGroup4 = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;

            Flags1 = (AccessCredentialFlags1)data[startingOffset++];
            Flags2 = (AccessCredentialFlags2)data[startingOffset++];
            //Flags1 = data[startingOffset++];
            //Flags2 = data[startingOffset++];
            ExpireCount = data[startingOffset++];
            CurrentArea = data[startingOffset++];
            ServerOverrideBehavior = (ServerOverrideBehaviorFlags)data[startingOffset++];
            //ServerOverrideBehavior = data[startingOffset++];
            Flags3 = (AccessCredentialFlags3)data[startingOffset++];
            //Flags3 = data[startingOffset++];
            //SpareBytes = null;
            //startingOffset += SpareBytesCount;
            Spare1 = data[startingOffset++];
            Spare2 = data[startingOffset++];
            Spare3 = data[startingOffset++];
            Spare4 = data[startingOffset++];
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AccessControlCredentialData256Bit : IAccessControlCredentialData
    {
        //        public const UInt16 SpareBytesCount = 2;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CredentialDataByteArrayLength.Extended256Bits)]
        public Byte[] CredentialBits;
        public UInt16 PIN { get; set; }
        //public CredentialAccessGroups600 AccessGroups;
        public byte AccessGroup1 { get; set; }
        public byte AccessGroup2 { get; set; }
        public UInt16 AccessGroup3 { get; set; }
        public UInt16 AccessGroup4 { get; set; }
        public AccessCredentialFlags1 Flags1 { get; set; }
        public AccessCredentialFlags2 Flags2 { get; set; }  // Flags2Flags and ForgivePassbackIntervals
        //public byte Flags1 { get; set; }
        //public byte Flags2 { get; set; }  // Flags2Flags and ForgivePassbackIntervals
        public Byte ExpireCount { get; set; }    // Contains the # of days or swipes till the credential expires, based on the Flag2 ExpireByUsageCount flag
        public Byte CurrentArea { get; set; }
        public ServerOverrideBehaviorFlags ServerOverrideBehavior { get; set; }
        //public byte ServerOverrideBehavior { get; set; }
        public AccessCredentialFlags3 Flags3 { get; set; }
        //public byte Flags3 { get; set; }
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = SpareBytesCount)]
        //public Byte[] SpareBytes;
        public byte Spare1 { get; set; }
        public byte Spare2 { get; set; }
        public AccessControlCredentialData256Bit(byte[] credentialBits)
        {
            if (credentialBits != null)
            {
                if (credentialBits.Length < CredentialDataByteArrayLength.Extended256Bits)
                    credentialBits = GCS.Core.Common.Utils.HexEncoding.PadByteArray(credentialBits, CredentialDataByteArrayLength.Extended256Bits, false);
                else if (credentialBits.Length > CredentialDataByteArrayLength.Extended256Bits)
                    credentialBits = GCS.Core.Common.Utils.HexEncoding.Right(credentialBits, CredentialDataByteArrayLength.Extended256Bits);
            }

            CredentialBits = new byte[CredentialDataByteArrayLength.Extended256Bits];
            if (credentialBits != null)
                CredentialBits = credentialBits;
            PIN = 0;
            //AccessGroups = new CredentialAccessGroups600(0, 0, 0, 0);
            AccessGroup1 = 0;
            AccessGroup2 = 0;
            AccessGroup3 = 0;
            AccessGroup4 = 0;

            Flags1 = AccessCredentialFlags1.AccessType;//| AccessCredentialFlags1.CardIsEnabled;
            Flags2 = AccessCredentialFlags2.None;
            ExpireCount = 0;
            CurrentArea = 0;
            ServerOverrideBehavior = ServerOverrideBehaviorFlags.None;
            //            Flags3 = AccessCredentialFlags3.None;
            Flags3 = AccessCredentialFlags3.None;
            //SpareBytes = null;//new byte[SpareBytesCount];  // if these bytes are newed up, the FillData method fails when Marshal.StructureToPtr(o, ptr, true) is called. 
            Spare1 = 0;
            Spare2 = 0;
        }

        public AccessControlCredentialData256Bit(byte[] data, ref int startingOffset)
        {
            CredentialBits = new byte[CredentialDataByteArrayLength.Extended256Bits];
            Array.ConstrainedCopy(data, startingOffset, CredentialBits, 0, CredentialBits.Length);
            startingOffset += CredentialBits.Length;
            PIN = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            //AccessGroups = new CredentialAccessGroups600(0, 0, 0, 0);
            AccessGroup1 = data[startingOffset++];
            AccessGroup2 = data[startingOffset++];
            AccessGroup3 = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            AccessGroup4 = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;

            Flags1 = (AccessCredentialFlags1)data[startingOffset++];
            Flags2 = (AccessCredentialFlags2)data[startingOffset++];
            //Flags1 = data[startingOffset++];
            //Flags2 = data[startingOffset++];
            ExpireCount = data[startingOffset++];
            CurrentArea = data[startingOffset++];
            ServerOverrideBehavior = (ServerOverrideBehaviorFlags)data[startingOffset++];
            //ServerOverrideBehavior = data[startingOffset++];
            Flags3 = (AccessCredentialFlags3)data[startingOffset++];
            //Flags3 = data[startingOffset++];
            //SpareBytes = null;
            //startingOffset += SpareBytesCount;
            Spare1 = data[startingOffset++];
            Spare2 = data[startingOffset++];
        }

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AlarmControlCredentialData48Bit : IAlarmControlCredentialData
    {
        //        public const UInt16 SpareBytesCount = 7;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CredentialDataByteArrayLength.Standard48Bit)]
        public Byte[] CredentialBits;
        public UInt16 PIN { get; set; }
        //public CredentialInputOutputGroups600 InputOutputGroups;
        public byte InputOutputGroup1 { get; set; }
        public byte InputOutputGroup2 { get; set; }
        public UInt16 InputOutputGroup3 { get; set; }
        public UInt16 InputOutputGroup4 { get; set; }

        public AlarmCredentialFlags1 Flags1 { get; set; }
        public AlarmCredentialFlags2 Flags2 { get; set; }
        public Byte ExpireCount { get; set; }    // Contains the # of days or swipes till the credential expires, based on the Flag2 ExpireByUsageCount flag
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = SpareBytesCount)]
        //public Byte[] SpareBytes;
        public byte Spare1 { get; set; }
        public byte Spare2 { get; set; }
        public byte Spare3 { get; set; }
        public byte Spare4 { get; set; }
        public byte Spare5 { get; set; }
        public byte Spare6 { get; set; }
        public byte Spare7 { get; set; }
        public AlarmControlCredentialData48Bit(byte[] credentialBits)
        {
            if (credentialBits != null)
            {
                if (credentialBits.Length < CredentialDataByteArrayLength.Standard48Bit)
                    credentialBits = GCS.Core.Common.Utils.HexEncoding.PadByteArray(credentialBits, CredentialDataByteArrayLength.Standard48Bit, false);
                else if (credentialBits.Length > CredentialDataByteArrayLength.Standard48Bit)
                    credentialBits = GCS.Core.Common.Utils.HexEncoding.Right(credentialBits, CredentialDataByteArrayLength.Standard48Bit);
            }
            CredentialBits = new byte[CredentialDataByteArrayLength.Standard48Bit];
            if (credentialBits != null)
                CredentialBits = credentialBits;
            PIN = 0;
            //InputOutputGroups = new CredentialInputOutputGroups600(0,0,0,0);
            InputOutputGroup1 = 0;
            InputOutputGroup2 = 0;
            InputOutputGroup3 = 0;
            InputOutputGroup4 = 0;

            Flags1 = AlarmCredentialFlags1.CardIsEnabled;
            Flags2 = AlarmCredentialFlags2.None;
            ExpireCount = 0;
            //SpareBytes = null;//new byte[SpareBytesCount];  // if these bytes are newed up, the FillData method fails when Marshal.StructureToPtr(o, ptr, true) is called. 
            //// "Type could not be marshaled because the length of an embedded array instance does not match the declared length in the layout"
            Spare1 = 0;
            Spare2 = 0;
            Spare3 = 0;
            Spare4 = 0;
            Spare5 = 0;
            Spare6 = 0;
            Spare7 = 0;

        }

        public AlarmControlCredentialData48Bit(byte[] data, ref int startingOffset)
        {
            CredentialBits = new byte[CredentialDataByteArrayLength.Standard48Bit];
            Array.ConstrainedCopy(data, startingOffset, CredentialBits, 0, CredentialBits.Length);
            startingOffset += CredentialBits.Length;
            PIN = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            //InputOutputGroups = new CredentialInputOutputGroups600(0,0,0,0);
            InputOutputGroup1 = data[startingOffset++];
            InputOutputGroup2 = data[startingOffset++];
            InputOutputGroup3 = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            InputOutputGroup4 = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            Flags1 = (AlarmCredentialFlags1)data[startingOffset++];
            Flags2 = (AlarmCredentialFlags2)data[startingOffset++];
            ExpireCount = data[startingOffset++];
            //SpareBytes = null;
            //startingOffset += SpareBytesCount;
            Spare1 = data[startingOffset++];
            Spare2 = data[startingOffset++];
            Spare3 = data[startingOffset++];
            Spare4 = data[startingOffset++];
            Spare5 = data[startingOffset++];
            Spare6 = data[startingOffset++];
            Spare7 = data[startingOffset++];
            //SpareBytes = new byte[SpareBytesCount];
            //Array.ConstrainedCopy(data, startingOffset, SpareBytes, 0, SpareBytes.Length);
            //startingOffset += SpareBytes.Length;
        }

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AlarmControlCredentialData256Bit : IAlarmControlCredentialData
    {
        //public const UInt16 SpareBytesCount = 5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CredentialDataByteArrayLength.Extended256Bits)]
        public Byte[] CredentialBits;
        public UInt16 PIN { get; set; }
        //public CredentialInputOutputGroups600 InputOutputGroups;
        public byte InputOutputGroup1 { get; set; }
        public byte InputOutputGroup2 { get; set; }
        public UInt16 InputOutputGroup3 { get; set; }
        public UInt16 InputOutputGroup4 { get; set; }
        public AlarmCredentialFlags1 Flags1 { get; set; }
        public AlarmCredentialFlags2 Flags2 { get; set; }  // Flags2Flags and ForgivePassbackIntervals
        public Byte ExpireCount { get; set; }    // Contains the # of days or swipes till the credential expires, based on the Flag2 ExpireByUsageCount flag
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = SpareBytesCount)]
        //public Byte[] SpareBytes;
        public byte Spare1 { get; set; }
        public byte Spare2 { get; set; }
        public byte Spare3 { get; set; }
        public byte Spare4 { get; set; }
        public byte Spare5 { get; set; }
        public AlarmControlCredentialData256Bit(byte[] credentialBits)
        {
            if (credentialBits != null)
            {
                if (credentialBits.Length < CredentialDataByteArrayLength.Extended256Bits)
                    credentialBits = GCS.Core.Common.Utils.HexEncoding.PadByteArray(credentialBits, CredentialDataByteArrayLength.Extended256Bits, false);
                else if (credentialBits.Length > CredentialDataByteArrayLength.Extended256Bits)
                    credentialBits = GCS.Core.Common.Utils.HexEncoding.Right(credentialBits, CredentialDataByteArrayLength.Extended256Bits);
            }
            CredentialBits = new byte[CredentialDataByteArrayLength.Standard48Bit];
            if (credentialBits != null)
                CredentialBits = credentialBits;
            PIN = 0;
            //InputOutputGroups = new CredentialInputOutputGroups600(0,0,0,0);
            InputOutputGroup1 = 0;
            InputOutputGroup2 = 0;
            InputOutputGroup3 = 0;
            InputOutputGroup4 = 0;
            Flags1 = AlarmCredentialFlags1.CardIsEnabled;
            Flags2 = AlarmCredentialFlags2.None;
            ExpireCount = 0;
            //SpareBytes = null;//new byte[SpareBytesCount];  // if these bytes are newed up, the FillData method fails when Marshal.StructureToPtr(o, ptr, true) is called. 
            //// "Type could not be marshaled because the length of an embedded array instance does not match the declared length in the layout"
            Spare1 = 0;
            Spare2 = 0;
            Spare3 = 0;
            Spare4 = 0;
            Spare5 = 0;
        }

        public AlarmControlCredentialData256Bit(byte[] data, ref int startingOffset)
        {
            CredentialBits = new byte[CredentialDataByteArrayLength.Extended256Bits];
            Array.ConstrainedCopy(data, startingOffset, CredentialBits, 0, CredentialBits.Length);
            startingOffset += CredentialBits.Length;
            PIN = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            //InputOutputGroups = new CredentialInputOutputGroups600(0,0,0,0);
            InputOutputGroup1 = data[startingOffset++];
            InputOutputGroup2 = data[startingOffset++];
            InputOutputGroup3 = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            InputOutputGroup4 = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            Flags1 = (AlarmCredentialFlags1)data[startingOffset++];
            Flags2 = (AlarmCredentialFlags2)data[startingOffset++];
            ExpireCount = data[startingOffset++];
            //SpareBytes = null;
            //startingOffset += SpareBytesCount;
            Spare1 = data[startingOffset++];
            Spare2 = data[startingOffset++];
            Spare3 = data[startingOffset++];
            Spare4 = data[startingOffset++];
            Spare5 = data[startingOffset++];
        }

    }

    [StructLayout(LayoutKind.Explicit)]
    public struct CredentialData48BitUnion
    {
        //public CredentialData48BitUnion(GalaxySMS.Common.Enums.PersonCredentialRoles role)
        //{
        //    AccessControlCredential = new AccessControlCredentialData48Bit(null);
        //    AlarmControlCredential = new AlarmControlCredentialData48Bit(null);
        //}

        public void SetData(byte[] data, ref int startingOffset)
        {
            var flags1 = (AccessCredentialFlags1)data[startingOffset + 14];
            if ((flags1 & AccessCredentialFlags1.AccessType) != 0)
                AccessControlCredential = new AccessControlCredentialData48Bit(data, ref startingOffset);
            else
                AlarmControlCredential = new AlarmControlCredentialData48Bit(data, ref startingOffset);
        }

        [FieldOffset(0)] public AccessControlCredentialData48Bit AccessControlCredential;
        [FieldOffset(0)] public AlarmControlCredentialData48Bit AlarmControlCredential;

        public bool HasCredentialBits
        {
            get
            {
                foreach (var b in AccessControlCredential.CredentialBits)
                {
                    if (b != 0)
                        return true;
                }
                return false;
            }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct CredentialData256BitUnion
    {
        //public CredentialData256BitUnion(object o)
        //{
        //    AccessControlCredential = new AccessControlCredentialData256Bit(null);
        //    AlarmControlCredential = new AlarmControlCredentialData256Bit(null);
        //}

        public void SetData(byte[] data, ref int startingOffset)
        {
            var flags1 = (AccessCredentialFlags1)data[startingOffset + 14];
            if ((flags1 & AccessCredentialFlags1.AccessType) != 0)
                AccessControlCredential = new AccessControlCredentialData256Bit(data, ref startingOffset);
            else
                AlarmControlCredential = new AlarmControlCredentialData256Bit(data, ref startingOffset);
        }
        [FieldOffset(0)] public AccessControlCredentialData256Bit AccessControlCredential;
        [FieldOffset(0)] public AlarmControlCredentialData256Bit AlarmControlCredential;

        public bool HasCredentialBits
        {
            get
            {
                foreach (var b in AccessControlCredential.CredentialBits)
                {
                    if (b != 0)
                        return true;
                }
                return false;
            }
        }

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CredentialData48Bit
    {
        public const UInt16 NumberOfCredentials = 32;

        public Byte Cmd { get; set; }                // 0x10
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfCredentials)]
        public CredentialData48BitUnion[] CredentialData;


        public CredentialData48Bit(byte data)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadStandardCards;
            CredentialData = new CredentialData48BitUnion[NumberOfCredentials];
            //for (int x = 0; x < NumberOfCredentials; x++)
            //{
            //    CredentialData[x] = new CredentialData48BitUnion(PersonCredentialRoles.AccessControl);
            //}
        }
        public CredentialData48Bit(byte[] data, int startingOffset)
        {
            Cmd = data[startingOffset++];
            CredentialData = new CredentialData48BitUnion[NumberOfCredentials];

            for (int x = 0; x < NumberOfCredentials; x++)
            {
                CredentialData[x].SetData(data, ref startingOffset);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CredentialData256Bit
    {
        public const UInt16 NumberOfCredentials = 16;

        public Byte Cmd;                // 0x10
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfCredentials)]
        public CredentialData256BitUnion[] CredentialData;


        public CredentialData256Bit(byte data)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadExtendedCards;
            CredentialData = new CredentialData256BitUnion[NumberOfCredentials];
            //for (int x = 0; x < NumberOfCredentials; x++)
            //{
            //    CredentialData[x] = new CredentialData256BitUnion(0);
            //}
        }

        public CredentialData256Bit(byte[] data, int startingOffset)
        {
            Cmd = data[startingOffset++];
            CredentialData = new CredentialData256BitUnion[NumberOfCredentials];

            for (int x = 0; x < NumberOfCredentials; x++)
            {
                CredentialData[x].SetData(data, ref startingOffset);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PanelAndDoorNumber
    {
        public PanelAndDoorNumber(UInt16 panelNumber, byte doorNumber)
        {
            PanelNumber = panelNumber;
            DoorNumber = doorNumber;
        }
        public UInt16 PanelNumber;      // 1 - 65535
        public Byte DoorNumber;         // 1 - 64
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PanelAndDoorNumber_PreV11
    {
        public PanelAndDoorNumber_PreV11(byte panelNumber, byte doorNumber)
        {
            PanelNumber = panelNumber;
            DoorNumber = doorNumber;
        }
        public Byte PanelNumber;      // 1 - 255
        public Byte DoorNumber;         // 1 - 64
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PersonalAccessGroupData
    {
        public const UInt16 NumberOfDoors = 100;

        public PersonalAccessGroupData(UInt16 personalAccessGroupNumber, bool bClearFlag, Byte scheduleNumber)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadPersonalDoors;
            if (bClearFlag == false)
                ClearFlag = 0;
            else
                ClearFlag = 1;
            ScheduleNumber = scheduleNumber;
            PersonalAccessGroupNumber = personalAccessGroupNumber;
            PanelDoorData = new PanelAndDoorNumber[NumberOfDoors];
        }

        public PersonalAccessGroupData(byte[] data, int startingOffset)
        {
            Cmd = data[startingOffset++];
            PersonalAccessGroupNumber = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            ClearFlag = data[startingOffset++];
            ScheduleNumber = data[startingOffset++];
            PanelDoorData = new PanelAndDoorNumber[NumberOfDoors];
            for (int x = 0; x < NumberOfDoors; x++)
            {
                if ((startingOffset + sizeof(UInt16) + sizeof(byte)) <= data.Length)
                {
                    PanelDoorData[x].PanelNumber = BitConverter.ToUInt16(data, startingOffset);
                    startingOffset += 2;
                    PanelDoorData[x].DoorNumber = data[startingOffset++];
                }
            }

        }
        public Byte Cmd;                // 0x57
        public UInt16 PersonalAccessGroupNumber;        // 2001 - 52000
        public Byte ClearFlag;          // 0: don't clear, 1:clear this number from the table
        public Byte ScheduleNumber;     // specifies the schedule number when this group is active
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfDoors)]
        public PanelAndDoorNumber[] PanelDoorData;

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PersonalAccessGroupData_PreV11
    {
        public const UInt16 NumberOfDoors = 100;

        public PersonalAccessGroupData_PreV11(UInt16 personalAccessGroupNumber, bool bClearFlag, Byte scheduleNumber)
        {
            Cmd = (byte)PacketDataCodeTo6xx.CommandLoadPersonalDoors;
            if (bClearFlag == false)
                ClearFlag = 0;
            else
                ClearFlag = 1;
            ScheduleNumber = scheduleNumber;
            PersonalAccessGroupNumber = personalAccessGroupNumber;
            PanelDoorData = new PanelAndDoorNumber_PreV11[NumberOfDoors];
        }

        public PersonalAccessGroupData_PreV11(byte[] data, int startingOffset)
        {
            Cmd = data[startingOffset++];
            PersonalAccessGroupNumber = BitConverter.ToUInt16(data, startingOffset);
            startingOffset += 2;
            ClearFlag = data[startingOffset++];
            ScheduleNumber = data[startingOffset++];
            PanelDoorData = new PanelAndDoorNumber_PreV11[NumberOfDoors];
            for (int x = 0; x < NumberOfDoors; x++)
            {
                if ((startingOffset + sizeof(byte) + sizeof(byte)) <= data.Length)
                {
                    PanelDoorData[x].PanelNumber = data[startingOffset++];
                    PanelDoorData[x].DoorNumber = data[startingOffset++];
                }
            }

        }
        public Byte Cmd;                // 0x57
        public UInt16 PersonalAccessGroupNumber;        // 2001 - 52000
        public Byte ClearFlag;          // 0: don't clear, 1:clear this number from the table
        public Byte ScheduleNumber;     // specifies the schedule number when this group is active
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfDoors)]
        public PanelAndDoorNumber_PreV11[] PanelDoorData;

    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ReaderPortStatusResponse
    {
        public enum StatusCode : byte
        {
            Unknown = 0x00,
            Idle = 0x01,
            Open = 0x02,
            OpenTooLong = 0x03,
            ReadingCardForward = 0x04,
            ReadingCardReverse = 0x05,
            RedStep = 0x06,
            Unlock = 0x07,
            Shunted = 0x08,
            Scheduled = 0x09,
            PinBlink = 0x0A,
            Pin = 0x0B,
            PrivacyMode = 0x0F,
            OfficeMode = 0x10,
            Dead = 0x20,
            Interlocked = 0x21,
            AlarmDisarmed = 0x23,
            AlarmArmed = 0x24,
            DelayedUnlock = 0x25
        }

        public enum DoorContactStateCode : byte
        {
            TroubleShort = 0,
            Closed = 64,
            TroubleOpen = 128,
            Open = 192,
            Unknown = 255
        }

        public const UInt16 NumberOfUnusedBytes = 9;
        public Byte Cmd;        // = 0x0A
        public Byte PortType;
        public Byte ReaderState;
        public Byte Leds;
        public Byte Relays;
        public Byte Flags;  // 1 = Board Missing, 0 = board present
        public Byte DoorContactState;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfUnusedBytes)]
        public Byte[] Unused;

        public ReaderPortStatusResponse(Byte[] data)
        {
            Cmd = 0;
            PortType = 0;
            ReaderState = 0;
            Leds = 0;
            Relays = 0;
            Flags = 0;
            DoorContactState = 0;
            Unused = new Byte[NumberOfUnusedBytes];

            if (data != null)
            {
                int x = 0;
                Cmd = data[x++];
                PortType = data[x++];
                ReaderState = data[x++];
                Leds = data[x++];
                Relays = data[x++];
                Flags = data[x++];
                DoorContactState = data[x++];
                Unused = GCS.Core.Common.Utils.ByteArrayUtilities.GetBytesFromArray(data, NumberOfUnusedBytes, x);
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InputDeviceStatusResponse
    {
        public const UInt16 NumberOfUnusedBytes = 9;

        public enum InputStates : byte
        {
            Unknown = 0x00,
            TroubleOpen = 0x0A,
            TroubleShort = 0x0B,
            DisarmedOff = 0x0C,
            DisarmedOn = 0x0D,
            ArmedSecure = 0x0E,
            ArmedAlarm = 0x0F
        }

        public enum MonitoringState : byte
        {
            Isolated = 0x00,
            Shunted = 0x10,
            Normal = 0x20,
            EntryDelay = 0x40,
            DwellDelay = 0x50,
            ArmingInputIdle = 0x80,
            ArmingInputTiming = 0xC0
        }

        [Flags]
        public enum InputOutputGroupState : byte
        {
            Armed = 1,
            ManuallyArmed = 4,
            ManuallyDisarmed = 8,
            LocalIoGroup = 0x80,
        }

        [Flags]
        public enum InputFlags : byte
        {
            BoardPresent = 0,
            BoardNotPresent = 1
        }


        public Byte Cmd;        // 0x0B
        public Byte InputNumber;
        public Byte CurrentMonitoringState;   // Upper nibble = InputStatusMode
        public Byte CurrentContactState;
        public Byte IOGroupState;
        public Byte Flags;  // 1 = Board Missing, 0 = board present

        public InputDeviceStatusResponse(Byte[] data)
        {
            Cmd = 0;
            InputNumber = 0;
            CurrentMonitoringState = 0;
            CurrentContactState = 0;
            IOGroupState = 0;
            Flags = 0;

            if (data != null)
            {
                var x = 0;
                Cmd = data[x++];
                InputNumber = data[x++];
                CurrentMonitoringState = data[x++];
                CurrentContactState = data[x++];
                IOGroupState = data[x++];
                Flags = data[x++];
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CardCommand48Bit
    {
        public Byte Cmd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CredentialDataByteArrayLength.Standard48Bit)]
        public Byte[] CredentialBits;

        public CardCommand48Bit(byte[] data, int startingOffset)
        {
            Cmd = data[startingOffset++];
            CredentialBits = new byte[CredentialDataByteArrayLength.Standard48Bit];
            Array.ConstrainedCopy(data, startingOffset, CredentialBits, 0, CredentialBits.Length);
        }
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CardCommand256Bit
    {
        public Byte Cmd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CredentialDataByteArrayLength.Extended256Bits)]
        public Byte[] CredentialBits;

        public CardCommand256Bit(byte[] data, int startingOffset)
        {
            Cmd = data[startingOffset++];
            CredentialBits = new byte[CredentialDataByteArrayLength.Extended256Bits];
            Array.ConstrainedCopy(data, startingOffset, CredentialBits, 0, CredentialBits.Length);
        }
    };


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InputOutputGroupCommand
    {
        public Byte Cmd;
        public Byte GroupNumber;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AccessPortalGroupCommand
    {
        public Byte Cmd;
        public Byte GroupNumber;
    };

    //    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    //    public struct VariableLengthFlashData
    //    {
    //        public const UInt16 NumberOfAddressBytes = 3;
    //        public const UInt16 NumberOfDataBytes = 1024;


    //        public Byte Cmd;    // 0xA7 for 600, 0xB7 for 635
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfAddressBytes)]
    //        public Byte[] Address;
    ////        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfDataBytes)]
    //        public Byte[] Data;

    //        public VariableLengthFlashData(Byte cmd, UInt32 address, Byte[] data)
    //        {
    //            Cmd = cmd;
    //            Address = new Byte[NumberOfAddressBytes];
    ////            Data = new Byte[NumberOfDataBytes];
    //            Data = new Byte[data.Length];
    //            var addressBytes = BitConverter.GetBytes(address);
    //            Address[0] = addressBytes[0];
    //            Address[1] = addressBytes[1];
    //            Address[2] = addressBytes[2];
    //            Array.Copy(data, Data, data.Length);
    //            //Data = data.ToArray();
    //        }

    //        public int GetSize()
    //        {
    //            return System.Runtime.InteropServices.Marshal.SizeOf(Cmd) + Address.Length + Data.Length;
    //        }
    //    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VariableLengthFlashData
    {
        public const UInt16 NumberOfAddressBytes = 3;


        public Byte Cmd;    // 0xA7 for 600, 0xB7 for 635
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfAddressBytes)]
        public Byte[] Address;

        public VariableLengthFlashData(Byte cmd, UInt32 address)
        {
            Cmd = cmd;
            Address = new Byte[NumberOfAddressBytes];
            var addressBytes = BitConverter.GetBytes(address);
            Address[0] = addressBytes[0];
            Address[1] = addressBytes[1];
            Address[2] = addressBytes[2];
        }

        public int GetSize()
        {
            return System.Runtime.InteropServices.Marshal.SizeOf(Cmd) + Address.Length;
        }
    };


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ValidateFlashBuffer
    {
        public Byte Cmd;    // 0xA8 (validate only), 0xA9 (validate and burn) for 600, 0xB8 (validate only), 0xB9 (validate and burn) for 635 
        public UInt16 PacketCount;
        public UInt32 Crc;
        public UInt32 CrcExtented;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InputDeviceDigitalIOBoard
    {
        public const UInt16 NumberOfArmingIOGroups = 4;
        public const UInt16 NumberOfVoltageThresholds = 3;
        public const UInt16 NumberOfSpareBytes = 11;

        [Flags]
        public enum Options1Flags : byte
        {
            SuppressDisarmedLogMessages = 0x1,
            DelayTypeEntry = 0x2,
            DelayTypeDwell = 0x4,
            InputModeArming = 0x8,
            NormalOpenContact = 0x40,
            IgnoreAlternatingVoltages = 0x80
        }

        public Byte Cmd;                        // 0x0C
        public Byte BoardSectionMode;                   // 0x30
        public Byte InputNumber;                // 
        public IoGroupAssignment IOGroupAssignment;
        public ushort DelaySeconds;
        public Byte Options1;    // Options1Flags
        public Byte Unused2;
        public Byte Unused3;


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfArmingIOGroups)]
        public Byte[] ArmingIoGroups;    // Will arm or disarm these io groups
        public Byte ArmingSchedule;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfVoltageThresholds)]
        public Byte[] VoltageThresholdsNormal;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfVoltageThresholds)]
        public Byte[] VoltageThresholdsAlternate;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfSpareBytes)]
        public byte[] Spares;

        public InputDeviceDigitalIOBoard(object o)
        {
            this.Cmd = (byte)PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData;
            BoardSectionMode = 0;
            InputNumber = 0;
            IOGroupAssignment = new IoGroupAssignment();
            DelaySeconds = 0;
            Options1 = 0;
            Unused2 = 0;
            Unused3 = 0;

            ArmingIoGroups = new byte[NumberOfArmingIOGroups];
            ArmingSchedule = 0;
            VoltageThresholdsNormal = new byte[NumberOfVoltageThresholds];
            VoltageThresholdsAlternate = new byte[NumberOfVoltageThresholds];
            Spares = new byte[NumberOfSpareBytes];
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InputDeviceRS485InputModule
    {
        public const UInt16 NumberOfArmingIOGroups = 4;

        [Flags]
        public enum Options1Flags : byte
        {
            SuppressDisarmedLogMessages = 0x1,
            DelayTypeEntry = 0x2,
            DelayTypeDwell = 0x4,
            InputModeArming = 0x8,
            ParallelResistor = 0x10,
            SeriesResistor = 0x20,
            NormalOpenContact = 0x40,
            InputIsActive = 0x80
        }

        public IoGroupAssignment IOGroupAssignment;
        public ushort DelaySeconds;
        public Byte Options1;    // Options1Flags


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfArmingIOGroups)]
        public Byte[] ArmingIoGroups;    // Will arm or disarm these io groups
        public Byte ArmingSchedule;

        public InputDeviceRS485InputModule(object o)
        {
            IOGroupAssignment = new IoGroupAssignment();
            DelaySeconds = 0;
            Options1 = 0;

            ArmingIoGroups = new byte[NumberOfArmingIOGroups];
            ArmingSchedule = 0;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RS485InputModule
    {
        public const UInt16 NumberOfInputs = 18;

        public Byte Cmd;    // 0x0C
        public Byte InputNumber;  	// 0 = load all 18 inputs, 1 - 18 = specific input only
        public Byte ModuleNumber;   // Board/Module # 1 - 16


        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfInputs)]
        public InputDeviceRS485InputModule[] Inputs;    // Will arm or disarm these io groups

        public RS485InputModule(byte inputNumber)
        {
            this.Cmd = (byte)PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData;
            InputNumber = inputNumber;
            ModuleNumber = 0;
            Inputs = new InputDeviceRS485InputModule[NumberOfInputs];
            for (int x = 0; x < NumberOfInputs; x++)
                Inputs[x] = new InputDeviceRS485InputModule(null);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OutputDeviceData
    {
        public const UInt16 NumberOfInputSources = 4;

        public enum TriggerCondition : byte
        {
            Nothing = 0,
            Trouble = 0x1,
            Unarmed = 0x2,
            Armed = 0x03,
            On = 0x4,
            Alarm = 0x5,
            Active = 0x6,
            TroubleOrAlarm = 0x07
        }

        public enum OutputMode : byte
        {
            Follows = 1,
            Latched = 2,
            Scheduled = 3,
            TimeoutRetriggerable = 4,
            Timeout = 5,
            Limit = 6,
            Counter = 7
        }

        [Flags]
        public enum ModeFlags : byte
        {
            InvertOutput = 0x10,
            ANDMode = 0x20,
        }

        [Flags]
        public enum TriggerFlags : byte
        {
            ANDMode = 0x10,
            IOGroupMode = 0x20,
            InvertInputs = 0x40 // NOR and NAND
        }

        public Byte Cmd;                        // 0x0C
        public Byte BoardSectionMode;           // 0x20 = DIO outputs, 0x42 = DSI relay module
        public Byte OutputNumber;               // 1-4 or 1-24
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfInputSources)]
        public Byte[] IoGroups;                 // the io group #
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfInputSources)]
        public UInt32[] Offsets;                // 32 bit masks for each source 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NumberOfInputSources)]
        public Byte[] TriggerConditions;        // the conditions that trigger the output 0 - x
                                                // 0 = nothing
                                                // 1 = trouble
                                                // 2 = unarmed
                                                // 3 = armed
                                                // 4 = on
                                                // 5 = alarm
                                                // 6 = active ( combination of on and alarm )
                                                // 7 = trouble or alarm
                                                // or in 0x10 = AND mode
                                                // or in 0x20 = group mode OUTPUT_PART_GROUP_MODE
                                                // or in 0x40 = input is inverted
        public ushort DurationLimitCount;       // duration in seconds or limit/count value
        public Byte Schedule;                   // when the output will respond to input conditions
        public Byte Mode;                       // 1 = follows    
                                                // 2 = latched    
                                                // 3 = scheduled
                                                // 4 = re-triggerable times out
                                                // 5 = non-extendable times out
                                                // 6 = limit - acts like follows
                                                // 7 = counter
                                                // xxxx.... upper 4 are options bits
                                                // xx1x.... x20 - 4 partitions are ANDED rather than ORed
                                                // xxx1.... x10 - invert the output

        public OutputDeviceData(object o)
        {
            this.Cmd = (byte)PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData;
            BoardSectionMode = 0;
            OutputNumber = 0;
            DurationLimitCount = 0;
            Schedule = 0;
            Mode = 0;

            IoGroups = new byte[NumberOfInputSources];
            Offsets = new UInt32[NumberOfInputSources];
            TriggerConditions = new byte[NumberOfInputSources];
        }
    }



}