////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\HttpSessionExtensions.cs
//
// summary:	Implements the HTTP session extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Web;
using System.Web.SessionState;

namespace GCS.Core.Common.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A session extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class SessionExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get value. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    . </typeparam>
        /// <param name="session">  . </param>
        /// <param name="key">      . </param>
        ///
        /// <returns>   The data from session. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T GetDataFromSession<T>(this HttpSessionState session, string key)
        {
            return (T) session[key];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get value. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    . </typeparam>
        /// <param name="session">  . </param>
        /// <param name="key">      . </param>
        ///
        /// <returns>   The data from session. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T GetDataFromSession<T>(this HttpSessionStateBase session, string key)
        {
            return (T)session[key];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Set value. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    . </typeparam>
        /// <param name="session">  . </param>
        /// <param name="key">      . </param>
        /// <param name="value">    . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetDataToSession<T>(this HttpSessionState session, string key, object value)
        {
            session[key] = value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Set value. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    . </typeparam>
        /// <param name="session">  . </param>
        /// <param name="key">      . </param>
        /// <param name="value">    . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetDataToSession<T>(this HttpSessionStateBase session, string key, object value)
        {
            session[key] = value;
        }
    }
}