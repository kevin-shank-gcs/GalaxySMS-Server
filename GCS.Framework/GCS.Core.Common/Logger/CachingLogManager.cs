////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Logger\CachingLogManager.cs
//
// summary:	Implements the caching log manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GCS.Core.Common.Contracts;

namespace GCS.Core.Common.Logger
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for caching logs. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class CachingLogManager : ILogManager
    {
        /// <summary>   Manager for log. </summary>
        private readonly ILogManager _logManager;
        /// <summary>   The logger map. </summary>
        static readonly IDictionary<Type,ILogger> LoggerMap = new Dictionary<Type, ILogger>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="logManager">   Manager for log. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CachingLogManager( ILogManager logManager )
        {
            _logManager = logManager;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a logger. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="type"> The type. </param>
        ///
        /// <returns>   The logger. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ILogger GetLogger(Type type)
        {
            ILogger logger = null;
            if (! LoggerMap.TryGetValue(type, out logger))
            {
                logger = _logManager.GetLogger(type);
                LoggerMap[type] = logger;
            }

            return logger;
        }
    }
}
