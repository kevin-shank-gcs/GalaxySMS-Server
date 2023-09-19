////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IDataRepository.cs
//
// summary:	Declares the IDataRepository interface
////////////////////////////////////////////////////////////////////////////////////////////////////

using PDSA.DataLayer.DataClasses;
using System;
using System.Collections.Generic;

namespace GCS.Core.Common.Contracts
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent operation types. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum OperationType
    {
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the read option. </summary>
        Read,
        /// <summary>   An enum constant representing the insert option. </summary>
        Insert,
        /// <summary>   An enum constant representing the update option. </summary>
        Update,
        /// <summary>   An enum constant representing the delete option. </summary>
        Delete
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for data repository. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IDataRepository
    {

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for data repository. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IDataRepository<T> : IDataRepository
        where T : class, IIdentifiableEntity, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds entity. </summary>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        /// <param name="saveParams">   Save parameters </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T Add(T entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction, ISaveParameters saveParams);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates this IDataRepository&lt;T&gt; </summary>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        /// <param name="saveParams">   Save parameters </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T Update(T entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction, ISaveParameters saveParams);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this IDataRepository&lt;T&gt; </summary>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        int Remove(T entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this IDataRepository&lt;T&gt; </summary>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        int Remove(int id, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this IDataRepository&lt;T&gt; </summary>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        int Remove(Guid id, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IEnumerable<T> Get(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all items in this collection. </summary>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process all items in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IEnumerable<T> GetAll(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T Get(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T Get(Guid id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is referenced. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsReferenced(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is referenced. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsReferenced(int id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can delete. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can delete, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool CanDelete(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can delete. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can delete, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool CanDelete(int id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'entity' is unique. </summary>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   True if unique, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsUnique(T entity);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does exist. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool DoesExist(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does exist. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool DoesExist(int id);
    }



    public interface IPagedDataRepository<T> : IDataRepository<T>
        where T : class, IIdentifiableEntity, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IArrayResponse<T> GetPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all items in this collection. </summary>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process all items in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IArrayResponse<T> GetAllPaged(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for simple data repository. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface ISimpleDataRepository<T> : IDataRepository
        where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds entity. </summary>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T Add(T entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates this ISimpleDataRepository&lt;T&gt; </summary>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T Update(T entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this ISimpleDataRepository&lt;T&gt; </summary>
        ///
        /// <param name="entity">       The entity. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        int Remove(T entity, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this ISimpleDataRepository&lt;T&gt; </summary>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        int Remove(int id, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes this ISimpleDataRepository&lt;T&gt; </summary>
        ///
        /// <param name="id">           The identifier. </param>
        /// <param name="sessionData">  Information describing the session. </param>
        /// <param name="transaction">  The transaction. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        int Remove(Guid id, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IEnumerable<T> Get();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        IEnumerable<T> Get(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T Get(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets. </summary>
        ///
        /// <param name="id">               The identifier. </param>
        /// <param name="sessionData">      Information describing the session. </param>
        /// <param name="getParameters">    Options for controlling the get. </param>
        ///
        /// <returns>   A T. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T Get(Guid id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is referenced. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsReferenced(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' is referenced. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if referenced, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsReferenced(int id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can delete. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can delete, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool CanDelete(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determine if we can delete. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if we can delete, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool CanDelete(int id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'entity' is unique. </summary>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   True if unique, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool IsUnique(T entity);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does exist. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool DoesExist(Guid id);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'id' does exist. </summary>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool DoesExist(int id);
    }
}
