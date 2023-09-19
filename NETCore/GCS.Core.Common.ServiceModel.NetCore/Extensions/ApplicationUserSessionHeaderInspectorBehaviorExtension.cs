////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\ApplicationUserSessionHeaderInspectorBehaviorExtension.cs
//
// summary:	Implements the application user session header inspector behavior extension class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.ServiceModel.Configuration;

namespace GCS.Core.Common.ServiceModel.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An application user session header inspector behavior extension. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ApplicationUserSessionHeaderInspectorBehaviorExtension : BehaviorExtensionElement
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a behavior extension based on the current configuration settings. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The behavior extension. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override object CreateBehavior()
        {
            return new ApplicationUserSessionHeaderInspectorBehavior();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the type of behavior. </summary>
        ///
        /// <value> The type of behavior. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override Type BehaviorType
        {
            get { return typeof (ApplicationUserSessionHeaderInspectorBehavior); }
        }
    }
}