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
    [Export(typeof(EditTimePeriodViewModel))]
    public class EditTimePeriodViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.TimePeriod _timePeriod;
        private bool _isBasicInfoExpanded = true;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditTimePeriodViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.TimePeriod entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _timePeriod = new Entities.TimePeriod(entity);
            _timePeriod.CleanAll();
            
            CurrentItemTitle = _timePeriod.Name;

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);

            MouseWheelOneMinuteCommand = new DelegateCommand<MouseWheelInfo>(OnMouseWheelOneMinuteCommand);

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditTimePeriodView_ViewTitle;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_timePeriod.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }

            OneMinuteZoomFactor = 1;

        }
        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }
        public DelegateCommand<MouseWheelInfo> MouseWheelOneMinuteCommand { get; private set; }
        #endregion

        #region Public Properties
        public Entities.TimePeriod TimePeriod
        {
            get { return _timePeriod; }
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
            _timePeriod.MakeDirty();
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
            models.Add(TimePeriod);
        }
        #endregion

        #region Private Methods

        private void OnMouseWheelOneMinuteCommand(MouseWheelInfo obj)
        {
            if (obj.Delta > 0)
            {
                if (OneMinuteZoomFactor < 2)
                    OneMinuteZoomFactor += .02;
            }
            else
            {
                if (OneMinuteZoomFactor > .05)
                    OneMinuteZoomFactor -= .02;
            }
            Trace.WriteLine(string.Format("OnMouseWheelOneMinuteCommand delta:{0}", obj.Delta));
        }

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditTimePeriodView_PleaseWaitWhileISave, TimePeriod.Name);

                TimePeriod.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == TimePeriod.EntityId)
                        TimePeriod.EntityIds.Add(ue.EntityId);
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<TimePeriodManager>();
                bool isNew = (TimePeriod.TimePeriodUid == Guid.Empty);
                Entities.TimePeriod savedEntity;
                var parameters = new SaveParameters<Entities.TimePeriod>()
                {
                    Data = TimePeriod,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveTimePeriod(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveTimePeriodAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.TimePeriod>>>()
                        .Publish(new EntitySavedEventArgs<Entities.TimePeriod>()
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
            return _timePeriod.IsAnythingDirty();
            //return _Schedule.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.TimePeriod>>>().Publish(new OperationCanceledEventArgs<Entities.TimePeriod>()
            {
                Entity = TimePeriod,
                OperationId = InstanceId
            });
        }
       #endregion
    }

}