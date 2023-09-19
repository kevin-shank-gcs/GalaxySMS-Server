////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Data\DataRepositoryDbContextBase.cs
//
// summary:	Implements the data repository database context base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Utils;
//using PDSA.DataLayer.DataClasses;
using EntityState = System.Data.Entity.EntityState;

namespace GCS.Core.Common.Data
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A data repository database context base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    /// <typeparam name="U">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class DataRepositoryDbContextBase<T, U> : IDataRepositoryDbContext<T>
        where T : class, IIdentifiableEntity, new()
        where U : DbContext, new()
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
        /// <param name="entityContext">    Context for the entity. </param>
        /// <param name="entity">           The entity. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T AddEntity(U entityContext, T entity, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityContext">    Context for the entity. </param>
        /// <param name="entity">           The entity. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T UpdateEntity(U entityContext, T entity, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityContext">    Context for the entity. </param>
        /// <param name="entity">           The entity. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract void DeleteEntity(U entityContext, T entity, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the entities in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityContext">    Context for the entity. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the entities in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract IEnumerable<T> GetEntities(U entityContext, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// There are two GetEntityBy functions, one for entities with a int PK and one that has a Guid
        /// PK The derived class should return a null value from the method that is not supported by the
        /// particular table.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityContext">    Context for the entity. </param>
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        ///
        /// <returns>   The entity by int identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T GetEntityByIntId(U entityContext, int id, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entity by unique identifier identifier. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityContext">    Context for the entity. </param>
        /// <param name="guid">             Unique identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        ///
        /// <returns>   The entity by unique identifier identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract T GetEntityByGuidId(U entityContext, Guid guid, IApplicationUserSessionDataHeader sessionData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an audit data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entityContext">    Context for the entity. </param>
        /// <param name="operationType">    Type of the operation. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="originalEntity">   The original entity. </param>
        /// <param name="newEntity">        The new entity. </param>
        /// <param name="auditXml">         The audit XML. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract void SaveAuditData(U entityContext, OperationType operationType,
            IApplicationUserSessionDataHeader sessionData, T originalEntity, T newEntity, string auditXml);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public T Add(T entity, IApplicationUserSessionDataHeader sessionData)
        {
            using (U entityContext = new U())
            {
                T addedEntity = AddEntity(entityContext, entity, sessionData);
                //entityContext.SaveChanges();
                return addedEntity;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this IDataRepositoryDbContext&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual void Remove(int id, IApplicationUserSessionDataHeader sessionData)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntityByIntId(entityContext, id, sessionData);
                if (entity != null)
                {
                    DeleteEntity(entityContext, entity, sessionData);
                    //entityContext.Entry<T>(entity).State = EntityState.Deleted;
                    //entityContext.SaveChanges();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this IDataRepositoryDbContext&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual void Remove(T entity, IApplicationUserSessionDataHeader sessionData)
        {
            using (U entityContext = new U())
            {
                DeleteEntity(entityContext, entity, sessionData);
                //T e = GetEntityByGuidId(entityContext, entity.EntityGuid);
                //if (e != null)
                //{
                //    entityContext.Entry<T>(e).State = EntityState.Deleted;
                //    entityContext.SaveChanges();
                //}
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this IDataRepositoryDbContext&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual void Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntityByGuidId(entityContext, id, sessionData);
                if (entity != null)
                {
                    DeleteEntity(entityContext, entity, sessionData);
                    //entityContext.Entry<T>(entity).State = EntityState.Deleted;
                    //entityContext.SaveChanges();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates this IDataRepositoryDbContext&lt;T&gt; </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual T Update(T entity, IApplicationUserSessionDataHeader sessionData)
        {
            using (U entityContext = new U())
            {
                T existingEntity = UpdateEntity(entityContext, entity, sessionData);

                //SimpleMapper.PropertyMap(entity, existingEntity);

                //entityContext.SaveChanges();
                return existingEntity;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionData">  Information describing the session. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual IEnumerable<T> Get(IApplicationUserSessionDataHeader sessionData)
        {
            using (U entityContext = new U())
                return (GetEntities(entityContext, sessionData)).ToArray().ToList();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual T Get(int id, IApplicationUserSessionDataHeader sessionData)
        {
            using (U entityContext = new U())
                return GetEntityByIntId(entityContext, id, sessionData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual T Get(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            using (U entityContext = new U())
                return GetEntityByGuidId(entityContext, id, sessionData);
        }
    }
}
