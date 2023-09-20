using GalaxySMS.Client.SDK.Managers;
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
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;
using SDK = GalaxySMS.Client.SDK;

namespace GalaxySMS.PersonCredential.ViewModels
{
    [Export(typeof(AccessProfileViewModel))]
    public class AccessProfileViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification,
        INavigationAware
    {
        #region Private fields

        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditAccessProfileViewModel _CurrentItemViewModel;
        private Entities.AccessProfile _deleteThisAccessProfile = null;
        private KeyValuePair<int, string> _gridPageSize;
        private ObservableCollection<KeyValuePair<int, string>> _gridPageSizes;
        private ObservableCollection<GalaxySMS.Client.Entities.AccessProfile> _AccessProfiles;
        private Entities.AccessProfileEditingData _accessProfileEditingData;
        private bool _bOnViewLoadedAlreadyCalled;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public AccessProfileViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = Properties.Resources.AccessProfileView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AccessProfile>>>()
                .Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.AccessProfile>>>()
                .Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>()
                .Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            //_eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>()
            //    .Subscribe(CurrentSiteChanged, ThreadOption.UIThread);

            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.AccessProfile>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.AccessProfile>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

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

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
        }

        #endregion

        #region Private Methods
        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanViewId);
        }

        private async void OnRefreshCommand(object obj)
        {
            await RefreshFromServer();
        }

        private async void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            await RefreshFromServer();
        }

        //private async void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        //{
        //    await RefreshFromServer();
        //}

        private void OperationCanceled(OperationCanceledEventArgs<Entities.AccessProfile> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.AccessProfile> obj)
        {
            if (AccessProfiles == null)
                AccessProfiles = new ObservableCollection<Client.Entities.AccessProfile>();
            if (!obj.IsNew)
            {
                var entity = AccessProfiles.FirstOrDefault(item => item.AccessProfileUid == obj.Entity.AccessProfileUid);
                entity?.Initialize(obj.Entity);
            }
            else
                AccessProfiles.Add(obj.Entity);

            CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.AccessProfile obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanUpdateId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
            ;
        }

        private async void OnEditCommand(Entities.AccessProfile obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                IsBusy = true;
                base.ClearCustomErrors();
                var parameters = new Entities.GetParametersWithPhoto
                {
                    IncludeMemberCollections = true,
                    IncludePhoto = true,
                    UniqueId = obj.AccessProfileUid
                };
                var mgr = _clientServices.GetManager<SDK.Managers.AccessProfileManager>();
                var ap = await mgr.GetAccessProfileAsync(parameters);

                if (mgr.HasErrors)
                {
                    base.AddCustomErrors(mgr.Errors, true);
                }
                else
                {
                }

                IsBusy = false;
                CurrentItemViewModel = new EditAccessProfileViewModel(_eventAggregator, _clientServices, ap, Guid.Empty, AccessProfileEditingData);
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanUpdateId);
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.AccessProfile()
            {
                EntityId = _clientServices.CurrentEntityId
            };
            CurrentItemViewModel = new EditAccessProfileViewModel(_eventAggregator, _clientServices, o, Guid.Empty, AccessProfileEditingData);
        }


        private bool OnDeleteCommandCanExecute(Entities.AccessProfile obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanDeleteId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
        }

        private void OnDeleteCommand(Entities.AccessProfile entity)
        {
            ClearCustomErrors();
            _deleteThisAccessProfile = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainAccessProfiles_AreYouSureDeleteAccessProfile,
                _deleteThisAccessProfile.AccessProfileName);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainAccessProfiles_YesDeleteAccessProfile,
                _deleteThisAccessProfile);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainAccessProfiles_NoDeleteAccessProfile,
                _deleteThisAccessProfile);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                int numberDeleted = 0;
                var mgr = _clientServices.GetManager<SDK.Managers.AccessProfileManager>();

                var parameters = new Entities.DeleteParameters()
                {
                    UniqueId = _deleteThisAccessProfile.AccessProfileUid,
                    SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = mgr.DeleteAccessProfileByUniqueId(parameters);
                }
                else
                {
                    numberDeleted = await mgr.DeleteAccessProfileByUniqueIdAsync(parameters);
                }

                if (mgr.HasErrors == false)
                {
                    var p = AccessProfiles.FirstOrDefault(o => o.AccessProfileUid == _deleteThisAccessProfile.AccessProfileUid);
                    if (p != null)
                        AccessProfiles.Remove(p);
                }
            }
            else
                _deleteThisAccessProfile = null;
        }

        #endregion

        #region Public Properties

        public EditAccessProfileViewModel CurrentItemViewModel
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


        public ObservableCollection<GalaxySMS.Client.Entities.AccessProfile> AccessProfiles
        {
            get { return _AccessProfiles; }
            set
            {
                if (_AccessProfiles != value)
                {
                    _AccessProfiles = value;
                    OnPropertyChanged(() => AccessProfiles, false);
                }
            }
        }


        public Entities.AccessProfileEditingData AccessProfileEditingData
        {
            get { return _accessProfileEditingData; }
            set
            {
                if (_accessProfileEditingData != value)
                {
                    _accessProfileEditingData = value;
                    OnPropertyChanged(() => AccessProfileEditingData, false);
                }
            }
        }

        public KeyValuePair<int, string> GridPageSize
        {
            get { return _gridPageSize; }
            set
            {
                _gridPageSize = value;
                OnPropertyChanged(() => GridPageSize, false);
            }
        }

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
                if (AccessProfiles == null)
                    return 0;
                return AccessProfiles.Count;
            }
            set { OnPropertyChanged(() => TotalRecordCount, false); }
        }

        #endregion

        #region Public Events

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        #endregion

        #region Public Commands

        public DelegateCommand<Entities.AccessProfile> EditCommand { get; private set; }
        public DelegateCommand<Entities.AccessProfile> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }

        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            if (_bOnViewLoadedAlreadyCalled == false)
            {
                _bOnViewLoadedAlreadyCalled = true;

                //Task.Run(async () => { await RefreshFromServer(); }).Wait();
                RefreshFromServer();
            }
        }

        private async Task RefreshFromServer()
        {
            IsBusy = true;
            base.ClearCustomErrors();
            AccessProfiles = new ObservableCollection<Client.Entities.AccessProfile>();
            var parameters = new Entities.GetParametersWithPhoto
            {
                IncludeMemberCollections = false,
                IncludePhoto = false,
                PhotoPixelWidth = _clientServices.ThumbnailPixelWidth
            };
            var mgr = _clientServices.GetManager<SDK.Managers.AccessProfileManager>();
            var accessProfiles = await mgr.GetAccessProfilesForEntityAsync(parameters);

            if (mgr.HasErrors)
            {
                base.AddCustomErrors(mgr.Errors, true);
            }
            else
            {
                if (accessProfiles != null)
                {
                    try
                    {
                        CollectionExtensions.AddRange(AccessProfiles, accessProfiles.Items);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Trace.WriteLine(e.ToString());
                    }
                }
            }

            OnPropertyChanged(() => TotalRecordCount, false);

            await FillAccessProfileEditorData();
            IsBusy = false;
        }

        private async Task FillAccessProfileEditorData()
        {
            var manager = _clientServices.GetManager<AccessProfileManager>();
            var parameters = new Entities.GetParametersWithPhoto()
            {
                //SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
                IncludePhoto = true,
                PhotoPixelWidth = _clientServices.ThumbnailPixelWidth,
            };
            parameters.ExcludeMemberCollectionSettings.Add(nameof(Entities.ClusterSelectionItem.AccessPortals));
            parameters.ExcludeMemberCollectionSettings.Add(nameof(Entities.ClusterSelectionItem.TimeSchedules));

            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() => { AccessProfileEditingData = manager.GetAccessProfileEditingData(parameters); }).Wait();
            }
            else
            {
                AccessProfileEditingData = await manager.GetAccessProfileEditingDataAsync(parameters);
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
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