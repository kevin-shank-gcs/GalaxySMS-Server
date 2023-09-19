////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\CpuDataPacket.cs
//
// summary:	Implements the CPU data packet class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A CPU data packet. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class CpuDataPacket : DataPacketBase
    {
        /// <summary>   The data. </summary>
        private Byte[] _data;
        /// <summary>   The when. </summary>
        private Byte[] _when = new Byte[4];
        /// <summary>   The sequence. </summary>
        private Byte[] _sequence = new Byte[4];
        //private Byte[] _when = new Byte[3];
        //private Byte[] _sequence = new Byte[3];
        /// <summary>   The soh. </summary>
        private uint _soh;
        /// <summary>   The length. </summary>
        private ushort _length;
        /// <summary>   The distribute. </summary>
        private ushort _distribute;
        /// <summary>   The cluster number. </summary>
        private int _clusterNumber;
        /// <summary>   The panel number. </summary>
        private int _panelNumber;
        /// <summary>   The CPU. </summary>
        private ushort _cpu;
        /// <summary>   The board. </summary>
        private ushort _board;
        /// <summary>   The section encoded. </summary>
        private ushort _sectionEncoded;
        /// <summary>   Unique identifier for the connection. </summary>
        private Guid _connectionGuid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this CpuDataPacket. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The CpuDataPacket to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Init(CpuDataPacket p)
        {
            if (p == null)
            {
                WhenBytes = new byte[4];
                SequenceBytes = new byte[4];
                Data = new byte[16];
            }
            else
            {
                Soh = p.Soh;
                Length = p.Length;
                Distribute = p.Distribute;
                ClusterNumber = p.ClusterNumber;
                PanelNumber = p.PanelNumber;
                Cpu = p.Cpu;
                Board = p.Board;
                SectionEncoded = p.SectionEncoded;
                WhenBytes = p.WhenBytes;
                SequenceBytes = p.SequenceBytes;
                Data = p.Data;
                ConnectionGuid = p.ConnectionGuid;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuDataPacket()
            : base()
        {
            Init(null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="p">    The CpuDataPacket to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CpuDataPacket(CpuDataPacket p)
            : base(p)
        {
            Init(p);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the soh. </summary>
        ///
        /// <value> The soh. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt32 Soh
        {
            get { return _soh; }
            set
            {
                if (_soh != value)
                {
                    _soh = value;
                    OnPropertyChanged(() => Soh);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the length. </summary>
        ///
        /// <value> The length. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt16 Length
        {
            get { return _length; }
            set
            {
                if (_length != value)
                {
                    _length = value;
                    OnPropertyChanged(() => Length);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the distribute. </summary>
        ///
        /// <value> The distribute. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt16 Distribute
        {
            get { return _distribute; }
            set
            {
                if (_distribute != value)
                {
                    _distribute = value;
                    OnPropertyChanged(() => Distribute);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster number. </summary>
        ///
        /// <value> The cluster number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int ClusterNumber
        {
            get { return _clusterNumber; }
            set
            {
                if (_clusterNumber != value)
                {
                    _clusterNumber = value;
                    OnPropertyChanged(() => ClusterNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the panel number. </summary>
        ///
        /// <value> The panel number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 PanelNumber
        {
            get { return _panelNumber; }
            set
            {
                if (_panelNumber != value)
                {
                    _panelNumber = value;
                    OnPropertyChanged(() => PanelNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU. </summary>
        ///
        /// <value> The CPU. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt16 Cpu
        {
            get { return _cpu; }
            set
            {
                if (_cpu != value)
                {
                    _cpu = value;
                    OnPropertyChanged(() => Cpu);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the board. </summary>
        ///
        /// <value> The board. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt16 Board
        {
            get { return _board; }
            set
            {
                if (_board != value)
                {
                    _board = value;
                    OnPropertyChanged(() => Board);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the section encoded. </summary>
        ///
        /// <value> The section encoded. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UInt16 SectionEncoded
        {
            get { return _sectionEncoded; }
            set
            {
                if (_sectionEncoded != value)
                {
                    _sectionEncoded = value;
                    OnPropertyChanged(() => SectionEncoded);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the section. </summary>
        ///
        /// <value> The section. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UInt16 Section
        {
            get
            {
                return (UInt16)(SectionEncoded & 3);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the node. </summary>
        ///
        /// <value> The node. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UInt16 Node
        {
            get
            {
                return (UInt16)((SectionEncoded & 0xf8) >> 3);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the when bytes. </summary>
        ///
        /// <value> The when bytes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Byte[] WhenBytes
        {
            get { return _when; }
            set
            {
                //if (value.Length != 3)
                //    throw new ArgumentOutOfRangeException("WhenBytes", "Value must be a 3 byte array");
                //Array.Copy(value, _when, 3);
                _when = value;
                OnPropertyChanged(() => WhenBytes);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sequence bytes. </summary>
        ///
        /// <value> The sequence bytes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Byte[] SequenceBytes
        {
            get { return _sequence; }
            set
            {
                //if (value.Length != 3)
                //    throw new ArgumentOutOfRangeException("SequenceBytes", "Value must be a 3 byte array");
                //Array.Copy(value, _sequence, 3);
                _sequence = value;
                OnPropertyChanged(() => SequenceBytes);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the when. </summary>
        ///
        /// <value> The when. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Int32 When { get { return BitConverter.ToInt32(WhenBytes, 0); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the sequence. </summary>
        ///
        /// <value> The sequence. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Int32 Sequence { get { return BitConverter.ToInt32(SequenceBytes, 0); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the type of the data. </summary>
        ///
        /// <value> The type of the data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PacketDataType DataType { get { return (PacketDataType)Data[0]; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data. </summary>
        ///
        /// <value> The data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Byte[] Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged(() => Data);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Trim data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void TrimData()
        {
            if (Data != null)
                Array.Resize(ref _data, Length - 16);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the connection. </summary>
        ///
        /// <value> Unique identifier of the connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid ConnectionGuid
        {
            get { return _connectionGuid; }
            set
            {
                if (_connectionGuid != value)
                {
                    _connectionGuid = value;
                    OnPropertyChanged(() => ConnectionGuid);
                }
            }
        }
    }
}
