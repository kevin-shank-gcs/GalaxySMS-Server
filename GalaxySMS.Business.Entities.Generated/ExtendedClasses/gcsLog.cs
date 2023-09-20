using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsLog
    {
        public gcsLog()
        {
            Initialize();
        }

        public gcsLog(gcsLog e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsLog e)
        {
            Initialize();
            if (e == null)
                return;
            this.LogId = e.LogId;
            this.ApplicationId = e.ApplicationId;
            this.ApplicationName = e.ApplicationName;
            this.EntityId = e.EntityId;
            this.EntityName = e.EntityName;
            this.UserId = e.UserId;
            this.UserName = e.UserName;
            this.LogType = e.LogType;
            this.ServerName = e.ServerName;
            this.ClientName = e.ClientName;
            this.ResourceName = e.ResourceName;
            this.ResourceKey = e.ResourceKey;
            this.LogInfo = e.LogInfo;
            this.SystemInfo = e.SystemInfo;
            this.ExtraInfo = e.ExtraInfo;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsLog Clone(gcsLog e)
        {
            return new gcsLog(e);
        }

        public bool Equals(gcsLog other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsLog other)
        {
            if (other == null)
                return false;

            if (other.LogId != this.LogId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
