////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\ApplicationUserSessionHeaderInspectorBehavior.cs
//
// summary:	Implements the application user session header inspector behavior class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using GCS.Core.Common.Contracts;
//using GCS.Core.Common.Logger;
using Message = System.ServiceModel.Channels.Message;

namespace GCS.Core.Common.ServiceModel.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// This is based on this article:
    /// http://trycatch.me/adding-custom-message-headers-to-a-wcf-service-using-inspectors-behaviors/.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [AttributeUsage(AttributeTargets.Class)]
    public class ApplicationUserSessionHeaderInspectorBehavior : Attribute, IDispatchMessageInspector, 
        IClientMessageInspector, IEndpointBehavior, IServiceBehavior
    {
        #region IDispatchMessageInspector

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Called after an inbound message has been received but before the message is dispatched to the
        /// intended operation.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="request">          [in,out] The request message. </param>
        /// <param name="channel">          The incoming channel. </param>
        /// <param name="instanceContext">  The current service instance. </param>
        ///
        /// <returns>
        /// The object used to correlate state. This object is passed back in the
        /// <see cref="M:System.ServiceModel.Dispatcher.IDispatchMessageInspector.BeforeSendReply(System.ServiceModel.Channels.Message@,System.Object)" />
        /// method.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //Retrieve Inbound Object from Request
            try
            {
                var header = request.Headers.GetHeader<ApplicationUserSessionHeader>(HeaderNames.ApplicationUserSessionHeaderName, HeaderNames.HeaderNamespace);
                if (header != null)
                {
                    //CustomHeaderServerContextExtension.Current.ApplicationUserSessionHeader = header;
                    OperationContext.Current.IncomingMessageProperties.Add(HeaderNames.ApplicationUserSessionHeaderName, header);
                }
            }
            catch (Exception ex)
            {
//               this.Log().Error(this, ex); 
            }

            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Called after the operation has returned but before the reply message is sent.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="reply">            [in,out] The reply message. This value is null if the
        ///                                 operation is one way. </param>
        /// <param name="correlationState"> The correlation object returned from the
        ///                                 <see cref="M:System.ServiceModel.Dispatcher.IDispatchMessageInspector.AfterReceiveRequest(System.ServiceModel.Channels.Message@,System.ServiceModel.IClientChannel,System.ServiceModel.InstanceContext)" />
        ///                                 method. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            //No need to do anything else
            
        }

        #endregion

        #region IClientMessageInspector

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Enables inspection or modification of a message before a request message is sent to a service.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="request">  [in,out] The message to be sent to the service. </param>
        /// <param name="channel">  The WCF client object channel. </param>
        ///
        /// <returns>
        /// The object that is returned as the <paramref name="correlationState " />argument of the
        /// <see cref="M:System.ServiceModel.Dispatcher.IClientMessageInspector.AfterReceiveReply(System.ServiceModel.Channels.Message@,System.Object)" />
        /// method. This is null if no correlation state is used.The best practice is to make this a
        /// <see cref="T:System.Guid" /> to ensure that no two <paramref name="correlationState" />
        /// objects are the same.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var dataToSend =
                new ApplicationUserSessionHeader(ClientApplicationUserSessionHeaderContext.HeaderInformation);

            var typedHeader = new MessageHeader<IApplicationUserSessionDataHeader>(dataToSend);
            var untypedHeader = typedHeader.GetUntypedHeader(HeaderNames.ApplicationUserSessionHeaderName, HeaderNames.HeaderNamespace);

            request.Headers.Add(untypedHeader);
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Enables inspection or modification of a message after a reply message is received but prior
        /// to passing it back to the client application.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="reply">            [in,out] The message to be transformed into types and handed
        ///                                 back to the client application. </param>
        /// <param name="correlationState"> Correlation state data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            //No need to do anything else
        }
    
        #endregion

        #region IEndpointBehavior

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Implement to confirm that the endpoint meets some intended criteria. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="endpoint"> The endpoint to validate. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Validate(ServiceEndpoint endpoint)
        {
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Implement to pass data at runtime to bindings to support custom behavior. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="endpoint">             The endpoint to modify. </param>
        /// <param name="bindingParameters">    The objects that binding elements require to support the
        ///                                     behavior. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Implements a modification or extension of the service across an endpoint. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="endpoint">             The endpoint that exposes the contract. </param>
        /// <param name="endpointDispatcher">   The endpoint dispatcher to be modified or extended. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            var channelDispatcher = endpointDispatcher.ChannelDispatcher;
            if (channelDispatcher == null) return;
            foreach (var ed in channelDispatcher.Endpoints)
            {
                var inspector = new ApplicationUserSessionHeaderInspectorBehavior();
                ed.DispatchRuntime.MessageInspectors.Add(inspector);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Implements a modification or extension of the client across an endpoint. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="endpoint">         The endpoint that is to be customized. </param>
        /// <param name="clientRuntime">    The client runtime to be customized. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            var inspector = new ApplicationUserSessionHeaderInspectorBehavior();
            clientRuntime.MessageInspectors.Add(inspector);
        }

        #endregion

        #region IServiceBehaviour

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Provides the ability to inspect the service host and the service description to confirm that
        /// the service can run successfully.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="serviceDescription">   The service description. </param>
        /// <param name="serviceHostBase">      The service host that is currently being constructed. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Provides the ability to pass custom data to binding elements to support the contract
        /// implementation.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="serviceDescription">   The service description of the service. </param>
        /// <param name="serviceHostBase">      The host of the service. </param>
        /// <param name="endpoints">            The service endpoints. </param>
        /// <param name="bindingParameters">    Custom objects to which binding elements have access. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Provides the ability to change run-time property values or insert custom extension objects
        /// such as error handlers, message or parameter interceptors, security extensions, and other
        /// custom extension objects.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="serviceDescription">   The service description. </param>
        /// <param name="serviceHostBase">      The host that is currently being built. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher cDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (var eDispatcher in cDispatcher.Endpoints)
                {
                    eDispatcher.DispatchRuntime.MessageInspectors.Add(new ApplicationUserSessionHeaderInspectorBehavior());
                }
            }
        }

        #endregion

    }
}