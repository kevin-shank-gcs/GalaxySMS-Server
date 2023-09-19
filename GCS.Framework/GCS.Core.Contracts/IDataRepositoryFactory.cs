////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IDataRepositoryFactory.cs
//
// summary:	Declares the IDataRepositoryFactory interface
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;

namespace GCS.Core.Common.Contracts
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for data repository factory. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IDataRepositoryFactory
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets data repository. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        ///
        /// <returns>   The data repository. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T GetDataRepository<T>() where T : IDataRepository;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets data insert repository. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        ///
        /// <returns>   The data insert repository. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T GetDataInsertRepository<T>() where T : IDataInsertRepository;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets data insert repository. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        ///
        /// <returns>   The data insert repository. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        T GetRepository<T>() where T : IRepository;
    }
}
