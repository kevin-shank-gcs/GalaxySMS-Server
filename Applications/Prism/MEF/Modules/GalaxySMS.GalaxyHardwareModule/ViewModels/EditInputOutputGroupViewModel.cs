using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;

namespace GalaxySMS.GalaxyHardware.ViewModels
{
    [Export(typeof(EditInputOutputGroupViewModel))]
    public class EditInputOutputGroupViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private InputOutputGroup _InputOutputGroup;

        private bool _isBasicInfoExpanded = true;

        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditInputOutputGroupViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.InputOutputGroup entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _InputOutputGroup = new Entities.InputOutputGroup(entity);
            _InputOutputGroup.CleanAll();

            if (_InputOutputGroup.InputOutputGroupUid == Guid.Empty)
                MakeDirty();

            FillEditorData();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            //SelectImageCommand = new DelegateCommand<object>(OnSelectImageCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);

            IsSaveControlVisible = true;
            IsCancelControlVisible = true;

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditClusterView_ViewTitle;
            CurrentItemTitle = _InputOutputGroup.Display;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_InputOutputGroup.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }
        }


        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }
        #endregion

        #region Public Properties
        public Entities.InputOutputGroup InputOutputGroup
        {
            get { return _InputOutputGroup; }
            set
            {
                if (_InputOutputGroup != value)
                {
                    _InputOutputGroup = value;
                    OnPropertyChanged(() => InputOutputGroup, false);
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

        private ReadOnlyCollection<TimeSchedule> _timeSchedules;

        public ReadOnlyCollection<TimeSchedule> TimeSchedules
        {
            get { return _timeSchedules; }
            set
            {
                if (_timeSchedules != value)
                {
                    _timeSchedules = value;
                    OnPropertyChanged(() => TimeSchedules, false);
                }
            }
        }

        public Guid InstanceId { get; }

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(InputOutputGroup);
            //models.Add(Cluster.Address);
        }
        #endregion

        #region Private Methods

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditInputOutputGroupView_PleaseWaitWhileISave, InputOutputGroup.Display);

                InputOutputGroup.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == _clientServices.CurrentSite.EntityId)
                        InputOutputGroup.EntityIds.Add(ue.EntityId);
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<GalaxyInputOutputGroupManager>();
                bool isNew = (InputOutputGroup.InputOutputGroupUid == Guid.Empty);
                Entities.InputOutputGroup savedEntity;
                var parameters = new SaveParameters<Entities.InputOutputGroup>()
                {
                    Data = InputOutputGroup,
                    //SessionId = _clientServices.UserSessionToken.SessionId, 
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveInputOutputGroup(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveInputOutputGroupAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.InputOutputGroup>>>().Publish(new EntitySavedEventArgs<Entities.InputOutputGroup>()
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
            return _InputOutputGroup.IsDirty;// || _Cluster.Address.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.InputOutputGroup>>>().Publish(new OperationCanceledEventArgs<Entities.InputOutputGroup>()
            {
                Entity = InputOutputGroup,
                OperationId = InstanceId
            });
        }

        //private void OnSelectImageCommandExecute(object obj)
        //{
        //    try
        //    {
        //        IDialogService dlgService = new DialogService();
        //        ImageCaptureControl captureControl = new ImageCaptureControl();
        //        captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_Cluster.gcsBinaryResource?.BinaryResource);
        //        captureControl.AutomaticallyScaleDownImage = true;
        //        captureControl.ScaleToMaximumHeight = 600;
        //        captureControl.AspectRatio = ImageAspectRatio.Square1X1;
        //        SetBackgroundSubdued();
        //        dlgService.ShowRadDialog(captureControl, null, CommonResources.Resources.Dialog_SelectClusterImageTitle);
        //        ClearBackgroundSubdued();
        //        if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
        //        {
        //            if (_Cluster.gcsBinaryResource == null)
        //                _Cluster.gcsBinaryResource = new gcsBinaryResource();
        //            _Cluster.gcsBinaryResource.BinaryResource =
        //                ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
        //            _Cluster.MakeDirty();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().DebugFormat("OnSelectImageCommandExecute: {0}", ex.Message);
        //    }
        //}
        #endregion


        #region Implementation of ISupportsUserEntitySelection
        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _InputOutputGroup.MakeDirty();
        }

        async void FillEditorData()
        {
            IsBusy = true;
            var manager = _clientServices.GetManager<TimeScheduleManager>();
            var parameters = new GetParametersWithPhoto()
            { //SessionId = _clientServices.UserSessionToken.SessionId, 
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
                UniqueId = InputOutputGroup.ClusterUid
            };
            if (UseAsyncServiceCalls == false)
            {
                TimeSchedules = manager.GetTimeSchedulesForCluster(parameters, false).Items.ToReadOnlyCollection();
            }
            else
            {
                var ts = await manager.GetTimeSchedulesForClusterAsync(parameters);
                TimeSchedules = ts.Items.ToReadOnlyCollection();
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            IsBusy = false;
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

