using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.ServiceModel.Extensions;

#if NETCOREAPP
namespace GalaxySMS.Client.Proxies.NetCore
#else
namespace GalaxySMS.Client.Proxies
#endif
{
    [Export(typeof(IServiceFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ServiceFactory : IServiceFactory
    {
        IServiceProvider _serviceProvider;

        T IServiceFactory.CreateClient<T>()
        {
            //return ObjectBase.Container.GetExportedValue<T>();
            return StaticObjects.Container.GetExportedValue<T>();
        }

        public T CreateClient<T>(Binding binding, EndpointAddress endpointAddress, IApplicationUserSessionDataHeader applicationUserSessionDataHeader) where T : IServiceContract
        {
            //var ret1 = Activator.CreateInstance<T>();
            //T ret = ObjectBase.Container.GetExportedValue<T>();
            
            //if (binding == null || endpointAddress == null)
            //{
            //    return ret;//ObjectBase.Container.GetExportedValue<T>();
            //}
            var factory = new ChannelFactory<T>(binding, endpointAddress);
            factory.Endpoint.EndpointBehaviors.Add(new ApplicationUserSessionHeaderInspectorBehavior());
            ClientApplicationUserSessionHeaderContext.HeaderInformation.UserName =
                applicationUserSessionDataHeader.UserName;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.SessionGuid =
                applicationUserSessionDataHeader.SessionGuid;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.CurrentEntityId =
                applicationUserSessionDataHeader.CurrentEntityId;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.CurrentSiteId =
                applicationUserSessionDataHeader.CurrentSiteId;
            //ClientApplicationUserSessionHeaderContext.HeaderInformation.ClientDateTime = DateTimeOffset.Now;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.Culture =
                applicationUserSessionDataHeader.Culture;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.UiCulture =
                applicationUserSessionDataHeader.UiCulture;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.OperationGuid =
                applicationUserSessionDataHeader.OperationGuid;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.ClientTimeZoneId = TimeZoneInfo.Local.Id;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.ApplicationId =
                applicationUserSessionDataHeader.ApplicationId;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.ApplicationName =
                applicationUserSessionDataHeader.ApplicationName;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.ApplicationVersion =
                applicationUserSessionDataHeader.ApplicationVersion;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.ProductVersionMajor =
                applicationUserSessionDataHeader.ProductVersionMajor;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.ProductVersionMinor =
                applicationUserSessionDataHeader.ProductVersionMinor;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.ProductVersionBuild =
                applicationUserSessionDataHeader.ProductVersionBuild;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.ProductVersionRevision =
                applicationUserSessionDataHeader.ProductVersionRevision;
            ClientApplicationUserSessionHeaderContext.HeaderInformation.MachineName =
                applicationUserSessionDataHeader.MachineName;

            var channel = factory.CreateChannel();
            return channel;

        }
        public T CreateDuplexClient<T>(object callbackInstance) where T : IServiceContract
        {
            //return GCS.Core.Common.Core.ObjectBase.Container.GetExportedValue<T>();
            return GCS.Core.Common.Core.StaticObjects.Container.GetExportedValue<T>();
        }


    }

}
