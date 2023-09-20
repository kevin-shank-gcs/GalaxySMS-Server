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
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;
using LocalResources = GalaxySMS.GalaxyHardware.Properties;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.GalaxyHardware.ViewModels
{
    [Export(typeof(ClusterViewModel))]
    public class ClusterViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditClusterViewModel _currentClusterViewModel;
        private Entities.Cluster _deleteThisCluster = null;
        private Entities.InputOutputGroup _deleteThisInputOutputGroup = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public ClusterViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            ViewTitle = LocalResources.Resources.GalaxyHardwareView_ViewTitle;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.Cluster>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.Cluster>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);

            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.Cluster>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.Cluster>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

            CreateGridPageSizes();

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsEditControlVisible = true;
            IsDeleteControlVisible = true;
        }

        private void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        {
            Task.Run(async () =>
            {
                await RefreshFromServer();
            });
        }



        #endregion


        #region Private methods
        private void CreateGridPageSizes()
        {
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

        private void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            Task.Run(async () =>
            {
                await RefreshFromServer();
            });
        }

        private void OperationCanceled(OperationCanceledEventArgs<Entities.Cluster> obj)
        {
            if (CurrentClusterViewModel?.InstanceId == obj.OperationId)
                CurrentClusterViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.Cluster> obj)
        {
            if (!obj.IsNew)
            {
                var entity = Clusters.FirstOrDefault(item => item.ClusterUid == obj.Entity.ClusterUid);
                if (entity != null)
                {
                    entity.Initialize(obj.Entity);
                }
            }
            else
                Clusters.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentClusterViewModel = null;
        }

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId) && IsRefreshControlVisible;
        }

        private void OnRefreshCommand(object obj)
        {
            Task.Run(async () =>
            {
                await RefreshFromServer();
            });
        }

        private bool OnEditCommandCanExecute(Entities.Cluster obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId) &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                obj?.EntityId == _clientServices.CurrentEntityId && IsEditControlVisible;
        }

        private async void OnEditCommand(Entities.Cluster obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                IsBusy = true;
                var mgr = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.ClusterManager>();

                var c = await mgr.GetClusterAsync(new Entities.GetParametersWithPhoto()
                {
                    UniqueId = obj.ClusterUid,
                    IncludePhoto = true,
                    IncludeMemberCollections = true,
                    IncludeHardwareAddress = true
                });
                CurrentClusterViewModel = new EditClusterViewModel(_eventAggregator, _clientServices, c, Guid.Empty);
                IsBusy = false;
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId) && IsAddNewControlVisible;
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var c = new Entities.Cluster();
            c.SetDefaults();
            c.SiteUid = _clientServices.CurrentSite.SiteUid;
            c.EntityId = _clientServices.CurrentEntityId;

            CurrentClusterViewModel = new EditClusterViewModel(_eventAggregator, _clientServices, c, Guid.Empty);
        }

        private bool OnDeleteCommandCanExecute(Entities.Cluster obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId) &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                obj?.EntityId == _clientServices.CurrentEntityId
                && IsDeleteControlVisible;
        }

        private void OnDeleteCommand(Entities.Cluster entity)
        {
            ClearCustomErrors();
            _deleteThisCluster = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainClusters_AreYouSureDeleteCluster,
                _deleteThisCluster.ClusterName);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainClusters_YesDeleteCluster, _deleteThisCluster.ClusterName);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainClusters_NoDeleteCluster, _deleteThisCluster.ClusterName);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                IsBusy = true;
                var ClusterManager = _clientServices.GetManager<Client.SDK.Managers.ClusterManager>();
                var parameters = new Entities.DeleteParameters<Entities.Cluster>() { Data = _deleteThisCluster, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    ClusterManager.DeleteCluster(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteCluster(parameters));
                    await ClusterManager.DeleteClusterAsync(parameters);
                }
                if (ClusterManager.HasErrors == false)
                    Clusters.Remove(_deleteThisCluster);
                else
                {
                    base.AddCustomErrors(ClusterManager.Errors, true);
                }
                IsBusy = false;

            }
            else
                _deleteThisCluster = null;
        }

        #endregion

        #region Public Properties

        public EditClusterViewModel CurrentClusterViewModel
        {
            get { return _currentClusterViewModel; }
            set
            {
                if (_currentClusterViewModel != value)
                {
                    _currentClusterViewModel = value;
                    OnPropertyChanged(() => CurrentClusterViewModel, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.Cluster> _clusters;

        public ObservableCollection<GalaxySMS.Client.Entities.Cluster> Clusters
        {
            get { return _clusters; }
            set
            {
                if (_clusters != value)
                {
                    _clusters = value;
                    OnPropertyChanged(() => Clusters, false);
                }
            }
        }

        private Entities.InputOutputGroup _SelectedInputOutputGroup;

        public Entities.InputOutputGroup SelectedInputOutputGroup
        {
            get { return _SelectedInputOutputGroup; }
            set
            {
                if (_SelectedInputOutputGroup != value)
                {
                    _SelectedInputOutputGroup = value;
                    OnPropertyChanged(() => SelectedInputOutputGroup, false);
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
                if (Clusters == null)
                    return 0;
                return Clusters.Count;
            }
            set
            {
                OnPropertyChanged(() => TotalRecordCount, false);
            }
        }

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.Cluster> EditCommand { get; private set; }
        public DelegateCommand<Entities.Cluster> DeleteCommand { get; private set; }
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
            Task.Run(async () =>
            {
                await RefreshFromServer();
            });
        }

        private async Task RefreshFromServer()
        {
            try
            {

                IsBusy = true;
                base.ClearCustomErrors();
                var parameters = new Entities.GetParametersWithPhoto() { IncludeMemberCollections = false, IncludePhoto = true, DescendingOrder = false, SortProperty = ClusterSortProperty.ClusterName.ToString() };// _clientServices.CreateGetParametersWithPhoto();
                parameters.UniqueId = _clientServices.CurrentSite.SiteUid;
                var clusterManager = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.ClusterManager>();
                //var Clusters = await ClusterManager.GetClustersForSite(parameters, false);
                var clusters = await clusterManager.GetClustersForSiteAsync(parameters);
                //var clusterList = await clusterManager.GetAllClustersForSiteListAsync(parameters);
                if (clusterManager.HasErrors)
                {
                    base.AddCustomErrors(clusterManager.Errors, true);
                }
                if (clusters != null)
                {
                    Clusters = clusters.ToObservableCollection();
                    //foreach (var c in clusterList.Items)
                    //{
                    //    clusters.Add(c.ToCluster());
                    //}
                    //foreach (var s in clusters)
                    //    this.Clusters.Add(s);
                }
                else
                {
                    Clusters = new ObservableCollection<Entities.Cluster>();
                }
            }
            catch (Exception ex)
            {
                this.Log().Error("RefreshFromServer", ex);
            }

            IsBusy = false;
        }

        private void RefreshInputOutputGroupsFromServer()
        {

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