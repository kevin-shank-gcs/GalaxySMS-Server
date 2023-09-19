////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\RoleManager.cs
//
// summary:	Implements the role manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Client.Contracts.NetCore;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for regions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class RegionManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The regions. </summary>
        private List<Region> _Regions;
        private List<ListItemBase> _RegionsList;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the regions. </summary>
        ///
        /// <value> The regions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Region> Regions { get; internal set; }

        public ReadOnlyCollection<ListItemBase> RegionsList { get; internal set; }
        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RegionManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RegionManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _Regions = new List<Region>();
        }

        #endregion

        #region Public methods

        #region Get all regions for entity


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the regions. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The regions. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Region> GetRegions(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _Regions = new List<Region>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            Region[] regions = proxy.GetAllRegionsForEntity(parameters);
                            if (regions != null)
                            {
                                foreach (var region in regions)
                                {
                                    _Regions.Add(region);
                                }
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

            Regions = new ReadOnlyCollection<Region>(_Regions);
            return Regions;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets regions asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The regions asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<Region>> GetRegionsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Regions = new List<Region>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            Region[] regions = await proxy.GetAllRegionsForEntityAsync(parameters);
                            if (regions != null)
                            {
                                foreach (var region in regions)
                                    _Regions.Add(region);
                            }
                            Regions = new ReadOnlyCollection<Region>(_Regions);
                            return Regions;
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

            return Regions;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets regions list items. </summary>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The regions list items. </returns>
        ///=================================================================================================

        public ReadOnlyCollection<ListItemBase> GetRegionsListItems(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _RegionsList = new List<ListItemBase>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var regions = proxy.GetAllRegionsListEntity(parameters);
                            if (regions != null)
                            {
                                foreach (var region in regions)
                                {
                                    _RegionsList.Add(region);
                                }
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

            RegionsList = new ReadOnlyCollection<ListItemBase>(_RegionsList);
            return RegionsList;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets regions list items asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The regions list items asynchronous. </returns>
        ///=================================================================================================

        public async Task<ReadOnlyCollection<ListItemBase>> GetRegionsListItemsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _RegionsList = new List<ListItemBase>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var regions = await proxy.GetAllRegionsListEntityAsync(parameters);
                            if (regions != null)
                            {
                                foreach (var region in regions)
                                    _RegionsList.Add(region);
                            }
                            RegionsList = new ReadOnlyCollection<ListItemBase>(_RegionsList);
                            return RegionsList;
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

            return RegionsList;
        }

        #endregion

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all regions. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all regions. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Region> GetAllRegions(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Regions = new List<Region>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            Region[] regions = proxy.GetAllRegions(parameters);
                            if (regions != null)
                            {
                                foreach (var region in regions)
                                    _Regions.Add(region);
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

            Regions = new ReadOnlyCollection<Region>(_Regions);
            return Regions;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all regions asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all regions asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<Region>> GetAllRegionsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Regions = new List<Region>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            Region[] regions = await proxy.GetAllRegionsAsync(parameters);
                            if (regions != null)
                            {
                                foreach (var region in regions)
                                    _Regions.Add(region);
                            }
                            Regions = new ReadOnlyCollection<Region>(_Regions);
                            return Regions;
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

            return Regions;
        }


        public ReadOnlyCollection<ListItemBase> GetAllRegionsListItems(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _RegionsList = new List<ListItemBase>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var regions = proxy.GetAllRegionsList(parameters);
                            if (regions != null)
                            {
                                foreach (var region in regions)
                                    _RegionsList.Add(region);
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

            RegionsList = new ReadOnlyCollection<ListItemBase>(_RegionsList);
            return RegionsList;
        }

        public async Task<ReadOnlyCollection<ListItemBase>> GetAllRegionsListItemsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _RegionsList = new List<ListItemBase>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var regions = await proxy.GetAllRegionsListAsync(parameters);
                            if (regions != null)
                            {
                                foreach (var region in regions)
                                    _RegionsList.Add(region);
                            }
                            RegionsList = new ReadOnlyCollection<ListItemBase>(_RegionsList);
                            return RegionsList;
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

            return RegionsList;
        }
        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the region described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteRegion(DeleteParameters<Region> parameters)
        {
            int ret = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            ret = proxy.DeleteRegion(parameters);
                            _Regions.Remove(parameters.Data);
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
            return ret;
        }

        //public async Task<int> DeleteRegionAsync(DeleteParameters<Region> parameters)
        //{
        //    InitializeErrorsCollection();
        //    DateTimeOffset startedAt = DateTimeOffset.Now;

        //    try
        //    {
        //        await WithClientAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //                {
        //                    // For some reason, the DeleteRegionAsync throws a WCF exception
        //                    //await proxy.DeleteRegionAsync(parameters);
        //                    proxy.DeleteRegion(parameters);
        //                    _Regions.Remove(parameters.Data);
        //                    Regions = new ReadOnlyCollection<Region>(_Regions);
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
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the region asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteRegionAsync(DeleteParameters<Region> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int ret = 0;
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteRegionAsync throws a WCF exception
                            ret = await proxy.DeleteRegionAsync(parameters);
                            _Regions.Remove(parameters.Data);
                            Regions = new ReadOnlyCollection<Region>(_Regions);
                            return ret;
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
            return ret;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the region by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteRegionByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int x = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            x = proxy.DeleteRegionByPk(parameters);
                            foreach (var r in _Regions)
                            {
                                if (r.RegionUid == parameters.UniqueId)
                                {
                                    _Regions.Remove(r);
                                    break;
                                }
                            }
                            Regions = new ReadOnlyCollection<Region>(_Regions);
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
            return x;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the region by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteRegionByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int x = 0;
            try
            {
                //return await WithClientAsync(
                return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        x = await proxy.DeleteRegionByPkAsync(parameters);
                        foreach (var r in _Regions)
                        {
                            if (r.RegionUid == parameters.UniqueId)
                            {
                                _Regions.Remove(r);
                                break;
                            }
                        }
                        Regions = new ReadOnlyCollection<Region>(_Regions);
                        return x;
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
            return x;
        }

        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a region. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Region. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Region SaveRegion(SaveParameters<Region> parameters)
        {
            InitializeErrorsCollection();
            Region savedRegion = null;
            bool isNew = (parameters.Data.RegionUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedRegion = proxy.SaveRegion(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _Regions
                                                    where i.RegionUid == parameters.Data.RegionUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _Regions.Remove(originalItem);
                            }
                            _Regions.Add(savedRegion);
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

            return savedRegion;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a region asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;Region&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<Region> SaveRegionAsync(SaveParameters<Region> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Region savedRegion = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.RegionUid == Guid.Empty);
                            savedRegion = await proxy.SaveRegionAsync(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _Regions
                                                    where i.RegionUid == parameters.Data.RegionUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _Regions.Remove(originalItem);
                            }
                            return savedRegion;
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

            return savedRegion;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a region. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The region. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Region GetRegion(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            Region region = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            region = proxy.GetRegion(parameters);
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

            return region;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets region asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The region asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<Region> GetRegionAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Region region = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            region = await proxy.GetRegionAsync(parameters);
                            return region;
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

            return region;
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