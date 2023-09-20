////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\EntityManager.cs
//
// summary:	Implements the entity manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Client.Contracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    #region EventArg Classes

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get all entities completed events. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetAllEntitiesCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entities">             The entities. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetAllEntitiesCompletedEventArgs(ArrayResponse<gcsEntityEx> entities, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Entities = entities;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entities. </summary>
        ///
        /// <value> The entities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<gcsEntityEx> Entities { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for delete entity completed events. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DeleteEntityCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entity">               The entity. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeleteEntityCompletedEventArgs(gcsEntity entity, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Entity = entity;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity. </summary>
        ///
        /// <value> The entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsEntity Entity { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for save entity completed events. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SaveEntityCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entity">               The entity. </param>
        /// <param name="isNew">                true if this object is new, false if not. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveEntityCompletedEventArgs(gcsEntityEx entity, Boolean isNew, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Entity = entity;
            IsNew = isNew;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity. </summary>
        ///
        /// <value> The entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsEntityEx Entity { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this object is new. </summary>
        ///
        /// <value> true if this object is new, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean IsNew { get; internal set; }
    }
    #endregion

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for entities. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class EntityManager : ManagerBase
    {
        #region Private fields
        ///// <summary>   The entities. </summary>
        //private List<gcsEntityEx> _Entities;
        /// <summary>   The entity map permission levels. </summary>
        private List<EntityMapPermissionLevel> _EntityMapPermissionLevels;

        #endregion

        #region Public properties

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the entities. </summary>
        /////
        ///// <value> The entities. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        ////public ArrayResponse<gcsEntityEx> Entities { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity map permission levels. </summary>
        ///
        /// <value> The entity map permission levels. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<EntityMapPermissionLevel> EntityMapPermissionLevels { get; internal set; }
        #endregion

        #region Events and Delegates

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetAllEntitiesCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get all entities completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetAllEntitiesCompletedEventHandler(object sender, GetAllEntitiesCompletedEventArgs e);
        /// <summary>   Event queue for all listeners interested in getAllEntitesCompleted events. </summary>
        public event GetAllEntitiesCompletedEventHandler GetAllEntitesCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DeleteEntityCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Delete entity completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void DeleteEntityCompletedEventHandler(object sender, DeleteEntityCompletedEventArgs e);
        /// <summary>   Event queue for all listeners interested in deleteEntityCompleted events. </summary>
        public event DeleteEntityCompletedEventHandler DeleteEntityCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling SaveEntityCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Save entity completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void SaveEntityCompletedEventHandler(object sender, SaveEntityCompletedEventArgs e);
        /// <summary>   Event queue for all listeners interested in saveEntityCompleted events. </summary>
        public event SaveEntityCompletedEventHandler SaveEntityCompletedEvent;

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// ### <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityManager()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            //_Entities = new List<gcsEntityEx>();
        }
        #endregion

        #region Public methods

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all entities. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all entities. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<gcsEntityEx> GetAllEntities(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsEntityEx> entities = null;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            entities = proxy.GetAllEntities(parameters);
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

            return entities;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all entities asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all entities asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<gcsEntityEx>> GetAllEntitiesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var entities = await proxy.GetAllEntitiesAsync(parameters);
                            return entities;
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

            return null;
        }

        #endregion

        #region GetAllForUser

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all entities for user asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ///
        /// <returns>   all entities for user asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<gcsEntityEx>> GetAllEntitiesForUserAsync(Guid userId)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = await client.GetAllEntitiesForUserAsync(new GetParametersWithPhoto() { UniqueId = userId });

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;

            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all entities for user. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ///
        /// <returns>   all entities for user. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<gcsEntityEx> GetAllEntitiesForUser(Guid userId)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = client.GetAllEntitiesForUser(new GetParametersWithPhoto() { UniqueId = userId });

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        #endregion

        #region Get

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsEntityEx GetEntity(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = client.GetEntity(parameters);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entity asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<gcsEntityEx> GetEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = await client.GetEntityAsync(parameters);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            catch (FaultException ex)
            {
                AddError(new CustomError(ex.Message));
                this.Log().Debug(ex.Message);
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the entity described by entity. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteEntity(gcsEntity entity)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteEntity(new DeleteParameters<gcsEntity>() { Data = entity });
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
        /// <summary>   Deletes the entity asynchronous described by entity. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteEntityAsync(gcsEntity entity)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task tDelete = proxy.DeleteEntityAsync(new DeleteParameters<gcsEntity>() { Data = entity });
                                await tDelete;
                            };

                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = DeleteEntityCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new DeleteEntityCompletedEventArgs(
                                            entity, startedAt, endedAt));
                                }
                            }
                            catch (AggregateException ae)
                            {
                                ae = ae.Flatten();
                                foreach (Exception ex in ae.InnerExceptions)
                                {
                                    AddError(new CustomError(ex.Message));
                                    this.Log().Debug(ex.Message);
                                }
                                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                            }
                        }
                    });

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the entity by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteEntityByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteEntityByPk(parameters);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the entity by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteEntityByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var ret = await proxy.DeleteEntityByPkAsync(parameters);
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
            return 0;
        }

        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an entity. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   A gcsEntity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsEntity SaveEntity(gcsEntity entity)
        {
            InitializeErrorsCollection();
            gcsEntityEx savedEntity = null;
            bool isNew = (entity.EntityId == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var p = new SaveParameters<gcsEntity>() { Data = entity };
                            if (entity.gcsBinaryResource != null)
                                p.SavePhoto = entity.gcsBinaryResource.IsDirty;
                            savedEntity = proxy.SaveEntity(p);
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

            return savedEntity;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SaveEntityAsyncWithEvent(gcsEntity entity)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsEntityEx savedEntity = null;
            bool isNew = false;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                isNew = (entity.EntityId == Guid.Empty);
                                var p = new SaveParameters<gcsEntity>() { Data = entity };
                                if (entity.gcsBinaryResource != null)
                                    p.SavePhoto = entity.gcsBinaryResource.IsDirty;
                                Task<gcsEntityEx> t = proxy.SaveEntityAsync(p);
                                savedEntity = await t;
                            };
                            try
                            {
                                task().Wait();
                                if (savedEntity != null)
                                {
                                    DateTimeOffset endedAt = DateTimeOffset.Now;
                                    var handler = SaveEntityCompletedEvent;
                                    if (handler != null)
                                    {
                                        handler(this,
                                            new SaveEntityCompletedEventArgs(
                                                savedEntity, isNew, startedAt, endedAt));
                                    }
                                }
                            }
                            catch (AggregateException ae)
                            {
                                ae = ae.Flatten();
                                foreach (Exception ex in ae.InnerExceptions)
                                {
                                    AddError(new CustomError(ex.Message));
                                    this.Log().Debug(ex.Message);
                                }
                                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                            }
                        }
                    });
        }


        public async Task<gcsEntityEx> SaveEntityAsync(SaveParameters<gcsEntity> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsEntityEx savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        isNew = (parameters.Data.EntityId == Guid.Empty);
                        savedItem = await proxy.SaveEntityAsync(parameters);
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

        #region Get Entity Map Permission Levels

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entity map permission levels asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The entity map permission levels asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<EntityMapPermissionLevel>> GetEntityMapPermissionLevelsAsync()
        {
            InitializeErrorsCollection();
            _EntityMapPermissionLevels = new List<EntityMapPermissionLevel>();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var perms = await client.GetEntityMapPermissionLevelsAsync(new GetParametersWithPhoto() { });
                if (perms != null)
                {
                    foreach (var p in perms)
                    {
                        _EntityMapPermissionLevels.Add(p);
                    }
                }

                EntityMapPermissionLevels = new ReadOnlyCollection<EntityMapPermissionLevel>(_EntityMapPermissionLevels);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();

            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return EntityMapPermissionLevels;
        }

        #endregion

        #region Get gcsEntityBasic List

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a list of entities. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all entities. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<gcsEntityExBasic> GetEntityList(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsEntityExBasic> returnList = null;

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            returnList = proxy.GetEntityList(parameters);

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
            return returnList;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a list of entities. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all entities asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<gcsEntityExBasic>> GetEntityListAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsEntityExBasic> returnList = null;
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            returnList = await proxy.GetEntityListAsync(parameters);
                            return returnList;
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

            return returnList;
        }



        #endregion

        #region Get gcsEntityListForUser

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a list of entities. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all entities. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<gcsEntityExBasic> GetEntityForUserList(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsEntityExBasic> returnList = null;

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            returnList = proxy.GetEntityListForUser(parameters);
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
            return returnList;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a list of entities. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all entities asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<gcsEntityExBasic>> GetEntityListForUserAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsEntityExBasic> returnList = null;
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            returnList = await proxy.GetEntityListForUserAsync(parameters);
                            return returnList;
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

            return returnList;
        }

        #endregion

        #region Get gcsEntityBasic List By Name

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entity list by name. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entity list by name. </returns>
        ///=================================================================================================

        public ArrayResponse<gcsEntityExBasic> GetEntityListByName(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsEntityExBasic> returnList = null;

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            returnList = proxy.GetEntityListByName(parameters);
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
            return returnList;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entity list by name asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entity list by name asynchronous. </returns>
        ///=================================================================================================

        public async Task<ArrayResponse<gcsEntityExBasic>> GetEntityListByNameAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsEntityExBasic> returnList = null;
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            returnList = await proxy.GetEntityListByNameAsync(parameters);
                            return returnList;
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

            return returnList;
        }

        #endregion

        #region Get gcsEntityBasic List By Description

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entity list by description. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entity list by description. </returns>
        ///=================================================================================================

        public ArrayResponse<gcsEntityExBasic> GetEntityListByDescription(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsEntityExBasic> returnList = null;

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            returnList = proxy.GetEntityListByDescription(parameters);
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
            return returnList;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entity list by description asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entity list by description asynchronous. </returns>
        ///=================================================================================================

        public async Task<ArrayResponse<gcsEntityExBasic>> GetEntityListByDescriptionAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsEntityExBasic> returnList = null;
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            returnList = await proxy.GetEntityListByDescriptionAsync(parameters);
                            return returnList;
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

            return returnList;
        }



        #endregion

        #region Get By Name

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entities by name asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entities by name asynchronous. </returns>
        ///=================================================================================================

        public async Task<ArrayResponse<gcsEntityEx>> GetEntitiesByNameAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = await client.GetEntitiesByNameAsync(parameters);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;

            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entities by name. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entities by name. </returns>
        ///=================================================================================================

        public ArrayResponse<gcsEntityEx> GetEntitiesByName(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = client.GetEntitiesByName(parameters);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        #endregion

        #region Get By Description

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entities by description asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entities by description asynchronous. </returns>
        ///=================================================================================================

        public async Task<ArrayResponse<gcsEntityEx>> GetEntitiesByDescriptionAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = await client.GetEntitiesByDescriptionAsync(parameters);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entities by description. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entities by description. </returns>
        ///=================================================================================================

        public ArrayResponse<gcsEntityEx> GetEntitiesByDescription(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = client.GetEntitiesByDescription(parameters);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        #endregion

        #region Get By Name or Description

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entities by name or description asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entities by name or description asynchronous. </returns>
        ///=================================================================================================

        public async Task<ArrayResponse<gcsEntityEx>> GetEntitiesByNameOrDescriptionAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = await client.GetEntitiesByNameOrDescriptionAsync(parameters);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entities by name or description. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The entities by name or description. </returns>
        ///=================================================================================================

        public ArrayResponse<gcsEntityEx> GetEntitiesByNameOrDescription(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = client.GetEntitiesByNameOrDescription(parameters);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        #endregion

        #region gcsSetting methods

        #region GetSettingsForEntity

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all settings for entity asynchronous. </summary>
        ///
        /// <param name="entityId"> Identifier for the entity. </param>
        ///
        /// <returns>   all settings for entity asynchronous. </returns>
        ///=================================================================================================

        public async Task<IEnumerable<gcsSetting>> GetAllSettingsForEntityAsync(Guid entityId)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = await client.GetSettingsForEntityAsync(entityId);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return new List<gcsSetting>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all settings for entities in this collection. </summary>
        ///
        /// <param name="entityId"> Identifier for the entity. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process all settings for entities in this
        /// collection.
        /// </returns>
        ///=================================================================================================

        public IEnumerable<gcsSetting> GetAllSettingsForEntity(Guid entityId)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = client.GetSettingsForEntity(entityId);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;

            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return new List<gcsSetting>();
        }

        #endregion

        #region GetSettingFromParms

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all settings from parameters asynchronous. </summary>
        ///
        /// <param name="entityId">             Identifier for the entity. </param>
        /// <param name="group">                The group. </param>
        /// <param name="subGroup">             Group the sub belongs to. </param>
        /// <param name="key">                  The key. </param>
        /// <param name="defaultValue">         The default value. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   all settings from parameters asynchronous. </returns>
        ///=================================================================================================

        public async Task<gcsSetting> GetAllSettingFromParamsAsync(Guid entityId, string group, string subGroup, string key, string defaultValue, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = await client.GetSettingFromParamsAsync(entityId, group, subGroup, key, defaultValue, bCreateIfNotFound);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all setting from parameters. </summary>
        ///
        /// <param name="entityId">             Identifier for the entity. </param>
        /// <param name="group">                The group. </param>
        /// <param name="subGroup">             Group the sub belongs to. </param>
        /// <param name="key">                  The key. </param>
        /// <param name="defaultValue">         The default value. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   all setting from parameters. </returns>
        ///=================================================================================================

        public gcsSetting GetAllSettingFromParams(Guid entityId, string group, string subGroup, string key, string defaultValue, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = client.GetSettingFromParams(entityId, group, subGroup, key, defaultValue, bCreateIfNotFound);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;

            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        #endregion

        #region GetSettingsForEntityAndGroup

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets settings for entity and group asynchronous. </summary>
        ///
        /// <param name="entityId"> Identifier for the entity. </param>
        /// <param name="group">    The group. </param>
        ///
        /// <returns>   The settings for entity and group asynchronous. </returns>
        ///=================================================================================================

        public async Task<IEnumerable<gcsSetting>> GetSettingsForEntityAndGroupAsync(Guid entityId, string group)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = await client.GetSettingsForEntityAndGroupAsync(entityId, group);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return new List<gcsSetting>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all settings for entity and groups in this collection. </summary>
        ///
        /// <param name="entityId"> Identifier for the entity. </param>
        /// <param name="group">    The group. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process all settings for entity and groups in
        /// this collection.
        /// </returns>
        ///=================================================================================================

        public IEnumerable<gcsSetting> GetAllSettingsForEntityAndGroup(Guid entityId, string group)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = client.GetSettingsForEntityAndGroup(entityId, group);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;

            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return new List<gcsSetting>();
        }

        #endregion

        #region GetSettingsForEntityAndGroup

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets settings for entity group and sub group asynchronous. </summary>
        ///
        /// <param name="entityId"> Identifier for the entity. </param>
        /// <param name="group">    The group. </param>
        /// <param name="subGroup"> Group the sub belongs to. </param>
        ///
        /// <returns>   The settings for entity group and sub group asynchronous. </returns>
        ///=================================================================================================

        public async Task<IEnumerable<gcsSetting>> GetSettingsForEntityGroupAndSubGroupAsync(Guid entityId, string group, string subGroup)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = await client.GetSettingsForEntityGroupAndSubGroupAsync(entityId, group, subGroup);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return new List<gcsSetting>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the settings for entity group and sub groups in this collection. </summary>
        ///
        /// <param name="entityId"> Identifier for the entity. </param>
        /// <param name="group">    The group. </param>
        /// <param name="subGroup"> Group the sub belongs to. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the settings for entity group and sub
        /// groups in this collection.
        /// </returns>
        ///=================================================================================================

        public IEnumerable<gcsSetting> GetSettingsForEntityGroupAndSubGroup(Guid entityId, string group, string subGroup)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = client.GetSettingsForEntityGroupAndSubGroup(entityId, group, subGroup);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;

            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return new List<gcsSetting>();
        }

        #endregion

        #region Get

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a setting. </summary>
        ///
        /// <param name="setting">              The setting. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   The setting. </returns>
        ///=================================================================================================

        public gcsSetting GetSetting(gcsSetting setting, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = client.GetSetting(setting, bCreateIfNotFound);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets setting asynchronous. </summary>
        ///
        /// <param name="setting">              The setting. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   The setting asynchronous. </returns>
        ///=================================================================================================

        public async Task<gcsSetting> GetSettingAsync(gcsSetting setting, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = await client.GetSettingAsync(setting, bCreateIfNotFound);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            catch (FaultException ex)
            {
                AddError(new CustomError(ex.Message));
                this.Log().Debug(ex.Message);
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the setting described by entity. </summary>
        ///
        /// <param name="entity">   The entity. </param>
        ///=================================================================================================

        public int DeleteSetting(gcsSetting entity)
        {
            InitializeErrorsCollection();
            int x = 0;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            x = proxy.DeleteSetting(entity);
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
            return x;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the setting asynchronous described by entity. </summary>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   A Task. </returns>
        ///=================================================================================================

        public async Task<int> DeleteSettingAsync(gcsSetting entity)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            return await proxy.DeleteSettingAsync(entity);
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
            return 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the setting by unique identifier described by parameters. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///=================================================================================================

        public void DeleteSettingByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteSettingByPk(parameters.UniqueId);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the setting by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ///=================================================================================================

        public async Task<int> DeleteSettingByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var ret = await proxy.DeleteSettingByPkAsync(parameters.UniqueId);
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
            return 0;
        }

        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a setting. </summary>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   A gcsSetting. </returns>
        ///=================================================================================================

        public gcsSetting SaveSetting(gcsSetting entity)
        {
            InitializeErrorsCollection();
            gcsSetting savedItem = null;
            bool isNew = (entity.SettingId == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var p = new SaveParameters<gcsSetting>() { Data = entity };
                            savedItem = proxy.SaveSetting(p);
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
        /// <summary>   Saves a setting asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;gcsSetting&gt; </returns>
        ///=================================================================================================

        public async Task<gcsSetting> SaveSettingAsync(SaveParameters<gcsSetting> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsSetting savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        isNew = (parameters.Data.SettingId == Guid.Empty);
                        savedItem = await proxy.SaveSettingAsync(parameters);
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

        #endregion

        #region gcsLargeObjectStorage methods

        #region Get
        public gcsLargeObjectStorage GetLargeObject(Guid uid)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = client.GetLargeObject(uid);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }


        public async Task<gcsLargeObjectStorage> GetLargeObjectAsync(Guid uid)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = await client.GetLargeObjectAsync(uid);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            //catch (FaultException ex)
            //{
            //    AddError(new CustomError(ex.Message));
            //    this.Log().Debug(ex.Message);
            //    OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            //}
            return null;
        }

        public gcsLargeObjectStorage GetLargeObjectByEntityIdAndUniqueTag(Guid entityId, string uniqueTag)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = client.GetLargeObjectByEntityIdAndUniqueTag(entityId, uniqueTag);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        public async Task<gcsLargeObjectStorage> GetLargeObjectByEntityIdAndUniqueTagAsync(Guid entityId, string uniqueTag)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = await client.GetLargeObjectByEntityIdAndUniqueTagAsync(entityId, uniqueTag);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            //catch (FaultException ex)
            //{
            //    AddError(new CustomError(ex.Message));
            //    this.Log().Debug(ex.Message);
            //    OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            //}
            return null;
        }
        #endregion

        #region Delete


        public void DeleteLargeObject(Guid uid)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var x = proxy.DeleteLargeObjectByPk(uid);
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

        public async Task<int> DeleteLargeObjectAsync(Guid uid)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var x = await proxy.DeleteLargeObjectByPkAsync(uid);
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
            return 0;
        }

        #endregion

        #region Save

        public gcsLargeObjectStorage SaveLargeObject(SaveParameters<gcsLargeObjectStorage> parameters)
        {
            InitializeErrorsCollection();
            gcsLargeObjectStorage savedItem = null;
            bool isNew = (parameters.Data.Uid == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            //                            var p = new SaveParameters<gcsApplicationSetting>() { Data = entity };
                            savedItem = proxy.SaveLargeObject(parameters);
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


        public async Task<gcsLargeObjectStorage> SaveLargeObjectAsync(SaveParameters<gcsLargeObjectStorage> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsLargeObjectStorage savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        isNew = (parameters.Data.Uid == Guid.Empty);
                        savedItem = await proxy.SaveLargeObjectAsync(parameters);
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

        #endregion

        #region Entity Count methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the entity counts described by entityId. </summary>
        ///
        /// <param name="entityId"> Identifier for the entity. </param>
        ///
        /// <returns>   The gcsEntityCounts. </returns>
        ///=================================================================================================

        public gcsEntityCounts UpdateEntityCounts(Guid entityId)
        {
            InitializeErrorsCollection();
            gcsEntityCounts data = null;

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.UpdateCountsForEntity(entityId);
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
        /// <summary>   Updates the entity counts asynchronous described by entityId. </summary>
        ///
        /// <param name="entityId"> Identifier for the entity. </param>
        ///
        /// <returns>   A Task&lt;gcsEntityCounts&gt; </returns>
        ///=================================================================================================

        public async Task<gcsEntityCounts> UpdateEntityCountsAsync(Guid entityId)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.UpdateCountsForEntityAsync(entityId);
                            return data;
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

            return null;
        }

        #endregion

        #region Get Editor Data

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets cluster editing data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The cluster editing data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityEditingData GetEntityEditingData(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            EntityEditingData editingData = null;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            editingData = proxy.GetEntityEditingData(parameters);
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

            return editingData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets editing data asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The editing data asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<EntityEditingData> GetEntityEditingDataAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            EntityEditingData editingData = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            editingData = await proxy.GetEntityEditingDataAsync(parameters);
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
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}
