////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Logger\LoggingActivity.cs
//
// summary:	Implements the logging activity class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using GCS.Core.Common.Contracts;

namespace GCS.Core.Common.Logger
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A log activity extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class LogActivityExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ILogger extension method that activities. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="log">      The log to act on. </param>
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ///
        /// <returns>   An IDisposable. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IDisposable Activity(this ILogger log, string format, params object[] args)
        {
            return new LoggingActivity(log, String.Format(format, args));
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A logging activity. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class LoggingActivity : IDisposable
    {
        /// <summary>   The log. </summary>
        private readonly ILogger _log;
        /// <summary>   Name of the activity. </summary>
        private readonly string _activityName;
        /// <summary>   The scope. </summary>
        private readonly IDisposable _scope;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="log">          The log. </param>
        /// <param name="activityName"> Name of the activity. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public LoggingActivity(ILogger log, string activityName)
        {
            _log = log;
            _activityName = activityName;

            _scope = _log.PushActivity(activityName); 
            log.DebugFormat(">> Entering activity [{0}]", activityName);            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        /// resources.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Dispose()
        {
            _log.DebugFormat("<< Leaving activity [{0}]", _activityName);
            _scope.Dispose();
        }
    }
}
