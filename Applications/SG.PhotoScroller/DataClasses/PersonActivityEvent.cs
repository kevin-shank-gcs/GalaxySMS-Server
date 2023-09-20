using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GCS.SysGal.SDK.DataClasses;

namespace SG.PhotoScroller.DataClasses
{
    public class PersonActivityEvent
    {
        private byte[] _photoBytes;
        public PersonActivityEvent(ActivityLogData eventData)
        {
            EventData = eventData;
        }

        public ActivityLogData EventData { get; internal set; }

        public Brush BorderColor
        {
            get
            {
                switch (EventData.EventType)
                {
                    case ActivityLogData.EventTypeCode.VALID_ACCESS_X:
                        return new SolidColorBrush(Colors.Green);

                    case ActivityLogData.EventTypeCode.INVALID_ATTEMPT_X:
                    case ActivityLogData.EventTypeCode.PASSBACK_VIOLATION_X:
                    case ActivityLogData.EventTypeCode.BAD_PIN_X:
                        return new SolidColorBrush(Colors.Red);

                    case ActivityLogData.EventTypeCode.DURESS_X:
                        return new SolidColorBrush(Colors.Orange);

                    default:
                        return new SolidColorBrush(Colors.Black);
                }
            }
        }

        public bool OnHold { get; set; }

        public byte[] Photo
        {
            get { return _photoBytes; }
            set { _photoBytes = value; }
        }
    }
}
