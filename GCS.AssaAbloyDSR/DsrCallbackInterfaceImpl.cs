using System;
using System.ServiceModel;
using System.Xml;

namespace GCS.AssaAbloyDSR
{
    public class DsrCallbackInterfaceImpl : DsrCallbackInterface
    {
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

        #region DsrCallbackInterface Members

        public DsrCallbackInterfaceImpl()
        {
            System.Diagnostics.Trace.WriteLine(string.Format("DsrCallbackInterfaceImpl constructor {0}", this.ToString()));
        }

        public notifyUpdatedResponse notifyUpdated(notifyUpdated request)
        {
            //throw new NotImplementedException();
            string result = "Time: " + DateTime.Now + " ";
            result += "### notifyUpdated ### ";
            result += "Access Point Serial Number: " + request.accessPoint.serialNumber + " ";
            result += "Access Point Name: " + request.accessPoint.accessPointType.displayName + " ";
            result += "Last Seen: " + request.accessPoint.lastSeen + " ";
            result += "Type: " + request.accessPoint.accessPointType + " ";

            NotifyAccessPointUpdatedEvent?.Invoke(this, new NotifyAccessPointUpdatedEventArgs(request.accessPoint));
            return new notifyUpdatedResponse();
        }

        public newEventResponse newEvent(newEvent request)
        {
            string result = "Time: " + request.logEntry.timeStamp + " ";
            result += "$$$ newEvent $$$ ";
            result += "Family: " + request.logEntry.family + " ";
            result += "Code: " + request.logEntry.code + " ";
            result += "Origin: " + request.logEntry.origin.logOriginType + " ";
            result += "Door: " + request.logEntry.origin.originId + " ";
            if (request.logEntry.logData != null)
            {
                foreach (var logEntryLogData in request.logEntry.logData)
                {
                    result += string.Format("/tName: " + logEntryLogData.name + ", Value: " + logEntryLogData.value.stringValue);
                }
            }

            NewEventEvent?.Invoke(this, new NewEventEventArgs(request));

            return new newEventResponse();
        }
        #endregion
    }
}
