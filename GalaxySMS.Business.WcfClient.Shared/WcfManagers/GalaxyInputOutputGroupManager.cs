////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyInputOutputGroupManager.cs
//
// summary:	Implements the InputOutputGroup manager class
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
    /// <summary>   Manager for galaxy input output groups. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyInputOutputGroupManager : ManagerBase
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

        public GalaxyInputOutputGroupManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInputOutputGroupManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }

        #endregion

        #region Public methods

        #region Get all GetInputOutput Groups for a Cluster

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets input output groups for cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The input output groups for cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<InputOutputGroup> GetInputOutputGroupsForCluster(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<InputOutputGroup> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllInputOutputGroupsForCluster(parameters);
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
        /// <summary>   Gets input output groups for cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The input output groups for cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<InputOutputGroup>> GetInputOutputGroupsForClusterAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<InputOutputGroup> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllInputOutputGroupsForClusterAsync(parameters);
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

        #region Get all GetInputOutput Groups for a Cluster Address

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets input output groups for cluster by address ( account code and cluster number). </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The input output groups for cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<InputOutputGroup> GetInputOutputGroupsForClusterAddress(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<InputOutputGroup> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllInputOutputGroupsForClusterAddress(parameters);
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
        /// <summary>   Gets input output groups for cluster address ( account code and cluster number) asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The input output groups for cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<InputOutputGroup>> GetInputOutputGroupsForClusterAddressAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<InputOutputGroup> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllInputOutputGroupsForClusterAddressAsync(parameters);

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

        #region Get all InputOutput Groups For a Entity

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all input output groups for entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all input output groups for entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<InputOutputGroup> GetAllInputOutputGroupsForEntity(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<InputOutputGroup> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllInputOutputGroupsForEntity(parameters);
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
        /// <summary>   Gets all input output groups for entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all input output groups for entity asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<InputOutputGroup>> GetAllInputOutputGroupsForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<InputOutputGroup> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllInputOutputGroupsForEntityAsync(parameters);

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

        #region Get All InputOutput Groups

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all input output groups. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all input output groups. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<InputOutputGroup> GetAllInputOutputGroups(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<InputOutputGroup> data = null;

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllInputOutputGroups(parameters);
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
        /// <summary>   Gets all input output groups asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all input output groups asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<InputOutputGroup>> GetAllInputOutputGroupsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<InputOutputGroup> data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetAllInputOutputGroupsAsync(parameters);

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
        /// <summary>   Deletes the input output group described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteInputOutputGroup(DeleteParameters<InputOutputGroup> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteInputOutputGroup(parameters);
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
        /// <summary>   Deletes the input output group asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteInputOutputGroupAsync(DeleteParameters<InputOutputGroup> parameters)
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
                            countDeleted = await proxy.DeleteInputOutputGroupAsync(parameters);
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
        /// Deletes the input output group by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteInputOutputGroupByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteInputOutputGroupByPk(parameters);
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
        /// Deletes the input output group by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteInputOutputGroupByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteInputOutputGroupByPkAsync(parameters);
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
        /// <summary>   Saves an input output group. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An InputOutputGroup. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputOutputGroup SaveInputOutputGroup(SaveParameters<InputOutputGroup> parameters)
        {
            InitializeErrorsCollection();
            InputOutputGroup savedItem = null;
            bool isNew = (parameters.Data.InputOutputGroupUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveInputOutputGroup(parameters);
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
        /// <summary>   Saves an input output group asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;InputOutputGroup&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<InputOutputGroup> SaveInputOutputGroupAsync(SaveParameters<InputOutputGroup> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            InputOutputGroup savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.InputOutputGroupUid == Guid.Empty);
                            savedItem = await proxy.SaveInputOutputGroupAsync(parameters);
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

            return savedItem;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets input output group. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The input output group. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputOutputGroup GetInputOutputGroup(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            InputOutputGroup InputOutputGroup = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            InputOutputGroup = proxy.GetInputOutputGroup(parameters);
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

            return InputOutputGroup;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets input output group asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The input output group asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<InputOutputGroup> GetInputOutputGroupAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            InputOutputGroup InputOutputGroup = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            InputOutputGroup = await proxy.GetInputOutputGroupAsync(parameters);
                            return InputOutputGroup;
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

            return InputOutputGroup;
        }

        #endregion

        #region Get by Cluster Address and IOGroup number

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets input output group. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The input output group. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputOutputGroup GetInputOutputGroupsForClusterAddressAndInputOutputGroupNumber(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            InputOutputGroup InputOutputGroup = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            InputOutputGroup = proxy.GetInputOutputGroupForClusterAddressAndInputOutputGroupNumber(parameters);
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

            return InputOutputGroup;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets input output group asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The input output group asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<InputOutputGroup> GetInputOutputGroupByClusterAddressAndInputOutputGroupNumberAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            InputOutputGroup InputOutputGroup = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            InputOutputGroup = await proxy.GetInputOutputGroupForClusterAddressAndInputOutputGroupNumberAsync(parameters);
                            return InputOutputGroup;
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

            return InputOutputGroup;
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

        public bool ExecuteCommand(CommandParameters<InputOutputGroupCommandAction> parameters)
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
                            result = proxy.ExecuteInputOutputGroupCommand(parameters);
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

        public async Task<bool> ExecuteCommandAsync(CommandParameters<InputOutputGroupCommandAction> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.ExecuteInputOutputGroupCommandAsync(parameters);
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