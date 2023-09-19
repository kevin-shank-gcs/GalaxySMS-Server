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
using System.Collections.ObjectModel;

namespace GalaxySMS.GalaxyHardware.ViewModels
{
    [Export]
    [Export(typeof(EditGalaxyFlashImageViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EditGalaxyFlashImageViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private GalaxyFlashImage _GalaxyFlashImage;

        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditGalaxyFlashImageViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.GalaxyFlashImage entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _GalaxyFlashImage = new Entities.GalaxyFlashImage(entity);

            if (entity.GalaxyFlashImageUid != Guid.Empty)
            {
                _GalaxyFlashImage.CleanAll();
            }

            FillEditorData();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);

            IsSaveControlVisible = true;
            IsCancelControlVisible = true;

            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditGalaxyFlashImageView_ViewTitle;
            CurrentItemTitle = _GalaxyFlashImage.Description;

        }
        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }
        #endregion

        #region Public Properties

        public Entities.GalaxyFlashImage GalaxyFlashImage
        {
            get { return _GalaxyFlashImage; }
            set
            {
                if (_GalaxyFlashImage != value)
                {
                    _GalaxyFlashImage = value;
                    OnPropertyChanged(() => GalaxyFlashImage, false);
                }
            }
        }

        public Guid InstanceId { get; }

        private ReadOnlyCollection<GalaxyCpuModel> _cpuModels;

        public ReadOnlyCollection<GalaxyCpuModel> CpuModels
        {
            get { return _cpuModels; }
            set
            {
                if (_cpuModels != value)
                {
                    _cpuModels = value;
                    OnPropertyChanged(() => CpuModels, false);
                }
            }
        }

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(GalaxyFlashImage);
            //models.Add(GalaxyFlashImage.Address);
        }
        #endregion

        #region Private Methods

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditGalaxyFlashImageView_PleaseWaitWhileISave, GalaxyFlashImage.Description);

                IsBusy = true;
                var manager = _clientServices.GetManager<GalaxyFlashImageManager>();
                bool isNew = (GalaxyFlashImage.GalaxyFlashImageUid == Guid.Empty);
                Entities.GalaxyFlashImage savedEntity;
                var parameters = new SaveParameters<Entities.GalaxyFlashImage>() { Data = GalaxyFlashImage};//, 
                    //SessionId = _clientServices.UserSessionToken.SessionId };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveGalaxyFlashImage(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveGalaxyFlashImageAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.GalaxyFlashImage>>>().Publish(new EntitySavedEventArgs<Entities.GalaxyFlashImage>()
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
            return _GalaxyFlashImage.IsDirty;// || _GalaxyFlashImage.Address.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.GalaxyFlashImage>>>().Publish(new OperationCanceledEventArgs<Entities.GalaxyFlashImage>()
            {
                Entity = GalaxyFlashImage,
                OperationId = InstanceId
            });
        }
        async void FillEditorData()
        {
            IsBusy = true;
            var manager = _clientServices.GetManager<GalaxyCpuModelManager>();
            var parameters = new GetParametersWithPhoto() { //SessionId = _clientServices.UserSessionToken.SessionId, 
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
            if (UseAsyncServiceCalls == false)
            {
                CpuModels = manager.GetAllGalaxyCpuModels(parameters);
            }
            else
            {
                CpuModels = await manager.GetAllGalaxyCpuModelsAsync(parameters);
            }

            if (manager.HasErrors)
            {
                AddCustomErrors(manager.Errors, true);
            }
            IsBusy = false;
        }

        #endregion

        public void OnImportsSatisfied()
        {

        }
    }
}

