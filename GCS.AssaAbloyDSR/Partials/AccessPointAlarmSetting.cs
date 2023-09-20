using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GCS.AssaAbloyDSR
{
    public class AccessPointAlarmSetting : ObjectBase
    {
        [Flags]
        public enum SecurityModeValue : int
        {
            Off = 0,
            On = 1
        }

        [Flags]
        public enum PassageModeValue : int
        {
            Off = 0,
            On = 2
        }

        [Flags]
        public enum RxHeldModeValue : int
        {
            Off = 0,
            On = 4
        }

        public enum AlarmType : int
        {
            Valid=1,
            Denied=2,
            DoorSecured=3,
            DoorForced=4,
            KeyOverride=5,
            InvalidEntry=6,
            DoorAjar=7,
            LowBattery=8,
            RXHeld=9,
            RTCFailure=10,
            TamperAlarm=11,
            TamperRestore=12
        }

        private string _alarmName;

        public string AlarmName
        {
            get { return _alarmName; }
            set
            {
                if (_alarmName != value)
                {
                    _alarmName = value;
                    OnPropertyChanged(() => AlarmName, false);
                }
            }
        }

        private AlarmType _type;

        public AlarmType Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(() => Type, false);
                }
            }
        }

        private SecurityModeValue _securityMode;

        public SecurityModeValue SecurityMode
        {
            get { return _securityMode; }
            set
            {
                if (_securityMode != value)
                {
                    _securityMode = value;
                    OnPropertyChanged(() => SecurityMode, true);
                }
            }
        }

        private PassageModeValue _passageMode;

        public PassageModeValue PassageMode
        {
            get { return _passageMode; }
            set
            {
                if (_passageMode != value)
                {
                    _passageMode = value;
                    OnPropertyChanged(() => PassageMode, true);
                }
            }
        }

        private RxHeldModeValue m_rxHeldMode;

        public RxHeldModeValue RxHeldMode
        {
            get { return m_rxHeldMode; }
            set
            {
                if (m_rxHeldMode != value)
                {
                    m_rxHeldMode = value;
                    OnPropertyChanged(() => RxHeldMode, true);
                }
            }
        }

        public int AlarmTypeValue
        { get { return (int) AlarmTypeValue; } }

        public int ModeValue
        {
            get { return (int) RxHeldMode | (int) PassageMode | (int) SecurityMode; }
            set
            {
                if ((value & (int) RxHeldMode) != 0)
                    RxHeldMode = RxHeldModeValue.On;
                else
                    RxHeldMode = RxHeldModeValue.Off;

                if ((value & (int) PassageMode) != 0)
                    PassageMode = PassageModeValue.On;
                else
                    PassageMode = PassageModeValue.Off;

                if ((value & (int) SecurityMode) != 0)
                    SecurityMode = SecurityModeValue.On;
                else
                    SecurityMode = SecurityModeValue.Off;
            }
        }


    }

}
