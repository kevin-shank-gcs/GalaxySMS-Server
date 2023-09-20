////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\GalaxyPanelModel.cs
//
// summary:	Implements the galaxy panel model class
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent galaxy panel models. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum GalaxyPanelModel
    {
        None = 0,
        /// <summary>   An enum constant representing the galaxy panel 5xx option. </summary>
        GalaxyPanel5xx = 500,
        /// <summary>   An enum constant representing the galaxy panel 600 option. </summary>
        GalaxyPanel600 = 600,
        /// <summary>   An enum constant representing the galaxy panel 635 option. </summary>
        GalaxyPanel635 = 635,
        /// <summary>   An enum constant representing the galaxy panel 708 option. </summary>
        GalaxyPanel708 = 708
    }
}
