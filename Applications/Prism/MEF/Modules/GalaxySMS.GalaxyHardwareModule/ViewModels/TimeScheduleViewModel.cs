using System;
using System.ComponentModel.Composition;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Prism.Infrastructure.Events;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;
using Entities = GalaxySMS.Client.Entities;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;
using CommonResources = GalaxySMS.Resources;
using LocalResources = GalaxySMS.GalaxyHardware.Properties;

namespace GalaxySMS.GalaxyHardware.ViewModels
{
    [Export]
    [Export(typeof(TimeScheduleViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TimeScheduleViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        //EditTimeScheduleViewModel _currentTimeScheduleViewModel;
        //private Entities.TimeSchedule _deleteThisTimeSchedule = null;
        private Entities.Cluster _cluster = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public TimeScheduleViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.Cluster cluster)
        {
            _eventAggregator = eventAggregator;
            ViewTitle = CommonResources.Resources.EditClusterView_TimeScheduleMappingView_ViewTitle;
            ViewToolTip = CommonResources.Resources.EditClusterView_TimeScheduleMappingView_ViewToolTip;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            _cluster = cluster;

            //_eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.TimeSchedule>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            //_eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.TimeSchedule>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);

            //AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            //EditCommand = new DelegateCommand<Entities.TimeSchedule>(OnEditCommand, OnEditCommandCanExecute);
            //DeleteCommand = new DelegateCommand<Entities.TimeSchedule>(OnDeleteCommand, OnDeleteCommandCanExecute);
            //RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);
            TimeScheduleMapChecked = new DelegateCommand<object>(OnTimeScheduleMapChecked);

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsEditControlVisible = true;
            IsDeleteControlVisible = true;
        }

        private void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        {
            RefreshFromServer();
        }

        #endregion

        #region Private methods

        private void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            RefreshFromServer();
        }

        private void OnTimeScheduleMapChecked(object obj)
        {
            _cluster.MakeDirty();
        }

        #endregion

        #region Public Properties

        public Entities.Cluster Cluster
        {
            get { return _cluster; }
            set
            {
                if (_cluster != value)
                {
                    _cluster = value;
                    OnPropertyChanged(() => Cluster, false);
                }
            }
        }

        
        #endregion

        #region Public Commands
        public DelegateCommand<object> TimeScheduleMapChecked { get; set; }
        #endregion

        #region Public Events
        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccurred;

        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            RefreshFromServer();
        }

        private void RefreshFromServer()
        {
            base.ClearCustomErrors();
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
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}