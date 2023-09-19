using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaxySMS.Client.Entities;
using Telerik.Windows.Controls.ScheduleView;

namespace GalaxySMS.Schedule
{
    public class DateTypeAppointmentsCollection : ObservableCollection<DateTypeAppointment>
    {
    }

    public class DateTypeAppointment: Appointment
    {
        private DayTypeListItem _dayType;

        public DayTypeListItem DayType
        {
            get
            {
                return this.Storage<DateTypeAppointment>()._dayType;
            }
            set
            {
                DateTypeAppointment storage = this.Storage<DateTypeAppointment>();
                if (_dayType != value)
                {
                    storage._dayType = value;
                    this.OnPropertyChanged(() => this.DayType);
                    if (DayType != null)
                        Subject = DayType.Name;
                    else
                        Subject = string.Empty;
                }
            }
        }

        public override IAppointment Copy()
        {
            IAppointment appointment = new DateTypeAppointment();
            appointment.CopyFrom(this);
            return appointment;
        }

        public override void CopyFrom(IAppointment other)
        {
            DateTypeAppointment appointment = other as DateTypeAppointment;
            if (appointment != null)
            {
                this.DayType = appointment.DayType;
            }
            base.CopyFrom(other);
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Start" || propertyName == "End")
            {
                this.OnPropertyChanged("Duration");
            }

            if (propertyName == "DayType" )
            {
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private string ValidateAppointment()
        {
            string errorString = this.ValidateSubject();
            errorString += this.ValidateDayType();

            return errorString;
        }

        private string ValidateSubject()
        {
            if (string.IsNullOrEmpty(this.Subject))
            {
                return "The subject cannot be empty!";
            }
            return null;
        }

        private string ValidateDayType()
        {
            return null;
        }
    }
}
