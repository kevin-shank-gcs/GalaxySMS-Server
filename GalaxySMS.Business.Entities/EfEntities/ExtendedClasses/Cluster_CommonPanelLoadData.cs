using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Cluster_CommonPanelLoadData
    {
        public Cluster_CommonPanelLoadData()
        {
            Initialize();
        }

        public Cluster_CommonPanelLoadData(Cluster_CommonPanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(Cluster_CommonPanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.ClusterUid = e.ClusterUid;
            this.ClusterNumber = e.ClusterNumber;
            this.ClusterName = e.ClusterName;
            this.InsertDate = e.InsertDate;
            this.UpdateDate = e.UpdateDate;
            this.ClusterGroupId = e.ClusterGroupId;
            this.IsActive = e.IsActive;
            this.AbaStartDigit = e.AbaStartDigit;
            this.AbaStopDigit = e.AbaStopDigit;
            this.AbaFoldOption = e.AbaFoldOption;
            this.AbaClipOption = e.AbaClipOption;
            this.WiegandStartBit = e.WiegandStartBit;
            this.WiegandStopBit = e.WiegandStopBit;
            this.CardaxStartBit = e.CardaxStartBit;
            this.CardaxStopBit = e.CardaxStopBit;
            this.LockoutAfterInvalidAttempts = e.LockoutAfterInvalidAttempts;
            this.LockoutDurationSeconds = e.LockoutDurationSeconds;
            this.AccessRuleOverrideTimeout = e.AccessRuleOverrideTimeout;
            this.UnlimitedCredentialTimeout = e.UnlimitedCredentialTimeout;
            this.TimeZoneId = e.TimeZoneId;
            this.ActivateCrisisIOGroupNumber = e.ActivateCrisisIOGroupNumber;
            this.ResetCrisisIOGroupNumber = e.ResetCrisisIOGroupNumber;
            this.LockedLED = e.LockedLED;
            this.UnlockedLED = e.UnlockedLED;
            this.ClusterTypeCode = e.ClusterTypeCode;
            this.CredentialDataLength = e.CredentialDataLength;
            this.TimeScheduleTypeCode = e.TimeScheduleTypeCode;
            this.RETURNVALUE = e.RETURNVALUE;
        }

        public Cluster_CommonPanelLoadData Clone(Cluster_CommonPanelLoadData e)
        {
            return new Cluster_CommonPanelLoadData(e);
        }

        public bool Equals(Cluster_CommonPanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Cluster_CommonPanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.ClusterUid != this.ClusterUid)
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