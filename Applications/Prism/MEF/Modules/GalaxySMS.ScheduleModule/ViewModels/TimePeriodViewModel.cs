using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;
using SDK = GalaxySMS.Client.SDK;
using Entities = GalaxySMS.Client.Entities;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Core;
using GCS.Core.Common;
using System.Linq;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GalaxySMS.Prism.Infrastructure.Events;
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using LocalResources = GalaxySMS.Schedule.Properties;


namespace GalaxySMS.Schedule.ViewModels
{
    [Export(typeof(TimePeriodViewModel))]
    public class TimePeriodViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditTimePeriodViewModel _CurrentItemViewModel;
        private Entities.TimePeriod _deleteThisTimePeriod = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public TimePeriodViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = CommonResources.Resources.ScheduleView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.TimePeriod>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.TimePeriod>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.TimePeriod>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.TimePeriod>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsEditControlVisible = true;
            IsDeleteControlVisible = true;

            TimePeriodTypes = new ObservableCollection<TimePeriodType>();
            TimePeriodTypes.Add(TimePeriodType.GalaxyOneMinuteInterval);
            TimePeriodTypes.Add(TimePeriodType.GalaxyFifteenMinuteInterval);
            TimePeriodTypes.Add(TimePeriodType.AssaAbloyDsr);
            SelectedTimePeriodType = TimePeriodType.GalaxyOneMinuteInterval;

            GridPageSizes = new ObservableCollection<KeyValuePair<int, string>>();

