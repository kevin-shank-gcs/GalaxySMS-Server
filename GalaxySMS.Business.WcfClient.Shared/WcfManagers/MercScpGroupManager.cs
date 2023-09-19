////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\MercScpGroupManager.cs
//
// summary:	Implements the MercScpGroup manager class
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
    /// <summary>   Manager for clusters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MercScpGroupManager : ManagerBase
    {
        #region Private fields


        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the clusters. </summary>
        ///
        /// <value> The clusters. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<MercScpGroup> MercScpGroups { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScpGroupManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScpGroupManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            MercScpGroups = new ArrayResponse<MercScpGroup>();
        }

        #endregion

        #region Public methods

        //#region Get MercScpGroups for a Site

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets all clusters for a site, based on the SiteUid value. </summary>
        /////
        ///// <remarks>   The SiteUid is determined by the following order. If the value is Guid.Empty (00000000-0000-0000-0000-000000000000), then the next item is considered:
        /////     <list type="number">
        /////         <item>
        /////             <description>parameters.UniqueId</description>
        /////         </item>
        /////         <item>
        /////             <description>parameters.CurrentSiteUId</description>
        /////         </item>
        /////         <item>
        /////             <description>ClientUserSessionData.CurrentSiteId</description>
        /////         </item>        
        /////     </list>
        ///// </remarks>
        /////
        ///// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        ///// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        ///// <param name="rethrow">      True to rethrow. </param>
        /////
        ///// <returns>   The clusters for site. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ReadOnlyCollection<MercScpGroup> GetMercScpGroupsForSite(GetParametersWithPhoto parameters, bool rethrow)
        //{
        //    InitializeErrorsCollection();
        //    _MercScpGroups = new List<MercScpGroup>();

        //    WithClient<IMercuryManagementService>(
        //        _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    var data = proxy.GetAllMercScpGroupsForSite(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _MercScpGroups.Add(o);
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

        //    MercScpGroups = new ReadOnlyCollection<MercScpGroup>(_MercScpGroups);
        //    return MercScpGroups;
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets all clusters for a site using Async, based on the SiteUid value. </summary>
        /////
        ///// <remarks>   The SiteUid is determined by the following order. If the value is Guid.Empty (00000000-0000-0000-0000-000000000000), then the next item is considered:
        /////     <list type="number">
        /////         <item>
        /////             <description>parameters.UniqueId</description>
        /////         </item>
        /////         <item>
        /////             <description>parameters.CurrentSiteUId</description>
        /////         </item>
        /////         <item>
        /////             <description>ClientUserSessionData.CurrentSiteId</description>
        /////         </item>        
        /////     </list>
        ///// </remarks>
        /////
        ///// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        ///// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        ///// <param name="rethrow">      True to rethrow. </param>
        /////
        ///// <returns>   The clusters for site. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<ReadOnlyCollection<MercScpGroup>> GetMercScpGroupsForSiteAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _MercScpGroups = new List<MercScpGroup>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var data = await proxy.GetAllMercScpGroupsForSiteAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _MercScpGroups.Add(o);
        //                    }
        //                    MercScpGroups = new ReadOnlyCollection<MercScpGroup>(_MercScpGroups);
        //                    return MercScpGroups;
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

        //    return MercScpGroups;
        //}

        //#endregion

        //#region Get MercScpGroups For a Entity

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets all clusters for a entity, based on the EntityId value. </summary>
        /////
        ///// <remarks>   The EntityId is determined by the following order. If the value is Guid.Empty (00000000-0000-0000-0000-000000000000), then the next item is considered:
        /////     <list type="number">
        /////         <item>
        /////             <description>parameters.UniqueId</description>
        /////         </item>
        /////         <item>
        /////             <description>parameters.CurrentEntityId</description>
        /////         </item>
        /////         <item>
        /////             <description>ClientUserSessionData.CurrentEntityId</description>
        /////         </item>        
        /////     </list>
        ///// </remarks>
        /////
        ///// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        ///// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        ///// <param name="rethrow">      True to rethrow. </param>
        /////
        ///// <returns>   The clusters for an entity. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ReadOnlyCollection<MercScpGroup> GetAllMercScpGroupsForEntity(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _MercScpGroups = new List<MercScpGroup>();

        //    WithClient<IMercuryManagementService>(
        //        _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    var data = proxy.GetAllMercScpGroupsForEntity(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _MercScpGroups.Add(o);
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

        //    MercScpGroups = new ReadOnlyCollection<MercScpGroup>(_MercScpGroups);
        //    return MercScpGroups;
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets all clusters for a entity asynchronously, based on the EntityId value. </summary>
        /////
        ///// <remarks>   The EntityId is determined by the following order. If the value is Guid.Empty (00000000-0000-0000-0000-000000000000), then the next item is considered:
        /////     <list type="number">
        /////         <item>
        /////             <description>parameters.UniqueId</description>
        /////         </item>
        /////         <item>
        /////             <description>parameters.CurrentEntityId</description>
        /////         </item>
        /////         <item>
        /////             <description>ClientUserSessionData.CurrentEntityId</description>
        /////         </item>        
        /////     </list>
        ///// </remarks>
        /////
        ///// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        ///// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        ///// <param name="rethrow">      True to rethrow. </param>
        /////
        ///// <returns>   The clusters for an entity. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //public async Task<ReadOnlyCollection<MercScpGroup>> GetAllMercScpGroupsForEntityAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _MercScpGroups = new List<MercScpGroup>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var data = await proxy.GetAllMercScpGroupsForEntityAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _MercScpGroups.Add(o);
        //                    }
        //                    MercScpGroups = new ReadOnlyCollection<MercScpGroup>(_MercScpGroups);
        //                    return MercScpGroups;
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

        //    return MercScpGroups;
        //}

        //#endregion

        //#region Get All MercScpGroups

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets all clusters. </summary>
        /////
        ///// <remarks>   Kevin, 12/26/2018. </remarks>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   all clusters. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ReadOnlyCollection<MercScpGroup> GetAllMercScpGroups(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _MercScpGroups = new List<MercScpGroup>();

        //    WithClient<IMercuryManagementService>(
        //        _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    var data = proxy.GetAllMercScpGroups(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _MercScpGroups.Add(o);
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

        //    MercScpGroups = new ReadOnlyCollection<MercScpGroup>(_MercScpGroups);
        //    return MercScpGroups;
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets all clusters asynchronous. </summary>
        /////
        ///// <remarks>   Kevin, 12/26/2018. </remarks>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   all clusters asynchronous. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<ReadOnlyCollection<MercScpGroup>> GetAllMercScpGroupsAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _MercScpGroups = new List<MercScpGroup>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var data = await proxy.GetAllMercScpGroupsAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _MercScpGroups.Add(o);
        //                    }
        //                    MercScpGroups = new ReadOnlyCollection<MercScpGroup>(_MercScpGroups);
        //                    return MercScpGroups;
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

        //    return MercScpGroups;
        //}

        //#endregion
        #region Get MercScpGroups for a Site

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all clusters for a site, based on the SiteUid value. </summary>
        ///
        /// <remarks>   The SiteUid is determined by the following order. If the value is Guid.Empty (00000000-0000-0000-0000-000000000000), then the next item is considered:
        ///     <list type="number">
        ///         <item>
        ///             <description>parameters.UniqueId</description>
        ///         </item>
        ///         <item>
        ///             <description>parameters.CurrentSiteUId</description>
        ///         </item>
        ///         <item>
        ///             <description>ClientUserSessionData.CurrentSiteId</description>
        ///         </item>        
        ///     </list>
        /// </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The clusters for site. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<MercScpGroup> GetMercScpGroupsForSite(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();

            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            MercScpGroups = proxy.GetAllMercScpGroupsForSite(parameters);
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

            return MercScpGroups;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all clusters for a site using Async, based on the SiteUid value. </summary>
        ///
        /// <remarks>   The SiteUid is determined by the following order. If the value is Guid.Empty (00000000-0000-0000-0000-000000000000), then the next item is considered:
        ///     <list type="number">
        ///         <item>
        ///             <description>parameters.UniqueId</description>
        ///         </item>
        ///         <item>
        ///             <description>parameters.CurrentSiteUId</description>
        ///         </item>
        ///         <item>
        ///             <description>ClientUserSessionData.CurrentSiteId</description>
        ///         </item>        
        ///     </list>
        /// </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The clusters for site. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<MercScpGroup>> GetMercScpGroupsForSiteAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            MercScpGroups = await proxy.GetAllMercScpGroupsForSiteAsync(parameters);
                            return MercScpGroups;
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

            return MercScpGroups;
        }

        #endregion

        #region Get MercScpGroups For a Entity

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all clusters for a entity, based on the EntityId value. </summary>
        ///
        /// <remarks>   The EntityId is determined by the following order. If the value is Guid.Empty (00000000-0000-0000-0000-000000000000), then the next item is considered:
        ///     <list type="number">
        ///         <item>
        ///             <description>parameters.UniqueId</description>
        ///         </item>
        ///         <item>
        ///             <description>parameters.CurrentEntityId</description>
        ///         </item>
        ///         <item>
        ///             <description>ClientUserSessionData.CurrentEntityId</description>
        ///         </item>        
        ///     </list>
        /// </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The clusters for an entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<MercScpGroup> GetAllMercScpGroupsForEntity(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            MercScpGroups = proxy.GetAllMercScpGroupsForEntity(parameters);
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
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            return MercScpGroups;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all clusters for a entity asynchronously, based on the EntityId value. </summary>
        ///
        /// <remarks>   The EntityId is determined by the following order. If the value is Guid.Empty (00000000-0000-0000-0000-000000000000), then the next item is considered:
        ///     <list type="number">
        ///         <item>
        ///             <description>parameters.UniqueId</description>
        ///         </item>
        ///         <item>
        ///             <description>parameters.CurrentEntityId</description>
        ///         </item>
        ///         <item>
        ///             <description>ClientUserSessionData.CurrentEntityId</description>
        ///         </item>        
        ///     </list>
        /// </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The clusters for an entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<ArrayResponse<MercScpGroup>> GetAllMercScpGroupsForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            MercScpGroups = await proxy.GetAllMercScpGroupsForEntityAsync(parameters);
                            return MercScpGroups;
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

            return MercScpGroups;
        }

        #endregion

        #region Get All MercScpGroups

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all clusters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all clusters. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<MercScpGroup> GetAllMercScpGroups(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            MercScpGroups = proxy.GetAllMercScpGroups(parameters);
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
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            return MercScpGroups;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all clusters asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all clusters asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<MercScpGroup>> GetAllMercScpGroupsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            MercScpGroups = await proxy.GetAllMercScpGroupsAsync(parameters);
                            return MercScpGroups;
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

            return MercScpGroups;
        }

        #endregion

        //#region Get List Operations
        //public async Task<ReadOnlyCollection<ListItemBase>> GetAllMercScpGroupsListAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    var list = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var items = await proxy.GetAllMercScpGroupsListAsync(parameters);
        //                    if (items != null)
        //                    {
        //                        foreach (var i in items)
        //                            list.Add(i);
        //                    }
        //                    return new ReadOnlyCollection<ListItemBase>(list);
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

        //    return new ReadOnlyCollection<ListItemBase>(list);
        //}
        //public async Task<ReadOnlyCollection<ListItemBase>> GetAllMercScpGroupsForEntityListAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    var list = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var items = await proxy.GetAllMercScpGroupsForEntityListAsync(parameters);
        //                    if (items != null)
        //                    {
        //                        foreach (var i in items)
        //                            list.Add(i);
        //                    }
        //                    return new ReadOnlyCollection<ListItemBase>(list);
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

        //    return new ReadOnlyCollection<ListItemBase>(list);
        //}
        //public async Task<ReadOnlyCollection<ListItemBase>> GetAllMercScpGroupsForSiteListAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    var list = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var items = await proxy.GetAllMercScpGroupsForSiteListAsync(parameters);
        //                    if (items != null)
        //                    {
        //                        foreach (var i in items)
        //                            list.Add(i);
        //                    }
        //                    return new ReadOnlyCollection<ListItemBase>(list);
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

        //    return new ReadOnlyCollection<ListItemBase>(list);
        //}

        //#endregion

        #region Get List Operations
        public async Task<ArrayResponse<MercScpGroupListItemCommands>> GetAllMercScpGroupsListAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            var list = new ArrayResponse<MercScpGroupListItemCommands>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            list = await proxy.GetAllMercScpGroupsListAsync(parameters);
                            return list;
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

            return list;
        }
        public async Task<ArrayResponse<MercScpGroupListItemCommands>> GetAllMercScpGroupsForEntityListAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            var list = new ArrayResponse<MercScpGroupListItemCommands>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            list = await proxy.GetAllMercScpGroupsForEntityListAsync(parameters);
                            return list;
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

            return list;
        }
        public async Task<ArrayResponse<MercScpGroupListItemCommands>> GetAllMercScpGroupsForSiteListAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            var list = new ArrayResponse<MercScpGroupListItemCommands>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            list = await proxy.GetAllMercScpGroupsForSiteListAsync(parameters);
                            return list;
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

            return list;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the cluster described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteMercScpGroup(DeleteParameters<MercScpGroup> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteMercScpGroup(parameters);
                            //if (countDeleted == 1)
                            //{
                            //    _MercScpGroups.Remove(parameters.Data);
                            //    MercScpGroups = new ReadOnlyCollection<MercScpGroup>(_MercScpGroups);
                            //}
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

                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });
            return countDeleted;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the cluster asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteMercScpGroupAsync(DeleteParameters<MercScpGroup> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteSiteAsync throws a WCF exception
                            countDeleted = await proxy.DeleteMercScpGroupAsync(parameters);
                            //if (countDeleted == 1)
                            //{
                            //    _MercScpGroups.Remove(parameters.Data);
                            //    MercScpGroups = new ReadOnlyCollection<MercScpGroup>(_MercScpGroups);
                            //}
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
        /// <summary>   Deletes the cluster by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteMercScpGroupByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteMercScpGroupByPk(parameters);
                            //if (countDeleted == 1)
                            //{
                            //    foreach (var o in _MercScpGroups)
                            //    {
                            //        if (o.MercScpGroupUid == parameters.UniqueId)
                            //        {
                            //            _MercScpGroups.Remove(o);
                            //            break;
                            //        }
                            //    }
                            //    MercScpGroups = new ReadOnlyCollection<MercScpGroup>(_MercScpGroups);
                            //}
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

                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });
            return countDeleted;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the cluster by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteMercScpGroupByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            countDeleted = await proxy.DeleteMercScpGroupByPkAsync(parameters);
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

        #region Validate

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validate a cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A MercScpGroup. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ValidationProblemDetails ValidateMercScpGroup(SaveParameters<MercScpGroup> parameters)
        {
            InitializeErrorsCollection();
            ValidationProblemDetails savedItem = null;
            bool isNew = (parameters.Data.MercScpGroupUid == Guid.Empty);
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.ValidateMercScpGroup(parameters);
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
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return savedItem;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;MercScpGroup&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ValidationProblemDetails> ValidateMercScpGroupAsync(SaveParameters<MercScpGroup> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            ValidationProblemDetails savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.MercScpGroupUid == Guid.Empty);
                            savedItem = await proxy.ValidateMercScpGroupAsync(parameters);
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

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A MercScpGroup. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScpGroup SaveMercScpGroup(SaveParameters<MercScpGroup> parameters)
        {
            InitializeErrorsCollection();
            MercScpGroup savedItem = null;
            bool isNew = (parameters.Data.MercScpGroupUid == Guid.Empty);
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveMercScpGroup(parameters);
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
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return savedItem;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;MercScpGroup&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<MercScpGroup> SaveMercScpGroupAsync(SaveParameters<MercScpGroup> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            MercScpGroup savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.MercScpGroupUid == Guid.Empty);
                            savedItem = await proxy.SaveMercScpGroupAsync(parameters);
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
        /// <summary>   Gets a cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScpGroup GetMercScpGroup(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            MercScpGroup MercScpGroup = null;
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            MercScpGroup = proxy.GetMercScpGroup(parameters);
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
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return MercScpGroup;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<MercScpGroup> GetMercScpGroupAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            MercScpGroup MercScpGroup = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            MercScpGroup = await proxy.GetMercScpGroupAsync(parameters);
                            return MercScpGroup;
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

            return MercScpGroup;
        }

        #endregion

        //#region Get by Hardware Address

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets a cluster. </summary>
        /////
        ///// <remarks>   Kevin, 12/26/2018. </remarks>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   The cluster. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public MercScpGroup GetMercScpGroupByHardwareAddress(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    MercScpGroup MercScpGroup = null;
        //    WithClient<IMercuryManagementService>(
        //        _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    MercScpGroup = proxy.GetMercScpGroupByHardwareAddress(parameters);
        //                }
        //                catch (FaultException<ExceptionDetail> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                }
        //    catch (FaultException<ExceptionDetailEx> ex)
        //    {
        //        if( !string.IsNullOrEmpty(ex.Message))
        //            AddError(new CustomError(ex));
        //        else
        //            AddError(new CustomError(ex.Detail));
        //    }

        //                catch (Exception ex)
        //                {
        //                    AddError(new CustomError(ex.Message));
        //                }
        //            });

        //    if (Errors.Count != 0)
        //        OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

        //    return MercScpGroup;
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets cluster asynchronous. </summary>
        /////
        ///// <remarks>   Kevin, 12/26/2018. </remarks>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   The cluster asynchronous. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<MercScpGroup> GetMercScpGroupByHardwareAddressAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    DateTimeOffset startedAt = DateTimeOffset.Now;
        //    MercScpGroup MercScpGroup = null;

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    MercScpGroup = await proxy.GetMercScpGroupByHardwareAddressAsync(parameters);
        //                    return MercScpGroup;
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

        //    return MercScpGroup;
        //}

        //#endregion

        #region Get MercScpGroup Editor Data

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets cluster editing data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The cluster editing data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScpGroupEditingData GetMercScpGroupEditingData(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            MercScpGroupEditingData clusterEditingData = null;
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            clusterEditingData = proxy.GetMercScpGroupEditingData(parameters);
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
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return clusterEditingData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets cluster editing data asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The cluster editing data asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<MercScpGroupEditingData> GetMercScpGroupEditingDataAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            MercScpGroupEditingData clusterEditingData = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            clusterEditingData = await proxy.GetMercScpGroupEditingDataAsync(parameters);
                            return clusterEditingData;
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

            return clusterEditingData;
        }

        #endregion

        //#region Execute MercScpGroup Command
        //public CommandResponse<GalaxyCpuCommandAction> ExecuteMercScpGroupCommand(CommandParameters<GalaxyCpuCommandAction> parameters)
        //{
        //    InitializeErrorsCollection();

        //    CommandResponse<GalaxyCpuCommandAction> result = null;
        //    DateTimeOffset startedAt = DateTimeOffset.Now;
        //    WithClient<IMercuryManagementService>(
        //        _ServiceFactory.CreateClient<IMercuryManagementService>(
        //            Binding,
        //            GetServiceAddress(ServiceNames.MercuryManagementService),
        //            ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    result = proxy.ExecuteMercScpGroupCommand(parameters);
        //                }
        //                catch (FaultException<ExceptionDetail> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                }
        //    catch (FaultException<ExceptionDetailEx> ex)
        //    {
        //        if( !string.IsNullOrEmpty(ex.Message))
        //            AddError(new CustomError(ex));
        //        else
        //            AddError(new CustomError(ex.Detail));
        //    }

        //                catch (Exception ex)
        //                {
        //                    AddError(new CustomError(ex.Message));
        //                }
        //            });
        //    if (Errors.Count != 0)
        //        OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //    return result;
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Executes the galaxy CPU command asynchronous operation. </summary>
        /////
        ///// <remarks>   Kevin, 12/26/2018. </remarks>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   A Task&lt;bool&gt; </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<CommandResponse<GalaxyCpuCommandAction>> ExecuteMercScpGroupCommandAsync(CommandParameters<GalaxyCpuCommandAction> parameters)
        //{
        //    InitializeErrorsCollection();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var data = await proxy.ExecuteMercScpGroupCommandAsync(parameters);

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

        //    return null;
        //}
        //#endregion

        #region Get MercScpGroups By Uids with minimal controller data

        public ArrayResponse<MercScpGroupMercScpMinimal> GetMercScpGroupsWithMercScpInfo(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            var data = new ArrayResponse<MercScpGroupMercScpMinimal>();
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetMercScpGroupsWithMercScpMinimal(parameters);
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
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            return data;
        }

        public async Task<ArrayResponse<MercScpGroupMercScpMinimal>> GetMercScpGroupsWithMercScpInfoAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            var data = new ArrayResponse<MercScpGroupMercScpMinimal>();
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetMercScpGroupsWithMercScpMinimalAsync(parameters);
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