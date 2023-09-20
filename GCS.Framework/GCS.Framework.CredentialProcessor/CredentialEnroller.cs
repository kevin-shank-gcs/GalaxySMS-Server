////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CredentialEnroller.cs
//
// summary:	Implements the credential enroller class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using GalaxySMS.Common.Enums;
using GCS.Framework.SerialPort;
using Subsembly.SmartCard;

namespace GCS.Framework.CredentialProcessor
{
    /// <summary>	Credential enroller. </summary>
    public class CredentialEnroller
    {
        /// <summary>	The USB 635 enroller data format regular expression. </summary>
        private const string USB635EnrollerDataFormatRegEx = "^\\[\\d{1,2},\\d{1,3},[0-9a-fA-F]{64}\\]$";

        /// <summary>	Name of the serial port. </summary>
        private string _serialPortName;

        /// <summary>	List of names of the serial ports. </summary>
        private string[] _serialPortNames;

        /// <summary>	Manager for serial port. </summary>
        private SerialPortManager _serialPortMgr;

        /// <summary>	Event queue for all listeners interested in CredentialDataReceived events. </summary>
        public event EventHandler<CredentialDataEventArgs> CredentialDataReceived;

        /// <summary>	Information describing the received. </summary>
        private string _receivedData;

        /// <summary>	Default constructor. </summary>
        public CredentialEnroller()
        {
            _serialPortNames = SerialPortManager.GetSerialPorts();
            _serialPortMgr = new SerialPortManager();
            _serialPortMgr.Properties.PortName = string.Empty;
            _serialPortMgr.Properties.BaudRate = BaudRate.BAUD_9600;
            _serialPortMgr.Properties.DataBits = DataBits.DATABITS_8;
            _serialPortMgr.Properties.Handshake = System.IO.Ports.Handshake.None;
            _serialPortMgr.Properties.Parity = System.IO.Ports.Parity.None;
            _serialPortMgr.Properties.StopBits = System.IO.Ports.StopBits.One;
            _serialPortMgr.NewSerialDataReceived +=
                new EventHandler<SerialDataEventArgs>(_serialPortMgr_NewSerialDataReceived);


        }

        /// <summary>	Finaliser. </summary>
        ~CredentialEnroller()
        {
            if (_serialPortMgr.IsOpen)
                _serialPortMgr.Close();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Gets a list of names of the serial ports. </summary>
        ///
        /// <value>	A list of names of the serial ports. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string[] SerialPortNames
        {
            get { return _serialPortNames; }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by _serialPortMgr for new serial data received events.
        /// </summary>
        ///
        /// <param name="sender">	Source of the event. </param>
        /// <param name="e">		 	Serial data event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void _serialPortMgr_NewSerialDataReceived(object sender, SerialDataEventArgs e)
        {
            string s = System.Text.Encoding.Default.GetString(e.Data);
            System.Diagnostics.Trace.Write(s);
            _receivedData += s;
            string sEndingChars = "\n\r";
            if (_receivedData.EndsWith(sEndingChars))
            {
                _receivedData = _receivedData.TrimEnd(sEndingChars.ToArray());
                System.Text.RegularExpressions.Regex regEx =
                    new System.Text.RegularExpressions.Regex(CredentialEnroller.USB635EnrollerDataFormatRegEx);
                if (regEx.IsMatch(_receivedData, 0) == true)
                {
                    string[] parts = _receivedData.Replace("[", "").Replace("]", "").Split(',');
                    if (parts.Length == 3)
                    {
                        var rawData = new RawCredentialData();
                        rawData.EnrollmentDeviceDescription = _serialPortName;
                        rawData.RawData = _receivedData;
                        rawData.ReaderDataFormat = (CredentialReaderDataFormat)short.Parse(parts[0]);
                        rawData.BitCount = short.Parse(parts[1]);
                        rawData.DataString = parts[2];
                        rawData.RegularExpression = RawCredentialData.CardDataHexStringRegEx;
                        rawData.UseDataType = RawCredentialData.DataType.HexString;
                        var format = CredentialAnalyzer.AnalyzeRawData(rawData);
                        var handler = CredentialDataReceived;
                        if (handler != null)
                            handler(this, new CredentialDataEventArgs(rawData));
                    }
                }
                _receivedData = string.Empty;
            }
        }

        public static RawCredentialData TestString(string s)
        {

            System.Text.RegularExpressions.Regex regEx =
                new System.Text.RegularExpressions.Regex(CredentialEnroller.USB635EnrollerDataFormatRegEx);
            if (regEx.IsMatch(s, 0) == true)
            {
                string[] parts = s.Replace("[", "").Replace("]", "").Split(',');
                if (parts.Length == 3)
                {
                    var rawData = new RawCredentialData();

                    rawData.ReaderDataFormat = (CredentialReaderDataFormat)short.Parse(parts[0]);
                    rawData.BitCount = short.Parse(parts[1]);
                    rawData.DataString = parts[2];
                    rawData.RegularExpression = RawCredentialData.CardDataHexStringRegEx;
                    rawData.UseDataType = RawCredentialData.DataType.HexString;
                    var format = CredentialAnalyzer.AnalyzeRawData(rawData);
                    return rawData;
                }
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>	Opens the specified serial port. </summary>
        ///
        /// <param name="port">	The port name. </param>
        ///
        /// <returns>	true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Open(string port)
        {
            _serialPortName = port;
            bool bFound = false;
            foreach (string sPort in _serialPortNames)
            {
                if (sPort.ToUpper() == port.ToUpper())
                {
                    bFound = true;
                    break;
                }
            }

            if (bFound == false)
                return false;

            _serialPortMgr.Properties.PortName = port;
            _serialPortMgr.Open();
            return true;
        }

        /// <summary>	Closes this object. </summary>
        public void Close()
        {
            if (_serialPortMgr.IsOpen)
                _serialPortMgr.Close();
        }

        public String SerialPort
        {
            get { return _serialPortName; }
        }

        public bool IsPortOpen
        {
            get { return _serialPortMgr.IsOpen; }
        }
    }
}
