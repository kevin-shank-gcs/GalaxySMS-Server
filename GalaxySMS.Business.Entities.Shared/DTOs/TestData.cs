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

    public class TestData : EntityBase, IIdentifiableEntity
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyCpuInformation GalaxyCpuInformation { get; set; }

        //[DataMember]
        public String UniqueId
        {
            get
            {
                if (GalaxyCpuInformation == null)
                    return string.Empty;
                else
                    return string.Format("{0:D3}:{1:D3}:{2:D}", GalaxyCpuInformation.ClusterNumber, GalaxyCpuInformation.PanelNumber,
                        GalaxyCpuInformation.CpuId);
            }
        }
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

        public TestData()
        {
            GalaxyCpuInformation = new GalaxyCpuInformation();
        }

        public TestData(TestData c)
        {
            Description = c.Description;
            RemoteIpEndpoint = c.RemoteIpEndpoint;
            LocalIpEndpoint = c.LocalIpEndpoint;
            IsConnected = c.IsConnected;
            IsAuthenticated = c.IsAuthenticated;
            CreatedDateTime = c.CreatedDateTime;
            SocketHandle = c.SocketHandle;
            GalaxyCpuInformation = new GalaxyCpuInformation(c.GalaxyCpuInformation);
        }


        public TestData(CpuConnectionInfo c)
        {
            Description = c.Description;
            RemoteIpEndpoint = c.RemoteIpEndpoint;
            LocalIpEndpoint = c.LocalIpEndpoint;
            IsConnected = c.IsConnected;
            IsAuthenticated = c.IsAuthenticated;
            CreatedDateTime = c.CreatedDateTime;
            SocketHandle = c.SocketHandle;
            GalaxyCpuInformation = new GalaxyCpuInformation(c.GalaxyCpuInformation);
        }
        //#region INotifyPropertyChanged Members

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void NotifyPropertyChanged(String info)
        //{
        //	if (PropertyChanged != null)
        //	{
        //		PropertyChanged(this, new PropertyChangedEventArgs(info));
        //	}
        //}
        //#endregion

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
                {
                    if (Guid.TryParse(GalaxyCpuInformation.InstanceGuid, out g))
                        return g;
                }
                return g;
            }
            set { }
        }
    }
}
