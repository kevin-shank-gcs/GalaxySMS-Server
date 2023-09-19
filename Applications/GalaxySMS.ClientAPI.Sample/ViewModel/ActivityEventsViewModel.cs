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

namespace GalaxySMS.ClientAPI.Sample.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ActivityEventsViewModel : ViewModelBase
    {
        #region Private fields
        private ObservableCollection<PanelCredentialActivityLogMessage> _credentialEvents = new ObservableCollection<PanelCredentialActivityLogMessage>();
        private ObservableCollection<PanelActivityLogMessage> _activityEvents = new ObservableCollection<PanelActivityLogMessage>();
        private RelayCommand _clearAllActivityEventsCommand;
        #endregion

        #region Public Properties
        public Globals Globals { get { return Globals.Instance; } }

        //public ObservableCollection<PanelCredentialActivityLogMessage> CredentialEvents
        //{
        //    get { return _credentialEvents; }
        //    set
        //    {
        //        if (_credentialEvents != value)
        //        {
        //            _credentialEvents = value;
        //            OnPropertyChanged(() => CredentialEvents, false);
        //        }
        //    }
        //}

        public ObservableCollection<PanelActivityLogMessage> ActivityEvents
        {
            get { return _activityEvents; }
            set
            {
                if (_activityEvents != value)
                {
                    _activityEvents = value;
                    OnPropertyChanged(() => ActivityEvents, false);
                }
            }
        }

        private int _maxEventCount = 50;

        public int MaxEventCount
        {
            get { return _maxEventCount; }
            set
            {
                if (_maxEventCount != value)
                {
                    _maxEventCount = value;
                    OnPropertyChanged(() => MaxEventCount, true);
                }
            }
        }

        #endregion

        #region Commands
        public RelayCommand ClearAllActivityEventsCommand
        {
            get
            {
                return _clearAllActivityEventsCommand
                    ?? (_clearAllActivityEventsCommand = new RelayCommand(
                    () =>
                    {
                        try
                        {
                            ActivityEvents.Clear();
                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name} exception", e);
                        }
                    }));
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public ActivityEventsViewModel()
        {
            Globals.Messenger.Register<NotificationMessage<UserEntity>>(this, OnUserEntityChanged);
            Globals.Messenger.Register<NotificationMessage<Site>>(this, OnSiteChanged);
            Globals.Messenger.Register<NotificationMessage<PanelCredentialActivityLogMessage>>(this, OnPanelCredentialActivityLogMessage);
            Globals.Messenger.Register<NotificationMessage<PanelActivityLogMessage>>(this, OnPanelActivityLogMessage);
        }

        private void OnPanelActivityLogMessage(NotificationMessage<PanelActivityLogMessage> obj)
        {
            ActivityEvents.Add(obj.Content);
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}=>({obj?.Content.DateTime},{obj?.Content.EventDescription},{obj?.Content.DeviceDescription})");
            if( ActivityEvents.Count > MaxEventCount)
                ActivityEvents.RemoveAt(0);
        }

        private void OnPanelCredentialActivityLogMessage(NotificationMessage<PanelCredentialActivityLogMessage> obj)
        {
            switch (obj.Content.PanelActivityType)
            {
                case PanelActivityEventCode.CredentialNotInPanelMemory:
                case PanelActivityEventCode.CredentialNotInPanelMemoryReverse:
                    if( string.IsNullOrEmpty(obj.Content.PersonDescription))
                    {
                        var hexCode = $"{System.BitConverter.ToString(obj.Content.CredentialBytes)}";
                        hexCode = hexCode.Replace("-", string.Empty);
                        var shortenedHexCode = "0x";
                        int x =0;
                        foreach(var c in hexCode)
                        {
                            x++;
                            if( c == '0')
                                continue;
                            shortenedHexCode = $"0x00{hexCode.Substring(x)}";
                            break;
                        }
                        obj.Content.PersonDescription = $"{obj.Content.BitCount} Bits, d:{obj.Content.CredentialNumber}, {shortenedHexCode}";
                    }
                    break;

            }
            ActivityEvents.Add(obj.Content);
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}=>({obj?.Content.DateTime},{obj?.Content.EventDescription},{obj?.Content.DeviceDescription},{obj?.Content.PersonDescription})");
            if( ActivityEvents.Count > MaxEventCount)
                ActivityEvents.RemoveAt(0);
        }

        private void OnUserEntityChanged(NotificationMessage<UserEntity> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.EntityName})");
        }

        private void OnSiteChanged(NotificationMessage<Site> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.SiteName})");
        }

    }
}