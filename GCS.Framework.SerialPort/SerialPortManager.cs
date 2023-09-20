using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.SerialPort
{
	/// <summary>
	/// EventArgs used to send bytes recieved on serial port
	/// </summary>
	public class SerialDataEventArgs : EventArgs
	{
		public SerialDataEventArgs(byte[] dataInByteArray)
		{
			Data = dataInByteArray;
		}

		/// <summary>
		/// Byte array containing data from serial port
		/// </summary>
		public byte[] Data;
	}

	public class SerialPortManager
	{
		System.IO.Ports.SerialPort _serialPort;
		Properties _properties;
		public event EventHandler<SerialDataEventArgs> NewSerialDataReceived; 

		public static string[] GetSerialPorts()
		{
			return System.IO.Ports.SerialPort.GetPortNames();
		}

		public SerialPortManager()
		{
			_properties = new Properties();
			CreateSerialPort();
		}

		public SerialPortManager(Properties properties)
		{
			if (properties == null)
				_properties = new Properties();
			else
				_properties = properties;

			CreateSerialPort();
		}

		~SerialPortManager()
		{
			if( _serialPort != null && _serialPort.IsOpen)
				_serialPort.Close();
		}

		
		private void CreateSerialPort()
		{
			_serialPort = new System.IO.Ports.SerialPort();
			_serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(_serialPort_DataReceived);
			_serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(_serialPort_ErrorReceived);
			_serialPort.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(_serialPort_PinChanged);
			_serialPort.Disposed += new EventHandler(_serialPort_Disposed);
		}

		void _serialPort_Disposed(object sender, EventArgs e)
		{
		}

		void _serialPort_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
		{

		}

		void _serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			int dataLength = _serialPort.BytesToRead;
			byte[] data = new byte[dataLength];
			int nbrDataRead = _serialPort.Read(data, 0, dataLength);
			if (nbrDataRead == 0)
				return;

			// Send data to whom ever interested
			if (NewSerialDataReceived != null)
				NewSerialDataReceived(this, new SerialDataEventArgs(data));
		}

		void _serialPort_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
		{
			
		}

		public Properties Properties
		{
			get { return _properties; }
		}

		public void Open()
		{
			// Closing serial port if it is open
			if (_serialPort != null && _serialPort.IsOpen)
				_serialPort.Close();

			if (_serialPort == null)
				CreateSerialPort();

			if( _serialPort != null )
			{
				_serialPort.Parity = this.Properties.Parity;
				_serialPort.Handshake = this.Properties.Handshake;
				_serialPort.BaudRate = (int)this.Properties.BaudRate;
				_serialPort.StopBits = this.Properties.StopBits;
				_serialPort.DataBits = (int)this.Properties.DataBits;
				_serialPort.PortName = this.Properties.PortName;
			    _serialPort.ReadTimeout = 200;
				_serialPort.Open(); 
			}
		}

		public void Close()
		{
			if (_serialPort != null && _serialPort.IsOpen)
				_serialPort.Close();
		}

		public bool IsOpen
		{
			get
			{
				if (_serialPort == null)
					return false;
				return _serialPort.IsOpen; 
			}
		}

		public void Write(string write)
		{
			if( _serialPort != null  && _serialPort.IsOpen)
				_serialPort.Write(write);
		}

	}
}
