using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using GalaxySMS.Common.Constants;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Infrastructure.Events;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;
using Telerik.Windows.Controls;
using Entities = GalaxySMS.Client.Entities;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;
using CommonResources = GalaxySMS.Resources;
using LocalResources = GalaxySMS.Site.Properties;

namespace GalaxySMS.Site.ViewModels
{
    [Export(typeof(SiteViewModel))]
    public class SiteViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditSiteViewModel _CurrentItemViewModel;
        private Entities.Site _deleteThisSite = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public SiteViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            ViewTitle = LocalResources.Resources.SiteView_ViewTitle;
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;


            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.Site>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.Site>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.Site>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.Site>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsEditControlVisible = true;
            IsDeleteControlVisible = true;
        }

        #endregion

        #region Private methods

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SiteCanViewId) && IsRefreshControlVisible;
        }

        private void OnRefreshCommand(object obj)
        {
            RefreshFromServer();
        }

        private void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            RefreshFromServer();
        }

        private void OperationCanceled(OperationCanceledEventArgs<Entities.Site> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.Site> obj)
        {
            if (!obj.IsNew)
            {
                var entity = GalaxySMSSites.FirstOrDefault(item => item.SiteUid == obj.Entity.SiteUid);
                if (entity != null)
                {
                    entity.Initialize(obj.Entity);
                    //entity.RegionUid = obj.Entity.RegionUid;
                    //entity.SiteUid = obj.Entity.SiteUid;
                    //entity.SiteName = obj.Entity.SiteName;
                    //entity.SiteId = obj.Entity.SiteId;
                    //entity.BinaryResourceUid = obj.Entity.BinaryResourceUid;
                    //entity.gcsBinaryResource = obj.Entity.gcsBinaryResource;

                    //entity.ConcurrencyValue = obj.Entity.ConcurrencyValue;
                }
            }
            else
                GalaxySMSSites.Add(obj.Entity);

            if (obj.CloseEditor)
                CurrentItemViewModel = null;
        }

        private bool OnEditCommandCanExecute(Entities.Site obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SiteCanUpdateId) &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                obj?.EntityId == _clientServices.CurrentEntityId && IsEditControlVisible;
        }

        void OnEditCommand(Entities.Site obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                CurrentItemViewModel = new EditSiteViewModel(_eventAggregator, _clientServices, obj, Guid.Empty);
            }
        }
        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SiteCanAddId) && IsAddNewControlVisible;
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var r = new Entities.Site();
            CurrentItemViewModel = new EditSiteViewModel(_eventAggregator, _clientServices, r, Guid.Empty);
        }

        private bool OnDeleteCommandCanExecute(Entities.Site obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.SiteCanDeleteId) &&
                //obj?.Region.EntityId == _clientServices.CurrentEntityId; 
                obj?.EntityId == _clientServices.CurrentEntityId 
                && IsDeleteControlVisible;
        }

        //private async void OnDeleteCommand(Entities.Site entity)
        //{
        //    ClearCustomErrors();

        //    var args = new CancelMessageEventArgs(entity.SiteName);
        //    if (ConfirmDelete != null)
        //        ConfirmDelete(this, args);
        //    if (!args.Cancel)
        //    {
        //        var regionManager = _clientServices.GetManager<SDK.Managers.SiteManager>();
        //        var parameters = new Entities.DeleteParameters<Entities.Site>() { Data = entity, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
        //        if (UseAsyncServiceCalls == false)
        //        {
        //            regionManager.DeleteSite(parameters);
        //            //Globals.Instance.RefreshEntities();
        //        }
        //        else
        //        {
        //            await regionManager.DeleteSiteAsync(parameters);
        //        }
        //        if (regionManager.HasErrors == false)
        //            GalaxySMSSites.Remove(entity);
        //    }
        //}
        private void OnDeleteCommand(Entities.Site entity)
        {
            ClearCustomErrors();
            _deleteThisSite = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainSites_AreYouSureDeleteSite,
                _deleteThisSite.SiteName);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainSites_YesDeleteSite, _deleteThisSite.SiteName);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainSites_NoDeleteSite, _deleteThisSite.SiteName);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                var siteManager = _clientServices.GetManager<Client.SDK.Managers.SiteManager>();
                var parameters = new Entities.DeleteParameters<Entities.Site>() { Data = _deleteThisSite, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    siteManager.DeleteSite(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteSite(parameters));
                    await siteManager.DeleteSiteAsync(parameters);
                }
                if (siteManager.HasErrors == false)
                    GalaxySMSSites.Remove(_deleteThisSite);
                else
                {
                    base.AddCustomErrors(siteManager.Errors, true);
                }

            }
            else
                _deleteThisSite = null;
        }
        #endregion

        #region Public Properties
        public EditSiteViewModel CurrentItemViewModel
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

        private ObservableCollection<GalaxySMS.Client.Entities.Site> _galaxySMSSites;

        public ObservableCollection<GalaxySMS.Client.Entities.Site> GalaxySMSSites
        {
            get { return _galaxySMSSites; }
            set
            {
                if (_galaxySMSSites != value)
                {
                    _galaxySMSSites = value;
                    OnPropertyChanged(() => GalaxySMSSites, false);
                }
            }
        }

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.Site> EditCommand { get; private set; }
        public DelegateCommand<Entities.Site> DeleteCommand { get; private set; }
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
             System.Diagnostics.Trace.WriteLine("SiteViewModel.OnViewLoaded");
           RefreshFromServer();
        }

        private void RefreshFromServer()
        {
            base.ClearCustomErrors();
            GalaxySMSSites = new ObservableCollection<Client.Entities.Site>();
            var parameters = new Entities.GetParametersWithPhoto();
            var siteManager = _clientServices.GetManager<GalaxySMS.Client.SDK.Managers.SiteManager>();
            var sites = siteManager.GetAllSitesForEntity(parameters);
            foreach (var s in sites)
                GalaxySMSSites.Add(s);

            if (siteManager.HasErrors)
            {
                base.AddCustomErrors(siteManager.Errors, true);
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