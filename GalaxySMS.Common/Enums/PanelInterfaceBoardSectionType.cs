////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\PanelInterfaceBoardSectionType.cs
//
// summary:	Implements the panel interface board section type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent credential reader data formats. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public enum CredentialReaderDataFormat
    {
/// <summary>   . </summary>
        [EnumMember] Unknown = 0x00,
/// <summary>   . </summary>
        [EnumMember] GalaxyKeypadFormat = 0x01,
/// <summary>   The xceed identifier piv wiegand. </summary>
        [EnumMember] WiegandFormat = 0x02,
/// <summary>   The xceed identifier piv wiegand. </summary>
        [EnumMember] WiegandKey = 0x03,
/// <summary>   The xceed identifier piv wiegand. </summary>
        [EnumMember] ClockDataInverted = 0x04,
/// <summary>   The xceed identifier piv wiegand. </summary>
        [EnumMember] ClockDataStandard = 0x05,
/// <summary>   The xceed identifier piv wiegand. </summary>
        [EnumMember] Rs232G5 = 0x06,
/// <summary>   The xceed identifier piv wiegand. </summary>
        [EnumMember] ClockDataFixed8Digits = 0x07,
/// <summary>   The xceed identifier piv wiegand. </summary>
        [EnumMember] CardaxWiegand = 0x08,
/// <summary>   The xceed identifier piv wiegand. </summary>
        [EnumMember] Cardax = 0x09,
/// <summary>   The xceed identifier piv wiegand. </summary>
        [EnumMember] XceedIdPiv = 0x0A,
/// <summary>   The xceed identifier piv wiegand. </summary>
        [EnumMember] XceedIdPivWiegand = 0x0B,
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent panel interface board section types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
	public enum PanelInterfaceBoardSectionType
	{
/// <summary>   . </summary>
        [EnumMember] None,
/// <summary>   . </summary>
        [EnumMember] DrmSection = 0x10,
/// <summary>   . </summary>
        [EnumMember] Dio8X4Outputs = 0x20,
/// <summary>   . </summary>
        [EnumMember] Dio8X4Inputs = 0x30,

/// <summary>   . </summary>
        [EnumMember] DsiElevatorControlRelays = 0x40,
/// <summary>   . </summary>
        [EnumMember] DsiCypressClockDisplay = 0x41,
/// <summary>   . </summary>
        [EnumMember] DsiOutputControlRelays = 0x42,
/// <summary>   The kone elevator interface CPU. </summary>
        [EnumMember] DsiIngersolRandPimWiegand = 0x43,
/// <summary>   The kone elevator interface CPU. </summary>
        [EnumMember] DsiIngersolRandPimClockData = 0x44,
/// <summary>   The kone elevator interface CPU. </summary>
        [EnumMember] DsiLcd4x20Display = 0x45,
/// <summary>   The kone elevator interface CPU. </summary>
        [EnumMember] DsiRs485DoorModule = 0x46,
/// <summary>   The kone elevator interface CPU. </summary>
        [EnumMember] DsiAssaAbloyAperio = 0x47,
/// <summary>   The kone elevator interface CPU. </summary>
        [EnumMember] DsiSalto = 0x48,
/// <summary>   The kone elevator interface CPU. </summary>
        [EnumMember] DsiRs485InputModule = 0x49,
/// <summary>   The kone elevator interface CPU. </summary>
        [EnumMember] OtisElevatorInterfaceCpu = 0x60,
/// <summary>   The kone elevator interface CPU. </summary>
        [EnumMember] CardTourManagerCpu = 0x61,
/// <summary>   The kone elevator interface CPU. </summary>
        [EnumMember] KoneElevatorInterfaceCpu = 0x62,

    }
}
