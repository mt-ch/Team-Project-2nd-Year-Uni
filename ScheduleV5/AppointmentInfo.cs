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

        public AppointmentInfo()
        {
        }

        [Display(Prompt = "Enter Name...")]
        public string AppointmentName
        {
            get { return this.appointmentName; }
            set
            {
                this.appointmentName = value;
            }
        }

        public DateTime? StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
            }


        }

        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
            }
        }

   



    }
}