            for (int key = 0; key < 50; key += 10)
            {
                if (key == 0)
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, CommonResources.Resources.PageSize_AllText));
                }
                else
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, key.ToString()));
                }
            }

            foreach (var s in GridPageSizes)
            {
                if (s.Key == 20)
                {
                    GridPageSize = s;
                    break;
                }
            }
        }


        #endregion

        #region Private Methods

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanViewId);
        }

        private async void OnRefreshCommand(object obj)
        {
            await RefreshFromServer();
        }

        private async void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            await RefreshFromServer();
        }

        private async void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        {
            await RefreshFromServer();
        }

        private void OperationCanceled(OperationCanceledEventArgs<Entities.TimePeriod> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.TimePeriod> obj)
        {
            if (!obj.IsNew)
            {
                var entity = TimePeriods.FirstOrDefault(item => item.TimePeriodUid == obj.Entity.TimePeriodUid);
                entity?.Initialize(obj.Entity);
            }
            else
                TimePeriods.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.TimePeriod obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId) &&
                obj != null &&
                obj?.EntityId == _clientServices.CurrentEntityId &&
                obj.TimePeriodUid != GalaxyTimePeriodIds.TimePeriod_Always &&
                obj.TimePeriodUid != GalaxyTimePeriodIds.TimePeriod_Never;
        }

        private async void OnEditCommand(Entities.TimePeriod obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                IsBusy = true;

                var currentItem = await GetItemFromServer(new Entities.GetParametersWithPhoto()
                {
                    UniqueId = obj.TimePeriodUid,
                    IncludeMemberCollections = true
                });
                CurrentItemViewModel = new EditTimePeriodViewModel(_eventAggregator, _clientServices, currentItem, Guid.Empty);
                IsBusy = false;
            }
        }

        private async Task<Entities.TimePeriod> GetItemFromServer(Entities.GetParametersWithPhoto p)
        {
            if (p == null)
                return null;
            base.ClearCustomErrors();
            var mgr = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.TimePeriodManager>();
            var ts = await mgr.GetTimePeriodAsync(p);

            if (mgr.HasErrors)
            {
                base.AddCustomErrors(mgr.Errors, true);
                return null;
            }
            return ts;
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId);
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.TimePeriod();
            CurrentItemViewModel = new EditTimePeriodViewModel(_eventAggregator, _clientServices, o, Guid.Empty);
        }

        private bool OnDeleteCommandCanExecute(Entities.TimePeriod obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanDeleteId) &&
                    obj != null &&
                    obj?.EntityId == _clientServices.CurrentEntityId &&
                    obj.TimePeriodUid != GalaxyTimePeriodIds.TimePeriod_Always &&
                    obj.TimePeriodUid != GalaxyTimePeriodIds.TimePeriod_Never;
        }


        private void OnDeleteCommand(Entities.TimePeriod entity)
        {
            ClearCustomErrors();
            _deleteThisTimePeriod = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainTimePeriods_AreYouSureDeleteTimePeriod,
                _deleteThisTimePeriod.Name);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainTimePeriods_YesDeleteTimePeriod, _deleteThisTimePeriod.Name);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainTimePeriods_NoDeleteTimePeriod, _deleteThisTimePeriod.Name);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                int numberDeleted = 0;
                var manager = _clientServices.GetManager<SDK.Managers.TimePeriodManager>();
                var parameters = new Entities.DeleteParameters<Entities.TimePeriod>() { Data = _deleteThisTimePeriod, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = manager.DeleteTimePeriod(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await manager.DeleteTimePeriodAsync(parameters);
                }
                if (manager.HasErrors == false)
                    TimePeriods.Remove(_deleteThisTimePeriod);
                else
                {
                    base.AddCustomErrors(manager.Errors, true);
                }
            }
            else
                _deleteThisTimePeriod = null;
        }
        #endregion

        #region Public Properties

        public EditTimePeriodViewModel CurrentItemViewModel
        {
            get { return _CurrentItemViewModel; }
            set
            {
                if (_CurrentItemViewModel != value)
                {
                    _CurrentItemViewModel = value;
                    OnPropertyChanged(() => CurrentItemViewModel, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.TimePeriod> _timePeriods;

        public ObservableCollection<GalaxySMS.Client.Entities.TimePeriod> TimePeriods
        {
            get { return _timePeriods; }
            set
            {
                if (_timePeriods != value)
                {
                    _timePeriods = value;
                    OnPropertyChanged(() => TimePeriods, false);
                }
            }
        }

        private ObservableCollection<TimePeriodType> _timePeriodTypes;

        public ObservableCollection<TimePeriodType> TimePeriodTypes
        {
            get { return _timePeriodTypes; }
            set
            {
                if (_timePeriodTypes != value)
                {
                    _timePeriodTypes = value;
                    OnPropertyChanged(() => TimePeriodTypes, false);
                }
            }
        }


        private TimePeriodType _selectedTimePeriodType;

        public TimePeriodType SelectedTimePeriodType
        {
            get { return _selectedTimePeriodType; }
            set
            {
                if (_selectedTimePeriodType != value)
                {
                    _selectedTimePeriodType = value;
                    OnPropertyChanged(() => SelectedTimePeriodType, false);
                    RefreshFromServer();
                }
            }
        }
        private KeyValuePair<int, string> _gridPageSize;

        public KeyValuePair<int, string> GridPageSize
        {
            get { return _gridPageSize; }
            set
            {
                _gridPageSize = value;
                OnPropertyChanged(() => GridPageSize, false);
            }
        }

        private ObservableCollection<KeyValuePair<int, string>> _gridPageSizes;

        public ObservableCollection<KeyValuePair<int, string>> GridPageSizes
        {
            get { return _gridPageSizes; }
            set
            {
                if (_gridPageSizes != value)
                {
                    _gridPageSizes = value;
                    OnPropertyChanged(() => GridPageSizes, false);
                }
            }
        }

        public int TotalRecordCount
        {
            get
            {
                if (TimePeriods == null)
                    return 0;
                return TimePeriods.Count;
            }
            set
            {
                OnPropertyChanged(() => TotalRecordCount, false);
            }
        }
        #endregion

        #region Public Events
        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.TimePeriod> EditCommand { get; private set; }
        public DelegateCommand<Entities.TimePeriod> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }

        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            Task.Run(async () =>
            {
                await RefreshFromServer();
                
            });
        }

        private async Task RefreshFromServer()
        {
            IsBusy = true;
            base.ClearCustomErrors();
            TimePeriods = new ObservableCollection<Client.Entities.TimePeriod>();
            var parameters = new Entities.GetParametersWithPhoto();
            //parameters.UniqueId = _clientServices.CurrentSite.SiteUid;
            parameters.IncludeMemberCollections = false;
            parameters.GetInt16 = (Int16)SelectedTimePeriodType;
            //parameters.IncludePhoto = true;
            var TimePeriodManager = _clientServices.GetManager<SDK.Managers.TimePeriodManager>();
            var timePeriods = TimePeriodManager.GetTimePeriodsForEntity(parameters, false);
            foreach (var s in timePeriods)
                TimePeriods.Add(s);

            if (TimePeriodManager.HasErrors)
            {
                base.AddCustomErrors(TimePeriodManager.Errors, true);
            }
            IsBusy = false;
        }

        #endregion

        #region IPartImportsSatisfiedNotification Implementation

        public void OnImportsSatisfied()
        {
        }

        #endregion

        #region INavigationAware Implementation

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}