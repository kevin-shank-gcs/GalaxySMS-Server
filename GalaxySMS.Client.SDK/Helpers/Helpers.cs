////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Helpers\Helpers.cs
//
// summary:	Implements the helpers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Helpers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A helpers. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class Helpers
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a manager. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="serverAddress">    The server address. </param>
        /// <param name="bindingType">      Type of the binding. </param>
        /// <param name="userName">         Name of the user. </param>
        /// <param name="password">         The password. </param>
        /// <param name="sessionHeader">    The session header. </param>
        ///
        /// <returns>   The manager. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T GetManager<T>(string serverAddress, GalaxySiteServerConnectionSettings.WcfBindingType bindingType, string userName, string password, IApplicationUserSessionDataHeader sessionHeader ) where T: ManagerBase, new()
        {
            var siteServerConnection = GetGalaxySiteServerConnection(serverAddress, bindingType, userName, password, sessionHeader);
            return (T)Activator.CreateInstance(typeof (T), siteServerConnection);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user session manager. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="serverAddress">    The server address. </param>
        /// <param name="bindingType">      Type of the binding. </param>
        /// <param name="userName">         Name of the user. </param>
        /// <param name="password">         The password. </param>
        /// <param name="sessionHeader">    The session header. </param>
        ///
        /// <returns>   The user session manager. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static UserSessionManager GetUserSessionManager(string serverAddress, GalaxySiteServerConnectionSettings.WcfBindingType bindingType, string userName, string password, IApplicationUserSessionDataHeader sessionHeader )
        {
            var siteServerConnection = GetGalaxySiteServerConnection(serverAddress, bindingType, userName, password, sessionHeader);
            return new UserSessionManager(siteServerConnection);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user manager. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="serverAddress">    The server address. </param>
        /// <param name="bindingType">      Type of the binding. </param>
        /// <param name="userName">         Name of the user. </param>
        /// <param name="password">         The password. </param>
        /// <param name="sessionHeader">    The session header. </param>
        ///
        /// <returns>   The user manager. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static UserManager GetUserManager(string serverAddress, GalaxySiteServerConnectionSettings.WcfBindingType bindingType, string userName, string password, IApplicationUserSessionDataHeader sessionHeader)
        {
            var siteServerConnection = GetGalaxySiteServerConnection(serverAddress, bindingType, userName, password, sessionHeader);
            return new UserManager(siteServerConnection);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets entity manager. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="serverAddress">    The server address. </param>
        /// <param name="bindingType">      Type of the binding. </param>
        /// <param name="userName">         Name of the user. </param>
        /// <param name="password">         The password. </param>
        /// <param name="sessionHeader">    The session header. </param>
        ///
        /// <returns>   The entity manager. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static EntityManager GetEntityManager(string serverAddress, GalaxySiteServerConnectionSettings.WcfBindingType bindingType, string userName, string password, IApplicationUserSessionDataHeader sessionHeader = null)
        {
            var siteServerConnection = GetGalaxySiteServerConnection(serverAddress, bindingType, userName, password, sessionHeader);
            return new EntityManager(siteServerConnection);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets initialize system database manager. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="serverAddress">    The server address. </param>
        /// <param name="bindingType">      Type of the binding. </param>
        /// <param name="userName">         Name of the user. </param>
        /// <param name="password">         The password. </param>
        /// <param name="sessionHeader">    The session header. </param>
        ///
        /// <returns>   The initialize system database manager. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static InitializeSystemDatabaseManager GetInitializeSystemDatabaseManager(string serverAddress, GalaxySiteServerConnectionSettings.WcfBindingType bindingType, string userName, string password, IApplicationUserSessionDataHeader sessionHeader = null)
        {
            var siteServerConnection = GetGalaxySiteServerConnection(serverAddress, bindingType, userName, password, sessionHeader);
            return new InitializeSystemDatabaseManager(siteServerConnection);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy site server connection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="serverAddress">    The server address. </param>
        /// <param name="bindingType">      Type of the binding. </param>
        /// <param name="userName">         Name of the user. </param>
        /// <param name="password">         The password. </param>
        /// <param name="sessionHeader">    The session header. </param>
        ///
        /// <returns>   The galaxy site server connection. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static GalaxySiteServerConnection GetGalaxySiteServerConnection(
            string serverAddress,
            GalaxySiteServerConnectionSettings.WcfBindingType bindingType,
            string userName, string password, IApplicationUserSessionDataHeader sessionHeader)
        {
            var galaxySiteServerConnectionSettings = new GalaxySiteServerConnectionSettings();

            if (string.IsNullOrWhiteSpace(serverAddress))
                serverAddress = "localhost";

            galaxySiteServerConnectionSettings.BindingType = bindingType;
            galaxySiteServerConnectionSettings.ServerAddress = serverAddress;
            galaxySiteServerConnectionSettings.UserName = userName;
            galaxySiteServerConnectionSettings.Password = password;

            var siteServerConnection = new GalaxySiteServerConnection(galaxySiteServerConnectionSettings);
            if (sessionHeader != null)
                siteServerConnection.ClientUserSessionData = sessionHeader;
            AppDomain root = AppDomain.CurrentDomain;
            return siteServerConnection;
        }
    }

}
