using System;
using System.Collections.Generic;
using System.Text;
//using GalaxySMS.Resources;
using GCS.Core.Common.Contracts;
using GCS.Framework.Utilities;
#if NETCOREAPP
#else
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Client.SDK.Managers;
#endif

namespace GalaxySMS.MessageQueue.Integration
{
    public static class MyHelpers
    {
#if NETCOREAPP
#else
        public static IGalaxySiteServerConnection ServerConnection { get; set; }
        public static AssemblyAttributes MyAssemblyAttributes { get; set; }

        public static T GetManager<T>(IApplicationUserSessionDataHeader sessionData) where T : ManagerBase, new()
        {
            var manager = Helpers.GetManager<T>(ServerConnection.ConnectionSettings.ServerAddress,
                ServerConnection.ConnectionSettings.BindingType, string.Empty, string.Empty, sessionData);
            return manager;
        }
#endif
    }
}
