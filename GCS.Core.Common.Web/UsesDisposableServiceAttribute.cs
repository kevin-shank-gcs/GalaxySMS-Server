////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	UsesDisposableServiceAttribute.cs
//
// summary:	Implements the uses disposable service attribute class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using GCS.Core.Common.Contracts;

namespace GCS.Core.Common.Web
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Attribute for uses disposable service. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UsesDisposableServiceAttribute : ActionFilterAttribute
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Occurs before the action method is invoked. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="actionContext">    The action context. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // pre-processing

            IServiceAwareController controller = actionContext.ControllerContext.Controller as IServiceAwareController;
            if (controller != null)
            {
                controller.RegisterDisposableServices(((IServiceAwareController)controller).DisposableServices);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Occurs after the action method is invoked. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="actionExecutedContext">    The action executed context. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //post-processing

            IServiceAwareController controller = actionExecutedContext.ActionContext.ControllerContext.Controller as IServiceAwareController;
            if (controller != null)
            {
                foreach (var service in controller.DisposableServices)
                {
                    if (service != null && service is IDisposable)
                        (service as IDisposable).Dispose();
                }
            }
        }
    }
}
