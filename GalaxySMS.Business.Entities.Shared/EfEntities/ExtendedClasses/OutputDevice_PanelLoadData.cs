using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

    public partial class OutputDevice_PanelLoadData
    {
        public OutputDevice_PanelLoadData()
        {
            Initialize();
        }

        public OutputDevice_PanelLoadData(OutputDevice_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.InputSources = new HashSet<GalaxyOutputDevice_InputSource_Main_PanelLoadData>();
        }

        public void Initialize(OutputDevice_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.OutputDeviceUid = e.OutputDeviceUid;
            this.ClusterUid = e.ClusterUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
            this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
            this.OutputName = e.OutputName;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.NodeNumber = e.NodeNumber;
            this.IsModuleActive = e.IsModuleActive;
            this.IsNodeActive = e.IsNodeActive;
            this.IsOutputActive = e.IsOutputActive;

            this.OutputDeviceBoardSectionMode = e.OutputDeviceBoardSectionMode;
            this.OutputDeviceBoardSectionModeDisplay = e.OutputDeviceBoardSectionModeDisplay;
            this.OutputDevicePanelModelTypeCode = e.OutputDevicePanelModelTypeCode;
            this.OutputDeviceCpuTypeCode = e.OutputDeviceCpuTypeCode;
            this.OutputDeviceBoardTypeModel = e.OutputDeviceBoardTypeModel;
            this.OutputDeviceBoardTypeTypeCode = e.OutputDeviceBoardTypeTypeCode;
            this.OutputDeviceBoardTypeDisplay = e.OutputDeviceBoardTypeDisplay;

            this.GalaxyOutputModeDisplay = e.GalaxyOutputModeDisplay;
            this.GalaxyOutputModeCode = e.GalaxyOutputModeCode;
            this.InputSourceRelationshipDisplay = e.InputSourceRelationshipDisplay;
            this.InputSourceRelationshipCode = e.InputSourceRelationshipCode;
            this.TimeoutDuration = e.TimeoutDuration;
            this.Limit = e.Limit;
            this.InvertOutput = e.InvertOutput;
            this.ScheduleDisplay = e.ScheduleDisplay;
            this.ScheduleNumber = e.ScheduleNumber;
            this.GalaxyOutputDevicePropertiesLastUpdated = e.GalaxyOutputDevicePropertiesLastUpdated;
            if(e.InputSources != null)
                this.InputSources = e.InputSources.ToCollection();


        }

        public OutputDevice_PanelLoadData Clone(OutputDevice_PanelLoadData e)
        {
            return new OutputDevice_PanelLoadData(e);
        }

        public bool Equals(OutputDevice_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(OutputDevice_PanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.OutputDeviceUid != this.OutputDeviceUid)
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
