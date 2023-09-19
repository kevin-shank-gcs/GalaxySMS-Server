////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\CpuModel.cs
//
// summary:	Implements the CPU model class
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent CPU models. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum CpuModel
    {
        /// <summary>   An enum constant representing the unknown option. </summary>
		Unknown = 0,
        /// <summary>   An enum constant representing the CPU 5xx option. </summary>
		Cpu5xx = 500,
        /// <summary>   An enum constant representing the CPU 600 option. </summary>
		Cpu600 = 600,
        /// <summary>   An enum constant representing the CPU 635 option. </summary>
		Cpu635 = 635,
        /// <summary>   An enum constant representing the CPU 708 option. </summary>
        Cpu708 = 708,
    }
}
