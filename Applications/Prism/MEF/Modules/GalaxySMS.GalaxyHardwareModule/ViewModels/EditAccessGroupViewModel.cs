using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
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
using System.Linq;
using System.Threading.Tasks;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;

namespace GalaxySMS.GalaxyHardware.ViewModels
{
    [Export(typeof(EditAccessGroupViewModel))]
    public class EditAccessGroupViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private AccessGroup _AccessGroup;
        private ObservableCollection<AccessGroup> _accessGroups;
        private bool _isBasicInfoExpanded = true;
        private ICollection<UserEntitySelect> _userEntitiesSelectionList;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditAccessGroupViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.AccessGroup entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _AccessGroup = new Entities.AccessGroup(entity);

            if (AccessGroup.AccessGroupUid != Guid.Empty)
                _AccessGroup.CleanAll();

            Task.Run(async () =>
            {
                await FillEditorData();
            }).Wait();

            foreach (var ap in AccessPortals)
            {
                var agap = AccessGroup.AccessPortals.FirstOrDefault(o => o.AccessPortalUid == ap.AccessPortalUid);
                if (agap == null)
                {
                    AccessGroup.AccessPortals.Add(new AccessGroupAccessPortal()
                    {
                        AccessPortalUid = ap.AccessPortalUid,
                        AccessGroupNumber = AccessGroup.AccessGroupNumber,
                        TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never,
                        AccessPortalName = ap.Name
                    });
                }
            }
            SelectedNotAuthorizedAccessPortals = new ObservableCollection<AccessGroupAccessPortal>();
            SelectedAuthorizedAccessPortals = new ObservableCollection<AccessGroupAccessPortal>();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);

            AuthorizedAccessPortalScheduleChanged = new DelegateCommand<TimeSchedule>(OnAuthorizedAccessPortalScheduleChanged);
            NotAuthorizedAccessPortalScheduleChanged = new DelegateCommand<object>(OnNotAuthorizedAccessPortalScheduleChanged);

            ToNotAuthorizedCommand = new DelegateCommand<ObservableCollection<object>>(OnToNotAuthorizedCommand, CanExecuteOnToNotAuthorizedCommand);
            ToAuthorizedCommand = new DelegateCommand<ObservableCollection<object>>(OnToAuthorizedCommand, CanExecuteOnToAuthorizedCommand);

            IsSaveControlVisible = true;
            IsCancelControlVisible = true;

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditAccessGroupView_ViewTitle;
            CurrentItemTitle = _AccessGroup.Display;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_AccessGroup.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }
        }

        private bool CanExecuteOnToAuthorizedCommand(ObservableCollection<object> obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.Count == 0)
                return false;
            return true;
        }

        private void OnToAuthorizedCommand(ObservableCollection<object> obj)
        {
            if (obj == null)
                return;

            var schId = Guid.Empty;//TimeScheduleIds.TimeSchedule_Always;
            if (SelectedAuthorizedTimeSchedule != null && SelectedAuthorizedTimeSchedule.TimeScheduleUid != TimeScheduleIds.TimeSchedule_Never)
                schId = SelectedAuthorizedTimeSchedule.TimeScheduleUid;

            foreach (var i in obj.ToList())
            {
                if (i is AccessGroupAccessPortal)
                    ((AccessGroupAccessPortal)i).TimeScheduleUid = schId;
            }
        }

        private bool CanExecuteOnToNotAuthorizedCommand(ObservableCollection<object> obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.Count == 0)
                return false;
            return true;
        }

        private void OnToNotAuthorizedCommand(ObservableCollection<object> obj)
        {
            if (obj == null)
                return;
            foreach (var i in obj.ToList())
            {
                if (i is AccessGroupAccessPortal)
                    ((AccessGroupAccessPortal)i).TimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
            }
        }

        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }
        public DelegateCommand<TimeSchedule> AuthorizedAccessPortalScheduleChanged { get; set; }
        public DelegateCommand<object> NotAuthorizedAccessPortalScheduleChanged { get; set; }
        public DelegateCommand<ObservableCollection<object>> ToNotAuthorizedCommand { get; set; }
        public DelegateCommand<ObservableCollection<object>> ToAuthorizedCommand { get; set; }

        #endregion

        #region Public Properties

        public ObservableCollection<AccessGroupAccessPortal> SelectedNotAuthorizedAccessPortals
        {
            get
            { return _selectedNotAuthorizedAccessPortals; }
            set
            {
                if (_selectedNotAuthorizedAccessPortals != value)
                {
                    _selectedNotAuthorizedAccessPortals = value;
                    OnPropertyChanged(() => SelectedNotAuthorizedAccessPortals, false);
                }
            }
        }

        public ObservableCollection<AccessGroupAccessPortal> SelectedAuthorizedAccessPortals
        {
            get
            { return _selectedAuthorizedAccessPortals; }
            set
            {
                if (_selectedAuthorizedAccessPortals != value)
                {
                    _selectedAuthorizedAccessPortals = value;
                    OnPropertyChanged(() => SelectedAuthorizedAccessPortals, false);
                }
            }
        }

        public Entities.AccessGroup AccessGroup
        {
            get { return _AccessGroup; }
            set
            {
                if (_AccessGroup != value)
                {
                    _AccessGroup = value;
                    OnPropertyChanged(() => AccessGroup, false);
                }
            }
        }



        public Entities.TimeSchedule SelectedToAuthorizedTimeSchedule
        {
            get { return _selectedToAuthorizedTimeSchedule; }
            set
            {
                if (_selectedToAuthorizedTimeSchedule != value)
                {
                    _selectedToAuthorizedTimeSchedule = value;
                    OnPropertyChanged(() => SelectedToAuthorizedTimeSchedule, false);
                    foreach (var i in SelectedNotAuthorizedAccessPortals.ToList())
                    {
                        i.TimeScheduleUid = SelectedToAuthorizedTimeSchedule.TimeScheduleUid;
                    }
                }
            }
        }

        public Entities.TimeSchedule SelectedAuthorizedTimeSchedule
        {
            get { return _selectedAuthorizedTimeSchedule; }
            set
            {
                if (_selectedAuthorizedTimeSchedule != value)
                {
                    _selectedAuthorizedTimeSchedule = value;
                    OnPropertyChanged(() => SelectedAuthorizedTimeSchedule, false);
                    foreach (var i in SelectedAuthorizedAccessPortals.ToList())
                    {
                        i.TimeScheduleUid = SelectedAuthorizedTimeSchedule.TimeScheduleUid;
                    }
                }
            }
        }

        public ObservableCollection<AccessGroup> AccessGroups
        {
            get { return _accessGroups; }
            set
            {
                if (_accessGroups != value)
                {
                    _accessGroups = value;
                    OnPropertyChanged(() => AccessGroups, false);
                }
            }
        }

        public ObservableCollection<AccessGroup> CrisisAccessGroups
        {
            get { return _accessGroups.Where(ag => ag.AccessGroupNumber != (int)GalaxySMS.Common.Enums.AccessGroupNumber.PersonalGroup).ToObservableCollection(); }
            set
            {
                if (_accessGroups != value)
                {
                    _accessGroups = value;
                    OnPropertyChanged(() => AccessGroups, false);
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

        private ObservableCollection<TimeSchedule> _timeSchedulesDef;

        public ObservableCollection<TimeSchedule> TimeSchedulesDef
        {
            get { return _timeSchedulesDef; }
            set
            {
                if (_timeSchedulesDef != value)
                {
                    _timeSchedulesDef = value;
                    OnPropertyChanged(() => TimeSchedulesDef, false);
                }
            }
        }



        private ReadOnlyCollection<AccessPortal> _accessPortals;

        public ReadOnlyCollection<AccessPortal> AccessPortals
        {
            get { return _accessPortals; }
            set
            {
                if (_accessPortals != value)
                {
                    _accessPortals = value;
                    OnPropertyChanged(() => AccessPortals, false);
                }
            }
        }

        public Guid InstanceId { get; }

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(AccessGroup);
            //models.Add(Cluster.Address);
        }
        #endregion

        #region Private Methods

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditAccessGroupView_PleaseWaitWhileISave, AccessGroup.Display);

                AccessGroup.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == _clientServices.CurrentSite.EntityId)
                        AccessGroup.EntityIds.Add(ue.EntityId);
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<GalaxyAccessGroupManager>();
                bool isNew = (AccessGroup.AccessGroupUid == Guid.Empty);
                Entities.AccessGroup savedEntity;
                var parameters = new SaveParameters<Entities.AccessGroup>()
                {
                    Data = AccessGroup,
                    //SessionId = _clientServices.UserSessionToken.SessionId, 
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };

                parameters.Options.Add(new KeyValuePair<string, string>(nameof(GalaxySMS.Common.Enums.SaveAccessGroupAccessPortalsOption).ToString(), SaveAccessGroupAccessPortalsOption.CreateMissingItems.ToString()));

                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveAccessGroup(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveAccessGroupAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AccessGroup>>>().Publish(new EntitySavedEventArgs<Entities.AccessGroup>()
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
            return _AccessGroup.IsAnythingDirty();// IsDirty;// || _Cluster.Address.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.AccessGroup>>>().Publish(new OperationCanceledEventArgs<Entities.AccessGroup>()
            {
                Entity = AccessGroup,
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

        private void OnNotAuthorizedAccessPortalScheduleChanged(object obj)
        {
            //if (SelectedNotAuthorizedAccessPortals == null || SelectedNotAuthorizedAccessPortals.Count == 0)
            //    return;

            //foreach (var i in this.SelectedNotAuthorizedAccessPortals)
            //{
            //    //if (i.AccessGroupAccessPortalUid != obj.AccessGroupAccessPortalUid)
            //        i.TimeScheduleUid = obj.TimeScheduleUid;
            //}
        }

        private void OnAuthorizedAccessPortalScheduleChanged(TimeSchedule obj)
        {
            //if (SelectedAuthorizedAccessPortals == null || SelectedAuthorizedAccessPortals.Count == 0)
            //    return;

            //foreach (var i in SelectedAuthorizedAccessPortals)
            //{
            //    //if (i.AccessGroupAccessPortalUid != obj.AccessGroupAccessPortalUid)
            //        i.TimeScheduleUid = obj.TimeScheduleUid;
            //}
        }
        #endregion

        #region Implementation of ISupportsUserEntitySelection
        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _AccessGroup.MakeDirty();
        }


        async Task FillEditorData()
        {
            IsBusy = true;
            var manager = _clientServices.GetManager<TimeScheduleManager>();
            var parameters = new GetParametersWithPhoto()
            {
                //SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
                UniqueId = AccessGroup.ClusterUid
            };
            parameters.AddOption(GetOptions_TimeSchedule.IncludeBlankSchedule, true);
            if (UseAsyncServiceCalls == false)
            {
                TimeSchedules = manager.GetTimeSchedulesForCluster(parameters, false).Items.ToReadOnlyCollection();
            }
            else
            {
                var ts = await manager.GetTimeSchedulesForClusterAsync(parameters);
                TimeSchedules = ts.Items.ToReadOnlyCollection();
            }

            TimeSchedulesDef = TimeSchedules.Where(o=>o.TimeScheduleUid != Guid.Empty).ToObservableCollection();
            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }

            var apManager = _clientServices.GetManager<AccessPortalManager>();
            var apParameters = new GetParametersWithPhoto()
            {
                //SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
                UniqueId = AccessGroup.ClusterUid,
                IncludePhoto = false,
                IncludeMemberCollections = false
            };
            if (UseAsyncServiceCalls == false)
            {
                AccessPortals = apManager.GetAccessPortalsForCluster(apParameters, false).Items.ToReadOnlyCollection();
            }
            else
            {
                var aps = await apManager.GetAccessPortalsForClusterAsync(apParameters);
                AccessPortals = aps.Items.ToReadOnlyCollection();
            }

            if (apManager.HasErrors)
            {
                AddCustomErrors(apManager.Errors, true);
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
        private ObservableCollection<AccessGroupAccessPortal> _selectedNotAuthorizedAccessPortals;
        private ObservableCollection<AccessGroupAccessPortal> _selectedAuthorizedAccessPortals;
        private TimeSchedule _selectedToAuthorizedTimeSchedule;
        private TimeSchedule _selectedAuthorizedTimeSchedule;

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

