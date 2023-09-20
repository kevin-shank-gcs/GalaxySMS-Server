////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyInterfaceBoardManager.cs
//
// summary:	Implements the GalaxyInterfaceBoard manager class
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
    /// <summary>   Manager for galaxy interface boards. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyInterfaceBoardManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The galaxy interface boards. </summary>
        private List<GalaxyInterfaceBoard> _GalaxyInterfaceBoards;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy interface boards. </summary>
        ///
        /// <value> The galaxy interface boards. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoard> GalaxyInterfaceBoards { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _GalaxyInterfaceBoards = new List<GalaxyInterfaceBoard>();
        }

        #endregion

        #region Public methods

        #region Get all GalaxyInterfaceBoards for a Cluster

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface boards for cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface boards for cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoard> GetGalaxyInterfaceBoardsForCluster(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoards = new List<GalaxyInterfaceBoard>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardsForCluster(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoards.Add(o);
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                            if (rethrow)
                                throw ex;
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
            return GalaxyInterfaceBoards;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface boards for cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface boards for cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoard>> GetGalaxyInterfaceBoardsForClusterAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoards = new List<GalaxyInterfaceBoard>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardsForClusterAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoards.Add(o);
                            }
                            GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
                            return GalaxyInterfaceBoards;
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

            return GalaxyInterfaceBoards;
        }

        #endregion

        #region Get GalaxyInterfaceBoards for a Panel

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface boards for panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface boards for panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoard> GetGalaxyInterfaceBoardsForPanel(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoards = new List<GalaxyInterfaceBoard>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardsForPanel(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoards.Add(o);
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                            if (rethrow)
                                throw ex;
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
            return GalaxyInterfaceBoards;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface boards for panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface boards for panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoard>> GetGalaxyInterfaceBoardsForPanelAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoards = new List<GalaxyInterfaceBoard>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardsForPanelAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoards.Add(o);
                            }
                            GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
                            return GalaxyInterfaceBoards;
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

            return GalaxyInterfaceBoards;
        }

        #endregion

        #region Get GalaxyInterfaceBoards for a Panel Address

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface boards for panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface boards for panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoard> GetGalaxyInterfaceBoardsForPanelAddress(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoards = new List<GalaxyInterfaceBoard>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardsForPanelAddress(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoards.Add(o);
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                            if (rethrow)
                                throw ex;
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
            return GalaxyInterfaceBoards;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface boards for panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface boards for panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoard>> GetGalaxyInterfaceBoardsForPanelAddressAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoards = new List<GalaxyInterfaceBoard>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardsForPanelAddressAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoards.Add(o);
                            }
                            GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
                            return GalaxyInterfaceBoards;
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

            return GalaxyInterfaceBoards;
        }

        #endregion

        #region Get All GalaxyInterfaceBoards

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy interface boards. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy interface boards. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoard> GetAllGalaxyInterfaceBoards(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoards = new List<GalaxyInterfaceBoard>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoards(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoards.Add(o);
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

            GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
            return GalaxyInterfaceBoards;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy interface boards asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy interface boards asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoard>> GetAllGalaxyInterfaceBoardsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoards = new List<GalaxyInterfaceBoard>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardsAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoards.Add(o);
                            }
                            GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
                            return GalaxyInterfaceBoards;
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

            return GalaxyInterfaceBoards;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the galaxy interface board described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyInterfaceBoard(DeleteParameters<GalaxyInterfaceBoard> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyInterfaceBoard(parameters);
                            if (countDeleted == 1)
                            {
                                _GalaxyInterfaceBoards.Remove(parameters.Data);
                                GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
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
        /// <summary>
        /// Deletes the galaxy interface board asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyInterfaceBoardAsync(DeleteParameters<GalaxyInterfaceBoard> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteGalaxyInterfaceBoardAsync throws a WCF exception
                            countDeleted = await proxy.DeleteGalaxyInterfaceBoardAsync(parameters);
                            if (countDeleted == 1)
                            {
                                _GalaxyInterfaceBoards.Remove(parameters.Data);
                                GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the galaxy interface board by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyInterfaceBoardByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyInterfaceBoardByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _GalaxyInterfaceBoards)
                                {
                                    if (o.GalaxyInterfaceBoardUid == parameters.UniqueId)
                                    {
                                        _GalaxyInterfaceBoards.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
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
        /// <summary>
        /// Deletes the galaxy interface board by unique identifier asynchronous described by
        /// parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyInterfaceBoardByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            countDeleted = await proxy.DeleteGalaxyInterfaceBoardByPkAsync(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _GalaxyInterfaceBoards)
                                {
                                    if (o.GalaxyInterfaceBoardUid == parameters.UniqueId)
                                    {
                                        _GalaxyInterfaceBoards.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyInterfaceBoards = new ReadOnlyCollection<GalaxyInterfaceBoard>(_GalaxyInterfaceBoards);
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

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a galaxy interface board. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxyInterfaceBoard. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoard SaveGalaxyInterfaceBoard(SaveParameters<GalaxyInterfaceBoard> parameters)
        {
            InitializeErrorsCollection();
            GalaxyInterfaceBoard savedItem = null;
            bool isNew = (parameters.Data.GalaxyInterfaceBoardUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyInterfaceBoard(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _GalaxyInterfaceBoards
                                                    where i.GalaxyInterfaceBoardUid == parameters.Data.GalaxyInterfaceBoardUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyInterfaceBoards.Remove(originalItem);
                            }
                            _GalaxyInterfaceBoards.Add(savedItem);
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
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return savedItem;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a galaxy interface board asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;GalaxyInterfaceBoard&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyInterfaceBoard> SaveGalaxyInterfaceBoardAsync(SaveParameters<GalaxyInterfaceBoard> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyInterfaceBoard savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.GalaxyInterfaceBoardUid == Guid.Empty);
                            savedItem = await proxy.SaveGalaxyInterfaceBoardAsync(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _GalaxyInterfaceBoards
                                                    where i.GalaxyInterfaceBoardUid == parameters.Data.GalaxyInterfaceBoardUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyInterfaceBoards.Remove(originalItem);
                            }
                            _GalaxyInterfaceBoards.Add(savedItem);
                            return savedItem;
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

            return savedItem;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoard GetGalaxyInterfaceBoard(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyInterfaceBoard GalaxyInterfaceBoard = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            GalaxyInterfaceBoard = proxy.GetGalaxyInterfaceBoard(parameters);
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

            return GalaxyInterfaceBoard;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyInterfaceBoard> GetGalaxyInterfaceBoardAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyInterfaceBoard GalaxyInterfaceBoard = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            GalaxyInterfaceBoard = await proxy.GetGalaxyInterfaceBoardAsync(parameters);
                            return GalaxyInterfaceBoard;
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

            return GalaxyInterfaceBoard;
        }

        #endregion


        #region Validate

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates the galaxy panel described by data. </summary>
        ///
        /// <remarks>   Kevin, 10/3/2022. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The ValidationProblemDetails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ValidationProblemDetails ValidateGalaxyInterfaceBoard(SaveParameters<GalaxyInterfaceBoard> data)
        {
            InitializeErrorsCollection();
            ValidationProblemDetails savedItem = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.ValidateGalaxyInterfaceBoard(data);
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
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return savedItem;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates the galaxy panel asynchronous described by data. </summary>
        ///
        /// <remarks>   Kevin, 10/3/2022. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The validate galaxy panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ValidationProblemDetails> ValidateGalaxyInterfaceBoardAsync(SaveParameters<GalaxyInterfaceBoard> data)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var savedItem = await proxy.ValidateGalaxyInterfaceBoardAsync(data);
                            return savedItem;
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

            return null;
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