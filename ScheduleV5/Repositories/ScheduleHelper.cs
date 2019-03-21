using Android.Content;
using Android.Database.Sqlite;

namespace ScheduleV5
{
    public class ScheduleHelper
    {
        private const string tableName = "ScheduleTable";
        private const string columnEventName = "EventName";
        private const string columnOrganiser = "Organiser";
        private const string columnID = "ContactID";
        private const string columnCapacity = "Capacity";
        private const string columnFrom = "From";
        private const string columnTo = "To";
        private const string columnAllDay = "AllDay";
        private const string columnColor = "Color";

        public const string createQuery = "CREATE TABLE " + tableName + "(" + columnEventName + " INTEGER PRIMARY KEY," + columnOrganiser + " TEXT," + columnID + " TEXT" + columnCapacity + " TEXT" + columnFrom + " TEXT" + columnTo + " TEXT)";
        public const string deleteQuery = "DROP TABLE IF EXISTS" + tableName;

        public ScheduleHelper()
        {
        }

        public static void InsertScheduleData(Context context, Appointments appointments)
        {
            SQLiteDatabase db = new DataStore(context).WritableDatabase;
            ContentValues contentValues = new ContentValues();
                contentValues.Put(columnEventName, appointments.EventName);
                contentValues.Put(columnOrganiser, appointments.Organizer);
                contentValues.Put(columnID, appointments.ContactID);
                contentValues.Put(columnCapacity, appointments.Capacity);
                contentValues.Put(columnFrom, appointments.From.ToString()); //temporary fix 
                contentValues.Put(columnTo, appointments.To.ToString());//temp fix 
                contentValues.Put(columnAllDay, appointments.AllDay);
            db.Insert(tableName, null, contentValues);
            db.Close();   
        }
    }
}