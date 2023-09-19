////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\ClusterManager.cs
//
// summary:	Implements the Cluster manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Client.Contracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.ServiceModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for clusters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ClusterManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The clusters. </summary>
        private List<Cluster> _Clusters;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the clusters. </summary>
        ///
        /// <value> The clusters. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Cluster> Clusters { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _Clusters = new List<Cluster>();
        }

        #endregion

        #region Public methods

        //#region Get all Clusters for a Region

        //public ReadOnlyCollection<Cluster> GetClustersForRegion(GetParametersWithPhoto parameters, bool rethrow)
        //{
        //    InitializeErrorsCollection();
        //    _Clusters = new List<Cluster>();

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    var data = proxy.GetAllClustersForRegion(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _Clusters.Add(o);
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

        //    Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
        //    return Clusters;
        //}

        //public async Task<ReadOnlyCollection<Cluster>> GetClustersForRegionAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _Clusters = new List<Cluster>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var data = await proxy.GetAllClustersForRegionAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _Clusters.Add(o);
        //                    }
        //                    Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
        //                    return Clusters;
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

        //    return Clusters;
        //}

        //#endregion

        #region Get Clusters for a Site

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

        public ReadOnlyCollection<Cluster> GetClustersForSite(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _Clusters = new List<Cluster>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllClustersForSite(parameters);
                            if (data != null)
                            {
                                foreach (var o in data.Items)
                                    _Clusters.Add(o);
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

            Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
            return Clusters;
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

        public async Task<ReadOnlyCollection<Cluster>> GetClustersForSiteAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Clusters = new List<Cluster>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllClustersForSiteAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data.Items)
                                    _Clusters.Add(o);
                            }
                            Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
                            return Clusters;
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

            return Clusters;
        }

        #endregion

        #region Get Clusters For a Entity

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

        public ReadOnlyCollection<Cluster> GetAllClustersForEntity(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Clusters = new List<Cluster>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllClustersForEntity(parameters);
                            if (data != null)
                            {
                                foreach (var o in data.Items)
                                    _Clusters.Add(o);
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

            Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
            return Clusters;
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
        public async Task<ReadOnlyCollection<Cluster>> GetAllClustersForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Clusters = new List<Cluster>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllClustersForEntityAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data.Items)
                                    _Clusters.Add(o);
                            }
                            Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
                            return Clusters;
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

            return Clusters;
        }

        #endregion

        #region Get All Clusters

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all clusters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all clusters. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Cluster> GetAllClusters(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Clusters = new List<Cluster>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllClusters(parameters);
                            if (data != null)
                            {
                                foreach (var o in data.Items)
                                    _Clusters.Add(o);
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

            Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
            return Clusters;
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

        public async Task<ReadOnlyCollection<Cluster>> GetAllClustersAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Clusters = new List<Cluster>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllClustersAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data.Items)
                                    _Clusters.Add(o);
                            }
                            Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
                            return Clusters;
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

            return Clusters;
        }

        #endregion

        //#region Get List Operations
        //public async Task<ReadOnlyCollection<ListItemBase>> GetAllClustersListAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    var list = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var items = await proxy.GetAllClustersListAsync(parameters);
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
        //public async Task<ReadOnlyCollection<ListItemBase>> GetAllClustersForEntityListAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    var list = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var items = await proxy.GetAllClustersForEntityListAsync(parameters);
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
        //public async Task<ReadOnlyCollection<ListItemBase>> GetAllClustersForSiteListAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    var list = new List<ListItemBase>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var items = await proxy.GetAllClustersForSiteListAsync(parameters);
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
        public async Task<ArrayResponse<ClusterListItemCommands>> GetAllClustersListAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            var list = new ArrayResponse<ClusterListItemCommands>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            list = await proxy.GetAllClustersListAsync(parameters);
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
        public async Task<ArrayResponse<ClusterListItemCommands>> GetAllClustersForEntityListAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            var list = new ArrayResponse<ClusterListItemCommands>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            list = await proxy.GetAllClustersForEntityListAsync(parameters);
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
        public async Task<ArrayResponse<ClusterListItemCommands>> GetAllClustersForSiteListAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            var list = new ArrayResponse<ClusterListItemCommands>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            list = await proxy.GetAllClustersForSiteListAsync(parameters);
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

        public int DeleteCluster(DeleteParameters<Cluster> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteCluster(parameters);
                            if (countDeleted == 1)
                            {
                                _Clusters.Remove(parameters.Data);
                                Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
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
        /// <summary>   Deletes the cluster asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteClusterAsync(DeleteParameters<Cluster> parameters)
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
                            countDeleted = await proxy.DeleteClusterAsync(parameters);
                            if (countDeleted == 1)
                            {
                                _Clusters.Remove(parameters.Data);
                                Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
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
        /// <summary>   Deletes the cluster by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteClusterByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteClusterByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _Clusters)
                                {
                                    if (o.ClusterUid == parameters.UniqueId)
                                    {
                                        _Clusters.Remove(o);
                                        break;
                                    }
                                }
                                Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
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
        /// Deletes the cluster by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteClusterByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteClusterByPkAsync(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _Clusters)
                                {
                                    if (o.ClusterUid == parameters.UniqueId)
                                    {
                                        _Clusters.Remove(o);
                                        break;
                                    }
                                }
                                Clusters = new ReadOnlyCollection<Cluster>(_Clusters);
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

        #region Validate

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validate a cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ValidationProblemDetails ValidateCluster(SaveParameters<Cluster> parameters)
        {
            InitializeErrorsCollection();
            ValidationProblemDetails savedItem = null;
            bool isNew = (parameters.Data.ClusterUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.ValidateCluster(parameters);
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
        /// <returns>   A Task&lt;Cluster&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ValidationProblemDetails> ValidateClusterAsync(SaveParameters<Cluster> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            ValidationProblemDetails savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.ClusterUid == Guid.Empty);
                            savedItem = await proxy.ValidateClusterAsync(parameters);
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
        /// <returns>   A Cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Cluster SaveCluster(SaveParameters<Cluster> parameters)
        {
            InitializeErrorsCollection();
            Cluster savedItem = null;
            bool isNew = (parameters.Data.ClusterUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveCluster(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _Clusters
                                                    where i.ClusterUid == parameters.Data.ClusterUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _Clusters.Remove(originalItem);
                            }
                            _Clusters.Add(savedItem);
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
        /// <summary>   Saves a cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;Cluster&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<Cluster> SaveClusterAsync(SaveParameters<Cluster> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Cluster savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.ClusterUid == Guid.Empty);
                            savedItem = await proxy.SaveClusterAsync(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _Clusters
                                                    where i.ClusterUid == parameters.Data.ClusterUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _Clusters.Remove(originalItem);
                            }
                            _Clusters.Add(savedItem);
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
        /// <summary>   Gets a cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Cluster GetCluster(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            Cluster Cluster = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            Cluster = proxy.GetCluster(parameters);
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

            return Cluster;
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

        public async Task<Cluster> GetClusterAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Cluster Cluster = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            Cluster = await proxy.GetClusterAsync(parameters);
                            return Cluster;
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

            return Cluster;
        }

        #endregion

        #region Get by Hardware Address

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Cluster GetClusterByHardwareAddress(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            Cluster Cluster = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            Cluster = proxy.GetClusterByHardwareAddress(parameters);
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

            return Cluster;
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

        public async Task<Cluster> GetClusterByHardwareAddressAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Cluster Cluster = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            Cluster = await proxy.GetClusterByHardwareAddressAsync(parameters);
                            return Cluster;
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

            return Cluster;
        }

        #endregion

        #region Get Cluster Editor Data

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets cluster editing data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The cluster editing data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterEditingData GetClusterEditingData(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ClusterEditingData clusterEditingData = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            clusterEditingData = proxy.GetClusterEditingData(parameters);
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

        public async Task<ClusterEditingData> GetClusterEditingDataAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            ClusterEditingData clusterEditingData = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            clusterEditingData = await proxy.GetClusterEditingDataAsync(parameters);
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

        #region Execute Cluster Command
        public CommandResponse<GalaxyCpuCommandAction> ExecuteClusterCommand(CommandParameters<GalaxyCpuCommandAction> parameters)
        {
            InitializeErrorsCollection();

            CommandResponse<GalaxyCpuCommandAction> result = null;
            DateTimeOffset startedAt = DateTimeOffset.Now;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(
                    Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService),
                    ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            result = proxy.ExecuteClusterCommand(parameters);
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
        /// <summary>   Executes the galaxy CPU command asynchronous operation. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<CommandResponse<GalaxyCpuCommandAction>> ExecuteClusterCommandAsync(CommandParameters<GalaxyCpuCommandAction> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.ExecuteClusterCommandAsync(parameters);

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