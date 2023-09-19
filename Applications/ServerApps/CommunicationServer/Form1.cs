using CommunicationServerWinForm.Interfaces;
using GCS.Core.Common.Logger;
using GCS.PanelCommunication.PanelCommunicationServerAsync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaxySMS.Common.Enums;


namespace CommunicationServerWinForm
{
    public partial class Form1 : Form
    {
        #region Private member variables
        private ConnectionManagerAsync _asyncManager;
        private bool _PanelServerEnabled = false;
        private bool _EncryptPanelCommunications = false;
        private string _EncryptionPhrase = "choose a phrase now";
        private Dictionary<String, IConnectionDebugWindow> _debugWindows = new Dictionary<String, IConnectionDebugWindow>();
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Public Properties
        public bool PanelServerEnabled
        {
            get { return _PanelServerEnabled; }
            set
            {
                if (_PanelServerEnabled != value)
                {
                    _PanelServerEnabled = value;
                }
            }
        }

        public bool EncryptPanelCommunications
        {
            get { return _EncryptPanelCommunications; }
            set
            {
                if (_EncryptPanelCommunications != value)
                {
                    _EncryptPanelCommunications = value;
                }
            }
        }

        public string EncryptionPhrase
        {
            get { return _EncryptionPhrase; }
            set
            {
                if (_EncryptionPhrase != value)
                {
                    _EncryptionPhrase = value;
                }
            }
        }

        public Collection<CpuConnectionInfo> CpuConnections
        {
            get
            {
                if (_asyncManager == null)
                    return null;

                System.Diagnostics.Trace.WriteLine(string.Format("PanelServerViewModel CpuConnections count:{0}", _asyncManager.CpuConnections.Count));

                return _asyncManager.CpuConnections;
            }
        }
        #endregion
        
