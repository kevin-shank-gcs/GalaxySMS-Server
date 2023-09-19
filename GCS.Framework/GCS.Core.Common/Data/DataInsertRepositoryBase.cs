////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Data\DataInsertRepositoryBase.cs
//
// summary:	Implements the data insert repository base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Utils;
using EntityState = System.Data.Entity.EntityState;

namespace GCS.Core.Common.Data
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A data insert repository base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public abstract class DataInsertRepositoryBase<T> : IDataInsertRepository<T>
        where T : class, new()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inserts an entity described by entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected abstract void InsertEntity(T entity);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inserts the given entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Insert(T entity)
        {
            InsertEntity(entity);
        }

    }
}
