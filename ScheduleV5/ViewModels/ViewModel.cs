using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;


namespace ScheduleV5
{
    public class ViewModel : INotifyPropertyChanged
    {
        //declaring collections
        public ObservableCollection<Appointments> Appointments { get; set; }// appointment collection
        List<string> eventNameCollection; //event name collection
        List<Color> colorCollection; //color collection



        public ViewModel()
        {
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

                    Appointments appointments = new Appointments();
                    appointments.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    appointments.To = (appointments.From.AddHours(1));
                    appointments.EventName = eventNameCollection[randomTime.Next(1)];
                    appointments.color = colorCollection[randomTime.Next(9)];
                    Appointments.Add(appointments);

            }
        }

        /// Creates event names collection
        private void CreateEventNameCollection()
        {
            eventNameCollection = new List<string>();

            eventNameCollection.Add("General Meeting");
            eventNameCollection.Add("Project Plan");
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseOnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
