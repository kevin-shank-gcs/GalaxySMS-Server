////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\BadgePrintManager.cs
//
// summary:	Implements the Person manager class
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
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for persons. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class BadgePrintManager : ManagerBase
    {

        #region Private fields
        private List<Printer> _printers;
        private List<PrintDispatcher> _printDispatchers;

        #endregion

        #region Public properties

        public ReadOnlyCollection<Printer> Printers { get; set; }
        public ReadOnlyCollection<PrintDispatcher> PrintDispatchers { get; set; }

        public PreviewData PreviewImages { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BadgePrintManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BadgePrintManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }

        #endregion

        #region Public methods

        #region Get Printers

        public ReadOnlyCollection<Printer> GetAllPrinters(GetParametersWithPhoto<IdProducerRequestParameters> parameters)
        {
            InitializeErrorsCollection();
            _printers = new List<Printer>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetPrinters(parameters);
                            Printers = new ReadOnlyCollection<Printer>(data);
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
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            return Printers;
        }

        public async Task<ReadOnlyCollection<Printer>> GetAllPrintersAsync(GetParametersWithPhoto<IdProducerRequestParameters> parameters)
        {
            InitializeErrorsCollection();
            _printers = new List<Printer>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetPrintersAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _printers.Add(o);
                            }
                            Printers = new ReadOnlyCollection<Printer>(_printers);
                            return Printers;
                        });
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

            return Printers;
        }

        #endregion

        #region Get PrintDispatchers

        public ReadOnlyCollection<PrintDispatcher> GetAllPrintDispatchers(GetParametersWithPhoto<IdProducerRequestParameters> parameters)
        {
            InitializeErrorsCollection();
            _printDispatchers = new List<PrintDispatcher>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetPrintDispatchers(parameters);
                            PrintDispatchers = new ReadOnlyCollection<PrintDispatcher>(data);
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
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            return PrintDispatchers;
        }

        public async Task<ReadOnlyCollection<PrintDispatcher>> GetAllPrintDispatchersAsync(GetParametersWithPhoto<IdProducerRequestParameters> parameters)
        {
            InitializeErrorsCollection();
            _printDispatchers = new List<PrintDispatcher>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetPrintDispatchersAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _printDispatchers.Add(o);
                            }
                            PrintDispatchers = new ReadOnlyCollection<PrintDispatcher>(_printDispatchers);
                            return PrintDispatchers;
                        });
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

            return PrintDispatchers;
        }

        #endregion

        #region GetPreviewImagesForCredential

        public PreviewData GetPreviewImagesForCredential(GetParametersWithPhoto<IdProducerPrintPreviewRequestParameters> parameters)
        {
            InitializeErrorsCollection();
            PreviewImages = new PreviewData();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            PreviewImages = proxy.GetPreviewImagesForCredential(parameters);
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
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            return PreviewImages;
        }

        public async Task<PreviewData> GetPreviewImagesForCredentialAsync(GetParametersWithPhoto<IdProducerPrintPreviewRequestParameters> parameters)
        {
            InitializeErrorsCollection();
            PreviewImages = new PreviewData();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            PreviewImages = await proxy.GetPreviewImagesForCredentialAsync(parameters);
                            return PreviewImages;
                        });
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

            return PreviewImages;
        }

        #endregion
        
        #region CreatePrintRequestForCredential
        
        public CreatedPrintRequest[] CreatePrintRequestForCredential(GetParametersWithPhoto<IdProducerPrintRequestParameters> parameters)
        {
            InitializeErrorsCollection();
            var createdPrintRequests = new List<CreatedPrintRequest>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var printRequests = proxy.CreatePrintRequestForCredential(parameters);
                            createdPrintRequests.AddRange(printRequests);
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
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            return createdPrintRequests.ToArray();
        }

        public async Task<CreatedPrintRequest[]> CreatePrintRequestForCredentialAsync(GetParametersWithPhoto<IdProducerPrintRequestParameters> parameters)
        {
            InitializeErrorsCollection();
            var createdPrintRequests = new List<CreatedPrintRequest>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var printRequests = await proxy.CreatePrintRequestForCredentialAsync(parameters);
                            return printRequests;
                        });
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

            return createdPrintRequests.ToArray();
        }

        #endregion

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}