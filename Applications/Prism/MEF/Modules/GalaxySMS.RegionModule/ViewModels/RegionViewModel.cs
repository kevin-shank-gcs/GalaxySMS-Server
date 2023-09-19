using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;
using SDK = GalaxySMS.Client.SDK;
using Entities = GalaxySMS.Client.Entities;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Core;
using GCS.Core.Common;
using System.Linq;
using GalaxySMS.Prism.Infrastructure.Events;
using Telerik.Windows.Controls;
using CommonResources = GalaxySMS.Resources;
using LocalResources = GalaxySMS.Region.Properties;

namespace GalaxySMS.Region.ViewModels
{
    [Export(typeof (RegionViewModel))]
    public class RegionViewModel : ShapefileViewModel, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields

        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditRegionViewModel _CurrentItemViewModel;
        private Entities.Region _deleteThisRegion = null;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public RegionViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            ViewTitle = LocalResources.Resources.RegionView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.Region>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.Region>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.Region>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.Region>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsEditControlVisible = true;
            IsDeleteControlVisible = true;
        }
        #endregion

        #region Private Methods

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.RegionCanViewId) && IsRefreshControlVisible;
        }

        private void OnRefreshCommand(object obj)
        {
            RefreshFromServer();
        }

        private void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            RefreshFromServer();
        }

        private void OperationCanceled(OperationCanceledEventArgs<Entities.Region> obj)
        {
            if( CurrentItemViewModel?.InstanceId == obj.OperationId )
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.Region> obj)
        {
            if (!obj.IsNew)
            {
                var entity = GalaxySMSRegions.FirstOrDefault(item => item.RegionUid == obj.Entity.RegionUid);
                entity?.Initialize(obj.Entity);
            }
            else
                GalaxySMSRegions.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.Region obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.RegionCanUpdateId) &&
                obj?.EntityId == _clientServices.CurrentEntityId && IsEditControlVisible;
        }

        private void OnEditCommand(Entities.Region obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                CurrentItemViewModel = new EditRegionViewModel(_eventAggregator, _clientServices, obj, Guid.Empty);
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.RegionCanAddId) && IsAddNewControlVisible;
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var r = new Entities.Region();
            CurrentItemViewModel = new EditRegionViewModel(_eventAggregator, _clientServices, r, Guid.Empty);
        }

        private bool OnDeleteCommandCanExecute(Entities.Region obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.RegionCanDeleteId) &&
                obj?.EntityId == _clientServices.CurrentEntityId && IsDeleteControlVisible;
        }

        //private async void OnDeleteCommand(Entities.Region entity)
        //{
        //    ClearCustomErrors();

        //    var args = new CancelMessageEventArgs(entity.RegionName);
        //    if (ConfirmDelete != null)
        //        ConfirmDelete(this, args);
        //    if (!args.Cancel)
        //    {
        //        var regionManager = _clientServices.GetManager<SDK.Managers.RegionManager>();
        //        var parameters = new Entities.DeleteParameters<Entities.Region>() { Data = entity, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
        //        if (UseAsyncServiceCalls == false)
        //        {
        //            regionManager.DeleteRegion(parameters);
        //            //Globals.Instance.RefreshEntities();
        //        }
        //        else
        //        {
        //            await regionManager.DeleteRegionAsync(parameters);
        //        }
        //        if (regionManager.HasErrors == false)
        //            GalaxySMSRegions.Remove(entity);
        //    }
        //}
        private void OnDeleteCommand(Entities.Region entity)
        {
            ClearCustomErrors();
            _deleteThisRegion = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainRegions_AreYouSureDeleteRegion,
                _deleteThisRegion.RegionName);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainRegions_YesDeleteRegion, _deleteThisRegion.RegionName);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainRegions_NoDeleteRegion, _deleteThisRegion.RegionName);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                int numberDeleted = 0;
                var regionManager = _clientServices.GetManager<SDK.Managers.RegionManager>();
                var parameters = new Entities.DeleteParameters<Entities.Region>() { Data = _deleteThisRegion, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = regionManager.DeleteRegion(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await regionManager.DeleteRegionAsync(parameters);
                }
                if (regionManager.HasErrors == false)
                    GalaxySMSRegions.Remove(_deleteThisRegion);
                else
                {
                    base.AddCustomErrors(regionManager.Errors, true);
                }
            }
            else
                _deleteThisRegion = null;
        }
        #endregion

        #region Public Properties
        public EditRegionViewModel CurrentItemViewModel
        {
            get { return _CurrentItemViewModel; }
            set
            {
                if (_CurrentItemViewModel != value)
                {
                    _CurrentItemViewModel = value;
                    OnPropertyChanged(() => CurrentItemViewModel, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.Region> _galaxySMSRegions;

        public ObservableCollection<GalaxySMS.Client.Entities.Region> GalaxySMSRegions
        {
            get { return _galaxySMSRegions; }
            set
            {
                if (_galaxySMSRegions != value)
                {
                    _galaxySMSRegions = value;
                    OnPropertyChanged(() => GalaxySMSRegions, false);
                }
            }
        }

        #endregion

        #region Public Events
        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.Region> EditCommand { get; private set; }
        public DelegateCommand<Entities.Region> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }

        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            RefreshFromServer();
        }

        private void RefreshFromServer()
        {
            base.ClearCustomErrors();
            GalaxySMSRegions = new ObservableCollection<Client.Entities.Region>();
            var parameters = new Entities.GetParametersWithPhoto();
            var regionManager = _clientServices.GetManager<SDK.Managers.RegionManager>();
            var regions = regionManager.GetRegions(parameters, false);
            foreach (var r in regions)
                GalaxySMSRegions.Add(r);

            if (regionManager.HasErrors)
            {
                base.AddCustomErrors(regionManager.Errors, true);
            }
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