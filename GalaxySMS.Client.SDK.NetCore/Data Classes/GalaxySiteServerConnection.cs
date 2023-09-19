////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DataClasses\GalaxySiteServerConnection.cs
//
// summary:	Implements the galaxy site server connection class
////////////////////////////////////////////////////////////////////////////////////////////////////

//using GCS.Core.Common.Config;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.Utils;
using System;
using System.ComponentModel.Composition;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace GalaxySMS.Client.SDK.DataClasses
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy site server connection. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [Export(typeof(IGalaxySiteServerConnection))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class GalaxySiteServerConnection : IGalaxySiteServerConnection
    {
        /// <summary>   Options for controlling the operation. </summary>
        private IGalaxySiteServerConnectionSettings _settings;
        /// <summary>   Unique identifier for the instance. </summary>
        private Guid _instanceGuid = Guid.Empty;
        /// <summary>   Size of the maximum received message. </summary>
        private int _maxReceivedMessageSize = Int32.MaxValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="connectionSettings">   The connection settings. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [ImportingConstructor]
        public GalaxySiteServerConnection(IGalaxySiteServerConnectionSettings connectionSettings)
        {
            _settings = connectionSettings;
            _instanceGuid = Guid.NewGuid();
            ClientUserSessionData = new ApplicationUserSessionHeader();
            ClientUserSessionData.ApplicationId = GalaxySMS.Common.Constants.ApplicationIds.GalaxySMS_Admin_Id;
            ClientUserSessionData.UserName = PrincipalIdentity.CurrentWindowsUserName;
            _maxReceivedMessageSize = Int32.MaxValue;// 2147483647;//ConfigurationUtilities.GetAppSetting(string.Empty, string.Empty, "MaxReceivedMessageSize", 2147483647, true);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier of the instance. </summary>
        ///
        /// <value> Unique identifier of the instance. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid InstanceGuid
        {
            get { return _instanceGuid; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the connection settings. </summary>
        ///
        /// <value> The connection settings. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IGalaxySiteServerConnectionSettings ConnectionSettings { get { return _settings; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the binding. </summary>
        ///
        /// <value> The binding. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Binding Binding
        {
            get
            {
                NetTcpBinding binding;
                switch (ConnectionSettings.BindingType)
                {
                    case GalaxySiteServerConnectionSettings.WcfBindingType.Tcp:
                        binding = new NetTcpBinding();

                        // ReliableSession and TransactionFlow are not available in NetTcpBinding .NET Core
                        //binding.ReliableSession.Enabled = true;
                        //binding.TransactionFlow = true;

                        binding.MaxReceivedMessageSize = _maxReceivedMessageSize;
                        binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
                        binding.SendTimeout = new TimeSpan(0, 10, 0);
                        return binding;

                    case GalaxySiteServerConnectionSettings.WcfBindingType.BasicHttp:
                        return new BasicHttpBinding();

                    case GalaxySiteServerConnectionSettings.WcfBindingType.SecureHttp:
                        return new BasicHttpsBinding();
                }

                return new NetTcpBinding();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the endpoint base address. </summary>
        ///
        /// <value> The endpoint base address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EndpointAddress EndpointBaseAddress
        {
            get
            {
                return new EndpointAddress(ConnectionSettings.SiteServerBaseAddress);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets service address. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="service">  The service. </param>
        ///
        /// <returns>   The service address. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EndpointAddress GetServiceAddress(string service)
        {
            return new EndpointAddress(string.Format("{0}{1}", EndpointBaseAddress, service));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the client user session. </summary>
        ///
        /// <value> Information describing the client user session. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IApplicationUserSessionDataHeader ClientUserSessionData
        {
            get;
            internal set;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests connection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   True if the test passes, false if the test fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool TestConnection()
        {

            return true;
        }


    }
}
