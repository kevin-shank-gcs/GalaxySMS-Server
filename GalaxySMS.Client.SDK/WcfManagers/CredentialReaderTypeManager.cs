////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\CredentialReaderTypeManager.cs
//
// summary:	Implements the CredentialReaderTypeManager class
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
    /// <summary>   Manager for credential reader types. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CredentialReaderTypeManager : ManagerBase
    {
        #region Private fields

        /// <summary>   List of types of the credential readers. </summary>
        private List<CredentialReaderType> _CredentialReaderTypes;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the credential readers. </summary>
        ///
        /// <value> A list of types of the credential readers. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<CredentialReaderType> CredentialReaderTypes { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialReaderTypeManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialReaderTypeManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _CredentialReaderTypes = new List<CredentialReaderType>();
        }

        #endregion

        #region Public methods

        #region GetAllCredentialReaderTypes

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all credential reader types. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all credential reader types. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<CredentialReaderType> GetAllCredentialReaderTypes(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _CredentialReaderTypes = new List<CredentialReaderType>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            CredentialReaderType[] data = proxy.GetAllCredentialReaderTypes(parameters);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _CredentialReaderTypes.Add(item);
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

            CredentialReaderTypes = new ReadOnlyCollection<CredentialReaderType>(_CredentialReaderTypes);
            return CredentialReaderTypes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all credential reader types asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all credential reader types asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<CredentialReaderType>> GetAllCredentialReaderTypesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _CredentialReaderTypes = new List<CredentialReaderType>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            CredentialReaderType[] data = await proxy.GetAllCredentialReaderTypesAsync(parameters);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _CredentialReaderTypes.Add(item);
                            }
                            CredentialReaderTypes = new ReadOnlyCollection<CredentialReaderType>(_CredentialReaderTypes);
                            return CredentialReaderTypes;
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

            return CredentialReaderTypes;
        }

        #endregion
        
        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets credential reader type. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The credential reader type. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialReaderType GetCredentialReaderType(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            CredentialReaderType data = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetCredentialReaderType(parameters);
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

            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets credential reader type asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The credential reader type asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<CredentialReaderType> GetCredentialReaderTypeAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            CredentialReaderType data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetCredentialReaderTypeAsync(parameters);
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

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a credential reader type. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A CredentialReaderType. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialReaderType SaveCredentialReaderType(SaveParameters<CredentialReaderType> parameters)
        {
            InitializeErrorsCollection();
            CredentialReaderType saved = null;
            bool isNew = (parameters.Data.CredentialReaderTypeUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            saved = proxy.SaveCredentialReaderType(parameters);
                            _CredentialReaderTypes.Add(saved);
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

            return saved;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a credential reader type asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;CredentialReaderType&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<CredentialReaderType> SaveCredentialReaderTypeAsync(SaveParameters<CredentialReaderType> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            CredentialReaderType saved = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.CredentialReaderTypeUid == Guid.Empty);
                            saved = await proxy.SaveCredentialReaderTypeAsync(parameters);
                            return saved;
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

            return saved;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the credential reader type described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteCredentialReaderType(DeleteParameters<CredentialReaderType> parameters)
        {
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteCredentialReaderType(parameters);
                            _CredentialReaderTypes.Remove(parameters.Data);
                            CredentialReaderTypes = new ReadOnlyCollection<CredentialReaderType>(_CredentialReaderTypes);
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

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the credential reader type asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task DeleteCredentialReaderTypeAsync(DeleteParameters<CredentialReaderType> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                await WithClientAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                        {
                            // For some reason, the DeleteXXXAsync throws a WCF exception
//                            await proxy.DeleteCredentialReaderTypeAsync(parameters);
                            proxy.DeleteCredentialReaderType(parameters);
                            _CredentialReaderTypes.Remove(parameters.Data);
                            CredentialReaderTypes = new ReadOnlyCollection<CredentialReaderType>(_CredentialReaderTypes);
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

        #region DeleteByUniqueId

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the credential reader type by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteCredentialReaderTypeByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteCredentialReaderTypeByPk(parameters);
                            foreach (var i in _CredentialReaderTypes)
                            {
                                if (i.CredentialReaderTypeUid == parameters.UniqueId)
                                {
                                    _CredentialReaderTypes.Remove(i);
                                    break;
                                }
                            }
                            CredentialReaderTypes = new ReadOnlyCollection<CredentialReaderType>(_CredentialReaderTypes);
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

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the credential reader type by unique identifier asynchronous described by
        /// parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task DeleteCredentialReaderTypeByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                await WithClientAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteCountryAsync throws a WCF exception
                            //await proxy.DeleteCountryAsync(parameters);
                            await proxy.DeleteCredentialReaderTypeByPkAsync(parameters);
                            foreach (var i in _CredentialReaderTypes)
                            {
                                if (i.CredentialReaderTypeUid == parameters.UniqueId)
                                {
                                    _CredentialReaderTypes.Remove(i);
                                    break;
                                }
                            }
                            CredentialReaderTypes = new ReadOnlyCollection<CredentialReaderType>(_CredentialReaderTypes);
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