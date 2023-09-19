////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\MercScpManager.cs
//
// summary:	Implements the MercScp manager class
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
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for mercury scp panels. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MercScpManager : ManagerBase
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

        public MercScpManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScpManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }

        #endregion

        #region Public methods

        #region Get all MercScps for a MercScpGroup

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets mercury scp panels for cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The mercury scp panels for cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<MercScp> GetMercScpsForMercScpGroup(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<MercScp> data = null;

            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllMercScpsForMercScpGroup(parameters);
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
        /// <summary>   Gets mercury scp panels for cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The mercury scp panels for cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<MercScp>> GetMercScpsForMercScpGroupAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<MercScp> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllMercScpsForMercScpGroupAsync(parameters);
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

        #region Get MercScps for a Site

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets mercury scp panels for site. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The mercury scp panels for site. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<MercScp> GetMercScpsForSite(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<MercScp> data = null;

            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllMercScpsForSite(parameters);
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
        /// <summary>   Gets mercury scp panels for site asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The mercury scp panels for site asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<MercScp>> GetMercScpsForSiteAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<MercScp> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllMercScpsForSiteAsync(parameters);
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

        //#region Get MercScps For a Entity

        //public ArrayResponse<MercScp> GetAllMercScpsForEntity(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    ArrayResponse<MercScp> data = null;

        //    WithClient<IMercuryManagementService>(
        //        _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    data = proxy.GetAllMercScpsForEntity(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //_MercScps.Add(o);
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

        //public async Task<ArrayResponse<MercScp>> GetAllMercScpsForEntityAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    ArrayResponse<MercScp> data = null;

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    data = await proxy.GetAllMercScpsForEntityAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //_MercScps.Add(o);
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

        #region Get All MercScps

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all mercury scp panels. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all mercury scp panels. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<MercScp> GetAllMercScps(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<MercScp> data = null;

            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllMercScps(parameters);
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all mercury scp panels asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all mercury scp panels asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<MercScp>> GetAllMercScpsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<MercScp> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllMercScpsAsync(parameters);

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
        /// <summary>   Deletes the mercury scp panel described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteMercScp(DeleteParameters<MercScp> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteMercScp(parameters);
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
        /// <summary>   Deletes the mercury scp panel asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteMercScpAsync(DeleteParameters<MercScp> parameters)
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
                            // For some reason, the DeleteMercScpAsync throws a WCF exception
                            countDeleted = await proxy.DeleteMercScpAsync(parameters);
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
        /// <summary>   Deletes the mercury scp panel by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteMercScpByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteMercScpByPk(parameters);
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
        /// Deletes the mercury scp panel by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteMercScpByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteMercScpByPkAsync(parameters);
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
        /// <summary>   Saves a mercury scp panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A MercScp. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScp SaveMercScp(SaveParameters<MercScp> parameters)
        {
            InitializeErrorsCollection();
            MercScp savedItem = null;
            bool isNew = (parameters.Data.MercScpUid == Guid.Empty);
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveMercScp(parameters);
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
        /// <summary>   Saves a mercury scp panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;MercScp&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<MercScp> SaveMercScpAsync(SaveParameters<MercScp> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            MercScp savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.MercScpUid == Guid.Empty);
                            savedItem = await proxy.SaveMercScpAsync(parameters);
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

        #region Save Mercury Panels

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a mercury scp panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A MercScp. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveResponse<List<MercuryPanel>> SaveMercuryPanels(SaveParameters<List<MercuryPanel>> parameters)
        {
            InitializeErrorsCollection();
            SaveResponse<List<MercuryPanel>> results = null;
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            results = proxy.SaveMercuryPanels(parameters);
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

            return results;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a mercury scp panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;MercScp&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<SaveResponse<List<MercuryPanel>>> SaveMercuryPanelsAsync(SaveParameters<List<MercuryPanel>> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            var results = await proxy.SaveMercuryPanelsAsync(parameters);
                            return results;
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

            return null;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets mercury scp panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The mercury scp panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScp GetMercScp(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            MercScp MercScp = null;
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            MercScp = proxy.GetMercScp(parameters);
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

            return MercScp;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets mercury scp panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The mercury scp panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<MercScp> GetMercScpAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            MercScp MercScp = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            MercScp = await proxy.GetMercScpAsync(parameters);
                            return MercScp;
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

            return MercScp;
        }

        #endregion

        //#region Get by Hardware Address

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets mercury scp panel. </summary>
        /////
        ///// <remarks>   Kevin, 12/26/2018. </remarks>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   The mercury scp panel. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public MercScp GetMercScpByHardwareAddress(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    MercScp MercScp = null;
        //    WithClient<IMercuryManagementService>(
        //        _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    MercScp = proxy.GetMercScpByHardwareAddress(parameters);
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

        //    return MercScp;
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets mercury scp panel asynchronous. </summary>
        /////
        ///// <remarks>   Kevin, 12/26/2018. </remarks>
        /////
        ///// <param name="parameters">   Options for controlling the operation. </param>
        /////
        ///// <returns>   The mercury scp panel asynchronous. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<MercScp> GetMercScpByHardwareAddressAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    DateTimeOffset startedAt = DateTimeOffset.Now;
        //    MercScp MercScp = null;

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    MercScp = await proxy.GetMercScpByHardwareAddressAsync(parameters);
        //                    return MercScp;
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

        //    return MercScp;
        //}

        //#endregion

        #region Get Mercury SCP Panel Editor Data

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets mercury scp panel editing data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The mercury scp panel editing data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScpEditingData GetMercScpEditingData(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            MercScpEditingData editingData = null;
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            editingData = proxy.GetMercScpEditingData(parameters);
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

            return editingData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets mercury scp panel editing data asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The mercury scp panel editing data asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<MercScpEditingData> GetMercScpEditingDataAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            MercScpEditingData editingData = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            editingData = await proxy.GetMercScpEditingDataAsync(parameters);
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
        /// <summary>   Gets mercury scp panel activity history events. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The mercury scp panel activity history events. </returns>
        ///=================================================================================================

        public ArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(ActivityHistoryEventSearchParameters parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<ActivityHistoryEvent> data = null;

            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetMercScpActivityHistoryEvents(parameters);
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets mercury scp panel activity history events asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The mercury scp panel activity history events asynchronous. </returns>
        ///=================================================================================================

        public async Task<ArrayResponse<ActivityHistoryEvent>> GetActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetMercScpActivityHistoryEventsAsync(parameters);
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
        /// <summary>   Validates the mercury scp panel described by data. </summary>
        ///
        /// <remarks>   Kevin, 10/3/2022. </remarks>
        ///
        /// <param name="parameters"> The data. </param>
        ///
        /// <returns>   The ValidationProblemDetails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ValidationProblemDetails ValidateMercScp(SaveParameters<MercScp> parameters)
        {
            InitializeErrorsCollection();
            ValidationProblemDetails savedItem = null;
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.ValidateMercScp(parameters);
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
        /// <summary>   Validates the mercury scp panel asynchronous described by data. </summary>
        ///
        /// <remarks>   Kevin, 10/3/2022. </remarks>
        ///
        /// <param name="parameters"> The data. </param>
        ///
        /// <returns>   The validate mercury scp panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ValidationProblemDetails> ValidateMercScpAsync(SaveParameters<MercScp> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            var savedItem = await proxy.ValidateMercScpAsync(parameters);
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