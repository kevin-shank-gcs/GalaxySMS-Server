﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IDataInsertRepository.cs
//
// summary:	Declares the IDataInsertRepository interface
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;

namespace GCS.Core.Common.Contracts
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for data insert repository. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IRepository
    {

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for data insert repository. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IRepository<T> : IRepository
        where T : class, new()
    {

    }
}
