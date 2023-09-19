////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\ClientApplicationUserSessionHeaderContext.cs
//
// summary:	Implements the client application user session header context class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Contracts;

namespace GCS.Core.Common.ServiceModel.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A client application user session header context. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class ClientApplicationUserSessionHeaderContext
    {
        /// <summary>   Information describing the header. </summary>
        public static IApplicationUserSessionDataHeader HeaderInformation;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Static constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static ClientApplicationUserSessionHeaderContext()
        {
#if NetCoreApi
            HeaderInformation = new GCS.Core.Common.ServiceModel.Api.ApplicationUserSessionHeader();
#else
            HeaderInformation = new ApplicationUserSessionHeader();
#endif            
        }
    }
}