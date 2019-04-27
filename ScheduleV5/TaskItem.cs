using SQLite;

namespace ScheduleV5
{
    public class TaskItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Task { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}