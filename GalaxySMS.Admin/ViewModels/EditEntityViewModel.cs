using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Media;
using System.Linq;
using System.Threading.Tasks;
using GalaxySMS.Admin.Properties;
using GalaxySMS.Admin.Support;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.Imaging;
using CommonResources = GalaxySMS.Resources;
using GCS.Framework.Licensing;

namespace GalaxySMS.Admin.ViewModels
{
    public class EditEntityViewModel : ViewModelBase
    {
        public EditEntityViewModel(IServiceFactory serviceFactory, gcsEntity entity, IEnumerable<gcsEntity> entities)
        {
            _ServiceFactory = serviceFactory;

            // Filter out the System Entity and the Entity itself. Neither can be used as the Parent Entity
            Entities = entities.Where(o => o.EntityId != GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id && o.EntityId != entity.EntityId).ToObservableCollection();

            _Entity = new gcsEntity(entity);
            _Entity.CleanAll();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            SelectEntityImageCommand = new DelegateCommand<object>(OnSelectEntityImageCommandExecute);
            SynchronizeIdProducerCommand = new DelegateCommand<object>(OnSynchronizeIdProducerCommandExecute, OnSynchronizeIdProducerCommandCanExecute);
            DeleteEntityApplicationCommand = new DelegateCommand<gcsApplication>(OnDeleteEntityApplicationCommand);
            AddEntityApplicationCommand = new DelegateCommand<gcsApplication>(OnAddEntityApplicationCommand);

            DeleteApplicationRoleCommand = new DelegateCommand<gcsRole>(OnDeleteApplicationRoleCommand);
            AddApplicationRoleCommand = new DelegateCommand<gcsRole>(OnAddApplicationRoleCommand);

            _EntityManager = new EntityManager(Globals.Instance.ServerConnections[0]);
            _EntityManager.SaveEntityCompletedEvent += _EntityManager_SaveEntityCompletedEvent;
            _EntityManager.ErrorsOccurredEvent += _EntityManager_ErrorsOccurredEvent;

            CreateGridPageSizes();

            Task.Run(async () =>
            {
                await GetPropertySensitivityLevels();

            }).Wait();

            if (entity?.EntityId != Guid.Empty)
            {
                Task.Run(async () =>
                {
                    await GetEntityUserDefinedProperties();

                });
            }

            Task.Run(async () =>
            {
                await FillEditorData();

            }).Wait();

        }


        private void _EntityManager_ErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (CustomError error in e.Errors)
            {
                AddCustomError(error);
            }
            Globals.Instance.IsBusy = false;
        }

