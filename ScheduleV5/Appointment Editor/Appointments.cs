using System;
using Xamarin.Forms;
using SQLite;

namespace ScheduleV5
{
    public class Appointments
    {
        [PrimaryKey, AutoIncrement]
        public string EventName { get; set; }
        public string Organizer { get; set; }
        public string ContactID { get; set; }
        public int Capacity { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Color color { get; set; }
        public bool AllDay { get; set; }

    }
}
