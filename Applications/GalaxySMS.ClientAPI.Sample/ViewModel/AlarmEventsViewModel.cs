using GalaSoft.MvvmLight.CommandWpf;
using GalaxySMS.Client.SDK.Managers;
using System;
using System.Diagnostics;
using GCS.Core.Common.Logger;
using System.Linq;
using GCS.Core.Common.UI.Core;
using GalaSoft.MvvmLight.Messaging;
using GalaxySMS.Client.Entities;
using System.Reflection;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;
using GalaxySMS.Common.Enums;
using System.Threading.Tasks;
using GCS.Core.Common.UI.Interfaces;
using GalaxySMS.ClientAPI.Sample.UserControls;
using Telerik.Windows.Controls;

namespace GalaxySMS.ClientAPI.Sample.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class AlarmEventsViewModel : GCS.Core.Common.UI.Core.ViewModelBase
    {
        #region Private fields
        private ObservableCollection<PanelCredentialActivityLogMessage> _credentialEvents = new ObservableCollection<PanelCredentialActivityLogMessage>();
        private ObservableCollection<PanelActivityLogMessage> _alarmEvents = new ObservableCollection<PanelActivityLogMessage>();
        private RelayCommand<PanelActivityLogMessage> _ackCommand;
        private PanelActivityLogMessage _ackThisEvent;
        private RelayCommand _clearAllAlarmEventsCommand;
        private RelayCommand _refreshUnackedAlarmEventsCommand;
        #endregion

        #region Public Properties
        public Globals Globals { get { return Globals.Instance; } }

        public ObservableCollection<PanelActivityLogMessage> AlarmEvents
        {
            get { return _alarmEvents; }
            set
            {
                if (_alarmEvents != value)
                {
                    _alarmEvents = value;
                    OnPropertyChanged(() => AlarmEvents, false);
                }
            }
        }

        #endregion

        #region Commands
        public RelayCommand<PanelActivityLogMessage> AcknowledgeCommand
        {
            get { return _ackCommand; }
            set
            {
                if (_ackCommand != value)
                {
                    _ackCommand = value;
                    OnPropertyChanged(() => AcknowledgeCommand, false);
                }
            }
        }

        public RelayCommand ClearAllAlarmEventsCommand
        {
            get
            {
                return _clearAllAlarmEventsCommand
                    ?? (_clearAllAlarmEventsCommand = new RelayCommand(
                    () =>
                    {
                        try
                        {
                            AlarmEvents.Clear();
                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name} exception", e);
                        }
                    }));
            }
        }


        public RelayCommand RefreshUnackedAlarmEventsCommand
        {
            get
            {
                return _refreshUnackedAlarmEventsCommand
                    ?? (_refreshUnackedAlarmEventsCommand = new RelayCommand(
                    async () =>
                    {
                        try
                        {
                            Globals.BusyContent = Properties.Resources.UserEntityChanged_BusyContent;
                            Globals.IsBusy = true;
                            var mgr = Globals.GetManager<AlarmEventAcknowledgeManager>();

                            var parameters = new GetParametersWithPhoto() { CurrentEntityId = Globals.Instance.CurrentUserEntity.EntityId };

                            var data = await mgr.GetUnacknowledgedAlarmsAsync(parameters);

                            if (data != null && mgr.HasErrors == false)
                            {
                                this.AlarmEvents = data.ToObservableCollection();
                            }
                            else if (mgr.HasErrors)
                            {
                                AddCustomErrors(mgr.Errors, true);
                            }
                            Globals.IsBusy = false;

                        }
                        catch (Exception ex)
                        {

                        }
                    }));
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public AlarmEventsViewModel()
        {
            Globals.Messenger.Register<NotificationMessage<UserEntity>>(this, OnUserEntityChanged);
            Globals.Messenger.Register<NotificationMessage<Site>>(this, OnSiteChanged);
            Globals.Messenger.Register<NotificationMessage<PanelCredentialActivityLogMessage>>(this, true.ToString(), OnPanelCredentialActivityLogMessage);
            Globals.Messenger.Register<NotificationMessage<PanelActivityLogMessage>>(this, true.ToString(), OnPanelActivityLogMessage);
            Globals.Messenger.Register<NotificationMessage<AcknowledgedAlarmBasicData>>(this, OnAcknowledgedAlarmBasicData);
            AcknowledgeCommand = new RelayCommand<PanelActivityLogMessage>(OnAcknowledgeCommand);
        }

        private void OnAcknowledgeCommand(PanelActivityLogMessage obj)
        {
            _ackThisEvent = obj;
            try
            {
                RadWindow.Prompt(Properties.Resources.AcknowledgeAlarm_ResponseTitle, this.OnAcknowledgeClosed);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }

        }

        private async void OnAcknowledgeClosed(object sender, WindowClosedEventArgs e)
        {
            if (_ackThisEvent == null || e.DialogResult == false)
                return;

            Globals.BusyContent = Properties.Resources.AcknowledgeAlarm_BusyContent;
            Globals.IsBusy = true;
            var mgr = Globals.GetManager<AlarmEventAcknowledgeManager>();

            var parameters = new SaveParameters<AcknowledgeAlarmEventParameters>()
            {
                Data = new AcknowledgeAlarmEventParameters
                {
                    ActivityEventUid = _ackThisEvent.ActivityEventUid,
                    ActivityEventCategory = _ackThisEvent.Category,
                    Response = e.PromptResult,
                },
                //SessionId = Globals.UserSessionToken.SessionId,
            };


            var ackResult = await mgr.AcknowledgeAlarmEventAsync(parameters);

            if (ackResult != null)
            {

            }

            if (mgr.HasErrors)
            {
                AddCustomErrors(mgr.Errors, true);
            }
            Globals.IsBusy = false;
            _ackThisEvent = null;
        }

        private void OnPanelActivityLogMessage(NotificationMessage<PanelActivityLogMessage> obj)
        {
            if (obj?.Content != null)
                if (obj.Content.Acknowledgements == null)
                    obj.Content.Acknowledgements = new ObservableCollection<AcknowledgedAlarmBasicData>();

            AlarmEvents.Add(obj.Content);
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}=>({obj?.Content.DateTime},{obj?.Content.EventDescription},{obj?.Content.DeviceDescription})");
        }

        private void OnPanelCredentialActivityLogMessage(NotificationMessage<PanelCredentialActivityLogMessage> obj)
        {
            AlarmEvents.Add(obj.Content);
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}=>({obj?.Content.DateTime},{obj?.Content.EventDescription},{obj?.Content.DeviceDescription},{obj?.Content.PersonDescription})");
        }

        private void OnAcknowledgedAlarmBasicData(NotificationMessage<AcknowledgedAlarmBasicData> obj)
        {
            if (obj?.Content != null)
            {
                var eventData = AlarmEvents.FirstOrDefault(o => o.ActivityEventUid == obj.Content.ActivityEventUid);
                if (eventData != null)
                {
                    if (eventData.Acknowledgements == null)
                        eventData.Acknowledgements = new ObservableCollection<AcknowledgedAlarmBasicData>();
                    eventData.Acknowledgements.Add(obj.Content);
                }
            }
        }

        private async void OnUserEntityChanged(NotificationMessage<UserEntity> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.EntityName})");
            try
            {
                Globals.BusyContent = Properties.Resources.UserEntityChanged_BusyContent;
                Globals.IsBusy = true;
                var mgr = Globals.GetManager<AlarmEventAcknowledgeManager>();

                var parameters = new GetParametersWithPhoto() { CurrentEntityId = Globals.Instance.CurrentUserEntity.EntityId };

                var data = await mgr.GetUnacknowledgedAlarmsAsync(parameters);

                if (data != null && mgr.HasErrors == false)
                {
                    this.AlarmEvents = data.ToObservableCollection();
                }
                else if (mgr.HasErrors)
                {
                    AddCustomErrors(mgr.Errors, true);
                }
                Globals.IsBusy = false;

            }
            catch (Exception ex)
            {

            }

        }

        private void OnSiteChanged(NotificationMessage<Site> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.SiteName})");
        }

    }
}