        #region Public Methods
        public void StartPanelServer()
        {
            try
            {
                if (_asyncManager != null)
                    _asyncManager.Stop();
                if (PanelServerEnabled == true)
                {
                    if (EncryptPanelCommunications == false)
                        _asyncManager = new ConnectionManagerAsync(500, 1050, 3001, ConnectionManagerAsync.IPVersionType.IPv4, string.Empty);
                    else
                        _asyncManager = new ConnectionManagerAsync(500, 1050, 3001, ConnectionManagerAsync.IPVersionType.IPv4, "choose a phrase now");
                    _asyncManager.ConnectionStateChangedEvent += asyncManager_ConnectionStateChangedEvent;
                    _asyncManager.DebugPacketEvent += _asyncManager_DebugPacketEvent;
                    _asyncManager.PanelInformationEvent += _asyncManager_PanelInformationEvent;
                    _asyncManager.Start();

                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                //GCS.Framework.Logging.AppLogExceptionManager.Log(ex);
                //				MessageBox.Show(ex.Message);
            }
        }


        public void StopPanelServer()
        {
            try
            {
                if (_asyncManager != null)
                    _asyncManager.Stop();
                _asyncManager = null;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                //				MessageBox.Show(ex.Message);
            }
        }

        //public void Debug(ref CpuConnectionInfo conn)
        //{
        //	if (_asyncManager != null)
        //	{
        //		bool bFound = false;
        //		foreach (ConnectionDebugWindow debugWindow in debugWindows.Values)
        //		{
        //			if (debugWindow.InstanceGuid == conn.InstanceGuid)
        //			{
        //				bFound = true;
        //				debugWindow.Activate();
        //				break;
        //			}
        //		}

        //		if (bFound == false)
        //		{
        //			ConnectionDebugWindow win = new ConnectionDebugWindow(this, ref conn);
        //			win.Closed += win_Closed;
        //			win.Show();
        //			debugWindows.Add(conn.InstanceGuid, win);
        //		}
        //		_asyncManager.EnableDebugging(conn.InstanceGuid, true);
        //	}
        //}
        #endregion

        #region Private Methods
        void win_Closed(object sender, EventArgs e)
        {
            foreach (IConnectionDebugWindow debugWindow in _debugWindows.Values)
            {
                if (debugWindow.Equals(sender))
                {
                    if (_asyncManager != null)
                    {
                        _asyncManager.EnableDebugging(debugWindow.InstanceGuid, false);
                    }

                    _debugWindows.Remove(debugWindow.InstanceGuid);
                    break;
                }
            }
        }
        void asyncManager_ConnectionStateChangedEvent(object sender, ConnectionStateChangeEventArgs e)
        {
            bool bRemoved = false;

            this.Log().DebugFormat("ViewModel received asyncManager_ConnectionStateChangedEvent {0}", e.ConnectionInfo.GalaxyCpuInformation.InstanceGuid);
            //GCS.Framework.Logging.LogWriter.Trace(string.Format("ViewModel received asyncManager_ConnectionStateChangedEvent {0}", e.ConnectionInfo.GalaxyCpuInformation.InstanceGuid));
            foreach (CpuConnectionInfo conn in CpuConnections)
            {
                if (conn.GalaxyCpuInformation.InstanceGuid == e.ConnectionInfo.GalaxyCpuInformation.InstanceGuid)
                {
                    bRemoved = CpuConnections.Remove(conn);
                    this.Log().DebugFormat("ViewModel received asyncManager_ConnectionStateChangedEvent found connection, bRemoved:{0}, CpuConnections.Count:{1}",
                        bRemoved, CpuConnections.Count);
                    //GCS.Framework.Logging.LogWriter.Trace(string.Format("ViewModel received asyncManager_ConnectionStateChangedEvent found connection, bRemoved:{0}, CpuConnections.Count:{1}",
                    //    bRemoved, CpuConnections.Count));
                    break;
                }
            }
            if (e.ConnectionInfo.IsConnected == true)
            {
                CpuConnections.Add(new CpuConnectionInfo(e.ConnectionInfo));
                this.Log().DebugFormat("ViewModel received asyncManager_ConnectionStateChangedEvent added connection, CpuConnections.Count:{0}",
                    CpuConnections.Count);
                //GCS.Framework.Logging.LogWriter.Trace(string.Format("ViewModel received asyncManager_ConnectionStateChangedEvent added connection, CpuConnections.Count:{0}",
                //    CpuConnections.Count));
            }
        }
        void _asyncManager_PanelInformationEvent(object sender, PanelInformationEventArgs e)
        {
            //GCS.Framework.Logging.LogWriter.Trace(string.Format("ViewModel received _asyncManager_PanelInformationEvent {0}", e.GalaxyCpuInformation.InstanceGuid));

            //bool bRemoved = false;

            //CpuConnectionInfo theConn = null;
            //foreach (CpuConnectionInfo conn in CpuConnections)
            //{
            //	if (conn.GalaxyCpuInformation.InstanceGuid == e.GalaxyCpuInformation.InstanceGuid)
            //	{
            //		bRemoved = CpuConnections.Remove(conn);
            //		GCS.Framework.Logging.LogWriter.Trace(string.Format("ViewModel received asyncManager_ConnectionStateChangedEvent found connection, bRemoved:{0}, CpuConnections.Count:{1}",
            //			bRemoved, CpuConnections.Count));
            //		theConn = conn;
            //		break;
            //	}
            //}

            //theConn.GalaxyCpuInformation = e.GalaxyCpuInformation;
            //CpuConnections.Add(theConn);
            //RaisePropertyChanged("CpuConnections");

            if (e.GalaxyCpuInformation.CpuModel == CpuModel.Cpu5xx &&
                e.GalaxyCpuInformation.PanelNumber != 0)
                return;

            foreach (CpuConnectionInfo conn in CpuConnections)
            {
                if (conn.GalaxyCpuInformation.InstanceGuid == e.GalaxyCpuInformation.InstanceGuid)
                {
                    conn.GalaxyCpuInformation.InqueryReply = e.GalaxyCpuInformation.InqueryReply;
                    conn.GalaxyCpuInformation.LoggingStatusReply = e.GalaxyCpuInformation.LoggingStatusReply;
                    conn.GalaxyCpuInformation.CardCountReply = e.GalaxyCpuInformation.CardCountReply;
                    break;
                }
            }
        }

        void _asyncManager_DebugPacketEvent(object sender, ConnectionDebugPacketEventArgs e)
        {
            IConnectionDebugWindow debugWindow;
            if (_debugWindows.TryGetValue(e.CpuInfo.GalaxyCpuInformation.InstanceGuid, out debugWindow) == true)
            {
                debugWindow.HandlePacket(e);
            }
        }
        void SendRawData(RawDataToSend data)
        {
            if (_asyncManager != null)
            {
                _asyncManager.SendRawData(data);
            }
        }
        #endregion

        private void chkCommunicationEnabled_CheckedChanged(object sender, EventArgs e)
        {
            PanelServerEnabled = chkCommunicationEnabled.Checked;
            if (PanelServerEnabled)
                StartPanelServer();
            else
                StopPanelServer();
        }

    }
}
