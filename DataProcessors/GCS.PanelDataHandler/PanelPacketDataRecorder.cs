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
using GalaxySMS.Common.Enums;

namespace GCS.PanelOutputDataHandlers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A class for recording panel data packets. </summary>
    ///
    /// <remarks>   This class records data packets that have been sent to or received from a panel. This is used primarily for
    ///             troubleshooting purposes.  </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PanelPacketDataRecorder : IPanelOutputDataMessageHandler
    {
        public void HandleMessage(object data)
        {
            try
            {
                if (data is IDataPacket6xx)
                {
                    var logData = new PanelDataPacketLog();
                    var pkt = (IDataPacket6xx)data;
                    logData.Distribute = (short)pkt.Distribute;
                    logData.ClusterId = pkt.ClusterId;
                    logData.PanelId = pkt.PanelId;
                    logData.CpuId = (short)pkt.Cpu;
                    logData.BoardNumber = pkt.BoardNumber;
                    logData.SectionNumber = (short)pkt.SectionEncoded;
                    logData.Sequence = ByteConverters.ThreeBytesToInt(pkt.Sequence[2], pkt.Sequence[1], pkt.Sequence[0]);
                    logData.SecondsFromWeekStart = ByteConverters.ThreeBytesToInt(pkt.When[2], pkt.When[1], pkt.When[0]);

                    //logData.RawData = ByteArrayUtilities.GetBytesFromArray(ref pkt.Data, pkt.Length - 16, 0);
                    logData.RawData = pkt.GetRawData();

                    if (logData.RawData == null)
                        this.Log().DebugFormat("RawData is null");
                    else
                    {    //                        logData.Length = (short)pkt.Data.Length;
                        logData.Length = (short)pkt.Length;
                    }
                    if (pkt.Direction == DataDirection.ReceivedFromPanel)
                        logData.Direction = true;
                    else
                        logData.Direction = false;
                    var mgr = new PanelDataPacketLogInsertRepository();
                    mgr.Insert(logData);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }
    }
}
