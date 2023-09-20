using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyInputDevice
    {
        public GalaxyInputDevice()
        {
            Initialize();
        }

        public GalaxyInputDevice(GalaxyInputDevice e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AlertEvents = new HashSet<InputDeviceAlertEvent>();
            GalaxyHardwareAddress = new InputDeviceGalaxyHardwareAddress();
            this.ArmingInputOutputGroups = new HashSet<GalaxyInputArmingInputOutputGroup>();
            this.TimeSchedule = new GalaxyInputDeviceTimeSchedule();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyInputDevice e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceUid = e.InputDeviceUid;
            this.InputDeviceSupervisionTypeUid = e.InputDeviceSupervisionTypeUid;
            this.GalaxyInputModeUid = e.GalaxyInputModeUid;
            this.DelayDuration = e.DelayDuration;
            this.GalaxyInputDelayTypeUid = e.GalaxyInputDelayTypeUid;
            this.DisableDisarmedOnOffLogEvents = e.DisableDisarmedOnOffLogEvents;
            this.IsNormalOpen = e.IsNormalOpen;
            this.TroubleShortThreshold = e.TroubleShortThreshold;
            this.NormalChangeThreshold = e.NormalChangeThreshold;
            this.TroubleOpenThreshold = e.TroubleOpenThreshold;
            this.AlternateVoltagesEnabled = e.AlternateVoltagesEnabled;
            this.AlternateTroubleShortThreshold = e.AlternateTroubleShortThreshold;
            this.AlternateNormalChangeThreshold = e.AlternateNormalChangeThreshold;
            this.AlternateTroubleOpenThreshold = e.AlternateTroubleOpenThreshold;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.TimeSchedule = e.TimeSchedule;
            this.GalaxyHardwareAddress = e.GalaxyHardwareAddress;
            if (this.AlertEvents != null)
                this.AlertEvents = e.AlertEvents.ToCollection();
            if (this.ArmingInputOutputGroups != null)
                this.ArmingInputOutputGroups = e.ArmingInputOutputGroups.ToCollection();
            //this.HardwareInformation = e.HardwareInformation;
        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public GalaxyInputDevice Clone(GalaxyInputDevice e)
        {
            return new GalaxyInputDevice(e);
        }

        public bool Equals(GalaxyInputDevice other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInputDevice other)
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

//#if NetCoreApi
//#else
//        [DataMember]
//#endif

//        public InputDevice_GetHardwareInformation HardwareInformation {get;set;}
    }
}