        private void _EntityManager_SaveEntityCompletedEvent(object sender, SaveEntityCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.Entity != null)
                {
                    _Entity = e.Entity;
                    if (EntityUpdated != null)
                        EntityUpdated(this, new EntityEventArgs(e.Entity, e.IsNew));
                }
                Globals.Instance.IsBusy = false;
            });
        }

        private IServiceFactory _ServiceFactory;
        private EntityManager _EntityManager;
        private gcsEntity _Entity;
        private gcsApplication _currentApplication;
        private UserInterfacePageControlData _userInterfacePageControlData;

        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> SelectEntityImageCommand { get; private set; }

        public DelegateCommand<gcsApplication> AddEntityApplicationCommand { get; private set; }

        public DelegateCommand<gcsApplication> DeleteEntityApplicationCommand { get; private set; }

        public DelegateCommand<gcsRole> DeleteApplicationRoleCommand { get; private set; }

        public DelegateCommand<gcsRole> AddApplicationRoleCommand { get; private set; }

        public event EventHandler CancelEditEntity;

        public event EventHandler<EntityEventArgs> EntityUpdated;

        public gcsEntity Entity
        {
            get { return _Entity; }
        }
        public DelegateCommand<object> SynchronizeIdProducerCommand { get; private set; }

        public IEnumerable<gcsEntity> Entities
        {
            get; set;
        }

        private EntityEditingData _entityEditingData;

        public EntityEditingData EntityEditingData
        {
            get { return _entityEditingData; }
            set
            {
                if (_entityEditingData != value)
                {
                    _entityEditingData = value;
                    OnPropertyChanged(() => EntityEditingData, false);
                }
            }
        }


        public ObservableCollection<PropertySensitivityLevel> PropertySensitivityLevels { get; set; }

        public UserInterfacePageControlData UserInterfacePageControlData
        {
            get { return _userInterfacePageControlData; }
            set
            {
                if (_userInterfacePageControlData != value)
                {
                    _userInterfacePageControlData = value;
                    OnPropertyChanged(() => UserInterfacePageControlData, false);
                }

            }
        }


        public gcsApplication CurrentApplication
        {
            get { return _currentApplication; }
            set
            {
                if (_currentApplication != value)
                {
                    _currentApplication = value;
                    OnPropertyChanged(() => CurrentApplication, false);
                }
            }
        }

        private KeyValuePair<int, string> _gridPageSize;

        public KeyValuePair<int, string> GridPageSize
        {
            get { return _gridPageSize; }
            set
            {
                _gridPageSize = value;
                OnPropertyChanged(() => GridPageSize, false);
            }
        }

        private ObservableCollection<KeyValuePair<int, string>> _gridPageSizes;

        public ObservableCollection<KeyValuePair<int, string>> GridPageSizes
        {
            get { return _gridPageSizes; }
            set
            {
                if (_gridPageSizes != value)
                {
                    _gridPageSizes = value;
                    OnPropertyChanged(() => GridPageSizes, false);
                }
            }
        }

        public int TotalRecordCount
        {
            get
            {
                if (UserInterfacePageControlData?.ControlProperties == null)
                    return 0;
                return UserInterfacePageControlData.ControlProperties.Count;
            }
            set
            {
                OnPropertyChanged(() => TotalRecordCount, false);
            }
        }

        public bool IsLicenseValid
        {
            get
            {
                if (this.Entity.TheLicense != null)
                {
                    var ld = new LicenseData();
                    ld.InitializeFromXmlString(Entity.PublicKey, Entity.License);
                    return ld.IsLicenseValid;
                }
                return false;
            }
        }

        public Brush LicenseBorderBrush
        {
            get
            {
                if (IsLicenseValid)
                    return new SolidColorBrush(Colors.AntiqueWhite);
                return new SolidColorBrush(Colors.Red);
            }
        }

        private void OnAddEntityApplicationCommand(gcsApplication obj)
        {
            obj.IsAuthorized = true;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            //Entity.AllApplications.Remove(obj);
            //Entity.AllApplications.Add(obj);
            Entity.MakeDirty();
        }

        private void OnDeleteEntityApplicationCommand(gcsApplication obj)
        {
            obj.IsAuthorized = false;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            //Entity.AllApplications.Remove(obj);
            //Entity.AllApplications.Add(obj);
            Entity.MakeDirty();
        }

        private void OnAddApplicationRoleCommand(gcsRole obj)
        {
            obj.IsAuthorized = true;

            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            //CurrentApplication.AllRoles.Remove(obj);
            //CurrentApplication.AllRoles.Add(obj);
            Entity.MakeDirty();
        }

        private void OnDeleteApplicationRoleCommand(gcsRole obj)
        {
            obj.IsAuthorized = false;
            // Must Remove then add to get the grid to refresh
            // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
            //CurrentApplication.AllRoles.Remove(obj);
            //CurrentApplication.AllRoles.Add(obj);
            Entity.MakeDirty();
        }

        private void CreateGridPageSizes()
        {
            GridPageSizes = new ObservableCollection<KeyValuePair<int, string>>();

            for (int key = 0; key < 50; key += 10)
            {
                if (key == 0)
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, CommonResources.Resources.PageSize_AllText));
                }
                else
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, key.ToString()));
                }
            }

            foreach (var s in GridPageSizes)
            {
                if (s.Key == 20)
                {
                    GridPageSize = s;
                    break;
                }
            }
        }


        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(Entity);
        }

        async Task FillEditorData()
        {
            IsBusy = true;
            var parameters = new GetParametersWithPhoto() {UniqueId = Entity.EntityId};
            if (UseAsyncServiceCalls == false)
            {
                EntityEditingData = _EntityManager.GetEntityEditingData(parameters);
            }
            else
            {
                EntityEditingData = await _EntityManager.GetEntityEditingDataAsync(parameters);
            }

            if (_EntityManager.HasErrors)
            {
                AddCustomErrors(_EntityManager.Errors, true);
            }
            IsBusy = false;
        }

        private async Task GetPropertySensitivityLevels()
        {
            var manager = new PropertySensitivityLevelManager(Globals.Instance.ServerConnections[0]);

            var parameters = new GetParametersWithPhoto()
            {
                //              SessionId = manager.ClientUserSessionData.SessionGuid,
                CurrentEntityId = Entity.EntityId,
                IncludeMemberCollections = false
            };
            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() =>
                {
                    PropertySensitivityLevels = manager.GetAllPropertySensitivityLevels(parameters).ToObservableCollection();
                }).Wait();
            }
            else
            {
                var data = await manager.GetAllPropertySensitivityLevelsAsync(parameters);
                PropertySensitivityLevels = data.ToObservableCollection();
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
        }

        private async Task GetEntityUserDefinedProperties()
        {
            var manager = new PersonManager(Globals.Instance.ServerConnections[0]);

            var parameters = new GetParametersWithPhoto()
            {
                //SessionId = manager.ClientUserSessionData.SessionGuid,
                CurrentEntityId = Entity.EntityId,
                IncludeMemberCollections = true
            };
            if (UseAsyncServiceCalls == false)
            {
                Task.Run(() =>
                {
                    UserInterfacePageControlData = manager.GetPersonUserInterfacePageControlData(parameters);
                }).Wait();
            }
            else
            {
                UserInterfacePageControlData = await manager.GetPersonUserInterfacePageControlDataAsync(parameters);
            }

            if (this.PropertySensitivityLevels != null && UserInterfacePageControlData != null)
            {
                foreach (var p in UserInterfacePageControlData.ControlProperties)
                {
                    p.SensitivityLevels = this.PropertySensitivityLevels.ToObservableCollection();
                }
                UserInterfacePageControlData.CleanAll();
            }

            OnPropertyChanged(() => TotalRecordCount, false);

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
        }

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                Globals.Instance.IsBusy = true;
                if (_Entity.IsDirty || _Entity.UserRequirements.IsDirty)
                {
                    bool isNew = (_Entity.EntityId == Guid.Empty);
                    if (UseAsyncServiceCalls == false)
                    {
                        var savedEntity = _EntityManager.SaveEntity(_Entity);
                        if (savedEntity != null)
                        {
                            if (EntityUpdated != null)
                                EntityUpdated(this, new EntityEventArgs(savedEntity, isNew));
                        }
                        Globals.Instance.IsBusy = false;
                    }
                    else
                    {
                        _EntityManager.SaveEntityAsyncWithEvent(_Entity);
                    }
                }
                if (UserInterfacePageControlData != null)
                {
                    if (UserInterfacePageControlData.IsAnythingDirty())
                    {
                        Globals.Instance.IsBusy = true;
                        var dirtyUserDefinedProperties = UserInterfacePageControlData.ControlProperties.Where(o => o.IsAnythingDirty()).ToList();
                        if (dirtyUserDefinedProperties.Count > 0)
                        {
                            var manager = new UserDefinedPropertyManager(Globals.Instance.ServerConnections[0]);
                            var parameters = new SaveParameters<List<UserDefinedProperty>>()
                            {
                                Data = dirtyUserDefinedProperties,
                                //SessionId = manager.ClientUserSessionData.SessionGuid,
                                CurrentEntityId = Entity.EntityId
                            };

                            if (UseAsyncServiceCalls == false)
                            {
                                UserInterfacePageControlData = manager.SaveUserDefinedProperties(parameters);
                                UserInterfacePageControlData.CleanAll();

                            }
                            else
                            {
                                UserInterfacePageControlData = await manager.SaveUserDefinedPropertiesAsync(parameters);
                                UserInterfacePageControlData.CleanAll();

                            }
                            if (manager.HasErrors)
                            {
                                AddCustomErrors(manager.Errors, true);
                            }

                        }
                        Globals.Instance.IsBusy = false;
                    }
                }
            }
        }

        private bool OnSaveCommandCanExecute(object arg)
        {
            if (this.UserInterfacePageControlData != null)
                return _Entity.IsDirty || _Entity.UserRequirements.IsDirty || UserInterfacePageControlData.IsAnythingDirty();
            return _Entity.IsDirty || _Entity.UserRequirements.IsDirty;
        }



        private bool OnSynchronizeIdProducerCommandCanExecute(object obj)
        {
            //          var idProducerKey = this.Entity.TheLicense.ProductFeatures.FirstOrDefault(o => o.name == LicenseFeatureKey.BadgingSystemIdProducer.ToString());
            var isIdProducerLicensed = Globals.Instance.MyLicense.GetFeatureValue<bool>(LicenseFeatureKey.BadgingSystemIdProducer.ToString());
            return isIdProducerLicensed && Entity.EntityId != Guid.Empty;
        }

        private async void OnSynchronizeIdProducerCommandExecute(object obj)
        {
            Globals.Instance.IsBusy = true;
            var idProdManager = new IdProducerManager(Globals.Instance.ServerConnections[0]);
            if (UseAsyncServiceCalls == false)
            {
                var saveParams = new SaveParameters<IdProducerSyncSubscriptionAndEntityParameters>()
                {
                    Data = new IdProducerSyncSubscriptionAndEntityParameters()
                    {
                        EntityId = Entity.EntityId
                    }
                };
                var subscriptionData = idProdManager.SyncSubscriptionAndEntity( saveParams);


            }
            else
            {
                var saveParams = new SaveParameters<IdProducerSyncSubscriptionAndEntityParameters>()
                {
                    Data = new IdProducerSyncSubscriptionAndEntityParameters()
                    {
                        EntityId = Entity.EntityId
                    }
                };
                var subscriptionData = await idProdManager.SyncSubscriptionAndEntityAsync( saveParams);


            }
            Globals.Instance.IsBusy = false;
        }




        private void OnCancelCommandExecute(object arg)
        {
            if (CancelEditEntity != null)
                CancelEditEntity(this, EventArgs.Empty);
        }
        private void OnSelectEntityImageCommandExecute(object obj)
        {
            try
            {
                IDialogService dlgService = new DialogService();
                ImageCaptureControl captureControl = new ImageCaptureControl();
                captureControl.Image = ByteArrayToFromImage.ByteArrayToImage(_Entity.gcsBinaryResource.BinaryResource);
                captureControl.AutomaticallyScaleDownImage = true;
                captureControl.ScaleToMaximumHeight = 600;
                captureControl.AspectRatio = ImageAspectRatio.Square1X1;
                SetBackgroundSubdued();
                dlgService.ShowRadDialog(captureControl, null, Properties.Resources.Dialog_SelectCapturePhotoTitle);
                ClearBackgroundSubdued();
                if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
                {
                    _Entity.gcsBinaryResource.BinaryResource = ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
                    _Entity.MakeDirty();
                }
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("OnSelectEntityImageCommandExecute: {0}", ex.Message);
            }
        }

    }
}