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
    public partial class GalaxyPanelActivityEvent
    {
        public GalaxyPanelActivityEvent() : base()
        {
            Initialize();
        }

        public GalaxyPanelActivityEvent(GalaxyPanelActivityEvent e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(GalaxyPanelActivityEvent e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyPanelActivityEventUid = e.GalaxyPanelActivityEventUid;
            this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.CredentialUid = e.CredentialUid;
            this.PersonUid = e.PersonUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
            this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
            this.ActivityDateTime = e.ActivityDateTime;
            this.CpuUid = e.CpuUid;
            this.CpuNumber = e.CpuNumber;
            this.BufferIndex = e.BufferIndex;
            this.InputOutputGroupNumber = e.InputOutputGroupNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.NodeNumber = e.NodeNumber;
            this.InsertDate = e.InsertDate;
            this.EventType = e.EventType;

        }

        public GalaxyPanelActivityEvent Clone(GalaxyPanelActivityEvent e)
        {
            return new GalaxyPanelActivityEvent(e);
        }

        public bool Equals(GalaxyPanelActivityEvent other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelActivityEvent other)
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
