using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using Entities = GalaxySMS.Client.Entities;
using CommonResources = GalaxySMS.Resources;
using System.Linq;
using GalaxySMS.Common.Constants;
using GalaxySMS.Prism.Infrastructure.Events;

namespace GalaxySMS.Region.ViewModels
{
    [Export(typeof(EditRegionViewModel))]
    public class EditRegionViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.Region _Region;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditRegionViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.Region entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _Region = new Entities.Region(entity);
            _Region.CleanAll();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            SelectImageCommand = new DelegateCommand<object>(OnSelectImageCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);

            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);

            IsSaveControlVisible = true;
            IsCancelControlVisible = true;

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditRegionView_ViewTitle;

            UserEntitiesSelectionList = _clientServices.BuildUserEntitiesSelectionList(_Region, _Region.EntityId);

            //if (UserSessionToken != null)
            //{
            //    UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
            //    foreach (var ue in UserEntitiesSelectionList)
            //    {
            //        if (_Region.EntityIds.Contains(ue.EntityId))
            //            ue.Selected = true;
            //        var mapEntity = _Region.MappedEntitiesPermissionLevels.Where(m => m.EntityId == ue.EntityId).FirstOrDefault();
            //        if (mapEntity != null)
            //        {
            //            ue.Selected = true;
            //            ue.EntityMapPermissionLevelUid = mapEntity.EntityMapPermissionLevelUid;
            //        }
            //        ue.IsOwner = (ue.EntityId == Region.EntityId);
            //        if (ue.IsOwner)
            //        {
            //            ue.EntityMapPermissionLevelUid = GalaxySMS.Common.Constants.EntityPermissionLevelIds.PermissionLevel_ViewEditDelete_Id;
            //        }
            //    }
            //}
        }
        #endregion

        private void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            var permissions = new List<Guid>();
            permissions.Add(PermissionIds.GalaxySMSDataAccessPermission.RegionCanAddId);
            permissions.Add(PermissionIds.GalaxySMSDataAccessPermission.RegionCanUpdateId);

            IsSaveControlVisible = UserSessionToken.HasPermission(permissions, Common.Enums.PermissionsCheck.CanHaveAny);

            OnPropertyChanged(() => IsCurrentEntityTheOwner, false);
        }

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> SelectImageCommand { get; private set; }

        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }
        #endregion

        #region Public Properties
        public Entities.Region Region
        {
            get { return _Region; }
        }

        public Guid InstanceId { get; }

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

        private bool _IsCurrentEntityTheOwner;

        public bool IsCurrentEntityTheOwner
        {
            get { return _Region?.EntityId == UserSessionToken?.CurrentEntityId; }
        }

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(Region);
        }

        #endregion

        #region Private Methods

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditRegionView_PleaseWaitWhileISave, Region.RegionName);

                Region.EntityIds.Clear();
                Region.MappedEntitiesPermissionLevels.Clear();

                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == Region.EntityId)
                    {
                        Region.EntityIds.Add(ue.EntityId);
                    }
                }

                IsBusy = true;
                var manager = _clientServices.GetManager<RegionManager>();
                bool isNew = (Region.RegionUid == Guid.Empty);
                Entities.Region savedEntity;
                var parameters = new SaveParameters<Entities.Region>() { SavePhoto = true, Data = Region, 
                    //SessionId = _clientServices.UserSessionToken.SessionId, 
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveRegion(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveRegionAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.Region>>>().Publish(new EntitySavedEventArgs<Entities.Region>()
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
            bool bDirty = _Region.IsDirty;
            foreach (var m in _Region.MappedEntitiesPermissionLevels)
            {
                if (m.IsAnythingDirty())
                    return true;
            }
            return bDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.Region>>>().Publish(new OperationCanceledEventArgs<Entities.Region>()
            {
                Entity = Region,
                OperationId = InstanceId
            });
        }

        private void OnSelectImageCommandExecute(object obj)
        {
            try
            {
                IDialogService dlgService = new DialogService();
                ImageCaptureControl captureControl = new ImageCaptureControl();
                captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_Region.gcsBinaryResource?.BinaryResource);
                captureControl.AutomaticallyScaleDownImage = true;
                captureControl.ScaleToMaximumHeight = 600;
                captureControl.AspectRatio = ImageAspectRatio.Square1X1;
                SetBackgroundSubdued();
                dlgService.ShowRadDialog(captureControl, null, CommonResources.Resources.Dialog_SelectSiteImageTitle);
                ClearBackgroundSubdued();
                if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
                {
                    if (_Region.gcsBinaryResource == null)
                        _Region.gcsBinaryResource = new gcsBinaryResource();
                    _Region.gcsBinaryResource.BinaryResource =
                        ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
                    _Region.MakeDirty();
                }
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("OnSelectEntityImageCommandExecute: {0}", ex.Message);
            }
        }

        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _Region.MakeDirty();
        }
        #endregion
    }
}