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

    public partial class InputDevice_PanelLoadData
    {
        public InputDevice_PanelLoadData()
        {
            Initialize();
        }

        public InputDevice_PanelLoadData(InputDevice_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(InputDevice_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;

            this.InputDeviceUid = e.InputDeviceUid;
            this.ClusterUid = e.ClusterUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
            this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
            this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
            this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
            this.InputName = e.InputName;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.NodeNumber = e.NodeNumber;
            this.IsModuleActive = e.IsModuleActive;
            this.IsNodeActive = e.IsNodeActive;
            this.IsInputActive = e.IsInputActive;
            this.InputDeviceBoardSectionMode = e.InputDeviceBoardSectionMode;
            this.InputDeviceBoardSectionModeDisplay = e.InputDeviceBoardSectionModeDisplay;
            this.InputDevicePanelModelTypeCode = e.InputDevicePanelModelTypeCode;
            this.InputDeviceCpuTypeCode = e.InputDeviceCpuTypeCode;
            this.InputDeviceBoardTypeModel = e.InputDeviceBoardTypeModel;
            this.InputDeviceBoardTypeTypeCode = e.InputDeviceBoardTypeTypeCode;
            this.InputDeviceBoardTypeDisplay = e.InputDeviceBoardTypeDisplay;
            this.SupervisionTypeDisplay = e.SupervisionTypeDisplay;
            this.HasSeriesResistor = e.HasSeriesResistor;
            this.HasParallelResistor = e.HasParallelResistor;
            this.IsNormalOpen = e.IsNormalOpen;
            this.TroubleShortThreshold = e.TroubleShortThreshold;
            this.TroubleOpenThreshold = e.TroubleOpenThreshold;
            this.NormalChangeThreshold = e.NormalChangeThreshold;
            this.AlternateNormalChangeThreshold = e.AlternateNormalChangeThreshold;
            this.AlternateTroubleOpenThreshold = e.AlternateTroubleOpenThreshold;
            this.AlternateTroubleShortThreshold = e.AlternateTroubleShortThreshold;
            this.AlternateVoltagesEnabled = e.AlternateVoltagesEnabled;
            this.GalaxyInputModeDisplay = e.GalaxyInputModeDisplay;
            this.GalaxyInputModeCode = e.GalaxyInputModeCode;
            this.GalaxyInputDelayTypeDisplay = e.GalaxyInputDelayTypeDisplay;
            this.GalaxyInputDelayTypeCode = e.GalaxyInputDelayTypeCode;
            this.MainIOGroupTag = e.MainIOGroupTag;
            this.MainIOGroupDisplay = e.MainIOGroupDisplay;
            this.MainIOGroupNumber = e.MainIOGroupNumber;
            this.MainIOGroupIsLocal = e.MainIOGroupIsLocal;
            this.MainIOGroupOffset = e.MainIOGroupOffset;
            this.MainIOGroupIsActive = e.MainIOGroupIsActive;
            this.DelayDuration = e.DelayDuration;
            this.DisableDisarmedOnOffLogEvents = e.DisableDisarmedOnOffLogEvents;
            this.GalaxyInputDevicePropertiesLastUpdated = e.GalaxyInputDevicePropertiesLastUpdated;
            this.MainIOGroupLastUpdated = e.MainIOGroupLastUpdated;
            this.ArmingIOGroup1LastUpdated = e.ArmingIOGroup1LastUpdated;
            this.ArmingIOGroup2LastUpdated = e.ArmingIOGroup2LastUpdated;
            this.ArmingIOGroup3LastUpdated = e.ArmingIOGroup3LastUpdated;
            this.ArmingIOGroup4LastUpdated = e.ArmingIOGroup4LastUpdated;
            this.MainScheduleLastUpdated = e.MainScheduleLastUpdated;
            this.ArmControlScheduleDisplay = e.ArmControlScheduleDisplay;
            this.ArmControlScheduleNumber = e.ArmControlScheduleNumber;
            this.ArmingIOGroup1Display = e.ArmingIOGroup1Display;
            this.ArmingIOGroupNumber1 = e.ArmingIOGroupNumber1;
            this.ArmingIOGroup1IsLocal = e.ArmingIOGroup1IsLocal;
            this.ArmingIOGroup2Display = e.ArmingIOGroup2Display;
            this.ArmingIOGroupNumber2 = e.ArmingIOGroupNumber2;
            this.ArmingIOGroup2IsLocal = e.ArmingIOGroup2IsLocal;
            this.ArmingIOGroup3Display = e.ArmingIOGroup3Display;
            this.ArmingIOGroupNumber3 = e.ArmingIOGroupNumber3;
            this.ArmingIOGroup3IsLocal = e.ArmingIOGroup3IsLocal;
            this.ArmingIOGroup4Display = e.ArmingIOGroup4Display;
            this.ArmingIOGroupNumber4 = e.ArmingIOGroupNumber4;
            this.ArmingIOGroup4IsLocal = e.ArmingIOGroup4IsLocal;
            this.CpuNumber = e.CpuNumber;
            this.CpuUid = e.CpuUid;
        }

        public InputDevice_PanelLoadData Clone(InputDevice_PanelLoadData e)
        {
            return new InputDevice_PanelLoadData(e);
        }

        public bool Equals(InputDevice_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDevice_PanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceUid != this.InputDeviceUid)
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
