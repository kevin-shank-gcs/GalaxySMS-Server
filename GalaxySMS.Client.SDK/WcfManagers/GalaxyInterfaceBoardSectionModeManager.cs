////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyInterfaceBoardSectionModeManager.cs
//
// summary:	Implements the InterfaceBoardSectionMode manager class
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
    /// <summary>   Manager for galaxy interface board section modes. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyInterfaceBoardSectionModeManager : ManagerBase
    {
        #region Private fields

        /// <summary>   List of types of the interface boards. </summary>
        private List<InterfaceBoardSectionMode> _InterfaceBoardTypes;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board section modes. </summary>
        ///
        /// <value> The interface board section modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<InterfaceBoardSectionMode> InterfaceBoardSectionModes { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSectionModeManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyInterfaceBoardSectionModeManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _InterfaceBoardTypes = new List<InterfaceBoardSectionMode>();
        }

        #endregion

        #region Public methods

        #region Get All Modes

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all interface board section modes. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all interface board section modes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<InterfaceBoardSectionMode> GetAllInterfaceBoardSectionModes(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _InterfaceBoardTypes = new List<InterfaceBoardSectionMode>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionModes(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _InterfaceBoardTypes.Add(o);
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

            InterfaceBoardSectionModes = new ReadOnlyCollection<InterfaceBoardSectionMode>(_InterfaceBoardTypes);
            return InterfaceBoardSectionModes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy interface board section modes asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy interface board section modes asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<InterfaceBoardSectionMode>> GetAllGalaxyInterfaceBoardSectionModesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _InterfaceBoardTypes = new List<InterfaceBoardSectionMode>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionModesAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _InterfaceBoardTypes.Add(o);
                            }
                            InterfaceBoardSectionModes = new ReadOnlyCollection<InterfaceBoardSectionMode>(_InterfaceBoardTypes);
                            return InterfaceBoardSectionModes;
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

            return InterfaceBoardSectionModes;
        }

        #endregion

        #region Get All Modes For Type

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all interface board section modes for type. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all interface board section modes for type. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<InterfaceBoardSectionMode> GetAllInterfaceBoardSectionModesForType(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _InterfaceBoardTypes = new List<InterfaceBoardSectionMode>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyInterfaceBoardSectionModesForType(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _InterfaceBoardTypes.Add(o);
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

            InterfaceBoardSectionModes = new ReadOnlyCollection<InterfaceBoardSectionMode>(_InterfaceBoardTypes);
            return InterfaceBoardSectionModes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy interface board section modes for type asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy interface board section modes for type asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<InterfaceBoardSectionMode>> GetAllGalaxyInterfaceBoardSectionModesForTypeAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _InterfaceBoardTypes = new List<InterfaceBoardSectionMode>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyInterfaceBoardSectionModesForTypeAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _InterfaceBoardTypes.Add(o);
                            }
                            InterfaceBoardSectionModes = new ReadOnlyCollection<InterfaceBoardSectionMode>(_InterfaceBoardTypes);
                            return InterfaceBoardSectionModes;
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

            return InterfaceBoardSectionModes;
        }

        #endregion
        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the galaxy interface board section mode described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyInterfaceBoardSectionMode(DeleteParameters<InterfaceBoardSectionMode> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyInterfaceBoardSectionMode(parameters);
                            if(countDeleted == 1)
                                _InterfaceBoardTypes.Remove(parameters.Data);
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
        /// Deletes the galaxy interface board section mode asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyInterfaceBoardSectionModeAsync(DeleteParameters<InterfaceBoardSectionMode> parameters)
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
                            countDeleted = await proxy.DeleteGalaxyInterfaceBoardSectionModeAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _InterfaceBoardTypes.Remove(parameters.Data);
                                InterfaceBoardSectionModes = new ReadOnlyCollection<InterfaceBoardSectionMode>(_InterfaceBoardTypes);
                                
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
        /// Deletes the galaxy interface board section mode by unique identifier described by
        /// parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyInterfaceBoardSectionModeByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyInterfaceBoardSectionModeByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _InterfaceBoardTypes)
                                {
                                    if (o.InterfaceBoardTypeUid == parameters.UniqueId)
                                    {
                                        _InterfaceBoardTypes.Remove(o);
                                        break;
                                    }
                                }
                                InterfaceBoardSectionModes = new ReadOnlyCollection<InterfaceBoardSectionMode>(_InterfaceBoardTypes);
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
        /// Deletes the galaxy interface board section mode by unique identifier asynchronous described
        /// by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyInterfaceBoardSectionModeByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteGalaxyInterfaceBoardSectionModeByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _InterfaceBoardTypes)
                                {
                                    if (o.InterfaceBoardTypeUid == parameters.UniqueId)
                                    {
                                        _InterfaceBoardTypes.Remove(o);
                                        break;
                                    }
                                }
                                InterfaceBoardSectionModes = new ReadOnlyCollection<InterfaceBoardSectionMode>(_InterfaceBoardTypes);
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
        /// <summary>   Saves a galaxy interface board section mode. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An InterfaceBoardSectionMode. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InterfaceBoardSectionMode SaveGalaxyInterfaceBoardSectionMode(SaveParameters<InterfaceBoardSectionMode> parameters)
        {
            InitializeErrorsCollection();
            InterfaceBoardSectionMode savedItem = null;
            bool isNew = (parameters.Data.InterfaceBoardTypeUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyInterfaceBoardSectionMode(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _InterfaceBoardTypes
                                    where i.InterfaceBoardTypeUid == parameters.Data.InterfaceBoardTypeUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _InterfaceBoardTypes.Remove(originalItem);
                            }
                            _InterfaceBoardTypes.Add(savedItem);
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

            return savedItem;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a galaxy interface board section mode asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;InterfaceBoardSectionMode&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<InterfaceBoardSectionMode> SaveGalaxyInterfaceBoardSectionModeAsync(SaveParameters<InterfaceBoardSectionMode> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            InterfaceBoardSectionMode savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.InterfaceBoardTypeUid == Guid.Empty);
                            savedItem = await proxy.SaveGalaxyInterfaceBoardSectionModeAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _InterfaceBoardTypes
                                    where i.InterfaceBoardTypeUid == parameters.Data.InterfaceBoardTypeUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _InterfaceBoardTypes.Remove(originalItem);
                            }
                            _InterfaceBoardTypes.Add(savedItem);
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
        /// <summary>   Gets galaxy interface board section mode. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section mode. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InterfaceBoardSectionMode GetGalaxyInterfaceBoardSectionMode(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            InterfaceBoardSectionMode InterfaceBoardSectionMode = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            InterfaceBoardSectionMode = proxy.GetGalaxyInterfaceBoardSectionMode(parameters);
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

            return InterfaceBoardSectionMode;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy interface board section mode asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy interface board section mode asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<InterfaceBoardSectionMode> GetGalaxyInterfaceBoardSectionModeAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            InterfaceBoardSectionMode InterfaceBoardSectionMode = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            InterfaceBoardSectionMode = await proxy.GetGalaxyInterfaceBoardSectionModeAsync(parameters);
                            return InterfaceBoardSectionMode;
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

            return InterfaceBoardSectionMode;
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