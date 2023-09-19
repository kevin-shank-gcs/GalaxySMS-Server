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
    public partial class GalaxyPanelActivityAlarmEvent
    {
        public GalaxyPanelActivityAlarmEvent() : base()
        {
            Initialize();
        }

        public GalaxyPanelActivityAlarmEvent(GalaxyPanelActivityAlarmEvent e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.GalaxyPanelAlarmEventAcknowledgments = new HashSet<GalaxyPanelAlarmEventAcknowledgment>();
        }

        public void Initialize(GalaxyPanelActivityAlarmEvent e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyPanelActivityEventUid = e.GalaxyPanelActivityEventUid;
            this.NoteUid = e.NoteUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.AlarmPriority = e.AlarmPriority;
            this.GalaxyPanelAlarmEventAcknowledgments = e.GalaxyPanelAlarmEventAcknowledgments.ToCollection();

        }

        public GalaxyPanelActivityAlarmEvent Clone(GalaxyPanelActivityAlarmEvent e)
        {
            return new GalaxyPanelActivityAlarmEvent(e);
        }

        public bool Equals(GalaxyPanelActivityAlarmEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelActivityAlarmEvent other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelActivityEventUid != this.GalaxyPanelActivityEventUid)
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
