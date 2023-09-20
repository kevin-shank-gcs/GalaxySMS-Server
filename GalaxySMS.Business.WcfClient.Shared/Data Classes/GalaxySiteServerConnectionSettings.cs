////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DataClasses\GalaxySiteServerConnectionSettings.cs
//
// summary:	Implements the galaxy site server connection settings class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.SDK.DataClasses
{
    [Export(typeof(IGalaxySiteServerConnectionSettings))]
    [PartCreationPolicy(CreationPolicy.Shared)]

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// A galaxy site server connection settings. This class cannot be inherited.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public sealed class GalaxySiteServerConnectionSettings : ObjectBase, IGalaxySiteServerConnectionSettings
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent WCF binding types. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum WcfBindingType
        {
            /// <summary>   SOAP Style. </summary>
            BasicHttp,
            /// <summary>   An enum constant representing the secure HTTP option. </summary>
            SecureHttp,
            /// <summary>   An enum constant representing the TCP option. </summary>
            //           WebHttp,        // REST style
            Tcp,
        }

        /// <summary>   The server address. </summary>
        private string _serverAddress = "localhost";
        /// <summary>   Name of the server. </summary>
        private string _serverName;
        /// <summary>   The port number. </summary>
        private ushort _portNumber = 8010;
        /// <summary>   Type of the binding. </summary>
        private WcfBindingType _bindingType = WcfBindingType.Tcp;
        /// <summary>   Name of the user. </summary>
        private string _userName;
        /// <summary>   The password. </summary>
        private string _password;
        /// <summary>   URL of the API server. </summary>
        private string _apiServerUrl;
        /// <summary>   URL of the signal r server. </summary>
        private string _signalRServerUrl;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the server. </summary>
        ///
        /// <value> The name of the server. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ServerName
        {
            get { return _serverName; }
            set
            {
                if (_serverName != value)
                {
                    _serverName = value;
                    OnPropertyChanged(() => ServerName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the port number. </summary>
        ///
        /// <value> The port number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ushort PortNumber
        {
            get { return _portNumber; }
            set
            {
                if (_portNumber != value)
                {
                    _portNumber = value;
                    OnPropertyChanged(() => PortNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the server address. </summary>
        ///
        /// <value> The server address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ServerAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_serverAddress))
                    _serverAddress = "localhost";
                return _serverAddress;
            }
            set
            {
                if (_serverAddress != value)
                {
                    _serverAddress = value;
                    OnPropertyChanged(() => ServerAddress);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the binding. </summary>
        ///
        /// <value> The type of the binding. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public WcfBindingType BindingType
        {
            get { return _bindingType; }
            set
            {
                if (_bindingType != value)
                {
                    _bindingType = value;
                    OnPropertyChanged(() => BindingType);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the user. </summary>
        ///
        /// <value> The name of the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(() => UserName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets URL of the API server. </summary>
        ///
        /// <value> The API server URL. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ApiServerUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_apiServerUrl))
                    _apiServerUrl = "http://localhost:38000";
                return _apiServerUrl;
            }
            set
            {
                if (_apiServerUrl != value)
                {
                    _apiServerUrl = value;
                    OnPropertyChanged(() => ApiServerUrl);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets URL of the signal r server. </summary>
        ///
        /// <value> The signal r server URL. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string SignalRServerUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_signalRServerUrl))
                    _signalRServerUrl = "http://localhost:38000/signalr";
                return _signalRServerUrl;
            }
            set
            {
                if (_signalRServerUrl != value)
                {
                    _signalRServerUrl = value;
                    OnPropertyChanged(() => SignalRServerUrl, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the password. </summary>
        ///
        /// <value> The password. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(() => Password);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the site server base address. </summary>
        ///
        /// <value> The site server base address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Uri SiteServerBaseAddress
        {
            get
            {
                switch (BindingType)
                {
                    case WcfBindingType.BasicHttp:
                        return new Uri(string.Format("http://{0}:{1}/", ServerAddress, PortNumber));
                        break;

                    case WcfBindingType.SecureHttp:
                        return new Uri(string.Format("https://{0}:{1}/", ServerAddress, PortNumber));
                        break;

                    case WcfBindingType.Tcp:
                    default:
                        return new Uri(string.Format("net.tcp://{0}:{1}/", ServerAddress, PortNumber));
                        break;
                }
            }
        }
    }
}
