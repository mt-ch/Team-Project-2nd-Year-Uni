using System;
using Xamarin.Forms;

namespace ScheduleV5.ViewModels
{
    public class EditViewModel : ContentPage
    {
        public virtual void OnAppointmentModified(ScheduleAppointmentModifiedEventArgs e)
        {
            EventHandler<ScheduleAppointmentModifiedEventArgs> handler = AppointmentModified;
            if (handler != null)
            {
                handler(this, e);
            }

        }

        public event EventHandler<ScheduleAppointmentModifiedEventArgs> AppointmentModified;

    }

    public class ScheduleAppointmentModifiedEventArgs : EventArgs
    {
        public Appointments Appointments { get; set; }
        public bool IsModified { get; set; }
    }
}
