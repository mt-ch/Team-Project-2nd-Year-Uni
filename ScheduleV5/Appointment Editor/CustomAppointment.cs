using System;
using System.ComponentModel;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace ScheduleV5
{
    public class CustomAppointment : ScheduleAppointment, INotifyPropertyChanged
    {
        public CustomAppointment()
        {
        }

        private string appointment_ID;
        public string appointment_id
        {
            get { return appointment_ID; }
            set { appointment_ID = value; OnPropertyChanged("String_ID"); }
        }


        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged(string propertyName)
        //{
        //    var eventHandler = this.PropertyChanged;
        //    if (eventHandler != null)
        //        eventHandler(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
