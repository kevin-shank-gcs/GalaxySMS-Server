using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public class CpuConnectionInfoResp 
    {
        public GalaxyCpuInformationResp GalaxyCpuInformation { get; set; }

        public String UniqueId { get { return string.Format("{0:D3}:{1:D3}:{2:D}", GalaxyCpuInformation.ClusterNumber, GalaxyCpuInformation.PanelNumber, GalaxyCpuInformation.CpuId); } }

        public String Description { get; set; }
        public String RemoteIpEndpoint { get; set; }
        public String LocalIpEndpoint { get; set; }
        public Boolean IsConnected { get; set; }
        public Boolean IsAuthenticated { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public String SocketHandle { get; set; }
        public GalaxyCpuDatabaseInformationResp CpuDatabaseInformation { get; set; }

        public CpuConnectionInfoResp()
        {
            GalaxyCpuInformation = new GalaxyCpuInformationResp();
        }

        public CpuConnectionInfoResp(CpuConnectionInfoResp c)
        {
            Description = c.Description;
            RemoteIpEndpoint = c.RemoteIpEndpoint;
            LocalIpEndpoint = c.LocalIpEndpoint;
            IsConnected = c.IsConnected;
            IsAuthenticated = c.IsAuthenticated;
            CreatedDateTime = c.CreatedDateTime;
            SocketHandle = c.SocketHandle;
            GalaxyCpuInformation = new GalaxyCpuInformationResp(c.GalaxyCpuInformation);
            CpuDatabaseInformation = new GalaxyCpuDatabaseInformationResp(c.CpuDatabaseInformation);
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

