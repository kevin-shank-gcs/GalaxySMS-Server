using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace GCS.Framework.SerialPort
{
    public enum BaudRate : int
    {
        BAUD_300 = 300,
        BAUD_600 = 600,
        BAUD_1200 = 1200,
        BAUD_2400 = 2400,
        BAUD_4800 = 4800,
        BAUD_7200 = 7200,
        BAUD_9600 = 9600,
        BAUD_14400 = 14400,
        BAUD_19200 = 19200,
        BAUD_38400 = 38400,
        BAUD_56000 = 56000,
        BAUD_57600 = 57600,
        BAUD_115200 = 115200,
        BAUD_128000 = 128000
    }

    public enum DataBits : int
    {
        DATABITS_7 = 7,
        DATABITS_8 = 8,
    }

    public class Properties
    {
	
        System.IO.Ports.Handshake _handshake;
        System.IO.Ports.Parity _parity;
        System.IO.Ports.StopBits _stopBits;
        DataBits _dataBits;
        BaudRate _baudRate;
        string _portName;

        public Properties()
        {
            _handshake = Handshake.None;
            _parity = Parity.None;
            _stopBits = StopBits.One;
            _baudRate = BaudRate.BAUD_57600;
            _dataBits = DataBits.DATABITS_8;
            _portName = string.Empty;
        }

        public System.IO.Ports.Handshake Handshake
        {
            get { return _handshake; }
            set { _handshake = value; }
        }

        public System.IO.Ports.Parity Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        public System.IO.Ports.StopBits StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        public BaudRate BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        public DataBits DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }
    }

}
