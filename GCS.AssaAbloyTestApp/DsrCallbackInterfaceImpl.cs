using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml;
using GCS.AssaAbloyTestApp;

namespace DSREventViewer
{
    class DsrCallbackInterfaceImpl : DsrCallbackInterface
    {
        #region DsrCallbackInterface Members

        public DsrCallbackInterfaceImpl()
        {
            System.Diagnostics.Trace.WriteLine("DsrCallbackInterfaceImpl constructor");
        }

        public notifyUpdatedResponse notifyUpdated(notifyUpdated request)
        {
            //throw new NotImplementedException();
            string result = "Time: " + DateTimeOffset.Now + " ";
            result += "### notifyUpdated ### ";
            result += "Access Point Serial Number: " + request.accessPoint.serialNumber + " ";
            result += "Access Point Name: " + request.accessPoint.accessPointType.displayName + " ";
            result += "Last Seen: " + request.accessPoint.lastSeen + " ";
            result += "Type: " + request.accessPoint.accessPointType + " ";
            MainForm.addEventText(result);
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
            if(request.logEntry.logData != null)
            {
                foreach (var logEntryLogData in request.logEntry.logData)
                {
                    result += string.Format("/tName: " + logEntryLogData.name + ", Value: " + logEntryLogData.value.stringValue);
                }
            }
            MainForm.addEventText(result);

            return new newEventResponse();
        }

        //public Task<newEventResponse> newEventAsync(newEvent request)
        //{
        //    return Task.Run(() =>
        //    {
        //        return newEvent(request);
        //    });
        //}

        //public Task<notifyUpdatedResponse> notifyUpdatedAsync(notifyUpdated request)
        //{
        //    return Task.Run(() =>
        //    {
        //        return notifyUpdated(request);
        //    });
        //}
        #endregion
    }
}
