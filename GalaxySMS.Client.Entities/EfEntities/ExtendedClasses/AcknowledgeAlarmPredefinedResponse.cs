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
    public partial class AcknowledgeAlarmPredefinedResponse
    {
        public AcknowledgeAlarmPredefinedResponse() : base()
        {
            Initialize();
        }

        public AcknowledgeAlarmPredefinedResponse(AcknowledgeAlarmPredefinedResponse e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(AcknowledgeAlarmPredefinedResponse e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.AcknowledgeAlarmPredefinedResponseUid = e.AcknowledgeAlarmPredefinedResponseUid;
            this.EntityId = e.EntityId;
            this.Response = e.Response;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AcknowledgeAlarmPredefinedResponse Clone(AcknowledgeAlarmPredefinedResponse e)
        {
            return new AcknowledgeAlarmPredefinedResponse(e);
        }

        public bool Equals(AcknowledgeAlarmPredefinedResponse other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AcknowledgeAlarmPredefinedResponse other)
        {
            if (other == null)
                return false;

            if (other.AcknowledgeAlarmPredefinedResponseUid != this.AcknowledgeAlarmPredefinedResponseUid)
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
