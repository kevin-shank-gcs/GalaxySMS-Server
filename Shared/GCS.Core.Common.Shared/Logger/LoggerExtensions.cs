////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Logger\LoggerExtensions.cs
//
// summary:	Implements the logger extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace GCS.Core.Common.Logger
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A logger extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class LoggerExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ILogger extension method that debugs. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="log">          The log to act on. </param>
        /// <param name="getMessage">   Message describing the get. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Debug(this ILogger log, Func<string> getMessage)
        {
            if (! log.IsDebugEnabled)
            {
                return;
            }

            var logMessage = getMessage();
            log.Debug(logMessage);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ILogger extension method that infoes. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="log">          The log to act on. </param>
        /// <param name="getMessage">   Message describing the get. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Info(this ILogger log, Func<string> getMessage)
        {
            if (!log.IsInfoEnabled)
            {
                return;
            }

            var logMessage = getMessage();
            log.Info(logMessage);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ILogger extension method that warns. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="log">          The log to act on. </param>
        /// <param name="getMessage">   Message describing the get. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Warn(this ILogger log, Func<string> getMessage)
        {
            if (!log.IsWarnEnabled)
            {
                return;
            }

            var logMessage = getMessage();
            log.Warn(logMessage);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ILogger extension method that errors. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="log">          The log to act on. </param>
        /// <param name="getMessage">   Message describing the get. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Error(this ILogger log, Func<string> getMessage)
        {
            if (!log.IsErrorEnabled)
            {
                return;
            }

            var logMessage = getMessage();
            log.Error(logMessage);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ILogger extension method that fatals. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="log">          The log to act on. </param>
        /// <param name="getMessage">   Message describing the get. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Fatal(this ILogger log, Func<string> getMessage)
        {
            if (!log.IsFatalEnabled)
            {
                return;
            }

            var logMessage = getMessage();
            log.Fatal(logMessage);
        }


        public static void LogTransactionInformation(this ILogger log, string callingMethod)
        {
            var ambientTransaction = Transaction.Current;
            if (ambientTransaction == null)
            {
                log.Log().Info($"{callingMethod} - Transaction.Current is null");
                return;
            }

            log.Log().Info($"{callingMethod} - Current transaction ID:{ambientTransaction.TransactionInformation.LocalIdentifier}, Distributed ID:{ambientTransaction.TransactionInformation.DistributedIdentifier}");
            log.Log().Info($"{callingMethod} - Current transaction Status: {ambientTransaction.TransactionInformation.Status}");
            log.Log().Info($"{callingMethod} - Current transaction Creation Time: {ambientTransaction.TransactionInformation.CreationTime}");
            log.Log().Info($"{callingMethod} - Current transaction Isolation level: {ambientTransaction.IsolationLevel}");
            log.Log().Info($"{callingMethod} - Current transaction PromoterType: {ambientTransaction.PromoterType}");
        }
    }
}
