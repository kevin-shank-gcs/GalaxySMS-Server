using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.PersonCredential.ViewModels
{
    [Export(typeof(EditAccessProfileViewModel))]
    public class EditAccessProfileViewModel : ViewModelBase, ISupportsUserEntitySelection
    {

        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.AccessProfile _AccessProfile;
        private AccessProfileEditingData _editingData;
        private bool _isBasicInfoExpanded = true;
        private ICollection<UserEntitySelect> _userEntitiesSelectionList;
        private Entities.AccessProfileCluster _deleteThisClusterPermission;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditAccessProfileViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.AccessProfile entity, Guid instanceId, AccessProfileEditingData editingData)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _editingData = editingData;

            foreach (var pcp in entity.AccessProfileClusters)
            {
                var c = _editingData.AccessAndAlarmControlPermissionsEditingData.GetClusterSelectionItem(pcp.ClusterUid);
                var s = _editingData.AccessAndAlarmControlPermissionsEditingData.GetSiteSelectionItem(c.SiteUid);
                RegionSelectionItemBasic r = null;
                if (s != null)
                    r = _editingData.AccessAndAlarmControlPermissionsEditingData.GetRegionSelectionItem(s.RegionUid);
                pcp.Initialize(c, s, r);
            }

            _AccessProfile = new Entities.AccessProfile(entity);
            _AccessProfile.CleanAll();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);
            AddNewClusterPermissionCommand = new DelegateCommand<ClusterSelectionItemBasic>(OnAddNewClusterPermissionCommandExecute, OnAddNewClusterPermissionCommandCanExecute);
            DeleteClusterPermissionCommand = new DelegateCommand<AccessProfileCluster>(OnDeleteClusterPermissionCommandExecute, OnDeleteClusterPermissionCommandCanExecute);


            IsAddNewClusterPermissionControlVisible = true;

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditAccessProfileView_ViewTitle;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_AccessProfile.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }

            this.SelectEntityHeaderText = string.Format(
                CommonResources.Resources.EditAccessProfileView_EntityMappingTabHeader, EntityAlias);

            this.SelectEntityHeaderToolTip = string.Format(
                CommonResources.Resources.EditAccessProfileView_EntityMappingTabHeaderToolTip, EntityAliasPlural);


        }

        private void OnDeleteClusterPermissionCommandExecute(AccessProfileCluster obj)
        {
            ClearCustomErrors();
            _deleteThisClusterPermission = obj;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainAccessProfiles_AreYouSureDeleteClusterPermission,
                _deleteThisClusterPermission.ClusterName);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainAccessProfiles_YesDeleteClusterPermission, _deleteThisClusterPermission);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainAccessProfiles_NoDeleteClusterPermission, _deleteThisClusterPermission);
            dlgParams.Closed += OnConfirmDeleteClusterPermissionClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClusterPermissionClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                AccessProfile.AccessProfileClusters.Remove(_deleteThisClusterPermission);
            }
            _deleteThisClusterPermission = null;
        }
        private bool OnDeleteClusterPermissionCommandCanExecute(AccessProfileCluster obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanDeleteId) &&
                AccessProfile.EntityId == _clientServices.CurrentEntityId;
        }

        private void OnAddNewClusterPermissionCommandExecute(ClusterSelectionItemBasic obj)
        {
            var existingAccessProfileCluster = AccessProfile.AccessProfileClusters.FirstOrDefault(p => p.ClusterUid == obj.ClusterUid);
            if (existingAccessProfileCluster == null)
            {
                var pcp = new AccessProfileCluster();
                var s = AccessProfileEditingData.AccessAndAlarmControlPermissionsEditingData.GetSiteSelectionItem(obj.SiteUid);
                RegionSelectionItemBasic r = null;
                if (s != null)
                    r = AccessProfileEditingData.AccessAndAlarmControlPermissionsEditingData.GetRegionSelectionItem(s.RegionUid);
                pcp.Initialize(obj, s, r);

                AccessProfile.AccessProfileClusters.Add(pcp);
            }

        }

        private bool OnAddNewClusterPermissionCommandCanExecute(ClusterSelectionItemBasic obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanAddId) &&
                AccessProfile.EntityId == _clientServices.CurrentEntityId &&
                AccessProfile.AccessProfileClusters.FirstOrDefault(o => o.ClusterUid == obj.ClusterUid) == null;
        }


        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }

        public DelegateCommand<ClusterSelectionItemBasic> AddNewClusterPermissionCommand { get; private set; }
        public DelegateCommand<AccessProfileCluster> DeleteClusterPermissionCommand { get; private set; }

        #endregion

        #region Public Properties
        public Entities.AccessProfile AccessProfile
        {
            get { return _AccessProfile; }
        }
        public Entities.AccessProfileEditingData AccessProfileEditingData
        {
            get { return _editingData; }
        }

        public bool IsBasicInfoExpanded
        {
            get { return _isBasicInfoExpanded; }
            set
            {
                if (_isBasicInfoExpanded != value)
                {
                    _isBasicInfoExpanded = value;
                    OnPropertyChanged(() => IsBasicInfoExpanded, false);
                }
            }
        }

        public Guid InstanceId { get; }


        private bool _IsAddNewClusterPermissionControlVisible;

        public bool IsAddNewClusterPermissionControlVisible
        {
            get { return _IsAddNewClusterPermissionControlVisible; }
            set
            {
                if (_IsAddNewClusterPermissionControlVisible != value)
                {
                    _IsAddNewClusterPermissionControlVisible = value;
                    OnPropertyChanged(() => IsAddNewClusterPermissionControlVisible, false);
                }
            }
        }
        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(AccessProfile);
        }

        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();
        }
        #endregion

        #region Private Methods

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditAccessProfileView_PleaseWaitWhileISave, AccessProfile);

                AccessProfile.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == AccessProfile.EntityId)
                        AccessProfile.EntityIds.Add(ue.EntityId);
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<AccessProfileManager>();
                bool isNew = (AccessProfile.AccessProfileUid == Guid.Empty);
                Entities.AccessProfile savedEntity;

                var parameters = new SaveParameters<Entities.AccessProfile>()
                {
                    SavePhoto = true,
                    Data = AccessProfile,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveAccessProfile(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveAccessProfileAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AccessProfile>>>()
                        .Publish(new EntitySavedEventArgs<Entities.AccessProfile>()
                        {
                            Entity = savedEntity,
                            IsNew = isNew
                        });
                }
                else if (manager.HasErrors)
                {
                    AddCustomErrors(manager.Errors, true);
                }
                IsBusy = false;
            }
        }

        private bool OnSaveCommandCanExecute(object arg)
        {
            if (AccessProfile.AccessProfileUid == Guid.Empty)
                return _AccessProfile.IsDirty || _AccessProfile.IsAnythingDirty() &&
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanAddId) &&
                AccessProfile.EntityId == _clientServices.CurrentEntityId;

            return _AccessProfile.IsDirty || _AccessProfile.IsAnythingDirty() &&
                   _clientServices.UserSessionToken.HasPermission(
                       PermissionIds.GalaxySMSDataAccessPermission.AccessProfileCanUpdateId) &&
                   AccessProfile.EntityId == _clientServices.CurrentEntityId;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.AccessProfile>>>().Publish(new OperationCanceledEventArgs<Entities.AccessProfile>()
            {
                Entity = AccessProfile,
                OperationId = InstanceId
            });
        }

        #endregion

        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _AccessProfile.MakeDirty();
        }
        #region Implementation of ISupportsUserEntitySelection

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

        public string EntityAliasPlural
        {
            get { return _clientServices.EntityAliasPlural; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    value = CommonResources.Resources.DefaultEntityAliasPlural;
                if (_clientServices.EntityAliasPlural != value)
                {
                    _clientServices.EntityAliasPlural = value;
                    OnPropertyChanged(() => EntityAliasPlural, false);
                }
            }
        }

        private string _selectEntityHeaderText;

        public string SelectEntityHeaderText
        {
            get { return _selectEntityHeaderText; }
            set
            {
                if (_selectEntityHeaderText != value)
                {
                    _selectEntityHeaderText = value;
                    OnPropertyChanged(() => SelectEntityHeaderText, false);
                }
            }
        }

        private string _selectEntityHeaderToolTip;

        public string SelectEntityHeaderToolTip
        {
            get { return _selectEntityHeaderToolTip; }
            set
            {
                if (_selectEntityHeaderToolTip != value)
                {
                    _selectEntityHeaderToolTip = value;
                    OnPropertyChanged(() => SelectEntityHeaderToolTip, false);
                }
            }
        }

        public UserSessionToken UserSessionToken
        {
            get { return _clientServices?.UserSessionToken; }
        }


        public ICollection<UserEntitySelect> UserEntitiesSelectionList
        {
            get { return _userEntitiesSelectionList; }
            internal set
            {
                _userEntitiesSelectionList = value;
                OnPropertyChanged(() => UserEntitiesSelectionList, false);
            }
        }

        #endregion

    }

}