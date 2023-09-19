////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\AccessPortalManager.cs
//
// summary:	Implements the AccessPortal manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Business.Entities;
using GalaxySMS.Client.Contracts.NetCore;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.ServiceModel;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for access portals. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AccessPortalManager : ManagerBase
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

        public AccessPortalManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }

        #endregion

        #region Public methods

        #region Get All Access Portals

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all access portals. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all access portals. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<AccessPortal> GetAllAccessPortals(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllAccessPortals(parameters);
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

            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all access portals asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all access portals asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllAccessPortalsAsync(parameters);
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

        #region Get all Access Portals For a Entity

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all access portals for entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all access portals for entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<AccessPortal> GetAllAccessPortalsForEntity(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllAccessPortalsForEntity(parameters);
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

            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all access portals for entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all access portals for entity asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<AccessPortal>> GetAllAccessPortalsForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllAccessPortalsForEntityAsync(parameters);
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

        #region Get all GetAccess Portals for a Region

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portals for region. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portals for region. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<AccessPortal> GetAccessPortalsForRegion(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllAccessPortalsForRegion(parameters);
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
        /// <summary>   Gets access portals for region asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portals for region asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<AccessPortal>> GetAccessPortalsForRegionAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllAccessPortalsForRegionAsync(parameters);
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

        #region Get all GetAccess Portals for a Site

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portals for site. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portals for site. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<AccessPortal> GetAccessPortalsForSite(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllAccessPortalsForSite(parameters);
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
        /// <summary>   Gets access portals for site asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portals for site asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<AccessPortal>> GetAccessPortalsForSiteAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllAccessPortalsForSiteAsync(parameters);

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

        #region Get all GetAccess Portals for a Cluster

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portals for cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portals for cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<AccessPortal> GetAccessPortalsForCluster(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                {
                    try
                    {
                        data = proxy.GetAllAccessPortalsForCluster(parameters);
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
        /// <summary>   Gets access portals for cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portals for cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<AccessPortal>> GetAccessPortalsForClusterAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        data = await proxy.GetAllAccessPortalsForClusterAsync(parameters);
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

        #region Get all GetAccess Portals for a Galaxy Panel

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portals for galaxy panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portals for galaxy panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<AccessPortal> GetAccessPortalsForGalaxyPanel(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                {
                    try
                    {
                        data = proxy.GetAllAccessPortalsForGalaxyPanel(parameters);
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
        /// <summary>   Gets access portals for galaxy panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portals for galaxy panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<AccessPortal>> GetAccessPortalsForGalaxyPanelAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        data = await proxy.GetAllAccessPortalsForGalaxyPanelAsync(parameters);
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

        #region Get all GetAccess Portals by name, comments or location

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portals by searching name, comments or location. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portals by name, comments or location. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<AccessPortal> GetAccessPortalsByTextSearch(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAccessPortalsByTextSearch(parameters);

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
        /// <summary>   Gets access portals by searching name, comments or location asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portals. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<AccessPortal>> GetAccessPortalsByTextSearchAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortal> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAccessPortalsByTextSearchAsync(parameters);
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

        #region Get all GetAccess Portal List for a Galaxy Panel

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the access portal list for galaxy panels in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the access portal list for galaxy
        /// panels in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<AccessPortalListItem> GetAccessPortalListForGalaxyPanel(GetParameters parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItem> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                {
                    try
                    {
                        data = proxy.GetAccessPortalListItemsForGalaxyPanel(parameters);
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
        /// <summary>   Gets access portal list for galaxy panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portal list for galaxy panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<AccessPortalListItem>> GetAccessPortalListForGalaxyPanelAsync(GetParameters parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItem> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        data = await proxy.GetAccessPortalListItemsForGalaxyPanelAsync(parameters);
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

        #region Get Get Access Portal List Item for a specific Access Portal

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portal list item. </summary>
        ///
        /// <remarks>   Kevin, 4/24/2019. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portal list item. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalListItem GetAccessPortalListItem(GetParameters parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            AccessPortalListItem returnValue = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                {
                    try
                    {
                        returnValue = proxy.GetAccessPortalListItem(parameters);
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

            return returnValue;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portal list item asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 4/24/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portal list item asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AccessPortalListItem> GetAccessPortalListItemAsync(GetParameters parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        var data = await proxy.GetAccessPortalListItemAsync(parameters);
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

        #region List methods
        #region Get All Access Portals List

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all access portals. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all access portals. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ArrayResponse<ListItemBase> GetAllAccessPortalsList(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    data = proxy.GetAllAccessPortalsList(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _AccessPortalsList.Add(o);
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

        //    AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
        //    return data;
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsList(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllAccessPortalsList(parameters);
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


            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all access portals asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all access portals asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<ArrayResponse<ListItemBase>> GetAllAccessPortalsListAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    data = await proxy.GetAllAccessPortalsListAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _AccessPortalsList.Add(o);
        //                    }
        //                    AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
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
        public async Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllAccessPortalsListAsync(parameters);

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

        #region Get all Access Portals List For a Entity

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all access portals for entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all access portals for entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ArrayResponse<ListItemBase> GetAllAccessPortalsListForEntity(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    data = proxy.GetAllAccessPortalsListForEntity(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _AccessPortalsList.Add(o);
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

        //    AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
        //    return data;
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAllAccessPortalsListForEntity(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllAccessPortalsListForEntity(parameters);
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


            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all access portals for entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all access portals for entity asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<ArrayResponse<ListItemBase>> GetAllAccessPortalsListForEntityAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    data = await proxy.GetAllAccessPortalsListForEntityAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _AccessPortalsList.Add(o);
        //                    }
        //                    AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
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
        public async Task<ArrayResponse<AccessPortalListItemCommands>> GetAllAccessPortalsListForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllAccessPortalsListForEntityAsync(parameters);

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

        #region Get all GetAccess Portals List for a Region

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portals for region. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portals for region. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ArrayResponse<ListItemBase> GetAccessPortalsListForRegion(GetParametersWithPhoto parameters, bool rethrow)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    data = proxy.GetAllAccessPortalsListForRegion(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _AccessPortalsList.Add(o);
        //                    }
        //                }
        //                catch (FaultException<ExceptionDetail> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                    if (rethrow)
        //                        throw ex;
        //                }
        //                catch (FaultException<ExceptionDetailEx> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                    if (rethrow)
        //                        throw ex;
        //                }
        //                catch (Exception ex)
        //                {
        //                    AddError(new CustomError(ex.Message));
        //                    if (rethrow)
        //                        throw ex;
        //                }
        //                if (Errors.Count != 0)
        //                    OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //            });

        //    AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
        //    return data;
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAccessPortalsListForRegion(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllAccessPortalsListForRegion(parameters);
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
        /// <summary>   Gets access portals for region asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portals for region asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<ArrayResponse<ListItemBase>> GetAccessPortalsListForRegionAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    data = await proxy.GetAllAccessPortalsListForRegionAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _AccessPortalsList.Add(o);
        //                    }
        //                    AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
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
        public async Task<ArrayResponse<AccessPortalListItemCommands>> GetAccessPortalsListForRegionAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllAccessPortalsListForRegionAsync(parameters);

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

        #region Get all GetAccess Portals List for a Site

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portals for site. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portals for site. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ArrayResponse<ListItemBase> GetAccessPortalsListForSite(GetParametersWithPhoto parameters, bool rethrow)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    data = proxy.GetAllAccessPortalsListForSite(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _AccessPortalsList.Add(o);
        //                    }
        //                }
        //                catch (FaultException<ExceptionDetail> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                    if (rethrow)
        //                        throw ex;
        //                }
        //                catch (FaultException<ExceptionDetailEx> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                    if (rethrow)
        //                        throw ex;
        //                }
        //                catch (Exception ex)
        //                {
        //                    AddError(new CustomError(ex.Message));
        //                    if (rethrow)
        //                        throw ex;
        //                }
        //                if (Errors.Count != 0)
        //                    OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //            });

        //    AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
        //    return data;
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAccessPortalsListForSite(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllAccessPortalsListForSite(parameters);
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
        /// <summary>   Gets access portals for site asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portals for site asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<ArrayResponse<ListItemBase>> GetAccessPortalsListForSiteAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    data = await proxy.GetAllAccessPortalsListForSiteAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _AccessPortalsList.Add(o);
        //                    }
        //                    AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
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
        public async Task<ArrayResponse<AccessPortalListItemCommands>> GetAccessPortalsListForSiteAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllAccessPortalsListForSiteAsync(parameters);

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

        #region Get all GetAccess Portals for a Cluster

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portals for cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portals for cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ArrayResponse<ListItemBase> GetAccessPortalsListForCluster(GetParametersWithPhoto parameters, bool rethrow)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //        {
        //            try
        //            {
        //                data = proxy.GetAllAccessPortalsListForCluster(parameters);
        //                if (data != null)
        //                {
        //                    foreach (var o in data)
        //                        _AccessPortalsList.Add(o);
        //                }
        //            }
        //            catch (FaultException<ExceptionDetail> ex)
        //            {
        //                AddError(new CustomError(ex.Detail));
        //                if (rethrow)
        //                    throw ex;
        //            }
        //            catch (FaultException<ExceptionDetailEx> ex)
        //            {
        //                AddError(new CustomError(ex.Detail));
        //                if (rethrow)
        //                    throw ex;
        //            }
        //            catch (Exception ex)
        //            {
        //                AddError(new CustomError(ex.Message));
        //                if (rethrow)
        //                    throw ex;
        //            }
        //            if (Errors.Count != 0)
        //                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //        });

        //    AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
        //    return data;
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAccessPortalsListForCluster(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllAccessPortalsListForCluster(parameters);
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
        /// <summary>   Gets access portals for cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portals for cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<ArrayResponse<ListItemBase>> GetAccessPortalsListForClusterAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //            {
        //                data = await proxy.GetAllAccessPortalsListForClusterAsync(parameters);
        //                if (data != null)
        //                {
        //                    foreach (var o in data)
        //                        _AccessPortalsList.Add(o);
        //                }
        //                AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
        //                return data;
        //            });
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
        public async Task<ArrayResponse<AccessPortalListItemCommands>> GetAccessPortalsListForClusterAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllAccessPortalsListForClusterAsync(parameters);

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

        #region Get all GetAccess Portals List for a Galaxy Panel

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portals for galaxy panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portals for galaxy panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ArrayResponse<ListItemBase> GetAccessPortalsListForGalaxyPanel(GetParametersWithPhoto parameters, bool rethrow)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //        {
        //            try
        //            {
        //                data = proxy.GetAllAccessPortalsListForGalaxyPanel(parameters);
        //                if (data != null)
        //                {
        //                    foreach (var o in data)
        //                        _AccessPortalsList.Add(o);
        //                }
        //            }
        //            catch (FaultException<ExceptionDetail> ex)
        //            {
        //                AddError(new CustomError(ex.Detail));
        //                if (rethrow)
        //                    throw ex;
        //            }
        //            catch (FaultException<ExceptionDetailEx> ex)
        //            {
        //                AddError(new CustomError(ex.Detail));
        //                if (rethrow)
        //                    throw ex;
        //            }
        //            catch (Exception ex)
        //            {
        //                AddError(new CustomError(ex.Message));
        //                if (rethrow)
        //                    throw ex;
        //            }
        //            if (Errors.Count != 0)
        //                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //        });

        //    AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
        //    return data;
        //}
        public ArrayResponse<AccessPortalListItemCommands> GetAccessPortalsListForGalaxyPanel(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllAccessPortalsListForGalaxyPanel(parameters);
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
        /// <summary>   Gets access portals for galaxy panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portals for galaxy panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<ArrayResponse<ListItemBase>> GetAccessPortalsListForGalaxyPanelAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _AccessPortalsList = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //            {
        //                data = await proxy.GetAllAccessPortalsListForGalaxyPanelAsync(parameters);
        //                if (data != null)
        //                {
        //                    foreach (var o in data)
        //                        _AccessPortalsList.Add(o);
        //                }
        //                AccessPortalsList = new ArrayResponse<ListItemBase>(_AccessPortalsList);
        //                return data;
        //            });
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
        public async Task<ArrayResponse<AccessPortalListItemCommands>> GetAccessPortalsListForGalaxyPanelAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllAccessPortalsListForGalaxyPanelAsync(parameters);

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

        #region Search for access portals by name, comments or location

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portals by searching name, comments or location. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The access portals. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<AccessPortalListItemCommands> GetAccessPortalsListByTextSearch(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAccessPortalsListByTextSearch(parameters);
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
        /// <summary>   Gets access portals by searching name, comments or location asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portals. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<AccessPortalListItemCommands>> GetAccessPortalsListByTextSearchAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<AccessPortalListItemCommands> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAccessPortalsListByTextSearchAsync(parameters);

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
        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the access portal described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteAccessPortal(DeleteParameters<AccessPortal> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteAccessPortal(parameters);
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
        /// <summary>   Deletes the access portal asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteAccessPortalAsync(DeleteParameters<AccessPortal> parameters)
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
                            // For some reason, the DeleteSiteAsync throws a WCF exception
                            countDeleted = await proxy.DeleteAccessPortalAsync(parameters);
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
        /// Deletes the access portal by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteAccessPortalByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteAccessPortalByPk(parameters);
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
        /// Deletes the access portal by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteAccessPortalByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteAccessPortalByPkAsync(parameters);
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
        /// <summary>   Saves the access portal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An AccessPortal. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortal SaveAccessPortal(SaveParameters<AccessPortal> parameters)
        {
            InitializeErrorsCollection();
            AccessPortal savedItem = null;
            bool isNew = (parameters.Data.AccessPortalUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveAccessPortal(parameters);
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
        /// <summary>   Saves the access portal asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;AccessPortal&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AccessPortal> SaveAccessPortalAsync(SaveParameters<AccessPortal> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AccessPortal savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.AccessPortalUid == Guid.Empty);
                            savedItem = await proxy.SaveAccessPortalAsync(parameters);
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
        /// <summary>   Gets access portal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portal. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortal GetAccessPortal(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            AccessPortal AccessPortal = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            AccessPortal = proxy.GetAccessPortal(parameters);
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

            return AccessPortal;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portal asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portal asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AccessPortal> GetAccessPortalAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AccessPortal AccessPortal = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            AccessPortal = await proxy.GetAccessPortalAsync(parameters);
                            return AccessPortal;
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

            return AccessPortal;
        }

        #endregion

        #region Get Access Portal Editor Data

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portal galaxy common editing data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portal galaxy common editing data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalGalaxyCommonEditingData GetAccessPortalGalaxyCommonEditingData(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            AccessPortalGalaxyCommonEditingData editingData = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            editingData = proxy.GetAccessPortalGalaxyCommonEditingData(parameters);
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

            return editingData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portal galaxy common editing data asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portal galaxy common editing data asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AccessPortalGalaxyCommonEditingData> GetAccessPortalGalaxyCommonEditingDataAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AccessPortalGalaxyCommonEditingData editingData = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            editingData = await proxy.GetAccessPortalGalaxyCommonEditingDataAsync(parameters);
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portal galaxy panel specific editing data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portal galaxy panel specific editing data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalGalaxyPanelSpecificEditingData GetAccessPortalGalaxyPanelSpecificEditingData(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            AccessPortalGalaxyPanelSpecificEditingData editingData = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            editingData = proxy.GetAccessPortalGalaxyPanelSpecificEditingData(parameters);
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

            return editingData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portal galaxy panel specific editing data asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portal galaxy panel specific editing data asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AccessPortalGalaxyPanelSpecificEditingData> GetAccessPortalGalaxyPanelSpecificEditingDataAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AccessPortalGalaxyPanelSpecificEditingData editingData = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            editingData = await proxy.GetAccessPortalGalaxyPanelSpecificEditingDataAsync(parameters);
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

        #region Execute Command

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the command operation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ExecuteCommand(CommandParameters<AccessPortalCommandAction> parameters)
        {
            InitializeErrorsCollection();

            bool result = false;
            DateTimeOffset startedAt = DateTimeOffset.Now;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(
                    Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService),
                    ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            result = proxy.ExecuteAccessPortalCommand(parameters);
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
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the command asynchronous operation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> ExecuteCommandAsync(CommandParameters<AccessPortalCommandAction> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.ExecuteAccessPortalCommandAsync(parameters);
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

            return false;
        }
        #endregion

        #region Get Activity History Events

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portal activity history events. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portal activity history events. </returns>
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
                            data = proxy.GetAccessPortalActivityHistoryEvents(parameters);
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

            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets access portal activity history events asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The access portal activity history events asynchronous. </returns>
        ///=================================================================================================

        public async Task<ArrayResponse<ActivityHistoryEvent>> GetActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<ActivityHistoryEvent> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAccessPortalActivityHistoryEventsAsync(parameters);
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