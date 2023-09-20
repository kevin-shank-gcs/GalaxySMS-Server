using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public class CpuDataPacket : DataPacketBase
	{
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
	    public CpuDataPacket() : base()
	    {
            Init(null);
        }

	    public CpuDataPacket(CpuDataPacket p) : base(p)
	    {
            Init(p);
	    }

		private Byte[] data;
        private Byte[] when = new Byte[4];
        private Byte[] sequence = new Byte[4];
        //private Byte[] when = new Byte[3];
        //private Byte[] sequence = new Byte[3];

		[DataMember]
		public UInt32 Soh { get; set; }
		[DataMember]
		public UInt16 Length { get; set; }
		[DataMember]
		public UInt16 Distribute { get; set; }
		[DataMember]
		public Int32 ClusterNumber { get; set; }
		[DataMember]
		public Int32 PanelNumber { get; set; }
		[DataMember]
		public UInt16 Cpu { get; set; }
		[DataMember]
		public Int32 Board { get; set; }
		[DataMember]
		public UInt16 SectionEncoded { get; set; }

        public UInt16 Section
		{
			get
			{
				return (UInt16)(SectionEncoded & 3);
			}
		}

        public UInt16 Node
		{
			get
			{
				return (UInt16)((Section & 0xf8) >> 3);
			}
		}
		[DataMember]
		public Byte[] WhenBytes
		{
			get { return when; }
			set
			{
			    if (value.Length > 3)
                    Array.Copy(value, when, 3);
                else if(value.Length == 3)
    				Array.Copy(value, when, 3);
			}
		}
		[DataMember]
		public Byte[] SequenceBytes
		{
			get { return sequence; }
			set
			{
                //if (value.Length != 3)
                //    throw new ArgumentOutOfRangeException("SequenceBytes", "Value must be a 3 byte array");
                //Array.Copy(value, sequence, 3);
                if (value.Length > 3)
                    Array.Copy(value, sequence, 3);
                else if (value.Length == 3)
                    Array.Copy(value, sequence, 3);
            }
		}

        public Int32 When { get { return BitConverter.ToInt32(WhenBytes, 0); } }

        public Int32 Sequence { get { return BitConverter.ToInt32(SequenceBytes, 0); } }

        public PacketDataType DataType { get { return (PacketDataType)Data[0]; } }

		[DataMember]
		public Byte[] Data
		{
			get
			{
				return data;
			}
			set{ 
				data = value;
				}
		}

		public void TrimData()
		{
			if (Data != null)
				Array.Resize(ref data, Length - 16 );
		}

	    [DataMember]
	    public Guid ConnectionGuid { get; set; }
	}
}
