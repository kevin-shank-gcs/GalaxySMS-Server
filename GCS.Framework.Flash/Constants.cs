using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Flash
{
    public class Constants
    {
        public const uint FIXED_MEMORY_BLOCK = 0x8000;
        public const uint EZ80_PACKAGE = 0x8004;
        public const uint EZ80_MAJOR_VERSION = 0x8005;
        public const uint EZ80_MINOR_VERSION = 0x8007;  // 2 bytes 8008
        public const uint EZ80_DESCRIPTION1 = 0x8080;   // many bytes, up to EZ80_FILE_SUMCHECK
        public const uint EZ80_DESCRIPTION2 = 0x8090;   // many bytes, up to EZ80_FILE_SUMCHECK
        public const uint EZ80_DESCRIPTION3 = 0x80A0;   // many bytes, up to EZ80_FILE_SUMCHECK
        public const uint EZ80_DESCRIPTION4 = 0x80B0;   // many bytes, up to EZ80_FILE_SUMCHECK
        public const uint EZ80_DESCRIPTION5 = 0x80C0;   // many bytes, up to EZ80_FILE_SUMCHECK
        public const uint EZ80_DESCRIPTION6 = 0x80D0;   // many bytes, up to EZ80_FILE_SUMCHECK
        public const uint EZ80_DESCRIPTION7 = 0x80E0;   // many bytes, up to EZ80_FILE_SUMCHECK
        public const uint EZ80_DESCRIPTION8 = 0x80F0;   // many bytes, up to EZ80_FILE_SUMCHECK
        public const uint EZ80_FILE_SUMCHECK = 0x80F8;  // 4 BYTE SUMCHECK ON ALL LOADABLE DATA

        public const int EZ80_FLASH_PACKET_SIZE = 128;
        public const uint EZ80_508I_CRC_BUFFER_SIZE = 307200;
        public const uint EZ80_600_BUFFER_SIZE = 0x3FFFFF;
        public const uint EZ80_600_CRC_SIZE_1_18 = 358400; // s28 version 1.19a and older uses this value for CRC calculations
        public const uint EZ80_600_CRC_SIZE_1_19 = 0x100000; //1048576// s28 version 1.19b and higher uses this value for CRC calculations
        public const uint EZ80_600_CRC_SIZE_5_01 = 0x200000; // s28 version 5.01 and higher uses this value for CRC calculations

    }

    public enum FlashPackageType : byte
    {
        Package508i = 2,
        Package600Cpu = 3,
        Package600DualReaderBoard = 4,
        Package600_8Inputs4Outputs = 5,
        Package600DualSerialInterface = 7,
        Package600CentralStationDialer = 8,
        Package635Cpu = 10,
        Package635DualReaderBoard = 12,
        PackageOtisElevatorInterface = 13,
        PackageCardTourManager = 14,
        Package635UsbEnrollmentBoard = 15,
        Package635DualSerialInterface = 16,
        PackageKoneEliElevatorInterface = 17,
        PackageVeridtReaderBoard = 18,
        PackageVeridtHarsCpu = 19,
    }
}
