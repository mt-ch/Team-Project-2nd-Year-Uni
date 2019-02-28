using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ScheduleV5
{
    public class ViewModel
    {
        public ObservableCollection<Appointments> Appointments { get; set; }
        List<string> eventNameCollection;
        List<Color> colorCollection;

        private AppointmentInfo appointmentInfo;
        public AppointmentInfo AppointmentInfo
        {
            get { return this.appointmentInfo; }
            set { this.appointmentInfo = value; }
        }

        public ViewModel()
        {
            this.appointmentInfo = new AppointmentInfo();
            Appointments = new ObservableCollection<Appointments>();
            CreateEventNameCollection();
            CreateColorCollection();
            CreateAppointments();

        }

        private void CreateAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = GettingTimeRanges();
            DateTime date;
            DateTime DateFrom = DateTime.Now.AddDays(-10);
            DateTime DateTo = DateTime.Now.AddDays(10);
            DateTime dataRangeStart = DateTime.Now.AddDays(-3);
            DateTime dataRangeEnd = DateTime.Now.AddDays(3);

            for (date = DateFrom; date < DateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dataRangeStart) > 0) && (DateTime.Compare(date, dataRangeEnd) < 0))
                {
                    for (int AdditionalAppointmentIndex = 0; AdditionalAppointmentIndex < 3; AdditionalAppointmentIndex++)
                    {
                        Appointments appointments = new Appointments();
                        int hour = (randomTime.Next((int)randomTimeCollection[AdditionalAppointmentIndex].X, (int)randomTimeCollection[AdditionalAppointmentIndex].Y));
                        appointments.From = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                        appointments.To = (appointments.From.AddHours(1));
                        appointments.EventName = eventNameCollection[randomTime.Next(9)];
                        appointments.color = colorCollection[randomTime.Next(9)];
                        if (AdditionalAppointmentIndex % 3 == 0)
                            appointments.AllDay = true;
                        Appointments.Add(appointments);
                    }
                }
                else
                {
                    Appointments appointments = new Appointments();
                    appointments.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    appointments.To = (appointments.From.AddHours(1));
                    appointments.EventName = eventNameCollection[randomTime.Next(9)];
                    appointments.color = colorCollection[randomTime.Next(9)];
                    Appointments.Add(appointments);
                }
            }
        }

        /// Creates event names collection
        private void CreateEventNameCollection()
        {
            eventNameCollection = new List<string>();
            eventNameCollection.Add("General Meeting");
            eventNameCollection.Add("Plan Execution");
            eventNameCollection.Add("Project Plan");
            eventNameCollection.Add("Consulting");
            eventNameCollection.Add("Performance Check");
            eventNameCollection.Add("Yoga Therapy");
            eventNameCollection.Add("Plan Execution");
            eventNameCollection.Add("Project Plan");
            eventNameCollection.Add("Consulting");
            eventNameCollection.Add("Performance Check");
        }

        /// Creates color collection.  
        private void CreateColorCollection()
        {
            colorCollection = new List<Color>();
            colorCollection.Add(Color.FromHex("#FF339933"));
            colorCollection.Add(Color.FromHex("#FF00ABA9"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFA2C139"));
            colorCollection.Add(Color.FromHex("#FFD80073"));
            colorCollection.Add(Color.FromHex("#FF339933"));
            colorCollection.Add(Color.FromHex("#FFE671B8"));
            colorCollection.Add(Color.FromHex("#FF00ABA9"));
        }

        /// Gets the time ranges.
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));
            return randomTimeCollection;
        }
    }
}
