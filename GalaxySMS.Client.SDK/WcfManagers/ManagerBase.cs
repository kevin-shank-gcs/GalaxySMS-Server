////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\ManagerBase.cs
//
// summary:	Implements the manager base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Contracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Common;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A manager base. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ManagerBase
    {
        /// <summary>   The service factory. </summary>
        protected IServiceFactory _ServiceFactory;

        /// <summary>   The galaxy server connection. </summary>
        private IGalaxySiteServerConnection _GalaxyServerConnection;

        /// <summary>   The errors. </summary>
        private List<CustomError> _Errors;

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the binding. </summary>
        ///
        /// <value> The binding. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Binding Binding
        {
            get { return _GalaxyServerConnection.Binding; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the endpoint base address. </summary>
        ///
        /// <value> The endpoint base address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EndpointAddress EndpointBaseAddress
        {
            get { return _GalaxyServerConnection.EndpointBaseAddress; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ManagerBase use asynchronous service calls.
        /// </summary>
        ///
        /// <value> True if use asynchronous service calls, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool UseAsyncServiceCalls { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the site server connection. </summary>
        ///
        /// <value> The site server connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IGalaxySiteServerConnection SiteServerConnection
        {
            get { return _GalaxyServerConnection; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets information describing the client user session. </summary>
        ///
        /// <value> Information describing the client user session. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IApplicationUserSessionDataHeader ClientUserSessionData
        {
            get { return _GalaxyServerConnection.ClientUserSessionData; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the errors. </summary>
        ///
        /// <value> The errors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<CustomError> Errors
        {
            get
            {
                if (_Errors == null)
                    _Errors = new List<CustomError>();
                return new ReadOnlyCollection<CustomError>(_Errors);
            }
        }

        #endregion

        #region Events and Delegates

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling ErrorsOccurred events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Errors occurred event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void ErrorsOccurredEventHandler(object sender, ErrorsOccurredEventArgs e);

        /// <summary>   Event queue for all listeners interested in errorsOccurred events. </summary>
        public virtual event ErrorsOccurredEventHandler ErrorsOccurredEvent;

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ManagerBase()
        {
            //            _ServiceFactory = ObjectBase.Container.GetExportedValue<IServiceFactory>();
            _ServiceFactory = StaticObjects.Container.GetExportedValue<IServiceFactory>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="galaxyServerConnection">   The galaxy server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ManagerBase(IGalaxySiteServerConnection galaxyServerConnection)
        {
            try
            {
                //            _ServiceFactory = ObjectBase.Container.GetExportedValue<IServiceFactory>();
                _ServiceFactory = StaticObjects.Container.GetExportedValue<IServiceFactory>();
                _GalaxyServerConnection = galaxyServerConnection;
            }
            catch (Exception ex)
            {
                this.Log().Error($"ManagerBase constructor exception. ", ex);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With client. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="proxy">            The proxy. </param>
        /// <param name="codeToExecute">    The code to execute. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void WithClient<T>(T proxy, Action<T> codeToExecute)
        {
            //codeToExecute.Invoke(proxy);

            try
            {
                codeToExecute.Invoke(proxy);
                //IDisposable disposableClient = proxy as IDisposable;
                //if (disposableClient != null)
                //    disposableClient.Dispose();
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("WithClient exception: {0}", ex.Message);
                throw;
            }
            finally
            {
                IDisposable disposableClient = proxy as IDisposable;
                if (disposableClient != null)
                {
                    try
                    {
                        disposableClient.Dispose();
                    }
                    catch (Exception e)
                    {
                        this.Log().DebugFormat("WithClient Dispose exception: {0}", e.Message);
                    }
                }
            }
        }

        //protected TResult WithClient<T, TResult>(T proxy, Func<T, TResult> codeToExecute)
        //{
        //    TResult r = codeToExecute.Invoke(proxy);

        //    try
        //    {
        //        IDisposable disposableClient = proxy as IDisposable;
        //        if (disposableClient != null)
        //            disposableClient.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Log().DebugFormat("WithClient exception: {0}", ex.Message);
        //    }
        //    return r;
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   With client asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="proxy">            The proxy. </param>
        /// <param name="codeToExecute">    The code to execute. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected async Task WithClientAsync<T>(T proxy, Action<T> codeToExecute)
        {
            try
            {
                await Task.Run(() => { codeToExecute.Invoke(proxy); });
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("WithClientAsync exception: {0}", ex.Message);
                throw;
            }
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
        /// <summary>   With client function asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">        Generic type parameter. </typeparam>
        /// <typeparam name="TResult">  Type of the result. </typeparam>
        /// <param name="proxy">            The proxy. </param>
        /// <param name="codeToExecute">    The code to execute. </param>
        ///
        /// <returns>   A Task&lt;TResult&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected async Task<TResult> WithClientFuncAsync<T, TResult>(T proxy, Func<T, Task<TResult>> codeToExecute)
        {
            TResult r = await Task<TResult>.Run(() => { return codeToExecute.Invoke(proxy); });

            try
            {
                IDisposable disposableClient = proxy as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("WithClientExAsync exception: {0}", ex.Message);
            }
            return r;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets service address. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="serviceName">  Name of the service. </param>
        ///
        /// <returns>   The service address. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected EndpointAddress GetServiceAddress(string serviceName)
        {
            return SiteServerConnection.GetServiceAddress(serviceName);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the errors collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void InitializeErrorsCollection()
        {
            _Errors = new List<CustomError>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds an error. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The CustomError to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void AddError(CustomError e)
        {
            if (e == null)
                return;

            if (_Errors == null)
                InitializeErrorsCollection();
            _Errors.Add(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            var handler = ErrorsOccurredEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this ManagerBase has errors. </summary>
        ///
        /// <value> True if this ManagerBase has errors, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool HasErrors
        {
            get
            {
                if (_Errors == null || Errors.Count == 0)
                    return false;
                return true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets errors string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The errors string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetErrorsString()
        {
            if (HasErrors == false)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var error in Errors)
            {
                sb.AppendFormat("{0}", error.ErrorMessage);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets client user session header data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="keyValuePairs">    The key value pairs. </param>
        /// <param name="parameters">       Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetClientUserSessionHeaderData(IEnumerable<KeyValuePair<string, IEnumerable<string>>> keyValuePairs,
            ICallParametersBase parameters)
        {
            foreach (var kvp in keyValuePairs)
            {
                Guid g = Guid.Empty;
                int intValue = 0;
                var firstValue = kvp.Value.FirstOrDefault();
                switch (kvp.Key)
                {
                    case HeaderNames.ApplicationId:
                        if (Guid.TryParse(kvp.Value.FirstOrDefault(), out g))
                            ClientUserSessionData.ApplicationId = g;
                        break;

                    case HeaderNames.CurrentEntityId:
                        if (Guid.TryParse(kvp.Value.FirstOrDefault(), out g))
                            ClientUserSessionData.CurrentEntityId = g;
                        break;

                    case HeaderNames.SessionGuid:
                        if (Guid.TryParse(kvp.Value.FirstOrDefault(), out g))
                            ClientUserSessionData.SessionGuid = g;
                        break;

                    //case HeaderNames.ClientDateTime:
                    //    DateTimeOffset dt;
                    //    if (DateTimeOffset.TryParse(firstValue, out dt))
                    //        ClientUserSessionData.ClientDateTime = dt;
                    //    break;

                    case HeaderNames.OperationGuid:
                        if (Guid.TryParse(kvp.Value.FirstOrDefault(), out g))
                            ClientUserSessionData.OperationGuid = g;
                        break;

                    case HeaderNames.ApplicationName:
                        ClientUserSessionData.ApplicationName = firstValue;
                        break;

                    case HeaderNames.ApplicationVersion:
                        ClientUserSessionData.ApplicationVersion = firstValue;
                        break;

                    case HeaderNames.ClientTimeZoneId:
                        ClientUserSessionData.ClientTimeZoneId = firstValue;
                        break;

                    case HeaderNames.Culture:
                        ClientUserSessionData.Culture = firstValue;
                        break;

                    case HeaderNames.UiCulture:
                        ClientUserSessionData.UiCulture = firstValue;
                        break;

                    case HeaderNames.MachineName:
                        ClientUserSessionData.MachineName = firstValue;
                        break;

                    case HeaderNames.ProductVersionBuild:
                        if (int.TryParse(firstValue, out intValue))
                            ClientUserSessionData.ProductVersionBuild = intValue;
                        break;

                    case HeaderNames.ProductVersionMajor:
                        if (int.TryParse(firstValue, out intValue))
                            ClientUserSessionData.ProductVersionMajor = intValue;
                        break;

                    case HeaderNames.ProductVersionMinor:
                        if (int.TryParse(firstValue, out intValue))
                            ClientUserSessionData.ProductVersionMinor = intValue;
                        break;

                    case HeaderNames.ProductVersionRevision:
                        if (int.TryParse(firstValue, out intValue))
                            ClientUserSessionData.ProductVersionRevision = intValue;
                        break;

                    case HeaderNames.UserName:
                        ClientUserSessionData.UserName = firstValue;
                        break;
                }
            }

            // ICallParameter values override header values
            if (parameters != null)
            {
                //if (parameters.SessionId != Guid.Empty)
                //    ClientUserSessionData.SessionGuid = parameters.SessionId;
                if (parameters.CurrentEntityId != Guid.Empty)
                    ClientUserSessionData.CurrentEntityId = parameters.CurrentEntityId;
            }
        }
    }
}