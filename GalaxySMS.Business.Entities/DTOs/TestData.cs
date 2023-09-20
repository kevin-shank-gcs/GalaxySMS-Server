using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class TestData : EntityBase, IIdentifiableEntity
    {
        [DataMember]
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
