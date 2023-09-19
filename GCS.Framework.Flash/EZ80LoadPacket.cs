using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Flash
{
    public class EZ80LoadPacket
    {
        public EZ80LoadPacket(UInt32 address)
        {
            Address = address;
            Data = new byte[Constants.EZ80_FLASH_PACKET_SIZE];
            IsFilled = false;
            IsZero = true;
        }

        public Boolean IsFilled { get; private set; }
        public Boolean IsZero { get; private set; }
        public UInt32 Address { get; private set; }
        public UInt32 DataSize { get { return Constants.EZ80_FLASH_PACKET_SIZE; } }
        public UInt32 MaxAddress
        {
            get { return Address + Constants.EZ80_FLASH_PACKET_SIZE - 1; }
        }
        public Byte[] Data { get; internal set; }

        public Int32 DataLength
        {
            get
            {
                if( Data == null)
                    return 0;
                return Data.Length;
            }
        }
        public Boolean AddData(S28Record sRec)
        {
            if (sRec == null)
                return false;

            //var data = new byte[Constants.EZ80_FLASH_PACKET_SIZE];
            var data = sRec.GetData(sRec.GetDataLength());
            return AddData(sRec.GetAddress(), data);
        }

        Boolean AddData(UInt32 address, byte[] data)
        {
            var length = data.Length;
            // 1ST STEP IS TO VERIFY THAT THE DATA BELONGS WITH THIS PACKET
            if ((address + length) > (Address + Data.Length))
                return false;               // CONFIRM THE LENGTH WILL NOT OVERFLOW PAST THE END OF THIS OJBECTS BUFFER

            if (address < Address)      // MAKE SURE THIS ADDRESS IS NOT < THAN THE OJBECTS BASE ADDRESS
                return false;

            UInt32 offset = address - Address;

            if (offset + length > Data.Length) // CONFIRM THE DATA WILL FIT IN THIS OBJECT
                return false;

            Buffer.BlockCopy(data, 0, Data, (int)offset, length);

            if (offset + length == Data.Length)
               IsFilled = true;

            if (IsZero == true)
            {
                for (int x = 0; x < length; x++)
                {
                    if (Data[offset + x] != 0)
                    {
                        IsZero = false;
                        break;
                    }
                }
            }

            return true;
        }

        public byte[] GetData()
        {
            return Data;
        }
    }
}
