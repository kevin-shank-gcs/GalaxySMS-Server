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
    [Export(typeof(AccessGroupViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessGroupViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditAccessGroupViewModel _currentAccessGroupViewModel;
        private Entities.AccessGroup _deleteThisAccessGroup = null;
        private Entities.Cluster _cluster = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public AccessGroupViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.Cluster cluster)
        {
            _eventAggregator = eventAggregator;
            ViewTitle = CommonResources.Resources.AccessGroupView_ViewTitle;
            ViewToolTip = CommonResources.Resources.AccessGroupView_ViewToolTip;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            _cluster = cluster;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AccessGroup>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.AccessGroup>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);

            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.AccessGroup>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.AccessGroup>(OnDeleteCommand, OnDeleteCommandCanExecute);
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

        private void OperationCanceled(OperationCanceledEventArgs<Entities.AccessGroup> obj)
        {
            if (CurrentAccessGroupViewModel?.InstanceId == obj.OperationId)
                CurrentAccessGroupViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.AccessGroup> obj)
        {
            if (!obj.IsNew)
            {
                var entity = AccessGroups.FirstOrDefault(item => item.AccessGroupUid == obj.Entity.AccessGroupUid);
                if (entity != null)
                {
                    entity.Initialize(obj.Entity);
                }
            }
            else
            {
                if (AccessGroups != null)
                    AccessGroups.Add(obj.Entity);
                else
                    RefreshFromServer();
            }

            if (obj.CloseEditor)
                CurrentAccessGroupViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.AccessGroup obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId) &&
                    obj != null &&
                    obj.AccessGroupNumber != (int)GalaxySMS.Common.Enums.AccessGroupNumber.NoAccess &&
                    obj.AccessGroupNumber != (int)GalaxySMS.Common.Enums.AccessGroupNumber.UnlimitedAccess &&
                    obj.AccessGroupNumber != (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                //obj?.EntityId == _clientServices.CurrentEntityId && 
                IsEditControlVisible;
        }

        void OnEditCommand(Entities.AccessGroup obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                var p = new Entities.GetParametersWithPhoto()
                {
                    UniqueId = obj.AccessGroupUid,
                    IncludeMemberCollections = true
                };

                p.AddOption(GalaxySMS.Common.Constants.GetOptions_AccessGroup.IncludeSystemAccessGroups, true);
                var currentItem = GetItemFromServer(p);

                CurrentAccessGroupViewModel = new EditAccessGroupViewModel(_eventAggregator, _clientServices, currentItem, Guid.Empty);
                CurrentAccessGroupViewModel.AccessGroups = this.AccessGroups;
            }
        }
        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId) &&
                    AccessGroups.Count() < AccessGroupLimits.MaximumCount &&
                    IsAddNewControlVisible;
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.AccessGroup
            {
                ClusterUid = _cluster.ClusterUid,
                IsEnabled = true
            };

            var definedNumbers = AccessGroups.Select(i => i.AccessGroupNumber);
            var enumerable = definedNumbers as int[] ?? definedNumbers.ToArray();
            var availableNumbers = Enumerable.Range(AccessGroupLimits.LowestDefinableNumber, AccessGroupLimits.MaximumNumber).Except(enumerable);
            var numbers = availableNumbers as int[] ?? availableNumbers.ToArray();
            if (!numbers.Any())
                return;

            var availableExtendedNumbers = Enumerable.Range(AccessGroupLimits.MinimumExtendedGroupNumber, AccessGroupLimits.MaximumNumber).Except(enumerable);
            if (!availableExtendedNumbers.Any())
                return;

            o.AccessGroupNumber = numbers.FirstOrDefault();
            o.Display = string.Format(CommonResources.Resources.AccessGroup_DefaultName, o.AccessGroupNumber);

            //o.IOGroupNumber = (from i in AccessGroups select i.IOGroupNumber).Max() + 1;

            //c.SetDefaults();
            //c.SiteUid = _clientServices.CurrentSite.SiteUid;
            //c.EntityId = _clientServices.CurrentEntityId;

            CurrentAccessGroupViewModel = new EditAccessGroupViewModel(_eventAggregator, _clientServices, o, Guid.Empty)
            {
                AccessGroups = this.AccessGroups
            };
        }

        private bool OnDeleteCommandCanExecute(Entities.AccessGroup obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId) &&
                    obj != null &&
                    obj.AccessGroupNumber != (int)GalaxySMS.Common.Enums.AccessGroupNumber.NoAccess &&
                    obj.AccessGroupNumber != (int)GalaxySMS.Common.Enums.AccessGroupNumber.UnlimitedAccess &&
                    obj.AccessGroupNumber != (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                //obj?.EntityId == _clientServices.CurrentEntityId && 
                IsDeleteControlVisible;
        }

        private void OnDeleteCommand(Entities.AccessGroup entity)
        {
            ClearCustomErrors();
            _deleteThisAccessGroup = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainAccessGroups_AreYouSureDeleteAccessGroup,
                _deleteThisAccessGroup.Display);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainAccessGroups_YesDeleteAccessGroup, _deleteThisAccessGroup.Display);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainAccessGroups_NoDeleteAccessGroup, _deleteThisAccessGroup.Display);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                IsBusy = true;
                var AccessGroupManager = _clientServices.GetManager<Client.SDK.Managers.GalaxyAccessGroupManager>();
                var parameters = new Entities.DeleteParameters<Entities.AccessGroup>() { Data = _deleteThisAccessGroup, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    AccessGroupManager.DeleteAccessGroup(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteAccessGroup(parameters));
                    await AccessGroupManager.DeleteAccessGroupAsync(parameters);
                }
                if (AccessGroupManager.HasErrors == false)
                    AccessGroups.Remove(_deleteThisAccessGroup);
                else
                {
                    base.AddCustomErrors(AccessGroupManager.Errors, true);
                }
            }
            else
                _deleteThisAccessGroup = null;
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

        public EditAccessGroupViewModel CurrentAccessGroupViewModel
        {
            get { return _currentAccessGroupViewModel; }
            set
            {
                if (_currentAccessGroupViewModel != value)
                {
                    _currentAccessGroupViewModel = value;
                    OnPropertyChanged(() => CurrentAccessGroupViewModel, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.AccessGroup> _AccessGroups;

        public ObservableCollection<GalaxySMS.Client.Entities.AccessGroup> AccessGroups
        {
            get { return _AccessGroups; }
            set
            {
                if (_AccessGroups != value)
                {
                    _AccessGroups = value;
                    OnPropertyChanged(() => AccessGroups, false);
                }
            }
        }

        private Entities.AccessGroup _SelectedAccessGroup;

        public Entities.AccessGroup SelectedAccessGroup
        {
            get { return _SelectedAccessGroup; }
            set
            {
                if (_SelectedAccessGroup != value)
                {
                    _SelectedAccessGroup = value;
                    OnPropertyChanged(() => SelectedAccessGroup, false);
                }
            }
        }

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.AccessGroup> EditCommand { get; private set; }
        public DelegateCommand<Entities.AccessGroup> DeleteCommand { get; private set; }
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
            this.AccessGroups = new ObservableCollection<Entities.AccessGroup>();
            var parameters = new Entities.GetParametersWithPhoto() { IncludeMemberCollections = false, UniqueId = Cluster.ClusterUid }; //new Entities.GetParametersWithPhoto() { IncludeMemberCollections = true, UniqueId = Cluster.ClusterUid };
            var accessGroupManager = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.GalaxyAccessGroupManager>();
            var AccessGroups = accessGroupManager.GetAccessGroupsForCluster(parameters, false);
            foreach (var s in AccessGroups.Items)
                this.AccessGroups.Add(s);

            if (accessGroupManager.HasErrors)
            {
                base.AddCustomErrors(accessGroupManager.Errors, true);
            }
        }

        private Entities.AccessGroup GetItemFromServer(Entities.GetParametersWithPhoto p)
        {
            if (p == null)
                return null;
            base.ClearCustomErrors();
            var accessGroupManager = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.GalaxyAccessGroupManager>();
            var ag = accessGroupManager.GetAccessGroup(p);

            if (accessGroupManager.HasErrors)
            {
                base.AddCustomErrors(accessGroupManager.Errors, true);
                return null;
            }
            return ag;
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