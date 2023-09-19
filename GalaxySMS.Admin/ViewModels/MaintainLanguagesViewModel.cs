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
    public class MaintainLanguagesViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public MaintainLanguagesViewModel(IServiceFactory serviceFactory)
        {
            _ServiceFactory = serviceFactory;

            EditCommand = new DelegateCommand<gcsLanguage>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<gcsLanguage>(OnDeleteCommand, OnDeleteCommandCanExecute);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);

            _languageManager = new LanguageManager(Globals.Instance.ServerConnections[0]);
            _languageManager.GetAllLanguagesCompletedEvent += LanguageManager_OnGetAllLanguagesCompletedEvent;
            _languageManager.DeleteLanguageCompletedEvent += LanguageManager_OnDeleteLanguageCompletedEvent;
            _languageManager.ErrorsOccurredEvent += LanguageManager_OnErrorsOccurredEvent;
        }

        private void LanguageManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach (CustomError error in e.Errors)
                {
                    AddCustomError(error);
                }
            });
        }

        private void LanguageManager_OnDeleteLanguageCompletedEvent(object sender, DeleteLanguageCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Languages.Remove(e.Language);
                Globals.Instance.RefreshLanguages();
            });
        }

        private void LanguageManager_OnGetAllLanguagesCompletedEvent(object sender, GetAllLanguagesCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Languages = new ObservableCollection<gcsLanguage>();
                foreach (gcsLanguage language in e.Languages)
                {
                    _Languages.Add(language);
                }
                OnPropertyChanged(() => Languages, false);
            });
        }

        IServiceFactory _ServiceFactory;

        EditLanguageViewModel _CurrentLanguageViewModel;
        LanguageManager _languageManager;

        public DelegateCommand<gcsLanguage> EditCommand { get; private set; }
        public DelegateCommand<gcsLanguage> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }

        public override string ViewTitle
        {
            get { return Properties.Resources.MaintainLanguages_Title; }
        }

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccurred;

        public EditLanguageViewModel CurrentLanguageViewModel
        {
            get { return _CurrentLanguageViewModel; }
            set
            {
                if (_CurrentLanguageViewModel != value)
                {
                    _CurrentLanguageViewModel = value;
                    OnPropertyChanged(() => CurrentLanguageViewModel, false);
                }
            }
        }

        ObservableCollection<gcsLanguage> _Languages;

        public ObservableCollection<gcsLanguage> Languages
        {
            get { return _Languages; }
            set
            {
                if (_Languages != value)
                {
                    _Languages = value;
                    OnPropertyChanged(() => Languages, false);
                }
            }
        }

        protected override void OnViewLoaded()
        {
            _Languages = new ObservableCollection<gcsLanguage>();
            if (UseAsyncServiceCalls == false)
            {
                ReadOnlyCollection<gcsLanguage> languages = _languageManager.GetAllLanguages();
                foreach (gcsLanguage langauge in languages)
                    _Languages.Add(langauge);
            }
            else
            {
                _languageManager.GetAllLanguagesAsync();
            }
        }

        private bool OnEditCommandCanExecute(gcsLanguage obj)
        {
            return CurrentLanguageViewModel == null;
        }
        void OnEditCommand(gcsLanguage language)
        {
            if (language != null)
            {
                CurrentLanguageViewModel = new EditLanguageViewModel(_ServiceFactory, language);
                CurrentLanguageViewModel.LanguageUpdated += CurrentLanguageViewModel_LanguageUpdated;
                CurrentLanguageViewModel.CancelEditLanguage += CurrentLanguageViewModel_CancelEvent;
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return CurrentLanguageViewModel == null;
        }
        void OnAddNewCommand(object arg)
        {
            gcsLanguage language = new gcsLanguage();
            CurrentLanguageViewModel = new EditLanguageViewModel(_ServiceFactory, language);
            CurrentLanguageViewModel.LanguageUpdated += CurrentLanguageViewModel_LanguageUpdated;
            CurrentLanguageViewModel.CancelEditLanguage += CurrentLanguageViewModel_CancelEvent;
        }

        void CurrentLanguageViewModel_LanguageUpdated(object sender, LanguageEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (!e.IsNew)
                {
                    gcsLanguage language = _Languages.Where(item => item.LanguageId == e.Language.LanguageId).FirstOrDefault();
                    if (language != null)
                    {
                        language.CultureName = e.Language.CultureName;
                        language.LanguageName = e.Language.LanguageName;
                        language.Description = e.Language.Description;
                        language.Notes = e.Language.Notes;
                        language.IsActive = e.Language.IsActive;
                        language.IsDefault = e.Language.IsDefault;
                        language.IsDisplay = e.Language.IsDisplay;
                        language.DisplayOrder = e.Language.DisplayOrder;
                        language.FlagImage = e.Language.FlagImage;
                        language.ConcurrencyValue = e.Language.ConcurrencyValue;
                    }
                }
                else
                    _Languages.Add(e.Language);

                CurrentLanguageViewModel = null;
                Globals.Instance.RefreshLanguages();
            });
        }

        void CurrentLanguageViewModel_CancelEvent(object sender, EventArgs e)
        {
            CurrentLanguageViewModel = null;
        }

 
        private bool OnDeleteCommandCanExecute(gcsLanguage obj)
        {
            return CurrentLanguageViewModel == null;
        }
        void OnDeleteCommand(gcsLanguage language)
        {
            ClearCustomErrors();

            var args = new CancelMessageEventArgs(language.LanguageName);
            if (ConfirmDelete != null)
                ConfirmDelete(this, args);
            if (!args.Cancel)
            {

                if (UseAsyncServiceCalls == false)
                {
                    _languageManager.DeleteLanguage(language);
                    _Languages.Remove(language);
                    Globals.Instance.RefreshLanguages();
                }
                else
                {
                    _languageManager.DeleteLanguageAsync(language);
                }

            }
        }
    }
}
