using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScheduleV5
{
    public class AppointmentInfo
    {
        private string appointmentName;
        private DateTime? startDate;
        private DateTime? endDate;
        private DateTime? startTime;
        private DateTime? endTime;


        public AppointmentInfo()
        {

        }

        [Display(Name = "Event Name:")]
        public string AppointmentName
        {
            get { return this.appointmentName; }
            set
            {
                this.appointmentName = value;
            }
        }

        [Display(Name = "Start Date:")]
        public DateTime? StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
            }
        }

        [DataType(DataType.Time)]
        [Display(Name = "Start Time:")]
        public DateTime? StartTime
        {
            get { return startTime; }
            set
            {
                startTime = value;
            }
        }

        [Display(Name = "End Date:")]
        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
            }
        }

        [DataType(DataType.Time)]
        [Display(Name = "End Time:")]
        public DateTime? EndTime
        {
            get { return endTime; }
            set
            {
                endTime = value;
            }
        }

    }
}
