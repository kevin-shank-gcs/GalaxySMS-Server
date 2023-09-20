////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	UserClientBase.cs
//
// summary:	Implements the user client base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

namespace GCS.Core.Common.ServiceModel
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user client base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class UserClientBase<T> : ClientBase<T> where T : class
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserClientBase()
        {
            InsertUserDataToOutgoingHeader();
            //System.Security.Principal.IPrincipal p = Thread.CurrentPrincipal;
            //if (Thread.CurrentPrincipal.Identity.Name == string.Empty)
            //    Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            //string userName = Thread.CurrentPrincipal.Identity.Name;
            //MessageHeader<string> header = new MessageHeader<string>(userName);

            //OperationContextScope contextScope =
            //                new OperationContextScope(InnerChannel);

            //OperationContext.Current.OutgoingMessageHeaders.Add(
            //                          header.GetUntypedHeader("String", "System"));
            //int x = 1;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="binding">          The binding. </param>
        /// <param name="endpointAddress">  The endpoint address. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserClientBase(Binding binding, EndpointAddress endpointAddress)
            :base(binding, endpointAddress)
        {
            InsertUserDataToOutgoingHeader();
            //System.Security.Principal.IPrincipal p = Thread.CurrentPrincipal;
            //if (Thread.CurrentPrincipal.Identity.Name == string.Empty)
            //    Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            //string userName = Thread.CurrentPrincipal.Identity.Name;
            //MessageHeader<string> header = new MessageHeader<string>(userName);

            //OperationContextScope contextScope =
            //                new OperationContextScope(InnerChannel);

            //OperationContext.Current.OutgoingMessageHeaders.Add(
            //                          header.GetUntypedHeader("String", "System"));
            //int x = 1;
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
        //public string CultureName { get; set; }
        //public string UICultureName { get; set; }
    }
}
