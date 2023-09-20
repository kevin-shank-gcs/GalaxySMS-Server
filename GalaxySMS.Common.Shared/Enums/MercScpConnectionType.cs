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
    public enum MercScpConnectionType
    {   
        None,
        IPServer = 4,   // Panel is IP server, accepting connection from communication server
        IPClient = 7    // Panel is IP client, connects to communication server
    }

}
