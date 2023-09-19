////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\UserDefinedPropertyManager.cs
//
// summary:	Implements the UserDefinedProperty manager class
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
    /// <summary>   Manager for user defined properties. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UserDefinedPropertyManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The user defined properties. </summary>
        private List<UserDefinedProperty> _UserDefinedProperties;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user defined properties. </summary>
        ///
        /// <value> The user defined properties. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<UserDefinedProperty> UserDefinedProperties { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserDefinedPropertyManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserDefinedPropertyManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _UserDefinedProperties = new List<UserDefinedProperty>();
        }

        #endregion

        #region Public methods

        #region Get all UserDefinedProperties For a Entity

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user defined propertys for entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all user defined propertys for entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<UserDefinedProperty> GetAllUserDefinedPropertysForEntity(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _UserDefinedProperties = new List<UserDefinedProperty>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllUserDefinedPropertiesForEntity(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _UserDefinedProperties.Add(o);
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

            UserDefinedProperties = new ReadOnlyCollection<UserDefinedProperty>(_UserDefinedProperties);
            return UserDefinedProperties;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user defined propertys for entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all user defined propertys for entity asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<UserDefinedProperty>> GetAllUserDefinedPropertysForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _UserDefinedProperties = new List<UserDefinedProperty>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllUserDefinedPropertiesForEntityAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _UserDefinedProperties.Add(o);
                            }
                            UserDefinedProperties = new ReadOnlyCollection<UserDefinedProperty>(_UserDefinedProperties);
                            return UserDefinedProperties;
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

            return UserDefinedProperties;
        }

        #endregion

        #region Get All UserDefinedProperties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user defined propertys. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all user defined propertys. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<UserDefinedProperty> GetAllUserDefinedPropertys(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _UserDefinedProperties = new List<UserDefinedProperty>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllUserDefinedProperties(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _UserDefinedProperties.Add(o);
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

            UserDefinedProperties = new ReadOnlyCollection<UserDefinedProperty>(_UserDefinedProperties);
            return UserDefinedProperties;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user defined propertys asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all user defined propertys asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<UserDefinedProperty>> GetAllUserDefinedPropertysAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _UserDefinedProperties = new List<UserDefinedProperty>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllUserDefinedPropertiesAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _UserDefinedProperties.Add(o);
                            }
                            UserDefinedProperties = new ReadOnlyCollection<UserDefinedProperty>(_UserDefinedProperties);
                            return UserDefinedProperties;
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

            return UserDefinedProperties;
        }

        #endregion


        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the user defined property described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteUserDefinedProperty(DeleteParameters<UserDefinedProperty> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteUserDefinedProperty(parameters);
                            if (countDeleted == 1)
                            {
                                _UserDefinedProperties.Remove(parameters.Data);
                                UserDefinedProperties = new ReadOnlyCollection<UserDefinedProperty>(_UserDefinedProperties);
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
        /// Deletes the user defined property asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteUserDefinedPropertyAsync(DeleteParameters<UserDefinedProperty> parameters)
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
                            countDeleted = await proxy.DeleteUserDefinedPropertyAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _UserDefinedProperties.Remove(parameters.Data);
                                UserDefinedProperties = new ReadOnlyCollection<UserDefinedProperty>(_UserDefinedProperties);
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
        /// Deletes the user defined property by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteUserDefinedPropertyByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteUserDefinedPropertyByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _UserDefinedProperties)
                                {
                                    if (o.UserDefinedPropertyUid == parameters.UniqueId)
                                    {
                                        _UserDefinedProperties.Remove(o);
                                        break;
                                    }
                                }
                                UserDefinedProperties = new ReadOnlyCollection<UserDefinedProperty>(_UserDefinedProperties);
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
        /// Deletes the user defined property by unique identifier asynchronous described by
        /// parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteUserDefinedPropertyByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteUserDefinedPropertyByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _UserDefinedProperties)
                                {
                                    if (o.UserDefinedPropertyUid == parameters.UniqueId)
                                    {
                                        _UserDefinedProperties.Remove(o);
                                        break;
                                    }
                                }
                                UserDefinedProperties = new ReadOnlyCollection<UserDefinedProperty>(_UserDefinedProperties);
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
        /// <summary>   Saves a user defined property. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An UserDefinedProperty. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserDefinedProperty SaveUserDefinedProperty(SaveParameters<UserDefinedProperty> parameters)
        {
            InitializeErrorsCollection();
            UserDefinedProperty savedItem = null;
            bool isNew = (parameters.Data.UserDefinedPropertyUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveUserDefinedProperty(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _UserDefinedProperties
                                    where i.UserDefinedPropertyUid == parameters.Data.UserDefinedPropertyUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _UserDefinedProperties.Remove(originalItem);
                            }
                            _UserDefinedProperties.Add(savedItem);
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
        /// <summary>   Saves a user defined property asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;UserDefinedProperty&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserDefinedProperty> SaveUserDefinedPropertyAsync(SaveParameters<UserDefinedProperty> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            UserDefinedProperty savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.UserDefinedPropertyUid == Guid.Empty);
                            savedItem = await proxy.SaveUserDefinedPropertyAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _UserDefinedProperties
                                    where i.UserDefinedPropertyUid == parameters.Data.UserDefinedPropertyUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _UserDefinedProperties.Remove(originalItem);
                            }
                            _UserDefinedProperties.Add(savedItem);
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


        #region Save UserDefinedProperties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user defined properties. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An UserInterfacePageControlData. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserInterfacePageControlData SaveUserDefinedProperties(SaveParameters<List<UserDefinedProperty>> parameters)
        {
            InitializeErrorsCollection();
            UserInterfacePageControlData result = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            result = proxy.SaveUserDefinedProperties(parameters);
                            
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
        /// <summary>   Saves a user defined properties asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;UserInterfacePageControlData&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserInterfacePageControlData> SaveUserDefinedPropertiesAsync(SaveParameters<List<UserDefinedProperty>> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            UserInterfacePageControlData result = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            result = await proxy.SaveUserDefinedPropertiesAsync(parameters);
                            return result;
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

            return result;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user defined property. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The user defined property. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserDefinedProperty GetUserDefinedProperty(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            UserDefinedProperty UserDefinedProperty = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            UserDefinedProperty = proxy.GetUserDefinedProperty(parameters);
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

            return UserDefinedProperty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user defined property asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The user defined property asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserDefinedProperty> GetUserDefinedPropertyAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            UserDefinedProperty UserDefinedProperty = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            UserDefinedProperty = await proxy.GetUserDefinedPropertyAsync(parameters);
                            return UserDefinedProperty;
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

            return UserDefinedProperty;
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