////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Logger\LogManager.cs
//
// summary:	Implements the log manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GCS.Core.Common.Logger
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for logs. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class LogManager : ILogManager
    {
        /// <summary>   Manager for log. </summary>
        static readonly ILogManager _logManager;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Static constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static LogManager()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            _logManager = new LogManager();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a logger. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        ///
        /// <returns>   The logger. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ILogger GetLogger<T>()
        {
            return _logManager.GetLogger(typeof (T));
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
            var logger = log4net.LogManager.GetLogger(type);
            return new LoggerAdapter( logger );
        }
    }
}
