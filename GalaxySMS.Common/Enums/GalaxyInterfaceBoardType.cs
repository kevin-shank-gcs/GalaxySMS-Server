////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\GalaxyInterfaceBoardType.cs
//
// summary:	Implements the galaxy interface board type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent galaxy interface board types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum GalaxyInterfaceBoardType
	{
/// <summary>   . </summary>
		None = 0,
/// <summary>   . </summary>
		DualPortInterfaceBoard500 = 1,
/// <summary>   . </summary>
		//Cpu500i = 2,
		Cpu600 = 3,
        /// <summary>   An enum constant representing the dual reader interface board 600 option. </summary>
		DualReaderInterfaceBoard600 = 4,
        /// <summary>   An enum constant representing the digital input output board 600 option. </summary>
		DigitalInputOutputBoard600 = 5,
        /// <summary>   An enum constant representing the dual serial interface board 600 option. </summary>
		DualSerialInterfaceBoard600 = 7,
        /// <summary>   An enum constant representing the CPU 635 option. </summary>
//		CentralStationDialerBoard600 = 8,
		Cpu635 = 10,
        /// <summary>   An enum constant representing the dual reader interface board 635 option. </summary>
		DualReaderInterfaceBoard635 = 12,
        /// <summary>   An enum constant representing the otis elevator interface option. </summary>
		OtisElevatorInterface = 13,
        /// <summary>   An enum constant representing the card tour manager CPU option. </summary>
		CardTourManagerCpu = 14,
        /// <summary>   An enum constant representing the dual serial interface board 635 option. </summary>
		DualSerialInterfaceBoard635 = 16,
        /// <summary>   An enum constant representing the kone elevator interface= 17 option. </summary>
        KoneElevatorInterface=17
	}
}
