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
using LocalResources = GalaxySMS.AssaAbloy.Properties;

namespace GalaxySMS.AssaAbloy.ViewModels
{
    [Export(typeof(AssaAbloyViewModel))]
    public class AssaAbloyViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditAssaAbloyViewModel _CurrentItemViewModel;
        private Entities.AssaDsr _deleteThisAssaDsr = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public AssaAbloyViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = LocalResources.Resources.AssaAbloyView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.AssaDsr>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.AssaDsr>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.AssaDsr>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.AssaDsr>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);
        }


        #endregion

        #region Private Methods

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.RegionCanViewId);
        }

        private void OnRefreshCommand(object obj)
        {
            RefreshFromServer();
        }

        private void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            RefreshFromServer();
        }

        private void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        {
            RefreshFromServer();
        }

        private void OperationCanceled(OperationCanceledEventArgs<Entities.AssaDsr> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.AssaDsr> obj)
        {
            if (!obj.IsNew)
            {
                var entity = AssaDsrs.FirstOrDefault(item => item.AssaDsrUid == obj.Entity.AssaDsrUid);
                entity?.Initialize(obj.Entity);
            }
            else
                AssaDsrs.Add(obj.Entity);

            if( obj.CloseEditor)
                CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.AssaDsr obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId) &&
                obj?.EntityId == _clientServices.CurrentEntityId; ;
        }

        private void OnEditCommand(Entities.AssaDsr obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                CurrentItemViewModel = new EditAssaAbloyViewModel(_eventAggregator, _clientServices, obj, Guid.Empty);
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanUpdateId);
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.AssaDsr();
            CurrentItemViewModel = new EditAssaAbloyViewModel(_eventAggregator, _clientServices, o, Guid.Empty);
        }

        private bool OnDeleteCommandCanExecute(Entities.AssaDsr obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SystemHardwareCanDeleteId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
        }

        //private async void OnDeleteCommand(Entities.AssaDsr entity)
        //{
        //    ClearCustomErrors();

        //    var args = new CancelMessageEventArgs(entity.PortalName);
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
        private void OnDeleteCommand(Entities.AssaDsr entity)
        {
            ClearCustomErrors();
            _deleteThisAssaDsr = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainAssaDsrs_AreYouSureDeleteAssaDsr,
                _deleteThisAssaDsr.Name);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainAssaDsrs_YesDeleteAssaDsr, _deleteThisAssaDsr.Name);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainAssaDsrs_NoDeleteAssaDsr, _deleteThisAssaDsr.Name);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                int numberDeleted = 0;
                var assaAbloyManager = _clientServices.GetManager<SDK.Managers.AssaDsrManager>();
                var parameters = new Entities.DeleteParameters<Entities.AssaDsr>() { Data = _deleteThisAssaDsr, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = assaAbloyManager.DeleteAssaDsr(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await assaAbloyManager.DeleteAssaDsrAsync(parameters);
                }
                if (assaAbloyManager.HasErrors == false)
                    AssaDsrs.Remove(_deleteThisAssaDsr);
            }
            else
                _deleteThisAssaDsr = null;
        }
        #endregion

        #region Public Properties
        public EditAssaAbloyViewModel CurrentItemViewModel
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

        private ObservableCollection<GalaxySMS.Client.Entities.AssaDsr> _AssaDsrs;

        public ObservableCollection<GalaxySMS.Client.Entities.AssaDsr> AssaDsrs
        {
            get { return _AssaDsrs; }
            set
            {
                if (_AssaDsrs != value)
                {
                    _AssaDsrs = value;
                    OnPropertyChanged(() => AssaDsrs, false);
                }
            }
        }

        #endregion

        #region Public Events
        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.AssaDsr> EditCommand { get; private set; }
        public DelegateCommand<Entities.AssaDsr> DeleteCommand { get; private set; }
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
            AssaDsrs = new ObservableCollection<Client.Entities.AssaDsr>();
            var parameters = new Entities.GetParametersWithPhoto();
            parameters.UniqueId = _clientServices.CurrentSite.SiteUid;
            parameters.IncludeMemberCollections = true;
            parameters.IncludePhoto = true;
            var assaAbloyManager = _clientServices.GetManager<SDK.Managers.AssaDsrManager>();
            var assaDsrs = assaAbloyManager.GetAllAssaDsrsForEntity(parameters);
            foreach (var ap in assaDsrs)
                AssaDsrs.Add(ap);

            if (assaAbloyManager.HasErrors)
            {
                base.AddCustomErrors(assaAbloyManager.Errors, true);
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