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
    public partial class GalaxyPanelAlarmEventAcknowledgment
    {
        public GalaxyPanelAlarmEventAcknowledgment() : base()
        {
            Initialize();
        }

        public GalaxyPanelAlarmEventAcknowledgment(GalaxyPanelAlarmEventAcknowledgment e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(GalaxyPanelAlarmEventAcknowledgment e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyPanelAlarmEventAcknowledgmentUid = e.GalaxyPanelAlarmEventAcknowledgmentUid;
            this.GalaxyPanelActivityEventUid = e.GalaxyPanelActivityEventUid;
            this.UserId = e.UserId;
            this.Response = e.Response;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyPanelAlarmEventAcknowledgment Clone(GalaxyPanelAlarmEventAcknowledgment e)
        {
            return new GalaxyPanelAlarmEventAcknowledgment(e);
        }

        public bool Equals(GalaxyPanelAlarmEventAcknowledgment other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelAlarmEventAcknowledgment other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelAlarmEventAcknowledgmentUid != this.GalaxyPanelAlarmEventAcknowledgmentUid)
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
