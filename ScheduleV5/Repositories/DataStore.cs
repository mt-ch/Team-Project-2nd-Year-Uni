using System;
using Android.Content;
using Android.Database.Sqlite;

namespace ScheduleV5
{
    public class DataStore : SQLiteOpenHelper
    {
        private static string _databaseName = "savedInfoDB.db";
        public DataStore(Context context) : base ( context, _databaseName,null,1)
        {
             
        }

    

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(ScheduleHelper.createQuery);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL(ScheduleHelper.deleteQuery);
            OnCreate(db);
        }
    }
}
