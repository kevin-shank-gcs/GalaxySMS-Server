////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\AssaAccessPointManager.cs
//
// summary:	Implements the AssaAccessPoint manager class
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
    /// <summary>   Manager for assa access points. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AssaAccessPointManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The assa access points. </summary>
        private List<AssaAccessPoint> _AssaAccessPoints;
        /// <summary>   List of types of the assa access points. </summary>
        private List<AssaAccessPointType> _AssaAccessPointTypes;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the assa access points. </summary>
        ///
        /// <value> The assa access points. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaAccessPoint> AssaAccessPoints { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the assa access points. </summary>
        ///
        /// <value> A list of types of the assa access points. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaAccessPointType> AssaAccessPointTypes { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaAccessPointManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaAccessPointManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _AssaAccessPoints = new List<AssaAccessPoint>();
        }

        #endregion

        #region Public methods

        #region Get all Get AssaAccessPoints for a Site

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets assa access points for site. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The assa access points for site. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaAccessPoint> GetAssaAccessPointsForSite(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _AssaAccessPoints = new List<AssaAccessPoint>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllAssaAccessPointsForSite(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _AssaAccessPoints.Add(o);
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

            AssaAccessPoints = new ReadOnlyCollection<AssaAccessPoint>(_AssaAccessPoints);
            return AssaAccessPoints;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets assa access points for site asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The assa access points for site asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<AssaAccessPoint>> GetAssaAccessPointsForSiteAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaAccessPoints = new List<AssaAccessPoint>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllAssaAccessPointsForSiteAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _AssaAccessPoints.Add(o);
                            }
                            AssaAccessPoints = new ReadOnlyCollection<AssaAccessPoint>(_AssaAccessPoints);
                            return AssaAccessPoints;
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

            return AssaAccessPoints;
        }

        #endregion

        #region Get all Access Portals For a Entity

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all assa access points for entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all assa access points for entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaAccessPoint> GetAllAssaAccessPointsForEntity(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaAccessPoints = new List<AssaAccessPoint>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllAssaAccessPointsForEntity(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _AssaAccessPoints.Add(o);
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

            AssaAccessPoints = new ReadOnlyCollection<AssaAccessPoint>(_AssaAccessPoints);
            return AssaAccessPoints;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all assa access points for entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all assa access points for entity asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<AssaAccessPoint>> GetAllAssaAccessPointsForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaAccessPoints = new List<AssaAccessPoint>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllAssaAccessPointsForEntityAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _AssaAccessPoints.Add(o);
                            }
                            AssaAccessPoints = new ReadOnlyCollection<AssaAccessPoint>(_AssaAccessPoints);
                            return AssaAccessPoints;
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

            return AssaAccessPoints;
        }

        #endregion

        #region Get All Access Portals

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all assa access points. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all assa access points. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaAccessPoint> GetAllAssaAccessPoints(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaAccessPoints = new List<AssaAccessPoint>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllAssaAccessPoints(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _AssaAccessPoints.Add(o);
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

            AssaAccessPoints = new ReadOnlyCollection<AssaAccessPoint>(_AssaAccessPoints);
            return AssaAccessPoints;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all assa access points asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all assa access points asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<AssaAccessPoint>> GetAllAssaAccessPointsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaAccessPoints = new List<AssaAccessPoint>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllAssaAccessPointsAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _AssaAccessPoints.Add(o);
                            }
                            AssaAccessPoints = new ReadOnlyCollection<AssaAccessPoint>(_AssaAccessPoints);
                            return AssaAccessPoints;
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

            return AssaAccessPoints;
        }

        #endregion
        
        #region Get All Access Point Types

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all assa access point types. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all assa access point types. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaAccessPointType> GetAllAssaAccessPointTypes(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaAccessPointTypes = new List<AssaAccessPointType>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllAssaAccessPointTypes(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _AssaAccessPointTypes.Add(o);
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

            AssaAccessPointTypes = new ReadOnlyCollection<AssaAccessPointType>(_AssaAccessPointTypes);
            return AssaAccessPointTypes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all assa access point types asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all assa access point types asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<AssaAccessPointType>> GetAllAssaAccessPointTypesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _AssaAccessPointTypes = new List<AssaAccessPointType>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllAssaAccessPointTypesAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _AssaAccessPointTypes.Add(o);
                            }
                            AssaAccessPointTypes = new ReadOnlyCollection<AssaAccessPointType>(_AssaAccessPointTypes);
                            return AssaAccessPointTypes;
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

            return AssaAccessPointTypes;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the assa access point described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteAssaAccessPoint(DeleteParameters<AssaAccessPoint> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteAssaAccessPoint(parameters);
                            if(countDeleted == 1)
                                _AssaAccessPoints.Remove(parameters.Data);
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
        /// <summary>   Deletes the assa access point asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteAssaAccessPointAsync(DeleteParameters<AssaAccessPoint> parameters)
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
                            countDeleted = await proxy.DeleteAssaAccessPointAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _AssaAccessPoints.Remove(parameters.Data);
                                AssaAccessPoints = new ReadOnlyCollection<AssaAccessPoint>(_AssaAccessPoints);
                                
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
        /// Deletes the assa access point by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteAssaAccessPointByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteAssaAccessPointByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _AssaAccessPoints)
                                {
                                    if (o.AssaAccessPointUid == parameters.UniqueId)
                                    {
                                        _AssaAccessPoints.Remove(o);
                                        break;
                                    }
                                }
                                AssaAccessPoints = new ReadOnlyCollection<AssaAccessPoint>(_AssaAccessPoints);
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
        /// Deletes the assa access point by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteAssaAccessPointByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteAssaAccessPointByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _AssaAccessPoints)
                                {
                                    if (o.AssaAccessPointUid == parameters.UniqueId)
                                    {
                                        _AssaAccessPoints.Remove(o);
                                        break;
                                    }
                                }
                                AssaAccessPoints = new ReadOnlyCollection<AssaAccessPoint>(_AssaAccessPoints);
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
        /// <summary>   Saves an assa access point. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An AssaAccessPoint. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaAccessPoint SaveAssaAccessPoint(SaveParameters<AssaAccessPoint> parameters)
        {
            InitializeErrorsCollection();
            AssaAccessPoint savedItem = null;
            bool isNew = (parameters.Data.AssaAccessPointUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveAssaAccessPoint(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _AssaAccessPoints
                                    where i.AssaAccessPointUid == parameters.Data.AssaAccessPointUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _AssaAccessPoints.Remove(originalItem);
                            }
                            _AssaAccessPoints.Add(savedItem);
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
        /// <summary>   Saves an assa access point asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;AssaAccessPoint&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AssaAccessPoint> SaveAssaAccessPointAsync(SaveParameters<AssaAccessPoint> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AssaAccessPoint savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.AssaAccessPointUid == Guid.Empty);
                            savedItem = await proxy.SaveAssaAccessPointAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _AssaAccessPoints
                                    where i.AssaAccessPointUid == parameters.Data.AssaAccessPointUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _AssaAccessPoints.Remove(originalItem);
                            }
                            _AssaAccessPoints.Add(savedItem);
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
        /// <summary>   Gets assa access point. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The assa access point. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaAccessPoint GetAssaAccessPoint(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            AssaAccessPoint AssaAccessPoint = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            AssaAccessPoint = proxy.GetAssaAccessPoint(parameters);
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

            return AssaAccessPoint;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets assa access point asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The assa access point asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AssaAccessPoint> GetAssaAccessPointAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AssaAccessPoint AssaAccessPoint = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            AssaAccessPoint = await proxy.GetAssaAccessPointAsync(parameters);
                            return AssaAccessPoint;
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

            return AssaAccessPoint;
        }

        #endregion

        #region Confirm access point

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Confirm assa access point. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An AssaAccessPoint. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaAccessPoint ConfirmAssaAccessPoint(SaveParameters<AssaAccessPoint> parameters)
        {
            InitializeErrorsCollection();
            AssaAccessPoint savedItem = null;
            bool isNew = (parameters.Data.AssaAccessPointUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.AssaConfirmAccessPoint(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _AssaAccessPoints
                                                    where i.AssaAccessPointUid == parameters.Data.AssaAccessPointUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _AssaAccessPoints.Remove(originalItem);
                            }
                            _AssaAccessPoints.Add(savedItem);
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
        /// <summary>   Confirm assa access point asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;AssaAccessPoint&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AssaAccessPoint> ConfirmAssaAccessPointAsync(SaveParameters<AssaAccessPoint> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AssaAccessPoint savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.AssaAccessPointUid == Guid.Empty);
                            savedItem = await proxy.AssaConfirmAccessPointAsync(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _AssaAccessPoints
                                                    where i.AssaAccessPointUid == parameters.Data.AssaAccessPointUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _AssaAccessPoints.Remove(originalItem);
                            }
                            _AssaAccessPoints.Add(savedItem);
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