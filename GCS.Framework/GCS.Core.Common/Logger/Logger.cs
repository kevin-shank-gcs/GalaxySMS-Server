////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Logger\Logger.cs
//
// summary:	Implements the logger class
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
    /// <summary>   A logger adapter. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class LoggerAdapter : ILogger
    {
        /// <summary>   The log. </summary>
        private readonly ILog _log;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="log">  The log. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal LoggerAdapter(ILog log)
        {
            _log = log;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Debugs. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Debug(object message)
        {
            _log.Debug(message);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Debugs. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">      The message. </param>
        /// <param name="exception">    The exception. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Debug(object message, Exception exception)
        {
            _log.Debug(message, exception);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Debug format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DebugFormat(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Debug format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DebugFormat(string format, object arg0)
        {
            _log.DebugFormat(format, arg0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Debug format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        /// <param name="arg1">     The first argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DebugFormat(string format, object arg0, object arg1)
        {
            _log.DebugFormat(format, arg0, arg1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Debug format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        /// <param name="arg1">     The first argument. </param>
        /// <param name="arg2">     The second argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.DebugFormat(format, arg0, arg1, arg2);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Debug format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="provider"> The provider. </param>
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.DebugFormat(provider, format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Infoes. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Info(object message)
        {
            _log.Info(message);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Infoes. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">      The message. </param>
        /// <param name="exception">    The exception. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Info(object message, Exception exception)
        {
            _log.Info(message, exception);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Information format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InfoFormat(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Information format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InfoFormat(string format, object arg0)
        {
            _log.InfoFormat(format, arg0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Information format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        /// <param name="arg1">     The first argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InfoFormat(string format, object arg0, object arg1)
        {
            _log.InfoFormat(format, arg0, arg1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Information format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        /// <param name="arg1">     The first argument. </param>
        /// <param name="arg2">     The second argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.InfoFormat(format, arg0, arg1, arg2);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Information format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="provider"> The provider. </param>
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.InfoFormat(provider, format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Warns. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Warn(object message)
        {
            _log.Warn(message);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Warns. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">      The message. </param>
        /// <param name="exception">    The exception. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Warn(object message, Exception exception)
        {
            _log.Warn(message, exception);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Warning format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void WarnFormat(string format, params object[] args)
        {
            _log.WarnFormat(format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Warning format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void WarnFormat(string format, object arg0)
        {
            _log.WarnFormat(format, arg0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Warning format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        /// <param name="arg1">     The first argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void WarnFormat(string format, object arg0, object arg1)
        {
            _log.WarnFormat(format, arg0, arg1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Warning format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        /// <param name="arg1">     The first argument. </param>
        /// <param name="arg2">     The second argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.WarnFormat(format, arg0, arg1, arg2);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Warning format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="provider"> The provider. </param>
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.WarnFormat(provider, format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Errors. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Error(object message)
        {
            _log.Error(message);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Errors. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">      The message. </param>
        /// <param name="exception">    The exception. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Error(object message, Exception exception)
        {
            _log.Error(message, exception);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Error format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ErrorFormat(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Error format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ErrorFormat(string format, object arg0)
        {
            _log.ErrorFormat(format, arg0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Error format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        /// <param name="arg1">     The first argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            _log.ErrorFormat(format, arg0, arg1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Error format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        /// <param name="arg1">     The first argument. </param>
        /// <param name="arg2">     The second argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.ErrorFormat(format, arg0, arg1, arg2);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Error format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="provider"> The provider. </param>
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.ErrorFormat(provider, format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fatals. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Fatal(object message)
        {
            _log.Fatal(message);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fatals. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">      The message. </param>
        /// <param name="exception">    The exception. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Fatal(object message, Exception exception)
        {
            _log.Fatal(message, exception);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fatal format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FatalFormat(string format, params object[] args)
        {
            _log.FatalFormat(format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fatal format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FatalFormat(string format, object arg0)
        {
            _log.FatalFormat(format, arg0);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fatal format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        /// <param name="arg1">     The first argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FatalFormat(string format, object arg0, object arg1)
        {
            _log.FatalFormat(format, arg0, arg1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fatal format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="arg0">     The argument 0. </param>
        /// <param name="arg1">     The first argument. </param>
        /// <param name="arg2">     The second argument. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.FatalFormat(format, arg0, arg1, arg2);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fatal format. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="provider"> The provider. </param>
        /// <param name="format">   Describes the format to use. </param>
        /// <param name="args">     A variable-length parameters list containing arguments. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.FatalFormat(provider, format, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether a debug is enabled. </summary>
        ///
        /// <value> True if a debug is enabled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsDebugEnabled
        {
            get { return _log.IsDebugEnabled; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether an information is enabled. </summary>
        ///
        /// <value> True if an information is enabled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsInfoEnabled
        {
            get { return _log.IsInfoEnabled; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether a warning is enabled. </summary>
        ///
        /// <value> True if a warning is enabled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsWarnEnabled
        {
            get { return _log.IsWarnEnabled; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether an error is enabled. </summary>
        ///
        /// <value> True if an error is enabled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsErrorEnabled
        {
            get { return _log.IsErrorEnabled; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether a fatal is enabled. </summary>
        ///
        /// <value> True if a fatal is enabled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsFatalEnabled
        {
            get { return _log.IsFatalEnabled; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Pushes an activity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="activityName"> Name of the activity. </param>
        ///
        /// <returns>   An IDisposable. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IDisposable PushActivity(string activityName)
        {
            return ThreadContext.Stacks["activity"].Push(activityName);
        }
    }
}
