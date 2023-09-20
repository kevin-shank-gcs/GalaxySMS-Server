using GalaxySMS.Business.Entities;
using GCS.Core.Common.Logger;
using GCS.Core.Common.SignalR;
using Microsoft.AspNet.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxySMS.Business.SignalR
{
    //[Authorize]
    public class GalaxySMSSignalRHub : Hub
    {
        public GalaxySMSSignalRHub()
        {
            //System.Diagnostics.Trace.WriteLine($"GalaxySMSSignalRHub constructor");
        }
        /// <summary>
        /// Context instance to access client connections to broadcast to
        /// </summary>
        public static IHubContext HubContext
        {
            get
            {
                if (_context == null)
                    _context = GlobalHost.ConnectionManager.GetHubContext<GalaxySMSSignalRHub>();

                return _context;
            }
        }
        static IHubContext _context = null;

        public override Task OnConnected()
        {
            this.Log().InfoFormat($"Client connected: {Context.ConnectionId}");

            return base.OnConnected();
        }

        public Task JoinGroup(SignalRGroup group)
        {
            try
            {
                this.Log().InfoFormat($"Client: {Context.ConnectionId}. Join Group: {group.GroupName}");
                return Groups.Add(Context.ConnectionId, group.GroupName);
            }
            catch (AggregateException e)
            {
                var flattenedEx = e.Flatten();
                foreach (var innerEx in flattenedEx.InnerExceptions)
                {
                    this.Log().ErrorFormat("GalaxySMSSignalRHub.JoinGroup exception {0}", innerEx.ToString());
                }
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat("GalaxySMSSignalRHub.JoinGroup exception: {0}: {1} " + Context.ConnectionId, e.ToString());
            }
            return null;
        }

        public Task LeaveGroup(SignalRGroup group)
        {
            try
            {
                this.Log().InfoFormat($"Client: {Context.ConnectionId}. Leaving Group: {group.GroupName}");
                return Groups.Remove(Context.ConnectionId, group.GroupName);
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat("GalaxySMSSignalRHub.LeaveGroup exception: {0}: {1} " + Context.ConnectionId, e.ToString());
            }
            return null;
        }

        public void SendMessage(string message)
        {
            HubContext.Clients.All.sendMessage(message);
        }

        public void NotifyPanelBoardInformationCollection(PanelBoardInformationCollection data)
        {
            try
            {
                //                HubContext.Clients.All.notifyPanelBoardInformationCollection(data);

                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                {
                    this.Log().InfoFormat($"Clients.All.notifyPanelBoardInformationCollection");
                    HubContext.Clients.All.notifyPanelBoardInformationCollection(data);
                }
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        this.Log().InfoFormat($"Clients.Group({s.ToString()}).notifyPanelBoardInformationCollection");
                        HubContext.Clients.Group(s.ToString()).notifyPanelBoardInformationCollection(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifySerialChannelGalaxyDoorModuleDataCollection(SerialChannelGalaxyDoorModuleDataCollection data)
        {
            try
            {
                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                    HubContext.Clients.All.notifySerialChannelGalaxyDoorModuleDataCollection(data);
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        HubContext.Clients.Group(s.ToString()).notifySerialChannelGalaxyDoorModuleDataCollection(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifySerialChannelGalaxyInputModuleDataCollection(SerialChannelGalaxyInputModuleDataCollection data)
        {
            try
            {
                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                    HubContext.Clients.All.notifySerialChannelGalaxyInputModuleDataCollection(data);
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        HubContext.Clients.Group(s.ToString()).notifySerialChannelGalaxyInputModuleDataCollection(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyPanelInqueryReply(PanelInqueryReply data)
        {
            try
            {
                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                    HubContext.Clients.All.notifyPanelInqueryReply(data);
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        HubContext.Clients.Group(s.ToString()).notifyPanelInqueryReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyCardCountReply(CredentialCountReply data)
        {
            try
            {
                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                    HubContext.Clients.All.notifyCardCountReply(data);
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        HubContext.Clients.Group(s.ToString()).notifyCardCountReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyLoggingStatusReply(LoggingStatusReply data)
        {
            try
            {
                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                    HubContext.Clients.All.notifyLoggingStatusReply(data);
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        HubContext.Clients.Group(s.ToString()).notifyLoggingStatusReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyFlashProgressMessage(FlashProgressMessage data)
        {
            try
            {
                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                    HubContext.Clients.All.notifyFlashProgressMessage(data);
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        HubContext.Clients.Group(s.ToString()).notifyFlashProgressMessage(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyPanelLoadDataReply(PanelLoadDataReply data)
        {
            try
            {
                //this.Log().InfoFormat($"SignalRHub NotifyPanelLoadDataReply {data.DataType}");
                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                {
                    this.Log().InfoFormat($"HubContext.Clients.All.notifyPanelLoadDataReply {data.DataType}");
                    HubContext.Clients.All.notifyPanelLoadDataReply(data);
                }
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        this.Log().InfoFormat($"HubContext.Clients.Group({s.ToString()}).notifyPanelLoadDataReply {data.DataType}");
                        HubContext.Clients.Group(s.ToString()).notifyPanelLoadDataReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyAccessPortalStatusReply(AccessPortalStatusReply data)
        {
            try
            {
                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                    HubContext.Clients.All.notifyAccessPortalStatusReply(data);
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        HubContext.Clients.Group(s.ToString()).notifyAccessPortalStatusReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyAccessPortalCommandReply(AccessPortalCommandReply data)
        {
            try
            {
                if (data.SessionIdsToSendTo == null || !data.SessionIdsToSendTo.Any())
                    HubContext.Clients.All.notifyAccessPortalCommandReply(data);
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        HubContext.Clients.Group(s.ToString()).notifyAccessPortalCommandReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyInputDeviceStatusReply(InputDeviceStatusReply data)
        {
            try
            {
                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                    HubContext.Clients.All.notifyInputDeviceStatusReply(data);
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        HubContext.Clients.Group(s.ToString()).notifyInputDeviceStatusReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyInputDeviceVoltagesReply(InputDeviceVoltagesReply data)
        {
            try
            {
                if (data.SessionIdsToSendTo == null || data.SessionIdsToSendTo.Count() == 0)
                    HubContext.Clients.All.notifyInputDeviceVoltagesReply(data);
                else
                {
                    foreach (var s in data.SessionIdsToSendTo)
                    {
                        HubContext.Clients.Group(s.ToString()).notifyInputDeviceVoltagesReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyCpuConnectionInfo(CpuConnectionInfo data)
        {
            try
            {
                if (data.CpuDatabaseInformation?.EntityId == null || data.CpuDatabaseInformation?.EntityId == Guid.Empty)
                    HubContext.Clients.All.notifyCpuConnectionInfo(data);
                else
                {
                    HubContext.Clients.Group(data.CpuDatabaseInformation.EntityId.ToString()).notifyCpuConnectionInfo(data);
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyPanelActivityLogMessage(PanelActivityLogMessage data)
        {
            try
            {
                if (data.DeviceEntityId != Guid.Empty)
                    HubContext.Clients.Group(data.DeviceEntityId.ToString()).notifyPanelActivityLogMessage(data);
                else
                    HubContext.Clients.All.notifyPanelActivityLogMessage(data);
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyPanelCredentialActivityLogMessage(PanelCredentialActivityLogMessage data)
        {
            try
            {
                if (data.DeviceEntityId != Guid.Empty)
                    HubContext.Clients.Group(data.DeviceEntityId.ToString()).notifyPanelCredentialActivityLogMessage(data);
                else
                    HubContext.Clients.All.notifyPanelCredentialActivityLogMessage(data);
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyAcknowledgedAlarmBasicData(AcknowledgedAlarmBasicData data)
        {
            try
            {
                if (data.DeviceEntityId != Guid.Empty)
                    HubContext.Clients.Group(data.DeviceEntityId.ToString()).notifyAcknowledgedAlarmBasicData(data);
                else
                    HubContext.Clients.All.notifyAcknowledgedAlarmBasicData(data);
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public void NotifyBackgroundJobInfo(BackgroundJobInfo data)
        {
            try
            {
                if (data.JobId != Guid.Empty)
                    HubContext.Clients.Group(data.JobId.ToString()).notifyBackgroundJobInfo(data);
                HubContext.Clients.All.notifyBackgroundJobInfo(data);
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }

        }
    }
}
