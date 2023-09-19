////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ErrorHandlingPipelineModule.cs
//
// summary:	Implements the error handling pipeline module class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace GCS.Core.Common.SignalR
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An error handling pipeline module. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ErrorHandlingPipelineModule : HubPipelineModule
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// This is called when an uncaught exception is thrown by a server-side hub method or the
        /// incoming component of a module added later to the
        /// <see cref="T:Microsoft.AspNet.SignalR.Hubs.IHubPipeline" />. Observing the exception using
        /// this method will not prevent it from bubbling up to other modules.
        /// </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="exceptionContext"> Represents the exception that was thrown during the server-
        ///                                 side invocation. It is possible to change the error or set a
        ///                                 result using this context. </param>
        /// <param name="invokerContext">   A description of the server-side hub method invocation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
        {
            Debug.WriteLine("=> Exception " + exceptionContext.Error.Message);
            if (exceptionContext.Error.InnerException != null)
            {
                Debug.WriteLine("=> Inner Exception " + exceptionContext.Error.InnerException.Message);
            }
            base.OnIncomingError(exceptionContext, invokerContext);

        }
    }
}
