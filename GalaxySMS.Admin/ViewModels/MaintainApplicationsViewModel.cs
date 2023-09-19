using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using GalaxySMS.Admin.Properties;
using GalaxySMS.Admin.Support;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MaintainApplicationsViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public MaintainApplicationsViewModel(IServiceFactory serviceFactory)
        {
            _ServiceFactory = serviceFactory;

            EditCommand = new DelegateCommand<gcsApplication>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<gcsApplication>(OnDeleteCommand, OnDeleteCommandCanExecute);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);

            _ApplicationManager = new ApplicationManager(Globals.Instance.ServerConnections[0]);
            _ApplicationManager.GetAllApplicationsCompletedEvent += ApplicationManager_OnGetAllApplicationsCompletedEvent;
            _ApplicationManager.DeleteApplicationCompletedEvent += ApplicationManager_OnDeleteApplicationCompletedEvent;
            _ApplicationManager.GetApplicationCompletedEvent += _ApplicationManager_GetApplicationCompletedEvent;
            _ApplicationManager.ErrorsOccurredEvent += ApplicationManager_OnErrorsOccurredEvent;

        }


        private void ApplicationManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach (CustomError error in e.Errors)
                {
                    AddCustomError(error);
                }
            });
        }

        private void ApplicationManager_OnDeleteApplicationCompletedEvent(object sender, DeleteApplicationCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Applications.Remove(e.Application);
                Globals.Instance.RefreshApplications();
            });
        }

        private void ApplicationManager_OnGetAllApplicationsCompletedEvent(object sender, GetAllApplicationsCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Applications = new ObservableCollection<gcsApplication>();
                foreach (gcsApplication application in e.Applications)
                {
                    _Applications.Add(application);
                }
                OnPropertyChanged(() => Applications, false);

            });
        }

        IServiceFactory _ServiceFactory;

        EditApplicationViewModel _CurrentApplicationViewModel;
        ApplicationManager _ApplicationManager;

        public DelegateCommand<gcsApplication> EditCommand { get; private set; }
        public DelegateCommand<gcsApplication> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }

        public override string ViewTitle
        {
            get { return Properties.Resources.MaintainApplications_Title; }
        }

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        public EditApplicationViewModel CurrentApplicationViewModel
        {
            get { return _CurrentApplicationViewModel; }
            set
            {
                if (_CurrentApplicationViewModel != value)
                {
                    _CurrentApplicationViewModel = value;
                    OnPropertyChanged(() => CurrentApplicationViewModel, false);
                }
            }
        }

        ObservableCollection<gcsApplication> _Applications;

        public ObservableCollection<gcsApplication> Applications
        {
            get { return _Applications; }
            set
            {
                if (_Applications != value)
                {
                    _Applications = value;
                    OnPropertyChanged(() => Applications, false);
                }
            }
        }

        protected override void OnViewLoaded()
        {
            _Applications = new ObservableCollection<gcsApplication>();
            if (UseAsyncServiceCalls == false)
            {
                ReadOnlyCollection<gcsApplication> applications = _ApplicationManager.GetAllApplications();
                foreach (gcsApplication application in applications)
                    _Applications.Add(application);
            }
            else
            {
                _ApplicationManager.GetAllApplicationsAsync();
            }
        }

        void _ApplicationManager_GetApplicationCompletedEvent(object sender, GetApplicationCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.Application != null)
                {
                    CurrentApplicationViewModel = new EditApplicationViewModel(_ServiceFactory, e.Application);
                    CurrentApplicationViewModel.ApplicationUpdated += CurrentApplicationViewModel_ApplicationUpdated;
                    CurrentApplicationViewModel.CancelEditApplication += CurrentApplicationViewModel_CancelEvent;
                }
            });
        }

        private bool OnEditCommandCanExecute(gcsApplication obj)
        {
            return CurrentApplicationViewModel == null;
        }

        void OnEditCommand(gcsApplication application)
        {
            if (application != null)
            {
                if (RefreshFromDatabaseOnStartEdit == true)
                {
                    _ApplicationManager.GetApplicationAsync(application.ApplicationId);
                }
                else
                {
                    CurrentApplicationViewModel = new EditApplicationViewModel(_ServiceFactory, application);
                    CurrentApplicationViewModel.ApplicationUpdated += CurrentApplicationViewModel_ApplicationUpdated;
                    CurrentApplicationViewModel.CancelEditApplication += CurrentApplicationViewModel_CancelEvent;
                }
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return CurrentApplicationViewModel == null;
        }

        void OnAddNewCommand(object arg)
        {
            gcsApplication application = new gcsApplication();
            CurrentApplicationViewModel = new EditApplicationViewModel(_ServiceFactory, application);
            CurrentApplicationViewModel.ApplicationUpdated += CurrentApplicationViewModel_ApplicationUpdated;
            CurrentApplicationViewModel.CancelEditApplication += CurrentApplicationViewModel_CancelEvent;
        }

        void CurrentApplicationViewModel_ApplicationUpdated(object sender, ApplicationEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (!e.IsNew)
                {
                    gcsApplication application = _Applications.Where(item => item.ApplicationId == e.Application.ApplicationId).FirstOrDefault();
                    if (application != null)
                    {
                        application.ApplicationName = e.Application.ApplicationName;
                        application.ApplicationDescription = e.Application.ApplicationDescription;
                        application.LanguageId = e.Application.LanguageId;
                        //application.SystemRoleId = e.Application.SystemRoleId;
                        application.ConcurrencyValue = e.Application.ConcurrencyValue;
                    }
                }
                else
                    _Applications.Add(e.Application);

                CurrentApplicationViewModel = null;
                Globals.Instance.RefreshApplications();
            });
        }

        void CurrentApplicationViewModel_CancelEvent(object sender, EventArgs e)
        {
            CurrentApplicationViewModel = null;
        }

        private bool OnDeleteCommandCanExecute(gcsApplication obj)
        {
            return CurrentApplicationViewModel == null;
        }
        
        void OnDeleteCommand(gcsApplication application)
        {
            ClearCustomErrors();

            var args = new CancelMessageEventArgs(application.ApplicationName);
            if (ConfirmDelete != null)
                ConfirmDelete(this, args);
            if (!args.Cancel)
            {

                if (UseAsyncServiceCalls == false)
                {
                    _ApplicationManager.DeleteApplication(application);
                    _Applications.Remove(application);
                    Globals.Instance.RefreshApplications();
                }
                else
                {
                    _ApplicationManager.DeleteApplicationAsync(application);
                }
            }
        }
    }
}
