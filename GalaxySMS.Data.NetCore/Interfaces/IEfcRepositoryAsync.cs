namespace GalaxySMS.Data.NetCore.Interfaces;


public interface IEfcRepository
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Select all. </summary>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ///
    /// <returns>   A List&lt;T&gt; </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    Task<IList<T>> SelectAllAsync<T>() where T : class;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Select by identifier. </summary>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    /// <param name="id">   The identifier. </param>
    ///
    /// <returns>   A T. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    Task<T> SelectByIdAsync<T>(object id) where T : class;


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Creates an asynchronous. </summary>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    /// <param name="entity">   The entity. </param>
    ///
    /// <returns>   A Task. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    Task<T> CreateAsync<T>(T entity, bool saveAuditTrail = true) where T : class;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Updates the asynchronous described by entity. </summary>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    /// <param name="entity">   The entity. </param>
    ///
    /// <returns>   A Task. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    Task<T> UpdateAsync<T>(T entity, bool saveAuditTrail = true) where T : class;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Deletes the asynchronous described by entity. </summary>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    /// <param name="entity">   The entity. </param>
    ///
    /// <returns>   A Task. </returns>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    Task DeleteAsync<T>(T entity, bool saveAuditTrail = true) where T : class;
}

//public interface IEfcRepositoryAsync<T, in TId> where T : class, IEntity<TId>
//{
//    IQueryable<T> Entities { get; }

//    Task<T> GetByIdAsync(TId id);

//    Task<IList<T>> GetAllAsync();

//    Task<IList<T>> GetPagedResponseAsync(int pageNumber, int pageSize);

//    Task<T> AddAsync(T entity);

//    Task UpdateAsync(T entity);

//    Task DeleteAsync(T entity);
//}