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
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.GalaxyHardware.ViewModels
{
    [Export]
    [Export(typeof(AreaViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AreaViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditAreaViewModel _currentAreaViewModel;
        private Entities.Area _deleteThisArea = null;
        private Entities.Cluster _cluster = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public AreaViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.Cluster cluster)
        {
            _eventAggregator = eventAggregator;
            ViewTitle = CommonResources.Resources.AreaView_ViewTitle;
            ViewToolTip = CommonResources.Resources.AreaView_ViewToolTip;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            _cluster = cluster;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.Area>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.Area>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);

            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.Area>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.Area>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsEditControlVisible = true;
            IsDeleteControlVisible = true;
        }

        private void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        {
            RefreshFromServer();
        }

        #endregion

        #region Private methods

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId) && IsRefreshControlVisible;
        }

        private void OnRefreshCommand(object obj)
        {
            RefreshFromServer();
        }

        private void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            RefreshFromServer();
        }

        private void OperationCanceled(OperationCanceledEventArgs<Entities.Area> obj)
        {
            if (CurrentAreaViewModel?.InstanceId == obj.OperationId)
                CurrentAreaViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.Area> obj)
        {
            if (!obj.IsNew)
            {
                var entity = Areas.FirstOrDefault(item => item.AreaUid == obj.Entity.AreaUid);
                if (entity != null)
                {
                    entity.Initialize(obj.Entity);
                }
            }
            else
                Areas.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentAreaViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.Area obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId) &&
                    obj != null &&
                    obj.AreaNumber != (int)GalaxySMS.Common.Enums.AreaNumber.NoChange &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                //obj?.EntityId == _clientServices.CurrentEntityId && 
                IsEditControlVisible;
        }

        void OnEditCommand(Entities.Area obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                CurrentAreaViewModel = new EditAreaViewModel(_eventAggregator, _clientServices, obj, Guid.Empty);
            }
        }
        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId) &&
                    Areas.Count() < GalaxySMS.Common.Constants.AreaLimits.MaximumCount &&
                    IsAddNewControlVisible;
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.Area();
            o.ClusterUid = _cluster.ClusterUid;

            var definedNumbers = Areas.Select(i => i.AreaNumber);
            var availableNumbers = Enumerable.Range(AreaLimits.LowestDefinableNumber, AreaLimits.HighestNumber).Except(definedNumbers);
            if (availableNumbers.Count() == 0)
                return;

            o.AreaNumber = availableNumbers.FirstOrDefault();
            o.Display = string.Format(CommonResources.Resources.Area_DefaultName, o.AreaNumber);

            CurrentAreaViewModel = new EditAreaViewModel(_eventAggregator, _clientServices, o, Guid.Empty);
        }

        private bool OnDeleteCommandCanExecute(Entities.Area obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId) &&
                    obj != null &&
                    obj.AreaNumber != (int)GalaxySMS.Common.Enums.AreaNumber.NoChange &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                //obj?.EntityId == _clientServices.CurrentEntityId && 
                IsDeleteControlVisible;
        }

        private void OnDeleteCommand(Entities.Area entity)
        {
            ClearCustomErrors();
            _deleteThisArea = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainAreas_AreYouSureDeleteArea,
                _deleteThisArea.Display);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainAreas_YesDeleteArea, _deleteThisArea.Display);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainAreas_NoDeleteArea, _deleteThisArea.Display);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                IsBusy = true;
                var AreaManager = _clientServices.GetManager<Client.SDK.Managers.GalaxyAreaManager>();
                var parameters = new Entities.DeleteParameters<Entities.Area>() { Data = _deleteThisArea, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    AreaManager.DeleteArea(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteArea(parameters));
                    await AreaManager.DeleteAreaAsync(parameters);
                }
                if (AreaManager.HasErrors == false)
                    Areas.Remove(_deleteThisArea);
                else
                {
                    base.AddCustomErrors(AreaManager.Errors, true);
                }
            }
            else
                _deleteThisArea = null;
        }

        #endregion

        #region Public Properties

        public Entities.Cluster Cluster
        {
            get { return _cluster; }
            set
            {
                if (_cluster != value)
                {
                    _cluster = value;
                    OnPropertyChanged(() => Cluster, false);
                }
            }
        }

        public EditAreaViewModel CurrentAreaViewModel
        {
            get { return _currentAreaViewModel; }
            set
            {
                if (_currentAreaViewModel != value)
                {
                    _currentAreaViewModel = value;
                    OnPropertyChanged(() => CurrentAreaViewModel, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.Area> _Areas;

        public ObservableCollection<GalaxySMS.Client.Entities.Area> Areas
        {
            get { return _Areas; }
            set
            {
                if (_Areas != value)
                {
                    _Areas = value;
                    OnPropertyChanged(() => Areas, false);
                }
            }
        }

        private Entities.Area _SelectedArea;

        public Entities.Area SelectedArea
        {
            get { return _SelectedArea; }
            set
            {
                if (_SelectedArea != value)
                {
                    _SelectedArea = value;
                    OnPropertyChanged(() => SelectedArea, false);
                }
            }
        }

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.Area> EditCommand { get; private set; }
        public DelegateCommand<Entities.Area> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }
        #endregion

        #region Public Events
        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccurred;

        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            RefreshFromServer();
        }

        private void RefreshFromServer()
        {
            base.ClearCustomErrors();
            this.Areas = new ObservableCollection<Entities.Area>();
            var parameters = new Entities.GetParametersWithPhoto() { IncludeMemberCollections = true, UniqueId = Cluster.ClusterUid };// _clientServices.CreateGetParametersWithPhoto();
            var AreaManager = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.GalaxyAreaManager>();
            var Areas = AreaManager.GetAreasForCluster(parameters, false);
            foreach (var s in Areas.Items)
                this.Areas.Add(s);

            if (AreaManager.HasErrors)
            {
                base.AddCustomErrors(AreaManager.Errors, true);
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
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}