using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyPanel
    {
        public GalaxyPanel()
        {
            Initialize();
        }

        public GalaxyPanel(GalaxyPanel e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.GalaxyPanelSites = new HashSet<GalaxyPanelSite>();
            this.Cpus = new HashSet<GalaxyCpu>();
            this.InterfaceBoards = new HashSet<GalaxyInterfaceBoard>();
            AlertEvents = new HashSet<GalaxyPanelAlertEvent>();
        }

        public void InitializeAlertEventsCollection(Guid neverScheduleUid, Guid alwaysScheduleUid, Guid ioGroupUid)
        {
            if (AlertEvents == null)
                AlertEvents = new HashSet<GalaxyPanelAlertEvent>();

            if (AlertEvents.FirstOrDefault(i => i.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.LowBattery) == null)
            {
                AlertEvents.Add(new GalaxyPanelAlertEvent()
                {
                    GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.LowBattery,
                    AcknowledgeTimeScheduleUid = alwaysScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.ACFailure) == null)
            {
                AlertEvents.Add(new GalaxyPanelAlertEvent()
                {
                    GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.ACFailure,
                    AcknowledgeTimeScheduleUid = alwaysScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.Tamper) == null)
            {
                AlertEvents.Add(new GalaxyPanelAlertEvent()
                {
                    GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.Tamper,
                    AcknowledgeTimeScheduleUid = alwaysScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }

            if (AlertEvents.FirstOrDefault(i => i.GalaxyPanelAlertEventTypeUid == GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.EmergencyUnlock) == null)
            {
                AlertEvents.Add(new GalaxyPanelAlertEvent()
                {
                    GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.EmergencyUnlock,
                    AcknowledgeTimeScheduleUid = alwaysScheduleUid,
                    InputOutputGroupUid = ioGroupUid
                });
            }
        }

        public void Initialize(GalaxyPanel e)
        {
            Initialize();
            if (e == null)
                return;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.ClusterUid = e.ClusterUid;
            this.PanelNumber = e.PanelNumber;
            this.PanelName = e.PanelName;
            this.Location = e.Location;
            this.IsDirty = e.IsDirty;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            this.GalaxyPanelSites = e.GalaxyPanelSites.ToCollection();
            this.Cpus = e.Cpus.ToCollection();
            this.InterfaceBoards = e.InterfaceBoards.ToCollection();

            if (e.AlertEvents != null)
                this.AlertEvents = e.AlertEvents.ToCollection();

            this.ClusterNumber = e.ClusterNumber;
        }

        public bool IsAnythingDirty
        {
            get
            {
                foreach (var o in Cpus)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }

                foreach (var o in InterfaceBoards)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }
                return IsDirty;
            }
        }

        public GalaxyPanel Clone(GalaxyPanel e)
        {
            return new GalaxyPanel(e);
        }

        public bool Equals(GalaxyPanel other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanel other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelUid != this.GalaxyPanelUid)
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
