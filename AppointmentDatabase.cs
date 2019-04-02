using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ScheduleV5
{
    public class AppointmentDatabase
    {
        readonly SQLiteAsyncConnection database;

        public AppointmentDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Appointments>().Wait();
        }

        public Task<List<Appointments>> GetItemsAsync()
        {
            return database.Table<Appointments>().ToListAsync();
        }

        public Task<List<Appointments>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Appointments>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Appointments> GetItemAsync(int id)
        {
            return database.Table<Appointments>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Appointments item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Appointments item)
        {
            return database.DeleteAsync(item);
        }
    }
}
