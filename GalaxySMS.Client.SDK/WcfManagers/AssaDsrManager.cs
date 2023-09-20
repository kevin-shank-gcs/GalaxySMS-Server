////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\RoleManager.cs
//
// summary:	Implements the role manager class
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
    /// <summary>   Manager for assa dsrs. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AssaDsrManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The assa dsrs. </summary>
        private List<AssaDsr> _AssaDsrs;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the assa dsrs. </summary>
        ///
        /// <value> The assa dsrs. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaDsr> AssaDsrs { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaDsrManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaDsrManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _AssaDsrs = new List<AssaDsr>();
        }

        #endregion

        #region Public methods

        #region GetAllAssaDsrs

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all assa dsrs. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all assa dsrs. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaDsr> GetAllAssaDsrs(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaDsrs = new List<AssaDsr>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            AssaDsr[] data = proxy.GetAllAssaDsrs(parameters);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _AssaDsrs.Add(item);
                            }
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

            AssaDsrs = new ReadOnlyCollection<AssaDsr>(_AssaDsrs);
            return AssaDsrs;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all assa dsrs asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all assa dsrs asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<AssaDsr>> GetAllAssaDsrsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaDsrs = new List<AssaDsr>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            AssaDsr[] data = await proxy.GetAllAssaDsrsAsync(parameters);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _AssaDsrs.Add(item);
                            }
                            AssaDsrs = new ReadOnlyCollection<AssaDsr>(_AssaDsrs);
                            return AssaDsrs;
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

            return AssaDsrs;
        }

        #endregion

        #region GetAllAssaDsrs

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all assa dsrs for entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all assa dsrs for entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaDsr> GetAllAssaDsrsForEntity(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaDsrs = new List<AssaDsr>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            AssaDsr[] data = proxy.GetAllAssaDsrsForEntity(parameters);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _AssaDsrs.Add(item);
                            }
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

            AssaDsrs = new ReadOnlyCollection<AssaDsr>(_AssaDsrs);
            return AssaDsrs;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all assa dsrs for entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all assa dsrs for entity asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<AssaDsr>> GetAllAssaDsrsForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaDsrs = new List<AssaDsr>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            AssaDsr[] data = await proxy.GetAllAssaDsrsForEntityAsync(parameters);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _AssaDsrs.Add(item);
                            }
                            AssaDsrs = new ReadOnlyCollection<AssaDsr>(_AssaDsrs);
                            return AssaDsrs;
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

            return AssaDsrs;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets assa dsr. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The assa dsr. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaDsr GetAssaDsr(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            AssaDsr data = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAssaDsr(parameters);
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

            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets assa dsr asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The assa dsr asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AssaDsr> GetAssaDsrAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AssaDsr data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAssaDsrAsync(parameters);
                            return data;
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

            return data;
        }

        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an assa dsr. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An AssaDsr. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaDsr SaveAssaDsr(SaveParameters<AssaDsr> parameters)
        {
            InitializeErrorsCollection();
            AssaDsr saved = null;
            bool isNew = (parameters.Data.AssaDsrUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            saved = proxy.SaveAssaDsr(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _AssaDsrs
                                                    where i.AssaDsrUid == parameters.Data.AssaDsrUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _AssaDsrs.Remove(originalItem);
                            }
                            _AssaDsrs.Add(saved);
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

            return saved;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an assa dsr asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;AssaDsr&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AssaDsr> SaveAssaDsrAsync(SaveParameters<AssaDsr> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AssaDsr saved = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.AssaDsrUid == Guid.Empty);
                            saved = await proxy.SaveAssaDsrAsync(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _AssaDsrs
                                                    where i.AssaDsrUid == parameters.Data.AssaDsrUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _AssaDsrs.Remove(originalItem);
                            }
                            return saved;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return saved;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the assa dsr described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteAssaDsr(DeleteParameters<AssaDsr> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteAssaDsr(parameters);
                            if (countDeleted == 1)
                            {
                                _AssaDsrs.Remove(parameters.Data);
                                AssaDsrs = new ReadOnlyCollection<AssaDsr>(_AssaDsrs);
                            }
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

            return countDeleted;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the assa dsr asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteAssaDsrAsync(DeleteParameters<AssaDsr> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteXXXAsync throws a WCF exception
                            //                            await proxy.DeleteAssaDsrAsync(parameters);
                            countDeleted = await proxy.DeleteAssaDsrAsync(parameters);
                            if (countDeleted == 1)
                            {
                                _AssaDsrs.Remove(parameters.Data);
                                AssaDsrs = new ReadOnlyCollection<AssaDsr>(_AssaDsrs);
                            }
                            return countDeleted;
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
            return countDeleted;
        }

        #endregion

        #region DeleteByUniqueId

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the assa dsr by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteAssaDsrByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteAssaDsrByPk(parameters);
                            foreach (var i in _AssaDsrs)
                            {
                                if (i.AssaDsrUid == parameters.UniqueId)
                                {
                                    _AssaDsrs.Remove(i);
                                    break;
                                }
                            }
                            AssaDsrs = new ReadOnlyCollection<AssaDsr>(_AssaDsrs);
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

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the assa dsr by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task DeleteAssaDsrByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                await WithClientAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteCountryAsync throws a WCF exception
                            //await proxy.DeleteCountryAsync(parameters);
                            await proxy.DeleteAssaDsrByPkAsync(parameters);
                            foreach (var i in _AssaDsrs)
                            {
                                if (i.AssaDsrUid == parameters.UniqueId)
                                {
                                    _AssaDsrs.Remove(i);
                                    break;
                                }
                            }
                            AssaDsrs = new ReadOnlyCollection<AssaDsr>(_AssaDsrs);
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
        }

        #endregion

        #region Import Data from Assa DSR

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Import access points from assa dsr. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An AssaDsr. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaDsr ImportAccessPointsFromAssaDsr(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            AssaDsr saved = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            saved = proxy.ImportAssaAccessPointsFromDsr(parameters);
                            var originalItem = (from i in _AssaDsrs
                                                where i.AssaDsrUid == saved.AssaDsrUid
                                                select i).FirstOrDefault();
                            if (originalItem != null)
                                _AssaDsrs.Remove(originalItem);
                            _AssaDsrs.Add(saved);
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

            return saved;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Import access points from assa dsr asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;AssaDsr&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AssaDsr> ImportAccessPointsFromAssaDsrAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AssaDsr saved = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            saved = await proxy.ImportAssaAccessPointsFromDsrAsync(parameters);
                            var originalItem = (from i in _AssaDsrs
                                                where i.AssaDsrUid == saved.AssaDsrUid
                                                select i).FirstOrDefault();
                            if (originalItem != null)
                                _AssaDsrs.Remove(originalItem);
                            _AssaDsrs.Add(saved);
                            return saved;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return saved;
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