using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.Imaging;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;

namespace GalaxySMS.GalaxyHardware.ViewModels
{
    [Export]
    [Export(typeof(EditClusterViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditClusterViewModel : GCS.Core.Common.UI.Core.ViewModelBase, ISupportsUserEntitySelection, IPartImportsSatisfiedNotification
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Cluster _Cluster;

        private bool _isBasicInfoExpanded = true;

        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditClusterViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.Cluster entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _Cluster = new Entities.Cluster(entity);
            _Cluster.CleanAll();

            if (entity.ClusterUid != Guid.Empty)
            {
                InputOutputGroupViewModel = new InputOutputGroupViewModel(eventAggregator, clientServices, _Cluster);
                AccessGroupViewModel = new AccessGroupViewModel(eventAggregator, clientServices, _Cluster);
                AreaViewModel = new AreaViewModel(eventAggregator, clientServices, _Cluster);
                TimeScheduleViewModel = new TimeScheduleViewModel(eventAggregator, clientServices, _Cluster);
                //DayTypeViewModel = new DayTypeViewModel(eventAggregator, clientServices, _Cluster);
                GalaxyPanelViewModel = new GalaxyPanelViewModel(eventAggregator, clientServices, _Cluster);
            }

            FillEditorData();


            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            SelectImageCommand = new DelegateCommand<object>(OnSelectImageCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);

            IsSaveControlVisible = true;
            IsCancelControlVisible = true;

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditClusterView_ViewTitle;
            CurrentItemTitle = _Cluster.ClusterName;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_Cluster.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }
        }
        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<object> SelectImageCommand { get; private set; }
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }
        #endregion

        #region Public Properties

        public Entities.Cluster Cluster
        {
            get { return _Cluster; }
            set
            {
                if (_Cluster != value)
                {
                    _Cluster = value;
                    OnPropertyChanged(() => Cluster, false);
                }
            }
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

        private ClusterEditingData _clusterEditingData;

        public ClusterEditingData ClusterEditingData
        {
            get { return _clusterEditingData; }
            set
            {
                if (_clusterEditingData != value)
                {
                    _clusterEditingData = value;
                    OnPropertyChanged(() => ClusterEditingData, false);
                }
            }
        }

        public Guid InstanceId { get; }

        public InputOutputGroupViewModel InputOutputGroupViewModel { get; private set; }

        public AccessGroupViewModel AccessGroupViewModel { get; private set; }

        public AreaViewModel AreaViewModel { get; private set; }

        public TimeScheduleViewModel TimeScheduleViewModel { get; private set; }

        //public DayTypeViewModel DayTypeViewModel { get; private set; }

        //public DayTypeViewModel TimePeriodViewModel { get; private set; }

        public GalaxyPanelViewModel GalaxyPanelViewModel { get; private set; }

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(Cluster);
            //models.Add(Cluster.Address);
        }
        #endregion

        #region Private Methods

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditClusterView_PleaseWaitWhileISave, Cluster.ClusterName);

                Cluster.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == _clientServices.CurrentSite.EntityId)
                        Cluster.EntityIds.Add(ue.EntityId);
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<ClusterManager>();
                bool isNew = (Cluster.ClusterUid == Guid.Empty);
                Entities.Cluster savedEntity;
                var parameters = new SaveParameters<Entities.Cluster>()
                {
                    SavePhoto = true,
                    Data = Cluster,
                    //SessionId = _clientServices.UserSessionToken.SessionId, 
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveCluster(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveClusterAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.Cluster>>>().Publish(new EntitySavedEventArgs<Entities.Cluster>()
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
            return _Cluster.IsDirty;// || _Cluster.Address.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.Cluster>>>().Publish(new OperationCanceledEventArgs<Entities.Cluster>()
            {
                Entity = Cluster,
                OperationId = InstanceId
            });
        }

        private void OnSelectImageCommandExecute(object obj)
        {
            try
            {
                IDialogService dlgService = new DialogService();
                ImageCaptureControl captureControl = new ImageCaptureControl();
                captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_Cluster.gcsBinaryResource?.BinaryResource);
                captureControl.AutomaticallyScaleDownImage = true;
                captureControl.ScaleToMaximumHeight = 600;
                captureControl.AspectRatio = ImageAspectRatio.Square1X1;
                SetBackgroundSubdued();
                dlgService.ShowRadDialog(captureControl, null, CommonResources.Resources.Dialog_SelectClusterImageTitle);
                ClearBackgroundSubdued();
                if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
                {
                    if (_Cluster.gcsBinaryResource == null)
                        _Cluster.gcsBinaryResource = new gcsBinaryResource();
                    _Cluster.gcsBinaryResource.BinaryResource =
                        ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
                    _Cluster.MakeDirty();
                }
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("OnSelectImageCommandExecute: {0}", ex.Message);
            }
        }

        #endregion

        async void FillEditorData()
        {
            IsBusy = true;
            var manager = _clientServices.GetManager<ClusterManager>();
            var parameters = new GetParametersWithPhoto()
            { //SessionId = _clientServices.UserSessionToken.SessionId, 
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
            };
            if (UseAsyncServiceCalls == false)
            {
                ClusterEditingData = manager.GetClusterEditingData(parameters);
            }
            else
            {
                ClusterEditingData = await manager.GetClusterEditingDataAsync(parameters);
            }

            //ClusterEditingData.TimeZones = _clientServices.GetTimeZones();
            //ClusterEditingData.UnlimitedCredentialTimeoutValues = _clientServices.GetUnlimitedCredentialTimeoutValues();
            //ClusterEditingData.AccessRuleOverrideTimeoutValues = _clientServices.GetAccessRuleOverrideTimeoutValues();

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            IsBusy = false;
        }

        public void OnImportsSatisfied()
        {

        }

        #region Implementation of ISupportsUserEntitySelection
        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _Cluster.MakeDirty();
        }

        public UserSessionToken UserSessionToken
        {
            get { return _clientServices?.UserSessionToken; }
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

        private ICollection<UserEntitySelect> _userEntitiesSelectionList;
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

