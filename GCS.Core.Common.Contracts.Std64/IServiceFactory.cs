using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace GCS.Core.Common.Contracts
{
    public interface IServiceFactory
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a client. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        ///
        /// <returns>   The new client. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T CreateClient<T>() where T : IServiceContract;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a client. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="binding">                          The binding. </param>
        /// <param name="endpointAddress">                  The endpoint address. </param>
        /// <param name="applicationUserSessionDataHeader"> The application user session data header. </param>
        ///
        /// <returns>   The new client. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T CreateClient<T>(Binding binding, EndpointAddress endpointAddress, IApplicationUserSessionDataHeader applicationUserSessionDataHeader) where T : IServiceContract;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates duplex client. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="callbackInstance"> The callback instance. </param>
        ///
        /// <returns>   The new duplex client. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T CreateDuplexClient<T>(object callbackInstance) where T : IServiceContract;

 //       T CreateChannel<T>(Binding binding, EndpointAddress endpointAddress) where T : IServiceContract;
    }

}
