using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GCS.AssaAbloyDSR
{
    public class AccessPointAlarmSettings: ObjectBase
    {
        public AccessPointAlarmSettings()
        {
            AlarmSettings = new List<AccessPointAlarmSetting>();
           
        }

        private string _accessPointId;

        public string AccessPointId
        {
            get { return _accessPointId; }
            set
            {
                if (_accessPointId != value)
                {
                    _accessPointId = value;
                    OnPropertyChanged(() => AccessPointId, false);
                }
            }
        }

        private IList<AccessPointAlarmSetting> _alarmSettings;

        public IList<AccessPointAlarmSetting> AlarmSettings
        {
            get { return _alarmSettings; }
            set
            {
                if (_alarmSettings != value)
                {
                    _alarmSettings = value;
                    OnPropertyChanged(() => AlarmSettings, false);
                }
            }
        }


    }
}
