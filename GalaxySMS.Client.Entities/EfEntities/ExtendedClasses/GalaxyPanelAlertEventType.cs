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
    public partial class GalaxyPanelAlertEventType
    {
        public GalaxyPanelAlertEventType() : base()
        {
            Initialize();
        }

        public GalaxyPanelAlertEventType(GalaxyPanelAlertEventType e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            //this.GalaxyPanelAlertEvents = new HashSet<GalaxyPanelAlertEvent>();
        }

        public void Initialize(GalaxyPanelAlertEventType e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyPanelAlertEventTypeUid = e.GalaxyPanelAlertEventTypeUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Display = e.Display;
            this.Description = e.Description;
            this.Tag = e.Tag;
            this.CanAcknowledge = e.CanAcknowledge;
            this.CanHaveInputOutputGroupOffset = e.CanHaveInputOutputGroupOffset;
            this.CanHaveSchedule = e.CanHaveSchedule;
            this.CanHaveAudio = e.CanHaveAudio;
            this.CanHaveInstructions = e.CanHaveInstructions;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.GalaxyPanelAlertEvents = e.GalaxyPanelAlertEvents.ToCollection();

        }

        public GalaxyPanelAlertEventType Clone(GalaxyPanelAlertEventType e)
        {
            return new GalaxyPanelAlertEventType(e);
        }

        public bool Equals(GalaxyPanelAlertEventType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelAlertEventType other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelAlertEventTypeUid != this.GalaxyPanelAlertEventTypeUid)
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
