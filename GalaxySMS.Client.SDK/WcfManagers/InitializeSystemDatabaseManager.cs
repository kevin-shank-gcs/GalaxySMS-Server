////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\LanguageManager.cs
//
// summary:	Implements the language manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Contracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Common.Constants;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Security;

namespace GalaxySMS.Client.SDK.Managers
{
    #region EventArg Classes

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for initialize system database completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/29/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class InitializeSystemDatabaseCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/29/2014. </remarks>
        ///
        /// <param name="bResult">              true to result. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InitializeSystemDatabaseCompletedEventArgs(bool bResult, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Result = bResult;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the result. </summary>
        ///
        /// <value> true if result, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Result { get; set; }
    }

    #endregion

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for initialize system databases. </summary>
    ///
    /// <remarks>   Kevin, 12/29/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]

    public class InitializeSystemDatabaseManager : ManagerBase
    {
        #region Private fields
        #endregion

        #region Public properties

        #endregion

        #region Events and Delegates

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling InitializeSystemDatabasCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/29/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Initialize system database completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void InitializeSystemDatabasCompletedEventHandler(object sender, InitializeSystemDatabaseCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in initializeSystemDatabasCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event InitializeSystemDatabasCompletedEventHandler InitializeSystemDatabaseCompletedEvent;

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InitializeSystemDatabaseManager()
        {
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/29/2014. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InitializeSystemDatabaseManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }
        #endregion

        #region Public methods

        #region InitializeSystemDatabase

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the system database. </summary>
        ///
        /// <remarks>   Kevin, 12/29/2014. </remarks>
        ///
        /// <param name="initializeData">   Information describing the initialize. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool InitializeSystemDatabase(InitializeSystemDatabaseRequest initializeData)
        {
            InitializeErrorsCollection();
            if (initializeData == null)
                initializeData = GetDefaultRequestData();

            bool bResult = false;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            bResult = proxy.InitializeSystemDatabase(initializeData);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }

                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return bResult;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the system database asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/29/2014. </remarks>
        ///
        /// <param name="initializeData">   Information describing the initialize. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InitializeSystemDatabaseAsyncWithEvents(InitializeSystemDatabaseRequest initializeData)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            bool bResult = false;
            if (initializeData == null)
                initializeData = GetDefaultRequestData();

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<bool> t = proxy.InitializeSystemDatabaseAsync(initializeData);
                                bResult = await t;
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = InitializeSystemDatabaseCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new InitializeSystemDatabaseCompletedEventArgs(
                                            bResult, startedAt, endedAt));
                                }
                            }
                            catch (AggregateException ae)
                            {
                                ae = ae.Flatten();
                                foreach (Exception ex in ae.InnerExceptions)
                                {
                                    AddError(new CustomError(ex.Message));
                                    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InitializeSystemDatabaseAsyncWithEvents", ex);
                                }
                                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                   
                                var handler1 = InitializeSystemDatabaseCompletedEvent;
                                if (handler1 != null)
                                {
                                    handler1(this,
                                        new InitializeSystemDatabaseCompletedEventArgs(
                                            false, startedAt, DateTimeOffset.Now));
                                }
                            }
                        }
                    });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes the system database asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="initializeData">   Information describing the initialize. </param>
        ///
        /// <returns>   A Task&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> InitializeSystemDatabaseAsync(InitializeSystemDatabaseRequest initializeData)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            bool bResult = false;
            if (initializeData == null)
                initializeData = GetDefaultRequestData();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                bResult = await client.InitializeSystemDatabaseAsync(initializeData);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();

            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//InitializeSystemDatabaseAsync", ex);
                }
            }
            return bResult;
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets default request data. </summary>
        ///
        /// <remarks>   Kevin, 12/29/2014. </remarks>
        ///
        /// <returns>   The default request data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InitializeSystemDatabaseRequest GetDefaultRequestData()
        {
            var requestData = new InitializeSystemDatabaseRequest();

            return requestData;
        }
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Kevin, 12/29/2014. </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}
