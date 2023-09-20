using GCS.PanelDataProcessors.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Data;
using GalaxySMS.Business.Entities;
using GalaxySMS.MessageQueue.Integration;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;
using GCS.Framework.MessageQueue.Messaging;
using GCS.PanelProtocols.Enums;
using GCS.PanelProtocols.Series6xx;
using GCS.PanelProtocols.Series6xx.Messages;

namespace GCS.PanelOutputDataHandlers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A class for handling panel data messages. </summary>
    ///
    /// <remarks>   This class sends messages that have been received from a panel and sends them to downstream processing queues.  </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PanelOutputDataMessageHandler : IPanelOutputDataMessageHandler
    {
        public PanelOutputDataMessageHandler()
        {
//            this.Log().Info($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} creating MessageQueues");
            this.Log().Info($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType.Name} creating MessageQueues");

            try
            {
                var queuePanelMessage = MessageQueueFactory.CreateOutbound(QueueNames.PanelMessage, MessagePattern.FireAndForget);
                var queueRecorder = MessageQueueFactory.CreateOutbound(QueueNames.PanelMessageRecorder, MessagePattern.FireAndForget);

                //var msg = new Message
                //{
                //    Body = "Creation message",
                //};
                //queuePanelMessage.Send(msg);
                //queueRecorder.Send(msg);

            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }

        public void HandleMessage(object data)
        {
            try
            {

                var msg = new Message
                {
                    Body = data,
                };

                var queuePanelMessage = MessageQueueFactory.CreateOutbound(QueueNames.PanelMessage, MessagePattern.FireAndForget);
                queuePanelMessage.Send(msg);

                var queueRecorder = MessageQueueFactory.CreateOutbound(QueueNames.PanelMessageRecorder, MessagePattern.FireAndForget);
                queueRecorder.Send(msg);


                //var mgr = new PanelDataPacketLogInsertRepository();
                //var logData = new PanelDataPacketLog();
                //if (msg is GalaxyDataWrapper)
                //{
                //    var dw = msg as GalaxyDataWrapper;
                //    Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {dw.ClusterGroupId}:{dw.ClusterNumber}:{dw.PanelNumber}:{dw.CpuNumber} PanelOutputDataMessageRecorder::HandleMessage processing {dw.Data.GetType()}");
                //    switch (dw.Direction)
                //    {
                //        case GalaxyDataWrapper.DataDirection.OutputToPanel:
                //            logData.Direction = false;  // Sent to panel
                //            break;
                //        case GalaxyDataWrapper.DataDirection.InputFromPanel:
                //            logData.Direction = true;  // Received from panel
                //            break;
                //    }
                //    if (dw.Data is PanelActivityLogMessageCredential)
                //    {
                //        var o = dw.Data as PanelActivityLogMessageCredential;
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {o.ClusterGroupId}:{o.ClusterNumber}:{o.PanelNumber}:{o.CpuId}  PanelOutputDataMessageRecorder::HandleMessage processing PanelActivityLogMessageCredential");
                //    }
                //    else if (dw.Data is ActivityLogMessageFromCpu)
                //    {
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {dw.ClusterGroupId}:{dw.ClusterNumber}:{dw.PanelNumber}:{dw.CpuNumber}  PanelOutputDataMessageRecorder::HandleMessage processing ActivityLogMessageFromCpu");
                //    }
                //    else if (dw.Data is PanelActivityLogMessage)
                //    {
                //        var o = dw.Data as PanelActivityLogMessage;
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {o.ClusterGroupId}:{o.ClusterNumber}:{o.PanelNumber}:{o.CpuId}  PanelOutputDataMessageRecorder::HandleMessage processing PanelActivityLogMessage");
                //    }
                //    else if (dw.Data is PanelInqueryReply)
                //    {
                //        var o = dw.Data as PanelInqueryReply;
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {o.ClusterGroupId}:{o.ClusterNumber}:{o.PanelNumber}:{o.CpuId}  PanelOutputDataMessageRecorder::HandleMessage processing PanelInqueryReply");
                //    }
                //    else if (dw.Data is CardCountReply)
                //    {
                //        var o = dw.Data as CardCountReply;
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {o.ClusterGroupId}:{o.ClusterNumber}:{o.PanelNumber}:{o.CpuId}  PanelOutputDataMessageRecorder::HandleMessage processing CardCountReply");
                //    }
                //    else if (dw.Data is LoggingStatusReply)
                //    {
                //        var o = dw.Data as LoggingStatusReply;
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {o.ClusterGroupId}:{o.ClusterNumber}:{o.PanelNumber}:{o.CpuId}  PanelOutputDataMessageRecorder::HandleMessage processing LoggingStatusReply");
                //    }
                //    else if (dw.Data is PingReply)
                //    {
                //        var o = dw.Data as PingReply;
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {o.ClusterGroupId}:{o.ClusterNumber}:{o.PanelNumber}:{o.CpuId}  PanelOutputDataMessageRecorder::HandleMessage processing PingReply");
                //    }
                //    else if (dw.Data is ExtendedCardDataActivityLogMessageFromCpu)
                //    {
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {dw.ClusterGroupId}:{dw.ClusterNumber}:{dw.PanelNumber}:{dw.CpuNumber}  PanelOutputDataMessageRecorder::HandleMessage processing ExtendedCardDataActivityLogMessageFromCpu");
                //    }
                //    else if (dw.Data is StandardCardDataActivityLogMessageFromCpu)
                //    {
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {dw.ClusterGroupId}:{dw.ClusterNumber}:{dw.PanelNumber}:{dw.CpuNumber}  PanelOutputDataMessageRecorder::HandleMessage processing StandardCardDataActivityLogMessageFromCpu");
                //    }
                //    else if (dw.Data is OtisElevatorActivityLogMessageFromCpu)
                //    {
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {dw.ClusterGroupId}:{dw.ClusterNumber}:{dw.PanelNumber}:{dw.CpuNumber}  PanelOutputDataMessageRecorder::HandleMessage processing OtisElevatorActivityLogMessageFromCpu");
                //    }
                //    else if (dw.Data is CardTourActivityLogMessageFromCpu)
                //    {
                //        //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {dw.ClusterGroupId}:{dw.ClusterNumber}:{dw.PanelNumber}:{dw.CpuNumber}  PanelOutputDataMessageRecorder::HandleMessage processing CardTourActivityLogMessageFromCpu");
                //    }
                //    else if (dw.Data is PanelReplyBase)
                //    {
                //        var panelMsg = (PanelReplyBase)dw.Data;
                //        logData.Distribute = panelMsg.Distribute;
                //        logData.ClusterId = panelMsg.ClusterNumber;
                //        logData.PanelId = panelMsg.PanelNumber;
                //        logData.CpuId = (short)panelMsg.CpuId;
                //        logData.BoardNumber = (short)panelMsg.BoardNumber;
                //        logData.SectionNumber = (short)panelMsg.SectionNodeCombinedNumber;
                //        logData.Sequence = panelMsg.Sequence;
                //        logData.SecondsFromWeekStart = panelMsg.SecondsFromBeginningOfWeek;
                //        logData.RawData = panelMsg.RawData;
                //        if (logData.RawData == null)
                //        {
                //            this.Log().DebugFormat("RawData is null");

                //            //Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {dw.ClusterGroupId}:{dw.ClusterNumber}:{dw.PanelNumber}:{dw.CpuNumber}  PanelOutputDataMessageRecorder::HandleMessage processing PanelReplyBase - RawData is null");
                //        }
                //        else
                //        {
                //            logData.Length = (short)panelMsg.RawData.Length;

                //            Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {dw.ClusterGroupId}:{dw.ClusterNumber}:{dw.PanelNumber}:{dw.CpuNumber} {logData.RawData[0]:X2}{logData.RawData[1]:X2}");
                //        }
                //        mgr.Insert(logData);
                //    }
                //    else if (dw.Data is IDataPacket6xx)
                //    {
                //        var pkt = (IDataPacket6xx)dw.Data;
                //        logData.Distribute = (short)pkt.Distribute;
                //        logData.ClusterId = pkt.ClusterId;
                //        logData.PanelId = pkt.PanelId;
                //        logData.CpuId = (short)pkt.Cpu;
                //        logData.BoardNumber = pkt.BoardNumber;
                //        logData.SectionNumber = (short)pkt.SectionEncoded;
                //        logData.Sequence = ByteConverters.ThreeBytesToInt(pkt.Sequence[2], pkt.Sequence[1], pkt.Sequence[0]);
                //        logData.SecondsFromWeekStart = ByteConverters.ThreeBytesToInt(pkt.When[2], pkt.When[1], pkt.When[0]);

                //        //logData.RawData = ByteArrayUtilities.GetBytesFromArray(ref pkt.Data, pkt.Length - 16, 0);
                //        logData.RawData = pkt.GetRawData();

                //        if (logData.RawData == null)
                //            this.Log().DebugFormat("RawData is null");
                //        else
                //        {    //                        logData.Length = (short)pkt.Data.Length;
                //            logData.Length = (short)pkt.Length;
                //            Trace.WriteLine($"{DateTimeOffset.Now} {dw.Direction} {dw.ClusterGroupId}:{dw.ClusterNumber}:{dw.PanelNumber}:{dw.CpuNumber} {logData.RawData[0]:X2}{logData.RawData[1]:X2}");
                //        }
                //        mgr.Insert(logData);

                //        if ((PacketDataCode6xx)pkt.Data[0] == PacketDataCode6xx.ActivityLogMessage)
                //        {
                //            var cpuLoggingRepo = new GalaxyCpuLoggingControlRepository();
                //            ushort index = BitConverter.ToUInt16(pkt.Data, 1);
                //            cpuLoggingRepo.SaveCpuLoggingControl(null, new SaveParameters<GalaxyCpuLoggingControl>()
                //            {
                //                Data = new GalaxyCpuLoggingControl()
                //                {
                //                    CpuUid = dw.GalaxyCpuUid,
                //                    LastLogIndex = (int)index
                //                }
                //            });
                //        }
                //    }
                //    else
                //    {
                //        int x = 1;
                //    }
                //}
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }
    }
}
