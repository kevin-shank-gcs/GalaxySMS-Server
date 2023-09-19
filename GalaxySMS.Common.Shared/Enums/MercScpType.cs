////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\GalaxyPanelModel.cs
//
// summary:	Implements the galaxy panel model class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent galaxy panel models. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    //public enum MercScpType
    //{
    //	Lp2500 = 307,    // device_id=3, device_ver = 7
    //	Lp1502 = 308,    // device_id=3, device_ver = 8
    //	Lp1501 = 309,    // device_id=3, device_ver = 9
    //	Lp4502 = 319    // device_id=3, device_ver = 19
    //}
    // From the AscendGalaxyLibrary .NET 7 project
    public enum MercuryPanelType
    {
        /// <summary>System Control Processor (legacy controller)</summary>
        SCP,
        /// <summary>System Control Processor Compact (legacy controller)</summary>
        SCPC,
        /// <summary>System Control Processor Extended(legacy controller)</summary>
        SCPE,
        /// <summary>Honeywell Pro-Watch 5000</summary>
        PW5000,
        /// <summary>Honeywell Pro-Watch 5000 Rev A</summary>
        PW5000A,
        /// <summary>Honeywell Pro-Watch 3000</summary>
        PW3000,
        /// <summary>Event Processor 1501, single-door, PoE controller</summary>
        EP1501,
        /// <summary>Event Processor 1502, dual door controller</summary>
        EP1502,
        /// <summary>Event Processor 2500</summary>
        EP2500,
        /// <summary>Event Procssor 4502 (legacy Linux controller)</summary>
        EP4502,
        /// <summary>Honeywell Pro-Watch 6000</summary>
        PW6000,
        /// <summary>Honweywell WIN-PAK 3200</summary>
        PRO3200,
        /// <summary>Keri Systems NXT</summary>
        NXT,
        /// <summary>GE RS4 replacement controller</summary>
        MIRS4,
        /// <summary>GE XL15 replacement controller</summary>
        MIXL16,
        /// <summary>Software House iSTAR replacement controller</summary>
        MSICS,
        /// <summary>Casi-Rusco M5 replacement controller</summary>
        M5IC,
        /// <summary>Schneider Electric SSC controller</summary>
        SSC,
        /// <summary>Vanderbilt Aliro AP</summary>
        AP2,
        /// <summary>Linux Processor 1501, single-door, PoE controller</summary>
        LP1501,
        /// <summary>Linux Processor 1502, dual door controller</summary>
        LP1502,
        /// <summary>Linux Processor 2500</summary>
        LP2500,
        /// <summary>Linux Processor 4502</summary>
        LP4502,
        /// <summary>X1100 (HID Vertx replacement controller)</summary>
        X1100,
        /// <summary>Honeywell Pro-Watch 7000</summary>
        PW7000,
        /// <summary>Honeywell WIN-PAK 4200</summary>
        PRO4200
    }

}
