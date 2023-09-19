using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Framework.Flash;
using GCS.PanelProtocols.Enums;
using GCS.PanelProtocols.Series6xx.Messages;
using DateTimeOffset = System.DateTimeOffset;

namespace GCS.PanelCommunicationServerAsync.Entities
{
    public class FlashLoadingData
    {
        public FlashLoadingData(CpuVersionInfo currentCpuVersion, GalaxyLoadFlashCommandActionCode command)
        {
            CurrentCpuVersion = currentCpuVersion;
            PacketsPerLoadMessage = 1;
            Command = command;
            LastPacketLoadedIndex = 0;
            LastAddressLoaded = 0;
            PacketCounter = 0;
            PacketsSentCounter = 0;
            StartedDateTime = DateTimeOffset.Now;
            SendPacketIntervalMilliseconds = 100;
        }

        public DateTimeOffset StartedDateTime { get; set; }
        public int LastPacketLoadedIndex { get; internal set; }
        public int PacketsPerLoadMessage { get; set; }
        public int SendPacketIntervalMilliseconds {get;set;}
        public UInt16 PacketCounter { get; internal set; }
        public UInt16 PacketsSentCounter { get; internal set; }
        //        public int SkipCount { get; set; }
        public UInt32 LastAddressLoaded { get; internal set; }
        public CpuVersionInfo CurrentCpuVersion { get; internal set; }
        public GalaxyLoadFlashCommandActionCode Command { get; set; }
        public PacketDataCodeTo6xx LastCommandSent { get; set; }
        public GalaxyFlashImageHelper FlashImageHelper { get; set; }
        public UInt16 TotalPacketCount { get { return (UInt16)FlashImageHelper.LoadPackets.Count; } }
        public bool Paused { get; set; }
        public EZ80LoadPacket[] GetNextPackets()
        {
            var packets = new List<EZ80LoadPacket>();

            if (LastPacketLoadedIndex >= FlashImageHelper.LoadPackets.Count)
                return packets.ToArray();

            LastAddressLoaded = FlashImageHelper.LoadPackets[LastPacketLoadedIndex].Address;
            for (var x = 0; x < PacketsPerLoadMessage; x++)
            {
                if (LastPacketLoadedIndex < FlashImageHelper.LoadPackets.Count)
                {
                    var pkt = FlashImageHelper.LoadPackets[LastPacketLoadedIndex++];

                    if ((pkt.Address - LastAddressLoaded) > Constants.EZ80_FLASH_PACKET_SIZE)
                    {
                        LastPacketLoadedIndex--;
                        break;
                    }
                    LastAddressLoaded = pkt.Address;

                    packets.Add(pkt);

                    PacketCounter++;
                }
            }
            PacketsSentCounter++;
            return packets.ToArray();
        }

        public UInt32 CRC
        {
            get
            {
                if (CurrentCpuVersion.Major >= 2)
                    return FlashImageHelper.CRC_119;
                return FlashImageHelper.CRC_118;
            }
        }

        public UInt32 CRCExtended { get { return FlashImageHelper.CRC_Ex; } }
    }
}
