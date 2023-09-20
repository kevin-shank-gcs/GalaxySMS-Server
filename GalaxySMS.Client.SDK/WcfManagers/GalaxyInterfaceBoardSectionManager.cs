////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyInterfaceBoardSectionManager.cs
//
// summary:	Implements the GalaxyInterfaceBoardSection manager class
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
    /// <summary>   Manager for galaxy interface board sections. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyInterfaceBoardSectionManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The galaxy interface board sections. </summary>
        private List<GalaxyInterfaceBoardSection> _GalaxyInterfaceBoardSections;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy interface board sections. </summary>
        ///
        /// <value> The galaxy interface board sections. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSection> GalaxyInterfaceBoardSections { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSectionManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSectionManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();
        }

        #endregion

        #region Public methods

        #region Get all GalaxyInterfaceBoardSections for a Cluster

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board sections for cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface board sections for cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSection> GetGalaxyInterfaceBoardSectionsForCluster(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionsForCluster(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSections.Add(o);
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

            GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
            return GalaxyInterfaceBoardSections;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board sections for cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board sections for cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSection>> GetGalaxyInterfaceBoardSectionsForClusterAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionsForClusterAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSections.Add(o);
                            }
                            GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
                            return GalaxyInterfaceBoardSections;
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

            return GalaxyInterfaceBoardSections;
        }

        #endregion

        #region Get GalaxyInterfaceBoardSections for a Panel

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board sections for panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface board sections for panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSection> GetGalaxyInterfaceBoardSectionsForPanel(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionsForPanel(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSections.Add(o);
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

            GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
            return GalaxyInterfaceBoardSections;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board sections for panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board sections for panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSection>> GetGalaxyInterfaceBoardSectionsForPanelAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionsForPanelAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSections.Add(o);
                            }
                            GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
                            return GalaxyInterfaceBoardSections;
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

            return GalaxyInterfaceBoardSections;
        }

        #endregion
         
        #region Get GalaxyInterfaceBoardSections for a Panel Address

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board sections for panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface board sections for panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSection> GetGalaxyInterfaceBoardSectionsForPanelAddress(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionsForPanelAddress(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSections.Add(o);
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

            GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
            return GalaxyInterfaceBoardSections;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board sections for panel address asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board sections for panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSection>> GetGalaxyInterfaceBoardSectionsForPanelAddressAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionsForPanelAddressAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSections.Add(o);
                            }
                            GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
                            return GalaxyInterfaceBoardSections;
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

            return GalaxyInterfaceBoardSections;
        }

        #endregion


        #region Get GalaxyInterfaceBoardSections for a Interface Board

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board sections for interface board. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy interface board sections for interface board. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSection> GetGalaxyInterfaceBoardSectionsForInterfaceBoard(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionsForInterfaceBoard(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSections.Add(o);
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

            GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
            return GalaxyInterfaceBoardSections;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board sections for interface board asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board sections for interface board asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSection>> GetGalaxyInterfaceBoardSectionsForInterfaceBoardAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionsForInterfaceBoardAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSections.Add(o);
                            }
                            GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
                            return GalaxyInterfaceBoardSections;
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

            return GalaxyInterfaceBoardSections;
        }

        #endregion

        #region Get All GalaxyInterfaceBoardSections

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy interface board sections. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy interface board sections. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyInterfaceBoardSection> GetAllGalaxyInterfaceBoardSections(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSections(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSections.Add(o);
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

            GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
            return GalaxyInterfaceBoardSections;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy interface board sections asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy interface board sections asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyInterfaceBoardSection>> GetAllGalaxyInterfaceBoardSectionsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyInterfaceBoardSections = new List<GalaxyInterfaceBoardSection>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionsAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyInterfaceBoardSections.Add(o);
                            }
                            GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
                            return GalaxyInterfaceBoardSections;
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

            return GalaxyInterfaceBoardSections;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the galaxy interface board section described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyInterfaceBoardSection(DeleteParameters<GalaxyInterfaceBoardSection> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyInterfaceBoardSection(parameters);
                            if (countDeleted == 1)
                            {
                                _GalaxyInterfaceBoardSections.Remove(parameters.Data);
                                GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
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
        /// Deletes the galaxy interface board section asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyInterfaceBoardSectionAsync(DeleteParameters<GalaxyInterfaceBoardSection> parameters)
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
                            // For some reason, the DeleteGalaxyInterfaceBoardSectionAsync throws a WCF exception
                            countDeleted = await proxy.DeleteGalaxyInterfaceBoardSectionAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _GalaxyInterfaceBoardSections.Remove(parameters.Data);
                                GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
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
        /// Deletes the galaxy interface board section by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyInterfaceBoardSectionByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyInterfaceBoardSectionByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _GalaxyInterfaceBoardSections)
                                {
                                    if (o.GalaxyInterfaceBoardSectionUid == parameters.UniqueId)
                                    {
                                        _GalaxyInterfaceBoardSections.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
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
        /// Deletes the galaxy interface board section by unique identifier asynchronous described by
        /// parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyInterfaceBoardSectionByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteGalaxyInterfaceBoardSectionByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _GalaxyInterfaceBoardSections)
                                {
                                    if (o.GalaxyInterfaceBoardSectionUid == parameters.UniqueId)
                                    {
                                        _GalaxyInterfaceBoardSections.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyInterfaceBoardSections = new ReadOnlyCollection<GalaxyInterfaceBoardSection>(_GalaxyInterfaceBoardSections);
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
        /// <summary>   Saves a galaxy interface board section. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxyInterfaceBoardSection. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSection SaveGalaxyInterfaceBoardSection(SaveParameters<GalaxyInterfaceBoardSection> parameters)
        {
            InitializeErrorsCollection();
            GalaxyInterfaceBoardSection savedItem = null;
            bool isNew = (parameters.Data.GalaxyInterfaceBoardSectionUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyInterfaceBoardSection(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _GalaxyInterfaceBoardSections
                                    where i.GalaxyInterfaceBoardSectionUid == parameters.Data.GalaxyInterfaceBoardSectionUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyInterfaceBoardSections.Remove(originalItem);
                            }
                            _GalaxyInterfaceBoardSections.Add(savedItem);
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
        /// <summary>   Saves a galaxy interface board section asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;GalaxyInterfaceBoardSection&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyInterfaceBoardSection> SaveGalaxyInterfaceBoardSectionAsync(SaveParameters<GalaxyInterfaceBoardSection> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyInterfaceBoardSection savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.GalaxyInterfaceBoardSectionUid == Guid.Empty);
                            savedItem = await proxy.SaveGalaxyInterfaceBoardSectionAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _GalaxyInterfaceBoardSections
                                    where i.GalaxyInterfaceBoardSectionUid == parameters.Data.GalaxyInterfaceBoardSectionUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyInterfaceBoardSections.Remove(originalItem);
                            }
                            _GalaxyInterfaceBoardSections.Add(savedItem);
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
        /// <summary>   Gets galaxy interface board section. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSection GetGalaxyInterfaceBoardSection(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyInterfaceBoardSection GalaxyInterfaceBoardSection = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            GalaxyInterfaceBoardSection = proxy.GetGalaxyInterfaceBoardSection(parameters);
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

            return GalaxyInterfaceBoardSection;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyInterfaceBoardSection> GetGalaxyInterfaceBoardSectionAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyInterfaceBoardSection GalaxyInterfaceBoardSection = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            GalaxyInterfaceBoardSection = await proxy.GetGalaxyInterfaceBoardSectionAsync(parameters);
                            return GalaxyInterfaceBoardSection;
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

            return GalaxyInterfaceBoardSection;
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