using GCS.PanelDataProcessors.Interfaces;
using System;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;
using GalaxySMS.Common.Enums;
using System.Threading.Tasks;
#if NETFRAMEWORK
using GCS.PanelProtocols.Series6xx;
using GalaxySMS.Data;
#elif NETCOREAPP

#endif


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
        public SystemType SystemType { get; private set; }

        public PanelPacketDataRecorder()
        {
            SystemType = SystemType.Galaxy;
        }

        public void HandleMessage(object data)
        {
#if NETFRAMEWORK
            try
            {
                if (data is IDataPacket6xx)
                {
                    var logData = new PanelDataPacketLog();
                    var pkt = (IDataPacket6xx)data;
                    logData.Distribute = (short)pkt.Distribute;
                    if(data is PanelMessageBase)
                        logData.ClusterGroupId = ((PanelMessageBase)data).ClusterGroupId;
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
#elif NETCOREAPP

#endif
        }

        public async Task HandleMessageAsync(object data)
        {
#if NETFRAMEWORK
            try
            {
                if (data is IDataPacket6xx)
                {
                    var logData = new PanelDataPacketLog();
                    var pkt = (IDataPacket6xx)data;
                    logData.Distribute = (short)pkt.Distribute;
                    logData.ClusterId = pkt.ClusterId;
                    if (data is PanelMessageBase)
                        logData.ClusterGroupId = ((PanelMessageBase)data).ClusterGroupId;
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
#elif NETCOREAPP

#endif
        }
    }
}
