using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Telerik.Windows.Controls;
using Entities = GalaxySMS.Client.Entities;
using CommonResources = GalaxySMS.Resources;

namespace GalaxySMS.Schedule.ViewModels
{
    [Export(typeof(EditDayPeriodViewModel))]
    public class EditDayPeriodViewModel : GCS.Core.Common.UI.Core.ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private AssaDayPeriod _AssaDayPeriod;
        private TimePeriod _deleteThisTimePeriod = null;

        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditDayPeriodViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.AssaDayPeriod entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _AssaDayPeriod = new Entities.AssaDayPeriod(entity);
            _AssaDayPeriod.CleanAll();

            DeleteCommand = new DelegateCommand<TimePeriod>(OnDeleteCommand, OnDeleteCommandCanExecute);
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);
            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditDayPeriodView_ViewTitle;
            IsSaveDeleteControlSaveVisible = System.Windows.Visibility.Collapsed;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_AssaDayPeriod.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }
        }

        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }
        public DelegateCommand<TimePeriod> DeleteCommand { get; private set; }

        #endregion

        #region Public Properties
        public Entities.AssaDayPeriod AssaDayPeriod
        {
            get { return _AssaDayPeriod; }
        }

        public Guid InstanceId { get; }
        #region Implementation of ISupportsUserEntitySelection

        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _AssaDayPeriod.MakeDirty();
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

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(AssaDayPeriod);
        }
        #endregion

        #region Private Methods

        private bool OnDeleteCommandCanExecute(TimePeriod obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanDeleteId);
        }

        private void OnDeleteCommand(TimePeriod obj)
        {
            ClearCustomErrors();
            _deleteThisTimePeriod = obj;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainDayPeriods_AreYouSureDeleteTimePeriod,
                _deleteThisTimePeriod.Name);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainDayPeriods_YesDeleteTimePeriod, _deleteThisTimePeriod.Name);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainDayPeriods_NoDeleteTimePeriod, _deleteThisTimePeriod.Name);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                //int numberDeleted = 0;
                //var manager = _clientServices.GetManager<SDK.Managers.TimePeriodManager>();
                //var parameters = new Entities.DeleteParameters<Entities.TimePeriod>() { Data = _deleteThisTimePeriod, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                //if (UseAsyncServiceCalls == false)
                //{
                //    numberDeleted = manager.DeleteTimePeriod(parameters);
                //}
                //else
                //{
                //    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                //    numberDeleted = await manager.DeleteTimePeriodAsync(parameters);
                //}
                //if (manager.HasErrors == false)
                AssaDayPeriod.TimePeriods.Remove(_deleteThisTimePeriod);
                AssaDayPeriod.MakeDirty();
            }
            else
                _deleteThisTimePeriod = null;
        }

        private async void OnSaveCommandExecute(object arg)
        {
            if (arg is TimePeriod)
            {
                var timePeriod = arg as TimePeriod;
                if (timePeriod == null)
                    return;
                BusyContent = string.Format(CommonResources.Resources.EditDayPeriodView_PleaseWaitWhileISaveTimePeriod, timePeriod.Name);
                IsBusy = true;
                var manager = _clientServices.GetManager<TimePeriodManager>();
                bool isNew = (timePeriod.TimePeriodUid == Guid.Empty);
                TimePeriod savedEntity;
                var parameters = new SaveParameters<TimePeriod>()
                {
                    Data = timePeriod,
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
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<TimePeriod>>>()
                        .Publish(new EntitySavedEventArgs<TimePeriod>()
                        {
                            Entity = savedEntity,
                            IsNew = isNew
                        });

                    savedEntity.CleanAll();
                    foreach (var tp in AssaDayPeriod.TimePeriods)
                    {
                        if (tp.TimePeriodUid == savedEntity.TimePeriodUid)
                        {
                            AssaDayPeriod.TimePeriods.Remove(tp);
                            AssaDayPeriod.TimePeriods.Add(savedEntity);
                            //ap.Initialize(savedEntity);
                            break;
                        }
                    }
                }
                else if (manager.HasErrors)
                {
                    AddCustomErrors(manager.Errors, true);
                }
                IsBusy = false;
            }
            else
            {
                ValidateModel();

                if (IsValid)
                {
                    BusyContent = string.Format(CommonResources.Resources.EditDayPeriodView_PleaseWaitWhileISave, AssaDayPeriod.Name);

                    AssaDayPeriod.EntityIds.Clear();
                    foreach (var ue in UserEntitiesSelectionList)
                    {
                        if (ue.Selected || ue.EntityId == AssaDayPeriod.EntityId)
                            AssaDayPeriod.EntityIds.Add(ue.EntityId);
                    }

                    IsBusy = true;
                    var manager = _clientServices.GetManager<DayPeriodManager>();
                    bool isNew = (AssaDayPeriod.AssaDayPeriodUid == Guid.Empty);
                    Entities.AssaDayPeriod savedEntity;
                    var parameters = new SaveParameters<Entities.AssaDayPeriod>()
                    {
                        Data = AssaDayPeriod,
                        //SessionId = _clientServices.UserSessionToken.SessionId,
                        CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                    };
                    if (UseAsyncServiceCalls == false)
                    {
                        savedEntity = manager.SaveDayPeriod(parameters);
                    }
                    else
                    {
                        savedEntity = await manager.SaveDayPeriodAsync(parameters);
                    }

                    if (savedEntity != null && manager.HasErrors == false)
                    {
                        _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AssaDayPeriod>>>()
                            .Publish(new EntitySavedEventArgs<Entities.AssaDayPeriod>()
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
        }

        private bool OnSaveCommandCanExecute(object arg)
        {
            if (arg is TimePeriod)
            {
                return ((TimePeriod)arg).IsDirty;
            }

            return _AssaDayPeriod.IsAnythingDirty();// IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.AssaDayPeriod>>>().Publish(new OperationCanceledEventArgs<Entities.AssaDayPeriod>()
            {
                Entity = AssaDayPeriod,
                OperationId = InstanceId
            });
        }
        #endregion
    }

}