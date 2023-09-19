////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EventArgs\ConnectionDebugPacketEventArgs.cs
//
// summary:	Implements the connection debug packet event arguments class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Enums;
using GCS.PanelProtocols.Enums;
using GCS.PanelProtocols.Series5xx;
using GCS.PanelProtocols.Series6xx;

namespace GCS.PanelCommunication.PanelCommunicationServerAsync
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for connection debug packet events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ConnectionDebugPacketEventArgs : EventArgs
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the date time created. </summary>
        ///
        /// <value> The date time created. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset DateTimeCreated { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the which direction. </summary>
        ///
        /// <value> The which direction. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataDirection WhichDirection { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the packet. </summary>
        ///
        /// <value> The packet. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuDataPacket Packet { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the packet 5xx. </summary>
        ///
        /// <value> The packet 5xx. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Panel5xxDataPacket Packet5xx { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the CPU. </summary>
        ///
        /// <value> Information describing the CPU. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuConnectionInfo CpuInfo { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets a value indicating whether this ConnectionDebugPacketEventArgs is 5xx connection.
        /// </summary>
        ///
        /// <value> True if this ConnectionDebugPacketEventArgs is 5xx connection, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Is5xxConnection
        {
            get
            {
                if (Packet5xx == null)
                    return false;
                return true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="packet">       [in,out] The packet. </param>
        /// <param name="direction">    The direction. </param>
        /// <param name="cpu">          The CPU. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ConnectionDebugPacketEventArgs(ref IDataPacket6xx packet, DataDirection direction, CpuConnectionInfo cpu)
        {
            DateTimeCreated = DateTimeOffset.Now;
            Packet = new CpuDataPacket();
            Packet.Soh = (uint)packet.Soh;
            Packet.Length = packet.Length;
            Packet.Distribute = (byte)packet.Distribute;
            Packet.ClusterNumber = packet.ClusterId;
            Packet.PanelNumber = packet.PanelId;
            Packet.Cpu = (byte)packet.Cpu;
            Packet.Board = packet.BoardNumber;
            Packet.SectionEncoded = packet.SectionEncoded;
            Packet.SequenceBytes = packet.Sequence;
            Packet.WhenBytes = packet.When;
            Packet.Data = packet.Data;
            Packet.WhichDirection = direction;
            Packet.ConnectionGuid = cpu.EntityGuid;
            WhichDirection = direction;
            CpuInfo = cpu;
            Packet.TrimData();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="packet">       [in,out] The packet. </param>
        /// <param name="direction">    The direction. </param>
        /// <param name="cpu">          The CPU. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ConnectionDebugPacketEventArgs(ref DataPacket5xx packet, DataDirection direction, CpuConnectionInfo cpu)
        {
            DateTimeCreated = DateTimeOffset.Now;
            Packet5xx = new Panel5xxDataPacket();
            Packet5xx.Length = packet.Length;
            Packet5xx.ClusterId = cpu.GalaxyCpuInformation.ClusterNumber;
            Packet5xx.FromPanelId = packet.Route.FromController;
            Packet5xx.FromPortBoard = packet.Route.FromPortBoard;
            Packet5xx.ToPanelId = packet.Route.ToController;
            Packet5xx.ToPortBoard = packet.Route.ToPortBoard;
            Packet5xx.Data = packet.Data;
            WhichDirection = direction;
            CpuInfo = cpu;
            Packet5xx.TrimData();
        }
    }
}
