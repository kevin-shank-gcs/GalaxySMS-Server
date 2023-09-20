////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	GalaxySMSClientManager.cs
//
// summary:	Implements the galaxy SMS client manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Bootstrapper;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.SDK
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for galaxy SMS clients. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxySMSClientManager
    {
        /// <summary>   The connections. </summary>
        private Dictionary<string, GalaxySiteServerConnection> _connections;
        /// <summary>   The site server connections. </summary>
        private ReadOnlyDictionary<string, GalaxySiteServerConnection> _siteServerConnections;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the site server connections. </summary>
        ///
        /// <value> The site server connections. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyDictionary<string, GalaxySiteServerConnection> SiteServerConnections
        {
            get
            {
                _siteServerConnections = new ReadOnlyDictionary<string, GalaxySiteServerConnection>(_connections);
                return _siteServerConnections;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxySMSClientManager()
        {
            //ObjectBase.Container = MEFLoader.Init(new List<ComposablePartCatalog>() 
            StaticObjects.Container = MEFLoader.Init(new List<ComposablePartCatalog>() 
            {
                new AssemblyCatalog(Assembly.GetExecutingAssembly())
            });

            _connections = new Dictionary<string, GalaxySiteServerConnection>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a site server connection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="settings"> Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxySiteServerConnection. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxySiteServerConnection AddSiteServerConnection(GalaxySiteServerConnectionSettings settings)
        {
            GalaxySiteServerConnection connection;
            if (_connections.Count == 0  ||
                _connections.ContainsKey(settings.ServerName) == false)
            {
                connection = new GalaxySiteServerConnection(settings);
                _connections.Add(settings.ServerName, connection);
                return connection;
            }
            else
            {
                return _connections[settings.ServerName];
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes the site server connection described by serverName. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="serverName">   Name of the server. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RemoveSiteServerConnection(string serverName)
        {
            if (_connections.ContainsKey(serverName) == true)
            {
                return _connections.Remove(serverName);
            }
            return false;
        }
    }
}
