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
using System.Threading.Tasks;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Utils;

namespace GalaxySMS.Schedule.ViewModels
{
    [Export(typeof(EditScheduleViewModel))]
    public class EditScheduleViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.TimeSchedule _Schedule;
        private bool _isBasicInfoExpanded = true;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditScheduleViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.TimeSchedule entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _Schedule = new Entities.TimeSchedule(entity);

            //foreach (var dttp in _Schedule.DayTypesTimePeriods)
            //{
            //    if (dttp.HighlightColor != 0)
            //        dttp.HighlightColor = ByteFlipper.RotateBytesLeft(dttp.HighlightColor);
            //}
            _Schedule.CleanAll();
            
            CurrentItemTitle = _Schedule.Display;

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);

            MouseWheelFifteenMinuteCommand = new DelegateCommand<MouseWheelInfo>(OnMouseWheelFifteenMinuteCommand);

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditScheduleView_ViewTitle;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_Schedule.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }

            FifteenMinuteZoomFactor = .7;

        }
        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }

        public DelegateCommand<MouseWheelInfo> MouseWheelFifteenMinuteCommand { get; private set; }
        #endregion

        #region Public Properties
        public Entities.TimeSchedule Schedule
        {
            get { return _Schedule; }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.GalaxyTimePeriod> _galaxyTimePeriods;

        public ObservableCollection<GalaxySMS.Client.Entities.GalaxyTimePeriod> GalaxyTimePeriods
        {
            get { return _galaxyTimePeriods; }
            set
            {
                if (_galaxyTimePeriods != value)
                {
                    _galaxyTimePeriods = value;
                    OnPropertyChanged(() => GalaxyTimePeriods, false);
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

        public Double FifteenMinuteZoomFactor
        {
            get { return _fifteenMinuteZoomFactor; }
            set
            {
                if (_fifteenMinuteZoomFactor != value)
                {
                    _fifteenMinuteZoomFactor = value;
                    OnPropertyChanged(() => FifteenMinuteZoomFactor);
                }
            }
        }
        public Guid InstanceId { get; }
        #region Implementation of ISupportsUserEntitySelection

        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _Schedule.MakeDirty();
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
            models.Add(Schedule);
        }
        #endregion

        #region Private Methods

        private void OnMouseWheelFifteenMinuteCommand(MouseWheelInfo obj)
        {
            if (obj.Delta > 0)
            {
                if (FifteenMinuteZoomFactor < 2)
                    FifteenMinuteZoomFactor += .02;
            }
            else
            {
                if (FifteenMinuteZoomFactor > .05)
                    FifteenMinuteZoomFactor -= .02;
            }
            Trace.WriteLine(string.Format("OnMouseWheelFifteenMinuteCommand delta:{0}", obj.Delta));
        }



        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditScheduleView_PleaseWaitWhileISave, Schedule.Display);

                Schedule.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == Schedule.EntityId)
                        Schedule.EntityIds.Add(ue.EntityId);
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<TimeScheduleManager>();
                bool isNew = (Schedule.TimeScheduleUid == Guid.Empty);
                Entities.TimeSchedule savedEntity;
                var parameters = new SaveParameters<Entities.TimeSchedule>()
                {
                    Data = Schedule,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveTimeSchedule(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveTimeScheduleAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.TimeSchedule>>>()
                        .Publish(new EntitySavedEventArgs<Entities.TimeSchedule>()
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
            return _Schedule.IsAnythingDirty();
            //return _Schedule.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.TimeSchedule>>>().Publish(new OperationCanceledEventArgs<Entities.TimeSchedule>()
            {
                Entity = Schedule,
                OperationId = InstanceId
            });
        }


        protected override void OnViewLoaded()
        {
            Task.Run(async () =>
            {
                await RefreshFromServer();
            });
        }

        private async Task RefreshFromServer()
        {
            IsBusy = true;
            base.ClearCustomErrors();
            GalaxyTimePeriods = new ObservableCollection<Client.Entities.GalaxyTimePeriod>();
            var parameters = new Entities.GetParametersWithPhoto();
            parameters.IncludeMemberCollections = false;
            //parameters.IncludePhoto = true;
            var mgr = _clientServices.GetManager<Client.SDK.Managers.GalaxyTimePeriodManager>();
            var tps = mgr.GetGalaxyTimePeriodsForEntity(parameters, false);
            foreach (var s in tps.Items)
                GalaxyTimePeriods.Add(s);

            if (mgr.HasErrors)
            {
                base.AddCustomErrors(mgr.Errors, true);
            }

            parameters.UniqueId = EntityIds.GalaxySMS_SystemEntity_Id;
            tps = mgr.GetGalaxyTimePeriodsForEntity(parameters, false);
            foreach (var s in tps.Items)
                GalaxyTimePeriods.Add(s);

            if (mgr.HasErrors)
            {
                base.AddCustomErrors(mgr.Errors, true);
            }
            IsBusy = false;
        }

        #endregion
    }

}