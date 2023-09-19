using GCS.CommunicationServerServiceContracts;
using GCS.DataContracts.ServiceControl;
using GCS.PanelCommunication.PanelCommunicationServerAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelCommunicationServerService
{
    public class PanelCommunicationService : ICommunicationServerAdministration
    {
        #region Private member variables
        private ConnectionManagerAsync _asyncManager;
        private bool _PanelServerEnabled = false;
        private CommunicationServerSettings _communicationServerSettings;
        #endregion
        public PanelCommunicationService()
        {
            _communicationServerSettings = new CommunicationServerSettings();
        }


        public DataContracts.ServiceControl.CommunicationServerSettings SetCommunicationServerSettings(DataContracts.ServiceControl.CommunicationServerSettings settings)
        {
            try
            {
                if (settings != null)
                {
                    _communicationServerSettings = settings;
                }
            }
            catch (Exception ex)
            {
                GCS.Framework.Logging.LogWriter.LogException(ex, "PanelCommunicationService.SetCommunicationSettings");
            }
            return _communicationServerSettings;
        }

        public DataContracts.ServiceControl.CommunicationServerSettings GetCommunicationServerSettings()
        {
            return _communicationServerSettings;
        }

        public DataContracts.PanelEntities.Enums.YesNo IsCommunicationServerStarted()
        {
            if (_asyncManager.IsRunning == true)
                return DataContracts.PanelEntities.Enums.YesNo.Yes;
            return DataContracts.PanelEntities.Enums.YesNo.No;
        }

        public DataContracts.PanelEntities.Enums.YesNo StartCommunicationServer()
        {
            try
            {
                if (_asyncManager != null)
                    _asyncManager.Stop();

                if (_communicationServerSettings.EncryptionEnabled == false)
                    _asyncManager = new ConnectionManagerAsync(500, 1050, _communicationServerSettings.ListenPort, ConnectionManagerAsync.IPVersionType.IPv4, string.Empty);
                else
                    _asyncManager = new ConnectionManagerAsync(500, 1050, _communicationServerSettings.ListenPort, ConnectionManagerAsync.IPVersionType.IPv4, _communicationServerSettings.EncryptionPhrase);
                _asyncManager.Start();
                return DataContracts.PanelEntities.Enums.YesNo.Yes;
            }
            catch (Exception ex)
            {
                GCS.Framework.Logging.LogWriter.LogException(ex, "PanelCommunicationService.StartCommunicationServer");
            }
            return DataContracts.PanelEntities.Enums.YesNo.No;
        }

        public DataContracts.PanelEntities.Enums.YesNo StopCommunicationServer()
        {
            try
            {
                if (_asyncManager != null)
                    _asyncManager.Stop();
            }
            catch (Exception ex)
            {
                GCS.Framework.Logging.LogWriter.LogException(ex, "PanelCommunicationService.StopCommunicationServer");
            }
            return DataContracts.PanelEntities.Enums.YesNo.No;
       }

        public DataContracts.PanelEntities.CpuConnectionInfo[] GetConnections()
        {
            if (_asyncManager != null)
                if (_asyncManager.CpuConnections != null)
                    return _asyncManager.CpuConnections.ToArray();

            return new List<DataContracts.PanelEntities.CpuConnectionInfo>().ToArray();
        }

    }
}
