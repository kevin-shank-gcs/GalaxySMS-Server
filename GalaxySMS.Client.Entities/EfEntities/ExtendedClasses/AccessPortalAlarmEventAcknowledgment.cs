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
    public partial class AccessPortalAlarmEventAcknowledgment
    {
        public AccessPortalAlarmEventAcknowledgment() : base()
        {
            Initialize();
        }

        public AccessPortalAlarmEventAcknowledgment(AccessPortalAlarmEventAcknowledgment e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(AccessPortalAlarmEventAcknowledgment e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AccessPortalAlarmEventAcknowledgmentUid = e.AccessPortalAlarmEventAcknowledgmentUid;
            this.AccessPortalActivityEventUid = e.AccessPortalActivityEventUid;
            this.UserId = e.UserId;
            this.Response = e.Response;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AccessPortalAlarmEventAcknowledgment Clone(AccessPortalAlarmEventAcknowledgment e)
        {
            return new AccessPortalAlarmEventAcknowledgment(e);
        }

        public bool Equals(AccessPortalAlarmEventAcknowledgment other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalAlarmEventAcknowledgment other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalAlarmEventAcknowledgmentUid != this.AccessPortalAlarmEventAcknowledgmentUid)
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
