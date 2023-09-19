using GalaxySMS.Common.Constants;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Flash;
using GCS.Framework.UI.Telerik.WPF;
using Microsoft.Win32;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;
using LocalResources = GalaxySMS.GalaxyHardware.Properties;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.GalaxyHardware.ViewModels
{
    [Export(typeof(GalaxyFlashImageViewModel))]
    public class GalaxyFlashImageViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditGalaxyFlashImageViewModel _currentGalaxyFlashImageViewModel;
        private Entities.GalaxyFlashImage _deleteThisGalaxyFlashImage = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public GalaxyFlashImageViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            ViewTitle = LocalResources.Resources.GalaxyFlashImageView_ViewTitle;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.GalaxyFlashImage>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.GalaxyFlashImage>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);

            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.GalaxyFlashImage>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.GalaxyFlashImage>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsEditControlVisible = true;
            IsDeleteControlVisible = true;
        }

        #endregion


        #region Private methods

        private void OperationCanceled(OperationCanceledEventArgs<Entities.GalaxyFlashImage> obj)
        {
            if (CurrentGalaxyFlashImageViewModel?.InstanceId == obj.OperationId)
                CurrentGalaxyFlashImageViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.GalaxyFlashImage> obj)
        {
            if (!obj.IsNew)
            {
                var entity = GalaxyFlashImages.FirstOrDefault(item => item.GalaxyFlashImageUid == obj.Entity.GalaxyFlashImageUid);
                if (entity != null)
                {
                    entity.Initialize(obj.Entity);
                }
            }
            else
                GalaxyFlashImages.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentGalaxyFlashImageViewModel = null;
        }

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanViewId) && IsRefreshControlVisible;
        }

        private void OnRefreshCommand(object obj)
        {
            Task.Run(async () =>
            {
                await RefreshFromServer();
            });
        }

        private bool OnEditCommandCanExecute(Entities.GalaxyFlashImage obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId) &&
                IsEditControlVisible;
        }

        private void OnEditCommand(Entities.GalaxyFlashImage obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                CurrentGalaxyFlashImageViewModel = new EditGalaxyFlashImageViewModel(_eventAggregator, _clientServices, obj, Guid.Empty);
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanAddId) && IsAddNewControlVisible;
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "s28 files (*.s28)|*.s28";//|Bin files (*.bin)|*.bin";
                if (openFileDialog.ShowDialog() == true)
                {
                    var flashHelper = new GalaxyFlashImageHelper();
                    if (flashHelper.ReadFlashS28File(openFileDialog.FileName))
                    {
                        var c = new Entities.GalaxyFlashImage();
                        c.Checksum = flashHelper.SumCheckString;
                        c.Description = flashHelper.Description;
                        c.Data = flashHelper.Data;
                        c.DataFormat = Path.GetExtension(openFileDialog.FileName).TrimStart('.');
                        c.FileDateTime = flashHelper.FileLastModifiedDate;
                        c.Package = flashHelper.PackageString;
                        c.ImportedFilename = Path.GetFileName(flashHelper.Filename);
                        c.Version = flashHelper.Version;
                        switch ((FlashPackageType)flashHelper.Package)
                        {
                            case FlashPackageType.Package635Cpu:
                                c.GalaxyCpuModelUid = GalaxySMS.Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_635;
                                break;

                            //case FlashPackageType.Package600Cpu:
                            //    c.GalaxyCpuModelUid = GalaxySMS.Common.Constants.GalaxyCpuTypeIds.GalaxyCpuType_600;
                            //    break;

                            default:
                                TelerikHelpers.ShowAlert(new DialogParameters() { Content = CommonResources.Resources.MaintainGalaxyFlashImages_InvalidFlashFile });
                                break;
                        }
                        if (c.GalaxyCpuModelUid != Guid.Empty)
                            CurrentGalaxyFlashImageViewModel = new EditGalaxyFlashImageViewModel(_eventAggregator, _clientServices, c, Guid.Empty);
                    }
                }

            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
        }

        private bool OnDeleteCommandCanExecute(Entities.GalaxyFlashImage obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId) &&
                IsDeleteControlVisible;
        }

        private void OnDeleteCommand(Entities.GalaxyFlashImage entity)
        {
            ClearCustomErrors();
            _deleteThisGalaxyFlashImage = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainGalaxyFlashImages_AreYouSureDeleteGalaxyFlashImage,
                _deleteThisGalaxyFlashImage.Description);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainGalaxyFlashImages_YesDeleteGalaxyFlashImage, _deleteThisGalaxyFlashImage.Description);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainGalaxyFlashImages_NoDeleteGalaxyFlashImage, _deleteThisGalaxyFlashImage.Description);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                IsBusy = true;
                var GalaxyFlashImageManager = _clientServices.GetManager<Client.SDK.Managers.GalaxyFlashImageManager>();
                var parameters = new Entities.DeleteParameters<Entities.GalaxyFlashImage>() { Data = _deleteThisGalaxyFlashImage, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    GalaxyFlashImageManager.DeleteGalaxyFlashImage(parameters);
                }
                else
                {
                    await GalaxyFlashImageManager.DeleteGalaxyFlashImageAsync(parameters);
                }
                if (GalaxyFlashImageManager.HasErrors == false)
                    GalaxyFlashImages.Remove(_deleteThisGalaxyFlashImage);
                else
                {
                    base.AddCustomErrors(GalaxyFlashImageManager.Errors, true);
                }
                IsBusy = false;

            }
            else
                _deleteThisGalaxyFlashImage = null;
        }

        #endregion

        #region Public Properties

        public EditGalaxyFlashImageViewModel CurrentGalaxyFlashImageViewModel
        {
            get { return _currentGalaxyFlashImageViewModel; }
            set
            {
                if (_currentGalaxyFlashImageViewModel != value)
                {
                    _currentGalaxyFlashImageViewModel = value;
                    OnPropertyChanged(() => CurrentGalaxyFlashImageViewModel, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.GalaxyFlashImage> _GalaxyFlashImages;

        public ObservableCollection<GalaxySMS.Client.Entities.GalaxyFlashImage> GalaxyFlashImages
        {
            get { return _GalaxyFlashImages; }
            set
            {
                if (_GalaxyFlashImages != value)
                {
                    _GalaxyFlashImages = value;
                    OnPropertyChanged(() => GalaxyFlashImages, false);
                }
            }
        }

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.GalaxyFlashImage> EditCommand { get; private set; }
        public DelegateCommand<Entities.GalaxyFlashImage> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }
        #endregion

        #region Public Events
        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccurred;

        #endregion

        #region Protected Methods

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
            this.GalaxyFlashImages = new ObservableCollection<Entities.GalaxyFlashImage>();
            var parameters = new Entities.GetParametersWithPhoto() { IncludeMemberCollections = false };
            var GalaxyFlashImageManager = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.GalaxyFlashImageManager>();
            var galaxyFlashImages = await GalaxyFlashImageManager.GetAllGalaxyFlashImagesAsync(parameters);
            foreach (var s in galaxyFlashImages)
                this.GalaxyFlashImages.Add(s);

            if (GalaxyFlashImageManager.HasErrors)
            {
                base.AddCustomErrors(GalaxyFlashImageManager.Errors, true);
            }
            IsBusy = false;
        }

        #endregion

        #region IPartImportsSatisfiedNotification Implementation

        public void OnImportsSatisfied()
        {
        }

        #endregion

        #region INavigationAware Implementation

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}