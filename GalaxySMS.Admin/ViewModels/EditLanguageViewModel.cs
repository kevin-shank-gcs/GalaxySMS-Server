using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using GalaxySMS.Admin.Support;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;


// How to call google translate API for free
// https://translate.googleapis.com/translate_a/single?client=gtx&sl=en-US&tl=es&dt=t&q=%27Reset/Clear%20Crisis%20Mode%27
// var url = "https://translate.googleapis.com/translate_a/single?client=gtx&sl="+ sourceLang + "&tl=" + targetLang + "&dt=t&q=" + encodeURI(sourceText);
// 
namespace GalaxySMS.Admin.ViewModels
{
    public class EditLanguageViewModel : ViewModelBase
    {
        public EditLanguageViewModel(IServiceFactory serviceFactory, gcsLanguage language)
        {
            _ServiceFactory = serviceFactory;
            _Language = new gcsLanguage()
            {
                LanguageId = language.LanguageId,
                CultureName = language.CultureName,
                LanguageName = language.LanguageName,
                Description = language.Description,
                Notes = language.Notes,
                IsDefault = language.IsDefault,
                IsActive = language.IsActive,
                IsDisplay = language.IsDisplay,
                FlagImage = language.FlagImage,
                DisplayOrder = language.DisplayOrder,
                InsertName = language.InsertName,
                InsertDate = language.InsertDate,
                UpdateName = language.UpdateName,
                UpdateDate = language.UpdateDate,
                ConcurrencyValue = language.ConcurrencyValue
            };

            _Language.CleanAll();

            _LanguageManager = new LanguageManager(Globals.Instance.ServerConnections[0]);
            _LanguageManager.SaveLanguageCompletedEvent += LanguageManagerOnSaveLanguageCompletedEvent;
            _LanguageManager.ErrorsOccurredEvent += LanguageManagerOnErrorsOccurredEvent;


            
            Cultures = new ObservableCollection<CultureInfo>();
            foreach (CultureInfo c in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                if( c.Name != string.Empty)
                    Cultures.Add(c);
            }
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
        }

        private void LanguageManagerOnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (CustomError error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void LanguageManagerOnSaveLanguageCompletedEvent(object sender, SaveLanguageCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.Language != null)
                {
                    if (LanguageUpdated != null)
                        LanguageUpdated(this, new LanguageEventArgs(e.Language, e.IsNew));
                }
            });
        }

        IServiceFactory _ServiceFactory;
        LanguageManager _LanguageManager;
        gcsLanguage _Language;

        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }

        public event EventHandler CancelEditLanguage;
        public event EventHandler<LanguageEventArgs> LanguageUpdated;

        public gcsLanguage Language
        {
            get { return _Language; }
        }

        public ObservableCollection<CultureInfo> Cultures { get; internal set; }

        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(Language);
        }

        //void OnSaveCommandExecute(object arg)
        //{
        //    ValidateModel();

        //    if (IsValid)
        //    {
        //        if (UseAsyncServiceCalls == false)
        //        {
        //            WithClient<IAdministrationService>(_ServiceFactory.CreateClient<IAdministrationService>(),
        //                proxy =>
        //                {
        //                    try
        //                    {
        //                        bool isNew = (_Language.LanguageId == Guid.Empty);

        //                        var savedLanguage = proxy.SaveLanguage(_Language);
        //                        if (savedLanguage != null)
        //                        {
        //                            if (LanguageUpdated != null)
        //                                LanguageUpdated(this, new LanguageEventArgs(savedLanguage, isNew));
        //                        }
        //                    }
        //                    catch (FaultException<ExceptionDetail> ex)
        //                    {
        //                        AddCustomError(new CustomError(ex.Message));
        //                    }
        //                    catch (FaultException<ExceptionDetailEx> ex)
        //                    {
        //                        AddCustomError(new CustomError(ex.Message));
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        AddCustomError(new CustomError(ex.Message));

        //                    }
        //                 });
        //        }
        //        else
        //        {
        //            WithClientAsync<IAdministrationService>(
        //                _ServiceFactory.CreateClient<IAdministrationService>(), async proxy =>
        //                {
        //                    if (proxy != null)
        //                    {
        //                        Func<Task> task = async () =>
        //                        {
        //                            bool isNew = (_Language.LanguageId == Guid.Empty);
        //                            Task<gcsLanguage> t = proxy.SaveLanguageAsync(_Language);
        //                            var savedLanguage = await t;
        //                            if (savedLanguage != null)
        //                            {
        //                                if (LanguageUpdated != null)
        //                                    LanguageUpdated(this, new LanguageEventArgs(savedLanguage, isNew));
        //                            }
        //                        };
        //                        try
        //                        {
        //                            task().Wait();
        //                        }
        //                        catch (AggregateException ae)
        //                        {
        //                            ae = ae.Flatten();
        //                            foreach (Exception ex in ae.InnerExceptions)
        //                            {
        //                                AddCustomError(new CustomError(ex.Message));
        //                                this.Log().Debug(ex.Message);
        //                            }
        //                        }
        //                    }
        //                });
        //        }
        //    }
        //}
        void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                bool isNew = (_Language.LanguageId == Guid.Empty);
                var saveParams = new SaveParameters<gcsLanguage>(_Language);
                if (UseAsyncServiceCalls == false)
                {

                    var savedLanguage = _LanguageManager.SaveLanguage(saveParams);
                    if (savedLanguage != null)
                    {
                        if (LanguageUpdated != null)
                            LanguageUpdated(this, new LanguageEventArgs(savedLanguage, isNew));
                    }
                }
                else
                {
                    _LanguageManager.SaveLanguageAsync(saveParams);
                }
            }
        }

        bool OnSaveCommandCanExecute(object arg)
        {
            return _Language.IsDirty;
        }

        void OnCancelCommandExecute(object arg)
        {
            if (CancelEditLanguage != null)
                CancelEditLanguage(this, EventArgs.Empty);
        }
    }
}
