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
    public partial class ActivityEventAcknowledgement
    {
        public ActivityEventAcknowledgement() : base()
        {
            Initialize();
        }

        public ActivityEventAcknowledgement(ActivityEventAcknowledgement e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(ActivityEventAcknowledgement e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.ActivityEventAcknowledgementUid = e.ActivityEventAcknowledgementUid;
            this.ActivityEventUid = e.ActivityEventUid;
            this.DeviceEntityId = e.DeviceEntityId;
            this.DeviceUid = e.DeviceUid;
            this.ActivityEventCategory = e.ActivityEventCategory;
            this.Response = e.Response;
            this.AckedByUserId = e.AckedByUserId;
            this.AckedByUserDisplayName = e.AckedByUserDisplayName;
            this.AckedDateTime = e.AckedDateTime;
            this.AckedUpdatedDateTime = e.AckedUpdatedDateTime;

        }

        public ActivityEventAcknowledgement Clone(ActivityEventAcknowledgement e)
        {
            return new ActivityEventAcknowledgement(e);
        }

        public bool Equals(ActivityEventAcknowledgement other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(ActivityEventAcknowledgement other)
        {
            if (other == null)
                return false;

            if (other.ActivityEventAcknowledgementUid != this.ActivityEventAcknowledgementUid)
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
