////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyHardwareModuleTypeManager.cs
//
// summary:	Implements the HardwareModuleType manager class
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
    /// <summary>   Manager for galaxy hardware module types. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyHardwareModuleTypeManager : ManagerBase
    {
        #region Private fields

        /// <summary>   List of types of the hardware modules. </summary>
        private List<GalaxyHardwareModuleType> _HardwareModuleTypes;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the hardware modules. </summary>
        ///
        /// <value> A list of types of the hardware modules. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyHardwareModuleType> HardwareModuleTypes { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyHardwareModuleTypeManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyHardwareModuleTypeManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _HardwareModuleTypes = new List<GalaxyHardwareModuleType>();
        }

        #endregion

        #region Public methods

        #region Get All Hardware Module Types

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all hardware module types. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all hardware module types. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyHardwareModuleType> GetAllHardwareModuleTypes(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _HardwareModuleTypes = new List<GalaxyHardwareModuleType>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyHardwareModuleTypes(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _HardwareModuleTypes.Add(o);
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

            HardwareModuleTypes = new ReadOnlyCollection<GalaxyHardwareModuleType>(_HardwareModuleTypes);
            return HardwareModuleTypes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy hardware module types asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy hardware module types asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyHardwareModuleType>> GetAllGalaxyHardwareModuleTypesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _HardwareModuleTypes = new List<GalaxyHardwareModuleType>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyHardwareModuleTypesAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _HardwareModuleTypes.Add(o);
                            }
                            HardwareModuleTypes = new ReadOnlyCollection<GalaxyHardwareModuleType>(_HardwareModuleTypes);
                            return HardwareModuleTypes;
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

            return HardwareModuleTypes;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the galaxy hardware module type described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyHardwareModuleType(DeleteParameters<GalaxyHardwareModuleType> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyHardwareModuleType(parameters);
                            if(countDeleted == 1)
                                _HardwareModuleTypes.Remove(parameters.Data);
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
        /// Deletes the galaxy hardware module type asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyHardwareModuleTypeAsync(DeleteParameters<GalaxyHardwareModuleType> parameters)
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
                            countDeleted = await proxy.DeleteGalaxyHardwareModuleTypeAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _HardwareModuleTypes.Remove(parameters.Data);
                                HardwareModuleTypes = new ReadOnlyCollection<GalaxyHardwareModuleType>(_HardwareModuleTypes);
                                
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
        /// Deletes the galaxy hardware module type by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyHardwareModuleTypeByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyHardwareModuleTypeByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _HardwareModuleTypes)
                                {
                                    if (o.GalaxyHardwareModuleTypeUid == parameters.UniqueId)
                                    {
                                        _HardwareModuleTypes.Remove(o);
                                        break;
                                    }
                                }
                                HardwareModuleTypes = new ReadOnlyCollection<GalaxyHardwareModuleType>(_HardwareModuleTypes);
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
        /// Deletes the galaxy hardware module type by unique identifier asynchronous described by
        /// parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyHardwareModuleTypeByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteGalaxyHardwareModuleTypeByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _HardwareModuleTypes)
                                {
                                    if (o.GalaxyHardwareModuleTypeUid == parameters.UniqueId)
                                    {
                                        _HardwareModuleTypes.Remove(o);
                                        break;
                                    }
                                }
                                HardwareModuleTypes = new ReadOnlyCollection<GalaxyHardwareModuleType>(_HardwareModuleTypes);
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
        /// <summary>   Saves a galaxy hardware module type. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxyHardwareModuleType. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyHardwareModuleType SaveGalaxyHardwareModuleType(SaveParameters<GalaxyHardwareModuleType> parameters)
        {
            InitializeErrorsCollection();
            GalaxyHardwareModuleType savedItem = null;
            bool isNew = (parameters.Data.GalaxyHardwareModuleTypeUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyHardwareModuleType(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _HardwareModuleTypes
                                    where i.GalaxyHardwareModuleTypeUid == parameters.Data.GalaxyHardwareModuleTypeUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _HardwareModuleTypes.Remove(originalItem);
                            }
                            _HardwareModuleTypes.Add(savedItem);
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
        /// <summary>   Saves a galaxy hardware module type asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;GalaxyHardwareModuleType&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyHardwareModuleType> SaveGalaxyHardwareModuleTypeAsync(SaveParameters<GalaxyHardwareModuleType> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyHardwareModuleType savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.GalaxyHardwareModuleTypeUid == Guid.Empty);
                            savedItem = await proxy.SaveGalaxyHardwareModuleTypeAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _HardwareModuleTypes
                                    where i.GalaxyHardwareModuleTypeUid == parameters.Data.GalaxyHardwareModuleTypeUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _HardwareModuleTypes.Remove(originalItem);
                            }
                            _HardwareModuleTypes.Add(savedItem);
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
        /// <summary>   Gets galaxy hardware module type. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy hardware module type. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyHardwareModuleType GetGalaxyHardwareModuleType(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyHardwareModuleType HardwareModuleType = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            HardwareModuleType = proxy.GetGalaxyHardwareModuleType(parameters);
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

            return HardwareModuleType;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy hardware module type asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy hardware module type asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyHardwareModuleType> GetGalaxyHardwareModuleTypeAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyHardwareModuleType HardwareModuleType = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            HardwareModuleType = await proxy.GetGalaxyHardwareModuleTypeAsync(parameters);
                            return HardwareModuleType;
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

            return HardwareModuleType;
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