using GalaxySMS.Common.Constants;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Infrastructure.Events;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
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
    [Export(typeof(GalaxyPanelViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GalaxyPanelViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditGalaxyPanelViewModel _currentGalaxyPanelViewModel;
        private Entities.GalaxyPanel _deleteThisGalaxyPanel = null;
        private Entities.Cluster _cluster = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public GalaxyPanelViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.Cluster cluster)
        {
            _eventAggregator = eventAggregator;
            ViewTitle = CommonResources.Resources.GalaxyPanelView_ViewTitle;
            ViewToolTip = CommonResources.Resources.GalaxyPanelView_ViewToolTip;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            _cluster = cluster;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.GalaxyPanel>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.GalaxyPanel>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);

            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.GalaxyPanel>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.GalaxyPanel>(OnDeleteCommand, OnDeleteCommandCanExecute);
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

        private void OperationCanceled(OperationCanceledEventArgs<Entities.GalaxyPanel> obj)
        {
            if (CurrentGalaxyPanelViewModel?.InstanceId == obj.OperationId)
                CurrentGalaxyPanelViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.GalaxyPanel> obj)
        {
            if (!obj.IsNew)
            {
                if (GalaxyPanels != null)
                {
                    var entity = GalaxyPanels.FirstOrDefault(item => item.GalaxyPanelUid == obj.Entity.GalaxyPanelUid);
                    if (entity != null)
                    {
                        entity.Initialize(obj.Entity);
                    }
                }
            }
            else
                GalaxyPanels.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentGalaxyPanelViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.GalaxyPanel obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId) &&
                    obj != null &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                //obj?.EntityId == _clientServices.CurrentEntityId && 
                IsEditControlVisible;
        }

        //void OnEditCommand(Entities.GalaxyPanel obj)
        //{
        //    ClearCustomErrors();
        //    if (obj != null)
        //    {
        //        CurrentGalaxyPanelViewModel = new EditGalaxyPanelViewModel(_eventAggregator, _clientServices, obj, Guid.Empty);
        //        CurrentGalaxyPanelViewModel.GalaxyPanels = this.GalaxyPanels;
        //    }
        //}

        async void OnEditCommand(Entities.GalaxyPanel obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                IsBusy = true;
                var galaxyPanelManager = _clientServices.GetManager<Client.SDK.Managers.GalaxyPanelManager>();
                var parameters = new Entities.GetParametersWithPhoto() { UniqueId = obj.GalaxyPanelUid, IncludeMemberCollections = true };

                parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.IncludeDeviceName, true));

                if (UseAsyncServiceCalls == false)
                {
                    obj = galaxyPanelManager.GetGalaxyPanel(parameters);
                }
                else
                {
                    obj = await galaxyPanelManager.GetGalaxyPanelAsync(parameters);
                }
                if (galaxyPanelManager.HasErrors == true)
                {
                    base.AddCustomErrors(galaxyPanelManager.Errors, true);
                }
                else
                {
                    CurrentGalaxyPanelViewModel = new EditGalaxyPanelViewModel(_eventAggregator, _clientServices, obj, Guid.Empty);
                    CurrentGalaxyPanelViewModel.GalaxyPanels = this.GalaxyPanels;
                }
                IsBusy = false;
            }
        }
        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId) &&
                    GalaxyPanels.Count() < GalaxyPanelLimits.MaximumPanelsPerCluster &&
                    IsAddNewControlVisible;
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.GalaxyPanel();
            o.ClusterGroupId = _cluster.ClusterGroupId;
            o.ClusterUid = _cluster.ClusterUid;
            o.ClusterNumber = _cluster.ClusterNumber;
            var definedNumbers = GalaxyPanels.Select(i => i.PanelNumber).ToList();
            var allNumbers = Enumerable.Range(GalaxyPanelLimits.LowestDefinablePanelNumber, GalaxyPanelLimits.HighestDefinablePanelNumber).ToArray();
            var availableNumbers = new List<short>();
            foreach (var n in allNumbers)
            {
                if (!definedNumbers.Contains((short)n))
                {
                    availableNumbers.Add((short)n);
                }
            }

            if (availableNumbers.Count() == 0)
                return;

            o.PanelNumber = availableNumbers.FirstOrDefault();
            o.PanelName = string.Format(CommonResources.Resources.GalaxyPanel_DefaultName, o.PanelNumber);
            o.GalaxyPanelModelUid = GalaxySMS.Common.Constants.GalaxyPanelTypeIds.GalaxyPanelType_635;
            o.Cpus.Add(new Client.Entities.GalaxyCpu()
            {
                ClusterGroupId = this.Cluster.ClusterGroupId,
                ClusterNumber = this.Cluster.ClusterNumber,
                PanelNumber = o.PanelNumber,
                CpuNumber = 1,
                IsActive = true
            });
            o.Cpus.Add(new Client.Entities.GalaxyCpu()
            {
                ClusterGroupId = this.Cluster.ClusterGroupId,
                ClusterNumber = this.Cluster.ClusterNumber,
                PanelNumber = o.PanelNumber,
                CpuNumber = 2,
                IsActive = false,
            });

            CurrentGalaxyPanelViewModel = new EditGalaxyPanelViewModel(_eventAggregator, _clientServices, o, Guid.Empty);
            CurrentGalaxyPanelViewModel.GalaxyPanels = this.GalaxyPanels;
        }

        private bool OnDeleteCommandCanExecute(Entities.GalaxyPanel obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId) &&
                    obj != null &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                //obj?.EntityId == _clientServices.CurrentEntityId && 
                IsDeleteControlVisible;
        }

        private void OnDeleteCommand(Entities.GalaxyPanel entity)
        {
            ClearCustomErrors();
            _deleteThisGalaxyPanel = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainGalaxyPanels_AreYouSureDeleteGalaxyPanel,
                _deleteThisGalaxyPanel.PanelName);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainGalaxyPanels_YesDeleteGalaxyPanel, _deleteThisGalaxyPanel.PanelName);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainGalaxyPanels_NoDeleteGalaxyPanel, _deleteThisGalaxyPanel.PanelName);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                IsBusy = true;
                var GalaxyPanelManager = _clientServices.GetManager<Client.SDK.Managers.GalaxyPanelManager>();
                var parameters = new Entities.DeleteParameters<Entities.GalaxyPanel>() { Data = _deleteThisGalaxyPanel, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    GalaxyPanelManager.DeleteGalaxyPanel(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteGalaxyPanel(parameters));
                    await GalaxyPanelManager.DeleteGalaxyPanelAsync(parameters);
                }
                if (GalaxyPanelManager.HasErrors == false)
                    GalaxyPanels.Remove(_deleteThisGalaxyPanel);
                else
                {
                    base.AddCustomErrors(GalaxyPanelManager.Errors, true);
                }

                IsBusy = false;
            }
            else
                _deleteThisGalaxyPanel = null;
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

        public EditGalaxyPanelViewModel CurrentGalaxyPanelViewModel
        {
            get { return _currentGalaxyPanelViewModel; }
            set
            {
                if (_currentGalaxyPanelViewModel != value)
                {
                    _currentGalaxyPanelViewModel = value;
                    OnPropertyChanged(() => CurrentGalaxyPanelViewModel, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.GalaxyPanel> _GalaxyPanels;

        public ObservableCollection<GalaxySMS.Client.Entities.GalaxyPanel> GalaxyPanels
        {
            get { return _GalaxyPanels; }
            set
            {
                if (_GalaxyPanels != value)
                {
                    _GalaxyPanels = value;
                    OnPropertyChanged(() => GalaxyPanels, false);
                }
            }
        }

        private Entities.GalaxyPanel _SelectedGalaxyPanel;

        public Entities.GalaxyPanel SelectedGalaxyPanel
        {
            get { return _SelectedGalaxyPanel; }
            set
            {
                if (_SelectedGalaxyPanel != value)
                {
                    _SelectedGalaxyPanel = value;
                    OnPropertyChanged(() => SelectedGalaxyPanel, false);
                }
            }
        }

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.GalaxyPanel> EditCommand { get; private set; }
        public DelegateCommand<Entities.GalaxyPanel> DeleteCommand { get; private set; }
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
            this.GalaxyPanels = new ObservableCollection<Entities.GalaxyPanel>();
            var parameters = new Entities.GetParametersWithPhoto() { IncludeMemberCollections = true, UniqueId = Cluster.ClusterUid };// _clientServices.CreateGetParametersWithPhoto();
            var galaxyPanelManager = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.GalaxyPanelManager>();
            var galaxyPanels = galaxyPanelManager.GetGalaxyPanelsForCluster(parameters, false);
            foreach (var s in galaxyPanels.Items)
                this.GalaxyPanels.Add(s);

            if (galaxyPanelManager.HasErrors)
            {
                base.AddCustomErrors(galaxyPanelManager.Errors, true);
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