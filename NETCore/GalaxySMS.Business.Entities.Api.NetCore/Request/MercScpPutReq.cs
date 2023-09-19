using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class MercScpPutReq : PutRequestBase
    {
        [Required]
        [RequiredGuidNotEmpty(nameof(MercScpUid))]
        public System.Guid MercScpUid { get; set; }

    	public System.Guid MercScpTypeUid { get; set; }

        [Required]
        [EnumDataType(typeof(GalaxySMS.Common.Enums.MercuryPanelType))]
        public MercuryPanelType MercScpType { get; set; } = MercuryPanelType.LP1501;

        public System.Guid MercScpGroupUid { get; set; }

        [Required]
        [StringLength(65)]
    	public string ScpName { get; set; }
    	public string Location { get; set; }
    	public string Description { get; set; }

    	public string MacAddress { get; set; }

    	public ulong SerialNumber { get; set; }

        public int ConnectionType { get; set; }

        [EnumDataType(typeof(GalaxySMS.Common.Enums.MercScpConnectionType))]
        public MercScpConnectionType ScpConnectionType { get; set; } = MercScpConnectionType.IPClient;

        public string IpAddress { get; set; }

        [Range(0, 65535)]
        public int IpPort { get; set; }

        public string AesPassword { get; set; }

        public int ScpReplyTimeout { get; set; }

        [Range(2000, 60000)] public int TcpConnectRetryInterval { get; set; } = 30000;

        public int RetryCountBeforeOffline { get; set; }

        [Range(2000, 65000)] public int OfflineTime { get; set; } = 32000;

        [Range(500, 5000)] public int PollDelay { get; set; } = 1000;

        public string TimeZoneId { get; set; }

        public bool UseDaylightSavingsTime { get; set; }

        [Range(10000, int.MaxValue)] public int TransactionCount { get; set; } = 100000;

        [Range(10000, int.MaxValue)] public int TransactionUnreportedLimit { get; set; } = 10000;

        public bool DualPortEnabled { get; set; }

        public int ConnectionTypeAlt { get; set; }

        [EnumDataType(typeof(GalaxySMS.Common.Enums.MercScpConnectionType))]
        public MercScpConnectionType ScpConnectionTypeAlt { get; set; } = MercScpConnectionType.None;

        public int RetryCountBeforeOfflineAlt { get; set; }

        [Range(500, 5000)] public int PollDelayAlt { get; set; } = 5000;

        public string IpAddressAlt { get; set; }

        [Range(0, 65535)]
        public int IpPortAlt { get; set; }

        public bool AllowConnection { get; set; }
        public Nullable<short> ConcurrencyValue { get; set; }
        
    }
}
