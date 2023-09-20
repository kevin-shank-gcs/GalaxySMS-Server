////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\HttpApplicationExtensions.cs
//
// summary:	Implements the HTTP application extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GCS.Core.Common.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An application state extension. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class ApplicationStateExtension
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HttpApplicationState extension method that gets set application state. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="appState">         The appState to act on. </param>
        /// <param name="objectName">       Name of the object. </param>
        /// <param name="objectValue">      The object value. </param>
        /// <param name="syncCheckMinutes"> The synchronise check in minutes. </param>
        ///
        /// <returns>   The set application state. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T GetSetApplicationState<T>(this HttpApplicationState appState, string objectName, object objectValue = null, int syncCheckMinutes = 0)
        {
            T retVal = default(T);
            appState.Lock();
            if (appState[objectName + "LastSync"] == null || DateTimeOffset.Now.Subtract(((DateTimeOffset)appState[objectName + "LastSync"])).TotalMinutes >= syncCheckMinutes)
            {
                appState[objectName + "LastSync"] = DateTimeOffset.Now;

                if (objectValue != null)
                    appState[objectName] = objectValue;
            }
            if (appState[objectName] != null)
                retVal = (T)appState[objectName];
            appState.UnLock();
            return retVal;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A HttpApplicationState extension method that gets set application state.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="appState">         The appState to act on. </param>
        /// <param name="objectName">       Name of the object. </param>
        /// <param name="objectValue">      The object value. </param>
        /// <param name="syncCheckMinutes"> The synchronise check in minutes. </param>
        ///
        /// <returns>   The set application state. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static object GetSetApplicationState(this HttpApplicationState appState, string objectName, object objectValue = null, int syncCheckMinutes = 0)
        {
            object retVal = null;
            appState.Lock();
            if (appState[objectName + "LastSync"] == null || DateTimeOffset.Now.Subtract(((DateTimeOffset)appState[objectName + "LastSync"])).TotalMinutes >= syncCheckMinutes)
            {
                appState[objectName + "LastSync"] = DateTimeOffset.Now;

                if (objectValue != null)
                    appState[objectName] = objectValue;
            }
            if (appState[objectName] != null)
                retVal = appState[objectName];
            appState.UnLock();
            return retVal;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HttpApplicationState extension method that sets application state. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="appState">         The appState to act on. </param>
        /// <param name="objectName">       Name of the object. </param>
        /// <param name="objectValue">      The object value. </param>
        /// <param name="syncCheckMinutes"> The synchronise check in minutes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetApplicationState(this HttpApplicationState appState, string objectName, object objectValue, int syncCheckMinutes = 0)
        {
            appState.Lock();
            if (appState[objectName + "LastSync"] == null || DateTimeOffset.Now.Subtract(((DateTimeOffset)appState[objectName + "LastSync"])).TotalMinutes >= syncCheckMinutes)
            {
                appState[objectName + "LastSync"] = DateTimeOffset.Now;
                appState[objectName] = objectValue;
            }
            appState.UnLock();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HttpApplicationState extension method that gets application state. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="appState">     The appState to act on. </param>
        /// <param name="objectName">   Name of the object. </param>
        ///
        /// <returns>   The application state. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static object GetApplicationState(this HttpApplicationState appState, string objectName)
        {
            object retVal = null;
            appState.Lock();
            if (appState[objectName] != null)
                retVal = appState[objectName];
            appState.UnLock();
            return retVal;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A HttpApplicationState extension method that gets application state. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="appState">     The appState to act on. </param>
        /// <param name="objectName">   Name of the object. </param>
        ///
        /// <returns>   The application state. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T GetApplicationState<T>(this HttpApplicationState appState, string objectName)
        {
            T retVal = default(T);
            appState.Lock();
            if (appState[objectName] != null)
                retVal = (T)appState[objectName];
            appState.UnLock();
            return retVal;
        }
    }
}
