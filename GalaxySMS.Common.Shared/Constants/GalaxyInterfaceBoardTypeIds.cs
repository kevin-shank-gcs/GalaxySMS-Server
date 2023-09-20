////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyInterfaceBoardTypeIds.cs
//
// summary:	Implements the galaxy interface board type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy interface board type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyInterfaceBoardTypeIds
    {
        /// <summary>   The galaxy interface board type dual reader interface 600. </summary>
        public static readonly Guid GalaxyInterfaceBoardType_DualReaderInterface600 = new Guid("00000000-0000-0000-0000-000000000004");
        /// <summary>   The galaxy interface board type digital input output 600. </summary>
        public static readonly Guid GalaxyInterfaceBoardType_DigitalInputOutput600 = new Guid("00000000-0000-0000-0000-000000000005");
        ///// <summary>   The galaxy interface board type dual serial interface 600. </summary>
        //public static readonly Guid GalaxyInterfaceBoardType_DualSerialInterface600 = new Guid("00000000-0000-0000-0000-000000000007");
        /// <summary>   The fifth galaxy interface board type dual reader interface 63. </summary>
        public static readonly Guid GalaxyInterfaceBoardType_DualReaderInterface635 = new Guid("00000000-0000-0000-0000-00000000000C");
        /// <summary>   The fifth galaxy interface board type dual serial interface 63. </summary>
        public static readonly Guid GalaxyInterfaceBoardType_DualSerialInterface635 = new Guid("00000000-0000-0000-0000-000000000010");
        ///// <summary>   Manager for galaxy interface board type card tour. </summary>
        //public static readonly Guid GalaxyInterfaceBoardType_CardTourManager = new Guid("00000000-0000-0000-0000-00000000000E");
        /// <summary>   The galaxy interface board type otis elevator interface. </summary>
        public static readonly Guid GalaxyInterfaceBoardType_OtisElevatorInterface = new Guid("00000000-0000-0000-0000-00000000000D");
        /// <summary>   The galaxy interface board type kone elevator interface. </summary>
        public static readonly Guid GalaxyInterfaceBoardType_KoneElevatorInterface = new Guid("00000000-0000-0000-0000-000000000011");

        /// <summary>   The galaxy interface board type veridt reader module. </summary>
        public static readonly Guid GalaxyInterfaceBoardType_Veridt_ReaderModule = new Guid("00000000-0000-0000-0000-000000000012");

        /// <summary>   The galaxy interface board type veridt CPU. </summary>
        public static readonly Guid GalaxyInterfaceBoardType_Veridt_Cpu = new Guid("00000000-0000-0000-0000-000000000013");


    }
}
