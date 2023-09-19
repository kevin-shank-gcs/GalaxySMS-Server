////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyInterfaceBoardSectionNodeManager.cs
//
// summary:	Implements the GalaxyInterfaceBoardSectionNode manager class
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
    /// <summary>   Manager for galaxy interface board section nodes. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyInterfaceBoardSectionNodeManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The galaxy interface board section nodes. </summary>
        private List<GalaxyInterfaceBoardSectionNode> _GalaxyInterfaceBoardSectionNodes;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy interface board section nodes. </summary>
        ///
        /// <value> The galaxy interface board section nodes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSectionNode> GalaxyInterfaceBoardSectionNodes { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSectionNodeManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSectionNodeManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();
        }

        #endregion

        #region Public methods

        #region Get all GalaxyInterfaceBoardSectionNodes for a Cluster

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section nodes for cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSectionNode> GetGalaxyInterfaceBoardSectionNodesForCluster(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionNodesForCluster(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
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

            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
            return GalaxyInterfaceBoardSectionNodes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section nodes for cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>> GetGalaxyInterfaceBoardSectionNodesForClusterAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionNodesForClusterAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
                            }
                            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
                            return GalaxyInterfaceBoardSectionNodes;
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

            return GalaxyInterfaceBoardSectionNodes;
        }

        #endregion

        #region Get GalaxyInterfaceBoardSectionNodes for a Panel

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section nodes for panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSectionNode> GetGalaxyInterfaceBoardSectionNodesForPanel(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionNodesForPanel(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
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

            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
            return GalaxyInterfaceBoardSectionNodes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section nodes for panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>> GetGalaxyInterfaceBoardSectionNodesForPanelAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionNodesForPanelAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
                            }
                            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
                            return GalaxyInterfaceBoardSectionNodes;
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

            return GalaxyInterfaceBoardSectionNodes;
        }

        #endregion

        #region Get GalaxyInterfaceBoardSectionNodes for a Panel

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section nodes for panel address. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSectionNode> GetGalaxyInterfaceBoardSectionNodesForPanelAddress(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionNodesForPanelAddress(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
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

            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
            return GalaxyInterfaceBoardSectionNodes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section nodes for panel address asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>> GetGalaxyInterfaceBoardSectionNodesForPanelAddressAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionNodesForPanelAddressAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
                            }
                            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
                            return GalaxyInterfaceBoardSectionNodes;
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

            return GalaxyInterfaceBoardSectionNodes;
        }

        #endregion

        #region Get GalaxyInterfaceBoardSectionNodes for a Interface Board

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section nodes for interface board. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for interface board. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSectionNode> GetGalaxyInterfaceBoardSectionNodesForInterfaceBoard(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoard(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
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

            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
            return GalaxyInterfaceBoardSectionNodes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets galaxy interface board section nodes for interface board asynchronous.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for interface board asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>> GetGalaxyInterfaceBoardSectionNodesForInterfaceBoardAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
                            }
                            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
                            return GalaxyInterfaceBoardSectionNodes;
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

            return GalaxyInterfaceBoardSectionNodes;
        }

        #endregion

        #region Get GalaxyInterfaceBoardSectionNodes for a Interface Board Section

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section nodes for interface board section. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for interface board section. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSectionNode> GetGalaxyInterfaceBoardSectionNodesForInterfaceBoardSection(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSection(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
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

            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
            return GalaxyInterfaceBoardSectionNodes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets galaxy interface board section nodes for interface board section asynchronous.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>
        /// The galaxy interface board section nodes for interface board section asynchronous.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>> GetGalaxyInterfaceBoardSectionNodesForInterfaceBoardSectionAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionNodesForInterfaceBoardSectionAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
                            }
                            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
                            return GalaxyInterfaceBoardSectionNodes;
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

            return GalaxyInterfaceBoardSectionNodes;
        }

        #endregion

        #region Get GalaxyInterfaceBoardSectionNodes for a Hardware Module

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section nodes for hardware module. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for hardware module. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSectionNode> GetGalaxyInterfaceBoardSectionNodesForHardwareModule(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModule(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
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

            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
            return GalaxyInterfaceBoardSectionNodes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets galaxy interface board section nodes for hardware module asynchronous.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section nodes for hardware module asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>> GetGalaxyInterfaceBoardSectionNodesForHardwareModuleAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionNodesForGalaxyHardwareModuleAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
                            }
                            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
                            return GalaxyInterfaceBoardSectionNodes;
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

            return GalaxyInterfaceBoardSectionNodes;
        }

        #endregion

        #region Get All GalaxyInterfaceBoardSectionNodes

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy interface board section nodes. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy interface board section nodes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSectionNode> GetAllGalaxyInterfaceBoardSectionNodes(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionNodes(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
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

            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
            return GalaxyInterfaceBoardSectionNodes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy interface board section nodes asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy interface board section nodes asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>> GetAllGalaxyInterfaceBoardSectionNodesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNode>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionNodesAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSectionNodes.Add(o);
                            }
                            GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
                            return GalaxyInterfaceBoardSectionNodes;
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

            return GalaxyInterfaceBoardSectionNodes;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the galaxy interface board section node described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyInterfaceBoardSectionNode(DeleteParameters<GalaxyInterfaceBoardSectionNode> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyInterfaceBoardSectionNode(parameters);
                            if (countDeleted == 1)
                            {
                                _GalaxyInterfaceBoardSectionNodes.Remove(parameters.Data);
                                GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
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
        /// Deletes the galaxy interface board section node asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyInterfaceBoardSectionNodeAsync(DeleteParameters<GalaxyInterfaceBoardSectionNode> parameters)
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
                            // For some reason, the DeleteGalaxyInterfaceBoardSectionNodeAsync throws a WCF exception
                            countDeleted = await proxy.DeleteGalaxyInterfaceBoardSectionNodeAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _GalaxyInterfaceBoardSectionNodes.Remove(parameters.Data);
                                GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
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
        /// Deletes the galaxy interface board section node by unique identifier described by
        /// parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyInterfaceBoardSectionNodeByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyInterfaceBoardSectionNodeByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _GalaxyInterfaceBoardSectionNodes)
                                {
                                    if (o.GalaxyInterfaceBoardSectionNodeUid == parameters.UniqueId)
                                    {
                                        _GalaxyInterfaceBoardSectionNodes.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
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
        /// Deletes the galaxy interface board section node by unique identifier asynchronous described
        /// by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyInterfaceBoardSectionNodeByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteGalaxyInterfaceBoardSectionNodeByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _GalaxyInterfaceBoardSectionNodes)
                                {
                                    if (o.GalaxyInterfaceBoardSectionNodeUid == parameters.UniqueId)
                                    {
                                        _GalaxyInterfaceBoardSectionNodes.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyInterfaceBoardSectionNodes = new ReadOnlyCollection<GalaxyInterfaceBoardSectionNode>(_GalaxyInterfaceBoardSectionNodes);
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
        /// <summary>   Saves a galaxy interface board section node. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxyInterfaceBoardSectionNode. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSectionNode SaveGalaxyInterfaceBoardSectionNode(SaveParameters<GalaxyInterfaceBoardSectionNode> parameters)
        {
            InitializeErrorsCollection();
            GalaxyInterfaceBoardSectionNode savedItem = null;
            bool isNew = (parameters.Data.GalaxyInterfaceBoardSectionNodeUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyInterfaceBoardSectionNode(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _GalaxyInterfaceBoardSectionNodes
                                    where i.GalaxyInterfaceBoardSectionNodeUid == parameters.Data.GalaxyInterfaceBoardSectionNodeUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyInterfaceBoardSectionNodes.Remove(originalItem);
                            }
                            _GalaxyInterfaceBoardSectionNodes.Add(savedItem);
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
        /// <summary>   Saves a galaxy interface board section node asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;GalaxyInterfaceBoardSectionNode&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyInterfaceBoardSectionNode> SaveGalaxyInterfaceBoardSectionNodeAsync(SaveParameters<GalaxyInterfaceBoardSectionNode> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyInterfaceBoardSectionNode savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.GalaxyInterfaceBoardSectionNodeUid == Guid.Empty);
                            savedItem = await proxy.SaveGalaxyInterfaceBoardSectionNodeAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _GalaxyInterfaceBoardSectionNodes
                                    where i.GalaxyInterfaceBoardSectionNodeUid == parameters.Data.GalaxyInterfaceBoardSectionNodeUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyInterfaceBoardSectionNodes.Remove(originalItem);
                            }
                            _GalaxyInterfaceBoardSectionNodes.Add(savedItem);
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
        /// <summary>   Gets galaxy interface board section node. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section node. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSectionNode GetGalaxyInterfaceBoardSectionNode(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyInterfaceBoardSectionNode GalaxyInterfaceBoardSectionNode = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            GalaxyInterfaceBoardSectionNode = proxy.GetGalaxyInterfaceBoardSectionNode(parameters);
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

            return GalaxyInterfaceBoardSectionNode;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section node asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section node asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyInterfaceBoardSectionNode> GetGalaxyInterfaceBoardSectionNodeAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyInterfaceBoardSectionNode GalaxyInterfaceBoardSectionNode = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            GalaxyInterfaceBoardSectionNode = await proxy.GetGalaxyInterfaceBoardSectionNodeAsync(parameters);
                            return GalaxyInterfaceBoardSectionNode;
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

            return GalaxyInterfaceBoardSectionNode;
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