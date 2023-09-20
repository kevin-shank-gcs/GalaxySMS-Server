using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Schedule.Support;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Entities = GalaxySMS.Client.Entities;
using CommonResources = GalaxySMS.Resources;

namespace GalaxySMS.Schedule.ViewModels
{
    [Export(typeof(EditGalaxyTimePeriodViewModel))]
    public class EditGalaxyTimePeriodViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.GalaxyTimePeriod _GalaxyTimePeriod;
        private bool _isBasicInfoExpanded = true;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditGalaxyTimePeriodViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.GalaxyTimePeriod entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _GalaxyTimePeriod = new Entities.GalaxyTimePeriod(entity);
            _GalaxyTimePeriod.CleanAll();
            
            CurrentItemTitle = _GalaxyTimePeriod.Display;

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);

            MouseWheelOneMinuteCommand = new DelegateCommand<MouseWheelInfo>(OnMouseWheelOneMinuteCommand);

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditGalaxyTimePeriodView_ViewTitle;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_GalaxyTimePeriod.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }

            OneMinuteZoomFactor = .7;
            TimeIntervalResolution = TimeInterval.Resolution.Minute;
            ItemsPerTimeEditorRow = 60;
        }
        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }
        public DelegateCommand<MouseWheelInfo> MouseWheelOneMinuteCommand { get; private set; }
        #endregion

        #region Public Properties
        public Entities.GalaxyTimePeriod GalaxyTimePeriod
        {
            get { return _GalaxyTimePeriod; }
        }

        public TimeInterval.Resolution TimeIntervalResolution
        {
            get { return _timeIntervalResolution; }
            set
            {
                if (_timeIntervalResolution != value)
                {
                    _timeIntervalResolution = value;
                    OnPropertyChanged(() => TimeIntervalResolution, false);
                }
            }
        }
        public int ItemsPerTimeEditorRow
        {
            get { return _itemsPerTimeEditorRow; }
            set
            {
                if (_itemsPerTimeEditorRow != value)
                {
                    _itemsPerTimeEditorRow = value;
                    OnPropertyChanged(() => ItemsPerTimeEditorRow, false);
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

        //public ObservableCollection<TimeInterval> TestFifteenMinuteTimeIntervals { get; set; }
        //public ObservableCollection<TimeInterval> TestOneMinuteTimeIntervals { get; set; }

        public Double OneMinuteZoomFactor
        {
            get { return _oneMinuteZoomFactor; }
            set
            {
                if (_oneMinuteZoomFactor != value)
                {
                    _oneMinuteZoomFactor = value;
                    OnPropertyChanged(() => OneMinuteZoomFactor);
                }
            }
        }

        public Guid InstanceId { get; }
        #region Implementation of ISupportsUserEntitySelection

        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _GalaxyTimePeriod.MakeDirty();
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
        private double _oneMinuteZoomFactor;
        private double _fifteenMinuteZoomFactor;
        private TimeInterval.Resolution _timeIntervalResolution;
        private int _itemsPerTimeEditorRow;

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

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(GalaxyTimePeriod);
        }
        #endregion

        #region Private Methods

        private void OnMouseWheelOneMinuteCommand(MouseWheelInfo obj)
        {
            if (obj.Delta > 0)
            {
                if (OneMinuteZoomFactor < 2)
                    OneMinuteZoomFactor += .05;
            }
            else
            {
                if (OneMinuteZoomFactor > .25)
                    OneMinuteZoomFactor -= .05;
            }
            Trace.WriteLine(string.Format("OnMouseWheelOneMinuteCommand delta:{0}", obj.Delta));
        }

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditGalaxyTimePeriodView_PleaseWaitWhileISave, GalaxyTimePeriod.Display);

                GalaxyTimePeriod.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == GalaxyTimePeriod.EntityId)
                        GalaxyTimePeriod.EntityIds.Add(ue.EntityId);
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<GalaxyTimePeriodManager>();
                bool isNew = (GalaxyTimePeriod.GalaxyTimePeriodUid == Guid.Empty);
                Entities.GalaxyTimePeriod savedEntity;
                var parameters = new SaveParameters<Entities.GalaxyTimePeriod>()
                {
                    Data = GalaxyTimePeriod,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveGalaxyTimePeriod(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveGalaxyTimePeriodAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.GalaxyTimePeriod>>>()
                        .Publish(new EntitySavedEventArgs<Entities.GalaxyTimePeriod>()
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
            return _GalaxyTimePeriod.IsAnythingDirty();
            //return _Schedule.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.GalaxyTimePeriod>>>().Publish(new OperationCanceledEventArgs<Entities.GalaxyTimePeriod>()
            {
                Entity = GalaxyTimePeriod,
                OperationId = InstanceId
            });
        }
       #endregion
    }

}