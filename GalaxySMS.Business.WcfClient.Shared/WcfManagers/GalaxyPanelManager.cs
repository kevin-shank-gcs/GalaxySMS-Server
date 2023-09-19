////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyPanelManager.cs
//
// summary:	Implements the GalaxyPanel manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Business.Entities;
#if NETCOREAPP
using GalaxySMS.Client.Contracts.NetCore;
#else
using GalaxySMS.Client.Contracts;
#endif
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.ServiceModel;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for galaxy panels. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyPanelManager : ManagerBase
    {
        #region Private fields

        #endregion

        #region Public properties

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }

        #endregion

        #region Public methods

        #region Get all GalaxyPanels for a Cluster

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panels for cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy panels for cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<GalaxyPanel> GetGalaxyPanelsForCluster(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<GalaxyPanel> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllGalaxyPanelsForCluster(parameters);
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


            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panels for cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panels for cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<GalaxyPanel>> GetGalaxyPanelsForClusterAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<GalaxyPanel> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllGalaxyPanelsForClusterAsync(parameters);
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

        #region Get GalaxyPanels for a Site

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panels for site. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy panels for site. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<GalaxyPanel> GetGalaxyPanelsForSite(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<GalaxyPanel> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllGalaxyPanelsForSite(parameters);
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


            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panels for site asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panels for site asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<GalaxyPanel>> GetGalaxyPanelsForSiteAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<GalaxyPanel> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllGalaxyPanelsForSiteAsync(parameters);
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

        //#region Get GalaxyPanels For a Entity

        //public ArrayResponse<GalaxyPanel> GetAllGalaxyPanelsForEntity(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    ArrayResponse<GalaxyPanel> data = null;

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    data = proxy.GetAllGalaxyPanelsForEntity(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //_GalaxyPanels.Add(o);
        //                    }
        //                }
        //                catch (FaultException<ExceptionDetail> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                }
        //                catch (FaultException<ExceptionDetailEx> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                }
        //                catch (Exception ex)
        //                {
        //                    AddError(new CustomError(ex.Message));
        //                }
        //                if (Errors.Count != 0)
        //                    OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //            });

        //    
        //    return data;
        //}

        //public async Task<ArrayResponse<GalaxyPanel>> GetAllGalaxyPanelsForEntityAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    ArrayResponse<GalaxyPanel> data = null;

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    data = await proxy.GetAllGalaxyPanelsForEntityAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //_GalaxyPanels.Add(o);
        //                    }
        //                    
        //                    return data;
        //                });
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        AddError(new CustomError(ex.Detail));
        //    }
        //    catch (FaultException<ExceptionDetailEx> ex)
        //    {
        //        AddError(new CustomError(ex.Detail));
        //    }
        //    catch (Exception ex)
        //    {
        //        AddError(new CustomError(ex.Message));
        //    }

        //    return data;
        //}

        //#endregion

        #region Get All GalaxyPanels

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy panels. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy panels. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<GalaxyPanel> GetAllGalaxyPanels(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<GalaxyPanel> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllGalaxyPanels(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });


            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy panels asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy panels asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<GalaxyPanel>> GetAllGalaxyPanelsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<GalaxyPanel> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllGalaxyPanelsAsync(parameters);

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

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the galaxy panel described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyPanel(DeleteParameters<GalaxyPanel> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyPanel(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
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
        /// <summary>   Deletes the galaxy panel asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyPanelAsync(DeleteParameters<GalaxyPanel> parameters)
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
                            // For some reason, the DeleteGalaxyPanelAsync throws a WCF exception
                            countDeleted = await proxy.DeleteGalaxyPanelAsync(parameters);
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
        /// <summary>   Deletes the galaxy panel by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyPanelByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyPanelByPk(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
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
        /// Deletes the galaxy panel by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyPanelByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteGalaxyPanelByPkAsync(parameters);
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
        /// <summary>   Saves a galaxy panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxyPanel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanel SaveGalaxyPanel(SaveParameters<GalaxyPanel> parameters)
        {
            InitializeErrorsCollection();
            GalaxyPanel savedItem = null;
            bool isNew = (parameters.Data.GalaxyPanelUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyPanel(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
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
        /// <summary>   Saves a galaxy panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;GalaxyPanel&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyPanel> SaveGalaxyPanelAsync(SaveParameters<GalaxyPanel> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyPanel savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.GalaxyPanelUid == Guid.Empty);
                            savedItem = await proxy.SaveGalaxyPanelAsync(parameters);
                            return savedItem;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
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
        /// <summary>   Gets galaxy panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanel GetGalaxyPanel(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyPanel GalaxyPanel = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            GalaxyPanel = proxy.GetGalaxyPanel(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return GalaxyPanel;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyPanel> GetGalaxyPanelAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyPanel GalaxyPanel = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            GalaxyPanel = await proxy.GetGalaxyPanelAsync(parameters);
                            return GalaxyPanel;
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

            return GalaxyPanel;
        }

        #endregion

        #region Get by Hardware Address

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanel GetGalaxyPanelByHardwareAddress(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyPanel GalaxyPanel = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            GalaxyPanel = proxy.GetGalaxyPanelByHardwareAddress(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return GalaxyPanel;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyPanel> GetGalaxyPanelByHardwareAddressAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyPanel GalaxyPanel = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            GalaxyPanel = await proxy.GetGalaxyPanelByHardwareAddressAsync(parameters);
                            return GalaxyPanel;
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

            return GalaxyPanel;
        }

        #endregion

        #region Get Galaxy Panel Editor Data

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panel editing data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panel editing data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelEditingData GetGalaxyPanelEditingData(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyPanelEditingData editingData = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            editingData = proxy.GetGalaxyPanelEditingData(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return editingData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panel editing data asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panel editing data asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyPanelEditingData> GetGalaxyPanelEditingDataAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyPanelEditingData editingData = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            editingData = await proxy.GetGalaxyPanelEditingDataAsync(parameters);
                            return editingData;
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

            return editingData;
        }

        #endregion

        #region Get Activity History Events

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panel activity history events. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panel activity history events. </returns>
        ///=================================================================================================

        public ArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<ActivityHistoryEvent> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetGalaxyPanelActivityHistoryEvents(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panel activity history events asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panel activity history events asynchronous. </returns>
        ///=================================================================================================

        public async Task<ArrayResponse<ActivityHistoryEvent>> GetActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetGalaxyPanelActivityHistoryEventsAsync(parameters);
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

            return null;
        }

        #endregion

        #region Validate

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates the galaxy panel described by data. </summary>
        ///
        /// <remarks>   Kevin, 10/3/2022. </remarks>
        ///
        /// <param name="parameters"> The data. </param>
        ///
        /// <returns>   The ValidationProblemDetails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ValidationProblemDetails ValidateGalaxyPanel(SaveParameters<GalaxyPanel> parameters)
        {
            InitializeErrorsCollection();
            ValidationProblemDetails savedItem = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.ValidateGalaxyPanel(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
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
        /// <param name="parameters"> The data. </param>
        ///
        /// <returns>   The validate galaxy panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ValidationProblemDetails> ValidateGalaxyPanelAsync(SaveParameters<GalaxyPanel> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var savedItem = await proxy.ValidateGalaxyPanelAsync(parameters);
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