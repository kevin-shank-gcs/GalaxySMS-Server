using GalaxySMS.Common.Constants;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Infrastructure.Events;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;
using SDK = GalaxySMS.Client.SDK;


namespace GalaxySMS.Schedule.ViewModels
{
    [Export(typeof(ScheduleViewModel))]
    public class ScheduleViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditScheduleViewModel _CurrentItemViewModel;
        private Entities.TimeSchedule _deleteThisTimeSchedule = null;
        private ObservableCollection<GalaxySMS.Client.Entities.TimeSchedule> _schedules;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public ScheduleViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = CommonResources.Resources.ScheduleView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.TimeSchedule>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.TimeSchedule>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.TimeSchedule>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.TimeSchedule>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsEditControlVisible = true;
            IsDeleteControlVisible = true;
        }


        #endregion

        #region Private Methods

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanViewId);
        }

        private void OnRefreshCommand(object obj)
        {
            RefreshFromServer();
        }

        private void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            RefreshFromServer();
        }

        private void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        {
            RefreshFromServer();
        }

        private void OperationCanceled(OperationCanceledEventArgs<Entities.TimeSchedule> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.TimeSchedule> obj)
        {
            Task.Run(async () => obj.Entity.gcsEntity = await _clientServices.GetEntity(obj.Entity.EntityId)).Wait();
            if (!obj.IsNew)
            {
                var entity = Schedules.FirstOrDefault(item => item.TimeScheduleUid == obj.Entity.TimeScheduleUid);
                entity?.Initialize(obj.Entity);
            }
            else
                Schedules.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.TimeSchedule obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId) &&
                obj != null &&
                obj?.EntityId == _clientServices.CurrentEntityId &&
                obj.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Always &&
                obj.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Never;
        }

        private async void OnEditCommand(Entities.TimeSchedule obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                IsBusy = true;

                var currentItem = await GetItemFromServer(new Entities.GetParametersWithPhoto()
                {
                    UniqueId = obj.TimeScheduleUid,
                    IncludeMemberCollections = true
                });
                CurrentItemViewModel = new EditScheduleViewModel(_eventAggregator, _clientServices, currentItem, Guid.Empty);
                IsBusy = false;
            }
        }

        private async Task<Entities.TimeSchedule> GetItemFromServer(Entities.GetParametersWithPhoto p)
        {
            if (p == null)
                return null;
            base.ClearCustomErrors();
            var mgr = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.TimeScheduleManager>();
            var ts = await mgr.GetTimeScheduleAsync(p);

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

        private async void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            IsBusy = true;

            var o = new Entities.TimeSchedule();
            CurrentItemViewModel = new EditScheduleViewModel(_eventAggregator, _clientServices, o, Guid.Empty);

            //var currentItem = await GetItemFromServer(new Entities.GetParametersWithPhoto()
            //{
            //    IncludeMemberCollections = true
            //});
            //CurrentItemViewModel = new EditScheduleViewModel(_eventAggregator, _clientServices, currentItem, Guid.Empty);
            IsBusy = false;
        }

        private bool OnDeleteCommandCanExecute(Entities.TimeSchedule obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanDeleteId) &&
                    obj != null &&
                    obj?.EntityId == _clientServices.CurrentEntityId &&
                    obj.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Always &&
                    obj.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Never;
        }


        private void OnDeleteCommand(Entities.TimeSchedule entity)
        {
            ClearCustomErrors();
            _deleteThisTimeSchedule = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainTimeSchedules_AreYouSureDeleteSchedule,
                _deleteThisTimeSchedule.Display);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainTimeSchedules_YesDeleteSchedule, _deleteThisTimeSchedule.Display);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainTimeSchedules_NoDeleteSchedule, _deleteThisTimeSchedule.Display);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                int numberDeleted = 0;
                var manager = _clientServices.GetManager<SDK.Managers.TimeScheduleManager>();
                var parameters = new Entities.DeleteParameters<Entities.TimeSchedule>() { Data = _deleteThisTimeSchedule, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = manager.DeleteTimeSchedule(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await manager.DeleteTimeScheduleAsync(parameters);
                }
                if (manager.HasErrors == false)
                    Schedules.Remove(_deleteThisTimeSchedule);
                else
                {
                    base.AddCustomErrors(manager.Errors, true);
                }
            }
            else
                _deleteThisTimeSchedule = null;
        }
        #endregion

        #region Public Properties

        //private DayPeriodViewModel _DayPeriodViewModel;

        //public DayPeriodViewModel DayPeriodViewModel
        //{
        //    get { return _DayPeriodViewModel; }
        //    set
        //    {
        //        if (_DayPeriodViewModel != value)
        //        {
        //            _DayPeriodViewModel = value;
        //            OnPropertyChanged(() => DayPeriodViewModel, false);
        //        }
        //    }
        //}



        public EditScheduleViewModel CurrentItemViewModel
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

        public ObservableCollection<GalaxySMS.Client.Entities.TimeSchedule> Schedules
        {
            get { return _schedules; }
            set
            {
                if (_schedules != value)
                {
                    _schedules = value;
                    OnPropertyChanged(() => Schedules, false);
                }
            }
        }

        public string EntityAlias
        {
            get { return _clientServices.EntityAlias; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    value = CommonResources.Resources.DefaultEntityAlias;
                if (_clientServices.EntityAlias != value)
                {
                    _clientServices.EntityAlias = value;
                    OnPropertyChanged(() => EntityAlias, false);
                }
            }
        }
        #endregion

        #region Public Events
        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.TimeSchedule> EditCommand { get; private set; }
        public DelegateCommand<Entities.TimeSchedule> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }

        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            RefreshFromServer();
        }

        private void RefreshFromServer()
        {
            base.ClearCustomErrors();
            Schedules = new ObservableCollection<Client.Entities.TimeSchedule>();
            var parameters = new Entities.GetParametersWithPhoto();
            //parameters.UniqueId = _clientServices.CurrentSite.SiteUid;
            parameters.IncludeMemberCollections = false;
            //parameters.IncludePhoto = true;
            var timeScheduleManager = _clientServices.GetManager<SDK.Managers.TimeScheduleManager>();
            var schedules = timeScheduleManager.GetTimeSchedulesForEntity(parameters, false);
            foreach (var s in schedules.Items)
            {
                Task.Run(async () => s.gcsEntity = await _clientServices.GetEntity(s.EntityId)).Wait();
                Schedules.Add(s);
            }
            if (timeScheduleManager.HasErrors)
            {
                base.AddCustomErrors(timeScheduleManager.Errors, true);
            }
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