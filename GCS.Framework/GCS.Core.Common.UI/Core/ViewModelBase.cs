////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\ViewModelBase.cs
//
// summary:	Implements the view model base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Media.Effects;
using GCS.Core.Common.Core;
using FluentValidation.Results;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.Validation;


namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A view model base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ViewModelBase : ObjectBase, IViewModel
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ViewModelBase()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this ViewModelBase. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Initialize()
        {
            TaskScheduler.UnobservedTaskException += new EventHandler<UnobservedTaskExceptionEventArgs>(TaskUnobservedException_Handler);
            ToggleValidationErrorsCommand = new DelegateCommand<object>(OnToggleValidationErrorsCommandExecute, OnToggleValidationErrorsCommandCanExecute);
            ToggleCustomErrorsCommand = new DelegateCommand<object>(OnToggleCustomErrorsCommandExecute, OnToggleCustomErrorsCommandCanExecute);
            CloseCommand = new DelegateCommand<object>(OnCloseCommandExecute, OnCloseCommandCanExecute);
            IsSaveDeleteControlSaveVisible = Visibility.Visible;
            IsSaveDeleteControlDeleteVisible = Visibility.Visible;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="view"> The view. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ViewModelBase(IView view)
        {
            View = View;
            View.ViewModel = this;

            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by TaskUnobservedException for handler events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Unobserved task exception event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TaskUnobservedException_Handler(object sender, UnobservedTaskExceptionEventArgs e)
        {
            this.Log().DebugFormat("** Unobserved: " + e.Exception.Message);
            e.SetObserved();
        }

        /// <summary>   True to show, false to hide the validation errors. </summary>
        private bool _ValidationErrorsVisible = false;
        /// <summary>   True to show, false to hide the custom errors. </summary>
        private bool _CustomErrorsVisible = false;
        /// <summary>   True to use asynchronous service calls. </summary>
        private bool _UseAsyncServiceCalls = true;
        /// <summary>   True to refresh from database on start edit. </summary>
        private bool _RefreshFromDatabaseOnStartEdit = true;
        /// <summary>   The models. </summary>
        private List<ObjectBase> _Models;
        /// <summary>   The background effect. </summary>
        private Effect _backgroundEffect;
        /// <summary>   The background opacity. </summary>
        private double _backgroundOpacity = 1;
        /// <summary>   The background brush. </summary>
        private Brush _backgroundBrush = null;
        /// <summary>   The view title. </summary>
        private string _viewTitle = String.Empty;
        /// <summary>   The view tool tip. </summary>
        private string _viewToolTip = string.Empty;
        /// <summary>   The current item title. </summary>
        private string _currentItemTitle = String.Empty;
        /// <summary>   True if this ViewModelBase is busy. </summary>
        private bool _isBusy;
        /// <summary>   The busy content. </summary>
        private string _busyContent;

        //public object ViewLoaded
        //{
        //    get
        //    {
        //        OnViewLoaded();
        //        return null;
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the view loaded. </summary>
        ///
        /// <value> The view loaded. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object ViewLoaded
        {
            get
            {
                if( _viewLoaded == null)
                {
                    OnViewLoaded();
                    _viewLoaded = true;
                }
                return _viewLoaded;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the view loaded action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnViewLoaded() { }

        //protected virtual Task OnViewLoadedAsync() { return Task.FromResult(default(object)); }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Executes the on user interface thread on a different thread, and waits for the result.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="codeToExecute">    The code to execute. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void InvokeOnUiThread(Action codeToExecute)
        {
            Application.Current.Dispatcher.Invoke(codeToExecute);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With client. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="proxy">            The proxy. </param>
        /// <param name="codeToExecute">    The code to execute. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void WithClient<T>(T proxy, Action<T> codeToExecute)
        {
            codeToExecute.Invoke(proxy);

            try
            {
                IDisposable disposableClient = proxy as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("WithClient exception: {0}", ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With client asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="proxy">            The proxy. </param>
        /// <param name="codeToExecute">    The code to execute. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected async void WithClientAsync<T>(T proxy, Action<T> codeToExecute)
        {
            await Task.Run(() =>
            {
                codeToExecute.Invoke(proxy);
            });

            try
            {
                IDisposable disposableClient = proxy as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("WithClientAsync exception: {0}", ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the view title. </summary>
        ///
        /// <value> The view title. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual string ViewTitle
        {
            get { return _viewTitle; }
            set
            {
                _viewTitle = value;
                OnPropertyChanged(() => ViewTitle, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the view tool tip. </summary>
        ///
        /// <value> The view tool tip. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual string ViewToolTip
        {
            get { return _viewToolTip; }
            set
            {
                _viewToolTip = value;
                OnPropertyChanged(() => ViewToolTip, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the current item title. </summary>
        ///
        /// <value> The current item title. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual string CurrentItemTitle
        {
            get { return _currentItemTitle; }
            set
            {
                _currentItemTitle = value;
                OnPropertyChanged(() => CurrentItemTitle, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds the models. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="models">   The models. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void AddModels(List<ObjectBase> models) { }

        protected void ClearModels()
        {
            _Models = null;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates the model. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void ValidateModel()
        {
            if (_Models == null || _Models?.Count == 0)
            {
                _Models = new List<ObjectBase>();
                AddModels(_Models);
            }

            _ValidationErrors = new List<ValidationFailure>();
            //_CustomErrors = new ObservableCollection<CustomError>();

            if (_Models.Count > 0)
            {
                foreach (ObjectBase modelObject in _Models)
                {
                    if (modelObject != null)
                        modelObject.Validate();

                    _ValidationErrors = _ValidationErrors.Union(modelObject.ValidationErrors).ToList();
                }

                OnPropertyChanged(() => ValidationErrors, false);
                OnPropertyChanged(() => ValidationHeaderText, false);
                OnPropertyChanged(() => ValidationHeaderVisible, false);

                //OnPropertyChanged(() => CustomErrors, false);
                //OnPropertyChanged(() => CustomErrorsHeaderText, false);
                //OnPropertyChanged(() => CustomErrorsHeaderVisible, false);
            }
            ClearCustomErrors();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Clears the custom errors. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ClearCustomErrors()
        {
            _CustomErrors = new ObservableCollection<CustomError>();
            OnPropertyChanged(() => CustomErrors, false);
            OnPropertyChanged(() => CustomErrorsHeaderText, false);
            OnPropertyChanged(() => CustomErrorsHeaderVisible, false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the toggle validation errors command. </summary>
        ///
        /// <value> The toggle validation errors command. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DelegateCommand<object> ToggleValidationErrorsCommand { get; protected set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the toggle custom errors command. </summary>
        ///
        /// <value> The toggle custom errors command. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DelegateCommand<object> ToggleCustomErrorsCommand { get; protected set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the close command. </summary>
        ///
        /// <value> The close command. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DelegateCommand<object> CloseCommand { get; protected set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the close action. </summary>
        ///
        /// <value> The close action. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Action<bool> CloseAction { get; set; }

        /// <summary>   Event queue for all listeners interested in RequestClose events. </summary>
        public event Action RequestClose;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the close command can execute action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool OnCloseCommandCanExecute(object obj)
        {
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the close command execute action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OnCloseCommandExecute(object obj)
        {
            if (RequestClose != null)
            {
                RequestClose();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether the validation header is visible. </summary>
        ///
        /// <value> True if validation header visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool ValidationHeaderVisible
        {
            get { return ValidationErrors != null && ValidationErrors.Count() > 0; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the validation errors is visible.
        /// </summary>
        ///
        /// <value> True if validation errors visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool ValidationErrorsVisible
        {
            get { return _ValidationErrorsVisible; }
            set
            {
                if (_ValidationErrorsVisible == value)
                    return;

                _ValidationErrorsVisible = value;
                OnPropertyChanged(() => ValidationErrorsVisible, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether the custom errors header is visible. </summary>
        ///
        /// <value> True if custom errors header visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool CustomErrorsHeaderVisible
        {
            get { return CustomErrors != null && CustomErrors.Count() > 0; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the custom errors is visible. </summary>
        ///
        /// <value> True if custom errors visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool CustomErrorsVisible
        {
            get { return _CustomErrorsVisible; }
            set
            {
                if (_CustomErrorsVisible == value)
                    return;

                _CustomErrorsVisible = value;
                OnPropertyChanged(() => CustomErrorsVisible, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a custom error. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="error">    The error. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddCustomError(CustomError error)
        {
            Application.Current.Dispatcher.BeginInvoke((Action) delegate
             {
                 if (_CustomErrors == null)
                     _CustomErrors = new ObservableCollection<CustomError>();
                 _CustomErrors.Add(error);
                 CustomErrorsVisible = true;
                 OnPropertyChanged(() => CustomErrors, false);
                 OnPropertyChanged(() => CustomErrorsHeaderText, false);
                 OnPropertyChanged(() => CustomErrorsHeaderVisible, false);
             });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a custom errors to 'clearCurrentErrors'. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="errors">               The errors. </param>
        /// <param name="clearCurrentErrors">   True to clear current errors. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddCustomErrors(IEnumerable<CustomError> errors, bool clearCurrentErrors)
        {
            Application.Current.Dispatcher.BeginInvoke((Action) delegate
             {
                 if (_CustomErrors == null || clearCurrentErrors == true)
                     _CustomErrors = new ObservableCollection<CustomError>();
                 foreach (var error in errors)
                     _CustomErrors.Add(error);
                 CustomErrorsVisible = true;
                 OnPropertyChanged(() => CustomErrors, false);
                 OnPropertyChanged(() => CustomErrorsHeaderText, false);
                 OnPropertyChanged(() => CustomErrorsHeaderVisible, false);
             });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a custom error to validation results. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="error">    The error. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddCustomErrorToValidationResults(CustomError error)
        {
            Application.Current.Dispatcher.BeginInvoke((Action) delegate
             {
                 AppendValidationError(new ValidationFailure(error.PropertyName, error.ErrorMessage));
                 OnPropertyChanged(() => ValidationErrors, false);
                 OnPropertyChanged(() => ValidationHeaderText, false);
                 OnPropertyChanged(() => ValidationHeaderVisible, false);

             });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ViewModelBase use asynchronous service calls.
        /// </summary>
        ///
        /// <value> True if use asynchronous service calls, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool UseAsyncServiceCalls
        {
            get { return _UseAsyncServiceCalls; }
            set
            {
                if (_UseAsyncServiceCalls == value)
                    return;

                _UseAsyncServiceCalls = value;
                OnPropertyChanged(() => UseAsyncServiceCalls, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether from database on start edit should be refreshed.
        /// </summary>
        ///
        /// <value> True if refresh from database on start edit, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool RefreshFromDatabaseOnStartEdit
        {
            get { return _RefreshFromDatabaseOnStartEdit; }
            set
            {
                if (_RefreshFromDatabaseOnStartEdit == value)
                    return;

                _RefreshFromDatabaseOnStartEdit = value;
                OnPropertyChanged(() => RefreshFromDatabaseOnStartEdit, false);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the validation header text. </summary>
        ///
        /// <value> The validation header text. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual string ValidationHeaderText
        {
            get
            {
                string ret = string.Empty;

                if (ValidationErrors != null)
                {
                    //string verb = (ValidationErrors.Count() == 1 ? "is" : "are");
                    //string suffix = (ValidationErrors.Count() == 1 ? "" : "s");

                    if (!IsValid)
                    {
                        //                        ret = string.Format("There {0} {1} validation error{2}.", verb, ValidationErrors.Count(), suffix);
                        ret = string.Format(Properties.Resources.ValidationHeader_ValidationErrorCount, ValidationErrors.Count());

                    }
                }

                return ret;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the custom errors header text. </summary>
        ///
        /// <value> The custom errors header text. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual string CustomErrorsHeaderText
        {
            get
            {
                string ret = string.Empty;

                if (CustomErrors != null)
                {
                    //string verb = (CustomErrors.Count() == 1 ? "is" : "are");
                    //string suffix = (CustomErrors.Count() == 1 ? "" : "s");

                    //ret = string.Format("There {0} {1} error{2}.", verb, CustomErrors.Count(), suffix);
                    ret = string.Format(Properties.Resources.CustomErrorHeader_ErrorCount, CustomErrors.Count());
                }

                return ret;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the toggle validation errors command execute action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="arg">  The argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnToggleValidationErrorsCommandExecute(object arg)
        {
            ValidationErrorsVisible = !ValidationErrorsVisible;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the toggle validation errors command can execute action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="arg">  The argument. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual bool OnToggleValidationErrorsCommandCanExecute(object arg)
        {
            return !IsValid;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the toggle custom errors command execute action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="arg">  The argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnToggleCustomErrorsCommandExecute(object arg)
        {
            CustomErrorsVisible = !CustomErrorsVisible;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the toggle custom errors command can execute action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="arg">  The argument. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual bool OnToggleCustomErrorsCommandCanExecute(object arg)
        {
            if (CustomErrors == null || CustomErrors.Count == 0)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   View unloaded. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="arg">  The argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual void ViewUnloaded(object arg)
        { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the background effect. </summary>
        ///
        /// <value> The background effect. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Effect BackgroundEffect
        {
            get { return _backgroundEffect; }
            set
            {
                if (_backgroundEffect != value)
                {
                    _backgroundEffect = value;
                    OnPropertyChanged(() => BackgroundEffect, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the background subdued effect. </summary>
        ///
        /// <value> The background subdued effect. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Effect BackgroundSubduedEffect { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the background subdued opacity. </summary>
        ///
        /// <value> The background subdued opacity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public double BackgroundSubduedOpacity { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the background opacity. </summary>
        ///
        /// <value> The background opacity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public double BackgroundOpacity
        {
            get { return _backgroundOpacity; }
            set
            {
                if (_backgroundOpacity != value)
                {
                    _backgroundOpacity = value;
                    OnPropertyChanged(() => BackgroundOpacity, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the background brush. </summary>
        ///
        /// <value> The background brush. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Brush BackgroundBrush
        {
            get { return _backgroundBrush; }
            set
            {
                if (_backgroundBrush != value)
                {
                    _backgroundBrush = value;
                    OnPropertyChanged(() => BackgroundBrush, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the flow direction. </summary>
        ///
        /// <value> The flow direction. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FlowDirection FlowDirection
        {
            get
            {
                if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
                    return FlowDirection.RightToLeft;
                return FlowDirection.LeftToRight;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the view. </summary>
        ///
        /// <value> The view. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IView View { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Clears the background subdued. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ClearBackgroundSubdued()
        {
            BackgroundOpacity = 1;
            BackgroundEffect = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets background subdued. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetBackgroundSubdued()
        {
            BackgroundOpacity = BackgroundSubduedOpacity;
            BackgroundEffect = BackgroundSubduedEffect;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets background properties. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="effect">   The effect. </param>
        /// <param name="opacity">  The opacity. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetBackgroundProperties(Effect effect, double opacity)
        {
            BackgroundOpacity = opacity;
            BackgroundEffect = effect;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the fault handled operation operation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="FaultException{AuthorizationValidationException}"> Thrown when a fault
        ///                                                                     exception error condition
        ///                                                                     occurs. </exception>
        /// <exception cref="fe">                                               Thrown when a fe error
        ///                                                                     condition occurs. </exception>
        /// <exception cref="FaultException">                                   Thrown when a Fault error
        ///                                                                     condition occurs. </exception>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="codetoExecute">    The codeto execute. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected T ExecuteFaultHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (AuthorizationValidationException ex)
            {
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
            catch (DataValidationException ex)
            {
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                foreach (ValidationRule r in ex.ValidationRuleMessages)
                    detail.AddMessage(r.Message);
                FaultException<ExceptionDetailEx> fe = new FaultException<ExceptionDetailEx>(detail, ex.ToString());
                throw fe;
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            //catch (AggregateException ae)
            //{
            //    ae = ae.Flatten();
            //    foreach (Exception ex in ae.InnerExceptions)
            //    {
            //        AddCustomError(new CustomError(ex.Message));
            //        this.Log().Debug(ex.Message);
            //    }
            //}
            catch (Exception ex)
            {
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                string msg = ex.Message;
                this.Log().DebugFormat("{0}", msg);
                FaultException<ExceptionDetailEx> fe = new FaultException<ExceptionDetailEx>(detail, msg);
                throw fe;
                //throw new FaultException(ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the fault handled operation operation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="FaultException{AuthorizationValidationException}"> Thrown when a fault
        ///                                                                     exception error condition
        ///                                                                     occurs. </exception>
        /// <exception cref="fe">                                               Thrown when a fe error
        ///                                                                     condition occurs. </exception>
        /// <exception cref="FaultException">                                   Thrown when a Fault error
        ///                                                                     condition occurs. </exception>
        /// <exception cref="FaultException{ExceptionDetailEx}">                Thrown when a fault
        ///                                                                     exception error condition
        ///                                                                     occurs. </exception>
        ///
        /// <param name="codetoExecute">    The codeto execute. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void ExecuteFaultHandledOperation(Action codetoExecute)
        {
            try
            {
                codetoExecute.Invoke();
            }
            catch (AuthorizationValidationException ex)
            {
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
            catch (DataValidationException ex)
            {
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                foreach (ValidationRule r in ex.ValidationRuleMessages)
                    detail.AddMessage(r.Message);
                FaultException<ExceptionDetailEx> fe = new FaultException<ExceptionDetailEx>(detail, ex.ToString());
                throw fe;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                ExceptionDetailEx detail = new ExceptionDetailEx(ae);
                foreach (Exception ex in ae.InnerExceptions)
                {
                    detail.AddMessage(ex.Message);
                }
                FaultException<ExceptionDetailEx> fe = new FaultException<ExceptionDetailEx>(detail, ae.ToString());
                throw fe;
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                //throw new FaultException(ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this ViewModelBase is busy. </summary>
        ///
        /// <value> True if this ViewModelBase is busy, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    BusyContent = string.Empty;
                    OnPropertyChanged(() => IsBusy, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the busy content. </summary>
        ///
        /// <value> The busy content. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string BusyContent
        {
            get { return _busyContent; }
            set
            {
                if (_busyContent != value)
                {
                    _busyContent = value;
                    OnPropertyChanged(() => BusyContent, false);
                }
            }
        }

        /// <summary>   The is save delete control save visible. </summary>
        private Visibility _isSaveDeleteControlSaveVisible;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the is save delete control save visible. </summary>
        ///
        /// <value> The is save delete control save visible. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Visibility IsSaveDeleteControlSaveVisible
        {
            get { return _isSaveDeleteControlSaveVisible; }
            set
            {
                if (_isSaveDeleteControlSaveVisible != value)
                {
                    _isSaveDeleteControlSaveVisible = value;
                    OnPropertyChanged(() => IsSaveDeleteControlSaveVisible, false);
                }
            }
        }

        /// <summary>   The is save delete control delete visible. </summary>
        private Visibility _isSaveDeleteControlDeleteVisible;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the is save delete control delete visible. </summary>
        ///
        /// <value> The is save delete control delete visible. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Visibility IsSaveDeleteControlDeleteVisible
        {
            get { return _isSaveDeleteControlDeleteVisible; }
            set
            {
                if (_isSaveDeleteControlDeleteVisible != value)
                {
                    _isSaveDeleteControlDeleteVisible = value;
                    OnPropertyChanged(() => IsSaveDeleteControlDeleteVisible, false);
                }
            }
        }

        /// <summary>   True if this ViewModelBase is save control visible. </summary>
        private bool _isSaveControlVisible;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ViewModelBase is save control visible.
        /// </summary>
        ///
        /// <value> True if this ViewModelBase is save control visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsSaveControlVisible
        {
            get { return _isSaveControlVisible; }
            set
            {
                if (_isSaveControlVisible != value)
                {
                    _isSaveControlVisible = value;
                    OnPropertyChanged(() => IsSaveControlVisible, false);
                }
            }
        }

        /// <summary>   True if this ViewModelBase is delete control visible. </summary>
        private bool _isDeleteControlVisible;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ViewModelBase is delete control visible.
        /// </summary>
        ///
        /// <value> True if this ViewModelBase is delete control visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsDeleteControlVisible
        {
            get { return _isDeleteControlVisible; }
            set
            {
                if (_isDeleteControlVisible != value)
                {
                    _isDeleteControlVisible = value;
                    OnPropertyChanged(() => IsDeleteControlVisible, false);
                }
            }
        }

        /// <summary>   True if this ViewModelBase is cancel control visible. </summary>
        private bool _isCancelControlVisible;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ViewModelBase is cancel control visible.
        /// </summary>
        ///
        /// <value> True if this ViewModelBase is cancel control visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsCancelControlVisible
        {
            get { return _isCancelControlVisible; }
            set
            {
                if (_isCancelControlVisible != value)
                {
                    _isCancelControlVisible = value;
                    OnPropertyChanged(() => IsCancelControlVisible, false);
                }
            }
        }

        /// <summary>   True if this ViewModelBase is edit control visible. </summary>
        private bool _isEditControlVisible;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ViewModelBase is edit control visible.
        /// </summary>
        ///
        /// <value> True if this ViewModelBase is edit control visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsEditControlVisible
        {
            get { return _isEditControlVisible; }
            set
            {
                if (_isEditControlVisible != value)
                {
                    _isEditControlVisible = value;
                    OnPropertyChanged(() => IsEditControlVisible, false);
                }
            }
        }

        /// <summary>   True if this ViewModelBase is add new control visible. </summary>
        private bool _isAddNewControlVisible;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ViewModelBase is add new control visible.
        /// </summary>
        ///
        /// <value> True if this ViewModelBase is add new control visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsAddNewControlVisible
        {
            get { return _isAddNewControlVisible; }
            set
            {
                if (_isAddNewControlVisible != value)
                {
                    _isAddNewControlVisible = value;
                    OnPropertyChanged(() => IsAddNewControlVisible, false);
                }
            }
        }

        /// <summary>   True if this ViewModelBase is refresh control visible. </summary>
        private bool _isRefreshControlVisible;
        /// <summary>   The view loaded. </summary>
        private object _viewLoaded;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ViewModelBase is refresh control visible.
        /// </summary>
        ///
        /// <value> True if this ViewModelBase is refresh control visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsRefreshControlVisible
        {
            get { return _isRefreshControlVisible; }
            set
            {
                if (_isRefreshControlVisible != value)
                {
                    _isRefreshControlVisible = value;
                    OnPropertyChanged(() => IsRefreshControlVisible, false);
                }
            }
        }
    }
}
