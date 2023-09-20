using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
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
            //this.GalaxyPanelSites = new HashSet<GalaxyPanelSite>();
            this.Cpus = new HashSet<GalaxyCpu>();
            this.InterfaceBoards = new HashSet<GalaxyInterfaceBoard>();
            AlertEvents = new HashSet<GalaxyPanelAlertEvent>();
            //this.GalaxyPanelCommands = new HashSet<GalaxyPanelCommand>();
            this.DisabledCommandIds = new HashSet<Guid>();
            this.ConcurrencyValue = 0;
        }

        public void InitializeAlertEventsCollection(Guid neverScheduleUid, Guid alwaysScheduleUid, Guid ioGroupUid)
        {
            if (AlertEvents == null)
                AlertEvents = new HashSet<GalaxyPanelAlertEvent>();
            else
                AlertEvents = AlertEvents.ToCollection();

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
            //this.GalaxyPanelSites = e.GalaxyPanelSites.ToCollection();
            this.Cpus = e.Cpus.ToCollection();
            this.InterfaceBoards = e.InterfaceBoards.ToCollection();

            if (e.AlertEvents != null)
                this.AlertEvents = e.AlertEvents.ToCollection();

            //if (e.GalaxyPanelCommands != null)
            //    this.GalaxyPanelCommands = e.GalaxyPanelCommands;
            
            if (e.DisabledCommandIds != null)
                this.DisabledCommandIds = e.DisabledCommandIds;
            this.EntityId = e.EntityId;

            this.ClusterNumber = e.ClusterNumber;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterName = e.ClusterName;
            this.TotalRowCount = e.TotalRowCount;
            this.InterfaceBoardCount = e.InterfaceBoardCount;
            this.ActiveCpuCount = e.ActiveCpuCount;
            this.AccessPortalCount = e.AccessPortalCount;
            this.InputDeviceCount = e.InputDeviceCount;
            this.OutputDeviceCount = e.OutputDeviceCount;
            this.ElevatorOutputCount = e.ElevatorOutputCount;
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InterfaceBoardCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ActiveCpuCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessPortalCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputDeviceCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int OutputDeviceCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ElevatorOutputCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ClusterName { get; set; }
    }
}
