////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Data\DataRepositoryBase.cs
//
// summary:	Implements the data repository base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Contracts;
using PDSA.DataLayer.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GCS.Core.Common.Data
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A data repository base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class DataRepositoryBase<T> : IDataRepository<T>
        where T : class, IIdentifiableEntity, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the data store table. </summary>
        ///
        /// <value> The name of the data store table. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DataStoreTableName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds an entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        /// <param name="saveParams">   Save parameters </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T AddEntity(T entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        /// <param name="saveParams">   Save parameters </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T UpdateEntity(T entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract int DeleteEntity(T entity, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the entities in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the entities in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract IEnumerable<T> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all entities in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process all entities in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract IEnumerable<T> GetAllEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// There are two GetEntityBy functions, one for entities with a int PK and one that has a Guid
        /// PK The derived class should return a null value from the method that is not supported by the
        /// particular table.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   The entity by int identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entity by unique identifier identifier. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="guid">             Unique identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   The entity by unique identifier identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an audit data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="operationType">    Type of the operation. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="originalEntity">   The original entity. </param>
        /// <param name="newEntity">        The new entity. </param>
        /// <param name="auditXml">         The audit XML. </param>
        /// <param name="transaction">      The transaction. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, T originalEntity, T newEntity, string auditXml);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fill member collections. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">           The entity. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract void FillMemberCollections(T entity, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        //        protected abstract void FillMemberCollections(T entity, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is entity referenced. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if entity referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool IsEntityReferenced(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is entity referenced. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if entity referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool IsEntityReferenced(int id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can entity be deleted. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can entity be deleted, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool CanEntityBeDeleted(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can entity be deleted. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can entity be deleted, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool CanEntityBeDeleted(int id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'entity' is entity unique. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   True if entity unique, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool IsEntityUnique(T entity);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does entity exist. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool DoesEntityExist(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does entity exist. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool DoesEntityExist(int id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        /// <param name="saveParams">  The save parameters. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public T Add(T entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            T addedEntity = AddEntity(entity, sessionData, saveParams);
            return addedEntity;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this IDataRepository&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual int Remove(int id, IApplicationUserSessionDataHeader sessionData)
        {
            T entity = GetEntityByIntId(id, sessionData, null);
            if (entity != null)
            {
                return DeleteEntity(entity, sessionData);
            }
            return 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this IDataRepository&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual int Remove(T entity, IApplicationUserSessionDataHeader sessionData)
        {
            return DeleteEntity(entity, sessionData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this IDataRepository&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            T entity = GetEntityByGuidId(id, sessionData, null);
            if (entity != null)
            {
                return DeleteEntity(entity, sessionData);
            }
            return 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates this IDataRepository&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        /// <param name="saveParams">   Save parameters </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual T Update(T entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            T existingEntity = UpdateEntity(entity, sessionData, saveParams);

            return existingEntity;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual IEnumerable<T> Get(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return (GetEntities(sessionData, getParameters)).ToArray().ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all items in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process all items in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IEnumerable<T> GetAll(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return (GetAllEntities(sessionData, getParameters)).ToArray().ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual T Get(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntityByIntId(id, sessionData, getParameters);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual T Get(Guid id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntityByGuidId(id, sessionData, getParameters);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is referenced. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool IsReferenced(Guid id)
        {
            return IsEntityReferenced(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is referenced. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsReferenced(int id)
        {
            return IsEntityReferenced(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can delete. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can delete, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool CanDelete(Guid id)
        {
            return CanEntityBeDeleted(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can delete. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can delete, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool CanDelete(int id)
        {
            return CanEntityBeDeleted(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'entity' is unique. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   True if unique, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool IsUnique(T entity)
        {
            return IsEntityUnique(entity);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does exist. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool DoesExist(Guid id)
        {
            return DoesEntityExist(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does exist. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool DoesExist(int id)
        {
            return DoesEntityExist(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the table entity base properties from existing. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The ITableEntityBase to process. </param>
        /// <param name="e">    The ITableEntityBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateTableEntityBasePropertiesFromExisting(ITableEntityBase o, ITableEntityBase e)
        {
            if (o == null || e == null)
                return;

            o.InsertName = e.InsertName;
            o.InsertDate = e.InsertDate;
            o.UpdateDate = e.UpdateDate;
            o.UpdateName = e.UpdateName;
            o.ConcurrencyValue = e.ConcurrencyValue;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the table entity base properties. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">            The ITableEntityBase to process. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateTableEntityBaseProperties(ITableEntityBase o, IApplicationUserSessionDataHeader sessionData)
        {
            if (o == null)
                return;

            if (o.InsertDate == DateTimeOffset.MinValue)
                o.InsertDate = DateTimeOffset.Now;
            if (string.IsNullOrEmpty(o.InsertName))
                o.InsertName = sessionData.UserName;
            o.UpdateDate = DateTimeOffset.Now;
            o.UpdateName = sessionData.UserName;
            if (!o.ConcurrencyValue.HasValue)
                o.ConcurrencyValue = 0;
        }

    }



    public abstract class PagedDataRepositoryBase<T> : DataRepositoryBase<T>, IPagedDataRepository<T>
    where T : class, IIdentifiableEntity, new()
    {
        protected abstract IArrayResponse<T> GetEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all entities in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process all entities in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract IArrayResponse<T> GetAllEntitiesPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   An ArrayResponse object with the results </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual IArrayResponse<T> GetPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntitiesPaged(sessionData, getParameters);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all items in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   An ArrayResponse object with the results </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IArrayResponse<T> GetAllPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetAllEntitiesPaged(sessionData, getParameters);
        }
    }



    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A simple data repository base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class SimpleDataRepositoryBase<T> : ISimpleDataRepository<T>
        where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the data store table. </summary>
        ///
        /// <value> The name of the data store table. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DataStoreTableName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds an entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T AddEntity(T entity, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T UpdateEntity(T entity, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract int DeleteEntity(T entity, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the entities in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the entities in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract IEnumerable<T> GetEntities(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// There are two GetEntityBy functions, one for entities with a int PK and one that has a Guid
        /// PK The derived class should return a null value from the method that is not supported by the
        /// particular table.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   The entity by int identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T GetEntityByIntId(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entity by unique identifier identifier. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="guid">             Unique identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   The entity by unique identifier identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T GetEntityByGuidId(Guid guid, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an audit data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="operationType">    Type of the operation. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="originalEntity">   The original entity. </param>
        /// <param name="newEntity">        The new entity. </param>
        /// <param name="auditXml">         The audit XML. </param>
        /// <param name="transaction">      The transaction. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract void SaveAuditData(OperationType operationType, IApplicationUserSessionDataHeader sessionData, T originalEntity, T newEntity, string auditXml);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fill member collections. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract void FillMemberCollections(T entity, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is entity referenced. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if entity referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool IsEntityReferenced(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is entity referenced. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if entity referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool IsEntityReferenced(int id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can entity be deleted. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can entity be deleted, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool CanEntityBeDeleted(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can entity be deleted. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can entity be deleted, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool CanEntityBeDeleted(int id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'entity' is entity unique. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   True if entity unique, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool IsEntityUnique(T entity);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does entity exist. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool DoesEntityExist(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does entity exist. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract bool DoesEntityExist(int id);

        //protected abstract DataSet GetDataSetFromSql(string sql);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public T Add(T entity, IApplicationUserSessionDataHeader sessionData)
        {
            T addedEntity = AddEntity(entity, sessionData);
            return addedEntity;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this ISimpleDataRepository&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual int Remove(int id, IApplicationUserSessionDataHeader sessionData)
        {
            T entity = GetEntityByIntId(id, sessionData, null);
            if (entity != null)
            {
                return DeleteEntity(entity, sessionData);
            }
            return 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this ISimpleDataRepository&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual int Remove(T entity, IApplicationUserSessionDataHeader sessionData)
        {
            return DeleteEntity(entity, sessionData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this ISimpleDataRepository&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            T entity = GetEntityByGuidId(id, sessionData, null);
            if (entity != null)
            {
                return DeleteEntity(entity, sessionData);
            }
            return 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates this ISimpleDataRepository&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual T Update(T entity, IApplicationUserSessionDataHeader sessionData)
        {
            T existingEntity = UpdateEntity(entity, sessionData);

            return existingEntity;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IEnumerable<T> Get()
        {
            return (GetEntities(null, null)).ToArray().ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual IEnumerable<T> Get(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return (GetEntities(sessionData, getParameters)).ToArray().ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual T Get(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntityByIntId(id, sessionData, getParameters);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual T Get(Guid id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            return GetEntityByGuidId(id, sessionData, getParameters);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is referenced. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool IsReferenced(Guid id)
        {
            return IsEntityReferenced(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is referenced. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsReferenced(int id)
        {
            return IsEntityReferenced(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can delete. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can delete, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool CanDelete(Guid id)
        {
            return CanEntityBeDeleted(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can delete. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can delete, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool CanDelete(int id)
        {
            return CanEntityBeDeleted(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'entity' is unique. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   True if unique, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool IsUnique(T entity)
        {
            return IsEntityUnique(entity);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does exist. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool DoesExist(Guid id)
        {
            return DoesEntityExist(id);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does exist. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool DoesExist(int id)
        {
            return DoesEntityExist(id);
        }
    }
}
