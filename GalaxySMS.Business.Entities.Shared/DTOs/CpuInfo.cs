using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public class CpuConnectionInfo : EntityBase, IIdentifiableEntity
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyCpuInformation GalaxyCpuInformation { get; set; }

        public String UniqueId { get { return string.Format("{0:D3}:{1:D3}:{2:D}", GalaxyCpuInformation.ClusterNumber, GalaxyCpuInformation.PanelNumber, GalaxyCpuInformation.CpuId); } }

#if NetCoreApi
#else
        [DataMember]
#endif
        public String Description { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String RemoteIpEndpoint { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String LocalIpEndpoint { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Boolean IsConnected { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Boolean IsAuthenticated { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset CreatedDateTime { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String SocketHandle { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyCpuDatabaseInformation CpuDatabaseInformation { get; set; }

        public CpuConnectionInfo()
        {
            GalaxyCpuInformation = new GalaxyCpuInformation();
        }

        public CpuConnectionInfo(CpuConnectionInfo c)
        {
            Description = c.Description;
            RemoteIpEndpoint = c.RemoteIpEndpoint;
            LocalIpEndpoint = c.LocalIpEndpoint;
            IsConnected = c.IsConnected;
            IsAuthenticated = c.IsAuthenticated;
            CreatedDateTime = c.CreatedDateTime;
            SocketHandle = c.SocketHandle;
            GalaxyCpuInformation = new GalaxyCpuInformation(c.GalaxyCpuInformation);
            CpuDatabaseInformation = new GalaxyCpuDatabaseInformation(c.CpuDatabaseInformation);
        }


        public Guid EntityGuid
        {
            get
            {
                Guid g = Guid.Empty;
                if (GalaxyCpuInformation != null)
                    Guid.TryParse(GalaxyCpuInformation.InstanceGuid, out g);
                return g;
            }
            set
            {
                Guid g = value;
            }
        }
    }
}

