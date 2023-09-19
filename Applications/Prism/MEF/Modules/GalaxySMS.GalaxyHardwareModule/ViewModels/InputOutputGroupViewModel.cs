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
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.GalaxyHardware.ViewModels
{
    [Export]
    [Export(typeof(InputOutputGroupViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InputOutputGroupViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditInputOutputGroupViewModel _currentInputOutputGroupViewModel;
        private Entities.InputOutputGroup _deleteThisInputOutputGroup = null;
        private Entities.Cluster _cluster = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public InputOutputGroupViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.Cluster cluster)
        {
            _eventAggregator = eventAggregator;
            ViewTitle = CommonResources.Resources.InputOutputGroupView_ViewTitle;
            ViewToolTip = CommonResources.Resources.InputOutputGroupView_ViewToolTip;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            _cluster = cluster;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.InputOutputGroup>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.InputOutputGroup>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);

            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.InputOutputGroup>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.InputOutputGroup>(OnDeleteCommand, OnDeleteCommandCanExecute);
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

        private void OperationCanceled(OperationCanceledEventArgs<Entities.InputOutputGroup> obj)
        {
            if (CurrentInputOutputGroupViewModel?.InstanceId == obj.OperationId)
                CurrentInputOutputGroupViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.InputOutputGroup> obj)
        {
            if (!obj.IsNew)
            {
                var entity = InputOutputGroups.FirstOrDefault(item => item.InputOutputGroupUid == obj.Entity.InputOutputGroupUid);
                if (entity != null)
                {
                    entity.Initialize(obj.Entity);
                }
            }
            else
            {
                if (InputOutputGroups != null)
                    InputOutputGroups.Add(obj.Entity);
                else
                    RefreshFromServer();
            }

            if (obj.CloseEditor)
                CurrentInputOutputGroupViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.InputOutputGroup obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId) &&
                    obj != null &&
                    obj.IOGroupNumber != (int)GalaxySMS.Common.Enums.InputOutputGroupNumber.None &&
                    //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                    //obj?.EntityId == _clientServices.CurrentEntityId && 
                    IsBusy == false &&
                IsEditControlVisible;
        }

        void OnEditCommand(Entities.InputOutputGroup obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                CurrentInputOutputGroupViewModel = new EditInputOutputGroupViewModel(_eventAggregator, _clientServices, obj, Guid.Empty);
            }
        }
        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId) &&
                    InputOutputGroups.Count() < GalaxySMS.Common.Constants.InputOutputGroupLimits.MaximumCount &&
                    IsBusy == false &&
                    IsAddNewControlVisible;
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.InputOutputGroup();
            o.ClusterUid = _cluster.ClusterUid;

            var definedNumbers = InputOutputGroups.Select(i => i.IOGroupNumber);
            var availableNumbers = Enumerable.Range(InputOutputGroupLimits.LowestDefinableNumber, InputOutputGroupLimits.HighestNumber).Except(definedNumbers);
            if (availableNumbers.Count() == 0)
                return;

            o.IOGroupNumber = availableNumbers.FirstOrDefault();
            o.Display = string.Format(CommonResources.Resources.InputOutputGroup_DefaultName, o.IOGroupNumber);
            //o.IOGroupNumber = (from i in InputOutputGroups select i.IOGroupNumber).Max() + 1;

            //c.SetDefaults();
            //c.SiteUid = _clientServices.CurrentSite.SiteUid;
            //c.EntityId = _clientServices.CurrentEntityId;

            CurrentInputOutputGroupViewModel = new EditInputOutputGroupViewModel(_eventAggregator, _clientServices, o, Guid.Empty);
        }

        private bool OnDeleteCommandCanExecute(Entities.InputOutputGroup obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId) &&
                    obj != null &&
                    obj.IOGroupNumber != (int)GalaxySMS.Common.Enums.InputOutputGroupNumber.None &&
                    IsBusy == false &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                //obj?.EntityId == _clientServices.CurrentEntityId && 
                IsDeleteControlVisible;
        }

        private void OnDeleteCommand(Entities.InputOutputGroup entity)
        {
            ClearCustomErrors();
            _deleteThisInputOutputGroup = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainInputOutputGroups_AreYouSureDeleteInputOutputGroup,
                _deleteThisInputOutputGroup.Display);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainInputOutputGroups_YesDeleteInputOutputGroup, _deleteThisInputOutputGroup.Display);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainInputOutputGroups_NoDeleteInputOutputGroup, _deleteThisInputOutputGroup.Display);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                IsBusy = true;
                var InputOutputGroupManager = _clientServices.GetManager<Client.SDK.Managers.GalaxyInputOutputGroupManager>();
                var parameters = new Entities.DeleteParameters<Entities.InputOutputGroup>() { Data = _deleteThisInputOutputGroup, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    InputOutputGroupManager.DeleteInputOutputGroup(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteInputOutputGroup(parameters));
                    await InputOutputGroupManager.DeleteInputOutputGroupAsync(parameters);
                }
                if (InputOutputGroupManager.HasErrors == false)
                    InputOutputGroups.Remove(_deleteThisInputOutputGroup);
                else
                {
                    base.AddCustomErrors(InputOutputGroupManager.Errors, true);
                }
                IsBusy = false;

            }
            else
                _deleteThisInputOutputGroup = null;
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

        public EditInputOutputGroupViewModel CurrentInputOutputGroupViewModel
        {
            get { return _currentInputOutputGroupViewModel; }
            set
            {
                if (_currentInputOutputGroupViewModel != value)
                {
                    _currentInputOutputGroupViewModel = value;
                    OnPropertyChanged(() => CurrentInputOutputGroupViewModel, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.InputOutputGroup> _InputOutputGroups;

        public ObservableCollection<GalaxySMS.Client.Entities.InputOutputGroup> InputOutputGroups
        {
            get { return _InputOutputGroups; }
            set
            {
                if (_InputOutputGroups != value)
                {
                    _InputOutputGroups = value;
                    OnPropertyChanged(() => InputOutputGroups, false);
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

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.InputOutputGroup> EditCommand { get; private set; }
        public DelegateCommand<Entities.InputOutputGroup> DeleteCommand { get; private set; }
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

        private async Task RefreshFromServer()
        {
            IsBusy = true;
            base.ClearCustomErrors();
            this.InputOutputGroups = new ObservableCollection<Entities.InputOutputGroup>();
            var parameters = new Entities.GetParametersWithPhoto() { IncludeMemberCollections = true, UniqueId = Cluster.ClusterUid };// _clientServices.CreateGetParametersWithPhoto();
            var InputOutputGroupManager = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.GalaxyInputOutputGroupManager>();
            var iogs = await InputOutputGroupManager.GetInputOutputGroupsForClusterAsync(parameters);
            foreach (var s in iogs.Items)
                this.InputOutputGroups.Add(s);

            if (InputOutputGroupManager.HasErrors)
            {
                base.AddCustomErrors(InputOutputGroupManager.Errors, true);
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
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}