using System;
using Xamarin.Forms;
using SQLite;

namespace ScheduleV5
{
    public class Appointments
    {
        [PrimaryKey, AutoIncrement]
        public string Name { get; set; }
        public string Notes { get; set; }
        public int ID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Color color { get; set; }
        public bool AllDay { get; set; }
    }
}
