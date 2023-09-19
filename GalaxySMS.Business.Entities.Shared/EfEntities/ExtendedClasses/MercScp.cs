using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

using System.Runtime.Serialization;

#if NetCoreApi
    namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
    namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class MercScp
    {
        public MercScp()
        {
            Initialize();
        }

        public MercScp(MercScp e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(MercScp e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.MercScpUid = e.MercScpUid;
            this.MercScpTypeUid = e.MercScpTypeUid;
            this.MercScpGroupUid = e.MercScpGroupUid;
            this.ScpName = e.ScpName;
            this.Location = e.Location;
            this.Description = e.Description;
            this.MacAddress = e.MacAddress;
            this.Serialnumber = e.Serialnumber;
            this.ConnectionType = e.ConnectionType;
            this.IpAddress = e.IpAddress;
            this.IpPort = e.IpPort;
            this.AesPassword = e.AesPassword;
            this.ScpReplyTimeout = e.ScpReplyTimeout;
            this.TcpConnectRetryInterval = e.TcpConnectRetryInterval;
            this.RetryCountBeforeOffline = e.RetryCountBeforeOffline;
            this.OfflineTime = e.OfflineTime;
            this.PollDelay = e.PollDelay;
            this.TimeZoneId = e.TimeZoneId;
            this.UseDaylightSavingsTime = e.UseDaylightSavingsTime;
            this.TransactionCount = e.TransactionCount;
            this.TransactionUnreportedLimit = e.TransactionUnreportedLimit;
            this.DualPortEnabled = e.DualPortEnabled;
            this.ConnectionTypeAlt = e.ConnectionTypeAlt;
            this.RetryCountBeforeOfflineAlt = e.RetryCountBeforeOfflineAlt;
            this.PollDelayAlt = e.PollDelayAlt;
            this.IpAddressAlt = e.IpAddressAlt;
            this.IpPortAlt = e.IpPortAlt;
            this.AllowConnection = e.AllowConnection;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            this.ScpMercGroupName = e.ScpMercGroupName;
            this.TotalRowCount = e.TotalRowCount;
            this.InterfaceBoardCount = e.InterfaceBoardCount;
            this.ActiveCpuCount = e.ActiveCpuCount;
            this.AccessPortalCount = e.AccessPortalCount;
            this.InputDeviceCount = e.InputDeviceCount;
            this.OutputDeviceCount = e.OutputDeviceCount;
            this.ElevatorOutputCount = e.ElevatorOutputCount;
            this.Online = e.Online;
            this.LastConnected = e.LastConnected;
        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public MercScp Clone(MercScp e)
        {
            return new MercScp(e);
        }

        public bool Equals(MercScp other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(MercScp other)
        {
            if (other == null)
                return false;

            if (other.MercScpUid != this.MercScpUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InterfaceBoardCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ActiveCpuCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessPortalCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputDeviceCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int OutputDeviceCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ElevatorOutputCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ScpMercGroupName { get; set; }


//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public MercScpStatus Status { get; set; }

    }
}
