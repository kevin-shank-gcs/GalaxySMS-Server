////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\GalaxyPanelAlertEventType.cs
//
// summary:	Implements the galaxy panel alert event type class
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent galaxy panel alert event types. </summary>
    ///
    /// <remarks>   Kevin, 3/7/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum GalaxyPanelAlertEventType
    {

        /// <summary>   An enum constant representing the low battery option. </summary>
        LowBattery = 1,

        /// <summary>   An enum constant representing the AC failure option. </summary>
        ACFailure,

        /// <summary>   An enum constant representing the tamper option. </summary>
        Tamper,

        /// <summary>   An enum constant representing the emergency unlock option. </summary>
        EmergencyUnlock,
    }
}
