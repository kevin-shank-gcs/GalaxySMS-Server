////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\PropertySensitivityLevelManager.cs
//
// summary:	Implements the PropertySensitivityLevel manager class
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
    /// <summary>   Manager for property sensitivity levels. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PropertySensitivityLevelManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The property sensitivity levels. </summary>
        private List<PropertySensitivityLevel> _PropertySensitivityLevels;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the property sensitivity levels. </summary>
        ///
        /// <value> The property sensitivity levels. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<PropertySensitivityLevel> PropertySensitivityLevels { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PropertySensitivityLevelManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PropertySensitivityLevelManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _PropertySensitivityLevels = new List<PropertySensitivityLevel>();
        }

        #endregion

        #region Public methods

        #region Get All PropertySensitivityLevels

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all property sensitivity levels. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all property sensitivity levels. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<PropertySensitivityLevel> GetAllPropertySensitivityLevels(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _PropertySensitivityLevels = new List<PropertySensitivityLevel>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllPropertySensitivityLevels(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _PropertySensitivityLevels.Add(o);
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

            PropertySensitivityLevels = new ReadOnlyCollection<PropertySensitivityLevel>(_PropertySensitivityLevels);
            return PropertySensitivityLevels;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all property sensitivity levels asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all property sensitivity levels asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<PropertySensitivityLevel>> GetAllPropertySensitivityLevelsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _PropertySensitivityLevels = new List<PropertySensitivityLevel>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllPropertySensitivityLevelsAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _PropertySensitivityLevels.Add(o);
                            }
                            PropertySensitivityLevels = new ReadOnlyCollection<PropertySensitivityLevel>(_PropertySensitivityLevels);
                            return PropertySensitivityLevels;
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

            return PropertySensitivityLevels;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the property sensitivity level described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeletePropertySensitivityLevel(DeleteParameters<PropertySensitivityLevel> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeletePropertySensitivityLevel(parameters);
                            if (countDeleted == 1)
                            {
                                _PropertySensitivityLevels.Remove(parameters.Data);
                                PropertySensitivityLevels = new ReadOnlyCollection<PropertySensitivityLevel>(_PropertySensitivityLevels);
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
        /// Deletes the property sensitivity level asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeletePropertySensitivityLevelAsync(DeleteParameters<PropertySensitivityLevel> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteSiteAsync throws a WCF exception
                            countDeleted = await proxy.DeletePropertySensitivityLevelAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _PropertySensitivityLevels.Remove(parameters.Data);
                                PropertySensitivityLevels = new ReadOnlyCollection<PropertySensitivityLevel>(_PropertySensitivityLevels);
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
        /// Deletes the property sensitivity level by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeletePropertySensitivityLevelByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeletePropertySensitivityLevelByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _PropertySensitivityLevels)
                                {
                                    if (o.PropertySensitivityLevelUid == parameters.UniqueId)
                                    {
                                        _PropertySensitivityLevels.Remove(o);
                                        break;
                                    }
                                }
                                PropertySensitivityLevels = new ReadOnlyCollection<PropertySensitivityLevel>(_PropertySensitivityLevels);
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
        /// Deletes the property sensitivity level by unique identifier asynchronous described by
        /// parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeletePropertySensitivityLevelByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            countDeleted = await proxy.DeletePropertySensitivityLevelByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _PropertySensitivityLevels)
                                {
                                    if (o.PropertySensitivityLevelUid == parameters.UniqueId)
                                    {
                                        _PropertySensitivityLevels.Remove(o);
                                        break;
                                    }
                                }
                                PropertySensitivityLevels = new ReadOnlyCollection<PropertySensitivityLevel>(_PropertySensitivityLevels);
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
        /// <summary>   Saves a property sensitivity level. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A PropertySensitivityLevel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PropertySensitivityLevel SavePropertySensitivityLevel(SaveParameters<PropertySensitivityLevel> parameters)
        {
            InitializeErrorsCollection();
            PropertySensitivityLevel savedItem = null;
            bool isNew = (parameters.Data.PropertySensitivityLevelUid == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SavePropertySensitivityLevel(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _PropertySensitivityLevels
                                    where i.PropertySensitivityLevelUid == parameters.Data.PropertySensitivityLevelUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _PropertySensitivityLevels.Remove(originalItem);
                            }
                            _PropertySensitivityLevels.Add(savedItem);
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
        /// <summary>   Saves a property sensitivity level asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;PropertySensitivityLevel&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<PropertySensitivityLevel> SavePropertySensitivityLevelAsync(SaveParameters<PropertySensitivityLevel> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            PropertySensitivityLevel savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.PropertySensitivityLevelUid == Guid.Empty);
                            savedItem = await proxy.SavePropertySensitivityLevelAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _PropertySensitivityLevels
                                    where i.PropertySensitivityLevelUid == parameters.Data.PropertySensitivityLevelUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _PropertySensitivityLevels.Remove(originalItem);
                            }
                            _PropertySensitivityLevels.Add(savedItem);
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
        /// <summary>   Gets property sensitivity level. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The property sensitivity level. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PropertySensitivityLevel GetPropertySensitivityLevel(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            PropertySensitivityLevel PropertySensitivityLevel = null;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            PropertySensitivityLevel = proxy.GetPropertySensitivityLevel(parameters);
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

            return PropertySensitivityLevel;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets property sensitivity level asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The property sensitivity level asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<PropertySensitivityLevel> GetPropertySensitivityLevelAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            PropertySensitivityLevel PropertySensitivityLevel = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            PropertySensitivityLevel = await proxy.GetPropertySensitivityLevelAsync(parameters);
                            return PropertySensitivityLevel;
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

            return PropertySensitivityLevel;
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