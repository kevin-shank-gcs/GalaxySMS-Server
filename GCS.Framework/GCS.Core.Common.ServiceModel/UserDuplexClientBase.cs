////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	UserDuplexClientBase.cs
//
// summary:	Implements the user duplex client base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

namespace GCS.Core.Common.ServiceModel
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user duplex client base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class UserDuplexClientBase<T> : DuplexClientBase<T> where T : class
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="callbackInstance"> The callback instance. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserDuplexClientBase(object callbackInstance) : base(callbackInstance)
        {
            InsertUserDataToOutgoingHeader();
            string userName = Thread.CurrentPrincipal.Identity.Name;
            MessageHeader<string> header = new MessageHeader<string>(userName);

            OperationContextScope contextScope =
                            new OperationContextScope(InnerChannel);

            OperationContext.Current.OutgoingMessageHeaders.Add(
                                      header.GetUntypedHeader("String", "System"));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inserts a user data to outgoing header. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InsertUserDataToOutgoingHeader()
        {
            System.Security.Principal.IPrincipal p = Thread.CurrentPrincipal;
            if (Thread.CurrentPrincipal.Identity.Name == string.Empty)
                Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            string userName = Thread.CurrentPrincipal.Identity.Name;
            MessageHeader<string> header = new MessageHeader<string>(userName);
            MessageHeader<Guid> secHdr = new MessageHeader<Guid>(GalaxyUserSessionGuid);
            MessageHeader<string> cultureHdr = new MessageHeader<string>(CultureInfo.CurrentCulture.ToString());
            MessageHeader<string> uiCultureHdr = new MessageHeader<string>(CultureInfo.CurrentUICulture.ToString());

            OperationContextScope contextScope = new OperationContextScope(InnerChannel);

            OperationContext.Current.OutgoingMessageHeaders.Add(
            header.GetUntypedHeader("CurrentThreadUserName", "System"));

            OperationContext.Current.OutgoingMessageHeaders.Add(
            secHdr.GetUntypedHeader("GalaxyUserSessionId", "System"));

            OperationContext.Current.OutgoingMessageHeaders.Add(
            cultureHdr.GetUntypedHeader("CurrentThreadCultureName", "System"));

            OperationContext.Current.OutgoingMessageHeaders.Add(
            uiCultureHdr.GetUntypedHeader("CurrentThreadUICultureName", "System"));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the galaxy user session. </summary>
        ///
        /// <value> Unique identifier of the galaxy user session. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid GalaxyUserSessionGuid { get; set; }
    }
}
