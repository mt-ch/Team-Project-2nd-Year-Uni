using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ScheduleV5
{
    public class TaskListDatabase
    {
          readonly SQLiteAsyncConnection database;

          public TaskListDatabase(string dbPath)
           {
               database = new SQLiteAsyncConnection(dbPath);
               database.CreateTableAsync<TaskItem>().Wait();
           }

          public Task<List<TaskItem>> GetItemAsync()
           {
               return database.Table<TaskItem>().ToListAsync();
           }

          public Task<List<TaskItem>> GetItemsNotDoneAsync()
           {
               return database.QueryAsync<TaskItem>("SELECT * FROM [TaskItem] WHERE [Done] = 0");
           }

          public Task<TaskItem> GetItemAsync(int id)
           {
               return database.Table<TaskItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
           }

          public Task<int> SaveItemAsync(TaskItem item)
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

          public Task<int> DeleteItemAsync(TaskItem item)
           {
               return database.DeleteAsync(item);
           }

    }
}
