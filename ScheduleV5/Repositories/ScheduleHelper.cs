using System;
using System.Collections.Generic;
using Android.Content;
using Android.Database;
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

        public static List<Appointments> GetAppointmentsList(Context context)
        {
            Appointments appoint = new Appointments();

            List<Appointments> appointments = new List<Appointments>();
            SQLiteDatabase db = new DataStore(context).ReadableDatabase;
            string[] columns = new string[] { columnEventName, columnOrganiser, columnID, columnCapacity, columnFrom, columnTo, columnAllDay, columnColor };

            using (ICursor cursor = db.Query(tableName, columns, null, null, null, null, null))
            {
                while (cursor.MoveToNext())
                {
                    appointments.Add(new Appointments
                    {
                        EventName = cursor.GetString(cursor.GetColumnIndexOrThrow(columnEventName)),
                        Organizer = cursor.GetString(cursor.GetColumnIndexOrThrow(columnOrganiser)),
                        ContactID = cursor.GetString(cursor.GetColumnIndexOrThrow(columnID)),
                        Capacity = cursor.GetInt(cursor.GetColumnIndexOrThrow(columnCapacity)),
                        //From = cursor.GetString(cursor.GetColumnIndexOrThrow(columnFrom)) //need to talk to matt

                    });
                }
            }
            db.Close();
            return appointments;
        }

        public static void DeleteAppointment (Context context, Appointments appointments)
        {
            SQLiteDatabase db = new DataStore(context).WritableDatabase;
            db.Delete(tableName, columnEventName + "=? OR " + columnOrganiser + "=? OR" + columnID + "=" + appointments.ContactID, new string[] { appointments.EventName, appointments.ContactID });
            db.Close();
        }

        public static Appointments SelectAppointment(Context context)
        {
            Appointments appointment;
            SQLiteDatabase db = new DataStore(context).WritableDatabase;
            string[] columns = new string[] { columnEventName, columnID, columnFrom, columnTo };
            string dateTime = DateTime.Now.ToString();
            string[] dt = dateTime.Split(' ');
            var date = dt[0];
            var tt = dt[1].Split(':');
            var time = tt[0] + ":" + tt[1] + " " + dt[2];

            using (ICursor cursor = db.Query(tableName, columns, columnFrom + "=? AND" + columnTo + " =?", new string[] { date, time }, null, null, null))
            {
                if (cursor.MoveToNext())
                {
                    appointment = new Appointments
                    {
                        EventName = cursor.GetString(cursor.GetColumnIndexOrThrow(columnEventName)),
                        ContactID = cursor.GetString(cursor.GetColumnIndexOrThrow(columnID)),
                        Organizer = cursor.GetString(cursor.GetColumnIndexOrThrow(columnOrganiser))
                    };
                }
                else
                {
                    appointment = null;
                }

            }
            return appointment;
        }
    }
}