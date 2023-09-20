﻿////////////////////////////////////////////////////////////////////////////////////////////////////
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
    /// <summary>   Manager for sites. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SiteManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The sites. </summary>
        private List<Site> _Sites;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sites. </summary>
        ///
        /// <value> The sites. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Site> Sites { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SiteManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SiteManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _Sites = new List<Site>();
        }

        #endregion

        #region Public methods

        #region Get all Sites for region

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets sites for region. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The sites for region. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Site> GetSitesForRegion(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _Sites = new List<Site>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            Site[] sites = proxy.GetAllSitesForEntity(parameters);
                            if (sites != null)
                            {
                                foreach (var site in sites)
                                    _Sites.Add(site);
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

            Sites = new ReadOnlyCollection<Site>(_Sites);
            return Sites;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets sites for region asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The sites for region asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<Site>> GetSitesForRegionAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Sites = new List<Site>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            Site[] sites = await proxy.GetAllSitesForRegionAsync(parameters);
                            if (sites != null)
                            {
                                foreach (var site in sites)
                                    _Sites.Add(site);
                            }
                            Sites = new ReadOnlyCollection<Site>(_Sites);
                            return Sites;
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

            return Sites;
        }

        #endregion

        #region GetAllSitesForEntity

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all sites for entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all sites for entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Site> GetAllSitesForEntity(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Sites = new List<Site>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            Site[] sites = proxy.GetAllSitesForEntity(parameters);
                            if (sites != null)
                            {
                                foreach (var site in sites)
                                    _Sites.Add(site);
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

            Sites = new ReadOnlyCollection<Site>(_Sites);
            return Sites;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all sites for entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all sites for entity asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<Site>> GetAllSitesForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Sites = new List<Site>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            Site[] sites = await proxy.GetAllSitesForEntityAsync(parameters);
                            if (sites != null)
                            {
                                foreach (var site in sites)
                                    _Sites.Add(site);
                            }
                            Sites = new ReadOnlyCollection<Site>(_Sites);
                            return Sites;
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

            return Sites;
        }

        #endregion

        #region GetAllSites

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all sites. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all sites. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Site> GetAllSites(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Sites = new List<Site>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            Site[] sites = proxy.GetAllSites(parameters);
                            if (sites != null)
                            {
                                foreach (var site in sites)
                                    _Sites.Add(site);
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

            Sites = new ReadOnlyCollection<Site>(_Sites);
            return Sites;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all sites asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all sites asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<Site>> GetAllSitesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Sites = new List<Site>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            Site[] sites = await proxy.GetAllSitesAsync(parameters);
                            if (sites != null)
                            {
                                foreach (var site in sites)
                                    _Sites.Add(site);
                            }
                            Sites = new ReadOnlyCollection<Site>(_Sites);
                            return Sites;
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

            return Sites;
        }

        #endregion
        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the site described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteSite(DeleteParameters<Site> parameters)
        {
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteSite(parameters);
                            _Sites.Remove(parameters.Data);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the site asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task DeleteSiteAsync(DeleteParameters<Site> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                await WithClientAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                        {
                            // For some reason, the DeleteSiteAsync throws a WCF exception
                            //await proxy.DeleteSiteAsync(parameters);
                            proxy.DeleteSite(parameters);
                            _Sites.Remove(parameters.Data);
                            Sites = new ReadOnlyCollection<Site>(_Sites);
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the site by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteSiteByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteSiteByPk(parameters);
                            foreach (var r in _Sites)
                            {
                                if (r.SiteUid == parameters.UniqueId)
                                {
                                    _Sites.Remove(r);
                                    break;
                                }
                            }
                            Sites = new ReadOnlyCollection<Site>(_Sites);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the site by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task DeleteSiteByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                await WithClientAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            await proxy.DeleteSiteByPkAsync(parameters);
                            foreach (var r in _Sites)
                            {
                                if (r.SiteUid == parameters.UniqueId)
                                {
                                    _Sites.Remove(r);
                                    break;
                                }
                            }
                            Sites = new ReadOnlyCollection<Site>(_Sites);
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

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a site. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Site. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Site SaveSite(SaveParameters<Site> parameters)
        {
            InitializeErrorsCollection();
            Site savedSite = null;
            bool isNew = (parameters.Data.SiteUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedSite = proxy.SaveSite(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _Sites
                                                    where i.SiteUid == parameters.Data.SiteUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _Sites.Remove(originalItem);
                            }
                            _Sites.Add(savedSite);
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

            return savedSite;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a site asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;Site&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<Site> SaveSiteAsync(SaveParameters<Site> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Site savedSite = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.SiteUid == Guid.Empty);
                            savedSite = await proxy.SaveSiteAsync(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _Sites
                                                    where i.SiteUid == parameters.Data.SiteUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _Sites.Remove(originalItem);
                            }
                            return savedSite;
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

            return savedSite;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a site. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The site. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Site GetSite(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            Site Site = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            Site = proxy.GetSite(parameters);
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

            return Site;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets site asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The site asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<Site> GetSiteAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Site Site = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            Site = await proxy.GetSiteAsync(parameters);
                            return Site;
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

            return Site;
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