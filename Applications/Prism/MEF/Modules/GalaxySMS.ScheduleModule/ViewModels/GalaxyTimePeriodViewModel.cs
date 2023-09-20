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
    [Export(typeof(GalaxyTimePeriodViewModel))]
    public class GalaxyTimePeriodViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditGalaxyTimePeriodViewModel _CurrentItemViewModel;
        private Entities.GalaxyTimePeriod _deleteThisGalaxyTimePeriod = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public GalaxyTimePeriodViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = CommonResources.Resources.ScheduleView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.GalaxyTimePeriod>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.GalaxyTimePeriod>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.GalaxyTimePeriod>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.GalaxyTimePeriod>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsEditControlVisible = true;
            IsDeleteControlVisible = true;

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

        private void OperationCanceled(OperationCanceledEventArgs<Entities.GalaxyTimePeriod> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.GalaxyTimePeriod> obj)
        {
            if (!obj.IsNew)
            {
                var entity = GalaxyTimePeriods.FirstOrDefault(item => item.GalaxyTimePeriodUid == obj.Entity.GalaxyTimePeriodUid);
                entity?.Initialize(obj.Entity);
            }
            else
                GalaxyTimePeriods.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.GalaxyTimePeriod obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId) &&
                obj != null &&
                obj?.EntityId == _clientServices.CurrentEntityId &&
                obj.GalaxyTimePeriodUid != GalaxyTimePeriodIds.TimePeriod_Always &&
                obj.GalaxyTimePeriodUid != GalaxyTimePeriodIds.TimePeriod_Never;
        }

        private async void OnEditCommand(Entities.GalaxyTimePeriod obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                IsBusy = true;

                var currentItem = await GetItemFromServer(new Entities.GetParametersWithPhoto()
                {
                    UniqueId = obj.GalaxyTimePeriodUid,
                    IncludeMemberCollections = true
                });
                CurrentItemViewModel = new EditGalaxyTimePeriodViewModel(_eventAggregator, _clientServices, currentItem, Guid.Empty);
                IsBusy = false;
            }
        }

        private async Task<Entities.GalaxyTimePeriod> GetItemFromServer(Entities.GetParametersWithPhoto p)
        {
            if (p == null)
                return null;
            base.ClearCustomErrors();
            var mgr = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.GalaxyTimePeriodManager>();
            var ts = await mgr.GetGalaxyTimePeriodAsync(p);

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
            var o = new Entities.GalaxyTimePeriod();

            var definedNumbers = GalaxyTimePeriods.Select(i => i.PanelTimePeriodNumber);
            var availableNumbers = Enumerable.Range(GalaxyTimePeriodLimits.LowestDefinableNumber, GalaxyTimePeriodLimits.HighestDefinableNumber).Except(definedNumbers);
            if (availableNumbers.Count() == 0)
                return;

            o.PanelTimePeriodNumber = availableNumbers.FirstOrDefault();
            o.Display = string.Format(CommonResources.Resources.GalaxyTimePeriod_DefaultName, o.PanelTimePeriodNumber);
            CurrentItemViewModel = new EditGalaxyTimePeriodViewModel(_eventAggregator, _clientServices, o, Guid.Empty);
        }

        private bool OnDeleteCommandCanExecute(Entities.GalaxyTimePeriod obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanDeleteId) &&
                    obj != null &&
                    obj?.EntityId == _clientServices.CurrentEntityId &&
                    obj.GalaxyTimePeriodUid != GalaxyTimePeriodIds.TimePeriod_Always &&
                    obj.GalaxyTimePeriodUid != GalaxyTimePeriodIds.TimePeriod_Never;
        }


        private void OnDeleteCommand(Entities.GalaxyTimePeriod entity)
        {
            ClearCustomErrors();
            _deleteThisGalaxyTimePeriod = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainGalaxyTimePeriods_AreYouSureDeleteGalaxyTimePeriod,
                _deleteThisGalaxyTimePeriod.Display);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainGalaxyTimePeriods_YesDeleteGalaxyTimePeriod, _deleteThisGalaxyTimePeriod.Display);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainGalaxyTimePeriods_NoDeleteGalaxyTimePeriod, _deleteThisGalaxyTimePeriod.Display);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                int numberDeleted = 0;
                var manager = _clientServices.GetManager<SDK.Managers.GalaxyTimePeriodManager>();
                var parameters = new Entities.DeleteParameters<Entities.GalaxyTimePeriod>() { Data = _deleteThisGalaxyTimePeriod, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = manager.DeleteGalaxyTimePeriod(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await manager.DeleteGalaxyTimePeriodAsync(parameters);
                }
                if (manager.HasErrors == false)
                    GalaxyTimePeriods.Remove(_deleteThisGalaxyTimePeriod);
                else
                {
                    base.AddCustomErrors(manager.Errors, true);
                }
            }
            else
                _deleteThisGalaxyTimePeriod = null;
        }
        #endregion

        #region Public Properties

        public EditGalaxyTimePeriodViewModel CurrentItemViewModel
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

        private ObservableCollection<GalaxySMS.Client.Entities.GalaxyTimePeriod> _GalaxyTimePeriods;

        public ObservableCollection<GalaxySMS.Client.Entities.GalaxyTimePeriod> GalaxyTimePeriods
        {
            get { return _GalaxyTimePeriods; }
            set
            {
                if (_GalaxyTimePeriods != value)
                {
                    _GalaxyTimePeriods = value;
                    OnPropertyChanged(() => GalaxyTimePeriods, false);
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
                if (GalaxyTimePeriods == null)
                    return 0;
                return GalaxyTimePeriods.Count;
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
        public DelegateCommand<Entities.GalaxyTimePeriod> EditCommand { get; private set; }
        public DelegateCommand<Entities.GalaxyTimePeriod> DeleteCommand { get; private set; }
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
            GalaxyTimePeriods = new ObservableCollection<Client.Entities.GalaxyTimePeriod>();
            var parameters = new Entities.GetParametersWithPhoto();
            parameters.IncludeMemberCollections = false;
            //parameters.IncludePhoto = true;
            var mgr = _clientServices.GetManager<SDK.Managers.GalaxyTimePeriodManager>();
            var tps = await mgr.GetGalaxyTimePeriodsForEntityAsync(parameters);
            foreach (var s in tps.Items)
                GalaxyTimePeriods.Add(s);

            if (mgr.HasErrors)
            {
                base.AddCustomErrors(mgr.Errors, true);
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