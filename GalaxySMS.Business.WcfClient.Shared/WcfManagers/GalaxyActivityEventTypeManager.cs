////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyActivityEventTypeManager.cs
//
// summary:	Implements the GalaxyActivityEventType manager class
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
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for galaxy activity event types. </summary>
    ///
    /// <remarks>   Kevin, 1/9/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyActivityEventTypeManager : ManagerBase
    {
        #region Private fields


        /// <summary>   List of types of the galaxy activity events. </summary>
        private List<GalaxyActivityEventType> _GalaxyActivityEventTypes;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the galaxy activity events. </summary>
        ///
        /// <value> A list of types of the galaxy activity events. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyActivityEventType> GalaxyActivityEventTypes { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyActivityEventTypeManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyActivityEventTypeManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _GalaxyActivityEventTypes = new List<GalaxyActivityEventType>();
        }

        #endregion

        #region Public methods

        #region Get all GalaxyActivityEventTypes For a Culture

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy activity event types for culture. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy activity event types for culture. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyActivityEventType> GetAllGalaxyActivityEventTypesForCulture(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyActivityEventTypes = new List<GalaxyActivityEventType>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyActivityEventTypeForCulture(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyActivityEventTypes.Add(o);
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

            GalaxyActivityEventTypes = new ReadOnlyCollection<GalaxyActivityEventType>(_GalaxyActivityEventTypes);
            return GalaxyActivityEventTypes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy activity event types for entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy activity event types for entity asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyActivityEventType>> GetAllGalaxyActivityEventTypesForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyActivityEventTypes = new List<GalaxyActivityEventType>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyActivityEventTypeForCultureAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyActivityEventTypes.Add(o);
                            }
                            GalaxyActivityEventTypes = new ReadOnlyCollection<GalaxyActivityEventType>(_GalaxyActivityEventTypes);
                            return GalaxyActivityEventTypes;
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

            return GalaxyActivityEventTypes;
        }

        #endregion

        #region Get All GalaxyActivityEventTypes

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy activity event types. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy activity event types. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyActivityEventType> GetAllGalaxyActivityEventTypes(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyActivityEventTypes = new List<GalaxyActivityEventType>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyActivityEventType(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyActivityEventTypes.Add(o);
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

            GalaxyActivityEventTypes = new ReadOnlyCollection<GalaxyActivityEventType>(_GalaxyActivityEventTypes);
            return GalaxyActivityEventTypes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy activity event types asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy activity event types asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyActivityEventType>> GetAllGalaxyActivityEventTypesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyActivityEventTypes = new List<GalaxyActivityEventType>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyActivityEventTypeAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyActivityEventTypes.Add(o);
                            }
                            GalaxyActivityEventTypes = new ReadOnlyCollection<GalaxyActivityEventType>(_GalaxyActivityEventTypes);
                            return GalaxyActivityEventTypes;
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

            return GalaxyActivityEventTypes;
        }

        #endregion

        #region Get All GalaxyActivityEventTypes Grouped

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy activity event types grouped by device type. </summary>
        ///
        /// <remarks>   Kevin, 4/27/2023. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy activity event types. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyActivityEventTypeBasicGroups GetGalaxyActivityEventTypes(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyActivityEventTypeBasicGroups results = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        { 
                            results = proxy.GetGalaxyActivityEventTypes(parameters);
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

            return results;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy activity event types grouped by device type async. </summary>
        ///
        /// <remarks>   Kevin, 4/27/2023. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy activity event types. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyActivityEventTypeBasicGroups> GetGalaxyActivityEventTypesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetGalaxyActivityEventTypesAsync(parameters);
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

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the galaxy activity event type described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyActivityEventType(DeleteParameters<GalaxyActivityEventType> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyActivityEventType(parameters);
                            if (countDeleted == 1)
                            {
                                _GalaxyActivityEventTypes.Remove(parameters.Data);
                                GalaxyActivityEventTypes = new ReadOnlyCollection<GalaxyActivityEventType>(_GalaxyActivityEventTypes);
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
        /// Deletes the galaxy activity event type asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyActivityEventTypeAsync(DeleteParameters<GalaxyActivityEventType> parameters)
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
                            countDeleted = await proxy.DeleteGalaxyActivityEventTypeAsync(parameters);
                            if (countDeleted == 1)
                            {
                                _GalaxyActivityEventTypes.Remove(parameters.Data);
                                GalaxyActivityEventTypes = new ReadOnlyCollection<GalaxyActivityEventType>(_GalaxyActivityEventTypes);
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
        /// Deletes the galaxy activity event type by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyActivityEventTypeByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyActivityEventTypeByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _GalaxyActivityEventTypes)
                                {
                                    if (o.GalaxyActivityEventTypeUid == parameters.UniqueId)
                                    {
                                        _GalaxyActivityEventTypes.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyActivityEventTypes = new ReadOnlyCollection<GalaxyActivityEventType>(_GalaxyActivityEventTypes);
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
        /// Deletes the galaxy activity event type by unique identifier asynchronous described by
        /// parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyActivityEventTypeByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteGalaxyActivityEventTypeByPkAsync(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _GalaxyActivityEventTypes)
                                {
                                    if (o.GalaxyActivityEventTypeUid == parameters.UniqueId)
                                    {
                                        _GalaxyActivityEventTypes.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyActivityEventTypes = new ReadOnlyCollection<GalaxyActivityEventType>(_GalaxyActivityEventTypes);
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
        /// <summary>   Saves a galaxy activity event type. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxyActivityEventType. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyActivityEventType SaveGalaxyActivityEventType(SaveParameters<GalaxyActivityEventType> parameters)
        {
            InitializeErrorsCollection();
            GalaxyActivityEventType savedItem = null;
            bool isNew = (parameters.Data.GalaxyActivityEventTypeUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyActivityEventType(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _GalaxyActivityEventTypes
                                                    where i.GalaxyActivityEventTypeUid == parameters.Data.GalaxyActivityEventTypeUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyActivityEventTypes.Remove(originalItem);
                            }
                            _GalaxyActivityEventTypes.Add(savedItem);
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
        /// <summary>   Saves a galaxy activity event type asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;GalaxyActivityEventType&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyActivityEventType> SaveGalaxyActivityEventTypeAsync(SaveParameters<GalaxyActivityEventType> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyActivityEventType savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.GalaxyActivityEventTypeUid == Guid.Empty);
                            savedItem = await proxy.SaveGalaxyActivityEventTypeAsync(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _GalaxyActivityEventTypes
                                                    where i.GalaxyActivityEventTypeUid == parameters.Data.GalaxyActivityEventTypeUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyActivityEventTypes.Remove(originalItem);
                            }
                            _GalaxyActivityEventTypes.Add(savedItem);
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
        /// <summary>   Gets galaxy activity event type. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy activity event type. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyActivityEventType GetGalaxyActivityEventType(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyActivityEventType GalaxyActivityEventType = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            GalaxyActivityEventType = proxy.GetGalaxyActivityEventType(parameters);
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

            return GalaxyActivityEventType;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy activity event type asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy activity event type asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyActivityEventType> GetGalaxyActivityEventTypeAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyActivityEventType GalaxyActivityEventType = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            GalaxyActivityEventType = await proxy.GetGalaxyActivityEventTypeAsync(parameters);
                            return GalaxyActivityEventType;
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

            return GalaxyActivityEventType;
        }

        #endregion

        #region Get by EventType

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy activity event type by event type. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy activity event type by event type. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyActivityEventType GetGalaxyActivityEventTypeByEventType(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyActivityEventType GalaxyActivityEventType = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            GalaxyActivityEventType = proxy.GetGalaxyActivityEventTypeByEventType(parameters);
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

            return GalaxyActivityEventType;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy activity event type by event type asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy activity event type by event type asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyActivityEventType> GetGalaxyActivityEventTypeByEventTypeAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyActivityEventType GalaxyActivityEventType = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            GalaxyActivityEventType = await proxy.GetGalaxyActivityEventTypeByEventTypeAsync(parameters);
                            return GalaxyActivityEventType;
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

            return GalaxyActivityEventType;
        }

        #endregion

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Kevin, 1/9/2019. </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}