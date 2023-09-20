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
#if NETCOREAPP
using GalaxySMS.Client.Contracts.NetCore;
#else
using GalaxySMS.Client.Contracts;
#endif
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for departments. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PersonRecordTypeManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The departments. </summary>
        private List<PersonRecordType> _PersonRecordTypes;
        private List<ListItemBase> _PersonRecordTypesList;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the departments. </summary>
        ///
        /// <value> The departments. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<PersonRecordType> PersonRecordTypes { get; internal set; }

        public ReadOnlyCollection<ListItemBase> PersonRecordTypesList { get; internal set; }
        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonRecordTypeManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonRecordTypeManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _PersonRecordTypes = new List<PersonRecordType>();
        }

        #endregion

        #region Public methods

        #region Get all departments for entity


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the departments. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The departments. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<PersonRecordType> GetPersonRecordTypes(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _PersonRecordTypes = new List<PersonRecordType>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            PersonRecordType[] departments = proxy.GetAllPersonRecordTypesForEntity(parameters);
                            if (departments != null)
                            {
                                foreach (var region in departments)
                                {
                                    _PersonRecordTypes.Add(region);
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

            PersonRecordTypes = new ReadOnlyCollection<PersonRecordType>(_PersonRecordTypes);
            return PersonRecordTypes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets departments asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The departments asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<PersonRecordType>> GetPersonRecordTypesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _PersonRecordTypes = new List<PersonRecordType>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            PersonRecordType[] departments = await proxy.GetAllPersonRecordTypesForEntityAsync(parameters);
                            if (departments != null)
                            {
                                foreach (var region in departments)
                                    _PersonRecordTypes.Add(region);
                            }
                            PersonRecordTypes = new ReadOnlyCollection<PersonRecordType>(_PersonRecordTypes);
                            return PersonRecordTypes;
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

            return PersonRecordTypes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets departments list items. </summary>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The departments list items. </returns>
        ///=================================================================================================

        public ReadOnlyCollection<ListItemBase> GetPersonRecordTypesListItems(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _PersonRecordTypesList = new List<ListItemBase>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var departments = proxy.GetAllPersonRecordTypesListEntity(parameters);
                            if (departments != null)
                            {
                                foreach (var region in departments)
                                {
                                    _PersonRecordTypesList.Add(region);
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

            PersonRecordTypesList = new ReadOnlyCollection<ListItemBase>(_PersonRecordTypesList);
            return PersonRecordTypesList;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets departments list items asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The departments list items asynchronous. </returns>
        ///=================================================================================================

        public async Task<ReadOnlyCollection<ListItemBase>> GetPersonRecordTypesListItemsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _PersonRecordTypesList = new List<ListItemBase>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var departments = await proxy.GetAllPersonRecordTypesListEntityAsync(parameters);
                            if (departments != null)
                            {
                                foreach (var region in departments)
                                    _PersonRecordTypesList.Add(region);
                            }
                            PersonRecordTypesList = new ReadOnlyCollection<ListItemBase>(_PersonRecordTypesList);
                            return PersonRecordTypesList;
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

            return PersonRecordTypesList;
        }

        #endregion

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all departments. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all departments. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<PersonRecordType> GetAllPersonRecordTypes(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _PersonRecordTypes = new List<PersonRecordType>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            PersonRecordType[] departments = proxy.GetAllPersonRecordTypes(parameters);
                            if (departments != null)
                            {
                                foreach (var region in departments)
                                    _PersonRecordTypes.Add(region);
                            }
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

            PersonRecordTypes = new ReadOnlyCollection<PersonRecordType>(_PersonRecordTypes);
            return PersonRecordTypes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all departments asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all departments asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<PersonRecordType>> GetAllPersonRecordTypesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _PersonRecordTypes = new List<PersonRecordType>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            PersonRecordType[] departments = await proxy.GetAllPersonRecordTypesAsync(parameters);
                            if (departments != null)
                            {
                                foreach (var region in departments)
                                    _PersonRecordTypes.Add(region);
                            }
                            PersonRecordTypes = new ReadOnlyCollection<PersonRecordType>(_PersonRecordTypes);
                            return PersonRecordTypes;
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

            return PersonRecordTypes;
        }


        public ReadOnlyCollection<ListItemBase> GetAllPersonRecordTypesListItems(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _PersonRecordTypesList = new List<ListItemBase>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var departments = proxy.GetAllPersonRecordTypesList(parameters);
                            if (departments != null)
                            {
                                foreach (var region in departments)
                                    _PersonRecordTypesList.Add(region);
                            }
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

            PersonRecordTypesList = new ReadOnlyCollection<ListItemBase>(_PersonRecordTypesList);
            return PersonRecordTypesList;
        }

        public async Task<ReadOnlyCollection<ListItemBase>> GetAllPersonRecordTypesListItemsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _PersonRecordTypesList = new List<ListItemBase>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var departments = await proxy.GetAllPersonRecordTypesListAsync(parameters);
                            if (departments != null)
                            {
                                foreach (var region in departments)
                                    _PersonRecordTypesList.Add(region);
                            }
                            PersonRecordTypesList = new ReadOnlyCollection<ListItemBase>(_PersonRecordTypesList);
                            return PersonRecordTypesList;
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

            return PersonRecordTypesList;
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

        public int DeletePersonRecordType(DeleteParameters<PersonRecordType> parameters)
        {
            int ret = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            ret = proxy.DeletePersonRecordType(parameters);
                            _PersonRecordTypes.Remove(parameters.Data);
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
            return ret;
        }

        //public async Task<int> DeletePersonRecordTypeAsync(DeleteParameters<PersonRecordType> parameters)
        //{
        //    InitializeErrorsCollection();
        //    DateTimeOffset startedAt = DateTimeOffset.Now;

        //    try
        //    {
        //        await WithClientAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //                {
        //                    // For some reason, the DeletePersonRecordTypeAsync throws a WCF exception
        //                    //await proxy.DeletePersonRecordTypeAsync(parameters);
        //                    proxy.DeletePersonRecordType(parameters);
        //                    _PersonRecordTypes.Remove(parameters.Data);
        //                    PersonRecordTypes = new ReadOnlyCollection<PersonRecordType>(_PersonRecordTypes);
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

        public async Task<int> DeletePersonRecordTypeAsync(DeleteParameters<PersonRecordType> parameters)
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
                            // For some reason, the DeletePersonRecordTypeAsync throws a WCF exception
                            ret = await proxy.DeletePersonRecordTypeAsync(parameters);
                            _PersonRecordTypes.Remove(parameters.Data);
                            PersonRecordTypes = new ReadOnlyCollection<PersonRecordType>(_PersonRecordTypes);
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

        public int DeletePersonRecordTypeByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int x = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            x = proxy.DeletePersonRecordTypeByPk(parameters);
                            foreach (var r in _PersonRecordTypes)
                            {
                                if (r.PersonRecordTypeUid == parameters.UniqueId)
                                {
                                    _PersonRecordTypes.Remove(r);
                                    break;
                                }
                            }
                            PersonRecordTypes = new ReadOnlyCollection<PersonRecordType>(_PersonRecordTypes);
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

        public async Task<int> DeletePersonRecordTypeByUniqueIdAsync(DeleteParameters parameters)
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
                        x = await proxy.DeletePersonRecordTypeByPkAsync(parameters);
                        foreach (var r in _PersonRecordTypes)
                        {
                            if (r.PersonRecordTypeUid == parameters.UniqueId)
                            {
                                _PersonRecordTypes.Remove(r);
                                break;
                            }
                        }
                        PersonRecordTypes = new ReadOnlyCollection<PersonRecordType>(_PersonRecordTypes);
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
        /// <returns>   A PersonRecordType. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonRecordType SavePersonRecordType(SaveParameters<PersonRecordType> parameters)
        {
            InitializeErrorsCollection();
            PersonRecordType savedPersonRecordType = null;
            bool isNew = (parameters.Data.PersonRecordTypeUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedPersonRecordType = proxy.SavePersonRecordType(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _PersonRecordTypes
                                                    where i.PersonRecordTypeUid == parameters.Data.PersonRecordTypeUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _PersonRecordTypes.Remove(originalItem);
                            }
                            _PersonRecordTypes.Add(savedPersonRecordType);
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

            return savedPersonRecordType;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a region asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;PersonRecordType&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<PersonRecordType> SavePersonRecordTypeAsync(SaveParameters<PersonRecordType> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            PersonRecordType savedPersonRecordType = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.PersonRecordTypeUid == Guid.Empty);
                            savedPersonRecordType = await proxy.SavePersonRecordTypeAsync(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _PersonRecordTypes
                                                    where i.PersonRecordTypeUid == parameters.Data.PersonRecordTypeUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _PersonRecordTypes.Remove(originalItem);
                            }
                            return savedPersonRecordType;
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

            return savedPersonRecordType;
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

        public PersonRecordType GetPersonRecordType(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            PersonRecordType region = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            region = proxy.GetPersonRecordType(parameters);
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

        public async Task<PersonRecordType> GetPersonRecordTypeAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            PersonRecordType region = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            region = await proxy.GetPersonRecordTypeAsync(parameters);
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