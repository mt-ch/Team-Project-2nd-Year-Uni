using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ScheduleV5.ViewModels;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace ScheduleV5
{
    public partial class MonthViewPage : ContentPage
    {
        private int indexOfAppointment = 0;
        private bool isNewAppointment = false;

        public MonthViewPage()
        {
            InitializeComponent();

            //schedule.CellTapped += CellTappedEventHandler;

            //(Edit.BindingContext as EditViewModel).AppointmentModified += EditorLayout_AppointmentModified;
        }

        //private void EditorLayout_AppointmentModified(object sender, ScheduleAppointmentModifiedEventArgs e)
        //{
        //    schedule.IsVisible = true;

        //    if (e.IsModified)
        //    {
        //        if (isNewAppointment)
        //        {
        //            (schedule.DataSource as ObservableCollection<Appointments>).Add(e.Appointments);
        //        }
        //        else
        //        {
        //            (schedule.DataSource as ObservableCollection<Appointments>).RemoveAt(indexOfAppointment);
        //            (schedule.DataSource as ObservableCollection<Appointments>).Insert(indexOfAppointment, e.Appointments);
        //        }
        //    }
        //}

        //void CellTappedEventHandler(object sender, CellTappedEventArgs e)
        //{
        //    schedule.IsVisible = false;
        //    Edit.IsVisible = true;
        //    if (schedule.ScheduleView == ScheduleView.MonthView)
        //    {
        //        //create Apppointment
        //        Edit.OpenEditor(null, e.Datetime);
        //        isNewAppointment = true;
        //    }
        //    else
        //    {
        //        if (e.Appointment != null)
        //        {
        //            ObservableCollection<Appointments> appointment = new ObservableCollection<Appointments>();
        //            appointment = (ObservableCollection<Appointments>)schedule.DataSource;
        //            indexOfAppointment = appointment.IndexOf((Appointments)e.Appointment);
        //            Edit.OpenEditor((Appointments)e.Appointment, e.Datetime);
        //            isNewAppointment = false;
        //        }
        //        else
        //        {
        //            //create Apppointment
        //            Edit.OpenEditor(null, e.Datetime);
        //            isNewAppointment = true;
        //        }
        //    }
        //}
    }
}
