using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Logger;
using GCS.Core.Common.SignalR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace GalaxySMS.SignalR.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GalaxySMSSignalRHub : Hub<IGalaxySMSSignalRHub>
    {
        public GalaxySMSSignalRHub()
        {
            //System.Diagnostics.Trace.WriteLine($"GalaxySMSSignalRHub constructor");
        }
        ///// <summary>
        ///// Context instance to access client connections to broadcast to
        ///// </summary>
        //public static IHubContext HubContext
        //{
        //    get
        //    {
        //        if (_context == null)
        //            _context = GlobalHost.ConnectionManager.GetHubContext<GalaxySMSSignalRHub>();

        //        return _context;
        //    }
        //}

        //static IHubContext _context = null;

        public override async Task OnConnectedAsync()
        {
            this.Log().InfoFormat($"Client connected: {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            this.Log().InfoFormat($"Client disconnected: {Context.ConnectionId}");

            await base.OnDisconnectedAsync(exception);
        }

        //[Authorize]
        public Task JoinGroup(SignalRGroup group)
        {
            try
            {
                this.Log().InfoFormat($"Client: {Context.ConnectionId}. Join Group: {group.GroupName}");
                return Groups.AddToGroupAsync(Context.ConnectionId, group.GroupName);
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
                return Groups.RemoveFromGroupAsync(Context.ConnectionId, group.GroupName);
            }
            catch (Exception e)
            {
                this.Log().ErrorFormat("GalaxySMSSignalRHub.LeaveGroup exception: {0}: {1} " + Context.ConnectionId, e.ToString());
            }
            return null;
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendMessage(message);
        }

        public async Task NotifyPanelBoardInformationCollection(PanelBoardInformationCollectionSignalR data)
        {
            try
            {
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if( data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();
#if DEBUG
                await Clients.All.NotifyPanelBoardInformationCollection(data);
#endif
                
                if (groupIds == null || !groupIds.Any())
                {
                    this.Log().InfoFormat($"await Clients.All.NotifyPanelBoardInformationCollection");
                    await Clients.All.NotifyPanelBoardInformationCollection(data);
                }
                else
                {
                    foreach (var s in groupIds)
                    {
                        this.Log().InfoFormat($"await Clients.Group({s.ToString()}).NotifyPanelBoardInformationCollection");
                        await Clients.Group(s.ToString()).NotifyPanelBoardInformationCollection(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifySerialChannelGalaxyDoorModuleDataCollection(SerialChannelGalaxyDoorModuleDataCollection data)
        {
            try
            {

                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();
#if DEBUG
                await Clients.All.NotifySerialChannelGalaxyDoorModuleDataCollection(data);
#endif

                if (groupIds == null || !groupIds.Any())
                    await Clients.All.NotifySerialChannelGalaxyDoorModuleDataCollection(data);
                else
                {
                    foreach (var s in groupIds)
                    {
                        await Clients.Group(s.ToString()).NotifySerialChannelGalaxyDoorModuleDataCollection(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifySerialChannelGalaxyInputModuleDataCollection(SerialChannelGalaxyInputModuleDataCollection data)
        {
            try
            {
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();
#if DEBUG
                await Clients.All.NotifySerialChannelGalaxyInputModuleDataCollection(data);
#endif

                if (groupIds == null || !groupIds.Any())
                    await Clients.All.NotifySerialChannelGalaxyInputModuleDataCollection(data);
                else
                {
                    foreach (var s in groupIds)
                    {
                        await Clients.Group(s.ToString()).NotifySerialChannelGalaxyInputModuleDataCollection(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyPanelInqueryReply(PanelInqueryReplySignalR data)
        {
            try
            {
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();
#if DEBUG
                await Clients.All.NotifyPanelInqueryReply(data);
#endif

                if (groupIds == null || !groupIds.Any())
                    await Clients.All.NotifyPanelInqueryReply(data);
                else
                {
                    foreach (var s in groupIds)
                    {
                        await Clients.Group(s.ToString()).NotifyPanelInqueryReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }
        
        public async Task NotifyPingReply(PingReplySignalR data)
        {
            try
            {
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();

#if DEBUG
                await Clients.All.NotifyPingReply(data);
#endif
                if (groupIds == null || !groupIds.Any())
                    await Clients.All.NotifyPingReply(data);
                else
                {
                    foreach (var s in groupIds)
                    {
                        await Clients.Group(s.ToString()).NotifyPingReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyCardCountReply(CredentialCountReplySignalR data)
        {
            try
            {
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();

#if DEBUG
                await Clients.All.NotifyCardCountReply(data);
#endif
                if (groupIds == null || !groupIds.Any())
                    await Clients.All.NotifyCardCountReply(data);
                else
                {
                    foreach (var s in groupIds)
                    {
                        await Clients.Group(s.ToString()).NotifyCardCountReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyLoggingStatusReply(LoggingStatusReplySignalR data)
        {
            try
            {
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();

#if DEBUG
                await Clients.All.NotifyLoggingStatusReply(data);
#endif
                if (groupIds == null || !groupIds.Any())
                    await Clients.All.NotifyLoggingStatusReply(data);
                else
                {
                    foreach (var s in groupIds)
                    {
                        await Clients.Group(s.ToString()).NotifyLoggingStatusReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyFlashProgressMessage(FlashProgressMessage data)
        {
            try
            {
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();

#if DEBUG
                await Clients.All.NotifyFlashProgressMessage(data);
#endif
                if (groupIds == null || !groupIds.Any()) 
                    await Clients.All.NotifyFlashProgressMessage(data);
                else
                {
                    foreach (var s in groupIds)
                    {
                        await Clients.Group(s.ToString()).NotifyFlashProgressMessage(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyPanelLoadDataReply(PanelLoadDataReplySignalR data)
        {
            try
            {
                //this.Log().InfoFormat($"SignalRHub NotifyPanelLoadDataReply {data.DataType}");
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();

#if DEBUG
                await Clients.All.NotifyPanelLoadDataReply(data);
#endif
                if (groupIds == null || !groupIds.Any())
                {
                    this.Log().InfoFormat($"await Clients.All.NotifyPanelLoadDataReply {data.DataType}");
                    await Clients.All.NotifyPanelLoadDataReply(data);
                }
                else
                {
                    foreach (var s in groupIds)
                    {
                        this.Log().InfoFormat($"await Clients.Group({s.ToString()}).NotifyPanelLoadDataReply {data.DataType}");
                        await Clients.Group(s.ToString()).NotifyPanelLoadDataReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }


//        public async Task NotifyPanelLoadDataNotificationCounts(LoadDataToPanelSettings data)
//        {
//            try
//            {
//                //this.Log().InfoFormat($"SignalRHub NotifyPanelLoadDataReply {data.DataType}");
//                var groupIds = data.SessionIdsToSendTo?.ToList();
//                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
//                    data.SessionIdsToSendTo.Clear();

//#if DEBUG
//                await Clients.All.NotifyPanelLoadDataReply(data);
//#endif
//                if (groupIds == null || !groupIds.Any())
//                {
//                    this.Log().InfoFormat($"await Clients.All.NotifyPanelLoadDataReply {data.DataType}");
//                    await Clients.All.NotifyPanelLoadDataReply(data);
//                }
//                else
//                {
//                    foreach (var s in groupIds)
//                    {
//                        this.Log().InfoFormat($"await Clients.Group({s.ToString()}).NotifyPanelLoadDataReply {data.DataType}");
//                        await Clients.Group(s.ToString()).NotifyPanelLoadDataReply(data);
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
//            }
//        }

        
        public async Task NotifyAccessPortalStatusReply(AccessPortalStatusReply data)
        {
            try
            {
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();

#if DEBUG
                await Clients.All.NotifyAccessPortalStatusReply(data);
#endif
                if (groupIds == null || !groupIds.Any())
                    await Clients.All.NotifyAccessPortalStatusReply(data);
                else
                {
                    foreach (var s in groupIds)
                    {
                        await Clients.Group(s.ToString()).NotifyAccessPortalStatusReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyInputDeviceStatusReply(InputDeviceStatusReply data)
        {
            try
            {
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();

#if DEBUG
                await Clients.All.NotifyInputDeviceStatusReply(data);
#endif
                if (groupIds == null || !groupIds.Any())
                    await Clients.All.NotifyInputDeviceStatusReply(data);
                else
                {
                    foreach (var s in groupIds)
                    {
                        await Clients.Group(s.ToString()).NotifyInputDeviceStatusReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyInputDeviceVoltagesReply(InputDeviceVoltagesReply data)
        {
            try
            {
                var groupIds = data.SessionIdsToSendTo?.ToList();
                if (data.SessionIdsToSendTo != null && data.SessionIdsToSendTo.Any())
                    data.SessionIdsToSendTo.Clear();

#if DEBUG
                await Clients.All.NotifyInputDeviceVoltagesReply(data);
#endif
                if (groupIds == null || !groupIds.Any())
                    await Clients.All.NotifyInputDeviceVoltagesReply(data);
                else
                {
                    foreach (var s in groupIds)
                    {
                        await Clients.Group(s.ToString()).NotifyInputDeviceVoltagesReply(data);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyCpuConnectionInfo(CpuConnectionInfo data)
        {
            try
            {
                if (data.CpuDatabaseInformation?.EntityId == null || data.CpuDatabaseInformation?.EntityId == Guid.Empty)
                    await Clients.All.NotifyCpuConnectionInfo(data);
                else
                {
                    await Clients.Group(data.CpuDatabaseInformation.EntityId.ToString()).NotifyCpuConnectionInfo(data);
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyBackgroundJobInfo(BackgroundJobInfo data)
        {
            try
            {
                if (data.EntityId == Guid.Empty)
                    await Clients.All.NotifyBackgroundJobInfo(data);
                else
                    await Clients.Group(data.EntityId.ToString()).NotifyBackgroundJobInfo(data);

                //await Clients.All.NotifyBackgroundJobInfo(data);
                //if (data.JobId == Guid.Empty)
                //{
                //    await Clients.All.NotifyBackgroundJobInfo(data);
                //}
                //else
                //{
                //    await Clients.All.NotifyBackgroundJobInfo(data);
                //    await Clients.Group(data.JobId.ToString()).NotifyBackgroundJobInfo(data);
                //}
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }


        public async Task NotifyOperationStatusInfo(SignalREnvelope<OperationStatusInfo> data)
        {
            try
            {
#if DEBUG
                await Clients.All.NotifyOperationStatusInfo(data.Payload);
#endif
                if ( !data.SignalRGroupUids.Any())
                    await Clients.All.NotifyOperationStatusInfo(data.Payload);
                else
                {
                    foreach( var uid in data.SignalRGroupUids )
                        await Clients.Group(uid.ToString()).NotifyOperationStatusInfo(data.Payload);
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyPanelActivityLogMessage(PanelActivityLogMessage data)
        {
            try
            {
                if (data.DeviceEntityId != Guid.Empty)
                    await Clients.Group(data.DeviceEntityId.ToString()).NotifyPanelActivityLogMessage(data);
                else
                    await Clients.All.NotifyPanelActivityLogMessage(data);

                if (data.IsAlarmEvent)
                    await NotifyPanelActivityAlarmLogMessage(data);
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyPanelCredentialActivityLogMessage(PanelCredentialActivityLogMessage data)
        {
            try
            {
                if (data.DeviceEntityId != Guid.Empty)
                    await Clients.Group(data.DeviceEntityId.ToString()).NotifyPanelCredentialActivityLogMessage(data);
                else
                    await Clients.All.NotifyPanelCredentialActivityLogMessage(data);

                if (data.IsAlarmEvent)
                    await NotifyPanelCredentialActivityAlarmLogMessage(data);
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }
        public async Task NotifyPanelActivityAlarmLogMessage(PanelActivityLogMessage data)
        {
            try
            {
                if (data.IsAlarmEvent)
                {
                    if (data.DeviceEntityId != Guid.Empty)
                        await Clients.Group(data.DeviceEntityId.ToString()).NotifyPanelActivityAlarmLogMessage(data);
                    else
                        await Clients.All.NotifyPanelActivityAlarmLogMessage(data);
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyPanelCredentialActivityAlarmLogMessage(PanelCredentialActivityLogMessage data)
        {
            try
            {
                if (data.IsAlarmEvent)
                {
                    if (data.DeviceEntityId != Guid.Empty)
                        await Clients.Group(data.DeviceEntityId.ToString())
                            .NotifyPanelCredentialActivityAlarmLogMessage(data);
                    else
                        await Clients.All.NotifyPanelCredentialActivityAlarmLogMessage(data);
                }
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

        public async Task NotifyAcknowledgedAlarmBasicData(AcknowledgedAlarmBasicData data)
        {
            try
            {
                if (data.DeviceEntityId != Guid.Empty)
                    await Clients.Group(data.DeviceEntityId.ToString()).NotifyAcknowledgedAlarmBasicData(data);
                else
                    await Clients.All.NotifyAcknowledgedAlarmBasicData(data);
            }
            catch (Exception e)
            {
                LogManager.GetLogger<GalaxySMSSignalRHub>().ErrorFormat($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType?.FullName} exception: {e.ToString()}");
            }
        }

    }
}
