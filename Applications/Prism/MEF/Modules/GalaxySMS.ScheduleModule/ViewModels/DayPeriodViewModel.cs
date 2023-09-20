using System;
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
using GalaxySMS.Prism.Infrastructure.Events;
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using LocalResources = GalaxySMS.Schedule.Properties;

namespace GalaxySMS.Schedule.ViewModels
{
    [Export(typeof(DayPeriodViewModel))]
    public class DayPeriodViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditDayPeriodViewModel _CurrentItemViewModel;
        private Entities.AssaDayPeriod _deleteThisAssaDayPeriod = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public DayPeriodViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = CommonResources.Resources.DayPeriodView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AssaDayPeriod>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.AssaDayPeriod>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.AssaDayPeriod>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.AssaDayPeriod>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
        }


        #endregion

        #region Private Methods

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.RegionCanViewId);
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

        private void OperationCanceled(OperationCanceledEventArgs<Entities.AssaDayPeriod> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.AssaDayPeriod> obj)
        {
            if (!obj.IsNew)
            {
                var entity = DayPeriods.FirstOrDefault(item => item.AssaDayPeriodUid == obj.Entity.AssaDayPeriodUid);
                entity?.Initialize(obj.Entity);
            }
            else
                DayPeriods.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.AssaDayPeriod obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId);
        }

        private void OnEditCommand(Entities.AssaDayPeriod obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                CurrentItemViewModel = new EditDayPeriodViewModel(_eventAggregator, _clientServices, obj, Guid.Empty);
            }
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
            var o = new Entities.AssaDayPeriod();
            CurrentItemViewModel = new EditDayPeriodViewModel(_eventAggregator, _clientServices, o, Guid.Empty);
        }

        private bool OnDeleteCommandCanExecute(Entities.AssaDayPeriod obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanDeleteId);
        }

        //private async void OnDeleteCommand(Entities.AssaDayPeriod entity)
        //{
        //    ClearCustomErrors();

        //    var args = new CancelMessageEventArgs(entity.PortalName);
        //    if (ConfirmDelete != null)
        //        ConfirmDelete(this, args);
        //    if (!args.Cancel)
        //    {
        //        var regionManager = _clientServices.GetManager<SDK.Managers.RegionManager>();
        //        var parameters = new Entities.DeleteParameters<Entities.Region>() { Data = entity, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
        //        if (UseAsyncServiceCalls == false)
        //        {
        //            regionManager.DeleteRegion(parameters);
        //            //Globals.Instance.RefreshEntities();
        //        }
        //        else
        //        {
        //            await regionManager.DeleteRegionAsync(parameters);
        //        }
        //        if (regionManager.HasErrors == false)
        //            GalaxySMSRegions.Remove(entity);
        //    }
        //}
        private void OnDeleteCommand(Entities.AssaDayPeriod entity)
        {
            ClearCustomErrors();
            _deleteThisAssaDayPeriod = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainDayPeriods_AreYouSureDeleteDayPeriod,
                _deleteThisAssaDayPeriod.Name);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainDayPeriods_YesDeleteDayPeriod, _deleteThisAssaDayPeriod.Name);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainDayPeriods_NoDeleteDayPeriod, _deleteThisAssaDayPeriod.Name);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                int numberDeleted = 0;
                var manager = _clientServices.GetManager<SDK.Managers.DayPeriodManager>();
                var parameters = new Entities.DeleteParameters<Entities.AssaDayPeriod>() { Data = _deleteThisAssaDayPeriod, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = manager.DeleteDayPeriod(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await manager.DeleteDayPeriodAsync(parameters);
                }
                if (manager.HasErrors == false)
                    DayPeriods.Remove(_deleteThisAssaDayPeriod);
                else
                {
                    base.AddCustomErrors(manager.Errors, true);
                }
            }
            else
                _deleteThisAssaDayPeriod = null;
        }
        #endregion

        #region Public Properties
        public EditDayPeriodViewModel CurrentItemViewModel
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

        private ObservableCollection<GalaxySMS.Client.Entities.AssaDayPeriod> _dayPeriods;

        public ObservableCollection<GalaxySMS.Client.Entities.AssaDayPeriod> DayPeriods   
        {
            get { return _dayPeriods; }
            set
            {
                if (_dayPeriods != value)
                {
                    _dayPeriods = value;
                    OnPropertyChanged(() => DayPeriods, false);
                }
            }
        }

        #endregion

        #region Public Events
        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        #endregion
       
        #region Public Commands
        public DelegateCommand<Entities.AssaDayPeriod> EditCommand { get; private set; }
        public DelegateCommand<Entities.AssaDayPeriod> DeleteCommand { get; private set; }
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
            DayPeriods = new ObservableCollection<Client.Entities.AssaDayPeriod>();
            var parameters = new Entities.GetParametersWithPhoto();
            //parameters.UniqueId = _clientServices.CurrentSite.SiteUid;
            parameters.IncludeMemberCollections = true;
            //parameters.IncludePhoto = true;
            var AssaDayPeriodManager = _clientServices.GetManager<SDK.Managers.DayPeriodManager>();
            var data = AssaDayPeriodManager.GetDayPeriodsForEntity(parameters, false);
            foreach (var s in data)
                DayPeriods.Add(s);

            if (AssaDayPeriodManager.HasErrors)
            {
                base.AddCustomErrors(AssaDayPeriodManager.Errors, true);
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