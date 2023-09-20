using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Data;
using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Telerik.Windows.Controls;
using static GalaxySMS.Common.Constants.PermissionIds;
using Entities = GalaxySMS.Client.Entities;
using CommonResources = GalaxySMS.Resources;
using SDK = GalaxySMS.Client.SDK;

namespace GalaxySMS.AssaAbloy.ViewModels
{
    [Export(typeof(EditAssaAbloyViewModel))]
    public class EditAssaAbloyViewModel : GCS.Core.Common.UI.Core.ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.AssaDsr _AssaDsr;
        private Entities.AssaAccessPoint _deleteThisAssaAccessPoint = null;

        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditAssaAbloyViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.AssaDsr entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _AssaDsr = new Entities.AssaDsr(entity);
            _AssaDsr.CleanAll();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);
            ImportDsrAccessPointData = new DelegateCommand<object>(OnImportDsrAccessPointDataExecute, OnImportDsrAccessPointDataCanExecute);
            AccessPointSiteChanged = new DelegateCommand<AssaAccessPoint>(OnAssaAccessPointSiteChanged);
            DeleteCommand = new DelegateCommand<object>(OnDeleteCommandExecute, OnDeleteCommandCanExecute);
            ConfirmAccessPointCommand = new DelegateCommand<AssaAccessPoint>(OnConfirmAccessPointCommandExecute, OnConfirmAccessPointCommandCanExecute);
            
            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditAssaDsrView_ViewTitle;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_AssaDsr.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }

            this.SelectEntityHeaderText = string.Format(
                CommonResources.Resources.EditAssaDsrView_EntityMappingTabHeader, EntityAlias);

            this.SelectEntityHeaderToolTip = string.Format(
                CommonResources.Resources.EditAssaDsrView_EntityMappingTabHeaderToolTip, EntityAliasPlural);
        }
     #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<object> DeleteCommand { get; private set; }

        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }

        public DelegateCommand<object> ImportDsrAccessPointData { get; private set; }

        public DelegateCommand<AssaAccessPoint> AccessPointSiteChanged { get; private set; }

        public DelegateCommand<AssaAccessPoint> ConfirmAccessPointCommand { get; private set; }
        #endregion

        #region Public Properties
        public Entities.AssaDsr AssaDsr
        {
            get { return _AssaDsr; }
        }

        public Guid InstanceId { get; }

        public ListCollectionView CurrentEntitySites
        {
            get { return _clientServices.CurrentEntitySites; }
        }

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(AssaDsr);
        }
        #endregion
        
        #region Public Methods
        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _AssaDsr.MakeDirty();
        }
        #endregion

        #region Private Methods

        private async void OnSaveCommandExecute(object arg)
        {
            if (arg is AssaAccessPoint)
            {
                var assaAccessPoint = arg as AssaAccessPoint;
                if (assaAccessPoint == null)
                    return;
                BusyContent = string.Format(CommonResources.Resources.EditAssaDsrView_PleaseWaitWhileISaveAccessPoint, assaAccessPoint.AccessPointName);
                IsBusy = true;
                var manager = _clientServices.GetManager<AssaAccessPointManager>();
                bool isNew = (assaAccessPoint.AssaAccessPointUid == Guid.Empty);
                Entities.AssaAccessPoint savedEntity;
                var parameters = new SaveParameters<Entities.AssaAccessPoint>()
                {
                    Data = assaAccessPoint,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveAssaAccessPoint(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveAssaAccessPointAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AssaAccessPoint>>>()
                        .Publish(new EntitySavedEventArgs<Entities.AssaAccessPoint>()
                        {
                            Entity = savedEntity,
                            IsNew = isNew
                        });

                    savedEntity.CleanAll();
                    foreach (var ap in AssaDsr.AssaAccessPoints)
                    {
                        if (ap.AssaAccessPointUid == savedEntity.AssaAccessPointUid)
                        {
                            AssaDsr.AssaAccessPoints.Remove(ap);
                            AssaDsr.AssaAccessPoints.Add(savedEntity);
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
                    BusyContent = string.Format(CommonResources.Resources.EditAssaDsrView_PleaseWaitWhileISave, AssaDsr.Name);

                    AssaDsr.EntityIds.Clear();
                    foreach (var ue in UserEntitiesSelectionList)
                    {
                        if (ue.Selected || ue.EntityId == AssaDsr.EntityId)
                            AssaDsr.EntityIds.Add(ue.EntityId);
                    }

                    IsBusy = true;
                    var manager = _clientServices.GetManager<AssaDsrManager>();
                    bool isNew = (AssaDsr.AssaDsrUid == Guid.Empty);
                    Entities.AssaDsr savedEntity;
                    var parameters = new SaveParameters<Entities.AssaDsr>()
                    {
                        Data = AssaDsr,
                        //SessionId = _clientServices.UserSessionToken.SessionId,
                        CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                    };
                    if (UseAsyncServiceCalls == false)
                    {
                        savedEntity = manager.SaveAssaDsr(parameters);
                    }
                    else
                    {
                        savedEntity = await manager.SaveAssaDsrAsync(parameters);
                    }

                    if (savedEntity != null && manager.HasErrors == false)
                    {
                        _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AssaDsr>>>()
                            .Publish(new EntitySavedEventArgs<Entities.AssaDsr>()
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
            if (arg is AssaAccessPoint)
            {
                return ((AssaAccessPoint)arg).IsDirty;
            }

            return _AssaDsr.IsAnythingDirty();// IsDirty;
        }

        private bool OnDeleteCommandCanExecute(object obj)
        {
            if (UserSessionToken == null)
                return false;
            return UserSessionToken.HasPermission(GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId);
        }

        private void OnDeleteCommandExecute(object obj)
        {
            ClearCustomErrors();
            if (obj is AssaAccessPoint)
            {
                var entity = obj as AssaAccessPoint;

                _deleteThisAssaAccessPoint = entity;
                var dlgParams = new DialogParameters();
                dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
                dlgParams.Content = string.Format(CommonResources.Resources.MaintainAssaDsrs_AreYouSureDeleteAssaAccessPoint,
                    _deleteThisAssaAccessPoint.AccessPointName);
                dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainAssaDsrs_YesDeleteAssaAccessPoint, _deleteThisAssaAccessPoint.AccessPointName);
                dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainAssaDsrs_NoDeleteAssaAccessPoint, _deleteThisAssaAccessPoint.AccessPointName);
                dlgParams.Closed += OnConfirmDeleteClosed;
                RadWindow.Confirm(dlgParams);
            }
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                int numberDeleted = 0;
                var assaAccessPointManager = _clientServices.GetManager<SDK.Managers.AssaAccessPointManager>();
                var parameters = new Entities.DeleteParameters<Entities.AssaAccessPoint>() { Data = _deleteThisAssaAccessPoint, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = assaAccessPointManager.DeleteAssaAccessPoint(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await assaAccessPointManager.DeleteAssaAccessPointAsync(parameters);
                }
                if (assaAccessPointManager.HasErrors == false)
                    AssaDsr.AssaAccessPoints.Remove(_deleteThisAssaAccessPoint);
            }
            else
                _deleteThisAssaAccessPoint = null;
        }

        private void OnAssaAccessPointSiteChanged(AssaAccessPoint obj)
        {

        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.AssaDsr>>>().Publish(new OperationCanceledEventArgs<Entities.AssaDsr>()
            {
                Entity = AssaDsr,
                OperationId = InstanceId
            });
        }

        private bool OnConfirmAccessPointCommandCanExecute(AssaAccessPoint obj)
        {
            if (obj == null || obj.AccessPoint == null)
                return false;
            return !obj.AccessPoint.confirmed;
        }

        private async void OnConfirmAccessPointCommandExecute(AssaAccessPoint obj)
        {
            BusyContent = string.Format(CommonResources.Resources.EditAssaDsrView_PleaseWaitWhileIConfirmAccessPoint);
            IsBusy = true;
            var manager = _clientServices.GetManager<AssaAccessPointManager>();
            bool isNew = (obj.AssaAccessPointUid == Guid.Empty);
            Entities.AssaAccessPoint savedEntity;
            var parameters = new SaveParameters<Entities.AssaAccessPoint>()
            {
                Data = obj,
                //SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
            };
            if (UseAsyncServiceCalls == false)
            {
                savedEntity = manager.ConfirmAssaAccessPoint(parameters);
            }
            else
            {
                savedEntity = await manager.ConfirmAssaAccessPointAsync(parameters);
            }
        }

        private bool OnImportDsrAccessPointDataCanExecute(object obj)
        {
            return !(_AssaDsr.AssaDsrUid == Guid.Empty);
        }

        private async void OnImportDsrAccessPointDataExecute(object obj)
        {
            BusyContent = string.Format(CommonResources.Resources.EditAssaDsrView_PleaseWaitWhileIImportAccessPointData, AssaDsr.Name);
            IsBusy = true;
            var manager = _clientServices.GetManager<AssaDsrManager>();
            Entities.AssaDsr savedEntity;
            var parameters = new GetParametersWithPhoto()
            {
                UniqueId = AssaDsr.AssaDsrUid,
  //              SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId,
                CurrentSiteUid = _clientServices.CurrentSite.SiteUid,
                IncludeMemberCollections = true
            };

            if (UseAsyncServiceCalls == false)
            {
                savedEntity = manager.ImportAccessPointsFromAssaDsr(parameters);
            }
            else
            {
                savedEntity = await manager.ImportAccessPointsFromAssaDsrAsync(parameters);
            }

            if (savedEntity != null && manager.HasErrors == false)
            {
                AssaDsr.AssaAccessPoints = savedEntity.AssaAccessPoints;
                _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AssaDsr>>>()
                    .Publish(new EntitySavedEventArgs<Entities.AssaDsr>()
                    {
                        Entity = savedEntity,
                        IsNew = false,
                        CloseEditor = false
                    });
            }
            else if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            foreach (var accessPoint in AssaDsr.AssaAccessPoints)
                accessPoint.CleanAll();

            IsBusy = false;
        }
        #endregion

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