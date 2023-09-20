using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    public partial class MercScp
    {
        public MercScp() : base()
        {
            Initialize();
        }

        public MercScp(MercScp e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(MercScp e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.MercScpUid = e.MercScpUid;
            this.MercScpTypeUid = e.MercScpTypeUid;
            this.MercScpGroupUid = e.MercScpGroupUid;
            this.SpcName = e.SpcName;
            this.Location = e.Location;
            this.Description = e.Description;
            this.MacAddress = e.MacAddress;
            this.SerialNumber = e.SerialNumber;
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
            this.Online = e.Online;
            this.LastConnected = e.LastConnected;
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
    }
}
