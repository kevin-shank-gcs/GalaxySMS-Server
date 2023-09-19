using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public partial class MercScpResp
    {
        public System.Guid MercScpUid { get; set; }

        public System.Guid MercScpTypeUid { get; set; }
        public System.Guid MercScpGroupUid { get; set; }
        public string ScpName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string MacAddress { get; set; }
        public string SerialNumber { get; set; }
        public int ConnectionType { get; set; }
        public string IpAddress { get; set; }
        public Nullable<int> IpPort { get; set; }
        public string AesPassword { get; set; }
        public int ScpReplyTimeout { get; set; }
        public int TcpConnectRetryInterval { get; set; }
        public int RetryCountBeforeOffline { get; set; }
        public int OfflineTime { get; set; }
        public int PollDelay { get; set; }
        public string TimeZoneId { get; set; }
        public bool UseDaylightSavingsTime { get; set; }
        public int TransactionCount { get; set; }
        public int TransactionUnreportedLimit { get; set; }
        public bool DualPortEnabled { get; set; }
        public int ConnectionTypeAlt { get; set; }
        public int RetryCountBeforeOfflineAlt { get; set; }
        public int PollDelayAlt { get; set; }
        public string IpAddressAlt { get; set; }
        public int IpPortAlt { get; set; }
        public bool AllowConnection { get; set; }
        public string InsertName { get; set; }
        public System.DateTimeOffset InsertDate { get; set; }
        public string UpdateName { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<short> ConcurrencyValue { get; set; }
        public MercScpGroup MercScpGroup { get; set; }

    }
}
