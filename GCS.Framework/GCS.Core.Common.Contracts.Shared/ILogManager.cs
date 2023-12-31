﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ILogManager.cs
//
// summary:	Declares the ILogManager interface
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace GCS.Core.Common.Contracts
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for log manager. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface ILogManager
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a logger. </summary>
        ///
        /// <param name="type"> The type. </param>
        ///
        /// <returns>   The logger. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ILogger GetLogger(Type type);
    }
}