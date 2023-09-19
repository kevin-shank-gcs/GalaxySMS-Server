using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class CpuConnectionInfo : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public GalaxyCpuInformation GalaxyCpuInformation { get; set; }

        //		[DataMember]
        public String UniqueId { get { return string.Format("{0:D3}:{1:D3}:{2:D}", GalaxyCpuInformation.ClusterNumber, GalaxyCpuInformation.PanelNumber, GalaxyCpuInformation.CpuId); } }

        [DataMember]
        public String Description { get; set; }

        [DataMember]
        public String RemoteIpEndpoint { get; set; }

        [DataMember]
        public String LocalIpEndpoint { get; set; }

        [DataMember]
        public Boolean IsConnected { get; set; }

        [DataMember]
        public Boolean IsAuthenticated { get; set; }

        [DataMember]
        public DateTimeOffset CreatedDateTime { get; set; }

        [DataMember]
        public String SocketHandle { get; set; }

        [DataMember]
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

        public int EntityId
        {
            get
            {
                return 0;
            }
            set
            {

            }
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
