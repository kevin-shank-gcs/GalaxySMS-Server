using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Logger;

namespace GCS.AssaAbloyDSR
{
    public class DsrCallbackService : IDisposable
    {
        public static ServiceHost CallbackServiceHost;
        public string CallbackUrl { get; set; }
        public int CallbackPort { get; set; }

        public DsrCallbackService()
        {
            var ipAddress = GCS.Core.Common.Utils.Net.GetMyIpAddress();
            var ipAddresses = GCS.Core.Common.Utils.Net.GetMyIpAddresses();
        }

        public void Start()
        {
            try
            {
                if (CallbackPort <= 0)
                    CallbackPort = 9090;

                if (string.IsNullOrEmpty(CallbackUrl))
                {
                    var ipAddress = GCS.Core.Common.Utils.Net.GetMyIpAddress();
                    var ipAddresses = GCS.Core.Common.Utils.Net.GetMyIpAddresses();
                    CallbackUrl = string.Format("http://{0}:{1}/callback", ipAddress.ToString(), CallbackPort);
                }

                CallbackServiceHost = new ServiceHost(typeof(DsrCallbackInterfaceImpl));
                var httpBinding = new BasicHttpBinding();
                httpBinding.Security.Mode = BasicHttpSecurityMode.None;

                var customHttpBinding = new CustomBinding();
                customHttpBinding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8));
                customHttpBinding.Elements.Add(new HttpTransportBindingElement());
                var ep = CallbackServiceHost.AddServiceEndpoint(typeof(DsrCallbackInterface),
                    customHttpBinding, new Uri(CallbackUrl));

                CallbackServiceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
                CallbackServiceHost.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });

                CallbackServiceHost.Open();
            }
            catch (Exception ex)
            {
                this.Log().Error(DsrManagementServiceMethodNames.ListAllAccessPoints, ex);
                throw;
            }
        }

        public void Stop()
        {
            if (CallbackServiceHost != null)
            {
                CallbackServiceHost.Close();
                CallbackServiceHost = null;
            }
        }

        #region Events
        #region NotifyAccessPointUpdated Event

        public class NotifyAccessPointUpdatedEventArgs : EventArgs
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 6/9/2014. </remarks>
            ///
            /// <param name="arg">  The argument. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public NotifyAccessPointUpdatedEventArgs(accessPoint arg)
            {
                Time = DateTime.Now;
                AccessPointData = arg;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets information describing the event. </summary>
            ///
            /// <value> Information describing the event. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            public DateTime Time { get; internal set; }
            public accessPoint AccessPointData { get; private set; }
        }

        public delegate void NotifyAccessPointUpdatedResponseEventHandler(object sender, NotifyAccessPointUpdatedEventArgs e);
        public event NotifyAccessPointUpdatedResponseEventHandler NotifyAccessPointUpdatedEvent;
        #endregion

        #region NewEvent Event

        public class NewEventEventArgs : EventArgs
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 6/9/2014. </remarks>
            ///
            /// <param name="arg">  The argument. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public NewEventEventArgs(newEvent arg)
            {
                Time = DateTime.Now;
                EventData = arg;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets information describing the event. </summary>
            ///
            /// <value> Information describing the event. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            public DateTime Time { get; internal set; }
            public newEvent EventData { get; private set; }
        }

        public delegate void NewEventEventHandler(object sender, NewEventEventArgs e);
        public event NewEventEventHandler NewEventEvent;
        #endregion

        #endregion

        #region IDisposable Implimentation
        public void Dispose()
        {
            Stop();
        } 
        #endregion
    }
}
